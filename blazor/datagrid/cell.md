---
layout: post
title: Cell in Blazor DataGrid | Syncfusion
description: Check out this page to learn how to set gridlines, tooltips, styles, and more in cells in the Syncfusion Blazor DataGrid component.
platform: Blazor
control: DataGrid
documentation: ug
---

# Cell in Blazor DataGrid 

In the Syncfusion Blazor DataGrid, a cell refers to an individual data point or a unit within a Grid column that displays data. It represents the intersection of a row and a column, and it contains specific information associated with that row and column. Each cell can display text, numbers, or other content related to the data it represents.

The Grid allows you to customize the appearance and behavior of cells using various features and options. You can define templates, format cell values, enable or disable editing, and perform various other operations on the cells to create interactive and informative data Grids in your web applications.

To know about how to customize cell in Grid, you can check this video.

{% youtube "youtube:https://www.youtube.com/watch?v=6H90a5tz7bE"%}

## Displaying the HTML content

Displaying HTML content in a Syncfusion Blazor DataGrid can be useful in scenarios where you want to display formatted content, such as images, links, or tables, in a tabular format. Grid allows you to display HTML tags in the Grid header and content. By default, the HTML content is encoded to prevent potential security vulnerabilities. However, you can enable the [DisableHtmlEncode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_DisableHtmlEncode) property by setting the value as false to display HTML tags without encoding. This feature is useful when you want to display HTML content in a Grid cell.

