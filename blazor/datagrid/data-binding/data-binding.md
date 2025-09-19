---
layout: post
title: Data Binding in Blazor DataGrid | Syncfusion
description: Learn how to bind data from various sources to the Syncfusion Blazor DataGrid and explore supported data binding options.
platform: Blazor
control: DataGrid
documentation: ug
---

# Data Binding in Blazor DataGrid

Data binding is a fundamental technique that ntegrates data into the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid, enabling the creation of dynamic and interactive Grid views. This feature is particularly valuable when working with large datasets or when data needs to be fetched remotely. 

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid utilizes the [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) for advanced data operations or directly accepts an `IEnumerable` collection for simpler scenarios. TThe primary property for data binding is[DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_DataSource), which can be assigned either an `SfDataManager` instance or a direct list of business objects.

The Blazor DataGrid supports two main categories of data binding:

*   **Local Data Binding**: Data is bound directly from an `IEnumerable` collection that is already present within your Blazor application. This is typically used for client-side data handling.
*   **Remote Data Binding**: Data is retrieved from an external service, such as a RESTful API, OData endpoint, or GraphQL API. For this, `SfDataManager` is used with various adaptors to facilitate communication with the remote source.

> When assigning an `IEnumerable<T>` to the `DataSource` property, the component type (`TValue`) is inferred from the enumerable's type. However, when using `SfDataManager` for data binding, the Grid's `TValue` property must be explicitly provided to specify the type of data being bound (e.g., `<SfGrid TValue="Order">`).
