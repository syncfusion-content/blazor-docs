---
layout: post
title: Large data handling in Blazor | Syncfusion®
description: Learn how Syncfusion® Blazor components efficiently handle large datasets using paging, virtualization, server side processing, and lazy loading. 
platform: Blazor
control: Common
documentation: ug
---
 
# Handling Large Data in Syncfusion® Blazor components

Handling large datasets efficiently is a critical requirement for modern Blazor applications. With the right data-handling strategies, applications can reliably display and interact with thousands of records while maintaining a fast and responsive user interface.

Syncfusion® Blazor components are built to ensure responsive rendering, smooth scrolling, and efficient memory usage, even when working with large volumes of data. By leveraging capabilities such as data virtualization, server side data operations, lazy loading, and optimized rendering pipelines, these components minimize UI overhead and deliver consistent performance.

This document provides guidance on how to load and interact with large datasets effectively in Blazor applications using Syncfusion® Blazor components, enabling scalable data experiences without compromising usability or performance.
 
## Understanding data size and processing location
 
Before selecting a data-handling strategy, determine where data operations should be performed on the client side (in the browser) or on the server side (backend services). The choice should balance factors such as data volume, network latency, bandwidth usage, and client memory constraints.

### Client side data processing
 
Client side processing loads the complete dataset into the browser and performs operations such as sorting, filtering, and searching locally. This approach is recommended only for small and manageable datasets.

**Use client side processing when:**

* The dataset size is small
* All required data can be safely loaded into browser memory
* Minimizing server interaction is preferred and frequent server requests are unnecessary
 
### Server side data handling

server side processing delegates data operations to the server. The client requests only the required data, and the server applies paging, filtering, or sorting before returning the result.

**Use server side processing when:**

* Working with large or unbounded datasets
* Data is sourced from a database or remote service
* Application performance, scalability, and reliability are critical

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

For more information on configuring server side data operations and remote data binding using Syncfusion® Blazor components, see the following documentation:

