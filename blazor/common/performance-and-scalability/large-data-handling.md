---
layout: post
title: Efficient Large Data Handling in Blazor Components | Syncfusion®
description: Learn how Blazor components efficiently handle large datasets using paging, virtualization, server side processing, and lazy loading. 
platform: Blazor
control: Common
documentation: ug
---
 
# Handling Large Data in Blazor Components

Handling large datasets efficiently is a critical requirement for modern Blazor applications. With the right data-handling strategies, applications can reliably display and interact with thousands of records while maintaining a fast and responsive user interface.

[Blazor components](https://www.syncfusion.com/blazor-components) are built to ensure responsive rendering, smooth scrolling, and efficient memory usage, even when working with large volumes of data. By leveraging capabilities such as data virtualization, server side data operations, lazy loading, and optimized rendering pipelines, these components minimize UI overhead and deliver consistent performance.

This document provides guidance on how to load and interact with large datasets effectively in Blazor applications using **Blazor components**, enabling scalable data experiences without compromising usability or performance.
 
## Understanding data size and processing location

Before choosing a data handling approach, it’s important to decide where the data operations should happen, either on the client side in the browser or on the server side in backend services. This decision usually depends on factors such as how large the dataset is, network speed, bandwidth, and how much memory is available in the browser.

### Client side data processing

Client side processing means loading the entire dataset into the browser and performing operations like sorting, filtering, and searching locally. This approach is generally suitable when the dataset is small and easy to handle. It works when the browser can comfortably manage all the data without affecting performance, and reducing server communication is a priority.
 
### Server side data processing

Server side processing transfers the workload from the browser to the server. Instead of sending all the data at once, the client requests only the required portion when needed. For instance, when a user applies a filter or navigates between pages, a request is sent to the server, which processes it and returns only the relevant data. This method is well-suited for handling large or continuously growing datasets, especially when the data is sourced from databases or external services, as it improves performance, scalability, and reliability.

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

For more information on configuring server side data operations and remote data binding using Blazor components, see the following documentation:

- [DataManager Overview](https://blazor.syncfusion.com/documentation/data/getting-started)
- [Remote Data Binding](https://blazor.syncfusion.com/documentation/data/adaptors)

N> Client side processing is generally suitable for smaller datasets, typically fewer than 10,000 simple records. When working with larger datasets, it is better to rely on server side processing along with techniques like paging and virtualization. This approach helps maintain better performance and ensures the application remains scalable and responsive.

## Enable paging to limit rendered records

Paging divides data into smaller sets and renders only one page at a time.  This approach helps reduce the number of elements rendered in the DOM, which improves the initial load time and keeps the interface responsive.

Paging is most commonly used techniques for handling moderate to large datasets.

By using paging, applications can load faster, consume less browser memory, and provide a more structured and predictable navigation experience for users.

For example, when paging is enabled in the [Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid), the component requests only a single page of records from the server at a time, reducing data transfer and improving performance. For more details, refer to the DataGrid documentation on [Handling paging operation](https://blazor.syncfusion.com/documentation/datagrid/connecting-to-adaptors/url-adaptor#handling-paging-operation).

## Use incremental loading (load-on-demand)

Incremental loading, also known as load-on-demand, retrieves data in smaller chunks based on user interaction. Instead of loading all records at once, additional data is fetched only when it is needed, such as when a user navigates through the data or scrolls within a component.

This approach is particularly helpful when working with very large datasets, where loading everything upfront would impact performance and responsiveness.

Incremental loading is triggered by actions like moving between pages, scrolling through a list, or expanding rows and nodes in hierarchical components. Because data is loaded progressively, the application feels faster and remains responsive to user actions.

For example, the [Blazor TreeGrid](https://www.syncfusion.com/blazor-components/blazor-tree-grid) supports incremental loading through the [LoadChildOnDemand](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_LoadChildOnDemand) feature, where child records are retrieved from the server only when a parent row is expanded. This avoids unnecessary data loading and improves efficiency.

For more information, refer to the [load-on-demand](https://blazor.syncfusion.com/documentation/treegrid/data-binding?cs-save-lang=1&cs-tab-name=RAZOR&cs-lang=razor#loadchildondemand) documentation.

N> Incremental loading retrieves additional data blocks as needed, whereas virtualization reduces the number of DOM elements rendered in the UI. These techniques are often used together, where incremental loading handles backend data fetching and virtualization optimizes client side rendering.

## Apply server driven querying

For large datasets, filtering, sorting, grouping, and searching should be handled on the server. In this approach, the component sends query parameters to the server, and only the processed result set is returned.

This method helps avoid sending large amounts of data to the client and reduces the amount of memory and processing required in the browser. As a result, applications remain more efficient and scalable, especially when handling data intensive scenarios.

For example, when a user applies a column filter in the DataGrid, the filter criteria are sent to the server. The server then processes the request and returns only the matching records, ensuring efficient data retrieval and optimal performance.

For more information, refer to the documentation [Handling server side filtering using adaptors](https://blazor.syncfusion.com/documentation/datagrid/connecting-to-adaptors/url-adaptor#handling-filtering-operation).

## Use virtualization or infinite scrolling

**Virtualization** improves performance by rendering only the visible items in the viewport. As the user scrolls, existing UI elements are reused instead of creating new ones.

**Infinite scrolling** loads additional data blocks automatically as the user scrolls, eliminating the need for explicit pagination controls and providing a continuous scrolling experience.

These techniques are especially useful when working with very large datasets, where smooth scrolling is important.

Virtualization and infinite scrolling are supported in several Blazor components. For example, in the DataGrid, virtualization can be enabled using the [EnableVirtualization](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_EnableVirtualization) property to render only the visible records for improved performance.

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

The following measured values may vary based on browser, device, hosting model (Blazor Server or WebAssembly), and data complexity.

| Record Count | With virtualization | Without virtualization |
|--------------|---------------------|------------------------|
| 100 | ~190 ms | ~440 ms |
| 1,000 | ~260 ms | ~1.9 s |
| 5,000 | ~520 ms | ~27 s |
| 10,000 | ~0.9 s | ~91.5 s |
| 20,000 | ~2.0 s | ~219 s |

N> Without virtualization, render time increases as record count grows because all rows are rendered in the DOM. With virtualization enabled, render time remains nearly constant by limiting the DOM rows to those visible in the viewport, ensuring smooth UI performance for larger datasets.

For more information, refer to the **Blazor DataGrid** documentation for [Virtualization](https://blazor.syncfusion.com/documentation/datagrid/virtual-scrolling) and [Infinite scrolling](https://blazor.syncfusion.com/documentation/datagrid/infinite-scrolling).

## Handle streaming data in Blazor Server

Blazor Server applications rely on SignalR to handle communication between the client and the server. When very large datasets are sent in a single SignalR message, it can increase the message size significantly and affect application stability, including higher memory usage on the server circuit.

To avoid these issues, it is better not to send large amounts of data in one go. Instead, techniques like paging, virtualization, or incremental loading should be used for UI-related data. For scenarios that involve large or bulk data transfers, it is more efficient to use a Web API or a gRPC streaming endpoint, while keeping SignalR focused on smaller, real-time updates such as notifications or UI interactions.

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

## Apply lazy loading for improved user experience

Lazy loading defers data retrieval until it is actually required. Instead of loading all data upfront, fetch data only when the user performs a specific action.

In many cases, data is loaded only after a user action. For example, it can be retrieved as a component becomes visible, a node is expanded in a hierarchical structure, or additional details or related records are requested.

Lazy loading improves perceived performance by reducing initial load time and allows users to interact with the application while data is being retrieved in the background.

For an example of implementing the [LoadChildOnDemand](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_LoadChildOnDemand) pattern in hierarchical components, refer to the [Gantt data binding](https://blazor.syncfusion.com/documentation/gantt-chart/data-binding#load-child-on-demand).

## How Blazor components handle large data

Blazor components are built with large‑data scenarios and follow these core principles.

*   Virtualized rendering for optimal UI performance
*   Server side query execution using [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) and adaptors
*   Minimal DOM updates and efficient data binding
*   Built‑in support for lazy loading and incremental fetch
*   Scalable design suitable for enterprise‑grade datasets

By following these principles, Blazor components enable developers to build applications that efficiently manage large datasets while delivering a smooth, responsive, and reliable user experience.

## See also

* [Handling large datasets efficiently in Blazor Gantt Chart](https://www.syncfusion.com/blogs/post/load-on-demand-blazor-gantt-chart)
* [Performance Optimization for Blazor DataGrid](https://blazor.syncfusion.com/documentation/datagrid/performance)

