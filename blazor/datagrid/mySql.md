---
layout: post
title: MySQL Data Binding in Blazor DataGrid Component | Syncfusion
description: Learn about consuming data from MYSQL and binding it to Syncfusion Component, and performing CRUD operations
platform: Blazor
control: DataGrid
documentation: ug
---

# MySQL Data Binding in DataGrid

This section describes how to use [MySQL data](https://www.nuget.org/packages/MySql.Data) to retrieve data from a MySQL server and bind it to the Blazor Pivot Table.

## Connecting a MySQL database to a Syncfusion Blazor Grid

**1.** Create a simple Blazor Grid by following the **"Getting Started"** documentation [link](https://blazor.syncfusion.com/documentation/datagrid/getting-started-with-web-app).

**2.** To connect a MySQL using the MySQL driver in our application, we need to install the [MySQL.Data](https://www.nuget.org/packages/MySql.Data) NuGet package. To do so, open the NuGet package manager of the project solution, search for the package **MySQL.Data** and install it.

![Add the NuGet package MySQL.Data to the project](./images/MySQL-nuget-package-install.png)

**3.** Next, in the **Index.razor** page, get the MySQL data from the MySQL server and bind it to the DataGrid component as a datasource by using the Custom adaptor feature and configure the report to use the MySQL data.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@rendermode InteractiveServer

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor
@using Microsoft.Data.SqlClient;
@using BlazorApp6.Data;

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

**4.** In the custom adaptor’s **Read** method, you can get the Grid action details like paging,filtering,sorting information, etc., using **DataManagerRequest**.

* Based on the DataManagerRequest, form a MySQL query string (to perform paging) and execute the MySQL query. Retrieve the data from the database using MySqlDataAdapter.

* The Fill method of the DataAdapter is used to populate a DataSet with the results of the SelectCommand of the DataAdapter, then convert the DataSet into the List.

* Return the response in Result and Count pair object in Read method to bind the data to the DataGrid.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@rendermode InteractiveServer

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor
@using MySql.Data.MySqlClient;
@using MySqlBlazorApp.Data;

<SfGrid @ref="Grid" TValue="Order" AllowPaging="true" Toolbar="@(new List<string>() { "Add","Edit", "Delete", "Update", "Cancel" })">
    <SfDataManager AdaptorInstance="@typeof(CustomAdaptor)" Adaptor="Adaptors.CustomAdaptor"></SfDataManager>
    <GridEditSettings AllowEditing="true" AllowDeleting="true" AllowAdding="true" Mode="@EditMode.Normal"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID"  IsPrimaryKey="true" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerName) HeaderText="Customer Name" Width="150"></GridColumn>
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
            IEnumerable<Order> DataSource = await Order.GetOrdersAsync(dm.Skip, dm.Take);
            int count = await Order.GetOrderCountAsync();
            return dm.RequiresCounts ? new DataResult() { Result = DataSource, Count = count } : (object)DataSource;
        }
}

{% endhighlight %}
{% highlight razor tabtitle="Orderdata.cs" %}
public class OrderData
{
      public async Task<List<Order>> GetOrdersAsync(int Skip, int Take)
  {
      string connectionString = "server=localhost;port=3306;user=root;database=firstdatabase;password=Spnk&&7777";
      string queryStr = $"SELECT * FROM orders ORDER BY OrderID LIMIT {Take} OFFSET {Skip}";
      List<Order> orders = null;

      using (MySqlConnection connection = new MySqlConnection(connectionString))
      {
          MySqlDataAdapter adapter = new MySqlDataAdapter(queryStr, connection);
          DataSet data = new DataSet();

          connection.Open();

          adapter.Fill(data);
          orders = data.Tables[0].AsEnumerable().Select(r => new Order
          {
              OrderID = r.Field<int>("OrderID"),
              CustomerName = r.Field<string>("CustomerName"),
              EmployeeID = r.Field<int>("EmployeeID"),
              ShipCity = r.Field<string>("ShipCity"),
              Freight = r.Field<decimal>("Freight")
          }).ToList();

          connection.Close();
      }
      return orders;
  }

  public async Task<int> GetOrderCountAsync()
  {
      string connectionString = "server=localhost;port=3306;user=root;database=firstdatabase;password=Spnk&&7777";
      string queryStr = "SELECT COUNT(*) FROM orders";
      MySqlConnection con = new MySqlConnection(connectionString);

      con.Open();
      MySqlCommand cmd = new MySqlCommand(queryStr, con);
      int count = Convert.ToInt32(cmd.ExecuteScalar());
      con.Close();

      return count;
  }
}
{% endhighlight %}
{% endtabs %}

While running the application, the grid will be displayed as follows.

![Blazor Grid bound with MYSQL data](./images/blazor-Grid-MYSQL-databinding.png)

### Handling CRUD operations with our Syncfusion Blazor DataGrid component

Enable editing in the grid component using the [GridEditSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEditSettings.html) component. Grid provides various modes of editing options such as Inline/Normal, Dialog and Batch editing. Refer the [Grid Editing](https://blazor.syncfusion.com/documentation/datagrid/editing) documentation for reference.

Here, inline edit mode and [Toolbar](https://blazor.syncfusion.com/documentation/datagrid/tool-bar) property are used to show toolbar items for editing.

{% highlight razor %}

<SfGrid @ref="Grid" TValue="Order" AllowPaging="true" Toolbar="@(new List<string>() { "Add","Edit","Delete","Update","Cancel"})">
    <GridEditSettings AllowAdding="true" AllowDeleting="true" AllowEditing="true"></GridEditSettings>
</SfGrid>

{% endhighlight %}

> Normal editing is the default edit mode for the DataGrid component. Also, to perform CRUD operations, set IsPrimaryKey property as True for a particular GridColumn, whose value is a unique.

The CRUD operations can be performed and customized on our own by overriding the following CRUD methods of the DataAdaptor abstract class.

* Insert/InsertAsync
* Remove/RemoveAsync
* Update/UpdateAsync
* BatchUpdate/BatchUpdateAsync

Let’s see how to perform CRUD operation using SQL server data with Syncfusion Blazor DataGrid component

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
 public async Task AddOrderAsync(Order value)
 {
     string ConnectionStr = "server=localhost;port=3306;user=root;database=firstdatabase;password=Spnk&&7777";
     string queryStr = $"INSERT INTO orders(CustomerName, Freight, ShipCity, EmployeeID) VALUES('{value.CustomerName}', '{value.Freight}', '{value.ShipCity}', '{value.EmployeeID}')";
     MySqlConnection Con = new MySqlConnection(ConnectionStr);
     Con.Open();
     MySqlCommand Cmd = new MySqlCommand(queryStr, Con);
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
 public async Task UpdateOrderAsync(Order value)
{
    string queryStr = $"UPDATE orders SET CustomerName = '{value.CustomerName}', Freight = {value.Freight}, EmployeeID = {value.EmployeeID}, ShipCity = '{value.ShipCity}' WHERE OrderID = {value.OrderID}";
    MySqlConnection Con = new MySqlConnection("server=localhost;port=3306;user=root;database=firstdatabase;password=Spnk&&7777");
    Con.Open();
    MySqlCommand Cmd = new MySqlCommand(queryStr, Con);
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
public async Task RemoveOrderAsync(int? value)
{
    string queryStr = $"DELETE FROM orders WHERE OrderID = {value}";
    MySqlConnection Con = new MySqlConnection("server=localhost;port=3306;user=root;database=firstdatabase;password=Spnk&&7777");
    Con.Open();
    MySqlCommand Cmd = new MySqlCommand(queryStr, Con);
    Cmd.ExecuteNonQuery();
    Con.Close();
}
{% endhighlight %}
{% endtabs %}

> You can find the sample in this [GitHub location]()

## Connecting a MySQL to a Syncfusion Blazor Pivot Table via Web API service

### Create a Web API service to fetch MySQL data

**1.** Open Visual Studio and create an ASP.NET Core Web App project type, naming it **MyWebService**. To create an ASP.NET Core Web application, follow the documentation [link](https://learn.microsoft.com/en-us/visualstudio/get-started/csharp/tutorial-aspnet-core?view=vs-2022).

![Create ASP.NET Core Web App project](./images/azure-asp-core-web-service-create.png)

**2.** To connect a MySQL using the **MySQL data** in our application, we need to install the [MySQL.Data](https://www.nuget.org/packages/MySql.Data) NuGet package. To do so, open the NuGet package manager of the project solution, search for the package **MySQL.Data** and install it.

![Add the NuGet package MySQL.Data to the project](./images/MySQL-nuget-package-install.png)

**3.** Create a Web API controller (aka, PivotController.cs) file under **Controllers** folder that helps to establish data communication with the Pivot Table.

**4.** In the Web API controller (aka, PivotController), ***MySqlConnection** helps to connect the MySQL database. Next, using **MySqlCommand** and **MySqlDataAdapter** you can process the desired query string and retrieve data from the MySQL database. The **Fill** method of the **MySqlDataAdapter** is used to populate the retrieved data into a **DataTable** as shown in the following code snippet.
{% tabs %}
{% highlight razor tabtitle="GridController.cs"%}
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.Extensions.Primitives;
namespace MyWebService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GridController : ODataController
    {

        public static List<Order> Orders { get; set; }

        public class Order
        {
            public int? OrderID { get; set; }
            public string CustomerName { get; set; }
            public int EmployeeID { get; set; }
            public decimal Freight { get; set; }
            public string ShipCity { get; set; }
        }
             
         public List<Order> GetMySQLResult(int skip, int top)
        {
            // Replace with your own connection string.
            MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;user=root;     database=firstdatabase;password=Spnk&&7777");
            connection.Open();
            MySqlCommand command = new MySqlCommand("SELECT * FROM orders", connection);
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            connection.Close();

            var dataSource = (from DataRow data in dataTable.Rows
                       select new Order()
                       {
                           OrderID = Convert.ToInt32(data["OrderID"]),
                           CustomerName = data["CustomerName"].ToString(),
                           EmployeeID = Convert.ToInt32(data["EmployeeID"]),
                           ShipCity = data["ShipCity"].ToString(),
                           Freight = Convert.ToDecimal(data["Freight"])
                       }).ToList();

            return dataSource;

        }
    }
}
{% endhighlight %}
{% endtabs %}


**5.** In the **Get()** method of the **GridController.cs** file, the **GetMySQLResult* method is used to retrieve the  MySQL data as a list.

{% tabs %}
{% highlight razor tabtitle="GridController.cs"%}
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Data;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.Extensions.Primitives;

namespace MySqlWebService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GridController : ODataController
    {

        public static List<Order> Orders { get; set; }

        public class Order
        {
            public int? OrderID { get; set; }
            public string CustomerName { get; set; }
            public int EmployeeID { get; set; }
            public decimal Freight { get; set; }
            public string ShipCity { get; set; }
        }
        [HttpGet(Name = "GetMySQLResult")]
        public async Task<object> Get()
        {
            var queryString = Request.Query;
            if (queryString.Keys.Contains("$inlinecount"))
            {
                var count = await GetOrderCountAsync();
                StringValues Skip;
                StringValues Take;
                int skip = (queryString.TryGetValue("$skip", out Skip)) ? Convert.ToInt32(Skip[0]) : 0;
                int top = (queryString.TryGetValue("$top", out Take)) ? Convert.ToInt32(Take[0]) : count;
                var data = GetMySQLResult(skip, top).AsQueryable();
                return new { Items = data, Count = count };
            }
            else
            {
                var count = await GetOrderCountAsync();
                var data = GetMySQLResult(0, count).AsQueryable();
                return data;
            }
        }

        public List<Order> GetMySQLResult(int skip, int top)
        {
            // Replace with your own connection string.
            MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;user=root;database=firstdatabase;password=Spnk&&7777");
            connection.Open();
            MySqlCommand command = new MySqlCommand("SELECT * FROM orders", connection);
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            connection.Close();

            var dataSource = (from DataRow data in dataTable.Rows
                              select new Order()
                              {
                                  OrderID = Convert.ToInt32(data["OrderID"]),
                                  CustomerName = data["CustomerName"].ToString(),
                                  EmployeeID = Convert.ToInt32(data["EmployeeID"]),
                                  ShipCity = data["ShipCity"].ToString(),
                                  Freight = Convert.ToDecimal(data["Freight"])
                              }).ToList();

            return dataSource;
        }
        
        public async Task<int> GetOrderCountAsync()
        {
            string connectionString = "server=localhost;port=3306;user=root;database=firstdatabase;password=Spnk&&7777";
            string queryStr = "SELECT COUNT(*) FROM orders";
            MySqlConnection con = new MySqlConnection(connectionString);

            con.Open();
            MySqlCommand cmd = new MySqlCommand(queryStr, con);
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();

            return count;
        }
    }
}
{% endhighlight %}
{% endtabs %}

**6.** Run the application and it will be hosted within the URL `https://localhost:7116`.

**7.** Finally, the retrieved data from MYSQL database which is in the form of JSON can be found in the Web API controller available in the URL link `https://localhost:7116/Grid`, as shown in the browser page below.

![Hosted Web API URL](./images/Ms-Sql-data.png)

### Connecting the Grid to a Microsoft SQL using the Web API service

**1.** Create a simple Blazor Pivot Table by following the **"Getting Started"** documentation [link](https://blazor.syncfusion.com/documentation/datagrid/getting-started-with-web-app).

**2.** Map the hosted Web API's URL link `https://localhost:7116/Grid` to the Grid in **Index.razor** by using the [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) to the [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_DataSource) property or by using [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) component. To interact with remote data source, provide the endpoint **Url**.

{% tabs %}
{% highlight razor tabtitle="Index.razor"%}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor

<SfGrid @ref="Grid" TValue="Order" AllowPaging="true" Toolbar="@(new List<string>() { "Add","Edit", "Delete", "Update", "Cancel" })">
    <SfDataManager Url="https://localhost:7116/Grid" Adaptor="Adaptors.WebApiAdaptor"></SfDataManager>
    <GridEditSettings AllowEditing="true" AllowDeleting="true" AllowAdding="true" Mode="EditMode.Normal"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" IsIdentity="true" IsPrimaryKey="true" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerName) HeaderText="Customer Name" Width="150"></GridColumn>
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
        public string CustomerName { get; set; }
        public int EmployeeID { get; set; }
        public decimal Freight { get; set; }
        public string ShipCity { get; set; }
    }
}
{% endhighlight %}
{% endtabs %}

When you run the application, the resultant pivot table will look like this

![Blazor Grid bound with MYSQL data](./images/blazor-Grid-MYSQL-databinding.png)

### Handling CRUD operations with our Syncfusion Blazor DataGrid component

You can enable editing in the grid component using the [GridEditSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEditSettings.html) component. Grid provides various modes of editing options such as [Inline/Normal](https://blazor.syncfusion.com/documentation/datagrid/in-line-editing), [Dialog](https://blazor.syncfusion.com/documentation/datagrid/dialog-editing), and [Batch](https://blazor.syncfusion.com/documentation/datagrid/batch-editing) editing.

Here, we are using **Inline** edit mode and used Toolbar property to show toolbar items for editing.
We have added the DataGrid Editing and Toolbar code with previous Grid model.

{% tabs %}
{% highlight razor %}

<SfGrid @ref="Grid" TValue="Order" AllowPaging="true" Toolbar="@(new List<string>() { "Add","Edit", "Delete", "Update", "Cancel" })">
    <SfDataManager Url="https://localhost:7116/Grid" Adaptor="Adaptors.WebApiAdaptor"></SfDataManager>
    <GridEditSettings AllowEditing="true" AllowDeleting="true" AllowAdding="true" Mode="EditMode.Normal"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" IsIdentity="true" IsPrimaryKey="true" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerName) HeaderText="Customer Name" Width="150"></GridColumn>
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

Clicking the **Update** toolbar button will insert the record in the Orders table by calling the following **POST** method of the Web API.

{% tabs %}
{% highlight c# tabtitle="OrdersController.cs" %}
  [HttpPost]
  public object Post([FromBody] Order Value)
  {
      string QueryStr = $"Insert into Orders(CustomerName,Freight,ShipCity,EmployeeID) values('{(Value as Order).CustomerName}','{(Value as Order).Freight}','{(Value as Order).ShipCity}','{(Value as Order).EmployeeID}')";
      string ConnectionStr = "server=localhost;port=3306;user=root;database=firstdatabase;password=Spnk&&7777";
      MySqlConnection Con = new MySqlConnection(ConnectionStr);
      Con.Open();
      MySqlCommand Cmd = new MySqlCommand(QueryStr, Con);
      Cmd.ExecuteNonQuery();
      Con.Close();
      return Value;
  }
{% endhighlight %}
{% endtabs %}

#### Update a row

To edit a row, select any row and click the **Edit** toolbar button. The edit form will look like below. Edit the Customer Name column.

Clicking the **Update** toolbar button will update the record in the Orders table by calling the following **PUT** method of the Web API.

{% tabs %}
{% highlight c# tabtitle="OrdersController.cs" %}
 [HttpPut]
 public object Put([FromBody] Order Value)
 {
     string connectionString = "server=localhost;port=3306;user=root;database=firstdatabase;password=Spnk&&7777";

     string QueryStr = "Update Orders set CustomerName=@CustomerName, Freight=@Freight, EmployeeID=@EmployeeID, ShipCity=@ShipCity where OrderID=@OrderID";

     using (MySqlConnection Con = new MySqlConnection(connectionString))
     {
         Con.Open();
         using (MySqlCommand Cmd = new MySqlCommand(QueryStr, Con))
         {
             Cmd.Parameters.AddWithValue("@CustomerName", (Value as Order).CustomerName);
             Cmd.Parameters.AddWithValue("@Freight", (Value as Order).Freight);
             Cmd.Parameters.AddWithValue("@EmployeeID", (Value as Order).EmployeeID);
             Cmd.Parameters.AddWithValue("@ShipCity", (Value as Order).ShipCity);
             Cmd.Parameters.AddWithValue("@OrderID", (Value as Order).OrderID);

             Cmd.ExecuteNonQuery();
         }
     }

     return Value;
 }
{% endhighlight %}
{% endtabs %}

#### Delete a row

To delete a row, select any row and click the **Delete** toolbar button. Deleting operation will send a **DELETE** request to the Web API with the selected record`s primary key value to remove the corresponding record from the Orders table.

{% tabs %}
{% highlight c# tabtitle="OrdersController.cs" %}
 [HttpDelete("{id}")]
 public async void Delete([FromBody] int id)
 {
     string connectionString = "server=localhost;port=3306;user=root;database=firstdatabase;password=Spnk&&7777";
     string QueryStr = $"Delete from Orders where OrderID={id}";
     MySqlConnection Con = new MySqlConnection(connectionString);

     Con.Open();
     MySqlCommand Cmd = new MySqlCommand(QueryStr, Con);
     Cmd.ExecuteNonQuery();
     Con.Close();
 }
{% endhighlight %}
{% endtabs %}

N> Find the sample from this [Github]() location.