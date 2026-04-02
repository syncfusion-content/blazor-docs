---
layout: post
title: Authentication and Authorization with AWS Cognito in Syncfusion Blazor
description: Authenticate a Blazor Server app with AWS Cognito (OIDC Hosted UI) and secure Syncfusion components.
platform: Blazor
control: Common
documentation: ug
---

# Authentication and Authorization with AWS Cognito in Blazor Server

AWS Cognito User Pools provide a managed identity system that supports OpenID Connect (OIDC), OAuth 2.0, JSON Web Tokens (JWTs), Multi-Factor Authentication (MFA), user attributes, and group-based roles. This guide explains how to integrate a Blazor Server application with Cognito using Authorization Code Flow with Proof Key for Code Exchange (PKCE) through the Hosted UI, configure roles, and secure Syncfusion Blazor UI components.

## What is AWS?

Amazon Web Services (AWS) is a cloud platform providing compute, storage, and identity services. For Blazor developers, its key identity service is Amazon Cognito, which handles sign-up, sign-in, Multi-Factor Authentication (MFA), token issuance, and issuing temporary AWS credentials through AWS Identity and Access Management (IAM). Cognito also exposes a managed login interface (Hosted UI) and standard OpenID Connect (OIDC) endpoints.

## Why Amazon Cognito for Blazor?

* Standards-based OIDC integrates directly with ASP.NET Core's built-in OpenID Connect middleware for Blazor Server. This is the Microsoft-recommended approach and requires no third-party authentication libraries. 
* Supports login with MFA and password policies, reducing custom auth UI work. 
* Emits `cognito:groups` in tokens for role-based authorization in your app and API. 
* Identity Pools can exchange a user's ID token for time-limited AWS credentials to call S3, DynamoDB, etc.

## Cognito building blocks

* **User Pools:** Managed user directory + OIDC authorization server (tokens, Hosted UI, MFA, groups). Use this to authenticate users and obtain ID/Access tokens for your app and APIs. 
* **Identity Pools (Federated Identities):** Optional service that exchanges a trusted identity for example User Pool ID token for temporary AWS credentials through IAM roles. Use this when the server must call AWS services (such as Amazon S3 and Amazon DynamoDB) on behalf of the user.

## Password policies

In **User Pool → Sign-in experience**:
* Configure **Password policy** (length, complexity, expiration).  
* Set MFA to Off, Optional, or Required; choose **SMS** or **TOTP** enrollment.  
* Hosted UI prompts users according to your policy.  

## Role-based authorization with Cognito groups

* Create groups (e.g., `Admin`) in **User Pool → Groups** and add users.  
* Ensure **Group membership** is included in tokens.  
* Map roles using `RoleClaimType = "cognito:groups"` and protect pages/endpoints with `[Authorize(Roles="Admin")]`. 

## Prerequisites

* .NET SDK 8.0 or later (this guide uses .NET 10.0)
* Visual Studio 2022 or Visual Studio Code with [C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit) extension 
* AWS Account with permission to manage Cognito

## Integrating Cognito with Blazor

Configure OpenID Connect with the Cognito Hosted UI (Authorization Code + PKCE), which Microsoft's docs show for any OIDC provider in Blazor Web Apps.

### Create a Blazor Server Project

If you already have a Blazor project, proceed to the **Install Authentication package** section. Otherwise, create one using Syncfusion Blazor getting started guides.

