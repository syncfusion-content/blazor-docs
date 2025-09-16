---
layout: post
title: Data Binding in Blazor DataGrid | Syncfusion
description: Learn how to bind data from various sources to the Syncfusion Blazor DataGrid and explore supported data binding options in detail.
platform: Blazor
control: DataGrid
documentation: ug
---

# Data Binding in Blazor DataGrid

Data binding is a fundamental technique that empowers the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid to integrate data into its interface, enabling the creation of dynamic and interactive Grid views. This feature is particularly valuable when working with large datasets or when data needs to be fetched remotely. 

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid utilizes the [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html), which supports both RESTful JSON data service binding and IEnumerable binding. The key property, [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_DataSource), can be assigned to a `SfDataManager` instance or list of business objects.

It supports two kinds of data binding methods:

* Local data
* Remote data

> When using [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_DataSource) as `IEnumerable<T>`, the component type (TValue) will be inferred from its value. When using [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) for data binding, the **TValue** must be provided explicitly in the Grid.