In the following example, the [Blazor Toggle Switch](https://www.syncfusion.com/blazor-components/blazor-toggle-switch-button) Button is added to enable and disable the `DisableHtmlEncode` property. When the switch is toggled, the [ValueChange](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfSwitch-1.html#Syncfusion_Blazor_Buttons_SfSwitch_1_ValueChange) event is triggered and the `DisableHtmlEncode` property of the column is updated accordingly. The [Refresh](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_Refresh) method is called to refresh the Grid and display the updated content.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons

<label> Enable or disable HTML Encode</label>
<SfSwitch ValueChange="Change" TChecked="bool"></SfSwitch>

<SfGrid @ref="Grid" DataSource="@Orders" Height="315">
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="140"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="<span> Customer ID </span>" DisableHtmlEncode="@IsEncode" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="100"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    private SfGrid<OrderData> Grid;
    public bool IsEncode { get; set; } = true;
    public List<OrderData> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
    }
    private void Change(Syncfusion.Blazor.Buttons.ChangeEventArgs<bool> args)
    {
        IsEncode = !args.Checked;
        Grid.Refresh();
    }

}
{% endhighlight %}
{% highlight c# tabtitle="OrderData.cs" %}

 public class OrderData
    {
        public static List<OrderData> Orders = new List<OrderData>();
        public OrderData()
        {

        }
        public OrderData(int? OrderID, string CustomerId, double? Freight, string ShipCity)
        {
            this.OrderID = OrderID;
            this.CustomerID = CustomerId;
            this.Freight = Freight;
            this.ShipCity= ShipCity;
        }

        public static List<OrderData> GetAllRecords()
        {
            if (Orders.Count() == 0)
            {
                int code = 10;
                for (int i = 1; i < 2; i++)
                {
                    Orders.Add(new OrderData(10248, "<b>VINET</b>",32.38, "Reims"));
                    Orders.Add(new OrderData(10249, "<b>TOMSP</b>", 11.61, "Münster"));
                    Orders.Add(new OrderData(10250, "<b>HANAR</b>", 65.83, "Rio de Janeiro"));
                    Orders.Add(new OrderData(10251, "<b>VICTE</b>", 41.34, "Lyon"));
                    Orders.Add(new OrderData(10252, "<b>SUPRD</b>", 51.30, "Charleroi"));
                    Orders.Add(new OrderData(10253, "<b>CHOPS</b>", 58.17, "Bern"));
                    Orders.Add(new OrderData(10254, "<b>RICSU</b>", 22.98, "Genève"));
                    Orders.Add(new OrderData(10255, "<b>WELLI</b>", 13.97, "San Cristóbal"));
                    Orders.Add(new OrderData(10256, "<b>HILAA</b>", 81.91, "Graz"));
                    code += 5;
                }
            }
            return Orders;
        }

        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public double? Freight { get; set; }
        public string ShipCity { get; set; }
    }
    {% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LtBAMZDRBetNXSsV?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> * The [DisableHtmlEncode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_DisableHtmlEncode) property disables HTML encoding for the corresponding column in the Grid.
> * If the property is set to **true**, any HTML tags in the column’s data will be displayed.
> * If the property is set to **false**, the HTML tags will be removed and displayed as plain text.
> * Disabling HTML encoding can potentially introduce security vulnerabilities, so use caution when enabling this feature.

## Autowrap the Grid content

The auto wrap feature allows the cell content in the Syncfusion Blazor DataGrid to wrap to the next line when it exceeds the boundary of the specified cell width. The cell content wrapping works based on the position of white space between words. To support the Autowrap functionality in Grid, you should set the appropriate width for the columns. The column width defines the maximum width of a column and helps to wrap the content automatically.

 To enable auto wrap, set the [AllowTextWrap](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowTextWrap) property to **true**. You can configure the auto wrap mode by setting the [TextWrapSettings.WrapMode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Type) property.

 Grid provides the below three options for configuring:

* **Both** - This is the default value for wrapMode. With this option, both the Grid **Header** and **Content** text is wrapped.
* **Header** -  With this option, only the Grid header text is wrapped.
* **Content** -  With this option, only the Grid content is wrapped.

> * When a column width is not specified, then auto wrap of columns will be adjusted with respect to the Grid's width.
> * If a column’s header text contains no white space, the text may not be wrapped.
> * If the content of a cell contains HTML tags, the Autowrap functionality may not work as expected. In such cases, you can use the [HeaderTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEditSettings.html#Syncfusion_Blazor_Grids_GridEditSettings_HeaderTemplate) and [Template](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEditSettings.html#Syncfusion_Blazor_Grids_GridEditSettings_Template) features of the column to customize the appearance of the header and cell content.

The following example demonstrates how to set the `AllowTextWrap` property to **true** and specify the wrap mode as **Content** by setting the `TextWrapSettings.WrapMode` property.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.DropDowns

<label>Change the wrapmode of auto wrap feature:</label>
<SfDropDownList TValue="WrapMode" TItem="DropDownOrder" @bind-Value="@WrapModeValue" DataSource="@DropDownValue" Width="100px">
    <DropDownListFieldSettings Text="Text" Value="Value"></DropDownListFieldSettings>
    <DropDownListEvents ValueChange="OnValueChange" TValue="WrapMode" TItem="DropDownOrder"></DropDownListEvents>
</SfDropDownList>

<SfGrid @ref="Grid" DataSource="@Orders" GridLines="GridLine.Default" AllowTextWrap="true" Height="315">
    <GridTextWrapSettings WrapMode="@WrapModeValue"></GridTextWrapSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.Name) HeaderText="Name of the inventor" Width="70"></GridColumn>
        <GridColumn Field=@nameof(OrderData.PatentFamilies) HeaderText="No of patentfamilies" Width="80"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Country) HeaderText="Country" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Active) HeaderText="Active" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.MainFields) HeaderText="Main fields of Invention" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    private SfGrid<OrderData> Grid;
    public List<OrderData> Orders { get; set; }
    public WrapMode WrapModeValue { get; set; } = WrapMode.Content;
    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
    }
    public class DropDownOrder
    {
        public string Text { get; set; }
        public WrapMode Value { get; set; }
    }
    List<DropDownOrder> DropDownValue = new List<DropDownOrder>
    {
        new DropDownOrder() { Text = "Both", Value = WrapMode.Both },
        new DropDownOrder() { Text = "Content", Value = WrapMode.Content },
        new DropDownOrder() { Text = "Header", Value = WrapMode.Header }
    };
    public void OnValueChange(ChangeEventArgs<WrapMode, DropDownOrder> Args)
    {
        WrapModeValue = Args.Value;
        Grid.Refresh();
    }
}
{% endhighlight %}
{% highlight c# tabtitle="OrderData.cs" %}
public class OrderData
    {
        public static List<OrderData> Orders = new List<OrderData>();
        public OrderData()
        {

        }
        public OrderData(string Name, int? PatentFamilies,string NumberofINPADOCpatents, string Country, string MainFields, string active)
        {
            this.Name = Name;
            this.PatentFamilies = PatentFamilies;
            this.NumberofINPADOCpatents = NumberofINPADOCpatents;
            this.Country = Country;
            this.MainFields = MainFields;
            this.Active = active;
        }

        public static List<OrderData> GetAllRecords()
        {
            if (Orders.Count() == 0)
            {
                int code = 10;
                for (int i = 1; i < 2; i++)
                {
                    Orders.Add(new OrderData("Kia Silverb", 4737, "9839", "Australia", "Printing, Digital paper, Internet, Electronics,Lab-on-a-chip, MEMS, Mechanical, VLSI", "1994-2016"));
                    Orders.Add(new OrderData("Shunpei Yamazaki", 4677, "10000+", "Japan", "Various", "1976-2016"));
                    Orders.Add(new OrderData("Lowell L. Wood, Jr.",13197, "1332", "Canada", "Printing, Digital paper, Internet, Electronics, CGI, VLSI", "1977-2016"));
                    Orders.Add(new OrderData("Paul Lap", 1255, "3099", "India", "Automotive, Stainless steel products", "2000-2016"));
                    Orders.Add(new OrderData("Gurtej Sandhu", 1240, "2038", "USA", "Gaming machines", "1991-2016"));
                    Orders.Add(new OrderData("Shunpei Yamazaki", 1240, "4126", "Canada", "Printing, Digital paper, Internet, Electronics, CGI, VLSI", "2000-2016"));
                    Orders.Add(new OrderData("Paul Lap", 1093, "3360", "USA", "Automotive, Stainless steel products", "1977 - 2016"));
                    Orders.Add(new OrderData("Gurtej Sandhu", 993, "1398", "Japan", "Various", "1976-2016"));
                    Orders.Add(new OrderData("Kia Silverb", 949,"NA", "India", "Printing, Digital paper, Internet, Electronics, CGI, VLSI", "1994-2016"));                  
                    code += 5;
                }
            }
            return Orders;
        }
        public string Name { get; set; }
        public int? PatentFamilies { get; set; }
        public string NumberofINPADOCpatents { get; set; }
        public string Country { get; set; }
        public string MainFields { get; set; }
        public string Active { get; set; }
    }
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hXBgiiNgrTpwZLYn?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Customize cell styles

Customizing the Syncfusion Blazor DataGrid cell styles allows you to modify the appearance of cells in the Grid control to meet your design requirements. You can customize the font, background color, and other styles of the cells. To customize the cell styles in the Grid, you can use Grid event, css or property support.

### Using event

To customize the appearance of the Syncfusion Blazor DataGrid cell, you can use the [QueryCellInfo](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.QueryCellInfoEventArgs-1.html) event of the Grid. This event is triggered when each cell is rendered in the Grid, and provides an object that contains information about the cell. You can use this object to modify the styles of the cell.

The following example demonstrates how to add a `QueryCellInfo` event handler to the Grid. In the event handler, checked whether the current column is **Freight** field and then applied the appropriate CSS class to the cell based on its value.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" AllowSelection="false" EnableHover="false" Height="315">
    <GridEvents QueryCellInfo="CustomizeCell" TValue="OrderData"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="140"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="100"></GridColumn>
    </GridColumns>
</SfGrid> 
@code {  
    public List<OrderData> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
    }
    
    public void CustomizeCell(QueryCellInfoEventArgs<OrderData> args)
    {
        if (args.Column.Field == "Freight")
        {
            if (args.Data.Freight < 30)
            {
                args.Cell.AddClass(new string[] { "below-30" });
            }
            else if (args.Data.Freight < 80)
            {
                args.Cell.AddClass(new string[] { "below-80" });
            }
            else
            {
                args.Cell.AddClass(new string[] { "above-80" });
            }
        }
    }

}
<style>
    .below-30 {
        background-color: orangered;
    }
    .below-80 {
        background-color: yellow;
    }
    .above-80 {
        background-color: greenyellow
    }