* [Server](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-visual-studio)
* [WebAssembly](https://blazor.syncfusion.com/documentation/getting-started/blazor-webassembly-app)
* [WebApp](https://blazor.syncfusion.com/documentation/getting-started/blazor-web-app)

### Install Authentication package

To enable authentication, install the required Microsoft packages.

{% tabs %}
{% highlight bash tabtitle=".NET CLI" %}

dotnet add package Microsoft.AspNetCore.Authentication.OpenIdConnect

{% endhighlight %}
{% endtabs %}

### Create a Cognito User Pool

Before building the Blazor app, set up an AWS Cognito User Pool:

1. Go to **AWS Management Console** > **Amazon Cognito**.
2. Click **Create user pool**.
3. Choose application type as **Traditional Web Application**.
4. Set your application name.
5. Choose authentication method: **Email** or **Phone number** (or both).
6. Continue through the setup wizard and confirm your settings. Once ready, click the button to **Create User Directory**.
7. Go to **Amazon Cognito** > **User pools**. Note the **User pool ID** and **User pool name**.
8. Go to **App clients and analytics** (or **App integration** > **App clients**).
9. Click **Create app client**:
   - **App type:** Choose **Public client** (for PKCE without a secret).
   - **Client name:** (for example, `MyBlazorServer`).
   - **Authentication flows:** Ensure **Authorization code flow** is selected.
   - Under **Allowed redirect URIs**, add: ```https://localhost:7000/signin` (adjust port if different; check `Properties/launchSettings.json`).
   - Under **Allowed sign-out URIs**, add: `https://localhost:7000/signout-callback`.
10. Create the app client and note the **Client ID**.

You now have the values to add to `appsettings.json`.

### Update `appsettings.json`

This stores your Cognito Hosted UI domain and app client ID so the app can read them at startup. The `Authority` is the base URL of your Cognito User Pool domain, and `ClientId` identifies your web app in Cognito. Keep these out of code to simplify environment changes. Replace the placeholders with your actual Cognito values.

{% tabs %}
{% highlight json tabtitle="appsettings.json" %}

{
  "Cognito": {
    "Authority": "https://your-domain.auth.<REGION>.amazoncognito.com", //Replace **<REGION>** with your AWS region (e.g., ap-east-1, ap-south-1, eu-west-1). 
    "RedirectUri": "https://localhost:<PORT>/signin-oidc", //Replace **<PORT>** with your actual localhost port (typically 5001 or 7000).
    "SignOutUri": "https://localhost:<PORT>/signout-callback-oidc", 
    "ClientId": "YOUR_APP_CLIENT_ID" //Replace **YOUR_APP_CLIENT_ID** with your Cognito app client ID
  },
  "AllowedHosts": "*"
}

{% endhighlight %}
{% endtabs %}

N> This sample uses Authorization Code + PKCE with a public client (no client secret). If you created a confidential client, add ClientSecret to configuration and set `options.ClientSecret` in the OIDC options. 

### Configure OIDC and Cookie Authentication

This wires OpenID Connect against Cognito’s Hosted UI using the Authorization Code flow (PKCE) and uses cookies for the authenticated session. `SaveTokens = true` keeps ID/Access tokens available for downstream API calls. `RoleClaimType = "cognito:groups"` turns Cognito groups into ASP.NET Core roles. The `/sign-in` and `/sign-out` endpoints start and end the hosted login flow.

{% tabs %}
{% highlight cs tabtitle="Program.cs" %}

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSyncfusionBlazor();
builder.Services.AddHttpContextAccessor();

var cognitoDomain = builder.Configuration["Cognito:Authority"];
var clientId = builder.Configuration["Cognito:ClientId"];

bool TryGetAuthorityUri(string? authority, out Uri? uri)
{
    uri = null;
    if (string.IsNullOrWhiteSpace(authority)) return false;
    if (authority.Contains("https://us-east-1td50lz7sv.auth.us-east-1.amazoncognito.com")) return false;
    // Require a valid absolute URI (e.g. https://your-domain.auth.region.amazoncognito.com)
    if (!Uri.TryCreate(authority, UriKind.Absolute, out var parsed)) return false;
    // only http or https are acceptable here for dev detection; production will require https
    if (parsed.Scheme != Uri.UriSchemeHttp && parsed.Scheme != Uri.UriSchemeHttps) return false;
    uri = parsed;
    return true;
}

// Decide whether to enable OIDC (Cognito) or fall back to cookie-only auth in Development.
bool useOidc = false;
if (!string.IsNullOrWhiteSpace(cognitoDomain)
    && !cognitoDomain.Contains("your-domain")
    && !string.Equals(cognitoDomain, "Test user", StringComparison.OrdinalIgnoreCase)
    && !string.IsNullOrWhiteSpace(clientId)
    && !clientId.Contains("YOUR_APP_CLIENT_ID"))
{
    if (Uri.TryCreate(cognitoDomain, UriKind.Absolute, out var u))
    {
        // Allow only HTTPS authority generally
        if (string.Equals(u.Scheme, Uri.UriSchemeHttps, StringComparison.OrdinalIgnoreCase))
        {
            useOidc = true;
        }
        else if (string.Equals(u.Scheme, Uri.UriSchemeHttp, StringComparison.OrdinalIgnoreCase)
                 && !u.IsLoopback
                 && builder.Environment.IsDevelopment())
        {
            // Allow non-local http authority in development (rare)
            useOidc = true;
        }
    }
}

if (useOidc)
{
    builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
    })
    .AddCookie()
    .AddOpenIdConnect(options =>
    {
        options.Authority = cognitoDomain!;          // Cognito Hosted UI domain
        options.ClientId = clientId!;                // App client ID
        options.ResponseType = "code";              // Authorization Code + PKCE
        options.SaveTokens = true;                  // Persist ID/Access tokens in session for use in API calls or as Bearer tokens

        // If the authority is http and we're in Development, allow non-https metadata.
        options.RequireHttpsMetadata = !(builder.Environment.IsDevelopment()
            && Uri.TryCreate(cognitoDomain, UriKind.Absolute, out var uu)
            && string.Equals(uu.Scheme, Uri.UriSchemeHttp, StringComparison.OrdinalIgnoreCase));

        options.Scope.Clear();
        options.Scope.Add("openid");
        options.Scope.Add("email");
        options.Scope.Add("profile");

        options.TokenValidationParameters = new TokenValidationParameters
        {
            NameClaimType = "cognito:username",
            RoleClaimType = "cognito:groups"
        };

        options.CallbackPath = "/signin-oidc";
        options.SignedOutCallbackPath = "/signout-callback-oidc";
    });
}
else
{
    // Cookie-only auth for development/test when Cognito isn't configured.
    builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie();
}

