---
layout: post
title: Blazor Authentication using AWS Cognito | Syncfusion
description: Authenticate a Blazor Web App or Blazor Server App with AWS Cognito (OIDC Hosted UI) and secure Blazor components.
platform: Blazor
control: Common
documentation: ug
---

# Getting Started with Blazor Authentication using AWS Cognito

This guide demonstrates how to integrate [AWS Cognito authentication](https://docs.aws.amazon.com/cognito/latest/developerguide/cognito-how-to-authenticate.html) with [Blazor components](https://www.syncfusion.com/blazor-components). This enables you to implement secure authentication, control access to Blazor components based on user identity, and protect application data.

## Prerequisites

* [.NET SDK](https://dotnet.microsoft.com/en-us/download/dotnet) 8.0 or later (examples in this guide target .NET 10)
* [Visual Studio](https://visualstudio.microsoft.com/downloads/) 2022 or later or [Visual Studio Code](https://code.visualstudio.com/) with [C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit) extension
* [AWS Account with permission to manage Cognito](https://docs.aws.amazon.com/accounts/latest/reference/getting-started.html)

## Create a Blazor project

If you already have a Blazor project, proceed to the [Install required packages](#install-required-packages) section. Otherwise, create one using one of the following Blazor getting started guides.

* [Getting Started with Blazor Server App](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-visual-studio)
* [Getting Started with Blazor Web App](https://blazor.syncfusion.com/documentation/getting-started/blazor-web-app)

N> Configure the appropriate [Interactive render mode](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/render-modes?view=aspnetcore-10.0#render-modes) and [Interactivity location](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-10.0&pivots=vs) while creating a Blazor Server App. For detailed information, refer to the [interactive render mode documentation](https://blazor.syncfusion.com/documentation/common/interactive-render-mode).

## Install required packages

To enable authentication and use Blazor components, install the required packages through NuGet Package Manager in Visual Studio (*Tools → NuGet Package Manager → Manage NuGet Packages for Solution*), or the integrated terminal in Visual Studio Code (`dotnet add package`), or the .NET CLI.

**Syncfusion packages**

* [Syncfusion.Blazor.Grid](https://www.nuget.org/packages/Syncfusion.Blazor.Grid)
* [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes)

**Microsoft package**

* [Microsoft.AspNetCore.Authentication.OpenIdConnect](https://www.nuget.org/packages/Microsoft.AspNetCore.Authentication.OpenIdConnect)

You can install the required packages by using the following .NET CLI commands.

{% tabs %}
{% highlight bash tabtitle=".NET CLI" %}

dotnet add package Syncfusion.Blazor.Grid -v {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Themes -v {{ site.releaseversion }}
dotnet add package Microsoft.AspNetCore.Authentication.OpenIdConnect --version 10.0.X

{% endhighlight %}
{% endtabs %}

N> Use the version of `Microsoft.AspNetCore.Authentication.OpenIdConnect` that matches your .NET SDK version (for example, 8.0.x for .NET 8, 10.0.x for .NET 10).

## Add required namespaces

Open the `~/_Imports.razor` file and add the `Syncfusion.Blazor`, `Syncfusion.Blazor.Grids` namespaces.

{% tabs %}
{% highlight razor tabtitle="~/_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Grids

{% endhighlight %}
{% endtabs %}

## Create a Cognito user pool

Before building the Blazor app, set up an AWS Cognito user pool.

1. Go to **[AWS Management Console](https://console.aws.amazon.com/cognito)** > **Amazon Cognito**.
2. Click **Create user pool**.
3. Choose **Traditional Web Application** as the application type. Cognito groups all server-rendered web apps (including Blazor Server and Blazor Web App) under this category.
4. Set your application name.
5. Choose authentication method: **Email** or **Phone number** (or both).
6. Enter your app's **Return URL** (also called callback URL): `https://localhost:7000/signin-oidc` (adjust the port if different; check `Properties/launchSettings.json`).
7. Continue through the setup wizard and confirm your settings. Once ready, click the **Create User Directory** button.
8. Go to **Amazon Cognito** > **User pools**. Note the **User pool ID** and **User pool name**.
9. Go to **App clients**, select your app client, and verify or update the following settings:
   - **Application type:** **Traditional Web Application** (this generates a client secret by default).
   - **Allowed callback URLs:** Confirm `https://localhost:7000/signin-oidc` is listed.
   - **Allowed sign-out URLs:** Add `https://localhost:7000/signout-callback-oidc`.
   - **OAuth grant types:** Ensure **Authorization code grant** is selected.
10. Go to **App integration** > **Domain** and confirm a Cognito domain (or custom domain) is assigned to your user pool. This is required to enable the managed login (hosted UI) pages.

You now have the values to add to `appsettings.json`.

## Update `appsettings.json` file

This stores your Cognito hosted UI domain and app client ID so the app can read them at startup. The `Authority` is the base URL of your Cognito user pool domain, and `ClientId` identifies your web app in Cognito. Keep these out of code to simplify environment changes. Replace the placeholders with your actual Cognito values.

{% tabs %}
{% highlight json tabtitle="appsettings.json" %}

{
  "Cognito": {
    "Authority": "https://your-domain.auth.{REGION}.amazoncognito.com",
    "ClientId": "YOUR_APP_CLIENT_ID"
  },
  "AllowedHosts": "*"
}

{% endhighlight %}
{% endtabs %}

N> Replace **{REGION}** with your AWS region (for example, `us-east-1`), and **YOUR_APP_CLIENT_ID** with your Cognito app client ID.

N> This sample uses Authorization Code + PKCE with a public client (no client secret). If you created a confidential client, add ClientSecret to configuration and set `options.ClientSecret` in the OIDC options.

## Configure OIDC and cookie authentication

This wires OpenID Connect against Cognito’s hosted UI using the Authorization Code flow (PKCE) and uses cookies for the authenticated session. `SaveTokens = true` keeps ID/Access tokens available for downstream API calls. `RoleClaimType = "cognito:groups"` turns Cognito groups into ASP.NET Core roles.

Also register the Blazor service in `~/Program.cs` file to enable Blazor components in the application.

{% tabs %}
{% highlight csharp tabtitle="Program.cs" %}

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddSyncfusionBlazor();
builder.Services.AddHttpContextAccessor();
builder.Services.AddCascadingAuthenticationState();

var cognitoAuthority = builder.Configuration["Cognito:Authority"];
var cognitoClientId = builder.Configuration["Cognito:ClientId"];

bool TryGetAuthorityUri(string? authority, out Uri? uri)
{
    uri = null;
    if (string.IsNullOrWhiteSpace(authority)) return false;
    if (authority.Contains("your-domain")) return false;
    // Require a valid absolute URI (e.g. https://your-domain.auth.region.amazoncognito.com)
    if (!Uri.TryCreate(authority, UriKind.Absolute, out var parsed)) return false;
    // only http or https are acceptable here for dev detection; production will require https
    if (parsed.Scheme != Uri.UriSchemeHttp && parsed.Scheme != Uri.UriSchemeHttps) return false;
    uri = parsed;
    return true;
}

// Decide whether to enable OIDC (Cognito) or fall back to cookie-only auth in Development.
bool useOidc = false;
if (!string.IsNullOrWhiteSpace(cognitoAuthority)
    && !cognitoAuthority.Contains("your-domain")
    && !string.Equals(cognitoAuthority, "Test user", StringComparison.OrdinalIgnoreCase)
    && !string.IsNullOrWhiteSpace(cognitoClientId)
    && !cognitoClientId.Contains("YOUR_APP_CLIENT_ID"))
{
    if (Uri.TryCreate(cognitoAuthority, UriKind.Absolute, out var u))
    {
        // Allow only HTTPS authority generally
        if (string.Equals(u.Scheme, Uri.UriSchemeHttps, StringComparison.OrdinalIgnoreCase))
        {
            useOidc = true;
        }
        else if (string.Equals(u.Scheme, Uri.UriSchemeHttp, StringComparison.OrdinalIgnoreCase)
         && u.IsLoopback
         && builder.Environment.IsDevelopment())
        {
            // Allow HTTP for localhost in development only
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
        options.Authority = cognitoAuthority!;          // Cognito hosted UI domain
        options.ClientId = cognitoClientId!;                // App client ID
        options.ResponseType = "code";              // Authorization Code + PKCE
        options.SaveTokens = true;                  // Persist ID/Access tokens in session for use in API calls or as Bearer tokens

        // If the authority is http and we're in Development, allow non-https metadata.
        options.RequireHttpsMetadata = !(builder.Environment.IsDevelopment()
            && Uri.TryCreate(cognitoAuthority, UriKind.Absolute, out var uu)
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
    if (!TryGetAuthorityUri(cognitoAuthority, out var prodUri)
    || prodUri!.Scheme != Uri.UriSchemeHttps
    || string.IsNullOrWhiteSpace(cognitoClientId)
    || cognitoClientId.Contains("YOUR_APP_CLIENT_ID"))
    {
        throw new InvalidOperationException(
            "Cognito configuration is invalid. Set 'Cognito:Authority' to your Cognito hosted UI domain (https://<your-domain>.auth.<region>.amazoncognito.com) and 'Cognito:ClientId' to your app client id.");
    }
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
app.UseAuthentication();
app.UseAuthorization();
app.UseAntiforgery();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();
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
app.Run();

{% endhighlight %}
{% endtabs %}

## Add theme and script references

Add the Blazor theme CSS and script references to your application's `App.razor` file.

{% tabs %}
{% highlight html tabtitle="App.razor" %}

<head>
    ...
    <!-- Theme stylesheet -->
    <link href="_content/Syncfusion.Blazor.Themes/fluent2.css" rel="stylesheet" />
    ...
</head>
<body>
    ...
    <!-- core script (required for UI components, including Blazor DataGrid) -->
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js"></script>
    ...
</body>

{% endhighlight %}
{% endtabs %}

## Blazor DataGrid on an authenticated page

This page demonstrates how to conditionally render the [Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) based on the authenticated state using `<AuthorizeView>`. When unauthenticated, a **Sign in with AWS Cognito** button is displayed. Once authenticated, the grid renders with sample data.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@page "/"
@rendermode InteractiveServer
@using Microsoft.AspNetCore.Components.Authorization
@using Syncfusion.Blazor.Grids

<div>
    <AuthorizeView>
        <Authorized>
            <div>
                <h1>Welcome to Blazor with AWS Cognito</h1>
                <h2>Orders Data</h2>
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
            <a href="/signout" class="btn btn-secondary">Sign out</a>
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

N> In this example, sample data is defined inline for demonstration purposes. In production applications, load data from a secure API endpoint that validates the user's JWT token or authentication cookie.

## Run the application

Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to launch the application.

Alternatively, run the application using the following .NET CLI command from the project root directory.

{% tabs %}
{% highlight bash tabtitle=".NET CLI" %}

dotnet run

{% endhighlight %}
{% endtabs %}

N> By default, the app runs on `https://localhost:7000` (or similar port defined in `Properties/launchSettings.json`). Older project templates may use `https://localhost:5001`. Ensure your Cognito app client **Allowed redirect URIs** match your actual localhost URL.

**Expected behavior**

* Unauthenticated users see the **Sign in** prompt.
* Clicking **Sign in with AWS Cognito** redirects to the Cognito hosted UI.
* After entering credentials, the user is redirected back to the app.
* The Blazor DataGrid appears with sample data.
* Clicking **Sign out** clears the session and returns to the **Sign in** page.

**Output:**

![Blazor DataGrid displaying order data after AWS Cognito authentication](./images/aws-cognito.webp)

## See also

* [Getting started with Blazor DataGrid](https://blazor.syncfusion.com/documentation/datagrid/getting-started-with-server-app)
* [Getting started with AWS Cognito user pools](https://docs.aws.amazon.com/cognito/latest/developerguide/cognito-user-pools.html)
* [Overview of ASP.NET Core authentication](https://learn.microsoft.com/en-us/aspnet/core/security/authentication/)
* [Configure ASP.NET Core Data Protection for production](https://learn.microsoft.com/en-us/aspnet/core/security/data-protection/configuration/overview)