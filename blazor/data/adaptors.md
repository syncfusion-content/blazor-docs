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

Each data source or remote service uses different way for accepting request and sending back the response. The [SfDataManager](https://help.syncfusion.com/cr/aspnetcore-blazor/Syncfusion.Blazor.Data.SfDataManager.html) cannot anticipate every way a data source works. To tackle this problem the [SfDataManager](https://help.syncfusion.com/cr/aspnetcore-blazor/Syncfusion.Blazor.Data.SfDataManager.html) uses adaptor concept to communicate with the particular data source.

* For local data sources, the role of the data adaptor is to query the object array based on the Query object and manipulate them.

* For remote data source, the data adaptor is used to send the request that the server can understand which then processes the server response.

The adaptor can be assigned using the [Adaptor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html#Syncfusion_Blazor_DataManager_Adaptor) property of the [SfDataManager](https://help.syncfusion.com/cr/aspnetcore-blazor/Syncfusion.Blazor.Data.SfDataManager.html).

## Json adaptor

The `JsonAdaptor` is used to query and manipulate object array. 

The following sample code demonstrates binding data to the DataGrid component through the [SfDataManager](https://help.syncfusion.com/cr/aspnetcore-blazor/Syncfusion.Blazor.Data.SfDataManager.html) using `JsonAdaptor`,

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

The following sample code demonstrates binding data to the DataGrid component through the [SfDataManager](https://help.syncfusion.com/cr/aspnetcore-blazor/Syncfusion.Blazor.Data.SfDataManager.html) using `UrlAdaptor`,

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

[OData](https://www.odata.org/documentation/odata-version-3-0/) is a standardized protocol for creating and consuming data. You can retrieve data from OData service using [SfDataManager](https://help.syncfusion.com/cr/aspnetcore-blazor/Syncfusion.Blazor.Data.SfDataManager.html). The `ODataAdaptor` helps you to interact with OData service.

The following sample code demonstrates binding remote data to the DataGrid component through the [SfDataManager](https://help.syncfusion.com/cr/aspnetcore-blazor/Syncfusion.Blazor.Data.SfDataManager.html) using OData service,

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

The ODataV4 is an improved version of OData protocols and the [SfDataManager](https://help.syncfusion.com/cr/aspnetcore-blazor/Syncfusion.Blazor.Data.SfDataManager.html) can also retrieve and consume OData v4 services. For more details on OData v4 Services, refer the [odata documentation](http://docs.oasis-open.org/odata/odata/v4.0/errata03/os/complete/part1-protocol/odata-v4.0-errata03-os-part1-protocol-complete.html#_Toc453752197). You can use the `ODataV4Adaptor` to interact with ODataV4 service.

The following sample code demonstrates binding remote data to the DataGrid component through the [SfDataManager](https://help.syncfusion.com/cr/aspnetcore-blazor/Syncfusion.Blazor.Data.SfDataManager.html) using ODataV4 service,

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

To enable OData query option for Web API, refer to this [documentation](https://docs.microsoft.com/en-us/aspnet/web-api/overview/odata-support-in-aspnet-web-api/supporting-odata-query-options).

The following sample code demonstrates binding remote data to the DataGrid component through the [SfDataManager](https://help.syncfusion.com/cr/aspnetcore-blazor/Syncfusion.Blazor.Data.SfDataManager.html) using Web API service,

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

## GraphQL adaptor

The GraphQLAdaptor provides an option to retrieve data from the GraphQL server. It performs CRUD and data operations such as paging, sorting, filtering etc by sending the required arguments to the server.

You can provide the GraphQL query string by using the Query property of the GraphQLAdaptorOptions. Also you need to set the ResolverName property of GraphQLAdaptorOptions to map the response. The GraphQLAdaptor expects response as a JSON object with properties of Result, Count and Aggregates which contains the collection of entities, total number of records and value of aggregates respectively. The GraphQL response should be returned in JSON format like { “data”: { … }} with query name as field.

```cshtml
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.Grids

<SfGrid TValue="Order" AllowPaging=true AllowSorting=true AllowFiltering=true>
    <SfDataManager Url="https://xxxxxx" GraphQLAdaptorOptions=@adaptorOptions Adaptor="Adaptors.GraphQLAdaptor"></SfDataManager>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" IsPrimaryKey=true TextAlign="TextAlign.Right" Width="120"><GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText="Order Date" Format="d" TextAlign="TextAlign.Right"
        Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
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

Configuration in GraphQL server application to set GraphQL query and mutation type and to enable CORS.

Program.cs

```cshtml

var builder = WebApplication.CreateBuilder(args);
//GraphQL resolver is defined in GraphQLQuery class and mutation methods are defined in GraphQLMutation class
builder.Services.AddGraphQLServer().AddQueryType<GraphQLQuery>().AddMutationType<GraphQLMutation>();
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

Below is the resolver function in the GraphQL server used to bind data.

```cshtml
    public class GraphQLQuery
    {
        public ReturnType<Order> OrdersData(DataManagerRequest dataManager)
        {
            List<Order> result = Orders;
            if (dataManager.Search != null)
            {
                //Handle Searching here
                result = result.Where(order =>
                    order.OrderID.ToString().Contains(dataManager.Search.FirstOrDefault().Key) ||
                    order.CustomerID.Contains(dataManager.Search.FirstOrDefault().Key) ||
                    order.Freight.ToString().Contains(dataManager.Search.FirstOrDefault().Key) ||
                    order.OrderDate.ToString().Contains(dataManager.Search.FirstOrDefault().Key)
                ).ToList();
            }
            if (dataManager.Sorted != null)
            {
                //Handle Sorting here
                if (dataManager.Sorted.FirstOrDefault().Name == "OrderID")
                {
                    if (dataManager.Sorted.FirstOrDefault().Direction == "ascending")
                    {
                        result = result.OrderBy(order => order.OrderID).ToList();
                    }
                    else
                    {
                        result = result.OrderByDescending(order => order.OrderID).ToList();
                    }
                }
                if (dataManager.Sorted.FirstOrDefault().Name == "CustomerID")
                {
                    if (dataManager.Sorted.FirstOrDefault().Direction == "ascending")
                    {
                        result = result.OrderBy(order => order.CustomerID).ToList();
                    }
                    else
                    {
                        result = result.OrderByDescending(order => order.CustomerID).ToList();
                    }
                }
                if (dataManager.Sorted.FirstOrDefault().Name == "Freight")
                {
                    if (dataManager.Sorted.FirstOrDefault().Direction == "ascending")
                    {
                        result = result.OrderBy(order => order.Freight).ToList();
                    }
                    else
                    {
                        result = result.OrderByDescending(order => order.Freight).ToList();
                    }
                }
                if (dataManager.Sorted.FirstOrDefault().Name == "OrderDate")
                {
                    if (dataManager.Sorted.FirstOrDefault().Direction == "ascending")
                    {
                        result = result.OrderBy(order => order.OrderDate).ToList();
                    }
                    else
                    {
                        result = result.OrderByDescending(order => order.OrderDate).ToList();
                    }
                }
            }
            if (dataManager.Where != null)
            {
                //Handle filtering here
                IDictionary<string, object> keyValuePair = GetValue(dataManager.Where, new Dictionary<string, object>());
                string field = keyValuePair.FirstOrDefault().Key;
                object value = keyValuePair.FirstOrDefault().Value;
                if (field == "OrderID")
                {
                    result = result.Where(order => order.OrderID.Equals(value)).ToList();
                }
                else if (field == "CustomerID")
                {
                    result = result.Where(order => order.CustomerID.ToString().Contains((string)value)).ToList();
                }
                else if (field == "Freight")
                {
                    result = result.Where(order => order.Freight.ToString() == value.ToString()).ToList();
                }                
                else if (field == "OrderDate")
                {
                    result = result.Where(order => order.OrderDate.ToString().Contains((string)value)).ToList();
                }
            }
            int count = result.Count;
            if (dataManager.Skip > 0 || dataManager.Take > 0)
            {
                //Handle paging here
                result = result.Skip(dataManager.Skip).Take(dataManager.Take).ToList();
            }
            if (dataManager.Aggregates != null)
            {
                //Handle aggregate here
                IDictionary<string, object> aggregates;
                return new ReturnType<Order>() { Count = count, Result = result, Aggregates = aggregates };
            }
            return new ReturnType<Order>() { Count = count, Result = result };
        }


        private IDictionary<string, object> GetValue(List<WhereFilter> whereFilters, IDictionary<string, object> result)
        {
            foreach (var filter in whereFilters)
            {
                if ((bool)filter.IsComplex)
                {
                    if (filter.value == null)
                    {
                        result = GetValue(filter.predicates, result);
                    }
                }
                else
                {
                    result.Add(filter.Field, filter.value);
                }
            }
            return result;
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

Below is the DataManagerRequest class which is passed as an argument to the resolver function.

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

### Performing CRUD action with GraphQLAdaptor

You can perform the CRUD operations by setting the mutation queries in the Mutation property of GraphQLAdaptorOptions.

```cshtml
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.Grids

<SfGrid TValue="Order" AllowPaging=true AllowSorting=true AllowFiltering=true
    Toolbar="@(new List<string>() { "Search", "Add", "Edit", "Delete", "Cancel", "Update" })">
    <GridEditSettings AllowAdding=true AllowEditing=true AllowDeleting=true></GridEditSettings>
    <SfDataManager Url="https://xxxxxx" GraphQLAdaptorOptions=@adaptorOptions Adaptor="Adaptors.GraphQLAdaptor"></SfDataManager>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" IsPrimaryKey=true TextAlign="TextAlign.Right" Width="120"><GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText="Order Date" Format="d" TextAlign="TextAlign.Right"
        Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

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
                  createBook(order: $record, index: $index, action: $action, additionalParameters: $additionalParameters) {
                    OrderID, CustomerID, OrderDate, Freight
                  }
                }",
            Update = @"
                mutation update($record: OrderInput!, $action: String!, $primaryColumnName: String! , $primaryColumnValue: Int!, $additionalParameters: Any) {
                  updateBook(order: $record, action: $action, primaryColumnName: $primaryColumnName, primaryColumnValue: $primaryColumnValue, additionalParameters: $additionalParameters) {
                    OrderID, CustomerID, OrderDate, Freight
                  }
                }",
            Delete = @"
                mutation delete($primaryColumnValue: Int!, $action: String!, $primaryColumnName: String!, $additionalParameters: Any) {
                  deleteBook(primaryColumnValue: $primaryColumnValue, action: $action, primaryColumnName: $primaryColumnName, additionalParameters: $additionalParameters) {
                    OrderID, CustomerID, OrderDate, Freight
                  }
                }",
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
Below is the mutation methods in the GraphQL server used for CRUD operation

```cshtml
    public class GraphQLMutation
    {
        public Order CreateBook(Order order, int index, string action,
            [GraphQLType(typeof(AnyType))] IDictionary<string, object> additionalParameters)
        {
            GraphQLQuery.Orders.Insert(index, order);
            return order;
        }
        public Order UpdateBook(Order order, string action, string primaryColumnName, int primaryColumnValue,
            [GraphQLType(typeof(AnyType))] IDictionary<string, object> additionalParameters)
        {
            Order updatedOrder = GraphQLQuery.Orders.Where(x => x.OrderID == primaryColumnValue).FirstOrDefault();
            updatedOrder.OrderID = order.OrderID;
            updatedOrder.CustomerID = order.CustomerID;
            updatedOrder.Freight = order.Freight;
            updatedOrder.OrderDate = order.OrderDate;
            return updatedOrder;
        }
        public Order DeleteBook(int primaryColumnValue, string action, string primaryColumnName,
            [GraphQLType(typeof(AnyType))] IDictionary<string, object> additionalParameters)
        {
            Order deletedOrder = GraphQLQuery.Orders.Where(x => x.OrderID == primaryColumnValue).FirstOrDefault();
            GraphQLQuery.Orders.Remove(deletedOrder);
            return deletedOrder;
        }
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
                    //for Drag and Drop feature in Grid
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
Below is the resolver function in the GraphQL server used to bind data.

```cshtml
    public class GraphQLQuery
    {
        public ReturnType<Order> OrdersData(DataManagerRequest dataManager)
        {
            List<Order> result = Orders;
            if (dataManager.Search != null)
            {
                //Handle Searching here
                result = result.Where(order =>
                    order.OrderID.ToString().Contains(dataManager.Search.FirstOrDefault().Key) ||
                    order.CustomerID.Contains(dataManager.Search.FirstOrDefault().Key) ||
                    order.Freight.ToString().Contains(dataManager.Search.FirstOrDefault().Key) ||
                    order.OrderDate.ToString().Contains(dataManager.Search.FirstOrDefault().Key)
                ).ToList();
            }
            if (dataManager.Sorted != null)
            {
                //Handle Sorting here
                if (dataManager.Sorted.FirstOrDefault().Name == "OrderID")
                {
                    if (dataManager.Sorted.FirstOrDefault().Direction == "ascending")
                    {
                        result = result.OrderBy(order => order.OrderID).ToList();
                    }
                    else
                    {
                        result = result.OrderByDescending(order => order.OrderID).ToList();
                    }
                }
                if (dataManager.Sorted.FirstOrDefault().Name == "CustomerID")
                {
                    if (dataManager.Sorted.FirstOrDefault().Direction == "ascending")
                    {
                        result = result.OrderBy(order => order.CustomerID).ToList();
                    }
                    else
                    {
                        result = result.OrderByDescending(order => order.CustomerID).ToList();
                    }
                }
                if (dataManager.Sorted.FirstOrDefault().Name == "Freight")
                {
                    if (dataManager.Sorted.FirstOrDefault().Direction == "ascending")
                    {
                        result = result.OrderBy(order => order.Freight).ToList();
                    }
                    else
                    {
                        result = result.OrderByDescending(order => order.Freight).ToList();
                    }
                }
                if (dataManager.Sorted.FirstOrDefault().Name == "OrderDate")
                {
                    if (dataManager.Sorted.FirstOrDefault().Direction == "ascending")
                    {
                        result = result.OrderBy(order => order.OrderDate).ToList();
                    }
                    else
                    {
                        result = result.OrderByDescending(order => order.OrderDate).ToList();
                    }
                }
            }
            if (dataManager.Where != null)
            {
                //Handle filtering here
                IDictionary<string, object> keyValuePair = GetValue(dataManager.Where, new Dictionary<string, object>());
                string field = keyValuePair.FirstOrDefault().Key;
                object value = keyValuePair.FirstOrDefault().Value;
                if (field == "OrderID")
                {
                    result = result.Where(order => order.OrderID.Equals(value)).ToList();
                }
                else if (field == "CustomerID")
                {
                    result = result.Where(order => order.CustomerID.ToString().Contains((string)value)).ToList();
                }
                else if (field == "Freight")
                {
                    result = result.Where(order => order.Freight.ToString() == value.ToString()).ToList();
                }                
                else if (field == "OrderDate")
                {
                    result = result.Where(order => order.OrderDate.ToString().Contains((string)value)).ToList();
                }
            }
            int count = result.Count;
            if (dataManager.Skip > 0 || dataManager.Take > 0)
            {
                //Handle paging here
                result = result.Skip(dataManager.Skip).Take(dataManager.Take).ToList();
            }
            if (dataManager.Aggregates != null)
            {
                //Handle aggregate here
                IDictionary<string, object> aggregates;
                return new ReturnType<Order>() { Count = count, Result = result, Aggregates = aggregates };
            }
            return new ReturnType<Order>() { Count = count, Result = result };
        }


        private IDictionary<string, object> GetValue(List<WhereFilter> whereFilters, IDictionary<string, object> result)
        {
            foreach (var filter in whereFilters)
            {
                if ((bool)filter.IsComplex)
                {
                    if (filter.value == null)
                    {
                        result = GetValue(filter.predicates, result);
                    }
                }
                else
                {
                    result.Add(filter.Field, filter.value);
                }
            }
            return result;
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

Below is code for DataManagerRequest class which is passed as an argument to the resolver function.

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

## WebMethod adaptor

You can use the `WebApiAdaptor` to interact with Web APIs created with OData endpoint. The `WebApiAdaptor` is extended from the `ODataAdaptor`. Hence to use `WebApiAdaptor`, the endpoint should understand the OData formatted queries sent along with request.

To enable OData query option for Web API, refer to this [documentation](https://docs.microsoft.com/en-us/aspnet/web-api/overview/odata-support-in-aspnet-web-api/supporting-odata-query-options).

The following sample code demonstrates binding remote data to the DataGrid component through the [SfDataManager](https://help.syncfusion.com/cr/aspnetcore-blazor/Syncfusion.Blazor.Data.SfDataManager.html) using Web method service,

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