---
layout: post
title: Scrolling in Blazor DataGrid Component | Syncfusion
description: Checkout and learn here all about Scrolling in Syncfusion Blazor DataGrid component and much more details.
platform: Blazor
control: DataGrid
documentation: ug
---

# Scrolling in Blazor DataGrid component

The scrolling feature in the Blazor Grid component allows you to navigate through the content that extends beyond the visible area of the grid . It provides scrollbars that are automatically displayed when the content exceeds the specified `Width` or `Height` of the grid element. This feature is useful when you have a large amount of data or when the content needs to be displayed within a limited space. The vertical and horizontal scrollbars will be displayed based on the following criteria:

* The vertical scrollbar appears when the total height of rows present in the grid exceeds its element height.
* The horizontal scrollbar appears when the sum of columns width exceeds the grid element width.
* The [Height](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_Height) and [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_Width) are used to set the grid height and width, respectively.

> The default value for `Height`and `Width` is `auto`.

## Set width and height

To specify the [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_Width) and [Height](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_Height) of the scroller in the pixel, set the pixel value to a number.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@OrderData" Height="315" Width="400">
    <GridColumns>
        <GridColumn Field=@nameof(OrderDetails.OrderID) HeaderText="Order ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.CustomerID) HeaderText="Customer ID" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.EmployeeID) HeaderText="Employee ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipCity) HeaderText="Ship City" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipCountry) HeaderText="Ship Country" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipName) HeaderText="Ship Name" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    public List<OrderDetails> OrderData { get; set; }
    protected override void OnInitialized()
    {
        OrderData = OrderDetails.GetAllRecords();
    }
}
{% endhighlight %}
{% highlight c# tabtitle="OrderDetails.cs" %}
public class OrderDetails
{
    public static List<OrderDetails> order = new List<OrderDetails>();    
    public OrderDetails(int OrderID, string CustomerId, int EmployeeId, string ShipCity, string ShipName, string ShipCountry)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerId;
        this.EmployeeID = EmployeeId;
        this.ShipCity = ShipCity;
        this.ShipName = ShipName;
        this.ShipCountry = ShipCountry;
    }
    public static List<OrderDetails> GetAllRecords()
    {
        if (order.Count == 0)
        {
            order.Add(new OrderDetails(10248, "VINET", 5, "Reims", "Vins et alcools Chevalier", "Australia"));
            order.Add(new OrderDetails(10249, "TOMSP", 6, "Münster", "Toms Spezialitäten", "Australia"));
            order.Add(new OrderDetails(10250, "HANAR", 4, "Rio de Janeiro", "Hanari Carnes", "United States"));
            order.Add(new OrderDetails(10251, "VICTE", 3, "Lyon", "Victuailles en stock", "Australia"));
            order.Add(new OrderDetails(10252, "SUPRD", 4, "Charleroi", "Suprêmes délices", "United States"));
            order.Add(new OrderDetails(10253, "HANAR", 3, "Rio de Janeiro", "Hanari Carnes", "United States"));
            order.Add(new OrderDetails(10254, "CHOPS", 5, "Bern", "Chop-suey Chinese", "Switzerland"));
            order.Add(new OrderDetails(10255, "RICSU", 9, "Genève", "Richter Supermarkt", "Switzerland"));
            order.Add(new OrderDetails(10256, "WELLI", 3, "Resende", "Wellington Importadora", "Brazil"));
            order.Add(new OrderDetails(10257, "HILAA", 4, "San Cristóbal", "HILARION-Abastos", "Venezuela"));
            order.Add(new OrderDetails(10258, "ERNSH", 1, "Graz", "Ernst Handel", "Austria"));
            order.Add(new OrderDetails(10259, "CENTC", 4, "México D.F.", "Centro comercial Moctezuma", "Mexico"));
            order.Add(new OrderDetails(10260, "OTTIK", 4, "Köln", "Ottilies Käseladen", "Germany"));
            order.Add(new OrderDetails(10261, "QUEDE", 4, "Rio de Janeiro", "Que Delícia", "Brazil"));
            order.Add(new OrderDetails(10262, "RATTC", 8, "Albuquerque", "Rattlesnake Canyon Grocery", "USA"));
        }
        return order;
    }
    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public int EmployeeID { get; set; }
    public string ShipCity { get; set; }
    public string ShipName { get; set; }
    public string ShipCountry { get; set; }
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VjryNWBTfUaCEgqf?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Responsive with parent container

The Grid component allows you to create a responsive layout by making it fill its parent container and automatically adjust its size based on the available space and changes in the container's dimensions. This capability is particularly useful for building applications that need to adapt to various screen sizes and devices.

To achieve this, you need to specify the [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_Width) and [Height](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_Height) properties of the Grid as 100%. However, keep in mind that setting the height property to 100% requires the Grid's parent element to have an explicit height defined.

In the following example, the parent container has explicit height and width set, and the Grid container's height and width are both set to 100%. This ensures that the Grid adjusts its size responsively based on the dimensions of the parent container:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

<div style="width:calc(100vw - 20rem); height:calc(100vh - 7rem);"> @*Change the rem values based on your browser page layout*@
    <SfGrid DataSource="@LazyLoadData" Height="100%" Width="100%">
        <GridColumns>
            <GridColumn Field=@nameof(LazyLoadDetails.OrderID) HeaderText="Order ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="120"></GridColumn>
            <GridColumn Field=@nameof(LazyLoadDetails.CustomerID) HeaderText="Customer ID" Width="150"></GridColumn>
            <GridColumn Field=@nameof(LazyLoadDetails.Freight) HeaderText="Freight" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="100"></GridColumn>
            <GridColumn Field=@nameof(LazyLoadDetails.ShipAddress) HeaderText="Ship Address" Width="120"></GridColumn>
        </GridColumns>
    </SfGrid>
</div>

@code{
    public List<LazyLoadDetails> LazyLoadData { get; set; }
    protected override void OnInitialized()
    {
        LazyLoadData = LazyLoadDetails.CreateLazyLoadData();
    }
}
{% endhighlight %}
{% highlight c# tabtitle="LazyLoadDetails.cs" %}
public class LazyLoadDetails
{
    public static List<LazyLoadDetails> CreateLazyLoadData()
    {
        var lazyLoadData = new List<LazyLoadDetails>();
        var customerIds = new[] { "VINET", "TOMSP", "HANAR", "VICTE", "SUPRD", "HANAR", "CHOPS", "RICSU", "WELLI", "HILAA", "ERNSH", "CENTC", "OTTIK", "QUEDE", "RATTC", "FOLKO", "BLONP", "WARTH" };
        var shipAddresses = new[] { "507 - 20th Ave. E.\nApt. 2A", "908 W. Capital Way", "722 Moss Bay Blvd.", "4110 Old Redmond Rd.", "14 Garrett Hill" };
        var freights = new[] { 10, 24, 12, 48, 36, 102, 18 };
        int orderId = 10248;
        var random = new Random();
        for (int i = 0; i < 50; i++)
        {
            lazyLoadData.Add(new LazyLoadDetails
            {
                OrderID = orderId + i,
                CustomerID = customerIds[random.Next(customerIds.Length)],
                ShipAddress = shipAddresses[random.Next(shipAddresses.Length)],
                Freight = freights[random.Next(freights.Length)]
            });
        }
        return lazyLoadData;
    }
    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public string ShipAddress { get; set; }
    public double Freight { get; set; }
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BNLIjMBcAgEnKHGz?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Sticky header

The Blazor Grid component provides a feature that allows you to make column headers remain fixed while scrolling, ensuring they stay visible at all times. To achieve this, you can utilize the [EnableStickyHeader](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_EnableStickyHeader) property by setting it to **true**.

In the below demo, the Grid headers will be sticky while scrolling the Grid's parent div element.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons

<div>
    <label> Enable or Disable Sticky Header</label>
    <SfSwitch ValueChange="Change" TChecked="bool" style="margin-top:5px"></SfSwitch>
</div>
<div style="height:350px; margin-top:5px"> 
    <SfGrid @ref="Grid" DataSource="@LazyLoadData" EnableStickyHeader="@IsStickyHeader">
        <GridColumns>
            <GridColumn Field=@nameof(LazyLoadDetails.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
            <GridColumn Field=@nameof(LazyLoadDetails.CustomerID) HeaderText="Customer ID" Width="150"></GridColumn>
            <GridColumn Field=@nameof(LazyLoadDetails.Freight) HeaderText="Freight" TextAlign="TextAlign.Right" Width="100"></GridColumn>
            <GridColumn Field=@nameof(LazyLoadDetails.ShipAddress) HeaderText="Ship Address" Width="120"></GridColumn>
        </GridColumns>
    </SfGrid>
</div>

@code{
    private SfGrid<LazyLoadDetails> Grid;
    public List<LazyLoadDetails> LazyLoadData { get; set; }
    protected override void OnInitialized()
    {
        LazyLoadData = LazyLoadDetails.CreateLazyLoadData();
    }
    public bool IsStickyHeader;
    private void Change(Syncfusion.Blazor.Buttons.ChangeEventArgs<bool> args)
    {
        IsStickyHeader = args.Checked;
        Grid.Refresh();
    }
}
{% endhighlight %}
{% highlight c# tabtitle="LazyLoadDetails.cs" %}
public class LazyLoadDetails
{
    public static List<LazyLoadDetails> CreateLazyLoadData()
    {
        var lazyLoadData = new List<LazyLoadDetails>();
        var customerIds = new[] { "VINET", "TOMSP", "HANAR", "VICTE", "SUPRD", "HANAR", "CHOPS", "RICSU", "WELLI", "HILAA", "ERNSH", "CENTC", "OTTIK", "QUEDE", "RATTC", "FOLKO", "BLONP", "WARTH" };
        var shipAddresses = new[] { "507 - 20th Ave. E.\nApt. 2A", "908 W. Capital Way", "722 Moss Bay Blvd.", "4110 Old Redmond Rd.", "14 Garrett Hill" };
        var freights = new[] { 10, 24, 12, 48, 36, 102, 18 };
        int orderId = 10248;
        var random = new Random();
        for (int i = 0; i < 50; i++)
        {
            lazyLoadData.Add(new LazyLoadDetails
            {
                OrderID = orderId + i,
                CustomerID = customerIds[random.Next(customerIds.Length)],
                ShipAddress = shipAddresses[random.Next(shipAddresses.Length)],
                Freight = freights[random.Next(freights.Length)]
            });
        }
        return lazyLoadData;
    }
    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public string ShipAddress { get; set; }
    public double Freight { get; set; }
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hjBytWVcUTZgQUiC?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Scroll to selected row

The Blazor Grid component allows you to scroll the grid content to the position of the selected row, ensuring that the selected row is automatically brought into view. This feature is particularly useful when dealing with a large dataset and wanting to maintain focus on the selected row. To achieve this, you can utilize the [ScrollIntoViewAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ScrollIntoViewAsync_System_Int32_System_Int32_System_Int32_) method provided by the Grid.

The following example that demonstrates how to use the `ScrollIntoViewAsync` method to scroll to the selected row:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.DropDowns

<div>
    <label style="padding: 30px 2px 0 0">Select row index:</label>
    <SfDropDownList TValue="string" TItem="Rows" Placeholder="Select count" Width="220px" DataSource="DropDownData" @bind-Value="SelectedValue">
        <DropDownListFieldSettings Text="Text" Value="Value"></DropDownListFieldSettings>
        <DropDownListEvents ValueChange="ValueChanged" TValue="string" TItem="Rows"></DropDownListEvents>
    </SfDropDownList>
</div>
<div style="height:350px; margin-top:5px">
    <SfGrid @ref="Grid" DataSource="@LazyLoadData" Height="315" Width="100%">
        <GridEvents RowSelected="RowselectedHandler" TValue="LazyLoadDetails"></GridEvents>>
        <GridColumns>
            <GridColumn Field=@nameof(LazyLoadDetails.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
            <GridColumn Field=@nameof(LazyLoadDetails.CustomerID) HeaderText="Customer ID" Width="150"></GridColumn>
            <GridColumn Field=@nameof(LazyLoadDetails.Freight) HeaderText="Freight" TextAlign="TextAlign.Right" Width="100"></GridColumn>
            <GridColumn Field=@nameof(LazyLoadDetails.ShipAddress) HeaderText="Ship Address" Width="120"></GridColumn>
        </GridColumns>
    </SfGrid>
</div>

@code{
    private SfGrid<LazyLoadDetails> Grid;
    public List<LazyLoadDetails> LazyLoadData { get; set; }
    protected override void OnInitialized()
    {
        LazyLoadData = LazyLoadDetails.CreateLazyLoadData();
    }
    public string SelectedValue { get; set; }
    public class Rows
    {
        public string Text { get; set; }
        public string Value { get; set; }
    }
    private List<Rows> DropDownData = new List<Rows>
    {
        new Rows() { Text = "Select count" },
        new Rows() { Text = "10", Value = "10" },
        new Rows() { Text = "20", Value = "20" },
        new Rows() { Text = "30", Value = "30" },
        new Rows() { Text = "80", Value = "80" },
        new Rows() { Text = "100", Value = "100" },
        new Rows() { Text = "200", Value = "200" },
        new Rows() { Text = "232", Value = "232" },
        new Rows() { Text = "300", Value = "300" },
        new Rows() { Text = "500", Value = "500" },
        new Rows() { Text = "800", Value = "800" },
        new Rows() { Text = "820", Value = "820" },
        new Rows() { Text = "920", Value = "920" },
        new Rows() { Text = "2020", Value = "2020" },
        new Rows() { Text = "3000", Value = "3000" },
        new Rows() { Text = "4000", Value = "4000" },
        new Rows() { Text = "4999", Value = "4999" }
    };
    public async Task ValueChanged(ChangeEventArgs<string, Rows> Args)
    {
        if (int.TryParse(SelectedValue, out int rowIndex))
        {
            await Grid.SelectRowAsync(rowIndex);
            await Grid.ScrollIntoViewAsync(rowIndex);
        }
    }
    public void RowselectedHandler(RowSelectEventArgs<LazyLoadDetails> args)
    {
        Grid.PreventRender(false);
    }
}
{% endhighlight %}
{% highlight c# tabtitle="LazyLoadDetails.cs" %}
public class LazyLoadDetails
{
    public static List<LazyLoadDetails> CreateLazyLoadData()
    {
        var lazyLoadData = new List<LazyLoadDetails>();
        var customerIds = new[] { "VINET", "TOMSP", "HANAR", "VICTE", "SUPRD", "HANAR", "CHOPS", "RICSU", "WELLI", "HILAA", "ERNSH", "CENTC", "OTTIK", "QUEDE", "RATTC", "FOLKO", "BLONP", "WARTH" };
        var shipAddresses = new[] { "507 - 20th Ave. E.\nApt. 2A", "908 W. Capital Way", "722 Moss Bay Blvd.", "4110 Old Redmond Rd.", "14 Garrett Hill" };
        var freights = new[] { 10, 24, 12, 48, 36, 102, 18 };
        int orderId = 10248;
        var random = new Random();
        for (int i = 0; i < 5000; i++)
        {
            lazyLoadData.Add(new LazyLoadDetails
            {
                OrderID = orderId + i,
                CustomerID = customerIds[random.Next(customerIds.Length)],
                ShipAddress = shipAddresses[random.Next(shipAddresses.Length)],
                Freight = freights[random.Next(freights.Length)]
            });
        }
        return lazyLoadData;
    }
    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public string ShipAddress { get; set; }
    public double Freight { get; set; }
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BjVoZiLPivFixBPP?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Customize grid scroll bar

The Grid component uses the native browser scroll bar to scroll through the content when the content is larger than the Grid. Refer to [this](https://css-tricks.com/almanac/properties/s/scrollbar/) to customize the appearance of the scroll bar.

By referring to the above link, we have customized the appearance of the scroll bar in the following sample.

> You can find the fully working sample [here](https://github.com/SyncfusionExamples/blazor-datagrid-customize-default-scrollbar).

```csharp
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" Height="315" Width="400">
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipCountry) HeaderText="Ship Country" Width="150"></GridColumn>
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
            Freight = 2.1 * x,
            OrderDate = DateTime.Now.AddDays(-x),
            ShipCountry = (new string[] { "USA", "UK", "JAPAN" })[new Random().Next(3)]
        }).ToList();
    }
    public class Order {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
        public string ShipCountry { get; set; }
    }
}
<style>
    ::-webkit-scrollbar-thumb {
        background-color: #888;
        border-radius: 10px
    }
    ::-webkit-scrollbar {
        background-color: white;
    }
    ::-webkit-scrollbar-button {
        background-color: #bbbbbb;
    }
</style>
```

![Customizing the scroll bar in Blazor DataGrid.](./images/blazor-datagrid-scrollbar-customization.png)