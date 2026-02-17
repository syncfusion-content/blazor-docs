---
layout: post
title: Adaptors in Blazor DataManager Component | Syncfusion
description: Checkout and learn here all about Adaptors in Syncfusion Blazor DataManager component and much more.
platform: Blazor
control: DataManager
documentation: ug
---

<!-- markdownlint-disable MD024 -->

# Adaptors in Blazor DataManager Component

The [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) component provides a unified approach for interacting with diverse data sources in Blazor applications. Each data source or remote service may define unique **request** and **response** formats. To manage these variations, the `SfDataManager` uses an **adaptor** mechanism that translates data operations into a format compatible with the target service.

* **Local data sources**: An adaptor applies query operations such as **sorting**, **filtering**, and **paging** directly on an **in-memory collection**.
* **Remote data sources**: An adaptor generates the required H**TTP requests** and processes the corresponding server **responses**.

The adaptor is configured using the [Adaptor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html#Syncfusion_Blazor_DataManager_Adaptor) property of the [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) component.

**Supported Adaptors**

The `SfDataManager` component provides several built-in adaptors for integrating remote data services.

* **UrlAdaptor** – Base adaptor for remote data services.
* **ODataAdaptor** – Integrates with services implementing the OData protocol.
* **ODataV4Adaptor** – Supports OData v4 protocol for advanced query capabilities.
* **WebApiAdaptor** – Works with Web API endpoints that support OData query options.
* **GraphQLAdaptor** – Enables interaction with GraphQL services for queries and mutations.
* **CustomAdaptor** – Allows custom implementations when built-in adaptors do not meet requirements.

## UrlAdaptor

The **UrlAdaptor** is the base adaptor for remote data services. It converts query operations into **HTTP requests** and processes the corresponding server **responses**. This adaptor is suitable for endpoints that do not implement specialized protocols such as **OData** or **GraphQL**.
To configure the `UrlAdaptor`, set the [Adaptor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html#Syncfusion_Blazor_DataManager_Adaptor) property to [Adaptors.UrlAdaptor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Adaptors.html#Syncfusion_Blazor_Adaptors_UrlAdaptor) and specify the service endpoint in the [Url](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html#Syncfusion_Blazor_DataManager_Url) property.

**Key Points**

* Acts as the **base adaptor** for most remote adaptors.
* Converts query operations into **HTTP requests**.
* Requires the server to return a **JSON** object with **result** and **count** properties.
* Supports operations such as **paging**, **sorting**, and **filtering** through `query` parameters.

```cshtml

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.Grids

<SfGrid TValue="EmployeeData" ID="Grid" AllowPaging="true">
    <SfDataManager Url="https://blazor.syncfusion.com/services/production/api/gridurldata" Adaptor="Adaptors.UrlAdaptor"></SfDataManager>
    <GridColumns>
        <GridColumn Field="@nameof(EmployeeData.EmployeeID)" HeaderText="Employee ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Center" Width="120"></GridColumn>
        <GridColumn Field="@nameof(EmployeeData.EmployeeName)" HeaderText="First Name" Width="130"></GridColumn>
        <GridColumn Field="@nameof(EmployeeData.Designation)" HeaderText="Title" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    
    public class EmployeeData
    {
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string Designation { get; set; }
    }
}

```

The server response must include two properties:

* **result** – A collection of entities.
* **count** – The total number of records.

```
{
    "result": [{...}, {...}, {...}],
    "count": 67
}
```

## OData adaptor

The `ODataAdaptor` is designed for services that implement the [OData](https://www.odata.org/documentation/) protocol. It enables the `SfDataManager` component to send OData-compliant queries and process responses from an **OData** service.

Use this adaptor when integrating with endpoints that follow **OData** standards for data querying and manipulation. It automatically generates query parameters for operations such as **paging**, **sorting**, **filtering**, and **grouping**.

To configure, set the [Adaptor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html#Syncfusion_Blazor_DataManager_Adaptor) property to `Adaptors.ODataAdaptor` and provide the OData service URL in the [Url](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html#Syncfusion_Blazor_DataManager_Url) property of the `SfDataManager` component.

**Key Points**

* Implements the **OData** protocol for standardized data access.
* Automatically generates **OData** query parameters for supported operations.
* Requires the server to return a **JSON** object with **result** and **count** properties.
* Ideal for services exposing **OData** endpoints.

```cshtml
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.Grids
<SfGrid TValue="OrderData" ID="OrdersGrid" AllowPaging="true">
    <SfDataManager Url="https://services.odata.org/Northwind/Northwind.svc/Orders" Adaptor="Adaptors.ODataAdaptor"></SfDataManager>
    <GridColumns>
        <GridColumn Field="@nameof(OrderData.OrderID)" HeaderText="Order ID" TextAlign="TextAlign.Center" Width="120"></GridColumn>
        <GridColumn Field="@nameof(OrderData.CustomerID)" HeaderText="Customer Name" Width="130"></GridColumn>
        <GridColumn Field="@nameof(OrderData.EmployeeID)" HeaderText="Employee ID" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {

    public class OrderData
    {
        public int OrderID { get; set; }
        public string? CustomerID { get; set; }
        public int EmployeeID { get; set; }
    }
}
```

## ODataV4 adaptor

The `ODataV4Adaptor` enables integration with services that implement the OData v4 protocol. It provides standardized communication between the [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) component and OData v4-compliant endpoints. This adaptor automatically generates query parameters for common data operations, reducing manual configuration.
Use this adaptor when the remote service supports **OData v4** and requires advanced query capabilities such as **filtering**, **sorting**, and **paging**.

To configure, set the [Adaptor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html#Syncfusion_Blazor_DataManager_Adaptor) property to [Adaptors.ODataV4Adaptor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Adaptors.html#Syncfusion_Blazor_Adaptors_ODataV4Adaptor) and provide the service URL in the [Url](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html#Syncfusion_Blazor_DataManager_Url) property of the `SfDataManager` component.

**Key Points**

* Implements OData v4 protocol for standardized data access.
* Automatically generates query parameters for supported operations.
* Requires the server to return a **JSON** object with **result** and **count** properties.

```cshtml
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.Grids

<SfGrid TValue="EmployeeData" ID="Grid" AllowPaging="true">
    <SfDataManager Url="https://services.odata.org/V4/Northwind/Northwind.svc/Orders/" Adaptor="Adaptors.ODataV4Adaptor"></SfDataManager>
    <GridColumns>
        <GridColumn Field=@nameof(EmployeeData.OrderID) TextAlign="TextAlign.Center" HeaderText="Order ID" Width="120"></GridColumn>
        <GridColumn Field=@nameof(EmployeeData.CustomerID) TextAlign="TextAlign.Center" HeaderText="Customer Name" Width="130"></GridColumn>
        <GridColumn Field=@nameof(EmployeeData.EmployeeID) TextAlign="TextAlign.Center" HeaderText="Employee ID" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    public class EmployeeData
    {
        public int OrderID { get; set; }
        public string CustomerID { get; set; }
        public int EmployeeID { get; set; }
    }
}
```

## Web API adaptor

The `WebApiAdaptor` is used to interact with Web API endpoints that support **OData query options**. It extends the functionality of the **ODataAdaptor**, enabling the [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) component to send OData-formatted queries and process responses from Web API services.

Use this adaptor when the endpoint understands **OData** queries and returns data in a compatible format.

To configure, set the [Adaptor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html#Syncfusion_Blazor_DataManager_Adaptor) property to [Adaptors.WebApiAdaptor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Adaptors.html#Syncfusion_Blazor_Adaptors_WebApiAdaptor) and provide the service URL in the [Url](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html#Syncfusion_Blazor_DataManager_Url) property of the `SfDataManager` component.

```cshtml
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.Grids

<SfGrid TValue="Order" AllowPaging="true">
    <SfDataManager Url="https://blazor.syncfusion.com/services/production/api/Orders/" Adaptor="Adaptors.WebApiAdaptor"></SfDataManager>
    <GridColumns>
        <GridColumn Field="@nameof(Order.OrderID)" HeaderText="Order ID" IsPrimaryKey="true" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field="@nameof(Order.CustomerID)" HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field="@nameof(Order.OrderDate)" HeaderText="Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field="@nameof(Order.Freight)" HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }

}
```

**Expected Server Response**

```csharp

{
    "result": [{...}, {...}, {...}],
    "count": 830
}

```

## GraphQL service binding

The `GraphQLAdaptor` enables integration with GraphQL services, allowing precise data retrieval and efficient operations. It supports **queries**, **mutations**, and common data operations such as **paging**, **sorting**, and **filtering** by sending the required arguments to the server.

### Fetching data from GraphQL service

To bind data from a GraphQL service to the DataGrid:

* Configure the [GraphQLAdaptorOptions](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.GraphQLAdaptorOptions.html) with:

    * [Query](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.GraphQLAdaptorOptions.html#Syncfusion_Blazor_Data_GraphQLAdaptorOptions_Query) – Defines the GraphQL query string.
    * [ResolverName](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.GraphQLAdaptorOptions.html#Syncfusion_Blazor_Data_GraphQLAdaptorOptions_ResolverName) – Maps the response to the query.

* Set the [Adaptor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html#Syncfusion_Blazor_DataManager_Adaptor) property to [Adaptors.GraphQLAdaptor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Adaptors.html#Syncfusion_Blazor_Adaptors_GraphQLAdaptor).

The GraphQL response must return a JSON-formatted response with properties:

* **Result** – A collection of entities.
* **Count** – Total number of records.
* **Aggregates** – Aggregate values, if applicable.

```cshtml

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.Grids

<SfGrid TValue="Order" AllowPaging="true" PageSettings="new PageSettings { PageSize = 10 }">
    <SfDataManager Url="https://api.example.com/graphql"
                   GraphQLAdaptorOptions="@adaptorOptions"
                   Adaptor="Adaptors.GraphQLAdaptor">
    </SfDataManager>

    <GridColumns>
        <GridColumn Field="@nameof(Order.OrderID)" HeaderText="Order ID" Width="120" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field="@nameof(Order.CustomerID)" HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field="@nameof(Order.OrderDate)" HeaderText="Order Date" Type="ColumnType.Date" Format="d" Width="130"></GridColumn>
        <GridColumn Field="@nameof(Order.Freight)" HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {

    private GraphQLAdaptorOptions adaptorOptions = new GraphQLAdaptorOptions
    {
        // GraphQL query that accepts the DataManager request as an input variable
        Query = @"
            query ordersData($dataManager: DataManagerRequestInput!) {
                ordersData(dataManager: $dataManager) {
                    count,
                    result { OrderID, CustomerID, OrderDate, Freight },
                    aggregates
                }
            }",
        // Resolver field name used in the GraphQL response under data.{ResolverName}
        ResolverName = "OrdersData"

    };

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }
}

```
N> Replace sample URL with the actual service endpoint URL.

### Performing data operations

The `GraphQLAdaptor` translates DataManager operations into a GraphQL request using [DataManagerRequest](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManagerRequest.html). Operations such as **paging**, **sorting**, **filtering**, and **searching** can be triggered through Grid UI interactions or programmatically using the `Query` API. The server resolver must consume `DataManagerRequest` and return a JSON-formatted response with **count**, **result**, and optionally **aggregates**.

```cshtml
    public class GraphQLQuery
    {
        public ReturnType<Order> OrdersData(DataManagerRequest dataManager)
        {
            IEnumerable<Order> result = Orders;
            if (dataManager.Search != null)
            {
                //Perform Searching here
            }
            if (dataManager.Sorted != null)
            {
                //Perform Sorting here
            }
            if (dataManager.Where != null)
            {
                //Perform Filtering here
            }
            int count = result.Count();
            if (dataManager.Skip != 0)
            {
                //Perform Paging here
            }
            if (dataManager.Take != 0)
            {
                //Perform Paging here
            }
            if (dataManager.Aggregates != null)
            {
                //Perform Total Aggregate here
                IDictionary<string, object> aggregates;
                return new ReturnType<Order>() { Count = count, Result = result, Aggregates = aggregates };
            }
            return dataManager.RequiresCounts ? new ReturnType<Order>() { Result = result, Count = count } : new ReturnType<Order>() { Result = result };
        }

        public static List<Order> Orders { get; set; } = GetOrdersList();

        private static List<Order> GetOrdersList()
        {
            var data = new List<Order>();
            int count = 1000;
            int employeeCount = 0;
            for (int i = 0; i < 10; i++)
            {
                data.Add(new Order() { OrderID = count + 1, EmployeeID = employeeCount + 1,  CustomerID = "ALFKI", OrderDate = new DateTime(2023, 08, 23), Freight = 5.7 * 2, Address = new CustomerAddress() { ShipCity = "Berlin", ShipCountry = "Denmark" }  });
                data.Add(new Order() { OrderID = count + 2, EmployeeID = employeeCount + 2, CustomerID = "ANANTR", OrderDate = new DateTime(1994, 08, 24), Freight = 6.7 * 2, Address = new CustomerAddress() { ShipCity = "Madrid", ShipCountry = "Brazil" } });
                data.Add(new Order() { OrderID = count + 3, EmployeeID = employeeCount + 3, CustomerID = "BLONP", OrderDate = new DateTime(1993, 08, 25), Freight = 7.7 * 2, Address = new CustomerAddress() { ShipCity = "Cholchester", ShipCountry = "Germany" } });
                data.Add(new Order() { OrderID = count + 4, EmployeeID = employeeCount + 4, CustomerID = "ANTON", OrderDate = new DateTime(1992, 08, 26), Freight = 8.7 * 2, Address = new CustomerAddress() { ShipCity = "Marseille", ShipCountry = "Austria" } });
                data.Add(new Order() { OrderID = count + 5, EmployeeID = employeeCount + 5, CustomerID = "BOLID", OrderDate = new DateTime(1991, 08, 27), Freight = 9.7 * 2, Address = new CustomerAddress() { ShipCity = "Tsawassen", ShipCountry = "Switzerland" } });
                count += 5;
                employeeCount += 5;
            }
            return data;
        }
    }

    public class ReturnType<T>
    {
        public int Count { get; set; }

        public IEnumerable<T> Result { get; set; }

        [GraphQLType(typeof(AnyType))]
        public IDictionary<string, object> Aggregates { get; set; }
    }

```

### Performing CRUD operation using mutation

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid integrates with GraphQL services through `GraphQLAdaptor` to perform **Create**, **Update**, **Delete**, and optional **Batch** operations. Mutations are defined in `GraphQLAdaptorOptions.Mutation` and invoked automatically by Grid editing. The server must expose resolvers that accept mutation variables and return a JSON formatted response with properties representing the updated entity or collection.

**Mutation Queries**

Each CRUD operation requires a specific mutation query:

* [Insert](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.GraphQLMutation.html#Syncfusion_Blazor_Data_GraphQLMutation_Insert): Adds a new record.
* [Update](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.GraphQLMutation.html#Syncfusion_Blazor_Data_GraphQLMutation_Update): Modifies an existing record.
* [Delete](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.GraphQLMutation.html#Syncfusion_Blazor_Data_GraphQLMutation_Delete): Removes a record.
* [Batch](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.GraphQLMutation.html#Syncfusion_Blazor_Data_GraphQLMutation_Batch): Handles multiple operations (Insert, Update, and Delete) in a single request.

**Insert mutation parameters**

These parameters are passed to the mutation method for the `Insert` operation on the server:

| Parameter | Description |
|--------|----------------|
| record | Represents the new record to be inserted. |
| index | Specifies the position at which the record should be inserted.  |
| action | Indicates the type of operation (e.g., Add, Delete, Update).  |
| additionalParameters | Optional parameter for custom logic during the operation.  |

**Update mutation parameters**

These parameters are passed to the mutation method for the `Update` operation on the server:

| Parameter | Description |
|--------|----------------|
| record | Represents the updated record. |
| action | Indicates the type of operation (e.g., Add, Delete, Update). |
| primaryColumnName | Specifies the name of the primary key column. |
| primaryColumnValue | Specifies the value of the primary key for the record to update.   |
| additionalParameters | Optional parameter for custom logic during the operation.   |

**Delete mutation parameters**

These parameters are passed to the mutation method for the **Delete** operation on the server:

| Parameter | Description |
|--------|----------------|
| primaryColumnValue | Specifies the primary key value of the record to delete. |
| action | Indicates the type of operation (e.g., Add, Delete, Update).  |
| primaryColumnName | Specifies the name of the primary key column.  |
| additionalParameters | Optional parameter for custom logic during the operation.   |


```cshtml

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Data

<SfDataManager Url="https://xxxxxx"
               GraphQLAdaptorOptions="@_adaptorOptions"
               Adaptor="Adaptors.GraphQLAdaptor">
</SfDataManager>

@code {
    // GraphQL adaptor configuration
    private GraphQLAdaptorOptions _adaptorOptions { get; set; } = new GraphQLAdaptorOptions
    {
        // Data query: passes DataManagerRequestInput ($dataManager) to the resolver
        Query = @"
            query ordersData($dataManager: DataManagerRequestInput!) {
                ordersData(dataManager: $dataManager) {
                    count,
                    result { OrderID, CustomerID, OrderDate, Freight },
                    aggregates
                }
            }",

        // CRUD mutations: Insert, Update, Delete (Batch can be added if required)
        Mutation = new GraphQLMutation
        {
            Insert = @"
                mutation create($record: OrderInput!, $index: Int!, $action: String!, $additionalParameters: Any) {
                  createOrder(order: $record, index: $index, action: $action, additionalParameters: $additionalParameters) {
                    OrderID, CustomerID, OrderDate, Freight
                  }
                }",

            Update = @"
                mutation update($record: OrderInput!, $action: String!, $primaryColumnName: String!, $primaryColumnValue: Int!, $additionalParameters: Any) {
                  updateOrder(order: $record, action: $action, primaryColumnName: $primaryColumnName, primaryColumnValue: $primaryColumnValue, additionalParameters: $additionalParameters) {
                    OrderID, CustomerID, OrderDate, Freight
                  }
                }",

            Delete = @"
                mutation delete($primaryColumnValue: Int!, $action: String!, $primaryColumnName: String!, $additionalParameters: Any) {
                  deleteOrder(primaryColumnValue: $primaryColumnValue, action: $action, primaryColumnName: $primaryColumnName, additionalParameters: $additionalParameters) {
                    OrderID, CustomerID, OrderDate, Freight
                  }
                }"
        },

        // Resolver mapping name used under data.{ResolverName}
        ResolverName = "OrdersData"
    };

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }
}

```

This configuration demonstrates the mutation methods implemented on the GraphQL server for performing CRUD operations.

```cshtml
   
public class GraphQLMutation
{
    public Order CreateOrder(
        Order order,
        int index,
        string action,
        [GraphQLType(typeof(AnyType))] IDictionary<string, object> additionalParameters)
    {
        // Defensive insert: clamp index within bounds
        var list = GraphQLQuery.Orders;
        var safeIndex = Math.Clamp(index, 0, list.Count);
        list.Insert(safeIndex, order);
        return order;
    }

    public Order UpdateOrder(
        Order order,
        string action,
        string primaryColumnName,
        int primaryColumnValue,
        [GraphQLType(typeof(AnyType))] IDictionary<string, object> additionalParameters)
    {
        var updatedOrder = GraphQLQuery.Orders.FirstOrDefault(x => x.OrderID == primaryColumnValue);
        if (updatedOrder == null)
        {
            // No matching entity; return the input or handle as needed (e.g., throw graph error)
            return order;
        }

        // Apply updates
        updatedOrder.OrderID = order.OrderID;
        updatedOrder.CustomerID = order.CustomerID;
        updatedOrder.Freight = order.Freight;
        updatedOrder.OrderDate = order.OrderDate;

        return updatedOrder;
    }

    public Order DeleteOrder(
        int primaryColumnValue,
        string action,
        string primaryColumnName,
        [GraphQLType(typeof(AnyType))] IDictionary<string, object> additionalParameters)
    {
        var deletedOrder = GraphQLQuery.Orders.FirstOrDefault(x => x.OrderID == primaryColumnValue);
        if (deletedOrder != null)
        {
            GraphQLQuery.Orders.Remove(deletedOrder);
        }
        return deletedOrder;
    }
}

```

#### Batch editing

Batch editing performs **Insert**, **Update**, and **Delete** operations in a single GraphQL request. Configuration is defined in the [Batch](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.GraphQLMutation.html#Syncfusion_Blazor_Data_GraphQLMutation_Batch) property of Mutation in [GraphQLAdaptorOptions](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.GraphQLAdaptorOptions.html), and the server must expose a **batchUpdate** resolver that accepts the batch parameters and returns the updated collection.

**Batch mutation parameters**

These parameters are passed to the mutation method for the **Batch** operation on the server:

| Parameter | Description |
|--------|----------------|
| changed | Collection of records to update. |
| added | Collection of records to insert.  |
| deleted | Collection of records to remove.   |
| action | Indicates the type of operation being performed. |
| primaryColumnName | Specifies the name of the primary key column.  |
| additionalParameters | Optional parameter for custom logic during the operation.   |
| dropIndex | Position where new records should be inserted during drag-and-drop.   |


```cshtml

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Data

<SfDataManager Url="https://xxxxxx"
               GraphQLAdaptorOptions="@_adaptorOptions"
               Adaptor="Adaptors.GraphQLAdaptor">
</SfDataManager>

@code {
    // GraphQL adaptor configuration
    private GraphQLAdaptorOptions _adaptorOptions { get; set; } = new GraphQLAdaptorOptions
    {
        Query = @"
            query ordersData($dataManager: DataManagerRequestInput!) {
                ordersData(dataManager: $dataManager) {
                    count,
                    result { OrderID, CustomerID, OrderDate, Freight },
                    aggregates
                }
            }",
        Mutation = new GraphQLMutation
        {
            Batch = @"
                mutation batch(
                    $changed: [OrderInput!],
                    $added: [OrderInput!],
                    $deleted: [OrderInput!],
                    $action: String!,
                    $primaryColumnName: String!,
                    $additionalParameters: Any,
                    $dropIndex: Int
                ) {
                  batchUpdate(
                    changed: $changed,
                    added: $added,
                    deleted: $deleted,
                    action: $action,
                    primaryColumnName: $primaryColumnName,
                    additionalParameters: $additionalParameters,
                    dropIndex: $dropIndex
                  ) {
                    OrderID, CustomerID, OrderDate, Freight
                  }
                }"
        },
        ResolverName = "OrdersData"
    };

    // Entity model
    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }
}

```

This example shows how to implement the batch logic on the GraphQL server.

```cshtml
    
public class GraphQLMutation
{
    public List<Order> BatchUpdate(
        List<Order>? changed,
        List<Order>? added,
        List<Order>? deleted,
        string action,
        string primaryColumnName,
        [GraphQLType(typeof(AnyType))] IDictionary<string, object>? additionalParameters,
        int? dropIndex)
    {
        // Update existing records
        if (changed != null && changed.Count > 0)
        {
            foreach (var changedOrder in changed)
            {
                var target = GraphQLQuery.Orders.FirstOrDefault(e => e.OrderID == changedOrder.OrderID);
                if (target != null)
                {
                    // Primary key updates are typically avoided; update non-key fields
                    target.CustomerID = changedOrder.CustomerID;
                    target.OrderDate = changedOrder.OrderDate;
                    target.Freight = changedOrder.Freight;
                }
            }
        }

        // Insert new records
        if (added != null && added.Count > 0)
        {
            if (dropIndex.HasValue)
            {
                var index = Math.Clamp(dropIndex.Value, 0, GraphQLQuery.Orders.Count);
                GraphQLQuery.Orders.InsertRange(index, added);
            }
            else
            {
                GraphQLQuery.Orders.AddRange(added);
            }
        }

        // Delete records
        if (deleted != null && deleted.Count > 0)
        {
            foreach (var deletedOrder in deleted)
            {
                var target = GraphQLQuery.Orders.FirstOrDefault(e => e.OrderID == deletedOrder.OrderID);
                if (target != null)
                {
                    GraphQLQuery.Orders.Remove(target);
                }
            }
        }

        return GraphQLQuery.Orders;
    }
}

```

### Configuration in GraphQL server application

The following configuration sets the GraphQL query and mutation types and enables CORS for a specific client origin in **Program.cs**.

{% tabs %}
{% highlight c# tabtitle="~/Program.cs" %}


// Program.cs

var builder = WebApplication.CreateBuilder(args);

// GraphQL schema: register query and mutation types
builder.Services
    .AddGraphQLServer()
    .AddQueryType<GraphQLQuery>()
    .AddMutationType<GraphQLMutation>();

// CORS: allow a specific client origin to access this server
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", cors =>
    {
        cors.WithOrigins("https://xxxxxx")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

var app = builder.Build();

app.UseCors("AllowSpecificOrigin");
app.MapGraphQL();

{% endhighlight %}
{% endtabs %}

The **resolver** method accepts an instance of [DataManagerRequestInput](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManagerRequest.html), which encapsulates query parameters from the DataManager request. These parameters are used to shape the response returned to the client application.

{% tabs %}
{% highlight cs tabtitle="DataManagerRequest.cs" %}
    public class DataManagerRequest
    {
        [GraphQLName("Skip")]
        public int Skip { get; set; }

        [GraphQLName("Take")]
        public int Take { get; set; }

        [GraphQLName("RequiresCounts")]
        public bool RequiresCounts { get; set; } = false;

        [GraphQLName("Params")]
        [GraphQLType(typeof(AnyType))]
        public IDictionary<string, object> Params { get; set; }

        [GraphQLName("Aggregates")]
        [GraphQLType(typeof(AnyType))]
        public List<Aggregate>? Aggregates { get; set; }

        [GraphQLName("Search")]
        public List<SearchFilter>? Search { get; set; }

        [GraphQLName("Sorted")]
        public List<Sort>? Sorted { get; set; }

        [GraphQLName("Where")]
        [GraphQLType(typeof(AnyType))]
        public List<WhereFilter>? Where { get; set; }

        [GraphQLName("Group")]
        public List<string>? Group { get; set; }

        [GraphQLName("antiForgery")]
        public string? antiForgery { get; set; }

        [GraphQLName("Table")]
        public string? Table { get; set; }

        [GraphQLName("IdMapping")]
        public string? IdMapping { get; set; }

        [GraphQLName("Select")]
        public List<string>? Select { get; set; }

        [GraphQLName("Expand")]
        public List<string>? Expand { get; set; }

        [GraphQLName("Distinct")]
        public List<string>? Distinct { get; set; }

        [GraphQLName("ServerSideGroup")]
        public bool? ServerSideGroup { get; set; }

        [GraphQLName("LazyLoad")]
        public bool? LazyLoad { get; set; }

        [GraphQLName("LazyExpandAllGroup")]
        public bool? LazyExpandAllGroup { get; set; }
    }

    public class Aggregate
    {
        [GraphQLName("Field")]
        public string Field { get; set; }

        [GraphQLName("Type")]
        public string Type { get; set; }
    }

    public class SearchFilter
    {
        [GraphQLName("Fields")]
        public List<string> Fields { get; set; }

        [GraphQLName("Key")]
        public string Key { get; set; }

        [GraphQLName("Operator")]
        public string Operator { get; set; }

        [GraphQLName("IgnoreCase")]
        public bool IgnoreCase { get; set; }
    }

    public class Sort
    {
        [GraphQLName("Name")]
        public string Name { get; set; }

        [GraphQLName("Direction")]
        public string Direction { get; set; }

        [GraphQLName("Comparer")]
        [GraphQLType(typeof(AnyType))]
        public object Comparer { get; set; }
    }

    public class WhereFilter
    {
        [GraphQLName("Field")]
        public string? Field { get; set; }

        [GraphQLName("IgnoreCase")]
        public bool? IgnoreCase { get; set; }

        [GraphQLName("IgnoreAccent")]
        public bool? IgnoreAccent { get; set; }

        [GraphQLName("IsComplex")]
        public bool? IsComplex { get; set; }

        [GraphQLName("Operator")]
        public string? Operator { get; set; }

        [GraphQLName("Condition")]
        public string? Condition { get; set; }

        [GraphQLName("value")]
        [GraphQLType(typeof(AnyType))]
        public object? value { get; set; }

        [GraphQLName("predicates")]
        public List<WhereFilter>? predicates { get; set; }
    }

{% endhighlight %}
{% endtabs %}

N> The complete implementation is available in the [GitHub](https://github.com/SyncfusionExamples/GraphQLAdaptor-Binding-Blazor-DataGrid) sample.

## Writing custom adaptor

When the built-in adaptors do not meet specific requirements, a **custom adaptor** can be implemented.

**Steps to create and use a custom adaptor**:

1. Create a class that inherits from the [DataAdaptor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html) base class.
2. Override the required methods to implement the desired functionality.
3. Assign the custom adaptor instance to the [AdaptorInstance](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html#Syncfusion_Blazor_DataManager_AdaptorInstance) property of the [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) component and set the [Adaptor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html#Syncfusion_Blazor_DataManager_Adaptor) property to [CustomAdaptor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Adaptors.html#Syncfusion_Blazor_Adaptors_CustomAdaptor).

For detailed implementation guidance, refer to the [custom binding documentation](custom-binding).
