---
layout: post
title: How to Hide the Built‑in Spinner and Show a Custom Loading Spinner in Blazor DataGrid
 | Syncfusion
description: Learn How to Hide the Built‑in Spinner and Show a Custom Loading Spinner in Syncfusion Blazor DataGrid
 component to control user interaction with it.
platform: Blazor
control: DataGrid
documentation: ug
---

# How to Hide the Built‑in Spinner and Show a Custom Loading Spinner in Blazor DataGrid

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid displays its default loading spinner while fetching and rendering data. If you want to provide a customized loading experience—such as a full overlay spinner—you can hide the Grid’s built‑in spinner and show your own custom spinner until the Grid finishes loading.

This can be achieved by:

* Creating a custom overlay spinner container and placing it over the Grid.
* Hiding the Grid’s built‑in spinner using CSS.
* Using the DataBound event to determine when the data has finished loading so the custom spinner can be hidden.

The `DataBound` event is triggered after the Grid has fully bound its dataSource and completed rendering the UI. This makes it the ideal place to hide the custom spinner.

### Create a wrapper container with a custom overlay spinner

```cshtml
<div class="e-spin-overlay" style="display: @(ShowSpinner ? "block" : "none");">
    <SfSpinner @bind-Visible="ShowSpinner"></SfSpinner>
</div>
```

### Hide the built‑in Grid spinner using CSS

```css
.e-grid .e-spinner-pane {
    display: none;
}
```

### Use the DataBound event to hide the custom spinner once data is loaded

```cshtml
public Task DataBoundHandler()
{
    if (IsLoading)
    {
        IsLoading = false;
        ShowSpinner = false; 
    }
    return Task.CompletedTask;
}

```
### Wrap the Grid and apply the logic

{% tabs %}
{% highlight C# tabtitle="Index.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons

<div class="grid-container">
    <div class="e-spin-overlay" style="display: @(ShowSpinner ? "block" : "none");">
        <Syncfusion.Blazor.Spinner.SfSpinner @bind-Visible="@ShowSpinner"></Syncfusion.Blazor.Spinner.SfSpinner>
    </div>
    <SfGrid TValue="OrderData" ID="OrdersGrid" AllowPaging="true">
        <SfDataManager Url="https://services.odata.org/Northwind/Northwind.svc/Orders" Adaptor="Adaptors.ODataAdaptor"></SfDataManager>
        <GridEvents DataBound="DataBoundHandler" TValue="OrderData"></GridEvents>
        <GridColumns>
            <GridColumn Field="@nameof(OrderData.OrderID)" HeaderText="Order ID" TextAlign="TextAlign.Center" Width="120"></GridColumn>
            <GridColumn Field="@nameof(OrderData.CustomerID)" HeaderText="Customer Name" Width="130"></GridColumn>
            <GridColumn Field="@nameof(OrderData.EmployeeID)" HeaderText="Employee ID" Width="120"></GridColumn>
        </GridColumns>
    </SfGrid>
</div>

<style>
    .grid-container {
        position: relative;
    }

    .e-spin-overlay {
        position: absolute;
        top: 0;
        left: 0;
        right: 0;
        bottom: 0;
        background-color: rgba(0,0,0,0.5); /* Adjust the opacity as needed */
        z-index: 1000; /* Ensure this is higher than the grid rows */
        pointer-events: none; /* Prevent interaction with the grid while spinning */
    }

    .e-grid .e-spinner-pane {
        display: none; /* hides the built-in grid spinner */
    }

</style>

@code 
{
    public bool ShowSpinner { get; set; } = true;

    public bool IsLoading { get; set; } = true;

    public class OrderData
    {
        public int OrderID { get; set; }
        public string? CustomerID { get; set; }
        public int EmployeeID { get; set; }
    }

    public async Task DataBoundHandler()
    {
        if (IsLoading)
        {
            IsLoading = false;
            ShowSpinner = false;
        }
    }
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LXLHtVNqAlYyiykJ?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}