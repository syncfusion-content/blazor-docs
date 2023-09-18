---
layout: post
title: Using dictionary values as datasource in Blazor DataGrid | Syncfusion
description: Learn here all about using dictionary values as datagrid datasource in Syncfusion Blazor DataGrid component and more.
platform: Blazor
control: DataGrid
documentation: ug
---

# Using Dictionary Values as Datasource in Blazor DataGrid Component

You can assign dictionary values in the datagrid's data source by accessing them using **KeyValuePair** data type inside the [Template](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Template) property of the [GridColumn](https://help.syncfusion.com/cr/aspnetcore-blazor/Syncfusion.Blazor.Grids.GridColumn.html) component

This is demonstrated in the following sample code, where **ShipName** is defined as Dictionary value and it is accessed inside the template property of the [GridColumn](https://help.syncfusion.com/cr/aspnetcore-blazor/Syncfusion.Blazor.Grids.GridColumn.html) using **KeyValuePair** data type. The key value is compared with the **OrderID** column value and based on that the value is displayed,

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@GridData" AllowPaging="true">
    <GridPageSettings PageSize="6"></GridPageSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderDetail.OrderID) HeaderText="Order ID" TextAlign="@TextAlign.Right" IsPrimaryKey="true" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetail.OrderDate) HeaderText=" Order Date" Format="d" Type=ColumnType.Date TextAlign="@TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(OrderDetail.Freight) HeaderText="Freight" Format="C2" AllowEditing="false" TextAlign="@TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetail.ShipCountry) HeaderText="Ship Country" TextAlign="@TextAlign.Right" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderDetail.ShipCity) HeaderText="Ship City" TextAlign="@TextAlign.Right" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderDetail.ShipName) HeaderText="Ship Name" TextAlign="@TextAlign.Right" Width="150">
            <Template>
                @{
                    var Details = context as OrderDetail;
                    var address = Details.ShipName.Select(kvp => (kvp.Key == Details.OrderID) ? kvp.Value.ToString() : "");
                    <p>@string.Join("", address)</p>
                }
            </Template>
        </GridColumn>
    </GridColumns>
</SfGrid>

@code{
    private static Dictionary<int, string> ShipDetails = new Dictionary<int, string>()
    {
        { 1001, "White Clover Markets" },
        { 1002, "Vins et alcools Chevalier" },
        { 1003, "Save-a-lot Markets" },
        { 1004, "Vins et alcools Chevalier" },
        { 1005, "Save-a-lot Markets" },
        { 1006, "Victuailles en stock" },
        { 1007, "Rattlesnake Canyon Grocery" },
        { 1008, "Victuailles en stock" },
        { 1009, "Rattlesnake Canyon Grocery" },
        { 1010, "Blondel et fils" }
    };

    List<OrderDetail> GridData = new List<OrderDetail>
    {
        new OrderDetail { OrderID = 1001, Freight = 2.3, OrderDate = new DateTime(1991, 05, 15), ShipCity = "Seattle", ShipName = ShipDetails, ShipCountry = "United States" },
        new OrderDetail { OrderID = 1002, Freight = 3.3, OrderDate = new DateTime(1990, 04, 04), ShipCity = "Reims", ShipName = ShipDetails, ShipCountry = "France" },
        new OrderDetail { OrderID = 1003, Freight = 5.3, OrderDate = new DateTime(1957, 11, 30), ShipCity = "Boise", ShipName = ShipDetails, ShipCountry = "United States" },
        new OrderDetail { OrderID = 1004, Freight = 2.3, OrderDate = new DateTime(1992, 07, 14), ShipCity = "Reims", ShipName = ShipDetails, ShipCountry = "France" },
        new OrderDetail { OrderID = 1005, Freight = 5.3, OrderDate = new DateTime(1927, 01, 20), ShipCity = "Boise", ShipName = ShipDetails, ShipCountry = "United States" },
        new OrderDetail { OrderID = 1006, Freight = 9.3, OrderDate = new DateTime(1920, 02, 15), ShipCity = "Lyon", ShipName = ShipDetails, ShipCountry = "France" },
        new OrderDetail { OrderID = 1007, Freight = 6.3, OrderDate = new DateTime(1951, 12, 08), ShipCity = "Albuquerque", ShipName = ShipDetails, ShipCountry = "United States" },
        new OrderDetail { OrderID = 1008, Freight = 4.3, OrderDate = new DateTime(1930, 10, 22), ShipCity = "Lyon", ShipName = ShipDetails, ShipCountry = "France" },
        new OrderDetail { OrderID = 1009, Freight = 6.3, OrderDate = new DateTime(1953, 02, 18), ShipCity = "Albuquerque", ShipName = ShipDetails, ShipCountry = "United States" },
        new OrderDetail { OrderID = 1010, Freight = 4.3, OrderDate = new DateTime(1923, 01, 28), ShipCity = "Strasbourg", ShipName = ShipDetails, ShipCountry = "France" }
    };

    public class OrderDetail
    {
        public int? OrderID { get; set; }
        public double? Freight { get; set; }
        public string ShipCity { get; set; }
        public DateTime OrderDate { get; set; }
        public string ShipCountry { get; set; }
        public Dictionary<int, string> ShipName { get; set; }
    }
}
```

The following image represent the datagrid rendered using the above sample code,

![Dictionary Values in Blazor DataGrid](../images/blazor-datagrid-dictionary-values.png)
