---
layout: post
title: Memory management in Syncfusion Blazor Components
description: Provides best practices for managing memory efficiently in Syncfusion Blazor components to improve performance, reduce leaks, and ensure optimal resource usage.
platform: Blazor
control: Common
documentation: ug
---

# Memory Management with Syncfusion® Blazor Components

This guide explains best practices for [managing memory](https://learn.microsoft.com/en-us/aspnet/core/performance/memory?view=aspnetcore-10.0) in Blazor applications using [Syncfusion® Blazor components](https://www.syncfusion.com/blazor-components). It focuses on efficient component lifecycle management, proper resource cleanup, and techniques such as IDisposable to prevent memory leaks and ensure optimal application performance and resource usage.

## Preventing memory leaks with Syncfusion® Blazor components

Syncfusion Blazor components are optimized for efficient rendering and automatically manage their internal resources. However, application level objects such as data collections, service subscriptions, timers, and JavaScript interop references must be released explicitly.

In Blazor WebAssembly, releasing these references allows the browser runtime to reclaim memory. In Blazor Server, explicit cleanup prevents memory retention across active user circuits, which is critical for maintaining scalability.

If you haven't created your Blazor app yet, follow the [Syncfusion® Blazor getting started guide](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-visual-studio) to create a project.

### Disposing data bound Syncfusion® Blazor components

Data bound components such as [DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) and [ListView](https://www.syncfusion.com/blazor-components/blazor-listview) frequently hold large data collections in memory. These references should be released when the component is removed from the render tree.

The following example demonstrates how to release large data collections used by DataGrid component.

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

@page "/"
@implements IAsyncDisposable
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders">
    <GridColumns>
        <GridColumn Field="OrderId" HeaderText="Order ID" Width="120" />
        <GridColumn Field="CustomerName" HeaderText="Customer Name" Width="200" />
    </GridColumns>
</SfGrid>

@code {
    private List<Order>? Orders = new();

    protected override void OnInitialized()
    {
        Orders = GetOrders();
    }

    public List<Order> GetOrders()
    {
        return new List<Order>
        {
            new Order { OrderId = 1001, CustomerName = "ALFKI" },
            new Order { OrderId = 1002, CustomerName = "ANATR" },
            new Order { OrderId = 1003, CustomerName = "ANTON" },
            new Order { OrderId = 1004, CustomerName = "VINET" },
            new Order { OrderId = 1005, CustomerName = "TOMSP" },
            new Order { OrderId = 1006, CustomerName = "LUNA" },
            new Order { OrderId = 1007, CustomerName = "MICHEL" },
            new Order { OrderId = 1008, CustomerName = "BLONP" },
            new Order { OrderId = 1009, CustomerName = "BOLID" },
            new Order { OrderId = 1010, CustomerName = "ALFKI" }
        };
    }

    public ValueTask DisposeAsync()
    {
        if (Orders != null)
        {
            Orders.Clear();
            Orders = null;
        }
        return ValueTask.CompletedTask;
    }

    // Model class
    public class Order
    {
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

In this example, the `Orders` collection is cleared and set to `null` in `DisposeAsync`. This ensures that references to large datasets are released when the component is removed from the render tree.

This practice is particularly important in Blazor Server applications, where retained references can increase server memory usage across user circuits.

### Managing event subscriptions in Syncfusion® Blazor components

Components such as [Dialog](https://www.syncfusion.com/blazor-components/blazor-modal-dialog), [Toast](https://www.syncfusion.com/blazor-components/blazor-toast), or custom wrappers around Syncfusion components may subscribe to shared application events. These subscriptions must be removed explicitly during component disposal.

This example shows how to properly manage event subscriptions in a component that listens to shared application state.

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

@page "/"
@using Syncfusion.Blazor.Buttons
@inject AppState AppState
@implements IDisposable

<div style="padding:16px">
    <SfButton OnClick="OnClicked" CssClass="e-primary">
        Update Message
    </SfButton>

    <p style="margin-top:12px">
        Current state: @AppState.CurrentMessage
    </p>
</div>

@code {
    protected override void OnInitialized()
    {
       AppState.OnChange += OnAppStateChanged;
    }

    private void OnClicked()
    {
        AppState.CurrentMessage = $"Updated at {DateTime.Now:T}";
    }

    private void OnAppStateChanged()
    {
        InvokeAsync(StateHasChanged);
    }

    public void Dispose()
    {
        AppState.OnChange -= OnAppStateChanged;
    }
}

{% endhighlight %}
{% endtabs %}

**Add service file:**

Create the service folder in the project root. Then create a service file (e.g., `AppState.cs`) under the service folder and add the following code:

{% tabs %}
{% highlight cs tabtitle="AppState.cs" %}

public class AppState
{
    private string _currentMessage = "Initial State";

    public string CurrentMessage
    {
        get => _currentMessage;
        set
        {
            if (_currentMessage == value)
                return;

            _currentMessage = value;
            OnChange?.Invoke();
        }
    }

    public event Action? OnChange;
}

{% endhighlight %}
{% endtabs %}

**Register the service:**

Register this service into the `Program.cs` file:

{% tabs %}
{% highlight cs tabtitle="Program.cs" %}

....
builder.Services.AddScoped<AppState>();

{% endhighlight %}
{% endtabs %}

The component subscribes to the `OnChange` event in `OnInitialized` and removes the subscription in Dispose.

Removing event subscriptions ensures the component instance is not retained in memory after it is removed from the UI. This is particularly important in Blazor Server applications with long lived circuits.

### Virtualizing large data with Syncfusion® Blazor components

Rendering large datasets without virtualization increases memory allocation and DOM size. Syncfusion Blazor components provide built‑in virtualization support to address this scenario.

To configure row virtualization, set [EnableVirtualization](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_EnableVirtualization) to **true** and define a fixed content height using the [Height](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_Height) property. The number of rendered records is implicitly determined by the content height.

The following example demonstrates how to use built‑in virtualization in the Syncfusion DataGrid component to efficiently render large data collections.

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

@page "/"
@implements IAsyncDisposable
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Employees"
        EnableVirtualization="true" RowHeight="36"
        Height="400">
    <GridPageSettings PageSize="50"></GridPageSettings>
    <GridColumns>
        <GridColumn Field="Id" HeaderText="ID" Width="100" />
        <GridColumn Field="Name" HeaderText="Employee Name" Width="200" />
    </GridColumns>
</SfGrid>

@code {
    private List<Employee>? Employees;

    protected override void OnInitialized()
    {
        Employees = GetLargeEmployeeList();
    }

    public ValueTask DisposeAsync()
    {
        // Clear large datasets when component is disposed
        if (Employees != null)
        {
            Employees.Clear();
            Employees = null;
        }
        return ValueTask.CompletedTask;
    }

    public List<Employee> GetLargeEmployeeList()
    {
        var employees = new List<Employee>();
        for (int i = 1; i <= 10000; i++)
        {
            employees.Add(new Employee { Id = i, Name = $"Employee {i}" });
        }
        return employees;
    }

    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

With virtualization enabled, only visible records are rendered. Clearing the Employees collection during disposal releases references to large datasets, which is especially beneficial in Blazor WebAssembly to reduce browser memory usage.

N> For datasets with many columns, consider also enabling `EnableColumnVirtualization="true"` on the DataGrid to virtualize horizontal rendering. See [Column Virtualization](https://blazor.syncfusion.com/documentation/datagrid/virtual-scrolling#column-virtualization) for details.

### Cleaning up JavaScript Interop used by Syncfusion® Blazor components

Some Syncfusion components rely on JavaScript interop for browser specific behavior. Managed interop references must be disposed explicitly to avoid memory retention.

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

@page "/"
@implements IDisposable
@inject IJSRuntime JS
@using Syncfusion.Blazor.Buttons

<SfButton OnClick="OnButtonClickAsync" CssClass="e-primary">Click me</SfButton>

@code {
    private DotNetObjectReference<Home>? dotNetRef;

    protected override void OnInitialized()
    {
        dotNetRef = DotNetObjectReference.Create(this);
    }

    private async Task OnButtonClickAsync()
    {
        await JS.InvokeVoidAsync("MyJavaScriptFunction", dotNetRef);
    }

    [JSInvokable]
    public void CustomMethod()
    {
        Console.WriteLine("Called from JavaScript");
    }

    public void Dispose()
    {
        dotNetRef?.Dispose();
    }
}

{% endhighlight %}
{% endtabs %}

**Add JavaScript file:**

Create the file `wwwroot/js/site.js` and add the following code:

{% tabs %}
{% highlight js tabtitle="site.js" %}

window.MyJavaScriptFunction = function (dotNetRef) {
    dotNetRef.invokeMethodAsync('CustomMethod');
};

{% endhighlight %}
{% endtabs %}

**Add script reference:**

Register the script in `App.razor` (for Blazor Web App / Blazor Server on .NET 8+), or `wwwroot/index.html` (for standalone Blazor WebAssembly), inside the `<body>` tag:

{% tabs %}
{% highlight razor tabtitle="App.razor" %}

<script src="js/site.js"></script>

{% endhighlight %}
{% endtabs %}

Disposing the `DotNetObjectReference` ensures that the component is not retained by JavaScript callbacks in either hosting model.

### Preventing unnecessary rendering

Dynamic rendering of components such as [TextBox](https://www.syncfusion.com/blazor-components/blazor-textbox), [DropDownList](https://www.syncfusion.com/blazor-components/blazor-dropdown-list), and [ComboBox](https://www.syncfusion.com/blazor-components/blazor-combobox) can lead to unnecessary component recreation. The `@key` directive helps stabilize rendering.

This example illustrates how the `@key` directive helps Blazor preserve component identity during re‑renders.

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

@page "/"
@implements IAsyncDisposable
@using Syncfusion.Blazor.Inputs

<div>
    @foreach (var item in Items)
    {
        <SfTextBox @key="item.Id" Placeholder="@item.Name" />
    }
</div>

@code {
    private List<Item>? Items = new();

    protected override void OnInitialized()
    {
        Items = GetItems();
    }

    public ValueTask DisposeAsync()
    {
        if (Items != null)
        {
            Items.Clear();
            Items = null;
        }
        return ValueTask.CompletedTask;
    }
    public List<Item> GetItems()
    {
        return new List<Item>
        {
            new Item { Id = 1, Name = "Item 1" },
            new Item { Id = 2, Name = "Item 2" },
            new Item { Id = 3, Name = "Item 3" }
        };
    }

    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

The `@key` directive ensures that each TextBox component is associated with a stable identifier.

When the collection changes, Blazor can correctly match existing components instead of destroying and recreating them, improving rendering efficiency and memory usage.

### Service lifetime considerations in Blazor Server applications

In Blazor Server, each user maintains their own `ServiceProvider` instance per circuit. A Scoped service is created once per user circuit, ensuring user specific state is isolated. `Singleton` services would be shared across all users, potentially causing data leaks.

{% tabs %}
{% highlight csharp tabtitle="Program.cs" %}

builder.Services.AddScoped<UserSessionService>();

{% endhighlight %}
{% endtabs %}

`UserSessionService` is a placeholder representing any user specific service (for example, one that holds session state or per-user preferences). Replace it with your actual service type.

This guidance applies to the Blazor Server hosting model and to Blazor Web App projects configured with server-side rendering. It is not applicable to standalone Blazor WebAssembly applications.

## See also

* [Blazor Component lifecycle](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/lifecycle?view=aspnetcore-10.0)
* [Syncfusion Blazor performance guidelines](https://blazor.syncfusion.com/documentation/common/best-practices)
* [Virtualization in Syncfusion DataGrid](https://blazor.syncfusion.com/documentation/datagrid/virtual-scrolling)
* [Dependency Injection in Blazor](https://learn.microsoft.com/en-us/aspnet/core/blazor/fundamentals/dependency-injection?view=aspnetcore-10.0)
