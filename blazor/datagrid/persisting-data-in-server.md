---
layout: post
title: Persisting data in the server in Blazor DataGrid | Syncfusion
description: Learn how to persist Syncfusion Blazor DataGrid data to servers using adaptors like UrlAdaptor, ODataV4Adaptor, WebApiAdaptor, and GraphQLAdaptor.
platform: Blazor
control: DataGrid
documentation: ug
---

# Persisting Data in Server in React Grid Component

The Syncfusion<sup style="font-size:70%">&reg;</sup> React Grid component allows data edited within the grid to be persisted in a database using RESTful web services. All CRUD (Create, Read, Update, Delete) operations within the grid are handled by the [DataManager](../../data), which can bind server-side data and send updates to the server. This capability is Essential<sup style="font-size:70%">&reg;</sup> for maintaining data integrity and ensuring that changes made in the UI are reflected in the backend.

> For your information, the ODataAdaptor persists data in the server as per OData protocol.

Syncfusion<sup style="font-size:70%">&reg;</sup> provides multiple adaptors to handle different server protocols and APIs, enabling smooth integration with RESTful services. Below are the various adaptors you can use to persist data in the Syncfusion<sup style="font-size:70%">&reg;</sup> React Grid component.

## URL adaptor

The [UrlAdaptor](https://ej2.syncfusion.com/react/documentation/data/adaptors#url-adaptor) is the base adaptor that facilitates communication between remote data services and the UI component. It allows seamless data binding and interaction with custom API services or any remote service through URLs. The UrlAdaptor is particularly useful when a custom API service has unique logic for handling data and CRUD operations.

For further details on configuration, refer to the [URL adaptor Documentation](https://ej2.syncfusion.com/react/documentation/grid/connecting-to-adaptors/url-adaptor)

## OData V4 adaptor

The [ODataV4Adaptor](https://ej2.syncfusion.com/react/documentation/data/adaptors#odatav4-adaptor) in the Syncfusion<sup style="font-size:70%">&reg;</sup> React Grid Component facilitates seamless integration with OData V4 services, allowing for efficient data fetching and manipulation. CRUD operations can be performed using the ODataV4Adaptor in the Syncfusion<sup style="font-size:70%">&reg;</sup> React Grid component.

For further details on configuration, refer to the [OData v4 adaptor Documentation](https://ej2.syncfusion.com/react/documentation/grid/connecting-to-adaptors/odatav4-adaptor).

## Web API adaptor

The [WebApiAdaptor](https://ej2.syncfusion.com/react/documentation/data/adaptors#web-api-adaptor) extends the capabilities of the ODataAdaptor and is designed to interact with Web APIs created with OData endpoints. This adaptor ensures seamless communication between the Syncfusion<sup style="font-size:70%">&reg;</sup> React Grid and OData-based Web APIs, enabling efficient data retrieval and manipulation.

For further details on configuration, refer to the [Web API Adaptor documentation](https://ej2.syncfusion.com/react/documentation/grid/connecting-to-adaptors/webapi-adaptor).

## Remote Save adaptor

The `RemoteSaveAdaptor` in the Syncfusion<sup style="font-size:70%">&reg;</sup> React Grid component allows grid actions such as sorting, filtering, searching, and paging to be performed primarily on the client side, while handling CRUD operations (updating, inserting, and removing data) on the server side for data persistence. This approach optimizes performance by minimizing unnecessary server interactions.

For further details on configuration, refer to the [Remote Save Adaptor Documentation](https://ej2.syncfusion.com/react/documentation/grid/connecting-to-adaptors/remote-save-adaptor)

## Web Method adaptor

The [WebMethodAdaptor](https://ej2.syncfusion.com/react/documentation/data/adaptors#webmethod-adaptor) facilitates data binding from remote services using web methods. This adaptor sends query parameters encapsulated within an object named value, allowing efficient communication between the client-side application and the server.

For further details on configuration, refer to the [Web Method Adaptor documentation](https://ej2.syncfusion.com/react/documentation/grid/connecting-to-adaptors/web-method-adaptor).

## GraphQL adaptor

GraphQL is a powerful query language for APIs designed to provide a more efficient alternative to traditional REST APIs. It allows precise data fetching, reducing over-fetching and under-fetching of data. GraphQL offers a flexible and expressive syntax for querying, enabling clients to request only the specific data they require.

The [GraphQLAdaptor](https://ej2.syncfusion.com/react/documentation/data/adaptors#graphql-adaptor) simplifies the interaction between the Syncfusion<sup style="font-size:70%">&reg;</sup> React Grid and GraphQL servers, allowing for efficient data retrieval with support for various operations such as CRUD (Create, Read, Update, Delete).

For further details on configuration, refer to the [GraphQL adaptor documentation](https://ej2.syncfusion.com/react/documentation/grid/connecting-to-adaptors/graphql-adaptor).


N> 
* All adaptors work with [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) to manage data operations.
* CRUD operations are automatically triggered based on Grid interactions.
* Backend services must implement appropriate endpoints to handle requests.