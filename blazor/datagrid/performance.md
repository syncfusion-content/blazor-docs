---
layout: post
title: Optimizing Blazor DataGrid Performance | Syncfusion
description: Learn best practices to optimize Syncfusion Blazor DataGrid performance when handling large datasets and multiple columns.
platform: Blazor
control: DataGrid
documentation: ug
---

# Performance tips for Blazor DataGrid

This article is a comprehensive guide on improving the loading performance of the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid, especially when dealing with large datasets and a large number of columns. It provides clear guidance on how to bind large data sources without encountering performance degradations. By offering detailed explanations and actionable tips, this resource aims to empower readers with the knowledge and best practices necessary to optimize the performance of the Blazor DataGrid during data binding, ensuring a smooth and efficient user experience.

## How to improve loading performance by binding large dataset

Rendering large collections in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid can impact performance because each cell is rendered individually. To maintain responsiveness and reduce rendering overhead, apply the following optimization techniques:

**Key performance optimization techniques**

* **Paging** – Divide data into pages to reduce the number of rows rendered at once.
* **Row virtualization** – Render only rows visible in the viewport.
* **Infinite scrolling** – Load data blocks on demand as the user scrolls.
* **Column virtualization** – Render only visible columns for grids with many columns.
* **Reduce row height or use paging for browser height limitations** – Handle scenarios where virtual scrolling hits browser height limits.
* **SignalR buffer adjustment for persistence** – Prevent connection errors when persisting large column sets.

### Optimizing performance with paging 

