---
layout: post
title: Column Header in Blazor DataGrid Component | Syncfusion
description: Learn how to customize column headers in Syncfusion Blazor DataGrid, including text, templates, alignment, styles, tooltips, and orientation.
platform: Blazor
control: DataGrid
documentation: ug
---

# Headers in Blazor DataGrid

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid provides options to customize and manage headers for better data organization and presentation. 

**Key properties for header customization:**

* **HeaderText** – Displays custom text in the column header instead of the default field name.
* **HeaderTemplate** – Renders custom HTML or Blazor components in the header cell.
* **HeaderTextAlign** – Aligns header text horizontally using **Left**, **Center**, **Right**, or **Justify**.
* **Stacked Headers** – Groups multiple columns under a single header for better organization.
* **Auto-Wrap Header Text** – Wraps header text when it exceeds column width using `AllowTextWrap` and `TextWrapSettings.WrapMode`.
* **Header Height** – Customizes header height using CSS.
* **Dynamic Header Text** – Updates header text at runtime using event or methods.
* **Orientation** – Changes header text orientation (vertical, diagonal, or custom angle) using CSS and `CustomAttributes`.
* **Tooltip for Header** – Adds custom tooltips to header cells using `HeaderTemplate` and `SfTooltip`.
* **Customize Header Text Style** – Applies styles such as font, color, and background using CSS, `CustomAttributes`, or `HeaderCellInfo` event.

## Header text

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid displays the header text of a column from its [Field](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Field) value by default.

To override this and provide a custom header title, define the [HeaderText](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_HeaderText) property in the [GridColumn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html).

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

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


>* The `HeaderText` property is optional. If it is not defined, the column’s `Field` value is used as the header text.
>* To apply custom HTML content to the header cell, use the [HeaderTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_HeaderTemplate) property of the `GridColumn`.

## Header template

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid allows customizing the header element of a column using the [HeaderTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_HeaderTemplate) property of the [GridColumn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html). This property enables rendering custom HTML elements or Blazor components in the header cell, allowing additional functionality such as icons, dropdowns, or switches.

{% youtube
"youtube:https://www.youtube.com/watch?v=9YF9HnFY5Ew"%}

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.DropDowns

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

>* The `HeaderTemplate` property is applicable only to columns that have a header element.
> * Any HTML or Blazor component can be used in the header template to add additional functionality.

## Stacked header 

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid allows grouping multiple levels of column headers by stacking columns. This feature organizes columns in a structured way and improves readability. 

To achieve this, nest the [GridColumn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn) directive within another `GridColumn` directive. Use the [HeaderText](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_HeaderText) property for each sub-header column to set its text.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.DropDowns

