---
layout: post
title: Blazor Rendering Performance - Syncfusion
description: Learn how Blazor's render tree, diffing, and update batching work, and apply techniques to optimize rendering with Syncfusion components effectively.
platform: Blazor
control: Common
documentation: ug
---

# Rendering and Performance Optimization for Syncfusion Blazor Components

## Overview

This section explains how rendering works in Blazor and shows practical ways to reduce rendering cost when authoring components with [Syncfusion Blazor components](https://www.syncfusion.com/blazor-components). The focus is on writing components that remain efficient as data volume, user interaction, and layout complexity increase.

## What Is Rendering in Blazor?

[Rendering in Blazor](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/rendering?view=aspnetcore-10.0) is the process of generating UI output from a component’s current state. Instead of directly updating HTML elements, Blazor builds an internal representation of the UI and compares it with the previous version to determine what changed.

This model helps Blazor update only the necessary parts of the interface. For Syncfusion components, this means rendering remains efficient when parameters are stable and state updates are intentional.

## Why Rendering Optimization Matters

Most commonly used Syncfusion components are interactive and data-driven. A DataGrid may respond to paging, sorting, filtering, and editing, while a chart may refresh when a dashboard filter changes or when live data arrives.

If component state changes too often or if child components receive new object references unnecessarily, Blazor performs more rendering work than required. Over time, this leads to slower interactions, increased CPU usage, and reduced UI smoothness.

N> Rendering issues often remain unnoticed in small samples and become visible only when the application starts handling larger datasets and real user interaction patterns.

## How Rendering Works in Blazor

Blazor represents the UI as a **render tree**, which is an internal structure describing elements, attributes, child content, and nested components. Every time a component renders, Blazor creates a new render tree for that component.

It then performs **diffing**, which means it compares the new render tree with the previous one and identifies the exact differences. These differences are grouped into a **batch** and applied efficiently to the UI, which avoids rebuilding the entire page and limits updates to only the affected components.

N> Rendering in Blazor is scoped to components. A single state change does not automatically refresh the full page unless the full page structure is part of the affected render tree.

## Measuring Rendering Overhead

Rendering overhead becomes noticeable when actions such as scrolling, filtering, resizing, or refreshing data begin to feel less responsive. The most practical way to identify this overhead is to observe browser developer tools and watch for long tasks, repeated layout updates, scripting cost, and memory growth during common user interactions.

When analyzing a page that contains a Syncfusion Grid or Chart, focus on how often the UI updates and whether updates are triggered by real data changes or by repeated object creation. In many cases, performance improvements come not from changing the component itself, but from reducing how often the parent component causes it to re-render.

## Render Tree Stability and Parameter Changes

Blazor determines whether child components should update based on state and parameter changes. If a parent component creates new objects or collections during every render, the child component receives those values as changed parameters, even if the content is logically identical.

Keeping parameter values stable reduces unnecessary diffing and avoids avoidable render work in Syncfusion components. This is especially important for grids, charts, and dropdown controls that often receive collections and configuration objects.

## Syncfusion Grid Example with Stable Data Binding

The following example shows a simple `SfGrid` with a stable data source. The data collection is created once and reused, which helps prevent unnecessary internal rendering when the component updates for unrelated reasons.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" AllowPaging="true">
    <GridColumns>
        <GridColumn Field="OrderId" HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120" />
        <GridColumn Field="Customer" HeaderText="Customer" Width="180" />
        <GridColumn Field="Total" HeaderText="Total Amount" Format="C2" Width="150" />
    </GridColumns>
</SfGrid>

@code {
    // The collection reference remains stable across renders.
    private readonly List<Order> Orders = new()
    {
        new Order { OrderId = 1001, Customer = "Contoso", Total = 2500 },
        new Order { OrderId = 1002, Customer = "Fabrikam", Total = 1800 },
        new Order { OrderId = 1003, Customer = "Northwind", Total = 3250 }
    };

    private sealed class Order
    {
        public int OrderId { get; set; }
        public string Customer { get; set; } = string.Empty;
        public decimal Total { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

In this pattern, the grid receives the same `Orders` reference unless the data actually changes. This allows Blazor to avoid treating the parameter as new on every render, which reduces the amount of diffing and internal component work.

N> Reassigning a new list instance with the same items still counts as a parameter change and may trigger unnecessary re-rendering.

## Managing Re-Renders with `ShouldRender`

There are cases where state changes occur but the visual output does not actually need to change. In such cases, the `ShouldRender` method can be used to explicitly control whether the component proceeds with rendering.

{% tabs %}
{% highlight cs %}

private bool isUiUpdateRequired;

protected override bool ShouldRender()
{
    // Render only when the visual state has changed.
    return isUiUpdateRequired;
}

{% endhighlight %}
{% endtabs %}

This pattern is useful when background work updates internal values that do not affect the visible UI immediately. It should be used carefully, because returning `false` at the wrong time can leave the UI out of sync with the component state.

N> `ShouldRender` is most effective when the render conditions are clear, predictable, and easy to validate during testing.

## Efficient Event Handling with `EventCallback`

Event handling contributes directly to rendering behavior because UI events often trigger state changes. Using `EventCallback` helps keep events aligned with the component model and avoids unnecessary allocations that can occur when many delegate instances are created repeatedly.

The following example uses a Syncfusion button to refresh grid data only when the user explicitly requests an update.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Grids

<SfButton Content="Refresh Orders" OnClick="RefreshDataAsync"></SfButton>

<SfGrid DataSource="@Orders" AllowPaging="true">
    <GridColumns>
        <GridColumn Field="OrderId" HeaderText="Order ID" Width="120" />
        <GridColumn Field="Customer" HeaderText="Customer" Width="180" />
        <GridColumn Field="Total" HeaderText="Total" Format="C2" Width="150" />
    </GridColumns>
</SfGrid>

@code {
    private List<Order> Orders = new()
    {
        new Order { OrderId = 2001, Customer = "Alpine", Total = 900 },
        new Order { OrderId = 2002, Customer = "Blue Yonder", Total = 1450 }
    };

    private async Task RefreshDataAsync()
    {
        // Simulate a data refresh.
        await Task.Delay(300);

        // Update the collection only when new data is available.
        Orders = new List<Order>
        {
            new Order { OrderId = 2001, Customer = "Alpine", Total = 900 },
            new Order { OrderId = 2002, Customer = "Blue Yonder", Total = 1450 },
            new Order { OrderId = 2003, Customer = "Wide World Importers", Total = 2200 }
        };
    }

    private sealed class Order
    {
        public int OrderId { get; set; }
        public string Customer { get; set; } = string.Empty;
        public decimal Total { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

Here, the data source changes only when new data is intentionally assigned. This keeps rendering predictable and avoids repeated updates that are unrelated to user action.

## Component Splitting and Child Component Patterns

As pages become larger, it is useful to split them into focused child components rather than keeping all UI sections in one file. A page that contains a grid, chart, filter panel, and summary cards performs better when each section manages its own render tree.

This improves render isolation. If a chart filter changes, only the chart section needs to update, while the grid and other sections can remain unchanged.

### Parent Component

{% tabs %}
{% highlight razor %}

<OrdersSummary TotalOrders="@TotalOrders" />
<OrdersGrid Orders="@Orders" />
<SalesChart Data="@SalesData" />

{% endhighlight %}
{% endtabs %}

### Child Grid Component

{% tabs %}
{% highlight razor tabtitle="OrdersGrid.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" AllowPaging="true">
    <GridColumns>
        <GridColumn Field="OrderId" HeaderText="Order ID" Width="120" />
        <GridColumn Field="Customer" HeaderText="Customer" Width="180" />
    </GridColumns>
</SfGrid>

@code {
    [Parameter]
    public IEnumerable<Order> Orders { get; set; } = Enumerable.Empty<Order>();

    public sealed class Order
    {
        public int OrderId { get; set; }
        public string Customer { get; set; } = string.Empty;
    }
}

{% endhighlight %}
{% endtabs %}

In this arrangement, each child component renders only when its own parameters change. This reduces the render impact of unrelated updates and makes the page easier to maintain.

## Avoiding Expensive Work During Rendering

Rendering should remain lightweight. If methods that perform calculations, LINQ queries, formatting logic, or object creation are called directly from Razor markup, that work is repeated every time the component renders.

The following example shows a common pattern that looks simple but becomes costly when the component renders frequently.

{% tabs %}
{% highlight razor %}

<p>Total Amount: @GetTotalAmount()</p>

{% endhighlight %}
{% endtabs %}

{% tabs %}
{% highlight cs %}

private decimal GetTotalAmount()
{
    // This runs on every render.
    return Orders.Sum(order => order.Total);
}

{% endhighlight %}
{% endtabs %}

A more efficient approach is to calculate the total when the data changes and store the result in a field or property.

{% tabs %}
{% highlight razor %}

<p>Total Amount: @TotalAmount</p>

{% endhighlight %}
{% endtabs %}

{% tabs %}
{% highlight cs %}

private decimal TotalAmount;

protected override void OnInitialized()
{
    TotalAmount = Orders.Sum(order => order.Total);
}

{% endhighlight %}
{% endtabs %}

This keeps the render path simple and avoids repeated computation during every UI update.

## Syncfusion Chart Example with Render-Efficient Updates

Charts are frequently used in dashboards where filters or live data can trigger repeated updates. Keeping the chart data stable and updating it only when required reduces redraw cost and avoids unnecessary layout recalculations.

{% tabs %}
{% highlight razor tabtitle="Charts.razor" %}

@using Syncfusion.Blazor.Charts

<SfChart Title="Monthly Sales">
    <ChartPrimaryXAxis ValueType="ValueType.Category" />
    <ChartSeriesCollection>
        <ChartSeries DataSource="@SalesData"
                     XName="Month"
                     YName="Amount"
                     Type="ChartSeriesType.Column">
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    // The chart receives a stable data reference unless the dataset truly changes.
    private readonly List<SalesRecord> SalesData = new()
    {
        new SalesRecord { Month = "Jan", Amount = 1200 },
        new SalesRecord { Month = "Feb", Amount = 1500 },
        new SalesRecord { Month = "Mar", Amount = 1800 }
    };

    private sealed class SalesRecord
    {
        public string Month { get; set; } = string.Empty;
        public double Amount { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

This approach keeps chart rendering predictable. If the chart is part of a larger dashboard, isolating it in its own component further reduces the impact of unrelated page updates.

## Syncfusion DropDownList Example with Stable Items

Dropdown components often appear lightweight, but they are also affected by repeated parameter changes. If the data source is rebuilt on each render, the component performs more work than necessary.

{% tabs %}
{% highlight razor tabtitle="Dropdown.razor" %}

@using Syncfusion.Blazor.DropDowns

<SfDropDownList TValue="string" TItem="string"
                DataSource="@Countries"
                Placeholder="Select a country">
</SfDropDownList>

@code {
    // Stable item source improves rendering consistency.
    private readonly List<string> Countries = new()
    {
        "India",
        "Germany",
        "United States",
        "Japan"
    };
}

{% endhighlight %}
{% endtabs %}

This pattern becomes especially useful in forms where multiple input controls are present. Keeping parameter values stable across the form reduces unnecessary updates while the user types or navigates between fields.

## Example of Before and After Rendering Behavior

A common inefficient pattern is to create collections directly inside markup or properties that are evaluated during render. In the following example, the component produces a new data source each time it renders.

{% tabs %}
{% highlight razor tabtitle="Dropdown.razor" %}

<SfDropDownList TValue="string" TItem="string"
                DataSource="@GetCountries()"
                Placeholder="Select a country">
</SfDropDownList>

@code {
    private List<string> GetCountries()
    {
        // A new list is created on every render.
        return new List<string> { "India", "Germany", "United States", "Japan" };
    }
}

{% endhighlight %}
{% endtabs %}

Although the displayed values remain the same, the component receives a new collection reference on every render. This causes unnecessary diffing and can increase render cost over time.

A more efficient version creates the collection once and reuses it.

{% tabs %}
{% highlight razor tabtitle="Dropdown.razor" %}

<SfDropDownList TValue="string" TItem="string"
                DataSource="@Countries"
                Placeholder="Select a country">
</SfDropDownList>

@code {
    // The list is created once and reused.
    private readonly List<string> Countries = new()
    {
        "India",
        "Germany",
        "United States",
        "Japan"
    };
}
{% endhighlight %}
{% endtabs %}

The difference here is not only code style; it directly affects rendering efficiency. Stable references help Blazor determine that the child component’s data has not changed unnecessarily.

## Common Scenarios

A reporting page that contains an `SfGrid` with paging and filtering usually benefits from stable data references, virtualization where appropriate, and isolated filter components. These changes reduce grid updates that are unrelated to visible row changes.

A dashboard that combines `SfChart`, cards, and dropdown filters benefits from child component isolation and from updating only the chart or card section that actually changed. This prevents the full dashboard layout from re-rendering unnecessarily.

A form that contains several input controls such as DropDownList, DatePicker, and text inputs benefits from keeping option sources stable and from grouping related form sections into smaller components. This keeps typing and validation responsive even when the page contains many fields.

## See Also

* [Razor component rendering](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/rendering?view=aspnetcore-10.0)
* [Razor component lifecycle](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/lifecycle?view=aspnetcore-10.0)
* [Blazor rendering performance best practices](https://learn.microsoft.com/en-us/aspnet/core/blazor/performance/rendering?view=aspnetcore-10.0).
* [DataGrid getting started](https://blazor.syncfusion.com/documentation/datagrid/getting-started)
* [Chart getting started](https://blazor.syncfusion.com/documentation/chart/getting-started)
* [DropDownList getting started](https://blazor.syncfusion.com/documentation/dropdown-list/getting-started)

