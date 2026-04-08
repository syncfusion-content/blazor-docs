---
layout: post
title: Data Binding in Blazor MultiColumn ComboBox Component | Syncfusion
description: Checkout and learn here all about Data Binding in Syncfusion Blazor MultiColumn ComboBox component and much more.
platform: Blazor
control: MultiColumn ComboBox
documentation: ug
---

# Data Binding in MultiColumn ComboBox Component

The MultiColumn ComboBox can retrieve data from either local data sources or remote data services. To connect local data, use the [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.SfMultiColumnComboBox-2.html#Syncfusion_Blazor_MultiColumnComboBox_SfMultiColumnComboBox_2_DataSource) property with an IEnumerable-compatible source. For remote data, create a [DataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html) instance configured with an adaptor and assign it to DataSource.

* **TItem** - Specifies the data model type for items in the MultiColumn ComboBox.

## Binding local data

The MultiColumn ComboBox loads data from local sources through the [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.SfMultiColumnComboBox-2.html#Syncfusion_Blazor_MultiColumnComboBox_SfMultiColumnComboBox_2_DataSource) property. Supported types include:
- Array of primitive type
- Array of object
- List of primitive type
- List of object
- ObservableCollection
- ExpandoObject
- DynamicObject

Ensure [TextField] and [ValueField] are set appropriately for your data model so display text and values are mapped correctly.

{% highlight cshtml %}

{% include_relative code-snippet/data-binding/local-data-binding.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VZBftYVqKvgHmaAA?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor MultiColumn ComboBox with local data binding](./images/data-binding/blazor_combobox_local-binding.png)" %}

## Index value binding

Index value binding can be accomplished with the `bind-Index` attribute, which supports both integer and nullable integer types. This binds the selected item by its zero-based index in the current view. Sorting or filtering may change indices, which affects the bound value.

```cshtml

@using Syncfusion.Blazor.MultiColumnComboBox

<SfMultiColumnComboBox TItem="Product" TValue="string" @bind-Index="@ComboIndex" DataSource="@Products" PopupWidth="600px" ValueField="Name" TextField="Name" Placeholder="Select any product"></SfMultiColumnComboBox>

@code {

     public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Availability { get; set; }
        public string Category { get; set; }
        public double Rating { get; set; }
    }
    private List<Product> Products = new List<Product>();
    private int? ComboIndex { get; set; } = 2;
    protected override Task OnInitializedAsync()
    {
        Products = new List<Product>
        {
            new Product { Name = "Laptop", Price = 999.99m, Availability = "In Stock", Category = "Electronics", Rating = 4.5 },
            new Product { Name = "Smartphone", Price = 599.99m, Availability = "Out of Stock", Category = "Electronics", Rating = 4.3 },
            new Product { Name = "Tablet", Price = 299.99m, Availability = "In Stock", Category = "Electronics", Rating = 4.2 },
            new Product { Name = "Headphones", Price = 49.99m, Availability = "In Stock", Category = "Accessories", Rating = 4.0 },
            new Product { Name = "Smartwatch", Price = 199.99m, Availability = "Limited Stock", Category = "Wearables", Rating = 4.4 },
            new Product { Name = "Monitor", Price = 129.99m, Availability = "In Stock", Category = "Electronics", Rating = 4.6 },
            new Product { Name = "Keyboard", Price = 39.99m, Availability = "In Stock", Category = "Accessories", Rating = 4.1 },
            new Product { Name = "Mouse", Price = 19.99m, Availability = "Out of Stock", Category = "Accessories", Rating = 4.3 },
        };
        return base.OnInitializedAsync();
    }
}
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/hNVpNOrAUlzhIfCJ?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Expando object binding

Bind the [ExpandoObject](https://learn.microsoft.com/en-us/dotnet/api/system.dynamic.expandoobject?view=net-8.0) data to the MultiColumn ComboBox component. In the following example, an `ExpandoObject` collection of vehicles is bound. Set TextField and ValueField to the corresponding dynamic property names.

{% highlight cshtml %}

{% include_relative code-snippet/data-binding/expando-object-binding.razor %}

{% endhighlight %}

![Blazor MultiColumn ComboBox with Expando object binding](./images/data-binding/blazor_combobox_expando-object-binding.gif)

### Dynamic object binding

Bind the [DynamicObject](https://learn.microsoft.com/en-us/dotnet/api/system.dynamic.dynamicobject?view=net-8.0) data to the MultiColumn ComboBox component. In the following example, a `DynamicObject` collection of customers is bound. Ensure TextField and ValueField map to the dynamic members exposed at runtime.

{% highlight cshtml %}

{% include_relative code-snippet/data-binding/dynamic-object-binding.razor %}

{% endhighlight %}

![Blazor MultiColumn ComboBox with Dynamic object binding](./images/data-binding/blazor_combobox_dynamic-data-binding.gif)

### ValueTuple data binding

Bind the [ValueTuple](https://learn.microsoft.com/en-us/dotnet/api/system.valuetuple-2?view=net-8.0) data to the MultiColumn ComboBox component. The following example retrieves a string value from enumeration data using `ValueTuple`. Map TextField/ValueField to the tuple members (for example, `Item1`, `Item2`) as used in the sample.

{% highlight cshtml %}

{% include_relative code-snippet/data-binding/value-tuple-data-binding.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LNLzNkLgKvoKORyE?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Binding remote data 

The MultiColumn ComboBox loads the data from remote data services through the [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.SfMultiColumnComboBox-2.html#Syncfusion_Blazor_MultiColumnComboBox_SfMultiColumnComboBox_2_DataSource) property when it is assigned a [DataManager](https://blazor.syncfusion.com/documentation/data/getting-started) instance.

The MultiColumn ComboBox supports retrieving data from remote services with the [DataManager](https://blazor.syncfusion.com/documentation/data/getting-started). Use the [Query](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownBase-1.html#Syncfusion_Blazor_DropDowns_SfDropDownBase_1_Query) property to shape requests and fetch data, then bind the results to the component.

* [DataManager.Url](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html#Syncfusion_Blazor_DataManager_Url) - Defines the service endpoint to fetch data.
* [DataManager.Adaptor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html#Syncfusion_Blazor_DataManager_Adaptor) - Defines the adaptor used to communicate with the service. By default, the [ODataAdaptor](https://blazor.syncfusion.com/documentation/data/adaptors#odata-adaptor) is used for remote binding. Choose the adaptor based on your API (for example, ODataV4Adaptor, WebApiAdaptor, UrlAdaptor).
* [Syncfusion.Blazor.Data](https://www.nuget.org/packages/Syncfusion.Blazor.Data/) package provides predefined adaptors designed to interact with specific service endpoints.

### OnActionBegin event

The [OnActionBegin](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.SfMultiColumnComboBox-2.html#Syncfusion_Blazor_MultiColumnComboBox_SfMultiColumnComboBox_2_OnActionBegin) event triggers before fetching data from the remote server. Use it to adjust the query, show a loading indicator, or log outgoing requests.

{% highlight cshtml %}

{% include_relative code-snippet/data-binding/action-begin.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LNVeMZjQHJYqdimB?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### OnActionFailure event

The [OnActionFailure](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.SfMultiColumnComboBox-2.html#Syncfusion_Blazor_MultiColumnComboBox_SfMultiColumnComboBox_2_OnActionFailure) event triggers when the data fetch request from the remote server fails. Handle this event to log errors, display user-friendly messages, or retry operations.

{% highlight cshtml %}

{% include_relative code-snippet/data-binding/action-failure.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LtVoWNZwRIdKNBsr?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### OData v4 services

The [OData v4 Adaptor](https://blazor.syncfusion.com/documentation/data/adaptors#odatav4-adaptor) provides the ability to consume and manipulate data from OData v4 services. The following sample displays the first six customer details from the `Customers` table of the `Northwind` data service.

{% highlight cshtml %}

{% include_relative code-snippet/data-binding/odata-v4-services.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LjVJZkBKUbFJULBC?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor MultiColumn ComboBox with OData v4 Adaptor](./images/data-binding/blazor_combobox_odata-v4-services.png)" %}

### Web API adaptor

The [Web API Adaptor](https://blazor.syncfusion.com/documentation/data/adaptors#web-api-adaptor) is used to interact with Web API endpoints that follow OData conventions. The `WebApiAdaptor` extends the [ODataAdaptor](https://blazor.syncfusion.com/documentation/data/adaptors#odata-adaptor). The endpoint must recognize OData-formatted queries sent with the request.

{% highlight cshtml %}

{% include_relative code-snippet/data-binding/web-api-adaptor.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hZhIWjjwnRBWAlvb?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}


### Offline mode

To avoid a postback for every action, load all data on initialization and process actions on the client side. Enable this behavior by setting the `Offline` property of `DataManager`. In offline mode, data is fetched once; filtering and searching then occur client side.

The following example demonstrates remote data binding with offline mode enabled.

{% highlight cshtml %}

{% include_relative code-snippet/data-binding/offline-mode.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rNLTjuLqKOjLPMlY?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Entity Framework

Follow these steps to consume data from the [Entity Framework](https://blazor.syncfusion.com/documentation/common/data-binding/bind-entity-framework) in the MultiColumn ComboBox component.

#### Create DBContext class

The first step is to create a DBContext class called `OrderContext` to connect to a Microsoft SQL Server database.

```csharp
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFDropDown.Shared.Models;

namespace EFDropDown.Shared.DataAccess
{
    public class OrderContext : DbContext
    {
        public virtual DbSet<Shared.Models.Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Blazor\DropDownList\EFDropDown\Shared\App_Data\NORTHWND.MDF;Integrated Security=True;Connect Timeout=30");
            }
        }
    }
}
```

#### Create data access layer to perform data operation

Now, create a class named `OrderDataAccessLayer`, which act as data access layer for retrieving the records from the database table.

```csharp
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFDropDown.Shared.Models;

namespace EFDropDown.Shared.DataAccess
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

#### Creating web API controller

 A Web API Controller has to be created, which allows the MultiColumn ComboBox to directly consume data from the Entity Framework.

```csharp
using EFDropDown.Shared.DataAccess;
using EFDropDown.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Http;

namespace EFDropDown.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //TreeGrid
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

### Configure MultiColumn ComboBox component using Web API adaptor

Now, configure the MultiColumn ComboBox using the [SfDataManager](https://blazor.syncfusion.com/documentation/data/getting-started) to interact with the created Web API and consume the data appropriately. To interact with web API, use the [WebApiAdaptor](https://blazor.syncfusion.com/documentation/data/adaptors#web-api-adaptor).

{% highlight cshtml %}

{% include_relative code-snippet/data-binding/combobox-with-web-api-adaptor.razor %}

{% endhighlight %}
