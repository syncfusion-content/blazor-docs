---
layout: post
title: State Management in Blazor DataGrid | Syncfusion
description: Learn how to persist, restore, and manage state in Syncfusion Blazor DataGrid, including saving, resetting, and versioned persistence.
platform: Blazor
control: DataGrid
documentation: ug
---

# State Management in Blazor DataGrid 

State management in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid enables preserving the grid’s configuration across browser reloads and page navigation within the same browser context. This includes settings such as paging, sorting, filtering, grouping, column visibility, and more. State persistence applies to the grid configuration, not the underlying data source; ensure the data is provided again on reload.

To enable state persistence, use the [EnablePersistence](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_EnablePersistence) property. When set to true, the grid saves its state to the browser’s [localStorage](https://developer.mozilla.org/en-US/docs/Web/API/Window/localStorage), so the settings are retained across reloads until cleared.

```cs
<SfGrid DataSource="@Orders" EnablePersistence="true">
```

> The grid stores its state using a combination of the component name and component ID. For example, with component name Grid and ID OrderDetails, the storage key becomes gridOrderDetails. For scenarios with multiple grids on a page or versioned persistence, use the [PersistenceKey](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_PersistenceKey) property to avoid key collisions.

When enabling state persistence, the following grid settings are saved in local storage.

| Grid Settings    | Properties persist                                                                                                                                                                                                                                                                                              | Ignored properties                                                                                                                                                                                                                                                                                                                                                                                                                                                          |
|------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| PageSettings     | CurrentPage<br> PageCount<br> PageSize<br> PageSizes                                                                                                                                                                                                                                                            | Template<br> EnableQueryString                                                                                                                                                                                                                                                                                                                                                                                                                                              |
| GroupSettings    | AllowReordering<br> Columns<br> DisablePageWiseAggregates<br> EnableLazyLoading<br> ShowDropArea<br> ShowGroupedColumn<br> ShowToggleButton<br> ShowUngroupButton                                                                                                                                               | CaptionTemplate                                                                                                                                                                                                                                                                                                                                                                                                                                                             |
| Columns          | AllowEditing<br> AllowFiltering<br> AllowGrouping<br> AllowReordering<br> AllowResizing<br> AllowSearching<br> AllowSorting<br> AutoFit<br> DisableHtmlEncode<br> EnableGroupByFormat<br> Field<br> ForeignKeyField<br> Index<br> ShowColumnMenu<br> ShowInColumnChooser<br> Type<br> Uid<br> Visible<br> Width | ClipMode<br> Commands<br> CustomAttributes<br> DataSource<br> DefaultValue<br> DisplayAsCheckBox<br> Edit<br> EditTemplate<br> EditType<br> Filter<br> filterItemTemplate<br> FilterTemplate<br> ForeignKeyValue<br> Format<br> Freeze<br> HeaderTemplate<br> HeaderText<br> HeaderTextAlign<br> HeaderValueAccessor<br> HideAtMedia<br> IsFrozen<br> IsIdentity<br> IsPrimaryKey<br> MaxWidth<br> MinWidth<br> SortComparer<br> Template<br> TextAlign<br> ValidationRules |
| SortSettings     | -                                                                                                                                                                                                                                                                                                               | -                                                                                                                                                                                                                                                                                                                                                                                                                                                                           |
| FilterSettings   | -                                                                                                                                                                                                                                                                                                               | -                                                                                                                                                                                                                                                                                                                                                                                                                                                                           |
| SearchSettings   | -                                                                                                                                                                                                                                                                                                               | -                                                                                                                                                                                                                                                                                                                                                                                                                                                                           |
| SelectedRowIndex | -                                                                                                                                                                                                                                                                                                               | -                                                                                                                                                                                                                                                                                                                                                                                                                                                                           |


Only a single selected row index is persisted. In multi-selection modes, the selection set is not stored.

N> State is persisted based on the ID property. Set an explicit ID or use PersistenceKey to ensure predictable behavior and to prevent key collisions. localStorage persists until cleared by application code, the user, or browser policies; it may not persist in private/incognito modes and is subject to per-origin storage limits.

The following example demonstrates how to enable persistence in the grid:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid ID="Grid" DataSource="@Orders" Height="315" EnablePersistence="true" AllowPaging="true" AllowFiltering="true" AllowGrouping="true" AllowSorting="true">
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderDate) HeaderText="Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
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