To boost the performance efficiency of your application, especially when dealing with large datasets, it is advised to implement paging. [Paging](https://blazor.syncfusion.com/documentation/datagrid/paging) divides large collections into smaller, manageable segments, reducing the number of rows rendered at once. This feature proves particularly beneficial in enhancing the overall performance of your application.

* **Enable paging in the DataGrid**

    Configure the `Paging` feature to display data across multiple pages. This prevents rendering the entire collection simultaneously.

* **Combine paging with other features**

    `Paging` works seamlessly with **grouping**, **sorting**, and **editing**, ensuring consistent functionality while improving performance.

For detailed implementation, refer to the paging [documentation](https://blazor.syncfusion.com/documentation/datagrid/paging).

### Optimizing performance with row virtualization or infinite scrolling

Rendering large collections in a single view can significantly impact performance. The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid supports techniques that load data on demand, reducing rendering overhead:

**1. Row virtualization**

Virtualization renders only the rows visible within the viewport instead of the entire collection. This approach minimizes DOM elements and improves responsiveness. This approach optimizes the rendering process by loading only the visible rows within the DataGrid viewport, rather than rendering the entire dataset simultaneously.

For more information on implementing row virtualization, refer to the [documentation](https://blazor.syncfusion.com/documentation/datagrid/virtualization).

**2. Infinite scrolling**

The Infinite Scrolling feature in the React Data Grid is a powerful tool for seamlessly handling extensive data sets without compromising DataGrid performance. It operates on a **“load-on-demand”** , ensuring that data is fetched only when needed. In the default infinite scrolling mode, a new block of data is loaded each time the scrollbar reaches the end of the vertical scroller.

For more information on implementing infinite scrolling, refer to the [documentation](https://blazor.syncfusion.com/documentation/datagrid/infinite-scrolling).

Both techniques are effective for handling large collections without compromising performance.

### Optimizing performance with column virtualization in large no of columns

[Column virtualization](https://blazor.syncfusion.com/documentation/datagrid/virtualization#column-virtualization) in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid optimizes rendering by displaying only the columns currently visible within the viewport. Additional columns are loaded dynamically as the user scrolls horizontally. This feature is particularly useful when dealing with DataGrids that have a large number of columns, as it helps to improve the performance and reduce the initial loading time.

Both **row** and **column** virtualization can be enabled together to handle large collections efficiently. This combination ensures that only visible rows and columns are rendered, minimizing DOM elements and enhancing overall performance.

For more information on implementing column virtualization, refer to the [documentation](https://blazor.syncfusion.com/documentation/datagrid/virtualization#column-virtualization).

### How to overcome browser height limitation in virtual scrolling

When virtual scrolling is enabled, the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid calculates its height using the formula:

> **Total height = Total record count × RowHeight**

Browsers impose a maximum pixel height for scrollable elements. If the calculated height exceeds this limit, scrolling beyond a certain point becomes impossible. For example, with a [RowHeight](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_RowHeight) of **30px** and **1,000,000** records, the total height is **30,000,000px**, which exceeds most browsers’ limits (approximately **22,369,600px**).

This limitation is a browser constraint, not specific to the DataGrid. It occurs even in standard HTML tables.

**Recommended approaches**

* **Reduce row height using the RowHeight property**

    Lower the [RowHeight](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_RowHeight) property to decrease the overall height. If the height still exceeds the browser limit after adjustment, consider using paging.

* **Use paging instead of virtual scrolling**

    [Paging](https://blazor.syncfusion.com/documentation/datagrid/paging) loads data on demand and avoids height limitations while maintaining compatibility with features such as **Grouping** and **Editing**, **Sorting**, and **Filtering**.

For more details, refer to the paging [documentation](https://blazor.syncfusion.com/documentation/datagrid/paging) and the virtual scrolling [documentation](https://blazor.syncfusion.com/documentation/datagrid/virtual-scrolling).

### Preventing connection errors when persistence is enabled

When the DataGrid attempts to apply persistent settings with a large number of columns, **SignalR** may encounter buffer size limitations, resulting in connection errors. To resolve this, increase the maximum message size for SignalR in the application configuration.

```csharp
builder.Services.AddSignalR(hubOptions =>
{
    hubOptions.MaximumReceiveMessageSize = 10 * 1024 * 1024; // 10MB
});
```

For more details on SignalR configuration, refer to the [official documentation](https://learn.microsoft.com/en-us/aspnet/core/signalr/configuration?view=aspnetcore-9.0&tabs=dotnet#configure-server-options). 

## How to improve performance of Blazor DataGrid in WASM application

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid can be optimized for efficient rendering in Blazor WebAssembly applications. Following best practices helps reduce unnecessary rendering and improve responsiveness.

**Recommended Practices**

1. [Avoid unnecessary component renders](https://blazor.syncfusion.com/documentation/datagrid/webassembly-performance#avoid-unnecessary-component-renders)

    * Prevent redundant rendering operations to improve performance.

2. [Avoid unnecessary renders after DataGrid events](https://blazor.syncfusion.com/documentation/datagrid/webassembly-performance#avoid-unnecessary-component-renders-after-grid-events)

    * Ensure DataGrid events do not trigger unnecessary re-renders.

For additional guidelines, refer to the official Blazor WebAssembly performance [documentation](https://learn.microsoft.com/en-us/aspnet/core/blazor/performance/?view=aspnetcore-8.0).

## How to improve loading performance by binding data from service

When binding data from a service to the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid, consider the following approaches to optimize performance:

**Recommended Practices**

1. **Assign Data in the Created Event**

    Set the [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_DataSource) in the DataGrid’s [Created](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_Created) event instead of `OnInitializedAsync`. This ensures the DataGrid is rendered before data assignment, reducing startup delays.

2. **Use Custom Binding for Large Collections**

    When working with large datasets, the `Created` event may trigger before data retrieval completes. In such cases, implement a custom binding approach using the [Read](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_Read_Syncfusion_Blazor_DataManagerRequest_System_String_) or [ReadAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_ReadAsync_Syncfusion_Blazor_DataManagerRequest_System_String_) method. This allows fetching data on demand and customizing the displayed collection.

For detailed guidance, refer to:

* [Custom Binding](https://blazor.syncfusion.com/documentation/datagrid/connecting-to-adaptors/custom-adaptor)
* [Injecting Service into CustomAdaptor](https://blazor.syncfusion.com/documentation/datagrid/connecting-to-adaptors/custom-adaptor#inject-service-into-custom-adaptor)

## How to improve loading performance by referring individual script and CSS

To optimize the initial rendering and improve performance during interactions, use the individual NuGet package (**Syncfusion.Blazor.Grid**) along with its corresponding script and CSS files instead of the consolidated package (**Syncfusion.Blazor**).

The consolidated package includes resources for all Syncfusion Blazor controls, which increases overall package size and script load time. Referencing only the required DataGrid resources reduces payload size and improves rendering performance.

For more details, refer to:

* [Install Syncfusion Blazor Grid NuGet Package](https://blazor.syncfusion.com/documentation/datagrid/getting-started-with-web-app#install-syncfusion-blazor-grid-and-themes-nuget-in-the-blazor-web-app)
* [Add Stylesheet and Script Resources](https://blazor.syncfusion.com/documentation/datagrid/getting-started-with-web-app#add-stylesheet-and-script-resources)

## How to update cell values without frequent server calls 

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid allows updating cell values efficiently without triggering frequent server calls. This approach is useful for live update scenarios where data is initially bound from the server but subsequent edits should not refresh the database.

Use the [SetRowDataAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_SetRowDataAsync_System_Object__0_System_Boolean_) method to update the DataGrid UI without affecting the underlying data source. To prevent database updates, pass **true** for the `preventDataUpdate` argument. Additionally, cancel built-in edit operations by setting **args.Cancel** to **true**.

```csharp
public async Task OnClick()
{
    await Grid.SetRowDataAsync(10001, new Orders()
    {
        OrderID = 10001,
        CustomerID = "Updated",
        Freight = 20,
        OrderDate = DateTime.Now,
        ShipCity = "New"
    }, true);
}
```

## How to optimize server-side data operations with adaptors

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid supports multiple adaptors such as [OData](https://blazor.syncfusion.com/documentation/datagrid/data-binding/remote-data#binding-with-odata-services), [ODataV4](https://blazor.syncfusion.com/documentation/datagrid/connecting-to-adaptors/odatav4-adaptor), [WebAPI](https://blazor.syncfusion.com/documentation/datagrid/connecting-to-adaptors/web-api-adaptor), and [URL](https://blazor.syncfusion.com/documentation/datagrid/connecting-to-adaptors/url-adaptor) for performing server-side data operations and CRUD actions. These adaptors work with the [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) to bind remote data sources and execute operations efficiently.

During actions like **filtering**, **sorting**, **paging**, and **grouping**, the DataGrid generates queries based on the adaptor configuration. The application must process these queries and return the appropriate data to the DataGrid. For optimal performance, handle operations in the following order:

* Filtering
* Sorting
* Aggregates
* Paging
* Grouping

For more details, refer to the [Remote Data Binding](https://blazor.syncfusion.com/documentation/datagrid/data-binding/remote-data) documentation.

## Strategic approaches to addressing latency challenges

When using dialog-oriented features such as [Filtering](https://blazor.syncfusion.com/documentation/datagrid/filtering) or [Dialog Editing](https://blazor.syncfusion.com/documentation/datagrid/dialog-editing), client-to-server communication can introduce delays if the server is hosted in a distant region. Increased network latency impacts responsiveness and overall performance.

**Recommended Solution**

* **Reduce Network Latency**

    Host the server in a region closer to the majority of users. This minimizes the distance between client and server, improving response times.

For more details, refer to the documentation: [Hosting and Deploying Blazor Applications](https://learn.microsoft.com/en-us/aspnet/core/blazor/host-and-deploy/server/?view=aspnetcore-9.0)

## Microsoft Excel limitation while exporting millions of records to Excel file format

Microsoft Excel supports a maximum of 1,048,576 rows per worksheet. Exporting millions of records to Excel is not possible due to this limitation.

For large datasets, use alternative formats such as **CSV** (Comma-Separated Values) or other file types that can handle extensive data efficiently.

For more details, refer to the documentation:[ Excel Specifications and Limits](https://support.microsoft.com/en-gb/office/excel-specifications-and-limits-1672b34d-7043-467e-8e27-269d656771c3)