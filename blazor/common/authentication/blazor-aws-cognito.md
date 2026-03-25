---
layout: post
title: Using Syncfusion Blazor Server with AWS Cognito
description: Authenticate a Blazor Server app with AWS Cognito (OIDC Hosted UI) and secure Syncfusion components.
platform: Blazor
control: Common
documentation: ug
---

# Authentication and Authorization with AWS Cognito in Blazor Server

AWS Cognito User Pools provide a managed identity system that supports OpenID Connect (OIDC), OAuth 2.0, JSON Web Tokens (JWTs), MFA, user attributes, and group-based roles. This guide explains how to integrate a Blazor Server application with Cognito using Authorization Code Flow + PKCE through the Hosted UI, configure roles, and secure Syncfusion Blazor UI components.

## What is AWS?

Amazon Web Services (AWS) is a cloud platform that provides compute, storage, and identity services. For Blazor developers, AWS offers Amazon Cognito for user authentication and identity management.

For identity, AWS provides Amazon Cognito to handle sign-up and sign-in, tokens, MFA, and issuing temporary AWS credentials via IAM. Cognito provides a managed login interface (Hosted UI) and implements standard OpenID Connect (OIDC) endpoints to support modern authentication flows.

## Why Amazon Cognito for Blazor?

* Standards-based OIDC works with ASP.NET Core's built-in OpenID Connect middleware for Blazor Server; no third-party libraries are necessary. This is the Microsoft-recommended pattern to connect non-Microsoft OIDC providers. 
* Supports login with MFA and password policies, reducing custom auth UI work. 
* Emits `cognito:groups` in tokens for role-based authorization in your app and API. 
* Identity Pools can exchange a user's ID token for time-limited AWS credentials to call S3, DynamoDB, etc.

## Cognito Building Blocks

* **User Pools:** Managed user directory + OIDC authorization server (tokens, Hosted UI, MFA, groups). Use this to authenticate users and obtain ID/Access tokens for your app and APIs. 
* **Identity Pools (Federated Identities):** Optional service that exchanges a trusted identity (e.g., User Pool ID token) for temporary AWS credentials through IAM roles. Use this when server must call AWS services (such as Amazon S3 and Amazon DynamoDB) on behalf of the user.

## Password Policies

In **User Pool → Sign-in experience**:
- Configure **Password policy** (length, complexity, expiration).  
- Turn **MFA** Off/Optional/Required; choose **SMS** or **TOTP** enrollment.  
- Hosted UI prompts users according to your policy.  

## Role-Based Authorization with Cognito Groups

* Create groups (e.g., `Admin`) in **User Pool → Groups** and add users.  
* Ensure **Group membership** is included in tokens.  
* Map roles using `RoleClaimType = "cognito:groups"` and protect pages/endpoints with `[Authorize(Roles="Admin")]`. 

Add the following attribute to any `.razor` page file to restrict access to the Admin role:

```razor
@page "/admin"
@using Microsoft.AspNetCore.Authorization
@attribute [Authorize(Roles = "Admin")]
<h3>Admin Dashboard</h3>
<p>Only users in the Admin group can access this page.</p>
```

> Group creation and behavior are documented in AWS; using roles in Blazor/ASP.NET Core follows Microsoft's standard policy system. 

## Prerequisites

* .NET SDK (version 8.0 or later; this guide uses .NET 10.0)
* Visual Studio 2022 or VS Code + C# Dev Kit  
* AWS Account with permission to manage Cognito

## Integrating Cognito with Blazor

Configure OpenID Connect with the Cognito Hosted UI (Authorization Code + PKCE), which Microsoft's docs show for any OIDC provider in Blazor Web Apps.

### Create a Blazor Server Project

If you already have a Blazor project, proceed to the **Create a Cognito User Pool** section. Otherwise, create one using Syncfusion Blazor Server getting started guides.

* [Server](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-visual-studio)

### Create a Cognito User Pool

Before building the Blazor app, set up an AWS Cognito User Pool:

1. Go to **AWS Management Console** > **Amazon Cognito**.
2. Click **Create user pool**.
3. Choose authentication method: **Email** or **Phone number** (or both).
4. Continue through the setup wizard. Accept defaults or customize as needed.
5. Note the **User pool ID** and **User pool name**.
6. Go to **App integration** > **App clients** (or **App clients and analytics**).
7. Click **Create app client**:
   - **App type:** Choose **Public client** (for PKCE without a secret).
   - **Client name:** (for example, `MyBlazorServer`).
   - **Authentication flows:** Ensure **Authorization code flow** is selected.
   - Under **Allowed redirect URIs**, add: `https://localhost:7000/signin` (adjust port if different; check `Properties/launchSettings.json`).
   - Under **Allowed sign-out URIs**, add: `https://localhost:7000/signout`.
