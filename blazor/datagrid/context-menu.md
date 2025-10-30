---
layout: post
title: Context Menu in Blazor DataGrid | Syncfusion
description: Explore and understand the Context Menu in Syncfusion Blazor DataGrid. Learn about its features, usage, customization, and more.
platform: Blazor
control: DataGrid
documentation: ug
---

# Context menu in Syncfusion Blazor DataGrid

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid supports a context menu that appears when right-clicking any part of the Grid. This menu provides quick access to actions and operations related to the Grid’s data.

To enable the context menu, configure the Grid's [ContextMenuItems](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ContextMenuItemModel.html) property. Use default items for built-in menu options or add custom items for tailored functionality. This feature improves interactivity by offering context-sensitive actions.

The context menu appears when right-clicking in these Grid areas:
* **Header:** Right-click the header for column-specific actions.
* **Content:** Right-click the main content for row-specific actions.
* **Pager:** Right-click the pager for navigation options.

The default context menu items include:

**Header** 

| Items            | Description                                                  |
| ---------------- | ------------------------------------------------------------ |
| `AutoFit`        | Automatically adjust the column width to fit the content.    |
| `AutoFitAll`     | Automatically adjust all column widths to fit their content. |
| `Group`          | Group the data based on the current column.                  |
| `Ungroup`        | Remove grouping for the current column.                      |
| `SortAscending`  | Sort the current column in ascending order.                  |
| `SortDescending` | Sort the current column in descending order.                 |

**Content**

| Items         | Description                                                         |
| ------------- | ------------------------------------------------------------------- |
| `Edit`        | Edit the currently selected record in the Grid.                     |
| `Delete`      | Delete the currently selected record.                               |
| `Save`        | Save the changes made to the edited record.                         |
| `Cancel`      | Cancel the edit state and revert changes made to the edited record. |
| `Copy`        | Copy the selected records to the clipboard.                         |
| `PdfExport`   | Export the Grid data as a PDF document.                             |
| `ExcelExport` | Export the Grid data as an Excel document.                          |
| `CsvExport`   | Export the Grid data as a CSV document.                             |

**Pager**

| Items       | Description                                |
| ----------- | ------------------------------------------ |
| `FirstPage` | Navigate to the first page of the Grid.    |
| `PrevPage`  | Navigate to the previous page of the Grid. |
| `LastPage`  | Navigate to the last page of the Grid.     |
| `NextPage`  | Navigate to the next page of the Grid.     |

**Example: Enable the context menu feature in the Grid**

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid @ref="Grid" DataSource="@Orders" AllowSorting="true" AllowPaging="true" AllowGrouping="true" AllowExcelExport="true" AllowPdfExport="true" ContextMenuItems="@ContextMenuItems">
    <GridEditSettings AllowDeleting="true" AllowEditing="true"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120" IsPrimaryKey="true"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" EditType="EditType.NumericEdit" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    private SfGrid<OrderData>? Grid;
    private List<OrderData> Orders { get; set; } = new List<OrderData>();
    private List<object> ContextMenuItems = new()
    {
        "AutoFit", "AutoFitAll", "SortAscending", "SortDescending", "Copy",
        "Edit", "Delete", "Save", "Cancel", "PdfExport", "ExcelExport", "CsvExport",
        "FirstPage", "PrevPage", "LastPage", "NextPage", "Group", "Ungroup"
    };

    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
    }
}

{% endhighlight %}

