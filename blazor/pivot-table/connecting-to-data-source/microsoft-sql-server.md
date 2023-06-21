---
title: "Microsoft SQL Data Binding in Blazor Pivot Table Component | Syncfusion"
component: "Pivot Table"
description: "Learn how to bind data from a Microsoft SQL server in the Syncfusion Blazor Pivot Table and more."
---

# Microsoft SQL Data Binding

This section describes how to use [System.Data.SqlClient](https://www.nuget.org/packages/System.Data.SqlClient/4.8.5?_src=template) to retrieve data from a Microsoft SQL server database and bind it to the Blazor Pivot Table.

## Connecting a Microsoft SQL database to a Syncfusion Blazor Pivot Table

**1.** Create a simple Blazor Pivot Table by following the **"Getting Started"** documentation [link](../getting-started).

**2.** To connect a Microsoft SQL using the Microsoft SQL driver in our application, we need to install the [System.Data.SqlClient](https://www.nuget.org/packages/System.Data.SqlClient/4.8.5?_src=template) NuGet package. To do so, open the NuGet package manager of the project solution, search for the package **System.Data.SqlClient** and install it.

![Add the NuGet package "System.Data.SqlClient" to the project](../images/system-Data-sql-client-nuget-package-install.png)

**3.** Next, in the **Index.razor** page, under the **OnInitialized** method, connect to Microsoft SQL server. **SqlConnection** helps to connect the SQL database (that is, Database1.mdf). Next, using **SqlCommand** and **SqlDataAdapter** you can process the desired SQL query string and retrieve data from the database. The **Fill** method of the DataAdapter is used to populate the SQL data into a **DataTable** , which is then converted to List type.

**4.** Finally, bind the list to the [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewDataSourceSettings-1.html?&_ga=2.187712492.558891908.1675655056-779654442.1675225237#Syncfusion_Blazor_PivotView_PivotViewDataSourceSettings_1_DataSource) property in the [PivotViewDataSourceSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.DataSourceSettingsModel-1.html?_ga=2.112723776.558891908.1675655056-779654442.1675225237) and configure the report to use the Microsoft SQL data.

```cshtml
@using Syncfusion.Blazor.PivotView;
@using System.Data;
@using System.Data.SqlClient;

<SfPivotView TValue="OrderDetails" Width="800" Height="360">
    <PivotViewDataSourceSettings TValue="OrderDetails" DataSource="@dataSource">
        <PivotViewColumns>
            <PivotViewColumn Name="Product"></PivotViewColumn>
        </PivotViewColumns>
        <PivotViewRows>
            <PivotViewRow Name="Date"></PivotViewRow>
        </PivotViewRows>
        <PivotViewValues>
            <PivotViewValue Name="Amount"></PivotViewValue>
        </PivotViewValues>
        <PivotViewFormatSettings>
            <PivotViewFormatSetting Name="Amount" Format="C2"></PivotViewFormatSetting>
        </PivotViewFormatSettings>
        </PivotViewDataSourceSettings>
</SfPivotView>

@code {
    private List<OrderDetails> dataSource { get; set; }

    protected override void OnInitialized()
    {
        string conSTR = @"<Enter a valid connection string>";
        string xquery = "SELECT * FROM table1";
        SqlConnection sqlConnection = new(conSTR);
        sqlConnection.Open();
        SqlCommand sqlCommand = new(xquery, sqlConnection);
        SqlDataAdapter dataAdapter = new(sqlCommand);
        DataTable dataTable = new();
        dataAdapter.Fill(dataTable);
        dataSource = (from DataRow data in dataTable.Rows
                       select new OrderDetails()
                           {
                               Quantity = Convert.ToInt32(data["Quantity"]),                               
                               Product= data["Product"].ToString(),
                               Date = data["Date"].ToString(),
                               Country = data["Country"].ToString(),
                               Amount = Convert.ToDouble(data["Amount"])
                           }).ToList();
    }

    public class OrderDetails
    {
        public int Quantity { get; set; }
        public string Product { get; set; }
        public string Date { get; set; }
        public string Country { get; set; }
        public double Amount { get; set; }
    }  
}
```

When you run the application, the resultant pivot table will look like this.

![Blazor Pivot Table bound with Microsoft SQL data](../images/blazor-pivottable-Ms-SQL-databinding.png)

## Connecting a Microsoft SQL to a Syncfusion Blazor Pivot Table via Web API service

### Create a Web API service to fetch Microsoft SQL data

**1.** Open Visual Studio and create an ASP.NET Core Web App project type, naming it **MyWebService**. To create an ASP.NET Core Web application, follow the documentation [link](https://learn.microsoft.com/en-us/visualstudio/get-started/csharp/tutorial-aspnet-core?view=vs-2022).

![Create ASP.NET Core Web App project](../images/azure-asp-core-web-service-create.png)

**2.** To connect a Microsoft SQL using the **System.Data.SqlClient** in our application, we need to install the [System.Data.SqlClient](https://www.nuget.org/packages/System.Data.SqlClient/4.8.5?_src=template) NuGet package. To do so, open the NuGet package manager of the project solution, search for the package **System.Data.SqlClient** and install it.

![Add the NuGet package "Sytem.Data.SqlClient" to the project](../images/system-Data-sql-client-nuget-package-install.png)

**3.** Create a Web API controller (aka, PivotController.cs) file under **Controllers** folder that helps to establish data communication with the Pivot Table.

**4.** In the Web API controller (aka, PivotController), connect to Microsoft SQL server. **SqlConnection** helps to connect the SQL database (that is, Database1.mdf). Next, using **SqlCommand** and **SqlDataAdapter** you can process the desired SQL query string and retrieve data from the database. The **Fill** method of the DataAdapter is used to populate the SQL data into a **DataTable** as shown in the following code snippet.

```csharp
    using Microsoft.AspNetCore.Mvc;
    using Microsoft SQL.Data.Microsoft SQLClient;
    using Newtonsoft.Json;
    using System.Data;

    namespace MyWebService.Controllers
    {
        [ApiController]
        [Route("[controller]")]
        public class PivotController : ControllerBase
        {
            public dynamic GetMicrosoft SQLResult()
            {
                // Replace with your own connection string.
                string conSTR = @"<Enter a valid connection string>";
                string xquery = "SELECT * FROM table1";
                SqlConnection sqlConnection = new(conSTR);
                sqlConnection.Open();
                SqlCommand sqlCommand = new(xquery, sqlConnection);
                SqlDataAdapter dataAdapter = new(sqlCommand);
                DataTable dataTable = new();
                dataAdapter.Fill(dataTable);
                return dataTable;
            }
        }
    }

```

**5.** In the **Get()** method of the **PivotController.cs** file, the **GetMicrosoft SQLResult** method is used to retrieve the Microsoft SQL data as a list, which is then serialized into JSON string using **JsonConvert.SerializeObject()**.

```csharp
    using Microsoft.AspNetCore.Mvc;
    using Microsoft SQL.Data.Microsoft SQLClient;
    using Newtonsoft.Json;
    using System.Data;

    namespace MyWebService.Controllers
    {
        [ApiController]
        [Route("[controller]")]
        public class PivotController : ControllerBase
        {
            [HttpGet(Name = "GetMicrosoft SQLResult")]
            public object Get()
            {
                return JsonConvert.SerializeObject(GetMicrosoft SQLResult());
            }

            public dynamic GetMicrosoft SQLResult()
            {
                // Replace with your own connection string.
                string conSTR = @"<Enter a valid connection string>";
                string xquery = "SELECT * FROM table1";
                SqlConnection sqlConnection = new(conSTR);
                sqlConnection.Open();
                SqlCommand sqlCommand = new(xquery, sqlConnection);
                SqlDataAdapter dataAdapter = new(sqlCommand);
                DataTable dataTable = new();
                dataAdapter.Fill(dataTable);
                return dataTable;
            }
        }
    }

```

**6.** Run the application and it will be hosted within the URL `https://localhost:7146`.

**7.** Finally, the retrieved data from Microsoft SQL database which is in the form of JSON can be found in the Web API controller available in the URL link `https://localhost:7146/Pivot`, as shown in the browser page below.

![Hosted Web API URL](../images/Ms-Sql-data.png)

### Connecting the Pivot Table to a Microsoft SQL using the Web API service

**1.** Create a simple Blazor Pivot Table by following the **"Getting Started"** documentation [link](../getting-started).

**2.** Map the hosted Web API's URL link `https://localhost:7139/Pivot` to the Pivot Table in **Index.razor** by using the [Url](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html?&_ga=2.200411303.844585580.1677740066-2135459383.1677740066#Syncfusion_Blazor_DataManager_Url) property under [PivotViewDataSourceSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.DataSourceSettingsModel-1.html?_ga=2.200411303.844585580.1677740066-2135459383.1677740066). This [Url](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewDataSourceSettings-1.html#Syncfusion_Blazor_PivotView_PivotViewDataSourceSettings_1_Url) property aids in the de-serialization of Microsoft SQL data into instances of your model data class (aka, TValue="ProductDetails") while bound to the pivot table.

```cshtml
@using Syncfusion.Blazor.PivotView

<SfPivotView TValue="OrderDetails" Width="1000" Height="300" ShowFieldList="true">
    <PivotViewDataSourceSettings TValue="OrderDetails" Url="https://localhost:7139/Pivot" ExpandAll=false EnableSorting=true>
         <PivotViewColumns>
            <PivotViewColumn Name="Product"></PivotViewColumn>
        </PivotViewColumns>
        <PivotViewRows>
            <PivotViewRow Name="Date"></PivotViewRow>
        </PivotViewRows>
        <PivotViewValues>
            <PivotViewValue Name="Amount"></PivotViewValue>
        </PivotViewValues>
        <PivotViewFormatSettings>
            <PivotViewFormatSetting Name="Amount" Format="C2"></PivotViewFormatSetting>
        </PivotViewFormatSettings>
        </PivotViewDataSourceSettings>    
    <PivotViewGridSettings ColumnWidth="120"></PivotViewGridSettings>
</SfPivotView>

@code {
    public class OrderDetails
    {
        public int Quantity { get; set; }
        public string Product { get; set; }
        public string Date { get; set; }
        public string Country { get; set; }
        public double Amount { get; set; }
    }  
}
```


When you run the application, the resultant pivot table will look like this.

![Blazor Pivot Table bound with Microsoft SQL data](../images/blazor-pivottable-Ms-SQL-databinding.png)

> In [this](https://github.com/SyncfusionExamples/how-to-bind-SQL-to-pivot-table/tree/master/Blazor) GitHub repository, you can find our Blazor Pivot Table sample for binding data from a Microsoft SQL using the Web API service.