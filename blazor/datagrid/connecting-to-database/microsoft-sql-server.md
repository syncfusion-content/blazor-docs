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

Microsoft SQL database can be bound to the datagrid in different ways (i.e.) DataSource property, CustomAdaptor and Remote Databinding using various adaptors (WebAPI, OData, ODataV4, URLadaptor). Here listed two options are the most efficient and easily customizable approaches. [CustomAdaptor](https://blazor.syncfusion.com/documentation/datagrid/custom-binding) approach suitable to local binding and [URLAdaptor](https://blazor.syncfusion.com/documentation/data/adaptors#url-adaptor) suitable for remote data bidning. Both the approaches have capability to handle data and CRUD operations with built-in methods as well as can be customized as per your own.

**Custom Adaptor**

A custom adapter allows you to perform manual operations on the data. For implementing custom data binding in Grid, DataAdaptor class is used. It class acts as a base class and has both synchronous and asynchronous method signatures whcih can be overriden in CustomAdaptor.

**API Services with URL Adaptor**

Remotely database can be bound to grid using multiple adaptors namely WebAPI, OData, ODataV4 including the URLadaptor. If you have pre configured API service following existing WebAPI standards, then WebAPI adaptor can be utilized to achieve your requirement. The URL adaptor send all requests to API service as a **POST** reqeust. The UrlAdaptor acts as the base adaptor for interacting with remote data services.


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

When utlizing a custom adaptor, managing the searching operation ivolves overriding the `Read` or `ReadAsync` method of the **DataAdaptor** abstract class.

In the code example below, searching a custom data source can be accomplished by employing the built-in [PerformSearching](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataOperations.html#Syncfusion_Blazor_DataOperations_PerformSearching_System_Collections_IEnumerable_System_Collections_Generic_List_Syncfusion_Blazor_Data_SearchFilter__) method of the [DataOperations](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataOperations.html) class. Alternatively, you can implement your own method for Searching operation and bind the resultant data to the grid.

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

When utlizing a custom adaptor, managing the sorting operation involves overriding the `Read` or `ReadAsync` method of the **DataAdaptor** abstract class.

In the code example below, sorting a custom data source can be accomplished by employing the built-in [PerformSorting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataOperations.html#Syncfusion_Blazor_DataOperations_PerformSorting__1_System_Collections_Generic_IEnumerable___0__System_Collections_Generic_List_Syncfusion_Blazor_Data_Sort__) method of the `DataOperations` class. Alternatively, you can implement your own method for sorting operation and bind the resulting data to the grid.

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

When employing a custom adaptor, handling the filtering operation involves overriding the `Read` or `ReadAsync` method of the **DataAdaptor** abstract class.

In the code example below, filtering a custom data source can be achieved by utilizing the built-in [PerformFiltering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataOperations.html#Syncfusion_Blazor_DataOperations_PerformFiltering__1_System_Collections_Generic_IEnumerable___0__System_Collections_Generic_List_Syncfusion_Blazor_Data_WhereFilter__System_String_) method of the `DataOperations` class. Alternatively, you can implement your own method for filtering operations and bind the resulting data to the grid.

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

When employing a custom adaptor, handling paging operation involves overriding the `Read` or `ReadAsync` method of the **DataAdaptor** abstract class.

In the code example below, paging a custom data source can be achieved by utilizing the built-in [PerformTake](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataOperations.html#Syncfusion_Blazor_DataOperations_PerformTake_System_Collections_IEnumerable_System_Int32_) and [PerformSkip](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataOperations.html#Syncfusion_Blazor_DataOperations_PerformSkip__1_System_Collections_Generic_IEnumerable___0__System_Int32_) method of the `DataOperations` class. Alternatively, you can use your own method for paging operation and bind the resulting data to the grid.

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

When employing Custom Adaptor, the grouping operation must be managed wihtin the `Read` or `ReadAsync` method of the Custom adaptor.

The provided sample code illustrated how to implement the grouping operation wihtin in Custom Adaptor, 

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

To enable editing in the grid component, utilize the [GridEditSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEditSettings.html) component.The grid offers multiple editing modes including the Inline/Normal, Dialog and Batch editing. For more details, refer to the [Grid Editing](https://blazor.syncfusion.com/documentation/datagrid/editing) documentation.

In this scenario, the inline edit mode and [Toolbar](https://blazor.syncfusion.com/documentation/datagrid/tool-bar) property configured to dispaly toolbar items for editing pruposes.

{% highlight razor %}

<SfGrid @ref="Grid" TValue="Order" AllowPaging="true" Toolbar="@(new List<string>() { "Add","Edit","Delete","Update","Cancel"})">
    <GridEditSettings AllowAdding="true" AllowDeleting="true" AllowEditing="true"></GridEditSettings>
</SfGrid>

{% endhighlight %}

> * Normal editing is the default edit mode for the DataGrid component. To enable CRUD operations, ensure that the [IsPrimaryKey](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_IsPrimaryKey) property is set to **true** for a specific GridColumn, ensuring that its value is unique.
> * If database have AutoGenerated column, kinldy ensure to define [IsIdentity](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_IsIdentity) property of GridColumn to disable them while adding or editing operations.

The CRUD operations can be performed and customized on our own by overriding the following CRUD methods of the **DataAdaptor** abstract class.

* Insert/InsertAsync
* Remove/RemoveAsync
* Update/UpdateAsync
* BatchUpdate/BatchUpdateAsync

Let’s see how to perform CRUD operation using SQL server data with Syncfusion Blazor DataGrid component.

**Insert Operation:**

To execute the insert operation, you will need to override the [Insert](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_Insert_Syncfusion_Blazor_DataManager_System_Object_System_String_) or [InsertAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_InsertAsync_Syncfusion_Blazor_DataManager_System_Object_System_String_) method of the custom adaptor. Then, integrate the following code snippet into the **CustomAdaptor** class. The above code snippet demonstrated how to handle the insertion of new records within the `InsertAsync` method of CustomAdaptor component. Adjust the login inside this method as per your application requirements.

{% tabs %}
{% highlight razor tabtitle="Index.razor"%}

public override async Task<object> InsertAsync(DataManager DataManager, object Value, string Key)
{
    //Add your insert logic here
    //This method will be invoked when inserting new records into the grid.
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

To execute the Update operation, override the [Update](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_Update_Syncfusion_Blazor_DataManager_System_Object_System_String_System_String_) or [UpdateAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_UpdateAsync_Syncfusion_Blazor_DataManager_System_Object_System_String_System_String_) method of the custom adaptor. Then, integrate the following code snippet into the **CustomAdaptor** class. This code snippet demonstrated how to handle the updating of existing records within the `UpdateAsync` method of the CustomAdaptor component. Adjust the login insdie this method as per your application requirements.

{% tabs %}
{% highlight razor tabtitle="Index.razor"%}

// Performs Update operation
 public override async Task<object> UpdateAsync(DataManager DataManager, object Value, string keyField, string key)
 {
    //Add your update logic here
    //This method will be invoked when updating existing in the grid.
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

To Perform the delete operation, you need to override the Remove(https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_Remove_Syncfusion_Blazor_DataManager_System_Object_System_String_System_String_) or RemoveAsync(https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_RemoveAsync_Syncfusion_Blazor_DataManager_System_Object_System_String_System_String_) method of the custom adaptor. Below is the code snippet that you can add to **CustomAdaptor** class. This code snippet demonstrated how to handle the deletion of existing records within the `RemoveAsync` method of CustomAdaptor component. Adjust the logic inside this method according to your application requirements.

{% tabs %}
{% highlight razor tabtitle="Index.razor"%}

 public override async Task<object> RemoveAsync(DataManager DataManager, object Value, string keyField, string key)
 {
    //Add your delete logic here
    //This method will be invoked when deleting existing records from the grid.
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
        public List<Order> GetOrderData()
        {
            string ConnectionString = @"<Enter a valid connection string>";
            string QueryStr = "SELECT * FROM dbo.Orders ORDER BY OrderID;";
            SqlConnection sqlConnection = new(ConnectionString);
            sqlConnection.Open();
            SqlCommand SqlCommand = new(QueryStr, sqlConnection);
            SqlDataAdapter DataAdapter = new(SqlCommand);
            DataTable DataTable = new();
            DataAdapter.Fill(DataTable);
            sqlConnection.Close();
            var DataSource = (from DataRow Data in DataTable.Rows
                      select new Order()
                      {
                          OrderID = Convert.ToInt32(Data["OrderID"]),
                          CustomerID = Data["CustomerID"].ToString(),
                          EmployeeID = Convert.IsDBNull(Data["EmployeeID"]) ? 0 : Convert.ToUInt16(Data["EmployeeID"]),
                          ShipCity = Data["ShipCity"].ToString(),
                          Freight = Convert.ToDecimal(Data["Freight"])
                      }).ToList();
            return DataSource;
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

**2.** Map the hosted API's URL link `https://localhost:xxxx/api/Grid` to the Grid in **Index.razor** by using the [SfDataManager's](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) [Url](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html#Syncfusion_Blazor_DataManager_Url) property. To interact with remote data source, provide the endpoint **Url**.

**3.** The SfDataManager offers mulitple adaptor options to connect with remote datasource based on API services. Below demonstrated is the URLAdaptor where API services is configured to return the resuting data in `Result` and `Count` format.  

**4.** The `UrlAdaptor` acts as the base adaptor for interacting with remote data services. Most of the built-in adaptors are derived from the `UrlAdaptor`.

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

The Syncfusion Grid component offers a range of powerful features for handling grid actions such as **Searching**, **Sorting**,**Filtering**,**Paging** and  **Grouping**. To handle the Dataoperation in serve side [PerformSearching](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataOperations.html#Syncfusion_Blazor_DataOperations_PerformSearching__1_System_Collections_Generic_IEnumerable___0__System_Collections_Generic_List_Syncfusion_Blazor_Data_SearchFilter__), [PerformSorting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataOperations.html#Syncfusion_Blazor_DataOperations_PerformSorting__1_System_Collections_Generic_IEnumerable___0__System_Collections_Generic_List_Syncfusion_Blazor_Data_Sort__), [PerformFiltering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataOperations.html#Syncfusion_Blazor_DataOperations_PerformFiltering_System_Collections_IEnumerable_System_Collections_Generic_List_Syncfusion_Blazor_Data_WhereFilter__System_String_), [PerformTake](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataOperations.html#Syncfusion_Blazor_DataOperations_PerformTake_System_Collections_IEnumerable_System_Int32_) and [PerformSkip](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataOperations.html#Syncfusion_Blazor_DataOperations_PerformSkip__1_System_Collections_Generic_IEnumerable___0__System_Int32_) method from Syncfusion package. This ensures efficient data retrieval and manipulation, providing a better user experience. Below are explanations on how to handle these data operations effectively in Url Adaptor:

> Ensure to refer syncfusion blazor nuget package in the Api service project

**Perform Searching:**

To handle searching operations, ensure that your API endpoint supports custom searching criteria. Implement the searching logic on the server-side using the [PerformSearching](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataOperations.html#Syncfusion_Blazor_DataOperations_PerformSearching__1_System_Collections_Generic_IEnumerable___0__System_Collections_Generic_List_Syncfusion_Blazor_Data_SearchFilter__) method from the [DataOperations](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataOperations.html) class. This allows the custom data source to undergo searching based on the criteria specified in the incoming **DataManagerRequest** object.

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

To handle sorting operations, ensure that your API endpoint supports custom sorting criteria. Implement the sorting logic on the server-side using the [PerformSorting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataOperations.html#Syncfusion_Blazor_DataOperations_PerformSorting__1_System_Collections_Generic_IEnumerable___0__System_Collections_Generic_List_Syncfusion_Blazor_Data_Sort__) method from the `DataOperations` class. This allows the custom data source to undergo sorting based on the criteria specified in the incoming **DataManagerRequest** object.

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

To handle filtering operations, ensure that your API endpoint supports custom filtering criteria. Implement the filtering logic on the server-side using the [PerformFiltering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataOperations.html#Syncfusion_Blazor_DataOperations_PerformFiltering_System_Collections_IEnumerable_System_Collections_Generic_List_Syncfusion_Blazor_Data_WhereFilter__System_String_) method from the `DataOperations` class. This allows the custom data source to undergo filtering based on the criteria specified in the incoming **DataManagerRequest** object.

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

To handle paging operations, ensure that your API endpoint supports custom paging criteria. Implement the paging logic on the server-side using the [PerformTake](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataOperations.html#Syncfusion_Blazor_DataOperations_PerformTake_System_Collections_IEnumerable_System_Int32_) and [PerformSkip](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataOperations.html#Syncfusion_Blazor_DataOperations_PerformSkip__1_System_Collections_Generic_IEnumerable___0__System_Int32_) method from the `DataOperations` class. This allows the custom data source to undergo paging based on the criteria specified in the incoming **DataManagerRequest** object.

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

To handle grouping operations, ensure that your API endpoint supports custom grouping criteria. Implement the grouping logic on the server-side using the `Group` method from the [DataUtil](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.DataUtil.html) class. This allows the custom data source to undergo grouping based on the criteria specified in the incoming **DataManagerRequest** object.

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

To enable editing in this grid component, utilize the [GridEditSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEditSettings.html) component. The grid offers multiple editing modes including the [Inline/Normal](https://blazor.syncfusion.com/documentation/datagrid/in-line-editing), [Dialog](https://blazor.syncfusion.com/documentation/datagrid/dialog-editing), and [Batch](https://blazor.syncfusion.com/documentation/datagrid/batch-editing) editing. For more details, refer to the [Grid Editing](https://blazor.syncfusion.com/documentation/datagrid/editing) documentation. 

In this scenario, the inline edit mode and [Toolbar](https://blazor.syncfusion.com/documentation/datagrid/tool-bar) property are configured to display toolbar items for editing purposes.

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

> * Normal editing is the default edit mode for the DataGrid component. To enable CRUD operations, ensure that the [IsPrimaryKey](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_IsPrimaryKey) property is set to **true** for a specific GridColumn, ensuring that its value is unique.
> * If database have AutoGenerated column, kinldy ensure to define [IsIdentity](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_IsIdentity) property of GridColumn to disable them while adding or editing operations.

**Insert Operation:**

To insert a new row, simply click the **Add** toolbar button. The new records edit form will be dispalyed as shown below. Upon clicking the **Update** toolbar button, record will inserted into in the Orders table by calling the following **POST** method of the  API.

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

To edit a row, first select desrired row and click the **Edit** toolbar button. The edit form will be displayed as shown below. proceed to modify the CustomerName column as needed. Clicking the **Update** toolbar button will update the edit record in the Orders table by involing the following **Post** method of the  API.

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

To delete a row, simply select the desrired row and click the **Delete** toolbar button. This action will trigger a **DELETE** request to the API, containing the primary key value of the selected record. As a result corresponding record will be removed from the Orders table.

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

To perform Batch Operation, define Edit Mode as [Batch] and define [BatchUrl] porperty in the SfDataManager. Use the Add toolbar button to insert new rows into the batch mode. To edit cell, double click the desried cell and update the value as requirement. To delete the desired record, simply select the record and press delete toolbar button. Now all the CRUD operations will be executed in batch mode only. Upon clicking the Update toolbar button will update the newly added ,edited records or deleted record from the Orders table using the single API **POST** request.

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