</style>
{% endhighlight %}
{% highlight c# tabtitle="OrderData.cs" %}
    public class OrderData
    {
        public static List<OrderData> Orders = new List<OrderData>();
        public OrderData()
        {

        }
        public OrderData(int? OrderID,string CustomerID,double? Freight,string ShipCity)
        {
            this.OrderID = OrderID;
            this.CustomerID = CustomerID;
            this.Freight = Freight;
            this.ShipCity = ShipCity;
        }

        public static List<OrderData> GetAllRecords()
        {
            if (Orders.Count() == 0)
            {
                int code = 10;
                for (int i = 1; i < 2; i++)
                {
                    Orders.Add(new OrderData(10248, "VINET", 32.38, "Reims"));
                    Orders.Add(new OrderData(10249, "TOMSP", 11.61, "Münster"));
                    Orders.Add(new OrderData(10250, "HANAR", 65.83, "Rio de Janeiro"));
                    Orders.Add(new OrderData(10251, "VICTE", 41.34, "Lyon"));
                    Orders.Add(new OrderData(10252, "SUPRD", 51.30, "Charleroi"));
                    Orders.Add(new OrderData(10253, "HANAR", 58.17, "Rio de Janeiro"));
                    Orders.Add(new OrderData(10254, "CHOPS", 22.98, "Bern"));
                    Orders.Add(new OrderData(10255, "RICSU", 148.33, "Genève"));
                    Orders.Add(new OrderData(10256, "WELLI", 13.97, "Resende"));
                    code += 5;
                }
            }
            return Orders;
        }

        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public double? Freight { get; set; }
        public string ShipCity { get; set; }
    }
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LDLgjvivAmfpAZcD?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

* Similarly, using the `QueryCellInfo` event, we can customize the appearance of the `Freight` column based on value ranges, and in this sample, each range is styled with distinct text and background colors using refined CSS:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" AllowPaging="true">
    <GridEvents QueryCellInfo="QueryCellInfoHandler" TValue="Order"></GridEvents>
    <GridPageSettings PageSize="8"></GridPageSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipCountry) HeaderText="ShipCountry" Width="130"></GridColumn>
    </GridColumns>
</SfGrid>

<style>
.e-grid .e-gridcontent .e-rowcell.above-40 {
    color: green;
    background-color: #e8f5e9; 
}

.e-grid .e-gridcontent .e-rowcell.above-20 {
    color: blue;
    background-color: #e3f2fd;
}

.e-grid .e-gridcontent .e-rowcell.below-20 {
    color: red;
    background-color: #ffebee; 
}
</style>

@code{
    private SfGrid<Order> Grid;
    public List<Order> Orders { get; set; }

    protected override void OnInitialized()
    {
      Orders = Order.GetAllRecords();
    }

    public void QueryCellInfoHandler(Syncfusion.Blazor.Grids.QueryCellInfoEventArgs<Order> args) {
    if (args.Data.Freight > 40)
    {
        args.Cell.AddClass(new string[] { "above-40" });
    }
    else if (args.Data.Freight > 20 && args.Data.Freight <= 40)
    {
        args.Cell.AddClass(new string[] { "above-20" });
    }
    else
    {
        args.Cell.AddClass(new string[] { "below-20" });
    }
    }
}

{% endhighlight %}
{% highlight c# tabtitle="Order.cs" %}

 public class Order
 {
     public static List<Order> Orders = new List<Order>();

     public Order(int orderID, string customerID, double freight, string shipCity, string shipName, string shipCountry)
     {
         this.OrderID = orderID;
         this.CustomerID = customerID;
         this.Freight = freight;
         this.ShipCity = shipCity;
         this.ShipName = shipName;
         this.ShipCountry = shipCountry;
     }

     public static List<Order> GetAllRecords()
     {
         if (Orders.Count == 0)
         {
             Orders.Add(new Order(10248, "VINET", 32.38, "Reims", "Vins et alcools Chevalier", "France"));
             Orders.Add(new Order(10249, "TOMSP", 11.61, "Münster", "Toms Spezialitäten", "Germany"));
             Orders.Add(new Order(10250, "HANAR", 65.83, "Rio de Janeiro", "Hanari Carnes", "Brazil"));
             Orders.Add(new Order(10251, "VICTE", 41.34, "Lyon", "Victuailles en stock", "France"));
             Orders.Add(new Order(10252, "SUPRD", 51.3, "Charleroi", "Suprêmes délices", "Belgium"));
             Orders.Add(new Order(10253, "HANAR", 58.17, "Rio de Janeiro", "Hanari Carnes", "Brazil"));
             Orders.Add(new Order(10254, "VICTE", 22.98, "Bern", "Chop-suey Chinese", "Switzerland"));
             Orders.Add(new Order(10255, "TOMSP", 148.33, "Genève", "Richter Supermarkt", "Switzerland"));
             Orders.Add(new Order(10256, "HANAR", 13.97, "Resende", "Wellington Import Export", "Brazil"));
             Orders.Add(new Order(10257, "VINET", 81.91, "San Cristóbal", "Hila Alimentos", "Venezuela"));
            
         }

         return Orders;
     }

     public int OrderID { get; set; }
     public string CustomerID { get; set; }
     public double Freight { get; set; }
     public string ShipCity { get; set; }
     public string ShipName { get; set; }
     public string ShipCountry { get; set; }
 }

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VNroZyCqJkbikUBx?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> The  [QueryCellInfo](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.QueryCellInfoEventArgs-1.html) event is triggered for every cell of the grid, so it may impact the performance of the grid whether used to modify a large number of cells.

### Using CSS

You can apply styles to the cells using CSS selectors. The Syncfusion Blazor DataGrid provides a class name for each cell element, which you can use to apply styles to that specific cell or cells in a particular column. The `e-rowcell` class is used to style the row cells, and the `e-selectionbackground` class is used to change the background color of the selected row.

```cshtml
<style>
    .e-grid td.e-cellselectionbackground {
        background: #9ac5ee;
        font-style: italic;
    }
</style>
```
The following example demonstrates how to customize the appearance of a specific row in the Grid on selection using `className`.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" AllowSelection="true" AllowPaging="true">
    <GridSelectionSettings CellSelectionMode="CellSelectionMode.Box" Mode="SelectionMode.Cell" Type="SelectionType.Multiple"></GridSelectionSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipName) HeaderText="Ship City" Width="100"></GridColumn>
    </GridColumns>
