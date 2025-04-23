---
layout: post
title: State Management in Blazor DataGrid Component | Syncfusion
description: Checkout and learn here all about State Management in Syncfusion Blazor DataGrid component and more.
platform: Blazor
control: DataGrid
documentation: ug
---

# State Management in Blazor DataGrid 

State management in the Grid allows you to maintain the Grid's state even after a browser refresh or when navigating to a different page within the same browser session. This feature is particularly useful for retaining the grid's configuration and data even after a page reload.

To enable state persistence in the Grid, you can utilize the [EnablePersistence](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_EnablePersistence) property. When this property is set to **true**, the grid will automatically save its state in the browser's [LocalStorage](https://www.w3schools.com/html/html5_webstorage.asp#), ensuring that the state is preserved across page reloads.

```cshtml
<SfGrid DataSource="@Orders" EnablePersistence="true">
```

> The grid will store the state using the combination of the component name and component ID in the storage. For example, if the component name is **grid** and the ID is **OrderDetails**, the state will be stored as **gridOrderDetails**.


When enabling state persistence, the following grid settings will persist in the local storage.

| Grid Settings    | Properties persist                                                                                                                                                                                                                                                                                                                | Ignored properties                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        |
| ---------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| PageSettings     | CurrentPage<br> PageCount<br> PageSize<br> PageSizes                                                                                                                                                                                                                                                       | Template<br> EnableQueryString                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           |
| GroupSettings    | AllowReordering<br> Columns<br> DisablePageWiseAggregates<br> EnableLazyLoading<br> ShowDropArea<br> ShowGroupedColumn<br> ShowToggleButton<br> ShowUngroupButton                                                                                                                                                                 | CaptionTemplate                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           |
| Columns          | AllowEditing<br> AllowFiltering<br> AllowGrouping<br> AllowReordering<br> AllowResizing<br> AllowSearching<br> AllowSorting<br> AutoFit<br> DisableHtmlEncode<br> EnableGroupByFormat<br> Field<br> ForeignKeyField<br> Index<br> ShowColumnMenu<br> ShowInColumnChooser<br> Type<br> Uid<br> Visible<br> Width | ClipMode<br> Commands<br> CustomAttributes<br> DataSource<br> DefaultValue<br> DisplayAsCheckBox<br> Edit<br> EditTemplate<br> EditType<br> Filter<br> filterItemTemplate<br> FilterTemplate<br> ForeignKeyValue<br> Format<br> Freeze<br> HeaderTemplate<br> HeaderText<br> HeaderTextAlign<br> HeaderValueAccessor<br> HideAtMedia<br> IsFrozen<br> IsIdentity<br> IsPrimaryKey<br> MaxWidth<br> MinWidth<br> SortComparer<br> Template<br> TextAlign<br> ValidationRules |
| SortSettings     | -                                                                                                                                                                                                                                                                                                                                 | -                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         |
| FilterSettings   | -                                                                                                                                                                                                                                                                                                                                 | -                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         |
| SearchSettings   | -                                                                                                                                                                                                                                                                                                                                 | -                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         |
| SelectedRowIndex | -                                                                                                                                                                                                                                                                                                                                 | -                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         |


The grid will persist only the last selected row index.

## Restore initial Grid state

In the Syncfusion Blazor Grid, you have the capability to restore the grid to its initial state, reverting all changes and configurations made during the interaction. This feature can be particularly useful when you want to reset the grid to its original settings, eliminating any applied filters, sorting, or column reordering.

Here are the steps to reset the grid to its initial state, even when the [EnablePersistence](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_EnablePersistence) property is enabled:

You can use [ResetPersistData](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ResetPersistData) method to reset grid state to its original state. This will clear persisted data in window local storage and renders grid with its original property values.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons

<SfButton OnClick="@(async() =>await Grid.ResetPersistDataAsync())">Restore Grid State</SfButton>

<SfGrid @ref="Grid" ID="OrderDetails" DataSource="@Orders" Height="315" AllowPaging="true" AllowFiltering="true" AllowGrouping="true" AllowSorting="true">
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120" IsPrimaryKey="true" />
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer Name" Width="150" />
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="120" />
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="150" />
    </GridColumns>
