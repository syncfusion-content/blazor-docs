---
layout: post
title: Blazor with JWT Authentication | Syncfusion®
description: Guide to setting up JWT authentication for Syncfusion® Blazor DataGrid with secure API access and token handling.
platform: Blazor
control: Common
documentation: ug
---

# Securing Syncfusion® Blazor DataGrid with JWT Authentication

This guide shows how to secure the [Syncfusion® Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) in a **Blazor Web App** with **Interactive Server** using [JWT (JSON Web Token)](https://www.jwt.io/introduction) authentication.

## Create a Blazor project

If you already have a Blazor project configured, you can skip this section and proceed to [Install required packages](./blazor-jwt-authentication#install-required-packages).

Otherwise, create a new Blazor application by following the [Syncfusion® getting started guide](https://blazor.syncfusion.com/documentation/getting-started/blazor-web-app) for a **Blazor Web App (Interactive Server)**.

Ensure that **HTTPS is enabled** during project creation, as JWT based authorization requires secure communication.

## Install required packages

Install the following NuGet packages to use the **Syncfusion® Blazor DataGrid** and enable **JWT** authentication.

**Syncfusion® packages:**

- [Syncfusion.Blazor.Grid](https://www.nuget.org/packages/Syncfusion.Blazor.Grid/)
- [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/)

**JWT package:**

- [Microsoft.AspNetCore.Authentication.JwtBearer](https://www.nuget.org/packages/Microsoft.AspNetCore.Authentication.JwtBearer)

You can install the required packages by using the following .NET CLI commands.

{% tabs %}
{% highlight bash tabtitle=".NET CLI" %}

dotnet add package Syncfusion.Blazor.Grid -v {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Themes -v {{ site.releaseversion }}
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer

{% endhighlight %}
{% endtabs %}

## Add Syncfusion® namespaces

Open the `~/_Imports.razor` file and import the Syncfusion® namespaces.

{% tabs %}
{% highlight razor tabtitle="~/_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Data

{% endhighlight %}
{% endtabs %}

## Add stylesheet and Interactive Server routing

Include the Syncfusion® theme stylesheet, required script references, and configure Interactive Server rendering in the `App.razor` file. 

{% tabs %}
{% highlight razor tabtitle="App.razor" %}

<head>
    ....
    <!-- Syncfusion® theme stylesheet -->
    <link href="_content/Syncfusion.Blazor.Themes/fluent2.css" rel="stylesheet" />
    ....
</head>

<body>
    ....
    <!-- Enable Interactive Server rendering -->
    <Routes @rendermode="InteractiveServer" />
    <!-- Syncfusion® Blazor core script (required for UI components, including DataGrid) -->
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
    ....
</body>

{% endhighlight %}
{% endtabs %}

## Configuring JWT in appsettings.json

The **JWT** configuration specifies how the server signs and validates authentication tokens.

{% tabs %}
{% highlight json tabtitle="appsettings.json" %}

{
  "Jwt": {
    // Secret key used to create and validate JWT tokens; you can set your own random string with at least 32 characters.
    "Key": "REPLACE_WITH_A_LONG_RANDOM_SECRET_32+_CHARS", 
    "Issuer": "BlazorJWT",
    "Audience": "BlazorJWTClient"
  }
}

{% endhighlight %}
{% endtabs %}

N> For production environments, do not store secrets directly in `appsettings.json`. Use environment variables or a secure secret store such as **Azure Key Vault** to protect sensitive information.

## Generating a JWT token

This section demonstrates how to generate a **JWT** token on the server by using a custom `TokenService` class.

{% tabs %}
{% highlight c# tabtitle="Services/TokenService.cs"  %}

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;

namespace YourProjectName.Services 
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

{% endhighlight %}
{% endtabs %}

## Getting the token

This section describes how the application issues a **JSON Web Token (JWT)** for authenticated access. The `AuthController` class provides an API endpoint that generates and returns a JWT for the requesting user.

{% tabs %}
{% highlight c# tabtitle="~/Controllers/AuthController.cs"  %}

using YourProjectName.Services;
using Microsoft.AspNetCore.Mvc;

namespace YourProjectName.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly TokenService _tokenService;
    public AuthController(TokenService tokenService) => _tokenService = tokenService;


    // This endpoint is intended for demonstration purposes only. 
    // For production, you can use validation mechanisms such as verifying user credentials before issuing tokens.

    [HttpPost("token")]
    public IActionResult Token([FromQuery] string user = "user123")
    {
        var jwt = _tokenService.IssueToken(user, name: user);
        return Ok(new { token = jwt });
    }
}

{% endhighlight %}
{% endtabs %}

## Adding JWT middleware

Register **JWT** authentication and authorization middleware to validate incoming API requests. Add these configurations in `Program.cs`.

{% tabs %}
{% highlight csharp tabtitle="~/Program.cs" %}

using System.Text;
using YourProjectName.Components;
using YourProjectName.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddControllers();
builder.Services.AddHttpClient();

// Register the Syncfusion® Blazor service 
builder.Services.AddSyncfusionBlazor();

var jwtKey = builder.Configuration["Jwt:Key"] ?? throw new InvalidOperationException("Jwt:Key missing");
var jwtIssuer = builder.Configuration["Jwt:Issuer"] ?? throw new InvalidOperationException("Jwt:Issuer missing");
var jwtAudience = builder.Configuration["Jwt:Audience"] ?? throw new InvalidOperationException("Jwt:Audience missing");

if (jwtKey.Length < 32)
{
    throw new InvalidOperationException("Jwt:Key must be at least 32 characters for HS256 algorithm");
}

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
            ValidIssuer = jwtIssuer,
            ValidAudience = jwtAudience,
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

## Create sample data model

Create sample records for the DataGrid in `~/Models/OrdersDetails.cs` file.

{% tabs %}
{% highlight c# tabtitle="~/Models/OrdersDetails.cs"  %}

namespace YourProjectName.Models;  

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
                ShipCity = i % 2 == 0 ? "New York" : "Los Angeles",
                ShipCountry = "USA"
            }).ToList();
        }
        return _data;
    }
}

{% endhighlight %}
{% endtabs %}

## Protecting the Syncfusion® Blazor DataGrid API

This section explains how the **Syncfusion® Blazor DataGrid** API endpoint is secured to allow access only to authenticated requests. The `Authorize` attribute enforces token based access to DataGrid data.

{% tabs %}
{% highlight c# tabtitle="~/Controllers/GridController.cs"  %}

using YourProjectName.Models;  
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.Blazor;
using Syncfusion.Blazor.Data;

namespace YourProjectName.Controllers;

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

{% endhighlight %}
{% endtabs %}

## Adding JWT to Syncfusion® Blazor DataManager headers

This example demonstrates how a **JWT** token is retrieved from the server and attached to the **Syncfusion® Blazor DataManager** as an HTTP Authorization header. This ensures that the **DataGrid** loads data only from a secured API after the user has been authenticated.

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

@page "/"
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Data
@using YourProjectName.Models
@inject HttpClient Http
@inject NavigationManager Nav

<h3>JWT‑Secured Syncfusion® Blazor DataGrid</h3>

<button class="btn btn-primary" style="margin-bottom: 15px" @onclick="LoadGridWithToken">Load GridData</button>

@if (!string.IsNullOrEmpty(error))
{
    <div class="alert alert-danger" role="alert">
        <strong>Error:</strong> @error
    </div>
}

<SfGrid TValue="OrdersDetails" @ref="grid" AllowPaging="true" AllowSorting="true" Width="100%">
    @* Only render the DataManager after the token is fetched. *@
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

## Run the application

Run the application using the following command:

{% tabs %}
{% highlight bash tabtitle=".NET CLI" %}

dotnet run

{% endhighlight %}
{% endtabs %}

After the application starts, click the **Load GridData** button to initiate authentication. The application requests a **JWT** token, attaches it to the **DataManager** request, and then securely loads data from the authorized API endpoint into the **Syncfusion® Blazor DataGrid**.

![Blazor DataGrid with JWT](images/jwt-authentication.webp)

## See also

- [Configure JWT bearer authentication in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/security/authentication/configure-jwt-bearer-authentication?view=aspnetcore-10.0)
- [Getting started with Syncfusion® Blazor DataGrid in Web App](https://blazor.syncfusion.com/documentation/datagrid/getting-started-with-web-app)
- [Getting started with JSON Web Token](https://www.jwt.io)
- [Getting started with Syncfusion® Blazor DataManager in Web App](https://blazor.syncfusion.com/documentation/data/getting-started-with-web-app)

