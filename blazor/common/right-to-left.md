---
layout: post
title: Right-To-Left (RTL) support in Blazor - Syncfusion
description: Learn here about that how to enable the Right-To-Left (RTL) support for Syncfusion Blazor Components.
platform: Blazor
component: Common
documentation: ug
---

# Right-To-Left

The right-to-left (RTL) support can be enabled for Syncfusion Blazor components by setting `EnableRtl` to `true`. This will render all the Syncfusion Blazor components in the right-to-left direction.

## Enable RTL to individual component

To control a component’s direction, set the component’s `EnableRtl` property to true directly. For illustration, the RTL support has been enabled for the DropDownList component in the following code snippet.

```cshtml

@using Syncfusion.Blazor.DropDowns

<SfDropDownList TValue="string" Placeholder="Select the country" TItem="Countries" DataSource="@CountryList" EnableRtl="true">
    <DropDownListFieldSettings Text="Name" Value="Code"></DropDownListFieldSettings>
</SfDropDownList>

@code {

    SfDropDownList<string, Countries> dropdownObj;

    public class Countries
    {
        public string Name { get; set; }

        public string Code { get; set; }
    }
    List<Countries> CountryList = new List<Countries>
    {
        new Countries() { Name = "Australia", Code = "AU" },
        new Countries() { Name = "Bermuda", Code = "BM" },
        new Countries() { Name = "Canada", Code = "CA" },
        new Countries() { Name = "Cameroon", Code = "CM" }
    };
}

```

After the successful compilation, press F5 to run the application. The following screenshot illustrates the output.

![Blazor component is rendered from the right-to-left](images/rightToLeft.png)

## Enable RTL for all components

To control the direction of all Syncfusion Blazor components in an application, set the [EnableRtl](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.GlobalOptions.html#Syncfusion_Blazor_GlobalOptions_EnableRtl) global option as `true` while adding Syncfusion blazor service using `AddSyncfusionBlazor()`.

* If you're using `.NET 6` Blazor Server App, set [EnableRtl](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.GlobalOptions.html#Syncfusion_Blazor_GlobalOptions_EnableRtl) property as `true` using `AddSyncfusionBlazor` service method in `~/Program.cs` file.

    ```c#
    // For .NET 6 project, add the EnableRtl in Syncfusion Blazor Service in Program.cs file.
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Web;
    using Syncfusion.Blazor;

    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddRazorPages();
    builder.Services.AddServerSideBlazor();
    ....
    builder.Services.AddSyncfusionBlazor(options => { options.EnableRtl = true; });
    var app = builder.Build();
    ....
    ....
    ```

* If you're using `.NET 5 or .NET Core SDK 3.1 project` Blazor Server App, set [EnableRtl](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.GlobalOptions.html#Syncfusion_Blazor_GlobalOptions_EnableRtl) property as `true` using `AddSyncfusionBlazor` service method in `~/Startup.cs` file.

    ```c#
    // For .NET 5 or .NET Core SDK 3.1 project, add the EnableRtl in Syncfusion Blazor Service in Startup.cs file.
    using Syncfusion.Blazor;
    namespace WebApplication1
    {
        public class Startup
        {
            public void ConfigureServices(IServiceCollection services)
            {
                ....
                ....
                services.AddSyncfusionBlazor(options => { options.EnableRtl = true; });
            }
        }
    }
    ```

* If you're using Blazor WebAssembly App, set [EnableRtl](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.GlobalOptions.html#Syncfusion_Blazor_GlobalOptions_EnableRtl) property as `true` using `AddSyncfusionBlazor` service method in `~/Program.cs` file.

    ```c#
    // For .NET 6 project.
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Web;
    using Syncfusion.Blazor;

    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddRazorPages();
    builder.Services.AddServerSideBlazor();
    ....
    builder.Services.AddSyncfusionBlazor(options => { options.EnableRtl = true; });
    var app = builder.Build();
    ....
    ....

    // For .NET 5 or .NET Core SDK 3.1 project.
    using Syncfusion.Blazor;
    ....
    ....
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args)    ;
        ....
        ....

        // Set IgnoreScriptIsolation as true to load custom  scripts
        builder.Services.AddSyncfusionBlazor(options => { options.EnableRtl = true; });
        await builder.Build().RunAsync();
    }
    ```

The following example demonstrates how to enable RTL support for Syncfusion Blazor DataGrid component using [EnableRlt](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.GlobalOptions.html#Syncfusion_Blazor_GlobalOptions_EnableRtl) global option in Blazor Server App.

* Create a Blazor Server App and set the [EnableRlt](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.GlobalOptions.html#Syncfusion_Blazor_GlobalOptions_EnableRtl) global option as `true` in `AddSyncfusionBlazor()` service.

    ```c#
    // For .NET 6 project, add the EnableRtl in Syncfusion Blazor Service in Program.cs file.
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Web;
    using Syncfusion.Blazor;

    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddRazorPages();
    builder.Services.AddServerSideBlazor();
    ....
    builder.Services.AddSyncfusionBlazor(options => { options.EnableRtl = true; });
    var app = builder.Build();
    ....
    ....

    // For .NET 6 project, add the EnableRtl in Syncfusion Blazor Service in Startup.cs file.
    using Syncfusion.Blazor;
    namespace WebApplication1
    {
        public class Startup
        {
            public void ConfigureServices(IServiceCollection services)
            {
                ....
                ....
                services.AddSyncfusionBlazor(options => { options.EnableRtl = true; });
            }
        }
    }
    ```

* Add the Syncfusion Blazor DataGrid component to the `~/Pages/Index.razor` file.

    ```cshtml

    @using Syncfusion.Blazor;
    @using Syncfusion.Blazor.Grids;

    <SfGrid DataSource="@Orders" AllowPaging="true" AllowSorting="true" AllowFiltering="true" AllowGrouping="true"  EnablePersistence="true">
        <GridPageSettings PageSize="8"></GridPageSettings>
        <GridColumns>
            <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="100"></GridColumn>
            <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="120"></GridColumn>
            <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign. Right" Width="100"></GridColumn>
            <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        </GridColumns>
    </SfGrid>

    @code {
        public List<Order> Orders { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            Orders = Enumerable.Range(1, 25).Select(x => new Order()
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

![Blazor Grid component is rendered from the right to left](images/rteGrid.png)
