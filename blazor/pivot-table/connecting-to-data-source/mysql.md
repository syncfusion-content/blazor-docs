---
title: "MySQL Data Binding in Blazor Pivot Table Component | Syncfusion"
component: "Pivot Table"
description: Checkout and learn here all about how to bind data from a MySQL in the Syncfusion Blazor Pivot Table and more.
---

# MySQL Data Binding

This section describes how to use [MySQL data](https://www.nuget.org/packages/MySql.Data) to retrieve data from a MySQL server and bind it to the Blazor Pivot Table.

## Connecting a MySQL database to a Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Pivot Table

**1.** Create a simple Blazor Pivot Table by following the **"Getting Started"** documentation [link](../getting-started).

**2.** To connect a MySQL using the MySQL driver in our application, we need to install the [MySQL.Data](https://www.nuget.org/packages/MySql.Data) NuGet package. To do so, open the NuGet package manager of the project solution, search for the package **MySQL.Data** and install it.

![Add the NuGet package "MySQL.Data" to the project](../images/MySQL-nuget-package-install-in-web-service-app.png)

**3.** Next, in the **Index.razor** page, under the **OnInitialized** method, connect to MySQL. **MySqlConnection** helps to connect the MySQL database. Next, using **MySqlCommand** and **MySqlDataAdapter** you can process the desired query string and retrieve data from the MySQL database. The **Fill** method of the **MySqlDataAdapter** is used to populate the retrieved data into a **DataTable**,  which is then converted to a List.

**4.** Finally, bind the list to the [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewDataSourceSettings-1.html?&_ga=2.187712492.558891908.1675655056-779654442.1675225237#Syncfusion_Blazor_PivotView_PivotViewDataSourceSettings_1_DataSource) property in the [PivotViewDataSourceSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.DataSourceSettingsModel-1.html?_ga=2.112723776.558891908.1675655056-779654442.1675225237) and configure the report to use the MySQL data.

```cshtml
@using Syncfusion.Blazor.PivotView
@using MySql.Data.MySqlClient;
@using Newtonsoft.Json;
@using System.Data;
@using Syncfusion.Blazor.Data;

<SfPivotView TValue="OrderDetails" Width="800" Height="340">
    <PivotViewDataSourceSettings TValue="OrderDetails" DataSource="@dataSource">
        <PivotViewColumns>
            <PivotViewColumn Name="ShipName"></PivotViewColumn>
        </PivotViewColumns>
        <PivotViewRows>
            <PivotViewRow Name="ShipCity"></PivotViewRow>
        </PivotViewRows>
        <PivotViewValues>
            <PivotViewValue Name="Freight"></PivotViewValue>
        </PivotViewValues>
        <PivotViewFormatSettings>
            <PivotViewFormatSetting Name="Freight" Format="N2"></PivotViewFormatSetting>
        </PivotViewFormatSettings>
        </PivotViewDataSourceSettings>
</SfPivotView>

@code {
    private List<OrderDetails> dataSource { get; set; }

    protected override void OnInitialized()
    {
        MySqlConnection connection = new MySqlConnection("<Enter your valid connection string here>");
        connection.Open();
        MySqlCommand command = new MySqlCommand("SELECT * FROM orders", connection);
        MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command);
        DataTable dataTable = new DataTable();
        dataAdapter.Fill(dataTable);
        connection.Close();
        dataSource = (from DataRow data in dataTable.Rows
                       select new OrderDetails()
                           {
                               OrderID = Convert.ToInt32(data["OrderId"]),
                               CustomerID = data["CustomerID"].ToString(),
                               ShipCity = data["ShipCity"].ToString(),
                               ShipName = data["ShipName"].ToString(),
                               Freight = Convert.ToDouble(data["Freight"])
                           }).ToList();

    }

    public class OrderDetails
    {
        public int OrderID { get; set; }
        public string CustomerID { get; set; }
        public string ShipCity { get; set; }
        public string ShipName { get; set; }
        public double Freight { get; set; }
        }
   
}
```

When you run the application, the resultant pivot table will look like this.

![Blazor Pivot Table bound with MySQL data](../images/blazor-pivottable-MySQL-databinding.png)

## Connecting a MySQL to a Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Pivot Table via Web API service

### Create a Web API service to fetch MySQL data

**1.** Open Visual Studio and create an ASP.NET Core Web App project type, naming it **MyWebService**. To create an ASP.NET Core Web application, follow the documentation [link](https://learn.microsoft.com/en-us/visualstudio/get-started/csharp/tutorial-aspnet-core?view=vs-2022).

![Create ASP.NET Core Web App project](../images/azure-asp-core-web-service-create.png)

**2.** To connect a MySQL using the **MySQL data** in our application, we need to install the [MySQL.Data](https://www.nuget.org/packages/MySQL.Driver) NuGet package. To do so, open the NuGet package manager of the project solution, search for the package **MySQL.Data** and install it.

![Add the NuGet package "MySQL.Data" to the project](../images/MySQL-nuget-package-install-in-web-service-app.png)

**3.** Create a Web API controller (aka, PivotController.cs) file under **Controllers** folder that helps to establish data communication with the Pivot Table.

**4.** In the Web API controller (aka, PivotController), ***MySqlConnection** helps to connect the MySQL database. Next, using **MySqlCommand** and **MySqlDataAdapter** you can process the desired query string and retrieve data from the MySQL database. The **Fill** method of the **MySqlDataAdapter** is used to populate the retrieved data into a **DataTable** as shown in the following code snippet.

```csharp
    using Microsoft.AspNetCore.Mvc;
    using MySql.Data.MySqlClient;
    using Newtonsoft.Json;
    using System.Data;

    namespace MyWebService.Controllers
    {
        [ApiController]
        [Route("[controller]")]
        public class PivotController : ControllerBase
        {
            public dynamic GetMySQLResult()
            {
                // Replace with your own connection string.
                MySqlConnection connection = new MySqlConnection("<Enter your valid connection string here>");
                connection.Open();
                MySqlCommand command = new MySqlCommand("SELECT * FROM orders", connection);
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                connection.Close();
                return dataTable;
            }
        }
    }

```

**5.** In the **Get()** method of the **PivotController.cs** file, the **GetMySQLResult** method is used to retrieve the MySQL data as a list, which is then serialized into JSON string using **JsonConvert.SerializeObject()**.

```csharp
    using Microsoft.AspNetCore.Mvc;
    using MySql.Data.MySqlClient;
    using Newtonsoft.Json;
    using System.Data;

    namespace MyWebService.Controllers
    {
        [ApiController]
        [Route("[controller]")]
        public class PivotController : ControllerBase
        {
            [HttpGet(Name = "GetMySQLResult")]
            public object Get()
            {
                return JsonConvert.SerializeObject(GetMySQLResult());
            }

            public dynamic GetMySQLResult()
            {
                // Replace with your own connection string.
                MySqlConnection connection = new MySqlConnection("<Enter your valid connection string here>");
                connection.Open();
                MySqlCommand command = new MySqlCommand("SELECT * FROM orders", connection);
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                connection.Close();
                return dataTable;
            }
        }
    }

```

**6.** Run the application and it will be hosted within the URL `https://localhost:7146`.

**7.** Finally, the retrieved data from MySQL database which is in the form of JSON can be found in the Web API controller available in the URL link `https://localhost:7146/Pivot`, as shown in the browser page below.

![Hosted Web API URL](../images/mysql-data.png)

### Connecting the Pivot Table to a MySQL using the Web API service

**1.** Create a simple Blazor Pivot Table by following the **"Getting Started"** documentation [link](../getting-started).

**2.** Map the hosted Web API's URL link `https://localhost:7146/Pivot` to the Pivot Table in **Index.razor** by using the [Url](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html?&_ga=2.200411303.844585580.1677740066-2135459383.1677740066#Syncfusion_Blazor_DataManager_Url) property under [PivotViewDataSourceSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.DataSourceSettingsModel-1.html?_ga=2.200411303.844585580.1677740066-2135459383.1677740066). This [Url](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewDataSourceSettings-1.html#Syncfusion_Blazor_PivotView_PivotViewDataSourceSettings_1_Url) property aids in the de-serialization of MySQL data into instances of your model data class (aka, TValue="ProductDetails") while bound to the pivot table.

```cshtml
@using Syncfusion.Blazor.PivotView

<SfPivotView TValue="OrderDetails" Width="1000" Height="300" ShowFieldList="true">
    <PivotViewDataSourceSettings TValue="OrderDetails" Url="https://localhost:7146/Pivot" ExpandAll=false EnableSorting=true>
         <PivotViewColumns>
            <PivotViewColumn Name="ShipName"></PivotViewColumn>
        </PivotViewColumns>
        <PivotViewRows>
            <PivotViewRow Name="ShipCity"></PivotViewRow>
        </PivotViewRows>
        <PivotViewValues>
            <PivotViewValue Name="Freight"></PivotViewValue>
        </PivotViewValues>
        <PivotViewFormatSettings>
            <PivotViewFormatSetting Name="Freight" Format="N2"></PivotViewFormatSetting>
        </PivotViewFormatSettings>
    </PivotViewDataSourceSettings>
    <PivotViewGridSettings ColumnWidth="120"></PivotViewGridSettings>
</SfPivotView>

@code {
    public class OrderDetails
    {
        public int OrderID { get; set; }
        public string ShipName { get; set; }
        public string CustomerID { get; set; }
        public string ShipCity { get; set; }
        public double Freight { get; set; }
    }
}
```


When you run the application, the resultant pivot table will look like this.

![Blazor Pivot Table bound with MySQL data](../images/blazor-pivottable-MySQL-databinding.png)

> In [this](https://github.com/SyncfusionExamples/how-to-bind-MySQL-to-pivot-table/tree/master/Blazor) GitHub repository, you can find our Blazor Pivot Table sample for binding data from a MySQL using the Web API service.
