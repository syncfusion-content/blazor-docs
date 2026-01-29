---
layout: post
title: State Management in Blazor DataGrid | Syncfusion
description: Learn how to persist, restore, and manage state in Syncfusion Blazor DataGrid, including saving, resetting, and versioned persistence.
platform: Blazor
control: DataGrid
documentation: ug
---

# State Management in Blazor DataGrid 

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid supports state management to preserve grid configuration across browser reloads and page navigation within the same session. Persisted settings include **paging**, **sorting**, **filtering**, **grouping**, **column visibility**, and similar configurations. State persistence applies only to grid settings; the underlying data must be reloaded when the page refreshes.

Enable state persistence by setting the [EnablePersistence](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_EnablePersistence) property to **true**. When enabled, the grid stores its state in the browser’s [localStorage](https://developer.mozilla.org/en-US/docs/Web/API/Window/localStorage), retaining settings until cleared.

```cs

<SfGrid DataSource="@Orders" EnablePersistence="true">

```

> The Grid stores its state using a key that combines the **component name** and its assigned **ID**. For example, if the component name is **Grid** and the ID is **OrderDetails**, the state key will be **gridOrderDetails**.

When state persistence is enabled, the Grid saves the following settings in local storage:

| **Feature**         | **Persisted Properties**                                                                                     | **Ignored Properties**                     |
|----------------------|-------------------------------------------------------------------------------------------------------------|--------------------------------------------|
| **PageSettings**     | CurrentPage<br>PageCount<br>PageSize<br>EnableQueryString<br>EnableExternalMessage                         | Template                  |
| **GroupSettings**    | AllowReordering<br>DisablePageWiseAggregates<br>ShowDropArea<br>ShowGroupedColumn<br>ShowToggleButton<br>ShowUngroupButton<br>EnableLazyLoading | CaptionTemplate<br>ExpandAllGroups<br>PersistGroupState |
| **Columns**          | AllowAdding<br>AllowEditing<br>AllowFiltering<br>AllowGrouping<br>AllowReordering<br>AllowResizing<br>AllowSearching<br>AllowSorting<br>AutoFit<br>DisableHtmlEncode<br>DisplayAsCheckBox<br>EditType<br>EnableGroupByFormat<br>Field<br>HeaderText<br>HeaderTextAlign<br>HideAtMedia<br>Index<br>OriginalIndex<br>IsFrozen<br>IsIdentity<br>IsPrimaryKey<br>FixedColumn<br>MaxWidth<br>MinWidth<br>ShowColumnMenu<br>ShowInColumnChooser<br>TextAlign<br>Freeze<br>Type<br>Uid<br>Visible<br>Width |EditorSettings<br>FilterEditorSettings<br>EditTemplate<br>FilterTemplate<br>HeaderTemplate<br>SortComparer<br>Template<br>AutoSpan<br>FilterItemTemplate |
| **FilterSettings**   | All properties |  None                             | 
| **SearchSettings**   | All properties                                                               | None                                       |
| **SortSettings**     | All properties                                                                                            | None                                       |
|



> When a row is initially selected using the `SelectedRowIndex` property, only that configured value is persisted. Changes made through UI interactions are not retained after a reload.

N> State persistence relies on the `ID` property. Explicitly set the `ID` value for the grid to ensure consistent behavior.

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

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid includes an option to revert to its original configuration by clearing all applied changes. This process resets **filters**, **sorting**, **grouping**, and **column customizations** to the initial state.

**Ways to Restore**

1. **Using ResetPersistData Method**

    Clears the persisted state from local storage and restores the grid to its original property values.

2. **Clearing Local Storage**

    Removes the stored state directly from the browser’s local storage and reloads the grid with its initial configuration.

### Using ResetPersistData Method

The [ResetPersistData](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ResetPersistData) method clears all persisted state data when persistence is enabled and restores the Grid to its original property values.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons

<SfButton CssClass="e-primary" OnClick="@(async() =>await Grid.ResetPersistDataAsync())">Restore Grid State</SfButton>

<SfGrid @ref="Grid" ID="OrderDetails" DataSource="@Orders" Height="315" EnablePersistence="true" AllowPaging="true" AllowFiltering="true" AllowGrouping="true" AllowSorting="true">
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/rDVHtWrktGTkADQZ?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Clearing local storage

Clear the **local storage** entry used for state persistence to remove all stored configuration and reload the Grid with the initial settings.

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

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid supports state persistence, enabling saving and restoring grid configurations such as **column settings**, **filters**, **sorting**, **grouping**, and **paging**. This example demonstrates version-based state persistence using **localStorage**.

Each version represents a unique grid configuration. When a version button is clicked:

1. The current grid state is saved to localStorage under the active version key.
2. The grid switches to the selected version.
3. If persisted data exists for the selected version, it is applied to the grid.
4. If no data exists, a new state will be stored when the grid is modified.

To implement version-based persistence, set the [PersistenceKey](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_PersistenceKey) dynamically based on the selected version (for example, **gridOrderDetails_v1**). This ensures each version maintains a distinct state in **localStorage**.

The core logic for switching versions is handled in the ChangeVersion method:

The method saves the current grid state using [GetPersistDataAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_GetPersistDataAsync) before switching versions. This method returns the grid’s current state as a string suitable for storage or transmission.
It then attempts to load the state associated with the selected version using [SetPersistDataAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_SetPersistDataAsync_System_String_). If a persisted state exists, it is applied to the grid. Otherwise, a message indicates that no saved state exists and a new state will be stored going forward.

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

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid supports saving and restoring the current state using local storage. This feature preserves configurations such as **column order**, **sorting**, **filtering**, **grouping**, and **paging**, allowing a return to a previously saved state.

**How It Works**

* The [GetPersistDataAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_GetPersistDataAsync) method retrieves the current state of the Grid as a string. This string can be stored in local storage or transmitted to a server.
* The [SetPersistDataAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_SetPersistDataAsync_System_String_) method applies a previously saved state to the Grid.
* If no saved state exists, the Grid remains in the current configuration.

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

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid persists configuration when [EnablePersistence](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_EnablePersistence) is **true**. Custom query parameters can be re-applied after persistence during data binding by using the [DataBound](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_DataBound) event. Re-applying parameters in `DataBound` ensures the query remains consistent across reloads and navigation when persistence is enabled.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}