</SfGrid>
<style>
    .e-grid td.e-cellselectionbackground {
        background: #9ac5ee;
        font-style: italic;
    }
</style>

@code {
  
    public List<OrderData> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
    }   

}
{% endhighlight %}
{% highlight c# tabtitle="OrderData.cs" %}
   public class OrderData
    {
        public static List<OrderData> Orders = new List<OrderData>();
        public OrderData()
        {

        }
        public OrderData(int? OrderID,string CustomerID,string ShipCity,string ShipName)
        {
            this.OrderID = OrderID;
            this.CustomerID = CustomerID;
            this.ShipCity = ShipCity;
            this.ShipName = ShipName;

        }

        public static List<OrderData> GetAllRecords()
        {
            if (Orders.Count() == 0)
            {
                int code = 10;
                for (int i = 1; i < 2; i++)
                {
                    Orders.Add(new OrderData(10248, "VINET", "Reims", "Vins et alcol"));
                    Orders.Add(new OrderData(10249, "TOMSP", "Münster", "Toms Spezialitäten"));
                    Orders.Add(new OrderData(10250, "HANAR", "Rio de Janeiro", "Hanari Carnes"));
                    Orders.Add(new OrderData(10251, "VICTE", "Lyon", "Victuailles en stock"));
                    Orders.Add(new OrderData(10252, "SUPRD", "Charleroi", "Suprêmes délices"));
                    Orders.Add(new OrderData(10253, "HANAR", "Rio de Janeiro", "Chop-suey Chinese"));
                    Orders.Add(new OrderData(10254, "CHOPS", "Bern", "Richter Supermarkt"));
                    Orders.Add(new OrderData(10255, "RICSU", "Genève", "Wellington Importadora"));
                    Orders.Add(new OrderData(10256, "WELLI", "Resende", "HILARION-Abastos"));
                    code += 5;
                }
            }
            return Orders;
        }

        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public string ShipCity { get; set; }
        public string ShipName { get; set; }
    }
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LjVgjFsvqbeONlFV?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Using property

To customize the style of Syncfusion Blazor DataGrid cells, define [CustomAttributes](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ColumnModel.html#Syncfusion_Blazor_Grids_ColumnModel_CustomAttributes) property to the GridColumn definition object. The `CustomAttributes` property takes an object with the name-value pair to customize the CSS properties for Grid cells. You can also set multiple CSS properties to the custom class using the `CustomAttributes` property.

```cshtml
<style>
    .custom-css {
        background: #d7f0f4;
        font-style: italic;
        color:navy
    }
</style>
```
Here, setting the `CustomAttributes` property of the **ShipCity** column to an object that contains the CSS class ‘custom-css’. This CSS class will be applied to all the cells in the **ShipCity** column of the Grid.

```cshtml
<GridColumn Field=@nameof(Order.ShipCity) HeaderText="Ship City" CustomAttributes="@(new Dictionary<string, object>(){ { "class", "custom-css" }})" Width="100"></GridColumn>
```

The following example demonstrates how to customize the appearance of the **OrderID** and **ShipCity** columns using custom attributes.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" Height="315">
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" CustomAttributes="@(new Dictionary<string, object>(){ { "class", "custom-css" }})" TextAlign="TextAlign.Right" Width="140"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" CustomAttributes="@(new Dictionary<string, object>(){ { "class", "custom-css" }})" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipName) HeaderText="Ship Name" Width="100"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
  
    public List<OrderData> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
    }   

}
<style>
    .custom-css {
        background: #d7f0f4;
        font-style: italic;
        color: navy
    }
