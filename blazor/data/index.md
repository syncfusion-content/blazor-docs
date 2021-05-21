---
layout: post
title: Adaptors in Blazor DataManager component - Syncfusion
description: Checkout and learn about Adaptors in Blazor DataManager component of Syncfusion, and more details
platform: Blazor
component: DataManager
documentation: ug
---

# Overview

The [`SfDataManager`](https://help.syncfusion.com/cr/aspnetcore-blazor/Syncfusion.Blazor.Data.SfDataManager.html) is a data management component used for performing data operations in applications. It acts as an abstraction for using local data source - array of objects and remote data source - web services returning JSON, JSONP, oData or XML.

## Key Features

* **DataManager**: Communicates with the data source and returns the desired result based on the provided Query.
* **Query**: DataManager has APIs for generating data query with ease.
* **CRUD in individual requests and Batch**: CRUD operations are fully supported. The options are enabled to commit the data as single or multiple requests.
* **Adaptors**: Adaptors are specific DataSource type interfaces that are used by DataManager to communicate with the DataSource. DataManager has three in-built adaptors - ODataAdaptor, JsonAdaptor and UrlAdaptor.
* Calculate and maintain aggregates, sorting order and paging.
