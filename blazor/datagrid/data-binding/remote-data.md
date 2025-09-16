---
layout: post
title: Remote Data in Blazor DataGrid | Syncfusion
description: Learn all about remote data in Syncfusion Blazor DataGrid and much more.
platform: Blazor
control: DataGrid
documentation: ug
---

# Remote Data in Blazor DataGrid

In the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid, binding remote data is a fundamental feature that enables efficient interaction with external data services. This process involves assigning a remote data service, represented by an instance of [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html), to the [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_DataSource) property of the Grid. By specifying the endpoint URL and the appropriate adaptor, you can seamlessly connect the Grid to remote sources such as OData, Web API, RESTful services, or GraphQL endpoints.

To bind remote data in the Grid:

- Create an instance of `SfDataManager` and configure its [Url](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html#Syncfusion_Blazor_DataManager_Url) property with the endpoint of your remote data service.
- Set the [Adaptor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html#Syncfusion_Blazor_DataManager_Adaptor) property to match the type of service you are connecting to (e.g., `ODataAdaptor`, `WebApiAdaptor`, `UrlAdaptor`, etc.).
- Assign the configured `SfDataManager` to the `DataSource` property of the Grid.
- Explicitly specify the `TValue` type for the Grid to match your data model.

**Example:**

```cs
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Data

<SfGrid TValue="Order" DataSource="@RemoteData" AllowPaging="true">
    <GridColumns>
        <GridColumn Field="OrderID" HeaderText="Order ID" Width="120" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field="CustomerID" HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field="Freight" HeaderText="Freight" Width="120" Format="C2" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field="ShipCountry" HeaderText="Ship Country" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public SfDataManager RemoteData = new SfDataManager
    {
        Url = "https://services.odata.org/V4/Northwind/Northwind.svc/Orders",
        Adaptor = Adaptors.ODataV4Adaptor
    };

    public class Order
    {
        public int OrderID { get; set; }
        public string CustomerID { get; set; }
        public double? Freight { get; set; }
        public string ShipCountry { get; set; }
    }
}
```

> When using `SfDataManager` for remote data binding, ensure the `TValue` type of the Grid matches your data model.
> If no `adaptor` is specified, `SfDataManager` uses the [ODataAdaptor](https://blazor.syncfusion.com/documentation/data/adaptors#odata-adaptor) by default.

This setup allows the Grid to interact with remote data sources efficiently, supporting features like paging, sorting, and filtering directly from the server.

## Binding with OData services

[OData](https://www.odata.org/documentation/odata-version-3-0/) (Open Data Protocol) is a standardized protocol designed to simplify data sharing across disparate systems. It enables querying and updating data via RESTful APIs. The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) provides built-in support for consuming OData v3 and v4 services, making it easy to bind remote OData service data to the Grid.

The `SfDataManager` communicates with the remote OData service using the `ODataAdaptor` or `ODataV4Adaptor`, depending on the OData protocol version.

> Use `ODataAdaptor` for OData v3 services and `ODataV4Adaptor` for OData v4 services.
> Ensure that the response format of the OData service aligns with the expected Grid data model.

The following example demonstrates how to bind an OData service to the Grid using `SfDataManager`:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.Grids

<SfGrid TValue="Order" AllowPaging="true">
        <SfDataManager Url="https://services.odata.org/Northwind/Northwind.svc/Orders" Adaptor="Adaptors.ODataAdaptor"></SfDataManager>
        <GridColumns>
                <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="TextAlign.Right" Width="120"></GridColumn>
                <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
                <GridColumn Field=@nameof(Order.OrderDate) HeaderText="Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
                <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
                <GridColumn Field=@nameof(Order.ShipCountry) HeaderText="Ship Country" Width="150"></GridColumn>
        </GridColumns>
</SfGrid>

@code{
        public class Order {
                public int? OrderID { get; set; }
                public string CustomerID { get; set; }
                public DateTime? OrderDate { get; set; }
                public double? Freight { get; set; }
                public string ShipCountry { get; set; }
        }
}

{% endhighlight %}
{% endtabs %}

## Enable SfDataManager after initial rendering

In Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid, remote data binding using the [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) is typically configured during initialization. However, in some scenarios where data should not be loaded immediately when the page is rendered. Instead, you can load data dynamically based on specific conditions or user actions. This approach optimizes performance by reducing initial load time and avoiding unnecessary network calls.

Initially, render the Grid with an empty data source. You can then conditionally assign the `SfDataManager` to the Grid's [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_DataSource) property in response to a user event. When the `SfDataManager` is added dynamically, the Grid will immediately initiate a request to the configured remote endpoint and display the fetched data.

The following example demonstrates how to bind the Grid to a remote Web API service only after a button is clicked by the user.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.Grids

<SfButton OnClick="Enable" CssClass="e-primary" IsPrimary="true" Content="Enable data manager"></SfButton>
<SfGrid TValue="Order" AllowPaging="true">
        <GridPageSettings PageSize="10"></GridPageSettings>
        @if (IsDataManagerEnabled)
        {
                <SfDataManager Url="https://blazor.syncfusion.com/services/production/api/Orders/" Adaptor="Adaptors.WebApiAdaptor"></SfDataManager>
        }
        <GridColumns>
                <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="TextAlign.Right" Width="120"></GridColumn>
                <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
                <GridColumn Field=@nameof(Order.OrderDate) HeaderText="Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
                <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        </GridColumns>
</SfGrid>

@code{
        public bool IsDataManagerEnabled = false;

        public class Order
        {
                public int? OrderID { get; set; }
                public string CustomerID { get; set; }
                public DateTime? OrderDate { get; set; }
                public double? Freight { get; set; }
        }

        public void Enable()
        {
                // Enabling condition to render the data manager.
                this.IsDataManagerEnabled = true;
        }
}

{% endhighlight %}
{% endtabs %}

The following GIF demonstrates dynamically rendering the data manager in the Grid:

![Dynamically Rendering Data Manager in Blazor DataGrid](../images/blazor-datagrid-dynamic-render-data-manager.gif)

## Configuring HttpClient

The [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html) uses an [HttpClient](https://learn.microsoft.com/dotnet/api/system.net.http.httpclient) instance to make HTTP requests to data services. When initializing, `SfDataManager` checks if an `HttpClient` is already registered in the [service container](https://learn.microsoft.com/aspnet/core/fundamentals/dependency-injection). If found, it uses the registered instance; otherwise, it creates and adds its own `HttpClient` to the service container for server requests.

> Register your `HttpClient` before calling `AddSyncfusionBlazor()` in `Program.cs`. This ensures `SfDataManager` uses your pre-configured `HttpClient` (with base address, authentication, default headers, etc.) instead of creating a new one.

You can also pass an `HttpClient` instance directly to the `SfDataManager` using the [HttpClientInstance](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html#Syncfusion_Blazor_DataManager_HttpClientInstance) property. This is useful when your application has multiple pre-configured or named `HttpClient` instances.

To troubleshoot HTTP requests and responses, you can use a custom [HTTP message handler](https://learn.microsoft.com/en-us/aspnet/web-api/overview/advanced/httpclient-message-handlers). For details on registering a custom handler, see the [ASP.NET Core documentation](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests).

> Using [Typed clients](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests#typed-clients) with `SfDataManager` is not supported. To achieve similar requirements, use the [custom binding](https://blazor.syncfusion.com/documentation/datagrid/data-binding#custom-binding) feature.

## Authorization and Authentication

When accessing remote data services, it is common for the server to require authorization to prevent anonymous access. The [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) can consume data from protected remote services by providing the appropriate bearer (access) token. You can provide the access token to `SfDataManager` in the following ways:

- **Using a pre-configured HttpClient:**  
    Register an `HttpClient` instance with the access token or an authentication message handler before calling `AddSyncfusionBlazor()` in your `Program.cs`. This ensures that `SfDataManager` uses the configured `HttpClient` instead of creating its own, allowing it to access protected services.

- **Setting the access token in the default headers:**  
    Inject the configured `HttpClient` into your page and set the access token in the default request headers. For example:

        ```csharp
        @inject HttpClient _httpClient

        @code {
                protected override async Task OnInitializedAsync()
                {
                        _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {tokenValue}");
                        await base.OnInitializedAsync();
                }
        }
        ```

- **Using the Headers property of SfDataManager:**  
    Set the access token directly in the [Headers](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html#Syncfusion_Blazor_DataManager_Headers) property of `SfDataManager`. For more details, see [Setting custom headers](#setting-custom-headers).

The method for obtaining the bearer token depends on your authentication provider. For more information on configuring `HttpClient` with authentication in Blazor, refer to the official documentation [here](https://learn.microsoft.com/aspnet/core/blazor/security/webassembly/additional-scenarios?view=aspnetcore-8.0).

## Setting custom headers

In scenarios where your application needs to send authentication tokens, API keys, or other metadata with each data request, you can add custom HTTP headers to the requests made by the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid. This is especially useful when interacting with secured APIs or services that require specific headers for authorization or tracking.

To achieve this, use the [Headers](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html#Syncfusion_Blazor_DataManager_Headers) property of the [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html). The `Headers` property accepts a dictionary of key-value pairs, where each key is the header name and the value is the header value.

The following example demonstrates adding custom headers to the `SfDataManager` request:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.Grids

<SfGrid TValue="Order" AllowPaging="true">
        <GridPageSettings PageSize="10"></GridPageSettings>
        @* Replace xxxx with your actual port number *@
        <SfDataManager Headers=@HeaderData Url="https://localhost:xxxx/api/Grid" Adaptor="Adaptors.WebApiAdaptor"></SfDataManager>
        <GridColumns>
                <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="TextAlign.Right" Width="120"></GridColumn>
                <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
                <GridColumn Field=@nameof(Order.OrderDate) HeaderText="Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
                <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        </GridColumns>
</SfGrid>

@code{
        private IDictionary<string, string> HeaderData = new Dictionary<string, string>();

        public class Order
        {
                public int? OrderID { get; set; }
                public string CustomerID { get; set; }
                public DateTime? OrderDate { get; set; }
                public double? Freight { get; set; }
        }
}

{% endhighlight %}
{% endtabs %}

![Setting Custom Headers](../images/remote-data-custom-headers.png)

## Dynamically change query parameter values

You can dynamically update the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid's [Query](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.Query.html) property at runtime to control the data retrieved from a remote source. This is useful for scenarios where you want to filter, sort, or otherwise modify the data displayed in the Grid based on user actions, such as button clicks or other UI events.

The following example demonstrates how to modify the query parameter dynamically using button click. Initially, the Grid displays orders where `CustomerID` is "VINET". When you click the **Modify Query Data** button, the Grid updates to show orders where **CustomerID** is "HANAR".

```cs
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.Grids

<SfButton Content="Modify Query Data" OnClick="BtnClick"></SfButton>
<SfGrid TValue="Order" @ref="GridObj" AllowPaging="true" Query="@QueryData">
    <GridPageSettings PageSize="10"></GridPageSettings>
    <SfDataManager Url="https://services.odata.org/V4/Northwind/Northwind.svc/Orders" Adaptor="Adaptors.ODataV4Adaptor"></SfDataManager>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public SfGrid<Order> GridObj;
    private Query QueryData = new Query().Where("CustomerID", "equal", "VINET");
    private Query UpdatedQueryData = new Query().Where("CustomerID", "equal", "HANAR");

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public double? Freight { get; set; }
    }

    public void BtnClick()
    {
        QueryData = UpdatedQueryData;
    }
}
```

The following GIF illustrates how the Grid updates its data when the query parameter is changed dynamically:

![Changing Query Dynamically in the Grid](./images/blazor-datagrid-query-update.gif)

## Offline mode

On remote data binding, all Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid actions such as paging, sorting, editing, grouping, filtering, etc, will be processed on server-side. To avoid post back for every action, set the Grid to load all data on initialization and make the actions process in client-side. To enable this behavior, use the [Offline](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html#Syncfusion_Blazor_DataManager_Offline) property of [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html).

{% tabs %}
{% highlight razor tabtitle="Index.razor"%}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor
 
<SfGrid TValue="OrdersDetails" Height="348">
    <SfDataManager Url="https://localhost:xxxx/api/Grid" Adaptor="Adaptors.WebApiAdaptor" Offline="true"></SfDataManager>
    <GridColumns>
        <GridColumn Field="OrderID" HeaderText="Order ID" Width="120" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field="CustomerID" HeaderText="Customer Name" Width="160"></GridColumn>
        <GridColumn Field="ShipCity" HeaderText="Ship City" Width="150"></GridColumn>
        <GridColumn Field="ShipCountry" HeaderText="Ship Country" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>
 
{% endhighlight %}
 
{% highlight c# tabtitle="GridController.cs"%}
 
using Microsoft.AspNetCore.Mvc;
using Syncfusion.Blazor.Data;
using Syncfusion.Blazor;
using WebApiAdaptor.Models;

namespace WebApiAdaptor.Controllers
{
    [ApiController]
    public class GridController : ControllerBase
    {
        /// <summary>
        /// Retrieves order data.
        /// </summary>
        /// <returns>Returns a JSON object with the list of orders and the total count.</returns>
        [HttpGet]
        [Route("api/[controller]")]
        public object GetOrderData()
        {
            // Retrieve all order records.
            List<OrdersDetails> data = OrdersDetails.GetAllRecords().ToList();

            // Return the data and total count.
            return new { Items = data, Count = data.Count() };
        }
    }
}
 
{% endhighlight %}
{% endtabs %}
 
> Replace `https://localhost:xxxx/api/Grid` with the actual URL of your API endpoint that provides the data in a consumable format (e.g., JSON).

You can find the complete code in the [Github location](https://github.com/SyncfusionExamples/databinding-in-blazor-datagrid/tree/master/Offline-Mode).

## Fetch result from the DataManager query using external button

By default, Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid binds to a remote data source using the [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html). However, you may want to fetch data dynamically from the server in response to an external button click, giving you more control over when and how data is loaded into the Grid.

To achieve this, you can use an external button to trigger an HTTP request, fetch the data, and then assign it to the Grid's [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_DataSource) property.

The following example demonstrates how to fetch data from the server when a button is clicked and display a status message indicating the fetch status:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@page "/"
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor
@using WebApiAdaptor.Models
@using System.Net.Http.Json
@inject HttpClient Http

<SfButton OnClick="ExecuteQuery" CssClass="e-primary">Execute Query</SfButton>

<p style="@StatusStyle">@StatusMessage</p>

<SfGrid TValue="OrdersDetails" DataSource="@Orders" AllowPaging="true">
    <GridColumns>
        <GridColumn Field="OrderID" HeaderText="Order ID" Width="120" TextAlign="TextAlign.Right" />
        <GridColumn Field="CustomerID" HeaderText="Customer ID" Width="160" />
        <GridColumn Field="EmployeeID" HeaderText="Employee ID" Width="120" TextAlign="TextAlign.Right" />
        <GridColumn Field="Freight" HeaderText="Freight" Width="150" Format="C2" TextAlign="TextAlign.Right" />
        <GridColumn Field="ShipCountry" HeaderText="Ship Country" Width="150" />
    </GridColumns>
</SfGrid>

@code {
    public string StatusMessage { get; set; } = "";
    public string StatusStyle { get; set; } = "color:black;";
    public List<OrdersDetails> Orders { get; set; } = new();

    private async Task ExecuteQuery()
    {
        try
        {
            StatusMessage = "Fetching data...";
            StatusStyle = "color:blue;";

            var response = await Http.GetFromJsonAsync<GridResponse<OrdersDetails>>("https://localhost:7167/api/Grid");

            if (response != null)
            {
                Orders = response.Items;
                StatusMessage = $"Data fetched successfully! Total Records: {response.Count}";
                StatusStyle = "color:green; text-align:center;";
            }
            else
            {
                StatusMessage = "No data returned from server.";
                StatusStyle = "color:orange;text-align:center;";
            }
        }
        catch (Exception ex)
        {
            StatusMessage = $"Error fetching data: {ex.Message}";
            StatusStyle = "color:red;text-align:center;";
        }
    }

    public class GridResponse<T>
    {
        public List<T> Items { get; set; }
        public int Count { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

![Fetch result using query](../images/fetch-query.png)

You can find the complete code in the [Github location](https://github.com/SyncfusionExamples/databinding-in-blazor-datagrid/tree/master/Fetch-result-from-the-DataManager-query).