</SfGrid>

@code {
    private SfGrid<OrderData> Grid;
    public List<OrderData> Orders { get; set; }

    public string _state;
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/rZrKsMZhrntSJwyp?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Clearing local storage

Another method to reset the grid is by clearing the local storage associated with the grid component. This action removes any stored state information, allowing the grid to return to its original configuration.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons
@inject IJSRuntime JS
<SfButton CssClass="e-primary" OnClick="RestoreGridState">Restore Grid State</SfButton>
<SfGrid ID="OrderDetails" @ref="Grid" DataSource="@Orders" EnablePersistence="true" AllowPaging="true" AllowFiltering="true" Height="230">
    <GridColumns>
        <GridColumn Field=@nameof(OrderDetails.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120" />
        <GridColumn Field=@nameof(OrderDetails.CustomerID) HeaderText="Customer ID" Width="150" />
        <GridColumn Field=@nameof(OrderDetails.ShipCity) HeaderText="Ship City" Width="150" />
        <GridColumn Field=@nameof(OrderDetails.ShipName) HeaderText="Ship Name" Width="150" />
    </GridColumns>
</SfGrid>
@code {
    private SfGrid<OrderDetails> Grid;

    public List<OrderDetails> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = OrderDetails.GetAllRecords();
    }

    private async Task RestoreGridState()
    {
        await Grid.ResetPersistDataAsync();
        await JS.InvokeVoidAsync("localStorage.setItem", "Grid", ""); // "Grid" = ID used in SfGrid.
        await JS.InvokeVoidAsync("location.reload");
    }
}

{% endhighlight %}

{% highlight c# tabtitle="OrderDetails.cs" %}

public class OrderDetails
{
    public static List<OrderDetails> order = new List<OrderDetails>();
    public OrderDetails(int OrderID, string CustomerId, string ShipCity, string ShipName)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerId;
        this.ShipCity = ShipCity;
        this.ShipName = ShipName;
    }
    public static List<OrderDetails> GetAllRecords()
    {
        if (order.Count == 0)
        {
            order.Add(new OrderDetails(10248, "VINET", "Reims", "Vins et alcools Chevalier"));
            order.Add(new OrderDetails(10249, "TOMSP", "Münster", "Toms Spezialitäten"));
            order.Add(new OrderDetails(10250, "HANAR", "Rio de Janeiro", "Hanari Carnes"));
            order.Add(new OrderDetails(10251, "VICTE", "Lyon", "Victuailles en stock"));
            order.Add(new OrderDetails(10252, "SUPRD", "Charleroi", "Suprêmes délices"));
            order.Add(new OrderDetails(10253, "HANAR", "Rio de Janeiro", "Hanari Carnes"));
            order.Add(new OrderDetails(10254, "CHOPS", "Bern", "Chop-suey Chinese"));
            order.Add(new OrderDetails(10255, "RICSU", "Genève", "Richter Supermarkt"));
            order.Add(new OrderDetails(10256, "WELLI", "Resende", "Wellington Importadora"));
            order.Add(new OrderDetails(10257, "HILAA", "San Cristóbal", "HILARION-Abastos"));
            order.Add(new OrderDetails(10258, "ERNSH", "Graz", "Ernst Handel"));
            order.Add(new OrderDetails(10259, "CENTC", "México D.F.", "Centro comercial Moctezuma"));
            order.Add(new OrderDetails(10260, "OTTIK", "Köln", "Ottilies Käseladen"));
            order.Add(new OrderDetails(10261, "QUEDE", "Rio de Janeiro", "Que Delícia"));
            order.Add(new OrderDetails(10262, "RATTC", "Albuquerque", "Rattlesnake Canyon Grocery"));
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/LtVItfhCIjLifBTr?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Restore to specific state version

Syncfusion Blazor Grid supports state persistence, allowing to save and restore grid configurations such as column settings, filters, sorting, grouping, paging, and more. This example demonstrates how to implement version-based state persistence using localStorage.

In this sample, each version represents a unique saved grid configuration (or state). When a version button is clicked:

1. The current grid state is saved to localStorage using the existing version key.

2. The grid switches to the selected version.

3. If persisted data exists for the selected version, it is applied to the grid.

4. If no data is found, a new state will be stored the next time the grid is modified.

To implement version-based persistence in Syncfusion Blazor Grid, first add the necessary components: use `SfGrid` to display the data and `SfButton` components to allow users to select different version states. The grid's **PersistenceKey** is set dynamically based on the selected version (e.g., gridOrderDetails_v.1), ensuring each version maintains a unique state in localStorage. The core logic for switching versions is handled in the `ChangeVersion` method. This method saves the current grid state using [GetPersistDataAsync()](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_GetPersistDataAsync) before switching versions. It then attempts to load the state associated with the selected version using [SetPersistDataAsync()](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_SetPersistDataAsync_System_String_). If a persisted state is available, it is applied to the grid; otherwise, a message is displayed indicating that no saved state exists and a new state will be stored going forward.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons
@inject IJSRuntime JS

<div class="mb-3">
    <SfButton CssClass="e-primary m-1" OnClick="@(() => ChangeVersion("v.1"))">Version 1</SfButton>
    <SfButton CssClass="e-primary m-1" OnClick="@(() => ChangeVersion("v.2"))">Version 2</SfButton>
    <SfButton CssClass="e-primary m-1" OnClick="@(() => ChangeVersion("v.3"))">Version 3</SfButton>
</div>
<div style="text-align: center; color: red">
    <span>@Message</span>
</div>
@if (!string.IsNullOrEmpty(CurrentVersion))
{
    <SfGrid ID="OrderDetails" @ref="Grid" DataSource="@Orders" EnablePersistence="true" PersistenceKey="@($"gridOrderDetails_{CurrentVersion}")"  AllowPaging="true" AllowFiltering="true" AllowSorting="true" AllowGrouping="true" AllowReordering="true" Height="315">
    <GridColumns>
        <GridColumn Field=@nameof(OrderDetails.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120" />
        <GridColumn Field=@nameof(OrderDetails.CustomerID) HeaderText="Customer ID" Width="150" />
        <GridColumn Field=@nameof(OrderDetails.ShipCity) HeaderText="Ship City" Width="150" />
        <GridColumn Field=@nameof(OrderDetails.ShipName) HeaderText="Ship Name" Width="150" />
    </GridColumns>
</SfGrid>}
@code {
private SfGrid<OrderDetails> Grid;
public List<OrderDetails> Orders { get; set; }
public string CurrentVersion { get; set; } = "v.0";
public string Message { get; set; }
protected override void OnInitialized()
{
    Orders = OrderDetails.GetAllRecords();
}

 private async Task ChangeVersion(string version)
 {
     // Save current state to localStorage before switching.
     if (Grid != null)
     {
         var currentData = await Grid.GetPersistDataAsync();
         await JS.InvokeVoidAsync("localStorage.setItem", $"gridOrderDetails_{CurrentVersion}", currentData);
     }

     // Switch to new version.
     CurrentVersion = version;

     // Load new version's data if available.
     var saved = await JS.InvokeAsync<string>("localStorage.getItem", $"gridOrderDetails_{version}");
     if (!string.IsNullOrEmpty(saved))
     {
         await Grid.SetPersistDataAsync(saved);
         Message = $"Grid state restored to {version}";
     }
     else
     {
         Message = $"No saved state found for {version}. New state will be stored.";
     }

     StateHasChanged();
 }

}

{% endhighlight %}

{% highlight c# tabtitle="OrderDetails.cs" %}

public class OrderDetails
{
    public static List<OrderDetails> order = new List<OrderDetails>();
    public OrderDetails(int OrderID, string CustomerId, string ShipCity, string ShipName)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerId;
        this.ShipCity = ShipCity;
        this.ShipName = ShipName;
    }
    public static List<OrderDetails> GetAllRecords()
    {
        if (order.Count == 0)
        {
            order.Add(new OrderDetails(10248, "VINET", "Reims", "Vins et alcools Chevalier"));
            order.Add(new OrderDetails(10249, "TOMSP", "Münster", "Toms Spezialitäten"));
            order.Add(new OrderDetails(10250, "HANAR", "Rio de Janeiro", "Hanari Carnes"));
            order.Add(new OrderDetails(10251, "VICTE", "Lyon", "Victuailles en stock"));
            order.Add(new OrderDetails(10252, "SUPRD", "Charleroi", "Suprêmes délices"));
            order.Add(new OrderDetails(10253, "HANAR", "Rio de Janeiro", "Hanari Carnes"));
            order.Add(new OrderDetails(10254, "CHOPS", "Bern", "Chop-suey Chinese"));
            order.Add(new OrderDetails(10255, "RICSU", "Genève", "Richter Supermarkt"));
            order.Add(new OrderDetails(10256, "WELLI", "Resende", "Wellington Importadora"));
            order.Add(new OrderDetails(10257, "HILAA", "San Cristóbal", "HILARION-Abastos"));
            order.Add(new OrderDetails(10258, "ERNSH", "Graz", "Ernst Handel"));
            order.Add(new OrderDetails(10259, "CENTC", "México D.F.", "Centro comercial Moctezuma"));
            order.Add(new OrderDetails(10260, "OTTIK", "Köln", "Ottilies Käseladen"));
            order.Add(new OrderDetails(10261, "QUEDE", "Rio de Janeiro", "Que Delícia"));
            order.Add(new OrderDetails(10262, "RATTC", "Albuquerque", "Rattlesnake Canyon Grocery"));
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/hZLIXJhrJGykpckS?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}


# State Management in Blazor DataGrid Component

State management allows users to save and load grid state. The grid will use user-provided state to render instead of its properties provided declaratively.

Below properties can be saved and loaded into grid later.

Property|
-----|
Columns |
GridFilterSettings |
GridSortSettings |
GridGroupSettings |
GridPageSettings |

## Enabling persistence in Grid

State persistence allows the Grid to retain the current grid state in the browser local storage for state maintenance. This action is handled through the `EnablePersistence` property which is set to false by default. When it is set to true, some properties of the Grid will be retained even after refreshing the page.

N> The state will be persisted based on **ID** property. So, it is recommended to explicitly set the **ID** property for Grid.

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid ID="Grid" DataSource="@Orders" Height="315" EnablePersistence="true" AllowPaging="true" AllowFiltering="true" AllowGrouping="true" AllowSorting="true">
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText="Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
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

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }
}
```

You can use [ResetPersistData](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ResetPersistData) method to reset grid state to its original state. This will clear persisted data in window local storage and renders grid with its original property values.

## Handling grid state manually

You can handle the grid's state manually by using in-built state persistence methods. You can use [GetPersistDataAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_GetPersistDataAsync), [SetPersistDataAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_SetPersistDataAsync_System_String_), [ResetPersistDataAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ResetPersistDataAsync) methods of grid to save, load and reset the Grid's persisted state manually. [GetPersistDataAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_GetPersistDataAsync) method will return grid current state as a string value, which is suitable for sending them over network and storing in data bases.

```cshtml
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons

<SfButton OnClick="@(async () => _state = await Grid.GetPersistDataAsync())">Save State</SfButton>
<SfButton OnClick="@(async() => await Grid.SetPersistDataAsync(_state))">Set State</SfButton>
<SfButton OnClick="@(async() =>await Grid.ResetPersistDataAsync())">Reset State</SfButton>

<SfGrid @ref="Grid" ID="GridOneTwo" DataSource="@Orders" Height="315" AllowPaging="true" AllowFiltering="true" AllowGrouping="true" AllowSorting="true">
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText="Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    SfGrid<Order> Grid;

    public List<Order> Orders { get; set; }

    public string _state;

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

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }
}
```

N> You can refer to our [Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) feature tour page for its groundbreaking feature representations. You can also explore our [Blazor DataGrid example](https://blazor.syncfusion.com/demos/datagrid/overview?theme=bootstrap5) to understand how to present and manipulate data.