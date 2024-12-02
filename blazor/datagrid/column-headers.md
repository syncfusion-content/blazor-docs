---
layout: post
title: Column Header in Blazor DataGrid Component | Syncfusion
description: Checkout and learn here all about column header in the Syncfusion Blazor DataGrid component and much more details.
platform: Blazor
control: DataGrid
documentation: ug
---

# Headers in Blazor DataGrid component

The Syncfusion Blazor DataGrid component provides a comprehensive set of options to customize and manage headers efficiently. Headers play a crucial role in organizing and presenting data effectively in the grid.

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

<SfGrid @ref="Grid" DataSource="@Orders" Height="315">
    <GridColumns>
        <GridColumn Field=@nameof(OrderDetails.OrderID) TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.CustomerID) Width="130">
            <HeaderTemplate>
                <div>
                    <span class="e-icon-userlogin e-icons employee"></span> Customer ID
                </div>
            </HeaderTemplate>
        </GridColumn>
        <GridColumn Field=@nameof(OrderDetails.Freight) HeaderText="Freight" Format="C2" Width="150">
            <HeaderTemplate>
                <div @onclick:stopPropagation>
                    <SfDropDownList TValue="string" TItem="Columns" DataSource="@DropDownData" @bind-Value="@DropDownValue" Width="120px">
                        <DropDownListFieldSettings Value="ID" Text="Value"></DropDownListFieldSettings>
                    </SfDropDownList>
                </div>
            </HeaderTemplate>
        </GridColumn>
        <GridColumn Field=@nameof(OrderDetails.OrderDate) Format="d" TextAlign="TextAlign.Right" Width="140">
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
        src: url(data:application/x-font-ttf;charset=utf-8;base64,AAEAAAAKAIAAAwAgT1MvMj1vTFIAAAEoAAAAVmNtYXDS2c5qAAABjAAAAEBnbHlmQmNFrQAAAdQAAANoaGVhZBRdbkIAAADQAAAANmhoZWEIUQQEAAAArAAAACRobXR4DAAAAAAAAYAAAAAMbG9jYQCOAbQAAAHMAAAACG1heHABHgENAAABCAAAACBuYW1lohGZJQAABTwAAAKpcG9zdA2o3w0AAAfoAAAAQAABAAAEAAAAAFwEAAAAAAAD9AABAAAAAAAAAAAAAAAAAAAAAwABAAAAAQAATBXy9l8PPPUACwQAAAAAANillKkAAAAA2KWUqQAAAAAD9APzAAAACAACAAAAAAAAAAEAAAADAQEAEQAAAAAAAgAAAAoACgAAAP8AAAAAAAAAAQQAAZAABQAAAokCzAAAAI8CiQLMAAAB6wAyAQgAAAIABQMAAAAAAAAAAAAAAAAAAAAAAAAAAAAAUGZFZABA5wLpYAQAAAAAXAQAAAAAAAABAAAAAAAABAAAAAQAAAAEAAAAAAAAAgAAAAMAAAAUAAMAAQAAABQABAAsAAAABgAEAAEAAucC6WD//wAA5wLpYP//AAAAAAABAAYABgAAAAIAAQAAAAAAjgG0ABEAAAAAA8kD8wADAAcACwAPABMAFwAbAB8AIwAnACsALwAzADcAOwBPAGsAACUVIzUjFSM1IxUjNSMVIzUjFSM1JRUjNSMVIzUjFSM1IxUjNSMVIzUlFSM1IxUjNSMVIzUjFSM1IxUjNQMVHwYhPwcRITcjDwghNS8HIzUjFSE1IwN2U1NTU1RTU1NTAuxTU1NTVFNTU1MC7FNTU1NUU1NTU1QCAwUGBggIA0QICAcHBQQBAvxsp30ICAcHAgUDAQEDlAECBAUHBwgIfVP+YFOzU1NTU1NTU1NTU6dUVFRUVFRUVFRUplNTU1NTU1NTU1P+NgQIBwcGBAMCAQIEBQcHAwgCdPoBAgQFAwcHCIF8CQgHBgUEAgFTU1MABAAAAAAD9APeADQAbQCuAQAAAAEfCDc1Lwc1PwIPBy8HHww3HwQPATMVPwc1Lx0jDwMfAgUdAR8GBTUzLxQjDx0BFxUfEDsBPxA1Nyc1LxIPEhUCCg8OGxcVExANCgMBAQMDCQQDAgECAxESEhMTExUUFRQTFBISEhEHCwYHCAkKCw0NDw8SuQQGAwIBAgRxlgsKCQcGBAMBAgMDAwUFBQcGBwgICQkKCgsKDAsMDQwNDQ4NDg45BQUDAQEEA/1eAgUGBwkKCwHjeggKDhEUFxs1FRMSEA4NCwoJBwcJBjwODg0ODQ0MDQwLDAoLCgoJCQgIBwYHBQUFAwMDAgEBAQECAgYICg0ODxISFBUXFwwMDA0MDQwMFxcVFBISDw4MCwgGAgIBAQICAwcJCw0PERITFRUXDAwMDA0NDAwMDAsXFRQTEQ8ODQoIBgICAVQEAwgJCgsMCwwbEBAREREZEA8VDAwKCgoIBwYFAwIBAQIDBQYHCAoUFQwLCwsLCgoJCAcGMwsWFhUVHB3QAQIEBggICgueDg4ODg0NDA0MCwsLCwoKCQgJBwgGBwUFBAQDAwECCw8NDxETCrIlawsKCAgGBAIB0AoLCwoLCQgNCAkLDA0NDg4ODg4ZFAIBAwMEBAUGBgYIBwkICQoKCwsLDAwMDA0ODQ4ODgH7DQwMDBgWFRQTERAODAoIBgICAQECAgYICgwOEBETFBUWGAwMDA0MDQwMCxcWFRMSEA8NDAkHAwIBAQEBAQECAwMICwwOEBETFBUWFwwMDQAAAAASAN4AAQAAAAAAAAABAAAAAQAAAAAAAQASAAEAAQAAAAAAAgAHABMAAQAAAAAAAwASABoAAQAAAAAABAASACwAAQAAAAAABQALAD4AAQAAAAAABgASAEkAAQAAAAAACgAsAFsAAQAAAAAACwASAIcAAwABBAkAAAACAJkAAwABBAkAAQAkAJsAAwABBAkAAgAOAL8AAwABBAkAAwAkAM0AAwABBAkABAAkAPEAAwABBAkABQAWARUAAwABBAkABgAkASsAAwABBAkACgBYAU8AAwABBAkACwAkAacgZWoyLWhlYWRlcnRlbXBsYXRlUmVndWxhcmVqMi1oZWFkZXJ0ZW1wbGF0ZWVqMi1oZWFkZXJ0ZW1wbGF0ZVZlcnNpb24gMS4wZWoyLWhlYWRlcnRlbXBsYXRlRm9udCBnZW5lcmF0ZWQgdXNpbmcgU3luY2Z1c2lvbiBNZXRybyBTdHVkaW93d3cuc3luY2Z1c2lvbi5jb20AIABlAGoAMgAtAGgAZQBhAGQAZQByAHQAZQBtAHAAbABhAHQAZQBSAGUAZwB1AGwAYQByAGUAagAyAC0AaABlAGEAZABlAHIAdABlAG0AcABsAGEAdABlAGUAagAyAC0AaABlAGEAZABlAHIAdABlAG0AcABsAGEAdABlAFYAZQByAHMAaQBvAG4AIAAxAC4AMABlAGoAMgAtAGgAZQBhAGQAZQByAHQAZQBtAHAAbABhAHQAZQBGAG8AbgB0ACAAZwBlAG4AZQByAGEAdABlAGQAIAB1AHMAaQBuAGcAIABTAHkAbgBjAGYAdQBzAGkAbwBuACAATQBlAHQAcgBvACAAUwB0AHUAZABpAG8AdwB3AHcALgBzAHkAbgBjAGYAdQBzAGkAbwBuAC4AYwBvAG0AAAAAAgAAAAAAAAAKAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAADAQIBAwEEAAtCVF9DYWxlbmRhcghlbXBsb3llZQAA) format('truetype');
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
    private SfGrid<OrderDetails> Grid;
    public List<OrderDetails> Orders { get; set; }
    public string HeaderValue { get; set; } = "Order Date";
    public string DropDownValue { get; set; } = "Freight";    
    public class Columns
    {
        public string ID { get; set; }
        public string Value { get; set; }
    }    
    List<Columns> DropDownData = new List<Columns>    {
        new Columns() { ID= "Freight", Value= "Freight" },
        new Columns() { ID= "Shipment", Value= "Shipment" },
        new Columns() { ID= "Cargo", Value= "Cargo" },
    };
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
        Orders = OrderDetails.GetAllRecords();
    }   
}
{% endhighlight %}
{% highlight c# tabtitle="OrderDetails.cs" %}
public class OrderDetails
{
    public static List<OrderDetails> order = new List<OrderDetails>();
    public OrderDetails(int OrderID, string CustomerId, int EmployeeId, double Freight, DateTime OrderDate)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerId;
        this.EmployeeID = EmployeeId;
        this.Freight = Freight;
        this.OrderDate = OrderDate;
    }
    public static List<OrderDetails> GetAllRecords()
    {
        if (order.Count == 0)
        {
            order.Add(new OrderDetails(10248, "VINET",  5,  32.38, new DateTime(1996, 7, 4)));
            order.Add(new OrderDetails(10249, "TOMSP",  6,  11.61, new DateTime(1996, 7, 5)));
            order.Add(new OrderDetails(10250, "HANAR",  4,  65.83,new DateTime(1996, 7, 8)));
            order.Add(new OrderDetails(10251, "VICTE",  3, 41.34, new DateTime(1996, 7, 8)));
            order.Add(new OrderDetails(10252, "SUPRD",  4, 51.3, new DateTime(1996, 7, 9)));
            order.Add(new OrderDetails(10253, "HANAR",  3,  58.17, new DateTime(1996, 7, 10)));
            order.Add(new OrderDetails(10254, "CHOPS",  5,  22.98, new DateTime(1996, 7, 11)));
            order.Add(new OrderDetails(10255, "RICSU",  9,  148.33,  new DateTime(1996, 7, 12)));
            order.Add(new OrderDetails(10256, "WELLI",  3,  13.97, new DateTime(1996, 7, 15)));
            order.Add(new OrderDetails(10257, "HILAA",  4,  81.91, new DateTime(1996, 7, 16)));
            order.Add(new OrderDetails(10258, "ERNSH",  1,  140.51, new DateTime(1996, 7, 17)));
            order.Add(new OrderDetails(10259, "CENTC",  4, 3.25, new DateTime(1996, 7, 18)));
            order.Add(new OrderDetails(10260, "OTTIK",  4, 55.09, new DateTime(1996, 7, 19)));
            order.Add(new OrderDetails(10261, "QUEDE",  4, 3.05, new DateTime(1996, 7, 19)));
            order.Add(new OrderDetails(10262, "RATTC", 8, 48.29, new DateTime(1996, 7, 22)));
        }
        return order;
    }
    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public int EmployeeID { get; set; }
    public double Freight { get; set; }
    public DateTime OrderDate { get; set; } 
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LXVJshXLfRNuKUbF?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

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

## Change header text dynamically

The Syncfusion Grid component provides a way to modify the header text of a corresponding column in real-time based on events or other events. This feature can be useful in various scenarios, such as displaying a custom header text for a specific column or updating the header text dynamically based on input. By allowing for dynamic changes to the header text, the Grid provides a more flexible and customizable experience.

**Using Event**

To modify the header text of a corresponding column dynamically, you can use the [HeaderCellInfo](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_HeaderCellInfo) event provided by the Syncfusion Grid. This event is triggered for each header cell element rendered in the Grid.

When the `HeaderCellInfo` event is triggered, it provides a **HeaderCellInfoEventArgs** object as a parameter. This object contains the following properties:

* **cell**: Defines the header cell that is being modified.
* **node**: Defines the DOM element of the header cell that is being modified.

You can use these properties to access and modify the header text of the corresponding column. Once the header text is modified, you can refresh the Grid to reflect the changes by calling the [RefreshHeaderAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_RefreshHeaderAsync) method of the Grid.

**Using method**

The Grid component provides several methods that allow you to change the column header text dynamically. Here are some of the methods you can use:

1. [GetColumnByFieldAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_GetColumnByFieldAsync_System_String_): This method takes a field name as a parameter and returns the entire column object that corresponds to that field name, including properties such as headerText, width, and alignment. You can use this method to modify any aspect of the column.

2.	[GetColumnByUidAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_GetColumnByUidAsync_System_String_): Retrieves the column object based on its unique identifier. You can modify the `HeaderText` property of the column object to change the header text.
	
> * When you change the header text dynamically, you need to **refresh** the Grid to reflect the changes by calling the [RefreshHeaderAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_RefreshHeaderAsync) method.
> * The unique identifier is automatically generated by the Grid component and may change whenever the grid is refreshed or updated.

Here is an example of how to change the header text of a column using the `GetColumnByFieldAsync` method:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.DropDowns
@using Syncfusion.Blazor.Inputs
@using Syncfusion.Blazor.Buttons

<div style="margin-bottom: 5px">
    <label style="margin: 7px 3px 0 0"> Select column name:</label>
    <SfDropDownList TValue="string" TItem="Columns" Width="150px" Placeholder="Select a Column" DataSource="@DropDownData" @bind-Value="@DropDownValue">
        <DropDownListFieldSettings Value="ID" Text="Value"></DropDownListFieldSettings>
    </SfDropDownList>
</div>
<div style="margin-bottom: 5px">
    <label style="margin: 7px 3px 0 0"> Enter New Header Text:</label>
    <SfTextBox CssClass="e-outline" @bind-Value="@ModifiedHeader" Width="150px" PlaceHolder="@PlaceHolder" ></SfTextBox>
</div>
<div style="margin-bottom: 5px">
    <label style="margin: 7px 3px 0 0"> Click the change button:</label>
    <SfButton CssClass="e-outline" OnClick="changeHeaderText">Change</SfButton>
</div>

<SfGrid @ref="Grid" ID="Grid" DataSource="@OrderData">                
    <GridColumns>
        <GridColumn Field=@nameof(OrderDetails.OrderID) HeaderText="@IdHeader" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.CustomerID) HeaderText="@CustomerHeader"  Width="140"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.Freight) HeaderText="@FreightHeader" Format="C2" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.OrderDate) HeaderText="@DateHeader" Format="d" Type="ColumnType.Date" Width="140"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public SfGrid<OrderDetails> Grid { get; set; }
    public List<OrderDetails> OrderData { get; set; }
    protected override void OnInitialized()
    {
        OrderData = OrderDetails.GetAllRecords();
    }
    public string ModifiedHeader { get; set; } = "";
    public string IdHeader { get; set; } = "Order ID";
    public string CustomerHeader { get; set; } = "Customer ID";
    public string FreightHeader { get; set; } = "Freight";
    public string DateHeader { get; set; } = "Order Date";
    public string PlaceHolder { get; set; } = "Enter new header text";
    public string DropDownValue { get; set; } = "OrderID";    
    public class Columns
    {
        public string ID { get; set; }
        public string Value { get; set; }
    }    
    List<Columns> DropDownData = new List<Columns>    {
        new Columns() { ID= "OrderID", Value= "OrderID" },
        new Columns() { ID= "CustomerID", Value= "CustomerID" },
        new Columns() { ID= "Freight", Value= "Freight" },
        new Columns() { ID= "OrderDate", Value= "OrderDate" },
    };
    
    public async Task changeHeaderText()
    {
        var selectedColumn = await Grid.GetColumnByFieldAsync(DropDownValue); 
        switch (selectedColumn.Field)
        {
            case "OrderID":
                IdHeader = ModifiedHeader;
                break;
            case "CustomerID":
                CustomerHeader = ModifiedHeader;
                break;
            case "Freight":
                FreightHeader = ModifiedHeader;
                break;
            case "OrderDate":
                DateHeader = ModifiedHeader;
                break;
        }        
        await Grid.RefreshHeaderAsync();
    }
}
{% endhighlight %}
{% highlight c# tabtitle="OrderDetails.cs" %}
public class OrderDetails
{
    public static List<OrderDetails> order = new List<OrderDetails>();
    public OrderDetails(int OrderID, string CustomerId, int EmployeeId, double Freight, DateTime OrderDate)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerId;
        this.EmployeeID = EmployeeId;
        this.Freight = Freight;
        this.OrderDate = OrderDate;
    }
    public static List<OrderDetails> GetAllRecords()
    {
        if (order.Count == 0)
        {
            order.Add(new OrderDetails(10248, "VINET",  5,  32.38, new DateTime(1996, 7, 4)));
            order.Add(new OrderDetails(10249, "TOMSP",  6,  11.61, new DateTime(1996, 7, 5)));
            order.Add(new OrderDetails(10250, "HANAR",  4,  65.83,new DateTime(1996, 7, 8)));
            order.Add(new OrderDetails(10251, "VICTE",  3, 41.34, new DateTime(1996, 7, 8)));
            order.Add(new OrderDetails(10252, "SUPRD",  4, 51.3, new DateTime(1996, 7, 9)));
            order.Add(new OrderDetails(10253, "HANAR",  3,  58.17, new DateTime(1996, 7, 10)));
            order.Add(new OrderDetails(10254, "CHOPS",  5,  22.98, new DateTime(1996, 7, 11)));
            order.Add(new OrderDetails(10255, "RICSU",  9,  148.33,  new DateTime(1996, 7, 12)));
            order.Add(new OrderDetails(10256, "WELLI",  3,  13.97, new DateTime(1996, 7, 15)));
            order.Add(new OrderDetails(10257, "HILAA",  4,  81.91, new DateTime(1996, 7, 16)));
            order.Add(new OrderDetails(10258, "ERNSH",  1,  140.51, new DateTime(1996, 7, 17)));
            order.Add(new OrderDetails(10259, "CENTC",  4, 3.25, new DateTime(1996, 7, 18)));
            order.Add(new OrderDetails(10260, "OTTIK",  4, 55.09, new DateTime(1996, 7, 19)));
            order.Add(new OrderDetails(10261, "QUEDE",  4, 3.05, new DateTime(1996, 7, 19)));
            order.Add(new OrderDetails(10262, "RATTC", 8, 48.29, new DateTime(1996, 7, 22)));
        }
        return order;
    }
    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public int EmployeeID { get; set; }
    public double Freight { get; set; }
    public DateTime OrderDate { get; set; }    
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LthfsiLOBGoUXutu?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

**Changing the header text of all columns**

If you want to change the header text of all columns in the grid, you can loop through the Columns collection of the grid and set the [HeaderText](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_HeaderText) property for each column. Here is an example:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons

<div style="margin-bottom: 5px">
    <SfButton CssClass="e-outline" OnClick="ChangeHeaderText">Change Header Text</SfButton>
</div>

<SfGrid @ref="Grid" ID="Grid" DataSource="@OrderData">                
    <GridColumns>
        <GridColumn Field="OrderID" HeaderText="@IdHeader" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="90"></GridColumn>
        <GridColumn Field="CustomerID" HeaderText="@CustomerHeader" Width="120"></GridColumn>
        <GridColumn Field="Freight" HeaderText="@FreightHeader" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Format="C2" Width="90"></GridColumn>
        <GridColumn Field="ShipCity" HeaderText="@CityHeader" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public SfGrid<OrderDetails> Grid { get; set; }
    public List<OrderDetails> OrderData { get; set; }
    protected override void OnInitialized()
    {
        OrderData = OrderDetails.GetAllRecords();
    }
    public string IdHeader { get; set; } = "OrderID";
    public string CustomerHeader { get; set; } = "CustomerID";
    public string FreightHeader { get; set; } = "Freight";
    public string CityHeader { get; set; } = "ShipCity";
    
    public void ChangeHeaderText()
    {
        IdHeader = "Order ID";
        CustomerHeader = "Customer Name";
        FreightHeader = "Freight Charge";
        CityHeader = "Ship To City";
        Grid.RefreshHeaderAsync(); 
    }
}
{% endhighlight %}
{% highlight c# tabtitle="OrderDetails.cs" %}
public class OrderDetails
{
    public static List<OrderDetails> order = new List<OrderDetails>();
    public OrderDetails(int OrderID, string CustomerId, int EmployeeId, double Freight, string Shipcity)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerId;
        this.EmployeeID = EmployeeId;
        this.Freight = Freight;
        this.ShipCity = Shipcity;
    }
    public static List<OrderDetails> GetAllRecords()
    {
        if (order.Count == 0)
        {
            order.Add(new OrderDetails(10248, "VINET", 5, 32.38, "Reims"));
            order.Add(new OrderDetails(10249, "TOMSP", 6, 11.61, "Münster"));
            order.Add(new OrderDetails(10250, "HANAR", 4, 65.83, "Rio de Janeiro"));
            order.Add(new OrderDetails(10251, "VICTE", 3, 41.34, "Lyon"));
            order.Add(new OrderDetails(10252, "SUPRD", 4, 51.3, "Charleroi"));
            order.Add(new OrderDetails(10253, "HANAR", 3, 58.17, "Rio de Janeiro"));
            order.Add(new OrderDetails(10254, "CHOPS", 5, 22.98, "Bern"));
            order.Add(new OrderDetails(10255, "RICSU", 9, 148.33, "Genève"));
            order.Add(new OrderDetails(10256, "WELLI", 3, 13.97, "Resende"));
            order.Add(new OrderDetails(10257, "HILAA", 4, 81.91, "San Cristóbal"));
            order.Add(new OrderDetails(10258, "ERNSH", 1, 140.51, "Graz"));
            order.Add(new OrderDetails(10259, "CENTC", 4, 3.25, "México D.F."));
            order.Add(new OrderDetails(10260, "OTTIK", 4, 55.09, "Köln"));
            order.Add(new OrderDetails(10261, "QUEDE", 4, 3.05, "Rio de Janeiro"));
            order.Add(new OrderDetails(10262, "RATTC", 8, 48.29, "Albuquerque"));
        }
        return order;
    }
    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public int EmployeeID { get; set; }
    public double Freight { get; set; }
    public string ShipCity { get; set; }    
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BtVfCVDLUYQXoZkN?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Change the orientation of header text

By default, the text in the column headers of the Syncfusion DataGrid control is oriented horizontally. However, in some cases, you may want to change the orientation of the header text to vertical, diagonal, or at a custom angle. This can be achieved by adding a custom CSS class to the column header cell using the [CustomAttributes](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_CustomAttributes) property of the [GridColumn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html).

Follow the below steps to change the orientation of the header text in DataGrid:

**Step 1**: **Create a CSS class with orientation style for grid header cell**

To `rotate` the header text, you can create a CSS class with the `transform` property that rotates the header text 90 degrees. This class will be added to the header cell using the `CustomAttributes` property.

```css
 .e-grid .e-columnheader .e-headercell.orientation .e-headercelldiv { 
        transform: rotate(90deg);  // Rotate a particular headertext  
    }
```

**Step 2**: **Add the custom CSS class to the datagrid column**

Once you have created the CSS class, you can add it to the particular column by using the `CustomAttributes` property. This property allows you to add any custom  attribute to the GridColumn.

For example, to add the orientation class to the CustomerID column, you can use the following code:

```cshtml
    <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" TextAlign="TextAlign.Center" CustomAttributes="@(new Dictionary<string, object>(){ { "class", "orientation" }})" Width="150"></GridColumn>
```

**Step 3**: **Resize the header cell height**

After adding the custom CSS class to a column, you need to resize the header cell height so that the rotated header text is fully visible. You can do this by using the following code:

```cshtml
function setHeaderHeight(args) {
    var textWidth = document.querySelector(".orientation > div").scrollWidth; // Obtain the width of the headerText content.
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
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" CustomAttributes="@(new Dictionary<string, object>(){ { "class", "orientation" }})" TextAlign="TextAlign.Center" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" TextAlign="TextAlign.Center" Width="130"></GridColumn>
    </GridColumns>
</SfGrid>
<style>
    .e-grid .e-columnheader .e-headercell.orientation .e-headercelldiv {
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

## Custom tooltip for header

Custom tooltips for headers provide additional information when hovering over a column header in the Syncfusion DataGrid. This can be useful in situations where there is not enough space to display all of the information related to a column, or when there is additional context that may be helpful.

To enable custom tooltips for headers in the Grid, you can use the [HeaderTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_HeaderTemplate) feature by rendering the [SfTooltip](https://blazor.syncfusion.com/documentation/tooltip/getting-started) components within the template.

Here's an example of how to use the `HeaderTemplate` to add a custom tooltip to a header cell:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
    
<SfGrid ID="Grid" DataSource="@OrderData" AllowPaging="true">            
    <GridColumns>
        <GridColumn Field=@nameof(OrderDetails.OrderID) HeaderText="Order ID"  Width="100">
            <HeaderTemplate>
                <SfTooltip Content="@GetTooltipContent("Order ID")" Position="Position.BottomCenter">
                    <span><b>Order ID</b></span>
                </SfTooltip>
            </HeaderTemplate>
        </GridColumn>
        <GridColumn Field=@nameof(OrderDetails.CustomerID) HeaderText="Customer ID" Width="100">
            <HeaderTemplate>
                <SfTooltip Content="@GetTooltipContent("Customer ID")" Position="Position.BottomCenter">
                    <span><b>Customer ID</b></span>
                </SfTooltip>
            </HeaderTemplate>
        </GridColumn>
        <GridColumn Field=@nameof(OrderDetails.OrderDate) HeaderText="Order Date" Format="d" Type="Syncfusion.Blazor.Grids.ColumnType.Date" Width="160">
            <HeaderTemplate>
                <SfTooltip Content="@GetTooltipContent("Order Date")"  Position="Position.BottomCenter">
                    <span><b>Order Date</b></span>
                </SfTooltip>
            </HeaderTemplate>
        </GridColumn>
        <GridColumn Field=@nameof(OrderDetails.Freight) HeaderText="Freight" Format="C2"  Width="150">
            <HeaderTemplate>
                <SfTooltip Content="@GetTooltipContent("Freight")" Position="Position.BottomCenter">
                    <span><b>Freight</b></span>
                </SfTooltip>
            </HeaderTemplate>
        </GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShippedDate) HeaderText="Shipped Date" Format="d" Type="Syncfusion.Blazor.Grids.ColumnType.Date" Width="160">
            <HeaderTemplate>
                <SfTooltip Content="@GetTooltipContent("Shipped Date")" Position="Position.BottomCenter">
                    <span><b>Shipped Date</b></span>
                </SfTooltip>
            </HeaderTemplate>
        </GridColumn>
    </GridColumns>
</SfGrid>   

@code {
    public SfGrid<OrderDetails> Grid { get; set; }

    public List<OrderDetails> OrderData { get; set; }
    protected override void OnInitialized()
    {
        OrderData = OrderDetails.GetAllRecords();
    }
    // Dictionary for column descriptions
    public Dictionary<string, string> ColumnDescriptions = new()
    {
        { "Order ID", "Order ID: A unique number assigned to each order." },
        { "Customer ID", "Customer ID: The ID of the customer placing the order." },
        { "Order Date", "Order Date: The date when the order was placed." },
        { "Freight", "Freight: The cost of shipping the order." },
        { "Shipped Date", "Shipped Date: The date when the order was shipped." }
    };

    // Method to get tooltip content dynamically based on HeaderText
    public string GetTooltipContent(string headerText)
    {
        return ColumnDescriptions.ContainsKey(headerText) ? ColumnDescriptions[headerText] : "No description available.";
    }
}
{% endhighlight %}
{% highlight c# tabtitle="OrderDetails.cs" %}
public class OrderDetails
{
    public static List<OrderDetails> order = new List<OrderDetails>();
    public OrderDetails(int OrderID, string CustomerId, int EmployeeId, double Freight, DateTime OrderDate, DateTime shippeddate)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerId;
        this.EmployeeID = EmployeeId;
        this.Freight = Freight;
        this.OrderDate = OrderDate;
        this.ShippedDate = shippeddate; 

    }
    public static List<OrderDetails> GetAllRecords()
    {
        if (order.Count == 0)
        {
            order.Add(new OrderDetails(10248, "VINET",  5,  32.38, new DateTime(1996, 7, 4), new DateTime(1996, 7, 16)));
            order.Add(new OrderDetails(10249, "TOMSP",  6,  11.61, new DateTime(1996, 7, 5), new DateTime(1996, 7, 10)));
            order.Add(new OrderDetails(10250, "HANAR",  4,  65.83,new DateTime(1996, 7, 8), new DateTime(1996, 7, 12)));
            order.Add(new OrderDetails(10251, "VICTE",  3, 41.34, new DateTime(1996, 7, 8), new DateTime(1996, 7, 15)));
            order.Add(new OrderDetails(10252, "SUPRD",  4, 51.3, new DateTime(1996, 7, 9), new DateTime(1996, 7, 11)));
            order.Add(new OrderDetails(10253, "HANAR",  3,  58.17, new DateTime(1996, 7, 10), new DateTime(1996, 7, 16)));
            order.Add(new OrderDetails(10254, "CHOPS",  5,  22.98, new DateTime(1996, 7, 11), new DateTime(1996, 7, 23)));
            order.Add(new OrderDetails(10255, "RICSU",  9,  148.33,  new DateTime(1996, 7, 12), new DateTime(1996, 7, 24)));
            order.Add(new OrderDetails(10256, "WELLI",  3,  13.97, new DateTime(1996, 7, 15), new DateTime(1996, 7, 25)));
            order.Add(new OrderDetails(10257, "HILAA",  4,  81.91, new DateTime(1996, 7, 16), new DateTime(1996, 7, 30)));
            order.Add(new OrderDetails(10258, "ERNSH",  1,  140.51, new DateTime(1996, 7, 17), new DateTime(1996, 7, 29)));
            order.Add(new OrderDetails(10259, "CENTC",  4, 3.25, new DateTime(1996, 7, 18), new DateTime(1996, 7, 31)));
            order.Add(new OrderDetails(10260, "OTTIK",  4, 55.09, new DateTime(1996, 7, 19), new DateTime(1996, 8, 1)));
            order.Add(new OrderDetails(10261, "QUEDE",  4, 3.05, new DateTime(1996, 7, 19), new DateTime(1996, 8, 2)));
            order.Add(new OrderDetails(10262, "RATTC", 8, 48.29, new DateTime(1996, 7, 22), new DateTime(1996, 8, 5)));
        }
        return order;
    }
    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public int EmployeeID { get; set; }
    public double Freight { get; set; }
    public DateTime OrderDate { get; set; }
    public DateTime ShippedDate { get; set; }     
}    
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VjhTCWVShlavzQwS?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

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

### Using event

To customize the appearance of the grid header, you can handle the [HeaderCellInfo](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_HeaderCellInfo) event of the grid. This event is triggered when each header cell is rendered in the grid, and provides an object that contains information about the header cell. You can use this object to modify the styles of the header column.

The following example demonstrates how to add a `HeaderCellInfo` event handler to the grid. In the event handler, checked whether the current header column is **Order Date** field and then applied the appropriate CSS class to the cell based on its value.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@OrderData" AllowPaging="true">
    <GridEvents TValue="OrderDetails" HeaderCellInfo="HeaderCell"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(OrderDetails.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.CustomerID) HeaderText="Customer ID"  Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.OrderDate) HeaderText="Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="160"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShippedDate) HeaderText="Shipped Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="160"></GridColumn>
    </GridColumns>
</SfGrid>
<style>
    .e-grid .e-headercell.customcss {
      background-color: rgb(43, 205, 226);
      color: black;
    }
</style>
@code {
    public SfGrid<OrderDetails> Grid { get; set; }

    public List<OrderDetails> OrderData { get; set; }
    protected override void OnInitialized()
    {
        OrderData = OrderDetails.GetAllRecords();
    }
    public void HeaderCell(HeaderCellInfoEventArgs args)
    {
        if (args.Column.Field == "OrderDate")
        {
        args.Cell.AddClass(new string[] { "customcss" });
        }
    }
}
{% endhighlight %}
{% highlight c# tabtitle="OrderDetails.cs" %}
public class OrderDetails
{
    public static List<OrderDetails> order = new List<OrderDetails>();
    public OrderDetails(int OrderID, string CustomerId, int EmployeeId, double Freight, DateTime OrderDate, DateTime shippeddate)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerId;
        this.EmployeeID = EmployeeId;
        this.Freight = Freight;
        this.OrderDate = OrderDate;
        this.ShippedDate = shippeddate; 

    }
    public static List<OrderDetails> GetAllRecords()
    {
        if (order.Count == 0)
        {
            order.Add(new OrderDetails(10248, "VINET",  5,  32.38, new DateTime(1996, 7, 4), new DateTime(1996, 7, 16)));
            order.Add(new OrderDetails(10249, "TOMSP",  6,  11.61, new DateTime(1996, 7, 5), new DateTime(1996, 7, 10)));
            order.Add(new OrderDetails(10250, "HANAR",  4,  65.83,new DateTime(1996, 7, 8), new DateTime(1996, 7, 12)));
            order.Add(new OrderDetails(10251, "VICTE",  3, 41.34, new DateTime(1996, 7, 8), new DateTime(1996, 7, 15)));
            order.Add(new OrderDetails(10252, "SUPRD",  4, 51.3, new DateTime(1996, 7, 9), new DateTime(1996, 7, 11)));
            order.Add(new OrderDetails(10253, "HANAR",  3,  58.17, new DateTime(1996, 7, 10), new DateTime(1996, 7, 16)));
            order.Add(new OrderDetails(10254, "CHOPS",  5,  22.98, new DateTime(1996, 7, 11), new DateTime(1996, 7, 23)));
            order.Add(new OrderDetails(10255, "RICSU",  9,  148.33,  new DateTime(1996, 7, 12), new DateTime(1996, 7, 24)));
            order.Add(new OrderDetails(10256, "WELLI",  3,  13.97, new DateTime(1996, 7, 15), new DateTime(1996, 7, 25)));
            order.Add(new OrderDetails(10257, "HILAA",  4,  81.91, new DateTime(1996, 7, 16), new DateTime(1996, 7, 30)));
            order.Add(new OrderDetails(10258, "ERNSH",  1,  140.51, new DateTime(1996, 7, 17), new DateTime(1996, 7, 29)));
            order.Add(new OrderDetails(10259, "CENTC",  4, 3.25, new DateTime(1996, 7, 18), new DateTime(1996, 7, 31)));
            order.Add(new OrderDetails(10260, "OTTIK",  4, 55.09, new DateTime(1996, 7, 19), new DateTime(1996, 8, 1)));
            order.Add(new OrderDetails(10261, "QUEDE",  4, 3.05, new DateTime(1996, 7, 19), new DateTime(1996, 8, 2)));
            order.Add(new OrderDetails(10262, "RATTC", 8, 48.29, new DateTime(1996, 7, 22), new DateTime(1996, 8, 5)));
        }
        return order;
    }
    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public int EmployeeID { get; set; }
    public double Freight { get; set; }
    public DateTime OrderDate { get; set; }
    public DateTime ShippedDate { get; set; }     
} 
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BjLfsMWkTIsIyEuk?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## How to refresh header 

The refresh header feature in the Syncfusion Blazor DataGrid allows you to update the header section of the grid whenever changes are made to the grid's columns. This feature is useful when you want to reflect changes in the header immediately, such as modifying the column header text, width, or alignment.

To use the refresh header feature, you can call the [RefreshHeaderAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_RefreshHeaderAsync) method of the DataGrid component. This method updates the grid header with the latest changes made to the columns.

The following example demonstrates how to use the `RefreshHeaderAsync` method to update the grid header:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons

<div style="margin-bottom:5px">
    <SfButton OnClick="refreshHeader">Refresh Header</SfButton>
</div>
<SfGrid @ref="Grid" ID="Grid" DataSource="@OrderData">                
    <GridColumns>
        <GridColumn Field=@nameof(OrderDetails.OrderID) HeaderText="Order ID" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.CustomerID) HeaderText="@CustomerHeaderText"  Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.OrderDate) HeaderText="Order Date" Format="d" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.Freight) HeaderText="Freight" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public SfGrid<OrderDetails> Grid { get; set; }

    public List<OrderDetails> OrderData { get; set; }
    protected override void OnInitialized()
    {
        OrderData = OrderDetails.GetAllRecords();
    }
    public string CustomerHeaderText = "CustomerID";
    public void refreshHeader()
    {
        CustomerHeaderText= "New Header Text";        
        Grid.RefreshHeaderAsync();
    }   
}
{% endhighlight %}
{% highlight c# tabtitle="OrderDetails.cs" %}
public class OrderDetails
{
    public static List<OrderDetails> order = new List<OrderDetails>();
    public OrderDetails(int OrderID, string CustomerId, int EmployeeId, double Freight, DateTime OrderDate)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerId;
        this.EmployeeID = EmployeeId;
        this.Freight = Freight;
        this.OrderDate = OrderDate;
    }
    public static List<OrderDetails> GetAllRecords()
    {
        if (order.Count == 0)
        {
            order.Add(new OrderDetails(10248, "VINET",  5,  32.38, new DateTime(1996, 7, 4)));
            order.Add(new OrderDetails(10249, "TOMSP",  6,  11.61, new DateTime(1996, 7, 5)));
            order.Add(new OrderDetails(10250, "HANAR",  4,  65.83,new DateTime(1996, 7, 8)));
            order.Add(new OrderDetails(10251, "VICTE",  3, 41.34, new DateTime(1996, 7, 8)));
            order.Add(new OrderDetails(10252, "SUPRD",  4, 51.3, new DateTime(1996, 7, 9)));
            order.Add(new OrderDetails(10253, "HANAR",  3,  58.17, new DateTime(1996, 7, 10)));
            order.Add(new OrderDetails(10254, "CHOPS",  5,  22.98, new DateTime(1996, 7, 11)));
            order.Add(new OrderDetails(10255, "RICSU",  9,  148.33,  new DateTime(1996, 7, 12)));
            order.Add(new OrderDetails(10256, "WELLI",  3,  13.97, new DateTime(1996, 7, 15)));
            order.Add(new OrderDetails(10257, "HILAA",  4,  81.91, new DateTime(1996, 7, 16)));
            order.Add(new OrderDetails(10258, "ERNSH",  1,  140.51, new DateTime(1996, 7, 17)));
            order.Add(new OrderDetails(10259, "CENTC",  4, 3.25, new DateTime(1996, 7, 18)));
            order.Add(new OrderDetails(10260, "OTTIK",  4, 55.09, new DateTime(1996, 7, 19)));
            order.Add(new OrderDetails(10261, "QUEDE",  4, 3.05, new DateTime(1996, 7, 19)));
            order.Add(new OrderDetails(10262, "RATTC", 8, 48.29, new DateTime(1996, 7, 22)));
        }
        return order;
    }
    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public int EmployeeID { get; set; }
    public double Freight { get; set; }
    public DateTime OrderDate { get; set; }    
} 
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BtBTCWruiIbAmHsM?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}