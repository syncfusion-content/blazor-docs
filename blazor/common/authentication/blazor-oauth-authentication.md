---
layout: post
title: Using Syncfusion Blazor DataGrid with OAuth 2.0
description: Step-by-step guide to integrating OAuth 2.0 authentication with Syncfusion Blazor components in a Blazor Web App.
platform: Blazor
control: Common
documentation: ug
---

# Blazor with OAuth 2.0 Authentication

This guide explains how to integrate **OAuth 2.0 authentication** into a **Blazor Web App (Interactive Server)** using **GitHub OAuth**. Once authenticated, the user can access protected [Syncfusion Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) page.

## What is OAuth 2.0?

OAuth 2.0 is an authorization framework that enables applications to obtain limited access to user accounts on an HTTP service (such as GitHub, Google, and Microsoft). It uses tokens instead of credentials and is widely used for secure authentication in modern applications.

OAuth provides:

- **Secure login using external providers**
- **No need to store username and password**
- **Short‑lived authorization tokens**
- **Minimal developer‑side security concerns**

## Prerequisites

- [.NET SDK 8.0](https://dotnet.microsoft.com/en-us/download/dotnet/10.0) or later
- Visual Studio 2022 or newer
- A GitHub account (required for creating the GitHub OAuth App)

## Create a Blazor Web App (Interactive server)

1. Open **Visual Studio**.
2. Select **Create a new project**
3. From the project templates, choose **Blazor Web App**, then click **Next**.
4. Enter a **Project name** and choose **Interactive Server** as the rendering mode.
5. Click **Create** to generate the project.

## Create a GitHub OAuth application

1. Go to: **https://github.com/settings/developers**
2. Click **OAuth Apps → New OAuth App**
3. Configure the application:
   - **Homepage URL:**(example:`https://localhost:5001/`) // Use your Blazor app’s base HTTPS URL.
   - **Authorization callback URL:** `https://localhost:5001/signin-github`
4. Copy the generated **Client ID** and **Client Secret**
5. Add them to your *appsettings.json*:

```json
"Authentication": {
  "GitHub": {
    "ClientId": "<your-client-id>",
    "ClientSecret": "<your-client-secret>"
  }
}
```

## Configure OAuth 2.0 authentication in Blazor

Add OAuth authentication using GitHub and enable cookie-based sign‑in in `Program.cs`.

{% tabs %}
{% highlight c# tabtitle="Program.cs" %}

using OAuth.Components;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
  .AddInteractiveServerComponents();

// Configure authentication (Cookies + GitHub OAuth).
builder.Services.AddAuthentication(options =>
{
  options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
  options.DefaultChallengeScheme = "GitHub";
})
  .AddCookie()
  .AddOAuth("GitHub", options =>
  {
    options.ClientId = builder.Configuration["Authentication:GitHub:ClientId"] ?? "your-github-client-id";
    options.ClientSecret = builder.Configuration["Authentication:GitHub:ClientSecret"] ?? "your-github-client-secret";
    options.CallbackPath = "/signin-github";
    options.AuthorizationEndpoint = "https://github.com/login/oauth/authorize";
    options.TokenEndpoint = "https://github.com/login/oauth/access_token";
    options.UserInformationEndpoint = "https://api.github.com/user";
    options.Scope.Add("user:email");
    options.SaveTokens = true;

    options.ClaimActions.MapJsonKey("urn:github:login", "login");
    options.ClaimActions.MapJsonKey("urn:github:id", "id");
    options.ClaimActions.MapJsonKey("urn:github:url", "html_url");
    options.ClaimActions.MapJsonKey("urn:github:avatar", "avatar_url");

    options.Events = new Microsoft.AspNetCore.Authentication.OAuth.OAuthEvents
    {
      OnCreatingTicket = async context =>
      {
        // GitHub requires a user-agent header.
        var request = new HttpRequestMessage(HttpMethod.Get, context.Options.UserInformationEndpoint);
        request.Headers.Accept.ParseAdd("application/json");
        request.Headers.UserAgent.ParseAdd("OAuthApp");
        request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", context.AccessToken);

        var response = await context.Backchannel.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, context.HttpContext.RequestAborted);
        response.EnsureSuccessStatusCode();
        var payload = System.Text.Json.JsonDocument.Parse(await response.Content.ReadAsStringAsync());
        context.RunClaimActions(payload.RootElement);
      }
    };
  });

builder.Services.AddAuthorization();
// Add support for API controllers (used to proxy calls to protected APIs).
builder.Services.AddControllers();
// Register IHttpClientFactory for outbound HTTP calls
builder.Services.AddHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
  app.UseExceptionHandler("/Error", createScopeForErrors: true);
  app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseAntiforgery();
app.MapControllers();
app.MapStaticAssets();
app.MapRazorComponents<App>()
  .AddInteractiveServerRenderMode();
app.Run();

{% endhighlight %}
{% endtabs %}

This configuration redirects users to GitHub for authentication, stores the authenticated session in a secure cookie, and retrieves the user's profile information from GitHub after a successful login.

## Implement login and logout endpoints

Create an `~/Controllers/AccountController.cs` class to handle OAuth redirection.

{% tabs %}
{% highlight c# tabtitle="AccountController.cs"  %}

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace OAuth.Controllers
{
  [Route("account")]
  public class AccountController : Controller
  {
      [HttpGet("login")]
      public IActionResult Login(string? returnUrl = "/")
      {
          return Challenge( new AuthenticationProperties { RedirectUri = returnUrl }, "GitHub" );
      }

      [HttpGet("logout")]
      public async Task<IActionResult> Logout()
      {
          await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
          return Redirect("/");
      }
  }
}

{% endhighlight %}
{% endtabs %}

## Enabling authentication state in Blazor

To allow components to receive authentication state, wrap the router inside **CascadingAuthenticationState** under `~/Components/Routes.razor` file.

{% tabs %}
{% highlight razor tabtitle="Routes.razor"  %}

@using Microsoft.AspNetCore.Components.Authorization

<CascadingAuthenticationState>
    <Router AppAssembly="typeof(Program).Assembly">
        <Found Context="routeData">
            <RouteView RouteData="routeData" DefaultLayout="typeof(Layout.MainLayout)" />
            <FocusOnNavigate RouteData="routeData" Selector="h1" />
        </Found>
    </Router>
</CascadingAuthenticationState>

{% endhighlight %}
{% endtabs %}

## Connect Syncfusion Blazor DataGrid 

**1. Install Syncfusion® Blazor DataGrid and themes NuGet packages**

To add the Blazor DataGrid in the app, open the NuGet Package Manager in Visual Studio (Tools → NuGet Package Manager → Manage NuGet Packages for Solution), search and install [Syncfusion.Blazor.Grid](https://www.nuget.org/packages/Syncfusion.Blazor.Grid/) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/).

**2. Register Syncfusion® Blazor service**

Open the **~/_Imports.razor** file and import the required namespaces.

{% tabs %}
{% highlight razor tabtitle="~/_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Grids

{% endhighlight %}
{% endtabs %}

**3. Register the Syncfusion® Blazor service in the ~/Program.cs file**

{% tabs %}
{% highlight razor tabtitle="~/Program.cs" %}

// Program.cs
using Syncfusion.Blazor;
 
builder.Services.AddSyncfusionBlazor();

{% endhighlight %}
{% endtabs %}

**4. Add stylesheet and script resources**

Include the theme stylesheet and script references in the `App.razor` file.

{% tabs %}
{% highlight html  %}

<head>
    <link href="_content/Syncfusion.Blazor.Themes/fluent2.css" rel="stylesheet" />
</head>
....
<body>
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
</body>

{% endhighlight %}
{% endtabs %}

## Create a protected page with Syncfusion DataGrid

Create `SecureGrid.razor` page and protect it using the [Authorize] attribute.

{% tabs %}
{% highlight razor %}

@page "/secure-grid"
@attribute [Authorize]
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" />

@code {
    public List<Order> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 5).Select(x => new Order
        {
            OrderID = x,
            CustomerID = new[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" }[new Random().Next(5)]
        }).ToList();
    }

    public class Order
    {
        public int OrderID { get; set; }
        public string CustomerID { get; set; }
    }
}
{% endhighlight %}
{% endtabs %}

## Display content based on authentication status

The `Home.razor` page uses `<AuthorizeView>` to change UI depending on whether the user is logged in.

{% tabs %}
{% highlight razor %}

@page "/"
@using Microsoft.AspNetCore.Components.Authorization
@using OAuth.Components.Pages

<PageTitle>Home</PageTitle>

<div class="container mt-4">
	<AuthorizeView>
		<Authorized>
            <h1>DataGrid</h1>
			<!-- Render DataGrid on the home page when authenticated -->
			<SecureGrid />
		</Authorized>
		<NotAuthorized>
            <h1>Welcome!</h1>
            <p>
                Click the Login button below to sign in with GitHub.
                Once you’re logged in, the Syncfusion DataGrid will be displayed.
            </p>
			<a class="btn btn-primary" href="/account/login?returnUrl=/">Login with GitHub</a>
		</NotAuthorized>
	</AuthorizeView>
</div>

{% endhighlight %}
{% endtabs %}

This example demonstrates how to integrate GitHub OAuth into a Blazor Web App and authenticate users using secure cookie-based sign‑in. After authentication, the user can access protected pages and view the Syncfusion Blazor DataGrid.