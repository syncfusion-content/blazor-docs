---
layout: post
title: Context Menu in Blazor DataGrid | Syncfusion
description: Explore and understand the Context Menu in Syncfusion Blazor DataGrid. Learn about its features, usage, customization, and more.
platform: Blazor
control: DataGrid
documentation: ug
---

# Context menu in Syncfusion Blazor DataGrid

The Syncfusion Blazor DataGrid comes equipped with a context menu feature, which is triggered when a user right-clicks anywhere within the Grid. This feature serves to enrich the user experience by offering immediate access to a variety of supplementary actions and operations that can be executed on the data displayed in the Grid.

To activate the context menu within the Grid, you have an option to configure the Grid's [ContextMenuItems](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ContextMenuItemModel.html) property. You can set this property to either include the default context menu items or define your own custom context menu items, tailoring the menu options to suit your specific needs. This customization allows you to enhance the Grid's functionality by providing context-sensitive actions for interacting with your data.
   
The context menu is triggered when you right-click on different areas of the Grid, including:
  * Header: When you right-click on the Grid's header section.
  * Content: When you right-click on the Grid's main content area.
  * Pager: When you right-click on the pager section.

The default context menu items in the header area of the Grid are as follows:

| Items            | Description                                                  |
| ---------------- | ------------------------------------------------------------ |
| `AutoFit`        | Automatically adjust the column width to fit the content.    |
| `AutoFitAll`     | Automatically adjust all column widths to fit their content. |
| `Group`          | Group the data based on the current column.                  |
| `Ungroup`        | Remove grouping for the current column.                      |
| `SortAscending`  | Sort the current column in ascending order.                  |
| `SortDescending` | Sort the current column in descending order.                 |

The default context menu items in the content area of the Grid are as follows:

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

The default context menu items in the pager area of the Grid are as follows:

| Items       | Description                                |
| ----------- | ------------------------------------------ |
| `FirstPage` | Navigate to the first page of the Grid.    |
| `PrevPage`  | Navigate to the previous page of the Grid. |
| `LastPage`  | Navigate to the last page of the Grid.     |
| `NextPage`  | Navigate to the next page of the Grid.     |

The following example demonstrates how to enable context menu feature in the Grid.

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
    private SfGrid<OrderData> Grid;
    public List<OrderData> Orders { get; set; }

    public List<object> ContextMenuItems = new List<object>
    {
        "AutoFit",
        "AutoFitAll",
        "SortAscending",
        "SortDescending",
        "Copy",
        "Edit",
        "Delete",
        "Save",
        "Cancel",
        "PdfExport",
        "ExcelExport",
        "CsvExport",
        "FirstPage",
        "PrevPage",
        "LastPage",
        "NextPage",
        "Group",
        "Ungroup"
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
    public static List<OrderData> Orders = new List<OrderData>();

    public OrderData(int orderID, string customerID, double freight, string shipCity)
    {
        this.OrderID = orderID;
        this.CustomerID = customerID;
        this.Freight = freight;
        this.ShipCity = shipCity;
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/htBIjJjlfrgDinOe?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}


## Custom context menu items

The Syncfusion Blazor DataGrid empowers you to enhance your user experience by incorporating custom context menu items into the default context menu. These customized options enable you to tailor the context menu to meet the unique requirements of your application.

To incorporate custom context menu items in the Syncfusion Blazor DataGrid, you can achieve this by specifying the [ContextMenuItems](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ContextMenuItemModel.html) property as a collection of [ContextMenuItemModel](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ContextMenuItemModel.html). This allows you to define and customize the appearance and behavior of these additional context menu items according to your requirements.

Furthermore, you can assign actions to these custom items by utilizing the [ContextMenuItemClicked](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ContextMenuClickEventArgs-1.html) event. This event provides you with the means to handle user interactions with the custom context menu items, enabling you to execute specific actions or operations when these items are clicked. 

The following example demonstrates how to add custom context menu items in the Grid. The [CopyAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_CopyAsync_System_Nullable_System_Boolean__) method is used to copy the selected rows or cells data to the clipboard, including headers.

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
    private SfGrid<EmployeeData> Grid;
    public List<EmployeeData> Employees { get; set; }

    protected override void OnInitialized()
    {
        Employees = EmployeeData.GetAllRecords();
    }

    public async Task OnContextMenuClick(ContextMenuClickEventArgs<EmployeeData> args)
    {
        if (args.Item.Id == "copywithheader")
        {
            await this.Grid.CopyAsync(true);
        }
    }

}

