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

To further enhance the search functionality, you can integrate a search text box directly into the grid’s toolbar. This allows users to enter search criteria conveniently within the grid interface. To add the search item to the grid’s toolbar, use the  [Toolbar](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_Toolbar) property and add Search item.

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" Toolbar=@Tool>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
         <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
    </GridColumns>
</SfGrid>

@code {

    public List<Order> Orders { get; set; }
    public List<string> Tool = new List<string>() { "Search" };

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
            {
                OrderID = 1000 + x,
                CustomerID = (new string[] { "VINET", "TOMSP", "HANAR", "VICTE", "SUPRD" })[new Random().Next(5)],
                Freight = 2.1 * x,
                OrderDate = DateTime.Now.AddDays(-x),
            }).ToList();
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BtrUDvVJWxsVkdgD?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

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

2.`operator`: **contains** indicates that the search should find records that contain the specified search key.

3.`key`: **Ha** is the initial search key that will be applied when the grid is rendered.

4.`IgnoreCase`: **true** makes the search case-insensitive.

5.`IgnoreAccent`: **true** will ignores diacritic characters or accents during the search operation.
```cshtml
@using Syncfusion.Blazor.Grids
    
<SfGrid DataSource="@Orders" Toolbar=@Tool>
    <GridSearchSettings Fields=@InitSearch Operator=Syncfusion.Blazor.Operator.Contains Key="Ha" IgnoreCase="true"></GridSearchSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn> 
    </GridColumns>
</SfGrid>

@code {
    public List<Order> Orders { get; set; }
    public List<string> Tool = new List<string>() { "Search" };
    public string[] InitSearch = new string[] { "CustomerID" };

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
            {
                OrderID = 1000 + x,
                CustomerID = (new string[] { "VINET", "TOMSP", "HANAR", "VICTE", "SUPRD" })[new Random().Next(5)],
                Freight = 2.1 * x,
                OrderDate = DateTime.Now.AddDays(-x),
            }).ToList();
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/rNLUXlVpivoCqYQK?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

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

```cshtml
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.DropDowns

<label>Change the search operators: </label>
<SfDropDownList Width="100px" TValue="string" TItem="ddlOrder" DataSource="@LocalData">
    <DropDownListFieldSettings Value="Text" Text="Text"></DropDownListFieldSettings>
    <DropDownListEvents TValue="string" TItem="ddlOrder" ValueChange="OnValueChange"></DropDownListEvents>
</SfDropDownList>