{% highlight c# tabtitle="OrderData.cs" %}

public class OrderData
{
    public static List<OrderData> Orders = new List<OrderData>();

    public OrderData() { }

    public OrderData(int OrderID, string CustomerID, string ShipName, double Freight, DateTime? OrderDate, DateTime? ShippedDate, bool? IsVerified, string ShipCity, string ShipCountry, int employeeID)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerID;
        this.ShipName = ShipName;
        this.Freight = Freight;
        this.OrderDate = OrderDate;
        this.ShippedDate = ShippedDate;
        this.IsVerified = IsVerified;
        this.ShipCity = ShipCity;
        this.ShipCountry = ShipCountry;
        this.EmployeeID = employeeID;
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count == 0)
        {
            Orders.Add(new OrderData(10248, "VINET", "Vins et alcools Chevalier", 32.38, new DateTime(1996, 7, 4), new DateTime(1996, 08, 07), true, "Reims", "France", 1));
            Orders.Add(new OrderData(10249, "TOMSP", "Toms Spezialitäten", 11.61, new DateTime(1996, 7, 5), new DateTime(1996, 08, 07), false, "Münster", "Germany", 2));
            Orders.Add(new OrderData(10250, "HANAR", "Hanari Carnes", 65.83, new DateTime(1996, 7, 6), new DateTime(1996, 08, 07), true, "Rio de Janeiro", "Brazil", 3));
            Orders.Add(new OrderData(10251, "VINET", "Vins et alcools Chevalier", 41.34, new DateTime(1996, 7, 7), new DateTime(1996, 08, 07), false, "Lyon", "France", 1));
            Orders.Add(new OrderData(10252, "SUPRD", "Suprêmes délices", 151.30, new DateTime(1996, 7, 8), new DateTime(1996, 08, 07), true, "Charleroi", "Belgium", 2));
            Orders.Add(new OrderData(10253, "HANAR", "Hanari Carnes", 58.17, new DateTime(1996, 7, 9), new DateTime(1996, 08, 07), false, "Bern", "Switzerland", 3));
            Orders.Add(new OrderData(10254, "CHOPS", "Chop-suey Chinese", 22.98, new DateTime(1996, 7, 10), new DateTime(1996, 08, 07), true, "Genève", "Switzerland", 2));
            Orders.Add(new OrderData(10255, "VINET", "Vins et alcools Chevalier", 148.33, new DateTime(1996, 7, 11), new DateTime(1996, 08, 07), false, "Resende", "Brazil", 1));
            Orders.Add(new OrderData(10256, "HANAR", "Hanari Carnes", 13.97, new DateTime(1996, 7, 12), new DateTime(1996, 08, 07), true, "Paris", "France", 3));
        }
        return Orders;
    }

    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public string ShipName { get; set; }
    public double? Freight { get; set; }
    public DateTime? OrderDate { get; set; }
    public DateTime? ShippedDate { get; set; }
    public bool? IsVerified { get; set; }
    public string ShipCity { get; set; }
    public string ShipCountry { get; set; }
    public int EmployeeID { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VNByDfrqqfeXQzlJ?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Restore initial Blazor DataGrid state

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid supports reverting to the initial configuration, clearing changes made during interaction. This is useful for resetting applied filters, sorting, grouping, column operations, and more.

### Using method

Use the [ResetPersistData](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ResetPersistData) method to restore the grid to its original state when persistence is enabled. This clears the persisted state in browser local storage and renders the grid with its initial property values.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons

<SfButton CssClass="e-primary" OnClick="@(async() =>await Grid.ResetPersistDataAsync())">Restore Grid State</SfButton>

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

{% previewsample "https://blazorplayground.syncfusion.com/embed/BDVetwXgrJTvTIlu?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Clearing local storage

Another way to reset the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid is by clearing the local storage used by the grid. This removes stored state information and returns the grid to its initial configuration.

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
        await JS.InvokeVoidAsync("localStorage.setItem", "Grid", "");
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

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid supports state persistence and can save and restore configurations such as column settings, filters, sorting, grouping, and paging. This example demonstrates version-based state persistence using local storage, where each version corresponds to a unique saved configuration.

When a version is selected:
1. The current grid state is saved to local storage under the active version key.
2. The grid switches to the selected version.
3. If persisted data exists for the selected version, it is applied to the grid.
4. If no data exists, a new state will be stored the next time the grid changes.

To implement version-based persistence, set the PersistenceKey dynamically based on the selected version (for example, gridOrderDetails_v.1) so each version maintains a distinct state in local storage. The ChangeVersion method coordinates saving the current state using [GetPersistDataAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_GetPersistDataAsync) and then applies the selected version via [SetPersistDataAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_SetPersistDataAsync_System_String_).

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

## Restore to previous state

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid can save and restore its current state using local storage. This preserves configuration such as column order, sorting, filtering, and more, allowing a return to a previous configuration.

Use the browser’s getItem and setItem methods with the grid’s [GetPersistDataAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_GetPersistDataAsync) and [SetPersistDataAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_SetPersistDataAsync_System_String_) methods. GetPersistDataAsync returns the grid state as a string suitable for storage; SetPersistDataAsync applies the saved state.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons
@inject IJSRuntime JS

<div class="mb-3">
    <SfButton CssClass="e-success m-1" OnClick="SaveGridState">Save</SfButton>
    <SfButton CssClass="e-danger m-1" OnClick="RestoreGridState">Restore</SfButton>
</div>

<div style="text-align: center; color: red">
    <span>@Message</span>
</div>

<SfGrid @ref="Grid" DataSource="@Orders" Height="300" AllowPaging="true" AllowSorting="true" AllowFiltering="true" AllowGrouping="true" EnablePersistence="true" Toolbar="@(new List<string> { "Edit", "Update", "Cancel" })">
 <GridFilterSettings Type="FilterType.Menu"></GridFilterSettings>
    <GridEditSettings AllowEditing="true"></GridEditSettings>
    <GridEvents OnActionBegin="OnActionBegin" TValue="OrderDetails"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(OrderDetails.OrderID) HeaderText="Order ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="140" IsPrimaryKey="true" ValidationRules="@(new ValidationRules{ Required=true, Number=true})" />
        <GridColumn Field=@nameof(OrderDetails.CustomerID) HeaderText="Customer ID" Width="140" ValidationRules="@(new ValidationRules{ Required=true})"/>
        <GridColumn Field=@nameof(OrderDetails.Freight) HeaderText="Freight" Width="140" Format="C2" TextAlign="TextAlign.Right" ValidationRules="@(new ValidationRules{ Required=true })"/>
        <GridColumn Field=@nameof(OrderDetails.OrderDate) HeaderText="Order Date" Width="150" AllowGrouping="false" Format="M/d/y hh:mm a" Type="ColumnType.DateTime" EditType="EditType.DateTimePickerEdit" TextAlign="TextAlign.Right" />
        <GridColumn Field=@nameof(OrderDetails.ShipCountry) HeaderText="Ship Country" Width="150" EditType="EditType.DropDownEdit"/>
    </GridColumns>
</SfGrid>

@code {
    private SfGrid<OrderDetails> Grid { get; set; }
    private string Message = string.Empty;
    public List<OrderDetails> Orders { get; set; }

    protected override void OnInitialized()
    {
    Orders = OrderDetails.GetAllRecords();
    }

    private async Task SaveGridState()
    {
        var state = await Grid.GetPersistDataAsync();
        await JS.InvokeVoidAsync("localStorage.setItem", "gridOrders", state);
        Message = "Grid state saved.";
    }

    private async Task RestoreGridState()
    {
        var state = await JS.InvokeAsync<string>("localStorage.getItem", "gridOrders");
        if (!string.IsNullOrEmpty(state))
        {
            await Grid.SetPersistDataAsync(state);
            Message = "Previous Grid state restored.";
        }
        else
        {
            Message = "No saved state found.";
        }
    }

    private void OnActionBegin(ActionEventArgs<OrderDetails> args)
    {
        Message = string.Empty;
    }
}

{% endhighlight %}

{% highlight c# tabtitle="OrderDetails.cs" %}

public class OrderDetails
{
    public static List<OrderDetails> order = new List<OrderDetails>();

    public OrderDetails(int orderId, string customerId, string shipCity, string shipName,
                        double freight, DateTime orderDate, string shipCountry)
    {
        this.OrderID = orderId;
        this.CustomerID = customerId;
        this.ShipCity = shipCity;
        this.ShipName = shipName;
        this.Freight = freight;
        this.OrderDate = orderDate;
        this.ShipCountry = shipCountry;
    }

    public static List<OrderDetails> GetAllRecords()
    {
        if (order.Count == 0)
        {
            order.Add(new OrderDetails(10248, "VINET", "Reims", "Vins et alcools Chevalier", 32.38, new DateTime(2024, 1, 5), "France"));
            order.Add(new OrderDetails(10249, "TOMSP", "Münster", "Toms Spezialitäten", 11.61, new DateTime(2024, 1, 7), "Germany"));
            order.Add(new OrderDetails(10250, "HANAR", "Rio de Janeiro", "Hanari Carnes", 65.83, new DateTime(2024, 1, 10), "Brazil"));
            order.Add(new OrderDetails(10251, "VICTE", "Lyon", "Victuailles en stock", 41.34, new DateTime(2024, 1, 12), "France"));
            order.Add(new OrderDetails(10252, "SUPRD", "Charleroi", "Suprêmes délices", 51.30, new DateTime(2024, 1, 14), "Belgium"));
            order.Add(new OrderDetails(10253, "HANAR", "Rio de Janeiro", "Hanari Carnes", 58.17, new DateTime(2024, 1, 16), "Brazil"));
            order.Add(new OrderDetails(10254, "CHOPS", "Bern", "Chop-suey Chinese", 22.98, new DateTime(2024, 1, 18), "Switzerland"));
            order.Add(new OrderDetails(10255, "RICSU", "Genève", "Richter Supermarkt", 148.33, new DateTime(2024, 1, 20), "Switzerland"));
            order.Add(new OrderDetails(10256, "WELLI", "Resende", "Wellington Importadora", 13.97, new DateTime(2024, 1, 22), "Brazil"));
            order.Add(new OrderDetails(10257, "HILAA", "San Cristóbal", "HILARION-Abastos", 81.91, new DateTime(2024, 1, 24), "Venezuela"));
        }
        return order;
    }

    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public string ShipCity { get; set; }
    public string ShipName { get; set; }
    public double Freight { get; set; }
    public DateTime OrderDate { get; set; }
    public string ShipCountry { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BZhSjfrUBZTkusas?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Maintaining custom query in a persistent state

When [EnablePersistence](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_EnablePersistence) is enabled, the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid does not automatically maintain custom query parameters after a page load because the grid refreshes its query parameters on each load. To retain custom parameters, reset the AddParams call in the [OnActionBegin](https://blazor.syncfusion.com/documentation/datagrid/events#onactionbegin) event.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid ID="OrderDetails" @ref="Grid" DataSource="@Orders" AllowFiltering="true" AllowPaging="true" EnablePersistence="true" Height="230">
    <GridEvents OnActionBegin="OnActionBegin" TValue="OrderDetails"></GridEvents>
        <GridColumns>
        <GridColumn Field=@nameof(OrderDetails.OrderID) HeaderText="Order ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="120" />
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
    private void OnActionBegin(Syncfusion.Blazor.Grids.ActionEventArgs<OrderDetails> args)
    {
        Grid?.Query?.AddParams("dataSource", "data");
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

## Get or set local storage value

If the [EnablePersistence](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_EnablePersistence) property is set to true, the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid property values are saved in window.localStorage. Use getItem and setItem on window.localStorage to retrieve or update the stored model.

To retrieve the grid model from local storage:

```cs
string localStorageKey = "gridOrders"; //"gridOrders" is component name + component id.
string modelJson = await JS.InvokeAsync<string>("localStorage.getItem", localStorageKey);
var modelObject = JsonSerializer.Deserialize<object>(modelJson);
```

```cs
await JS.InvokeVoidAsync("localStorage.setItem", localStorageKey, modelJson);
```

N> Refer to the [Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) feature tour page for feature highlights. Explore the [Blazor DataGrid example](https://blazor.syncfusion.com/demos/datagrid/overview?theme=bootstrap5) to see how to present and manipulate data.