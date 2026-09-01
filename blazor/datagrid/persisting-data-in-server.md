---
layout: post
title: Blazor Grid Persisting Data on the Server | Syncfusion
description: Learn how to persist Blazor Data Grid data in server-side applications using UrlAdaptor, OData, Web API, and GraphQL adaptors.
platform: Blazor
control: DataGrid
documentation: ug
---

# Persisting Data to the Server in Blazor Data Grid

The [Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) supports persisting data changes to a server or database using RESTful web services. The [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) manages Create, Read, Update, and Delete (CRUD) requests when Grid editing settings enable the related operations. The configuration synchronizes changes from the Grid UI with the backend.

Before persisting data changes, enable the required CRUD operations through [GridEditSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEditSettings.html) by setting `AllowAdding`, `AllowEditing`, and `AllowDeleting` to **true** as needed. Define a primary-key column by setting `IsPrimaryKey` to **true**. For more information, refer to [Editing in Blazor Data Grid](https://blazor.syncfusion.com/documentation/datagrid/editing).

## Supported Adaptors

Syncfusion® provides multiple adaptors for DataGrid integration with server protocols and APIs. [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) manages data operations for every adaptor. Grid editing settings and matching Grid interactions trigger CRUD requests. Backend services must implement appropriate endpoints for CRUD operations.

## UrlAdaptor

The [UrlAdaptor](https://blazor.syncfusion.com/documentation/data/adaptors#url-adaptor) connects the DataGrid to remote services through HTTP endpoints. UrlAdaptor suits custom APIs with custom CRUD logic.

- Supports manual implementation of server-side logic.
- Ideal for RESTful services with custom endpoints.

For implementation details, refer to the [UrlAdaptor documentation](https://blazor.syncfusion.com/documentation/datagrid/connecting-to-adaptors/url-adaptor).

## ODataV4Adaptor

The [ODataV4Adaptor](https://blazor.syncfusion.com/documentation/data/adaptors#odatav4-adaptor) supports services implementing the **OData V4** specification. ODataV4Adaptor provides enhanced support for advanced querying and metadata handling.

- Suitable for modern **OData V4** services.
- Enables efficient data manipulation and retrieval.

For implementation details, refer to the [ODataV4Adaptor documentation](https://blazor.syncfusion.com/documentation/datagrid/connecting-to-adaptors/odatav4-adaptor).

## WebApiAdaptor

The [WebApiAdaptor](https://blazor.syncfusion.com/documentation/data/adaptors#web-api-adaptor) supports Web APIs following the OData protocol. WebApiAdaptor extends OData protocol support and simplifies integration with ASP.NET Web API services.

- Automatically maps CRUD operations to Web API endpoints.
- Useful for applications built with ASP.NET Core Web API.

For implementation details, refer to the [WebApiAdaptor documentation](https://blazor.syncfusion.com/documentation/datagrid/connecting-to-adaptors/web-api-adaptor).

## GraphQLAdaptor

The [GraphQLAdaptor](https://blazor.syncfusion.com/documentation/data/adaptors#graphql-service-binding) enables integration with GraphQL servers. GraphQL allows clients to request only required data, improving performance and reducing payload size.

- Supports flexible and efficient data querying.
- Ideal for modern APIs using GraphQL syntax.

For implementation details, refer to the [GraphQLAdaptor documentation](https://blazor.syncfusion.com/documentation/datagrid/connecting-to-adaptors/graphql-adaptor).

N> 
* All adaptors work with [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) to manage data operations.
* CRUD requests occur only when Grid editing settings enable the related operations and a matching Grid interaction takes place.
* Backend services must implement appropriate endpoints to handle requests.