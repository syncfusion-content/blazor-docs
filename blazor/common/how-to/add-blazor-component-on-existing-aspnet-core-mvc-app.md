---
layout: post
title: Client Resources in Production Environment in Blazor - Syncfusion
description: Check out the documentation for Configure Syncfusion Blazor Client Resources in Production Environment in Blazor
platform: Blazor
component: Common
documentation: ug
---

# How to Add Blazor Component into Existing ASP.NET Core MVC Application

This section explains how to add Syncfusion Blazor component on an existing ASP.NET Core MVC application.

1. Open your existing ASP.NET Core MVC application on Visual Studio 2022.

2. Right-click on the project and select `Manage NuGet Package`.

    ![Manage NuGet package on ASP.NET Core MVC app](images/asp-mvc-manage-nuget-package.png)

3. Search the `Syncfusion.Blazor.Grid` and `Syncfusion.Blazor.Themes` NuGet packages and install them.

    ![Installing Syncfusion Blazor Grid NuGet package](images/asp-mvc-install-nuget.png)

4. Register Blazor server service and Syncfusion Blazor service in the `~/Program.cs` file.

    ```c#
    using Syncfusion.Blazor;
    ....
    builder.Services.AddServerSideBlazor();
    builder.Services.AddSyncfusionBlazor();

    ```

5. Add BlazorHub in the `~/Program.cs` file.

    ```c#
    // Map your endpoints here...

    app.MapRazorPages();
    app.MapBlazorHub();
    app.MapFallbackToPage("/_Host");
    ```

6. Create `~/_Imports.razor` file in the root of your application and add the below namespaces.

    ```cshtml
    @using System.Net.Http
    @using Microsoft.AspNetCore.Authorization
    @using Microsoft.AspNetCore.Components.Authorization
    @using Microsoft.AspNetCore.Components.Forms
    @using Microsoft.AspNetCore.Components.Routing
    @using Microsoft.AspNetCore.Components.Web
    @using Microsoft.AspNetCore.Components.Web.Virtualization
    @using Microsoft.JSInterop
    @using AspCoreMvcApp;
    @using Syncfusion.Blazor
    @using Syncfusion.Blazor.Grids
    ```

7. Add Blazor script references at the end of `<body>` tag and Syncfusion theme and script references inside the `<head>` tag on `~/Views/Shared/_Layout.cshtml` file.

    ```cshtml
    <head>
        ....
        ....
        <link href="_content/Syncfusion.Blazor.Themes/bootstrap4.css" rel="stylesheet" />
        <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
    </head>
    <body>
        ....
        ....
        <script src="_framework/blazor.server.js"></script>
    </body>
    ```

8. Create a new folder `~/Components` at the root of application. Right-click on the `~/Components` folder and add a new razor component by `Add -> Razor Component`.

9. Add the Syncfusion Blazor component in the created razor file.

    ```cshtml
    <SfGrid DataSource="@Orders" AllowPaging="true">
        <GridPageSettings PageSize="5"></GridPageSettings>
        <GridColumns>
            <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" Width="120"></GridColumn>
            <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
            <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Width="130"></GridColumn>
            <GridColumn Field=@nameof(Order.Freight) Format="C2" Width="120"></GridColumn>
        </GridColumns>
    </SfGrid>

    @code{
        public List<Order> Orders { get; set; }

        protected override void OnInitialized()
        {
            Orders = Enumerable.Range(1, 50).Select(x => new Order()
            {
                OrderID = 1000 + x,
                CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
                Freight = 2.1 * x,
                OrderDate = DateTime.Now.AddDays(-x),
            }).ToList();
        }

        public class Order
        {
            public int? OrderID { get; set; }
            public string CustomerID { get; set; }
            public DateTime? OrderDate { get; set; }
            public double? Freight { get; set; }
        }
    }
    ```

10. Now, add the razor component in the `~/Views/Home/Index.cshtml` page using `component` tag helper. The `.razor` file name will be considered as a Razor component. For example, the above SfGrid component is added on `~/Components/MyGrid.razor` file.

    ```cshtml
    @using AspCoreMvcApp.Components;

    <component type="typeof(MyGrid)" render-mode="ServerPrerendered" />
    ```

11. Run the application by pressing `F5` key. Now, the Syncfusion Blazor Grid component will be rendered in the ASP.NET Core MVC application.

    ![Syncfusion Blazor Grid component rendered on ASP.NET Core MVC application](images/asp-mvc-grid.png)

## See Also

* [Component Tag Helper in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/mvc/views/tag-helpers/built-in/component-tag-helper?view=aspnetcore-7.0)
* [Integrating Blazor Components on Existing ASP.NET Core MVC apps](https://devblogs.microsoft.com/premier-developer/integrating-blazor-components-into-existing-asp-net-core-mvc-apps/)
