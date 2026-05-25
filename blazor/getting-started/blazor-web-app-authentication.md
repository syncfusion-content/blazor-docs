---
layout: post
title: Getting Started with Blazor Web App Authentication | Syncfusion
description: Check out the documentation for getting started with Blazor Web App and Blazor Components with Authentication.
platform: Blazor
component: Common
documentation: ug
---

# Getting Started with Blazor Web App Authentication

This guide explains how to create a Blazor Web App with authentication enabled. You will learn how to use the built-in `AuthenticationStateProvider` to manage user identity and integrate the [Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) component for authenticated users.

## Create a new Blazor Web App 

To create a new Blazor Web App, follow the [Blazor getting started guide](https://blazor.syncfusion.com/documentation/getting-started/blazor-web-app?tabcontent=visual-studio-code).

Ensure the **Configure for HTTPS** option is enabled, and select **Individual Accounts** as the authentication type. This enables authentication support without persisting user data in a local database.

![Project-setting](images/project-setting.webp)

If using Visual Studio Code, run the following commands in your command-line interface (CLI):

{% tabs %}
{% highlight bash tabtitle=".NET CLI" %}

dotnet new blazor -o BlazorAppAuthentication --interactivity Server --auth Individual
cd BlazorAppAuthentication
dotnet run

{% endhighlight %}
{% endtabs %}

## Register a User

After creating the project, run the application. On the registration page, click the **Register** button. Enter your **email address** and **password**, then click **Register** to create a new account.

![Enter-register-details](images/register-details.webp)

## Apply Database Migrations

After registration completes, click **Apply Migrations** to create the database schema and configure account-related tables and settings.

![Apply-migration](images/apply-migration.webp)

## Verify Login

Once migrations are complete, refresh the page. You should see your email address displayed and a **Logout** option, confirming you are signed in.

![Verify-login](images/verify-login.webp)

## Integrating Blazor component

Blazor components can be integrated within the **AuthorizeView** component as shown in the following steps.

### Install NuGet packages

To add the [Blazor Grid](https://www.syncfusion.com/blazor-components/blazor-datagrid) component to your application, open the NuGet Package Manager in Visual Studio **(*Tools → NuGet Package Manager → Manage NuGet Packages for Solution*)**. Search and install the [Syncfusion.Blazor.Grid](https://www.nuget.org/packages/Syncfusion.Blazor.Grid/) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/) packages.

Alternatively, install the packages by using the following command in the **Package Manager Console**:

{% tabs %}
{% highlight bash tabtitle=".NET CLI" %}

dotnet add package Syncfusion.Blazor.Grid -v {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Themes -v {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

### Register Blazor Service

Register the Blazor service in the **~/Program.cs** file of the Blazor Web App.

{% tabs %}
{% highlight c# tabtitle="Program.cs" %}

using Syncfusion.Blazor;
....
builder.Services.AddSyncfusionBlazor();
....

{% endhighlight %}
{% endtabs %}

### Add required namespaces

Open the `~/_Imports.razor` file and import the namespaces.

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
    ....
    <!-- Theme stylesheet -->
    <link href="_content/Syncfusion.Blazor.Themes/fluent2.css" rel="stylesheet" />
    ....
</head>

<body>
    ....
    <!-- Blazor core script (required for UI components, including DataGrid) -->
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
    ....
</body>

{% endhighlight %}
{% endtabs %}

### Add Blazor component

Add the [Blazor Grid](https://www.syncfusion.com/blazor-components/blazor-datagrid) component in the **~/Pages/Home.razor** file within an `AuthorizeView`.

{% tabs %}
{% highlight razor tabtitle="Pages/Home.razor" %}

<AuthorizeView>
    <Authorized>
        <SfGrid DataSource="@Orders">
            <GridColumns>
                <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120" />
                <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer ID" Width="100" />
                <GridColumn Field=@nameof(Order.OrderDate) HeaderText="Order Date" Format="d" Type="ColumnType.Date" Width="100" />
                <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120" />
            </GridColumns>
        </SfGrid>
    </Authorized>
    <NotAuthorized>
        <h1>Authentication Failure!</h1>
        <p>You're not signed in.</p>
    </NotAuthorized>
</AuthorizeView>

@code {
    public List<Order> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 12).Select(i => new Order
        {
            OrderID = 1000 + i,
            CustomerID = new[] { "ALFKI", "ANATR", "ANTON", "BLONP", "BOLID" }[Random.Shared.Next(5)],
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

### Run the application

To run the application, use the following command:

{% tabs %}
{% highlight bash tabtitle=".NET CLI" %}

dotnet run

{% endhighlight %}
{% endtabs %}

![Blazor Grid Component](images/sync-components-auth.webp)

N> For a complete implementation, download the demo project from the [GitHub repository](https://github.com/SyncfusionExamples/blazor-authentication).

## See Also

* [Getting Started with Blazor WASM App with Authentication Library](https://blazor.syncfusion.com/documentation/getting-started/blazor-webassembly-authentication)

* [Secure an ASP.NET Core Blazor WebAssembly standalone app with the Authentication library](https://learn.microsoft.com/en-us/aspnet/core/blazor/security/webassembly/standalone-with-authentication-library?view=aspnetcore-8.0&tabs=visual-studio)

