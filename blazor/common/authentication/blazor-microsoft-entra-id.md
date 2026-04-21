---
layout: post
title: Blazor with Microsoft Entra ID Authentication | Syncfusion® 
description: Step-by-step guide to integrating Microsoft Entra ID authentication with Syncfusion® Blazor components in a Blazor Web App.
platform: Blazor
control: Common
documentation: ug
---

# Securing Syncfusion® Blazor DataGrid with Microsoft Entra ID

This document explains how to build a **Blazor Web App (Interactive Server)** that uses **Microsoft Entra ID** (formerly Azure Active Directory) for user authentication. Once users log in with their Microsoft account, they will be able to access a protected page that includes the **[Syncfusion® Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid)** component.

## What is Microsoft Entra ID?

Microsoft Entra ID is Microsoft’s identity platform that allows users to securely sign in to applications using their Microsoft account.

**Benefits of using Entra ID in Blazor applications**

Entra ID enables secure Microsoft account sign-in for your Blazor App with Single Sign‑On (SSO) and token based authentication, so your app never stores passwords. It also supports role and group based authorization and provides enterprise grade security managed by Microsoft, so you don’t need to write or maintain authentication logic yourself.

## Implementing Microsoft Entra ID Authentication for Syncfusion® Blazor DataGrid

This section explains how to connect **Microsoft Entra ID login** to a Blazor Web App and show the **Syncfusion® Blazor DataGrid** only after a user signs in.

### Create a Blazor project

If you already have a Blazor project configured, you can skip this section and proceed to **Install required packages**.

