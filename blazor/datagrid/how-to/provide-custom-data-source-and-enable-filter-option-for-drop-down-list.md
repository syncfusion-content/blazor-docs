---
layout: post
title: Data source & filtering for DropDownList | Syncfusion Blazor DataGrid 
description: Learn here all about providing custom data source and enabling filtering for DropDownList in Syncfusion Blazor DataGrid component and more.
platform: Blazor
control: DataGrid
documentation: ug
---

# Custom Data Source & Filtering for DropDownList in Blazor DataGrid

In the Syncfusion Blazor DataGrid, a custom data source can be provided for the DropDownList used during editing by configuring the `EditType` and assigning a custom data source using `EditorSettings`. Along with the data, filtering support can be enabled by setting the `AllowFiltering` property to **true**. This helps users easily search and select values, especially when the dropdown contains many items.

To achieve this, a `DropDownEditCellParams` object is defined with a `DropDownListModel` that includes a custom data source. This configuration is then assigned to the `EditorSettings` of the target Grid column. In the sample, the Customer Name column uses a local list of country names as its dropdown data source with filtering enabled for better usability during editing.

This is demonstrated in the following sample code,

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
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
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rXVetJUNUxOPHKlT?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}