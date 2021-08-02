---
layout: post
title: Right-To-Left in Blazor - Syncfusion
description: Check out the documentation for Right-To-Left in Blazor
platform: Blazor
component: Common
documentation: ug
---

# Right-To-Left

The right-to-left (RTL) support can be enabled for Syncfusion Blazor components by setting `EnableRtl` to `true`. This will render all the Syncfusion Blazor components in the right-to-left direction.

## Enable RTL to individual component

To control a component’s direction, set the component’s `EnableRtl` property to true directly. For illustration, the RTL support has been enabled for the DropDownList component in the following code snippet.

```csharp

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

To control the direction of all Syncfusion Blazor components in an application, import `Syncfusion.Blazor`, inject  and the `SyncfusionBlazorService` in your `@code` section and invoke `EnableRtl` method. In the following code snippet, the RTL support has been enabled for all Syncfusion Blazor components.

```csharp

@using Syncfusion.Blazor;
@using Syncfusion.Blazor.Grids;

<SfGrid DataSource="@Orders" AllowPaging="true" AllowSorting="true" AllowFiltering="true" AllowGrouping="true"  EnablePersistence="true">
    <GridPageSettings PageSize="8"></GridPageSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="100"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign. Right" Width="100"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></    GridColumn>
    </GridColumns>
</SfGrid>

@code {
    [Inject]
    SyncfusionBlazorService SyncfusionService { get; set; }
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

        //Set EnableRtl to all Syncfusion Blazor Components
        SyncfusionService.EnableRtl();
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
