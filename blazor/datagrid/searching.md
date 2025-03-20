---
layout: post
title: Searching in Blazor DataGrid Component | Syncfusion
description: Checkout and learn here all about Searching in Syncfusion Blazor DataGrid component and much more details.
platform: Blazor
control: DataGrid
documentation: ug
---

# Searching in Blazor DataGrid Component

The Syncfusion Blazor Grid includes a powerful built-in searching feature that allows users to search for specific data within the grid. This feature enables efficient filtering of grid records based on user-defined search criteria, making it easier to locate and display relevant information. Whether you have a large dataset or simply need to find specific records quickly, the search feature provides a convenient solution.

Set the  [AllowSearching](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_AllowSearching) property to true to enable the searching feature in the grid.

To further enhance the search functionality, you can integrate a search text box directly into the grid’s toolbar. This allows users to enter search criteria conveniently within the grid interface. To add the search item to the grid’s toolbar, use the  [Toolbar](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_Toolbar) property and add **Search** item.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using BlazorApp1.Data

<SfGrid DataSource="@Orders" Toolbar=@ToolbarItems>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
    </GridColumns>
</SfGrid>

@code {

    public List<OrderData> Orders { get; set; }
    public List<string> ToolbarItems = new List<string>() { "Search" };

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
        public OrderData(int? OrderID, string CustomerID, DateTime? OrderDate, double Freight)
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
                    Orders.Add(new OrderData(10248, "VINET", new DateTime(1996,04,17), 32.38));
                    Orders.Add(new OrderData(10249, "TOMSP", new DateTime(1996,05,07), 11.61));
                    Orders.Add(new OrderData(10250, "HANAR", new DateTime(1996,08,07), 65.83));
                    Orders.Add(new OrderData(10251, "VICTE", new DateTime(1996, 08, 07), 41.34));
                    Orders.Add(new OrderData(10252, "SUPRD", new DateTime(1996,09,07), 51.30));
                    Orders.Add(new OrderData(10253, "HANAR", new DateTime(1996,07,10), 58.17));
                    Orders.Add(new OrderData(10254, "CHOPS",new DateTime(1996,07,11), 22.98));
                    Orders.Add(new OrderData(10255, "RICSU", new DateTime(1996,07,12), 148.33));
                    Orders.Add(new OrderData(10256, "WELLI", new DateTime(1996,07,15), 13.97));
                    code += 5;
                }
            }
            return Orders;
        }

        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double Freight { get; set; }
    }
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hNrqMDUXsngnslOp?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> The clear icon is shown in the Data Grid search text box when it is focused on search text or after typing the single character in the search text box. A single click of the clear icon clears the text in the search box as well as the search results in the Grid.

## Initial search

By default, the search operation can be performed on the grid data after the grid renders. However, there might be scenarios where need to perform a search operation on the grid data during the initial rendering of the grid. In such cases, you can make use of the initial search feature provided by the grid.

To apply search at initial rendering, need to set the following properties in the [GridSearchSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSearchSettings.html) component.

