---
layout: post
title: Working with Data in Blazor Charts Component | Syncfusion
description: Learn here all about Working with Data in Syncfusion Blazor Charts component and more.
platform: Blazor
control: Chart
documentation: ug
---

<!-- markdownlint-disable MD036 -->

# Working with Data in Blazor Charts Component

The Chart uses [`SfDataManager`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html), which supports both RESTful JSON data services binding and IEnumerable binding. The [`DataSource`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_DataSource) value can be assigned either with the property values from [`SfDataManager`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html) or list of business objects.
It supports the following kinds of data binding method:
* List binding
* Remote data

## List binding

 You can assign a IEnumerable object to the [`DataSource`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_DataSource) property. The list data source can also be provided as an instance of [`SfDataManager`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html) or by using [`SfDataManager`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html) component. Now map the data fields to
[`XName`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_XName) and [`YName`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_YName)
properties.

```csharp

@using Syncfusion.Blazor.Charts

<SfChart Title="Inflation - Consumer Price" Width="60%">
    <ChartPrimaryXAxis IntervalType="IntervalType.Years" LabelFormat="y" ValueType="Syncfusion.Blazor.Charts.ValueType.DateTime"></ChartPrimaryXAxis>
    <ChartSeriesCollection>
        <ChartSeries DataSource="@ConsumerReports" XName="XValue" YName="YValue" Type="ChartSeriesType.Line">
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code{
    public class ChartData
    {
        public DateTime XValue { get; set; }
        public double YValue { get; set; }
    }

    public List<ChartData> ConsumerReports = new List<ChartData>
    {
            new ChartData { XValue = new DateTime(2005, 01, 01), YValue = 21 },
            new ChartData { XValue = new DateTime(2006, 01, 01), YValue = 24 },
            new ChartData { XValue = new DateTime(2007, 01, 01), YValue = 36 },
            new ChartData { XValue = new DateTime(2008, 01, 01), YValue = 38 },
            new ChartData { XValue = new DateTime(2009, 01, 01), YValue = 54 },
            new ChartData { XValue = new DateTime(2010, 01, 01), YValue = 57 },
            new ChartData { XValue = new DateTime(2011, 01, 01), YValue = 70 },
        };
}


```

![Local Data](images/working-data/local-data.png)

