---
layout: post
title: Using dictionary values as datasource in Blazor DataGrid | Syncfusion
description: Learn here all about using dictionary values as datagrid datasource in Syncfusion Blazor DataGrid component and more.
platform: Blazor
control: DataGrid
documentation: ug
---

# Using dictionary values as datasource in Blazor DataGrid

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid can use dictionary values as a data source within a column by accessing them through the **KeyValuePair** type inside the column's [Template](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Template). This is helpful when you want to display values from a shared dictionary that maps keys to specific values. Since a dictionary isn't a typical scalar field, a custom template is needed to extract and display the correct value for each row using the row's key.

This is demonstrated in the following sample code, where **ShipName** is defined as Dictionary value and it is accessed inside the template property of the `GridColumn` using **KeyValuePair** data type. The key value is compared with the **OrderID** column value and based on that the value is displayed.This approach allows each row in the Grid to dynamically retrieve and render the appropriate dictionary value based on its key:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
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
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rtheXzKjfXFpgmwJ?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}
