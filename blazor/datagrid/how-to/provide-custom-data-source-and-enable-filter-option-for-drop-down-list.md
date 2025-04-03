---
layout: post
title: Data source & filtering for DropDownList | Syncfusion Blazor DataGrid 
description: Learn here all about providing custom data source and enabling filtering for DropDownList in Syncfusion Blazor DataGrid component and more.
platform: Blazor
control: DataGrid
documentation: ug
---

# Custom Data Source & Filtering for DropDownList in Blazor DataGrid

You can provide custom data source and enable filter option for DropDownList while performing DataGrid editing by using the [Edit](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html) params property.

While setting new data source for DropDownList using [Edit](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html) params, you must also specify a new [Query](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.DropDownListModel-2.html#Syncfusion_Blazor_DropDowns_DropDownListModel_2_Query) property for DropDownList.

This is demonstrated in the following sample code,

```cshtml
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.DropDowns

<SfGrid DataSource="@Orders" AllowPaging="true" Toolbar="@(new List<string>(){"Add","Edit","Delete","Update","Cancel"})">
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" EditType="EditType.DropDownEdit" EditorSettings="@CustomerIDEditParams" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type=ColumnType.Date Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code{

    public List<Order> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
        {
            OrderID = 1000 + x,
            CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
            Freight = 2.5 * x,
            OrderDate = DateTime.Now.AddDays(-x),
        }).ToList();
    }
    public IEditorSettings CustomerIDEditParams = new DropDownEditCellParams
    {
        Params = new DropDownListModel<object, object>() { DataSource = LocalData, AllowFiltering = true }
    };
    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }
    public static List<Order> LocalData = new List<Order> {
                new Order() { CustomerID= "United States" },
                new Order() { CustomerID= "Australia" },
                new Order() { CustomerID= "India" }
    };
}
```
