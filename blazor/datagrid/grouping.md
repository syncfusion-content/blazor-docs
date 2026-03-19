---
layout: post
title: Grouping in Blazor DataGrid | Syncfusion
description: Learn how to group data, manage drop area visibility, persist group state, and sort or format grouped columns in the Syncfusion Blazor DataGrid.
platform: Blazor
control: DataGrid
documentation: ug
---

# Grouping in Blazor DataGrid

The grouping feature in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid enables data to be organized into a hierarchical structure, allowing records to be expanded and collapsed for improved readability and analysis.

The group feature is enabled by setting the [AllowGrouping](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowGrouping) property to **true**. Configure behavior using [GridGroupSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_GroupSettings).

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@GridData" AllowGrouping="true" Height="267px">
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="90"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipName) HeaderText="Ship Name" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<OrderData> GridData { get; set; }

    protected override void OnInitialized()
    {
        GridData = OrderData.GetAllRecords();
    }
}

{% endhighlight %}

{% highlight c# tabtitle="OrderData.cs" %}

public class OrderData
{
    public static List<OrderData> Orders = new List<OrderData>();
    public OrderData() {}

    public OrderData(int? OrderID,string CustomerID,string ShipCity, string ShipName)
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
                Orders.Add(new OrderData(10248, "VINET", "Reims", "Vins et alcools Chevali"));
                Orders.Add(new OrderData(10249, "TOMSP", "Münster", "Toms Spezialitäten"));
                Orders.Add(new OrderData(10250, "HANAR", "Rio de Janeiro", "Hanari Carnes"));
                Orders.Add(new OrderData(10251, "VICTE", "Lyon", "Victuailles en stock"));
                Orders.Add(new OrderData(10252, "SUPRD", "Charleroi", "Suprêmes délices"));
                Orders.Add(new OrderData(10253, "HANAR", "Lyon", "Hanari Carnes"));
                Orders.Add(new OrderData(10254, "CHOPS", "Rio de Janeiro", "Chop-suey Chinese"));
                Orders.Add(new OrderData(10255, "RICSU", "Münster", "Richter Supermarkt"));
                Orders.Add(new OrderData(10256, "WELLI", "Reims", "Wellington Import"));
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/rNLqMCNQhjHRjNeQ?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> - Columns can be grouped and ungrouped dynamically using the [GroupColumnAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_GroupColumnAsync_System_String_) and [UngroupColumnAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_UngroupColumnAsync_System_String_) methods.
> - To disable grouping for a specific column, set the [GridColumn.AllowGrouping](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_AllowGrouping) property to `false` in column configuration.

## Initial group

Initial grouping in the DataGrid is configured by assigning an array of column field names to the [Columns](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridGroupSettings.html#Syncfusion_Blazor_Grids_GridGroupSettings_Columns) property of [GridGroupSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridGroupSettings.html). This approach is effective for organizing large datasets based on predefined criteria.

The example below demonstrates grouping by **"Customer ID"** and **"Ship City"**, rendering the DataGrid with data structured in a two-level hierarchy first by **"Customer ID"**, followed by **"Ship City"** within each group.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@GridData" AllowGrouping="true" Height="267px">
    <GridGroupSettings Columns="@Initial"></GridGroupSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="90"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipName) HeaderText="Ship Name" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<OrderData> GridData { get; set; }

    public string[] Initial = (new string[] { "CustomerID", "ShipCity" });

    protected override void OnInitialized()
    {
        GridData = OrderData.GetAllRecords();
    }
}

{% endhighlight %}

{% highlight c# tabtitle="OrderData.cs" %}

public class OrderData
{
    public static List<OrderData> Orders = new List<OrderData>();   
    public OrderData(){}

    public OrderData(int? OrderID,string CustomerID,string ShipCity, string ShipName)
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
                Orders.Add(new OrderData(10248, "VINET", "Reims", "Vins et alcools Chevali"));
                Orders.Add(new OrderData(10249, "TOMSP", "Münster", "Toms Spezialitäten"));
                Orders.Add(new OrderData(10250, "HANAR", "Rio de Janeiro", "Hanari Carnes"));
                Orders.Add(new OrderData(10251, "VICTE", "Lyon", "Victuailles en stock"));
                Orders.Add(new OrderData(10252, "SUPRD", "Charleroi", "Suprêmes délices"));
                Orders.Add(new OrderData(10253, "HANAR", "Lyon", "Hanari Carnes"));
                Orders.Add(new OrderData(10254, "CHOPS", "Rio de Janeiro", "Chop-suey Chinese"));
                Orders.Add(new OrderData(10255, "RICSU", "Münster", "Richter Supermarkt"));
                Orders.Add(new OrderData(10256, "WELLI", "Reims", "Wellington Import"));
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/rXBKsCNQBXkOKmSa?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> To group multiple columns, specify a list of column names in the `Columns` property of `GridGroupSettings`.

## Prevent grouping for specific columns

Columns that contain unique identifiers or sensitive information may not be suitable for grouping. In such cases, grouping can be disabled by setting the[GridColumn.AllowGrouping](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_AllowGrouping) property to `false` in the column configuration, preventing the column header from being placed in the group drop area.

The following example prevents grouping on the "Customer ID" column. While other columns can be grouped, "Customer ID" cannot be dragged to the group drop area.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@GridData" AllowGrouping="true" Height="267px">
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="90"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" AllowGrouping="false" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipName) HeaderText="Ship Name" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<OrderData> GridData { get; set; }

    protected override void OnInitialized()
    {
        GridData = OrderData.GetAllRecords();
    }
}

{% endhighlight %}

{% highlight c# tabtitle="OrderData.cs" %}

public class OrderData
{
    public static List<OrderData> Orders = new List<OrderData>();  
    public OrderData() {}
    public OrderData(int? OrderID,string CustomerID,string ShipCity, string ShipName)
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
                Orders.Add(new OrderData(10248, "VINET", "Reims", "Vins et alcools Chevali"));
                Orders.Add(new OrderData(10249, "TOMSP", "Münster", "Toms Spezialitäten"));
                Orders.Add(new OrderData(10250, "HANAR", "Rio de Janeiro", "Hanari Carnes"));
                Orders.Add(new OrderData(10251, "VICTE", "Lyon", "Victuailles en stock"));
                Orders.Add(new OrderData(10252, "SUPRD", "Charleroi", "Suprêmes délices"));
                Orders.Add(new OrderData(10253, "HANAR", "Lyon", "Hanari Carnes"));
                Orders.Add(new OrderData(10254, "CHOPS", "Rio de Janeiro", "Chop-suey Chinese"));
                Orders.Add(new OrderData(10255, "RICSU", "Münster", "Richter Supermarkt"));
                Orders.Add(new OrderData(10256, "WELLI", "Reims", "Wellington Import"));
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/LthUWWNcBWKrghqe?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Hide drop area

By default, the DataGrid shows a drop area container where column headers can be dragged to configure grouping or ungrouping. In scenarios where grouping through the drag‑and‑drop interface is not required, this drop area can be hidden.

To disable the group drop area container, set the [ShowDropArea](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridGroupSettings.html#Syncfusion_Blazor_Grids_GridGroupSettings_ShowDropArea) property of `GridGroupSettings` to `false`. This hides the drop area from the UI, while still allowing grouping to be managed programmatically using the DataGrid `GroupColumnAsync` and `UngroupColumnAsync` methods if needed.

In this example, the [Toggle Switch Button](https://blazor.syncfusion.com/documentation/toggle-switch-button/getting-started-webapp) button is used to dynamically show or hide the group drop area. When the switch is toggled, the `ValueChange` event updates the DataGrid’s `ShowDropArea` property to either display or hide the drop area.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons

<div style="display:flex;gap: 5px;">
    <label> Hide or show drop area</label>
    <SfSwitch @bind-Checked="isChecked" OffLabel="OFF" OnLabel="ON" ValueChange="Change" TChecked="bool?"></SfSwitch>
</div>

<SfGrid DataSource="@GridData" AllowGrouping="true" Height="315px">
    <GridGroupSettings ShowDropArea="@show" Columns="@Initial"></GridGroupSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="90"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipName) HeaderText="Ship Name" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<OrderData> GridData { get; set; }

    public bool show { get; set; } = false;

    public string[] Initial = (new string[] { "CustomerID", "ShipCity" });

    protected override void OnInitialized()
    {
        GridData = OrderData.GetAllRecords();
    }

    private bool? isChecked = null;

    private async Task Change(Syncfusion.Blazor.Buttons.ChangeEventArgs<bool?> args)
    {
        if (args.Checked == true)
        {
            show = true;
        }
        else
        {
            show = false;
        }
    }
}

{% endhighlight %}

{% highlight c# tabtitle="OrderData.cs" %}

public class OrderData
{
    public static List<OrderData> Orders = new List<OrderData>();  
    public OrderData() { }

    public OrderData(int? OrderID,string CustomerID,string ShipCity, string ShipName)
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
                Orders.Add(new OrderData(10248, "VINET", "Reims", "Vins et alcools Chevali"));
                Orders.Add(new OrderData(10249, "TOMSP", "Münster", "Toms Spezialitäten"));
                Orders.Add(new OrderData(10250, "HANAR", "Rio de Janeiro", "Hanari Carnes"));
                Orders.Add(new OrderData(10251, "VICTE", "Lyon", "Victuailles en stock"));
                Orders.Add(new OrderData(10252, "SUPRD", "Charleroi", "Suprêmes délices"));
                Orders.Add(new OrderData(10253, "HANAR", "Lyon", "Hanari Carnes"));
                Orders.Add(new OrderData(10254, "CHOPS", "Rio de Janeiro", "Chop-suey Chinese"));
                Orders.Add(new OrderData(10255, "RICSU", "Münster", "Richter Supermarkt"));
                Orders.Add(new OrderData(10256, "WELLI", "Reims", "Wellington Import"));
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/VZhgiitwBBVMzKlC?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> By default, the group drop area is shown only if at least one column is available to group.

## Show the grouped column

By default, when a column is grouped in the DataGrid, that column is hidden from the display. This keeps the layout clean and makes grouped rows easier to read. To keep grouped columns visible, set the [ShowGroupedColumn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridGroupSettings.html#Syncfusion_Blazor_Grids_GridGroupSettings_ShowGroupedColumn) property to `true`.

In the example below, a [Toggle Switch Button](https://blazor.syncfusion.com/documentation/toggle-switch-button/getting-started-webapp) button is used to control this setting. When the switch is toggled, the `ValueChange` event updates the DataGrid’s `ShowGroupedColumn` property, showing or hiding the grouped columns as needed.


{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons

<div style="display:flex;gap: 5px;">
    <label> Hide or show grouped columns</label>
    <SfSwitch @bind-Checked="isChecked" OffLabel="OFF" OnLabel="ON" ValueChange="Change" TChecked="bool?"></SfSwitch>
</div>

<SfGrid @ref="Grid" DataSource="@GridData" AllowGrouping="true" Height="315px">
    <GridGroupSettings Columns="@Initial" ShowGroupedColumn=@IsShow></GridGroupSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="90"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipName) HeaderText="Ship Name" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<OrderData> GridData { get; set; }
    SfGrid<OrderData> Grid;

    public bool IsShow { get; set; } = true;

    public string[] Initial = (new string[] { "CustomerID", "ShipCity" });

    protected override void OnInitialized()
    {
        GridData = OrderData.GetAllRecords();
    }

    private bool? isChecked = null;


    private async Task Change(Syncfusion.Blazor.Buttons.ChangeEventArgs<bool?> args)
    {
        if (args.Checked == true)
        {
            IsShow = false;
            await Grid.Refresh();
        }
        else
        {
            IsShow = true;
            await Grid.Refresh();
        }
    }
}

{% endhighlight %}

{% highlight c# tabtitle="OrderData.cs" %}

public class OrderData
{
    public static List<OrderData> Orders = new List<OrderData>();  
    public OrderData(){}

    public OrderData(int? OrderID,string CustomerID,string ShipCity, string ShipName)
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
                Orders.Add(new OrderData(10248, "VINET", "Reims", "Vins et alcools Chevali"));
                Orders.Add(new OrderData(10249, "TOMSP", "Münster", "Toms Spezialitäten"));
                Orders.Add(new OrderData(10250, "HANAR", "Rio de Janeiro", "Hanari Carnes"));
                Orders.Add(new OrderData(10251, "VICTE", "Lyon", "Victuailles en stock"));
                Orders.Add(new OrderData(10252, "SUPRD", "Charleroi", "Suprêmes délices"));
                Orders.Add(new OrderData(10253, "HANAR", "Lyon", "Hanari Carnes"));
                Orders.Add(new OrderData(10254, "CHOPS", "Rio de Janeiro", "Chop-suey Chinese"));
                Orders.Add(new OrderData(10255, "RICSU", "Münster", "Richter Supermarkt"));
                Orders.Add(new OrderData(10256, "WELLI", "Reims", "Wellington Import"));
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/rtLqCCBPUOxoyWyr?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Persist grouped row expand or collapse state
 
The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid can persist the expand or collapse state of grouped rows across operations such as paging, sorting, filtering, and editing. By default, these operations reset grouped rows to their initial state. To retain the current state and ensure a consistent user experience, set [GridGroupSettings.PersistGroupState](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridGroupSettings.html#Syncfusion_Blazor_Grids_GridGroupSettings_PersistGroupState) to **true**. This also applies when using external methods like [ExpandAllGroupAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ExpandAllGroupAsync) and [CollapseAllGroupAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_CollapseAllGroupAsync).

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons

<div style="display:flex;gap: 5px;">
    <label> Enable or disable grouped row state persistence</label>
    <SfSwitch @bind-checked="IsGroupStatePersistent " OffLabel="OFF" OnLabel="ON" ValueChange="Change" TChecked="bool"></SfSwitch>
</div>

<SfGrid DataSource="@GridData" AllowGrouping="true" Height="190px" AllowSorting="true" AllowFiltering="true" AllowPaging="true">
    <GridGroupSettings Columns="@InitialGroupedColumns" PersistGroupState="@IsGroupStatePersistent"></GridGroupSettings>
    <GridEditSettings AllowEditing="true"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" IsPrimaryKey="true" Width="90"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipName) HeaderText="Ship Name" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<OrderData> GridData { get; set; }
    private bool IsGroupStatePersistent { get; set; } = true;
    private string[] InitialGroupedColumns = new string[] { "CustomerID", "ShipCity" };

    protected override void OnInitialized()
    {
        GridData = OrderData.GetAllRecords();
    }

    private void Change(Syncfusion.Blazor.Buttons.ChangeEventArgs<bool> args)
    {
        if (args.Checked == true)
        {
            IsGroupStatePersistent = true;
        }
        else
        {
            IsGroupStatePersistent = false;
        }
    }
}

{% endhighlight %}

{% highlight c# tabtitle="OrderData.cs" %}

public class OrderData
{
    public static List<OrderData> Orders = new List<OrderData>();  
    public OrderData(){}

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
            int code = 10001;
            string[] customerIDs = { "VINET", "TOMSP", "HANAR", "VICTE", "SUPRD", "CHOPS", "RICSU", "WELLI" };
            string[] cities = { "Reims", "Münster", "Rio de Janeiro", "Lyon", "Charleroi" };
            string[] shipNames = { "Vins et alcools Chevali", "Toms Spezialitäten", "Hanari Carnes", 
                                    "Victuailles en stock", "Suprêmes délices", "Chop-suey Chinese", 
                                    "Richter Supermarkt", "Wellington Import" };
            for (int i = 0; i < 45; i++)
            {
                string customerID = customerIDs[i % customerIDs.Length];
                string city = cities[i % cities.Length];
                string shipName = shipNames[i % shipNames.Length];
                
                Orders.Add(new OrderData(code, customerID, city, shipName));
                code++;
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/hZVINYihrdGfllLS?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Sort grouped columns in descending order during initial grouping

Grouped columns are sorted in ascending order by default (A–Z, 0–9, oldest to newest). To display grouped values in descending order such as showing the most recent dates or highest values first (Z–A, 9–0, newest to oldest) configure the [GridSortSettings.Columns](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSortSettings.html#Syncfusion_Blazor_Grids_GridSortSettings_Columns) property with the appropriate [Field](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSortColumn.html#Syncfusion_Blazor_Grids_GridSortColumn_Field) and set its [Direction](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSortColumn.html#Syncfusion_Blazor_Grids_GridSortColumn_Direction) to `Descending`.

The following example demonstrates how to sort the **"Customer ID"** column in descending order during the DataGrid's initial load.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@GridData" AllowSorting="true" AllowGrouping="true" Height="267px">
    <GridGroupSettings Columns="@Initial"></GridGroupSettings>
    <GridSortSettings>
        <GridSortColumns>
            <GridSortColumn Field="CustomerID" Direction="SortDirection.Descending"></GridSortColumn>
        </GridSortColumns>
    </GridSortSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="90"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipName) HeaderText="Ship Name" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<OrderData> GridData { get; set; }

    public string[] Initial = (new string[] { "CustomerID" });

    protected override void OnInitialized()
    {
        GridData = OrderData.GetAllRecords();
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
    public OrderData(int? OrderID,string CustomerID,string ShipCity, string ShipName)
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
                Orders.Add(new OrderData(10248, "VINET", "Reims", "Vins et alcools Chevali"));
                Orders.Add(new OrderData(10249, "TOMSP", "Münster", "Toms Spezialitäten"));
                Orders.Add(new OrderData(10250, "HANAR", "Rio de Janeiro", "Hanari Carnes"));
                Orders.Add(new OrderData(10251, "VICTE", "Lyon", "Victuailles en stock"));
                Orders.Add(new OrderData(10252, "SUPRD", "Charleroi", "Suprêmes délices"));
                Orders.Add(new OrderData(10253, "HANAR", "Lyon", "Hanari Carnes"));
                Orders.Add(new OrderData(10254, "CHOPS", "Rio de Janeiro", "Chop-suey Chinese"));
                Orders.Add(new OrderData(10255, "RICSU", "Münster", "Richter Supermarkt"));
                Orders.Add(new OrderData(10256, "WELLI", "Reims", "Wellington Import"));
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/hjhUCMZGLoABNhxp?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Group by format

By default, grouping is based on the raw data values of each row. For numeric or datetime columns, grouping can also be performed using a specified format for example, grouping dates by month or numbers by range. To enable this behavior, set the [EnableGroupByFormat](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_EnableGroupByFormat) property on the corresponding column. This allows the DataGrid to group values based on their specific format.

The following example demonstrates grouping the **"Order Date"** and **"Freight"** columns using formatted values.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

<SfGrid @ref="Grid" DataSource="@GridData" AllowGrouping="true" Height="315px">
    <GridGroupSettings ShowDropArea="false" Columns=@Format></GridGroupSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="90"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderDate) HeaderText=" Order Date" Format="yyyy/MMM" Type="ColumnType.Date" EnableGroupByFormat="true" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" EnableGroupByFormat="true" Width="80"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<OrderData> GridData { get; set; }
    SfGrid<OrderData>? Grid { get; set; }
    public string[] Format = (new string[] { "OrderDate", "Freight" });

    protected override void OnInitialized()
    {
        GridData = OrderData.GetAllRecords();
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
    public OrderData(int? OrderID,string CustomerID, DateTime? OrderDate, double? Freight)
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
                Orders.Add(new OrderData(10248, "VINET", new DateTime(1996, 07, 06), 32.38));
                Orders.Add(new OrderData(10249, "TOMSP", new DateTime(1996, 07, 06), 11.61));
                Orders.Add(new OrderData(10250, "HANAR", new DateTime(1996, 07, 06), 65.83));
                Orders.Add(new OrderData(10251, "VICTE", new DateTime(1996, 07, 06), 45.78));
                Orders.Add(new OrderData(10252, "SUPRD", new DateTime(1996, 07, 06), 98.6));
                Orders.Add(new OrderData(10253, "HANAR", new DateTime(1996, 07, 06), 103.45));
                Orders.Add(new OrderData(10254, "CHOPS", new DateTime(1996, 07, 06), 103.45));
                Orders.Add(new OrderData(10255, "RICSU", new DateTime(1996, 07, 06), 112.48));
                Orders.Add(new OrderData(10256, "WELLI", new DateTime(1996, 07, 06), 33.45));
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/LDLUisZcqcKfqGvJ?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> Numeric columns can be grouped based on formats such as currency or percentage, while datetime columns can be grouped based on specific date or time formats.

## Collapse all grouped rows at initial rendering

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid provides the ability to expand or collapse grouped rows, enabling better control over data visibility. This is especially useful for large datasets where an initial summarized view is preferred.

To collapse all grouped rows on initial render, use the [DataBound](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_DataBound) event in combination with the [CollapseAllGroupAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_CollapseAllGroupAsync) method. This can be achieved in the below example.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@GridData" @ref="Grid" AllowGrouping="true" Height="267px">
    <GridGroupSettings Columns="@groupOptions"></GridGroupSettings>
    <GridEvents DataBound="DataBoundHandler" TValue="OrderData"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="90"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipName) HeaderText="Ship Name" Width="110"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<OrderData> GridData { get; set; }

    SfGrid<OrderData> Grid;

    public bool initial = true;

    public string[] groupOptions = (new string[] { "ShipCity" });

    protected override void OnInitialized()
    {
        GridData = OrderData.GetAllRecords();
    }

    public async Task DataBoundHandler()
    {
        if(initial == true)
        {
            await Grid.CollapseAllGroupAsync();
            initial = false;
        }
    }
}

{% endhighlight %}

{% highlight c# tabtitle="OrderData.cs" %}

public class OrderData
{
    public static List<OrderData> Orders = new List<OrderData>();
        
    public OrderData() {}
    public OrderData(int? OrderID,string CustomerID,string ShipCity, string ShipName)
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
                Orders.Add(new OrderData(10248, "VINET", "Reims", "Vins et alcools Chevali"));
                Orders.Add(new OrderData(10249, "TOMSP", "Münster", "Toms Spezialitäten"));
                Orders.Add(new OrderData(10250, "HANAR", "Rio de Janeiro", "Hanari Carnes"));
                Orders.Add(new OrderData(10251, "VICTE", "Lyon", "Victuailles en stock"));
                Orders.Add(new OrderData(10252, "SUPRD", "Charleroi", "Suprêmes délices"));
                Orders.Add(new OrderData(10253, "HANAR", "Lyon", "Hanari Carnes"));
                Orders.Add(new OrderData(10254, "CHOPS", "Rio de Janeiro", "Chop-suey Chinese"));
                Orders.Add(new OrderData(10255, "RICSU", "Münster", "Richter Supermarkt"));
                Orders.Add(new OrderData(10256, "WELLI", "Reims", "Wellington Import"));
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/VjrfDsjKqkAfFfop?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

>  The collapse all approach is recommended for a limited number of records since collapsing every grouped record requires time. For large datasets, [lazy-load grouping](https://blazor.syncfusion.com/documentation/datagrid/lazy-load-grouping) is recommended to optimize performance. This approach is also applicable to the [ExpandAllGroupAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ExpandAllGroupAsync) method.

## Group or Ungroup column externally

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid supports both interactive and programmatic approaches to column grouping. Columns can be grouped manually via drag-and-drop or programmatically using the [GroupColumnAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_GroupColumnAsync_System_String_) and [UngroupColumnAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_UngroupColumnAsync_System_String_) methods.

The following example demonstrates how to implement programmatic grouping and ungrouping using the [SfDropDownList](https://blazor.syncfusion.com/documentation/dropdown-list/getting-started-with-web-app) for column selection. When the corresponding button is activated, the selected column is grouped or ungrouped using the appropriate API method.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.DropDowns

<div style="display: flex; flex-direction: column; ">
    <div style="display: flex; gap: 5px;">
        <label>Column name:</label>
        <SfDropDownList TValue="string" TItem="Columns" Width="120px" Placeholder="Select a Column" DataSource="@LocalData" @bind-Value="@DropDownValue">
            <DropDownListFieldSettings Value="ID" Text="Value"></DropDownListFieldSettings>
        </SfDropDownList>
    </div>

    <div style="display: flex; gap: 5px; margin-top: 10px; margin-bottom: 10px">
        <SfButton OnClick="GroupColumn">Group column</SfButton>
        <SfButton OnClick="UnGroupColumn">UnGroup column</SfButton>
    </div>
</div>

<SfGrid @ref="Grid" DataSource="@GridData"  AllowGrouping="true" Height="315px">
    <GridGroupSettings ShowDropArea="false" Columns="@Initial"></GridGroupSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="90"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipName) HeaderText="Ship Name" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<OrderData> GridData { get; set; }
    SfGrid<OrderData>? Grid { get; set; }
    public string DropDownValue { get; set; } = "CustomerID";
    public string[] Initial = (new string[] { "CustomerID", "ShipCity" });

    protected override void OnInitialized()
    {
        GridData = OrderData.GetAllRecords();
    }

    List<Columns> LocalData = new List<Columns>
    {
        new Columns() { ID= "OrderID", Value= "OrderID" },
        new Columns() { ID= "CustomerID", Value= "CustomerID" },
        new Columns() { ID= "ShipCity", Value= "ShipCity" },
        new Columns() { ID= "ShipName", Value= "ShipName" },
    };

    public class Columns
    {
        public string ID { get; set; }
        public string Value { get; set; }
    }

    public async Task GroupColumn()
    {
        await Grid.GroupColumnAsync(DropDownValue);
    }

    public async Task UnGroupColumn()
    {
        await Grid.UngroupColumnAsync(DropDownValue);
    }
}

{% endhighlight %}

{% highlight c# tabtitle="OrderData.cs" %}

public class OrderData
{
    public static List<OrderData> Orders = new List<OrderData>();
        
    public OrderData() {}
    public OrderData(int? OrderID,string CustomerID,string ShipCity, string ShipName)
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
                Orders.Add(new OrderData(10248, "VINET", "Reims", "Vins et alcools Chevali"));
                Orders.Add(new OrderData(10249, "TOMSP", "Münster", "Toms Spezialitäten"));
                Orders.Add(new OrderData(10250, "HANAR", "Rio de Janeiro", "Hanari Carnes"));
                Orders.Add(new OrderData(10251, "VICTE", "Lyon", "Victuailles en stock"));
                Orders.Add(new OrderData(10252, "SUPRD", "Charleroi", "Suprêmes délices"));
                Orders.Add(new OrderData(10253, "HANAR", "Lyon", "Hanari Carnes"));
                Orders.Add(new OrderData(10254, "CHOPS", "Rio de Janeiro", "Chop-suey Chinese"));
                Orders.Add(new OrderData(10255, "RICSU", "Münster", "Richter Supermarkt"));
                Orders.Add(new OrderData(10256, "WELLI", "Reims", "Wellington Import"));
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/htBgCiNGTssPWSDl?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Expand or collapse externally

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid supports external control of grouped row visibility through programmatic expand and collapse. This functionality can be integrated using the DataGrid's methods to manage grouped data display dynamically.

### Expand or collapse all grouped rows

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid enables programmatic expand and collapse of all grouped rows using the [ExpandAllGroupAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ExpandAllGroupAsync) and [CollapseAllGroupAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_CollapseAllGroupAsync) methods.

In the example below, the [Toggle Switch Button](https://blazor.syncfusion.com/documentation/toggle-switch-button/getting-started-webapp) is used to control the visibility of grouped rows. When toggled, the `ValueChange` event triggers the appropriate method to expand or collapse all groups accordingly.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons

<div style="display:flex;gap:10px">
    <label>  Expand or collapse rows </label>
    <SfSwitch OffLabel="OFF" OnLabel="ON" ValueChange="Change" TChecked="bool?"></SfSwitch>
</div>

<SfGrid @ref="Grid" DataSource="@GridData"  AllowGrouping="true" Height="315px">
    <GridGroupSettings ShowDropArea="false" Columns="@columns"></GridGroupSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="90"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipName) HeaderText="Ship Name" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<OrderData> GridData { get; set; }
    SfGrid<OrderData>? Grid { get; set; }
    public string[] columns = (new string[] { "CustomerID", "ShipCity" });
    public bool IsShow { get; set; } = true;


    protected override void OnInitialized()
    {
        GridData = OrderData.GetAllRecords();
    }

    private async Task Change(Syncfusion.Blazor.Buttons.ChangeEventArgs<bool?> args)
    {
        if (args.Checked == true)
        {
            await Grid.CollapseAllGroupAsync();
        }
        else
        {
           await Grid.ExpandAllGroupAsync();
        }
    }
}

{% endhighlight %}

{% highlight c# tabtitle="OrderData.cs" %}

 
public class OrderData
{
    public static List<OrderData> Orders = new List<OrderData>(); 
    public OrderData() {}

    public OrderData(int? OrderID,string CustomerID,string ShipCity, string ShipName)
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
                Orders.Add(new OrderData(10248, "VINET", "Reims", "Vins et alcools Chevali"));
                Orders.Add(new OrderData(10249, "TOMSP", "Münster", "Toms Spezialitäten"));
                Orders.Add(new OrderData(10250, "HANAR", "Rio de Janeiro", "Hanari Carnes"));
                Orders.Add(new OrderData(10251, "VICTE", "Lyon", "Victuailles en stock"));
                Orders.Add(new OrderData(10252, "SUPRD", "Charleroi", "Suprêmes délices"));
                Orders.Add(new OrderData(10253, "HANAR", "Lyon", "Hanari Carnes"));
                Orders.Add(new OrderData(10254, "CHOPS", "Rio de Janeiro", "Chop-suey Chinese"));
                Orders.Add(new OrderData(10255, "RICSU", "Münster", "Richter Supermarkt"));
                Orders.Add(new OrderData(10256, "WELLI", "Reims", "Wellington Import"));
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/BZVgMWDwTMzdeJff?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Clear grouping 

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid provides a [ClearGroupingAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ClearGroupingAsync) method to remove all grouped columns programmatically. This is useful for resetting the DataGrid to an ungrouped state.

The following example demonstrates how to execute `ClearGroupingAsync` through an external button click.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons

<SfButton OnClick="ClearGrouping"> Clear Grouping</SfButton>

<SfGrid @ref="Grid" DataSource="@GridData"  AllowGrouping="true" Height="315px">
    <GridGroupSettings Columns="@columns"></GridGroupSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipName) HeaderText="Ship Name" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<OrderData> GridData { get; set; }
    SfGrid<OrderData>? Grid { get; set; }
    public string[] columns = (new string[] { "CustomerID", "ShipCity" });

    protected override void OnInitialized()
    {
        GridData = OrderData.GetAllRecords();
    }

    private async Task ClearGrouping()
    {
        await Grid.ClearGroupingAsync();
    }
}

{% endhighlight %}

{% highlight c# tabtitle="OrderData.cs" %}

public class OrderData
{
    public static List<OrderData> Orders = new List<OrderData>();
        
    public OrderData() { }
    public OrderData(int? OrderID,string CustomerID,string ShipCity, string ShipName)
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
                Orders.Add(new OrderData(10248, "VINET", "Reims", "Vins et alcools Chevali"));
                Orders.Add(new OrderData(10249, "TOMSP", "Münster", "Toms Spezialitäten"));
                Orders.Add(new OrderData(10250, "HANAR", "Rio de Janeiro", "Hanari Carnes"));
                Orders.Add(new OrderData(10251, "VICTE", "Lyon", "Victuailles en stock"));
                Orders.Add(new OrderData(10252, "SUPRD", "Charleroi", "Suprêmes délices"));
                Orders.Add(new OrderData(10253, "HANAR", "Lyon", "Hanari Carnes"));
                Orders.Add(new OrderData(10254, "CHOPS", "Rio de Janeiro", "Chop-suey Chinese"));
                Orders.Add(new OrderData(10255, "RICSU", "Münster", "Richter Supermarkt"));
                Orders.Add(new OrderData(10256, "WELLI", "Reims", "Wellington Import"));
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/VNhKsMDwJCOGDhcq?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Grouping events

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid provides two key events for handling grouping operations. These events enable the integration of custom logic before and after a grouping action:

- [Grouping](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_Grouping): Triggered before the grouping or ungrouping action is performed in the DataGrid. Use this to perform operations or cancel the action. The event parameters include the current grouping column name and the action.
- [Grouped](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_Grouped): Triggered after the grouping or ungrouping action is performed in the Grid. Use this to run post-action logic. The event parameters include the current grouping column name and the action.

The following example demonstrates how to cancel grouping for the **"Order ID"** column using `Grouping` and display a status message via `Grouped`.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

@if (show == true)
{
    <div style="text-align : center; color: red">
        <span> Group action completed for @columnName column</span>
    </div>
    <br />
}

<SfGrid @ref="Grid" DataSource="@GridData"  AllowGrouping="true" Height="260px">
    <GridEvents Grouping="GroupingHandler" Grouped="GroupedHandler" TValue="OrderData"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="90"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipName) HeaderText="Ship Name" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>


@code {
    public List<OrderData> GridData { get; set; }
    SfGrid<OrderData>? Grid { get; set; }
    public bool show { get; set; } = false;

    public string columnName { get; set; }
    public string requesttype { get; set; }

    protected override void OnInitialized()
    {
        GridData = OrderData.GetAllRecords();
    }

    public async Task GroupingHandler(GroupingEventArgs args)
    {
        if (args.ColumnName == "OrderID")
        {
            args.Cancel = true;
        }
    }

    public async Task GroupedHandler(GroupedEventArgs args)
    {
        columnName = args.ColumnName;
        show = true;
    }
}

{% endhighlight %}

{% highlight c# tabtitle="OrderData.cs" %}

public class OrderData
{
    public static List<OrderData> Orders = new List<OrderData>(); 
    public OrderData() {}

    public OrderData(int? OrderID,string CustomerID,string ShipCity, string ShipName)
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
                Orders.Add(new OrderData(10248, "VINET", "Reims", "Vins et alcools Chevali"));
                Orders.Add(new OrderData(10249, "TOMSP", "Münster", "Toms Spezialitäten"));
                Orders.Add(new OrderData(10250, "HANAR", "Rio de Janeiro", "Hanari Carnes"));
                Orders.Add(new OrderData(10251, "VICTE", "Lyon", "Victuailles en stock"));
                Orders.Add(new OrderData(10252, "SUPRD", "Charleroi", "Suprêmes délices"));
                Orders.Add(new OrderData(10253, "HANAR", "Lyon", "Hanari Carnes"));
                Orders.Add(new OrderData(10254, "CHOPS", "Rio de Janeiro", "Chop-suey Chinese"));
                Orders.Add(new OrderData(10255, "RICSU", "Münster", "Richter Supermarkt"));
                Orders.Add(new OrderData(10256, "WELLI", "Reims", "Wellington Import"));
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/VDLpNCtffrjjtSYQ?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}


## See Also

- [Exporting grouped records](https://blazor.syncfusion.com/documentation/datagrid/excel-exporting#exporting-grouped-records)

> Refer to the [Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) feature tour for an overview of capabilities. Explore the [Blazor DataGrid example](https://blazor.syncfusion.com/demos/datagrid/overview?theme=bootstrap5) to learn how to present and manipulate data.