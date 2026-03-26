---
title: ASP.NET Core Identity with Blazor Interactive Server | Syncfusion
description: Guide to configure ASP.NET Core Identity in an Interactive Server Blazor app and protect Syncfusion components (DataGrid, Charts).
platform: blazor
component: common
documentation: ug
---

# Blazor Web App (Interactive Server) with ASP.NET Core Identity

This guide explains how to configure ASP.NET Core Identity in a **Blazor Web App using Interactive Server render mode** and protect Syncfusion components such as [DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) and [Charts](https://www.syncfusion.com/blazor-components/blazor-charts).

## What is ASP.NET Core Identity?

ASP.NET Core Identity is the built-in membership system for ASP.NET Core apps. It provides UI and APIs for registration, login, logout, password management, roles, claims, and more.  In Blazor Web Apps, Microsoft recommends using the Identity Razor Pages for authentication tasks and using Blazor authorization for your components.

## When should I use it in Blazor?

Use Identity when your app needs cookie‑based, server‑side authentication and you want the standard login/registration experience without building it from scratch. In a Blazor Web App using Interactive Server render mode, all authorization checks happen on the server. This gives strong security because the UI is not shown to the user until authentication is complete.

## Prerequisites

* .NET SDK 8.0 or later
* Editor/IDE: Visual Studio 2022 or later, or VS Code

## Create the sample app

The steps below will help you build a secure Blazor Web App using Interactive Server mode. You will set up ASP.NET Core Identity with SQLite and add Syncfusion components such as the [DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) and [Charts](https://www.syncfusion.com/blazor-components/blazor-charts) to pages that require the `[Authorize]` attribute.

### 1. Create a Blazor web app with Interactive Server

Create a new Blazor Web App configured to use **Interactive Server render mode**. In this mode, the app runs on the server and updates the UI in the browser through a real-time connection. This helps keep your data secure because it stays on the server.

`BlazorIdentitySyncfusion` is used as the sample project name in the following commands. You may replace it with any project name that suits your application.

Run the following commands in your **command-line interface (CLI)**.

{% tabs %}
{% highlight c# tabtitle=".NET CLI" %}

dotnet new blazor -o BlazorIdentitySyncfusion --interactivity Server
cd BlazorIdentitySyncfusion

{% endhighlight %}
{% endtabs %}

### 2. Install Identity and database packages

Install the necessary NuGet packages that provide ASP.NET Core Identity features and database connectivity. These packages allow your app to store user accounts, manage authentication, and connect to a SQLite database.

**Package Overview**

| Package | What It Does |
|---------|--------------|
| **Microsoft.AspNetCore.Identity.EntityFrameworkCore** | Connects Identity to your database via Entity Framework Core, enabling storage of users, passwords (hashed), and roles |
| **Microsoft.AspNetCore.Identity.UI** | Provides ready-made login, registration, and account management pages (Razor Pages) so you don't have to build them from scratch |
| **Microsoft.EntityFrameworkCore.Sqlite** | SQLite database provider-a lightweight database stored as a single file, perfect for development and small applications |
| **Microsoft.EntityFrameworkCore.Design** | Tools for creating and managing database schema changes (migrations) |
| **Microsoft.EntityFrameworkCore.Tools** | Adds the `dotnet ef` command-line tool for running migration commands |
| **Microsoft.VisualStudio.Web.CodeGeneration.Design** | Scaffolding tool for customizing Identity Razor Pages (e.g., to override the default login page design) |

Run the following commands inside your project folder.

{% tabs %}
{% highlight c# tabtitle=".NET CLI" %}

dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore
dotnet add package Microsoft.AspNetCore.Identity.UI
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design

{% endhighlight %}
{% endtabs %}

N> For Production Applications, SQLite is excellent for development and learning, but for production apps with multiple users or high traffic, use SQL Server, PostgreSQL, or MySQL for better performance, scalability, and concurrent access support.

### 3. Install Syncfusion Blazor component packages

Add Syncfusion Blazor packages to your project. These packages provide professional UI components like DataGrid (for displaying tabular data) and Charts (for visualizing data) that you'll use in the protected pages.

Run the following commands in your project folder (the folder that contains the `.csproj` file).

{% tabs %}
{% highlight c# tabtitle=".NET CLI" %}

dotnet add package Syncfusion.Blazor.Grid
dotnet add package Syncfusion.Blazor.Charts
dotnet add package Syncfusion.Blazor.Themes

{% endhighlight %}
{% endtabs %}

### 4. Create the database context for Identity users

Create the **ApplicationDbContext** class that connects ASP.NET Core Identity to your database. This class tells Entity Framework Core how to store and manage Identity data such as users, passwords, and roles.

Create a folder named `Data` in the project root (same level as `Program.cs`). Inside that folder, create a file named **ApplicationDbContext.cs** and add the following code:

{% tabs %}
{% highlight c# tabtitle="Data/ApplicationDbContext.cs" %}

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlazorIdentitySyncfusion.Data;

/// <summary>
/// Database context for ASP.NET Core Identity. Inherits IdentityDbContext to include
/// tables for users, roles, claims, etc.
/// </summary>

public class ApplicationDbContext : IdentityDbContext<IdentityUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }
}

{% endhighlight %}
{% endtabs %}

N> `IdentityDbContext<IdentityUser>` uses the default `IdentityUser` class provided by ASP.NET Core Identity. You can replace `IdentityUser` with a custom user class (e.g., `ApplicationUser : IdentityUser`) if you need additional user properties like `FullName` or `Department`.

### 5. Configure the SQLite connection string

Set up the connection string that tells your app where the `SQLite` database should be created. Entity Framework Core uses this connection string to store Identity data.

Open your **appsettings.json** file and add the `ConnectionStrings` section at the top.

{% tabs %}
{% highlight c# tabtitle="appsettings.json" %}

{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=blazor_identity.db"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}

{% endhighlight %}
{% endtabs %}

N> SQLite is a simple, file‑based database that stores all data in one `.db` file. It is easy to use and works well for development, testing, and learning. For production apps with many users or heavy traffic, consider switching to SQL Server, PostgreSQL, or MySQL.

**Security Warning**: Add `*.db` to your `.gitignore` file to prevent committing the database file (which contains hashed passwords and personal data) to source control. This is critical for protecting user privacy and security.

### 6. Configure application services and middleware

Configure your application by registering essential services and middleware in **Program.cs**. This is the central configuration file where you:
- Connect to the database
- Enable Identity authentication
- Register Syncfusion components
- Set up the request processing pipeline

**Understanding Services vs. Middleware**
- **Services**: Reusable components registered in the dependency injection container (database, authentication, Syncfusion, etc.)
- **Middleware**: Components that process each HTTP request in a specific order (authentication → authorization → routing)

Open **Program.cs** and replace its contents with the below.

{% tabs %}
{% highlight c# tabtitle="Program.cs" %}

// Program.cs
...
using BlazorIdentitySyncfusion.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Syncfusion.Blazor;
...
// EF Core + SQLite
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// ASP.NET Core Identity (cookie auth + default UI)
builder.Services
    .AddDefaultIdentity<IdentityUser>(options =>
    {
        // WARNING: Email confirmation is disabled for demo purposes only.
        // In production, set SignIn.RequireConfirmedAccount = true and configure an email sender to prevent unauthorized account access.
        options.SignIn.RequireConfirmedAccount = false;
    })
    .AddEntityFrameworkStores<ApplicationDbContext>();

// Razor Pages (Identity UI lives here)
builder.Services.AddRazorPages();

// Blazor auth state for <CascadingAuthenticationState>/<AuthorizeRouteView>
builder.Services.AddCascadingAuthenticationState();

// Register Syncfusion Blazor services
builder.Services.AddSyncfusionBlazor();
...

app.UseStaticFiles();
app.UseRouting();

// Authentication & Authorization middleware (order matters!)
app.UseAuthentication();
app.UseAuthorization();

// Antiforgery Middleware (required for Identity Razor Pages login/logout forms in .NET 8+)
app.UseAntiforgery();

// Map endpoints
app.MapRazorPages(); // Identity UI endpoints
...

{% endhighlight %}
{% endtabs %}

### 7. Import authorization and Syncfusion namespaces

Add the required namespaces in **Components/_Imports.razor**. These namespaces allow you to use authorization features such as `[Authorize]` and `<AuthorizeView>`, and they enable Syncfusion components in your Blazor pages.

{% tabs %}
{% highlight razor tabtitle="Components/_Imports.razor" %}

@using Microsoft.AspNetCore.Authorization
@using Microsoft.AspNetCore.Components.Authorization
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Charts

{% endhighlight %}
{% endtabs %}

### 8. Add Syncfusion styles and script resources

Before adding the Syncfusion theme stylesheet, ensure that no other Syncfusion theme CSS (e.g., `material.css`, `fluent.css`) is already referenced to avoid styling conflicts.

Open **Components/App.razor** and include the following inside the `<head>` and `<body>` sections.

{% tabs %}
{% highlight razor tabtitle="Components/App.razor" hl_lines="4 11" %}

<head>
    ...
    <!-- Syncfusion theme style sheet -->
    <link href="_content/Syncfusion.Blazor.Themes/fluent2.css" rel="stylesheet" />
    <HeadOutlet />
</head>

<body>
    ...
    <!-- Syncfusion Blazor Core script -->
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
</body>

{% endhighlight %}
{% endtabs %}

### 9. Create the _LoginPartial.cshtml file for Identity UI

Create the `_LoginPartial.cshtml` file to display the login, logout, register, and manage account links used by ASP.NET Core Identity. This partial view is shown in the navigation bar and updates based on whether the user is signed in.

Create a folder named `Pages` at the project root (next to Program.cs). Inside the Pages folder, create a subfolder named `Shared`. Then create a new file called **_LoginPartial.cshtml** and add the following content.

{% tabs %}
{% highlight c# tabtitle="Pages/Shared/_LoginPartial.cshtml" %}

@using Microsoft.AspNetCore.Identity
@inject SignInManager<IdentityUser> SignInManager
@inject UserManager<IdentityUser> UserManager

<ul class="navbar-nav">
@if (SignInManager.IsSignedIn(User))
{
    <li class="nav-item">
        <a class="nav-link text-dark" asp-area="Identity" asp-page="/Account/Manage/Index" title="Manage">
            @* Display the authenticated user's name *@
            Hello @User.Identity?.Name!
        </a>
    </li>
    <li class="nav-item">
        <form class="form-inline" asp-area="Identity" asp-page="/Account/Logout"
              asp-route-returnUrl="~/" method="post">
            <button type="submit" class="nav-link btn btn-link text-dark">Logout</button>
        </form>
    </li>
}
else
{
    <li class="nav-item">
        <a class="nav-link text-dark" asp-area="Identity" asp-page="/Account/Register">Register</a>
    </li>
    <li class="nav-item">
        <a class="nav-link text-dark" asp-area="Identity" asp-page="/Account/Login">Login</a>
    </li>
}
</ul>


{% endhighlight %}
{% endtabs %}

Create a file named `_ViewImports.cshtml` inside the `Pages` folder. This enables Tag Helpers for all Razor Pages, including the Identity UI pages.

{% tabs %}
{% highlight c# tabtitle="Pages/_ViewImports.cshtml" %}

@addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers

{% endhighlight %}
{% endtabs %}

### 10. Configure the Blazor router with authorization support

Update the router in your **App.razor** file so that Blazor can enforce authorization rules on your components. This allows pages marked with `[Authorize]` to require sign‑in before they are shown.

Find the `<body>` section in **App.razor** and update it to the following.

* Wrap the router in `<CascadingAuthenticationState>` so Blazor can pass authentication information to all components.
* Replace `<RouteView>` with `<AuthorizeRouteView>` so pages can show different content based on the user's sign‑in status.
* Keep the `<NotAuthorized>` and `<Authorizing>` sections to display messages to the user when needed.

This setup ensures protected pages only load after the user is authenticated and provides clear messages when access is denied.

{% tabs %}
{% highlight razor tabtitle="App.razor" %}

<body>
      <CascadingAuthenticationState>
        <Router AppAssembly="@typeof(App).Assembly">
            <Found Context="routeData">
                <AuthorizeRouteView RouteData="@routeData" DefaultLayout="@typeof(MainLayout)">
                    <NotAuthorized>
                        <p class="mt-3">
                            You are not authorized. Please
                            <a href="/Identity/Account/Login">log in</a>.
                        </p>
                    </NotAuthorized>
                    <Authorizing>
                        <p>Authorizing...</p>
                    </Authorizing>
                </AuthorizeRouteView>
                <FocusOnNavigate RouteData="@routeData" Selector="h1" />
            </Found>
            <NotFound>
                <LayoutView Layout="@typeof(MainLayout)">
                    <p>Sorry, there’s nothing at this address.</p>
                </LayoutView>
            </NotFound>
        </Router>
    </CascadingAuthenticationState>

    <ReconnectModal />
    ...

</body>

{% endhighlight %}
{% endtabs %}

N> `<ReconnectModal />` is a custom component for handling SignalR reconnection UI. If your template does not include it, you can omit this line.

### 11. Add authentication UI in Components/Layout/MainLayout.razor

Update your main layout to display authentication options in the header. The `<AuthorizeView>` component will display different links depending on whether the user is signed in. This gives users an easy way to access login, logout, register, or manage account pages.

Open **Components/Layout/MainLayout.razor** and replace its content with the updated layout.

{% tabs %}
{% highlight razor tabtitle="MainLayout.razor" %}

@inherits LayoutComponentBase
@using Microsoft.AspNetCore.Components.Authorization  @* needed for <AuthorizeView> *@

<div class="page">
    <div class="sidebar">
        <NavMenu />
    </div>

    <main>
        <div class="top-row px-4 d-flex align-items-center">
            <a href="https://learn.microsoft.com/aspnet/core/" target="_blank">About</a>

            <!-- Right-aligned auth menu -->
            <div class="ms-auto d-flex gap-3">
                <AuthorizeView>
                    <Authorized>
                        <span class="navbar-text">Hello @context.User.Identity?.Name</span>

                        <!-- Manage (Identity UI) -->
                        <a class="nav-link text-dark" href="/Identity/Account/Manage/Index" title="Manage">Manage</a>

                        <!-- Logout: GET request shows confirmation page, then POST with antiforgery token completes logout -->
                        <a class="nav-link text-dark" href="/Identity/Account/Logout">Logout</a>
                    </Authorized>

                    <NotAuthorized>
                        <a class="nav-link text-dark" href="/Identity/Account/Login">Login</a>
                        <a class="nav-link text-dark" href="/Identity/Account/Register">Register</a>
                    </NotAuthorized>
                </AuthorizeView>
            </div>
        </div>

        <article class="content px-4">
            @Body
        </article>
    </main>
</div>

<div id="blazor-error-ui" data-nosnippet>
    An unhandled error has occurred.
    <a href="." class="reload">Reload</a>
    <span class="dismiss">🗙</span>
</div>

{% endhighlight %}
{% endtabs %}

### 12. Create the secure Syncfusion DataGrid and Charts pages

Create two protected pages using `[Authorize]` that display Syncfusion DataGrid and Charts components. The generated components will use the default namespace `BlazorIdentitySyncfusion.Components.Pages`. If needed, adjust the `@namespace` directive in the generated files.

{% tabs %}
{% highlight c# tabtitle=".NET CLI" %}

dotnet new razorcomponent -n SecureGrid -o Components/Pages
dotnet new razorcomponent -n SecureChart -o Components/Pages

{% endhighlight %}
{% endtabs %}

**Add Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid component**

This component displays a sample order list using Syncfusion's DataGrid. The `@attribute [Authorize]` directive ensures only authenticated users can access this page.

{% tabs %}
{% highlight razor tabtitle="SecureGrid.razor" %}

@page "/secure-grid"
@attribute [Authorize]
@rendermode InteractiveServer

<PageTitle>Secure Grid</PageTitle>
<h1>Orders (Authorized users only)</h1>

<SfGrid DataSource="@Orders">
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120" />
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer" Width="150" />
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText="Order Date" Format="d" Type="ColumnType.Date" Width="140" />
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120" />
    </GridColumns>
</SfGrid>

@code {
    public List<Order> Orders { get; set; } = default!;

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 12).Select(i => new Order {
            OrderID = 1000 + i,
            CustomerID = new[] { "ALFKI","ANATR","ANTON","BLONP","BOLID" }[Random.Shared.Next(5)],
            OrderDate = DateTime.Today.AddDays(-i),
            Freight = Math.Round(25 + 15 * Random.Shared.NextDouble(), 2)
        }).ToList();
    }

    public class Order
    {
        public int OrderID { get; set; }
        public string? CustomerID { get; set; }
        public DateTime OrderDate { get; set; }
        public double Freight { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

**Add Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Charts component**

This component displays a column chart showing monthly sales data.

{% tabs %}
{% highlight razor tabtitle="SecureChart.razor" %}

@page "/secure-chart"
@attribute [Authorize]
@rendermode InteractiveServer

<PageTitle>Secure Chart</PageTitle>
<h1>Monthly Sales (Authorized users only)</h1>

<SfChart Title="Sales (USD)">
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category"></ChartPrimaryXAxis>
    <ChartSeriesCollection>
        <ChartSeries DataSource="Data"
                     XName="Month" YName="Amount"
                     Type="Syncfusion.Blazor.Charts.ChartSeriesType.Column"
                     Name="Sales" />
    </ChartSeriesCollection>
</SfChart>

@code {
    public List<Point> Data { get; set; } = new()
    {
        new("Jan", 42500), new("Feb", 39100), new("Mar", 45900),
        new("Apr", 54400), new("May", 49350), new("Jun", 61200)
    };

    public record Point(string Month, double Amount);
}

{% endhighlight %}
{% endtabs %}

### 13. Add secure links to the left navigation

Update the navigation menu to include links to your secured pages. This makes them easily accessible from any page in your application. When users click these links, they'll be able to access the pages if logged in, or will be prompted to log in if they're not authenticated.

Open **Components/Layout/NavMenu.razor** and add the following navigation items after the existing menu links.

{% tabs %}
{% highlight c# tabtitle="Layout/NavMenu.razor" %}

...

<!-- Secure pages (protected by [Authorize]) -->
<div class="nav-item px-3">
    <NavLink class="nav-link" href="secure-grid">
        <span class="bi bi-list-nested" aria-hidden="true"></span> Secure Grid
    </NavLink>
</div>

<div class="nav-item px-3">
    <NavLink class="nav-link" href="secure-chart">
        <span class="bi bi-list-nested" aria-hidden="true"></span> Secure Chart
    </NavLink>
</div>

{% endhighlight %}
{% endtabs %}

### 14. Generate and apply EF Core migrations

Create the database tables required for ASP.NET Core Identity by running Entity Framework Core migrations. Migrations generate the schema and apply it to your SQLite database.

If you have not installed the EF Core command‑line tools, install them first.

{% tabs %}
{% highlight c# tabtitle=".NET CLI" %}

dotnet tool install --global dotnet-ef 

{% endhighlight %}
{% endtabs %}

Then create the migration and update the database.

{% tabs %}
{% highlight c# tabtitle=".NET CLI" %}

dotnet ef migrations add CreateIdentitySchema
dotnet ef database update

{% endhighlight %}
{% endtabs %}

After these commands run, the SQLite database will include the Identity tables such as AspNetUsers, AspNetRoles, and others used for authentication.

### 15. Run the application and validate authentication flow

Run the application and verify the authentication flow.

{% tabs %}
{% highlight c# tabtitle=".NET CLI" %}

dotnet run

{% endhighlight %}
{% endtabs %}

1. Open a browser and navigate to `https://localhost:<port>` (the port is shown in the terminal output).
2. Click **Secure Grid** or **Secure Chart** in the left navigation.
3. You will be redirected to the Identity login page (`/Identity/Account/Login`) because you are not authenticated.
4. Click **Register** and create a new account (email and password).
5. After registration, you will be automatically logged in.
6. Navigate back to **Secure Grid** or **Secure Chart** - the pages should now render successfully with Syncfusion components.
7. Click **Logout** to end the session and verify that accessing the secure pages redirects back to the login page. 