<SfGrid DataSource="@Orders">
    <GridColumns>
        <GridColumn Field=@nameof(OrderDetails.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" IsPrimaryKey="true" Width="120">
            <HeaderTemplate>
                <a href="#">Order ID</a>
            </HeaderTemplate>
        </GridColumn>
        <GridColumn HeaderText="Order Details" TextAlign="TextAlign.Center">
            <HeaderTemplate>
                <div @onclick:stopPropagation>
                    <SfDropDownList TValue="string" TItem="Columns" DataSource="@DropDownData" @bind-Value="@DropDownValue" Width="160px">
                        <DropDownListFieldSettings Value="ID" Text="Value"></DropDownListFieldSettings>
                    </SfDropDownList>
                </div>
            </HeaderTemplate>
            <ChildContent>
            <GridColumns>
                <GridColumn Field="OrderDate" Width="130" HeaderText="Order Date" Format="d" TextAlign="TextAlign.Right" MinWidth="10"></GridColumn>
                <GridColumn Field="Freight" HeaderText="Freight ($)" Width="135" Format="C2" TextAlign="TextAlign.Right" MinWidth="10">
                </GridColumn>
            </GridColumns>
            </ChildContent>
        </GridColumn>
        <GridColumn HeaderText="Ship Details" TextAlign="TextAlign.Center">
            <ChildContent>
                <GridColumns>
                    <GridColumn Field="ShippedDate" Width="140" HeaderText="Shipped Date" Format="d" TextAlign="TextAlign.Right" MinWidth="10"></GridColumn>
                    <GridColumn Field="ShipCountry" Width="140" HeaderText="Ship Country" Format="d" TextAlign="TextAlign.Right" MinWidth="10"></GridColumn>
                </GridColumns>
            </ChildContent>
            <HeaderTemplate>
                Ship Details <span>(<svg xmlns="http://www.w3.org/2000/svg" height="10" width="12.5" viewBox="0 0 640 512"><path d="M48 0C21.5 0 0 21.5 0 48L0 368c0 26.5 21.5 48 48 48l16 0c0 53 43 96 96 96s96-43 96-96l128 0c0 53 43 96 96 96s96-43 96-96l32 0c17.7 0 32-14.3 32-32s-14.3-32-32-32l0-64 0-32 0-18.7c0-17-6.7-33.3-18.7-45.3L512 114.7c-12-12-28.3-18.7-45.3-18.7L416 96l0-48c0-26.5-21.5-48-48-48L48 0zM416 160l50.7 0L544 237.3l0 18.7-128 0 0-96zM112 416a48 48 0 1 1 96 0 48 48 0 1 1 -96 0zm368-48a48 48 0 1 1 0 96 48 48 0 1 1 0-96z"/></svg>)</span>
            </HeaderTemplate>           
        </GridColumn>
    </GridColumns>
</SfGrid>
@code {
    public List<OrderDetails> Orders { get; set; }          
    protected override void OnInitialized()
    {
        Orders = OrderDetails.GetAllRecords();
    }   
    public string DropDownValue { get; set; } = "Order Details";
    
    public class Columns
    {
        public string ID { get; set; }
        public string Value { get; set; }
    }    
    List<Columns> DropDownData = new List<Columns>    {
        new Columns() { ID= "Order Details", Value= "Order Details" },
        new Columns() { ID= "Order Information", Value= "Order Information" },
    };
}
{% endhighlight %}
{% highlight c# tabtitle="OrderDetails.cs" %}
public class OrderDetails
{
    public static List<OrderDetails> order = new List<OrderDetails>();
    public OrderDetails(int OrderID, string Shipcountry, double Freight, DateTime OrderDate, DateTime shippeddate)
    {
        this.OrderID = OrderID;
        this.ShipCountry = Shipcountry;
        this.Freight = Freight;
        this.OrderDate = OrderDate;
        this.ShippedDate = shippeddate; 

    }
    public static List<OrderDetails> GetAllRecords()
    {
        if (order.Count == 0)
        {
            order.Add(new OrderDetails(10248, "France", 32.38, new DateTime(1996, 7, 4), new DateTime(1996, 7, 16)));
            order.Add(new OrderDetails(10249, "Germany", 11.61, new DateTime(1996, 7, 5), new DateTime(1996, 7, 10)));
            order.Add(new OrderDetails(10250, "Brazil", 65.83,new DateTime(1996, 7, 8), new DateTime(1996, 7, 12)));
            order.Add(new OrderDetails(10251, "France", 41.34, new DateTime(1996, 7, 8), new DateTime(1996, 7, 15)));
            order.Add(new OrderDetails(10252, "Belgium", 51.3, new DateTime(1996, 7, 9), new DateTime(1996, 7, 11)));
            order.Add(new OrderDetails(10253, "Brazil", 58.17, new DateTime(1996, 7, 10), new DateTime(1996, 7, 16)));
            order.Add(new OrderDetails(10254, "Switzerland", 22.98, new DateTime(1996, 7, 11), new DateTime(1996, 7, 23)));
            order.Add(new OrderDetails(10255, "Switzerland", 148.33,  new DateTime(1996, 7, 12), new DateTime(1996, 7, 24)));
            order.Add(new OrderDetails(10256, "Brazil", 13.97, new DateTime(1996, 7, 15), new DateTime(1996, 7, 25)));
            order.Add(new OrderDetails(10257, "Venezuela", 81.91, new DateTime(1996, 7, 16), new DateTime(1996, 7, 30)));
            order.Add(new OrderDetails(10258, "Austria", 140.51, new DateTime(1996, 7, 17), new DateTime(1996, 7, 29)));
            order.Add(new OrderDetails(10259, "Mexico", 3.25, new DateTime(1996, 7, 18), new DateTime(1996, 7, 31)));
            order.Add(new OrderDetails(10260, "Germany", 55.09, new DateTime(1996, 7, 19), new DateTime(1996, 8, 1)));
            order.Add(new OrderDetails(10261, "Brazil", 3.05, new DateTime(1996, 7, 19), new DateTime(1996, 8, 2)));
            order.Add(new OrderDetails(10262, "USA", 48.29, new DateTime(1996, 7, 22), new DateTime(1996, 8, 5)));
        }
        return order;
    }
    public int OrderID { get; set; }
    public string ShipCountry { get; set; }
    public double Freight { get; set; }
    public DateTime OrderDate { get; set; }
    public DateTime ShippedDate { get; set; }     
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LNhJMLtKrNbNTfwi?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Header text alignment

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid allows horizontally aligning the text in column headers using the [HeaderTextAlign](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_HeaderTextAlign)  property of the [GridColumn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html). By default, the text is aligned to the **left**. 

The alignment can be changed by setting `HeaderTextAlign` to one of the following options:

* **Left**: Aligns the text to the left (default).
* **Center**: Aligns the text to the center.
* **Right**: Aligns the text to the right.
* **Justify**: Justifies the header text.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

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

>* The `HeaderTextAlign` property only changes the alignment of the text in the column header, not the content of the column. To align both the header and the column content, use the [TextAlign](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_TextAlign) property.

> * The `HeaderTextAlign` property can also be used with stacked headers. It aligns the header text in sub-headers as well.

## Autowrap the header text

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid supports wrapping header text when it exceeds the column width.

Enable this feature by setting the [AllowTextWrap](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowTextWrap) property to **true**. Configure the wrap mode using the [TextWrapSettings.WrapMode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_TextWrapSettings) property.

Specify appropriate column widths using the [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Width) property to ensure proper wrapping.

Wrap modes determine whether header text, content, or both are wrapped:

* **Both**: Wraps both header text and content (default).
* **Header**: Wraps only header text.
* **Content**: Wraps only content.

> * If column width is not specified, wrapping adjusts based on the grid’s width.
> * Header text without white space does not wrap.
> * For cells containing HTML tags, use [HeaderTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_HeaderTemplate) and [Template](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Template) properties for customization.

The following example demonstrates how to dynamically change the auto-wrap of the header text based on DropDown change:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.DropDowns

<div style="margin-bottom:10px">
<label> Autowrap for header column: </label>
<SfDropDownList TValue="WrapMode" TItem="DropDownOrder" DataSource="@DropDownData" @bind-Value="@DropDownValue" Width="120px">
    <DropDownListFieldSettings Text="Text" Value="Value"></DropDownListFieldSettings>
    <DropDownListEvents ValueChange="OnChange" TValue="WrapMode" TItem="DropDownOrder"></DropDownListEvents>
</SfDropDownList>
</div>
<SfGrid @ref="Grid" DataSource="@Orders" GridLines="GridLine.Default" AllowTextWrap="true" Height="315">
    <GridTextWrapSettings WrapMode="@WrapModeValue"></GridTextWrapSettings>
    <GridColumns>
        <GridColumn Field=@nameof(InventoryData.Inventor) HeaderText="Inventor Name" Width="70"></GridColumn>
        <GridColumn Field=@nameof(InventoryData.NumberofPatentFamilies) HeaderText="Number of Patent Families" Width="80"></GridColumn>
        <GridColumn Field=@nameof(InventoryData.Country) HeaderText="Country" Width="100"></GridColumn>
        <GridColumn Field=@nameof(InventoryData.Mainfieldsofinvention) HeaderText="Main Fields Of Invention" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public SfGrid<InventoryData> Grid { get; set; }
    public List<InventoryData> Orders { get; set; }
    protected override void OnInitialized()
    {
        Orders = InventoryData.GetAllRecords();
    }
    public WrapMode WrapModeValue = WrapMode.Header;
    public WrapMode DropDownValue = WrapMode.Header;
    public class DropDownOrder
    {
        public string Text { get; set; }
        public WrapMode Value { get; set; }
    }
    List<DropDownOrder> DropDownData = new List<DropDownOrder>
    {
        new DropDownOrder() { Text = "Both", Value = WrapMode.Both },
        new DropDownOrder() { Text = "Header", Value = WrapMode.Header},
    };
    public async Task OnChange(ChangeEventArgs<WrapMode, DropDownOrder> Args)
    {        
        WrapModeValue = Args.Value;
        await Grid.Refresh();        
    }  
}
{% endhighlight %}
{% highlight c# tabtitle="InventoryData.cs" %}
public class InventoryData
{
    public static List<InventoryData> Orders = new List<InventoryData>();

    public InventoryData(string inventor, int? patentFamilies, string country, string mainFields)
    {
        this.Inventor = inventor;
        this.NumberofPatentFamilies = patentFamilies;
        this.Country = country;
        this.Mainfieldsofinvention = mainFields;
    }

    public static List<InventoryData> GetAllRecords()
    {
        if (Orders.Count == 0)
        {
            Orders.Add(new InventoryData("Kia Silverbrook", 4737, "Australia", "Printing, Digital paper, Internet, Electronics, Lab-on-a-chip, MEMS, Mechanical, VLSI"));
            Orders.Add(new InventoryData("Shunpei Yamazaki", 4677, "Japan", "Thin film transistors, Liquid crystal displays, Solar cells, Flash memory, OLED"));
            Orders.Add(new InventoryData("Lowell L. Wood, Jr.", 1419, "USA", "Mosquito laser, Nuclear weapons"));
            Orders.Add(new InventoryData("Paul Lapstun", 1281, "Australia", "Printing, Digital paper, Internet, Electronics, CGI, VLSI"));
            Orders.Add(new InventoryData("Gurtej Sandhu", 1255, "India", "Thin film processes and materials, VLSI, Semiconductor device fabrication"));
            Orders.Add(new InventoryData("Jun Koyama", 1240, "Japan", "Thin film transistors, Liquid crystal displays, OLED"));
            Orders.Add(new InventoryData("Roderick A. Hyde", 1240, "USA", "Various"));
            Orders.Add(new InventoryData("Leonard Forbes", 1093, "Canada", "Semiconductor Memories, CCDs, Thin film processes and materials, VLSI"));
            Orders.Add(new InventoryData("Thomas Edison", 1084, "USA", "Electric power, Lighting, Batteries, Phonograph, Cement, Telegraphy, Mining"));
            Orders.Add(new InventoryData("Donald E. Weder", 999, "USA", "Florist supplies"));
            Orders.Add(new InventoryData("George Albert Lyon", 993, "Canada", "Automotive, Stainless steel products"));
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/hXVJMVDAgevobXAA?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Change the height of header

Changing the header height is useful when the default size is not sufficient to display the header content. Headers with lengthy text or images require additional height to ensure proper display. This can be achieved by applying CSS or adjusting the height dynamically using methods.

**Using css**

Override the default height of the **.e-grid .e-headercell** class to set a custom header height:

```css
.e-grid .e-headercell {
  height: 130px;
}
```

## Change header text dynamically

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid allows modifying the header text of a column in real time. This can be achieved in two ways:

* **Using event**: The [HeaderCellInfo](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_HeaderCellInfo) event triggers for each header cell during rendering. It provides access to the header cell element, allowing customization of the header text dynamically.
* **Using methods**: The Grid includes methods such as [GetColumnByFieldAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_GetColumnByFieldAsync_System_String_) and [GetColumnByUidAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_GetColumnByUidAsync_System_String_) to retrieve column objects and update their [HeaderText](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_HeaderText) property. After updating, call [RefreshHeaderAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_RefreshHeaderAsync) to apply changes.

> * When the header text is changed dynamically, the Grid does not update automatically. Call the `RefreshHeaderAsync` method to refresh the Grid and apply the updated header text.

### Using Event

The [HeaderCellInfo](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_HeaderCellInfo) event is triggered for each header cell during rendering. This event can be used to customize the header text dynamically.

**Event Arguments**

The event uses the [HeaderCellInfoEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.HeaderCellInfoEventArgs.html) class, which includes:

| Property | Type   | Description                                  |
|----------|--------|---------------------------------------------|
| cell     | object | Represents the header cell being modified. |
| node     | object | Represents the DOM element of the header cell.|


After updating the header text, call the `RefreshHeaderAsync` method to apply changes.

### Using method

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid provides methods to change the header text dynamically. These methods allow retrieving column objects and updating their [HeaderText](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_HeaderText) property. After updating, call the `RefreshHeaderAsync` method to apply changes.

**Get Column by Field**

The [GetColumnByFieldAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_GetColumnByFieldAsync_System_String_) method is used to retrieve a column object based on its field name. After retrieving the column, modify the `HeaderText` property of the column object and refresh the header.


| Parameter  | Type   | Description                                                  |
|------------|--------|--------------------------------------------------------------|
| fieldName  | string | Specifies the field name of the column to update header text.|

**Get Column by Uid**

The [GetColumnByUidAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_GetColumnByUidAsync_System_String_) method is used to retrieve a column object based on its unique identifier. After retrieving the column, update its `HeaderText` property and refresh the header.


| Parameter | Type   | Description                                                  |
|-----------|--------|--------------------------------------------------------------|
| uid       | string | Specifies the unique identifier of the column to update header text.|

> * The unique identifier is automatically generated by the Grid and changes whenever the Grid is refreshed or updated.

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

To change the header text of all columns in the Grid, loop through the Columns collection and set the [HeaderText](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_HeaderText) property for each column. When the header text is changed dynamically, call the `RefreshHeaderAsync` method to refresh the Grid and reflect the updated headers.

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

By default, the text in the column headers of the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid is displayed **horizontally**. To change the orientation to **vertical**, **diagonal**, or a **custom angle**, apply a custom CSS class to the header cell using the [CustomAttributes](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_CustomAttributes) property of [GridColumn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html).

**Steps to change header text orientation:**

**1. Create a CSS class with rotation style**

Define a CSS class using the **transform** property to rotate the header text:

```css
 .e-grid .e-columnheader .e-headercell.orientation .e-headercelldiv { 
        transform: rotate(90deg);  // Rotate a particular headertext  
    }
```

**2. Apply the CSS class to the column**

Use the `CustomAttributes` property to add the class to the desired column:

```cshtml
<GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" TextAlign="TextAlign.Center"
            CustomAttributes="@(new Dictionary<string, object>(){ { "class", "orientation" }})" Width="150">
</GridColumn>
```

**3. Adjust header cell height**

Ensure the rotated text is visible by resizing the header cell height:

```cshtml
function setHeaderHeight(args) {
    var textWidth = document.querySelector(".orientation > div").scrollWidth; // Obtain the width of the headerText content.
    var header = document.querySelectorAll(".e-columnheader");
    for (var i = 0; i < header.length; i++) {
        (header.item(i)).style.height = textWidth + 'px'; // Assign the obtained textWidth as the height of the column header.
    }
}
```

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
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

Custom tooltips for headers provide additional information when hovering over a column header in the Grid. This is useful when there is limited space to display details or when extra context is required.

To add custom tooltips for headers, use the [HeaderTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_HeaderTemplate) property and render the [SfTooltip](https://blazor.syncfusion.com/documentation/tooltip/getting-started) component inside the template.

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

{% previewsample "https://blazorplayground.syncfusion.com/embed/LtrJirtAJDjvaNlx?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Customize header text styles 

Customizing the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid header styles allows modifying the appearance of column headers to match design requirements. Styles such as **font**, **background color**, and **text color** can be applied using the following approaches:

* **Using CSS** - Apply styles globally or to specific columns by defining CSS rules.

* **Using property** - Assign a custom CSS class to individual columns using the [CustomAttributes](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_CustomAttributes) property of [GridColumn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html).

* **Using event** - Handle the [HeaderCellInfo](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_HeaderCellInfo) event to apply styles dynamically when header cells are rendered.

### Using CSS

Apply styles to header cells by defining CSS rules. The **.e-headercell** class targets all header cells and can be used to change properties like **background color** and **text color**.

```CSS
  .e-grid .e-headercell {
    background-color: #a2d6f4;
    color:rgb(3, 2, 2);
  }
```

To style a specific column header, assign a custom class to that column and define styles for that class in CSS.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

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

The [CustomAttributes](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_CustomAttributes) property of [GridColumn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html) allows assigning a custom CSS class to specific column headers for styling. This approach is useful for applying unique styles without affecting other headers.

**Step 1:** Define a CSS class with the desired styles for the header cell.

```CSS
.e-grid .e-headercell.customcss {
    background-color: rgb(43, 205, 226);
    color: black;
}

```

**Step 2:** Assign the CSS class to the column using the `CustomAttributes` property.

```cshtml
<GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name"
            CustomAttributes="@(new Dictionary<string, object>(){ { "class", "customcss" }})"
            Width="150">
</GridColumn>
```

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders">
    <GridColumns>
        <GridColumn Field=@nameof(OrderDetails.OrderID) HeaderText="Order ID" CustomAttributes="@(new Dictionary<string, object>(){ { "class", "customcss" }})" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.OrderDate) HeaderText="Order Date" CustomAttributes="@(new Dictionary<string, object>(){ { "class", "customcss" }})" Format="d" Type="ColumnType.Date" Width="130"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShippedDate) HeaderText="Shipped Date" Format="d" Type="ColumnType.Date" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>
<style>
    .e-grid .e-headercell.customcss {
        background-color: rgb(43, 205, 226);
        color: black;
    }
</style>
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
    public OrderDetails(int OrderID, string CustomerId, DateTime OrderDate, DateTime shippeddate)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerId;
        this.OrderDate = OrderDate;
        this.ShippedDate = shippeddate; 

    }
    public static List<OrderDetails> GetAllRecords()
    {
        if (order.Count == 0)
        {
            order.Add(new OrderDetails(10248, "Paul Henriot", new DateTime(1996, 7, 4), new DateTime(1996, 7, 16)));
            order.Add(new OrderDetails(10249, "Karin Josephs", new DateTime(1996, 7, 5), new DateTime(1996, 7, 10)));
            order.Add(new OrderDetails(10250, "Mario Pontes", new DateTime(1996, 7, 8), new DateTime(1996, 7, 12)));
            order.Add(new OrderDetails(10251, "Mary Saveley", new DateTime(1996, 7, 8), new DateTime(1996, 7, 15)));
            order.Add(new OrderDetails(10252, "Pascale Cartrain", new DateTime(1996, 7, 9), new DateTime(1996, 7, 11)));
            order.Add(new OrderDetails(10253, "Mario Pontes", new DateTime(1996, 7, 10), new DateTime(1996, 7, 16)));
            order.Add(new OrderDetails(10254, "Yang Wang", new DateTime(1996, 7, 11), new DateTime(1996, 7, 23)));
            order.Add(new OrderDetails(10255, "Michael Holz", new DateTime(1996, 7, 12), new DateTime(1996, 7, 24)));
            order.Add(new OrderDetails(10256, "Paula Parente", new DateTime(1996, 7, 15), new DateTime(1996, 7, 25)));
            order.Add(new OrderDetails(10257, "Carlos Hernández", new DateTime(1996, 7, 16), new DateTime(1996, 7, 30)));
            order.Add(new OrderDetails(10258, "Roland Mendel", new DateTime(1996, 7, 17), new DateTime(1996, 7, 29)));
            order.Add(new OrderDetails(10259, "Francisco Chang", new DateTime(1996, 7, 18), new DateTime(1996, 7, 31)));
            order.Add(new OrderDetails(10260, "Henriette Pfalzheim", new DateTime(1996, 7, 19), new DateTime(1996, 8, 1)));
            order.Add(new OrderDetails(10261, "Bernardo Batista", new DateTime(1996, 7, 19), new DateTime(1996, 8, 2)));
            order.Add(new OrderDetails(10262, "Paula Wilson", new DateTime(1996, 7, 22), new DateTime(1996, 8, 5)));
        }
        return order;
    }
    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public DateTime OrderDate { get; set; }
    public DateTime ShippedDate { get; set; }     
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rNVJMVtUKbqNkJzn?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Using event

The [HeaderCellInfo](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_HeaderCellInfo) event is triggered when each header cell is rendered in the Grid. This event provides information about the header cell and allows applying custom styles dynamically based on column properties or conditions.

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

The refresh header feature updates the header section of the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid when changes are made to column properties such as header text, width, or alignment. The [RefreshHeaderAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_RefreshHeaderAsync) method of the Grid is used to apply these changes immediately.

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