Property|Description
-----|-----
Fields |Specifies the [Fields](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSearchSettings.html#Syncfusion_Blazor_Grids_GridSearchSettings_Fields) in which the search operation needs to be performed.
Operator |Specifies the [Operator](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSearchSettings.html#Syncfusion_Blazor_Grids_GridSearchSettings_Operator) to be used for the search operation.
Key|Specifies the key value to be searched.
IgnoreCase |[IgnoreCase](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.WhereFilter.html#Syncfusion_Blazor_Data_WhereFilter_IgnoreCase) specifies whether the search operation needs to be case-sensitive or case-insensitive
IgnoreAccent |[IgnoreAccent](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.WhereFilter.html#Syncfusion_Blazor_Data_WhereFilter_IgnoreAccent) property will ignore the diacritic characters or accents in the text during a search operation.

The following example demonstrates how to set an initial search in the grid using the `GridSearchSettings` property. The `GridSearchSettings` property is set with the following values:

1.`Field`: **CustomerID** specifies that the search should be performed only in the ‘CustomerID’ field.

2.`Operator`: **contains** indicates that the search should find records that contain the specified search key.

3.`Key`: **Ha** is the initial search key that will be applied when the grid is rendered.

4.`IgnoreCase`: **true** makes the search case-insensitive.

5.`IgnoreAccent`: **true** will ignores diacritic characters or accents during the search operation.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using BlazorApp1.Data

<SfGrid DataSource="@Orders" Toolbar=@ToolbarItems>
    <GridSearchSettings Fields=@InitSearch Operator=Syncfusion.Blazor.Operator.Contains Key="Ha" IgnoreCase="true"></GridSearchSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<OrderData> Orders { get; set; }
    public List<string> ToolbarItems = new List<string>() { "Search" };
    public string[] InitSearch = new string[] { "CustomerID" };

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
        public OrderData(int? OrderID, string CustomerID, DateTime? OrderDate, double Freight)
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
                    Orders.Add(new OrderData(10248, "VINET", new DateTime(1996,04,17), 32.38));
                    Orders.Add(new OrderData(10249, "TOMSP", new DateTime(1996,05,07), 11.61));
                    Orders.Add(new OrderData(10250, "HANAR", new DateTime(1996,08,07), 65.83));
                    Orders.Add(new OrderData(10251, "VICTE", new DateTime(1996, 08, 07), 41.34));
                    Orders.Add(new OrderData(10252, "SUPRD", new DateTime(1996,09,07), 51.30));
                    Orders.Add(new OrderData(10253, "HANAR", new DateTime(1996,07,10), 58.17));
                    Orders.Add(new OrderData(10254, "CHOPS",new DateTime(1996,07,11), 22.98));
                    Orders.Add(new OrderData(10255, "RICSU", new DateTime(1996,07,12), 148.33));
                    Orders.Add(new OrderData(10256, "WELLI", new DateTime(1996,07,15), 13.97));
                    code += 5;
                }
            }
            return Orders;
        }

        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double Freight { get; set; }
    }
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rNVKWZUXimSvcekD?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> By default, datagrid searches all the bound column values. To customize this behavior, define the `Fields` property of **GridSearchSettings** component.

## Search operators

Search operators are symbols or keywords used to define the type of comparison or condition applied during a search operation. They help specify how the search key should match the data being searched. The [GridSearchSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSearchSettings.html).[Operator](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSearchSettings.html#Syncfusion_Blazor_Grids_GridSearchSettings_Operator)  property can be used to define the search operator in the grid.

By default, the `GridSearchSettings.Operator` is set to **contains**, which returns the values contains the search key. The following operators are supported in searching:

The following operators are supported in searching:

Operator |Description
-----|-----
StartsWith |Checks whether a value begins with the specified value.
EndsWith |Checks whether a value ends with the specified value.
Contains |Checks whether a value contains the specified value.
Equal |Checks whether a value is equal to the specified value.

These operators provide flexibility in defining the search behavior and allow you to perform different types of comparisons based on your requirements.

The following example demonstrates how to set the `SearchSettings.Operator` property based on changing the dropdown value using the [ValueChange](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfSwitch-1.html#Syncfusion_Blazor_Buttons_SfSwitch_1_ValueChange) event of the [DropDownList](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2__ctor) component.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.DropDowns
@using BlazorApp1.Data

<label>Change the search operators: </label>
<SfDropDownList Width="100px" TValue="Operator" TItem="DropDownOrder" Value="@SearchOperator" DataSource="@DropDownData">
    <DropDownListFieldSettings Value="Value" Text="Text"></DropDownListFieldSettings>
    <DropDownListEvents TValue="Operator" TItem="DropDownOrder" ValueChange="OnValueChange"></DropDownListEvents>
</SfDropDownList>

<SfGrid DataSource="@Orders" Toolbar=@ToolbarItems>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipName) HeaderText="Ship Name" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCountry) HeaderText="Ship Country" TextAlign="TextAlign.Right" Width="130"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<OrderData> Orders { get; set; }
    public List<string> ToolbarItems = new List<string>() { "Search" };
    public Operator SearchOperator { get; set; } = Operator.StartsWith;
    
    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
    } 
    public class DropDownOrder
    {
        public string Text { get; set; }
        public Operator Value { get; set; }
    }

    List<DropDownOrder> DropDownData = new List<DropDownOrder>
    {
        new DropDownOrder(){Text="StartsWith",Value= Operator.StartsWith },
        new DropDownOrder(){Text="EndsWith",Value=Operator.EndsWith},
        new DropDownOrder(){Text="Contains",Value=Operator.Contains},
        new DropDownOrder(){Text="Equal",Value=Operator.Equal}
    };

    public void OnValueChange(ChangeEventArgs<Operator, DropDownOrder> args)
    {
        SearchOperator = args.Value;
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
        public OrderData(int? OrderID, string CustomerID, string ShipName, string ShipCountry)
        {
            this.OrderID = OrderID;
            this.CustomerID = CustomerID;
            this.ShipName = ShipName;
            this.ShipCountry = ShipCountry;

        }

        public static List<OrderData> GetAllRecords()
        {
            if (Orders.Count() == 0)
            {
                int code = 10;
                for (int i = 1; i < 2; i++)
                {
                    Orders.Add(new OrderData(10248, "VINET", "Vins et alcools Chevalier", "France"));
                    Orders.Add(new OrderData(10249, "TOMSP", "Toms Spezialitäten", "Germany"));
                    Orders.Add(new OrderData(10250, "HANAR", "Hanari Carnes", "Brazil"));
                    Orders.Add(new OrderData(10251, "VICTE", "Victuailles en stock", "France"));
                    Orders.Add(new OrderData(10252, "SUPRD", "Suprêmes délices", "Belgium"));
                    Orders.Add(new OrderData(10253, "HANAR", "Hanari Carnes", "Brazil"));
                    Orders.Add(new OrderData(10254, "CHOPS", "Chop-suey Chines", "Switzerland"));
                    Orders.Add(new OrderData(10255, "RICSU", "Vins et alcools Chevalier", "France"));
                    Orders.Add(new OrderData(10256, "WELLI", "Richter Supermar", "Switzerland"));
                    code += 5;
                }
            }
            return Orders;
        }

        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public string ShipName { get; set; }
        public string ShipCountry { get; set; }
    }
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hZBgCXKXMPQpCngI?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Search by external button