</style>
{% endhighlight %}
{% highlight c# tabtitle="OrderData.cs" %}
   public class OrderData
    {
        public static List<OrderData> Orders = new List<OrderData>();
        public OrderData()
        {

        }
        public OrderData(int? OrderID,string CustomerID,string ShipCity,string ShipName)
        {
            this.OrderID = OrderID;
            this.CustomerID = CustomerID;
            this.ShipCity = ShipCity;
            this.ShipName = ShipName;

        }

        public static List<OrderData> GetAllRecords()
        {
            if (Orders.Count() == 0)
            {
                int code = 10;
                for (int i = 1; i < 2; i++)
                {
                    Orders.Add(new OrderData(10248, "VINET", "Reims", "Vins et alcol"));
                    Orders.Add(new OrderData(10249, "TOMSP", "Münster", "Toms Spezialitäten"));
                    Orders.Add(new OrderData(10250, "HANAR", "Rio de Janeiro", "Hanari Carnes"));
                    Orders.Add(new OrderData(10251, "VICTE", "Lyon", "Victuailles en stock"));
                    Orders.Add(new OrderData(10252, "SUPRD", "Charleroi", "Suprêmes délices"));
                    Orders.Add(new OrderData(10253, "HANAR", "Rio de Janeiro", "Chop-suey Chinese"));
                    Orders.Add(new OrderData(10254, "CHOPS", "Bern", "Richter Supermarkt"));
                    Orders.Add(new OrderData(10255, "RICSU", "Genève", "Wellington Importadora"));
                    Orders.Add(new OrderData(10256, "WELLI", "Resende", "HILARION-Abastos"));
                    code += 5;
                }
            }
            return Orders;
        }

        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public string ShipCity { get; set; }
        public string ShipName { get; set; }
    }
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LtVKDuDnTisVMfBa?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> Custom attributes can be used to customize any cell in the Grid, including header and footer cells.

## Clip Mode

The clip mode feature is useful when you have a long text or content in a Syncfusion Blazor DataGrid cell, which overflows the cell’s width or height. It provides options to display the overflow content by either truncating it, displaying an ellipsis or displaying an ellipsis with a tooltip. You can enable this feature by setting [Columns.ClipMode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_ClipMode) property to one of the below available options.

There are three types of [ClipMode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_ClipMode) available:

* **Clip**: Truncates the cell content when it overflows its area.
* **Ellipsis**: Displays ellipsis when the cell content overflows its area.
* **EllipsisWithTooltip**: Displays ellipsis when the cell content overflows its area, also it will display the tooltip while hover on ellipsis is applied. Also it will display the tooltip while hover on ellipsis is applied.

The following example demonstrates, how to set the [ClipMode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_ClipMode) property for the Grid column.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.DropDowns

<label> Change the clip mode: </label>
<SfDropDownList TValue="ClipMode" TItem="DropDownOrder" DataSource="@DropDownValue" Width="100px">
    <DropDownListFieldSettings Text="Text" Value="Value"></DropDownListFieldSettings>
    <DropDownListEvents ValueChange="OnChange" TValue="ClipMode" TItem="DropDownOrder"></DropDownListEvents>
</SfDropDownList>

<SfGrid @ref="Grid" DataSource="@Orders" AllowPaging="true" Height="315">
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.Inventor) HeaderText="Name of the inventor" Width="80"></GridColumn>
        <GridColumn Field=@nameof(OrderData.PatentFamilies) HeaderText="No of patent families" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Country) HeaderText="Country" Width="80"></GridColumn>
        <GridColumn Field=@nameof(OrderData.NumberofINPADOCpatents) HeaderText="Number of INPADOC patents" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.MainFields) HeaderText="Main fields of Invention" ClipMode="@ClipValue" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    private SfGrid<OrderData> Grid;
    public List<OrderData> Orders { get; set; }
    public ClipMode ClipValue { get; set; } = Syncfusion.Blazor.Grids.ClipMode.Clip;
      
    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
    }   
    public class DropDownOrder
    {
        public string Text { get; set; }
        public ClipMode Value { get; set; }
    }    
    public void OnChange(ChangeEventArgs<ClipMode, DropDownOrder> Args)
    {
        ClipValue = Args.Value;
        Grid.Refresh();
    }
    List<DropDownOrder> DropDownValue = new List<DropDownOrder>
    {
        new DropDownOrder() { Text = "Clip", Value =Syncfusion.Blazor.Grids.ClipMode.Clip },
        new DropDownOrder() { Text = "Ellipsis", Value = Syncfusion.Blazor.Grids.ClipMode.Ellipsis},
        new DropDownOrder() { Text = "Ellipsis With Tooltip", Value = Syncfusion.Blazor.Grids.ClipMode.EllipsisWithTooltip }
    };
}
{% endhighlight %}
{% highlight c# tabtitle="OrderData.cs" %}
    public class OrderData
    {
        public static List<OrderData> Orders = new List<OrderData>();
        public OrderData()
        {

        }
        public OrderData(string Inventor,int? PatentFamilies,string NumberofINPADOCpatents,string Country,string MainFields)
        {
          this.Inventor= Inventor;
          this.PatentFamilies= PatentFamilies;
          this.NumberofINPADOCpatents= NumberofINPADOCpatents;
          this.Country= Country;
          this.MainFields= MainFields;
        }
        public static List<OrderData> GetAllRecords()
        {
            if (Orders.Count() == 0)
            {
                int code = 10;
                for (int i = 1; i < 2; i++)
                {
                    Orders.Add(new OrderData("Kia Silverb", 4737, "9839", "Australia", "Printing, Digital paper, Internet, Electronics,Lab-on-a-chip, MEMS, Mechanical, VLSI"));
                    Orders.Add(new OrderData("Shunpei Yamazaki", 4677, "10000+", "Japan", "Various"));
                    Orders.Add(new OrderData("Lowell L. Wood, Jr.",13197, "1332", "Canada", "Printing, Digital paper, Internet, Electronics, CGI, VLSI"));
                    Orders.Add(new OrderData("Paul Lap", 1255, "3099", "India", "Automotive, Stainless steel products"));
                    Orders.Add(new OrderData("Gurtej Sandhu", 1240, "2038", "USA", "Gaming machines"));
                    Orders.Add(new OrderData("Shunpei Yamazaki", 1240, "4126", "Canada", "Printing, Digital paper, Internet, Electronics, CGI, VLSI"));
                    Orders.Add(new OrderData("Paul Lap", 1093, "3360", "USA", "Automotive, Stainless steel products"));
                    Orders.Add(new OrderData("Gurtej Sandhu", 993, "1398", "Japan", "Various"));
                    Orders.Add(new OrderData("Kia Silverb", 949,"NA", "India", "Printing, Digital paper, Internet, Electronics, CGI, VLSI"));                  
                    code += 5;
                }
            }
            return Orders;
        }
        public string Inventor { get; set; }
        public int? PatentFamilies { get; set; }
        public string NumberofINPADOCpatents { get; set; }
        public string Country { get; set; }
        public string MainFields { get; set; }
    } 
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hjVAiMZUrUOzmfhI?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> * By default, [Columns.ClipMode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_ClipMode) value is **Ellipsis**.
> * If you set the **width** property of a column, the clip mode feature will be automatically applied to that column if the content exceeds the specified width.
> * Be careful when using the Clip mode, as it may result in important information being cut off. It is generally recommended to use the Ellipsis or EllipsisWithTooltip modes instead.

## Tooltip

The Syncfusion Blazor DataGrid allows you to display information about the Grid columns to the user when they hover over them with the mouse.

### Show tooltip

The Syncfusion Blazor DataGrid provides a built-in feature to display tooltips when hovering over header and content cells. You can enable this feature by setting the `ShowTooltip` property to **true** in the DataGrid. By default, it shows the cell value for both header and content cells. For special types like templates, it displays the row data of the corresponding cells.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" ShowTooltip="true" Width="700">
     <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="90"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="80"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="70"></GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderDate) HeaderText="Order Date" Format="d" Type="Syncfusion.Blazor.Grids.ColumnType.Date" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="90"></GridColumn>
   </GridColumns>
