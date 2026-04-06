---
layout: post
title: Blazor with JWT Authentication | Syncfusion®
description: Guide to setting up JWT authentication for Syncfusion® Blazor DataGrid with secure API access and token handling.
platform: Blazor
control: Common
documentation: ug
---

# Blazor with JWT Authentication

This guide shows how to secure the [Syncfusion® Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) in a **Blazor Web App** with **Interactive Server** using **JWT (JSON Web Token)** authentication.

## What is JWT (JSON Web Token)?

A JSON Web Token (JWT) is a compact, digitally signed string that identifies a user and authorizes API calls. It has three parts:

- **Header** – specifies the token type and the signing algorithm used.
- **Payload** – contains claims (e.g., `sub`, `name`, `role`, `exp`).
- **Signature** – computed using the header, payload, and secret (or private key) to prevent tampering.

## Why use JWT in Blazor?

Syncfusion® components make HTTP requests to your API internally. JWT allows each request  to carry a trusted identity and prevents unauthorized access without relying on server-side session state.

**Benefits of using JWT in Blazor applications**

JWT allows users to log in once and securely access APIs, controls features based on user roles, maintain authentication while navigating between pages, ensure secure communication between client and server, and supports large‑scale applications without storing login sessions on the server.

## Create a Blazor web app (Interactive Server)

1. Open **Visual Studio**.
2. Select **Create a new project**.
3. In the Create a new project dialog:
    - Choose **Blazor Web App**.
    - Click **Next**.
4. In Configure your new project:
    - Enter a **Project name**.
    - Choose a **Location**.
    - Click **Next**.
5. In the Additional information screen, configure the following:
    - **Framework**: Select **.NET 8.0** (or .NET (Latest) if available in your Visual Studio version).
    - **Authentication type**: Select **None** (JWT will be configured manually in later steps).
    - **Interactive mode**: Select **Server**.
    - **Interactivity location**: Select **Per page/component**.
    - **Enable HTTPS**.
6. Click **Create** to generate the Blazor Web App.

## Add JWT authentication

This section explains how to enable JWT authentication in your Blazor Web App. 

### Install required packages for JWT

To enable JWT authentication in the application, open the NuGet Package Manager in Visual Studio from (*Tools → NuGet Package Manager → Manage NuGet Packages for Solution*), and install the required package.

- [Microsoft.AspNetCore.Authentication.JwtBearer](https://www.nuget.org/packages/Microsoft.AspNetCore.Authentication.JwtBearer)

### Configuring JWT in appsettings.json

The JWT configuration specifies how the server signs and validates authentication tokens.

```json
{
  "Jwt": {
    "Key": "REPLACE_WITH_A_LONG_RANDOM_SECRET_32+_CHARS", 
    "Issuer": "BlazorJWT",
    "Audience": "BlazorJWTClient"
  }
}
```

N> For production environments, do not store secrets directly in `appsettings.json`. Use environment variables or a secure secret store such as **Azure Key Vault** to protect sensitive information.

### Generating a JWT token

This section demonstrates how to generate a JWT token on the server by using a custom **TokenService** class in `Services/TokenService.cs`.

```csharp
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;

namespace BlazorJWT.Services
{
    public class TokenService
    {
        private readonly IConfiguration _config;
        public TokenService(IConfiguration config) => _config = config;

        public string IssueToken(string subjectUserId, string? name = null)
        {
            var issuer = _config["Jwt:Issuer"]!;
            var audience = _config["Jwt:Audience"]!;
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Sub, subjectUserId),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            if (!string.IsNullOrWhiteSpace(name))
            {
                claims.Add(new Claim(ClaimTypes.Name, name));
            }

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                notBefore: DateTime.UtcNow.AddMinutes(-1),
                expires: DateTime.UtcNow.AddMinutes(30),
                signingCredentials: creds);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
```
### Getting the token

This section describes how the application issues a JSON Web Token (JWT) for authenticated access. The **AuthController** class provides an API endpoint that generates and returns a JWT for the requesting user.

```csharp
// ~/Controllers/AuthController.cs
using BlazorJWT.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlazorJWT.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly TokenService _tokenService;
    public AuthController(TokenService tokenService) => _tokenService = tokenService;

    [HttpPost("token")]
    public IActionResult Token([FromQuery] string user = "user123")
    {
        var jwt = _tokenService.IssueToken(user, name: user);
        return Ok(new { token = jwt });
    }
}

```
### Adding JWT middleware

Register JWT authentication and authorization middleware to validate incoming API requests. Add these configurations in `Program.cs`.

{% tabs %}
{% highlight razor tabtitle="~/Program.cs" %}

using System.Text;
using BlazorJWT.Components;
using BlazorJWT.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddControllers();
builder.Services.AddHttpClient();
builder.Services.AddSyncfusionBlazor();

var jwtKey = builder.Configuration["Jwt:Key"] ?? throw new InvalidOperationException("Jwt:Key missing");

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.FromMinutes(5),
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
        };
    });