// In Production require a valid HTTPS Cognito authority.
if (!builder.Environment.IsDevelopment())
{
    if (!TryGetAuthorityUri(cognitoDomain, out var prodUri) || prodUri!.Scheme != Uri.UriSchemeHttps || string.IsNullOrWhiteSpace(clientId) || clientId.Contains("YOUR_APP_CLIENT_ID"))
    {
        throw new InvalidOperationException(
            "Cognito configuration is invalid. Set 'Cognito:Authority' to your Cognito Hosted UI domain (https://<your-domain>.auth.<region>.amazoncognito.com) and 'Cognito:ClientId' to your app client id.");
    }

    // If we reach here, OIDC is already registered above when appropriate.
}

builder.Services.AddAuthorization(o =>
{
    o.AddPolicy("AdminOnly", p => p.RequireRole("Admin"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapBlazorHub();
// Custom login/logout entry points (not OIDC callbacks; see CallbackPath and SignedOutCallbackPath above)
app.MapGet("/signin", async (HttpContext ctx) =>
{
    if (useOidc)
    {
        await ctx.ChallengeAsync(OpenIdConnectDefaults.AuthenticationScheme, new AuthenticationProperties { RedirectUri = "/" });
        return Results.Empty;
    }

    // Dev fallback: create a local cookie user and redirect home
    var claims = new[] {
        new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.NameIdentifier, "devuser"),
        new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.Name, "Developer User"),
        new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.Email, "dev@example.local")
    };
    var identity = new System.Security.Claims.ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
    var user = new System.Security.Claims.ClaimsPrincipal(identity);
    await ctx.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, user);
    ctx.Response.Redirect("/");
    return Results.Empty;
});

