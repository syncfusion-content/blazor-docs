---
layout: post
title: CSS isolation for Blazor DataGrid Component | Syncfusion
description: Checkout and learn here all about applying styles by using CSS isolation in Syncfusion Blazor DataGrid component and more.
platform: Blazor
control: DataGrid
documentation: ug
---

# CSS isolation for datagrid component

By using the CSS isolation, you can define component-specific styles by creating a .razor.css file matching the name of the .razor file in the same folder. For example, to apply CSS for `Index` Component, create a file named `Index.razor.css`.

To apply the CSS isolation for the DataGrid component, you have to wrap the SfGrid Component inside a HTML div element and then use the **::deep** selector as like provided in the below code snippet.

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

> You can get more information on CSS Isolation [`here`](https://docs.microsoft.com/en-us/aspnet/core/blazor/components/css-isolation?view=aspnetcore-5.0#child-component-support).