builder.Services.AddAuthorization();
builder.Services.AddSingleton<TokenService>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();
app.UseAntiforgery();
app.MapControllers();
app.MapRazorComponents<App>()
   .AddInteractiveServerRenderMode();
app.Run();

{% endhighlight %}
{% endtabs %}

## Connecting Syncfusion® DataGrid with JWT token

This section shows how to fetch a JWT token from the server, attach it to Syncfusion® DataManager requests and securely load data into the DataGrid using authenticated API calls.

**1. Install Syncfusion® Blazor DataGrid and themes NuGet packages**

To add the Blazor DataGrid in the app, open the NuGet Package Manager in Visual Studio (*Tools → NuGet Package Manager → Manage NuGet Packages for Solution*), search and install [Syncfusion.Blazor.Grid](https://www.nuget.org/packages/Syncfusion.Blazor.Grid/)* and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/).

**2. Add Syncfusion® namespaces**

Open the `~/_Imports.razor` file and import the Syncfusion® namespaces.

{% tabs %}
{% highlight razor tabtitle="~/_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Data

{% endhighlight %}
{% endtabs %}

**3. Register the Syncfusion® Blazor service**

Add the Syncfusion® Blazor service to the `~/Program.cs` file to enable Syncfusion® components in the application.

{% tabs %}
{% highlight razor tabtitle="~/Program.cs" %}

using Syncfusion.Blazor;
 
builder.Services.AddSyncfusionBlazor();

{% endhighlight %}
{% endtabs %}

**4. Add stylesheet and script resources**

Include the theme stylesheet and script references in the `App.razor` file.

{% tabs %}
{% highlight html  %}

<head>
    <!-- Syncfusion theme stylesheet -->
    <link href="_content/Syncfusion.Blazor.Themes/fluent2.css" rel="stylesheet" />
</head>

<body>
    <!-- Syncfusion Blazor DataGrid component's script reference -->
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
</body>

{% endhighlight %}
{% endtabs %}

### Create sample data model

Create sample records for the DataGrid in `~/Models/OrdersDetails.cs` file.

```csharp
namespace BlazorJWT.Models;

public class OrdersDetails
{
    public int OrderID { get; set; }
    public string? CustomerID { get; set; }
    public string? ShipCity { get; set; }
    public string? ShipCountry { get; set; }
    private static List<OrdersDetails>? _data;
    public static List<OrdersDetails> GetAllRecords()
    {
        if (_data is null)
        {
            _data = Enumerable.Range(1, 50).Select(i => new OrdersDetails
            {
                OrderID = i,
                CustomerID = $"CUST-{i:000}",
                ShipCity = i % 2 == 0 ? "Chennai" : "Bengaluru",
                ShipCountry = "India"
            }).ToList();
        }
        return _data;
    }
}

```
### Protecting the Syncfusion® DataGrid API

This section explains how the Syncfusion® DataGrid API endpoint is secured to allow access only to authenticated requests. The `Authorize` attribute enforces token based access to Grid data.

```csharp
// ~/Controllers/GridController.cs
using BlazorJWT.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.Blazor.Data;

namespace BlazorJWT.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
[IgnoreAntiforgeryToken] // DataManager uses bearer token authentication; antiforgery tokens are not applicable for API endpoints using JWT.
public class GridController : ControllerBase
{
    [HttpPost]
    public IActionResult Post([FromBody] DataManagerRequest dm)
    {
        var data = OrdersDetails.GetAllRecords().AsQueryable();
        var total = data.Count();
        return Ok(new { result = data.ToList(), count = total });
    }
}
```

###  Requesting token and loading Syncfusion® DataGrid

This section explains how the Blazor component requests the JWT token and refreshes the DataGrid after authentication.

```csharp
var tokenRes = await Http.PostAsync("api/auth/token?user=username", null);
jwt = json["token"];
isDataManagerEnabled = true;
await grid.Refresh();
```

### Adding JWT to Syncfusion® DataManager headers

Attach the JWT token to HTTP headers so the DataManager can send authenticated requests.

{% tabs %}
{% highlight razor %}

@page "/"
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Data
@using BlazorJWT.Models
@inject HttpClient Http
@inject NavigationManager Nav

<h3>JWT + Syncfusion DataGrid (Click to Load)</h3>

<button class="btn btn-primary" @onclick="LoadGridWithToken">Load GridData</button>

<SfGrid TValue="OrdersDetails" @ref="grid" AllowPaging="true" AllowSorting="true" Width="100%">
    // Only render the DataManager after the token is fetched.
    @if (isDataManagerEnabled)
    {
        <SfDataManager Url="api/grid" Adaptor="Adaptors.UrlAdaptor" Headers="HeaderData" />
    }
    <GridColumns>
        <GridColumn Field=@nameof(OrdersDetails.OrderID) HeaderText="Order ID" Width="120" TextAlign="TextAlign.Center" />
        <GridColumn Field=@nameof(OrdersDetails.CustomerID) HeaderText="Customer" Width="150" />
        <GridColumn Field=@nameof(OrdersDetails.ShipCity) HeaderText="City" Width="150" />
    </GridColumns>
</SfGrid>

@code {
    private SfGrid<OrdersDetails>? grid;
    // DataManager is enabled only after token is retrieved.
    private bool isDataManagerEnabled = false;
    private string? jwt;
    private string? error;
    private IDictionary<string, string> HeaderData => new Dictionary<string, string>
    {
        ["Authorization"] = string.IsNullOrEmpty(jwt) ? "" : $"Bearer {jwt}"
    };
    // Ensure jwt is set before the DataManager is rendered; otherwise headers may be empty.
    private async Task LoadGridWithToken()
    {
        error = null;
        try
        {
            var baseUri = new Uri(Nav.BaseUri);
            var tokenRes = await Http.PostAsync(new Uri(baseUri, "api/auth/token?user=username"), content: null);
            tokenRes.EnsureSuccessStatusCode();
            var json = await tokenRes.Content.ReadFromJsonAsync<Dictionary<string, string>>();
            jwt = json!["token"];
            isDataManagerEnabled = true;
            StateHasChanged();
            await Task.Yield();
            if (grid is not null)
            {
                await grid.Refresh(); // Triggers the first data request using the DataManager and headers.
            }
        }
        catch (Exception ex)
        {
            error = ex.Message;
            isDataManagerEnabled = false;
        }
    }
}

{% endhighlight %}
{% endtabs %}

The complete application flow ensures the **DataGrid** loads only after the user is authenticated using a valid JWT.

## See also

- [Configure JWT bearer authentication in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/security/authentication/configure-jwt-bearer-authentication?view=aspnetcore-10.0)

- [Getting started with Blazor DataGrid in Web app](https://blazor.syncfusion.com/documentation/datagrid/getting-started-with-web-app)