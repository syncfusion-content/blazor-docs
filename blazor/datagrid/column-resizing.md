---
layout: post
title: Column Resizing in Blazor DataGrid Component | Syncfusion
description: Learn how to resize columns in the Syncfusion Blazor DataGrid, including programmatic resizing, stacked headers, touch support, and events.
platform: Blazor
control: DataGrid
documentation: ug
---

# Column Resizing in Blazor DataGrid

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid provides an intuitive interface for resizing columns to fit their content. This feature allows columns to be adjusted for improved readability and layout control.

To enable column resizing, set the [AllowResizing](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowResizing) property of the [SfGrid](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html) component to **true**.

Once enabled, column width can be adjusted by clicking and dragging the right edge of the column header. The column resizes immediately during the drag operation.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" AllowResizing="true">
    <GridColumns>
        <GridColumn Field=@nameof(OrderDetails.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.CustomerID) HeaderText="Customer ID" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipCity) HeaderText="Ship City" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipName) HeaderText="Ship Name" Width="130"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipCountry) HeaderText="Ship Country" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipAddress) HeaderText="Ship Address" Width="130"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="100"></GridColumn>
    </GridColumns>
</SfGrid>
@code {
    private SfGrid<OrderDetails> Grid;
    public List<OrderDetails> Orders { get; set; }   
    protected override void OnInitialized()
    {
        Orders = OrderDetails.GetAllRecords();       
    }
}
{% endhighlight %}
{% highlight c# tabtitle="OrderDetails.cs" %}
public class OrderDetails
{
    public static List<OrderDetails> order = new List<OrderDetails>();
    public OrderDetails(int OrderID, string CustomerId, double Freight, string ShipCity, string ShipName, string ShipCountry, string ShipAddress)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerId;
        this.Freight = Freight;
        this.ShipCity = ShipCity;
        this.ShipName = ShipName;
        this.ShipCountry = ShipCountry;
        this.ShipAddress = ShipAddress;      
    }
    public static List<OrderDetails> GetAllRecords()
    {
        if (order.Count == 0)
        {
            order.Add(new OrderDetails(10248, "VINET", 32.38, "Reims", "Vins et alcools Chevalier", "Australia", "59 rue de l Abbaye"));
            order.Add(new OrderDetails(10249, "TOMSP", 11.61, "Münster", "Toms Spezialitäten", "Australia", "Luisenstr. 48"));
            order.Add(new OrderDetails(10250, "HANAR", 65.83, "Rio de Janeiro", "Hanari Carnes", "United States", "Rua do Paço, 67"));
            order.Add(new OrderDetails(10251, "VICTE", 41.34, "Lyon", "Victuailles en stock", "Australia", "2, rue du Commerce"));
            order.Add(new OrderDetails(10252, "SUPRD", 51.3, "Charleroi", "Suprêmes délices", "United States", "Boulevard Tirou, 255"));
            order.Add(new OrderDetails(10253, "HANAR", 58.17, "Rio de Janeiro", "Hanari Carnes", "United States", "Rua do Paço, 67"));
            order.Add(new OrderDetails(10254, "CHOPS", 22.98, "Bern", "Chop-suey Chinese", "Switzerland", "Hauptstr. 31"));
            order.Add(new OrderDetails(10255, "RICSU", 148.33, "Genève", "Richter Supermarkt", "Switzerland", "Starenweg 5"));
            order.Add(new OrderDetails(10256, "WELLI", 13.97, "Resende", "Wellington Importadora", "Brazil", "Rua do Mercado, 12"));
            order.Add(new OrderDetails(10257, "HILAA", 81.91, "San Cristóbal", "HILARION-Abastos", "Venezuela", "Carrera 22 con Ave. Carlos Soublette #8-35"));
            order.Add(new OrderDetails(10258, "ERNSH", 140.51, "Graz", "Ernst Handel", "Austria", "Kirchgasse 6"));
            order.Add(new OrderDetails(10259, "CENTC", 3.25, "México D.F.", "Centro comercial Moctezuma", "Mexico", "Sierras de Granada 9993"));
            order.Add(new OrderDetails(10260, "OTTIK", 55.09, "Köln", "Ottilies Käseladen", "Germany", "Mehrheimerstr. 369"));
            order.Add(new OrderDetails(10261, "QUEDE", 3.05, "Rio de Janeiro", "Que Delícia", "Brazil", "Rua da Panificadora, 12"));
            order.Add(new OrderDetails(10262, "RATTC", 48.29, "Albuquerque", "Rattlesnake Canyon Grocery", "USA", "2817 Milton Dr."));
        }
        return order;
    }
    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public double Freight { get; set; }
    public string ShipCity { get; set; }
    public string ShipName { get; set; }
    public string ShipCountry { get; set; }
    public string ShipAddress { get; set; }
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rNVJWLXdfpEFruXA?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> * To disable resizing for a specific column, set the [AllowResizing](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_AllowResizing) property of the [GridColumn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html) to **false**.
> * In RTL mode, column resizing is performed by dragging the left edge of the header cell.
> * The [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_Width) property of the `GridColumn` can be set to define the initial column width. When resizing is enabled, this value can be overridden by manual adjustments.
> * If the `Width` property of a `GridColumn` is explicitly set to **0** and resizing is enabled, the DataGrid automatically assigns a default width of **200px** to that column.

## Restrict the resizing based on minimum and maximum width

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid allows restricting column resizing between a defined minimum and maximum width. This ensures that columns remain within a specific size range, maintaining layout consistency and readability.

To configure this behavior, set the [MinWidth](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_MinWidth) and [MaxWidth](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_MaxWidth) properties for the respective [GridColumn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html).

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" AllowResizing="true">
    <GridColumns>
        <GridColumn Field=@nameof(OrderDetails.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" MinWidth="100" MaxWidth="250" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.CustomerID) HeaderText="Customer ID" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipCity) HeaderText="Ship City" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipName) HeaderText="Ship Name" MinWidth="150" MaxWidth="300" Width="200"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipCountry) HeaderText="Ship Country" MinWidth="120" MaxWidth="280" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipAddress) HeaderText="Ship Address" Width="130"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="100"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<OrderDetails> Orders { get; set; }   
    protected override void OnInitialized()
    {
        Orders = OrderDetails.GetAllRecords();       
    }
}
{% endhighlight %}
{% highlight c# tabtitle="OrderDetails.cs" %}
public class OrderDetails
{
    public static List<OrderDetails> order = new List<OrderDetails>();
    public OrderDetails(int OrderID, string CustomerId, double Freight, string ShipCity, string ShipName, string ShipCountry, string ShipAddress)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerId;
        this.Freight = Freight;
        this.ShipCity = ShipCity;
        this.ShipName = ShipName;
        this.ShipCountry = ShipCountry;
        this.ShipAddress = ShipAddress;      
    }
    public static List<OrderDetails> GetAllRecords()
    {
        if (order.Count == 0)
        {
            order.Add(new OrderDetails(10248, "VINET", 32.38, "Reims", "Vins et alcools Chevalier", "Australia", "59 rue de l Abbaye"));
            order.Add(new OrderDetails(10249, "TOMSP", 11.61, "Münster", "Toms Spezialitäten", "Australia", "Luisenstr. 48"));
            order.Add(new OrderDetails(10250, "HANAR", 65.83, "Rio de Janeiro", "Hanari Carnes", "United States", "Rua do Paço, 67"));
            order.Add(new OrderDetails(10251, "VICTE", 41.34, "Lyon", "Victuailles en stock", "Australia", "2, rue du Commerce"));
            order.Add(new OrderDetails(10252, "SUPRD", 51.3, "Charleroi", "Suprêmes délices", "United States", "Boulevard Tirou, 255"));
            order.Add(new OrderDetails(10253, "HANAR", 58.17, "Rio de Janeiro", "Hanari Carnes", "United States", "Rua do Paço, 67"));
            order.Add(new OrderDetails(10254, "CHOPS", 22.98, "Bern", "Chop-suey Chinese", "Switzerland", "Hauptstr. 31"));
            order.Add(new OrderDetails(10255, "RICSU", 148.33, "Genève", "Richter Supermarkt", "Switzerland", "Starenweg 5"));
            order.Add(new OrderDetails(10256, "WELLI", 13.97, "Resende", "Wellington Importadora", "Brazil", "Rua do Mercado, 12"));
            order.Add(new OrderDetails(10257, "HILAA", 81.91, "San Cristóbal", "HILARION-Abastos", "Venezuela", "Carrera 22 con Ave. Carlos Soublette #8-35"));
            order.Add(new OrderDetails(10258, "ERNSH", 140.51, "Graz", "Ernst Handel", "Austria", "Kirchgasse 6"));
            order.Add(new OrderDetails(10259, "CENTC", 3.25, "México D.F.", "Centro comercial Moctezuma", "Mexico", "Sierras de Granada 9993"));
            order.Add(new OrderDetails(10260, "OTTIK", 55.09, "Köln", "Ottilies Käseladen", "Germany", "Mehrheimerstr. 369"));
            order.Add(new OrderDetails(10261, "QUEDE", 3.05, "Rio de Janeiro", "Que Delícia", "Brazil", "Rua da Panificadora, 12"));
            order.Add(new OrderDetails(10262, "RATTC", 48.29, "Albuquerque", "Rattlesnake Canyon Grocery", "USA", "2817 Milton Dr."));
        }
        return order;
    }
    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public double Freight { get; set; }
    public string ShipCity { get; set; }
    public string ShipName { get; set; }
    public string ShipCountry { get; set; }
    public string ShipAddress { get; set; }
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rjrJChtRfnLvXiTu?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> * The `MinWidth` and `MaxWidth` properties are applied only during column resizing. These constraints are not enforced when resizing the browser window.
> * Ensure that the values assigned to `MinWidth` and `MaxWidth` are suitable for the content and layout requirements.
> * When resizing exceeds the defined range, the column width is automatically restricted to the nearest valid value within the specified limits.

## Prevent resizing for particular column

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid provides the ability to restrict resizing for individual columns. This is useful when a column's width must remain fixed for layout consistency or to prevent unintended changes.

To disable resizing for a specific column, set the [AllowResizing](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_AllowResizing) property of that [GridColumn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html) to **false**.

In this configuration, resizing is disabled for the **CustomerID** column.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" AllowResizing="true">
    <GridColumns>
        <GridColumn Field=@nameof(OrderDetails.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.CustomerID) HeaderText="Customer ID" AllowResizing="false" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipCity) HeaderText="Ship City" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="100"></GridColumn>
    </GridColumns>
</SfGrid>
@code {
    public List<OrderDetails> Orders { get; set; }   
    protected override void OnInitialized()
    {
        Orders = OrderDetails.GetAllRecords();       
    }  
}
{% endhighlight %}
{% highlight c# tabtitle="OrderDetails.cs" %}
public class OrderDetails
{
    public static List<OrderDetails> order = new List<OrderDetails>();
    public OrderDetails(int OrderID, string CustomerId, double Freight, string ShipCity)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerId;
        this.Freight = Freight;
        this.ShipCity = ShipCity;      
    }
    public static List<OrderDetails> GetAllRecords()
    {
        if (order.Count == 0)
        {
            order.Add(new OrderDetails(10248, "VINET", 32.38, "Reims"));
            order.Add(new OrderDetails(10249, "TOMSP", 11.61, "Münster"));
            order.Add(new OrderDetails(10250, "HANAR", 65.83, "Rio de Janeiro"));
            order.Add(new OrderDetails(10251, "VICTE", 41.34, "Lyon"));
            order.Add(new OrderDetails(10252, "SUPRD", 51.3, "Charleroi"));
            order.Add(new OrderDetails(10253, "HANAR", 58.17, "Rio de Janeiro"));
            order.Add(new OrderDetails(10254, "CHOPS", 22.98, "Bern"));
            order.Add(new OrderDetails(10255, "RICSU", 148.33, "Genève"));
            order.Add(new OrderDetails(10256, "WELLI", 13.97, "Resende"));
            order.Add(new OrderDetails(10257, "HILAA", 81.91, "San Cristóbal"));
            order.Add(new OrderDetails(10258, "ERNSH", 140.51, "Graz"));
            order.Add(new OrderDetails(10259, "CENTC", 3.25, "México D.F."));
            order.Add(new OrderDetails(10260, "OTTIK", 55.09, "Köln"));
            order.Add(new OrderDetails(10261, "QUEDE", 3.05, "Rio de Janeiro"));
            order.Add(new OrderDetails(10262, "RATTC", 48.29, "Albuquerque"));
        }
        return order;
    }
    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public double Freight { get; set; }
    public string ShipCity { get; set; }
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rZhJsBsWiczvQVGx?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> Resizing can also be prevented dynamically by setting **args.Cancel** to **true** in the [OnResizeStart](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_OnResizeStart) event.

## Resize stacked header column

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid allows resizing stacked columns by dragging the right edge of the stacked column header. During this action, the widths of the child columns are adjusted simultaneously.

To disable resizing for a specific stacked column, set the [AllowResizing](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_AllowResizing) property of that [GridColumn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html) to **false**.

In this configuration, resizing is disabled for the **ShipCity** column.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" AllowResizing="true"  Height="315">
    <GridColumns>
        <GridColumn Field=@nameof(OrderDetails.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn HeaderText=" Order Details">
            <GridColumns>
                <GridColumn Field=@nameof(OrderDetails.OrderDate) Width="130" HeaderText="Order Date" Format="d" TextAlign="TextAlign.Right" MinWidth="10"></GridColumn>
                <GridColumn Field=@nameof(OrderDetails.Freight) Width="135" HeaderText="Freight($)" Format="C2" TextAlign="TextAlign.Right" MinWidth="10"></GridColumn>
            </GridColumns>
        </GridColumn>
        <GridColumn HeaderText=" Ship Details">
            <GridColumns>
                <GridColumn Field=@nameof(OrderDetails.ShipCity) Width="130" HeaderText="Ship City" AllowResizing="false" MinWidth="10"></GridColumn>
                <GridColumn Field=@nameof(OrderDetails.ShipCountry) Width="135" HeaderText="Ship Country" MinWidth="10"></GridColumn>
            </GridColumns>
        </GridColumn>
    </GridColumns>
</SfGrid>
@code {
    public List<OrderDetails> Orders { get; set; }   
    protected override void OnInitialized()
    {
        Orders = OrderDetails.GetAllRecords();       
    }  
}
{% endhighlight %}
{% highlight c# tabtitle="OrderDetails.cs" %}
public class OrderDetails
{
    public static List<OrderDetails> order = new List<OrderDetails>();
    public OrderDetails(int OrderID, double Freight, DateTime OrderDate, string ShipCity, string ShipCountry)
    {
        this.OrderID = OrderID;
        this.Freight = Freight;
        this.ShipCity = ShipCity;
        this.OrderDate = OrderDate;
        this.ShipCountry = ShipCountry;
    }
    public static List<OrderDetails> GetAllRecords()
    {
        if (order.Count == 0)
        {
            order.Add(new OrderDetails(10248, 32.38, new DateTime(1996, 7, 4), "Reims", "Australia"));
            order.Add(new OrderDetails(10249, 11.61, new DateTime(1996, 7, 5), "Münster", "Australia"));
            order.Add(new OrderDetails(10250, 65.83, new DateTime(1996, 7, 8), "Rio de Janeiro", "United States"));
            order.Add(new OrderDetails(10251, 41.34, new DateTime(1996, 7, 8), "Lyon", "Australia"));
            order.Add(new OrderDetails(10252, 51.3, new DateTime(1996, 7, 9), "Charleroi","United States"));
            order.Add(new OrderDetails(10253, 58.17, new DateTime(1996, 7, 10), "Rio de Janeiro","United States"));
            order.Add(new OrderDetails(10254, 22.98, new DateTime(1996, 7, 11), "Bern", "Switzerland"));
            order.Add(new OrderDetails(10255, 148.33, new DateTime(1996, 7, 12), "Genève", "Switzerland"));
            order.Add(new OrderDetails(10256, 13.97, new DateTime(1996, 7, 15), "Resende", "Brazil"));
            order.Add(new OrderDetails(10257, 81.91, new DateTime(1996, 7, 16), "San Cristóbal", "Venezuela"));
            order.Add(new OrderDetails(10258, 140.51, new DateTime(1996, 7, 17), "Graz", "Austria"));
            order.Add(new OrderDetails(10259, 3.25, new DateTime(1996, 7, 18), "México D.F.", "Mexico"));
            order.Add(new OrderDetails(10260, 55.09, new DateTime(1996, 7, 19), "Köln", "Germany"));
            order.Add(new OrderDetails(10261, 3.05, new DateTime(1996, 7, 19), "Rio de Janeiro", "Brazil"));
            order.Add(new OrderDetails(10262, 48.29, new DateTime(1996, 7, 22), "Albuquerque", "USA"));
        }
        return order;
    }
    public int OrderID { get; set; }
    public double Freight { get; set; }
    public string ShipCity { get; set; }
    public DateTime OrderDate { get; set; }
    public string ShipCountry { get; set; }
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hjhfWrWihrtoRpwi?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Touch interaction

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid supports touch interactions, enabling column resizing on mobile devices. Columns can be resized by tapping and dragging the floating handler, or adjusted using the column menu options.

**Resizing Columns on Touch Devices**

To resize a column:

1. Tap the right edge of the column header.
2. A floating handler appears over the column’s right border.
3. Tap and drag the handler to adjust the column width.

![Blazor DataGrid column resizing in touch interaction.](./images/blazor-datagrid-column-resizing.jpg)

## Resize columns programmatically

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid supports column resizing through external UI interactions such as dropdowns or buttons. This allows dynamic control over column widths without relying on the Grid’s built-in UI handlers.

To resize a column externally, update the [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Width)  property of the target [GridColumn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html), and invoke the [RefreshColumnsAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_RefreshColumnsAsync) method to apply the changes.

In this configuration:

1. The column name is selected using a [DropDownList](https://blazor.syncfusion.com/documentation/dropdown-list/getting-started-with-web-app).
2. The new width is entered in a TextBox.
3. On clicking the Resize button, the [GetColumnByFieldAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_GetColumnByFieldAsync_System_String_) method retrieves the column reference.
4. The updated width is applied and the Grid is refreshed.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.DropDowns
@using Syncfusion.Blazor.Inputs
@using Syncfusion.Blazor.Buttons

<div style="display:flex; margin-bottom:5px;">
    <label style="margin: 5px 5px 0 0"> Select column name:</label>
    <SfDropDownList TValue="string" TItem="Columns" Width="120px" Placeholder="Select a Column" DataSource="@LocalData" @bind-Value="@DropDownValue">
        <DropDownListEvents TItem="Columns" TValue="string"></DropDownListEvents>
        <DropDownListFieldSettings Value="ID" Text="Value"></DropDownListFieldSettings>
    </SfDropDownList>
</div>
<div style="margin-bottom:5px">
    <label style="margin: 5px 5px 0 0"> Enter the width:</label>
    <SfTextBox CssClass="e-outline" @bind-Value="@ModifiedWidth" PlaceHolder="@PlaceHolder" Width="150px"></SfTextBox>
    <SfButton OnClick="onExternalResize">Resize</SfButton>
</div>
<SfGrid @ref="Grid" AllowResizing="true" DataSource="@Orders">                
    <GridColumns>
        <GridColumn Field=@nameof(OrderDetails.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="@IdWidth"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.CustomerID) HeaderText="Customer ID"  Width="@CustomerWidth"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="@FreightWidth"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipCountry) HeaderText="Ship Country" Width="@CountryWidth"></GridColumn>
    </GridColumns>
</SfGrid>
@code {
    public SfGrid<OrderDetails> Grid { get; set; }
    public List<OrderDetails> Orders { get; set; }
    protected override void OnInitialized()
    {
        Orders = OrderDetails.GetAllRecords();
    }
    public string ModifiedWidth;
    public string IdWidth = "100";
    public string CustomerWidth = "120";
    public string FreightWidth = "80";
    public string CountryWidth = "100";
    public string PlaceHolder { get; set; } = "Enter new width";
    public string DropDownValue { get; set; } = "OrderID";    
    public class Columns
    {
        public string ID { get; set; }
        public string Value { get; set; }
    }    
    List<Columns> LocalData = new List<Columns>    {
        new Columns() { ID= "OrderID", Value= "OrderID" },
        new Columns() { ID= "CustomerID", Value= "CustomerID" },
        new Columns() { ID= "Freight", Value= "Freight" },
        new Columns() { ID= "ShipCountry", Value= "ShipCountry" },
    };   
    public async Task onExternalResize()
    {        
        var selectedColumn = await Grid.GetColumnByFieldAsync(DropDownValue); 
        if(selectedColumn.Field == "OrderID") {
            IdWidth = ModifiedWidth;
        }
        if(selectedColumn.Field == "CustomerID") {
            CustomerWidth = ModifiedWidth;
        }         
        if(selectedColumn.Field == "Freight") {
            FreightWidth = ModifiedWidth;
        } 
        if(selectedColumn.Field == "ShipCountry") {
            CountryWidth = ModifiedWidth;
        }      
        await Grid.RefreshColumnsAsync();        
    }
}
{% endhighlight %}
{% highlight c# tabtitle="OrderDetails.cs" %}
public class OrderDetails
{
    public static List<OrderDetails> order = new List<OrderDetails>();
    public OrderDetails(int OrderID, string CustomerId, double Freight, string ShipCountry)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerId;
        this.Freight = Freight;
        this.ShipCountry = ShipCountry; 
    }
    public static List<OrderDetails> GetAllRecords()
    {
        if (order.Count == 0)
        {
            order.Add(new OrderDetails(10248, "VINET", 32.38, "Australia"));
            order.Add(new OrderDetails(10249, "TOMSP", 11.61, "Australia"));
            order.Add(new OrderDetails(10250, "HANAR", 65.83, "United States"));
            order.Add(new OrderDetails(10251, "VICTE", 41.34, "Australia"));
            order.Add(new OrderDetails(10252, "SUPRD", 51.3, "United States"));
            order.Add(new OrderDetails(10253, "HANAR", 58.17, "United States"));
            order.Add(new OrderDetails(10254, "CHOPS", 22.98,"Switzerland"));
            order.Add(new OrderDetails(10255, "RICSU", 148.33,"Switzerland"));
            order.Add(new OrderDetails(10256, "WELLI", 13.97, "Brazil"));
            order.Add(new OrderDetails(10257, "HILAA", 81.91, "Venezuela"));
            order.Add(new OrderDetails(10258, "ERNSH", 140.51, "Austria"));
            order.Add(new OrderDetails(10259, "CENTC", 3.2, "Mexico"));
            order.Add(new OrderDetails(10260, "OTTIK", 55.09, "Germany"));
            order.Add(new OrderDetails(10261, "QUEDE", 3.0, "Brazil"));
            order.Add(new OrderDetails(10262, "RATTC", 48.29, "USA"));
        }
        return order;
    }
    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public double Freight { get; set; }
    public string ShipCountry { get; set; }
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VtLzCrCWVoSJCfYw?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Resizing events

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid provides events that are triggered during column resizing operations. These events allow execution of custom logic before and after a column is resized, enabling validation, customization, and UI updates or notifications.

[OnResizeStart](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_OnResizeStart): Triggered when column resizing begins.

[ResizeStopped](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_ResizeStopped): Triggered when column resizing ends.

### OnResizeStart

The `OnResizeStart` event is triggered before a column is resized. This event can be used to inspect or cancel the resizing operation based on custom logic.

**Event Arguments**

The event uses the [ResizeArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ResizeArgs.html) class, which includes the following properties:

| Event Argument | Description                                                                 |
|----------------|------------------------------------------------------------------------------|
| Column       | Represents the column being resized.                                        |
| Cancel       | Determines whether the resizing operation should be aborted. Setting this property to **true** prevents the resizing from being applied. |


### ResizeStopped

The `ResizeStopped` event is triggered after a column has been resized. This event provides details about the resized column and can be used to display messages or perform post-resize actions.

**Event Arguments**

The event uses the [ResizeArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ResizeArgs.html) class, which includes the following properties:

| Event Argument | Description                                                                 |
|----------------|------------------------------------------------------------------------------|
| Column       | Represents the column that was resized.                                     |
| Cancel       | Indicates whether the resize operation was canceled. If **true**, the column was not resized. |


{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

<div style="text-align: center; color: red">
    <span>@ResizeMessage</span>
</div>
<SfGrid @ref="Grid" DataSource="@OrderData" AllowResizing="true">
    <GridEvents TValue="OrderDetails" OnResizeStart="OnResizeStart" ResizeStopped="ResizeStopped"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(OrderDetails.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.CustomerID) HeaderText="Customer ID" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipCity) HeaderText="Ship City" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipName) HeaderText="Ship Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipCountry) HeaderText="Ship Country" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipAddress) HeaderText="Ship Address" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>
@code {
    private SfGrid<OrderDetails> Grid;
    public List<OrderDetails> OrderData { get; set; }   
    protected override void OnInitialized()
    {
        OrderData = OrderDetails.GetAllRecords();       
    }
    public string ResizeMessage;
    public void OnResizeStart(ResizeArgs args)
    {
        if (args.Column.Field == "OrderID")
        {
            args.Cancel = true;
            ResizeMessage = "OnResizeStart event is triggered. Column Resizing cancelled for " + args.Column.HeaderText + " column ";
        }
    }
    public void ResizeStopped(ResizeArgs args)
    {
        ResizeMessage = "ResizeStopped event is triggered. " + args.Column.HeaderText + " column resizing completed.";
    }
}
{% endhighlight %}
{% highlight c# tabtitle="OrderDetails.cs" %}
public class OrderDetails
    {
        public static List<OrderDetails> order = new List<OrderDetails>();
        public OrderDetails(int OrderID, string CustomerId, double Freight, string ShipCity, string ShipName, string ShipCountry, string ShipAddress)
        {
            this.OrderID = OrderID;
            this.CustomerID = CustomerId;
            this.Freight = Freight;
            this.ShipCity = ShipCity;
            this.ShipName = ShipName;
            this.ShipCountry = ShipCountry;
            this.ShipAddress = ShipAddress;      
        }
        public static List<OrderDetails> GetAllRecords()
        {
            if (order.Count == 0)
            {
                order.Add(new OrderDetails(10248, "VINET", 32.38, "Reims", "Vins et alcools Chevalier", "Australia", "59 rue de l Abbaye"));
                order.Add(new OrderDetails(10249, "TOMSP", 11.61, "Münster", "Toms Spezialitäten", "Australia", "Luisenstr. 48"));
                order.Add(new OrderDetails(10250, "HANAR", 65.83, "Rio de Janeiro", "Hanari Carnes", "United States", "Rua do Paço, 67"));
                order.Add(new OrderDetails(10251, "VICTE", 41.34, "Lyon", "Victuailles en stock", "Australia", "2, rue du Commerce"));
                order.Add(new OrderDetails(10252, "SUPRD", 51.3, "Charleroi", "Suprêmes délices", "United States", "Boulevard Tirou, 255"));
                order.Add(new OrderDetails(10253, "HANAR", 58.17, "Rio de Janeiro", "Hanari Carnes", "United States", "Rua do Paço, 67"));
                order.Add(new OrderDetails(10254, "CHOPS", 22.98, "Bern", "Chop-suey Chinese", "Switzerland", "Hauptstr. 31"));
                order.Add(new OrderDetails(10255, "RICSU", 148.33, "Genève", "Richter Supermarkt", "Switzerland", "Starenweg 5"));
                order.Add(new OrderDetails(10256, "WELLI", 13.97, "Resende", "Wellington Importadora", "Brazil", "Rua do Mercado, 12"));
                order.Add(new OrderDetails(10257, "HILAA", 81.91, "San Cristóbal", "HILARION-Abastos", "Venezuela", "Carrera 22 con Ave. Carlos Soublette #8-35"));
                order.Add(new OrderDetails(10258, "ERNSH", 140.51, "Graz", "Ernst Handel", "Austria", "Kirchgasse 6"));
                order.Add(new OrderDetails(10259, "CENTC", 3.25, "México D.F.", "Centro comercial Moctezuma", "Mexico", "Sierras de Granada 9993"));
                order.Add(new OrderDetails(10260, "OTTIK", 55.09, "Köln", "Ottilies Käseladen", "Germany", "Mehrheimerstr. 369"));
                order.Add(new OrderDetails(10261, "QUEDE", 3.05, "Rio de Janeiro", "Que Delícia", "Brazil", "Rua da Panificadora, 12"));
                order.Add(new OrderDetails(10262, "RATTC", 48.29, "Albuquerque", "Rattlesnake Canyon Grocery", "USA", "2817 Milton Dr."));
           }
            return order;
        }
        public int OrderID { get; set; }
        public string CustomerID { get; set; }
        public double Freight { get; set; }
        public string ShipCity { get; set; }
        public string ShipName { get; set; }
        public string ShipCountry { get; set; }
        public string ShipAddress { get; set; }
    }
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hjBTWViiLnOofXge?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}