</SfGrid>

@code {
    public List<OrderData> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
    }
}

{% endhighlight %}
{% highlight c# tabtitle="OrderData.cs" %}

public class OrderData
{
    public static List<OrderData> Orders = new List<OrderData>();
    public OrderData()
    {

    }
    public OrderData( int? OrderID, string CustomerID, DateTime? OrderDate, double? Freight)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerID;
        this.OrderDate = OrderDate;
        this.Freight = Freight;
    }
    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count() == 0)
        {
            Orders.Add(new OrderData(10248, "VINET", new DateTime(2025, 07, 07), 32.38));
            Orders.Add(new OrderData(10249, "TOMSP", new DateTime(2025, 07, 07), 92.38));
            Orders.Add(new OrderData(10250, "HANAR", new DateTime(2025, 07, 07), 62.77));
            Orders.Add(new OrderData(10251, "VICTE", new DateTime(2025, 07, 07), 12.38));
            Orders.Add(new OrderData(10252, "SUPRD", new DateTime(2025, 07, 07), 82.38));
            Orders.Add(new OrderData(10253, "CHOPS", new DateTime(2025, 07, 07), 31.31));
            Orders.Add(new OrderData(10254, "RICSU", new DateTime(2025, 07, 07), 22.37));
            Orders.Add(new OrderData(10255, "WELLI", new DateTime(2025, 07, 07), 44.34));
            Orders.Add(new OrderData(10256, "RICSU", new DateTime(2025, 07, 07), 31.33));
        }
        return Orders;
    }
    public int? OrderID { get; set; }
    public string CustomerID { get; set; }
    public DateTime? OrderDate { get; set; }
    public double? Freight { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LXBSNYMiAEMphkRe?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Tooltip template

The Syncfusion Blazor DataGrid component provides a built-in option to customize tooltip content for both header and content cells. This can be achieved using the `TooltipTemplate` property, which accepts a `RenderFragment` under the `GridTemplates` component. This feature allows you to display additional information about columns when users hover over them, enhancing the clarity and usability of the DataGrid.

Tooltip customization is supported through the `TooltipTemplateContext`, which provides access to the following built-in properties:
<ul>
    <li><strong>Value</strong> – Displays the content of the hovered cell: the column name for header cells or the cell value for content cells.</li>
    <li><strong>RowIndex</strong> – Indicates the row number of the hovered cell. Returns -1 for header cells.</li>
    <li><strong>ColumnIndex</strong> – Indicates the column number of the hovered cell.</li>
    <li><strong>Data</strong> – Provides the full data object of the hovered row. Not available for header cells.</li>
    <li><strong>Column</strong> – Contains metadata about the column, such as the field name and formatting.</li>
</ul>

The following sample demonstrates a custom tooltip implementation using the `TooltipTemplate` in the DataGrid. The tooltip content is styled and includes interactive elements such as formatted text, icons, and contextual information to improve the overall user experience.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" Height="330" ShowTooltip="true" Width="700">
    <GridTemplates>
        <TooltipTemplate>
            @{
                var tooltip = context as TooltipTemplateContext;
                var order = tooltip?.Data as OrdersDetails;
                if (tooltip?.RowIndex == -1)
                {
                    if (tooltip.Value == "Order ID")
                    {
                        <span><strong>@tooltip.Value: </strong>Unique number used to identify each customer order.</span>
                    }
                    else if (tooltip.Value == "Customer ID")
                    {
                        <div>
                            <span><strong>@tooltip.Value: </strong>Displays the name of the customer who placed the order.</span>
                        </div>
                    }
                    else if (tooltip.Value == "Freight")
                    {
                        <span><strong>@tooltip.Value: </strong>Shipping cost for the order. </span>
                    }
                    else
                    {
                        <span><strong>@tooltip.Value: </strong>Name of the city where the order is delivered.</span>
                    }
                }
                else
                {
                    var fieldName = tooltip?.Column?.Field;
                    <div style="font-family: Arial; line-height: 1.6;">
                        @switch (fieldName)
                        {
                            case nameof(order.OrderID):
                                <p style="margin: 2px 0;">@((MarkupString)GetStatusMessage(order.Status, order.OrderDate))</p>
                                break;
                            case nameof(OrdersDetails.CustomerID):
                                <div>
                                    <p style="margin: 2px 0;">
                                        <strong>Email: </strong><a href="mailto:@order.Email">@order.Email</a>
                                    </p>
                                </div>
                                break;
                            case nameof(OrdersDetails.Freight):
                                <p style="margin: 4px 0;">
                                    <strong>Delivery Type: </strong>
                                    @GetDeliveryType(order.Freight)
                                </p>
                                break;
                            case nameof(OrdersDetails.ShipCity):
                                <span class="e-icons e-location"></span>
                                <strong>Country: </strong> @order.ShipCountry
                                break;
                            default:
                                <strong>@tooltip?.Column?.Field: </strong> @tooltip.Value
                                break;
                        }
                    </div>
                }
            }
        </TooltipTemplate>
    </GridTemplates>
    <GridColumns>
        <GridColumn Field=@nameof(OrdersDetails.OrderID) HeaderText="Order ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="90"></GridColumn>
        <GridColumn Field=@nameof(OrdersDetails.CustomerID) HeaderText="Customer ID" Width="90"></GridColumn>
        <GridColumn Field=@nameof(OrdersDetails.Freight) Format="C2" Width="80" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" EditType="EditType.NumericEdit"></GridColumn>
        <GridColumn Field=@nameof(OrdersDetails.ShipCity) HeaderText="Ship City" Width="100"></GridColumn>
    </GridColumns>
</SfGrid>

<style>
    .e-icons.e-location:before {
        position: relative;
        top: 2px; 
    }
</style>

@code {
    public List<OrdersDetails> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = OrdersDetails.GetAllRecords();
    }
    private string GetStatusMessage(string status, DateTime? orderDate)
    {
        return status switch
        {
            "Cancelled" => "This item has been cancelled and will not be delivered.",
            "Pending" => $"<strong>Expected Delivery Date: </strong> {orderDate?.ToShortDateString()}",
            "Delivered" => $"<strong>Delivered Date: </strong> {orderDate?.ToShortDateString()}",
            _ => "<strong>Status Unknown</strong>"
        };
    }
    private string GetDeliveryType(double freight)
    {
        if (freight <= 100.00)
            return "Standard Delivery";
        else if (freight <= 150.00)
            return "Express Delivery";
        else
            return "Premium Delivery";
    }
}