8. Create the app client and note the **Client ID**.
9. In **Domain name** (under App integration), create a custom domain or use the Cognito-provided sub-domain. Note the full Hosted UI domain:
   ```  
   https://your-domain.auth.{region}.amazoncognito.com
   ```

You now have the values to add to `appsettings.json`.

[Amazon Cognito user pools](https://docs.aws.amazon.com/cognito/latest/developerguide/cognito-user-pools.html)

### Update `appsettings.json`

This stores your Cognito Hosted UI domain and app client ID so the app can read them at startup. The `Authority` is the base URL of your Cognito User Pool domain, and `ClientId` identifies your web app in Cognito. Keep these out of code to simplify environment changes. Replace the placeholders with your actual Cognito values.

{% tabs %}
{% highlight %}

{
  "Cognito": {
    "Authority": "https://your-domain.auth.ap-south-1.amazoncognito.com", //Replace **ap-south-1** with your AWS region (e.g., us-east-1, eu-west-1). Check your Cognito User Pool details page for the correct region.
    "ClientId": "YOUR_APP_CLIENT_ID"
  },
  "AllowedHosts": "*"
}

{% endhighlight %}
{% endtabs %}

**Where to find these values:**
- **Authority:** Go to **Amazon Cognito** > Your **User Pool** > **App integration** > **Domain name**. The full URL is `https://{domain-name}.auth.{region}.amazoncognito.com` (for example, `https://myapp.auth.us-east-1.amazoncognito.com`).
- **ClientId:** Go to **App integration** > **App clients** and copy the **Client ID** for your app.


N> This sample uses Authorization Code + PKCE with a public client (no client secret). If you created a confidential client, add ClientSecret to configuration and set `options.ClientSecret` in the OIDC options. 

### `Program.cs` (OIDC + Cookies)

This wires OpenID Connect against Cognito’s Hosted UI using the Authorization Code flow (PKCE) and uses cookies for the authenticated session. `SaveTokens = true` keeps ID/Access tokens available for downstream API calls. `RoleClaimType = "cognito:groups"` turns Cognito groups into ASP.NET Core roles. The `/sign-in` and `/sign-out` endpoints start and end the hosted login flow.

{% tabs %}
{% highlight cs %}

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
    if (authority.Contains("your-domain")) return false;
    // Require a valid absolute URI (for example, https://your-domain.auth.region.amazoncognito.com)
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
        options.ResponseType = "code";             // Authorization Code + PKCE
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
// Dev + auth endpoints for sign-in/sign-out to avoid performing SignIn/Challenge from Blazor components
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
{% highlight razor %}

@page "/"
@using Microsoft.AspNetCore.Components.Authorization
@using Syncfusion.Blazor.Grids

<h3>Welcome</h3>

<AuthorizeView>
    <Authorized>
        <div class="mb-3">
            <a class="btn btn-outline-secondary" href="/signout">Sign out</a>
        </div>

        <SfGrid DataSource="@_orders">
            <GridColumns>
                <GridColumn Field="Id" HeaderText="ID" Width="120"></GridColumn>
                <GridColumn Field="Item" HeaderText="Item"></GridColumn>
                <GridColumn Field="Qty" HeaderText="Qty"></GridColumn>
                <GridColumn Field="Price" HeaderText="Price" Format="C2"></GridColumn>
            </GridColumns>
        </SfGrid>
    </Authorized>
    <NotAuthorized>
        <p>Please sign in to view the grid.</p>
        <a class="btn btn-primary" href="/signin">Sign in</a>
    </NotAuthorized>
</AuthorizeView>

@code {

     // Demo data for this sample; in production, fetch from a service/API
    private record Order(int Id, string Item, int Qty, decimal Price);

    private readonly List<Order> _orders = new()
    {
        new Order(1, "Laptop", 1, 1299.00m),
        new Order(2, "Mouse", 2, 49.99m)
    };
}

{% endhighlight %}
{% endtabs %}

### Run the Application

Run the application using the following command:

```
dotnet run
```

N> By default, the app runs on `https://localhost:7000` (or `https://localhost:5001` in older project templates). Ensure your Cognito app client **Allowed redirect URIs** match your actual localhost URL.

**Expected Behavior**

* Syncfusion DataGrid component should render only for authorized users.
* If the user is not authenticated, the application should display Sign in options instead of the Syncfusion components.
* After a successful login, the user should be able to view the Syncfusion DataGrid component.

**Output:**

![AWS with Blazor](./images/aws-cognito.webp)
