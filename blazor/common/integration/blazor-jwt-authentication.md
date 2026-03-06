---
layout: post
title: JWT Authentication in Syncfusion® Blazor 
description: Guide to setting up JWT authentication for Syncfusion Blazor DataGrid with secure API access and token handling.
platform: Blazor
control: Common
documentation: ug
---

# JWT Authentication in Blazor

This guide walks you through creating a minimal, working Blazor JWT demo: an ASP.NET Core Web API that issues JWTs and a Blazor WebAssembly client that logs in, stores the token, and calls a protected API to display orders in a [Syncfusion DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid).

## Introduction to JWT

**JSON Web Token (JWT)**  is a compact, signed token containing claims that clients send as `Authorization: Bearer <token>` to authenticate API requests.

### Structure: Header, Payload, Signature

A JWT is three Base64Url-encoded parts separated by dots:

```
xxxxx.yyyy.zzzzz
```

- **Header** – declares the signing algorithm and token type (e.g., `{ "alg": "HS256", "typ": "JWT" }`).
- **Payload** – contains claims (e.g., `sub`, `name`, `role`, `exp`).
- **Signature** – computed using the header + payload + secret (or private key) to prevent tampering.

![Blazor DataGrid with jwt](../images/authentication.webp)

### Why JWT for Blazor?

- **Decoupled**: Works well when your Blazor client calls a separate API.
- **Stateless**: No server session to maintain; authorization is embedded in the token.
- **Interpretable**: Any client that can send HTTP headers can use it.

## Create a solution and projects

Create a solution with two projects: API (Minimal API) and Client (Blazor WASM).

{% tabs %}
{% highlight bash tabtitle="Terminal" %}

// Create solution folder and move into it
mkdir BlazorJwtDemo
cd BlazorJwtDemo
// Create a solution file
dotnet new sln -n BlazorJwtDemo
// Create a Web API (Minimal API)
dotnet new web -n Api
// Create a Blazor WebAssembly app
dotnet new blazorwasm -n Client
// Add both projects to the solution
dotnet sln add .\Api\Api.csproj
dotnet sln add .\Client\Client.csproj

{% endhighlight %}
{% endtabs %}

## Install NuGet packages

Install required packages for Web API and Blazor WebAssembly app

{% tabs %}
{% highlight bash tabtitle="Terminal" %}

# Api
cd Api
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer
dotnet add package System.IdentityModel.Tokens.Jwt

# Client
cd ..\Client
dotnet add package Microsoft.Extensions.Http
dotnet add package Microsoft.AspNetCore.Components.Authorization
dotnet add package System.IdentityModel.Tokens.Jwt
dotnet add package Blazored.LocalStorage
dotnet add package Syncfusion.Blazor
dotnet add package Syncfusion.Blazor.Themes
dotnet restore

{% endhighlight %}
{% endtabs %}

## Configuring the Backend API

Configure JWT bearer authentication and CORS in `Api/Program.cs`.

```csharp
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// CORS: allow the Blazor client dev origin.
const string CorsPolicy = "DevClient";
builder.Services.AddCors(options =>
{
    options.AddPolicy(CorsPolicy, policy =>
        policy.WithOrigins("http://localhost:XXXX") // your WASM dev URL.
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials());
});

// JWT setup (use secure secrets in production!).
var jwtKey   = builder.Configuration["Jwt:Key"]     ?? "dev-secret-key-change-me-please-123456";
var issuer   = builder.Configuration["Jwt:Issuer"]  ?? "SyncGridJwtDemo";
var audience = builder.Configuration["Jwt:Audience"]?? "SyncGridJwtDemoAudience";
var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false; 
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = issuer,
        ValidAudience = audience,
        IssuerSigningKey = signingKey,
        ClockSkew = TimeSpan.FromSeconds(5)
    };
});

builder.Services.AddAuthorization();

var app = builder.Build();
app.UseCors(CorsPolicy);
app.UseAuthentication();
app.UseAuthorization();
app.Run();

```

