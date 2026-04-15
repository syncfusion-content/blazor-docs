---
layout: post
title: Memory management in Syncfusion Blazor Components
description: Provides best practices for managing memory efficiently in Syncfusion Blazor components to improve performance, reduce leaks, and ensure optimal resource usage.
platform: Blazor
control: Common
documentation: ug
---

# Memory Management with Syncfusion® Blazor Components

This section explains best practices for managing memory in Blazor applications that use [Syncfusion Blazor components](https://www.syncfusion.com/blazor-components). Proper memory management helps minimize memory allocations, prevent memory leaks, and maintain consistent performance in both Blazor WebAssembly and Blazor Server hosting models.

## What is memory management in Blazor?

Memory management in Blazor involves controlling the lifecycle of components, services, event subscriptions, and JavaScript interop references. Memory is allocated during component rendering, data binding, event handling, and interaction with JavaScript. When these allocations are not released properly, memory remains occupied and impacts application performance.

In Blazor WebAssembly, retained memory affects the browser environment and client-side responsiveness. In Blazor Server, memory is allocated on the server per user circuit (a persistent connection between a user and the server), making memory leaks more serious for application scalability.

## Why is memory management required?

Proper memory management is required to avoid performance degradation in applications that run for extended periods. Components that are not disposed correctly may continue to hold references to data or services after navigation. In Blazor WebAssembly, this leads to increased browser memory usage, while in Blazor Server, it results in higher server memory consumption and reduced concurrency.

N> In Blazor Server applications, improperly released memory impacts all connected users because server resources are shared.

## Identifying memory issues

Memory issues are commonly identified through gradual memory growth during repeated navigation or user interaction. Components that react to events after being removed from the UI, and delayed garbage collection, are typical indicators. These issues usually appear as browser slowdowns in Blazor WebAssembly and increased memory usage or reduced throughput in Blazor Server applications.

## Preventing memory leaks with Syncfusion Blazor components

Syncfusion Blazor components are optimized for efficient rendering and automatically manage their internal resources. However, application level objects such as data collections, service subscriptions, timers, and JavaScript interop references must be released explicitly.

In Blazor WebAssembly, releasing these references allows the browser runtime to reclaim memory. In Blazor Server, explicit cleanup prevents memory retention across active user circuits, which is critical for maintaining scalability.

### Disposing data‑bound Syncfusion components

Data‑bound components such as [DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) and [ListView](https://www.syncfusion.com/blazor-components/blazor-listview) frequently hold large data collections in memory. These references should be released when the component is removed from the render tree.

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

When the component is disposed, clearing the data source ensures that memory can be reclaimed. In Blazor WebAssembly, this frees browser memory. In Blazor Server, it prevents server‑side memory retention after navigation.

### Managing event subscriptions in Syncfusion UI components

Components such as [Dialog](https://www.syncfusion.com/blazor-components/blazor-modal-dialog), [Toast](https://www.syncfusion.com/blazor-components/blazor-toast), or custom wrappers around Syncfusion components may subscribe to shared application events. These subscriptions must be removed explicitly during component disposal.

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

@page "/"
@using Syncfusion.Blazor.Buttons
@inject AppState _appState
@implements IDisposable

<div style="padding:16px">
    <SfButton OnClick="OnClicked" CssClass="e-primary">
        Update Message
    </SfButton>

    <p style="margin-top:12px">
        Current state: @_appState.CurrentMessage
    </p>
</div>

@code {
    protected override void OnInitialized()
    {
       _appState.OnChange += OnAppStateChanged;
    }

    private void OnClicked()
    {
        _appState.CurrentMessage = $"Updated at {DateTime.Now:T}";
    }

    private void OnAppStateChanged()
    {
        InvokeAsync(StateHasChanged);
    }

    public void Dispose()
    {
        _appState.OnChange -= OnAppStateChanged;
    }
}

{% endhighlight %}
{% endtabs %}

**Add service file:**

Create the service file(e.g., AppState.cs) and add the following code:

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

Removing event subscriptions ensures the component instance is not retained in memory after it is removed from the UI. This is particularly important in Blazor Server applications with long lived circuits.

### Virtualizing large data with Syncfusion components

Rendering large datasets without virtualization increases memory allocation and DOM size. Syncfusion Blazor components provide built‑in virtualization support to address this scenario.

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

@page "/"
@implements IAsyncDisposable
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Employees"
        EnableVirtualization="true"
        Height="400">
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
            Employees?.Clear();
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

With virtualization enabled, only visible records are rendered. This reduces memory usage in Blazor WebAssembly and significantly improves scalability in Blazor Server applications.

### Cleaning up JavaScript Interop used by Syncfusion components

Some Syncfusion components rely on JavaScript interop for browser‑specific behavior. Managed interop references must be disposed explicitly to avoid memory retention.

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

@page "/"
@implements IDisposable
@inject IJSRuntime JS
@using System
@using Syncfusion.Blazor.Buttons

<SfButton OnClick="IncrementCount" CssClass="e-primary">Click me</SfButton>

@code {
    private DotNetObjectReference<Home>? dotNetRef;

    protected override void OnInitialized()
    {
        dotNetRef = DotNetObjectReference.Create(this);
    }

    private async Task IncrementCount()
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

Register the script in `App.razor` (or `_Host.cshtml` or `wwwroot/index.html` depending on your project template) inside the `<body>` tag for Blazor WebApp: 

{% tabs %}
{% highlight razor tabtitle="App.razor" %}

<script src="js/site.js"></script>

{% endhighlight %}
{% endtabs %}

Disposing the `DotNetObjectReference` ensures that the component is not retained by JavaScript callbacks in either hosting model.

### Preventing unnecessary rendering

Dynamic rendering of components such as [TextBox](https://www.syncfusion.com/blazor-components/blazor-textbox), [DropDownList](https://www.syncfusion.com/blazor-components/blazor-dropdown-list), and [ComboBox](https://www.syncfusion.com/blazor-components/blazor-combobox) can lead to unnecessary component recreation. The `@key` directive helps stabilize rendering.

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
    private List<Item> Items = new();

    protected override void OnInitialized()
    {
        Items = GetItems();
    }

    async ValueTask IAsyncDisposable.DisposeAsync()
    {
        if (Items != null)
        {
            Items.Clear();
            Items = null;
        }
        await Task.CompletedTask;
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

Using `@key` preserves component identity between renders and reduces memory churn during UI updates.

### Service lifetime considerations in Blazor Server applications

In Blazor Server, each user maintains their own `ServiceProvider` instance per circuit. A Scoped service is created once per circuit/user, ensuring user specific state is isolated. `Singleton` services would be shared across all users, potentially causing data leaks.

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