The Syncfusion Blazor Grid component allows you to perform searches programmatically, enabling you to search for records using an external button instead of relying solely on the built-in search bar. This feature provides flexibility and allows for custom search implementations within your application. To search for records using an external button, you can utilize the [SearchAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_SearchAsync_System_String_) method provided by the Grid component.

The ```SearchAsync``` method allows you to perform a search operation based on a search key or criteria. The following example demonstatres how to implement ```SearchAsync``` by an external button using the following steps:

1. Add a Syncfusion Blazor Button element outside of the grid component.

2. Attach a OnClick event handler to the button.

3. Inside the event handler, get the reference of the grid component.

4. Invoke the ```SearchAsync``` method of the grid by passing the search key as a parameter.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Inputs
@using Syncfusion.Blazor.Buttons
@using BlazorApp1.Data

<SfTextBox @ref="TextBox" Placeholder="Search" Width="200px"></SfTextBox>
<SfButton Content="Search" OnClick="SearchBtnHandler"></SfButton>

<SfGrid DataSource="@Orders" @ref="DefaultGrid">
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipName) HeaderText="Ship Name" TextAlign="TextAlign.Right" Width="130"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    SfTextBox TextBox;
    private SfGrid<OrderData> DefaultGrid;
    public List<OrderData> Orders { get; set; }
    
    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
    } 
    public void SearchBtnHandler()
    {
        var textBoxValue = TextBox.Value;
        this.DefaultGrid.SearchAsync(textBoxValue);
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
        public OrderData(int? OrderID, string CustomerID, string ShipCity, string ShipName)
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
                    Orders.Add(new OrderData(10248, "VINET", "Reims", "Vins et alcools Chevalier"));
                    Orders.Add(new OrderData(10249, "TOMSP", "Münster", "Toms Spezialitäten"));
                    Orders.Add(new OrderData(10250, "HANAR", "Rio de Janeiro", "Hanari Carnes"));
                    Orders.Add(new OrderData(10251, "VICTE", "Lyon", "Victuailles en stock"));
                    Orders.Add(new OrderData(10252, "SUPRD", "Charleroi", "Suprêmes délices"));
                    Orders.Add(new OrderData(10253, "HANAR", "Rio de Janeiro", "Hanari Carnes"));
                    Orders.Add(new OrderData(10254, "CHOPS", "Chop-suey Chines", "Switzerland"));
                    Orders.Add(new OrderData(10255, "RICSU", "Bern", "Vins et alcools Chevalier"));
                    Orders.Add(new OrderData(10256, "WELLI", "Genève", "Richter Supermar"));
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/LZLgWjqXrthTCrNT?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Search specific columns

By default, the search functionality searches all visible columns. However, if you want to search only specific columns, you can define the specific column’s field names in the [GridSearchSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSearchSettings.html).[Fields](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSearchSettings.html#Syncfusion_Blazor_Grids_GridSearchSettings_Fields)  property. This allows you to narrow down the search to a targeted set of columns, which is particularly useful when dealing with large datasets or grids with numerous columns.

The following example demonstrates how to search specific columns such as **CustomerID** and **ShipCity** by using the `SearchSettings.Fields` property.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using BlazorApp1.Data

<SfGrid DataSource="@Orders" Toolbar=@ToolbarItems>
    <GridSearchSettings Fields=@SpecificColumns></GridSearchSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<OrderData> Orders { get; set; }
    public List<string> ToolbarItems = new List<string>() { "Search" };
    public string[] SpecificColumns = new string[] { "CustomerID", "ShipCity" };
    
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
        public OrderData(int? OrderID, string CustomerID, string ShipCity, double Freight)
        {
            this.OrderID = OrderID;
            this.CustomerID = CustomerID;
            this.ShipCity = ShipCity;
            this.Freight = Freight;

        }

        public static List<OrderData> GetAllRecords()
        {
            if (Orders.Count() == 0)
            {
                int code = 10;
                for (int i = 1; i < 2; i++)
                {
                    Orders.Add(new OrderData(10248, "VINET", "Reims", 32.38));
                    Orders.Add(new OrderData(10249, "TOMSP", "Münster", 11.61));
                    Orders.Add(new OrderData(10250, "HANAR", "Rio de Janeiro", 65.83));
                    Orders.Add(new OrderData(10251, "VICTE", "Lyon", 41.34));
                    Orders.Add(new OrderData(10252, "SUPRD", "Charleroi", 51.30));
                    Orders.Add(new OrderData(10253, "HANAR", "Rio de Janeiro", 58.17));
                    Orders.Add(new OrderData(10254, "CHOPS", "Chop-suey Chines", 22.98));
                    Orders.Add(new OrderData(10255, "RICSU", "Bern", 148.33));
                    Orders.Add(new OrderData(10256, "WELLI", "Genève", 13.97));
                    code += 5;
                }
            }
            return Orders;
        }

        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public string ShipCity { get; set; }
        public double Freight { get; set; }
    }
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BXVKMNADrifXTYHZ?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Disable search for particular column

By default, DataGrid searches all visible columns. You can disable searching for a particular column by setting the [AllowSearching](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_AllowSearching) property of **GridColumn** as false.

In the below code example, the **Order ID** column search functionality is disabled.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using BlazorApp1.Data


<SfGrid DataSource="@Orders" Toolbar=@ToolbarItems>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" AllowSearching="false" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<OrderData> Orders { get; set; }
    public List<string> ToolbarItems = new List<string>() { "Search" };
       
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
        public OrderData(int? OrderID, string CustomerID, string ShipCity, string ShipName)
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
                    Orders.Add(new OrderData(10248, "VINET", "Reims", "Vins et alcools Chevalier"));
                    Orders.Add(new OrderData(10249, "TOMSP", "Münster", "Toms Spezialitäten"));
                    Orders.Add(new OrderData(10250, "HANAR", "Rio de Janeiro", "Hanari Carnes"));
                    Orders.Add(new OrderData(10251, "VICTE", "Lyon", "Victuailles en stock"));
                    Orders.Add(new OrderData(10252, "SUPRD", "Charleroi", "Suprêmes délices"));
                    Orders.Add(new OrderData(10253, "HANAR", "Rio de Janeiro", "Hanari Carnes"));
                    Orders.Add(new OrderData(10254, "CHOPS", "Chop-suey Chines", "Switzerland"));
                    Orders.Add(new OrderData(10255, "RICSU", "Bern", "Vins et alcools Chevalier"));
                    Orders.Add(new OrderData(10256, "WELLI", "Genève", "Richter Supermar"));
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

N> You can refer to our [Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) feature tour page for its groundbreaking feature representations. You can also explore our [Blazor DataGrid example](https://blazor.syncfusion.com/demos/datagrid/overview?theme=bootstrap5) to understand how to present and manipulate data.

## Search on each key stroke

The search on each keystroke feature in Syncfusion Grid enables you to perform real-time searching of grid data as they type in the search text box. This functionality provides a seamless and interactive searching experience, allowing you to see the search results dynamically updating in real time as they enter each keystroke in the search box.

By default, the datagrid will initiate searching operation after the Enter key is pressed. If you want to initiate the searching operation while typing the values in the search box, then you can invoke the [SearchAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_SearchAsync_System_String_) method of the datagrid in the [Input](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfTextBox.html#Syncfusion_Blazor_Inputs_SfTextBox_Input) event by rendering the  [SfTextBox](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfTextBox.html#Syncfusion_Blazor_Inputs_SfTextBox__ctor) comonent as toolbar template component.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Inputs
@using Syncfusion.Blazor.Navigations
@using BlazorApp1.Data

<SfGrid @ref="DefaultGrid" DataSource="@Orders" AllowSorting="true" AllowPaging="true">
    <SfToolbar>
        <ToolbarItems>
            <ToolbarItem Type="ItemType.Input" Align="Syncfusion.Blazor.Navigations.ItemAlign.Right">
                <Template>
                    <SfTextBox Placeholder="Enter values to search" Input="OnInput"></SfTextBox>
                    <span class="e-search-icon e-icons"></span>
                </Template>
            </ToolbarItem>
        </ToolbarItems>
    </SfToolbar>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="@TextAlign.Center" Width="140"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.EmployeeID) HeaderText="Employee ID" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCountry) HeaderText="Ship Country" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipName) HeaderText="Ship Name" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>
