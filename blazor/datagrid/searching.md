---
layout: post
title: Searching in Blazor DataGrid | Syncfusion
description: Learn search options in Syncfusion Blazor DataGrid including toolbar, initial, external search, operators, multi-keyword, and accent-insensitive support.
platform: Blazor
control: DataGrid
documentation: ug
---

# Searching in Blazor DataGrid

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid includes a powerful built-in searching feature that enables efficient filtering of DataGrid records based on search criteria. This feature allows quick discovery of specific data within large datasets. Whether the application works with small or large datasets, the search feature provides a seamless solution for locating relevant records instantly.

## Enable searching

To provide a search box in the UI, add the Search item to the toolbar using the [Toolbar](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_Toolbar) property. Searching can also be performed programmatically using [SearchAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_SearchAsync_System_String_) method. The [AllowSearching](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_AllowSearching) property is column-level and is used to include or exclude specific columns from search; it is not required to enable global search.  


The following example demonstrates enabling the `Toolbar` with search option in the DataGrid:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

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

> The clear icon appears in the search text box when it has focus or after entering a character. Clicking the clear icon removes the text from the search box and resets the DataGrid to display all records.

## Initial search

By default, the search operation is performed after the DataGrid renders. However, scenarios may require applying a search automatically when the DataGrid first loads. The initial search feature enables this by setting search criteria before the DataGrid displays its data.

To apply search at initial rendering, configure the following properties in the [GridSearchSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSearchSettings.html).