app.MapGet("/signout", async (HttpContext ctx) =>
{
    if (useOidc)
    {
        await ctx.SignOutAsync(OpenIdConnectDefaults.AuthenticationScheme, new AuthenticationProperties { RedirectUri = "/" });
        return Results.Empty;
    }

    await ctx.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    ctx.Response.Redirect("/");
    return Results.Empty;
});
app.MapFallbackToPage("/_Host");

app.Run();

{% endhighlight %}
{% endtabs %}

### Syncfusion DataGrid on an authenticated page

This page demonstrates how to protect a Syncfusion DataGrid using ASP.NET Core authorization. When unauthenticated, a `Sign in` link is displayed. Once authenticated, the grid renders with sample data.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@page "/"
@using Microsoft.AspNetCore.Components.Authorization
@using Syncfusion.Blazor.Grids

<div>
    <AuthorizeView>
        <Authorized>
            <div>
                <h1>Welcome to Blazor with AWS Cognito</h1>
                <h5> Orders Data</h5>
                <SfGrid DataSource="@_orders" AllowPaging="true" AllowSorting="true" AllowSelection="true">
                    <GridPageSettings PageSize="10"></GridPageSettings>
                    <GridColumns>
                        <GridColumn Field="Id" HeaderText="ID" Width="80"></GridColumn>
                        <GridColumn Field="Item" HeaderText="Item"></GridColumn>
                        <GridColumn Field="Qty" HeaderText="Quantity" Width="100"></GridColumn>
                        <GridColumn Field="Price" HeaderText="Price" Width="120" Format="C2" TextAlign="TextAlign.Right"></GridColumn>
                    </GridColumns>
                </SfGrid>
            </div>
        </Authorized>
        <NotAuthorized>
            <div>
                <div>
                    <h2>Sign in</h2>
                    <p>Sign in to your account with AWS Cognito.</p>
                </div>                        
                <div>
                    <p class="signin-description">
                        Secure authentication powered by AWS Cognito
                    </p>
                    <a href="/signin" class="btn btn-primary btn-lg signin-button">
                    <span class="signin-icon"></span>
                        Sign in with AWS Cognito
                    </a>
                </div>
            </div>
        </NotAuthorized>
    </AuthorizeView>
</div>

@code {
    private record Order(int Id, string Item, int Qty, decimal Price);

    // In production, load orders from an API or database
    // protected override async Task OnInitializedAsync() => _orders = await OrderService.GetOrdersAsync();
    private readonly List<Order> _orders = new()
    {
        new Order(1, "Laptop", 1, 1299.00m),
        new Order(2, "Mouse", 2, 49.99m),
        new Order(3, "Keyboard", 3, 89.99m),
        new Order(4, "Monitor", 1, 349.99m)
    };
}

{% endhighlight %}
{% endtabs %}

### Run the application

Run the application using the following command:

{% tabs %}
{% highlight bash tabtitle=".NET CLI" %}

dotnet run

{% endhighlight %}
{% endtabs %}

N> By default, the app runs on `https://localhost:7000` (or `https://localhost:5001` in older project templates). Ensure your Cognito app client **Allowed redirect URIs** match your actual localhost URL.

**Expected behavior**

* Unauthenticated users see the sign-in prompt.
* Clicking "Sign in with AWS Cognito" redirects to the Cognito Hosted UI.
* After entering credentials, the user is redirected back to the app.
* The Syncfusion DataGrid appears with sample data.
* Clicking "Sign out" clears the session and returns to the sign-in page.

**Output:**

![AWS with Blazor](./images/aws-cognito.webp)

## See also

* [AWS Cognito User Pools Documentation](https://docs.aws.amazon.com/cognito/latest/developerguide/cognito-user-pools.html)
* [ASP.NET Core Authentication overview](https://learn.microsoft.com/en-us/aspnet/core/security/authentication/)
* [Syncfusion Blazor Server Getting Started](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-visual-studio)

