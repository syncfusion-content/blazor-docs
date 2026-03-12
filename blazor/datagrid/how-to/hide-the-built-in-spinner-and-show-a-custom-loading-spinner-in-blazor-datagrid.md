---
layout: post
title: Use a Custom Loading Spinner in Syncfusion Blazor DataGrid
description: Learn how to hide the built-in spinner and show a custom overlay spinner in the Syncfusion Blazor DataGrid.
platform: Blazor
control: DataGrid
keywords: blazor datagrid custom spinner, hide default spinner, datagrid loading overlay
documentation: ug
---

# Hide Built‑in Spinner and Show a Custom Loading Spinner

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid displays its default loading spinner while fetching and rendering data. A customized loading experience—such as a full overlay spinner—can be implemented by hiding the Grid’s built‑in spinner and displaying a custom spinner until the data load is complete.

This customization involves the following steps:

* Create a custom overlay spinner container and position it over the DataGrid.
* Hide the built‑in Grid spinner by applying CSS.
* Using the [DataBound](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_DataBound) event to detect when the Grid has finished loading and hide the custom spinner.

The `DataBound` event is triggered after the DataGrid has fully bound its DataSource and completed UI rendering, making it the appropriate event for removing the custom loading indicator.

### Create a wrapper container with a custom overlay spinner

```cshtml
<div class="e-spin-overlay" style="display: @(ShowSpinner ? "block" : "none");">
    <SfSpinner @bind-Visible="ShowSpinner"></SfSpinner>
</div>
```

### Hide the built‑in Grid spinner using CSS

```css
.e-grid .e-spinner-pane {
    display: none; /* Hides the built-in DataGrid loading spinner */
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
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons

<div class="grid-container">
    <div class="e-spin-overlay" style="display: @(ShowSpinner ? "block" : "none");">
        <Syncfusion.Blazor.Spinner.SfSpinner @bind-Visible="@ShowSpinner"></Syncfusion.Blazor.Spinner.SfSpinner>
    </div>
    <SfGrid TValue="APIGridOrder">
        <SfDataManager Url="https://blazor.syncfusion.com/services/development/api/GridWebApi" Adaptor="Syncfusion.Blazor.Adaptors.WebApiAdaptor"></SfDataManager>
        <GridEvents DataBound="DataBoundHandler" TValue="APIGridOrder"></GridEvents>
        <GridColumns>
            <GridColumn Field=@nameof(APIGridOrder.EmployeeID) HeaderText="Employee ID" IsPrimaryKey="true" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="120"></GridColumn>
            <GridColumn Field=@nameof(APIGridOrder.FirstName) HeaderText="First Name" Width="150"></GridColumn>
            <GridColumn Field=@nameof(APIGridOrder.Designation) HeaderText=" Designation" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="130"></GridColumn>
            <GridColumn Field=@nameof(APIGridOrder.ReportsTo) HeaderText="ReportsTo" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="120"></GridColumn>
            <GridColumn Field=@nameof(APIGridOrder.Country) HeaderText="Country" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="120"></GridColumn>
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
</style>

@if (ShowSpinner)
{
    <style>
        .e-grid .e-spinner-pane {
            display: none; /* hides the built-in grid spinner */
        }
    </style>
}

@code
{
    public bool ShowSpinner { get; set; } = true;

    public bool IsLoading { get; set; } = true;

    public class APIGridOrder
    {
        public APIGridOrder()
        {

        }
        public APIGridOrder(string employeeId, string firstName, string designation, string country, string reportsTo)
        {
            this.EmployeeID = employeeId;
            this.FirstName = firstName;
            this.Designation = designation;
            this.ReportsTo = reportsTo;
            this.Country = country;
        }
        public string EmployeeID { get; set; }
        public string ReportsTo { get; set; }
        public string FirstName { get; set; }
        public string Designation { get; set; }
        public string Country { get; set; }
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/hZhRjUWVpislfAyD?appbar=true&editor=true&result=true&errorlist=true&theme=bootstrap5" %}
