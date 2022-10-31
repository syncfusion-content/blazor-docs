---
layout: post
title: Data Binding in Blazor DropDown List Component | Syncfusion
description: Checkout and learn here all about Data Binding in Syncfusion Blazor DropDown List component and more.
platform: Blazor
control: DropDown List
documentation: ug
---

# Data Binding in Blazor DropDown List Component

Data binding can be achieved by using the `bind-Value` attribute and it supports string, int, Enum and bool types. If component value has been changed, it will affect all the places where you bind the variable for the **bind-value** attribute.

* **TValue** - specifies the type of the each list item of the dropdown component.
* **TItem** - specifies the type of the whole list of the dropdown component.

## Binding Local data

The DropDownList loads the data from local data sources through the DataSource property. It supports the data type of Array, Observable Collection, ExpandoObject, DynamicObject.

Below code demonstrate the binding local data to the DropDownList.

```cshtml
@using Syncfusion.Blazor.DropDowns

<p>DropDownList value is:<strong>@DropVal</strong></p>

<SfDropDownList TValue="string" Placeholder="e.g. Australia" TItem="Country" @bind-Value="@DropVal" DataSource="@Countries">
    <DropDownListFieldSettings Value="Name"></DropDownListFieldSettings>
</SfDropDownList>

@code {

    public string DropVal;

    public class Country
    {
        public string Name { get; set; }

        public string Code { get; set; }
    }

    List<Country> Countries = new List<Country>
{
        new Country() { Name = "Australia", Code = "AU" },
        new Country() { Name = "Bermuda", Code = "BM" },
        new Country() { Name = "Canada", Code = "CA" },
        new Country() { Name = "Cameroon", Code = "CM" },
    };
}
```

### Primitive type

You can bind the data to the DropDownList as a list of string, int, double and bool type items.

The following code demonstrates array of string and integer values to the DropDownList component.

{% highlight cshtml %}

{% include_relative code-snippet/data-binding/primitive-type-string.razor %}

{% endhighlight %}

![Blazor DropdownList with Primitive string type](./images/data-binding/blazor_dropdown_primitive-type-string.png)

{% highlight cshtml %}

{% include_relative code-snippet/data-binding/primitive-type-int.razor %}

{% endhighlight %}

![Blazor DropdownList with Primitive int type](./images/data-binding/blazor_dropdown_primitive-type-int.png)

### Complex data type

The DropDownList can generate its list items through an array of complex data. For this, the appropriate columns should be mapped to the [Fields](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.FieldSettingsModel.html) property.

In the following example, `Code.ID` column and `Country.CountryID` column from complex data have been mapped to the `Value` field and `Text` field, respectively.

{% highlight cshtml %}

{% include_relative code-snippet/data-binding/complex-data-type.razor %}

{% endhighlight %}

![Blazor DropdownList with Complex data type](./images/data-binding/blazor_dropdown_complex-data-type.png)

### Expando object binding

You can bind ExpandoObject data to the DropDownList component. The following example `ExpandoObject` is bound to the collection of vehicles data.

{% highlight cshtml %}

{% include_relative code-snippet/data-binding/expando-object-binding.razor %}

{% endhighlight %}

![Blazor DropdownList with Expando object binding](./images/data-binding/blazor_dropdown_expando-object-binding.png)

### Observable collection binding

You can bind ObservableCollection data to the DropDownList component. In the following example, `Observable Data` is bound to a collection of colors data.

{% highlight cshtml %}

{% include_relative code-snippet/data-binding/observable-collection-binding.razor %}

{% endhighlight %}

![Blazor DropdownList with Observable collection binding](./images/data-binding/blazor_dropdown_observable-collection-binding.png)

### Dynamic object binding

You can bind DynamicObject data to the DropDownList component. The following example `DynamicObject` is bound to the collection of customers data.

{% highlight cshtml %}

{% include_relative code-snippet/data-binding/dynamic-object-binding.razor %}

{% endhighlight %}

![Blazor DropdownList with Dynamic object binding](./images/data-binding/blazor_dropdown_dynamic-data-binding.png)

### Enum data binding

You can bind enum data to DropDownList component. The following code helps you get a description value from the enumeration data.

{% highlight cshtml %}

{% include_relative code-snippet/data-binding/enum-data-binding.razor %}

{% endhighlight %}

![Blazor DropdownList with Enum data binding](./images/data-binding/blazor_dropdown_enum-data-binding.png)

### ValueTuple data binding

You can bind ValueTuple data to the DropDownList component. The following code helps you to get a string value from the enumeration data by using ValueTuple

{% highlight cshtml %}

{% include_relative code-snippet/data-binding/value-tuple-data-binding.razor %}

{% endhighlight %}

![Blazor DropdownList with ValueTuple data binding](./images/data-binding/blazor_dropdown_value-tuple-data-binding.png)

## Binding Remote data 

The DropDownList loads the data from remote data services through the DataSource property. 

