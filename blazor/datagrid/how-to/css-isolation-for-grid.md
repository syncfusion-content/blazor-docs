---
layout: post
title: CSS isolation for Blazor DataGrid Component | Syncfusion
description: Checkout and learn here all about applying styles by using CSS isolation in Syncfusion Blazor DataGrid component and more.
platform: Blazor
control: DataGrid
documentation: ug
---

# CSS isolation for DataGrid

CSS isolation allows defining component-specific styles by creating a `.razor.css` file that matches the name of the `.razor` file. This ensures that the styles apply only to the intended component without affecting other parts of the application. For example, to apply styles to an `Index` component, create a file named `Index.razor.css` in the same folder as `Index.razor`.

To enable CSS isolation for the Grid, it is recommended to wrap the **SfGrid** inside a standard HTML <div> element. This setup helps properly scope the styles when using the **::deep** combinator, which is required to target nested child elements within the isolated styles.

Below is an example of implementing a simple Grid inside the `Index.razor` file:

```csharp

Index.razor

@using Syncfusion.Blazor.Grids

<div>
    <SfGrid DataSource="@Orders" AllowPaging="true">
        <GridColumns>
            <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
            <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="120"></GridColumn>
            <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" EditType="EditType.DatePickerEdit" Format="d" TextAlign="TextAlign.Right" Width="130" Type="ColumnType.Date"></GridColumn>
            <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" EditType="EditType.NumericEdit" Width="120"></GridColumn>
            <GridColumn Field=@nameof(Order.ShipCountry) HeaderText="Ship Country" EditType="EditType.DropDownEdit" Width="150"></GridColumn>
        </GridColumns>
    </SfGrid>
</div>

@code{
    public List<Order> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
        {
            OrderID = 1000 + x,
            CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
            Freight = 2.1 * x,
            OrderDate = DateTime.Now.AddDays(-x),
            ShipCountry = (new string[] { "USA", "UK", "CHINA", "RUSSIA", "INDIA" })[new Random().Next(5)]
        }).ToList();
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
        public string ShipCountry { get; set; }
    }
}
```

```csharp
Index.razor.css
::deep .e-grid .e-altrow {
    background-color: violet;
}
```
> Please find the sample in this [GitHub location](https://github.com/SyncfusionExamples/How-to-Getting-Started-Blazor-DataGrid-Samples/tree/master/CSS_Isolation).

N> You can get more information on CSS Isolation [here](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/css-isolation?view=aspnetcore-8.0#child-component-support).