### Token generation

Implement a POST endpoint /api/auth/login in `Api/Program.cs` that validates credentials, builds claims, signs a JWT, and returns it.

```csharp

// Issue access token (and, optionally, refresh token).
app.MapPost("/api/auth/login", ([FromBody] LoginRequest req) =>
{
    if (string.IsNullOrWhiteSpace(req.Username) || string.IsNullOrWhiteSpace(req.Password))
        return Results.BadRequest("Username/password required");

    // Demo credentials. Replace with identity store.
    if (req.Username == "admin" && req.Password == "admin123")
    {
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, req.Username),
            new Claim(ClaimTypes.Name, req.Username),
            new Claim(ClaimTypes.Role, "Admin")
        };

        var creds = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(30),
            signingCredentials: creds);

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);

        return Results.Ok(new { token = jwt });
    }

    return Results.Unauthorized();
});

public record LoginRequest(string Username, string Password);
// Protected data endpoint.
public record Order(int OrderID, string CustomerID, string ShipCountry)
{
    public static List<Order> Seed() => new()
    {
        new(10001, "ALFKI", "Germany"),
        new(10002, "ANATR", "Brazil"),
        new(10003, "ANTON", "Mexico"),
        new(10004, "BERGS", "Sweden"),
        new(10005, "BLONP", "France"),
    };
}
```

### Validation

The `AddJwtBearer` configuration ensures tokens are checked for:
- Correct **issuer** and **audience**
- **Signature** with your signing key
- **Expiration**

## Blazor WebAssembly Client Configuration

This section explains how to configure your Blazor WebAssembly (WASM) app to use JWT authentication, Syncfusion UI components, local storage, and a secured HttpClient that automatically attaches the JWT to every API request.

### Client Setup

Register Syncfusion, local storage, auth state provider, and an `HttpClient` that attaches the JWT in `Client/Program.cs`.

```csharp
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Syncfusion.Blazor;
using System.Net.Http.Headers;
using Client.Services;
using Client;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");

builder.Services.AddSyncfusionBlazor();

builder.Services.AddAuthorizationCore();

builder.Services.AddBlazoredLocalStorage();

builder.Services.AddTransient<AuthMessageHandler>();

var apiBase = new Uri("http://localhost:XXXX/");

builder.Services.AddHttpClient("ApiClient", client =>
{
    client.BaseAddress = apiBase;
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
})
.AddHttpMessageHandler<AuthMessageHandler>();

await builder.Build().RunAsync();
```

### AuthMessageHandler – Attach JWT

This handler reads the JWT from local storage and attaches it to outgoing HTTP requests in `Client/Services/AuthMessageHandler.cs`

```csharp
using System.Net.Http.Headers;
using Blazored.LocalStorage;

namespace Client.Services
{
    public class AuthMessageHandler : DelegatingHandler
    {
        private readonly ILocalStorageService storage;
        public AuthMessageHandler(ILocalStorageService storage) => this.storage = storage;

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken ct)
        {
            var token = await storage.GetItemAsync<string>("jwtToken");
            if (!string.IsNullOrWhiteSpace(token))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            var response = await base.SendAsync(request, ct);
            return response;
        }
    }
}
```

### Login Page – Authenticate and Store JWT

Create a simple login UI that posts credentials to the API and saves the JWT into local storage in `Client/Pages/Login.razor`.

{% tabs %}
{% highlight razor tabtitle="Login.razor" %}

@page "/login"
@using Microsoft.Extensions.DependencyInjection
@inject IHttpClientFactory ClientFactory
@inject Blazored.LocalStorage.ILocalStorageService Storage
@inject NavigationManager Nav

<h3>Login</h3>
@if (!string.IsNullOrWhiteSpace(message))
{
    <div style="color:red">@message</div>
}

