---
layout: post
title: Grouping in Blazor DataGrid | Syncfusion
description: Checkout and learn here all about Grouping in Syncfusion Blazor DataGrid component and much more details.
platform: Blazor
control: DataGrid
documentation: ug
---

# Grouping in Blazor DataGrid

The grouping feature in the Syncfusion Blazor DataGrid allows you to organize data into a hierarchical structure, making it easier to expand and collapse records. You can group the columns by simply dragging and dropping the column header to the group drop area. To enable grouping in the Grid, you need to set the [AllowGrouping](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowGrouping) property to **true**. Additionally, you can customize the grouping options using the [GridGroupSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_GroupSettings).

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

> * You can group and ungroup columns by using the [GroupColumnAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_GroupColumnAsync_System_String_) and [UngroupColumnAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_UngroupColumnAsync_System_String_) methods.
> * To disable grouping for a particular column, set the [AllowGrouping](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_AllowGrouping) to **false** in **GridColumn**.

## Initial group

To enable initial grouping in the Syncfusion Blazor DataGrid, you can use the [GridGroupSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridGroupSettings.html) property and set the GridGroupSettings [Columns](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridGroupSettings.html#Syncfusion_Blazor_Grids_GridGroupSettings_Columns) property to a string array of column names(field of the column) that you want to group by. This feature is particularly useful when working with large datasets, as it allows you to quickly organize and analyze the data based on specific criteria.

The following example demonstrates how to set an initial grouping for the **CustomerID** and **ShipCity** columns during the initial rendering Grid, by using the `GridGroupSettings` of the `Columns` property.

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

> You can group by multiple columns by specifying a string array of column names in the `Columns` property of the `GridGroupSettings`.

## Prevent grouping for particular column

The Syncfusion Blazor DataGrid provides the ability to prevent grouping for a particular column. This can be useful when you have certain columns that you do not want to be included in the grouping process. It can be achieved by setting the [AllowGrouping](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_AllowGrouping) property of the particular `Column` to **false**. 

The following example demonstrates, how to disable grouping for **CustomerID** column:

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

{% previewsample "https://blazorplayground.syncfusion.com/embed/LthUWWNcBWKrghqe?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap55" %}

## Hide drop area

By default, the Syncfusion Blazor DataGrid provides a drop area for grouping columns. This drop area allows you to drag and drop columns to group and ungroup them. However, in some cases, you may want to prevent ungrouping or further grouping a column after initial grouping.

To hide the drop area in the Grid, you can set the `GridGroupSettings` of the [ShowDropArea](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridGroupSettings.html#Syncfusion_Blazor_Grids_GridGroupSettings_ShowDropArea) property to **false**. 


The following example, the [Blazor Toggle Switch Button](https://blazor.syncfusion.com/documentation/toggle-switch-button/getting-started) is added to hide or show the drop area. When the switch is toggled, the [ValueChange](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.ChangeEventArgs-1.html) event is triggered and the `GridGroupSettings` of the `ShowDropArea` property of the Grid is updated accordingly.

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

> By default, the group drop area will be shown only if there is at least one column available to group.

## Show the grouped column

The Syncfusion Blazor DataGrid has a default behavior where the grouped column is hidden, to provide a cleaner and more focused view of your data. However, if you prefer to show the grouped column in the Grid, you can achieve this by setting the `GridGroupSettings` of the [ShowGroupedColumn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridGroupSettings.html#Syncfusion_Blazor_Grids_GridGroupSettings_ShowGroupedColumn) property to **true**.

In the following example, the [Blazor Toggle Switch Button](https://blazor.syncfusion.com/documentation/toggle-switch-button/getting-started) is added to hide or show the grouped columns. When the switch is toggled, the [ValueChange](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.ChangeEventArgs-1.html) event is triggered and the `GridGroupSettings` of the `showGroupedColumn` property of the Grid is updated accordingly.

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
 
The Syncfusion Blazor DataGrid offers the ability to persist the expand or collapse state of grouped rows across various data operations such as paging, sorting, filtering, and editing. By default, these operations reset the grouped rows to their initial collapsed or expanded state. To retain the current state of grouped rows and ensure a consistent user experience, set the [GridGroupSettings.PersistGroupState](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridGroupSettings.html#Syncfusion_Blazor_Grids_GridGroupSettings_PersistGroupState) property to **true**. This also applies when using external grouping methods like [ExpandAllGroupAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ExpandAllGroupAsync) and [CollapseAllGroupAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_CollapseAllGroupAsync).

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

By default, grouped columns are sorted in ascending order. However, you can sort them in descending order during initial grouping by setting the [Field](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSortColumn.html#Syncfusion_Blazor_Grids_GridSortColumn_Field) and [Direction](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSortColumn.html#Syncfusion_Blazor_Grids_GridSortColumn_Direction) in the `GridSortSettings` of the [Columns](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSortSettings.html#Syncfusion_Blazor_Grids_GridSortSettings_Columns) property.

The following example demonstrates how to sort the **CustomerID** column by setting the `GridSortSettings` of the `Columns` property to **Descending** during the initial grouping of the Grid.

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

By default, columns are grouped by the data or value present for the particular row. However, you can also group numeric or datetime columns based on the specified format. To enable this feature, you need to set the [EnableGroupByFormat](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_EnableGroupByFormat)
property of the corresponding Grid column. This feature allows you to group numeric or datetime columns based on a specific format.

The following example demonstrates how to perform a group action using the `EnableGroupByFormat` property for the  **OrderDate** and **Freight** columns of the Grid:

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

> Numeric columns can be grouped based on formats such as currency or percentage, while datetime columns can be grouped based on specific date or time formats.

## Collapse all grouped rows at initial rendering

The Syncfusion Blazor DataGrid offers a convenient feature to expand or collapse grouped rows, allowing you to control the visibility of grouped data. The option is useful when dealing with a large dataset that contains many groups, and there is a need to provide a summarized view by initially hiding the details.

To collapse all grouped rows at the initial rendering of the Grid using the [DataBound](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_DataBound) event along with the  [CollapseAllGroupAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_CollapseAllGroupAsync) method.

The following example demonstrates how to collapse all grouped rows at the initial rendering:

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

> The collapse all approach is suggested for a limited number of records since collapsing every grouped record takes some time. If you have a large dataset, it is recommended to use [lazy-load grouping](https://blazor.syncfusion.com/documentation/datagrid/lazy-load-grouping). This approach is also applicable for the [ExpandAllGroupAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ExpandAllGroupAsync) method.

## Group or Ungroup column externally

By default, the Syncfusion Blazor DataGrid supports interaction-oriented column grouping, where users manually group columns by dragging and dropping them into the grouping area of the Grid. The Grid provides an ability to group and ungroup a column using [GroupColumnAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_GroupColumnAsync_System_String_) and [UngroupColumnAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_UngroupColumnAsync_System_String_) methods. These methods provide a programmatic approach to perform column grouping and ungrouping.

The following example demonstrates how to group and ungroup the columns in a Grid. It utilizes the [DropDownList](https://blazor.syncfusion.com/documentation/dropdown-list/getting-started) to select the column. When an external button is clicked, the `GroupColumnAsync` and `UngroupColumnAsync` methods are called to group or ungroup the selected column.

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

The Syncfusion Blazor DataGrid offers a convenient feature to expand or collapse grouped rows, allowing you to control the visibility of grouped data. This section will provide guidance on enabling this functionality and integrating it into your application using the Grid properties and methods.

### Expand or collapse all grouped rows

The Syncfusion Blazor DataGrid provides an ability to expand or collapse grouped rows using [ExpandAllGroupAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ExpandAllGroupAsync) and [CollapseAllGroupAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_CollapseAllGroupAsync) methods respectively.

In the following example, the [Blazor Toggle Switch Button](https://blazor.syncfusion.com/documentation/toggle-switch-button/getting-started) is added to expand or collapse grouped rows. When the switch is toggled, the [ValueChange](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.ChangeEventArgs-1.html) event is triggered and the `ExpandAllGroupAsync` and `CollapseAllGroupAsync` methods are called to expand or collapse grouped rows.

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

The clear grouping feature in the Syncfusion Blazor DataGrid allows you to removing all the grouped columns from the Grid. This feature provides a convenient way to clear the grouping of columns in your application.

To clear all the grouped columns in the Grid, you can utilize the [ClearGroupingAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ClearGroupingAsync) method of the Grid.

The following example demonstrates how to clear the grouping using `ClearGroupingAsync` method in the external button click.

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

The Syncfusion Blazor DataGrid provides two events that are triggered during the group action such as [Grouping](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_Grouping) and [Grouped](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_Grouped). The `Grouping` event is triggered before the group action starts, and the `Grouped` event is triggered after the group action is completed. You can use these events to perform any custom action based on the grouping.

1. **Grouping Event**: `Grouping` event is triggered before the grouping action or un-grouping action is performed in the Grid. It provides a way to perform any necessary operations before the group action takes place. This event provides a parameter that contains the current sorting column name, and action.

2. **Grouped Event**: `Grouped` event is triggered after the grouping action or un-grouping action is performed in the Grid. It provides a way to perform any necessary operations after the group action has taken place. This event provides a parameter that contains the current sorting column name, and action.

The following example demonstrates how the `Grouping` and `Grouped` events work when grouping is performed. The `Grouping` event event is used to cancel the grouping of the **OrderID** column. The `Grouped` event is used to display a message

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

* [Exporting grouped records](https://blazor.syncfusion.com/documentation/datagrid/excel-exporting#exporting-grouped-records)

> You can refer to our [Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) feature tour page for its groundbreaking feature representations. You can also explore our [Blazor DataGrid example](https://blazor.syncfusion.com/demos/datagrid/overview?theme=bootstrap5) to understand how to present and manipulate data.