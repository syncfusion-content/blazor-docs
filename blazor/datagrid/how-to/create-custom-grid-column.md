---
layout: post
title: Create custom Grid column in Blazor DataGrid Component | Syncfusion
description: Checkout and learn here all about Create custom Grid column component in Syncfusion Blazor DataGrid component and more.
platform: Blazor
control: DataGrid
documentation: ug
---

# Create Custom GridColumn in Blazor DataGrid Component

To create custom Grid columns and maintain their display order, follow these steps:

In the following sample code, there are two custom columns defined inside the Grid. By extending the code in the below way will maintain the displayed order.

Index.razor

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" AllowPaging="true">
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="@TextAlign.Center" HeaderTextAlign="@TextAlign.Center" Width="140"></GridColumn>
        <AlignLeftColumn Field=@nameof(Order.OrderDate) HeaderText="Order Date" TextAlign="@TextAlign.Left" HeaderTextAlign="@TextAlign.Left" Width="140"></AlignLeftColumn>
        <CustomerColumn></CustomerColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" Width="140" TextAlign="@TextAlign.Right" HeaderTextAlign="@TextAlign.Right"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    public List<Order> Orders { get; set; }
    public SfGrid<Order> GridObj;
    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
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
In the below code the custom columns are defined by extending the GridColumn component.

Extend the GridColumn components to define your custom columns and their properties. These properties could include header text alignment, column type, text alignment, width, and more.

AlignmentLeftColumn.razor

```csharp
@using Syncfusion.Blazor.Grids

@inherits GridColumn

@ChildContent

@code {
    protected override void OnInitialized()
    {
        base.OnInitialized();

        HeaderTextAlign = TextAlign.Left;
        Type = ColumnType.String;
        TextAlign = TextAlign.Center;
        Width = "30";
    }
}

```

CustomerColumn.razor

```csharp

@using Syncfusion.Blazor.Grids

@inherits GridColumn

@ChildContent

@code {
    protected override void OnInitialized()
    {
        base.OnInitialized();
        Field = "CustomerID";
        HeaderText = "Customer Name";
        Width = "150";
    }
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LDLqtbZYpfMwjWpB?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

N> While rendering the custom GridColumn in a separate razor page, the position or order of that specific column will not align properly unless if we extend or create the customized Grid column component by inheriting the GridColumn class in razor page.