---
layout: post
title: Column Header in Blazor DataGrid Component | Syncfusion
description: Checkout and learn here all about column header in the Syncfusion Blazor DataGrid component and much more details.
platform: Blazor
control: DataGrid
documentation: ug
---

# Headers in Blazor DataGrid component

## Header text

By default, the header text of a column in DataGrid is displayed from the column's [Field](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Field)  value. However, you can easily override the default header title and provide a custom header text for the column using the [HeaderText](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_HeaderText) property. 

To enable the `HeaderText` property, you simply need to define it in the **GridColumn** component. The following example demonstrates how to enable header text for a  Grid column.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using BlazorApp1.Data

<SfGrid DataSource="@Orders" Height="315">
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderDate) HeaderText="Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
    </GridColumns>
</SfGrid>
@code {
    private SfGrid<OrderData> Grid;
    public List<OrderData> Orders { get; set; }
       
    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
    }   
}
{% endhighlight %}
{% highlight c# tabtitle="Order.cs" %}
    public class OrderData
    {
        public static List<OrderData> Orders = new List<OrderData>();
        public OrderData()
        {

        }
        public OrderData( int? OrderID, string CustomerID, DateTime? OrderDate,double? Freight)
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
                int code = 10;
                for (int i = 1; i < 2; i++)
                {
                    Orders.Add(new OrderData(10248, "VINET", new DateTime(1996,07,08), 32.38));
                    Orders.Add(new OrderData(10249, "TOMSP", new DateTime(1996, 07, 08),66.98));
                    Orders.Add(new OrderData(10248, "HANAR", new DateTime(1996, 07, 08),56.08));
                    Orders.Add(new OrderData(10248, "VICTE", new DateTime(1996, 07, 08),21.78));
                    Orders.Add(new OrderData(10248, "SUPRD", new DateTime(1996, 07, 08),87.56));
                    Orders.Add(new OrderData(10248, "HANAR", new DateTime(1996, 07, 08),32.56));
                    Orders.Add(new OrderData(10248, "CHOPS", new DateTime(1996, 07, 08),12.76));
                    Orders.Add(new OrderData(10248, "RICSU", new DateTime(1996, 07, 08),55.45));
                    Orders.Add(new OrderData(10248, "VINET", new DateTime(1996, 07, 08),11.94));                                                                                    
                    code += 5;
                }
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/LNrUMtACJAAfwAum?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}


>* The `HeaderText` property is optional, and if it is not defined, then the corresponding column's field value is set as header text for that column.  
>* You can also use the [HeaderTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_HeaderTemplate) of the `GridColumn` component to apply custom HTML content to the header cell.

## Header template

The [HeaderTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_HeaderTemplate) of the  [GridColumn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html) component used to customize the header element of a Grid column. With this property, you can render custom HTML elements or Blazor components to the header element. This feature allows you to add more functionality to the header, such as sorting or filtering.

To know about **Header Template** in Blazor DataGrid Component, you can check this video.

{% youtube
"youtube:https://www.youtube.com/watch?v=9YF9HnFY5Ew"%}

In this demo, the custom element is rendered for both **EmployeeID** and **OrderDate** column headers.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons
@using BlazorApp1.Data

<SfGrid @ref="Grid" DataSource="@Orders" AllowPaging="true" Height="315">
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) Width="130">
            <HeaderTemplate>
                <div>
                    <span class="e-icon-userlogin e-icons employee"></span> Customer ID
                </div>
            </HeaderTemplate>
        </GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderDate) Format="d" TextAlign="TextAlign.Right" Width="140">
            <HeaderTemplate>
                <div >
                    <SfSwitch ValueChange="Change" TChecked="bool"></SfSwitch>@HeaderValue
                </div>
            </HeaderTemplate>
        </GridColumn>
    </GridColumns>
