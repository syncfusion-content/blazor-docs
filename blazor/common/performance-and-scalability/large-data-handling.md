---
layout: post
title: Efficient Large Data Handling in Blazor Components | Syncfusion®
description: Learn how Blazor components efficiently handle large datasets using paging, virtualization, server side processing, and lazy loading. 
platform: Blazor
control: Common
documentation: ug
---
 
# Handling Large Data in Blazor Components

[Blazor components](https://www.syncfusion.com/blazor-components) handle large datasets efficiently through data virtualization, server side processing, lazy loading, and optimized rendering pipelines. This documentation explains how to load and interact with large datasets in Blazor applications while maintaining performance.
 
## Understanding data size and processing location

Before choosing a data handling approach, it’s important to decide where the data operations should happen, either on the client side or on the server side. Consider dataset size, network speed, bandwidth, and browser memory.

### Client side data processing

Load the entire dataset into the browser and perform operations like sorting, filtering, and searching locally. Best for small datasets (typically under 10,000 records).
 
### Server side data processing

The server handles filtering, sorting, and searching. The client requests only the required data when needed. Ideal for large or growing datasets, especially when data comes from a database.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.Grids

<SfGrid TValue="Order" AllowPaging="true">
    <SfDataManager Url="https://blazor.syncfusion.com/services/production/api/Orders/" Adaptor="Adaptors.WebApiAdaptor"></SfDataManager>
    <GridColumns>
        <GridColumn Field="@nameof(Order.OrderID)" HeaderText="Order ID" IsPrimaryKey="true" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field="@nameof(Order.CustomerID)" HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field="@nameof(Order.OrderDate)" HeaderText="Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field="@nameof(Order.Freight)" HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
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

For more information on remote data binding, see [DataManager Overview](https://blazor.syncfusion.com/documentation/data/getting-started) and [Remote Data Binding](https://blazor.syncfusion.com/documentation/data/adaptors)

N> Use server side processing with paging and virtualization for datasets larger than 10,000 records.

## Enable paging to limit rendered records

Paging divides data into smaller sets and renders only one page at a time. This reduces DOM elements, speeds up initial load, and keeps the interface responsive.

In the [Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid), enable paging using the AllowPaging property:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" AllowPaging="true">
    <GridColumns>
        <GridColumn Field="@nameof(Order.OrderID)" HeaderText="Order ID" IsPrimaryKey="true" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field="@nameof(Order.CustomerID)" HeaderText="Customer Name" Width="150">
    </GridColumn>
</SfGrid>

@code {
    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

For more details, refer to [Handling paging operation](https://blazor.syncfusion.com/documentation/datagrid/connecting-to-adaptors/url-adaptor#handling-paging-operation).

## Use incremental loading (load-on-demand)

Incremental loading (load-on-demand) fetches data in smaller chunks as needed. For example, when navigating pages or scrolling through a list. This keeps the app responsive with large datasets.

The [Blazor TreeGrid](https://www.syncfusion.com/blazor-components/blazor-tree-grid) supports incremental loading through the [LoadChildOnDemand](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_LoadChildOnDemand) feature. Child records load only when a parent row expands.

For more information, refer to the [load-on-demand](https://blazor.syncfusion.com/documentation/treegrid/data-binding?cs-save-lang=1&cs-tab-name=RAZOR&cs-lang=razor#loadchildondemand) documentation.

Incremental loading fetches additional data blocks as needed, while virtualization reduces DOM elements. Use both together for best performance.

## Apply server driven querying

For large datasets, let the server handle filtering, sorting, grouping, and searching. The component sends query parameters to the server, which returns only the processed result.

When a user applies a column filter, the filter criteria are sent to the server, and only matching records return.

For more information, refer to the [Handling server side filtering using adaptors](https://blazor.syncfusion.com/documentation/datagrid/connecting-to-adaptors/url-adaptor#handling-filtering-operation) documentation.

## Use virtualization or infinite scrolling

**Virtualization** renders only the visible items in the viewport. As you scroll, existing UI elements reuse instead of creating new ones.

**Infinite scrolling** auto loads more data as the user scrolls, providing a continuous scrolling experience without pagination controls.

In the [Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid), enable virtualization using the [EnableVirtualization](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_EnableVirtualization) property:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@TaskData" Height="300" EnableVirtualization="true">
    <GridPageSettings PageSize="50"></GridPageSettings>
    <GridColumns>
        <GridColumn Field=@nameof(TaskDetails.TaskID) HeaderText="TaskID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(TaskDetails.Engineer) HeaderText="Engineer" Width="150"></GridColumn>
        <GridColumn Field=@nameof(TaskDetails.Designation) HeaderText="Designation" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(TaskDetails.Estimation) HeaderText="Estimation" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(TaskDetails.Status) HeaderText="Status" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<TaskDetails> TaskData { get; set; }
    protected override void OnInitialized()
    {
        TaskData = TaskDetails.GenerateData(1000);
    }  
}

{% endhighlight %}

{% highlight cs tabtitle="TaskDetails.cs" %}

public class TaskDetails
{
    public static List<TaskDetails> GenerateData(int count)
    {
        var names = new List<string> { "TOM", "Hawk", "Jon", "Chandler", "Monica", "Rachel", "Phoebe", "Gunther", "Ross", "Geller", "Joey", "Bing", "Tribbiani", "Janice", "Bong", "Perk", "Green", "Ken", "Adams" };
        var hours = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        var designations = new List<string> { "Manager", "Engineer 1", "Engineer 2", "Developer", "Tester" };
        var statusValues = new List<string> { "Completed", "Open", "In Progress", "Review", "Testing" };
        var random = new Random();
        var result = new List<TaskDetails>();
        // Generate random data.
        for (int i = 0; i < count; i++)
        {
            result.Add(new TaskDetails
            {
                TaskID = i + 1,
                Engineer = names[random.Next(names.Count)],
                Designation = designations[random.Next(designations.Count)],
                Estimation = hours[random.Next(hours.Count)],
                Status = statusValues[random.Next(statusValues.Count)]
            });
        }
        return result;
    }
    public int TaskID { get; set; }
    public string Engineer { get; set; }
    public string Designation { get; set; }
    public int Estimation { get; set; }
    public string Status { get; set; }
}

{% endhighlight %}
{% endtabs %}

The following measured values may vary based on browser, device, hosting model (Blazor Server or WebAssembly), and data complexity.

| Record Count | With virtualization | Without virtualization |
|--------------|---------------------|------------------------|
| 100 | ~190 ms | ~440 ms |
| 1,000 | ~260 ms | ~1.9 s |
| 5,000 | ~520 ms | ~27 s |
| 10,000 | ~0.9 s | ~91.5 s |
| 20,000 | ~2.0 s | ~219 s |

Without virtualization, render time grows with record count because all rows load into the DOM.

For more information, refer to the [Virtualization](https://blazor.syncfusion.com/documentation/datagrid/virtual-scrolling) and [Infinite scrolling](https://blazor.syncfusion.com/documentation/datagrid/infinite-scrolling).

## Handle streaming data in Blazor Server

[Blazor Server](https://learn.microsoft.com/en-us/aspnet/core/blazor/hosting-models?view=aspnetcore-9.0#blazor-server) uses SignalR for client-server communication. Sending large datasets in a single SignalR message increases message size and affects stability.

Use paging, virtualization, incremental loading, or Web API/gRPC streaming for large data transfers. Keep SignalR for smaller real time updates like notifications.

{% tabs %}
{% highlight C# tabtitle="Program.cs" %}

builder.Services.AddSignalR(hubOptions =>
{
    hubOptions.MaximumReceiveMessageSize = 10 * 1024 * 1024; // 10MB
});

{% endhighlight %}
{% endtabs %}

When persistence is enabled with many columns, SignalR message size limits may be exceeded, causing connection errors. Adjust SignalR configuration or reduce persisted state.

For more details on SignalR configuration, refer to the [official documentation](https://learn.microsoft.com/en-us/aspnet/core/signalr/configuration?view=aspnetcore-9.0&tabs=dotnet#configure-server-options).

## Apply lazy loading for improved user experience

Lazy loading defers data retrieval until it is actually required. Instead of loading all data upfront, fetch data only when the user performs a specific action.

For example, when a component becomes visible, a node expands, or additional details are requested. Lazy loading improves perceived performance by reducing initial load time.

For an example of implementing the [LoadChildOnDemand](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_LoadChildOnDemand) pattern in hierarchical [Gantt Chart](https://www.syncfusion.com/blazor-components/blazor-gantt-chart) components, refer to the [Gantt Chart data binding](https://blazor.syncfusion.com/documentation/gantt-chart/data-binding#load-child-on-demand).

## How Blazor components handle large data

Blazor components are built for large data scenarios and follow these core principles.

*   Virtualized rendering for optimal UI performance
*   Server side query execution using [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) and adaptors
*   Minimal DOM updates and efficient data binding
*   Built‑in support for lazy loading and incremental fetch
*   Scalable design suitable for enterprise grade datasets

By following these principles, Blazor components enable developers to build applications that efficiently manage large datasets while delivering a smooth, responsive, and reliable user experience.

## See also

* [Handling large datasets efficiently in Blazor Gantt Chart](https://www.syncfusion.com/blogs/post/load-on-demand-blazor-gantt-chart)
* [Performance optimization for Blazor DataGrid](https://blazor.syncfusion.com/documentation/datagrid/performance)
* [Blazor rendering and performance optimization](https://blazor.syncfusion.com/documentation/common/performance-and-scalability/blazor-rendering-performance)