{% highlight c# tabtitle="OrderData.cs" %}

public class OrderData
{
    private static readonly List<OrderData> Orders = new();

    public OrderData(int orderID, string customerID, double freight, string shipCity)
    {
        OrderID = orderID;
        CustomerID = customerID;
        Freight = freight;
        ShipCity = shipCity;
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count == 0)
        {
            Orders.Add(new OrderData(10248, "VINET", 32.38, "Reims"));
            Orders.Add(new OrderData(10249, "TOMSP", 11.61, "Münster"));
            Orders.Add(new OrderData(10250, "HANAR", 65.83, "Rio de Janeiro"));
            Orders.Add(new OrderData(10251, "VICTE", 41.34, "Lyon"));
            Orders.Add(new OrderData(10252, "SUPRD", 51.3, "Charleroi"));
            Orders.Add(new OrderData(10253, "HANAR", 58.17, "Rio de Janeiro"));
            Orders.Add(new OrderData(10254, "CHOPS", 22.98, "Bern"));
            Orders.Add(new OrderData(10255, "RICSU", 148.33, "Genève"));
            Orders.Add(new OrderData(10256, "WELLI", 13.97, "Resende"));
            Orders.Add(new OrderData(10257, "HILAA", 81.91, "San Cristóbal"));
            Orders.Add(new OrderData(10258, "ERNSH", 140.51, "Graz"));
            Orders.Add(new OrderData(10259, "CENTC", 3.25, "México D.F."));
            Orders.Add(new OrderData(10260, "OTTIK", 55.09, "Köln"));
            Orders.Add(new OrderData(10261, "QUEDE", 3.05, "Rio de Janeiro"));
            Orders.Add(new OrderData(10262, "RATTC", 48.29, "Albuquerque"));
        }

        return Orders;
    }

    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public double Freight { get; set; }
    public string ShipCity { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VXrIsjrEUXtJazSQ?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Context menu interaction](/images/context-menu/blazor-datagrid-context-menu.gif)

## Custom context menu items

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid supports adding custom context menu items along with default options.

To configure custom context menu items:

1. Define the [ContextMenuItems](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ContextMenuItemModel.html) property as a collection of [ContextMenuItemModel](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ContextMenuItemModel.html) objects.
2. Specify properties such as **Text**, **Target**, and **Id** for each custom item.
3. Handle actions using the [ContextMenuItemClicked](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ContextMenuClickEventArgs-1.html) event.

**Example: Add a custom context menu item to copy data with headers**

The [CopyAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_CopyAsync_System_Nullable_System_Boolean__) method is used to copy selected rows or cells, including headers, to the clipboard.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid @ref="Grid" DataSource="@Employees" AllowSelection="true" AllowPaging="true" Height="315" ContextMenuItems="@(new List<ContextMenuItemModel>() { new ContextMenuItemModel { Text = "Copy with headers", Target = ".e-content", Id = "copywithheader" } })">
    <GridEvents ContextMenuItemClicked="OnContextMenuClick" TValue="EmployeeData"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(EmployeeData.EmployeeID) HeaderText="Employee ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(EmployeeData.FirstName) HeaderText="First Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(EmployeeData.LastName) HeaderText="Last Name" Width="120"></GridColumn>
        <GridColumn Field=@nameof(EmployeeData.City) HeaderText="City" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    private SfGrid<EmployeeData>? Grid;
    private List<EmployeeData>? Employees { get; set; }

    protected override void OnInitialized()
    {
        Employees = EmployeeData.GetAllRecords();
    }

    private async Task OnContextMenuClick(ContextMenuClickEventArgs<EmployeeData> args)
    {
        if (args.Item.Id == "copywithheader")
        {
            await Grid!.CopyAsync(true);
        }
    }
}

{% endhighlight %}

