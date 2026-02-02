---
layout: post
title: Syncfusion Blazor Gantt Chart Performance Optimization Guide
description: Learn how to optimize the loading and rendering performance of the Syncfusion Blazor Gantt Chart component, especially when working with large datasets.
platform: Blazor
control: Gantt Chart
documentation: ug
---

# Performance tips for Blazor Gantt Chart component

This guide provides practical strategies to enhance the loading performance of the Blazor Gantt Chart component, especially when dealing with large datasets and multiple columns. It provides valuable insights into effective strategies and best practices for binding extensive data sources without encountering performance degradation. It includes actionable tips to ensure smooth data binding and a responsive user experience.

## How to improve loading performance when binding large dataset?

A Gantt chart consists of rows, columns, and taskbars. For example, binding 10 rows and 10 columns results in rendering 100 elements in the Document Object Model (DOM) of Grid area and 10 elements in the Document Object Model (DOM) of chart area. To ensure optimal loading performance for the component, it is recommended to limit the number of rows and columns rendered. This approach helps in efficiently managing large datasets and enhancing the overall user experience.

### Optimizing performance with virtualization

To enhance the efficiency of the Blazor Gantt Chart, particularly when handling large datasets, it is recommended to use [virtualization](https://blazor.syncfusion.com/documentation/gantt-chart/virtualization) techniques. These methods can significantly reduce the load on your application, improving overall performance.

1.	**Row Virtualization**: [Row virtualization](https://blazor.syncfusion.com/documentation/gantt-chart/virtualization#row-virtualization) in the Blazor Gantt Chart allows the efficient handling and display of large datasets by rendering only the visible rows within the Gantt viewport, rather than loading the entire dataset simultaneously. This approach optimizes rendering and reduces the DOM size, resulting in faster load times and smoother interactions. This feature is particularly effective during vertical scrolling, as rows are loaded on-demand based on the current scroll position.

2. **Column Virtualization**: [Column virtualization](https://blazor.syncfusion.com/documentation/gantt-chart/virtualization#column-virtualization) optimizes the rendering of Gantt Chart with a large number of columns by displaying only the columns currently within the viewport. This feature renders column cells dynamically during horizontal scrolling, significantly reducing the initial loading time and improving performance by limiting the number of DOM elements rendered at once.

3.	**Timeline Virtualization**: [Timeline virtualization](https://blazor.syncfusion.com/documentation/gantt-chart/virtualization#timeline-virtualization) optimizes the rendering of extensive timespan in the Gantt Chart. By loading only the visible timeline cells, typically three times the width of the Gantt element, this feature reduces the amount of data rendered at once. Additional timeline cells are loaded dynamically during horizontal scrolling, which helps maintain performance even with complex or long project timelines.

4.  **Load On Demand**: The [Load On Demand](https://blazor.syncfusion.com/documentation/gantt-chart/data-binding#load-child-on-demand) feature improves performance by initially fetching only the root-level records from the data source. As the user interacts with the Gantt Chart, such as expanding parent nodes or scrolling vertically, additional tasks are fetched dynamically based on the viewport’s position. This ensures that only the necessary data is rendered, enhancing responsiveness and reducing initial load times.

For the most comprehensive performance optimization, combining row, column, and timeline virtualization in the Blazor Gantt Chart allows efficient management of extensive datasets and timelines. By dynamically loading only the visible rows, columns, and timeline cells, this approach minimizes memory usage and ensures smooth scrolling and interaction across large projects. This combined strategy significantly improves performance, reduces initial load times, and enhances the overall user experience by maintaining a responsive and efficient Gantt Chart.

## How to improve performance of Gantt chart in Blazor WASM application?

This section provides performance guidelines for using the Syncfusion<sup style="font-size:70%">&reg;</sup> Gantt Chart component efficiently in Blazor WebAssembly (WASM) applications. For general Blazor WebAssembly performance best practices, please refer to the official guidelines [here](https://learn.microsoft.com/en-us/aspnet/core/blazor/performance?view=aspnetcore-8.0).

1.	[Avoid unnecessary component renders](https://blazor.syncfusion.com/documentation/gantt-chart/webassembly-performance#avoid-unnecessary-component-renders)
2.	[Avoid unnecessary initial auto-scheduling validation](https://blazor.syncfusion.com/documentation/gantt-chart/webassembly-performance#avoid-unnecessary-initial-auto-scheduling-validation)

## Optimizing performance with AutoCalculateDateScheduling

In the Blazor Gantt Chart component, the start and end dates of tasks are automatically calculated by default based on various factors, including working times, holidays, weekends, and task dependencies (predecessors). While this feature ensures accurate scheduling, it can lead to performance issues when rendering large datasets due to the intensive calculations involved in data validation.

To improve performance when working with large datasets, you can disable this automatic date calculation by setting the [AutoCalculateDateScheduling](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_AutoCalculateDateScheduling) property to **false**. Disabling this feature stops the Gantt Chart from recalculating dates based on the aforementioned factors, thus reducing the processing load and enhancing performance.

```csharp
    <SfGantt DataSource="@TaskCollection" AutoCalculateDateScheduling="false">  
    </SfGantt>
```
N> When setting `AutoCalculateDateScheduling` property to **false**, you must provide the valid data source; otherwise, the Gantt chart will render with invalid dates.

## How to improve loading performance when binding large data by showing custom text or element?

When integrating images or custom template elements into Gantt chart columns in the Blazor Gantt Chart, it is recommended to use the [Column Template](https://blazor.syncfusion.com/documentation/gantt-chart/column-template) feature rather than customizing data through event handlers such as [RowDataBound](https://blazor.syncfusion.com/documentation/gantt-chart/events#rowdatabound) or [QueryCellInfo](https://blazor.syncfusion.com/documentation/gantt-chart/events#querycellinfo). These events are triggered for every row and cell during rendering, which can significantly slow down the component’s rendering process, especially with large datasets. Additionally, using these events for custom element rendering can lead to performance degradation over time due to the accumulation of rendered elements.

By utilizing the Column Template feature, you can efficiently render custom content without experiencing rendering delays, ensuring a smoother and more responsive user experience.

## How to improve loading performance by binding data from service?

1. Instead of fetching and binding data directly in the `OnInitializedAsync` method, it is advisable to set the data source in the Gantt Chart's [Created](https://blazor.syncfusion.com/documentation/gantt-chart/events#created) event. Fetching data within `OnInitializedAsync` can delay the application's startup time and affect the rendering of the Gantt Chart, especially if the service call is slow. By assigning the data inside the `Created` event, the Gantt Chart will have already been created/rendered. This way, you are only assigning the data that was previously fetched and stored in a variable, rather than making a service call during the component’s initialization.

2. If your service returns a large dataset, there is a chance that the `Created` event might be triggered before the data fetching in `OnInitializedAsync` completes. In such cases, use a custom binding approach to manage data more effectively. You can utilize custom binding through the `Read or ReadAsync` methods to handle data retrieval and binding. This approach allows you to fetch data from the service and assign it to the Gantt Chart’s [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_DataSource) property as needed.

* [Custom binding](https://blazor.syncfusion.com/documentation/gantt-chart/custom-binding)
* [Injecting service into CustomAdaptor](https://blazor.syncfusion.com/documentation/gantt-chart/custom-binding#inject-service-into-custom-adaptor)

## How to improve loading performance by referring individual script and CSS?

Instead of using the consolidated `Syncfusion.Blazor` package, which includes all Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components and can result in a larger package size, you should use the specific NuGet package for the Gantt Chart component, such as `Syncfusion.Blazor.Gantt`. This approach ensures that only the necessary components and dependencies for the Gantt Chart are included, leading to improved performance and reduced load times.

When configuring your Blazor `Gantt Chart`, use individual script and CSS files instead of a single large package file. This practice allows for more efficient loading and rendering of the component by reducing the amount of data processed during initialization. By referring to individual scripts and CSS files, you can ensure that only the necessary resources are loaded, which enhances performance and speeds up the initial rendering of the Gantt Chart.

Refer the below documentation
* [Individual nuget package](https://blazor.syncfusion.com/documentation/gantt-chart/getting-started-with-web-app#install-syncfusion-blazor-gantt-and-themes-nuget-in-the-blazor-web-app)
* [Adding script and CSS](https://blazor.syncfusion.com/documentation/gantt-chart/getting-started-with-web-app#add-stylesheet-and-script-resources)

These strategies help improve initial rendering performance and deliver a smoother user experience.

## How to optimize server-side data operations with adaptors?

The Blazor Gantt Chart supports various adaptors (OData, ODataV4, WebAPI, URL, etc.) to facilitate server-side data operations and CRUD functionalities. By utilizing these adaptors along with the [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) component, you can seamlessly bind remote data sources to the Gantt Chart and execute actions. During data operations such as filtering and sorting, the corresponding action queries are generated according to the adaptor’s requirements. It is crucial to handle these actions on the application side and return the processed data back to the Gantt Chart. For efficient data processing, the suggested order for returning processed data to the Gantt Chart is as follows:

* Filtering
* Sorting

## Strategic approaches to addressing latency challenges

Understanding the concerns related to latency in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Gantt Chart component, several factors contributing to responsiveness issues have been identified. Notably, when using features like filtering, taskbar resizing, and dialog edit in the Gantt Chart, delays may occur due to client-server interactions, if the server is located far from the client.

### Potential solutions to mitigate delay

**Network latency**: Increased distance between the client and server can result in higher latency, affecting the responsiveness of client-server communication.

**Solution**: Host the server in a region closer to the majority of your users to reduce network latency. Selecting a server location nearer to your target audience can significantly enhance response times.

By considering these factors and implementing the recommended solutions, you can minimize delays in client-to-server interactions in your Blazor Gantt Chart application. Continuous testing and performance monitoring are essential to ensure optimal responsiveness for your users.

For more detailed guidance, refer to the [documentation](https://learn.microsoft.com/en-us/aspnet/core/blazor/host-and-deploy/server?view=aspnetcore-8.0) on hosting and deploying Blazor applications.

## Microsoft Excel limitation while exporting millions of records to excel file format

Microsoft Excel supports a maximum of 1,048,576 rows per sheet. Therefore, it is not feasible to export millions of records into a single Excel file due to this limitation. For handling large datasets, consider exporting data in formats such as CSV (Comma-Separated Values), which can efficiently manage larger volumes of data.
For more details on Microsoft Excel's specifications and limits, you can refer to the official [documentation](https://support.microsoft.com/en-gb/office/excel-specifications-and-limits-1672b34d-7043-467e-8e27-269d656771c3).