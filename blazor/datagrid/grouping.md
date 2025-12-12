---
layout: post
title: Grouping in Blazor DataGrid | Syncfusion
description: Learn how to group data, manage drop area visibility, persist group state, and sort or format grouped columns in the Syncfusion Blazor DataGrid.
platform: Blazor
control: DataGrid
documentation: ug
---

# Grouping in Blazor DataGrid

The grouping feature in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid organizes rows into groups, enabling users to expand or collapse related records. Columns can be grouped by dragging the column header into the group drop area. Enable grouping by setting the [AllowGrouping](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowGrouping) property to **true**. Configure behavior using [GridGroupSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_GroupSettings).

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

> - Group and ungroup columns programmatically using [GroupColumnAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_GroupColumnAsync_System_String_) and [UngroupColumnAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_UngroupColumnAsync_System_String_).
> - To prevent grouping for a specific column, set [GridColumn.AllowGrouping](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_AllowGrouping) to **false**.

## Initial group

Configure initial grouping in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid by setting the [Columns](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridGroupSettings.html#Syncfusion_Blazor_Grids_GridGroupSettings_Columns) property of [GridGroupSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridGroupSettings.html) to an array of field names. This pre-groups the specified columns on initial render to accelerate data analysis.

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

> Group multiple columns by listing their field names in the `Columns` property of `GridGroupSettings`.

## Prevent grouping for particular column

To prevent grouping for a specific column, set [GridColumn.AllowGrouping](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_AllowGrouping) to **false**. This disables the drag-to-group feature for that column, while allowing grouping for other columns.

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

By default, the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid displays a drop area for grouping columns. In scenarios where further grouping or ungrouping should be restricted after initial grouping, hide the drop area.

To hide the drop area, set the [ShowDropArea](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridGroupSettings.html#Syncfusion_Blazor_Grids_GridGroupSettings_ShowDropArea) property of `GridGroupSettings` to `false`.

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

By default, grouped columns are hidden to keep the view focused. To display grouped columns, set [ShowGroupedColumn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridGroupSettings.html#Syncfusion_Blazor_Grids_GridGroupSettings_ShowGroupedColumn) to **true** in `GridGroupSettings`.


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

By default, grouped columns are sorted in ascending order. To sort in descending order during initial grouping, set the [Field](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSortColumn.html#Syncfusion_Blazor_Grids_GridSortColumn_Field) and [Direction](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSortColumn.html#Syncfusion_Blazor_Grids_GridSortColumn_Direction) in `GridSortSettings.Columns`.

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

By default, grouping is performed based on the raw values. Alternatively, numeric or datetime columns can be grouped based on a specified display format by setting [EnableGroupByFormat](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_EnableGroupByFormat) on the corresponding column.

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
    public OrderData() {
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

> Numeric columns can be grouped based on formats such as currency or percentage, and datetime columns can be grouped based on date or time formats.

## Collapse all grouped rows at initial rendering

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid can expand or collapse grouped rows to control the visibility of grouped data. This is useful for summarizing large datasets by initially hiding details.

To collapse all grouped rows at initial rendering, use the [DataBound](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_DataBound) event with the [CollapseAllGroupAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_CollapseAllGroupAsync) method.

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

> Collapsing every grouped record can take time on large datasets. For large data, use [lazy-load grouping](https://blazor.syncfusion.com/documentation/datagrid/lazy-load-grouping). The same consideration applies to [ExpandAllGroupAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ExpandAllGroupAsync).

## Group or Ungroup column externally

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid supports interaction-based grouping by dragging headers to the grouping area. It also supports programmatic grouping and ungrouping via [GroupColumnAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_GroupColumnAsync_System_String_) and [UngroupColumnAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_UngroupColumnAsync_System_String_).

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

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid can expand or collapse grouped rows programmatically to control the visibility of grouped data.

### Expand or collapse all grouped rows

Use [ExpandAllGroupAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ExpandAllGroupAsync) and [CollapseAllGroupAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_CollapseAllGroupAsync) to expand or collapse all grouped rows.

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

The clear grouping feature in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid removes all grouped columns from the Grid, providing a quick way to reset grouping.

To clear all grouped columns, call the [ClearGroupingAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ClearGroupingAsync) method.

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

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid provides two events for the group action: [Grouping](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_Grouping) and [Grouped](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_Grouped). `Grouping` is triggered before the action starts, and `Grouped` is triggered after completion. These events support custom logic based on grouping.

1. **Grouping Event**: Triggered before the grouping or ungrouping action is performed in the Grid. Use this to perform operations or cancel the action. The event parameters include the current grouping column name and the action.

2. **Grouped Event**: Triggered after the grouping or ungrouping action is performed in the Grid. Use this to run post-action logic. The event parameters include the current grouping column name and the action.

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