The DropDownList supports retrieval of data from remote data services with the help of [DataManager]((https://blazor.syncfusion.com/documentation/data/getting-started)) control. The [Query](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownBase-1.html#Syncfusion_Blazor_DropDowns_SfDropDownBase_1_Query) property is used to fetch data from the database and bind it to the DropDownList.

* [DataManager.Url](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html#Syncfusion_Blazor_DataManager_Url) - Defines the service endpoint to fetch data.
* [DataManager.Adaptor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html#Syncfusion_Blazor_DataManager_Adaptor) - Defines the adaptor option. By default, ODataAdaptor is used for remote binding. The adaptor is responsible for processing responses and requests from/to the service endpoint. 
* [Syncfusion.Blazor.Data](https://www.nuget.org/packages/Syncfusion.Blazor.Data/) package provides some predefined adaptors that are designed to interact with particular service endpoints.

### OData v4 services

[OData v4 Adaptor](https://blazor.syncfusion.com/documentation/data/adaptors#odatav4-adaptor) provides ability to consume and manipulate data from OData v4 services. The following sample displays the first 6 contacts from Customers table of the `Northwind` Data Service.

{% highlight cshtml %}

{% include_relative code-snippet/data-binding/odata-v4-services.razor %}

{% endhighlight %}

![Blazor DropdownList with OData v4 Adaptor](./images/data-binding/blazor_dropdown_odata-v4-services.png)

### Web API Adaptor

[Web Api Adaptor](https://blazor.syncfusion.com/documentation/data/adaptors#web-api-adaptor) use this to interact with Web API created under OData standards. The WebApiAdaptor is extended from the ODataAdaptor. Hence to use WebApiAdaptor, the endpoint should understand the OData formatted queries sent along with request. 

{% highlight cshtml %}

{% include_relative code-snippet/data-binding/web-api-adaptor.razor %}

{% endhighlight %}

![Blazor DropdownList with Web API Adaptor](./images/data-binding/blazor_dropdown_web-api-adaptor.png)

### Custom Adaptor

The [SfDataManager](https://help.syncfusion.com/cr/aspnetcore-blazor/Syncfusion.Blazor.Data.SfDataManager.html) has custom adaptor support which allows you to perform manual operations on the data. This can be utilized for implementing custom data binding and editing operations in the DropDownList component.

For implementing custom data binding in DropDownList, the `DataAdaptor` class is used. This abstract class acts as a base class for the custom adaptor.

The `DataAdaptor` abstract class has both synchronous and asynchronous method signatures which can be overridden in the custom adaptor. Following are the method signatures present in this class,

```csharp
public abstract class DataAdaptor
{
    /// <summary>
    /// Performs data Read operation synchronously.
    /// </summary>
    public virtual object Read(DataManagerRequest dataManagerRequest, string key = null)

    /// <summary>
    /// Performs data Read operation asynchronously.
    /// </summary>
    public virtual Task<object> ReadAsync(DataManagerRequest dataManagerRequest, string key = null)
}
```

The custom data binding can be performed in the DropDownList component by providing the custom adaptor class and overriding the Read or ReadAsync method of the DataAdaptor abstract class.

The following sample code demonstrates implementing custom data binding using custom adaptor,

{% highlight cshtml %}

{% include_relative code-snippet/data-binding/custom-adaptor.razor %}

{% endhighlight %}

### Offline mode

To avoid post back for every action, set the DropDownList to load all data on initialization and make the actions process in client-side. To enable this behaviour, use the `Offline` property of `DataManager`.

The following example for remote data binding and enabled offline mode.

{% highlight cshtml %}

{% include_relative code-snippet/data-binding/offline-mode.razor %}

{% endhighlight %}

![Blazor DropdownList with Offline mode](./images/data-binding/blazor_dropdown_offline-mode.png)

### Entity Framework

You need to follow the below steps to consume data from the [Entity Framework](https://blazor.syncfusion.com/documentation/common/data-binding/bind-entity-framework) in the DropDownList component.

#### Create DBContext class

The first step is to create a DBContext class called **OrderContext** to connect to a Microsoft SQL Server database.

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

Now, you need to create a class named **OrderDataAccessLayer**, which act as data access layer for retrieving the records from the database table.

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

#### Creating Web API Controller

 A Web API Controller has to be created which allows DropDownList directly to consume data from the Entity framework.

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

### Configure DropDownList component using Web API adaptor

Now, you can configure the DropDownList using the [SfDataManager](https://blazor.syncfusion.com/documentation/data/getting-started) to interact with the created Web API and consume the data appropriately. To interact with web api, you need to use [WebApiAdaptor](https://blazor.syncfusion.com/documentation/data/adaptors#web-api-adaptor).

{% highlight cshtml %}

{% include_relative code-snippet/data-binding/dropdown-with-web-api-adaptor.razor %}

{% endhighlight %}

You can add the new item in the popup with help of using [AddItemsAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownBase-1.html#Syncfusion_Blazor_DropDowns_SfDropDownBase_1_AddItemsAsync_System_Collections_Generic_IEnumerable__0__System_Nullable_System_Int32__) public method. This method will add a mentioned item in the DropDownList popup without affecting the data source items.

{% highlight cshtml %}

{% include_relative code-snippet/data-binding/add-new-item.razor %}

{% endhighlight %}

![Blazor DropdownList with adding new Item](./images/data-binding/blazor_dropdown_add-new-item.png)

