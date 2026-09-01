---
layout: post
title: Blazor Grid: Create a Custom Blazor Data Grid Component | Syncfusion
canonical_url: "https://www.syncfusion.com/blazor-components/blazor-datagrid"
description: Learn how to create a reusable custom Blazor Data Grid component that wraps SfGrid and shares paging, sorting, and layout settings across applications.
platform: Blazor
control: DataGrid
documentation: ug
---

# Creating a Reusable Custom Blazor Data Grid Component

Creating a reusable custom Blazor Data Grid by wrapping the `SfGrid` in a reusable Razor component standardizes configuration and improves maintainability across applications. The pattern supports consistent Data Grid settings across multiple pages or modules.

Manual configuration of paging, sorting, filtering, and layout for each Data Grid can result in duplicated code and inconsistent behavior. Repetitive setup increases development effort and makes updates more difficult. A wrapper component centralizes common settings and supports uniform behavior throughout the application.

## Why create a custom Blazor Data Grid component

A custom Data Grid component simplifies development by reducing repetitive configuration. Instead of defining the same settings for each Grid instance, properties such as paging, sorting, and layout can be configured once and reused across the application.

The approach is especially beneficial in team environments where multiple developers contribute to different modules. The pattern keeps all Data Grid implementations consistent in design and behavior. Centralized configuration also reduces errors and inconsistencies caused by manual setup.

Another advantage is improved maintainability. Updates such as modifying page size or enabling additional features can be applied in a single location without changing multiple files. Centralized updates reduce maintenance overhead and improve development efficiency.

A reusable component also enhances code readability. Abstracting repetitive logic into a single component makes page-level code cleaner and easier to understand.

## How the custom Blazor Data Grid works

The custom component internally renders the `SfGrid` and applies predefined settings shared across all usages. The wrapper encapsulates default behavior while allowing customization.

* Generic type support with **TItem** enables strongly typed data binding, improving type safety and providing compile-time validation.
* Child content projection using **ChildContent** allows column definitions, templates, and other markup to be passed into the Data Grid.
* Attribute forwarding applies additional parameters, properties, or events from the custom component to the underlying `SfGrid`.

The design provides reusable grid behavior with configurable component parameters and projected column content.

## When to use a custom Blazor Data Grid

Use a custom Data Grid component when consistency, scalability, and maintainability are key requirements.

Common use cases include:

* Applications with multiple Data Grid instances across various pages
* Requirements for consistent paging, sorting, or layout behavior
* Projects where Data Grid configurations are frequently updated
* Large-scale applications requiring reusable and structured components

The pattern helps enforce development standards, reduce duplication, and improve overall code quality.

## Implement a custom Blazor Data Grid component

The reusable `CustomGrid` component uses predefined [GridPageSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_PageSettings). The wrapper component centralizes common configuration options, such as [PageCount](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridPageSettings.html#Syncfusion_Blazor_Grids_GridPageSettings_PageCount) and [PageSize](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridPageSettings.html#Syncfusion_Blazor_Grids_GridPageSettings_PageSize), while allowing external customization through parameters and projected content.

1. Create `CustomGrid.razor` for the Data Grid markup and projected column content.
2. Add `CustomGrid.razor.cs` for the generic type and component parameters.
3. Add the `CustomGrid` component to a page and provide a data source and column definitions.


**CustomGrid.razor:**

{% tabs %}
{% highlight C# tabtitle="CustomGrid.razor" %}

@using Syncfusion.Blazor.Grids
@typeparam TItem

<SfGrid TValue="TItem"
        DataSource="@DataSource"
        AllowSorting="@AllowSorting"
        AllowPaging="@AllowPaging"
        @attributes="AdditionalAttributes">
    <GridPageSettings PageCount="@PageCount"
                      PageSize="@PageSize"
                      PageSizes="@PageSizes">
    </GridPageSettings>
    @ChildContent
</SfGrid>

{% endhighlight %}
{% endtabs %}

**CustomGrid.razor.cs:**

{% tabs %}
{% highlight C# tabtitle="CustomGrid.razor.cs" %}

using Microsoft.AspNetCore.Components;
using Syncfusion.Blazor.Grids;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SF_Grid_Inheritance.Shared
{
    public partial class CustomGrid<TItem> : ComponentBase
    {
        [Parameter] public IEnumerable<TItem>? DataSource { get; set; }
        [Parameter] public bool AllowPaging { get; set; } = true;
        [Parameter] public bool AllowSorting { get; set; } = true;
        [Parameter] public int PageCount { get; set; } = 5;
        [Parameter] public int PageSize { get; set; } = 10;
        [Parameter] public string[] PageSizes { get; set; } = new[] { "10", "20", "50" };
        [Parameter] public RenderFragment? ChildContent { get; set; }

        [Parameter(CaptureUnmatchedValues = true)]
        public IReadOnlyDictionary<string, object>? AdditionalAttributes { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

## Use the Reusable Data Grid Component in Blazor

After the custom component is defined, developers can reuse the component across different pages by supplying a data source and defining column structures. Predefined settings are applied automatically, reducing setup time and supporting consistent behavior.

The reusable component lets developers focus on application logic instead of repetitive Data Grid configuration. The pattern also supports a consistent user experience and simplifies long-term maintenance.

**Index.razor:**

{% tabs %}
{% highlight C# tabtitle="Index.razor" %}

@using SF_Grid_Inheritance.Shared
@using Syncfusion.Blazor.Grids

<CustomGrid DataSource="Orders" TItem="Order">
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer ID" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText="Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
    </GridColumns>
</CustomGrid>

@code {
    public List<Order> Orders { get; set; } = new();

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
        {
            OrderID = 1000 + x,
            CustomerID = new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" }[(x - 1) % 5],
            Freight = Math.Round(2.1 * x, 2),
            OrderDate = new DateTime(2024, 1, 1).AddDays(-x),
        }).ToList();
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string? CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}