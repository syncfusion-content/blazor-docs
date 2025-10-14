---
layout: post
title: Data Source in Blazor ComboBox Component | Syncfusion
description: Checkout and learn here all about Data Source in Syncfusion Blazor ComboBox component and much more.
platform: Blazor
control: ComboBox
documentation: ug
---

# Data Source in Blazor ComboBox Component

The ComboBox loads the data either from local data sources or remote data services using the [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownBase-1.html#Syncfusion_Blazor_DropDowns_SfDropDownBase_1_DataSource) property. It supports the data type of `array` or [DataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html).

The ComboBox also supports different kinds of data services such as OData, OData V4, and Web API, and data formats such as XML, JSON, and JSONP with the help of [DataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html) adaptors.

| Fields | Type | Description |
|------|------|-------------|
| Text |  `string` | Specifies the display text of each list item. |
| Value |  `int or string` | Specifies the hidden data value mapped to each list item; the type is determined by the component’s TValue and should be unique. |
| GroupBy |  `string` | Specifies the category under which the list item is grouped. |
| IconCss |  `string` | Specifies the icon CSS class for each list item. |

N> When binding complex data to the ComboBox, fields must be mapped correctly. Otherwise, the selected item remains undefined.

## Binding local data

Local data can be represented in two ways as described below.

### Array of JSON data

The ComboBox can generate its list items from an array or list of objects. Map the appropriate properties to the [Fields](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.FieldSettingsModel.html) property.

In the following example, the Name property is mapped to the Text field and the Code property is mapped to the Value field.

```cshtml
@using Syncfusion.Blazor.DropDowns

<SfComboBox TValue="string" TItem="Country" Placeholder="e.g. Australia" DataSource="@Countries">
    <ComboBoxFieldSettings Text="Name" Value="Code"></ComboBoxFieldSettings>
</SfComboBox>

@code {

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
        new Country() { Name = "Denmark", Code = "DK" },
        new Country() { Name = "France", Code = "FR" },
        new Country() { Name = "Finland", Code = "FI" },
        new Country() { Name = "Germany", Code = "DE" },
        new Country() { Name = "Greenland", Code = "GL" },
        new Country() { Name = "Hong Kong", Code = "HK" },
        new Country() { Name = "India", Code = "IN" },
        new Country() { Name = "Italy", Code = "IT" },
        new Country() { Name = "Japan", Code = "JP" },
        new Country() { Name = "Mexico", Code = "MX" },
        new Country() { Name = "Norway", Code = "NO" },
        new Country() { Name = "Poland", Code = "PL" },
        new Country() { Name = "Switzerland", Code = "CH" },
        new Country() { Name = "United Kingdom", Code = "GB" },
        new Country() { Name = "United States", Code = "US" },
    };
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VXBKsLLcKnxcdvLv?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Binding Blazor ComboBox Items](./images/blazor-combobox-binding-items.png)

### Array of complex data

The ComboBox can generate its list items from complex objects. Map nested properties to the [Fields](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.FieldSettingsModel.html) by using dot notation.

In the following example, Code.ID is mapped to the Value field and Country.CountryID is mapped to the Text field.

```cshtml
@using Syncfusion.Blazor.DropDowns

<SfComboBox TValue="string" DataSource="@LocalData" TValue="string" TItem="Complex" Placeholder="e.g. Select a Country">
    <ComboBoxFieldSettings Text="Country.CountryID" Value="Code.ID"></ComboBoxFieldSettings>
</SfComboBox>

@code {

public IEnumerable<Complex> LocalData { get; set; } = new Complex().GetData();

    public class Code
    {
        public string ID { get; set; }
    }

    public class Country
    {
        public string CountryID { get; set; }
    }

    public class Complex
    {
        public Country Country { get; set; }
        public Code Code { get; set; }
        public List<Complex>GetData() {
             List<Complex>Data = new List<Complex>();
            Data.Add(new Complex() { Country = new Country() { CountryID = "Australia" }, Code = new Code() { ID = "AU" } });
            Data.Add(new Complex() { Country = new Country() { CountryID = "Bermuda" }, Code = new Code() { ID = "BM" } });
            Data.Add(new Complex() { Country = new Country() { CountryID = "Canada" }, Code = new Code() { ID = "CA" } });
            Data.Add(new Complex() { Country = new Country() { CountryID = "Cameroon" }, Code = new Code() { ID = "CM" } });
            Data.Add(new Complex() { Country = new Country() { CountryID = "Denmark" }, Code = new Code() { ID = "DK" } });
            Data.Add(new Complex() { Country = new Country() { CountryID = "France" }, Code = new Code() { ID = "FR" } });
            return Data;
         }
     }
}
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/rZrqiLVwKHwhTfxb?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Binding Complex Items with Blazor ComboBox](./images/blazor-combobox-complex-data.png)