{% endhighlight %}
{% highlight c# tabtitle="OrderDetails.cs" %}

public class OrdersDetails
{
    public static List<OrdersDetails> Orders = new List<OrdersDetails>();
    public OrdersDetails()
    {

    }
    public OrdersDetails(int OrderID, string CustomerID, double Freight, DateTime OrderDate, string ShipCity, string ShipCountry, string Status, string Location, string Email)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerID;
        this.Freight = Freight;
        this.OrderDate = OrderDate;
        this.ShipCity = ShipCity;
        this.Status = Status;
        this.ShipCountry = ShipCountry;
        this.Location = Location;
        this.Email = Email;
    }
    public static List<OrdersDetails> GetAllRecords()
    {
        if (Orders.Count() == 0)
        {
            Orders.Add (new OrdersDetails (1001, "Nancy", 80, DateTime.Now.AddDays(-1), "Reims", "France", "Delivered", "France", "nancy@example.com"));
            Orders.Add (new OrdersDetails (1002, "Andrew", 120, DateTime.Now.AddDays(3), "Munster", "Germany", "Pending", "Germany", "andrew@example.com"));
            Orders.Add (new OrdersDetails (1003, "Janet", 180, DateTime.Now.AddDays(-3), "Charleroi", "Belgium", "Cancelled", "Belgium", "janet@example.com"));
            Orders.Add (new OrdersDetails (1004, "Margaret", 60, DateTime.Now.AddDays(-4), "Lyon", "France", "Delivered", "France", "margaret@example.com"));
            Orders.Add (new OrdersDetails (1005, "Steven", 130, DateTime.Now.AddDays(4), "Delhi", "India", "Pending", "India", "steven@example.com"));
            Orders.Add (new OrdersDetails (1006, "Michael", 220, DateTime.Now.AddDays(-6), "Tokyo", "Japan", "Delivered", "Japan", "michael@example.com"));
            Orders.Add (new OrdersDetails (1007, "Robert", 90, DateTime.Now.AddDays(-7), "Toronto", "Canada", "Cancelled", "Canada", "robert@example.com"));
            Orders.Add (new OrdersDetails (1008, "Laura", 160, DateTime.Now.AddDays(1), "Sydney", "Australia", "Pending", "Australia", "laura@example.com"));
            Orders.Add (new OrdersDetails (1009, "Anne", 90, DateTime.Now.AddDays(-9), "Reims", "France", "Delivered", "France", "anne@example.com"));
        }
        return Orders;
    }
                    
    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public DateTime OrderDate { get; set; }
    public double Freight { get; set; }
    public string ShipCity { get; set; }
    public string ShipCountry { get; set; }
    public string Status { get; set; }
    public string Location { get; set; }
    public string Email { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rtBItaiifNQmMncI?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> By default, custom tooltips will be displayed if the `ShowTooltip` property is set to **true**.

### Display custom tooltip for columns

The Syncfusion Blazor DataGrid provides a feature to display custom tooltips for its columns using the [SfTooltip](https://blazor.syncfusion.com/documentation/tooltip/getting-started). This allows you to provide additional information about the columns when the user hovers over them.

To enable custom tooltips for columns in the Grid, you can use the [Column Template](https://blazor.syncfusion.com/documentation/datagrid/column-template) feature by rendering the components inside the template.

This is demonstrated in the following sample code, where the tooltip for the **FirstName** column is rendered using `Column Template`.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Popups

<SfGrid DataSource="@Orders">
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.EmployeeID) HeaderText="Employee ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.FirstName) HeaderText="First Name" Width="130">
            <Template>
                @{
                    var employee = (context as OrderData);
                    Count++;
                    <SfTooltip @key="@Count" Position="Position.BottomLeft">
                        <ContentTemplate>
                            @employee.FirstName
                        </ContentTemplate>
                        <ChildContent>
                            <span>@employee.FirstName</span>
                        </ChildContent>
                    </SfTooltip>
                }
            </Template>
        </GridColumn>
        <GridColumn Field=@nameof(OrderData.Title) HeaderText="Title" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.HireDate) HeaderText="Hire Date" Format="d" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    int Count { get; set; } = 0;
    private SfGrid<OrderData> Grid;
    public List<OrderData> Orders { get; set; }
      
    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
    }     
}
{% endhighlight %}
{% highlight c# tabtitle="OrderData.cs" %}
public class OrderData
    {
        public static List<OrderData> Orders = new List<OrderData>();
        public OrderData()
        {

        }
        public OrderData( int? EmployeeID,string FirstName,string Title,DateTime HireDate)
        {
            this.EmployeeID= EmployeeID;
            this.FirstName= FirstName;
            this.Title= Title;
            this.HireDate = HireDate;
        }

        public static List<OrderData> GetAllRecords()
        {
            if (Orders.Count() == 0)
            {
                int code = 10;
                for (int i = 1; i < 2; i++)
                {
                    Orders.Add(new OrderData(1, "Nancy","Sales Representative",new DateTime(1996,07,06 )));
                    Orders.Add(new OrderData(2, "Andrew", "Vice President, Sales", new DateTime(1996, 07, 06)));
                    Orders.Add(new OrderData(3, "Janet", "Sales Manager", new DateTime(1996, 07, 06)));
                    Orders.Add(new OrderData(4, "Margaret", "Inside Sales Coordinator", new DateTime(1996, 07, 06)));
                    Orders.Add(new OrderData(5, "Steven", "Sales Representative", new DateTime(1996, 07, 06)));
                    Orders.Add(new OrderData(6, "Nancy", "Inside Sales Coordinator", new DateTime(1996, 07, 06)));
                    Orders.Add(new OrderData(7, "Janet", "Vice President, Sales", new DateTime(1996, 07, 06)));
                    Orders.Add(new OrderData(8, "Steven", "Inside Sales Coordinator", new DateTime(1996, 07, 06)));
                    Orders.Add(new OrderData(9,"Andrew", "Sales Manager", new DateTime(1996, 07, 06)));                             
                    code += 5;
                }
            }
            return Orders;
        }      
        public int? EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string Title { get; set; }
        public DateTime HireDate { get; set; }
    }  
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hDBUXxhczXWCAKzo?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Grid lines

The [GridLines](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_GridLines) in a Syncfusion Blazor DataGrid are used to separate the cells with horizontal and vertical lines for better readability. You can enable the Grid lines by setting the `GridLines` property to one of the following values:

| Modes | Actions |
|-------|---------|
| Both | Displays both the horizontal and vertical Grid lines.|
| None | No Grid lines are displayed.|
| Horizontal | Displays the horizontal Grid lines only.|
| Vertical | Displays the vertical Grid lines only.|
| Default | Displays Grid lines based on the theme.|

The following example demonstrates how to set the `GridLines` property based on changing the dropdown value using the [ValueChange](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfSwitch-1.html#Syncfusion_Blazor_Buttons_SfSwitch_1_ValueChange) event of the [DropDownList](https://blazor.syncfusion.com/documentation/dropdown-list/getting-started-with-web-app).

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.DropDowns

<label> Change the Grid lines: </label>
<SfDropDownList TValue="GridLine" TItem="DropDownOrder" DataSource="@DropDownValue" Width="100px">
    <DropDownListFieldSettings Text="Text" Value="Value"></DropDownListFieldSettings>
    <DropDownListEvents ValueChange="OnChange" TValue="GridLine" TItem="DropDownOrder"></DropDownListEvents>
</SfDropDownList>
<SfGrid DataSource="@Orders" GridLines="@GridLineValue" Height="315">
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.Inventor) HeaderText="Name of the inventor" Width="180"></GridColumn>
        <GridColumn Field=@nameof(OrderData.PatentFamilies) HeaderText="No of patent families" Width="180"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Country) HeaderText="Country" Width="140"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Active) HeaderText="Active" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.MainFields) HeaderText="Main fields of Invention" Width="200"></GridColumn>
    </GridColumns>