@code {
    private SfGrid<OrderData> DefaultGrid;
    public List<OrderData> Orders { get; set; }
          
    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
    }  
    
    public void OnInput(InputEventArgs args)
    {
        this.DefaultGrid.SearchAsync(args.Value);
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
        public OrderData(int OrderID, string CustomerID, string EmployeeID, string ShipCity,string ShipCountry,string ShipName)
        {
            this.OrderID = OrderID;
            this.CustomerID = CustomerID;
            this.EmployeeID = EmployeeID;
            this.ShipCity = ShipCity;
            this.ShipCountry = ShipCountry;
            this.ShipName = ShipName;

        }

        public static List<OrderData> GetAllRecords()
        {
            if (Orders.Count() == 0)
            {
                int code = 10;
                for (int i = 1; i < 2; i++)
                {
                    Orders.Add(new OrderData(10248, "VINET", "5", "Reims", "France", "Vins et alcools Chevalier"));
                    Orders.Add(new OrderData(10249, "TOMSP","6", "Münster", "Germany", "Toms Spezialitäten"));
                    Orders.Add(new OrderData(10250, "HANAR", "4","Rio de Janeiro", "Brazil", "Wellington Importadora"));
                    Orders.Add(new OrderData(10251, "VICTE", "3","Lyon", "France", "Victuailles en stock"));
                    Orders.Add(new OrderData(10252, "SUPRD","4", "Charleroi", "Belgium", "Suprêmes délices"));
                    Orders.Add(new OrderData(10253, "HANAR","3", "Rio de Janeiro", "Brazil", "Hanari Carnes"));
                    Orders.Add(new OrderData(10254, "CHOPS", "9","Chop-suey Chines", "Switzerland", "Chop-suey Chinese"));
                    Orders.Add(new OrderData(10255, "RICSU", "5","Bern", "Switzerland", "Richter Supermarkt"));
                    Orders.Add(new OrderData(10256, "WELLI", "3","Genève", "Brazil", "Wellington Importadora"));
                    code += 5;
                }
            }
            return Orders;
        }

        public int OrderID { get; set; }
        public string CustomerID { get; set; }
        public string EmployeeID { get; set; }
        public string ShipCity { get; set; }
        public string ShipCountry { get; set; }
        public string ShipName { get; set; }
    }
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BDrgXFLzhbsDRpHF?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}