{% highlight c# tabtitle="EmployeeData.cs" %}

public class EmployeeData
{
    private static readonly List<EmployeeData> Employees = new();

    public EmployeeData(int employeeID, string firstName, string lastName, string city)
    {
        EmployeeID = employeeID;
        FirstName = firstName;
        LastName = lastName;
        City = city;
    }

    public static List<EmployeeData> GetAllRecords()
    {
        if (Employees.Count == 0)
        {
            Employees.Add(new EmployeeData(1001, "Nancy", "Davolio", "Seattle"));
            Employees.Add(new EmployeeData(1002, "Andrew", "Fuller", "Tacoma"));
            Employees.Add(new EmployeeData(1003, "Janet", "Leverling", "Kirkland"));
            Employees.Add(new EmployeeData(1004, "Margaret", "Peacock", "Redmond"));
            Employees.Add(new EmployeeData(1005, "Steven", "Buchanan", "London"));
            Employees.Add(new EmployeeData(1006, "Michael", "Suyama", "London"));
            Employees.Add(new EmployeeData(1007, "Robert", "King", "London"));
            Employees.Add(new EmployeeData(1008, "Laura", "Callahan", "Seattle"));
            Employees.Add(new EmployeeData(1009, "Anne", "Dodsworth", "London"));
            Employees.Add(new EmployeeData(1010, "Andrew", "Smith", "New York"));
            Employees.Add(new EmployeeData(1011, "David", "Brown", "Chicago"));
            Employees.Add(new EmployeeData(1012, "James", "Taylor", "Houston"));
            Employees.Add(new EmployeeData(1013, "Emily", "Johnson", "Phoenix"));
            Employees.Add(new EmployeeData(1014, "Linda", "Clark", "San Diego"));
            Employees.Add(new EmployeeData(1015, "Daniel", "Lee", "Denver"));
        }

        return Employees;
    }

    public int EmployeeID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string City { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LtBoMjLaVOKOJFCg?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Custom menu item](/images/context-menu/blazor-datagrid-context-menu-custom-item.gif)

## Built-in and Custom context menu items

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid supports using both built-in and custom context menu items together. This is helpful when extending default actions such as **Copy**, **Delete**, or **Edit** with application-specific commands like **Copy with headers** or **Export row**.

To configure **built-in** and **custom** context menu items:

1. Define both built-in item strings and custom [ContextMenuItemModel](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ContextMenuItemModel.html) objects in the [ContextMenuItems](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ContextMenuItemModel.html) property.
2. For custom items, specify properties such as **Text**, **Target**, and **Id**.
3. Handle custom actions using the [ContextMenuItemClicked](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ContextMenuClickEventArgs-1.html) event.

**Example: Combine built-in and custom context menu items**

The [CopyAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_CopyAsync_System_Nullable_System_Boolean__) method copies selected rows or cells, including headers, to the clipboard.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid @ref="Grid" DataSource="@Orders" AllowPaging="true" ContextMenuItems="@(new List<object>() { "Copy", new ContextMenuItemModel { Text = "Copy with headers", Target = ".e-content", Id = "copywithheader" } })">
    <GridEvents ContextMenuItemClicked="OnContextMenuClick" TValue="OrderData"></GridEvents>
    <GridPageSettings PageSize="8"></GridPageSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120" IsPrimaryKey="true"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    private SfGrid<OrderData>? Grid;
    private List<OrderData> Orders { get; set; } = new List<OrderData>();

    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
    }

    private async Task OnContextMenuClick(ContextMenuClickEventArgs<OrderData> args)
    {
        if (args.Item.Id == "copywithheader")
        {
            await Grid!.CopyAsync(true);
        }
    }
}

{% endhighlight %}

