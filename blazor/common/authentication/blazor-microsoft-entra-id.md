---
layout: post
title: Using Syncfusion Blazor DataGrid with Microsoft Entra ID
description: Step-by-step guide to integrating Microsoft Entra ID authentication with Syncfusion Blazor components in a Blazor Web App.
platform: Blazor
control: Common
documentation: ug
---

# Blazor with Microsoft Entra ID Authentication

This document explains how to build a **Blazor Web App (Interactive Server)** that uses **Microsoft Entra ID** (formerly Azure Active Directory) for user authentication. Once users log in with their Microsoft account, they will be able to access a protected page that includes the Syncfusion Blazor DataGrid component.

## What is Microsoft Entra ID?

Microsoft Entra ID is Microsoft’s identity platform that allows users to securely sign in to applications using their Microsoft account.

**Benefits of using Entra ID in Blazor applications**

- Secure login using Microsoft accounts
- Single Sign‑On (SSO)
- Token‑based authentication
- No password storage in your app
- Role‑based and group‑based authorization
- Enterprise‑grade security

With Entra ID, you do not need to write authentication logic manually. Microsoft handles the security for you.

## Prerequisites

- [.NET SDK 8.0](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) or later
- Visual Studio 2022 or newer
- Azure subscription

## Create a Blazor Web App (Interactive server)

1. Open **Visual Studio**.
2. Select **Create a new project**.
3. In the Create a new project dialog.
  - Choose **Blazor Web App**
  - Click **Next**
4. In Configure your new project.
  - Enter a **Project name**
  - Choose a **Location**
  - Click **Next**
5. In the Additional information screen, configure the following.
  - **Framework**: Select **.NET 8.0** (or .NET (Latest) if available in your Visual Studio version)
  - **Authentication type**: Select **None** (authentication will be configured manually)
  - **Interactive render mode**: Select **Server**
  - **Interactivity location**: Select **Per page/component**
  - **Enable HTTPS**
6. Click **Create** to generate the Blazor Web App.

## Register Your App in Microsoft Entra ID (Azure Portal)

This step registers the Blazor application in Azure so Microsoft Entra ID can authenticate users.

1. Open [Azure Portal](https://portal.azure.com)
2. Go to **Microsoft Entra ID** → **App registrations**
3. Click **New registration**
4. Enter **App name** and select **Single tenant**
5. Click **Register**

After registration, note the following values:
- **Application (Client) ID**
- **Directory (Tenant) ID**

These values are required in the application configuration.

## Configure Redirect URLs

Redirect URLs specify where Microsoft Entra ID should return the user after a successful login.

1. Open the registered application in Azure Portal
2. Navigate to **Authentication**
3. Click **Add a platform** and select **Web**
4. Add the redirect URL: (example: https://localhost:5001/signin-oidc) // (Use your application’s HTTPS URL if different.)
5. Enable **ID tokens**
6. Save the changes

## Configure Azure AD settings in appsettings.json

This step stores Microsoft Entra ID configuration values so the Blazor app can read them at runtime.
After copying the **Tenant ID** and **Client ID**, update the `appsettings.json` file as shown below.

```json
"AzureAd": {
  "Instance": "https://login.microsoftonline.com/",
  "TenantId": "<tenant-id>",
  "ClientId": "<client-id>",
  "CallbackPath": "/signin-oidc"
}
```

## Configure Microsoft Entra ID authentication in Blazor

This step enables OpenID Connect authentication using Microsoft Entra ID.

{% tabs %}
{% highlight c# tabtitle="Program.cs" %}

using Microsoft_Entra_ID.Components;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Http;

var builder = WebApplication.CreateBuilder(args);

// Configure authentication with Microsoft Entra ID (Azure AD)
// Ensure configuration contains a path-only CallbackPath (avoid full-URL overrides)
builder.Configuration["AzureAd:CallbackPath"] = "/signin-oidc";

builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
  .AddMicrosoftIdentityWebApp(builder.Configuration.GetSection("AzureAd"));

// Ensure the OIDC callback path is set to a path-only value to avoid config binding errors
builder.Services.Configure<OpenIdConnectOptions>(OpenIdConnectDefaults.AuthenticationScheme, options =>
{
    options.CallbackPath = new PathString("/signin-oidc");
});

builder.Services.AddAuthorization(options =>
{
  // Example role policy; ensure roles are configured in the Azure app manifest or via groups
  options.AddPolicy("RequireAdmin", policy => policy.RequireRole("Admin"));
});

builder.Services.AddRazorComponents()
  .AddInteractiveServerComponents();

// Add controllers with UI endpoints for Microsoft Identity (SignIn/SignOut)
builder.Services.AddControllersWithViews().AddMicrosoftIdentityUI();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
  app.UseExceptionHandler("/Error", createScopeForErrors: true);
  app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.UseAntiforgery();
app.MapStaticAssets();
app.MapRazorComponents<App>()
  .AddInteractiveServerRenderMode();
app.Run();

{% endhighlight %}
{% endtabs %}

## Enabling authentication state in Blazor

This step allows Blazor components to access the current user’s authentication state.

@using Microsoft.AspNetCore.Components.Authorization

<CascadingAuthenticationState>
    <Router AppAssembly="typeof(Program).Assembly">
        <Found Context="routeData">
            <RouteView RouteData="routeData"
                       DefaultLayout="typeof(Layout.MainLayout)" />
        </Found>
    </Router>
</CascadingAuthenticationState>

## Connect Syncfusion Blazor DataGrid 

**1. Install Syncfusion® Blazor DataGrid and themes NuGet packages**

To add the Blazor DataGrid in the app, open the NuGet Package Manager in Visual Studio (Tools → NuGet Package Manager → Manage NuGet Packages for Solution), search and install [Syncfusion.Blazor.Grid](https://www.nuget.org/packages/Syncfusion.Blazor.Grid/) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/).

**2. Add import namespaces**

Open the **~/_Imports.razor** file and import the required namespaces.

{% tabs %}
{% highlight razor tabtitle="~/_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Grids

{% endhighlight %}
{% endtabs %}

**3. Register the Syncfusion® Blazor service in the `~/Program.cs` file**

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

**5. Create a protected page with Syncfusion DataGrid**

This section creates a protected page that displays the Syncfusion DataGrid only after the user successfully signs in with Microsoft Entra ID.

{% tabs %}
{% highlight razor %}

@page "/"
@using Microsoft.AspNetCore.Components.Authorization

<PageTitle>Home</PageTitle>

<AuthorizeView>
	<NotAuthorized>
		<div class="text-center mt-5">
			<h1>Welcome!</h1>
			<p>
				Click the Login button below to sign in with Microsoft Entra ID.
				Once you’re logged in, the Syncfusion DataGrid will be displayed below.
			</p>
			<a class="btn btn-primary" href="/MicrosoftIdentity/Account/SignIn">Login with Microsoft</a>
		</div>
	</NotAuthorized>
	<Authorized>
		<div class="d-flex justify-content-between align-items-center">
			<h1>DataGrid</h1>
			<a class="btn btn-secondary" href="/MicrosoftIdentity/Account/SignOut">Logout</a> </div>
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
	</Authorized>
</AuthorizeView>

{% endhighlight %}
{% endtabs %}

This example demonstrates how to integrate Microsoft Entra ID authentication into a Blazor Web App using the Microsoft Identity platform. The application securely signs users in through Entra ID and manages the authentication lifecycle using OpenID Connect. After successfully signing in, authenticated users can access protected pages and interact with the Syncfusion Blazor DataGrid component.This approach provides a secure, enterprise-ready foundation for building modern Blazor applications with controlled access to data and UI components.   