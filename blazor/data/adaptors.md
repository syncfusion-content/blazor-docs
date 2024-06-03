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

Each data source or remote service uses different way for accepting request and sending back the response. The [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) cannot anticipate every way a data source works. To tackle this problem the [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) uses adaptor concept to communicate with the particular data source.

* For local data sources, the role of the data adaptor is to query the object array based on the Query object and manipulate them.

* For remote data source, the data adaptor is used to send the request that the server can understand which then processes the server response.

The adaptor can be assigned using the [Adaptor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html#Syncfusion_Blazor_DataManager_Adaptor) property of the [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html).

## Json adaptor

The `JsonAdaptor` is used to query and manipulate object array. 

The following sample code demonstrates binding data to the DataGrid component through the [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) using `JsonAdaptor`,

```cshtml
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.Grids

<SfGrid TValue="EmployeeData" ID="Grid">
    <SfDataManager Json=@Employees Adaptor="Adaptors.JsonAdaptor"></SfDataManager>
    <GridColumns>
        <GridColumn Field=@nameof(EmployeeData.EmployeeID) TextAlign="TextAlign.Center" HeaderText="Employee ID" Width="120"></GridColumn>
        <GridColumn Field=@nameof(EmployeeData.Name) HeaderText="First Name" Width="130"></GridColumn>
        <GridColumn Field=@nameof(EmployeeData.Title) HeaderText="Title" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    public class EmployeeData
    {
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
    }

    public EmployeeData[] Employees = new EmployeeData[]
    {
        new EmployeeData { EmployeeID = 1, Name = "Nancy Fuller", Title = "Vice President" },
        new EmployeeData { EmployeeID = 2, Name = "Steven Buchanan", Title = "Sales Manager" },
        new EmployeeData { EmployeeID = 3, Name = "Janet Leverling", Title = "Sales Representative" },
        new EmployeeData { EmployeeID = 4, Name = "Andrew Davolio", Title = "Inside Sales Coordinator" },
        new EmployeeData { EmployeeID = 5, Name = "Steven Peacock", Title = "Inside Sales Coordinator" },
        new EmployeeData { EmployeeID = 6, Name = "Janet Buchanan", Title = "Sales Representative" },
        new EmployeeData { EmployeeID = 7, Name = "Andrew Fuller", Title = "Inside Sales Coordinator" },
        new EmployeeData { EmployeeID = 8, Name = "Steven Davolio", Title = "Inside Sales Coordinato" },
        new EmployeeData { EmployeeID = 9, Name = "Janet Davolio", Title = "Sales Representative" },
        new EmployeeData { EmployeeID = 10, Name = "Andrew Buchanan", Title = "Sales Representative" }
    };
}
```

## Url adaptor

The `UrlAdaptor` acts as the base adaptor for interacting with remote data services. Most of the built-in adaptors are derived from the `UrlAdaptor`.

The following sample code demonstrates binding data to the DataGrid component through the [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) using `UrlAdaptor`,

```cshtml
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.Grids

<SfGrid TValue="EmployeeData" ID="Grid" AllowPaging="true">
    <SfDataManager Url="http://controller.com/actions" Adaptor="Adaptors.UrlAdaptor"></SfDataManager>
    <GridColumns>
        <GridColumn Field=@nameof(EmployeeData.EmployeeID) TextAlign="TextAlign.Center" HeaderText="Employee ID" Width="120"></GridColumn>
        <GridColumn Field=@nameof(EmployeeData.Name) HeaderText="First Name" Width="130"></GridColumn>
        <GridColumn Field=@nameof(EmployeeData.Title) HeaderText="Title" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    public class EmployeeData
    {
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
    }
}
```

N> The above mentioned URL is given for reference purposes. In that place, you can provide your service URL.

`UrlAdaptor` expects response as a JSON object with properties `result` and `count` which contains the collection of entities and the total number of records respectively.

The sample response object should be as follows,

```
{
    "result": [{..}, {..}, {..}, ...],
    "count": 67
}
```

## OData adaptor

[OData](https://www.odata.org/documentation/odata-version-3-0/) is a standardized protocol for creating and consuming data. You can retrieve data from OData service using [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html). The `ODataAdaptor` helps you to interact with OData service.

The following sample code demonstrates binding remote data to the DataGrid component through the [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) using OData service,

```cshtml
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.Grids

<SfGrid TValue="EmployeeData" ID="Grid" AllowPaging="true">
    <SfDataManager Url="https://js.syncfusion.com/demos/ejServices/Wcf/Northwind.svc/Orders" Adaptor="Adaptors.ODataAdaptor"></SfDataManager>
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

N> By default, `ODataAdaptor` is used by DataManager.

## ODataV4 adaptor

The ODataV4 is an improved version of OData protocols and the [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) can also retrieve and consume OData v4 services. For more details on OData v4 Services, refer the [odata documentation](https://docs.oasis-open.org/odata/odata/v4.0/errata03/os/complete/part1-protocol/odata-v4.0-errata03-os-part1-protocol-complete.html#_Toc453752197). You can use the `ODataV4Adaptor` to interact with ODataV4 service.

The following sample code demonstrates binding remote data to the DataGrid component through the [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) using ODataV4 service,

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

You can use the `WebApiAdaptor` to interact with Web APIs created with OData endpoint. The `WebApiAdaptor` is extended from the `ODataAdaptor`. Hence to use `WebApiAdaptor`, the endpoint should understand the OData formatted queries sent along with request.

To enable OData query option for Web API, refer to this [documentation](https://learn.microsoft.com/en-us/aspnet/web-api/overview/odata-support-in-aspnet-web-api/supporting-odata-query-options).

The following sample code demonstrates binding remote data to the DataGrid component through the [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) using Web API service,

```cshtml
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.Grids

<SfGrid TValue="Order" AllowPaging="true">
    <SfDataManager Url="https://ej2services.syncfusion.com/production/web-services/api/Orders" Adaptor="Adaptors.WebApiAdaptor"></SfDataManager>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }
}
```

`WebApiAdaptor` expects JSON response from the server and the response object should contain properties `Items` and `Count` whose values are collection of entities and total count of the entities respectively.

The sample response object should look like below.

```csharp
{
    "Items": [{..}, {..}, {..}, ...],
    "Count": 830
}
```

## GraphQL service binding

GraphQL is a query language for APIs with which you can get exactly what you need and nothing more. The GraphQLAdaptor provides an option to retrieve data from the GraphQL server. You can also perform CRUD and data operations like paging, sorting, filtering etc by sending the required arguments to the server.

### Fetching data from GraphQL service

To bind GraphQL service data to grid, you have to provide the GraphQL query string by using the [Query](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.GraphQLAdaptorOptions.html#Syncfusion_Blazor_Data_GraphQLAdaptorOptions_Query) property of the [GraphQLAdaptorOptions](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.GraphQLAdaptorOptions.html). Also you need to set the [ResolverName](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.GraphQLAdaptorOptions.html#Syncfusion_Blazor_Data_GraphQLAdaptorOptions_ResolverName) property of [GraphQLAdaptorOptions](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.GraphQLAdaptorOptions.html) to map the response. The GraphQLAdaptor expects response as a JSON object with properties of Result, Count and Aggregates which contains the collection of entities, total number of records and value of aggregates respectively. The GraphQL response should be returned in JSON format like { “data”: { … }} with query name as field.

```cshtml
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.Buttons

