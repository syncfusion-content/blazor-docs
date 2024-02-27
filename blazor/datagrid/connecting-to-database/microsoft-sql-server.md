---
layout: post
title: Microsoft SQL Data Binding in Blazor DataGrid Component | Syncfusion
description: Learn about consuming data from SQL Server using Microsoft SQL Client, binding it to Syncfusion Component, and performing CRUD operations
platform: Blazor
control: DataGrid
documentation: ug
---

# Microsoft SQL Data Binding

This section describes how to use [System.Data.SqlClient](https://www.nuget.org/packages/System.Data.SqlClient/4.8.6?_src=template) to retrieve data from a Microsoft SQL server database and bind it to the Blazor DataGrid.

## Bind data using Custom Adaptor

**1.** Create a simple Blazor DataGrid by following the **"Getting Started"** documentation [link](https://blazor.syncfusion.com/documentation/datagrid/getting-started-with-web-app).

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

<SfGrid @ref="Grid" TValue="Order" AllowSorting="true" AllowFiltering="true"  AllowGrouping="true" AllowPaging="true" Toolbar="@(new List<string>() { "Add", "Delete", "Update", "Cancel" })">
    <SfDataManager AdaptorInstance="@typeof(CustomAdaptor)" Adaptor="Adaptors.CustomAdaptor"></SfDataManager>
    <GridEditSettings AllowEditing="true" AllowDeleting="true" AllowAdding="true" Mode="@EditMode.Normal"></GridEditSettings>    
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

**4.** In the custom adaptor’s **Read** method, you can get the Grid action details like paging, filtering, sorting information, etc. using [DataManagerRequest](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManagerRequest.html).

* Based on the **DataManagerRequest**, form a SQL query string (to perform paging) and execute the SQL query. Retrieve the data from the database using **SqlDataAdapter** class.

* The Fill method of the **DataAdapter** is used to populate a DataSet with the results of the SelectCommand of the DataAdapter, then convert the DataSet into the List.

* Return the response in **Result** and **Count** pair object in **Read** method to bind the data to the DataGrid.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@rendermode InteractiveServer

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor
@using Microsoft.Data.SqlClient;

<SfGrid @ref="Grid" TValue="Order" AllowSorting="true" AllowFiltering="true"  AllowGrouping="true" AllowPaging="true" Toolbar="@(new List<string>() { "Add", "Delete", "Update", "Cancel" })">
    <SfDataManager AdaptorInstance="@typeof(CustomAdaptor)" Adaptor="Adaptors.CustomAdaptor"></SfDataManager>
    <GridEditSettings AllowEditing="true" AllowDeleting="true" AllowAdding="true" Mode="@EditMode.Normal"></GridEditSettings>    
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
    
     public class CustomAdaptor : DataAdaptor
  {
      public OrderData Order = new OrderData();
      // Performs data Read operation
      public override async Task<object> ReadAsync(DataManagerRequest dm, string key = null)
      {
          IEnumerable<Order> DataSource = await Order.GetOrdersAsync();    
          int count = DataSource.Cast<Order>().Count();
          if (dm.Skip != 0)
          {
              //Paging
              DataSource = DataOperations.PerformSkip(DataSource, dm.Skip);
          }
          if (dm.Take != 0)
          {
              DataSource = DataOperations.PerformTake(DataSource, dm.Take);
          }
          return dm.RequiresCounts ? new DataResult() { Result = DataSource, Count = count } : (object)DataSource;
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

While running the application, the grid will be displayed as follows.

![Blazor Grid bound with Microsoft SQL data](../images/blazor-Grid-Ms-SQL-databinding.png)

### Handling data operations

The Syncfusion Grid component offers a range of powerful features for handling grid actions such as **grouping**, **sorting** and **filtering**. This ensures efficient data retrieval and manipulation, providing a better user experience. Below are explanations on how to handle these data operations effectively in Custom Adaptor:

#### Filtering 

When using a custom adaptor, the filtering operation has to be handled by overriding the Read/ReadAsync method of the **DataAdaptor** abstract class.

In the below code example, a custom data source can be filtered using the built-in `PerformFiltering` method of the `DataOperations` class. Also, you can use your own method to do the filtering operation and bind the resultant data to the grid.

{% highlight razor %}

   public class CustomAdaptor : DataAdaptor
   {
       public OrderData Order = new OrderData();
       // Performs data Read operation
       public override async Task<object> ReadAsync(DataManagerRequest dm, string key = null)
       {
           IEnumerable<Order> DataSource = await Order.GetOrdersAsync();    
            if (dm.Where != null && dm.Where.Count > 0)
           {
               // Filtering
               DataSource = DataOperations.PerformFiltering(DataSource, dm.Where, dm.Where[0].Operator);
           }
           int count = DataSource.Cast<Order>().Count();
           return dm.RequiresCounts ? new DataResult() { Result = DataSource, Count = count } : (object)DataSource;
       }

{% endhighlight %}

#### Sorting 

When using a custom adaptor, the sorting operation has to be handled by overriding the Read/ReadAsync method of the **DataAdaptor** abstract class.

In the below code example, a custom data source can be sorted using the built-in `PerformSorting` method of the `DataOperations` class. Also, you can use your own method to do the sorting operation and bind the resultant data to the grid.

{% highlight razor %}

   public class CustomAdaptor : DataAdaptor
   {
       public OrderData Order = new OrderData();
       // Performs data Read operation
       public override async Task<object> ReadAsync(DataManagerRequest dm, string key = null)
       {
           IEnumerable<Order> DataSource = await Order.GetOrdersAsync();    
           
              if (dm.Sorted != null && dm.Sorted.Count > 0)
           {
               // Sorting
               DataSource = DataOperations.PerformSorting(DataSource, dm.Sorted);
           }
           int count = DataSource.Cast<Order>().Count();
           return dm.RequiresCounts ? new DataResult() { Result = DataSource, Count = count } : (object)DataSource;
       }

{% endhighlight %}

#### Grouping 

When using Custom Adaptor, the grouping operation has to be handled in the Read/ReadAsync method of Custom adaptor.

The following sample code demonstrates implementing the grouping operation in Custom Adaptor, 

{% highlight razor %}

   public class CustomAdaptor : DataAdaptor
   {
       public OrderData Order = new OrderData();
       // Performs data Read operation
       public override async Task<object> ReadAsync(DataManagerRequest dm, string key = null)
       {
           IEnumerable<Order> DataSource = await Order.GetOrdersAsync();    
           int count = DataSource.Cast<Order>().Count();
           DataResult DataObject = new DataResult();
           if (dm.Group != null)
           {
              IEnumerable ResultData = DataSource.ToList();
               // Grouping
               foreach (var group in dm.Group)
               {
                   ResultData = DataUtil.Group<Order>(ResultData, group, dm.Aggregates, 0, dm.GroupByFormatter);
               }
               DataObject.Result = ResultData;
               DataObject.Count = count;
               return dm.RequiresCounts ? DataObject : (object)ResultData;
           }

           return dm.RequiresCounts ? new DataResult() { Result = DataSource, Count = count } : (object)DataSource;
       }
{% endhighlight %}

### Handling CRUD operations

Enable editing in the grid component using the [GridEditSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEditSettings.html) component. Grid provides various modes of editing options such as Inline/Normal, Dialog and Batch editing. Refer the [Grid Editing](https://blazor.syncfusion.com/documentation/datagrid/editing) documentation for reference.

Here, inline edit mode and [Toolbar](https://blazor.syncfusion.com/documentation/datagrid/tool-bar) property are used to show toolbar items for editing.

{% highlight razor %}

<SfGrid @ref="Grid" TValue="Order" AllowPaging="true" Toolbar="@(new List<string>() { "Add","Edit","Delete","Update","Cancel"})">
    <GridEditSettings AllowAdding="true" AllowDeleting="true" AllowEditing="true"></GridEditSettings>
</SfGrid>

{% endhighlight %}

> Normal editing is the default edit mode for the DataGrid component. Also, to perform CRUD operations, set [IsPrimaryKey](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_IsPrimaryKey) property as **true** for a particular GridColumn, whose value is a unique.

The CRUD operations can be performed and customized on our own by overriding the following CRUD methods of the DataAdaptor abstract class.

* Insert/InsertAsync
* Remove/RemoveAsync
* Update/UpdateAsync
* BatchUpdate/BatchUpdateAsync

Let’s see how to perform CRUD operation using SQL server data with Syncfusion Blazor DataGrid component.

#### Insert Operation

To Perform the Insert operation, override the Insert/InsertAsync method of the custom adaptor and add the following code in the CustomAdaptorComponent.razor.

{% tabs %}
{% highlight razor tabtitle="Index.razor"%}

 public override async Task<object> InsertAsync(DataManager DataManager, object Value, string Key)
 {
     await Order.AddOrderAsync(Value as Order);
     return Value;
 }

{% endhighlight %}
{% highlight razor tabtitle="Orderdata.cs"%}
 public async Task AddOrderAsync(Order Value)
 {
     string connectionString = @"<Enter a valid connection string>";
     string QueryStr = $"Insert into Orders(CustomerID,Freight,ShipCity,EmployeeID) values('{(Value as Order).CustomerID}','{(Value as Order).Freight}','{(Value as Order).ShipCity}','{(Value as Order).EmployeeID}')";
     SqlConnection Con = new SqlConnection(connectionString);
     Con.Open();
     SqlCommand Cmd = new SqlCommand(QueryStr, Con);
     Cmd.ExecuteNonQuery();
     Con.Close();
 }
{% endhighlight %}
{% endtabs %}

#### Update Operation

To Perform the Update operation, override the Update/UpdateAsync method of the custom adaptor and add the following code in the CustomAdaptorComponent.razor.

{% tabs %}
{% highlight razor tabtitle="Index.razor"%}

// Performs Update operation
 public override async Task<object> UpdateAsync(DataManager dm, object Value, string keyField, string key)
 {
     await Order.UpdateOrderAsync(Value as Order);
     return Value;
 }

{% endhighlight %}
{% highlight razor tabtitle="Orderdata.cs"%}
 public async Task UpdateOrderAsync(Order Value)
 {
     string connectionString = @"<Enter a valid connection string>";
     string QueryStr = $"Update Orders set CustomerID='{(Value as Order).CustomerID}', Freight={(Value as Order).Freight},EmployeeID={(Value as Order).EmployeeID},ShipCity={(Value as Order).ShipCity} where OrderID={(Value as Order).OrderID}";

     SqlConnection Con = new SqlConnection(connectionString);

     Con.Open();
     SqlCommand Cmd = new SqlCommand(QueryStr, Con);
     Cmd.ExecuteNonQuery();
     Con.Close();
 }
{% endhighlight %}
{% endtabs %}

#### Delete Operation

To Perform the Delete operation, override the Remove/RemoveAsync method of the custom adaptor and add the following code in the CustomAdaptorComponent.razor.

{% tabs %}
{% highlight razor tabtitle="Index.razor"%}

public override async Task<object> RemoveAsync(DataManager dm, object Value, string keyField, string key)
{
    await Order.RemoveOrderAsync(Value as int?);
    return Value;
}

{% endhighlight %}
{% highlight razor tabtitle="Orderdata.cs"%}
public async Task RemoveOrderAsync(int? Value)
{
    string connectionString = @"<Enter a valid connection string>"; 
    string QueryStr = $"Delete from Orders where OrderID={Value}";
    SqlConnection Con = new SqlConnection(connectionString);
    Con.Open();
    SqlCommand Cmd = new SqlCommand(QueryStr, Con);
    Cmd.ExecuteNonQuery();
    Con.Close();
}
{% endhighlight %}
{% endtabs %}

> You can find the sample in this [GitHub location](https://github.com/VigneshNatarajan27/connecting-microsoft-sql-data-base-to-data-grid).

## Bind data using an API Service with a Url Adaptor

### Creating a API service 

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

**5.** Run the application and it will be hosted within the URL `https://localhost:7033`.

**6.** Finally, the retrieved data from Microsoft SQL database which is in the form of JSON can be found in the API controller available in the URL link `https://localhost:7033/api/Grid`, as shown in the browser page below.

![Hosted API URL](../images/Ms-Sql-data.png)

### Connecting the Grid to API service

**1.** Create a simple Blazor Grid by following the **"Getting Started"** documentation [link](https://blazor.syncfusion.com/documentation/datagrid/getting-started-with-web-app).

**2.** Map the hosted API's URL link `https://localhost:7033/api/Grid` to the Grid in **Index.razor** by using the [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) to the [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_DataSource) property or by using [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) component. To interact with remote data source, provide the endpoint **Url**.

{% tabs %}
{% highlight razor tabtitle="Index.razor"%}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor
@using Microsoft.Data.SqlClient;

<SfGrid @ref="Grid" TValue="Order" AllowPaging="true" AllowFiltering="true" AllowSorting="true" AllowGrouping="true" Toolbar="@(new List<string>() { "Add", "Delete", "Update", "Cancel" })">
    <SfDataManager Url="https://localhost:7033/api/Grid" InsertUrl="https://localhost:7033/api/Grid/Insert" UpdateUrl="https://localhost:7033/api/Grid/Update" RemoveUrl="https://localhost:7033/api/Grid/Delete" Adaptor="Adaptors.UrlAdaptor"></SfDataManager>
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

When you run the application, the resultant Grid will look like this

![Blazor Grid bound with Microsoft SQL data](../images/blazor-Grid-Ms-SQL-databinding.png)

### Handling data operations

The Syncfusion Grid component offers a range of powerful features for handling grid actions such as **grouping**, **sorting** and **filtering**.This ensures efficient data retrieval and manipulation, providing a better user experience. Below are explanations on how to handle these data operations effectively in Custom Adaptor:

#### Filtering 

To handle filtering operations, ensure that your API endpoint supports custom filtering criteria. Implement the filtering logic on the server-side using the `PerformFiltering` method from the `DataOperations` class. This allows the custom data source to undergo filtering based on the criteria specified in the incoming **DataManagerRequest** object.

{% highlight razor %}
 [HttpPost]
[Route("api/[controller]")]
public object Post([FromBody] DataManagerRequest dm)
{
    IEnumerable<Order> DataSource = GetSQLResult();
    if (dm.Where != null && dm.Where.Count > 0)
    {
        // Filtering
        DataSource = DataOperations.PerformFiltering(DataSource, dm.Where, dm.Where[0].Operator);
    }
     int count = DataSource.Cast<Order>().Count();
    return new { result = DataSource, count = count };
}
{% endhighlight %}

#### Sorting

To handle filtering operations, ensure that your API endpoint supports custom sorting criteria. Implement the sorting logic on the server-side using the `PerformSorting` method from the `DataOperations` class. This allows the custom data source to undergo sorting based on the criteria specified in the incoming **DataManagerRequest** object.

{% highlight razor %}
 [HttpPost]
 [Route("api/[controller]")]
 public object Post([FromBody] DataManagerRequest dm)
 {
     IEnumerable<Order> DataSource = GetSQLResult();
     if (dm.Sorted != null && dm.Sorted.Count > 0)
     {
         // Sorting
         DataSource = DataOperations.PerformSorting(DataSource, dm.Sorted);
     }
     int count = DataSource.Cast<Order>().Count();
     return new { result = DataSource, count = count };
 }
{% endhighlight %}

#### Grouping 

To handle grouping operations, ensure that your  API endpoint supports custom grouping criteria. Implement the grouping logic on the server-side using the Group method from the [DataUtil](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.DataUtil.html) class. This allows the custom data source to undergo grouping based on the criteria specified in the incoming **DataManagerRequest** object.

{% highlight razor %}
 [HttpPost]
 [Route("api/[controller]")]
 public object Post([FromBody] DataManagerRequest dm)
 {
     IEnumerable<Order> DataSource = GetSQLResult();
     int count = DataSource.Cast<Order>().Count();
     DataResult DataObject = new DataResult();
     if (dm.Group != null)
     {
         System.Collections.IEnumerable ResultData = DataSource.ToList();

         // Grouping
         foreach (var group in dm.Group)
         {
             ResultData = DataUtil.Group<Order>(ResultData, group, dm.Aggregates, 0, dm.GroupByFormatter);
         }
         DataObject.Result = ResultData;
         DataObject.Count = count;
         return dm.RequiresCounts ? DataObject : (object)ResultData;
     }
     return new { result = DataSource, count = count };
 }
{% endhighlight %}

### Handling CRUD operations 

You can enable editing in the grid component using the [GridEditSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEditSettings.html) component. Grid provides various modes of editing options such as [Inline/Normal](https://blazor.syncfusion.com/documentation/datagrid/in-line-editing), [Dialog](https://blazor.syncfusion.com/documentation/datagrid/dialog-editing), and [Batch](https://blazor.syncfusion.com/documentation/datagrid/batch-editing) editing.

Here, Inline edit mode is utilized, and used Toolbar property to show toolbar items for editing.
DataGrid Editing and Toolbar code have been added to the previous Grid model.

{% tabs %}
{% highlight razor %}

<SfGrid @ref="Grid" TValue="Order" AllowPaging="true" AllowFiltering="true" AllowSorting="true" AllowGrouping="true" Toolbar="@(new List<string>() { "Add", "Delete", "Update", "Cancel" })">
    <SfDataManager Url="https://localhost:7033/api/Grid" InsertUrl="https://localhost:7033/api/Grid/Insert" UpdateUrl="https://localhost:7033/api/Grid/Update" RemoveUrl="https://localhost:7033/api/Grid/Delete" Adaptor="Adaptors.UrlAdaptor"></SfDataManager>
    <GridEditSettings AllowEditing="true" AllowDeleting="true" AllowAdding="true" Mode="EditMode.Normal"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" IsIdentity="true" IsPrimaryKey="true" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.EmployeeID) HeaderText="Employee ID" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipCity) HeaderText="Ship City" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

{% endhighlight %}
{% endtabs %}

> Normal editing is the default edit mode for the DataGrid component. Set the [IsPrimaryKey](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_IsPrimaryKey) property of Column as **true** for a particular column, whose value is a unique value for editing purposes.

#### Insert a row

To insert a new row, click the **Add** toolbar button. The new record edit form will look like below.

Clicking the **Update** toolbar button will insert the record in the Orders table by calling the following **POST** method of the  API.

{% tabs %}
{% highlight c# tabtitle="OrdersController.cs" %}
 [HttpPost]
 [Route("api/Grid/Insert")]
 public void Insert([FromBody] CRUDModel<Order> value)
 {
     string connectionString = @"<Enter a valid connection string>";
     string QueryStr = $"Insert into Orders(CustomerID,Freight,ShipCity,EmployeeID) values('{value.Value.CustomerID}','{value.Value.Freight}','{value.Value.ShipCity}','{value.Value.EmployeeID}')";
     SqlConnection Con = new SqlConnection(connectionString);
     Con.Open();
     SqlCommand Cmd = new SqlCommand(QueryStr, Con);
     Cmd.ExecuteNonQuery();
     Con.Close();
 }
{% endhighlight %}
{% endtabs %}

#### Update a row

To edit a row, select any row and click the **Edit** toolbar button. The edit form will look like below. Edit the Customer Name column.

Clicking the **Update** toolbar button will update the record in the Orders table by calling the following **Post** method of the  API.

{% tabs %}
{% highlight c# tabtitle="OrdersController.cs" %}
 [HttpPost]
 [Route("api/Grid/Update")]
 public void Update([FromBody] CRUDModel<Order> value)
 {
     string connectionString = @"<Enter a valid connection string>";
     string QueryStr = $"Update Orders set CustomerID='{value.Value.CustomerID}', Freight='{value.Value.Freight}',EmployeeID='{value.Value.EmployeeID}',ShipCity='{value.Value.ShipCity}' where OrderID='{value.Value.OrderID}'";
     SqlConnection Con = new SqlConnection(connectionString);
     Con.Open();
     SqlCommand Cmd = new SqlCommand(QueryStr, Con);
     Cmd.ExecuteNonQuery();
     Con.Close();
 }
{% endhighlight %}
{% endtabs %}

#### Delete a row

To delete a row, select any row and click the **Delete** toolbar button. Deleting operation will send a **DELETE** request to the API with the selected record`s primary key value to remove the corresponding record from the Orders table.

{% tabs %}
{% highlight c# tabtitle="OrdersController.cs" %}
[HttpPost]
[Route("api/Grid/Delete")]
public void Delete([FromBody] CRUDModel<Order> Value)
{
    string connectionString = @"<Enter a valid connection string>";
    string QueryStr = $"Delete from Orders where OrderID={Value.Key}";
    SqlConnection Con = new SqlConnection(connectionString);
    Con.Open();
    SqlCommand Cmd = new SqlCommand(QueryStr, Con);
    Cmd.ExecuteNonQuery();
 }
{% endhighlight %}
{% endtabs %}

> Find the sample from this [Github location](https://github.com/VigneshNatarajan27/connecting-sql-data-base-to-data-grid-using-api-service).