<div class="card p-3" style="max-width:420px">
    <div class="mb-2">
        <label>Username</label>
        <input @bind="username" class="form-control" />
    </div>
    <div class="mb-2">
        <label>Password</label>
        <input @bind="password" type="password" class="form-control" />
    </div>
    <button class="btn btn-primary" @onclick="LoginAsync">Login</button>
    <button class="btn btn-secondary ms-2" @onclick="Logout">Logout</button>
</div>

@code {
    private string? username;
    private string? password;
    private string? message;

    private async Task Logout()
    {
        await Storage.RemoveItemAsync("jwtToken");
        Nav.NavigateTo("/login", forceLoad: true);
    }

    private async Task LoginAsync()
    {
        try
        {
            var client = ClientFactory.CreateClient("ApiClient");
            var resp = await client.PostAsJsonAsync("api/auth/login", new { Username = username, Password = password });
            if (resp.IsSuccessStatusCode)
            {
                var json = await resp.Content.ReadFromJsonAsync<TokenResponse>();
                if (!string.IsNullOrWhiteSpace(json?.token))
                {
                    await Storage.SetItemAsync("jwtToken", json!.token);
                    Nav.NavigateTo("/orders", true);
                    return;
                }
            }
            message = "Invalid credentials";
        }
        catch (Exception ex)
        {
            message = ex.Message;
        }
    }
    public class TokenResponse { public string? token { get; set; } }
}

{% endhighlight %}
{% endtabs %}

### Add Syncfusion Assets and Imports

**Add Syncfusion CSS & script**

Include the stylesheet reference in the <head> section and the script reference at the end of the <body> in `wwwroot/index.html`.

```html
<head>
    ....
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
</head>

<body>
    ....
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
</body>
```

**Add Import Namespaces**

Open the `Client/_Imports.razor` file in the client project and import the namespaces.

{% tabs %}
{% highlight razor tabtitle="~/_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.Grids

{% endhighlight %}
{% endtabs %}

### Add Syncfusion DataGrid

This page loads Syncfusion Datagrid orders from a protected API endpoint using the JWT-bearing HttpClient in `Client/Pages/Orders.razor`.

{% tabs %}
{% highlight razor tabtitle="Orders.razor" %}

@page "/orders"
@using Syncfusion.Blazor.Grids
@inject IHttpClientFactory ClientFactory

<h3>Orders</h3>
<SfGrid TValue="Order" AllowPaging="true" AllowSorting="true" Height="400px">
    <SfDataManager Url="api/orders" Adaptor="Adaptors.UrlAdaptor" HttpClientInstance="@_apiClient" />
    <GridColumns>
        <GridColumn Field="OrderID" HeaderText="Order ID" Width="120" />
        <GridColumn Field="CustomerID" HeaderText="Customer" Width="150" />
        <GridColumn Field="ShipCountry" HeaderText="Country" Width="150" />
    </GridColumns>
</SfGrid>

@code {
    private HttpClient? _apiClient;
    protected override void OnInitialized() => _apiClient = ClientFactory.CreateClient("ApiClient");

    public class Order { public int OrderID { get; set; } public string? CustomerID { get; set; } public string? ShipCountry { get; set; } }
}

{% endhighlight %}
{% endtabs %}

## Run and Test the Application

Follow these steps to verify that your API and Blazor WebAssembly client work together with JWT authentication and the Syncfusion DataGrid.

1. Start the API
    * Open a terminal in the API project folder.
    * Run the command: `dotnet run`.
    * The API will start and listen on its configured URL.
2. Start the Blazor Client  
    * Open a terminal in the Client project folder.
    * Run the command: `dotnet run`.
    * The Blazor dev server will display a local URL—open it in the browser. 
3. Login
    * Navigate to /login on the client app.
    * Sign in using:
            Username: admin
            Password: admin123
    * After logging in, the JWT token is saved in local storage.
admin / admin123.
4. View Protected Data
    * Navigate to /orders.
    * The Syncfusion DataGrid now loads protected API data using the stored JWT.

![Blazor DataGrid with jwt output](../images/jwt-with-datagrid.webp)