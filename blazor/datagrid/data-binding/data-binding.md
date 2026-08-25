---
layout: post
title: Blazor Grid Data Binding | Syncfusion
description: Learn how to bind data from various data sources in Blazor Data Grid and explore local, remote, and custom data binding options.
platform: Blazor
control: DataGrid
documentation: ug
---

# Data Binding in Blazor Data Grid

Data binding is a fundamental technique that empowers the [Blazor Data Grid](https://www.syncfusion.com/blazor-components/blazor-datagrid) to integrate data into its interface, enabling the creation of dynamic and interactive Grid views. This feature is particularly valuable when working with large datasets or when data needs to be fetched remotely. 

The Blazor DataGrid uses [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html), which supports RESTful JSON service binding and IEnumerable binding. The [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_DataSource) property can be assigned to a `SfDataManager` instance or to a list of business objects.

The Blazor Data Grid supports two data binding approaches:

* [Local data](https://blazor.syncfusion.com/documentation/datagrid/data-binding/local-data)
* [Remote data](https://blazor.syncfusion.com/documentation/datagrid/data-binding/remote-data)

> When using [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_DataSource) as `IEnumerable<T>`, the component type (TValue) will be inferred from its value. When using [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) for data binding, the **TValue** must be provided explicitly in the Data Grid.