## Perform search operation in Grid using multiple keywords

In addition to searching with a single keyword, the Grid component offers the capability to perform a search operation using multiple keywords. This feature enables you to narrow down your search results by simultaneously matching multiple keywords. It can be particularly useful when you need to find records that meet multiple search conditions simultaneously.

The following example demonstrates, how to perform a search with multiple keywords in the grid by using the ```query``` property .

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Inputs
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Data
@using BlazorApp1.Data

<SfTextBox Input="OnInput"></SfTextBox>
<SfRadioButton TChecked="bool" ValueChange="DariRadioButton" Label="Lucas"></SfRadioButton>

<SfGrid @ref="DefaultGrid" DataSource="@Orders" Query="@SearchQuery">
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Paid) Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public Query SearchQuery { get; set; }
    private SfGrid<OrderData> DefaultGrid;
    public List<OrderData> Orders { get; set; }
    WhereFilter ColumnPredicate = new WhereFilter();
    List<WhereFilter> Predicate = new List<WhereFilter>();
    public void OnInput(InputEventArgs args)
    {
        Predicate = new List<WhereFilter>();
        Predicate.Add(new WhereFilter()
            {
                Field = "CustomerID",
                value = args.Value,
                Operator = "contains",
                IgnoreCase = true
            });
        ColumnPredicate = WhereFilter.Or(Predicate);
        SearchQuery = new Query().Where(ColumnPredicate);
    }

    public void DariRadioButton(ChangeArgs<bool> pilihan)
    {
        Predicate.Add(new WhereFilter()
            {
                Field = "Paid",
                value = "Lunas",
                Operator = "equal",
                IgnoreCase = true
            });

        ColumnPredicate = WhereFilter.And(Predicate);
        SearchQuery = new Query().Where(ColumnPredicate);
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
        public OrderData(int OrderID, string Paid, string CustomerID, DateTime? OrderDate, double? Freight)
        {
            this.OrderID = OrderID;
            this.Paid = Paid;
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
                    Orders.Add(new OrderData(10248, "Dibayarkan", "VINET",new DateTime(2010, 5, 1),33.1));
                    Orders.Add(new OrderData(10249, "Lunas", "TOMSP",new DateTime(2010, 5, 2),56.78));
                    Orders.Add(new OrderData(10250, "Dibayarkan", "HANAR", new DateTime(2010, 5, 3), 96.8));
                    Orders.Add(new OrderData(10251, "Lunas", "VICTE", new DateTime(2010, 5, 4), 45.76));
                    Orders.Add(new OrderData(10252, "Dibayarkan", "SUPRD",new DateTime(2010, 5, 5), 77.78));
                    Orders.Add(new OrderData(10253, "Lunas", "HANAR",new DateTime(2010, 5, 6), 5.78));
                    Orders.Add(new OrderData(10254, "Dibayarkan", "CHOPS", new DateTime(2010, 5, 7), 56.78));
                    Orders.Add(new OrderData(10255, "Lunas", "RICSU", new DateTime(2010, 5, 8), 6.79));
                    Orders.Add(new OrderData(10256, "Dibayarkan", "WELLI", new DateTime(2010, 5,9), 33.76));
                    code += 5;
                }
            }
            return Orders;
        }

        public int? OrderID { get; set; }
        public string Paid { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }   
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LtVqCDqNBkpniqXe?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Clear search by external button