</SfGrid>
<style>
      @@font-face {
        font-family: 'ej2-headertemplate';
        src: url(data:application/x-font-ttf;charset=utf-8;base64,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) format('truetype');
        font-weight: normal;
        font-style: normal;
    }

    .e-grid .e-icon-userlogin::before {
        font-family: 'ej2-headertemplate';
        width: 15px !important;
        content: '\e702';
    }

</style>
@code {
    private SfGrid<OrderData> Grid;
    public List<OrderData> Orders { get; set; }
    public string HeaderValue { get; set; } = "Order Date";
    private void Change(Syncfusion.Blazor.Buttons.ChangeEventArgs<bool> args)
    {
        if (args.Checked)
        {
            HeaderValue = "Purchase Date";
        }
        else
        {
            HeaderValue = "Order Date";
        }
        Grid.Refresh();
    }
       
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
        public OrderData( int? OrderID, string CustomerID, DateTime? OrderDate,double? Freight)
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
                int code = 10;
                for (int i = 1; i < 2; i++)
                {
                    Orders.Add(new OrderData(10248, "VINET", new DateTime(1996,07,08), 32.38));
                    Orders.Add(new OrderData(10249, "TOMSP", new DateTime(1996, 07, 08),66.98));
                    Orders.Add(new OrderData(10248, "HANAR", new DateTime(1996, 07, 08),56.08));
                    Orders.Add(new OrderData(10248, "VICTE", new DateTime(1996, 07, 08),21.78));
                    Orders.Add(new OrderData(10248, "SUPRD", new DateTime(1996, 07, 08),87.56));
                    Orders.Add(new OrderData(10248, "HANAR", new DateTime(1996, 07, 08),32.56));
                    Orders.Add(new OrderData(10248, "CHOPS", new DateTime(1996, 07, 08),12.76));
                    Orders.Add(new OrderData(10248, "RICSU", new DateTime(1996, 07, 08),55.45));
                    Orders.Add(new OrderData(10248, "VINET", new DateTime(1996, 07, 08),11.94));                                                                                    
                    code += 5;
                }
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/hDLqXarRxgGevNlF?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

>* The `HeaderTemplate` property is only applicable to DataGrid columns that have a header element.
>* You can use any HTML or Blazor component in the header template to add additional functionality to the header element.

## Stacked header 

In DataGrid, you can group multiple levels of column headers by stacking the Grid columns. This feature allows you to organize the Grid columns in a more structured and understandable way.This can be achieved by nesting the [GridColumn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn) directive within another `GridColumn` directive.You can define the `HeaderText` property of each sub-header column to set the text for that sub-header.

In the following sample, the columns **Order Date**, and **Freight** are grouped under **Order Details** and the columns **Shipped Date**, and **Ship Country** are grouped under **Shipped Details**.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.DropDowns
@using BlazorApp1.Data

<SfGrid DataSource="@Orders" AllowPaging="true">
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" IsPrimaryKey="true" Width="120">
            <HeaderTemplate>
                <a href="#">Order ID</a>
            </HeaderTemplate>
        </GridColumn>
        <GridColumn HeaderText="Order Details" TextAlign="TextAlign.Center">
            <GridColumns>
                <GridColumn Field="OrderDate" Width="130" HeaderText="Order Date" Format="d" TextAlign="TextAlign.Right" MinWidth="10"></GridColumn>
                <GridColumn Field="Freight" HeaderText="Freight ($)" Width="135" Format="C2" TextAlign="TextAlign.Right" MinWidth="10">
                </GridColumn>
            </GridColumns>
        </GridColumn>
        <GridColumn HeaderText="Ship Details" TextAlign="TextAlign.Center">
            <ChildContent>
                <GridColumns>
                    <GridColumn Field="ShippedDate" Width="140" HeaderText="Shipped Date" Format="d" TextAlign="TextAlign.Right" MinWidth="10"></GridColumn>
                    <GridColumn Field="ShipCountry" Width="140" HeaderText="Ship Country" Format="d" TextAlign="TextAlign.Right" MinWidth="10"></GridColumn>
                </GridColumns>
            </ChildContent>
            <HeaderTemplate>
                Ship Details <span>(<i class="fa fa-truck"></i>)</span>
            </HeaderTemplate>
           
        </GridColumn>
    </GridColumns>
</SfGrid>
<style>
    @{
        <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
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
        public OrderData( int? OrderID,DateTime? OrderDate,double? Freight,string ShipCountry,DateTime? ShippedDate)
        {
           this.OrderID = OrderID;
           this.OrderDate = OrderDate;   
           this.Freight = Freight;
           this.ShipCountry = ShipCountry;
           this.ShippedDate = ShippedDate;
        }

        public static List<OrderData> GetAllRecords()
        {
            if (Orders.Count() == 0)
            {
                int code = 10;
                for (int i = 1; i < 2; i++)
                {
                    Orders.Add(new OrderData(10248, new DateTime(1996,07,08), 32.38, "France",new DateTime(1996,07,16)));
                    Orders.Add(new OrderData(10249, new DateTime(1996, 07, 08),66.98, "Germany", new DateTime(1996, 07, 10)));
                    Orders.Add(new OrderData(10248, new DateTime(1996, 07, 08),56.08, "Brazil", new DateTime(1996, 07, 26)));
                    Orders.Add(new OrderData(10248, new DateTime(1996, 07, 08),21.78, "France", new DateTime(1996, 07, 24)));
                    Orders.Add(new OrderData(10248, new DateTime(1996, 07, 08),87.56, "Belgium", new DateTime(1996, 07, 01)));
                    Orders.Add(new OrderData(10248, new DateTime(1996, 07, 08),32.56, "Brazil", new DateTime(1996, 07, 06)));
                    Orders.Add(new OrderData(10248, new DateTime(1996, 07, 08),12.76, "Switzerland", new DateTime(1996, 07, 18)));
                    Orders.Add(new OrderData(10248, new DateTime(1996, 07, 08),55.45, "Switzerland", new DateTime(1996, 07, 19)));
                    Orders.Add(new OrderData(10248, new DateTime(1996, 07, 08),11.94, "Brazil", new DateTime(1996, 07, 17)));                                                                                    
                    code += 5;
                }
            }
            return Orders;
        }
        public int? OrderID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
        public string ShipCountry { get; set; }
        public DateTime? ShippedDate { get; set; }
    }
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LNrUsCZiiuVewxQD?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Align the text of header text

You can horizontally align the text in column headers of the DataGrid component using the [HeaderTextAlign](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_HeaderTextAlign) property of the `GridColumn` component. By default, the text is aligned to the left, but you can change the alignment by setting the value of the `HeaderTextAlign` property to one of the following options:

* **Left**: Aligns the text to the left (default).
* **Center**: Aligns the text to the center.
* **Right**: Aligns the text to the right.
* **Justify**: Header text is justified.

Here is an example of using the `HeaderTextAlign` property to align the text of a Grid column header:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using BlazorApp1.Data

<SfGrid DataSource="@Orders" AllowPaging="true">
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" HeaderTextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer Name" HeaderTextAlign="TextAlign.Center" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderDate) HeaderText=" Order Date" HeaderTextAlign="TextAlign.Left" Format="d" Type="ColumnType.Date" Width="130"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" HeaderTextAlign="TextAlign.Right" Format="C2" Width="120"></GridColumn>
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
        public OrderData( int? OrderID,DateTime? OrderDate,double? Freight,string CustomerID)
        {
           this.OrderID = OrderID;
           this.OrderDate = OrderDate;   
           this.Freight = Freight;
           this.CustomerID = CustomerID;          
        }
        public static List<OrderData> GetAllRecords()
        {
            if (Orders.Count() == 0)
            {
                int code = 10;
                for (int i = 1; i < 2; i++)
                {
                    Orders.Add(new OrderData(10248, new DateTime(1996,07,08), 32.38, "VINET"));
                    Orders.Add(new OrderData(10249, new DateTime(1996, 07, 08),66.98, "TOMSP"));
                    Orders.Add(new OrderData(10248, new DateTime(1996, 07, 08),56.08, "HANAR"));
                    Orders.Add(new OrderData(10248, new DateTime(1996, 07, 08),21.78, "SUPRD"));
                    Orders.Add(new OrderData(10248, new DateTime(1996, 07, 08),87.56, "VICTE"));
                    Orders.Add(new OrderData(10248, new DateTime(1996, 07, 08),32.56, "HANAR"));
                    Orders.Add(new OrderData(10248, new DateTime(1996, 07, 08),12.76, "CHOPS"));
                    Orders.Add(new OrderData(10248, new DateTime(1996, 07, 08),55.45, "RICSU"));
                    Orders.Add(new OrderData(10248, new DateTime(1996, 07, 08),11.94, "WELLI"));                                                                                    
                    code += 5;
                }
            }
            return Orders;
        }
        public int? OrderID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
        public string CustomerID { get; set; }    
    }
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BNLqWMjsrtUyIcLO?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