- [DataManager overview](https://blazor.syncfusion.com/documentation/data/getting-started) and [remote data binding](https://blazor.syncfusion.com/documentation/data/adaptors)

N> Client side processing is generally suitable for small datasets (approximately fewer than 10,000 simple records). For larger datasets, it is recommended to use server side processing combined with paging and virtualization to ensure optimal performance and scalability.

## Enable paging to limit rendered records

Paging divides data into smaller sets and renders only one page at a time. This reduces the number of DOM elements created during rendering and improves initial load time.

Paging is the first and most commonly recommended approach when working with moderate to large datasets.

**Benefits of paging:**

* Faster initial load time
* Reduced browser memory usage
* Predictable navigation for users

For example, when paging is enabled in the DataGrid, the component requests only a single page of records from the server at a time, reducing data transfer and improving performance. For more details, refer to the DataGrid documentation on [Handling paging operation](https://blazor.syncfusion.com/documentation/datagrid/connecting-to-adaptors/url-adaptor#handling-paging-operation).

## Use incremental loading (load-on-demand)

Incremental loading (load-on-demand) retrieves data in small blocks based on user interaction. Instead of fetching all records at once, additional data is loaded as the user navigates or scrolls.

This approach is especially useful when the total number of records is very high.

**Common triggers for incremental loading include:**

* Changing pages
* Scrolling within a component
* Expanding a node or row

Incremental loading improves perceived performance and keeps the UI responsive.

For example, The Syncfusion® Blazor TreeGrid supports incremental loading using the **LoadChildOnDemand** feature. Child records are retrieved from the server only when a parent row is expanded.

For more information, refer to the [Syncfusion® Blazor TreeGrid](https://blazor.syncfusion.com/documentation/treegrid/data-binding?cs-save-lang=1&cs-tab-name=C#loadchildondemand)

N> Incremental loading retrieves additional data blocks as needed, whereas virtualization reduces the number of DOM elements rendered in the UI. These techniques are often used together, where incremental loading handles backend data fetching and virtualization optimizes Client side rendering.

## Apply server driven querying

For large datasets, filtering, sorting, grouping, and searching should be handled on the server. In this approach, the component sends query parameters to the server, and only the processed result set is returned.

**Why server driven querying is important:**

* Avoids transferring large volumes of data to the client
* Minimizes Client side memory usage and computation
* Enables better scalability for data-intensive applications

For example, when a user applies a column filter in the DataGrid, the filter criteria are sent to the server. The server then processes the request and returns only the matching records, ensuring efficient data retrieval and optimal performance.

For more information, refer to the documentation [handling server side filtering using adaptors](https://blazor.syncfusion.com/documentation/datagrid/connecting-to-adaptors/url-adaptor#handling-filtering-operation).

## Use virtualization or infinite scrolling

**Virtualization** improves performance by rendering only the visible items in the viewport. As the user scrolls, existing UI elements are reused instead of creating new ones.

**Infinite scrolling** loads additional data blocks automatically as the user scrolls, eliminating the need for explicit pagination controls and providing a continuous scrolling experience.

These approaches are recommended when:

* The dataset contains a very large number of records
* Smooth scrolling is required
* Paging alone is not sufficient

Virtualization and infinite scrolling are supported in several Syncfusion® Blazor components. For example, in the DataGrid, virtualization can be enabled using the [EnableVirtualization](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_EnableVirtualization) property to render only the visible records for improved performance.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@TaskData" Height="300" EnableVirtualization="true">
    <GridPageSettings PageSize="50"></GridPageSettings>
    <GridColumns>
        <GridColumn Field=@nameof(TaskDetails.TaskID) HeaderText="TaskID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(TaskDetails.Engineer) HeaderText="Engineer" Width="150"></GridColumn>
        <GridColumn Field=@nameof(TaskDetails.Designation) HeaderText="Designation" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(TaskDetails.Estimation) HeaderText="Estimation" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(TaskDetails.Status) HeaderText="Status" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
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

The following measured values may vary based on browser, device, hosting model(Blazor Server or WebAssembly), and data complexity.

| Record Count | With virtualization | Without virtualization |
|--------------|---------------------|------------------------|
| 100 | ~190 ms | ~440 ms |
| 1,000 | ~260 ms | ~1.9 s |
| 5,000 | ~520 ms | ~27 s |
| 10,000 | ~0.9 s | ~91.5 s |
| 20,000 | ~2.0 s | ~219 s |

N> Without virtualization, render time increases as record count grows because all rows are rendered in the DOM. With virtualization enabled, render time remains nearly constant by limiting the DOM rows to those visible in the viewport, ensuring smooth UI performance for larger datasets.

For more information, refer to the Syncfusion® Blazor DataGrid documentation for [Virtualization](https://blazor.syncfusion.com/documentation/datagrid/virtual-scrolling) and [Infinite scrolling](https://blazor.syncfusion.com/documentation/datagrid/infinite-scrolling).

## Handle streaming data in Blazor Server

Blazor Server applications use SignalR for communication between the client and the server. Sending very large datasets in a single SignalR message can increase message sizes and affect application stability and circuit memory.

**Key recommendations**:

* Avoid sending large datasets in one request
* Use paging, virtualization, or incremental loading for UI data
* For large or bulk data transfers, use a Web API or gRPC streaming endpoint, and reserve SignalR for incremental UI updates, notifications, and real-time interactions

When features such as persistence are enabled with a large number of columns, SignalR message size limits may be exceeded, potentially resulting in connection errors. In such cases, adjust the SignalR configuration or reduce the amount of state being persisted.

{% tabs %}
{% highlight C# tabtitle="Program.cs" %}

builder.Services.AddSignalR(hubOptions =>
{
    hubOptions.MaximumReceiveMessageSize = 10 * 1024 * 1024; // 10MB
});

{% endhighlight %}
{% endtabs %}

For more details on SignalR configuration, refer to the [official documentation](https://learn.microsoft.com/en-us/aspnet/core/signalr/configuration?view=aspnetcore-9.0&tabs=dotnet#configure-server-options).

## Apply lazy-loading for improved user experience

Lazy loading defers data retrieval until it is actually required. Instead of loading all data upfront, fetch data only when the user performs a specific action.

**lazy-loading scenarios include:**

* Loading data when a component becomes visible
* Fetching child items when a node is expanded (LoadChildOnDemand patterns)
* Retrieving detail records or related data on demand

Lazy loading improves perceived performance by reducing initial load time and allows users to interact with the application while data is being retrieved in the background.

For an example of implementing the **LoadChildOnDemand** pattern in hierarchical components, refer to the [Gantt data binding](https://blazor.syncfusion.com/documentation/gantt-chart/data-binding#load-child-on-demand).

## How Syncfusion® Approaches Large Data Handling

Syncfusion® Blazor components are built with large‑data scenarios and follow these core principles:

*   Virtualized rendering for optimal UI performance
*   Server side query execution using `SfDataManager` and adaptors
*   Minimal DOM updates and efficient data binding
*   Built‑in support for lazy loading and incremental fetch
*   Scalable design suitable for enterprise‑grade datasets

By following these principles, Syncfusion® Blazor components enable developers to build applications that efficiently manage large datasets while delivering a smooth, responsive, and reliable user experience.

## See also

* [Handling Large Data Sets Efficiently in Syncfusion® Blazor Gantt Chart](https://www.syncfusion.com/blogs/post/load-on-demand-blazor-gantt-chart)
* [Performance Optimization for Syncfusion® Blazor DataGrid](https://blazor.syncfusion.com/documentation/datagrid/performance)