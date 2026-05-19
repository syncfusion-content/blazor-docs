---
layout: post
<<<<<<< HEAD
title: Blazor Rendering Performance - Syncfusion
description: Learn how Blazor's render tree, diffing, and update batching work, and apply techniques to optimize rendering with Blazor components effectively.
=======
title: Guide to Blazor Rendering Performance Optimization | Syncfusion
description: Learn techniques to optimize Blazor rendering performance, including data binding, ShouldRender control, EventCallback usage, and efficient component design.
>>>>>>> 798378f559189b8c2973aa7c8f0af3167ecddfa3
platform: Blazor
control: Common
documentation: ug
---

<<<<<<< HEAD
# Blazor Rendering and Performance Optimization

This guide explains how rendering works in Blazor and provides practical techniques to optimize rendering performance when using [Blazor components](https://www.syncfusion.com/blazor-components). It focuses on reducing unnecessary re-renders, minimizing diffing overhead, and improving UI update efficiency.
=======
# Blazor Rendering Performance Optimization

This guide explains how rendering works in Blazor and provides practical techniques to [rendering performance optimization](https://learn.microsoft.com/en-us/aspnet/core/blazor/performance/rendering?view=aspnetcore-10.0) when using [Blazor components](https://www.syncfusion.com/blazor-components). It focuses on reducing unnecessary re-renders, minimizing diffing overhead, and improving UI update efficiency.
>>>>>>> 798378f559189b8c2973aa7c8f0af3167ecddfa3

## Blazor DataGrid example with stable data binding

The following example demonstrates a [Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) with a stable data source. The data collection is created once and reused, which helps prevent unnecessary internal rendering when the component updates for unrelated reasons.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" AllowPaging="true">
    <GridColumns>
        <GridColumn Field="OrderId" HeaderText="Order ID" Width="120" />
        <GridColumn Field="Customer" HeaderText="Customer" Width="180" />
        <GridColumn Field="Total" HeaderText="Total Amount" Format="C2" Width="150" />
    </GridColumns>
</SfGrid>

@code {
    // The collection reference remains stable across renders, preventing unnecessary parameter change notifications to the grid.
    private readonly List<Order> Orders = new()
    {
        new Order { OrderId = 1001, Customer = "Contoso", Total = 2500 },
        new Order { OrderId = 1002, Customer = "Fabrikam", Total = 1800 },
        new Order { OrderId = 1003, Customer = "Northwind", Total = 3250 },
        new Order { OrderId = 1004, Customer = "Adventure Works", Total = 4100 },
        new Order { OrderId = 1005, Customer = "Tailspin Toys", Total = 950 },
        new Order { OrderId = 1006, Customer = "Wide World Importers", Total = 2875 },
        new Order { OrderId = 1007, Customer = "Proseware", Total = 1600 },
        new Order { OrderId = 1008, Customer = "Litware", Total = 3720 },
        new Order { OrderId = 1009, Customer = "Graphic Design Institute", Total = 2100 },
        new Order { OrderId = 1010, Customer = "Blue Yonder Airlines", Total = 4980 }
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

<<<<<<< HEAD
=======
{% previewsample "https://blazorplayground.syncfusion.com/embed/VthdtoWPgPQkxKtj?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2"  %}

>>>>>>> 798378f559189b8c2973aa7c8f0af3167ecddfa3
In this pattern, the grid receives the same `Orders` reference unless the data actually changes. This allows Blazor to avoid treating the parameter as new on every render, which reduces the amount of diffing and internal component work.

N>  Reassigning a new list instance with the same items still counts as a parameter change and will cause the component to re-render unnecessarily.

## Managing re-renders with ShouldRender

There are cases where state changes occur but the visual output does not actually need to change. In such cases, the `ShouldRender` method can be used to explicitly control whether the component proceeds with rendering.

```c#

private bool isUiUpdateRequired;

<<<<<<< HEAD
protected override bool ShouldRender()
{
    // Render only when the visual state has changed.
    return isUiUpdateRequired;
}

private async Task OnDataRefreshAsync()
{
    isUiUpdateRequired = true; 
    StateHasChanged(); // Trigger render with isUiUpdateRequired = true
    await RefreshDataAsync();
    isUiUpdateRequired = false; 
    StateHasChanged(); // Trigger render with isUiUpdateRequired = false (no render occurs)
=======
// Controls whether the component should re-render
protected override bool ShouldRender()
{
    // Only re-render when UI actually needs updating
    return isUiUpdateRequired;
}

// Simulates a data refresh operation
private async Task RefreshDataAsync()
{
    await Task.Delay(1000); // Simulate async work
    data = $"Updated at {DateTime.Now}";
}

// Called when data needs to be refreshed
private async Task OnDataRefreshAsync()
{
    // Enable rendering before updating UI
    isUiUpdateRequired = true;
    StateHasChanged();

    // Perform background work
    await RefreshDataAsync();

    // Disable rendering after update
    isUiUpdateRequired = false;
    StateHasChanged(); // No render occurs if ShouldRender returns false
>>>>>>> 798378f559189b8c2973aa7c8f0af3167ecddfa3
}

```

This pattern is useful when background work updates internal values that do not affect the visible UI immediately. It should be used carefully, because returning `false` at the wrong time can leave the UI out of sync with the component state.

N> `ShouldRender` is most effective when the render conditions are clear, predictable, and easy to validate during testing.

## Efficient event handling with EventCallback

<<<<<<< HEAD
Event handling contributes directly to rendering behavior because UI events often trigger state changes. Using `EventCallback` helps keep events aligned with the component model and avoids unnecessary lambda or delegate allocations that can occur when multiple delegate instances are created repeatedly during rendering cycles.

The following example uses a button to refresh grid data only when the user explicitly requests an update.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Grids

<SfButton Content="Refresh Orders" OnClick="RefreshDataAsync"></SfButton>
=======
Event handling plays an important role in Blazor rendering because UI actions trigger state updates. Using `EventCallback` allows child components to notify parent components in a structured and efficient way, avoiding unnecessary delegate allocations.

The following example separates the [Button](https://www.syncfusion.com/blazor-components/blazor-button) into a child component that exposes an `EventCallback`, making the pattern explicit.

{% tabs %}
{% highlight razor tabtitle="RefreshButton.razor" %}

@using Syncfusion.Blazor.Buttons

<SfButton Content="Refresh Orders" OnClick="OnClickHandler"></SfButton>

@code {
    // Explicit EventCallback definition
    [Parameter]
    public EventCallback OnRefresh { get; set; }

    private async Task OnClickHandler()
    {
        // Trigger parent callback
        await OnRefresh.InvokeAsync();
    }
}

{% endhighlight %}

{% highlight razor tabtitle="Index.razor" %}

@page "/"
@using Syncfusion.Blazor.Grids

<RefreshButton OnRefresh="HandleRefreshAsync"></RefreshButton>
>>>>>>> 798378f559189b8c2973aa7c8f0af3167ecddfa3

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
<<<<<<< HEAD
        new Order { OrderId = 2002, Customer = "Blue Yonder", Total = 1450 },
        new Order { OrderId = 2003, Customer = "Contoso", Total = 2100 },
        new Order { OrderId = 2004, Customer = "Fabrikam", Total = 1700 },
        new Order { OrderId = 2005, Customer = "Northwind", Total = 3200 },
        new Order { OrderId = 2006, Customer = "Tailspin Toys", Total = 800 },
        new Order { OrderId = 2007, Customer = "Adventure Works", Total = 4100 },
        new Order { OrderId = 2008, Customer = "Litware", Total = 2950 },
        new Order { OrderId = 2009, Customer = "Wide World Importers", Total = 2500 }
    };

    private async Task RefreshDataAsync()
    {
        // Simulate a data refresh.
        await Task.Delay(300);
        // Replace the collection when new data is available.
        Orders = new List<Order>
        {   
            new Order { OrderId = 2010, Customer = "Alpine", Total = 950 },
            new Order { OrderId = 2011, Customer = "Blue Yonder", Total = 1500 },
            new Order { OrderId = 2012, Customer = "Contoso", Total = 2250 },
            new Order { OrderId = 2013, Customer = "Fabrikam", Total = 1850 },
            new Order { OrderId = 2014, Customer = "Northwind", Total = 3400 },
            new Order { OrderId = 2015, Customer = "Tailspin Toys", Total = 875 },
          };
=======
        new Order { OrderId = 2002, Customer = "Blue Yonder", Total = 1450 }
    };

    private async Task HandleRefreshAsync()
    {
        await Task.Delay(300);

        Orders = new List<Order>
        {
            new Order { OrderId = 2010, Customer = "Updated Alpine", Total = 950 },
            new Order { OrderId = 2011, Customer = "Updated Blue", Total = 1500 }
        };
>>>>>>> 798378f559189b8c2973aa7c8f0af3167ecddfa3
    }

    private sealed class Order
    {
        public int OrderId { get; set; }
        public string Customer { get; set; } = string.Empty;
        public decimal Total { get; set; }
    }
}
<<<<<<< HEAD

{% endhighlight %}
{% endtabs %}

Here, the data source changes only when new data is intentionally assigned. This keeps rendering predictable and avoids repeated updates that are unrelated to user action.

## Component splitting and child component patterns

As Razor components grow larger, it is recommended to split them into focused child components instead of placing all UI sections in a single `.razor` file. For example, a Razor component that contains a DataGrid, Chart, filter panel, and summary cards performs better when each section is implemented as an independent component.

This improves render isolation. If a chart filter changes, only the chart component is updated, while the DataGrid and other UI sections remain unchanged.

### Parent component

{% tabs %}
{% highlight razor %}

<OrdersGrid Orders="@Orders" />

{% endhighlight %}
{% endtabs %}

### Child DataGrid component

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
=======
{% endhighlight %}

{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VNLxDSCFqFoocyLn?appbar=false&editor=false&result=true&errorlist=false&theme="  %}

In the above example, `EventCallback` allows a child component to notify the parent, which updates data and refreshes the UI efficiently.

## Component splitting and child component patterns

As Razor components grow larger, it is recommended to split them into smaller, focused child components instead of placing all UI logic in a single `.razor` file. For example, a page that contains a [DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid), [Charts](https://www.syncfusion.com/blazor-components/blazor-charts), and summary UI becomes easier to manage when each part is implemented as a separate component.

This approach improves code readability and maintainability. It also helps reduce unnecessary UI updates by isolating different parts of the interface.

**Parent component**

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@page "/"

<OrdersGrid Orders="@Orders" />

@code {
    private List<Order> Orders = new();
    private Random rand = new();

    private string[] customers = new[]
    {
        "Michael Smith", "Emma Johnson", "Liam Brown", "Olivia Davis",
        "Noah Wilson", "Sophia Martinez", "James Anderson",
        "Isabella Taylor", "William Thomas", "Mia Garcia"
    };

    private string[] products = new[]
    {
        "Laptop", "Smartphone", "Headphones", "Smart TV",
        "Tablet", "Gaming Console", "Camera", "Smartwatch",
        "Bluetooth Speaker", "Monitor"
    };

    protected override void OnInitialized()
    {
        LoadInitialData();
    }

    private void LoadInitialData()
    {
        Orders = Enumerable.Range(1, 10).Select(i => new Order
        {
            OrderId = i,
            Customer = customers[i - 1],
            Product = products[i - 1],
            Quantity = rand.Next(1, 5),
            Total = rand.Next(200, 2000)
        }).ToList();
    }

    private void UpdateData(object? state)
    {
        var index = rand.Next(Orders.Count);

        Orders[index].Quantity = rand.Next(1, 5);
        Orders[index].Total = rand.Next(200, 2000);

        InvokeAsync(StateHasChanged);
>>>>>>> 798378f559189b8c2973aa7c8f0af3167ecddfa3
    }
}

{% endhighlight %}
{% endtabs %}

<<<<<<< HEAD
In this arrangement, each child component renders only when its own parameters change. This reduces the render impact of unrelated updates and makes the page easier to maintain.
=======
**Child DataGrid component**

{% tabs %}
{% highlight razor tabtitle="OrdersGrid.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" Height="300" AllowPaging="true">
    <GridColumns>
        <GridColumn Field="OrderId" HeaderText="Order ID" Width="100" />
        <GridColumn Field="Customer" HeaderText="Customer" Width="150" />
        <GridColumn Field="Product" HeaderText="Product" Width="150" />
        <GridColumn Field="Quantity" HeaderText="Qty" Width="100" />
        <GridColumn Field="Total" HeaderText="Total ($)" Width="120" />
    </GridColumns>
</SfGrid>

@code {
    [Parameter]
    public IEnumerable<Order> Orders { get; set; } = Enumerable.Empty<Order>();
}
{% endhighlight %}

{% highlight razor tabtitle="Order.cs" %}

public sealed class Order
{
    public int OrderId { get; set; }
    public string Customer { get; set; } = string.Empty;
    public string Product { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public int Total { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LtVRXoCvTjjRwOzo?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2"  %}

The UI is organized into smaller components, where the parent handles data management and the child component focuses on rendering the grid. When the `Orders` data changes in the parent, the updated values are passed to the child, triggering a grid refresh. This separation keeps the code clean and helps Blazor perform efficient UI updates.
>>>>>>> 798378f559189b8c2973aa7c8f0af3167ecddfa3

## Avoiding expensive work during rendering

Rendering should remain lightweight. If methods that perform calculations, LINQ queries, formatting logic, or object creation are called directly from Razor markup, that work is repeated every time the component renders.

The following example shows a common pattern that looks simple but becomes costly when the component renders frequently.

```c#

<p>Total Amount: @GetTotalAmount()</p>

```

```c#

private decimal GetTotalAmount()
{
    // This runs on every render.
    return Orders.Sum(order => order.Total);
}

```

A more efficient approach is to calculate the total when the data changes and store the result in a field or property.

```c#

<p>Total Amount: @TotalAmount</p>

```

```c#

private decimal TotalAmount;

protected override void OnInitialized()
{
    TotalAmount = Orders.Sum(order => order.Total);
}

```

This keeps the render path simple and avoids repeated computation during every UI update.

## Blazor Chart example with render-efficient updates

[Blazor Charts](https://www.syncfusion.com/blazor-components/blazor-charts) are frequently used in dashboards where filters or live data can trigger repeated updates. Keeping the chart data stable and updating it only when required reduces redraw cost and avoids unnecessary layout recalculations.

{% tabs %}
{% highlight razor tabtitle="Charts.razor" %}

@using Syncfusion.Blazor.Charts

<SfChart Title="Monthly Sales">
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />
    <ChartSeriesCollection>
        <ChartSeries DataSource="@SalesData"
                     XName="Month"
                     YName="Amount"
                     Type="Syncfusion.Blazor.Charts.ChartSeriesType.Column">
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    // The chart receives a stable data reference unless the dataset truly changes.
    private readonly List<SalesRecord> SalesData = new()
    {
        new SalesRecord { Month = "Jan", Amount = 1200 },
        new SalesRecord { Month = "Feb", Amount = 1500 },
        new SalesRecord { Month = "Mar", Amount = 1800 },
        new SalesRecord { Month = "Apr", Amount = 1400 },
        new SalesRecord { Month = "May", Amount = 1200 },
        new SalesRecord { Month = "Jun", Amount = 1900 }
    };

    private sealed class SalesRecord
    {
        public string Month { get; set; } = string.Empty;
        public double Amount { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

<<<<<<< HEAD
This approach keeps chart rendering predictable. If the chart is part of a larger dashboard, isolating it in its own component further reduces the impact of unrelated page updates.

## Example of before and after rendering behavior

A common inefficient pattern is to create collections directly inside markup or properties that are evaluated during render. In the following example, the component produces a new data source each time it renders.
=======
{% previewsample "https://blazorplayground.syncfusion.com/embed/LNBxNyClJWszeZqL?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2"  %}

This approach keeps chart rendering predictable. If the chart is part of a larger dashboard, isolating it in its own component further reduces the impact of unrelated page updates.

## Stable collection references in the Blazor DropDownList

A common performance issue in Blazor occurs when collections are created during each render cycle. This typically happens when methods are called directly in markup or properties that are evaluated during rendering. In such cases, a new collection instance is generated every time the component renders.

In the following example, the [DropDownList](https://www.syncfusion.com/blazor-components/blazor-dropdown-list) receives a new data source on every render.
>>>>>>> 798378f559189b8c2973aa7c8f0af3167ecddfa3

{% tabs %}
{% highlight razor tabtitle="Dropdown.razor" %}

@using Syncfusion.Blazor.DropDowns
<<<<<<< HEAD
=======
@using Syncfusion.Blazor.Buttons

<h4>Inefficient Example (New List Every Render)</h4>
>>>>>>> 798378f559189b8c2973aa7c8f0af3167ecddfa3

<SfDropDownList TValue="string" TItem="string"
                DataSource="@GetCountries()"
                Placeholder="Select a country">
</SfDropDownList>

<<<<<<< HEAD
@code {
    private List<string> GetCountries()
    {
        // A new list is created on every render.
        return new List<string> { "India", "Germany", "United States", "Japan" };
=======
<SfButton @onclick="TriggerRender">Trigger Re-render</SfButton>

<h5>Logs:</h5>
<ul>
    @foreach (var log in Logs)
    {
        <li>@log</li>
    }
</ul>

@code {
    private List<string> Logs = new();

    protected override void OnAfterRender(bool firstRender)
    {
        AddLog("Component rendered");
    }

    private List<string> GetCountries()
    {
        AddLog("GetCountries() called - new list created");
        return new List<string> { "India", "Germany", "USA", "Japan" };
    }

    private void TriggerRender()
    {
        AddLog("Button clicked - forcing render");
    }

    private void AddLog(string message)
    {
        Logs.Add($"{message}");
>>>>>>> 798378f559189b8c2973aa7c8f0af3167ecddfa3
    }
}

{% endhighlight %}
{% endtabs %}

<<<<<<< HEAD
Although the displayed values remain the same, the component receives a new collection reference on every render. This causes unnecessary diffing and can increase render cost over time.

A more efficient version creates the collection once and reuses it.
=======
{% previewsample "https://blazorplayground.syncfusion.com/embed/LjhHZeCbztldiiGC?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2"  %}

Although the displayed values remain unchanged, the component receives a new collection reference each time it renders. This leads to unnecessary diffing and can increase rendering overhead.

A more efficient approach is to create the collection once and reuse it.
>>>>>>> 798378f559189b8c2973aa7c8f0af3167ecddfa3

{% tabs %}
{% highlight razor tabtitle="Dropdown.razor" %}

@using Syncfusion.Blazor.DropDowns
<<<<<<< HEAD
=======
@using Syncfusion.Blazor.Buttons
>>>>>>> 798378f559189b8c2973aa7c8f0af3167ecddfa3

<SfDropDownList TValue="string" TItem="string"
                DataSource="@Countries"
                Placeholder="Select a country">
</SfDropDownList>

<<<<<<< HEAD
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

This difference is not about code style and directly impacts rendering efficiency. Stable references allow Blazor to recognize when a child component’s data has not changed unnecessarily.

## See also

* [Razor component rendering](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/rendering?view=aspnetcore-10.0)
* [Razor component lifecycle](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/lifecycle?view=aspnetcore-10.0)
=======
<SfButton @onclick="TriggerRender">Trigger Re-render</SfButton>

<h5>Logs:</h5>
<ul>
    @foreach (var log in Logs)
    {
        <li>@log</li>
    }
</ul>

@code {
    private List<string> Logs = new();

    private readonly List<string> Countries = new()
    {
        "India", "Germany", "USA", "Japan"
    };

    protected override void OnAfterRender(bool firstRender)
    {
        AddLog(" Component rendered");
    }

    private void TriggerRender()
    {
        AddLog(" Button clicked - forcing render");
    }

    private void AddLog(string message)
    {
        Logs.Add($"{message}");
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BNBdNyWPTCNsZWPJ?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2"  %}

By maintaining a stable collection reference, Blazor can detect that the data has not changed and avoid unnecessary rendering work. This improves performance and ensures more efficient UI updates.

## See also

* [Explore the fundamentals of Razor component rendering](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/rendering?view=aspnetcore-10.0)
* [Understand the flow of the Razor component lifecycle](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/lifecycle?view=aspnetcore-10.0)
>>>>>>> 798378f559189b8c2973aa7c8f0af3167ecddfa3
* [Blazor rendering performance best practices](https://learn.microsoft.com/en-us/aspnet/core/blazor/performance/rendering?view=aspnetcore-10.0)
* [Getting started with Blazor DataGrid](https://blazor.syncfusion.com/documentation/datagrid/getting-started)
* [Getting started with Blazor Chart](https://blazor.syncfusion.com/documentation/chart/getting-started)
* [Getting started with Blazor DropDownList](https://blazor.syncfusion.com/documentation/dropdown-list/getting-started)