| Property     | Description                                                                                                                                                                                                         |
|--------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Fields       | Specifies the [Fields](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSearchSettings.html#Syncfusion_Blazor_Grids_GridSearchSettings_Fields) that participate in the search. By default, the DataGrid searches all columns. Set this property to limit the search to specific columns. |                     |
| Operator     | Specifies the [Operator](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSearchSettings.html#Syncfusion_Blazor_Grids_GridSearchSettings_Operator) used for comparison. Available Options include `Startswith`, `Endswith`, `Contains`, `Equal`, and others. The default value is `Contains`.                            |
| `Key`          | Specifies the [Key](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSearchSettings.html#Syncfusion_Blazor_Grids_GridSearchSettings_Key). The DataGrid filters records matching this value based on the specified operator.                                                                                                                                                                                   |
| IgnoreCase   | [IgnoreCase](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSearchSettings.html#Syncfusion_Blazor_Grids_GridSearchSettings_IgnoreCase) sets case-insensitive search when true. For example, searching "john" finds "John", "JOHN", and "john".                   |
| IgnoreAccent | [IgnoreAccent](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSearchSettings.html#Syncfusion_Blazor_Grids_GridSearchSettings_IgnoreAccent) ignores diacritic characters during search when true. For example, “café” matches “cafe”. |

The following example demonstrates configuring initial search by setting these properties.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

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

> By default, the DataGrid searches all visible columns. Customize this by setting the `Fields` property of `GridSearchSettings` to limit searching to specific columns only.

## Search operators

Search operators are symbols or keywords used to define the type of comparison or condition applied during a search operation. They specify the way the search key is compared with the column data. Different operators enable different types of matching logic. The [GridSearchSettings.Operator](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSearchSettings.html#Syncfusion_Blazor_Grids_GridSearchSettings_Operator) property configures which operator the DataGrid uses.

By default, the `GridSearchSettings.Operator` is set to `Contains`, which returns records containing the search key anywhere in the specified columns. The following operators are available.

| Operator | Description | Example |
|----------|-------------|---------|
| **StartsWith** | Matches records that begin with the search key | Searching "John" finds "Johnson" and "Johnathan", but not "St. John". |
| **EndsWith** | Matches records that end with the search key | Searching "son" finds "Johnson" and "Allison", but not "Sunshine". |
| **Contains** | Matches records containing the search key anywhere | Searching "son" finds "Johnson", "Sunshine", and "Allison". |
| **WildCard** | Uses wildcards (* symbol) for pattern matching | Searching "J*n" finds "John", "Jen", "Jargon". |
 **Equal** | Matches records exactly equal to the search key | Searching "John" finds only cells containing exactly "John". |
| **NotEqual** | Matches records that DO NOT equal the search key | Searching "John" finds all records except those with exactly "John". |

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.DropDowns

<label>Change the search operators: </label>
<SfDropDownList Width="100px" TValue="Operator" TItem="DropDownOrder" Value="@SearchOperator" DataSource="@DropDownData">
    <DropDownListFieldSettings Value="Value" Text="Text"></DropDownListFieldSettings>
    <DropDownListEvents TValue="Operator" TItem="DropDownOrder" ValueChange="OnValueChange"></DropDownListEvents>
</SfDropDownList>

<SfGrid DataSource="@Orders" Toolbar=@ToolbarItems>
    <GridSearchSettings Operator="@SearchOperator"></GridSearchSettings>
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/VDrnNUrxUzwNiCNf?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Search using an external button

The DataGrid provides the [SearchAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_SearchAsync_System_String_) method, which enables programmatic searching. This allows implementing custom search interfaces outside the DataGrid's toolbar, such as using a dedicated search button or external search box.

Implementation steps for searching via an external button:

1. Add a [SfTextBox](https://blazor.syncfusion.com/documentation/textbox/getting-started-webapp) and a [SfButton](https://blazor.syncfusion.com/documentation/button/getting-started-with-web-app) element outside the DataGrid.
2. Attach a [OnClick](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfButton.html#Syncfusion_Blazor_Buttons_SfButton_OnClick) event handler to the button.
3. Enter the text to search in the DataGrid.
4. In the event handler, get the entered text from the `SfTextBox`.
5. Call the DataGrid's `SearchAsync` method, passing the text as a parameter.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Inputs
@using Syncfusion.Blazor.Buttons

<SfTextBox @ref="TextBox" Placeholder="Search" Width="200px"></SfTextBox>
<SfButton Content="Search" OnClick="search"></SfButton>

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
    public void search()
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

By default, the search functionality searches across all visible columns. However, scenarios may require searching only specific columns. The [GridSearchSettings.Fields](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSearchSettings.html#Syncfusion_Blazor_Grids_GridSearchSettings_Fields) property enables limiting the search scope to targeted columns.

This approach is useful when:
- Applications work with large DataGrids containing many columns (reduces processing time).
- Search should focus on key columns (like "Customer ID" or "Freight") rather than all columns.
- Displaying search results for specific fields improves relevance.

The following example searches only the "CustomerID" and "ShipCity" columns.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

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

## Perform real-time search while typing

The real-time search feature enables searching as each keystroke is entered into the search box. This provides immediate, dynamic search results without requiring pressing <kbd>Enter</kbd> or clicking a button.

 By default, search is executed on Enter. To trigger search as the user types, render an [SfTextBox](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfTextBox.html#Syncfusion_Blazor_Inputs_SfTextBox__ctor) in the toolbar template and call [SearchAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_SearchAsync_System_String_) in the TextBox [Input](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfTextBox.html#Syncfusion_Blazor_Inputs_SfTextBox_Input) event.

In the following example, the `Input` event of the SfTextBox calls the DataGrid's `SearchAsync` method with the new text. This produces real-time filtering as typing happens.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Inputs
@using Syncfusion.Blazor.Navigations

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

> Real-time search on keystroke may impact performance when the application works with large datasets (thousands of rows). Consider implementing a delayed search trigger or using initial search combined with external buttons for better performance with large data.

## Disable search for particular column

By default, the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid searches across all visible columns. To exclude a column, set the column’s [AllowSearching](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_AllowSearching) property to false.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" Toolbar=@ToolbarItems>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" AllowSearching="false" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipName) HeaderText="ShipName" Width="150"></GridColumn>
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

N> For a broader overview, see the [Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) feature tour and the [Blazor DataGrid example](https://blazor.syncfusion.com/demos/datagrid/overview?theme=bootstrap5).

## Ignore accents and diacritics while searching

By default, the DataGrid’s search does not treat accented and unaccented characters as equivalent. To support accent-insensitive search, set [GridSearchSettings.IgnoreAccent](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSearchSettings.html#Syncfusion_Blazor_Grids_GridSearchSettings_IgnoreAccent) property to `true`. This improves usability when data contains diacritic characters.

This feature is useful when:
- Applications work with international data containing accented characters (é, ñ, ü, etc.).
- Input searches may not include accents even though data contains them.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid @ref="Grid" DataSource="@GridData" Toolbar="@(new List<string>() { "Search" })">
    <GridSearchSettings IgnoreAccent="true"></GridSearchSettings>
    <GridColumns>
        <GridColumn Field=@nameof(InventorDetails.Inventor) IsPrimaryKey="true" HeaderText="Inventor Name" Width="180"></GridColumn>
        <GridColumn Field=@nameof(InventorDetails.PatentFamilies) HeaderText="Number of Patent Families" TextAlign="TextAlign.Right" Width="195"></GridColumn>
        <GridColumn Field=@nameof(InventorDetails.Country) HeaderText="Country" Width="120"></GridColumn>
        <GridColumn Field=@nameof(InventorDetails.MainFields) HeaderText="Main Fields of Invention" Width="130"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    private SfGrid<InventorDetails> Grid;
    public List<InventorDetails> GridData { get; set; }
    protected override void OnInitialized()
    {
        GridData = InventorDetails.GetAllRecords();
    }   
}
{% endhighlight %}

{% highlight c# tabtitle="InventorDetails.cs" %}

public class InventorDetails
{
    public static List<InventorDetails> Inventors = new List<InventorDetails>();
    public InventorDetails()
    {

    }
    public InventorDetails(string Inventor,int? PatentFamilies,string NumberofINPADOCpatents,string Country,string MainFields)
    {
      this.Inventor= Inventor;
      this.PatentFamilies= PatentFamilies;
      this.NumberofINPADOCpatents= NumberofINPADOCpatents;
      this.Country= Country;
      this.MainFields= MainFields;
    }
    public static List<InventorDetails> GetAllRecords()
    {
        if (Inventors.Count() == 0)
        {
            int code = 10;
            for (int i = 1; i < 2; i++)
            {
                Inventors.Add(new InventorDetails("Łukasz Kowalski", 4737, "9839", "Australia", "Printing, Digital paper, Internet, Electronics,Lab-on-a-chip, MEMS, Mechanical, VLSI"));
                Inventors.Add(new InventorDetails("João Pereira", 4677, "10000+", "Japan", "Various"));
                Inventors.Add(new InventorDetails("Štěpán Novák",13197, "1332", "Canada", "Printing, Digital paper, Internet, Electronics, CGI, VLSI"));
                Inventors.Add(new InventorDetails("Guðrún Jónsdóttir", 1255, "3099", "India", "Automotive, Stainless steel products"));
                Inventors.Add(new InventorDetails("Zsófia Tóth", 1240, "2038", "USA", "Gaming machines"));
                Inventors.Add(new InventorDetails("Márcio Silveira", 1240, "4126", "Canada", "Printing, Digital paper, Internet, Electronics, CGI, VLSI"));
                Inventors.Add(new InventorDetails("René González", 1093, "3360", "USA", "Automotive, Stainless steel products"));
                Inventors.Add(new InventorDetails("Émile Durand", 993, "1398", "Japan", "Various"));
                Inventors.Add(new InventorDetails("José Martínez", 949,"NA", "India", "Printing, Digital paper, Internet, Electronics, CGI, VLSI"));                  
                code += 5;
            }
        }
        return Inventors;
    }
    public string Inventor { get; set; }
    public int? PatentFamilies { get; set; }
    public string NumberofINPADOCpatents { get; set; }
    public string Country { get; set; }
    public string MainFields { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LNrItRCfhblhPJaR?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> * The `IgnoreAccent` property can be combined with other search settings such as `Fields`, `Operator`, `IgnoreCase` to customize search behavior.
> * This feature applies only to non-ASCII characters (characters with diacritical marks).
> * Enabling accent-ignoring may have a slight performance impact on very large datasets.

## Search using multiple keywords

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid supports searching with multiple keywords simultaneously. This enables narrowing search results by matching multiple conditions at once. For example, finding records where CustomerID contains "A" AND Paid contains "Lunas".

Build compound predicates with the DataGrid's [Query](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_Query) property and Syncfusion Data query helpers (**WhereFilter**, **And/Or**) to combine conditions. 

In the following example, the search uses WhereFilter to combine conditions.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Inputs
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Data

<SfTextBox Input="OnInput"></SfTextBox>
<SfRadioButton TChecked="bool" ValueChange="OnRadioButtonChecked" Label="Lucas"></SfRadioButton>

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

    public void OnRadioButtonChecked(ChangeArgs<bool> pilihan)
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

## Clear search results using an external button

The DataGrid provides the capability to clear search results and reset the DataGrid to display all records. This is useful for resetting search filters when a "Clear" or "Reset" button is clicked.

To reset search results from an external button, call [SearchAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_SearchAsync_System_String_) with an empty string. This clears the search text and removes the applied search.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Grids

<SfButton Content="ClearSearch" OnClick="clearSearch"></SfButton>
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
    public async Task clearSearch()
    {
        await DefaultGrid.SearchAsync("");
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/BZVzjpXoqkaJnBKx?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> Alternatively, the search box's built-in clear icon also clears search results. When the search box has focus or contains text, clicking the clear icon removes the text and resets the DataGrid to display all records.