@page "/"
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Data

<SfGrid ID="OrderDetails" @ref="Grid" DataSource="@Orders" Query="@QueryData" AllowFiltering="true" AllowPaging="true" EnablePersistence="true" Height="230">
    <GridEvents DataBound="OnDataBound" TValue="OrderDetails"></GridEvents>
    <GridColumns>
        <GridColumn Field="@nameof(OrderDetails.OrderID)" HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120" />
        <GridColumn Field="@nameof(OrderDetails.CustomerID)" HeaderText="Customer ID" Width="150" />
        <GridColumn Field="@nameof(OrderDetails.ShipCity)" HeaderText="Ship City" Width="150" />
        <GridColumn Field="@nameof(OrderDetails.ShipName)" HeaderText="Ship Name" Width="150" />
    </GridColumns>
</SfGrid>

@code {
    private SfGrid<OrderDetails> Grid;
    public List<OrderDetails> Orders { get; set; } = new();

    private Query QueryData = new Query().Where("CustomerID", "equal", "VINET");
    protected override void OnInitialized()
    {
        Orders = OrderDetails.GetAllRecords();
    }
    private void OnDataBound()
    {
        Grid?.Query?.AddParams("dataSource", "orders");
    }
}

{% endhighlight %}

{% highlight c# tabtitle="OrderDetails.cs" %}

public sealed class OrderDetails
{

    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public string ShipCity { get; set; }
    public string ShipName { get; set; }

    private static readonly List<OrderDetails> Order = new();

    public OrderDetails(int orderId, string customerId, string shipCity, string shipName)
    {
        OrderID = orderId;
        CustomerID = customerId;
        ShipCity = shipCity;
        ShipName = shipName;
    }

    public static List<OrderDetails> GetAllRecords()
    {
        if (Order.Count == 0)
        {
            Order.Add(new OrderDetails(10248, "VINET", "Reims", "Vins et alcools Chevalier"));
            Order.Add(new OrderDetails(10249, "TOMSP", "Münster", "Toms Spezialitäten"));
            Order.Add(new OrderDetails(10250, "HANAR", "Rio de Janeiro", "Hanari Carnes"));
            Order.Add(new OrderDetails(10251, "VICTE", "Lyon", "Victuailles en stock"));
            Order.Add(new OrderDetails(10252, "SUPRD", "Charleroi", "Suprêmes délices"));
            Order.Add(new OrderDetails(10253, "HANAR", "Rio de Janeiro", "Hanari Carnes"));
            Order.Add(new OrderDetails(10254, "CHOPS", "Bern", "Chop-suey Chinese"));
            Order.Add(new OrderDetails(10255, "RICSU", "Genève", "Richter Supermarkt"));
            Order.Add(new OrderDetails(10256, "WELLI", "Resende", "Wellington Importadora"));
            Order.Add(new OrderDetails(10257, "HILAA", "San Cristóbal", "HILARION-Abastos"));
            Order.Add(new OrderDetails(10258, "ERNSH", "Graz", "Ernst Handel"));
            Order.Add(new OrderDetails(10259, "CENTC", "México D.F.", "Centro comercial Moctezuma"));
            Order.Add(new OrderDetails(10260, "OTTIK", "Köln", "Ottilies Käseladen"));
            Order.Add(new OrderDetails(10261, "QUEDE", "Rio de Janeiro", "Que Delícia"));
            Order.Add(new OrderDetails(10262, "RATTC", "Albuquerque", "Rattlesnake Canyon Grocery"));
        }

        return Order;
    }
}

{% endhighlight %}
{% endtabs %}

## Get or set local storage value

When the [EnablePersistence](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_EnablePersistence) property is **true**, the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid saves its configuration in **window.localStorage**. This includes settings such as **paging**, **filtering**, **sorting**, and **column visibility**. The stored state can be retrieved or updated using JavaScript interop.

To retrieve the grid model from local storage:

```cs

string localStorageKey = "gridOrders"; // Key format: component name + component ID
string modelJson = await JS.InvokeAsync<string>("localStorage.getItem", localStorageKey);

// Deserialize the JSON string into an object
var modelObject = JsonSerializer.Deserialize<object>(modelJson);
```

Update the grid state in local storage:

```cs
await JS.InvokeVoidAsync("localStorage.setItem", localStorageKey, modelJson);
```

N> Refer to the [Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) feature tour for a broad overview. Explore the [Blazor DataGrid example](https://blazor.syncfusion.com/demos/datagrid/overview?theme=bootstrap5) to understand data presentation and manipulation.