---
layout: post
title: Using Syncfusion Blazor with JWT Authentication
description: Guide to setting up JWT authentication for Syncfusion Blazor DataGrid with secure API access and token handling.
platform: Blazor
control: Common
documentation: ug
---

# Using Blazor with JWT Authentication

This guide shows how to secure the [Syncfusion Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) in a Blazor Web App with Interactive Server rendering using JWT (JSON Web Token) authentication. You will configure JWT on the server, request a token from the client, attach it to Syncfusion DataManager requests, and protect your grid API with `Authorize` attribute.

## What is JWT (JSON Web Token)?

A JSON Web Token (JWT) is a compact, digitally signed string that identifies a user and authorizes API calls. It contains claims (such as user ID and name) and an expiry, so the server can trust the request for a limited time.

### Structure: Header, Payload, Signature

A JWT contains three parts:

- **Header** – declares the signing algorithm and token type (e.g., `{ "alg": "HS256", "typ": "JWT" }`).
- **Payload** – contains claims (e.g., `sub`, `name`, `role`, `exp`).
- **Signature** – computed using the header + payload + secret (or private key) to prevent tampering.

## Why Use JWT in Blazor?

Syncfusion components make HTTP requests to your API under the hood. JWT attaches a trusted identity to each request and prevents unauthorized access without relying on server‑side session state.

## Create a Blazor Web App (Interactive Server)

Create a new **Blazor Web App** and select **Interactive Server** rendering. Install the Syncfusion Blazor packages, and add the required style and script references as outlined in the [Getting started](https://blazor.syncfusion.com/documentation/getting-started/blazor-web-app?tabcontent=visual-studio) documentation.


## Add JWT Authentication

This section explains how to enable JWT authentication in your Blazor Web App. 

### Configuring JWT in appsettings.json

In this step, you define the JWT settings that the server uses to sign and validate authentication tokens.

```csharp
{
  "Jwt": {
    "Key": "REPLACE_WITH_A_LONG_RANDOM_SECRET_32+_CHARS",
    "Issuer": "BlazorJWT",
    "Audience": "BlazorJWTClient"
  }
}

```

### Install Required Packages for JWT

In **Tools → NuGet Package Manager → Manage NuGet Packages for Solution**, install:

```csharp
Microsoft.AspNetCore.Authentication.JwtBearer;
```

### Token generation

This part explains how to generate a JWT token on the server using a custom TokenService in `Services/TokenService.cs`.

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
### Getting the Token (AuthController.cs)

AuthController exposes an API endpoint that returns a JWT token for the requesting user in `~/Controllers/AuthController.cs`.

```csharp
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
### Adding JWT Middleware 

This step registers the JWT authentication and authorization middleware so that API requests can be validated in `Program.cs`.

```csharp
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

var jwtKey = builder.Configuration["Jwt:Key"]
    ?? throw new InvalidOperationException("Jwt:Key missing");

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
            ClockSkew = TimeSpan.FromMinutes(2),
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

```

## Connecting Syncfusion DataGrid with JWT Token

This section shows how to fetch a JWT token from the server, attach it to Syncfusion DataManager requests and securely load data into the DataGrid using authenticated API calls.

### Create Sample Data Model

Create sample records for the DataGrid to display in `~/Models/OrdersDetails.cs`.

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
### Protecting the Syncfusion DataGrid API

This step secures the API endpoint used by the DataGrid so only authenticated requests can access data. The `Authorize` attribute ensures only users with a valid token can load grid data in `~/Controllers/GridController.cs`.

```csharp
using BlazorJWT.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.Blazor.Data;

namespace BlazorJWT.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
// [IgnoreAntiforgeryToken] // Optional: see CSRF note
public class GridController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
        => BadRequest("Use POST for DataManager requests.");

    [HttpPost]
    public IActionResult Post([FromBody] DataManagerRequest dm)
    {
        var data = OrdersDetails.GetAllRecords().AsQueryable();
        var total = data.Count();
        return Ok(new { result = data.ToList(), count = total });
    }
}
```


###  Requesting Token and Loading Syncfusion DataGrid

This section explains how the Blazor component requests the JWT token and refreshes the DataGrid after authentication.

```csharp

var tokenRes = await Http.PostAsync("api/auth/token?user=username", null);
jwt = json["token"];
isDataManagerEnabled = true;
await grid.Refresh();
```

### Adding JWT to Syncfusion DataManager Headers

Here you attach the JWT token to HTTP headers so the DataManager can send authenticated API requests.

```csharp
// Razor page
@page "/"
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Data
@using BlazorJWT.Models
@inject HttpClient Http
@inject NavigationManager Nav

<h3>JWT + Syncfusion Grid (Click to Load)</h3>

<button class="btn btn-primary" @onclick="LoadGridWithToken">Load Grid Data</button>

<!-- Grid is always visible, but no data is fetched until the button is clicked -->
<SfGrid TValue="OrdersDetails" @ref="grid" AllowPaging="true" AllowSorting="true" Width="100%">
    @* Only render the DataManager after the token is fetched *@
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
    // Grid is visible; DataManager is enabled only after token is retrieved.
    private bool isDataManagerEnabled = false;
    private string? jwt;
    private string? error;
    private IDictionary<string, string> HeaderData => new Dictionary<string, string>
    {
        ["Authorization"] = string.IsNullOrEmpty(jwt) ? "" : $"Bearer {jwt}"
    };
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
                await grid.Refresh(); // Triggers the first data request using the DataManager and headers
            }
        }
        catch (Exception ex)
        {
            error = ex.Message;
            isDataManagerEnabled = false;
        }
    }
}
```
The complete application flow ensures the grid loads only after the user is authenticated using a valid JWT.