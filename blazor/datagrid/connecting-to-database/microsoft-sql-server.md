---
layout: post
title: Microsoft SQL Data Binding in Blazor DataGrid Component | Syncfusion
description: Learn about consuming data from SQL Server using Microsoft SQL Client, binding it to Syncfusion Component, and performing CRUD operations
platform: Blazor
control: DataGrid
documentation: ug
---

# Microsoft SQL Server Data Binding

This section describes how to use [System.Data.SqlClient](https://www.nuget.org/packages/System.Data.SqlClient/4.8.6?_src=template) to retrieve data from a Microsoft SQL server database and bind it to the Blazor DataGrid.

Microsoft SQL database bound to the grid in different ways, and I'll provide two examples on my end using different approaches: a custom adapter with local binding and API services with a URL adapter.

**Custom Adapter - Local Binding:**

A custom adapter allows you to perform manual operations on the data. This is demonstrated below by implementing custom data binding and editing operations in the DataGrid component.

**API Services with URL Adapter-Remote data binding:**

The UrlAdaptor acts as the base adaptor for interacting with remote data services.Using API services with a URL adapter involves creating your own service to connect to the adapter and bind data to the grid. You can also connect your own service to different adapters like OData v4 or WebAPI adapters.


## Binding data from Microsoft SQL Server using Custom Adaptor

**1.** Create a simple Blazor DataGrid by following the [Getting Started](https://blazor.syncfusion.com/documentation/datagrid/getting-started-with-web-app) documentation link.

**2.** To connect a Microsoft SQL using the Microsoft SQL driver in our application, you need to install the [System.Data.SqlClient](https://www.nuget.org/packages/System.Data.SqlClient/4.8.6?_src=template) NuGet package. To do so, open the NuGet package manager of the project solution, search for the package **System.Data.SqlClient** and install it.

![Add the NuGet package System.Data.SqlClient to the project](../images/system-Data-sql-client-nuget-package-install.png)

**3.** Next, in the **Index.razor** page, get the SQL data from the SQL server and bind it to the DataGrid component as a datasource by using the [CustomAdaptor](https://blazor.syncfusion.com/documentation/datagrid/custom-binding) feature.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@rendermode InteractiveServer

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor
@using Microsoft.Data.SqlClient;

<SfGrid @ref="Grid" TValue="Order" AllowPaging="true">
    <SfDataManager AdaptorInstance="@typeof(CustomAdaptor)" Adaptor="Adaptors.CustomAdaptor"></SfDataManager>   
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" IsIdentity="true" IsPrimaryKey="true" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.EmployeeID) HeaderText="Employee ID" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Width="150"></GridColumn>       
        <GridColumn Field=@nameof(Order.ShipCity) HeaderText="Ship City" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    SfGrid<Order> Grid { get; set; }
}
{% endhighlight %}
{% highlight razor tabtitle="Orderdata.cs"%}
  public class Order
  {
      public int? OrderID { get; set; }
      public string CustomerID { get; set; }
      public int EmployeeID { get; set; }
      public decimal Freight { get; set; }
      public string ShipCity { get; set; }
  }
{% endhighlight %}
{% endtabs %}

**4.** Within the custom adaptor’s [ReadAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_ReadAsync_Syncfusion_Blazor_DataManagerRequest_System_String_) method, leverage the [DataManagerRequest](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManagerRequest.html) to gather Grid action specifics such as paging, filtering, and sorting details.

* Utilize the `DataManagerRequest` to formulate a SQL query string for paging purposes and execute the query. Fetch data from the database using the **SqlDataAdapter** class.

* Employ the Fill method of the **DataAdapter** to populate a DataSet with the results of the `Select` command of the DataAdapter, followed by conversion of the DataSet into a List.

* Finally, return the response as a `Result` and `Count` pair object in the **ReadAsync** method to bind the data to the DataGrid.


{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@rendermode InteractiveServer

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor
@using Microsoft.Data.SqlClient;

<SfGrid TValue="Order" AllowSorting="true" AllowFiltering="true" AllowGrouping="true" AllowPaging="true" Toolbar="@(new List<string>() { "Add","Edit", "Delete", "Update", "Cancel", "Search" })">
    <SfDataManager AdaptorInstance="@typeof(CustomAdaptor)" Adaptor="Adaptors.CustomAdaptor"></SfDataManager>
    <GridEditSettings AllowEditing="true" AllowDeleting="true" AllowAdding="true" Mode="@EditMode.Normal"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" IsIdentity="true" IsPrimaryKey="true" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.EmployeeID) HeaderText="Employee ID" TextAlign="TextAlign.Right" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" TextAlign="TextAlign.Right" Format="C2" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipCity) HeaderText="Ship City" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public class CustomAdaptor : DataAdaptor
    {
        public OrderData OrderService = new OrderData();
        // Performs data Read operation
        public override async Task<object> ReadAsync(DataManagerRequest DataManagerRequest, string key = null)
        {
            IEnumerable<Order> DataSource = await OrderService.GetOrdersAsync();
            int count = DataSource.Cast<Order>().Count();
            if (DataManagerRequest.Skip != 0)
            {
                //Paging
                DataSource = DataOperations.PerformSkip(DataSource, DataManagerRequest.Skip);
            }
            if (DataManagerRequest.Take != 0)
            {
                DataSource = DataOperations.PerformTake(DataSource, DataManagerRequest.Take);
            }
            return DataManagerRequest.RequiresCounts ? new DataResult() { Result = DataSource, Count = count } : (object)DataSource;
        }
  }
}

{% endhighlight %}
{% highlight razor tabtitle="Orderdata.cs" %}
  public class OrderData
  {
      public async Task<List<Order>> GetOrdersAsync()
      {
          string connectionString = @"<Enter a valid connection string>";            
          string QueryStr = "SELECT * FROM dbo.Orders ORDER BY OrderID;";
          List<Order> Orders = null;
          using (SqlConnection connection = new SqlConnection(connectionString))
          {
              SqlDataAdapter adapter = new SqlDataAdapter(QueryStr, connection);
              DataSet data = new DataSet();
              connection.Open();
              // Using SqlDataAdapter, we process the query string and fill the data into the dataset
              adapter.Fill(data);
              Orders = data.Tables[0].AsEnumerable().Select(r => new Order
              {
                  OrderID = r.Field<int>("OrderID"),
                  CustomerID = r.Field<string>("CustomerID"),
                  EmployeeID = r.Field<int>("EmployeeID"),
                  ShipCity = r.Field<string>("ShipCity"),
                  Freight = r.Field<decimal>("Freight")
              }).ToList();
              connection.Close();
          }
          return Orders;
      }
}
{% endhighlight %}
{% endtabs %}

> In the above grid,  [AllowSearching](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_AllowSearching), [AllowSorting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowSorting), [AllowFiltering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowFiltering),[AllowPaging](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowPaging), [AllowGrouping](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowGrouping), and CRUD-related properties have been enabled. The details on how to handle these actions are explained below.

When the application is executed, the grid will appear as depicted below.

![Blazor Grid bound with Microsoft SQL data](../images/blazor-Grid-Ms-SQL-databinding.png)

### Handling data operations

The Syncfusion Grid component offers a range of powerful features for handling grid actions such as **Searching**, **sorting**,**filtering**,**Paging** and  **grouping**. This ensures efficient data retrieval and manipulation, providing a better user experience. Below are explanations on how to handle these data operations effectively in Custom Adaptor:

**Perform Searching:**

When using a custom adaptor, the filtering operation has to be handled by overriding the `Read` or `ReadAsync` method of the **DataAdaptor** abstract class.

In the below code example, a custom data source can be search using the built-in `PerformSearching` method of the `DataOperations` class. Also, you can use your own method to do the Searching operation and bind the resultant data to the grid.

{% highlight razor %}
public class CustomAdaptor : DataAdaptor
{
    public OrderData OrderService = new OrderData();
    // Performs data Read operation
    public override async Task<object> ReadAsync(DataManagerRequest DataManagerRequest, string key = null)
    {
        IEnumerable<Order> DataSource = await OrderService.GetOrdersAsync();
        if (DataManagerRequest.Search != null && DataManagerRequest.Search.Count > 0)
        {
            // Searching
            DataSource = DataOperations.PerformSearching(DataSource, DataManagerRequest.Search);
        }
        int count = DataSource.Cast<Order>().Count();
        return DataManagerRequest.RequiresCounts ? new DataResult() { Result = DataSource, Count = count } : (object)DataSource;
    }
}
{% endhighlight %}

**Perform Sorting:** 

When using a custom adaptor, the sorting operation has to be handled by overriding the `Read` or `ReadAsync` method of the **DataAdaptor** abstract class.

In the below code example, a custom data source can be sorted using the built-in `PerformSorting` method of the `DataOperations` class. Also, you can use your own method to do the sorting operation and bind the resultant data to the grid.

{% highlight razor %}

   public class CustomAdaptor : DataAdaptor
{
    public OrderData OrderService = new OrderData();
    // Performs data Read operation
    public override async Task<object> ReadAsync(DataManagerRequest DataManagerRequest, string key = null)
    {
        IEnumerable<Order> DataSource = await OrderService.GetOrdersAsync();
        if (DataManagerRequest.Sorted != null && DataManagerRequest.Sorted.Count > 0)
        {
            // Sorting
            DataSource = DataOperations.PerformSorting(DataSource, DataManagerRequest.Sorted);
        }
        int count = DataSource.Cast<Order>().Count();
        return DataManagerRequest.RequiresCounts ? new DataResult() { Result = DataSource, Count = count } : (object)DataSource;
    }
}

{% endhighlight %}

**Perform Filtering:**

When using a custom adaptor, the filtering operation has to be handled by overriding the `Read` or `ReadAsync` method of the **DataAdaptor** abstract class.

In the below code example, a custom data source can be filtered using the built-in `PerformFiltering` method of the `DataOperations` class. Also, you can use your own method to do the filtering operation and bind the resultant data to the grid.

{% highlight razor %}

 public class CustomAdaptor : DataAdaptor
{
    public OrderData OrderService = new OrderData();
    // Performs data Read operation
    public override async Task<object> ReadAsync(DataManagerRequest DataManagerRequest, string key = null)
    {
        IEnumerable<Order> DataSource = await OrderService.GetOrdersAsync();
        if (DataManagerRequest.Where != null && DataManagerRequest.Where.Count > 0)
        {
            // Filtering
            DataSource = DataOperations.PerformFiltering(DataSource, DataManagerRequest.Where, DataManagerRequest.Where[0].Operator);
        }
        int count = DataSource.Cast<Order>().Count();
        return DataManagerRequest.RequiresCounts ? new DataResult() { Result = DataSource, Count = count } : (object)DataSource;
    }
}

{% endhighlight %}

**Perform Paging:**

When using a custom adaptor, the filtering operation has to be handled by overriding the `Read` or `ReadAsync` method of the **DataAdaptor** abstract class.

In the below code example, a custom data source can be paging using the built-in `PerformTake` and `PerformSkip` method of the `DataOperations` class. Also, you can use your own method to do the paging operation and bind the resultant data to the grid.

{% highlight razor %}

public class CustomAdaptor : DataAdaptor
{
    public OrderData OrderService = new OrderData();
    // Performs data Read operation
    public override async Task<object> ReadAsync(DataManagerRequest DataManagerRequest, string key = null)
    {
        IEnumerable<Order> DataSource = await OrderService.GetOrdersAsync();
        int count = DataSource.Cast<Order>().Count();
        if (DataManagerRequest.Skip != 0)
        {
            //Paging
            DataSource = DataOperations.PerformSkip(DataSource, DataManagerRequest.Skip);
        }
        if (DataManagerRequest.Take != 0)
        {
            DataSource = DataOperations.PerformTake(DataSource, DataManagerRequest.Take);
        }
        return DataManagerRequest.RequiresCounts ? new DataResult() { Result = DataSource, Count = count } : (object)DataSource;
    }
}
{% endhighlight %}

**Perform Grouping:** 

When using Custom Adaptor, the grouping operation has to be handled in the `Read` or `ReadAsync` method of Custom adaptor.

The following sample code demonstrates implementing the grouping operation in Custom Adaptor, 

{% highlight razor %}
public class CustomAdaptor : DataAdaptor
{
    public OrderData OrderService = new OrderData();
    // Performs data Read operation
    public override async Task<object> ReadAsync(DataManagerRequest DataManagerRequest, string key = null)
    {
        IEnumerable<Order> DataSource = await OrderService.GetOrdersAsync();
        int count = DataSource.Cast<Order>().Count();
        DataResult DataObject = new DataResult();
        if (DataManagerRequest.Group != null)
        {
            IEnumerable ResultData = DataSource.ToList();
            // Grouping
            foreach (var group in DataManagerRequest.Group)
            {
                ResultData = DataUtil.Group<Order>(ResultData, group, DataManagerRequest.Aggregates, 0, DataManagerRequest.GroupByFormatter);
            }
            DataObject.Result = ResultData;
            DataObject.Count = count;
            return DataManagerRequest.RequiresCounts ? DataObject : (object)ResultData;
        }
        return DataManagerRequest.RequiresCounts ? new DataResult() { Result = DataSource, Count = count } : (object)DataSource;
    }
}
{% endhighlight %}

> For optimal performance, it is recommended to follow this sequence of operations(Search, Sort, Filter, Paging, Grouping) in the **ReadAsync** method 

### Handling CRUD operations

Enable editing in the grid component using the [GridEditSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEditSettings.html) component. Grid provides various modes of editing options such as Inline/Normal, Dialog and Batch editing. Refer the [Grid Editing](https://blazor.syncfusion.com/documentation/datagrid/editing) documentation for reference.

Here, inline edit mode and [Toolbar](https://blazor.syncfusion.com/documentation/datagrid/tool-bar) property are used to show toolbar items for editing.

{% highlight razor %}

<SfGrid @ref="Grid" TValue="Order" AllowPaging="true" Toolbar="@(new List<string>() { "Add","Edit","Delete","Update","Cancel"})">
    <GridEditSettings AllowAdding="true" AllowDeleting="true" AllowEditing="true"></GridEditSettings>
</SfGrid>

{% endhighlight %}

>* Normal editing is the default edit mode for the DataGrid component. Also, to perform CRUD operations, set [IsPrimaryKey](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_IsPrimaryKey) property as **true** for a particular GridColumn, whose value is a unique.
> * If [IsIdentity](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_IsIdentity) is enabled, then it will be considered as a read-only column when editing and adding a record.

The CRUD operations can be performed and customized on our own by overriding the following CRUD methods of the DataAdaptor abstract class.

* Insert/InsertAsync
* Remove/RemoveAsync
* Update/UpdateAsync
* BatchUpdate/BatchUpdateAsync

Let’s see how to perform CRUD operation using SQL server data with Syncfusion Blazor DataGrid component.

**Insert Operation:**

To Perform the Insert operation, override the [Insert](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_Insert_Syncfusion_Blazor_DataManager_System_Object_System_String_) or [InsertAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_InsertAsync_Syncfusion_Blazor_DataManager_System_Object_System_String_) method of the custom adaptor and add the following code in the CustomAdaptor.

{% tabs %}
{% highlight razor tabtitle="Index.razor"%}

public override async Task<object> InsertAsync(DataManager DataManager, object Value, string Key)
{
    await OrderService.AddOrderAsync(Value as Order);
    return Value;
}

{% endhighlight %}
{% highlight razor tabtitle="Orderdata.cs"%}
 public async Task AddOrderAsync(Order Value)
{
    string ConnectionString = $"<Enter a valid connection string>";
    string Query = $"Insert into Orders(CustomerID,Freight,ShipCity,EmployeeID) values('{(Value as Order).CustomerID}','{(Value as Order).Freight}','{(Value as Order).ShipCity}','{(Value as Order).EmployeeID}')";
    SqlConnection Connection = new SqlConnection(ConnectionString);
    Connection.Open();
    SqlCommand Command = new SqlCommand(Query, Connection);
    Command.ExecuteNonQuery();
    Connection.Close();
}
{% endhighlight %}
{% endtabs %}

**Update Operation:**

To Perform the Update operation, override the [Update](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_Update_Syncfusion_Blazor_DataManager_System_Object_System_String_System_String_) or [UpdateAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_UpdateAsync_Syncfusion_Blazor_DataManager_System_Object_System_String_System_String_) method of the custom adaptor and add the following code in the CustomAdaptor.

{% tabs %}
{% highlight razor tabtitle="Index.razor"%}

// Performs Update operation
 public override async Task<object> UpdateAsync(DataManager DataManager, object Value, string keyField, string key)
 {
     await OrderService.UpdateOrderAsync(Value as Order);
     return Value;
 }

{% endhighlight %}
{% highlight razor tabtitle="Orderdata.cs"%}
 public async Task UpdateOrderAsync(Order Value)
{
    string ConnectionString = $"<Enter a valid connection string>";
    SqlConnection Connection = new SqlConnection(ConnectionString);
    Connection.Open();
    SqlCommand Command = new SqlCommand(Query, Connection);
    Command.ExecuteNonQuery();
    Connection.Close();
}
 
{% endhighlight %}
{% endtabs %}

**Delete Operation:**

To Perform the Delete operation, override the Remove(https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_Remove_Syncfusion_Blazor_DataManager_System_Object_System_String_System_String_) or RemoveAsync(https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_RemoveAsync_Syncfusion_Blazor_DataManager_System_Object_System_String_System_String_) method of the custom adaptor and add the following code in the CustomAdaptor.

{% tabs %}
{% highlight razor tabtitle="Index.razor"%}

 public override async Task<object> RemoveAsync(DataManager DataManager, object Value, string keyField, string key)
 {
     await OrderService.RemoveOrderAsync(Value as int?);
     return Value;
 }
{% endhighlight %}
{% highlight razor tabtitle="Orderdata.cs"%}
 public async Task RemoveOrderAsync(int? Key)
 {
     string ConnectionString = $"<Enter a valid connection string>";
     string Query = $"Delete from Orders where OrderID={Key}";
     SqlConnection Connection = new SqlConnection(ConnectionString);
     Connection.Open();
     SqlCommand Command = new SqlCommand(Query, Connection);
     Command.ExecuteNonQuery();
     Connection.Close();
 } 
{% endhighlight %}
{% endtabs %}

**Batch Operation**

To Perform the Batch operation, override the [BatchUpdate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_BatchUpdate_Syncfusion_Blazor_DataManager_System_Object_System_Object_System_Object_System_String_System_String_System_Nullable_System_Int32__) or [BatchUpdateAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_BatchUpdateAsync_Syncfusion_Blazor_DataManager_System_Object_System_Object_System_Object_System_String_System_String_System_Nullable_System_Int32__) method of the custom adaptor and add the following code in the Custom Adaptor.

{% highlight razor %}
 // Performs BatchUpdate operation
 public override async Task<object> BatchUpdateAsync(DataManager DataManager, object Changed, object Added, object Deleted, string KeyField, string Key, int? dropIndex)
 {
     if (Changed != null)
     {
         foreach (var record in (IEnumerable<Order>)Changed)
         {
             await OrderService.UpdateOrderAsync(record as Order);
         }
     }
     if (Added != null)
     {
         foreach (var record in (IEnumerable<Order>)Added)
         {
             await OrderService.AddOrderAsync(record as Order);
         }
     }
     if (Deleted != null)
     {
         foreach (var record in (IEnumerable<Order>)Deleted)
         {
             await OrderService.RemoveOrderAsync((record as Order).OrderID);
         }
     }
     return Key;
 }
{% endhighlight %}

> You can find the sample in this [GitHub location](https://github.com/SyncfusionExamples/blazor-grid-mssql-connectivity-using-custom-adaptor).

## Binding data from Microsoft SQL Server using an API service

### Creating an API service 

**1.** Open Visual Studio and create an ASP.NET Core Web App project type, naming it **MyWebService**. To create an ASP.NET Core Web application, follow the documentation [link](https://learn.microsoft.com/en-us/visualstudio/get-started/csharp/tutorial-aspnet-core?view=vs-2022).

![Create ASP.NET Core Web App project](../images/azure-asp-core-web-service-create.png)

**2.** To connect a Microsoft SQL using the **System.Data.SqlClient** in our application, we need to install the [System.Data.SqlClient](https://www.nuget.org/packages/System.Data.SqlClient/4.8.6?_src=template) NuGet package. To do so, open the NuGet package manager of the project solution, search for the package **System.Data.SqlClient** and install it.

![Add the NuGet package Sytem.Data.SqlClient to the project](../images/system-Data-sql-client-nuget-package-install.png)

**3.** Create a API controller (aka, GridController.cs) file under **Controllers** folder that helps to establish data communication with the DataGrid.

**4.** In the API controller  (aka, GridController), connect to Microsoft SQL server. In the **Get()** method **SqlConnection** helps to connect the SQL database (that is, Database1.mdf). Next, using **SqlCommand** and **SqlDataAdapter** you can process the desired SQL query string and retrieve data from the database. The **Fill** method of the DataAdapter is used to populate the SQL data into a **DataTable** as shown in the following code snippet.

{% tabs %}
{% highlight razor tabtitle="GridController.cs"%}
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using Syncfusion.Blazor;
using Syncfusion.Blazor.Data;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
namespace MyWebService.Controllers
{
    [ApiController]    
    public class GridController : ControllerBase
    {
        public static List<Order> Orders { get; set; }
        public class Order
        {
            [Key]
            public int? OrderID { get; set; }
            public string? CustomerID { get; set; }
            public int? EmployeeID { get; set; }
            public decimal? Freight { get; set; }
            public string? ShipCity { get; set; }
        }
        [Route("api/[controller]")]
        public List<Order> GetSQLResult()
        {
            string conSTR = @"<Enter a valid connection string>";
            string QueryStr = "SELECT * FROM dbo.Orders ORDER BY OrderID;";
            SqlConnection sqlConnection = new(conSTR);
            sqlConnection.Open();
            SqlCommand sqlCommand = new(QueryStr, sqlConnection);
            SqlDataAdapter dataAdapter = new(sqlCommand);
            DataTable dataTable = new();
            dataAdapter.Fill(dataTable);
            sqlConnection.Close();
            var dataSource = (from DataRow data in dataTable.Rows
                              select new Order()
                              {
                                  OrderID = Convert.ToInt32(data["OrderID"]),
                                  CustomerID = data["CustomerID"].ToString(),
                                  EmployeeID = Convert.IsDBNull(data["EmployeeID"]) ? 0 : Convert.ToUInt16(data["EmployeeID"]),
                                  ShipCity = data["ShipCity"].ToString(),
                                  Freight = Convert.ToDecimal(data["Freight"])
                              }).ToList();
            return dataSource;
        } 
    }
}
{% endhighlight %}
{% endtabs %}

**5.** Run the application and it will be hosted within the URL `https://localhost:xxxx`.

**6.** Finally, the retrieved data from Microsoft SQL database which is in the form of JSON can be found in the API controller available in the URL link `https://localhost:xxxx/api/Grid`, as shown in the browser page below.

![Hosted API URL](../images/Ms-Sql-data.png)

### Connecting Grid to an API service

**1.** Create a simple Blazor Grid by following the [Getting Started](https://blazor.syncfusion.com/documentation/datagrid/getting-started-with-web-app) documentation link.

**2.** Map the hosted API's URL link `https://localhost:xxxx/api/Grid` to the Grid in **Index.razor** by using the [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) to the [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_DataSource) property or by using [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) component. To interact with remote data source, provide the endpoint **Url**.

**3.** The `UrlAdaptor` acts as the base adaptor for interacting with remote data services. Most of the built-in adaptors are derived from the `UrlAdaptor`.

{% tabs %}
{% highlight razor tabtitle="Index.razor"%}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor
@using Microsoft.Data.SqlClient;

<SfGrid @ref="Grid" TValue="Order" AllowPaging="true" AllowFiltering="true" AllowSorting="true" AllowGrouping="true" Toolbar="@(new List<string>() { "Add","Edit", "Delete", "Update", "Cancel", "Search" })">
    <SfDataManager Url="https://localhost:xxxx/api/Grid" InsertUrl="https://localhost:xxxx/api/Grid/Insert" UpdateUrl="https://localhost:xxxx/api/Grid/Update" RemoveUrl="https://localhost:xxxx/api/Grid/Delete" Adaptor="Adaptors.UrlAdaptor"></SfDataManager>
    <GridEditSettings AllowEditing="true" AllowDeleting="true" AllowAdding="true" Mode="EditMode.Normal"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" IsIdentity="true" IsPrimaryKey="true" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.EmployeeID) HeaderText="Employee ID" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipCity) HeaderText="Ship City" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    SfGrid<Order> Grid { get; set; }
    public List<Order> Orders { get; set; }

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public int EmployeeID { get; set; }
        public decimal Freight { get; set; }
        public string ShipCity { get; set; }
    }
}
{% endhighlight %}
{% endtabs %}

> In the above grid,  `AllowSearching`, `AllowSorting`, `AllowFiltering`,`AllowPaging`, `AllowGrouping`, and CRUD-related properties have been enabled. The details on how to handle these actions are explained below.

When you run the application, the resultant Grid will look like this

![Blazor Grid bound with Microsoft SQL data](../images/blazor-Grid-Ms-SQL-databinding.png)

### Handling data operations

The Syncfusion Grid component offers a range of powerful features for handling grid actions such as **Searching**, **Sorting**,**Filtering**,**Paging** and  **Grouping**. This ensures efficient data retrieval and manipulation, providing a better user experience. Below are explanations on how to handle these data operations effectively in Url Adaptor:

**Perform Searching:**

When using a custom adaptor, the filtering operation has to be handled by overriding the `Read` or `ReadAsync` method of the **DataAdaptor** abstract class.

In the below code example, a custom data source can be search using the built-in `PerformSearching` method of the `DataOperations` class. Also, you can use your own method to do the Searching operation and bind the resultant data to the grid.

{% highlight razor %}

 [HttpPost]
[Route("api/[controller]")]
    public object Post([FromBody] DataManagerRequest DataManagerRequest)
    {
        IEnumerable<Order> DataSource = GetOrderData();
        if (DataManagerRequest.Search != null && DataManagerRequest.Search.Count > 0)
        {
            // Searching
            DataSource = DataOperations.PerformSearching(DataSource, DataManagerRequest.Search);
        }
        int count = DataSource.Cast<Order>().Count();
        return new { result = DataSource, count = count };
    }

{% endhighlight %}

**Perform Sorting:**

To handle filtering operations, ensure that your API endpoint supports custom sorting criteria. Implement the sorting logic on the server-side using the `PerformSorting` method from the `DataOperations` class. This allows the custom data source to undergo sorting based on the criteria specified in the incoming **DataManagerRequest** object.

{% highlight razor %}
 [HttpPost]
 [Route("api/[controller]")]
 public object Post([FromBody] DataManagerRequest DataManagerRequest)
 {
     IEnumerable<Order> DataSource = GetOrderData();
     if (DataManagerRequest.Sorted != null && DataManagerRequest.Sorted.Count > 0)
     {
         // Sorting
         DataSource = DataOperations.PerformSorting(DataSource, DataManagerRequest.Sorted);
     }
     int count = DataSource.Cast<Order>().Count();
     return new { result = DataSource, count = count };
 }
{% endhighlight %}

**Perform Filtering:**

To handle filtering operations, ensure that your API endpoint supports custom filtering criteria. Implement the filtering logic on the server-side using the `PerformFiltering` method from the `DataOperations` class. This allows the custom data source to undergo filtering based on the criteria specified in the incoming **DataManagerRequest** object.

{% highlight razor %}
 [HttpPost]
 [Route("api/[controller]")]
 public object Post([FromBody] DataManagerRequest DataManagerRequest)
 {
     IEnumerable<Order> DataSource = GetOrderData();
     if (DataManagerRequest.Where != null && DataManagerRequest.Where.Count > 0)
     {
         // Filtering
         DataSource = DataOperations.PerformFiltering(DataSource, DataManagerRequest.Where, DataManagerRequest.Where[0].Operator);
     }
     int count = DataSource.Cast<Order>().Count();
     return new { result = DataSource, count = count };
 }
{% endhighlight %}

**Perform Paging:**

When using a custom adaptor, the filtering operation has to be handled by overriding the `Read` or `ReadAsync` method of the **DataAdaptor** abstract class.

In the below code example, a custom data source can be paging using the built-in `PerformTake` and `PerformSkip` method of the `DataOperations` class. Also, you can use your own method to do the paging operation and bind the resultant data to the grid.

{% highlight razor %}
 [HttpPost]
 [Route("api/[controller]")]
 public object Post([FromBody] DataManagerRequest DataManagerRequest)
 {
     IEnumerable<Order> DataSource = GetOrderData();
     int count = DataSource.Cast<Order>().Count();

     if (DataManagerRequest.Skip != 0)
     {
         // Paging
         DataSource = DataOperations.PerformSkip(DataSource, DataManagerRequest.Skip);
     }
     if (DataManagerRequest.Take != 0)
     {
         DataSource = DataOperations.PerformTake(DataSource, DataManagerRequest.Take);
     }
     return new { result = DataSource, count = count };
 }
{% endhighlight %}

**Perform Grouping:**

To handle grouping operations, ensure that your  API endpoint supports custom grouping criteria. Implement the grouping logic on the server-side using the Group method from the [DataUtil](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.DataUtil.html) class. This allows the custom data source to undergo grouping based on the criteria specified in the incoming **DataManagerRequest** object.

{% highlight razor %}
 [HttpPost]
 [Route("api/[controller]")]
 [HttpPost]
 [Route("api/[controller]")]
 public object Post([FromBody] DataManagerRequest DataManagerRequest)
 {
     IEnumerable<Order> DataSource = GetOrderData();
     int count = DataSource.Cast<Order>().Count();
     DataResult DataObject = new DataResult();
     if (DataManagerRequest.Group != null)
     {
         System.Collections.IEnumerable ResultData = DataSource.ToList();
         // Grouping
         foreach (var group in DataManagerRequest.Group)
         {
             ResultData = DataUtil.Group<Order>(ResultData, group, DataManagerRequest.Aggregates, 0, DataManagerRequest.GroupByFormatter);
         }
         DataObject.Result = ResultData;
         DataObject.Count = count;
         return DataManagerRequest.RequiresCounts ? DataObject : (object)ResultData;
     }
     return new { result = DataSource, count = count };
 }
{% endhighlight %}

> For optimal performance, it is recommended to follow this sequence of operations(Search, Sort, Filter, Paging, Grouping) in the **ReadAsync** method 

### Handling CRUD operations 

You can enable editing in the grid component using the [GridEditSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEditSettings.html) component. Grid provides various modes of editing options such as [Inline/Normal](https://blazor.syncfusion.com/documentation/datagrid/in-line-editing), [Dialog](https://blazor.syncfusion.com/documentation/datagrid/dialog-editing), and [Batch](https://blazor.syncfusion.com/documentation/datagrid/batch-editing) editing.

Here, Inline edit mode is utilized, and used Toolbar property to show toolbar items for editing. DataGrid Editing and Toolbar code have been added to the previous Grid model.

{% tabs %}
{% highlight razor %}

<SfGrid @ref="Grid" TValue="Order" AllowPaging="true" AllowFiltering="true" AllowSorting="true" AllowGrouping="true" Toolbar="@(new List<string>() { "Add","Edit", "Delete", "Update", "Cancel", "Search" })">
    <SfDataManager Url="https://localhost:xxxx/api/Grid" InsertUrl="https://localhost:xxxx/api/Grid/Insert" UpdateUrl="https://localhost:xxxx/api/Grid/Update" RemoveUrl="https://localhost:xxxx/api/Grid/Delete" BatchUrl="https://localhost:7033/api/Grid/Batch" Adaptor="Adaptors.UrlAdaptor"></SfDataManager>
    <GridEditSettings AllowEditing="true" AllowDeleting="true" AllowAdding="true" Mode="EditMode.Normal"></GridEditSettings>
     <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" IsIdentity="true" IsPrimaryKey="true" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.EmployeeID) HeaderText="Employee ID" TextAlign="TextAlign.Right" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" TextAlign="TextAlign.Right" Format="C2" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipCity) HeaderText="Ship City" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

{% endhighlight %}
{% endtabs %}

> Normal editing is the default edit mode for the DataGrid component. Set the [IsPrimaryKey](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_IsPrimaryKey) property of Column as **true** for a particular column, whose value is a unique value for editing purposes.
> * If [IsIdentity](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_IsIdentity) is enabled, then it will be considered as a read-only column when editing and adding a record.

**Insert Operation:**

To insert a new row, click the **Add** toolbar button. Clicking the **Update** toolbar button will insert the new record in the Orders table by calling the following **POST** method of the  API.

{% tabs %}
{% highlight c# tabtitle="OrdersController.cs" %}
 [HttpPost]
 [Route("api/Grid/Insert")]
 public void Insert([FromBody] CRUDModel<Order> Value)
 {
     string ConnectionString = @"<Enter a valid connection string>";
     string Query = $"Insert into Orders(CustomerID,Freight,ShipCity,EmployeeID) values('{Value.Value.CustomerID}','{Value.Value.Freight}','{Value.Value.ShipCity}','{Value.Value.EmployeeID}')";
     SqlConnection SqlConnection = new SqlConnection(ConnectionString);
     SqlConnection.Open();
     SqlCommand SqlCommand = new SqlCommand(Query, SqlConnection);
     SqlCommand.ExecuteNonQuery();
     SqlConnection.Close();
 }
{% endhighlight %}
{% endtabs %}

**Update Operation:**

To edit a row, select any row and click the **Edit** toolbar button. Clicking the **Update** toolbar button will update the edit record in the Orders table by calling the following **Post** method of the  API.

{% tabs %}
{% highlight c# tabtitle="OrdersController.cs" %}
[HttpPost]
[Route("api/Grid/Update")]
public void Update([FromBody] CRUDModel<Order> Value)
{
    string ConnectionString = @"<Enter a valid connection string>";
    string Query = $"Update Orders set CustomerID='{Value.Value.CustomerID}', Freight='{Value.Value.Freight}',EmployeeID='{Value.Value.EmployeeID}',ShipCity='{Value.Value.ShipCity}' where OrderID='{Value.Value.OrderID}'";
    SqlConnection SqlConnection = new SqlConnection(ConnectionString);
    SqlConnection.Open();
    SqlCommand SqlCommand = new SqlCommand(Query, SqlConnection);
    SqlCommand.ExecuteNonQuery();
    SqlConnection.Close();
}
{% endhighlight %}
{% endtabs %}

**Delete Operation:**

To delete a row, select any row and click the **Delete** toolbar button. Deleting operation will send a **DELETE** request to the API with the selected record`s primary key value to remove the corresponding record from the Orders table.

{% tabs %}
{% highlight c# tabtitle="OrdersController.cs" %}
 [HttpPost]
 [Route("api/Grid/Delete")]
 public void Delete([FromBody] CRUDModel<Order> Value)
 {
     string ConnectionString = @"<Enter a valid connection string>";
     string Query = $"Delete from Orders where OrderID={Value.Key}";
     SqlConnection SqlConnection = new SqlConnection(ConnectionString);
     SqlConnection.Open();
     SqlCommand SqlCommand = new SqlCommand(Query, SqlConnection);
     SqlCommand.ExecuteNonQuery();
     SqlConnection.Close();
 }
{% endhighlight %}
{% endtabs %}

**Batch Operation**

To perform Batch Operation, define Edit Mode as Batch and define  BatchUrl porperty in the SfDataManager, then use the Add toolbar button to insert new rows. To edit rows, select them and click the Edit toolbar button. clicking the Update toolbar button will update the new and edited records in the Orders table using the API **POST** method. For batch deletion, select multiple rows and click the Delete toolbar button

{% highlight razor %}
 // Performs BatchUpdate operation
[HttpPost]
[Route("api/Grid/Batch")]
public void Batch([FromBody] CRUDModel<Order> Value)
{
    if (Value.Changed != null)
    {
        foreach (var record in (IEnumerable<Order>)Value.Changed)
        {
            //update in your database
        }

    }
    if (Value.Added != null)
    {
        foreach (var record in (IEnumerable<Order>)Value.Added)
        {
            //Insert in your database
        }

    }
    if (Value.Deleted != null)
    {
        foreach (var record in (IEnumerable<Order>)Value.Deleted)
        {
            //remove the records from your database
        }
    }
}
{% endhighlight %}

> Find the sample from this [Github location](https://github.com/SyncfusionExamples/blazor-grid-mssql-connectivity-using-api-service).