The Syncfusion Grid component provides a capability to clear searched data in the grid. This functionality offers the ability to reset or clear any active search filters that have been applied to the grid’s data.

To clear the searched grid records from an external button, you can set the [SearchSettings.Key](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_SearchSettings) property to an empty string to clear the search text.This property represents the current search text in the search box.

The following example demonstrates how to clear the searched records using an external button.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Grids
@using BlazorApp1.Data

<SfButton Content="ClearSearch" OnClick="clearSearchBtnHandler"></SfButton>
<SfGrid @ref="DefaultGrid" DataSource="@Orders" AllowSorting="true" Toolbar=@ToolbarItems>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipName) HeaderText="Ship Name" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    private SfGrid<OrderData> DefaultGrid;
    public List<string> ToolbarItems = new List<string>() { "Search" };
    public List<OrderData> Orders { get; set; }
             
    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
    }  
    public void clearSearchBtnHandler()
    {
        this.DefaultGrid.SearchSettings.Key = "";
        DefaultGrid.Refresh();
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
        public OrderData(int? OrderID, string CustomerID, string ShipCity, string ShipName)
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
                    Orders.Add(new OrderData(10248, "VINET", "Reims", "Vins et alcools Chevalier"));
                    Orders.Add(new OrderData(10249, "TOMSP", "Münster", "Toms Spezialitäten"));
                    Orders.Add(new OrderData(10250, "HANAR", "Rio de Janeiro", "Hanari Carnes"));
                    Orders.Add(new OrderData(10251, "VICTE", "Lyon", "Victuailles en stock"));
                    Orders.Add(new OrderData(10252, "SUPRD", "Charleroi", "Suprêmes délices"));
                    Orders.Add(new OrderData(10253, "HANAR", "Rio de Janeiro", "Hanari Carnes"));
                    Orders.Add(new OrderData(10254, "CHOPS", "Chop-suey Chines", "Switzerland"));
                    Orders.Add(new OrderData(10255, "RICSU", "Bern", "Vins et alcools Chevalier"));
                    Orders.Add(new OrderData(10256, "WELLI", "Genève", "Richter Supermar"));
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/LjhUMXKtKjyEzLsl?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> You can also clear the searched records by using the clear icon within the search input field.