## Binding remote data

The ComboBox supports retrieval of data from remote data services with the help of [DataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownBase-1.html#Syncfusion_Blazor_DropDowns_SfDropDownBase_1_Query) property, which is used to fetch data from the database and bind it to the ComboBox.

In the following sample, the first six records are retrieved from the Orders entity of the Northwind OData V4 service and display CustomerID as text and OrderID as value.

```cshtml
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.DropDowns

<SfComboBox TValue="string" TItem="OrderDetails" Placeholder="Select a customer" Query="@Query">
    <SfDataManager Url="https://services.odata.org/V4/Northwind/Northwind.svc/Orders" Adaptor="Adaptors.ODataV4Adaptor" CrossDomain=true></SfDataManager>
    <ComboBoxFieldSettings Text="CustomerID" Value="OrderID"></ComboBoxFieldSettings>
</SfComboBox>

@code {
    public Query Query = new Query().Select(new List<string> { "CustomerID", "OrderID" }).Take(6).RequiresCount();

    public class OrderDetails
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public int? EmployeeID { get; set; }
        public double? Freight { get; set; }
        public string ShipCity { get; set; }
        public bool Verified { get; set; }
        public DateTime? OrderDate { get; set; }
        public string ShipName { get; set; }
        public string ShipCountry { get; set; }
        public DateTime? ShippedDate { get; set; }
        public string ShipAddress { get; set; }
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VthUChrmAnbDTsys?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor ComboBox with Data Binding](./images/blazor-combobox-binding-data.png)

### Web API Adaptor

Use the WebApiAdaptor to bind the ComboBox to a Web API endpoint (including services built with OData).

```cshtml
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.DropDowns

<SfComboBox TValue="string" TItem="EmployeeData" Placeholder="Select a Employee" Query="@Query">
    <SfDataManager Url="https://ej2services.syncfusion.com/production/web-services/api/Employees" Adaptor="Adaptors.WebApiAdaptor" CrossDomain=true></SfDataManager>
    <ComboBoxFieldSettings Text="FirstName" Value="EmployeeID"></ComboBoxFieldSettings>
</SfComboBox>

@code {
    public Query Query = new Query();

    public class EmployeeData
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string Designation { get; set; }
        public string Country { get; set; }
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/hjBgiVLwKnloDWBQ?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor ComboBox with Web API Data](./images/blazor-combobox-web-api-data.png)

### Custom adaptor

The [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html) supports custom adaptors, which allow performing manual operations on the data. This is useful for implementing custom data binding and editing operations in the ComboBox component.

For custom data binding in the ComboBox, the DataAdaptor class is used as the base class for a custom adaptor.

The DataAdaptor abstract class provides synchronous and asynchronous methods that can be overridden in the custom adaptor. The following methods are available:

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

Custom data binding can be performed by providing the custom adaptor class and overriding the Read or ReadAsync method of the DataAdaptor abstract class.

The following sample demonstrates implementing custom data binding using a custom adaptor:

```cshtml
<SfComboBox TValue="string" TItem="Orders">
    <SfDataManager AdaptorInstance="@typeof(CustomAdaptor)" Adaptor="Adaptors.CustomAdaptor"></SfDataManager>
    <ComboBoxFieldSettings Value="CustomerID"></ComboBoxFieldSettings>
</SfComboBox>

@code{

    public class Orders
    {
        public Orders() { }
        public Orders(int OrderID, string CustomerID)
        {
            this.OrderID = OrderID;
            this.CustomerID = CustomerID;
        }
        public int OrderID { get; set; }
        public string CustomerID { get; set; }
    }

    public class CustomAdaptor : DataAdaptor
    {
        static readonly HttpClient client = new HttpClient();
        public static List<OrdersDetails> order = OrdersDetails.GetAllRecords();
        
        public override object Read(DataManagerRequest dm, string key = null)
        {
            IEnumerable<OrdersDetails> DataSource = order;
            if (dm.Search != null && dm.Search.Count > 0)
            {
                DataSource = DataOperations.PerformSearching(DataSource, dm.Search);  //Search
            }
            if (dm.Sorted != null && dm.Sorted.Count > 0) //Sorting
            {
                DataSource = DataOperations.PerformSorting(DataSource, dm.Sorted);
            }
            if (dm.Where != null && dm.Where.Count > 0) //Filtering
            {
                DataSource = DataOperations.PerformFiltering(DataSource, dm.Where, dm.Where[0].Operator);
            }
            int count = DataSource.Cast<OrdersDetails>().Count();
            if (dm.Skip != 0)
            {
                DataSource = DataOperations.PerformSkip(DataSource, dm.Skip);         //Paging
            }
            if (dm.Take != 0)
            {
                DataSource = DataOperations.PerformTake(DataSource, dm.Take);
            }
            return dm.RequiresCounts ? new DataResult() { Result = DataSource, Count = count } : (object)DataSource;
       }
    }
}
```

### Offline mode

To avoid a server round trip for every action, load all data during initialization and process subsequent actions on the client. Enable this behavior by setting the Offline property on the [DataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html).

The following example demonstrates remote data binding with offline mode enabled:

```cshtml
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.DropDowns

<SfComboBox TValue="string" TItem="EmployeeData" Placeholder="Select a Employee" Query="@Query">
    <SfDataManager Url="https://ej2services.syncfusion.com/production/web-services/api/Employees" Offline=true Adaptor="Adaptors.WebApiAdaptor" CrossDomain=true></SfDataManager>
    <ComboBoxFieldSettings Text="FirstName" Value="EmployeeID"></ComboBoxFieldSettings>
</SfComboBox>

@code {
    public Query Query = new Query();

    public class EmployeeData
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string Designation { get; set; }
        public string Country { get; set; }
    }
}
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/LtBACrBQKGCrmiJb?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor ComboBox using offline mode with Web API data](./images/blazor-combobox-web-api-data.png)

### ValueTuple data binding

Bind [ValueTuple](https://learn.microsoft.com/en-us/dotnet/api/system.valuetuple-2?view=net-8.0) data to the ComboBox component. The following code helps you to get a string value from the enumeration data by using [ValueTuple](https://learn.microsoft.com/en-us/dotnet/api/system.valuetuple-2?view=net-8.0).

```csharp

@using Syncfusion.Blazor.DropDowns;

<SfComboBox TItem="(DayOfWeek, string)" Width="250px" TValue="DayOfWeek"
            DataSource="@(Enum.GetValues<DayOfWeek>().Select(e => (e, e.ToString())))">
    <ComboBoxFieldSettings Value="Item1" Text="Item2" />
</SfComboBox>

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/rDrKihrcgcMdJUXG?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor ComboBox bound using ValueTuple for enum display/value](./images/blazor_combobox_valuetuple.png)