<SfDataManager @ref=DataManager Url="https://xxxxxx" GraphQLAdaptorOptions=@adaptorOptions Adaptor="Adaptors.GraphQLAdaptor"></SfDataManager>

<SfButton @onclick="ClickHandler" CssClass="e-info" Content="@Content"></SfButton>

@code{

    SfDataManager DataManager { get; set; }
    public string Content = "Get Data";

    Query query = new Query().Skip(0).Take(10).RequiresCount();

    private async Task ClickHandler()
    {
        // You can obtain the response here
        var data = await DataManager.ExecuteQueryAsync<Order>(query);

        //You can obtain collection from Result property
        var result = (data as DataResult).Result;

        //You can obtain count from Count property
        var count = (data as DataResult).Count;
    }

    private GraphQLAdaptorOptions adaptorOptions { get; set; } = new GraphQLAdaptorOptions
    {
        Query = @"
            query ordersData($dataManager: DataManagerRequestInput!){
                ordersData(dataManager: $dataManager) {
                    count, result { OrderID, CustomerID, OrderDate, Freight } , aggregates
                }
            }",
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

### Performing data operations

The following code demonstrates the resolver function used in the GraphQL server to bind data and to perform data operations like paging, sorting, filtering etc.

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

You can perform the CRUD operations by setting the mutation queries in the [Mutation](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.GraphQLAdaptorOptions.html#Syncfusion_Blazor_Data_GraphQLAdaptorOptions_Mutation) property of [GraphQLAdaptorOptions](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.GraphQLAdaptorOptions.html).

You have to set the Insert mutation query in [Insert](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.GraphQLMutation.html#Syncfusion_Blazor_Data_GraphQLMutation_Insert) property of Mutation in GraphQLAdaptorOptions. Similarly, you have to set the Update and Delete mutation queries in [Update](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.GraphQLMutation.html#Syncfusion_Blazor_Data_GraphQLMutation_Update) and [Delete](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.GraphQLMutation.html#Syncfusion_Blazor_Data_GraphQLMutation_Delete) properties of Mutation in `GraphQLAdaptorOptions` respectively.

The following variables are passed as a parameter to the mutation method written for **Insert** operation in server side.

| Properties | Description |
|--------|----------------|
| record | The new record which is need to be inserted. |
| index | Specifies the index at which the newly added record will be inserted.  |
| action | Indicates the type of operation being performed. When the same method is used for all CRUD actions, this argument serves to distinguish the action, such as **Add, Delete and Update**  |
| additionalParameters | An optional parameter that can be used to perform any operations.   |

The following variables are passed as a parameter to the mutation method written for **Update** operation in server side.

| Properties | Description |
|--------|----------------|
| record | The new record which is need to be updated. |
| action | Indicates the type of operation being performed. When the same method is used for all CRUD actions, this argument serves to distinguish the action, such as **Add, Delete and Update**  |
| primaryColumnName | Specifies the field name of the primary column. |
| primaryColumnValue | Specifies the primary column value which is needs to be updated in the collection.   |
| additionalParameters | An optional parameter that can be used to perform any operations.   |

The following variables are passed as a parameter to the mutation method written for **Delete** operation in server side.

| Properties | Description |
|--------|----------------|
| primaryColumnValue | Specifies the primary column value which is needs to be removed from the collection. |
| action | Indicates the type of operation being performed. When the same method is used for all CRUD actions, this argument serves to distinguish the action, such as **Add, Delete and Update**  |
| primaryColumnName | specifies the field name of the primary column.  |
| additionalParameters | An optional parameter that can be used to perform any operations.   |


```cshtml
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Data

<SfDataManager Url="https://xxxxxx" GraphQLAdaptorOptions=@adaptorOptions Adaptor="Adaptors.GraphQLAdaptor"></SfDataManager>

@code{
    private GraphQLAdaptorOptions adaptorOptions { get; set; } = new GraphQLAdaptorOptions
    {
        Query = @"
            query ordersData($dataManager: DataManagerRequestInput!){
                ordersData(dataManager: $dataManager) {
                    count, result { OrderID, CustomerID, OrderDate, Freight } , aggregates
                }
            }",
        Mutation = new GraphQLMutation
        {
            Insert = @"
                mutation create($record: OrderInput!, $index: Int!, $action: String!, $additionalParameters: Any) {
                  createOrder(order: $record, index: $index, action: $action, additionalParameters: $additionalParameters) {
                    OrderID, CustomerID, OrderDate, Freight
                  }
                }",
            Update = @"
                mutation update($record: OrderInput!, $action: String!, $primaryColumnName: String! , $primaryColumnValue: Int!, $additionalParameters: Any) {
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

The following code demonstrates the mutation methods used in the GraphQL server for CRUD operation.

```cshtml
    public class GraphQLMutation
    {
        public Order CreateOrder(Order order, int index, string action,
            [GraphQLType(typeof(AnyType))] IDictionary<string, object> additionalParameters)
        {
            GraphQLQuery.Orders.Insert(index, order);
            return order;
        }
        public Order UpdateOrder(Order order, string action, string primaryColumnName, int primaryColumnValue,
            [GraphQLType(typeof(AnyType))] IDictionary<string, object> additionalParameters)
        {
            Order updatedOrder = GraphQLQuery.Orders.Where(x => x.OrderID == primaryColumnValue).FirstOrDefault();
            updatedOrder.OrderID = order.OrderID;
            updatedOrder.CustomerID = order.CustomerID;
            updatedOrder.Freight = order.Freight;
            updatedOrder.OrderDate = order.OrderDate;
            return updatedOrder;
        }
        public Order DeleteOrder(int primaryColumnValue, string action, string primaryColumnName,
            [GraphQLType(typeof(AnyType))] IDictionary<string, object> additionalParameters)
        {
            Order deletedOrder = GraphQLQuery.Orders.Where(x => x.OrderID == primaryColumnValue).FirstOrDefault();
            GraphQLQuery.Orders.Remove(deletedOrder);
            return deletedOrder;
        }
    }
```

#### Batch editing

The following sample code demonstrates performing **Batch** operation. You have to set the Batch mutation query in [Batch](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.GraphQLMutation.html#Syncfusion_Blazor_Data_GraphQLMutation_Batch) property of Mutation in `GraphQLAdaptorOptions`.

The following variables are passed as a parameter to the mutation method written for **Batch** operation in server side.

| Properties | Description |
|--------|----------------|
| changed | Specifies the collection of record to be updated. |
| added | Specifies the collection of record to be inserted.  |
| deleted | Specifies the collection of record to be removed.   |
| action | Indicates the type of operation being performed. |
| primaryColumnName | Specifies the field name of the primary column.  |
| additionalParameters | An optional parameter that can be used to perform any operations.   |
| dropIndex | Specifies the record position, from which new records will be added while performing drag and drop.   |

```cshtml
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Data

<SfDataManager Url="https://xxxxxx" GraphQLAdaptorOptions=@adaptorOptions Adaptor="Adaptors.GraphQLAdaptor"></SfDataManager>

@code{
    private GraphQLAdaptorOptions adaptorOptions { get; set; } = new GraphQLAdaptorOptions
    {
        Query = @"
            query ordersData($dataManager: DataManagerRequestInput!){
                ordersData(dataManager: $dataManager) {
                    count, result { OrderID, CustomerID, OrderDate, Freight } , aggregates
                }
            }",
        Mutation = new GraphQLMutation
        {
            Batch = @"
                mutation batch($changed: [OrderInput!], $added: [OrderInput!], $deleted: [OrderInput!], $action: String!, $primaryColumnName: String!, $additionalParameters: Any, $dropIndex: Int) {
                  batchUpdate(changed: $changed, added: $added, deleted: $deleted, action: $action, primaryColumnName :$primaryColumnName, additionalParameters: $additionalParameters, dropIndex: $dropIndex) {
                    OrderID, CustomerID, OrderDate, Freight
                  }
                }"
        },
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

The following code demonstrates the mutation method used in the GraphQL server for **Batch** operation.

```cshtml
    public class GraphQLMutation
    {
        public List<Order> BatchUpdate(List<Order>? changed, List<Order>? added,
            List<Order>? deleted, string action, String primaryColumnName,
            [GraphQLType(typeof(AnyType))] IDictionary<string, object> additionalParameters, int? dropIndex)
        {
            if (changed != null && changed.Count > 0)
            {
                foreach (var changedOrder in (IEnumerable<Order>)changed)
                {
                    Order order = GraphQLQuery.Orders.Where(e => e.OrderID == changedOrder.OrderID).FirstOrDefault();
                    order.OrderID = changedOrder.OrderID;
                    order.CustomerID = changedOrder.CustomerID;
                    order.OrderDate = changedOrder.OrderDate;
                    order.Freight = changedOrder.Freight;
                }
            }
            if (added != null && added.Count > 0)
            {
                if (dropIndex != null)
                {
                    //for Drag and Drop feature
                    GraphQLQuery.Orders.InsertRange((int)dropIndex, added);
                }
                else {
                    foreach (var newOrder in (IEnumerable<Order>)added)
                    {
                        GraphQLQuery.Orders.Add(newOrder);
                    }
                }                
            }
            if (deleted != null && deleted.Count > 0)
            {
                foreach (var deletedOrder in (IEnumerable<Order>)deleted)
                {
                    GraphQLQuery.Orders.Remove(GraphQLQuery.Orders.Where(e => e.OrderID == deletedOrder.OrderID).FirstOrDefault());
                }
            }
            return GraphQLQuery.Orders;
        }
    }
```

### Configuration in GraphQL server application

The following code is the configuration in GraphQL server application to set GraphQL query, mutation type and to enable CORS.

Program.cs

```cshtml

var builder = WebApplication.CreateBuilder(args);

//GraphQL resolver is defined in GraphQLQuery class and mutation methods are defined in GraphQLMutation class
builder.Services.AddGraphQLServer().AddQueryType<GraphQLQuery>().AddMutationType<GraphQLMutation>();

//CORS is enabled to access the GraphQL server from the client application
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", builder =>
    {
        builder.WithOrigins("https://xxxxxx")
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials().Build();
    });
});

```

The following code demonstrates the **DataManagerRequest** class which is passed as an argument to the resolver function.

```cshtml
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

```

### Note

You can get the entire code in the [github](https://github.com/SyncfusionExamples/GraphQLAdaptor-Binding-Blazor-DataGrid) sample.

## WebMethod adaptor

You can use the `WebApiAdaptor` to interact with Web APIs created with OData endpoint. The `WebApiAdaptor` is extended from the `ODataAdaptor`. Hence to use `WebApiAdaptor`, the endpoint should understand the OData formatted queries sent along with request.

To enable OData query option for Web API, refer to this [documentation](https://learn.microsoft.com/en-us/aspnet/web-api/overview/odata-support-in-aspnet-web-api/supporting-odata-query-options).

The following sample code demonstrates binding remote data to the DataGrid component through the [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) using Web method service,

```cshtml
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.Grids

<SfGrid TValue="EmployeeData" ID="Grid">
    <SfDataManager Url="https://demoUrl/action" Adaptor="Adaptors.WebMethodAdaptor"></SfDataManager>
    <GridColumns>
        <GridColumn Field=@nameof(EmployeeData.EmployeeID) HeaderText="Employee ID" Width="120"></GridColumn>
        <GridColumn Field=@nameof(EmployeeData.FirstName) HeaderText="First Name" Width="130"></GridColumn>
        <GridColumn Field=@nameof(EmployeeData.Designation) HeaderText="Designation" Width="120"></GridColumn>
        <GridColumn Field=@nameof(EmployeeData.Country) HeaderText="Country" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    public class EmployeeData
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string Designation { get; set; }
        public string Country { get; set; }
    }
}
```

N> The above mentioned URL is given for reference purposes. In that place, you can provide your service URL.

`WebMethodAdaptor` expects JSON response from the server and the response object should contain properties `result` and `count` whose values are collection of entities and total count of the entities respectively.

The sample response object should look like below.

```csharp
{
    "result": [{..}, {..}, {..}, ...],
    "count": 830
}
```

N> The controller method’s data parameter name must be `value`.

## Writing custom adaptor

Sometimes the built-in adaptors do not meet your requirements and in such cases you can create your own adaptor.

To create and use custom adaptor, follow the following steps,

* Create a class which extended from DataAdaptor class. DataAdaptor class will act as base class for your custom adaptor.
* Override the desired method to achieve your requirement.
* Assign the custom adaptor class to the **AdaptorInstance** property of SfDataManager component.

You can refer to this [link](custom-binding) for more details on the working of custom adaptor.
