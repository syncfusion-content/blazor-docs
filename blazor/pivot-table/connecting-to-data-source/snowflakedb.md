---
title: "Snowflake Data Binding in Blazor Pivot Table Component | Syncfusion"
component: "Pivot Table"
description: "Learn how to bind data from a Snowflake database in the Syncfusion Blazor Pivot Table and more."
---

# Snowflake Data Binding

This section describes how to use [Snowflake data](https://www.nuget.org/packages/Snowflake.Data) to retrieve data from a Snowflake database and bind it to the Blazor Pivot Table.

## Connecting a Snowflake to a Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Pivot Table

**1.** Create a simple Blazor Pivot Table by following the **"Getting Started"** documentation [link](../getting-started).

**2.** To connect a Snowflake database using the Snowflake data provider in our application, we need to install the [Snowflake.Data](https://www.nuget.org/packages/Snowflake.Data) NuGet package. To do so, open the NuGet package manager of the project solution, search for the package **Snowflake.Data** and install it.

![Add the NuGet package "Snowflake.Data" to the project](../images/Snowflake-nuget-package-install.png)

**3.** Next, in the **Index.razor** page, under the **OnInitialized** method, connect to Snowflake database. You can get the specified database by using the **SnowflakeDbConnection**. Following that, the **SnowflakeDbDataAdapter** is used to retrieve the desired collection from the database. The **Fill** method of the **SnowflakeDbDataAdapter** is used to populate the retrieved data into a **DataTable**,  which is then convert into a list.

**4.** Finally, bind the list to the [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewDataSourceSettings-1.html?&_ga=2.187712492.558891908.1675655056-779654442.1675225237#Syncfusion_Blazor_PivotView_PivotViewDataSourceSettings_1_DataSource) property in the [PivotViewDataSourceSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.DataSourceSettingsModel-1.html?_ga=2.112723776.558891908.1675655056-779654442.1675225237) and configure the report to use the Snowflake data.

```cshtml
@using Syncfusion.Blazor.PivotView
@using Snowflake.Data.Client
@using System.Data

<SfPivotView TValue="SnowflakeService" Width="1000" Height="300" ShowFieldList="true">
    <PivotViewDataSourceSettings TValue="SnowflakeService" DataSource="@dataSource" ExpandAll=false EnableSorting=true>
        <PivotViewColumns>
            <PivotViewColumn Name="CC_CALL_CENTER_SK"></PivotViewColumn>
            <PivotViewColumn Name="CC_SQ_FT"></PivotViewColumn>
        </PivotViewColumns>
        <PivotViewRows>
            <PivotViewRow Name="CC_REC_START_DATE"></PivotViewRow>
        </PivotViewRows>
        <PivotViewValues>
            <PivotViewValue Name="CC_EMPLOYEES"></PivotViewValue>
        </PivotViewValues>
        <PivotViewFormatSettings>
            <PivotViewFormatSetting Name="CC_EMPLOYEES" Format="N0"></PivotViewFormatSetting>
        </PivotViewFormatSettings>
    </PivotViewDataSourceSettings>
    <PivotViewGridSettings ColumnWidth="120"></PivotViewGridSettings>
</SfPivotView>

@code {
    private List<SnowflakeService> dataSource;

    protected override void OnInitialized()
    {
        using (SnowflakeDbConnection snowflakeConnection = new SnowflakeDbConnection())
        {
            List<SnowflakeService> snowflakeList = new List<SnowflakeService>();
            // Replace with your own connection string.
            snowflakeConnection.ConnectionString = "<Enter your valid connection string here>";
            snowflakeConnection.Open();
            SnowflakeDbDataAdapter adapter = new SnowflakeDbDataAdapter("select * from CALL_CENTER", snowflakeConnection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            snowflakeConnection.Close();
            snowflakeList = dataTable.AsEnumerable().Select(r => new SnowflakeService
            {
                CC_CALL_CENTER_SK = r.Field<int>("CC_CALL_CENTER_SK"),
                CC_CALL_CENTER_ID = r.Field<string>("CC_CALL_CENTER_ID"),
                CC_EMPLOYEES = r.Field<int?>("CC_EMPLOYEES"),
                CC_SQ_FT = r.Field<int>("CC_SQ_FT"),
                CC_REC_END_DATE = r.Field<DateTime?>("CC_REC_END_DATE"),
                CC_REC_START_DATE = r.Field<DateTime?>("CC_REC_START_DATE"),
            }).ToList();
            this.dataSource = snowflakeList;
        }
    }

    public class SnowflakeService
    {
        public int CC_CALL_CENTER_SK { get; set; }
        public string CC_CALL_CENTER_ID { get; set; }
        public int? CC_EMPLOYEES { get; set; }
        public int CC_SQ_FT { get; set; }
        public DateTime? CC_REC_END_DATE { get; set; }
        public DateTime? CC_REC_START_DATE { get; set; }
    }
}
```

When you run the application, the resultant pivot table will look like this.

![Blazor Pivot Table bound with Snowflake data](../images/blazor-pivottable-Snowflake-databinding.png)

## Connecting a Snowflake database to a Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Pivot Table via Web API service

### Create a Web API service to fetch Snowflake data

**1.** Open Visual Studio and create an ASP.NET Core Web App project type, naming it **MyWebService**. To create an ASP.NET Core Web application, follow the documentation [link](https://learn.microsoft.com/en-us/visualstudio/get-started/csharp/tutorial-aspnet-core?view=vs-2022).

![Create ASP.NET Core Web App project](../images/azure-asp-core-web-service-create.png)

**2.** To connect a Snowflake database using the **Snowflake.Data** in our application, we need to install the [Snowflake.Data](https://www.nuget.org/packages/Snowflake.Data) NuGet package. To do so, open the NuGet package manager of the project solution, search for the package **Snowflake.Data** and install it.

![Add the NuGet package "Snowflake.Data" to the project](../images/Snowflake-nuget-package-install-in-web-service-app.png)

**3.** Create a Web API controller (aka, PivotController.cs) file under **Controllers** folder that helps to establish data communication with the Pivot Table.

**4.** In the Web API controller (aka, PivotController), **SnowflakeDbConnection** helps to connect the Snowflake database. Next, using **SnowflakeDbDataAdapter** you can process the desired query string and retrieve data from the Snowflake database. The **Fill** method of the **SnowflakeDbDataAdapter** is used to populate the retrieved data into a **DataTable** as shown in the following code snippet.

```csharp
using Microsoft.AspNetCore.Mvc;
using Snowflake.Data.Client;
using Newtonsoft.Json;
using System.Data;

namespace MyWebService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PivotController : ControllerBase
    {
        public static DataTable FetchSnowflakeResult()
        {
            using (SnowflakeDbConnection snowflakeConnection = new SnowflakeDbConnection())
            {
                // Replace with your own connection string.
                snowflakeConnection.ConnectionString = "<Enter your valid connection string here>";
                snowflakeConnection.Open();
                SnowflakeDbDataAdapter adapter = new SnowflakeDbDataAdapter("select * from CALL_CENTER", snowflakeConnection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                snowflakeConnection.Close();
                return dataTable;
            }
        }
    }
}
```

**5.** In the **Get()** method of the **PivotController.cs** file, the **FetchSnowflakeResult** method is used to retrieve the Snowflake data as a DataTable, which is then serialized into JSON string using **JsonConvert.SerializeObject()**.

```csharp
using Microsoft.AspNetCore.Mvc;
using Snowflake.Data.Client;
using Newtonsoft.Json;
using System.Data;

namespace MyWebService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PivotController : ControllerBase
    {
        [HttpGet(Name = "GetSnowflakeResult")]
        public object Get()
        {
            return JsonConvert.SerializeObject(FetchSnowflakeResult());
        }

        public static DataTable FetchSnowflakeResult()
        {
            using (SnowflakeDbConnection snowflakeConnection = new SnowflakeDbConnection())
            {
                // Replace with your own connection string.
                snowflakeConnection.ConnectionString = "<Enter your valid connection string here>";
                snowflakeConnection.Open();
                SnowflakeDbDataAdapter adapter = new SnowflakeDbDataAdapter("select * from CALL_CENTER", snowflakeConnection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                snowflakeConnection.Close();
                return dataTable;
            }
        }
    }
}
```

**6.** Run the application and it will be hosted within the URL `https://localhost:44378`.

**7.** Finally, the retrieved data from Snowflake database which is in the form of JSON can be found in the Web API controller available in the URL link `https://localhost:44378/Pivot`, as shown in the browser page below.

![Hosted Web API URL](../images/Snowflake-data.png)

### Connecting the Pivot Table to a Snowflake database using the Web API service

**1.** Create a simple Blazor Pivot Table by following the **"Getting Started"** documentation [link](../getting-started).

**2.** Map the hosted Web API's URL link `https://localhost:44378/Pivot` to the Pivot Table in **Index.razor** by using the [Url](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html?&_ga=2.200411303.844585580.1677740066-2135459383.1677740066#Syncfusion_Blazor_DataManager_Url) property under [PivotViewDataSourceSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.DataSourceSettingsModel-1.html?_ga=2.200411303.844585580.1677740066-2135459383.1677740066). This [Url](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewDataSourceSettings-1.html#Syncfusion_Blazor_PivotView_PivotViewDataSourceSettings_1_Url) property aids in the de-serialization of Snowflake data into instances of your model data class (aka, TValue="SnowflakeService") while bound to the pivot table.

```cshtml
@using Syncfusion.Blazor.PivotView

<SfPivotView TValue="ProductDetails" Width="1000" Height="300" ShowFieldList="true">
    <PivotViewDataSourceSettings TValue="SnowflakeService" Url="https://localhost:44378/Pivot" ExpandAll=false EnableSorting=true>
        <PivotViewColumns>
            <PivotViewColumn Name="CC_CALL_CENTER_SK"></PivotViewColumn>
            <PivotViewColumn Name="CC_SQ_FT"></PivotViewColumn>
        </PivotViewColumns>
        <PivotViewRows>
            <PivotViewRow Name="CC_REC_START_DATE"></PivotViewRow>
        </PivotViewRows>
        <PivotViewValues>
            <PivotViewValue Name="CC_EMPLOYEES"></PivotViewValue>
        </PivotViewValues>
        <PivotViewFormatSettings>
            <PivotViewFormatSetting Name="CC_EMPLOYEES" Format="N0"></PivotViewFormatSetting>
        </PivotViewFormatSettings>
    </PivotViewDataSourceSettings>
    <PivotViewGridSettings ColumnWidth="120"></PivotViewGridSettings>
</SfPivotView>

@code {
    public class SnowflakeService
    {
        public int CC_CALL_CENTER_SK { get; set; }
        public string CC_CALL_CENTER_ID { get; set; }
        public int? CC_EMPLOYEES { get; set; }
        public int CC_SQ_FT { get; set; }
        public DateTime? CC_REC_END_DATE { get; set; }
        public DateTime? CC_REC_START_DATE { get; set; }
    }
}
```


When you run the application, the resultant pivot table will look like this.

![Blazor Pivot Table bound with Snowflake data](../images/blazor-pivottable-Snowflake-databinding.png)

> In [this](https://github.com/SyncfusionExamples/how-to-bind-Snowflake-database-to-pivot-table/tree/master/Blazor) GitHub repository, you can find our Blazor Pivot Table sample for binding data from a Snowflake database using the Web API service.