Otherwise, create a new Blazor application by following the Syncfusion getting started guides [Blazor Web App (Interactive Server)](https://blazor.syncfusion.com/documentation/getting-started/blazor-web-app)

Ensure that **HTTPS is enabled** during project creation, as Microsoft Entra ID based authorization requires secure communication.

### Install required packages

Open the NuGet Package Manager in Visual Studio from (*Tools → NuGet Package Manager → Manage NuGet Packages for Solution*), and install the required package.

**Syncfusion packages:**

- [Syncfusion.Blazor.Grid](https://www.nuget.org/packages/Syncfusion.Blazor.Grid/)
- [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/)

**Microsoft Identity packages:**

- [Microsoft.Identity.Web](https://www.nuget.org/packages/Microsoft.Identity.Web)
- [Microsoft.Identity.Web.UI](https://www.nuget.org/packages/Microsoft.Identity.Web.UI)

### Add Syncfusion® namespaces

Open the `~/_Imports.razor` file and import the Syncfusion® namespaces.

{% tabs %}
{% highlight razor tabtitle="~/_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Grids

{% endhighlight %}
{% endtabs %}

### Add stylesheet and script resources

Include the theme stylesheet and script references in the `App.razor` file.

{% tabs %}
{% highlight razor tabtitle="App.razor" %}

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

### Register your app in Microsoft Entra ID (Azure Portal)

This step registers the Blazor application in Azure so Microsoft Entra ID can authenticate users.

1. Open [Azure Portal](https://portal.azure.com).
2. Go to **Microsoft Entra ID** → **App registrations**.
3. Click **New registration**.
4. Enter **App name** and under **Supported account types**, select:
   - **Single tenant** - if the app is for users in your organization only.
   - **Multi tenant** - if the app should support users from any Microsoft Entra organization.
   - **Multi tenant and personal Microsoft accounts** - for the broadest access.
   For this tutorial, select **Single tenant**.
5. Click **Register**.

After registration, note the following values:
- **Application (Client) ID**
- **Directory (Tenant) ID**

These values are required in the application configuration.

### Configure redirect URLs

Redirect URLs specify where Microsoft Entra ID should return the user after a successful login.

1. Open the registered application in Azure Portal.
2. Navigate to **Authentication**.
3. Click **Add a platform** and select **Web**.
4. Add the redirect URL: `https://localhost:5001/signin-oidc` *(Replace `5001` with your application's actual HTTPS port number from `launchSettings.json` if different)*.
5. Enable **ID tokens**.
6. Save the changes.

### Configure Azure AD settings in appsettings.json

This step stores Microsoft Entra ID configuration values so the Blazor App can read them at runtime.
After copying the **Tenant ID** and **Client ID**, update the `appsettings.json` file as shown below.

{% tabs %}
{% highlight json tabtitle="appsettings.json" %}

"AzureAd": {
  "Instance": "https://login.microsoftonline.com/",
  "TenantId": "<tenant-id>",
  "ClientId": "<client-id>",
  "CallbackPath": "/signin-oidc"
}

{% endhighlight %}
{% endtabs %}

### Configure Microsoft Entra ID authentication in Blazor

This step enables OpenID Connect authentication in the Blazor application by configuring Microsoft Entra ID settings in the `Program.cs` file.

{% tabs %}
{% highlight c# tabtitle="Program.cs" %}

using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

// Configure authentication with Microsoft Entra ID (Azure AD)
builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
  .AddMicrosoftIdentityWebApp(builder.Configuration.GetSection("AzureAd"));

builder.Services.AddAuthorization();

builder.Services.AddRazorComponents()
  .AddInteractiveServerComponents();

// Register the Syncfusion® Blazor service  
builder.Services.AddSyncfusionBlazor();

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
app.MapStaticAssets();
app.UseAuthentication();
app.UseAuthorization();
app.UseAntiforgery();
app.MapControllers();
app.MapRazorComponents<App>()
  .AddInteractiveServerRenderMode();
app.Run();

{% endhighlight %}
{% endtabs %}

### Enabling authentication state in Blazor

This step allows Blazor components to access the current user’s authentication state by configuring the `~/Components/Routes.razor` file.

{% tabs %}
{% highlight razor tabtitle="Routes.razor"  %}

@using Microsoft.AspNetCore.Components.Authorization

<CascadingAuthenticationState>
	<Router AppAssembly="typeof(Program).Assembly" NotFoundPage="typeof(Pages.NotFound)">
		<Found Context="routeData">
			<RouteView RouteData="routeData" DefaultLayout="typeof(Layout.MainLayout)" />
			<FocusOnNavigate RouteData="routeData" Selector="h1" />
		</Found>
	</Router>
</CascadingAuthenticationState>

{% endhighlight %}
{% endtabs %}

### Connect Syncfusion® Blazor DataGrid

Create a protected page that displays the Syncfusion® **DataGrid** only after the user successfully signs in with **Microsoft Entra ID**.

{% tabs %}
{% highlight razor tabtitle="Pages/Home.razor" %}

@page "/"
@rendermode InteractiveServer
@using Microsoft.AspNetCore.Components.Authorization

<PageTitle>Home</PageTitle>

<AuthorizeView>
	<NotAuthorized>
		<div class="text-center mt-5">
			<h1>Welcome!</h1>
			<p>
				Click the Login button below to sign in with Microsoft Entra ID.
				Once you’re logged in, the Syncfusion Blazor DataGrid will be displayed below.
			</p>
			<a class="btn btn-primary" href="/MicrosoftIdentity/Account/SignIn">Login with Microsoft</a>
		</div>
	</NotAuthorized>
	<Authorized>
		<div class="d-flex justify-content-between align-items-center">
			<h1>DataGrid</h1>
			<a class="btn btn-secondary" href="/MicrosoftIdentity/Account/SignOut">Logout</a>
		</div>

		<SfGrid DataSource="@Orders" AllowPaging="true" AllowSorting="true">
			<GridColumns>
				<GridColumn Field="@nameof(Order.OrderID)" HeaderText="Order ID" Width="120" IsPrimaryKey="true">
				</GridColumn>
				<GridColumn Field="@nameof(Order.CustomerID)" HeaderText="Customer ID" Width="150"></GridColumn>
			</GridColumns>
		</SfGrid>

		@code {
			public List<Order> Orders { get; set; } = new List<Order>();

			protected override void OnInitialized()
			{
				var customerIds = new[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" };
				Orders = Enumerable.Range(1, 5).Select(x => new Order
				{
					OrderID = x,
					CustomerID = customerIds[Random.Shared.Next(5)]
				}).ToList();
			}

			public class Order
			{
				public int OrderID { get; set; }
				public string? CustomerID { get; set; }
			}
		}
	</Authorized>
</AuthorizeView>

{% endhighlight %}
{% endtabs %}

This example demonstrates how to integrate Microsoft Entra ID authentication into a Blazor Web App using the Microsoft Identity platform. 

![Blazor DataGrid with Microsoft Enta ID login page](images/microsoft-authentication.webp)

The application securely signs users in through Entra ID and manages the authentication lifecycle using OpenID Connect. After successfully signing in, authenticated users can access protected pages and interact with the **Syncfusion® Blazor DataGrid** component. 

![Blazor DataGrid with Microsoft Enta ID](images/blazor-datagrid-microsoftentraid.webp)

This approach provides a secure, enterprise ready foundation for building modern Blazor applications with controlled access to data and UI components.   

## See also

- [Secure an ASP.NET Core Blazor WebAssembly Standalone App with Microsoft Accounts](https://learn.microsoft.com/en-us/aspnet/core/blazor/security/webassembly/standalone-with-microsoft-accounts)
- [Getting started with Syncfusion® Blazor DataGrid in Web App](https://blazor.syncfusion.com/documentation/datagrid/getting-started-with-web-app)