{% endhighlight %}

{% highlight c# tabtitle="EmployeeData.cs" %}

public class EmployeeData
{

    public static List<EmployeeData> Employees = new List<EmployeeData>();

    public EmployeeData(int employeeID, string firstName, string lastName, string city)
    {
        this.EmployeeID = employeeID;
        this.FirstName = firstName;
        this.LastName = lastName;
        this.City = city;
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/BZVyDfNYsPWaHXLo?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Built-in and Custom context menu items

The Syncfusion Blazor DataGrid provides the flexibility to use both built-in and custom context menu items simultaneously. This is useful when you want to extend the default functionalities (like copy, delete, or edit) with your own custom actions, such as Copy with headers, Export row, or other application-specific commands.

You can achieve this by defining a list containing both built-in menu item strings and custom context menu items using the [ContextMenuItemModel](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ContextMenuItemModel.html) in the [ContextMenuItems](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ContextMenuItemModel.html) property of the Grid. The actions for custom context menu items can be handled using the [ContextMenuItemClicked](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ContextMenuClickEventArgs-1.html) event.

The following example demonstrates how to define both built-in and custom context menu items, and how to handle the custom item action in the `ContextMenuItemClicked` event. The [CopyAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_CopyAsync_System_Nullable_System_Boolean__) method is used to copy the selected rows or cells data to the clipboard, including headers.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid @ref="Grid" DataSource="@Orders" AllowPaging="true" ContextMenuItems="@(new List<Object>() { "Copy", new ContextMenuItemModel { Text = "Copy with headers", Target = ".e-content", Id = "copywithheader" } })">
    <GridEvents ContextMenuItemClicked="OnContextMenuClick" TValue="OrderData"></GridEvents>
    <GridPageSettings PageSize="8"></GridPageSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120" IsPrimaryKey="true" />
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer Name" Width="150" />
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120" />
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="150" />
    </GridColumns>
</SfGrid>

@code {
    private SfGrid<OrderData> Grid;
    public List<OrderData> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
    }

    public async Task OnContextMenuClick(ContextMenuClickEventArgs<OrderData> args)
    {
        if (args.Item.Id == "copywithheader")
        {
            await Grid.CopyAsync(true);
        }
    }
}

{% endhighlight %}

{% highlight c# tabtitle="OrderData.cs" %}

public class OrderData
{
    public static List<OrderData> Orders = new List<OrderData>();

    public OrderData(int orderID, string customerID, double freight, string shipCity)
    {
        this.OrderID = orderID;
        this.CustomerID = customerID;
        this.Freight = freight;
        this.ShipCity = shipCity;
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/VNBSNftEhBsXumEv?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Sub context menu items in DataGrid

The Syncfusion Blazor DataGrid supports hierarchical context menu structures, allowing you to define sub-context menu items that appear as child options under a parent item in the context menu. This feature is useful when organizing multiple related actions under a single top-level context menu item.

To define sub-context menu items in the Blazor Grid, do follow the steps given below:

1. Use the [ContextMenuItems](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ContextMenuItemModel.html) property to define a list of [ContextMenuItemModel](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ContextMenuItemModel.html) objects.

2. The sub context menu items can be added by defining the collection of `MenuItems` for `Items` Property in `ContextMenuItemModel`.

3. Use the [ContextMenuItemClicked](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ContextMenuClickEventArgs-1.html) event to handle actions for each menu item.


The following example demonstrates how to create a sub context menu titled **Clipboard**, with sub-items **Copy** and **Copy With Header**. The corresponding actions are triggered when the `ContextMenuItemClicked` event is fired and [CopyAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_CopyAsync_System_Nullable_System_Boolean__) action is carried out with and without headers.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid @ref="Grid" DataSource="@Orders" AllowPaging="true" ContextMenuItems="@ContextMenuItems" >
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
    private SfGrid<OrderData> Grid;
    public List<OrderData> Orders { get; set; }
    public List<ContextMenuItemModel> ContextMenuItems = new()
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

    public async Task OnContextMenuClick(ContextMenuClickEventArgs<OrderData> args)
    {
        if (args.Item.Id == "copy")
        {
            await Grid.CopyAsync(false);
        }
        else if (args.Item.Id == "copywithheader")
        {
            await Grid.CopyAsync(true);
        }
    }
}

{% endhighlight %}

{% highlight c# tabtitle="OrderData.cs" %}

public class OrderData
{
    public static List<OrderData> Orders = new List<OrderData>();

    public OrderData(int orderID, string customerID, double freight, string shipCity)
    {
        this.OrderID = orderID;
        this.CustomerID = customerID;
        this.Freight = freight;
        this.ShipCity = shipCity;
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/LNVyjfjkrhfaJLAr?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Disable the context menu for specific columns in DataGrid

In certain scenarios, you may want to restrict the context menu from appearing on specific columns within the Syncfusion Blazor DataGrid. This can be helpful to prevent actions like copying or editing on columns that contain sensitive or read-only data. 

You can achieve this by using the [ContextMenuOpen](https://blazor.syncfusion.com/documentation/datagrid/events#contextmenuopen)  event. This event is triggered before the context menu is opened, allowing you to cancel it conditionally.

To prevent the context menu from opening on a specific column:

1. Handle the `ContextMenuOpen` event of the Grid and use the `Column.Field` property within the event handler to identify the target column.

2. Set `Args.Cancel` as **true** to prevent the menu from opening on that column.

The following example demonstrates how to prevent the context menu from opening when right-clicking on the **Freight** column. The [ContextMenuItemClicked](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ContextMenuClickEventArgs-1.html) event is used to handle actions triggered by context menu item clicks. The [CopyAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_CopyAsync_System_Nullable_System_Boolean__) method will be executed for all columns except **Freight** column, where the context menu is disabled.

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
    private SfGrid<OrderData> Grid;
    public List<OrderData> Orders { get; set; }


    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
    }

    public void OnContextMenuOpen(ContextMenuOpenEventArgs<OrderData> Args)
    {
        if (Args.Column.Field == "Freight")
        {
            Args.Cancel = true; // To prevent the context menu from opening.
        }
    }

    public async Task OnContextMenuClick(ContextMenuClickEventArgs<OrderData> args)
    {
        if (args.Item.Id == "copywithheader")
        {
            await Grid.CopyAsync(true);
        }
    }
}

{% endhighlight %}

{% highlight c# tabtitle="OrderData.cs" %}


public class OrderData
{
    public static List<OrderData> Orders = new List<OrderData>();

    public OrderData(int orderID, string customerID, double freight, string shipCity)
    {
        this.OrderID = orderID;
        this.CustomerID = customerID;
        this.Freight = freight;
        this.ShipCity = shipCity;
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/htBeNTjaVhQWEiHK?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Enable or disable context menu items

The Syncfusion Blazor DataGrid allows you to dynamically enable or disable specific context menu items using [Disabled](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.MenuItem.html#Syncfusion_Blazor_Navigations_MenuItem_Disabled) property. This feature is particularly useful in scenarios where certain actions, such as **Edit** or **Delete**, should be restricted based on the column, the data in the row, or other custom logic.

To achieve this, handle the [ContextMenuOpen](https://blazor.syncfusion.com/documentation/datagrid/events#contextmenuopen) event. This event is triggered before the context menu is opened, allowing you to enable or disable the desired menu items dynamically.

To enable or disable context menu items dynamically, follow the steps below:

1. Handle the `ContextMenuOpen` event of the DataGrid and use the `Args.ContextMenuObj.Items` collection within the handler to access the context menu items.

2. Set the `Disabled` property of the desired item(s) to `true` or `false` based on your logic.

The following example demonstrates how to dynamically enable or disable **Copy** context menu items in the Grid using the `ContextMenuOpen` event. The **Copy** item is disabled for the **ShipCity** column and enabled for other columns.

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
    private SfGrid<OrderData> Grid;
    public List<OrderData> Orders { get; set; }


    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
    }

    public void OnContextMenuOpen(ContextMenuOpenEventArgs<OrderData> Args)
    {
        if (Args.Column.Field == "ShipCity") // You can check condition based on your requirement.
        {
            Args.ContextMenu.Items[0].Disabled = true; // To disable edit context menu item.
        }
        else
        {
            Args.ContextMenu.Items[0].Disabled = false; // To enable edit context menu item.
        }
    }
}
{% endhighlight %}

{% highlight c# tabtitle="OrderData.cs" %}


public class OrderData
{
    public static List<OrderData> Orders = new List<OrderData>();

    public OrderData(int orderID, string customerID, double freight, string shipCity)
    {
        this.OrderID = orderID;
        this.CustomerID = customerID;
        this.Freight = freight;
        this.ShipCity = shipCity;
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/VZryDfXEqqyMSDPD?appbar=false&editor=true&result=true&errorlist=true&theme=bootstrap5" %}

## Show or hide context menu 

The Syncfusion Blazor DataGrid  provides the flexibility to show or hide both default and custom context menu items. This feature allows you to customize the context menu items based on various conditions or individuals interactions.

This can be achieved using  the [ContextMenuOpen](https://blazor.syncfusion.com/documentation/datagrid/events#contextmenuopen) event. This event is triggered before the context menu is opened , allowing you to customize context menu items visibility dynamically.

To control the visibility of context menu items, follow the steps below:

1. Handle the `ContextMenuOpen` event of the Grid and access the `Args.ContextMenu.Items` collection within the event handler to modify the visibility of specific menu items.

2. Set the [Hidden](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.MenuItem.html#Syncfusion_Blazor_Navigations_MenuItem_Hidden) property of `MenuItems` to **true** or **false**, based on your conditions

The following example demonstrates how to dynamically show or hide **Edit** context menu items in the Grid using the `ContextMenuOpen` event. The **Edit** item is disabled for the **CustomerID** column and enabled for other columns.

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
    public List<OrderData> Orders { get; set; }


    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
    }

    public void OnContextMenuOpen(ContextMenuOpenEventArgs<OrderData> Args)
    {
        if (Args.Column.Field == "CustomerID")
        {
            Args.ContextMenu.Items[1].Hidden = true;
        }
        else
        {
            Args.ContextMenu.Items[1].Hidden = false;
        }
    }
}

{% endhighlight %}

{% highlight c# tabtitle="OrderData.cs" %}


public class OrderData
{
    public static List<OrderData> Orders = new List<OrderData>();

    public OrderData(int orderID, string customerID, double freight, string shipCity)
    {
        this.OrderID = orderID;
        this.CustomerID = customerID;
        this.Freight = freight;
        this.ShipCity = shipCity;
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

### Access specific row details on context menu click

The Syncfusion Blazor DataGrid allows you to interact with specific row data when a context menu item is clicked. This feature is useful when you want to perform actions like viewing, editing, or processing data from the selected row.

You can achieve this by handling the [ContextMenuItemClicked](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ContextMenuClickEventArgs-1.html) event. This event provides access to the clicked menu item and the associated row data, enabling you to fetch and display specific details dynamically.

Steps to access row data on context menu click:

1. Define a custom context menu item using the [ContextMenuItems](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ContextMenuItemModel.html) property.
2. Handle the `ContextMenuItemClicked` event to capture the selected row's data.
3. Use the `RowInfo.RowData` property from the event arguments to access the full row details.

The following example demonstrates how to fetch specific row details when a context menu item is clicked in the Grid using the `ContextMenuItemClicked` event. The fetch data item retrieves the row information and displays it below the Grid:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid @ref="Grid" DataSource="@Orders" AllowPaging="true" ContextMenuItems="@(new List<ContextMenuItemModel>() { new ContextMenuItemModel { Text = "fetch data", Id = "fetch data" } })">
    <GridEvents ContextMenuItemClicked="OnContextMenuClick" TValue="OrderData"></GridEvents>
    <GridPageSettings PageSize="8"></GridPageSettings>
    <GridColumns>
       <GridColumn Field="OrderID" HeaderText="Order ID" Width="90" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" />
       <GridColumn Field="CustomerID" HeaderText="Customer ID" Width="100" />
       <GridColumn Field="ShipCity" HeaderText="ShipCity" Width="100" />
       <GridColumn Field="ShipName" HeaderText="ShipName" Width="100" />
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
    private SfGrid<OrderData> Grid;
    public List<OrderData> Orders { get; set; }
 
    private OrderData rowData { get; set; }

    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
    }

    public void OnContextMenuClick(ContextMenuClickEventArgs<OrderData> args)
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
    public static List<OrderData> order = new List<OrderData>();
    public OrderData(int OrderID, string CustomerId, string ShipCity, string ShipName)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerId;
        this.ShipCity = ShipCity;
        this.ShipName = ShipName;
    }
    public static List<OrderData> GetAllRecords()
    {
        if (order.Count == 0)
        {
            order.Add(new OrderData(10248, "VINET", "Reims", "Vins et alcools Chevalier"));
            order.Add(new OrderData(10249, "TOMSP", "Münster", "Toms Spezialitäten"));
            order.Add(new OrderData(10250, "HANAR", "Rio de Janeiro", "Hanari Carnes"));
            order.Add(new OrderData(10251, "VICTE", "Lyon", "Victuailles en stock"));
            order.Add(new OrderData(10252, "SUPRD", "Charleroi", "Suprêmes délices"));
            order.Add(new OrderData(10253, "HANAR", "Rio de Janeiro", "Hanari Carnes"));
            order.Add(new OrderData(10254, "CHOPS", "Bern", "Chop-suey Chinese"));
            order.Add(new OrderData(10255, "RICSU", "Genève", "Richter Supermarkt"));
            order.Add(new OrderData(10256, "WELLI", "Resende", "Wellington Importadora"));
            order.Add(new OrderData(10257, "HILAA", "San Cristóbal", "HILARION-Abastos"));
            order.Add(new OrderData(10258, "ERNSH", "Graz", "Ernst Handel"));
            order.Add(new OrderData(10259, "CENTC", "México D.F.", "Centro comercial Moctezuma"));
            order.Add(new OrderData(10260, "OTTIK", "Köln", "Ottilies Käseladen"));
            order.Add(new OrderData(10261, "QUEDE", "Rio de Janeiro", "Que Delícia"));
            order.Add(new OrderData(10262, "RATTC", "Albuquerque", "Rattlesnake Canyon Grocery"));
        }
        return order;
    }
    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public string ShipCity { get; set; }
    public string ShipName { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BtLetwrTrwitHdvW?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

N> You can refer to [Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) feature tour page for its groundbreaking feature representations. You can also explore [Blazor DataGrid example](https://blazor.syncfusion.com/demos/datagrid/overview?theme=bootstrap5) to understand how to present and manipulate data.
