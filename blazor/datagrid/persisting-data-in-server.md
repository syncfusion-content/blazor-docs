---
layout: post
title: Persisting data in the server in Blazor DataGrid | Syncfusion
description: Learn how to persist data in the server using the Syncfusion Blazor DataGrid, including supported adaptors and integration with RESTful services.
platform: Blazor
control: DataGrid
documentation: ug
---

# Persisting data in the server in Blazor DataGrid

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid enables you to persist data changes made in the Grid to a server or database using RESTful web services. All CRUD (Create, read, update, and delete) operations performed in the Grid are managed by the [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html), which can bind to server-side data sources and synchronize updates with the backend. This ensures that any changes made in the UI are reliably saved to your data store.

> The [ODataAdaptor](https://blazor.syncfusion.com/documentation/data/adaptors#odata-adaptor) persists data in the server according to the **OData** protocol.

Syncfusion<sup style="font-size:70%">&reg;</sup> provides multiple adaptors to handle different server protocols and APIs, enabling smooth integration with RESTful services. Below are the various adaptors you can use to persist data in the Grid.

**Using UrlAdaptor**

The [UrlAdaptor](https://blazor.syncfusion.com/documentation/data/adaptors#url-adaptor) is the default adaptor for connecting the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid to remote data services via URLs. It enables seamless data binding and interaction with custom APIs or any remote service that exposes endpoints for CRUD operations. Use the `UrlAdaptor` when your API has custom logic for handling data operations.

For more information, see the [UrlAdaptor documentation](https://blazor.syncfusion.com/documentation/datagrid/connecting-to-adaptors/url-adaptor).

**Using ODataV4Adaptor**

The [ODataV4Adaptor](https://blazor.syncfusion.com/documentation/data/adaptors#odatav4-adaptor) allows the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid to integrate with OData V4 services, supporting efficient data querying and manipulation. You can perform CRUD operations using the `ODataV4Adaptor` to ensure compatibility with OData-compliant backend.

For more information, see the [ODataV4Adaptor documentation](https://blazor.syncfusion.com/documentation/datagrid/connecting-to-adaptors/odatav4-adaptor).

**Using WebApiAdaptor**

The [WebApiAdaptor](https://blazor.syncfusion.com/documentation/data/adaptors#web-api-adaptor) is designed for use with Web APIs that follow the **OData** protocol. It extends the capabilities of the `ODataAdaptor` and enables smooth communication between the Grid and OData-based Web APIs for data retrieval and updates.

For more information, see the [WebApiAdaptor documentation](https://blazor.syncfusion.com/documentation/datagrid/connecting-to-adaptors/web-api-adaptor).

**Using GraphQLAdaptor**

GraphQL is a powerful query language for APIs designed to provide a more efficient alternative to traditional REST APIs. It allows you to precisely fetch the data you need, reducing over-fetching and under-fetching of data. GraphQL offers a flexible and expressive syntax for querying, enabling clients to request only the specific data they require.

The [GraphQLAdaptor](https://blazor.syncfusion.com/documentation/data/adaptors#graphql-service-binding) simplifies the interaction between the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid and GraphQL servers, allowing for efficient data retrieval with support for various operations such as CRUD (Create, Read, Update, and Delete).

For more information, see the [GraphQLAdaptor documentation](https://blazor.syncfusion.com/documentation/datagrid/connecting-to-adaptors/graphql-adaptor).