{% highlight c# tabtitle="OrderData.cs" %}

public class OrderData
{
    private static readonly List<OrderData> Orders = new();

    public OrderData(int orderID, string customerID, double freight, string shipCity)
    {
        OrderID = orderID;
        CustomerID = customerID;
        Freight = freight;
        ShipCity = shipCity;
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count == 0)
        {
            Orders.Add(new OrderData(10248, "VINET", 32.38, "Reims"));
            Orders.Add(new OrderData(10249, "TOMSP", 11.61, "Münster"));
            Orders.Add(new OrderData(10250, "HANAR", 65.83, "Rio de Janeiro"));
            Orders.Add(new OrderData(10251, "VICTE", 41.34, "Lyon"));
            Orders.Add(new OrderData(10252, "SUPRD", 51.3, "Charleroi"));
            Orders.Add(new OrderData(10253, "HANAR", 58.17, "Rio de Janeiro"));
            Orders.Add(new OrderData(10254, "CHOPS", 22.98, "Bern"));
            Orders.Add(new OrderData(10255, "RICSU", 148.33, "Genève"));
            Orders.Add(new OrderData(10256, "WELLI", 13.97, "Resende"));
            Orders.Add(new OrderData(10257, "HILAA", 81.91, "San Cristóbal"));
            Orders.Add(new OrderData(10258, "ERNSH", 140.51, "Graz"));
            Orders.Add(new OrderData(10259, "CENTC", 3.25, "México D.F."));
            Orders.Add(new OrderData(10260, "OTTIK", 55.09, "Köln"));
            Orders.Add(new OrderData(10261, "QUEDE", 3.05, "Rio de Janeiro"));
            Orders.Add(new OrderData(10262, "RATTC", 48.29, "Albuquerque"));
        }

        return Orders;
    }

    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public double Freight { get; set; }
    public string ShipCity { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BDLSiXBaVEwxOsiX?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Built-in and Custom Context Menu Items](/images/context-menu/blazor-datagrid-context-menu-built-in-custom.gif)

## Sub context menu items in DataGrid

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid supports hierarchical context menu structures, allowing sub-context menu items to appear as child options under a parent item. This feature helps organize multiple related actions under a single top-level context menu item.

To configure sub-context menu items:

1. Define the [ContextMenuItems](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ContextMenuItemModel.html) property with a list of [ContextMenuItemModel](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ContextMenuItemModel.html) objects.
2. Add sub-items by specifying the collection for the Items property in ContextMenuItemModel.
3. Handle actions using the [ContextMenuItemClicked](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ContextMenuClickEventArgs-1.html) event.

**Example: Sub Context Menu Items**

This example creates a sub-context menu titled **Clipboard**, which includes the sub-items **Copy** and **Copy With Header**. When the `ContextMenuItemClicked` event is triggered, the [CopyAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_CopyAsync_System_Nullable_System_Boolean__) method runs to copy data with or without headers.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid @ref="Grid" DataSource="@Orders" AllowPaging="true" ContextMenuItems="@ContextMenuItems">
    <GridEvents TValue="OrderData" ContextMenuItemClicked="OnContextMenuClick"></GridEvents>
    <GridPageSettings PageSize="8"></GridPageSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120" IsPrimaryKey="true" />
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer Name" Width="150" />
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120" />
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="150" />
    </GridColumns>
</SfGrid>

@code {
    private SfGrid<OrderData>? Grid;
    private List<OrderData> Orders { get; set; } = new List<OrderData>();
    private List<ContextMenuItemModel> ContextMenuItems = new()
    {
        new ContextMenuItemModel
        {
            Text = "Clipboard",
            Target = ".e-content",
            Id = "clipboard",
            Items = new List<Syncfusion.Blazor.Navigations.MenuItem>
            {
                new Syncfusion.Blazor.Navigations.MenuItem { Text = "Copy", Id = "copy" },
                new Syncfusion.Blazor.Navigations.MenuItem { Text = "Copy With Header", Id = "copywithheader" }
            }
        }
    };

    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
    }

    private async Task OnContextMenuClick(ContextMenuClickEventArgs<OrderData> args)
    {
        if (args.Item.Id == "copy")
        {
            await Grid!.CopyAsync(false);
        }
        else if (args.Item.Id == "copywithheader")
        {
            await Grid!.CopyAsync(true);
        }
    }
}

{% endhighlight %}