>* The `HeaderTextAlign` property only changes the alignment of the text in the column header, and not the content of the column. If you want to align both the column header and content, you can use the [TextAlign](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_TextAlign) property.
>* You can also use the `HeaderTextAlign` property with the stacked header feature in Syncfusion DataGrid. The property will align the header text in the sub-headers as well.

## Autowrap the header text

The autowrap allows the cell content of the datagrid to wrap to the next line when it exceeds the boundary of the specified cell width. The cell content wrapping works based on the position of white space between words. To support the Autowrap functionality in Syncfusion DataGrid, you should set the appropriate [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Width) for the columns. The column width defines the maximum width of a column and helps to wrap the content automatically.

To enable auto wrap, set the [AllowTextWrap](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowTextWrap) property to `true`. You can configure the auto wrap mode by setting the [TextWrapSettings.WrapMode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_TextWrapSettings) property.

DataGrid provides the below three options for configuring:

* **Both**: This is the default value for wrapMode. With this option, both the grid header text and content is wrapped.
* **Header**: With this option, only the grid header text is wrapped.
* **Content**: With this option, only the grid content is wrapped.

In the following example, the [TextWrapSettings.WrapMode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridTextWrapSettings.html#Syncfusion_Blazor_Grids_GridTextWrapSettings_WrapMode) is set to **Content**.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using BlazorApp1.Data

<SfGrid  DataSource="@Orders" GridLines="GridLine.Default" AllowTextWrap="true" Height="315">
    <GridTextWrapSettings WrapMode="WrapMode.Header"></GridTextWrapSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.Inventor) HeaderText="Inventor Name" Width="70"></GridColumn>
        <GridColumn Field=@nameof(OrderData.NumberofPatentFamilies) HeaderText="Number of Patent Families" Width="80"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Country) HeaderText="Country" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Mainfieldsofinvention) HeaderText="Main Fields Of Invention" Width="120"></GridColumn>
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
        public OrderData(string Inventor, int? PatentFamilies, string Country, string MainFields)
        {
            this.Inventor = Inventor;
            this.NumberofPatentFamilies = PatentFamilies;
            this.Country = Country;
            this.Mainfieldsofinvention = MainFields;          
        }
        public static List<OrderData> GetAllRecords()
        {
            if (Orders.Count() == 0)
            {
                int code = 10;
                for (int i = 1; i < 2; i++)
                {
                    Orders.Add(new OrderData("Kia Silverb", 4737, "Australia", "Printing, Digital paper, Internet, Electronics,Lab-on-a-chip, MEMS, Mechanical, VLSI"));
                    Orders.Add(new OrderData("Shunpei Yamazaki", 4677, "Japan", "Various"));
                    Orders.Add(new OrderData("Lowell L. Wood, Jr.", 13197, "Canada", "Printing, Digital paper, Internet, Electronics, CGI, VLSI"));
                    Orders.Add(new OrderData("Paul Lap", 1255, "India", "Automotive, Stainless steel products"));
                    Orders.Add(new OrderData("Gurtej Sandhu", 1240, "USA", "Gaming machines"));
                    Orders.Add(new OrderData("Shunpei Yamazaki", 1240, "Canada", "Printing, Digital paper, Internet, Electronics, CGI, VLSI"));
                    Orders.Add(new OrderData("Paul Lap", 1093, "USA", "Automotive, Stainless steel products"));
                    Orders.Add(new OrderData("Gurtej Sandhu", 993, "Japan", "Various"));
                    Orders.Add(new OrderData("Kia Silverb", 949, "India", "Printing, Digital paper, Internet, Electronics, CGI, VLSI"));
                    code += 5;
                }
            }
            return Orders;
        }
        public string Inventor { get; set; }
        public int? NumberofPatentFamilies { get; set; }
        public string Country { get; set; }
        public string Mainfieldsofinvention { get; set; }
    }
{% endhighlight %}
{% endtabs %}

