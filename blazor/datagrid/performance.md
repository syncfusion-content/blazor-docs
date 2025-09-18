---
layout: post
title: Performance tips for Blazor DataGrid Component | Syncfusion
description: Checkout and learn here all about how to improve the loading performance of Blazor DataGrid even binding large data set.
platform: Blazor
control: DataGrid
documentation: ug
---

# Performance tips for Blazor DataGrid

This article is a comprehensive guide on improving the loading performance of the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid, especially when dealing with large datasets along with large number of columns. It provides valuable insights into the steps that need to be followed to bind a large data source without experiencing any performance degradations. By offering detailed explanations and actionable tips, this resource aims to empower readers with the knowledge and best practices necessary to optimize the performance of the Grid during data binding, ensuring a smooth and efficient user experience.

## How to improve loading performance by binding large dataset

In Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid, the framework takes about 0.06 milliseconds to render one component in the page. You can find more details in the official [documentation link](https://learn.microsoft.com/en-us/aspnet/core/blazor/performance?view=aspnetcore-8.0#avoid-thousands-of-component-instances). In Grid each cell(td) is rendered as separate Blazor component so, it is recommended to render only a limited number of rows and columns to guarantee the best loading performance for the component.

### Optimizing performance with paging 

To boost the performance efficiency of your application, especially when dealing with large datasets, it is advised to implement paging. [Paging](https://blazor.syncfusion.com/documentation/datagrid/paging) allows you to display Grid data in segmented pages, facilitating easier navigation through substantial datasets. This feature proves particularly beneficial in enhancing the overall performance of your application. For more information on implementing paging, you can refer to the [documentation](https://blazor.syncfusion.com/documentation/datagrid/paging) section dedicated to this feature.

### Optimizing performance with row virtualization or infinite scrolling

To enhance your application's efficiency, especially when dealing with substantial datasets, it is recommended to either using [virtualization](https://blazor.syncfusion.com/documentation/datagrid/virtualization) or [infinite scrolling](https://blazor.syncfusion.com/documentation/datagrid/infinite-scrolling). Implementing these techniques can significantly reduce the load on your application and elevate its overall performance.

1.	**Virtualization**: The Virtual scrolling feature in the Grid enables the efficient handling and display of large volumes of data without compromising performance. This approach optimizes the rendering process by loading only the visible rows within the Grid viewport, rather than rendering the entire dataset simultaneously. For more information on implementing row virtualization, you can refer to the [documentation](https://blazor.syncfusion.com/documentation/datagrid/virtualization) section dedicated to this feature.

2.	**Infinite scrolling**: The Infinite Scrolling feature in the Grid is a powerful tool for seamlessly handling extensive data sets without compromising Grid performance. It operates on a "load-on-demand" concept, ensuring that data is fetched only when needed. In the default infinite scrolling mode, a new block of data is loaded each time the scrollbar reaches the end of the vertical scroller. For more information on implementing infinite scrolling, you can refer to the [documentation](https://blazor.syncfusion.com/documentation/datagrid/infinite-scrolling) section dedicated to this feature.

### Optimizing performance with column virtualization in large no of columns

[Column virtualization](https://blazor.syncfusion.com/documentation/datagrid/virtualization#column-virtualization) feature in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid that allows you to optimize the rendering of columns by displaying only the columns that are currently within the viewport. It allows horizontal scrolling to view additional columns. This feature is particularly useful when dealing with Grids that have a large number of columns, as it helps to improve the performance and reduce the initial loading time.

It is possible to enable both row and column virtualization. This feature allows for efficient handling of large datasets by dynamically loading only the visible rows and columns, optimizing performance and enhancing the overall responsiveness of the Grid. For more information on implementing column virtualization , you can refer to the [documentation](https://blazor.syncfusion.com/documentation/datagrid/virtualization#column-virtualization) section dedicated to this feature.

### How to overcome browser height limitation in virtual scrolling

You can load millions of records in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid by using virtual scrolling, where the Grid loads and renders rows on-demand while scrolling vertically. As a result, Grid lightens the browser’s load by minimizing the DOM elements and rendering elements visible in the viewport. The height of the Grid is calculated using the **Total Records Count * RowHeight** property.

The browser has some maximum pixel height limitations for the scroll bar element. The content placed above the maximum height can’t be scrolled if the element height is greater than the browser’s maximum height limit. The browser height limit affects the virtual scrolling of the Grid. When a large number of records are bound to the Grid, it can only display the records until the maximum height limit of the browser. Once the browser’s height limit is reached while scrolling, the user won’t able to scroll further to view the remaining records.

For example, if the [RowHeight](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_RowHeight) is set as 30px and the total record count is 1000000(1 million), then the height of the Grid element will be 30,000,000 pixels. In this case, the browser’s maximum height limit for a div is about 22,369,600 (The maximum pixel height limitation differs for different browsers). The records above the maximum height limit of the browser can’t be scrolled.
This height limitation is not related to the Grid. It fully depends on the default behavior of the browser. The same issue is reproduced in the normal HTML table too.

The Grid has an option to overcome this limitation of the browser in the following ways.

**Solution 1: Using RowHeight property**

You can reduce the row height using the rowHeight property of the Grid. It will reduce the overall height to accommodate more rows. But this approach optimizes the limitation, but if the height limit is reached after reducing row height also, you have to opt for the previous solution or use paging.

**Solution 2: Using paging instead of virtual scrolling**

Similar to virtual scrolling, the paging feature also loads the data in an on-demand concept. Pagination is also compatible with all the other features(Grouping, Editing, etc.) in Grid. So, use the paging feature instead of virtual scrolling to view a large number of records in the Grid without any kind of performance degradation or browser height limitation.

### How to prevent connection disconnected error when loading a large number of columns with enabled persistence
The problem arises specifically when the Grid attempts to set persistent data with a larger number of columns. It is recommended to increase the buffer size of the websocket. Check the below provided code snippet added in the Program.cs file and official [documentation](https://learn.microsoft.com/en-us/aspnet/core/signalr/configuration?view=aspnetcore-3.0&tabs=dotnet#configure-server-options) link.

```csharp
builder.Services.AddSignalR(hubOptions =>
{
    hubOptions.MaximumReceiveMessageSize = 10 * 1024 * 1024; // 10MB
});
```

## How to improve performance of Blazor DataGrid in WASM application

This section provides performance guidelines for using Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid efficiently in Blazor WebAssembly application. The general framework Blazor WebAssembly performance best practice/guidelines can be found [here](https://learn.microsoft.com/en-us/aspnet/core/blazor/performance?view=aspnetcore-8.0).

1.	[Avoid unnecessary component renders](https://blazor.syncfusion.com/documentation/datagrid/webassembly-performance#avoid-unnecessary-component-renders)
2.	[Avoid unnecessary component renders after grid events](https://blazor.syncfusion.com/documentation/datagrid/webassembly-performance#avoid-unnecessary-component-renders-after-grid-events)

## How to improve loading performance by binding data from service

1.	When binding data to the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid from a service, it's advisable to set the data source in the Grid [Created](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_Created) event instead of the `OnInitializedAsync` method. If you call the data-fetching method within `OnInitializedAsync`, the delay in fetching data from the service can impact the application's startup time and the rendering of the Grid. However, if you assign the data inside the `Created` event, the Grid will have already been created/rendered. Since there are no service request calls inside the `Created` event, you are simply assigning the data already fetched from `OnInitializedAsync` to the Grid's [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_DataSource) property within the Created event handler.

2.	When dealing with a service that returns a large dataset, there's a possibility that the `Created` event might be triggered before the completion of the `OnInitializedAsync`. In such scenarios, it is recommended to employ a custom binding approach for associating data with the Grid. This method enables customization of the displayed data using the `Read/ReadAsync` method. Instead of relying on `OnInitializedAsync`, you can invoke your service within the `Read/ReadAsync` method and provide the data for display in the Grid. For detailed information, you can check the below documentations
* [Custom binding](https://blazor.syncfusion.com/documentation/datagrid/custom-binding)
* [Injecting service into CustomAdaptor](https://blazor.syncfusion.com/documentation/datagrid/custom-binding#inject-service-into-custom-adaptor)

## How to improve loading performance by referring individual script and CSS

To improve the performance of Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid during the initial render as well as certain actions, suggested you to refer individual NuGet package (Syncfusion.Blazor.Grid) along with its specified script files. In the consolidated package (Syncfusion.Blazor) all the components will be defined and hence size of the package will be more. Along with its script file size will be more since scripts necessary for all the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components will be defined inside it. 

When package and script file size is more, there might be delay or performance lag in rendering the component in certain specification compared to Grid rendered using individual scripts and NuGet. Individual Nuget package will contain all the necessary and required dependent component sources along with its script reference. So it is not necessary to refer the dependent component externally while referring the Individual package.

Refer the below documentations
* [Individual nuget package](https://blazor.syncfusion.com/documentation/datagrid/getting-started-with-web-app#install-syncfusion-blazor-grid-and-themes-nuget-in-the-blazor-web-app)
* [Adding script and CSS](https://blazor.syncfusion.com/documentation/datagrid/getting-started-with-web-app#add-stylesheet-and-script-resources)

So to improve the performance of Grid during the initial rendering, request you to refer Individual NuGet package and scripts.

## How to update cell values without frequent server calls 

Efficiently update cell values without the need for frequent server calls, especially beneficial for live update scenarios. Even when the data is initially bound from the server, performing edit operations can be done without triggering a database refresh. Utilize the [SetRowDataAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_SetRowDataAsync_System_Object__0_System_Boolean_) method to update the Grid without affecting the database. Additionally, you can prevent the built-in edit functionality by setting `args.Cancel` to **true**. If you pass the `preventDataUpdate` argument value as **true** to the `SetRowDataAsync` method, it will prevent the database from updating and only refresh the UI.

```csharp
public async Task OnClick()
    {
        await Grid.SetRowDataAsync(10001, new Orders() { OrderID = 10001, CustomerID = "Updated", Freight = 20, OrderDate = DateTime.Now,ShipCity="new" },true);
    }
```

## How to optimize server-side data operations with adaptors

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid provides support for various adaptors (OData, ODataV4, WebAPI, URL, etc.) to facilitate server-side data operations and CRUD functionalities. By leveraging these adaptors along with the [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) component, you can seamlessly bind remote data sources to the Grid and execute actions. During data operations like filtering, sorting, and paging, the corresponding action queries are generated as per the adaptor's requirements. It is crucial to handle these actions on the application end and return the processed data back to the Grid. Refer to the documentation for comprehensive details. It's worth noting that for efficient data processing, the suggested order for returning processed data to the Grid is as follows
* Filtering
* Sorting
* Aggregates
* Paging
* Grouping

## Strategic approaches to addressing latency challenges

Understanding the concerns you are facing regarding the lagging responsiveness of the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components, your situation has been reviewed, and several factors contributing to this issue have been identified. It's important to note that when using dialog-oriented features like filtering and dialog editing, a call is made from the client to the server to share position details, resulting in some delay if the servers are located in a distant location.

Additionally, potential solutions to mitigate the delay are offered:

**Network Latency**: When the server is in a different region, the increased distance between the client and server leads to higher latency, impacting the responsiveness of client-server communication.

**Solution**: Host the server in a region closer to the majority of your users to reduce network latency. Choosing a server location nearer to your target audience can significantly improve response times.

Considering these factors and implementing the suggested solutions can minimize the delay in client-to-server calls when hosting the server in a different region in your Blazor application. Testing and monitoring performance are crucial to ensuring optimal responsiveness for your users.

For more information and further guidance, refer to the [documentation](https://learn.microsoft.com/en-us/aspnet/core/blazor/host-and-deploy/server?view=aspnetcore-8.0) on hosting and deploying Blazor applications

## Microsoft Excel limitation while exporting millions of records to Excel file format

By default, Microsoft Excel supports only 1,048,576 records in an Excel sheet. Hence it is not possible to export millions of records to Excel. You can refer the [documentation](https://support.microsoft.com/en-gb/office/excel-specifications-and-limits-1672b34d-7043-467e-8e27-269d656771c3) link for more details on Microsoft excel specifications and limits. So suggest to export the data in CSV (Comma-Separated Values) or other formats that can handle large datasets more efficiently than Excel.
