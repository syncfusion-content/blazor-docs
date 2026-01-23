---
layout: post
title: SQL server data binding and performing CRUD operations | Syncfusion
description: Learn about consuming data from SQL Server using Microsoft SQL Client, binding it to Syncfusion Component, and performing CRUD operations
platform: Blazor
component: DataGrid component and DataManager
documentation: ug
---

# SQL server data binding and performing CRUD operations

## Introduction

This topic explains how to retrieve data from a [SQL Server](https://learn.microsoft.com/en-us/sql/sql-server/?view=sql-server-ver15) database using Microsoft SQL Client, bind it to a Syncfusion® Blazor DataGrid component, and perform CRUD operations. The approach uses a custom adaptor and manual API integration to support flexible data access and editing workflows.

## Prerequisite software

The following software are needed:

* Microsoft.EntityFrameworkCore.SqlServer (Nuget Package).
* Visual Studio 2026 or earlier
* .NET 10.0 or earlier versions.

## Create the database

Open Visual Studio, then navigate to **View → SQL Server Object Explorer.**
Right-click on the Databases folder and **select Add New Database**.
In the dialog box, enter the database name as OrdersDetails and click OK to create it.

![Add new database in Blazor](../images/odata-add-db.png)
![Adding database name and location in Blazor](../images/odata-db-name.png)

Right-click on the **Tables** folder of the OrdersDetails database and select **Add New Table**.


![Add table in Blazor](../images/odata-add-table.png)

Use the following SQL query to define a new table named **Orders** in the **OrdersDetails** database. This table will store basic order information including ID, customer reference, freight charges, and order date.


```
Create Table Orders(
 OrderID BigInt Identity(1,1) Primary Key Not Null,
 CustomerID Varchar(100) Not Null,
 Freight int Null,
 OrderDate datetime null
)
```

After executing the query, the Orders table schema will appear in the designer as shown in the snippet below.
Verify that the columns and data types are correctly defined, then click **Update** to apply the changes.

![Database table design in Blazor](../images/odata-table-design.png)

Now, select **Update Database** to confirm and create the table in the OrdersDetails database.

![Update database in Blazor](../images/odata-update-db.png)

## Creating Blazor Web App

Open Visual Studio and follow the standard steps to create a new Blazor Web App as per in the [documentation](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-8.0&pivots=windows).
During project setup, ensure that you configure the appropriate[Interactive render mode](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/render-modes?view=aspnetcore-8.0#render-modes) and [Interactivity location](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-8.0&pivots=windows) based on your application requirements.

### Generate model class and API services from the database

To work with the SQL Server database in your Blazor application, begin by installing the required NuGet packages.
If you’ve created a Blazor Web App with the Interactive render mode set to `WebAssembly` or `Auto`, follow these steps:

* Create a new project using the Class Library template and name it `BlazorWebApp.Shared` for model class and API services as shown below.

![Create Shared Project](../images/db-shared-project.png)

This shared project will contain your model classes and API service logic, and should be referenced by both the server-side and client-side projects of your Blazor Web App. 

* Next, open the NuGet Package Manager and install the following packages in both the shared and server-side projects of your Blazor Web App:
    * [Microsoft.EntityFrameworkCore.Tools](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Tools): This package enables scaffolding of database context and model classes from an existing database.
    * [Microsoft.EntityFrameworkCore.SqlServer](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.SqlServer/): Provides SQL Server support for Entity Framework Core.

Alternatively, you can utilize the following package manager command to achieve the same.

{% tabs %}
{% highlight C# tabtitle="Package Manager" %}

Install-Package Microsoft.EntityFrameworkCore.Tools

Install-Package Microsoft.EntityFrameworkCore.SqlServer

{% endhighlight %}
{% endtabs %}

* Once the above packages are installed, add the following classes to the `BlazorWebApp.Shared` project as like in below snip.
This shared project will contain both the model definitions and the client-side service logic used to interact with the SQL Server database.

![Create Client Side Services](../images/db-models-services.png)

{% tabs %}
{% highlight C# tabtitle="Order.cs" %}

public class Order
{
    public int? OrderID { get; set; }

    public string CustomerID { get; set; }

    public int? Freight { get; set; }

    public DateTime? OrderDate { get; set; }
}

{% endhighlight %}
{% highlight C# tabtitle="ClientServices.cs" %}

public class ClientServices
{
    private readonly HttpClient _httpClient;

    public ClientServices ( HttpClient httpClient )
    {
        _httpClient = httpClient;

    }

    public async Task<List<Order>> GetOrders (int skip, int take)
    {
        var apiUrl = $"https://localhost:7223/api/DataGrid?skip={skip}&take={take}";
        var result = await _httpClient.GetFromJsonAsync<List<Order>>(apiUrl);
        return result;
    }


    public async Task<object> InsertOrder ( object value)
    {
        string apiUrl = $"https://localhost:7223/api/DataGrid/";

        await _httpClient.PostAsJsonAsync<object>(apiUrl, value);
        return value;
    }
    public async Task<object> RemoveOrder ( object value )
    {
        await _httpClient.DeleteAsync($"https://localhost:7223/api/DataGrid/{value}");
        return value;
    }

    public async Task<object> UpdateOrder ( object value)
    {

            string apiUrl = $"https://localhost:7223/api/DataGrid/";
            await _httpClient.PutAsJsonAsync<object>(apiUrl, value);
            return value;
    }
    public async Task<int> GetOrderCountAsync ()
    {
        var response = await _httpClient.GetAsync("https://localhost:7223/api/DataGrid/OrderCount");

        if (response.IsSuccessStatusCode)
        {
            // Assuming the API returns an integer value for Order count
            int OrderCount = await response.Content.ReadFromJsonAsync<int>();
            return OrderCount;
        }
        else
        {
            // Handle the error response
            // You might want to return a default value or throw an exception
            return 0;
        }

    }
}

{% endhighlight %}
{% endtabs %}

Here, the `ClientServices` class will be responsible for interacting with the server-side API to perform operations such as retrieving data, inserting new records, removing existing records, and updating existing records. This ensures that all CRUD operations are handled in a centralized and reusable way within the shared project. 

* Additionally, make sure to register the `ClientServices` class in the `Program.cs` files of both the server-side and client-side projects so that it can be injected and accessed throughout the application lifecycle.

```
builder.Services.AddScoped<ClientServices>();
```
N> Ensure that you are using the correct localhost port number in the code snippets. The port number may vary depending on your environment and project configuration, so always verify it before running the application.

* Next, ensure that the `BaseUri` is added in the **appsettings.json** file of the server-side project of your Blazor Web App. This configuration is essential for defining the API endpoint that the client-side project will use to communicate with the server. By specifying the correct **BaseUri**, you enable seamless interaction between the client and server components, ensuring that all CRUD operations are routed properly through the configured API.

```
{
 // your app localhost
  "BaseUri": "https://localhost:7223",
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}

```
* Add the following code snippet in the **Program.cs** file of the server-side project to configure a scoped HttpClient with a base address. 

{% tabs %}
{% highlight c# tabtitle="~/Program.cs" %}

builder.Services.AddScoped(http => new HttpClient { BaseAddress = new Uri(builder.Configuration.GetSection("BaseUri").Value!) });

{% endhighlight %}
{% endtabs %}

* Next, create a new controller named `DataGridController` in the server-side application. This controller will be responsible for handling all CRUD (Create, Read, Update, and Delete) operations for the Order entity. By exposing endpoints through this controller, the client-side application can interact with the SQL Server database via API calls, ensuring that data retrieval, insertion, modification, and deletion are managed in a structured and centralized manner.

```cshtml
namespace BlazorWebApp.Controller
{

    [Route("api/[controller]")]
    [ApiController]
    public class DataGridController : ControllerBase
    {
        public static DataSet CreateCommand(string queryString, string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(
                       connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(queryString, connection);
                DataSet dt = new DataSet();
                try
                {
                    connection.Open();

                    // Using sqlDataAdapter, we process the query string and fill the data into the dataset

                    adapter.Fill(dt);
                }
                catch (SqlException se)
                {
                    Console.WriteLine(se.ToString());
                }
                finally
                {
                    connection.Close();
                }
                return dt;
            }
        }


        // GET: api/<DataGridController>
        [HttpGet]
        public async Task<ActionResult<List<Order>>> Get (int skip, int take)
        {

            string ConnectionStr = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\VIDEOTEAM\\BLAZOR UG\\IMPLEMENTATION\\BINDDATAUSINGSQL\\SERVERRENDERMODE\\APP_DATA\\NORTHWND.MDF;Integrated Security=True;Connect Timeout=30";

            // Here, we formed the SQL query string based on the skip and take count from the DataManagerRequest

            string QueryStr = "SELECT OrderID, CustomerID FROM dbo.Orders ORDER BY OrderID OFFSET " + skip + " ROWS FETCH NEXT " + take + " ROWS ONLY;";
            DataSet Data = CreateCommand(QueryStr, ConnectionStr);
            Orders = Data.Tables[0].AsEnumerable().Select(r => new Order
            {
                OrderID = r.Field<int>("OrderID"),
                CustomerID = r.Field<string>("CustomerID")
            }).ToList();  // Here, we convert dataset into list
            List<Order> DataSource = Orders;
            return (DataSource);
        }

        [HttpGet("OrderCount")]
        public async Task<ActionResult<int>> GetOrderCountAsync ()
        {
            string ConnectionStr = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\VIDEOTEAM\\BLAZOR UG\\IMPLEMENTATION\\BINDDATAUSINGSQL\\SERVERRENDERMODE\\APP_DATA\\NORTHWND.MDF;Integrated Security=True;Connect Timeout=30";

            SqlConnection Con = new SqlConnection(ConnectionStr);
            Con.Open();
            SqlCommand Cmd = new SqlCommand("SELECT COUNT(*) FROM dbo.Orders", Con);
            Int32 Count = (Int32)Cmd.ExecuteScalar();
            return Ok(Count);
        }
        // GET api/<DataGridController>/5
        [HttpGet("{id}")]
        public string Get ( int id )
        {
            return "value";
        }

        // POST api/<DataGridController>
        [HttpPost]
        public void Post([FromBody] object value)
        {
            Order order = Newtonsoft.Json.JsonConvert.DeserializeObject<Order>(value.ToString());
            string ConnectionStr = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\VIDEOTEAM\\BLAZOR UG\\IMPLEMENTATION\\BINDDATAUSINGSQL\\SERVERRENDERMODE\\APP_DATA\\NORTHWND.MDF;Integrated Security=True;Connect Timeout=30";
            string QueryStr = $"Insert into Orders(CustomerID) values('{order.CustomerID}')";
            SqlConnection Con = new SqlConnection(ConnectionStr);
            try
            {
                Con.Open();
                SqlCommand Cmd = new SqlCommand(QueryStr, Con);
                Cmd.ExecuteNonQuery();
            }
            catch (SqlException Exception)
            {
                Console.WriteLine(Exception.ToString());
            }
            finally
            {
                Con.Close();
            }

        }

        // PUT api/<DataGridController>/5
        [HttpPut]
        public void Put([FromBody] object value)
        {
            Order order = Newtonsoft.Json.JsonConvert.DeserializeObject<Order>(value.ToString());
            string ConnectionStr = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\VIDEOTEAM\\BLAZOR UG\\IMPLEMENTATION\\BINDDATAUSINGSQL\\SERVERRENDERMODE\\APP_DATA\\NORTHWND.MDF;Integrated Security=True;Connect Timeout=30";
            string QueryStr = $"Update Orders set CustomerID='{order.CustomerID}' where OrderID={order.OrderID}";
            SqlConnection Con = new SqlConnection(ConnectionStr);
            try
            {
                Con.Open();
                SqlCommand Cmd = new SqlCommand(QueryStr, Con);
                Cmd.ExecuteNonQuery();
            }
            catch (SqlException Exception)
            {
                Console.WriteLine(Exception.ToString());
            }
            finally
            {
                Con.Close();
            }

        }

        // DELETE api/<DataGridController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

            string ConnectionStr = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\VIDEOTEAM\\BLAZOR UG\\IMPLEMENTATION\\BINDDATAUSINGSQL\\SERVERRENDERMODE\\APP_DATA\\NORTHWND.MDF;Integrated Security=True;Connect Timeout=30";
            string QueryStr = $"Delete from Orders where OrderID={id}";
            SqlConnection Con = new SqlConnection(ConnectionStr);
            try
            {
                Con.Open();
                SqlCommand Cmd = new SqlCommand(QueryStr, Con);
                Cmd.ExecuteNonQuery();
            }
            catch (SqlException Exception)
            {
                Console.WriteLine(Exception.ToString());
            }
            finally
            {
                Con.Close();
            }

        }

    }

}

```
## Create Blazor Server Application

Open Visual Studio and follow the steps in the [documentation](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-visual-studio) to create the Blazor Server Application.

## Add Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid package

To add the **Blazor DataGrid** component in your application, open the NuGet Package Manager in Visual Studio (*Tools → NuGet Package Manager → Manage NuGet Packages for Solution*), then search for and install [Syncfusion.Blazor.Grid](https://www.nuget.org/packages/Syncfusion.Blazor.Grid/) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/).

If your Blazor Web App is configured to use `WebAssembly or Auto` render modes, make sure to install the Syncfusion® Blazor component NuGet packages within the client project as well. 

Alternatively, you can achieve the same by running the appropriate Package Manager Console commands to install the required packages directly.

{% tabs %}
{% highlight C# tabtitle="Package Manager" %}

Install-Package Syncfusion.Blazor.Grid -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.Themes -Version {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

N> Syncfusion®<sup style="font-size:70%">&reg;</sup> Blazor components are available on [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). For a complete list of available NuGet packages along with detailed information about each component, refer to the NuGet packages topic in the documentation.


Open **~/_Imports.razor** file and import the following namespace.

{% highlight razor %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Grids

{% endhighlight %}

Now, register the Syncfusion® Blazor service in the **~/Program.cs** file of your application to enable the use of Syncfusion components such as the DataGrid.

If you are working with a `Blazor Web App` configured to use `WebAssembly` or Auto (Server and WebAssembly) interactive render modes, make sure to register the Syncfusion®<sup style="font-size:70%">&reg;</sup>  Blazor service in both **~/Program.cs** files of your web app so that the components function correctly in both environments.

```cshtml

....
using Syncfusion.Blazor;
....
builder.Services.AddSyncfusionBlazor();
....

```

Themes provide life to components, and Syncfusion®<sup style="font-size:70%">&reg;</sup> Blazor offers different themes:

- Bootstrap5
- Material 3
- Tailwind CSS
- High Contrast
- Fluent

In this demo application, the latest theme will be used.

* For **.NET 8, .NET 9, and .NET 10** Blazor Web Apps using any render mode (Server, WebAssembly, or Auto), refer the stylesheet inside the `<head>` of **~/Components/App.razor**.

* For **Blazor WebAssembly applications**, refer the stylesheet inside the `<head>` element of **wwwroot/index.html** file.

{% highlight cshtml %}

<link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />

{% endhighlight %}

Also, Include the script reference at the end of the `<body>` of **~/Components/App.razor**(For Blazor Web App) or **Pages/_Host.cshtml** (for Blazor Server App) file as shown below:

```html
<body>
    ....
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
</body>
```
## Add Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid component to an application

In previous steps, you have successfully configured the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor package in the application. Now, you can add the grid component to the to the `.razor` page inside the `Pages` folder.

If the interactivity location in your Blazor Web App is set to `Per page/component`, make sure to define a render mode at the very top of the Razor page that includes the Syncfusion®<sup style="font-size:70%">&reg;</sup> Blazor component as follows:

{% tabs %}
{% highlight razor %}

@* Your App render mode define here *@
@rendermode InteractiveAuto

{% endhighlight %}
{% endtabs %}

{% tabs %}
{% highlight razor %}

<SfGrid TValue="Order"></SfGrid>

{% endhighlight %}
{% endtabs %}

## Binding SQL data to the Blazor DataGrid Component

Now, retrieve the SQL data from the SQL Server and bind it to the DataGrid component by using the Custom Adaptor feature. The Custom Adaptor can be implemented as a reusable component, allowing you to define how the grid interacts with the server-side API for fetching and manipulating data. For more details on creating and configuring a [Custom Adaptor](https://blazor.syncfusion.com/documentation/datagrid/connecting-to-adaptors/custom-adaptor), refer to the Grid [Custom Binding](https://blazor.syncfusion.com/documentation/datagrid/connecting-to-adaptors/custom-adaptor#data-binding) and [Custom Adaptor as Component](https://blazor.syncfusion.com/documentation/datagrid/connecting-to-adaptors/custom-adaptor) documentation. 

Once the adaptor is set up, you can define the grid columns using the [GridColumn](https://blazor.syncfusion.com/documentation/datagrid/columns) component. These columns specify how each field from the SQL data source is displayed in the DataGrid. The properties used in the column definitions and their usage are explained in the following section, along with sample code to illustrate the setup.

{% tabs %}
{% highlight razor tabtitle="Blazor Web App" %}

@* Your App render mode define here *@
@rendermode InteractiveAuto
@using BlazorWebApp.Shared.Data

<SfGrid @ref="Grid" TValue="Order" AllowPaging="true">
    <SfDataManager Adaptor="Adaptors.CustomAdaptor">
        <CustomAdaptorComponent></CustomAdaptorComponent>
    </SfDataManager>
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID"  IsIdentity="true" IsPrimaryKey="true" TextAlign="TextAlign.Right" Width="120">
        </GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>
@code{
    SfGrid<Order> Grid { get; set; }
    public static List<Order> Orders { get; set; }
}

{% endhighlight %}
{% highlight razor tabtitle="Blazor Server App" %}

<SfGrid @ref="Grid" TValue="Order" AllowPaging="true" >
    <SfDataManager Adaptor="Adaptors.CustomAdaptor">
        <CustomAdaptorComponent></CustomAdaptorComponent>
    </SfDataManager>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" IsIdentity="true" IsPrimaryKey="true" TextAlign="TextAlign.Right" Width="120">
        </GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>
@code{
    SfGrid<Order> Grid { get; set; }
    public static List<Order> Orders { get; set; }

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

 

* Based on this request, construct a SQL query string that incorporates the necessary logic for paging and execute it against the SQL Server database. Use SqlDataAdapter to retrieve the data, and apply its Fill method to populate a DataSet with the results of the SelectCommand. Once the dataset is populated, convert it into a List to make it compatible with the DataGrid’s data binding. 

* Return the response from the Read method as a Result and Count pair object, which allows the DataGrid to render the data and manage pagination accurately.


In the **Read** method of the custom adaptor component, you can access the grid’s action details—such as paging, filtering, and sorting—using the **DataManagerRequest** object.

* Based on the DataManagerRequest, form a SQL query string (to perform paging) and execute the SQL query. Retrieve the data from the database using SqlDataAdapter.

* The Fill method of the DataAdapter is used to populate a DataSet with the results of the SelectCommand of the DataAdapter, then convert the DataSet into the List.

* Return the response in Result and Count pair object in Read method to bind the data to the DataGrid.

{% tabs %}
{% highlight razor tabtitle="Blazor Web App" %}
[CustomAdaptorComponent.razor]
@using Newtonsoft.Json
@using BlazorWebApp.Shared.Data;
@using Microsoft.Data.SqlClient;
@using System.Data;
@using System.IO;
@using Microsoft.AspNetCore.Hosting;
@inherits DataAdaptor<Order>
@using BlazorWebApp.Shared.Services;

<CascadingValue Value="@this">
    @ChildContent
</CascadingValue>

@code {
    [Parameter]
    [JsonIgnore]
    public RenderFragment ChildContent { get; set; }



    ClientServices OrderDetails = new ClientServices(new HttpClient());
    public override async Task<object> ReadAsync ( DataManagerRequest dataManagerRequest, string key = null )
    {
        List<Order> orders = await OrderDetails.GetOrders(dataManagerRequest.Skip, dataManagerRequest.Take);
        int count = await OrderDetails.GetOrderCountAsync();
        return dataManagerRequest.RequiresCounts ? new DataResult() { Result = orders, Count = count } : count;
    }

}

{% endhighlight %}
{% highlight razor tabtitle="Blazor Server App" %}
[CustomAdaptorComponent.razor]
[CustomAdaptorComponent.razor]

@using Syncfusion.Blazor;
@using Syncfusion.Blazor.Data;
@using Newtonsoft.Json
@using static EFGrid.Pages.Index;
@using Microsoft.Data.SqlClient;
@using System.Data;
@using System.IO;
@using Microsoft.AspNetCore.Hosting;
@inject IHostingEnvironment _env

@inherits DataAdaptor<Order>

//Here, we are rendering the CustomAdaptorComponent as a child component for the SfDataManager
<CascadingValue Value="@this">
    @ChildContent
</CascadingValue>

@code {
[Parameter]
[JsonIgnore]
public RenderFragment ChildContent { get; set; }

public static DataSet CreateCommand(string queryString, string connectionString)
{
    using (SqlConnection connection = new SqlConnection(
               connectionString))
    {
        SqlDataAdapter adapter = new SqlDataAdapter(queryString, connection);
        DataSet dt = new DataSet();
        try
        {
            connection.Open();

// Using sqlDataAdapter, we process the query string and fill the data into the dataset

            adapter.Fill(dt);
        }
        catch (SqlException se)
        {
            Console.WriteLine(se.ToString());
        }
        finally
        {
            connection.Close();
        }
        return dt;
    }
}

// Performs data Read operation
// DataManagerRequest defines the members of the query
public override object Read(DataManagerRequest DataManagerReq, string Key = null)
{
    string AppData = _env.ContentRootPath;
    string DatabasePath = Path.Combine(AppData, "App_Data\\NORTHWND.MDF");
string ConnectionStr = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename='{DatabasePath}';Integrated Security=True;Connect Timeout=30";

    // Here, we formed the SQL query string based on the skip and take count from the DataManagerRequest

    string QueryStr = "SELECT OrderID, CustomerID FROM dbo.Orders ORDER BY OrderID OFFSET " + DataManagerReq.Skip + " ROWS FETCH NEXT " + DataManagerReq.Take + " ROWS ONLY;";
    DataSet Data = CreateCommand(QueryStr, ConnectionStr);
    Orders = Data.Tables[0].AsEnumerable().Select(r => new Order
    {
        OrderID = r.Field<int>("OrderID"),
        CustomerID = r.Field<string>("CustomerID")
    }).ToList();  // Here, we convert dataset into list
    IEnumerable<Order> DataSource = Orders;
    SqlConnection Con = new SqlConnection(ConnectionStr);
    Con.Open();
    SqlCommand Cmd = new SqlCommand("SELECT COUNT(*) FROM dbo.Orders", Con);
    Int32 Count = (Int32)Cmd.ExecuteScalar();
    return DataManagerReq.RequiresCounts ? new DataResult() { Result = DataSource, Count = Count } : (object)DataSource;
}
}

{% endhighlight %}
{% endtabs %}

While running the application, the grid will be displayed as follows.

![Binding SQL data to the Blazor DataGrid Component](../images/SQLServerBoundedGrid.png)

## Handling CRUD operations with our Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid component

Enable editing in the grid component by using the [GridEditSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEditSettings.html) component. The DataGrid supports multiple editing modes such as Inline/Normal, Dialog, and Batch editing. For more details, refer to the [Grid Editing](https://blazor.syncfusion.com/documentation/datagrid/editing) documentation.

In the below code snippet, the Inline edit mode is enabled, and the [Toolbar](https://blazor.syncfusion.com/documentation/datagrid/tool-bar) property is used to display toolbar items for editing operations.

{% highlight razor %}

<SfGrid @ref="Grid" TValue="Order" AllowPaging="true" Toolbar="@(new List<string>() { "Add","Edit","Delete","Update","Cancel"})">
    <GridEditSettings AllowAdding="true" AllowDeleting="true" AllowEditing="true"></GridEditSettings>
</SfGrid>

{% endhighlight %}

N> Normal editing is the default edit mode for the DataGrid component. To perform CRUD operations, ensure that the IsPrimaryKey property is set to True for a specific GridColumn whose value is unique. This allows the grid to correctly identify and update records during editing.

The CRUD operations can be performed and customized by overriding the following methods of the DataAdaptor abstract class:

* Insert / InsertAsync – to add new records into the database.
* Remove / RemoveAsync – to delete existing records.
* Update / UpdateAsync – to modify existing records.
* BatchUpdate / BatchUpdateAsync – to handle multiple changes (insert, update, delete) in a single request.

By implementing these methods, you can directly connect the Syncfusion® Blazor DataGrid component with SQL Server data and manage all CRUD operations seamlessly. In the following steps, we will see how to perform these operations using SQL Server data with the DataGrid.

### Insert Operation

To Perform the Insert operation, override the Insert/InsertAsync method of the custom adaptor and add the following code in the CustomAdaptorComponent.razor.

{% tabs %}
{% highlight razor tabtitle="Blazor Web App" %}

public override async Task<object> InsertAsync(DataManager DataManager, object Value, string Key)
{
    await OrderDetails.InsertOrder(Value);
    return Value;
}

{% endhighlight %}
{% highlight razor tabtitle="Blazor Server App" %}
// Performs Insert operation
//You will get the DataManager instance in the DataManager parameter
//You will get the record in the Value parameter
public override object Insert(DataManager DataManager, object Value, string Key)
{

//Here, you can implement your own code to update the record from the grid.

    string AppData = _env.ContentRootPath;
    string DatabasePath = Path.Combine(AppData, "App_Data\\NORTHWND.MDF");
    string ConnectionStr = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename='{DatabasePath}';Integrated Security=True;Connect Timeout=30";
    string QueryStr = $"Insert into Orders(CustomerID) values('{(Value as Order).CustomerID}')";
    SqlConnection Con = new SqlConnection(ConnectionStr);
    try
    {
        Con.Open();
        SqlCommand Cmd = new SqlCommand(QueryStr, Con);
        Cmd.ExecuteNonQuery();
    }
    catch (SqlException Exception)
    {
        Console.WriteLine(Exception.ToString());
    }
    finally
    {
        Con.Close();
    }
    return Value;
}
{% endhighlight %}
{% endtabs %}

The resultant grid will look like below.

![Insert Operation](../images/SQLInsert.png)

### Update Operation

To Perform the Update operation, override the Update/UpdateAsync method of the custom adaptor and add the following code in the CustomAdaptorComponent.razor.

{% tabs %}
{% highlight razor tabtitle="Blazor Web App" %}

// Performs Update operation
public override async Task<object> Update(DataManager dm, object value, string keyField, string key)
{
    await OrderDetails.UpdateOrder(value);
    return value;
}

{% endhighlight %}
{% highlight razor tabtitle="Blazor Server App" %}

// Performs Update operation
//You will get the DataManager instance in the DataManager parameter
//You will get the edited record in the Value parameter
//You will get the PrimaryKey field in the KeyField parameter
public override object Update(DataManager DataManager, object Value, string KeyField, string Key)
{
//Here, you can implement your own code to update the record from the grid.
    string AppData = _env.ContentRootPath;
    string DatabasePath = Path.Combine(AppData, "App_Data\\NORTHWND.MDF");
    string ConnectionStr = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename='{DatabasePath}';Integrated Security=True;Connect Timeout=30";
    string QueryStr = $"Update Orders set CustomerID='{(Value as Order).CustomerID}' where OrderID={(Value as Order).OrderID}";
    SqlConnection Con = new SqlConnection(ConnectionStr);
    try
    {
        Con.Open();
        SqlCommand Cmd = new SqlCommand(QueryStr, Con);
        Cmd.ExecuteNonQuery();
    }
    catch (SqlException Exception)
    {
        Console.WriteLine(Exception.ToString());
    }
    finally
    {
        Con.Close();
    }
    return Value;
}

{% endhighlight %}
{% endtabs %}

The resultant grid will look like below.

![Update Operation](../images/SQLUpdate.png)

### Delete Operation

To Perform the Delete operation, override the Remove/RemoveAsync method of the custom adaptor and add the following code in the CustomAdaptorComponent.razor.

{% tabs %}
{% highlight razor tabtitle="Blazor Web App" %}

public override async Task<object> RemoveAsync(DataManager dm, object value, string keyField, string key)
{
    await OrderDetails.RemoveOrder(value);
    return value;
}

{% endhighlight %}
{% highlight razor tabtitle="Blazor Server App" %}

// Performs Remove operation
//You will get the DataManager instance in the DataManager parameter
//You will get the record in the Value parameter
//You will get the PrimaryKey field in the KeyField parameter
public override object Remove(DataManager DataManager, object Value, string KeyField, string Key)
{
//Here, you can implement your own code to delete the record from the grid.

    string AppData = _env.ContentRootPath;
    string DatabasePath = Path.Combine(AppData, "App_Data\\NORTHWND.MDF");
    string Connectionstr = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename='{DatabasePath}';Integrated Security=True;Connect Timeout=30";
    string QueryStr = $"Delete from Orders where OrderID={Value}";
    SqlConnection Con = new SqlConnection(Connectionstr);
    try
    {
        Con.Open();
        SqlCommand Cmd = new SqlCommand(QueryStr, Con);
        Cmd.ExecuteNonQuery();
    }
    catch (SqlException Exception)
    {
        Console.WriteLine(Exception.ToString());
    }
    finally
    {
        Con.Close();
    }
    return Value;
}

{% endhighlight %}
{% endtabs %}

The resultant grid will look like below.

![Delete Operation](../images/SQLDelete.png)

N> You can find the sample in this [GitHub location](https://github.com/SyncfusionExamples/blazor-grid-sqldatabinding)