>* If a column width is not specified, then the Autowrap of columns will be adjusted with respect to the DataGrid's width.
>* If a column's header text contains no white space, the text may not be wrapped.
>* If the content of a cell contains HTML tags, the Autowrap functionality may not work as expected. In such cases, you can use the [HeaderTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_HeaderTemplate) and [Template](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Template) properties of the column to customize the appearance of the header and cell content.

{% previewsample "https://blazorplayground.syncfusion.com/embed/BtVKWMjirseyNsmj?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}


## Change the height of header

Changing the height of the header can be useful in cases where the default height is not sufficient to display the header content cell. For example, if you have a header with a lot of text or if you want to add an image to the header, you may need to increase the height of the header to accommodate the content.This can be easily achieved by changing the height of the header using CSS or by dynamically adjusting the height using a methods.

**Using css**

You can use CSS to override the default height of the **.e-grid .e-headercell** class to change the height of the header. Here is an example code snippet:

```css
.e-grid .e-headercell {
  height: 130px;
}
```

## Change the orientation of header text

By default, the text in the column headers of the Syncfusion DataGrid control is oriented horizontally. However, in some cases, you may want to change the orientation of the header text to vertical, diagonal, or at a custom angle. This can be achieved by adding a custom CSS class to the column header cell using the [CustomAttributes](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_CustomAttributes) property of the [GridColumn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html).

Follow the below steps to change the orientation of the header text in DataGrid:

**Step 1**: **Create a CSS class with orientation style for grid header cell**

To `rotate` the header text, you can create a CSS class with the `transform` property that rotates the header text 90 degrees. This class will be added to the header cell using the `CustomAttributes` property.

```css
 .e-grid .e-columnheader .e-headercell.textorientationclass .e-headercelldiv { 
        transform: rotate(90deg);  // Rotate a particular headertext  
    }
```

**Step 2**: **Add the custom CSS class to the datagrid column**

Once you have created the CSS class, you can add it to the particular column by using the `CustomAttributes` property. This property allows you to add any custom  attribute to the GridColumn.

For example, to add the textorientationclass class to the CustomerID column, you can use the following code:

```cshtml
    <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" TextAlign="TextAlign.Center" CustomAttributes="@(new Dictionary<string, object>(){ { "class", "textorientationclass" }})" Width="150"></GridColumn>
```

**Step 3**: **Resize the header cell height**

After adding the custom CSS class to a column, you need to resize the header cell height so that the rotated header text is fully visible. You can do this by using the following code:

```cshtml
function setHeaderHeight(args) {
    var textWidth = document.querySelector(".textorientationclass > div").scrollWidth; // Obtain the width of the headerText content.
    var header = document.querySelectorAll(".e-columnheader");
    for (var i = 0; i < header.length; i++) {
        (header.item(i)).style.height = textWidth + 'px'; // Assign the obtained textWidth as the height of the column header.
    }
}
```

This is demonstrated in the following sample:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using BlazorApp1.Data
@inject IJSRuntime IJSRuntime

<SfGrid DataSource="@Orders" Height="240" RowHeight="60">
    <GridEvents DataBound="DataBound" Created="Created" TValue="OrderData"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Center" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer Name" TextAlign="TextAlign.Center" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" CustomAttributes="@(new Dictionary<string, object>(){ { "class", "textorientationclass" }})" TextAlign="TextAlign.Center" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" TextAlign="TextAlign.Center" Width="130"></GridColumn>
    </GridColumns>
</SfGrid>
<style>
    .e-grid .e-columnheader .e-headercell.textorientationclass .e-headercelldiv {
        transform: rotate(90deg);
    }
</style>
@code {
    public List<OrderData> Orders { get; set; }
    public bool InitialRender = false;
    public void Created()
    {
        InitialRender = true;
    }
    public void DataBound()
    {
        if (InitialRender) //Call the JS method by checking for initial Grid rendering
        {
            InitialRender = false;
            IJSRuntime.InvokeAsync<object>("setHeaderHeight");
        }
    }
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
        public OrderData(int? OrderID, string CustomerID, double Freight, string ShipCity)
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
                    Orders.Add(new OrderData(10250, "HANAR", 65.83, "Rio de Janei"));
                    Orders.Add(new OrderData(10251, "VINET", 41.34, "Lyon"));
                    Orders.Add(new OrderData(10252, "SUPRD", 51.30, "Charleroi"));
                    Orders.Add(new OrderData(10253, "HANAR", 58.17, "Rio de Janei"));
                    Orders.Add(new OrderData(10254, "CHOPS", 22.98, "Bern"));
                    Orders.Add(new OrderData(10255, "VINET", 148.53, "Genève"));
                    Orders.Add(new OrderData(10256, "HANAR", 13.97, "Resende"));
                    code += 5;
                }
            }
            return Orders;
        }
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public double Freight { get; set; }
        public string ShipCity { get; set; }
    }
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VZBKiiDMrraFxmkh?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Customize header text styles 

