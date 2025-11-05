---
layout: post
title: Data Binding in Blazor DropDown List Component | Syncfusion
description: Checkout and learn here all about Data Binding in Syncfusion Blazor DropDown List component and more.
platform: Blazor
control: DropDown List
documentation: ug
---

# Data Binding in Dropdown List

The DropDownList loads the data either from the local data sources or remote data services. Using the [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownBase-1.html#Syncfusion_Blazor_DropDowns_SfDropDownBase_1_DataSource) property,  bind the local data or using the [DataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html), bind the remote data.

* **TItem** - Specifies the type of the datasource of the dropdown component.

## Binding local data

The DropDownList loads the data from local data sources through the [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownBase-1.html#Syncfusion_Blazor_DropDowns_SfDropDownBase_1_DataSource) property. It supports the data type of `Array of primitive type`, `Array of object`, `List of primitive type`,`List of object`, `Observable Collection`, `ExpandoObject`, `DynamicObject`.

{% highlight cshtml %}

{% include_relative code-snippet/data-binding/local-data-binding.razor %}

{% endhighlight %}

![Blazor DropdownList with local data binding](./images/data-binding/blazor_dropdown_local-binding.png)

### DataBound event

The [DataBound](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.DropDownListEvents-2.html#Syncfusion_Blazor_DropDowns_DropDownListEvents_2_DataBound) event triggers when the data source is populated in the popup list.

{% highlight cshtml %}

{% include_relative code-snippet/data-binding/data-bound.razor %}

{% endhighlight %}

### Primitive type

Bind the data to the DropDownList as an array or list of the `string`, `int`, `double` and `bool` type items.

The following code demonstrates array of string values to the DropDownList component.

{% highlight cshtml %}

{% include_relative code-snippet/data-binding/primitive-type-string.razor %}

{% endhighlight %}

![Blazor DropdownList with Primitive string type](./images/data-binding/blazor_dropdown_primitive-type-string.png)

The following code demonstrates array of integer values to the DropDownList component.

{% highlight cshtml %}

{% include_relative code-snippet/data-binding/primitive-type-int.razor %}

{% endhighlight %}

![Blazor DropdownList with Primitive int type](./images/data-binding/blazor_dropdown_primitive-type-int.png)

### Complex data type

The DropDownList can generate its list items through an array of complex data. For this, the appropriate columns should be mapped to the [Fields](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.FieldSettingsModel.html) property.

In the following example, the `Code.ID` column and `Country.CountryID` column from complex data have been mapped to the [DropDownListFieldSettings.Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.FieldSettingsModel.html#Syncfusion_Blazor_DropDowns_FieldSettingsModel_Value) and  [DropDownListFieldSettings.Text](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.FieldSettingsModel.html#Syncfusion_Blazor_DropDowns_FieldSettingsModel_Text) respectively.

{% highlight cshtml %}

{% include_relative code-snippet/data-binding/complex-data-type.razor %}

{% endhighlight %}

![Blazor DropdownList with Complex data type](./images/data-binding/blazor_dropdown_complex-data-type.png)

### Expando object binding

Bind the [ExpandoObject](https://learn.microsoft.com/en-us/dotnet/api/system.dynamic.expandoobject?view=net-8.0) data to the DropDownList component. In the following example, the `ExpandoObject` is bound to the collection of vehicles data.

{% highlight cshtml %}

{% include_relative code-snippet/data-binding/expando-object-binding.razor %}

{% endhighlight %}

![Blazor DropdownList with Expando object binding](./images/data-binding/blazor_dropdown_expando-object-binding.png)

### Observable collection binding

Bind the [ObservableCollection](https://blazor.syncfusion.com/documentation/common/data-binding/data-updates#observable-collection) data to the DropDownList component. In the following example, the `Observable Data` is bound to a collection of colors data.

{% highlight cshtml %}

{% include_relative code-snippet/data-binding/observable-collection-binding.razor %}

{% endhighlight %}

![Blazor DropdownList with Observable collection binding](./images/data-binding/blazor_dropdown_observable-collection-binding.png)

### Dynamic object binding

Bind the [DynamicObject](https://learn.microsoft.com/en-us/dotnet/api/system.dynamic.dynamicobject?view=net-8.0) data to the DropDownList component. In the following example, the `DynamicObject` is bound to the collection of customer data.

{% highlight cshtml %}

{% include_relative code-snippet/data-binding/dynamic-object-binding.razor %}

{% endhighlight %}

![Blazor DropdownList with Dynamic object binding](./images/data-binding/blazor_dropdown_dynamic-data-binding.png)

### Enum data binding

Bind the enum data to the DropDownList component. The following code helps you to get a description value from the enumeration data.

{% highlight cshtml %}

{% include_relative code-snippet/data-binding/enum-data-binding.razor %}

{% endhighlight %}

![Blazor DropdownList with Enum data binding](./images/data-binding/blazor_dropdown_enum-data-binding.png)

### ValueTuple data binding

Bind the [ValueTuple](https://learn.microsoft.com/en-us/dotnet/api/system.valuetuple-2?view=net-8.0) data to the DropDownList component. The following code helps you to get a string value from the enumeration data by using `ValueTuple`

{% highlight cshtml %}

{% include_relative code-snippet/data-binding/value-tuple-data-binding.razor %}

{% endhighlight %}

![Blazor DropdownList with ValueTuple data binding](./images/data-binding/blazor_dropdown_value-tuple-data-binding.png)

## Binding remote data 

The DropDownList loads the data from remote data services through the [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownBase-1.html#Syncfusion_Blazor_DropDowns_SfDropDownBase_1_DataSource) property. 

The DropDownList supports the retrieval of data from the remote data services with the help of the [DataManager](https://blazor.syncfusion.com/documentation/data/getting-started) control. The [Query](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownBase-1.html#Syncfusion_Blazor_DropDowns_SfDropDownBase_1_Query) property is used to fetch data from the database and bind it to the DropDownList.

* [DataManager.Url](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html#Syncfusion_Blazor_DataManager_Url) - Defines the service endpoint to fetch data.
* [DataManager.Adaptor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html#Syncfusion_Blazor_DataManager_Adaptor) - Defines the adaptor option. By default, the [ODataAdaptor](https://blazor.syncfusion.com/documentation/data/adaptors#odata-adaptor) is used for remote binding. The adaptor is responsible for processing responses and requests from or to the service endpoint. 
* [Syncfusion.Blazor.Data](https://www.nuget.org/packages/Syncfusion.Blazor.Data/) package provides some predefined adaptors that are designed to interact with particular service endpoints.

### OnActionBegin event

The [OnActionBegin](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.DropDownListEvents-2.html#Syncfusion_Blazor_DropDowns_DropDownListEvents_2_OnActionBegin) event triggers before fetching data from the remote server.

{% highlight cshtml %}

{% include_relative code-snippet/data-binding/action-begin.razor %}

{% endhighlight %}

### OnActionComplete event

The [OnActionComplete](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.DropDownListEvents-2.html#Syncfusion_Blazor_DropDowns_DropDownListEvents_2_OnActionComplete) event triggers after data is fetched successfully from the remote server.

{% highlight cshtml %}

{% include_relative code-snippet/data-binding/action-complete.razor %}

{% endhighlight %}

### OnActionFailure event

The [OnActionFailure](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.DropDownListEvents-2.html#Syncfusion_Blazor_DropDowns_DropDownListEvents_2_OnActionFailure) event triggers when the data fetch request from the remote server fails.

{% highlight cshtml %}

{% include_relative code-snippet/data-binding/action-failure.razor %}

{% endhighlight %}

### OData v4 services

The [OData v4 Adaptor](https://blazor.syncfusion.com/documentation/data/adaptors#odatav4-adaptor) provides the ability to consume and manipulate data from OData v4 services. The following sample displays the first six customer details from `Customers` table of the `Northwind` Data Service.

{% highlight cshtml %}

{% include_relative code-snippet/data-binding/odata-v4-services.razor %}

{% endhighlight %}

![Blazor DropdownList with OData v4 Adaptor](./images/data-binding/blazor_dropdown_odata-v4-services.png)

### Web API adaptor

The [Web API Adaptor](https://blazor.syncfusion.com/documentation/data/adaptors#web-api-adaptor) is used to interact with Web API created under OData standards. The `WebApiAdaptor` is extended from the [ODataAdaptor](https://blazor.syncfusion.com/documentation/data/adaptors#odata-adaptor). Hence to use the `WebApiAdaptor`, the endpoint should understand the OData formatted queries sent along with the request. 

{% highlight cshtml %}

{% include_relative code-snippet/data-binding/web-api-adaptor.razor %}

{% endhighlight %}

![Blazor DropdownList with Web API Adaptor](./images/data-binding/blazor_dropdown_web-api-adaptor.png)

### Custom adaptor

The [SfDataManager](https://help.syncfusion.com/cr/aspnetcore-blazor/Syncfusion.Blazor.Data.SfDataManager.html) has custom adaptor support which allows you to perform manual operations on the data. This can be utilized for implementing customize data binding and editing operations in the DropDownList component.

For implementing custom data binding in the DropDownList, the `DataAdaptor` class is used. This abstract class acts as a base class for the custom adaptor.

The `DataAdaptor` abstract class has both synchronous and asynchronous method signatures, which can be overridden in the custom adaptor. Following are the method signatures present in this class.

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

In custom Adaptor, the data binding operation can be performed in the DropDownList component by providing the custom adaptor class and overriding the Read or ReadAsync method of the DataAdaptor abstract class.

The following sample code demonstrates implementing custom data binding using custom adaptor.

{% highlight cshtml %}

{% include_relative code-snippet/data-binding/custom-adaptor.razor %}

{% endhighlight %}

### Offline mode

To avoid post back for every action, set the DropDownList to load all data on initialization and make the actions process on the client-side. To enable this behavior, use the `Offline` property of `DataManager`.

The following example is for remote data binding and enabled offline mode.

{% highlight cshtml %}

{% include_relative code-snippet/data-binding/offline-mode.razor %}

{% endhighlight %}

![Blazor DropdownList with Offline mode](./images/data-binding/blazor_dropdown_offline-mode.png)

### Entity Framework

Follow these steps to consume data from the [Entity Framework](https://blazor.syncfusion.com/documentation/common/data-binding/bind-entity-framework) in the DropDownList component.

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

 A Web API Controller has to be created, which allows the DropDownList to directly consume data from the Entity Framework.

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

Now, configure the DropDownList using the [SfDataManager](https://blazor.syncfusion.com/documentation/data/getting-started) to interact with the created Web API and consume the data appropriately. To interact with web API, use the [WebApiAdaptor](https://blazor.syncfusion.com/documentation/data/adaptors#web-api-adaptor).

{% highlight cshtml %}

{% include_relative code-snippet/data-binding/dropdown-with-web-api-adaptor.razor %}

{% endhighlight %}

## Adding new items

Add the new item in the popup with the help of [AddItemsAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownBase-1.html#Syncfusion_Blazor_DropDowns_SfDropDownBase_1_AddItemsAsync_System_Collections_Generic_IEnumerable__0__System_Nullable_System_Int32__) public method. This method will add a mentioned item in the DropDownList popup without affecting the data source items.

{% highlight cshtml %}

{% include_relative code-snippet/data-binding/add-new-item.razor %}

{% endhighlight %}

![Blazor DropdownList with adding new Item](./images/data-binding/blazor_dropdown_add-new-item.png)

## Getting datasource of dropdown list

### Getting datasource using instance

To retrieve the data source from a Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DropDownList component, you can access the `DataSource` property of the component instance. An example of how this can be done is by binding the component to a list of objects as its data source and then, in the button click event, calling the `GetDataSource` method which in turn retrieves the data source by accessing the DataSource property of the DropDownList instance.

{% highlight cshtml %}

{% include_relative code-snippet/data-binding/get-datasource.razor %}

{% endhighlight %}

### Getting datasource using variable

To obtain the data source for a Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DropDownList using a variable, you can define a variable in your component to hold the data source, and then use this variable to access the data source. In this example, the `GetDataSource` method is triggered when the button is clicked. This method retrieves the data source for the DropDownList by accessing the Countries variable, which holds the list of countries for the DropDownList.

{% highlight cshtml %}

{% include_relative code-snippet/data-binding/get-datasource-variable.razor %}

{% endhighlight %}