## Binding ExpandoObject

Bind [ExpandoObject](https://learn.microsoft.com/en-us/dotnet/api/system.dynamic.expandoobject?view=net-8.0) data to the ComboBox component. The following example `ExpandoObject` is bound to the collection of vehicles data.

```csharp

@using Syncfusion.Blazor.DropDowns
@using System.Dynamic

<SfComboBox TItem="ExpandoObject" TValue="string" PopupHeight="230px" Placeholder="Select a vehicle" DataSource="@VehicleData">
    <ComboBoxFieldSettings Text="Text" Value="ID"></ComboBoxFieldSettings>
</SfComboBox>

@code{
    public List<ExpandoObject> VehicleData { get; set; } = new List<ExpandoObject>();
    protected override void OnInitialized()
    {
        VehicleData = Enumerable.Range(1, 15).Select((x) =>
        {
            dynamic d = new ExpandoObject();
            d.ID = (1000 + x).ToString();
            d.Text = (new string[] { "Hennessey Venom", "Bugatti Chiron", "Bugatti Veyron Super Sport", "SSC Ultimate Aero", "Koenigsegg CCR", "McLaren F1", "Aston Martin One- 77", "Jaguar XJ220", "McLaren P1", "Ferrari LaFerrari", "Mahindra Jaguar", "Hyundai Toyota", "Jeep Volkswagen", "Tata Maruti Suzuki", "Audi Mercedes Benz" }[x - 1]);
            return d;
        }).Cast<ExpandoObject>().ToList<ExpandoObject>();
    }
}

```

![Blazor ComboBox with expando object data binding](./images/blazor_combobox_expando-object.png)

## Binding DynamicObject

Bind [DynamicObject](https://learn.microsoft.com/en-us/dotnet/api/system.dynamic.dynamicobject?view=net-8.0) data to the ComboBox component. The following example `DynamicObject` is bound to the collection of customers data.

```csharp

@using Syncfusion.Blazor.DropDowns
@using System.Dynamic

<SfComboBox TValue="string" TItem="DynamicDictionary" Placeholder="Select a name" DataSource="@Orders">
    <ComboBoxFieldSettings Text="CustomerName" Value="CustomerName"></ComboBoxFieldSettings>
</SfComboBox>

@code{
    public List<DynamicDictionary> Orders = new List<DynamicDictionary>() { };
    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 15).Select((x) =>
        {
            dynamic d = new DynamicDictionary();
            d.OrderID = 1000 + x;
            d.CustomerName = (new string[] { "Nancy", "Andrew", "Janet", "Margaret", "Steven", "Michael", "Robert", "Anne", "Nige", "Fuller", "Dodsworth", "Leverling", "Callahan", "Suyama", "Davolio" }[x - 1]);
            return d;
        }).Cast<DynamicDictionary>().ToList<DynamicDictionary>();
    }
    public class DynamicDictionary : System.Dynamic.DynamicObject
    {
        Dictionary<string, object> dictionary = new Dictionary<string, object>();
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            string name = binder.Name;
            return dictionary.TryGetValue(name, out result);
        }
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            dictionary[binder.Name] = value;
            return true;
        }
        //The GetDynamicMemberNames method of DynamicObject class must be overridden and return the property names to perform data operation and editing while using DynamicObject.
        public override System.Collections.Generic.IEnumerable<string> GetDynamicMemberNames()
        {
            return this.dictionary?.Keys;
        }
    }
}

```

![Blazor ComboBox bound to DynamicObject data](./images/blazor_combobox_dynamic-object.png)

## Binding ObservableCollection

Bind [ObservableCollection](https://learn.microsoft.com/en-us/dotnet/api/system.collections.objectmodel.observablecollection-1?view=net-8.0) data to the ComboBox component. The following example `Observable Data` is bound to a collection of colors data.

```csharp

@using Syncfusion.Blazor.DropDowns
@using System.Collections.ObjectModel;

<SfComboBox TValue="string" TItem="Colors" PopupHeight="230px" Placeholder="Select a color" DataSource="@ColorsData">
    <ComboBoxFieldSettings Text="Color" Value="Code"></ComboBoxFieldSettings>
</SfComboBox>

@code{
    public class Colors
    {
        public string Code { get; set; }
        public string Color { get; set; }
    }
    private ObservableCollection<Colors> ColorsData = new ObservableCollection<Colors>()
    {
        new Colors() { Color = "Chocolate", Code = "#75523C" },
        new Colors() { Color = "CadetBlue", Code = "#3B8289" },
        new Colors() { Color = "DarkOrange", Code = "#FF843D" },
        new Colors() { Color = "DarkRed", Code = "#CA3832"},
        new Colors() { Color = "Fuchsia", Code = "#D44FA3" },
        new Colors() { Color = "HotPink", Code = "#F23F82" },
        new Colors() { Color = "Indigo", Code = "#2F5D81" },
        new Colors() { Color = "LimeGreen", Code = "#4CD242" },
        new Colors() { Color = "OrangeRed", Code = "#FE2A00" },
        new Colors() { Color = "Tomato", Code = "#FF745C" },
        new Colors() { Color = "Brown", Code = "#A52A2A" },
        new Colors() { Color = "Maroon", Code = "#800000" },
        new Colors() { Color = "Green", Code = "#008000" },
        new Colors() { Color = "Pink", Code = "#FFC0CB" },
        new Colors() { Color = "Purple", Code = "#800080" }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/hDBgCBVcAmhLLFOi?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}


![Blazor ComboBox bound to an ObservableCollection of colors](./images/blazor_combobox_observable-collection.png)

## Entity Framework

You need to follow the below steps to consume data from the **Entity Framework** in the ComboBox component.

### Create DBContext class

The first step is to create a DbContext class called **OrderContext** to connect to a Microsoft SQL Server database.

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

### Create data access layer to perform data operation

Now, create a class named **OrderDataAccessLayer**, which acts as the data access layer for retrieving records from the database table.

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

### Creating Web API Controller

Create a Web API controller to allow the ComboBox to consume data from Entity Framework directly.

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

### Configure ComboBox component using Web API adaptor

Now, configure the ComboBox using the **SfDataManager** to interact with the created Web API and consume data. To interact with a Web API, use WebApiAdaptor.

```cshtml
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.DropDowns

<SfComboBox TValue="string" TItem="Order" Placeholder="Select a Country">
    <SfDataManager Url="api/Default" Adaptor="Adaptors.WebApiAdaptor" CrossDomain="true"></SfDataManager>
    <ComboBoxFieldSettings Text="ShipCountry" Value="OrderID"></ComboBoxFieldSettings>
</SfComboBox>

@code{
    public class Order
    {
        public int? OrderID { get; set; }
        public string ShipCountry { get; set; }
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BjBqiBLcAGhEHVHQ?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Configure cascading in the Blazor ComboBox component

To get started quickly with cascading in the Blazor ComboBox component, you can check the video below.

{% youtube "https://www.youtube.com/watch?v=zGGntfBPQNI" %}