Customizing the datagrid header styles allows you to modify the appearance of the column header in the DataGrid control to meet your design requirements. You can customize the font, background color, and other styles of the header cells. To customize the header styles in the grid, you can use CSS and CustomAttributes property of the GridColumn component.

### Using CSS

You can apply styles to the header cells using CSS selectors. The DataGrid provides a class name for each header cell element, which you can use to apply styles to that specific header cell. The **.e-headercell** class can be used to change the background color and text color of the column header.

```CSS
  .e-grid .e-headercell {
    background-color: #a2d6f4;
    color:rgb(3, 2, 2);
  }
```
Here's an example that demonstrates how to customize the appearance of a specific column header in the DataGrid using **className**.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using BlazorApp1.Data

<SfGrid DataSource="@Orders" AllowPaging="true">
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" Width="130"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>
<style>
    .e-grid .e-headercell {
        background-color: #a2d6f4;
        color: rgb(3, 2, 2);
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
        public OrderData(int? OrderID, string CustomerID, double Freight, DateTime? OrderDate)
        {
            this.OrderID = OrderID;
            this.CustomerID = CustomerID;
            this.Freight = Freight;
            this.OrderDate = OrderDate;            
        }
        public static List<OrderData> GetAllRecords()
        {
            if (Orders.Count() == 0)
            {
                int code = 10;
                for (int i = 1; i < 2; i++)
                {
                    Orders.Add(new OrderData(10248, "VINET", 32.38, new DateTime(1996,07,08)));
                    Orders.Add(new OrderData(10249, "TOMSP", 11.61, new DateTime(1996, 07, 18)));
                    Orders.Add(new OrderData(10250, "HANAR", 65.83, new DateTime(1996, 07, 05)));
                    Orders.Add(new OrderData(10251, "VINET", 41.34, new DateTime(1996, 07, 23)));
                    Orders.Add(new OrderData(10252, "SUPRD", 51.30, new DateTime(1996, 07, 16)));
                    Orders.Add(new OrderData(10253, "HANAR", 58.17, new DateTime(1996, 07, 12)));
                    Orders.Add(new OrderData(10254, "CHOPS", 22.98, new DateTime(1996, 07, 18)));
                    Orders.Add(new OrderData(10255, "VINET", 148.53, new DateTime(1996, 07, 05)));
                    Orders.Add(new OrderData(10256, "HANAR", 13.97, new DateTime(1996, 07, 01)));
                    code += 5;
                }
            }
            return Orders;
        }
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public double Freight { get; set; }
        public DateTime? OrderDate { get; set; }
    } 
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rZLUsMjiVUSAIviT?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Using property 

