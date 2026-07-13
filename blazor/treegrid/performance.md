---
layout: post
title: Optimizing Blazor TreeGrid Performance | Syncfusion®
description: Learn best practices to optimize Blazor TreeGrid performance when handling large hierarchical datasets and multiple columns.
platform: Blazor
control: TreeGrid
documentation: ug
---

# Performance Optimization for Blazor TreeGrid

The [Blazor TreeGrid](https://www.syncfusion.com/blazor-components/blazor-treegrid) provides advanced features for displaying and managing large hierarchical datasets. When working with extensive datasets or grids containing numerous columns, performance optimization becomes essential to ensure responsive rendering and smooth interactions. This guide outlines proven strategies and best practices for improving TreeGrid performance during data binding and rendering operations.

## How to improve loading performance by binding large dataset

Rendering large hierarchical collections in the Blazor TreeGrid can impact performance because each cell is treated as an individual Blazor component. To maintain responsiveness and reduce rendering overhead, apply the following optimization techniques:

**Key performance optimization techniques**

* **Paging** – Divide data into pages to reduce the number of rows rendered at once.
* **Row virtualization** – Render only rows visible in the viewport.
* **Column virtualization** – Render only visible columns for grids with many columns.
* **Reduce row height or use paging for browser height limitations** – Handle scenarios where virtual scrolling hits browser height limits.

### Optimizing performance with paging 

[Paging](https://blazor.syncfusion.com/documentation/treegrid/paging) divides large collections into smaller, manageable segments, reducing the number of rows rendered at once. This approach improves initial load time and enhances overall responsiveness.

* **Enable paging in the TreeGrid**

    Configure the `Paging` feature to display data across multiple pages. This prevents rendering the entire collection simultaneously, which is especially beneficial for large hierarchical datasets.

* **Combine paging with other features**

    `Paging` works seamlessly with **sorting**, **filtering**, and **editing**, ensuring consistent functionality while improving performance.

For detailed implementation, refer to the paging [documentation](https://blazor.syncfusion.com/documentation/treegrid/paging).

### Optimizing performance with row virtualization

Rendering large collections in a single view can significantly impact performance. The Blazor TreeGrid supports techniques that load data on demand, reducing rendering overhead:

**1. Row virtualization**

Virtualization renders only the rows visible within the viewport instead of the entire collection. This approach minimizes DOM elements and improves responsiveness, even with extensive hierarchical data.

For more information on implementing row virtualization, refer to the [documentation](https://blazor.syncfusion.com/documentation/treegrid/virtualization#row-virtualization).

### Optimizing performance with column virtualization in large no of columns

[Column virtualization](https://blazor.syncfusion.com/documentation/treegrid/virtualization#column-virtualization) in the Blazor TreeGrid optimizes rendering by displaying only the columns currently visible within the viewport. Additional columns are loaded dynamically as the user scrolls horizontally. This approach significantly reduces initial load time and improves responsiveness when working with grids that contain a large number of columns.

Both **row** and **column** virtualization can be enabled together to handle large collections efficiently. This combination ensures that only visible rows and columns are rendered, minimizing DOM elements and enhancing overall performance.

For more information on implementing column virtualization, refer to the [documentation](https://blazor.syncfusion.com/documentation/treegrid/virtualization#column-virtualization).

### How to overcome browser height limitation in virtual scrolling

When virtual scrolling is enabled, the Blazor TreeGrid calculates its height using the formula:

> **Total height = Total record count × RowHeight**

Browsers impose a maximum pixel height for scrollable elements. If the calculated height exceeds this limit, scrolling beyond a certain point becomes impossible. For example, with a [RowHeight](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_RowHeight) of **30px** and **1,000,000** records, the total height is **30,000,000px**, which exceeds most browsers' limits (approximately **22,369,600px**).

This limitation is a browser constraint, not specific to the TreeGrid. It occurs even in standard HTML tables.

**Recommended approaches**

* **Reduce row height using the RowHeight property**

    Lower the [RowHeight](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_RowHeight) property to decrease the overall height. If the height still exceeds the browser limit after adjustment, consider using paging.

* **Use paging instead of virtual scrolling**

    [Paging](https://blazor.syncfusion.com/documentation/treegrid/paging) loads data on demand and avoids height limitations while maintaining compatibility with features such as **Sorting**, **Filtering**, and **Editing**.

For more details, refer to the paging [documentation](https://blazor.syncfusion.com/documentation/treegrid/paging) and the virtual scrolling [documentation](https://blazor.syncfusion.com/documentation/treegrid/virtualization).

## How to improve loading performance by binding data from service

When binding data from a service to the Blazor TreeGrid, consider the following approaches to optimize performance:

**Recommended Practices**

1. **Assign Data in the Created Event**

    Set the [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_DataSource) in the TreeGrid's [Created](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridEvents-1.html#Syncfusion_Blazor_TreeGrid_TreeGridEvents_1_Created) event instead of `OnInitializedAsync`. This ensures the TreeGrid is rendered before data assignment, reducing startup delays.

2. **Use Custom Binding for Large Collections**

    When working with large datasets, the `Created` event may trigger before data retrieval completes. In such cases, implement a custom binding approach using the [Read](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_Read_Syncfusion_Blazor_DataManagerRequest_System_String_) or [ReadAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_ReadAsync_Syncfusion_Blazor_DataManagerRequest_System_String_) method. This allows fetching data on demand and customizing the displayed collection.

For detailed guidance, refer to:

* [Custom Binding](https://blazor.syncfusion.com/documentation/treegrid/custom-binding)
* [Injecting Service into CustomAdaptor](https://blazor.syncfusion.com/documentation/treegrid/custom-binding#inject-service-into-custom-adaptor)

## How to improve loading performance by referring individual script and CSS

To optimize the initial rendering and improve performance during interactions, use the individual NuGet package (**Syncfusion.Blazor.TreeGrid**) along with its corresponding script and CSS files instead of the consolidated package (**Syncfusion.Blazor**).

The consolidated package includes resources for all Blazor components, which increases overall package size and script load time. Referencing only the required TreeGrid resources reduces payload size and improves rendering performance.

For more details, refer to:

* [Install Blazor TreeGrid NuGet Package](https://blazor.syncfusion.com/documentation/treegrid/getting-started-webapp#install-syncfusion-blazor-packages)
* [Add Stylesheet and Script Resources](https://blazor.syncfusion.com/documentation/treegrid/getting-started-webapp#add-stylesheet-and-script-resources)

## How to update cell values without frequent server calls 

The Blazor TreeGrid allows updating cell values efficiently without triggering frequent server calls. This approach is useful for live update scenarios where data is initially bound from the server but subsequent edits should not refresh the database.

Use the [SetRowDataAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_SetRowDataAsync_System_Object__0_System_Boolean_) method to update the TreeGrid UI without affecting the underlying data source. To prevent database updates, pass **true** for the `preventDataUpdate` argument. Additionally, cancel built-in edit operations by setting **args.Cancel** to **true**.

```csharp
public async Task OnClick()
{
    await TreeGrid.SetRowDataAsync(1001, new TreeData()
    {
        TaskID = 1001,
        TaskName = "Updated Task",
        Duration = 5,
        StartDate = DateTime.Now,
        Progress = 50
    }, true);
}
```

## Strategic approaches to addressing latency challenges

When using dialog-oriented features such as [Filtering](https://blazor.syncfusion.com/documentation/treegrid/filtering) or [Dialog Editing](https://blazor.syncfusion.com/documentation/treegrid/editing/dialog-editing), client-to-server communication can introduce delays if the server is hosted in a distant region. Increased network latency impacts responsiveness and overall performance.

**Recommended Solution**

* **Reduce Network Latency**

    Host the server in a region closer to the majority of users. This minimizes the distance between client and server, improving response times.

For more details, refer to the documentation: [Hosting and Deploying Blazor Applications](https://learn.microsoft.com/en-us/aspnet/core/blazor/host-and-deploy/server/?view=aspnetcore-9.0)

## Microsoft Excel limitation while exporting millions of records to Excel file format

Microsoft Excel supports a maximum of 1,048,576 rows per worksheet. Exporting millions of records to Excel is not possible due to this limitation.

For large datasets, use alternative formats such as **CSV** (Comma-Separated Values) or other file types that can handle extensive data efficiently.

For more details, refer to the documentation: [Excel Specifications and Limits](https://support.microsoft.com/en-gb/office/excel-specifications-and-limits-1672b34d-7043-467e-8e27-269d656771c3)
