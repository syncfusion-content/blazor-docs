---
layout: post
title: Persisting data in the server in Blazor DataGrid | Syncfusion
description: Learn how to persist Syncfusion Blazor DataGrid data to servers using adaptors like UrlAdaptor, ODataV4Adaptor, WebApiAdaptor, and GraphQLAdaptor.
platform: Blazor
control: DataGrid
documentation: ug
---

# Persisting data in the server in Blazor DataGrid

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid supports persisting data changes to a server or database using RESTful web services. All CRUD operations Create, Read, Update, and Delete are managed by the [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html), which enables seamless communication with server-side data sources. This configuration ensures that changes made in the Grid UI are reliably synchronized with the backend.

**Supported Adaptors**

The Syncfusion<sup style="font-size:70%">&reg;</sup> provides multiple adaptors to integrate the DataGrid with various server protocols and APIs. Each adaptor works with [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) to manage data operations and automatically trigger CRUD actions based on Grid interactions. Backend services must implement appropriate endpoints to handle these requests.

**UrlAdaptor**

The [UrlAdaptor](https://blazor.syncfusion.com/documentation/data/adaptors#url-adaptor) connects the DataGrid to remote services via HTTP endpoints. This adaptor is suitable for custom APIs that implement their own logic for handling CRUD operations.

- Supports manual implementation of server-side logic.
- Ideal for RESTful services with custom endpoints.

For implementation details, refer to the [UrlAdaptor documentation](https://blazor.syncfusion.com/documentation/datagrid/connecting-to-adaptors/url-adaptor).

**ODataV4Adaptor**

The [ODataV4Adaptor](https://blazor.syncfusion.com/documentation/data/adaptors#odatav4-adaptor) is designed for services that implement the **OData V4** specification. It provides enhanced support for advanced querying and metadata handling.

- Suitable for modern **OData V4** services.
- Enables efficient data manipulation and retrieval.

For implementation details, refer to the [ODataV4Adaptor documentation](https://blazor.syncfusion.com/documentation/datagrid/connecting-to-adaptors/odatav4-adaptor).

**WebApiAdaptor**

The [WebApiAdaptor](https://blazor.syncfusion.com/documentation/data/adaptors#web-api-adaptor) is optimized for Web APIs that follow the OData protocol. It extends the capabilities of the ODataAdaptor and simplifies integration with ASP.NET Web API services.

- Automatically maps CRUD operations to Web API endpoints.
- Useful for applications built with ASP.NET Core Web API.

For implementation details, refer to the [WebApiAdaptor documentation](https://blazor.syncfusion.com/documentation/datagrid/connecting-to-adaptors/web-api-adaptor).

**GraphQLAdaptor**

The [GraphQLAdaptor](https://blazor.syncfusion.com/documentation/data/adaptors#graphql-service-binding) enables integration with GraphQL servers. GraphQL allows clients to request only the data they need, improving performance and reducing payload size.

- Supports flexible and efficient data querying.
- Ideal for modern APIs using GraphQL syntax.

For implementation details, refer to the [GraphQLAdaptor documentation](https://blazor.syncfusion.com/documentation/datagrid/connecting-to-adaptors/graphql-adaptor).


N> 
* All adaptors work with [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) to manage data operations.
* CRUD operations are automatically triggered based on Grid interactions.
* Backend services must implement appropriate endpoints to handle requests.