> By default, [`SfDataManager`](https://help.syncfusion.com/cr/aspnetcore-blazor/Syncfusion.Blazor.Data.SfDataManager.html) uses **BlazorAdaptor** for list data-binding.

### ExpandoObject binding

Chart is a generic component which is strongly bound to a model type. There are cases when the model type is unknown during compile type. In such cases you can bound data to the chart as list of  **ExpandoObject**.

**ExpandoObject** can be bound to chart by assigning to the [`DataSource`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_DataSource) property.

```cshtml
@using Syncfusion.Blazor.Charts
@using System.Dynamic

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />
    <ChartSeriesCollection>
        <ChartSeries DataSource="@MedalDetails" XName="X" YName="Y" Type="ChartSeriesType.Column">
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code{
    private List<string> countries = new List<string> { "South Korea", "India", "Germany", "Italy", "Russia" };
    private Random randomNum = new Random();
    public List<ExpandoObject> MedalDetails { get; set; } = new List<ExpandoObject>();
    protected override void OnInitialized()
    {
        MedalDetails = Enumerable.Range(0, 5).Select((x) =>
        {
            dynamic d = new ExpandoObject();
            d.X = countries[x];
            d.Y = randomNum.Next(20, 80);
            return d;
        }).Cast<ExpandoObject>().ToList<ExpandoObject>();
    }
}
```

## Remote Data

To bind remote data to chart component, assign service data as an instance of [`SfDataManager`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html) to the `DataSource` property. To interact with remote data source, provide the endpoint Url.

```csharp

@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.Charts

<SfChart>
    <SfDataManager Url="https://services.odata.org/V4/Northwind/Northwind.svc/Orders" Adaptor="Adaptors.ODataV4Adaptor"></SfDataManager>

    <ChartPrimaryXAxis Title="Orders" ValueType="Syncfusion.Blazor.Charts.ValueType.Category"
                       RangePadding="ChartRangePadding.Additional"></ChartPrimaryXAxis>

    <ChartSeriesCollection>
        <ChartSeries XName="OrderID" YName="Freight" Type="ChartSeriesType.Column"></ChartSeries>
    </ChartSeriesCollection>
</SfChart>

```

### Binding with OData services

[OData](http://www.odata.org/documentation/odata-version-3-0/) is a standardized protocol for creating and consuming data. You can retrieve data from OData service using the [`SfDataManager`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html). Refer to the following code example for remote data binding using **OData** service.

### Binding with OData v4 services

ODataV4 is an enhanced version of OData protocols, and [`SfDataManager`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html) can also retrieve and consume OData v4 services. For more details on OData v4 services, please refer to the [OData documentation](http://docs.oasis-open.org/odata/odata/v4.0/errata03/os/complete/part1-protocol/odata-v4.0-errata03-os-part1-protocol-complete.html#_Toc453752197). Use the **ODataV4Adaptor** to bind OData v4 service.

![Remote Data](images/working-data/remote-data.png)

### Web API

You can use the [`WebApiAdaptor`](https://blazor.syncfusion.com/documentation/data/adaptors/?no-cache=1#web-api-adaptor) to bind chart with the Web API created using the [OData](http://www.odata.org/documentation/odata-version-3-0/) endpoint.

```cshtml
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.Charts

<SfChart>
    <SfDataManager Url="https://ej2services.syncfusion.com/production/web-services/api/Orders" Adaptor="Adaptors.WebApiAdaptor"></SfDataManager>

    <ChartPrimaryXAxis Title="Orders" ValueType="Syncfusion.Blazor.Charts.ValueType.Category"
                       ></ChartPrimaryXAxis>

    <ChartSeriesCollection>
        <ChartSeries XName="OrderID" YName="Freight" Type="ChartSeriesType.Column"></ChartSeries>
    </ChartSeriesCollection>
</SfChart>
```

![Web API](images/working-data/webapi.png)

### Sending additional parameters to the server

To add a custom parameter to the data request. Assign the Query object with additional parameters to the chart [`Query`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Query) property.

The following sample code demonstrates sending parameters using the Query property in the series,

```cshtml
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.Charts

<SfChart>
    <SfDataManager Url="https://services.odata.org/V4/Northwind/Northwind.svc/Orders" Adaptor="Adaptors.ODataV4Adaptor"></SfDataManager>

    <ChartPrimaryXAxis Title="Orders" ValueType="Syncfusion.Blazor.Charts.ValueType.Category"
                       RangePadding="ChartRangePadding.Additional"></ChartPrimaryXAxis>

    <ChartSeriesCollection>
        <ChartSeries Query="ChartQuery" XName="OrderID" YName="Freight" Type="ChartSeriesType.Column"></ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code{
    public Query ChartQuery { get; set; }

    protected override void OnInitialized()
    {
        ChartQuery = new Query().Take(10).Where("Freight", "GreaterThan", 300, false);
    }

}
```

## Entity Framework

Entity Framework acts as a modern object-database mapper for .NET. This section explains how to consume data from the **Microsoft SQL Server** database and bind it to the chart component.

### Create DBContext class

The first step is to create a DBContext class called **OrderContext** for establishing connection to a Microsoft SQL Server database.

```csharp
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using EFChart.Data;

    namespace EFChart.Data
    {
        public class OrderContext : DbContext
        {
            public virtual DbSet<Order> Orders { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                if (!optionsBuilder.IsConfigured)
                {
                    // Configures the context to connect to a Microsoft SQL Serve database
                    optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='D:\blazor\EFTreeMap\App_Data\NORTHWND.MDF';Integrated Security=True;Connect Timeout=30");
                }
            }
        }

        public class Order
        {
            [Key]
            public int? OrderID { get; set; }
            [Required]
            public string CustomerID { get; set; }
            [Required]
            public int EmployeeID { get; set; }
        }
    }

```

### Create data access layer to perform data operation

Now need to create a class called **OrderDataAccessLayer**, which acts as a data access layer to retrieve the records from the database table.

```csharp
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using static BlazorApp1.Data.OrderContext;
    using EFChart.Data;

    namespace EFChart.Data
    {
        public class OrderDataAccessLayer
        {
            OrderContext db = new OrderContext();

            //To Get all Orders details
            public DbSet<Order> GetAllOrders()
            {
                try
                {
                    return db.Orders;
                }
                catch
                {
                    throw;
                }
            }
        }
    }

```

### Creating Web API Controller

A Web API Controller must be created which allows the chart to directly consume data from the Entity framework.

```csharp
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Primitives;
    using static BlazorApp1.Data.OrderContext;
    using EFChart.Data;

    namespace EFChart.Controller
    {
        [Route("api/[controller]")]
        [ApiController]
        public class DefaultController : ControllerBase
        {
            OrderDataAccessLayer db = new OrderDataAccessLayer();
            [HttpGet]
            public object Get()
            {
                IQueryable<Order> data = db.GetAllOrders().AsQueryable();
                var count = data.Count();
                var queryString = Request.Query;
                if (queryString.Keys.Contains("$inlinecount"))
                {
                    StringValues Skip;
                    StringValues Take;
                    int skip = (queryString.TryGetValue("$skip", out Skip)) ? Convert.ToInt32(Skip[0]) : 0;
                    int top = (queryString.TryGetValue("$top", out Take)) ? Convert.ToInt32(Take[0]) : data.Count();
                    return new { Items = data.Skip(skip).Take(top), Count = count };
                }
                else
                {
                    return data;
                }
            }
        }
    }

```

### Add Web API Controller services in Startup.cs

Open the **Startup.cs** file to add services and endpoints required for Web API Controller as follows.

```csharp
using EFChart.Data;
using Newtonsoft.Json.Serialization;

namespace BlazorApplication
{
    public class Startup
    {
        ....
        ....
        public void ConfigureServices(IServiceCollection services)
        {
            ....
            ....
            services.AddSingleton<OrderDataAccessLayer>();

            // Adds services for controllers to the specified Microsoft.Extensions.DependencyInjection.IServiceCollection.
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            ....
            ....
            app.UseEndpoints(endpoints =>
            {
                // Adds endpoints for controller actions to the Microsoft.AspNetCore.Routing.IEndpointRouteBuilder
                endpoints.MapDefaultControllerRoute();
                .....
                .....
            });
        }
    }
}
```

### Configure chart component

Configure the chart to bind data using either [`DataSource`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfChart.html#Syncfusion_Blazor_Charts_SfChart_DataSource) property or [`SfDataManager`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html).

For instance, to bind data directly from the data access layer class **OrderDataAccessLayer**, assign the [`DataSource`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfChart.html#Syncfusion_Blazor_Charts_SfChart_DataSource) property to be **OrderData.GetAllOrders()**.

```csharp

    @using EFChart.Data;
    @inject OrderDataAccessLayer OrderData;

    @using Syncfusion.Blazor.Charts

    <SfChart DataSource="@OrderData.GetAllOrders()">
      <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category">
      </ChartPrimaryXAxis>
      <ChartSeriesCollection>
        <ChartSeries XName="CustomerID" YName="OrderID" Type="ChartSeriesType.Column">
        </ChartSeries>
      </ChartSeriesCollection>
    </SfChart>
```

On the other hand, to configure the chart using Web API, provide the appropriate endpoint Url within [`SfDataManager`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html) along with [`Adaptor`](https://blazor.syncfusion.com/documentation/data/adaptors/). Here, need to use [`WebApiAdaptor`](https://blazor.syncfusion.com/documentation/data/adaptors/?no-cache=1#web-api-adaptor) in-order to interact with the Web API to consume data from the entity framework appropriately.

```cshtml
@using Syncfusion.Blazor.Charts
@using Syncfusion.Blazor.Data

    <SfChart>
          <SfDataManager Url="api/Default" Adaptor="Syncfusion.Blazor.Adaptors.WebApiAdaptor">
          </SfDataManager>
          <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category">
          </ChartPrimaryXAxis>
          <ChartSeriesCollection>
             <ChartSeries XName="CustomerID" YName="OrderID" Type="ChartSeriesType.Column">
             </ChartSeries>
          </ChartSeriesCollection>
    </SfChart>

```

## Empty points

Data points with NaN values are regarded as empty points. By using [`EmptyPointSettings`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_EmptyPointSettings) property in series, you can customize the empty point. Default Empty Point [`Mode`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.EmptyPointMode.html) is `Gap`.

```csharp

@using Syncfusion.Blazor.Charts

<SfChart Title="Inflation - Consumer Price" Width="60%">
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category">
    </ChartPrimaryXAxis>

    <ChartSeriesCollection>
        <ChartSeries DataSource="@ConsumerReports" XName="XValue" YName="YValue" Type="ChartSeriesType.Column">
            <ChartEmptyPointSettings Fill="blue" Mode="@mode"></ChartEmptyPointSettings>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code{
    public class ChartData
    {
        public String XValue { get; set; }
        public double YValue { get; set; }
    }
    public EmptyPointMode mode = EmptyPointMode.Average;
    public List<ChartData> ConsumerReports = new List<ChartData> {
            new ChartData { XValue = "Rice", YValue = 80 },
            new ChartData { XValue = "Wheat", YValue = Double.NaN },
            new ChartData { XValue = "Oil", YValue = 70 },
            new ChartData { XValue = "Corn", YValue = 60 },
            new ChartData { XValue = "Gram", YValue = Double.NaN },
            new ChartData { XValue = "Milk", YValue = 70 },
            new ChartData { XValue = "Peas", YValue = 80 },
            new ChartData { XValue = "Fruit", YValue = 60 },
            new ChartData { XValue = "Butter", YValue = Double.NaN },
        };
}

```

**Customizing empty point**

Specific color and border for empty point can be set by [`Fill`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEmptyPointSettings.html#Syncfusion_Blazor_Charts_ChartEmptyPointSettings_Fill) and [`Border`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEmptyPointSettings.html#Syncfusion_Blazor_Charts_ChartEmptyPointSettings_Border) properties in [`EmptyPointSettings`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_EmptyPointSettings).

```csharp

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category">
    </ChartPrimaryXAxis>

    <ChartSeriesCollection>
        <ChartSeries DataSource="@SalesReports" XName="Month" YName="Sales" Type="ChartSeriesType.Column">
            <ChartEmptyPointSettings Fill="blue" Mode="@Mode"></ChartEmptyPointSettings>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code{
    public class ChartData
    {
        public string Month { get; set; }
        public Nullable<double> Sales { get; set; }
    }
    public EmptyPointMode Mode = EmptyPointMode.Average;

    public List<ChartData> SalesReports = new List<ChartData>
    {
    new ChartData{ Month="Jan", Sales= 35 },
    new ChartData{ Month= "Feb", Sales= 28 },
    new ChartData{ Month="Mar", Sales=null },
    new ChartData{ Month="Apr", Sales=32 },
    new ChartData{ Month="May", Sales=40 },
    new ChartData{ Month= "Jun", Sales=32 },
    new ChartData{ Month="Jul", Sales=35 },
    new ChartData{ Month="Aug", Sales=null },
    new ChartData{ Month="Sep", Sales=38 },
    new ChartData{ Month="Oct", Sales=30 },
    new ChartData{ Month="Nov", Sales=25 },
    new ChartData{ Month= "Dec", Sales=32 }
    };
}


```

![Empty points](images/working-data/custom-emptypoint.png)

> Note: You can refer to our [`Blazor Charts`](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations. You can also explore our [`Blazor Chart example`](https://blazor.syncfusion.com/demos/chart/line?theme=bootstrap4) to knows various chart types and how to represent time-dependent data, showing trends in data at equal intervals.

## See Also

* [Data label](./data-labels)
* [Tooltip](./tool-tip)
* [Marker](./data-markers)