</SfGrid>

@code {   
    public List<OrderData> Orders { get; set; }
    public GridLine GridLineValue { get; set; } = GridLine.Both;

    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
    }
    public class DropDownOrder
    {
        public string Text { get; set; }
        public GridLine Value { get; set; }
    }
    List<DropDownOrder> DropDownValue = new List<DropDownOrder>
    {
        new DropDownOrder() { Text = "Default", Value =GridLine.Default },
        new DropDownOrder() { Text = "Horizontal", Value = GridLine.Horizontal},
        new DropDownOrder() { Text = "Vertical", Value = GridLine.Vertical },
        new DropDownOrder() { Text = "Both", Value = GridLine.Both },
        new DropDownOrder() { Text = "None", Value = GridLine.None }
    };
    public void OnChange(ChangeEventArgs<GridLine, DropDownOrder> Args)
    {
        GridLineValue = Args.Value;
    }
}
{% endhighlight %}
{% highlight c# tabtitle="OrderData.cs" %}
   public class OrderData
    {
        public static List<OrderData> Orders = new List<OrderData>();
        public OrderData()
        {

        }
        public OrderData(string Inventor,int? PatentFamilies,string Active,string Country,string MainFields)
        {
           this.Inventor = Inventor;
            this.PatentFamilies = PatentFamilies;
            this.Active = Active;
            this.Country = Country;
            this.MainFields = MainFields;

        }

        public static List<OrderData> GetAllRecords()
        {
            if (Orders.Count() == 0)
            {
                int code = 10;
                for (int i = 1; i < 2; i++)
                {
                    Orders.Add(new OrderData("Kia Silverbrook", 4737, "1994-2016", "Australia","Printing, Digital paper, Internet, Electronics,Lab-on-a-chip, MEMS, Mechanical"));
                    Orders.Add(new OrderData("Shunpei Yamazaki", 4677, "1976-2016", "Japan", "Thin film transistors, Liquid crystal displays, Solar cells, Flash memory, OLED"));
                    Orders.Add(new OrderData("Lowell L. Wood, Jr.", 1419, "1977-2016", "USA", "Mosquito laser, Nuclear weapons"));
                    Orders.Add(new OrderData("Paul Lapstun", 1281, "2000-2016", "Australia", "Printing, Digital paper, Internet, Electronics, CGI, VLSI"));
                    Orders.Add(new OrderData("Gurtej Sandhu", 1255, "1991-2016","India", "Thin film processes and materials, VLSI, Semiconductor device fabrication"));
                    Orders.Add(new OrderData("Jun Koyama", 1240, "1991-2016", "Japan", "Thin film transistors, Liquid crystal displays, OLED"));
                    Orders.Add(new OrderData("Roderick A. Hyde", 1240, "2001-2016", "USA", "Various"));
                    Orders.Add(new OrderData("Leonard Forbes", 1093, "1991-2016", "Canada", "Semiconductor Memories, CCDs, Thin film processes and materials, VLSI"));
                    Orders.Add(new OrderData("Thomas Edison", 1084, "1847(b)-1931(d)", "USA", "Electric power, Lighting, Batteries, Phonograph, Cement, Telegraphy, Mining"));
                    code += 5;
                }
            }
            return Orders;
        }

        public string Inventor { get; set; }
        public int? PatentFamilies { get; set; }
        public string Active { get; set; }
        public string Country { get; set; }
        public string MainFields { get; set; }
    }
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LNhgjYDHsYMePtHJ?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> By default, the Grid renders with **Default** mode.

N> You can refer to the [Syncfusion Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) feature tour page for its groundbreaking feature representations. You can also explore [Syncfusion Blazor DataGrid example](https://blazor.syncfusion.com/demos/datagrid/overview?theme=bootstrap5) to understand how to present and manipulate data.