You can customize the appearance of the column headers in DataGrid using the [CustomAttributes](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_CustomAttributes) property of the [GridColumn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html). The `CustomAttributes` property takes an object with the name-value pair to customize the CSS properties for grid header cells. You can also set multiple CSS properties to the custom class using the customAttributes property.

To customize the header of a column, you can follow the steps below:

Step 1: Define a CSS class that specifies the styles you want to apply to the header cell of the column. For example, to change the background color and text color of the header cell, define a CSS class like this:

```CSS
.e-grid .e-headercell.customcss {
       background-color: rgb(43, 205, 226);
       color: black;
    }

```

Step 2: Set the **CustomAttributes** property of the desired column to an object that contains the CSS class **customcss**. This CSS class will be applied to the header cell of the specified column in the Grid.

```cshtml
<GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" CustomAttributes="@(new Dictionary<string, object>(){ { "class", "customcss" }})" HeaderTextAlign="TextAlign.Center" Width="150"></GridColumn>
```

The following example demonstrates how to customize the appearance of the **OrderID** and **Freight** columns using custom attributes.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using BlazorApp1.Data

<SfGrid DataSource="@Orders" AllowPaging="true">
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" CustomAttributes="@(new Dictionary<string, object>(){ { "class", "customcss" }})" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer Name" CustomAttributes="@(new Dictionary<string, object>(){ { "class", "customcss" }})" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" Width="130"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>
<style>
    .e-grid .e-headercell.customcss {
        background-color: rgb(43, 205, 226);
        color: black;
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
        public OrderData(int? OrderID, string CustomerID, double Freight, DateTime? OrderDate)
        {
            this.OrderID = OrderID;
            this.CustomerID = CustomerID;
            this.Freight = Freight;
            this.OrderDate = OrderDate;            
        }
        public static List<OrderData> GetAllRecords()
        {
            if (Orders.Count() == 0)
            {
                int code = 10;
                for (int i = 1; i < 2; i++)
                {
                    Orders.Add(new OrderData(10248, "VINET", 32.38, new DateTime(1996,07,08)));
                    Orders.Add(new OrderData(10249, "TOMSP", 11.61, new DateTime(1996, 07, 18)));
                    Orders.Add(new OrderData(10250, "HANAR", 65.83, new DateTime(1996, 07, 05)));
                    Orders.Add(new OrderData(10251, "VINET", 41.34, new DateTime(1996, 07, 23)));
                    Orders.Add(new OrderData(10252, "SUPRD", 51.30, new DateTime(1996, 07, 16)));
                    Orders.Add(new OrderData(10253, "HANAR", 58.17, new DateTime(1996, 07, 12)));
                    Orders.Add(new OrderData(10254, "CHOPS", 22.98, new DateTime(1996, 07, 18)));
                    Orders.Add(new OrderData(10255, "VINET", 148.53, new DateTime(1996, 07, 05)));
                    Orders.Add(new OrderData(10256, "HANAR", 13.97, new DateTime(1996, 07, 01)));
                    code += 5;
                }
            }
            return Orders;
        }
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public double Freight { get; set; }
        public DateTime? OrderDate { get; set; }
    } 
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LZLqCMNiLfcCJPPZ?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}