<SfGrid @ref="Grid" DataSource="@Orders" Toolbar=@Tool>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    private SfGrid<Order> Grid;
    public List<Order> Orders { get; set; }
    public List<string> Tool = new List<string>() { "Search" };

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
            {
                OrderID = 1000 + x,
                CustomerID = (new string[] { "VINET", "TOMSP", "HANAR", "VICTE", "SUPRD" })[new Random().Next(5)],
                Freight = 2.1 * x,
                OrderDate = DateTime.Now.AddDays(-x),
            }).ToList();
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }
    public class ddlOrder
    {
        public string Text { get; set; }
        public string Value { get; set; }
    }
    List<ddlOrder> LocalData = new List<ddlOrder>
    {
        new ddlOrder(){Text="StartsWith",Value="StartsWith"},
        new ddlOrder(){Text="EndsWith",Value="EndsWith"},
        new ddlOrder(){Text="Contains",Value="Contains"},
        new ddlOrder(){Text="Equal",Value="Equal"},
    };
    public void OnValueChange(ChangeEventArgs<string, ddlOrder> args)
    {
        if (args.Value == "StartsWith")
        {
            this.Grid.SearchSettings.Operator = Operator.StartsWith;
        }
        else if (args.Value == "EndsWith")
        {
            this.Grid.SearchSettings.Operator = Operator.EndsWith;
        }
        else if(args.Value=="Contains")
        {
            this.Grid.SearchSettings.Operator = Operator.Contains;
        }
        else
        {
            this.Grid.SearchSettings.Operator = Operator.Equal;
        }
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LDLANateWmdQMmro?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Search by external button

The Syncfusion Blazor Grid component allows you to perform searches programmatically, enabling you to search for records using an external button instead of relying solely on the built-in search bar. This feature provides flexibility and allows for custom search implementations within your application. To search for records using an external button, you can utilize the [SearchAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_SearchAsync_System_String_) method provided by the Grid component.

The ```SearchAsync``` method allows you to perform a search operation based on a search key or criteria. The following example demonstatres how to implement ```SearchAsync``` by an external button using the following steps:

1. Add a Syncfusion Blazor Button element outside of the grid component.

2. Attach a OnClick event handler to the button.

3. Inside the event handler, get the reference of the grid component.

4. Invoke the ```SearchAsync``` method of the grid by passing the search key as a parameter.

```cshtml
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Inputs


<SfTextBox @ref="TextBox" Placeholder="Search" Width="200px" ></SfTextBox>
<SfButton Content="Search" OnClick="SearchBtnHandler"></SfButton>

<SfGrid @ref="DefaultGrid" DataSource="@Orders" AllowSorting="true" Toolbar=@Tool>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer ID" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipCity) HeaderText="Ship City" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipName) HeaderText="Ship Name" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    SfTextBox TextBox;
    private SfGrid<Order> DefaultGrid;

    public List<Order> Orders { get; set; }

    public List<string> Tool = new List<string>() { "Search" };

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
            {
                OrderID = 1000 + x,
                CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
                ShipCity = (new string[] { "Reims", "Münster", "Rio de Janeiro", "Lyon", "Charleroi" })[new Random().Next(5)],
                ShipName = (new string[] { "Vins et alcools Chevali", "Toms Spezialitäten", "Hanari Carnes", "Victuailles en stock", "Suprêmes délices" })[new Random().Next(5)],
            }).ToList();
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public string ShipCity { get; set; }
        public string ShipName { get; set; }
    }

    public void SearchBtnHandler()
    {
        var data = TextBox.Value;
        this.DefaultGrid.SearchAsync(data);
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/htLgNuZIrXJaXVsM?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Search specific columns

By default, the search functionality searches all visible columns. However, if you want to search only specific columns, you can define the specific column’s field names in the [GridSearchSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSearchSettings.html).[Fields](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSearchSettings.html#Syncfusion_Blazor_Grids_GridSearchSettings_Fields)  property. This allows you to narrow down the search to a targeted set of columns, which is particularly useful when dealing with large datasets or grids with numerous columns.

The following example demonstrates how to search specific columns such as **CustomerID** and **ShipCity** by using the `SearchSettings.Fields` property.

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" Toolbar=@Tool>
    <GridSearchSettings Fields=@SpecificCols></GridSearchSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer ID" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipCity) HeaderText="Ship City" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<Order> Orders { get; set; }
    public List<string> Tool = new List<string>() { "Search" };
    public string[] SpecificCols = new string[] { "CustomerID", "ShipCity" };

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
            {
                OrderID = 1000 + x,
                CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
                Freight = 2.1 * x,
                ShipCity = (new string[] { "Reims", "Münster", "Rio de Janeiro", "Lyon", "Charleroi" })[new Random().Next(5)]
            }).ToList();
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
        public string ShipCity { get; set; }
    }
}
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/rDLgZbBThxJDmjCd?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Search on each key stroke

The search on each keystroke feature in Syncfusion Grid enables you to perform real-time searching of grid data as they type in the search text box. This functionality provides a seamless and interactive searching experience, allowing you to see the search results dynamically updating in real time as they enter each keystroke in the search box.

By default, the datagrid will initiate searching operation after the Enter key is pressed. If you want to initiate the searching operation while typing the values in the search box, then you can invoke the [SearchAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_SearchAsync_System_String_) method of the datagrid in the [Input](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfTextBox.html#Syncfusion_Blazor_Inputs_SfTextBox_Input) event of the [SfTextBox](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfTextBox.html#Syncfusion_Blazor_Inputs_SfTextBox__ctor).

```cshtml
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
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="@TextAlign.Center" Width="140"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.EmployeeID) HeaderText="Employee ID" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipCity) HeaderText="Ship City" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipCountry) HeaderText="Ship Country" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipName) HeaderText="Ship Name" Width="150"></GridColumn>   
   </GridColumns>
</SfGrid>

@code {
    private SfGrid<Order> DefaultGrid;

    public List<Order> Orders { get; set; }

    public void OnInput(InputEventArgs args)
    {
        this.DefaultGrid.SearchAsync(args.Value);
    }

    public class Order
    {
        public int OrderID { get; set; }
        public string CustomerID { get; set; }
        public string EmployeeID { get; set; }
        public string ShipCity { get; set; }
        public string ShipCountry { get; set; }
        public string ShipName { get; set; }
    }

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
            {
                OrderID = 1000 + x,
                CustomerID = (new string[] { "VINET", "TOMSP", "HANAR", "VICTE", "SUPRD" })[new Random().Next(5)],
                EmployeeID = (new string[] { "5", "6", "3", "4", "1" })[new Random().Next(5)],       
                ShipCity = (new string[] { "Reims", "Münster", "Rio de Janeiro", "Lyon", "Charleroi" })[new Random().Next(5)],
                ShipCountry = (new string[] { "France", "Germany", "Brazil", "Belgium", "Switzerland" })[new Random().Next(5)],
                ShipName = (new string[] { "Vins et alcools Chevali", "Toms Spezialitäten", "Hanari Carnes", "Victuailles en stock", "Suprêmes délices" })[new Random().Next(5)],
            }).ToList();
    }
}
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/BDrgXFLzhbsDRpHF?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}


