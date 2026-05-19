---
layout: post
<<<<<<< HEAD
title: Memory management in Blazor Components | Syncfusion
=======
title: Memory Management Best Practices for Blazor Applications | Syncfusion
>>>>>>> 798378f559189b8c2973aa7c8f0af3167ecddfa3
description: Provides best practices for managing memory efficiently in Blazor components to improve performance, reduce leaks, and ensure optimal resource usage.
platform: Blazor
control: Common
documentation: ug
---

<<<<<<< HEAD
# Memory Management with Blazor Components

This guide explains best practices for [managing memory](https://learn.microsoft.com/en-us/aspnet/core/performance/memory) in Blazor applications using [Blazor components](https://www.syncfusion.com/blazor-components). It covers efficient component lifecycle management, proper resource cleanup, and techniques such as `IDisposable` to prevent memory leaks and optimize application performance.

## Preventing memory leaks with Blazor components

Blazor components are optimized for efficient rendering and automatically manage their internal resources. However, application level objects such as data collections, service subscriptions, timers, and JavaScript interop references should be cleared explicitly.

In Blazor WebAssembly, releasing these references allows the browser runtime to reclaim memory. In Blazor Server, proper cleanup prevents memory retention across active user circuits, which is essential for maintaining scalability.

If you haven't created a Blazor application yet, follow the [Blazor getting started guide](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-visual-studio) to create a project.

### Disposing data bound Blazor components

Data bound components such as [DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) and [ListView](https://www.syncfusion.com/blazor-components/blazor-listview) can hold large data collections in memory. These references should be cleared when the component is removed from the render tree.
=======
# Memory Management Best Practices for Blazor Applications

This guide explains best practices for [managing memory](https://learn.microsoft.com/en-us/aspnet/core/performance/memory) in Blazor applications using [Blazor components](https://www.syncfusion.com/blazor-components). It covers efficient component lifecycle management, proper resource cleanup using `IDisposable` and `IAsyncDisposable`, and techniques to prevent memory leaks and optimize application performance.

## Preventing memory leaks with Blazor components

[Blazor components](https://www.syncfusion.com/blazor-components) are optimized for efficient rendering and automatically manage their internal resources. However, application level objects such as data collections, service subscriptions, timers, and JavaScript interop references should be cleared explicitly.

In Blazor WebAssembly, releasing these references allows the browser runtime to reclaim memory. In Blazor Server, proper cleanup prevents memory retention across active user circuits, which is essential for maintaining scalability.

If you haven't created a Blazor application yet, create one using the following Blazor getting started guides.

* [Getting Started with Blazor WebAssembly App](https://blazor.syncfusion.com/documentation/getting-started/blazor-webassembly-app)
* [Getting Started with Blazor Server App](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-visual-studio)

### Disposing data bound Blazor components

Data bound components such as [DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) and [ListView](https://www.syncfusion.com/blazor-components/blazor-listview) can hold large data collections in memory. Clearing large data collections during component disposal helps release memory references earlier, although the .NET garbage collector ultimately handles memory cleanup.
>>>>>>> 798378f559189b8c2973aa7c8f0af3167ecddfa3

The following example demonstrates how to release data collections used by the DataGrid component.

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

@page "/"
<<<<<<< HEAD
@implements IAsyncDisposable
=======
@implements IDisposable
>>>>>>> 798378f559189b8c2973aa7c8f0af3167ecddfa3
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders">
    <GridColumns>
        <GridColumn Field="OrderId" HeaderText="Order ID" Width="120" />
        <GridColumn Field="CustomerName" HeaderText="Customer Name" Width="200" />
    </GridColumns>
</SfGrid>

@code {
    private List<Order>? Orders;

    protected override void OnInitialized()
    {
        Orders = GetOrders();
    }

<<<<<<< HEAD
    public List<Order> GetOrders()
=======
    private List<Order> GetOrders()
>>>>>>> 798378f559189b8c2973aa7c8f0af3167ecddfa3
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
<<<<<<< HEAD

    public ValueTask DisposeAsync()
    {
        if (Orders != null)
        {
            Orders.Clear();
            Orders = null;
        }
        return ValueTask.CompletedTask;
=======
    
    public void Dispose()
    {
        // Synchronous cleanup
        Orders?.Clear();
>>>>>>> 798378f559189b8c2973aa7c8f0af3167ecddfa3
    }

    // Model class
    public class Order
    {
        public int OrderId { get; set; }
<<<<<<< HEAD
        public string CustomerName { get; set; }
=======
        public string CustomerName { get; set; } = string.Empty;
>>>>>>> 798378f559189b8c2973aa7c8f0af3167ecddfa3
    }
}

{% endhighlight %}
{% endtabs %}

In this example, the `Orders` collection is cleared during component disposal. This removes references to the data and allows the garbage collector to reclaim memory.

This practice is particularly important in Blazor Server applications, where retained references can increase server memory usage across user circuits.

<<<<<<< HEAD
=======
N> Use `IDisposable` when your cleanup is synchronous (such as clearing collections or removing references). Use `IAsyncDisposable` only when performing asynchronous cleanup operations, such as JavaScript interop calls, stream flushing, or releasing unmanaged async resources.

>>>>>>> 798378f559189b8c2973aa7c8f0af3167ecddfa3
### Managing event subscriptions

Components or application logic used alongside [Blazor components](https://www.syncfusion.com/blazor-components) may subscribe to shared application events through services or state containers. These subscriptions should be removed during component disposal to prevent memory leaks and avoid retaining unnecessary references.

<<<<<<< HEAD
This example demonstrates how to manage event subscriptions in a component that listens to shared application state and ensures proper cleanup during disposal.
=======
This example uses the [Blazor Button](https://www.syncfusion.com/blazor-components/blazor-button) component to trigger a state update.
>>>>>>> 798378f559189b8c2973aa7c8f0af3167ecddfa3

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
<<<<<<< HEAD
       AppState.OnChange += OnAppStateChanged;
=======
        AppState.OnChange += OnAppStateChanged;
>>>>>>> 798378f559189b8c2973aa7c8f0af3167ecddfa3
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

<<<<<<< HEAD
**Add service file:**
=======
**Add service file**
>>>>>>> 798378f559189b8c2973aa7c8f0af3167ecddfa3

Create a `Services` folder in your project root. Then add a service file named `AppState.cs` with the following code.

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

<<<<<<< HEAD
**Register the service:**

Register this service into the `Program.cs` file:
=======
**Register the service**

Register this service in the `Program.cs` file.
>>>>>>> 798378f559189b8c2973aa7c8f0af3167ecddfa3

{% tabs %}
{% highlight cs tabtitle="Program.cs" %}

...
builder.Services.AddScoped<AppState>();
...

{% endhighlight %}
{% endtabs %}

<<<<<<< HEAD
The component subscribes to the `OnChange` event in `OnInitialized` and removes the subscription in Dispose.
=======
The component subscribes to the `OnChange` event in `OnInitialized` and removes the subscription in `Dispose()`.
>>>>>>> 798378f559189b8c2973aa7c8f0af3167ecddfa3

Removing event subscriptions ensures the component is not retained in memory after removal.

### Virtualizing large data

Rendering large datasets increases memory allocation and DOM size. [Blazor components](https://www.syncfusion.com/blazor-components) support [virtualization](https://blazor.syncfusion.com/documentation/common/performance-and-scalability/virtualization#components-supporting-virtualization) to improve performance.

In [DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid), to configure row virtualization, set [EnableVirtualization](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_EnableVirtualization) to **true** and define a fixed content height using the [Height](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_Height) property. The number of rendered records is implicitly determined by the content height.

The following example demonstrates how to use built‑in virtualization in the DataGrid component to efficiently render large data collections.

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

@page "/"
<<<<<<< HEAD
@implements IAsyncDisposable
=======
@implements IDisposable
>>>>>>> 798378f559189b8c2973aa7c8f0af3167ecddfa3
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
<<<<<<< HEAD

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
=======
    
    public void Dispose()
    {
        Employees?.Clear();
    }

    private List<Employee> GetLargeEmployeeList()
>>>>>>> 798378f559189b8c2973aa7c8f0af3167ecddfa3
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
<<<<<<< HEAD
        public string Name { get; set; }
=======
        public string Name { get; set; } = string.Empty;
>>>>>>> 798378f559189b8c2973aa7c8f0af3167ecddfa3
    }
}

{% endhighlight %}
{% endtabs %}

With virtualization enabled, only visible records are rendered. Clearing the Employees collection during disposal releases references to large datasets, which is especially beneficial in Blazor WebAssembly to reduce browser memory usage.

N> For datasets with many columns, consider also enabling `EnableColumnVirtualization="true"` on the DataGrid to virtualize horizontal rendering. See [Column Virtualization](https://blazor.syncfusion.com/documentation/datagrid/virtual-scrolling#column-virtualization) for details.

### Preventing unnecessary rendering

Dynamic rendering of components such as [TextBox](https://www.syncfusion.com/blazor-components/blazor-textbox), [DropDownList](https://www.syncfusion.com/blazor-components/blazor-dropdown-list), and [ComboBox](https://www.syncfusion.com/blazor-components/blazor-combobox) can lead to unnecessary component recreation. The `@key` directive helps stabilize rendering.

This example illustrates how the `@key` directive helps Blazor preserve component identity during re‑renders.

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

@page "/"
<<<<<<< HEAD
@implements IAsyncDisposable
=======
@implements IDisposable
>>>>>>> 798378f559189b8c2973aa7c8f0af3167ecddfa3
@using Syncfusion.Blazor.Inputs

<div>
    @foreach (var item in Items)
    {
        <SfTextBox @key="item.Id" Placeholder="@item.Name" />
    }
</div>

@code {
    private List<Item>? Items;

    protected override void OnInitialized()
    {
        Items = GetItems();
    }
<<<<<<< HEAD

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
=======
    
    public void Dispose()
    {
        Items?.Clear();
    }

    private List<Item> GetItems()
>>>>>>> 798378f559189b8c2973aa7c8f0af3167ecddfa3
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
<<<<<<< HEAD
        public string Name { get; set; }
=======
        public string Name { get; set; } = string.Empty;
>>>>>>> 798378f559189b8c2973aa7c8f0af3167ecddfa3
    }
}

{% endhighlight %}
{% endtabs %}

The `@key` directive ensures that each TextBox component is associated with a stable identifier.

When the collection changes, Blazor can correctly match existing components instead of destroying and recreating them, improving rendering efficiency and memory usage.

<<<<<<< HEAD
### Service Lifetime Considerations in Blazor Server Applications
=======
### Managing service lifetimes in Blazor Server applications
>>>>>>> 798378f559189b8c2973aa7c8f0af3167ecddfa3

In Blazor Server, each user maintains their own `ServiceProvider` instance per circuit. A scoped service is created once per user circuit, ensuring user specific state is isolated. `Singleton` services are shared across all users and may lead to unintended data sharing or memory issues.

This behavior is important when working with [Blazor components](https://www.syncfusion.com/blazor-components) that depend on application state, data services, or user specific data. Choosing the correct service lifetime helps prevent memory retention issues and ensures proper component behavior.

{% tabs %}
{% highlight csharp tabtitle="Program.cs" %}

<<<<<<< HEAD
=======
// `UserSessionService` is a placeholder representing any user-specific service (for example, one that maintains session state or per-user preferences). Replace it with your actual service type.
>>>>>>> 798378f559189b8c2973aa7c8f0af3167ecddfa3
builder.Services.AddScoped<UserSessionService>();

{% endhighlight %}
{% endtabs %}

<<<<<<< HEAD
`UserSessionService` is a placeholder representing any user specific service (for example, one that maintains session state or per user preferences). Replace it with your actual service type.

=======
>>>>>>> 798378f559189b8c2973aa7c8f0af3167ecddfa3
This guidance applies to the Blazor Server hosting model and to Blazor Web App projects configured with server-side rendering. It is not applicable to standalone Blazor WebAssembly applications.

## See also

<<<<<<< HEAD
* [Blazor DataGrid Virtualization](https://blazor.syncfusion.com/documentation/datagrid/virtual-scrolling)
* [Blazor Performance Guidelines](https://blazor.syncfusion.com/documentation/common/best-practices)
* [Blazor Component Lifecycle documentation](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/lifecycle?view=aspnetcore-10.0)
* [Blazor Dependency Injection](https://learn.microsoft.com/en-us/aspnet/core/blazor/fundamentals/dependency-injection?view=aspnetcore-10.0)
=======
* [Getting started with Blazor DataGrid Virtualization](https://blazor.syncfusion.com/documentation/datagrid/virtual-scrolling)
* [Discover best practices in Blazor Performance Guidelines](https://blazor.syncfusion.com/documentation/common/best-practices)
* [Learn about the Blazor Component Lifecycle](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/lifecycle)
* [Explore concepts in Blazor Dependency Injection](https://learn.microsoft.com/en-us/aspnet/core/blazor/fundamentals/dependency-injection)
>>>>>>> 798378f559189b8c2973aa7c8f0af3167ecddfa3