{% highlight c# tabtitle="OrderData.cs" %}

public class OrderData
{
     private static readonly List<OrderData> Orders = new();

    public OrderData(int orderID, string customerID, double freight, string shipCity)
    {
        OrderID = orderID;
        CustomerID = customerID;
        Freight = freight;
        ShipCity = shipCity;
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count == 0)
        {
            Orders.Add(new OrderData(10248, "VINET", 32.38, "Reims"));
            Orders.Add(new OrderData(10249, "TOMSP", 11.61, "Münster"));
            Orders.Add(new OrderData(10250, "HANAR", 65.83, "Rio de Janeiro"));
            Orders.Add(new OrderData(10251, "VICTE", 41.34, "Lyon"));
            Orders.Add(new OrderData(10252, "SUPRD", 51.3, "Charleroi"));
            Orders.Add(new OrderData(10253, "HANAR", 58.17, "Rio de Janeiro"));
            Orders.Add(new OrderData(10254, "CHOPS", 22.98, "Bern"));
            Orders.Add(new OrderData(10255, "RICSU", 148.33, "Genève"));
            Orders.Add(new OrderData(10256, "WELLI", 13.97, "Resende"));
            Orders.Add(new OrderData(10257, "HILAA", 81.91, "San Cristóbal"));
            Orders.Add(new OrderData(10258, "ERNSH", 140.51, "Graz"));
            Orders.Add(new OrderData(10259, "CENTC", 3.25, "México D.F."));
            Orders.Add(new OrderData(10260, "OTTIK", 55.09, "Köln"));
            Orders.Add(new OrderData(10261, "QUEDE", 3.05, "Rio de Janeiro"));
            Orders.Add(new OrderData(10262, "RATTC", 48.29, "Albuquerque"));
        }

        return Orders;
    }

    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public double Freight { get; set; }
    public string ShipCity { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LNLIiNhEqQfJGczz?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Sub Context Menu Items](/images/context-menu/blazor-datagrid-context-menu-sub-items.gif)

## Disable the context menu for specific columns in DataGrid

The Syncfusion<sup style="font-size:70%">&reg;</sup>  Blazor DataGrid allows restricting the context menu on specific columns—particularly when those columns contain `sensitive` or `read-only` data.

This behavior can be controlled using the [ContextMenuOpen](https://blazor.syncfusion.com/documentation/datagrid/events#contextmenuopen) event. This event is triggered before the context menu is displayed and provides access to the column details. By checking the column field, the menu can be conditionally cancelled.

To disable the context menu for a specific column:

1. Handle the [ContextMenuOpen](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_ContextMenuOpen) event of the Grid.
2. Use the **Column.Field** property to identify the column.
3. Set **args.Cancel** to `true` to prevent the menu from opening for that column.

**Example: Disable Context Menu for Specific Columns**

The [ContextMenuItemClicked](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ContextMenuClickEventArgs-1.html) event handles actions triggered by context menu item clicks. The [CopyAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_CopyAsync_System_Nullable_System_Boolean__) method executes for all columns except **Freight**, where the context menu is disabled.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid @ref="Grid" DataSource="@Orders" AllowPaging="true" ContextMenuItems="@(new List<ContextMenuItemModel>() { new ContextMenuItemModel { Text = "Copy with headers", Target = ".e-content", Id = "copywithheader" }})">
    <GridEvents TValue="OrderData" ContextMenuItemClicked="OnContextMenuClick" ContextMenuOpen="OnContextMenuOpen"></GridEvents>
    <GridPageSettings PageSize="8"></GridPageSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120" IsPrimaryKey="true" />
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer Name" Width="150" />
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120" />
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="150" />
    </GridColumns>
</SfGrid>

@code {
    private SfGrid<OrderData>? Grid;
    private List<OrderData> Orders { get; set; } = new List<OrderData>();

    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
    }

    public void OnContextMenuOpen(ContextMenuOpenEventArgs<OrderData> args)
    {
        if (args.Column.Field == "Freight")
        {
            args.Cancel = true;
        }
    }

    private async Task OnContextMenuClick(ContextMenuClickEventArgs<OrderData> args)
    {
        if (args.Item.Id == "copywithheader")
        {
            await Grid!.CopyAsync(true);
        }
    }
}

{% endhighlight %}

{% highlight c# tabtitle="OrderData.cs" %}

public class OrderData
{
    private static readonly List<OrderData> Orders = new();

    public OrderData(int orderID, string customerID, double freight, string shipCity)
    {
        OrderID = orderID;
        CustomerID = customerID;
        Freight = freight;
        ShipCity = shipCity;
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count == 0)
        {
            Orders.Add(new OrderData(10248, "VINET", 32.38, "Reims"));
            Orders.Add(new OrderData(10249, "TOMSP", 11.61, "Münster"));
            Orders.Add(new OrderData(10250, "HANAR", 65.83, "Rio de Janeiro"));
            Orders.Add(new OrderData(10251, "VICTE", 41.34, "Lyon"));
            Orders.Add(new OrderData(10252, "SUPRD", 51.3, "Charleroi"));
            Orders.Add(new OrderData(10253, "HANAR", 58.17, "Rio de Janeiro"));
            Orders.Add(new OrderData(10254, "CHOPS", 22.98, "Bern"));
            Orders.Add(new OrderData(10255, "RICSU", 148.33, "Genève"));
            Orders.Add(new OrderData(10256, "WELLI", 13.97, "Resende"));
            Orders.Add(new OrderData(10257, "HILAA", 81.91, "San Cristóbal"));
            Orders.Add(new OrderData(10258, "ERNSH", 140.51, "Graz"));
            Orders.Add(new OrderData(10259, "CENTC", 3.25, "México D.F."));
            Orders.Add(new OrderData(10260, "OTTIK", 55.09, "Köln"));
            Orders.Add(new OrderData(10261, "QUEDE", 3.05, "Rio de Janeiro"));
            Orders.Add(new OrderData(10262, "RATTC", 48.29, "Albuquerque"));
        }

        return Orders;
    }

    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public double Freight { get; set; }
    public string ShipCity { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VtBSCNrOqOXtBomQ?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Disable Context Menu for Specific Columns](/images/context-menu/blazor-datagrid-disable-context-menu-specific-columns.gif)

## Enable or disable context menu items

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid allows dynamically enabling or disabling specific context menu items using the [Disabled](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.MenuItem.html#Syncfusion_Blazor_Navigations_MenuItem_Disabled) property. This feature is useful when certain actions, such as **Edit** or **Delete** should be restricted based on the column, row data, or custom logic.

To achieve this, handle the [ContextMenuOpen](https://blazor.syncfusion.com/documentation/datagrid/events#contextmenuopen) event. The event is triggered before the context menu is displayed and allows enabling or disabling menu items dynamically based on conditions.

1. Handle the [ContextMenuOpen](https://blazor.syncfusion.com/documentation/datagrid/events#contextmenuopen) event of the grid.
2. Use the **Args.ContextMenuObj.Items** collection to access the menu items.
3. Set the **Disabled** property of the required item(s) to `true` or `false` based on the defined logic.

**Example: Enable or Disable Context Menu Items Dynamically**

The **Copy** menu item is disabled for the **ShipCity** column and remains enabled for all other columns.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" AllowPaging="true" ContextMenuItems="@(new List<object> { "Copy", "Edit", "Delete" })">
    <GridEvents ContextMenuOpen="OnContextMenuOpen" TValue="OrderData"></GridEvents>
    <GridPageSettings PageSize="8"></GridPageSettings>
    <GridEditSettings AllowEditing="true" AllowDeleting="true"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120" IsPrimaryKey="true" />
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer Name" Width="150" />
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" EditType="EditType.NumericEdit" TextAlign="TextAlign.Right" Width="120" />
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="150" />
    </GridColumns>
</SfGrid>

@code {
    private List<OrderData> Orders { get; set; } = new List<OrderData>();

    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
    }

    private void OnContextMenuOpen(ContextMenuOpenEventArgs<OrderData> args)
    {
        args.ContextMenu.Items[0].Disabled = args.Column.Field == nameof(OrderData.ShipCity);
    }
}

{% endhighlight %}

{% highlight c# tabtitle="OrderData.cs" %}

public class OrderData
{
    private static readonly List<OrderData> Orders = new();

    public OrderData(int orderID, string customerID, double freight, string shipCity)
    {
        OrderID = orderID;
        CustomerID = customerID;
        Freight = freight;
        ShipCity = shipCity;
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count == 0)
        {
            Orders.Add(new OrderData(10248, "VINET", 32.38, "Reims"));
            Orders.Add(new OrderData(10249, "TOMSP", 11.61, "Münster"));
            Orders.Add(new OrderData(10250, "HANAR", 65.83, "Rio de Janeiro"));
            Orders.Add(new OrderData(10251, "VICTE", 41.34, "Lyon"));
            Orders.Add(new OrderData(10252, "SUPRD", 51.3, "Charleroi"));
            Orders.Add(new OrderData(10253, "HANAR", 58.17, "Rio de Janeiro"));
            Orders.Add(new OrderData(10254, "CHOPS", 22.98, "Bern"));
            Orders.Add(new OrderData(10255, "RICSU", 148.33, "Genève"));
            Orders.Add(new OrderData(10256, "WELLI", 13.97, "Resende"));
            Orders.Add(new OrderData(10257, "HILAA", 81.91, "San Cristóbal"));
            Orders.Add(new OrderData(10258, "ERNSH", 140.51, "Graz"));
            Orders.Add(new OrderData(10259, "CENTC", 3.25, "México D.F."));
            Orders.Add(new OrderData(10260, "OTTIK", 55.09, "Köln"));
            Orders.Add(new OrderData(10261, "QUEDE", 3.05, "Rio de Janeiro"));
            Orders.Add(new OrderData(10262, "RATTC", 48.29, "Albuquerque"));
        }

        return Orders;
    }

    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public double Freight { get; set; }
    public string ShipCity { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BXreWNBkTWeKfahW?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Enable or Disable Context Menu Items](/images/context-menu/blazor-datagrid-enable-disable-context-menu-items.gif)

## Show or hide context menu 

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid allows dynamically showing or hiding specific context menu items using the [Hidden](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.MenuItem.html#Syncfusion_Blazor_Navigations_MenuItem_Hidden) property. This feature is useful when certain actions, such as Edit or Delete, should be hidden based on the column, row data, or custom logic.

To achieve this, handle the [ContextMenuOpen](https://blazor.syncfusion.com/documentation/datagrid/events#contextmenuopen) event. The event is triggered before the context menu is displayed and allows modifying the visibility of menu items dynamically based on conditions.

To control the visibility of context menu items:

1. Handle the [ContextMenuOpen](https://blazor.syncfusion.com/documentation/datagrid/events#contextmenuopen) event of the grid.
2. Use the **Args.ContextMenuObj.Items** collection to access the menu items.
3. Set the [Hidden](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.MenuItem.html#Syncfusion_Blazor_Navigations_MenuItem_Hidden) property of the required item(s) to `true` or `false` based on the defined logic.

**Example: Show or Hide Context Menu Items Dynamically**

The **Edit** menu item is hidden for the **CustomerID** column and remains visible for all other columns.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" AllowPaging="true" ContextMenuItems="@(new List<object>() { "Copy", "Edit", "Delete"})">
    <GridEvents ContextMenuOpen="OnContextMenuOpen" TValue="OrderData"></GridEvents>
    <GridPageSettings PageSize="8"></GridPageSettings>
    <GridEditSettings AllowEditing="true" AllowDeleting="true"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120" IsPrimaryKey="true" />
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer Name" Width="150" />
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" EditType="EditType.NumericEdit" TextAlign="TextAlign.Right" Width="120" />
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="150" />
    </GridColumns>
</SfGrid>

@code {
    private List<OrderData> Orders { get; set; } = new List<OrderData>();

    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
    }

    private void OnContextMenuOpen(ContextMenuOpenEventArgs<OrderData> args)
    {
        args.ContextMenu.Items[1].Hidden = args.Column.Field == nameof(OrderData.CustomerID);
    }
}

{% endhighlight %}

{% highlight c# tabtitle="OrderData.cs" %}

public class OrderData
{
    private static readonly List<OrderData> Orders = new();

    public OrderData(int orderID, string customerID, double freight, string shipCity)
    {
        OrderID = orderID;
        CustomerID = customerID;
        Freight = freight;
        ShipCity = shipCity;
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count == 0)
        {
            Orders.Add(new OrderData(10248, "VINET", 32.38, "Reims"));
            Orders.Add(new OrderData(10249, "TOMSP", 11.61, "Münster"));
            Orders.Add(new OrderData(10250, "HANAR", 65.83, "Rio de Janeiro"));
            Orders.Add(new OrderData(10251, "VICTE", 41.34, "Lyon"));
            Orders.Add(new OrderData(10252, "SUPRD", 51.3, "Charleroi"));
            Orders.Add(new OrderData(10253, "HANAR", 58.17, "Rio de Janeiro"));
            Orders.Add(new OrderData(10254, "CHOPS", 22.98, "Bern"));
            Orders.Add(new OrderData(10255, "RICSU", 148.33, "Genève"));
            Orders.Add(new OrderData(10256, "WELLI", 13.97, "Resende"));
            Orders.Add(new OrderData(10257, "HILAA", 81.91, "San Cristóbal"));
            Orders.Add(new OrderData(10258, "ERNSH", 140.51, "Graz"));
            Orders.Add(new OrderData(10259, "CENTC", 3.25, "México D.F."));
            Orders.Add(new OrderData(10260, "OTTIK", 55.09, "Köln"));
            Orders.Add(new OrderData(10261, "QUEDE", 3.05, "Rio de Janeiro"));
            Orders.Add(new OrderData(10262, "RATTC", 48.29, "Albuquerque"));
        }

        return Orders;
    }

    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public double Freight { get; set; }
    public string ShipCity { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VNLIZfXYKSwAiUpU?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Show or Hide Context Menu Items](/images/context-menu/blazor-datagrid-show-hide-context-menu-items.gif)

### Access specific row details on context menu click

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid allows retrieving details of a specific row when a context menu item is clicked. This feature is useful for displaying or processing the selected row’s data.

To achieve this, handle the [ContextMenuItemClicked](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ContextMenuClickEventArgs-1.html) event. The event is triggered when a context menu item is clicked and provides access to the selected row details.

To access row data on context menu click:

1. Define a custom context menu item using the [ContextMenuItems](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ContextMenuItemModel.html) property.
2. Handle the [ContextMenuItemClicked](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ContextMenuClickEventArgs-1.html) event of the grid.
3. Use the **RowInfo.RowData** property from the event arguments to access the full details of the selected row.

**Example: Fetch Row Details on Context Menu Click**

The **Fetch Data** menu item retrieves the details of the selected row and displays them below the grid.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid @ref="Grid" DataSource="@Orders" AllowPaging="true" ContextMenuItems="@(new List<ContextMenuItemModel>() { new ContextMenuItemModel { Text = "Fetch Data", Id = "fetch data" } })">
    <GridEvents ContextMenuItemClicked="OnContextMenuClick" TValue="OrderData"></GridEvents>
    <GridPageSettings PageSize="8"></GridPageSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" Width="90" TextAlign="TextAlign.Right" />
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="100" />
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="100" />
        <GridColumn Field=@nameof(OrderData.ShipName) HeaderText="Ship Name" Width="100" />
    </GridColumns>
</SfGrid>

@if (rowData != null)
{
    <div class="mt-3 p-3 border rounded bg-light">
        <h5>Selected Row Details:</h5>
        <p><strong>Order ID:</strong> @rowData.OrderID</p>
        <p><strong>Customer ID:</strong> @rowData.CustomerID</p>
        <p><strong>ShipCity:</strong> @rowData.ShipCity</p>
        <p><strong>ShipName:</strong> @rowData.ShipName</p>
    </div>
}

@code {
    private SfGrid<OrderData>? Grid;
    private List<OrderData> Orders { get; set; } = new List<OrderData>();
    private OrderData? rowData;

    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
    }

    private void OnContextMenuClick(ContextMenuClickEventArgs<OrderData> args)
    {
        if (args.Item.Id == "fetch data")
        {
            rowData = args.RowInfo.RowData;
        }
    }
}

{% endhighlight %}

{% highlight c# tabtitle="OrderData.cs" %}

public class OrderData
{
    private static readonly List<OrderData> Orders = new();

    public OrderData(int orderID, string customerID, string shipCity, string shipName)
    {
        OrderID = orderID;
        CustomerID = customerID;
        ShipCity = shipCity;
        ShipName = shipName;
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count == 0)
        {
            Orders.Add(new OrderData(10248, "VINET", "Reims", "Vins et alcools Chevalier"));
            Orders.Add(new OrderData(10249, "TOMSP", "Münster", "Toms Spezialitäten"));
            Orders.Add(new OrderData(10250, "HANAR", "Rio de Janeiro", "Hanari Carnes"));
            Orders.Add(new OrderData(10251, "VICTE", "Lyon", "Victuailles en stock"));
            Orders.Add(new OrderData(10252, "SUPRD", "Charleroi", "Suprêmes délices"));
            Orders.Add(new OrderData(10253, "HANAR", "Rio de Janeiro", "Hanari Carnes"));
            Orders.Add(new OrderData(10254, "CHOPS", "Bern", "Chop-suey Chinese"));
            Orders.Add(new OrderData(10255, "RICSU", "Genève", "Richter Supermarkt"));
            Orders.Add(new OrderData(10256, "WELLI", "Resende", "Wellington Importadora"));
            Orders.Add(new OrderData(10257, "HILAA", "San Cristóbal", "HILARION-Abastos"));
            Orders.Add(new OrderData(10258, "ERNSH", "Graz", "Ernst Handel"));
            Orders.Add(new OrderData(10259, "CENTC", "México D.F.", "Centro comercial Moctezuma"));
            Orders.Add(new OrderData(10260, "OTTIK", "Köln", "Ottilies Käseladen"));
            Orders.Add(new OrderData(10261, "QUEDE", "Rio de Janeiro", "Que Delícia"));
            Orders.Add(new OrderData(10262, "RATTC", "Albuquerque", "Rattlesnake Canyon Grocery"));
        }

        return Orders;
    }

    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public string ShipCity { get; set; }
    public string ShipName { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LXBSMXVazHjnCzPv?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Fetch Row Details on Context Menu Click](/images/context-menu/blazor-datagrid-context-menu-fetch-row-details.gif)

N> Refer to the [Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) feature tour for a detailed overview of available capabilities. Explore the [Blazor DataGrid example](https://blazor.syncfusion.com/demos/datagrid/overview?theme=bootstrap5) to understand data presentation and manipulation.