## Perform search operation in Grid using multiple keywords

In addition to searching with a single keyword, the Grid component offers the capability to perform a search operation using multiple keywords. This feature enables you to narrow down your search results by simultaneously matching multiple keywords. It can be particularly useful when you need to find records that meet multiple search conditions simultaneously.

The following example demonstrates, how to perform a search with multiple keywords in the grid by using the ```query``` property .

```cshtml
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Inputs
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Data

<SfTextBox Input="OnInput"></SfTextBox>

<SfRadioButton TChecked="bool" ValueChange="DariRadioButton" Label="Lucas"></SfRadioButton>

<SfGrid @ref="DefaultGrid" DataSource="@Orders" Query="@SearchQuery">
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.Paid) Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    public Query SearchQuery { get; set; }
    public List<Order> Orders { get; set; }
    SfGrid<Order> DefaultGrid;
    public string val = "ANANTR";
    WhereFilter ColPre = new WhereFilter();
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
        ColPre = WhereFilter.Or(Predicate);
        SearchQuery = new Query().Where(ColPre);
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

        ColPre = WhereFilter.And(Predicate);
        SearchQuery = new Query().Where(ColPre);
    }
    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
        {
            OrderID = 1000 + x,
            CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
            Paid = (new string[] { "Lunas", "Dibayarkan" })[new Random().Next(2)],
            Freight = 2.1 * x,
            OrderDate = (new DateTime[] { new DateTime(2010, 5, 1), new DateTime(2010, 5, 2), new DateTime(2010, 5, 3), })[new Random().Next(3)]
        }).ToList();
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string Paid { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/rjLqtvDkIGdYRHQb?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Disable search for particular column

By default, DataGrid searches all visible columns. You can disable searching for a particular column by setting the [AllowSearching](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_AllowSearching) property of **GridColumn** as false.

In the below code example, the **Order ID** column search functionality is disabled.

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" Toolbar="@(new List<string>() { "Search" })">
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" AllowSearching="false" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
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
            Freight = 2.1 * x,
            OrderDate = DateTime.Now.AddDays(-x),
        }).ToList();
    }

    public class Order {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }
}
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/LNLKjnrLLLzpTgOm?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> You can refer to our [Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) feature tour page for its groundbreaking feature representations. You can also explore our [Blazor DataGrid example](https://blazor.syncfusion.com/demos/datagrid/overview?theme=bootstrap4) to understand how to present and manipulate data.


## Clear search by external button

The Syncfusion Grid component provides a capability to clear searched data in the grid. This functionality offers the ability to reset or clear any active search filters that have been applied to the grid’s data.

To clear the searched grid records from an external button, you can set the [SearchSettings.Key](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_SearchSettings) property to an empty string to clear the search text.This property represents the current search text in the search box.

The following example demonstrates how to clear the searched records using an external button.

```cshtml
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Grids

<SfButton Content="ClearSearch" OnClick="clearSearchBtnHandler"></SfButton>
<SfGrid @ref="DefaultGrid" DataSource="@Orders" AllowSorting="true" Toolbar=@Tool>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer ID" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipCity) HeaderText="Ship City" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipName) HeaderText="Ship Name" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    private SfGrid<Order> DefaultGrid;
    public List<string> Tool = new List<string>() { "Search" };

    public List<Order> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
            {
                OrderID = 1000 + x,
                CustomerID = (new string[] { "VINET", "TOMSP", "HANAR", "VICTE", "SUPRD" })[new Random().Next(5)],
                ShipCity = (new string[] { "Reims", "Münster", "Rio de Janeiro", "Lyon", "Charleroi" })[new Random().Next(5)],
                ShipName = (new string[] { "Vins et alcools Chevali", "Toms Spezialitäten", "Hanari Carnes", "Victuailles en stock", "Suprêmes délices" })[new Random().Next(5)],
            }).ToList();
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public string ShipCity { get; set; }
        public string ShipName { get; set; }
    }

    public void clearSearchBtnHandler()
    {
        this.DefaultGrid.SearchSettings.Key = "";
        DefaultGrid.Refresh();
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/hXVqDFrpgzbtiXsl?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> You can also clear the searched records by using the clear icon within the search input field.
