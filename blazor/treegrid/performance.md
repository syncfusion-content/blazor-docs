---
layout: post
title: Performance tips for Blazor TreeGrid Component | Syncfusion
description: Checkout and learn here all about how to improve the loading performance of Blazor TreeGrid even binding large data set.
platform: Blazor
control: TreeGrid
documentation: ug
---

# Performance tips for Blazor TreeGrid Component

This article is a comprehensive guide on improving the loading performance of the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor TreeGrid, especially when dealing with large datasets along with a large number of columns. It provides valuable insights into the steps that need to be followed to bind a large data source without experiencing any performance degradations. By offering detailed explanations and actionable tips, this resource aims to empower readers with the knowledge and best practices necessary to optimize the performance of the TreeGrid during data binding, ensuring a smooth and efficient user experience.

## How to improve loading performance by binding large dataset

In Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor TreeGrid, the framework takes about 0.06 milliseconds to render one component in the page. You can find more details in the official [documentation](https://learn.microsoft.com/en-us/aspnet/core/blazor/performance?view=aspnetcore-8.0#avoid-thousands-of-component-instances). In TreeGrid, each cell (td) is rendered as a separate Blazor component, so it is recommended to render only a limited number of rows and columns to guarantee the best loading performance for the component.

### Optimizing performance with paging

To boost the performance efficiency of your application, especially when dealing with large datasets, it is advised to implement paging. [Paging](https://blazor.syncfusion.com/documentation/treegrid/paging) allows you to display TreeGrid data in segmented pages, facilitating easier navigation through substantial datasets. This feature proves particularly beneficial in enhancing the overall performance of your application. For more information on implementing paging, refer to the [paging documentation](https://blazor.syncfusion.com/documentation/treegrid/paging).

### Optimizing performance with row virtualization

To enhance your application's efficiency, especially when dealing with substantial datasets, it is recommended to use [virtualization](https://blazor.syncfusion.com/documentation/treegrid/virtualization). Implementing virtualization can significantly reduce the load on your application and elevate its overall performance.

**Virtualization**: The virtual scrolling feature in the TreeGrid enables the efficient handling and display of large volumes of data without compromising performance. This approach optimizes the rendering process by loading only the visible rows within the TreeGrid viewport, rather than rendering the entire dataset simultaneously. For more information on implementing row virtualization, refer to the [row virtualization documentation](https://blazor.syncfusion.com/documentation/treegrid/virtualization#row-virtualization).

### Optimizing performance with column virtualization

The [column virtualization](https://blazor.syncfusion.com/documentation/treegrid/virtualization#column-virtualization) feature in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor TreeGrid allows you to optimize the rendering of columns by displaying only the columns that are currently within the viewport. It allows horizontal scrolling to view additional columns. This feature is particularly useful when dealing with a TreeGrid that has a large number of columns, as it helps to improve performance and reduce the initial loading time.

It is possible to enable both row and column virtualization. This feature allows for efficient handling of large datasets by dynamically loading only the visible rows and columns, optimizing performance and enhancing the overall responsiveness of the TreeGrid. For more information on implementing column virtualization, refer to the [column virtualization documentation](https://blazor.syncfusion.com/documentation/treegrid/virtualization#column-virtualization).

### How to overcome browser height limitation in virtual scrolling

You can load millions of records in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor TreeGrid by using virtual scrolling, where the TreeGrid loads and renders rows on-demand while scrolling vertically. As a result, TreeGrid lightens the browser's load by minimizing the DOM elements and rendering elements visible in the viewport. The height of the TreeGrid is calculated using the **Total Records Count * RowHeight** property.

The browser has some maximum pixel height limitations for the scroll bar element. The content placed above the maximum height cannot be scrolled if the element height is greater than the browser's maximum height limit. The browser height limit affects the virtual scrolling of the TreeGrid. When a large number of records are bound to the TreeGrid, it can only display the records until the maximum height limit of the browser. Once the browser's height limit is reached while scrolling, the user will not be able to scroll further to view the remaining records.

For example, if the [RowHeight](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_RowHeight) is set as 30px and the total record count is 1,000,000 (1 million), then the height of the TreeGrid element will be 30,000,000 pixels. In this case, the browser's maximum height limit for a div is about 22,369,600 pixels (the maximum pixel height limitation differs for different browsers). The records above the maximum height limit of the browser cannot be scrolled.

This height limitation is not related to the TreeGrid. It fully depends on the default behavior of the browser. The same issue is reproduced in a normal HTML table as well.

The TreeGrid provides the following options to overcome this browser limitation.

**Solution 1: Using RowHeight property**

You can reduce the row height using the [RowHeight](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_RowHeight) property of the TreeGrid. It will reduce the overall height to accommodate more rows. If the height limit is still reached after reducing the row height, use paging instead.

**Solution 2: Using paging instead of virtual scrolling**

Similar to virtual scrolling, the paging feature also loads the data in an on-demand concept. Paging is compatible with all other features (Filtering, Editing, etc.) in TreeGrid. Use the paging feature instead of virtual scrolling to view a large number of records in the TreeGrid without any performance degradation or browser height limitation.

### How to prevent connection disconnected error when loading large number of columns with persistence enabled

The problem arises specifically when the TreeGrid attempts to persist data with a large number of columns. It is recommended to increase the buffer size of the WebSocket. Refer to the following code snippet to be added in the `Program.cs` file and the official [SignalR configuration documentation](https://learn.microsoft.com/en-us/aspnet/core/signalr/configuration?view=aspnetcore-3.0&tabs=dotnet#configure-server-options).

{% tabs %}
{% highlight c# tabtitle="Program.cs" %}

builder.Services.AddSignalR(hubOptions =>
{
    hubOptions.MaximumReceiveMessageSize = 10 * 1024 * 1024; // 10MB
});

{% endhighlight %}
{% endtabs %}

## How to improve loading performance by binding data from service

When binding data to the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor TreeGrid from a service, it is advisable to set the data source in the TreeGrid [Created](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridEvents-1.html#Syncfusion_Blazor_TreeGrid_TreeGridEvents_1_Created) event instead of the `OnInitializedAsync` method. If the data-fetching method is called within `OnInitializedAsync`, the delay in fetching data from the service can impact the application's startup time and the rendering of the TreeGrid. However, if the data is assigned inside the `Created` event, the TreeGrid will have already been created and rendered. Since there are no service request calls inside the `Created` event, the data already fetched from `OnInitializedAsync` is simply assigned to the TreeGrid's [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_DataSource) property within the `Created` event handler.

When dealing with a service that returns a large dataset, there is a possibility that the `Created` event might be triggered before the completion of `OnInitializedAsync`. In such scenarios, it is recommended to use a custom binding approach for associating data with the TreeGrid. This method enables customization of the displayed data using the `Read/ReadAsync` method. Instead of relying on `OnInitializedAsync`, the service can be invoked within the `Read/ReadAsync` method to provide the data for display in the TreeGrid. For detailed information, refer to the following documentation:

* [Custom binding](https://blazor.syncfusion.com/documentation/treegrid/custom-binding)
* [Inject service into CustomAdaptor](https://blazor.syncfusion.com/documentation/treegrid/custom-binding#inject-service-into-custom-adaptor)

## How to improve loading performance by referring individual NuGet package and script

To improve the performance of the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor TreeGrid during the initial render as well as certain actions, it is recommended to refer to the individual NuGet package (`Syncfusion.Blazor.TreeGrid`) along with its specified script files. In the consolidated package (`Syncfusion.Blazor`), all the components are defined and hence the size of the package is larger. Similarly, the script file size is larger since scripts for all Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components are defined inside it.

When the package and script file sizes are larger, there may be a delay or performance lag in rendering the component compared to TreeGrid rendered using individual scripts and NuGet. The individual NuGet package contains all the necessary and required dependent component sources along with its script reference, so it is not necessary to refer to dependent components externally.

Refer to the following documentation:
* [Individual NuGet package](https://blazor.syncfusion.com/documentation/treegrid/getting-started-webapp#install-syncfusion-blazor-treegrid-and-themes-nuget-in-the-app)
* [Adding script and CSS](https://blazor.syncfusion.com/documentation/treegrid/getting-started-webapp#include-syncfusion-styles-and-scripts)

## How to update cell values without frequent server calls

Cell values can be updated efficiently without the need for frequent server calls, which is especially beneficial for live update scenarios. Even when the data is initially bound from the server, edit operations can be performed without triggering a database refresh. Use the [SetRowDataAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_SetRowDataAsync_System_Object__0_) method to update the TreeGrid without affecting the database. Additionally, the built-in edit functionality can be prevented by setting `args.Cancel` to **true**. If the `preventDataUpdate` argument value is passed as **true** to the `SetRowDataAsync` method, it will prevent the database from updating and only refresh the UI.

{% tabs %}
{% highlight razor %}

@code {
    public async Task OnClick()
    {
        var data = new BusinessObject() { TaskId = 2, TaskName = "Test Add", StartDate = new DateTime(2017, 10, 23), Duration = 10, Progress = 70, Priority = "Critical" };
        await TreeGrid.SetRowDataAsync(2, data);
    }
}

{% endhighlight %}
{% endtabs %}

## How to optimize server-side data operations with adaptors

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor TreeGrid provides support for various adaptors (OData, ODataV4, WebAPI, URL, etc.) to facilitate server-side data operations and CRUD functionalities. By leveraging these adaptors along with the [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) component, remote data sources can be seamlessly bound to the TreeGrid and actions can be executed. During data operations like filtering, sorting, and paging, the corresponding action queries are generated as per the adaptor's requirements. It is crucial to handle these actions on the application end and return the processed data back to the TreeGrid. For efficient data processing, the suggested order for returning processed data to the TreeGrid is as follows:

* Filtering
* Sorting
* Aggregates
* Paging

## Strategic approaches to addressing latency challenges

When using dialog-oriented features like filtering and dialog editing, a call is made from the client to the server to share position details, which can result in some delay if the servers are located in a distant region. The following factors contribute to this issue and their recommended solutions are listed below.

**Network Latency**: When the server is in a different region, the increased distance between the client and server leads to higher latency, impacting the responsiveness of client-server communication.

**Solution**: Host the server in a region closer to the majority of your users to reduce network latency. Choosing a server location nearer to your target audience can significantly improve response times.

Implementing the suggested solution can minimize the delay in client-to-server calls. Testing and monitoring performance are crucial to ensuring optimal responsiveness for users.

For more information, refer to the [documentation on hosting and deploying Blazor applications](https://learn.microsoft.com/en-us/aspnet/core/blazor/host-and-deploy/server?view=aspnetcore-8.0).

## Microsoft Excel limitation while exporting millions of records

By default, Microsoft Excel supports only 1,048,576 records in an Excel sheet. Hence, it is not possible to export millions of records to Excel. Refer to the [Excel specifications and limits documentation](https://support.microsoft.com/en-gb/office/excel-specifications-and-limits-1672b34d-7043-467e-8e27-269d656771c3) for more details. It is recommended to export the data in CSV (Comma-Separated Values) or other formats that can handle large datasets more efficiently than Excel.
