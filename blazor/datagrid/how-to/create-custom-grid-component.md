---
layout: post
title: Create a custom Grid component in Blazor DataGrid | Syncfusion
description: Learn how to build a reusable custom Grid component that wraps SfGrid in Blazor to share default paging, sorting, and layout settings across the application.
platform: Blazor
control: DataGrid
documentation: ug
---

# Create a reusable custom DataGrid Component

Creating a reusable custom Blazor DataGrid by wrapping the Syncfusion `SfGrid` inside a Razor component helps standardize configuration and improve maintainability across applications. This approach is particularly useful in modern web applications where multiple Grid instances are used across different pages or modules.

In such scenarios, manually configuring features such as paging, sorting, filtering, and layout for each Grid can result in duplicated code and inconsistent behavior. Over time, this repetitive setup increases development effort and makes updates more difficult. By introducing a wrapper component, common configurations can be centralized and reused efficiently, ensuring uniform behavior throughout the application.

## Why create a custom DataGrid component

A custom DataGrid component simplifies development by reducing repetitive configuration. Instead of defining the same settings for each Grid instance, properties such as paging, sorting, and layout can be configured once and reused across the application.

This approach is especially beneficial in team environments where multiple developers contribute to different modules. It ensures that all Grid implementations follow consistent design patterns and behavior. Centralizing configurations also reduces the chances of errors or inconsistencies caused by manual setup.

Another advantage is improved maintainability. When updates are required, such as modifying page size or enabling additional features, changes can be applied in a single location without affecting multiple files. This significantly reduces maintenance overhead and improves development efficiency.

Additionally, a reusable component enhances code readability. By abstracting repetitive logic into a single component, page-level code becomes cleaner and easier to understand.

## How the custom Grid works

The custom component internally renders the Syncfusion `SfGrid` and applies predefined settings that are shared across all usages. It acts as a wrapper that encapsulates default behavior while allowing flexibility for customization.

* Generic type support **TItem** enables strongly typed data binding, improving type safety and providing compile-time validation.

* Child content projection using **ChildContent** allows dynamic column definitions, templates, and other elements to be passed into the Grid.

* Attribute forwarding ensures that additional parameters, properties, or events passed to the custom component are automatically applied to the underlying `SfGrid`.

This design approach provides a balance between reusable and flexibility. Developers can rely on the predefined defaults while still having the ability to extend or override behavior when needed.

## When to use a custom DataGrid

Using a custom DataGrid component is recommended in scenarios where consistency, scalability, and maintainability are key requirements.

Common use cases include:

* Applications with multiple Grid instances across various pages
* Requirements for consistent paging, sorting, or layout behavior
* Projects where Grid configurations are frequently updated
* Large-scale applications that demand reusable and structured components

Adopting this pattern helps enforce development standards, reduces duplication, and improves overall code quality.

## CustomGrid component implementation

The following example demonstrates how to create a reusable CustomGrid component with predefined `GridPageSettings`. This component centralizes common configuration options, such as `PageCount` and `PageSize`, while still allowing external customization through parameters and projected content.

**CustomGrid.razor:**

{% tabs %}
{% highlight C# tabtitle="CustomGrid.razor" %}

@using Syncfusion.Blazor.Grids
@typeparam TItem

<SfGrid TValue="TItem"
        DataSource="DataSource"
        AllowSorting="AllowSorting"
        AllowPaging="AllowPaging"
        @attributes="AdditionalAttributes">
    <GridPageSettings PageCount="@PAGE_COUNT"
                      PageSize="@DEFAULT_PAGE_SIZE"
                      PageSizes="PageSizes">
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
        public const int PAGE_COUNT = 5;
        public const int DEFAULT_PAGE_SIZE = 10;

        [Parameter] public IEnumerable<TItem>? DataSource { get; set; }
        [Parameter] public bool AllowPaging { get; set; } = true;
        [Parameter] public bool AllowSorting { get; set; } = true;
        [Parameter] public string[] PageSizes { get; set; } = new[] { "10", "20", "50" };
        [Parameter] public RenderFragment? ChildContent { get; set; }

        // Forwards any additional attributes/events to the inner SfGrid
        [Parameter(CaptureUnmatchedValues = true)]
        public IReadOnlyDictionary<string, object>? AdditionalAttributes { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

## Use the custom Grid component

Once the custom component is defined, it can be reused across different pages by supplying the required data source and defining column structures. The predefined settings are automatically applied, which reduces setup time and ensures consistent behavior.

This approach allows developers to focus more on application logic rather than repetitive Grid configuration. It also ensures a consistent user experience across all parts of the application and simplifies long-term maintenance as the project evolves.

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

@code{
    public List<Order> Orders { get; set; } = new();
    private static readonly Random _random = new Random();

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
        {
            OrderID = 1000 + x,
            CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[_random.Next(5)],
            Freight = Math.Round(2.1 * x, 2),
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

{% endhighlight %}
{% endtabs %}
