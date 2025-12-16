---
layout: post
title: Bind GraphQL Data in Blazor TreeGrid | Syncfusion
description: Learn how to bind data from a GraphQL API to the Syncfusion Blazor TreeGrid, including querying, mutation, and integration techniques.
platform: Blazor
control: TreeGrid
documentation: ug
---

# GraphQL Adaptor in Blazor TreeGrid

GraphQL is a powerful query language for APIs, designed to provide a more efficient alternative to traditional REST APIs. It allows you to precisely fetch the data you need, reducing over-fetching and under-fetching of data. GraphQL provides a flexible and expressive syntax for querying, enabling clients to request only the specific data they require.

Syncfusion’s Blazor TreeGrid  seamlessly integrates with GraphQL servers using the GraphQLAdaptor in the [SfDataManager](https://blazor.syncfusion.com/documentation/data/getting-started-with-web-app). This specialized adaptor simplifies the interaction between the TreeGrid and GraphQL servers, allowing efficient data retrieval with support for data operations like CRUD (Create, Read, Update and Delete), paging, sorting, and filtering.

This section describes a step-by-step process for retrieving data from a GraphQL service using GraphQLAdaptor, then binding it to the TreeGrid to facilitate data and CRUD operations.

## Configure a GraphQL server

To configure a GraphQL server using Hot Chocolate with the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor TreeGrid, follow these steps:

**Step 1: Create a new ASP.NET Core application**

- Open Visual Studio and select **Create a new project**.
- Choose **ASP.NET Core Web App** and name the project `GraphQLServer`.
- Alternatively, you can use a terminal or command prompt to create the project:
    ```bash
    dotnet new web -n GraphQLServer
    ```
- Navigate to the project directory:
    ```bash
    cd GraphQLServer
    ```

**Step 2: Add the Hot Chocolate NuGet package**

- Open the **NuGet Package Manager** by right-clicking on the project in the **Solution Explorer** and selecting **Manage NuGet Packages**.
- Go to the **Browse** tab, search for `HotChocolate.AspNetCore`, and select the package.
- Click **Install** to add it to your project.

Alternatively, you can use the **Package Manager Console** to install the package by running the following command:

```powershell
Install-Package HotChocolate.AspNetCore
```

**Step 3: Create a model class**

Add a new folder named **Models**. Then, add a model class named **OrderData.cs** in the **Models** folder to represent the order data.

{% tabs %}
{% highlight cs tabtitle="OrderData.cs" %}

using System.Text.Json.Serialization;

namespace GraphQLServer.Models
{
    public class OrderData
    {
        public int OrderID { get; set; }
        public string? CustomerName { get; set; }
        public string? ShipCity { get; set; }
        public string? ShipCountry { get; set; }
        public int? ParentID { get; set; }
        public bool HasChild { get; set; }

        private static readonly object _sync = new();
        private static List<OrderData>? _store;

        public static List<OrderData> GetAllRecords()
        {
            // Return the same list every time so mutations persist
            if (_store != null) return _store;

            lock (_sync)
            {
                if (_store == null)
                {
                    // Seed once. Replace with your real seed data.
                    _store = new List<OrderData>
                    {
                        // Root: Germany
                        new OrderData { OrderID = 1, CustomerName = "Alfreds Futterkiste", ShipCity = "Berlin", ShipCountry = "Germany", ParentID = null, HasChild = true },
                        new OrderData { OrderID = 2, CustomerName = "Ana Trujillo Emparedados y Helados", ShipCity = "México D.F.", ShipCountry = "Mexico", ParentID = 1, HasChild = false },
                        new OrderData { OrderID = 3, CustomerName = "Bayerische Feinkost GmbH", ShipCity = "Munich", ShipCountry = "Germany", ParentID = 1, HasChild = false },
                        new OrderData { OrderID = 4, CustomerName = "Nordsee Handelshaus", ShipCity = "Hamburg", ShipCountry = "Germany", ParentID = 1, HasChild = false },
                        new OrderData { OrderID = 5, CustomerName = "Rheinland Delikatessen", ShipCity = "Cologne", ShipCountry = "Germany", ParentID = 1, HasChild = false },

                        // Root: UK
                        new OrderData { OrderID = 6, CustomerName = "Around the Horn", ShipCity = "London", ShipCountry = "UK", ParentID = null, HasChild = true },
                        new OrderData { OrderID = 7, CustomerName = "Bon app'", ShipCity = "Paris", ShipCountry = "France", ParentID = 6, HasChild = false },
                        new OrderData { OrderID = 8, CustomerName = "B's Beverages", ShipCity = "London", ShipCountry = "UK", ParentID = 6, HasChild = false },
                        new OrderData { OrderID = 9, CustomerName = "Romero y Tomillo", ShipCity = "Madrid", ShipCountry = "Spain", ParentID = 6, HasChild = false },
                        new OrderData { OrderID = 10, CustomerName = "Midlands Market Ltd.", ShipCity = "Birmingham", ShipCountry = "UK", ParentID = 6, HasChild = false },

                        // Root: Japan
                        new OrderData { OrderID = 11, CustomerName = "Tokyo Traders", ShipCity = "Tokyo", ShipCountry = "Japan", ParentID = null, HasChild = true },
                        new OrderData { OrderID = 12, CustomerName = "Osaka Noodle Co.", ShipCity = "Osaka", ShipCountry = "Japan", ParentID = 11, HasChild = false },
                        new OrderData { OrderID = 13, CustomerName = "Sydney Food Market", ShipCity = "Sydney", ShipCountry = "Australia", ParentID = 11, HasChild = false },

                        // Root: Australia (no children)

                        // Root: Brazil
                        new OrderData { OrderID = 14, CustomerName = "Rio Supermercados", ShipCity = "Rio de Janeiro", ShipCountry = "Brazil", ParentID = null, HasChild = true },
                        new OrderData { OrderID = 15, CustomerName = "Que Delícia", ShipCity = "São Paulo", ShipCountry = "Brazil", ParentID = 14, HasChild = false },
                        new OrderData { OrderID = 16, CustomerName = "Rio Grande Imports", ShipCity = "Rio de Janeiro", ShipCountry = "Brazil", ParentID = 14, HasChild = false },

                        // Root: Italy
                        new OrderData { OrderID = 17, CustomerName = "Magazzini Alimentari Riuniti", ShipCity = "Rome", ShipCountry = "Italy", ParentID = null, HasChild = true },
                        new OrderData { OrderID = 18, CustomerName = "La Casa di Pasta", ShipCity = "Milan", ShipCountry = "Italy", ParentID = 17, HasChild = false },
                        new OrderData { OrderID = 19, CustomerName = "Napoli Dolce & Salato", ShipCity = "Naples", ShipCountry = "Italy", ParentID = 17, HasChild = false },
                        new OrderData { OrderID = 20, CustomerName = "Torino Alimentari", ShipCity = "Turin", ShipCountry = "Italy", ParentID = 17, HasChild = false }
                    };
                }
            }
            return _store!;
        }
    }
}

{% endhighlight %}
{% endtabs %}

**Step 4: Define the GraphQL query**

Create a `GraphQLQuery` class to define the query resolver for fetching order data. This class will handle the logic for retrieving data from the `OrderData` model. The following code demonstrates the `DataManagerRequestInput` class, which is passed as an argument to the resolver function.

{% tabs %}
{% highlight cs tabtitle="GraphQLQuery.cs" %}

using GraphQLServer.Models;

/// <summary>
/// Represents the GraphQL query resolver for fetching order data.
/// </summary>
public class GraphQLQuery
{
    // Exposed as 'ordersData' by default
    public OrdersDataResponse OrdersData(DataManagerRequestInput dataManager)
    {
        var all = OrderData.GetAllRecords() ?? new List<OrderData>();

        // Pagination only
        int skip = dataManager?.Skip ?? 0;
        int take = dataManager?.Take ?? 0;
        bool requiresCounts = dataManager?.RequiresCounts ?? true;

        // Params (case-insensitive)
        var p = AsCaseInsensitiveDict(dataManager?.Params);
        int? parentIdParam =
            GetIntN(p, "parentId") ??
            GetIntN(p, "ParentId") ??
            GetIntN(p, "ParentID") ??
            GetIntN(p, "parentID") ??
            GetIntN(p, "parentItem") ??
            GetIntN(p, "ParentItem");
        // Also honor expandParentId param sent by UI when expanding rows
        int? expandParentIdParam =
            GetIntN(p, "expandParentId") ?? GetIntN(p, "ExpandParentId") ?? GetIntN(p, "ExpandParentID");
        // Fallback: attempt to infer parent id from common keys if not provided explicitly
        int? inferredParentId = InferParentId(p);

        // Extract ParentID filters only (for child slice)
        var where = dataManager?.Where ?? new List<WhereFilter>();
        var parentIds = GetParentIdFilters(where);
        if (parentIdParam is int pidFromParams)
            parentIds.Add(pidFromParams);
        if (expandParentIdParam is int epid)
            parentIds.Add(epid);
        if (inferredParentId is int ipid)
            parentIds.Add(ipid);

        // Build group map once for deep traversal (used only when loadChildOnDemand is true)
        var groupMap = BuildGroupMap(all);

        if (parentIds.Count > 0)
        {
            // CHILDREN SLICE: return only direct children of the requested parents (no descendants)
            var childrenUnion = new List<OrderData>(128);
            foreach (var pid in parentIds)
                childrenUnion.AddRange(all.Where(o => o.ParentID == pid));

            // De-duplicate and sort
            childrenUnion = childrenUnion
                .GroupBy(o => o.OrderID)
                .Select(g => g.First())
                .OrderBy(o => o.OrderID)
                .ToList();

            // IMPORTANT: Do NOT apply root-level paging to children slice
            var total = childrenUnion.Count;

            return new OrdersDataResponse
            {
                Count = requiresCounts ? total : childrenUnion.Count,
                Result = childrenUnion
            };
        }
        else
        {
            // ROOTS: proper root-level paging (children do not affect paging)
            var rootsAll = all.Where(o => o.ParentID == null)
                            .OrderBy(o => o.OrderID)
                            .ToList();
            var totalRoots = rootsAll.Count;

            // Root window by Skip/Take
            var rootsWindow = rootsAll;
            if (skip > 0) rootsWindow = rootsWindow.Skip(skip).ToList();
            if (take > 0) rootsWindow = rootsWindow.Take(take).ToList();

            // Always return roots with all descendants (expanded view)
            List<OrderData> result = FlattenWithDescendants(rootsWindow, groupMap);

            return new OrdersDataResponse
            {
                Count = requiresCounts ? totalRoots : result.Count,
                Result = result
            };
        }
    }

    // Alias to match client query field name 'dataManager'
    [GraphQLName("dataManager")]
    public OrdersDataResponse DataManager(DataManagerRequestInput dataManager) => OrdersData(dataManager);

    // Build parent -> children map from the entire data set
    private static Dictionary<int, List<OrderData>> BuildGroupMap(IEnumerable<OrderData> all)
    {
        var map = new Dictionary<int, List<OrderData>>();
        foreach (var o in all)
        {
            if (o.ParentID is int pid)
            {
                if (!map.TryGetValue(pid, out var list))
                {
                    list = new List<OrderData>(4);
                    map[pid] = list;
                }
                list.Add(o);
            }
        }
        foreach (var kv in map)
            kv.Value.Sort((a, b) => a.OrderID.CompareTo(b.OrderID));
        return map;
    }

    // Flatten a fixed set of starts; children do not influence paging (roots window already applied)
    private static List<OrderData> FlattenWithDescendants(
        List<OrderData> starts,
        Dictionary<int, List<OrderData>> groupMap)
    {
        var flat = new List<OrderData>(Math.Max(16, starts.Count * 8));
        foreach (var start in starts)
        {
            flat.Add(start);

            if (groupMap.TryGetValue(start.OrderID, out var firstLevel) && firstLevel.Count > 0)
            {
                var stack = new Stack<OrderData>(firstLevel.Count * 4);
                for (int i = firstLevel.Count - 1; i >= 0; i--)
                    stack.Push(firstLevel[i]);

                while (stack.Count > 0)
                {
                    var node = stack.Pop();
                    flat.Add(node);

                    if (groupMap.TryGetValue(node.OrderID, out var kids) && kids.Count > 0)
                    {
                        for (int i = kids.Count - 1; i >= 0; i--)
                            stack.Push(kids[i]);
                    }
                }
            }
        }
        return flat;
    }

    // ----------- Utility: Params parsing and parent-id extraction -----------
    private static int? InferParentId(Dictionary<string, object> p)
    {
        // Common client keys that may carry the expanded row id
        string[] keys = new[] { "key", "id", "rowId", "RowId", "RowID", "primaryKey", "PrimaryKey" };
        foreach (var k in keys)
        {
            var n = GetIntN(p, k);
            if (n.HasValue) return n.Value;
        }
        // Any key containing 'parent' and 'id'
        foreach (var kv in p)
        {
            var name = kv.Key ?? string.Empty;
            if (name.IndexOf("parent", StringComparison.OrdinalIgnoreCase) >= 0 &&
                name.IndexOf("id", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                var n = GetIntN(p, name);
                if (n.HasValue) return n.Value;
            }
        }
        return null;
    }

    private static Dictionary<string, object> AsCaseInsensitiveDict(object? obj)
    {
        var dict = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
        if (obj is IDictionary<string, object> dso)
        {
            foreach (var kv in dso) dict[kv.Key] = kv.Value!;
        }
        else if (obj is JsonElement je && je.ValueKind == JsonValueKind.Object)
        {
            foreach (var prop in je.EnumerateObject())
                dict[prop.Name] = prop.Value;
        }
        return dict;
    }

    private static int? GetIntN(Dictionary<string, object> p, string key)
    {
        if (!p.TryGetValue(key, out var v) || v is null) return null;
        return ToIntNullable(v);
    }

    private static int? ToIntNullable(object val)
    {
        switch (val)
        {
            case int i: return i;
            case long l: return (int)l;
            case string s when int.TryParse(s, out var si): return si;
            case JsonElement je:
                if (je.ValueKind == JsonValueKind.Number && je.TryGetInt32(out var ni)) return ni;
                if (je.ValueKind == JsonValueKind.String && int.TryParse(je.GetString(), out var ns)) return ns;
                break;
        }
        return null;
    }

    private static HashSet<int> GetParentIdFilters(List<WhereFilter> where)
    {
        var ids = new HashSet<int>();
        if (where == null) return ids;

        static bool IsParentField(string field)
            => field.Equals("ParentID", StringComparison.OrdinalIgnoreCase)
            || field.Equals("ParentId", StringComparison.OrdinalIgnoreCase)
            || field.Equals("parentId", StringComparison.OrdinalIgnoreCase)
            || field.Equals("parentID", StringComparison.OrdinalIgnoreCase)
            || field.Equals("ParentItem", StringComparison.OrdinalIgnoreCase)
            || field.Equals("parentItem", StringComparison.OrdinalIgnoreCase);

        void Walk(IEnumerable<WhereFilter> filters)
        {
            foreach (var f in filters)
            {
                if (f.IsComplex == true && f.Predicates?.Count > 0)
                {
                    Walk(f.Predicates);
                    continue;
                }
                if (!string.IsNullOrWhiteSpace(f.Field) &&
                    IsParentField(f.Field) &&
                    (string.Equals(f.Operator, "equal", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(f.Operator, "==", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(f.Operator, "eq", StringComparison.OrdinalIgnoreCase)))
                {
                    var n = ToIntNullable(f.Value ?? "");
                    if (n.HasValue) ids.Add(n.Value);
                }
            }
        }

        Walk(where);
        return ids;
    }
}

/// <summary>
/// Represents the response structure for order data queries.
/// </summary>
public class OrdersDataResponse
{
    /// <summary>
    /// Gets or sets the total count of records.
    /// </summary>
    public int Count { get; set; }

    /// <summary>
    /// Gets or sets the list of order data records.
    /// </summary>
    public List<OrderData> Result { get; set; } = new List<OrderData>();
}

{% endhighlight %}

{% highlight cs tabtitle="DataManagerRequest.cs" %}

namespace GraphQLServer.Models
{
    /// <summary>
    /// Represents the input structure for data manager requests.
    /// </summary>
    public class DataManagerRequestInput
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

    /// <summary>
    /// Represents an aggregate operation in the data manager request.
    /// </summary>
    public class Aggregate
    {
        [GraphQLName("Field")]
        public string Field { get; set; }

        [GraphQLName("Type")]
        public string Type { get; set; }
    }

    /// <summary>
    /// Represents a search filter in the data manager request.
    /// </summary>
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

    /// <summary>
    /// Represents a sorting operation in the data manager request.
    /// </summary>
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

    /// <summary>
    /// Represents a filter condition in the data manager request.
    /// </summary>
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

        [GraphQLName("Value")]
        [GraphQLType(typeof(AnyType))]
        public object? Value { get; set; }

        [GraphQLName("predicates")]
        public List<WhereFilter>? predicates { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

**Step 5: Configure the GraphQL server**

Update the `Program.cs` file to configure the GraphQL server. This configuration ensures that the server can handle GraphQL requests effectively.

{% tabs %}
{% highlight cs tabtitle="Program.cs" %}

var builder = WebApplication.CreateBuilder(args);

// Register GraphQL services.
builder.Services.AddGraphQLServer()
    .AddQueryType<GraphQLQuery>();

var app = builder.Build();

// Use routing middleware.
app.UseRouting();

// Map endpoints.
app.MapGet("/", () => "Hello, World!");
app.MapGraphQL(); // Maps the /graphql endpoint by default.

app.Run();

{% endhighlight %}
{% endtabs %}

**Step 6: Test the GraphQL endpoint**

To verify that the GraphQL server is functioning correctly, use the following example query in a GraphQL client or playground:

```
{
    ordersData {
        count
        result {
            orderID
            customerID
            shipCity
            shipCountry
        }
    }
}
```

This query will return the total count of orders and a list of order details. Ensure the server is running and accessible at `http://localhost:xxxx/graphql` before testing. Here, `xxxx` represents the port number.

For more details, refer to the [Hot Chocolate documentation](https://chillicream.com/docs/hotchocolate).

## Connecting Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor TreeGrid to an GraphQL service
 
To integrate the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor TreeGrid into your project using Visual Studio, follow the below steps:

**Step 1: Create a Blazor Web App**

Create a **Blazor Web App** named **TreeGrid** using Visual Studio. You can use either [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-8.0) or the [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-integration/template-studio). Ensure you configure the appropriate [interactive render mode](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/render-modes?view=aspnetcore-8.0#render-modes) and [interactivity location](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-8.0&pivots=windows).

**Step 2: Install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor TreeGrid and Themes NuGet packages**

To add the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor TreeGrid to your app, open the NuGet Package Manager in Visual Studio (*Tools → NuGet Package Manager → Manage NuGet Packages for Solution*). Search for and install the following packages:

- [Syncfusion.Blazor.TreeGrid](https://www.nuget.org/packages/Syncfusion.Blazor.TreeGrid/)
- [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/)

If your Blazor Web App uses `WebAssembly` or `Auto` render modes, install these packages in the client project.

Alternatively, use the following Package Manager commands:

```powershell
Install-Package Syncfusion.Blazor.TreeGrid -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.Themes -Version {{ site.releaseversion }}
```

> Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components are available on [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). Refer to the [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for a complete list of available packages.

**Step 3: Register Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor service**

- Open the **~/_Imports.razor** file and import the required namespaces:

```cs
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.TreeGrid
@using Syncfusion.Blazor.Data
```

- Register the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor service in the **~/Program.cs** file:

```csharp
using Syncfusion.Blazor;

builder.Services.AddSyncfusionBlazor();
```

For apps using `WebAssembly` or `Auto (Server and WebAssembly)` render modes, register the service in both **~/Program.cs** files.

**Step 4: Add stylesheet and script resources**

Include the theme stylesheet and script references in the **~/Components/App.razor** file:

```html
<head>
    ...
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
</head>
...
<body>
    ...
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
</body>
```

> - Refer to the [Blazor Themes](https://blazor.syncfusion.com/documentation/appearance/themes) topic for various methods to include themes (e.g., Static Web Assets, CDN, or CRG).
> - Set the `rendermode` to **InteractiveServer** or **InteractiveAuto** in your Blazor Web App configuration.

**Step 5: Add Blazor TreeGrid and Configure with server**

To bind GraphQL service data to the TreeGrid, provide the GraphQL query string using the [Query](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.GraphQLAdaptorOptions.html#Syncfusion_Blazor_Data_GraphQLAdaptorOptions_Query) property of the [GraphQLAdaptorOptions](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.GraphQLAdaptorOptions.html). Additionally, set the [ResolverName](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.GraphQLAdaptorOptions.html#Syncfusion_Blazor_Data_GraphQLAdaptorOptions_ResolverName) property to map the response. The GraphQLAdaptor expects the response as a JSON object with properties `Result`, `Count`, and `Aggregates`, which contain the collection of entities, total number of records, and aggregate values, respectively. The GraphQL response should be returned in JSON format like `{ "data": { ... } }` with the query name as the field.

{% tabs %}
{% highlight cs tabtitle="Home.razor" %}

@page "/"

@rendermode InteractiveServer
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.TreeGrid
@using System.Text.Json.Serialization


<SfTreeGrid TValue="OrderData"
            AllowPaging="true"
            EnableVirtualization=false
            IdMapping="OrderID"
            ParentIdMapping="ParentID"
            HasChildMapping="HasChild"
            TreeColumnIndex="1"
            Height="412"
            RowHeight="38">
    <SfDataManager Url="https://localhost:7213/graphql"
                   Adaptor="Adaptors.GraphQLAdaptor"
                   GraphQLAdaptorOptions="@adaptorOptions">
    </SfDataManager>
    <TreeGridPageSettings PageSize="3"></TreeGridPageSettings>
    <TreeGridColumns>
        <TreeGridColumn Field="OrderID" HeaderText="Order ID" IsPrimaryKey="true" Width="120" TextAlign="TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="CustomerName" HeaderText="Customer Name" Width="150"></TreeGridColumn>
        <TreeGridColumn Field="ShipCity" HeaderText="Ship City" Width="150"></TreeGridColumn>
        <TreeGridColumn Field="ShipCountry" HeaderText="Ship Country" Width="160"></TreeGridColumn>
    </TreeGridColumns>
</SfTreeGrid>

@code {
    // IMPORTANT:
    // - Replace https://localhost:xxxx/graphql with your actual server port.
    // - The server code already supports TreeGrid lazy loading via Params.parentId when expanding nodes.
    // - ResolverName "ordersData" matches the server query method OrdersData in Models/GraphQLQuery.cs.
    private GraphQLAdaptorOptions adaptorOptions = new GraphQLAdaptorOptions
    {
        Query = @"
        query ordersData($dataManager: DataManagerRequestInput!) {
        ordersData(dataManager: $dataManager) {
            count
            result {
            orderID
            customerName
            shipCity
            shipCountry
            parentID
            hasChild
            }
        }
        }",
        ResolverName = "OrdersData"
    };

    // TreeGrid data model used on the client (camelCase mapping to match server schema)
    public class OrderData
    {
        [JsonPropertyName("orderID")]
        public int OrderID { get; set; }

        [JsonPropertyName("customerName")]
        public string? CustomerName { get; set; }

        [JsonPropertyName("shipCity")]
        public string? ShipCity { get; set; }

        [JsonPropertyName("shipCountry")]
        public string? ShipCountry { get; set; }

        [JsonPropertyName("parentID")]
        public int? ParentID { get; set; }

        [JsonPropertyName("hasChild")]
        public bool HasChild { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

> Replace `https://localhost:xxxx/graphql` with the actual URL of your API endpoint that provides the data in a consumable format (e.g., JSON).

**Step 6: Enable CORS Policy**

To allow your Blazor application to access the GraphQL server, you need to enable Cross-Origin Resource Sharing (CORS) in your server application. Add the following code to your `Program.cs` file:

```csharp
// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", policy =>
    {
        // Replace with your Blazor app's URL.
        policy.WithOrigins("https://localhost:xxxx/") 
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});

// Use CORS.
app.UseCors("AllowSpecificOrigin");
```

This configuration ensures that your Blazor application can communicate with the GraphQL server without encountering CORS-related issues.

**Step 7: Run the Application**

After completing the setup, run your application. The TreeGrid will fetch and display data from the configured GraphQL API. Ensure that both the Blazor application and the GraphQL server are running and accessible.
 
![GraphQL Adaptor Data](./images/GraphQlRender.gif)

**Understanding DataManagerRequestInput Class**

Before you dive into specific data operations like search, sorting, or filtering, it's essential to understand the request structure that the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor TreeGrid sends to the GraphQL server.

The following code demonstrates the `DataManagerRequestInput` class, which encapsulates parameters such as pagination (Skip, Take), search filters (Search), sorting (Sorted), and more. These parameters are passed as arguments to the resolver function for processing.

{% tabs %}
{% highlight cs tabtitle="DataManagerRequest.cs" %}

namespace GraphQLServer.Models
{
    /// <summary>
    /// Represents the input structure for data manager requests.
    /// </summary>
    public class DataManagerRequestInput
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

    /// <summary>
    /// Represents an aggregate operation in the data manager request.
    /// </summary>
    public class Aggregate
    {
        [GraphQLName("Field")]
        public string Field { get; set; }

        [GraphQLName("Type")]
        public string Type { get; set; }
    }

    /// <summary>
    /// Represents a search filter in the data manager request.
    /// </summary>
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

    /// <summary>
    /// Represents a sorting operation in the data manager request.
    /// </summary>
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

    /// <summary>
    /// Represents a filter condition in the data manager request.
    /// </summary>
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

        [GraphQLName("Value")]
        [GraphQLType(typeof(AnyType))]
        public object? Value { get; set; }

        [GraphQLName("predicates")]
        public List<WhereFilter>? predicates { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

## Handling searching operation

To handle search operations in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor TreeGrid using the GraphQLAdaptor, you can make use of the `dataManager.Search` parameters and apply the search logic on the server side. This allows users to efficiently filter and retrieve relevant records from the TreeGrid based on the provided search criteria.

When a search is performed in the TreeGrid, the DataManager sends the search parameters to the server, which include the search keyword and the list of fields to search against. The server then processes these parameters and filters the data accordingly.

![GraphqlAdaptor - Searching](./images/GraphqlSearch.gif)

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

@page "/"
@rendermode InteractiveServer
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.TreeGrid
@using System.Text.Json.Serialization


<SfTreeGrid TValue="OrderData"
            AllowPaging="true"
            EnableVirtualization=false
            IdMapping="OrderID"
            ParentIdMapping="ParentID"
            HasChildMapping="HasChild"
            TreeColumnIndex="1"
            Height="412"
            Toolbar="@(new List<string>() { "Search"})"
            RowHeight="38">
    <SfDataManager Url="https://localhost:xxxx/graphql"
                   Adaptor="Adaptors.GraphQLAdaptor"
                   GraphQLAdaptorOptions="@adaptorOptions">
    </SfDataManager>
    <TreeGridPageSettings PageSize="3"></TreeGridPageSettings>
    <TreeGridColumns>
        <TreeGridColumn Field="OrderID" HeaderText="Order ID" IsPrimaryKey="true" Width="120" TextAlign="TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="CustomerName" HeaderText="Customer Name" Width="150"></TreeGridColumn>
        <TreeGridColumn Field="ShipCity" HeaderText="Ship City" Width="150"></TreeGridColumn>
        <TreeGridColumn Field="ShipCountry" HeaderText="Ship Country" Width="160"></TreeGridColumn>
    </TreeGridColumns>
</SfTreeGrid>

@code {
    // IMPORTANT:
    // - Replace https://localhost:xxxx/graphql with your actual server port.
    // - The server code already supports TreeGrid lazy loading via Params.parentId when expanding nodes.
    // - ResolverName "ordersData" matches the server query method OrdersData in Models/GraphQLQuery.cs.
    private GraphQLAdaptorOptions adaptorOptions = new GraphQLAdaptorOptions
    {
        Query = @"
        query ordersData($dataManager: DataManagerRequestInput!) {
          ordersData(dataManager: $dataManager) {
            count
            result {
              orderID
              customerName
              shipCity
              shipCountry
              parentID
              hasChild
            }
          }
        }",
        ResolverName = "OrdersData"
    };

    // TreeGrid data model used on the client (camelCase mapping to match server schema)
    public class OrderData
    {
        [JsonPropertyName("orderID")]
        public int OrderID { get; set; }

        [JsonPropertyName("customerName")]
        public string? CustomerName { get; set; }

        [JsonPropertyName("shipCity")]
        public string? ShipCity { get; set; }

        [JsonPropertyName("shipCountry")]
        public string? ShipCountry { get; set; }

        [JsonPropertyName("parentID")]
        public int? ParentID { get; set; }

        [JsonPropertyName("hasChild")]
        public bool HasChild { get; set; }
    }
}

{% endhighlight %}

{% highlight c# tabtitle="GraphQLQuery.cs" %}

using GraphQLServer.Models;

// Defines the GraphQL resolver for handling TreeGrid data requests.
public class GraphQLQuery
{
    // Exposed as 'ordersData' by default
    public OrdersDataResponse OrdersData(DataManagerRequestInput dataManager)
    {
        var all = OrderData.GetAllRecords() ?? new List<OrderData>();

        // Paging
        int skip = dataManager?.Skip ?? 0;
        int take = dataManager?.Take ?? 0;
        bool requiresCounts = dataManager?.RequiresCounts ?? true;

        // Searching only
        var searches = dataManager?.Search ?? new List<SearchFilter>();

        // Params (case-insensitive)
        var p = AsCaseInsensitiveDict(dataManager?.Params);
        int? parentIdParam =
            GetIntN(p, "parentId") ?? GetIntN(p, "ParentId") ?? GetIntN(p, "ParentID") ??
            GetIntN(p, "parentID") ?? GetIntN(p, "parentItem") ?? GetIntN(p, "ParentItem") ??
            GetIntN(p, "expandParentId") ?? GetIntN(p, "ExpandParentId") ?? GetIntN(p, "ExpandParentID");

        // Extract ParentID filters only (for child slice)
        var where = dataManager?.Where ?? new List<WhereFilter>();
        var parentIds = GetParentIdFilters(where);
        if (parentIdParam is int pidFromParams)
            parentIds.Add(pidFromParams);

        // Apply search
        IEnumerable<OrderData> baseQuery = ApplySearch(all, searches);

        // Build group map once for deep traversal
        var groupMap = BuildGroupMap(all);

        if (parentIds.Count > 0)
        {
            // CHILDREN SLICE: return only direct children of the requested parents (no descendants)
            var childrenUnion = new List<OrderData>(128);
            foreach (var pid in parentIds)
                childrenUnion.AddRange(baseQuery.Where(o => o.ParentID == pid));

            // De-duplicate and sort
            childrenUnion = childrenUnion
                .GroupBy(o => o.OrderID)
                .Select(g => g.First())
                .OrderBy(o => o.OrderID)
                .ToList();

            return new OrdersDataResponse
            {
                Count = requiresCounts ? childrenUnion.Count : childrenUnion.Count,
                Result = childrenUnion
            };
        }
        else
        {
            // ROOTS: proper root-level paging (children do not affect paging)
            var rootsAll = baseQuery.Where(o => o.ParentID == null)
                                    .OrderBy(o => o.OrderID)
                                    .ToList();
            var totalRoots = rootsAll.Count;

            // Root window by Skip/Take
            var rootsWindow = rootsAll;
            if (skip > 0) rootsWindow = rootsWindow.Skip(skip).ToList();
            if (take > 0) rootsWindow = rootsWindow.Take(take).ToList();

            // Return only roots; do not auto-expand on initial or after search
            var result = rootsWindow;

            return new OrdersDataResponse
            {
                Count = requiresCounts ? totalRoots : result.Count,
                Result = result
            };
        }
    }

    // Alias to match client query field name 'dataManager'
    [GraphQLName("dataManager")]
    public OrdersDataResponse DataManager(DataManagerRequestInput dataManager) => OrdersData(dataManager);

    // ----------------- Helpers: search only -----------------
    private static IEnumerable<OrderData> ApplySearch(IEnumerable<OrderData> data, List<SearchFilter> searches)
    {
        if (searches == null || searches.Count == 0) return data;

        foreach (var s in searches)
        {
            if (string.IsNullOrWhiteSpace(s?.Key) || s.Fields == null || s.Fields.Count == 0) continue;
            var cmp = s.IgnoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal;
            var key = s.Key;

            data = data.Where(o =>
            {
                foreach (var f in s.Fields)
                {
                    var val = o.GetType().GetProperty(f ?? string.Empty)?.GetValue(o)?.ToString();
                    if (!string.IsNullOrEmpty(val) && val.IndexOf(key, cmp) >= 0) return true;
                }
                return false;
            });
        }
        return data;
    }

    // Build parent -> children map from the entire data set
    private static Dictionary<int, List<OrderData>> BuildGroupMap(IEnumerable<OrderData> all)
    {
        var map = new Dictionary<int, List<OrderData>>();
        foreach (var o in all)
        {
            if (o.ParentID is int pid)
            {
                if (!map.TryGetValue(pid, out var list))
                {
                    list = new List<OrderData>(4);
                    map[pid] = list;
                }
                list.Add(o);
            }
        }
        foreach (var kv in map)
            kv.Value.Sort((a, b) => a.OrderID.CompareTo(b.OrderID));
        return map;
    }

    // Flatten a fixed set of starts; children do not influence paging (roots window already applied)
    private static List<OrderData> FlattenWithDescendants(
        List<OrderData> starts,
        Dictionary<int, List<OrderData>> groupMap)
    {
        var flat = new List<OrderData>(Math.Max(16, starts.Count * 8));
        foreach (var start in starts)
        {
            flat.Add(start);

            if (groupMap.TryGetValue(start.OrderID, out var firstLevel) && firstLevel.Count > 0)
            {
                var stack = new Stack<OrderData>(firstLevel.Count * 4);
                for (int i = firstLevel.Count - 1; i >= 0; i--)
                    stack.Push(firstLevel[i]);

                while (stack.Count > 0)
                {
                    var node = stack.Pop();
                    flat.Add(node);

                    if (groupMap.TryGetValue(node.OrderID, out var kids) && kids.Count > 0)
                    {
                        for (int i = kids.Count - 1; i >= 0; i--)
                            stack.Push(kids[i]);
                    }
                }
            }
        }
        return flat;
    }

    // ----------- Utility: Params parsing and parent-id extraction -----------
    private static Dictionary<string, object> AsCaseInsensitiveDict(object? obj)
    {
        var dict = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
        if (obj is IDictionary<string, object> dso)
        {
            foreach (var kv in dso) dict[kv.Key] = kv.Value!;
        }
        else if (obj is JsonElement je && je.ValueKind == JsonValueKind.Object)
        {
            foreach (var prop in je.EnumerateObject())
                dict[prop.Name] = prop.Value;
        }
        return dict;
    }





    private static int? GetIntN(Dictionary<string, object> p, string key)
    {
        if (!p.TryGetValue(key, out var v) || v is null) return null;
        return ToIntNullable(v);
    }

    private static int? ToIntNullable(object val)
    {
        switch (val)
        {
            case int i: return i;
            case long l: return (int)l;
            case string s when int.TryParse(s, out var si): return si;
            case JsonElement je:
                if (je.ValueKind == JsonValueKind.Number && je.TryGetInt32(out var ni)) return ni;
                if (je.ValueKind == JsonValueKind.String && int.TryParse(je.GetString(), out var ns)) return ns;
                break;
        }
        return null;
    }



    private static HashSet<int> GetParentIdFilters(List<WhereFilter> where)
    {
        var ids = new HashSet<int>();
        if (where == null) return ids;

        static bool IsParentField(string field)
            => field.Equals("ParentID", StringComparison.OrdinalIgnoreCase)
            || field.Equals("ParentId", StringComparison.OrdinalIgnoreCase)
            || field.Equals("parentId", StringComparison.OrdinalIgnoreCase)
            || field.Equals("parentID", StringComparison.OrdinalIgnoreCase)
            || field.Equals("ParentItem", StringComparison.OrdinalIgnoreCase)
            || field.Equals("parentItem", StringComparison.OrdinalIgnoreCase);

        void Walk(IEnumerable<WhereFilter> filters)
        {
            foreach (var f in filters)
            {
                if (f.IsComplex == true && f.Predicates?.Count > 0)
                {
                    Walk(f.Predicates);
                    continue;
                }
                if (!string.IsNullOrWhiteSpace(f.Field) &&
                    IsParentField(f.Field) &&
                    (string.Equals(f.Operator, "equal", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(f.Operator, "==", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(f.Operator, "eq", StringComparison.OrdinalIgnoreCase)))
                {
                    var n = ToIntNullable(f.Value ?? "");
                    if (n.HasValue) ids.Add(n.Value);
                }
            }
        }

        Walk(where);
        return ids;
    }
}

// Defines the response structure with data and count.
public class OrdersDataResponse
{
    public int Count { get; set; }
    public List<OrderData> Result { get; set; } = new List<OrderData>();
}

{% endhighlight %}
{% endtabs %}

## Handling filtering operation

To handle filtering operations in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor TreeGrid using the GraphQLAdaptor, you can make use of the `dataManager.Where` parameters and apply the filter logic on the server side. This enables users to refine the TreeGrid data by specifying one or more filter conditions based on column values.

When a filter is applied in the TreeGrid, the DataManager sends the filtering criteria to the server through the `Where` property. Each filter condition includes the target field, operator, filter value, and other optional settings such as case sensitivity or nested predicates.

On the server, these parameters are parsed and used to filter the data source accordingly before returning the results to the TreeGrid.

![GraphqlAdaptor - Filtering](./images/GraphqlFilter.gif)

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

@page "/"
@rendermode InteractiveServer
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.TreeGrid
@using System.Text.Json.Serialization


<SfTreeGrid TValue="OrderData"
            AllowPaging="true"
            EnableVirtualization=false
            IdMapping="OrderID"
            ParentIdMapping="ParentID"
            HasChildMapping="HasChild"
            TreeColumnIndex="1"
            Height="412"
            AllowFiltering=true
            RowHeight="38">
    <SfDataManager Url="https://localhost:xxxx/graphql"
                   Adaptor="Adaptors.GraphQLAdaptor"
                   GraphQLAdaptorOptions="@adaptorOptions">
    </SfDataManager>
    <TreeGridPageSettings PageSize="3"></TreeGridPageSettings>
    <TreeGridColumns>
        <TreeGridColumn Field="OrderID" HeaderText="Order ID" IsPrimaryKey="true" Width="120" TextAlign="TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="CustomerName" HeaderText="Customer Name" Width="150"></TreeGridColumn>
        <TreeGridColumn Field="ShipCity" HeaderText="Ship City" Width="150"></TreeGridColumn>
        <TreeGridColumn Field="ShipCountry" HeaderText="Ship Country" Width="160"></TreeGridColumn>
    </TreeGridColumns>
</SfTreeGrid>

@code {
    // IMPORTANT:
    // - Replace https://localhost:xxxx/graphql with your actual server port.
    // - The server code already supports TreeGrid lazy loading via Params.parentId when expanding nodes.
    // - ResolverName "ordersData" matches the server query method OrdersData in Models/GraphQLQuery.cs.
    private GraphQLAdaptorOptions adaptorOptions = new GraphQLAdaptorOptions
    {
        Query = @"
        query ordersData($dataManager: DataManagerRequestInput!) {
          ordersData(dataManager: $dataManager) {
            count
            result {
              orderID
              customerName
              shipCity
              shipCountry
              parentID
              hasChild
            }
          }
        }",
        ResolverName = "OrdersData"
    };

    // TreeGrid data model used on the client (camelCase mapping to match server schema)
    public class OrderData
    {
        [JsonPropertyName("orderID")]
        public int OrderID { get; set; }

        [JsonPropertyName("customerName")]
        public string? CustomerName { get; set; }

        [JsonPropertyName("shipCity")]
        public string? ShipCity { get; set; }

        [JsonPropertyName("shipCountry")]
        public string? ShipCountry { get; set; }

        [JsonPropertyName("parentID")]
        public int? ParentID { get; set; }

        [JsonPropertyName("hasChild")]
        public bool HasChild { get; set; }
    }
}

{% endhighlight %}

{% highlight c# tabtitle="GraphQLQuery.cs" %}

using GraphQLServer.Models;

// Defines the GraphQL resolver for handling TreeGrid requests.
public class GraphQLQuery
{ 
    // Exposed as 'ordersData' by default
    public OrdersDataResponse OrdersData(DataManagerRequestInput dataManager)
    {
        var all = OrderData.GetAllRecords() ?? new List<OrderData>();

        // Paging
        int skip = dataManager?.Skip ?? 0;
        int take = dataManager?.Take ?? 0;
        bool requiresCounts = dataManager?.RequiresCounts ?? true;

        // Filters only
        var where = dataManager?.Where ?? new List<WhereFilter>();

        // Params (case-insensitive)
        var p = AsCaseInsensitiveDict(dataManager?.Params);
        int? parentIdParam =
            GetIntN(p, "parentId") ?? GetIntN(p, "ParentId") ?? GetIntN(p, "ParentID") ??
            GetIntN(p, "parentID") ?? GetIntN(p, "parentItem") ?? GetIntN(p, "ParentItem") ??
            GetIntN(p, "expandParentId") ?? GetIntN(p, "ExpandParentId") ?? GetIntN(p, "ExpandParentID");

        // Extract ParentID filters only (for child slice)
        var parentIds = GetParentIdFilters(where);
        if (parentIdParam is int pidFromParams)
            parentIds.Add(pidFromParams);

        // Apply filters to base dataset (excluding ParentID)
        IEnumerable<OrderData> baseQuery = ApplyWhereExcludingParent(all, where);

        if (parentIds.Count > 0)
        {
            // CHILDREN SLICE: return only direct children of the requested parents (no descendants)
            var childrenUnion = new List<OrderData>(128);
            foreach (var pid in parentIds)
                childrenUnion.AddRange(baseQuery.Where(o => o.ParentID == pid));

            // De-duplicate and sort
            childrenUnion = childrenUnion
                .GroupBy(o => o.OrderID)
                .Select(g => g.First())
                .OrderBy(o => o.OrderID)
                .ToList();

            return new OrdersDataResponse
            {
                Count = requiresCounts ? childrenUnion.Count : childrenUnion.Count,
                Result = childrenUnion
            };
        }
        else
        {
            // ROOTS: proper root-level paging (children do not affect paging)
            var rootsAll = baseQuery.Where(o => o.ParentID == null)
                                    .OrderBy(o => o.OrderID)
                                    .ToList();
            var totalRoots = rootsAll.Count;

            // Root window by Skip/Take
            var rootsWindow = rootsAll;
            if (skip > 0) rootsWindow = rootsWindow.Skip(skip).ToList();
            if (take > 0) rootsWindow = rootsWindow.Take(take).ToList();

            // Return only roots; do not auto-expand on initial or after search
            var result = rootsWindow;

            return new OrdersDataResponse
            {
                Count = requiresCounts ? totalRoots : result.Count,
                Result = result
            };
        }
    }

    // Alias to match client query field name 'dataManager'
    [GraphQLName("dataManager")]
    public OrdersDataResponse DataManager(DataManagerRequestInput dataManager) => OrdersData(dataManager);

    // ----------------- Helpers: filtering only -----------------
    // Apply Where but ignore ParentID filters (Already use them to decide slice)
    private static IEnumerable<OrderData> ApplyWhereExcludingParent(IEnumerable<OrderData> data, List<WhereFilter> where)
    {
        if (where == null || where.Count == 0) return data;

        bool Match(OrderData o, WhereFilter f)
        {
            var op = (f.Operator ?? "equal").ToLowerInvariant();
            var val = f.Value?.ToString() ?? string.Empty;
            var ignoreCase = f.IgnoreCase ?? true;
            var cmp = ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal;

            if ((f.Field ?? "").Equals("ParentID", StringComparison.OrdinalIgnoreCase) ||
                (f.Field ?? "").Equals("ParentId", StringComparison.OrdinalIgnoreCase) ||
                (f.Field ?? "").Equals("ParentItem", StringComparison.OrdinalIgnoreCase))
                return true;

            var prop = o.GetType().GetProperty(f.Field ?? string.Empty);
            var left = prop?.GetValue(o)?.ToString() ?? string.Empty;

            return op switch
            {
                "equal" or "==" or "eq" => string.Equals(left, val, cmp),
                "notequal" or "!=" or "ne" => !string.Equals(left, val, cmp),
                "contains" => left.IndexOf(val, cmp) >= 0,
                "startswith" => left.StartsWith(val, cmp),
                "endswith" => left.EndsWith(val, cmp),
                _ => string.Equals(left, val, cmp)
            };
        }

        IEnumerable<OrderData> Apply(IEnumerable<OrderData> src, WhereFilter filter)
        {
            if (filter.IsComplex == true && filter.Predicates?.Count > 0)
            {
                var condition = (filter.Condition ?? "and").ToLowerInvariant();
                if (condition == "or")
                {
                    var set = new HashSet<int>();
                    var bag = new List<OrderData>();
                    foreach (var p in filter.Predicates)
                        foreach (var item in Apply(src, p))
                            if (set.Add(item.OrderID)) bag.Add(item);
                    return bag;
                }
                else
                {
                    var result = src;
                    foreach (var p in filter.Predicates)
                        result = Apply(result, p);
                    return result;
                }
            }
            else
            {
                return src.Where(o => Match(o, filter));
            }
        }

        var resultAll = data;
        foreach (var f in where)
            resultAll = Apply(resultAll, f);

        return resultAll;
    }

    // ----------- Utility: Params parsing and parent-id extraction -----------
    private static Dictionary<string, object> AsCaseInsensitiveDict(object? obj)
    {
        var dict = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
        if (obj is IDictionary<string, object> dso)
        {
            foreach (var kv in dso) dict[kv.Key] = kv.Value!;
        }
        else if (obj is JsonElement je && je.ValueKind == JsonValueKind.Object)
        {
            foreach (var prop in je.EnumerateObject())
                dict[prop.Name] = prop.Value;
        }
        return dict;
    }

    private static int? GetIntN(Dictionary<string, object> p, string key)
    {
        if (!p.TryGetValue(key, out var v) || v is null) return null;
        return ToIntNullable(v);
    }

    private static int? ToIntNullable(object val)
    {
        switch (val)
        {
            case int i: return i;
            case long l: return (int)l;
            case string s when int.TryParse(s, out var si): return si;
            case JsonElement je:
                if (je.ValueKind == JsonValueKind.Number && je.TryGetInt32(out var ni)) return ni;
                if (je.ValueKind == JsonValueKind.String && int.TryParse(je.GetString(), out var ns)) return ns;
                break;
        }
        return null;
    }



    private static HashSet<int> GetParentIdFilters(List<WhereFilter> where)
    {
        var ids = new HashSet<int>();
        if (where == null) return ids;

        static bool IsParentField(string field)
            => field.Equals("ParentID", StringComparison.OrdinalIgnoreCase)
            || field.Equals("ParentId", StringComparison.OrdinalIgnoreCase)
            || field.Equals("parentId", StringComparison.OrdinalIgnoreCase)
            || field.Equals("parentID", StringComparison.OrdinalIgnoreCase)
            || field.Equals("ParentItem", StringComparison.OrdinalIgnoreCase)
            || field.Equals("parentItem", StringComparison.OrdinalIgnoreCase);

        void Walk(IEnumerable<WhereFilter> filters)
        {
            foreach (var f in filters)
            {
                if (f.IsComplex == true && f.Predicates?.Count > 0)
                {
                    Walk(f.Predicates);
                    continue;
                }
                if (!string.IsNullOrWhiteSpace(f.Field) &&
                    IsParentField(f.Field) &&
                    (string.Equals(f.Operator, "equal", StringComparison.OrdinalIgnoreCase) ||
                     string.Equals(f.Operator, "==", StringComparison.OrdinalIgnoreCase) ||
                     string.Equals(f.Operator, "eq", StringComparison.OrdinalIgnoreCase)))
                {
                    var n = ToIntNullable(f.Value ?? "");
                    if (n.HasValue) ids.Add(n.Value);
                }
            }
        }

        Walk(where);
        return ids;
    }
}

// Defines the structure for returning filtered data and total record count.
public class OrdersDataResponse
{
    public int Count { get; set; }
    public List<OrderData> Result { get; set; } = new List<OrderData>();
}

{% endhighlight %}
{% endtabs %}

## Handling sorting operation

To handle sorting operations in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor TreeGrid using the GraphQLAdaptor, the sorting logic can be implemented on the server side by utilizing the `dataManager.Sorted` parameter. This enables the TreeGrid to send sorting instructions to the server, specifying the fields and sort directions to apply.

When a sort action is triggered in the TreeGrid, the DataManager sends the sorting configuration in the `Sorted` property. This includes the field name to sort and the direction (Ascending or Descending). The server processes this parameter and sorts the data accordingly before returning it to the TreeGrid.

![GraphqlAdaptor - Sorting](./images/GraphqlSorting.gif)

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

@page "/"
@rendermode InteractiveServer
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.TreeGrid
@using System.Text.Json.Serialization


<SfTreeGrid TValue="OrderData"
            AllowPaging="true"
            EnableVirtualization=false
            IdMapping="OrderID"
            ParentIdMapping="ParentID"
            HasChildMapping="HasChild"
            TreeColumnIndex="1"
            Height="412"
            AllowSorting=true
            RowHeight="38">
    <SfDataManager Url="https://localhost:7213/graphql"
                   Adaptor="Adaptors.GraphQLAdaptor"
                   GraphQLAdaptorOptions="@adaptorOptions">
    </SfDataManager>
    <TreeGridPageSettings PageSize="3"></TreeGridPageSettings>
    <TreeGridColumns>
        <TreeGridColumn Field="OrderID" HeaderText="Order ID" IsPrimaryKey="true" Width="120" TextAlign="TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="CustomerName" HeaderText="Customer Name" Width="150"></TreeGridColumn>
        <TreeGridColumn Field="ShipCity" HeaderText="Ship City" Width="150"></TreeGridColumn>
        <TreeGridColumn Field="ShipCountry" HeaderText="Ship Country" Width="160"></TreeGridColumn>
    </TreeGridColumns>
</SfTreeGrid>

@code {
    // IMPORTANT:
    // - Replace https://localhost:xxxx/graphql with your actual server port.
    // - The server code already supports TreeGrid lazy loading via Params.parentId when expanding nodes.
    // - ResolverName "ordersData" matches the server query method OrdersData in Models/GraphQLQuery.cs.
    private GraphQLAdaptorOptions adaptorOptions = new GraphQLAdaptorOptions
    {
        Query = @"
        query ordersData($dataManager: DataManagerRequestInput!) {
          ordersData(dataManager: $dataManager) {
            count
            result {
              orderID
              customerName
              shipCity
              shipCountry
              parentID
              hasChild
            }
          }
        }",
        ResolverName = "OrdersData"
    };

    // TreeGrid data model used on the client (camelCase mapping to match server schema)
    public class OrderData
    {
        [JsonPropertyName("orderID")]
        public int OrderID { get; set; }

        [JsonPropertyName("customerName")]
        public string? CustomerName { get; set; }

        [JsonPropertyName("shipCity")]
        public string? ShipCity { get; set; }

        [JsonPropertyName("shipCountry")]
        public string? ShipCountry { get; set; }

        [JsonPropertyName("parentID")]
        public int? ParentID { get; set; }

        [JsonPropertyName("hasChild")]
        public bool HasChild { get; set; }
    }
}
{% endhighlight %}

{% highlight c# tabtitle="GraphQLQuery.cs" %}

using GraphQLServer.Models;

// Defines the GraphQL resolver for handling TreeGrid requests.
public class GraphQLQuery
{
    
    // Exposed as 'ordersData' by default
    public OrdersDataResponse OrdersData(DataManagerRequestInput dataManager)
    {
        var all = OrderData.GetAllRecords() ?? new List<OrderData>();

        // Paging
        int skip = dataManager?.Skip ?? 0;
        int take = dataManager?.Take ?? 0;
        bool requiresCounts = dataManager?.RequiresCounts ?? true;

        // Sorting only
        var sorted = dataManager?.Sorted ?? new List<Sort>();
        // We still read where for ParentID to fetch children slices when a row is expanded
        var where = dataManager?.Where ?? new List<WhereFilter>();

        // Params (case-insensitive)
        var p = AsCaseInsensitiveDict(dataManager?.Params);
        int? parentIdParam =
            GetIntN(p, "parentId") ?? GetIntN(p, "ParentId") ?? GetIntN(p, "ParentID") ??
            GetIntN(p, "parentID") ?? GetIntN(p, "parentItem") ?? GetIntN(p, "ParentItem") ??
            GetIntN(p, "expandParentId") ?? GetIntN(p, "ExpandParentId") ?? GetIntN(p, "ExpandParentID");

        // Extract ParentID filters only (for child slice)
        var parentIds = GetParentIdFilters(where);
        if (parentIdParam is int pidFromParams)
            parentIds.Add(pidFromParams);

        // No general filtering; base dataset remains intact
        IEnumerable<OrderData> baseQuery = all;

        if (parentIds.Count > 0)
        {
            // CHILDREN SLICE: return only direct children of the requested parents (no descendants)
            var childrenUnion = new List<OrderData>(128);
            foreach (var pid in parentIds)
                childrenUnion.AddRange(baseQuery.Where(o => o.ParentID == pid));

            // De-duplicate and sort
            childrenUnion = childrenUnion
                .GroupBy(o => o.OrderID)
                .Select(g => g.First())
                .ToList();

            childrenUnion = ApplySorting(childrenUnion, sorted).ToList();

            return new OrdersDataResponse
            {
                Count = requiresCounts ? childrenUnion.Count : childrenUnion.Count,
                Result = childrenUnion
            };
        }
        else
        {
            // ROOTS: proper root-level paging (children do not affect paging)
            var rootsAll = ApplySorting(baseQuery.Where(o => o.ParentID == null), sorted).ToList();
            var totalRoots = rootsAll.Count;

            // Root window by Skip/Take
            var rootsWindow = rootsAll;
            if (skip > 0) rootsWindow = rootsWindow.Skip(skip).ToList();
            if (take > 0) rootsWindow = rootsWindow.Take(take).ToList();

            // Return only roots; do not auto-expand on initial or after search
            var result = rootsWindow;

            return new OrdersDataResponse
            {
                Count = requiresCounts ? totalRoots : result.Count,
                Result = result
            };
        }
    }

    // Alias to match client query field name 'dataManager'
    [GraphQLName("dataManager")]
    public OrdersDataResponse DataManager(DataManagerRequestInput dataManager) => OrdersData(dataManager);

    // ----------------- Helpers: sorting only -----------------
    private static IEnumerable<OrderData> ApplySorting(IEnumerable<OrderData> data, List<Sort> sorted)
    {
        if (sorted == null || sorted.Count == 0)
            return data.OrderBy(o => o.OrderID);

        IOrderedEnumerable<OrderData>? ordered = null;
        foreach (var s in sorted)
        {
            var name = s?.Name ?? string.Empty;
            var desc = (s?.Direction ?? "ascending").Equals("descending", StringComparison.OrdinalIgnoreCase);
            Func<OrderData, object?> keySelector = o => o.GetType().GetProperty(name)?.GetValue(o);

            if (ordered == null)
            {
                ordered = desc ? data.OrderByDescending(keySelector).ThenBy(o => o.OrderID)
                               : data.OrderBy(keySelector).ThenBy(o => o.OrderID);
            }
            else
            {
                ordered = desc ? ordered.ThenByDescending(keySelector).ThenBy(o => o.OrderID)
                               : ordered.ThenBy(keySelector).ThenBy(o => o.OrderID);
            }
        }
        return ordered ?? data.OrderBy(o => o.OrderID);
    }

    // ----------- Utility: Params parsing and parent-id extraction -----------
    private static Dictionary<string, object> AsCaseInsensitiveDict(object? obj)
    {
        var dict = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
        if (obj is IDictionary<string, object> dso)
        {
            foreach (var kv in dso) dict[kv.Key] = kv.Value!;
        }
        else if (obj is JsonElement je && je.ValueKind == JsonValueKind.Object)
        {
            foreach (var prop in je.EnumerateObject())
                dict[prop.Name] = prop.Value;
        }
        return dict;
    }

    private static int? GetIntN(Dictionary<string, object> p, string key)
    {
        if (!p.TryGetValue(key, out var v) || v is null) return null;
        return ToIntNullable(v);
    }

    private static int? ToIntNullable(object val)
    {
        switch (val)
        {
            case int i: return i;
            case long l: return (int)l;
            case string s when int.TryParse(s, out var si): return si;
            case JsonElement je:
                if (je.ValueKind == JsonValueKind.Number && je.TryGetInt32(out var ni)) return ni;
                if (je.ValueKind == JsonValueKind.String && int.TryParse(je.GetString(), out var ns)) return ns;
                break;
        }
        return null;
    }



    private static HashSet<int> GetParentIdFilters(List<WhereFilter> where)
    {
        var ids = new HashSet<int>();
        if (where == null) return ids;

        static bool IsParentField(string field)
            => field.Equals("ParentID", StringComparison.OrdinalIgnoreCase)
            || field.Equals("ParentId", StringComparison.OrdinalIgnoreCase)
            || field.Equals("parentId", StringComparison.OrdinalIgnoreCase)
            || field.Equals("parentID", StringComparison.OrdinalIgnoreCase)
            || field.Equals("ParentItem", StringComparison.OrdinalIgnoreCase)
            || field.Equals("parentItem", StringComparison.OrdinalIgnoreCase);

        void Walk(IEnumerable<WhereFilter> filters)
        {
            foreach (var f in filters)
            {
                if (f.IsComplex == true && f.Predicates?.Count > 0)
                {
                    Walk(f.Predicates);
                    continue;
                }
                if (!string.IsNullOrWhiteSpace(f.Field) &&
                    IsParentField(f.Field) &&
                    (string.Equals(f.Operator, "equal", StringComparison.OrdinalIgnoreCase) ||
                     string.Equals(f.Operator, "==", StringComparison.OrdinalIgnoreCase) ||
                     string.Equals(f.Operator, "eq", StringComparison.OrdinalIgnoreCase)))
                {
                    var n = ToIntNullable(f.Value ?? "");
                    if (n.HasValue) ids.Add(n.Value);
                }
            }
        }

        Walk(where);
        return ids;
    }
}

// Defines the structure for returning processed data and its total count.
public class OrdersDataResponse
{
    public int Count { get; set; }
    public List<OrderData> Result { get; set; } = new List<OrderData>();
}

{% endhighlight %}
{% endtabs %}

## Handling paging operation

To handle paging operations in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor TreeGrid using the GraphQLAdaptor, you can make use of the `dataManager.Skip` and `dataManager.Take` parameters. These parameters allow you to retrieve data in pages, helping to manage large datasets efficiently by loading only a subset of records at a time.

When paging is applied, the DataManager sends the **Skip** and **Take** values to the server. The **Skip** parameter specifies the number of records to be skipped, while the **Take** parameter defines how many records to retrieve in the current page.

On the server side, the data is sliced based on the **Skip** and **Take** values, and the total record count is returned to enable proper pagination in the TreeGrid.

![GraphQLAdaptor - Paging](./images/GraphQlRender.gif)

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

@page "/"

@rendermode InteractiveServer
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.TreeGrid
@using System.Text.Json.Serialization


<SfTreeGrid TValue="OrderData"
            AllowPaging="true"
            EnableVirtualization=false
            IdMapping="OrderID"
            ParentIdMapping="ParentID"
            HasChildMapping="HasChild"
            TreeColumnIndex="1"
            Height="412"
            RowHeight="38">
    <SfDataManager Url="https://localhost:7213/graphql"
                   Adaptor="Adaptors.GraphQLAdaptor"
                   GraphQLAdaptorOptions="@adaptorOptions">
    </SfDataManager>
    <TreeGridPageSettings PageSize="3"></TreeGridPageSettings>
    <TreeGridColumns>
        <TreeGridColumn Field="OrderID" HeaderText="Order ID" IsPrimaryKey="true" Width="120" TextAlign="TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="CustomerName" HeaderText="Customer Name" Width="150"></TreeGridColumn>
        <TreeGridColumn Field="ShipCity" HeaderText="Ship City" Width="150"></TreeGridColumn>
        <TreeGridColumn Field="ShipCountry" HeaderText="Ship Country" Width="160"></TreeGridColumn>
    </TreeGridColumns>
</SfTreeGrid>

@code {
    // IMPORTANT:
    // - Replace https://localhost:xxxx/graphql with your actual server port.
    // - The server code already supports TreeGrid lazy loading via Params.parentId when expanding nodes.
    // - ResolverName "ordersData" matches the server query method OrdersData in Models/GraphQLQuery.cs.
    private GraphQLAdaptorOptions adaptorOptions = new GraphQLAdaptorOptions
    {
        Query = @"
        query ordersData($dataManager: DataManagerRequestInput!) {
        ordersData(dataManager: $dataManager) {
            count
            result {
            orderID
            customerName
            shipCity
            shipCountry
            parentID
            hasChild
            }
        }
        }",
        ResolverName = "OrdersData"
    };

    // TreeGrid data model used on the client (camelCase mapping to match server schema)
    public class OrderData
    {
        [JsonPropertyName("orderID")]
        public int OrderID { get; set; }

        [JsonPropertyName("customerName")]
        public string? CustomerName { get; set; }

        [JsonPropertyName("shipCity")]
        public string? ShipCity { get; set; }

        [JsonPropertyName("shipCountry")]
        public string? ShipCountry { get; set; }

        [JsonPropertyName("parentID")]
        public int? ParentID { get; set; }

        [JsonPropertyName("hasChild")]
        public bool HasChild { get; set; }
    }
}


{% endhighlight %}

{% highlight c# tabtitle="GraphQLQuery.cs" %}

using GraphQLServer.Models;

// Defines the GraphQL resolver for handling TreeGrid requests.
public class GraphQLQuery
{
    // Exposed as 'ordersData' by default
    public OrdersDataResponse OrdersData(DataManagerRequestInput dataManager)
    {
        var all = OrderData.GetAllRecords() ?? new List<OrderData>();

        // Pagination only
        int skip = dataManager?.Skip ?? 0;
        int take = dataManager?.Take ?? 0;
        bool requiresCounts = dataManager?.RequiresCounts ?? true;

        // Params (case-insensitive)
        var p = AsCaseInsensitiveDict(dataManager?.Params);
        int? parentIdParam =
            GetIntN(p, "parentId") ??
            GetIntN(p, "ParentId") ??
            GetIntN(p, "ParentID") ??
            GetIntN(p, "parentID") ??
            GetIntN(p, "parentItem") ??
            GetIntN(p, "ParentItem");
        // Also honor expandParentId param sent by UI when expanding rows
        int? expandParentIdParam =
            GetIntN(p, "expandParentId") ?? GetIntN(p, "ExpandParentId") ?? GetIntN(p, "ExpandParentID");
        // Fallback: attempt to infer parent id from common keys if not provided explicitly
        int? inferredParentId = InferParentId(p);

        // Extract ParentID filters only (for child slice)
        var where = dataManager?.Where ?? new List<WhereFilter>();
        var parentIds = GetParentIdFilters(where);
        if (parentIdParam is int pidFromParams)
            parentIds.Add(pidFromParams);
        if (expandParentIdParam is int epid)
            parentIds.Add(epid);
        if (inferredParentId is int ipid)
            parentIds.Add(ipid);

        // Build group map once for deep traversal (used only when loadChildOnDemand is true)
        var groupMap = BuildGroupMap(all);

        if (parentIds.Count > 0)
        {
            // CHILDREN SLICE: return only direct children of the requested parents (no descendants)
            var childrenUnion = new List<OrderData>(128);
            foreach (var pid in parentIds)
                childrenUnion.AddRange(all.Where(o => o.ParentID == pid));

            // De-duplicate and sort
            childrenUnion = childrenUnion
                .GroupBy(o => o.OrderID)
                .Select(g => g.First())
                .OrderBy(o => o.OrderID)
                .ToList();

            // IMPORTANT: Do NOT apply root-level paging to children slice
            var total = childrenUnion.Count;

            return new OrdersDataResponse
            {
                Count = requiresCounts ? total : childrenUnion.Count,
                Result = childrenUnion
            };
        }
        else
        {
            // ROOTS: proper root-level paging (children do not affect paging)
            var rootsAll = all.Where(o => o.ParentID == null)
                            .OrderBy(o => o.OrderID)
                            .ToList();
            var totalRoots = rootsAll.Count;

            // Root window by Skip/Take
            var rootsWindow = rootsAll;
            if (skip > 0) rootsWindow = rootsWindow.Skip(skip).ToList();
            if (take > 0) rootsWindow = rootsWindow.Take(take).ToList();

            // Always return roots with all descendants (expanded view)
            List<OrderData> result = FlattenWithDescendants(rootsWindow, groupMap);

            return new OrdersDataResponse
            {
                Count = requiresCounts ? totalRoots : result.Count,
                Result = result
            };
        }
    }

    // Alias to match client query field name 'dataManager'
    [GraphQLName("dataManager")]
    public OrdersDataResponse DataManager(DataManagerRequestInput dataManager) => OrdersData(dataManager);

    // Build parent -> children map from the entire data set
    private static Dictionary<int, List<OrderData>> BuildGroupMap(IEnumerable<OrderData> all)
    {
        var map = new Dictionary<int, List<OrderData>>();
        foreach (var o in all)
        {
            if (o.ParentID is int pid)
            {
                if (!map.TryGetValue(pid, out var list))
                {
                    list = new List<OrderData>(4);
                    map[pid] = list;
                }
                list.Add(o);
            }
        }
        foreach (var kv in map)
            kv.Value.Sort((a, b) => a.OrderID.CompareTo(b.OrderID));
        return map;
    }

    // Flatten a fixed set of starts; children do not influence paging (roots window already applied)
    private static List<OrderData> FlattenWithDescendants(
        List<OrderData> starts,
        Dictionary<int, List<OrderData>> groupMap)
    {
        var flat = new List<OrderData>(Math.Max(16, starts.Count * 8));
        foreach (var start in starts)
        {
            flat.Add(start);

            if (groupMap.TryGetValue(start.OrderID, out var firstLevel) && firstLevel.Count > 0)
            {
                var stack = new Stack<OrderData>(firstLevel.Count * 4);
                for (int i = firstLevel.Count - 1; i >= 0; i--)
                    stack.Push(firstLevel[i]);

                while (stack.Count > 0)
                {
                    var node = stack.Pop();
                    flat.Add(node);

                    if (groupMap.TryGetValue(node.OrderID, out var kids) && kids.Count > 0)
                    {
                        for (int i = kids.Count - 1; i >= 0; i--)
                            stack.Push(kids[i]);
                    }
                }
            }
        }
        return flat;
    }

    // ----------- Utility: Params parsing and parent-id extraction -----------
    private static int? InferParentId(Dictionary<string, object> p)
    {
        // Common client keys that may carry the expanded row id
        string[] keys = new[] { "key", "id", "rowId", "RowId", "RowID", "primaryKey", "PrimaryKey" };
        foreach (var k in keys)
        {
            var n = GetIntN(p, k);
            if (n.HasValue) return n.Value;
        }
        // Any key containing 'parent' and 'id'
        foreach (var kv in p)
        {
            var name = kv.Key ?? string.Empty;
            if (name.IndexOf("parent", StringComparison.OrdinalIgnoreCase) >= 0 &&
                name.IndexOf("id", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                var n = GetIntN(p, name);
                if (n.HasValue) return n.Value;
            }
        }
        return null;
    }

    private static Dictionary<string, object> AsCaseInsensitiveDict(object? obj)
    {
        var dict = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
        if (obj is IDictionary<string, object> dso)
        {
            foreach (var kv in dso) dict[kv.Key] = kv.Value!;
        }
        else if (obj is JsonElement je && je.ValueKind == JsonValueKind.Object)
        {
            foreach (var prop in je.EnumerateObject())
                dict[prop.Name] = prop.Value;
        }
        return dict;
    }

    private static int? GetIntN(Dictionary<string, object> p, string key)
    {
        if (!p.TryGetValue(key, out var v) || v is null) return null;
        return ToIntNullable(v);
    }

    private static int? ToIntNullable(object val)
    {
        switch (val)
        {
            case int i: return i;
            case long l: return (int)l;
            case string s when int.TryParse(s, out var si): return si;
            case JsonElement je:
                if (je.ValueKind == JsonValueKind.Number && je.TryGetInt32(out var ni)) return ni;
                if (je.ValueKind == JsonValueKind.String && int.TryParse(je.GetString(), out var ns)) return ns;
                break;
        }
        return null;
    }

    private static HashSet<int> GetParentIdFilters(List<WhereFilter> where)
    {
        var ids = new HashSet<int>();
        if (where == null) return ids;

        static bool IsParentField(string field)
            => field.Equals("ParentID", StringComparison.OrdinalIgnoreCase)
            || field.Equals("ParentId", StringComparison.OrdinalIgnoreCase)
            || field.Equals("parentId", StringComparison.OrdinalIgnoreCase)
            || field.Equals("parentID", StringComparison.OrdinalIgnoreCase)
            || field.Equals("ParentItem", StringComparison.OrdinalIgnoreCase)
            || field.Equals("parentItem", StringComparison.OrdinalIgnoreCase);

        void Walk(IEnumerable<WhereFilter> filters)
        {
            foreach (var f in filters)
            {
                if (f.IsComplex == true && f.Predicates?.Count > 0)
                {
                    Walk(f.Predicates);
                    continue;
                }
                if (!string.IsNullOrWhiteSpace(f.Field) &&
                    IsParentField(f.Field) &&
                    (string.Equals(f.Operator, "equal", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(f.Operator, "==", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(f.Operator, "eq", StringComparison.OrdinalIgnoreCase)))
                {
                    var n = ToIntNullable(f.Value ?? "");
                    if (n.HasValue) ids.Add(n.Value);
                }
            }
        }

        Walk(where);
        return ids;
    }
}

// Defines the structure for returning processed data and its total count.
public class OrdersDataResponse
{
    public int Count { get; set; }
    public List<OrderData> Result { get; set; } = new List<OrderData>();
}

{% endhighlight %}
{% endtabs %}

## Handling CRUD operation using mutation

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor TreeGrid integrates seamlessly with GraphQL APIs using the GraphQLAdaptor, enabling support for CRUD (Create, Read, Update, and Delete) and Batch operations. This adaptor maps TreeGrid actions to GraphQL queries and mutations for real-time data interaction.

This section demonstrates how to configure the TreeGrid with actual code to bind data and perform CRUD actions using the GraphQLAdaptor.

**Set Up Mutation Queries**

Define GraphQL mutation queries for Insert, Update, Delete, and Batch operations in the [GraphQLAdaptorOptions.Mutation](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.GraphQLAdaptorOptions.html#Syncfusion_Blazor_Data_GraphQLAdaptorOptions_Mutation) property. Below are the required queries for each operation:

* **Insert Mutation:** A GraphQL mutation that allows adding new records.

* **Update Mutation:** A GraphQL mutation for updating existing records.

* **Delete Mutation:** A GraphQL mutation that removes records.

**Configuration in GraphQL server application**

The following code is the configuration in GraphQL server application to set GraphQL query and mutation type and to enable CORS.

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

The following steps outline how to set up these operations in the TreeGrid.

**1. Insert Operation:**

To insert a new record into the GraphQL server, define the mutation query in the [Insert](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.GraphQLMutation.html#Syncfusion_Blazor_Data_GraphQLMutation_Insert) property of the [Mutation](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.GraphQLAdaptorOptions.html#Syncfusion_Blazor_Data_GraphQLAdaptorOptions_Mutation) object within [GraphQLAdaptorOptions](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.GraphQLAdaptorOptions.html).

This mutation query is executed when a new row is added to the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid. The adaptor sends the necessary parameters to the GraphQL server to perform the insertion.

**Mutation query configuration**

The `Insert` mutation should be configured as shown below:

```cs
Mutation = new GraphQLMutation
{
    Insert = @"
    mutation create($record: OrderDataInput!, $index: Int!, $action: String!, $additionalParameters: Any) {
    createOrder(record: $record, index: $index, action: $action, additionalParameters: $additionalParameters) {
            orderID
            customerName
            shipCity
            shipCountry
            parentID
            hasChild
        }
    }",
},
```

**Parameters Sent to the Server**

The following variables are passed as a parameter to the mutation method written for **Insert** operation in server side.

| Properties | Description |
|--------|----------------|
| record | The new record which is need to be inserted. |
| index | Specifies the index at which the newly added record will be inserted.  |
| action | Indicates the type of operation being performed. When the same method is used for all CRUD actions, this argument serves to distinguish the action, such as **Add, Delete and Update**  |
| additionalParameters | An optional parameter that can be used to perform any operations.   |

**Server-Side Mutation Implementation**

The following example demonstrates how to implement the insert logic on the GraphQL server using C# with HotChocolate:

```cs

using GraphQLServer.Models;

namespace GraphQLServer.GraphQL
{
    public class GraphQLMutation
    {
        public OrderData CreateOrder(
            OrderData record,
            int index,
            string action,
            [GraphQLType(typeof(AnyType))] IDictionary<string, object> additionalParameters)
            {
                var orders = OrderData.GetAllRecords();

                var entity = new OrderData
                {
                    OrderID = record.OrderID,
                    CustomerName = record.CustomerName,
                    ShipCity = record.ShipCity,
                    ShipCountry = record.ShipCountry,
                    ParentID = record.ParentID,
                    HasChild = record.HasChild
                };

                if (entity.ParentID.HasValue)
                {
                    var parent = orders.FirstOrDefault(o => o.OrderID == entity.ParentID.Value);
                    if (parent != null) parent.HasChild = true;
                }

                if (index >= 0 && index <= orders.Count)
                    orders.Insert(index, entity);
                else
                    orders.Add(entity);

                return entity;
            }
    }
}

```

**2. Update Operation:**

To update an existing record on the GraphQL server, define the mutation query in the [Update](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.GraphQLMutation.html#Syncfusion_Blazor_Data_GraphQLMutation_Update) property of the [Mutation](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.GraphQLAdaptorOptions.html#Syncfusion_Blazor_Data_GraphQLAdaptorOptions_Mutation) object within [GraphQLAdaptorOptions](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.GraphQLAdaptorOptions.html).

This mutation query is triggered when an existing row in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid is modified. The adaptor sends the updated data and relevant parameters to the GraphQL server for processing.

**Mutation query configuration**

The Update mutation should be configured as shown below:

```cs
Mutation = new GraphQLMutation
{
    Update = @"
        mutation update($record: OrderDataInput!, $action: String!, $primaryColumnName: String!, $primaryColumnValue: Int!, $additionalParameters: Any) {
        updateOrder(record: $record, action: $action, primaryColumnName: $primaryColumnName, primaryColumnValue: $primaryColumnValue, additionalParameters: $additionalParameters) {
            orderID
            customerName
            shipCity
            shipCountry
            parentID
            hasChild
        }
    }",
},
```

**Parameters Sent to the Server**

The following variables are passed as a parameter to the mutation method written for **Update** operation in server side.

| Properties | Description |
|--------|----------------|
| record | The new record which is need to be updated. |
| action | Indicates the type of operation being performed. When the same method is used for all CRUD actions, this argument serves to distinguish the action, such as **Add, Delete and Update**  |
| primaryColumnName | Specifies the field name of the primary column. |
| primaryColumnValue | Specifies the primary column value which is needs to be updated in the collection.   |
| additionalParameters | An optional parameter that can be used to perform any operations.   |

**Server-Side Mutation Implementation**

The following example demonstrates how to implement the update logic on the GraphQL server using C# with HotChocolate:

```cs
using GraphQLServer.Models;

namespace GraphQLServer.GraphQL
{
    public class GraphQLMutation
    {
        public OrderData? UpdateOrder(
            OrderData record,
            string action,
            string primaryColumnName,
            int primaryColumnValue,
            [GraphQLType(typeof(AnyType))] IDictionary<string, object> additionalParameters)
            {
                var orders = OrderData.GetAllRecords();

                var existing = primaryColumnName?.ToLowerInvariant() switch
                {
                    "orderid" => orders.FirstOrDefault(x => x.OrderID == primaryColumnValue),
                    _ => orders.FirstOrDefault(x => x.OrderID == primaryColumnValue)
                };
                if (existing == null) return null;

                if (record.CustomerName != null) existing.CustomerName = record.CustomerName;
                if (record.ShipCity != null) existing.ShipCity = record.ShipCity;
                if (record.ShipCountry != null) existing.ShipCountry = record.ShipCountry;

                if (record.ParentID.HasValue && record.ParentID.Value != existing.ParentID)
                {
                    var oldParentId = existing.ParentID;
                    existing.ParentID = record.ParentID;

                    if (existing.ParentID.HasValue)
                    {
                        var newParent = orders.FirstOrDefault(o => o.OrderID == existing.ParentID.Value);
                        if (newParent != null) newParent.HasChild = true;
                    }

                    if (oldParentId.HasValue)
                    {
                        var oldParent = orders.FirstOrDefault(o => o.OrderID == oldParentId.Value);
                        if (oldParent != null)
                        {
                            oldParent.HasChild = orders.Any(o => o.ParentID == oldParent.OrderID);
                        }
                    }
                }

                if (record.HasChild) existing.HasChild = record.HasChild;

                return existing;
            }
    }
}

```

**3. Delete Operation:**

To delete an existing record from the GraphQL server, define the mutation query in the [Delete](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.GraphQLMutation.html#Syncfusion_Blazor_Data_GraphQLMutation_Delete) property of the [Mutation](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.GraphQLAdaptorOptions.html#Syncfusion_Blazor_Data_GraphQLAdaptorOptions_Mutation) object within [GraphQLAdaptorOptions](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.GraphQLAdaptorOptions.html).

This mutation query is executed when a row is removed from the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor TreeGrid. The adaptor passes the required parameters to the GraphQL server to process the deletion.

**Mutation query configuration**

The Delete mutation should be configured as shown below:

```cs
Mutation = new GraphQLMutation
{
    Delete = @"
        mutation delete($primaryColumnValue: Int!, $action: String!, $primaryColumnName: String!, $additionalParameters: Any) {
        deleteOrder(primaryColumnValue: $primaryColumnValue, action: $action, primaryColumnName: $primaryColumnName, additionalParameters: $additionalParameters) {
            orderID
            customerName
            shipCity
            shipCountry
            parentID
            hasChild
        }
    }",
},
```

**Parameters Sent to the Server**

The following variables are passed as a parameter to the mutation method written for **Delete** operation in server side.

| Properties | Description |
|--------|----------------|
| primaryColumnValue | Specifies the primary column value which is needs to be removed from the collection. |
| action | Indicates the type of operation being performed. When the same method is used for all CRUD actions, this argument serves to distinguish the action, such as **Add, Delete and Update**  |
| primaryColumnName | specifies the field name of the primary column.  |
| additionalParameters | An optional parameter that can be used to perform any operations.   |

**Server-Side Mutation Implementation**

The following example demonstrates how to implement the delete logic on the GraphQL server using C# with HotChocolate:

```cs
using GraphQLServer.Models;

namespace GraphQLServer.GraphQL
{
    public class GraphQLMutation
    {
        public OrderData? DeleteOrder(
        int primaryColumnValue,
        string action,
        string primaryColumnName,
        [GraphQLType(typeof(AnyType))] IDictionary<string, object> additionalParameters)
        {
            var orders = OrderData.GetAllRecords();

            var toDelete = primaryColumnName?.ToLowerInvariant() switch
            {
                "orderid" => orders.FirstOrDefault(x => x.OrderID == primaryColumnValue),
                _ => orders.FirstOrDefault(x => x.OrderID == primaryColumnValue)
            };
            if (toDelete == null) return null;

            var idsToRemove = new HashSet<int>();
            CollectWithDescendants(orders, toDelete.OrderID, idsToRemove);

            orders.RemoveAll(o => idsToRemove.Contains(o.OrderID));

            if (toDelete.ParentID.HasValue)
            {
                var parent = orders.FirstOrDefault(o => o.OrderID == toDelete.ParentID.Value);
                if (parent != null)
                {
                    parent.HasChild = orders.Any(o => o.ParentID == parent.OrderID);
                }
            }

            return toDelete;
        }
    }
}

```

The following code shows how to bind the TreeGrid with a GraphQL service and enable CRUD operations.

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

@page "/"
@rendermode InteractiveServer
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.TreeGrid
@using System.Text.Json.Serialization


<SfTreeGrid TValue="OrderData"
            AllowPaging="true"
            EnableVirtualization=false
            IdMapping="OrderID"
            ParentIdMapping="ParentID"
            HasChildMapping="HasChild"
            TreeColumnIndex="1"
            Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Update", "Search", "Cancel" })" 
            AllowFiltering="true"
            AllowSorting="true"
            Height="412"
            RowHeight="38">
    <SfDataManager Url="https://localhost:7213/graphql"
                   Adaptor="Adaptors.GraphQLAdaptor"
                   GraphQLAdaptorOptions="@adaptorOptions">
    </SfDataManager>
    <TreeGridPageSettings PageSize="3"></TreeGridPageSettings>
    <TreeGridEditSettings AllowEditing="true" AllowDeleting="true" AllowAdding="true" Mode="Syncfusion.Blazor.TreeGrid.EditMode.Cell"></TreeGridEditSettings>
    <TreeGridColumns>
        <TreeGridColumn Field="OrderID" HeaderText="Order ID" IsPrimaryKey="true" Width="120" TextAlign="TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="CustomerName" HeaderText="Customer Name" Width="150"></TreeGridColumn>
        <TreeGridColumn Field="ShipCity" HeaderText="Ship City" Width="150"></TreeGridColumn>
        <TreeGridColumn Field="ShipCountry" HeaderText="Ship Country" Width="160"></TreeGridColumn>
    </TreeGridColumns>
</SfTreeGrid>

@code {
    // IMPORTANT:
    // - Replace https://localhost:xxxx/graphql with your actual server port.
    // - The server code already supports TreeGrid lazy loading via Params.parentId when expanding nodes.
    // - ResolverName "ordersData" matches the server query method OrdersData in Models/GraphQLQuery.cs.
    private GraphQLAdaptorOptions adaptorOptions = new GraphQLAdaptorOptions
    {
        Query = @"
        query ordersData($dataManager: DataManagerRequestInput!) {
          ordersData(dataManager: $dataManager) {
            count
            result {
              orderID
              customerName
              shipCity
              shipCountry
              parentID
              hasChild
            }
          }
        }",
        Mutation = new Syncfusion.Blazor.Data.GraphQLMutation
        {
            Insert = @"
            mutation create($record: OrderDataInput!, $index: Int!, $action: String!, $additionalParameters: Any) {
              createOrder(record: $record, index: $index, action: $action, additionalParameters: $additionalParameters) {
                orderID
                customerName
                shipCity
                shipCountry
                parentID
                hasChild
              }
            }",
            Update = @"
            mutation update($record: OrderDataInput!, $action: String!, $primaryColumnName: String!, $primaryColumnValue: Int!, $additionalParameters: Any) {
              updateOrder(record: $record, action: $action, primaryColumnName: $primaryColumnName, primaryColumnValue: $primaryColumnValue, additionalParameters: $additionalParameters) {
                orderID
                customerName
                shipCity
                shipCountry
                parentID
                hasChild
              }
            }",
            Delete = @"
            mutation delete($primaryColumnValue: Int!, $action: String!, $primaryColumnName: String!, $additionalParameters: Any) {
              deleteOrder(primaryColumnValue: $primaryColumnValue, action: $action, primaryColumnName: $primaryColumnName, additionalParameters: $additionalParameters) {
                orderID
                customerName
                shipCity
                shipCountry
                parentID
                hasChild
              }
            }"
        },
        ResolverName = "OrdersData"
    };

    // TreeGrid data model used on the client (camelCase mapping to match server schema)
    public class OrderData
    {
        [JsonPropertyName("orderID")]
        public int OrderID { get; set; }

        [JsonPropertyName("customerName")]
        public string? CustomerName { get; set; }

        [JsonPropertyName("shipCity")]
        public string? ShipCity { get; set; }

        [JsonPropertyName("shipCountry")]
        public string? ShipCountry { get; set; }

        [JsonPropertyName("parentID")]
        public int? ParentID { get; set; }

        [JsonPropertyName("hasChild")]
        public bool HasChild { get; set; }
    }
}

{% endhighlight %}

{% highlight c# tabtitle="GraphQLMutation.cs" %}

using GraphQLServer.Models;
using System.Collections.Generic;
using System.Linq;
using HotChocolate;

namespace GraphQLServer.GraphQL
{
    public class GraphQLMutation
    {
         public OrderData CreateOrder(
            OrderData record,
            int index,
            string action,
            [GraphQLType(typeof(AnyType))] IDictionary<string, object> additionalParameters)
        {
            var orders = OrderData.GetAllRecords();

            var entity = new OrderData
            {
                OrderID = record.OrderID,
                CustomerName = record.CustomerName,
                ShipCity = record.ShipCity,
                ShipCountry = record.ShipCountry,
                ParentID = record.ParentID,
                HasChild = record.HasChild
            };

            if (entity.ParentID.HasValue)
            {
                var parent = orders.FirstOrDefault(o => o.OrderID == entity.ParentID.Value);
                if (parent != null) parent.HasChild = true;
            }

            if (index >= 0 && index <= orders.Count)
                orders.Insert(index, entity);
            else
                orders.Add(entity);

            return entity;
        }

        public OrderData? UpdateOrder(
            OrderData record,
            string action,
            string primaryColumnName,
            int primaryColumnValue,
            [GraphQLType(typeof(AnyType))] IDictionary<string, object> additionalParameters)
        {
            var orders = OrderData.GetAllRecords();

            var existing = primaryColumnName?.ToLowerInvariant() switch
            {
                "orderid" => orders.FirstOrDefault(x => x.OrderID == primaryColumnValue),
                _ => orders.FirstOrDefault(x => x.OrderID == primaryColumnValue)
            };
            if (existing == null) return null;

            if (record.CustomerName != null) existing.CustomerName = record.CustomerName;
            if (record.ShipCity != null) existing.ShipCity = record.ShipCity;
            if (record.ShipCountry != null) existing.ShipCountry = record.ShipCountry;

            if (record.ParentID.HasValue && record.ParentID.Value != existing.ParentID)
            {
                var oldParentId = existing.ParentID;
                existing.ParentID = record.ParentID;

                if (existing.ParentID.HasValue)
                {
                    var newParent = orders.FirstOrDefault(o => o.OrderID == existing.ParentID.Value);
                    if (newParent != null) newParent.HasChild = true;
                }

                if (oldParentId.HasValue)
                {
                    var oldParent = orders.FirstOrDefault(o => o.OrderID == oldParentId.Value);
                    if (oldParent != null)
                    {
                        oldParent.HasChild = orders.Any(o => o.ParentID == oldParent.OrderID);
                    }
                }
            }

            if (record.HasChild) existing.HasChild = record.HasChild;

            return existing;
        }

        public OrderData? DeleteOrder(
        int primaryColumnValue,
        string action,
        string primaryColumnName,
        [GraphQLType(typeof(AnyType))] IDictionary<string, object> additionalParameters)
        {
            var orders = OrderData.GetAllRecords();

            var toDelete = primaryColumnName?.ToLowerInvariant() switch
            {
                "orderid" => orders.FirstOrDefault(x => x.OrderID == primaryColumnValue),
                _ => orders.FirstOrDefault(x => x.OrderID == primaryColumnValue)
            };
            if (toDelete == null) return null;

            var idsToRemove = new HashSet<int>();
            CollectWithDescendants(orders, toDelete.OrderID, idsToRemove);

            orders.RemoveAll(o => idsToRemove.Contains(o.OrderID));

            if (toDelete.ParentID.HasValue)
            {
                var parent = orders.FirstOrDefault(o => o.OrderID == toDelete.ParentID.Value);
                if (parent != null)
                {
                    parent.HasChild = orders.Any(o => o.ParentID == parent.OrderID);
                }
            }

            return toDelete;
        }

        private static void CollectWithDescendants(List<OrderData> all, int rootId, HashSet<int> bag)
        {
            if (!bag.Add(rootId)) return;
            foreach (var childId in all.Where(o => o.ParentID == rootId).Select(o => o.OrderID).ToList())
                CollectWithDescendants(all, childId, bag);
        }
    }
}

{% endhighlight %}
{% endtabs %}

![Crud Operation](./images/GraphCRUD.gif)
