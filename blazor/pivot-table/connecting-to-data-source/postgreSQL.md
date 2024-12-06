---
title: "PostgreSQL Data Binding in Blazor Pivot Table Component | Syncfusion"
component: "Pivot Table"
description: "Learn how to bind data from a PostgreSQL database in the Syncfusion Blazor Pivot Table and more."
---

# PostgreSQL Data Binding

This section describes how to use [Npgsql EntityFrameworkCore PostgreSQL](https://www.nuget.org/packages/Npgsql.EntityFrameworkCore.PostgreSQL) to retrieve data from a PostgreSQL database and bind it to the Blazor Pivot Table.

## Connecting a PostgreSQL to a Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Pivot Table

**1.** Create a simple Blazor Pivot Table by following the **"Getting Started"** documentation [link](../getting-started).

**2.** To connect a PostgreSQL using the Npgsql EntityFrameworkCore PostgreSQL in our application, we need to install the [Npgsql.EntityFrameworkCore.PostgreSQL](https://www.nuget.org/packages/Npgsql.EntityFrameworkCore.PostgreSQL) NuGet package. To do so, open the NuGet package manager of the project solution, search for the package **Npgsql.EntityFrameworkCore.PostgreSQL** and install it.

![Add the NuGet package "Npgsql.EntityFrameworkCore.PostgreSQL" to the project](../images/postgreSQL-nuget-package-install.png)

**3.** Next, in the **Index.razor** page, under the **OnInitialized** method, connect to PostgreSQL database. You can get the specified database by using the **NpgsqlConnection**. Following that, the **NpgsqlCommand** is used to retrieve the desired collection from the database. Then populate the data collection from the **NpgsqlCommand** into a list using the **Read** method of **NpgsqlDataReader**.

**4.** Finally, bind the list to the [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewDataSourceSettings-1.html?&_ga=2.187712492.558891908.1675655056-779654442.1675225237#Syncfusion_Blazor_PivotView_PivotViewDataSourceSettings_1_DataSource) property in the [PivotViewDataSourceSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.DataSourceSettingsModel-1.html?_ga=2.112723776.558891908.1675655056-779654442.1675225237) and configure the report to use the PostgreSQL data.

```cshtml
@using System.Data
@using Npgsql
@using Syncfusion.Blazor.PivotView

<SfPivotView TValue="PostgreSQLService" Width="1000" Height="300" ShowFieldList="true">
    <PivotViewDataSourceSettings TValue="PostgreSQLService" DataSource="@dataSource" ExpandAll=false EnableSorting=true>
        <PivotViewColumns>
            <PivotViewColumn Name="openinghours_practice" Caption="Openinghours Practice"></PivotViewColumn>
            <PivotViewColumn Name="closinghours_practice" Caption="Closinghours Practice"></PivotViewColumn>
        </PivotViewColumns>
        <PivotViewRows>
            <PivotViewRow Name="servicetype" Caption="Service Type"></PivotViewRow>
            <PivotViewRow Name="servicecategory" Caption="Service Category"></PivotViewRow>
        </PivotViewRows>
        <PivotViewValues>
            <PivotViewValue Name="revenue" Caption="Revenue"></PivotViewValue>
        </PivotViewValues>
        <PivotViewFormatSettings>
            <PivotViewFormatSetting Name="revenue" Format="C0"></PivotViewFormatSetting>
        </PivotViewFormatSettings>
    </PivotViewDataSourceSettings>
    <PivotViewGridSettings ColumnWidth="120"></PivotViewGridSettings>
</SfPivotView>

@code {
    private List<PostgreSQLService> dataSource { get; set; }

    protected override void OnInitialized()
    {
        List<PostgreSQLService> postGreSqlData = new List<PostgreSQLService>();
        // Replace with your own connection string.
        NpgsqlConnection connection = new NpgsqlConnection("<Enter your valid connection string here>");
        connection.Open();
        NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM apxtimestamp", connection);
        using (NpgsqlDataReader reader = cmd.ExecuteReader())
        {
            while (reader.Read())
            {
                postGreSqlData.Add(new PostgreSQLService()
                {
                    openinghours_practice = (TimeSpan)reader["openinghours_practice"],
                    closinghours_practice = (TimeSpan)reader["closinghours_practice"],
                    servicetype = reader["servicetype"].ToString(),
                    servicecategory = reader["servicecategory"].ToString(),
                    revenue = Convert.ToInt32(reader["revenue"])
                });
            }
        }
        connection.Close();   
        this.dataSource = postGreSqlData;
    }

    public class PostgreSQLService
    {
        public TimeSpan openinghours_practice { get; set; }
        public TimeSpan closinghours_practice { get; set; }
        public string servicetype { get; set; }
        public string servicecategory { get; set; }
        public int revenue { get; set; }
    }
}
```

When you run the application, the resultant pivot table will look like this.

![Blazor Pivot Table bound with PostgreSQL data](../images/blazor-pivottable-postgreSQL-databinding.png)

## Connecting a PostgreSQL to a Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Pivot Table via Web API service

### Create a Web API service to fetch PostgreSQL data

**1.** Open Visual Studio and create an ASP.NET Core Web App project type, naming it **MyWebService**. To create an ASP.NET Core Web application, follow the documentation [link](https://learn.microsoft.com/en-us/visualstudio/get-started/csharp/tutorial-aspnet-core?view=vs-2022).

![Create ASP.NET Core Web App project](../images/azure-asp-core-web-service-create.png)

**2.** To connect a PostgreSQL using the **Npgsql EntityFrameworkCore PostgreSQL** in our application, we need to install the [Npgsql.EntityFrameworkCore.PostgreSQL](https://www.nuget.org/packages/Npgsql.EntityFrameworkCore.PostgreSQL) NuGet package. To do so, open the NuGet package manager of the project solution, search for the package **Npgsql.EntityFrameworkCore.PostgreSQL** and install it.

![Add the NuGet package "Npgsql.EntityFrameworkCore.PostgreSQL" to the project](../images/postgreSQL-nuget-package-install-in-web-service-app.png)

**3.** Create a Web API controller (aka, PivotController.cs) file under **Controllers** folder that helps to establish data communication with the Pivot Table.

**4.** In the Web API controller (aka, PivotController), **NpgsqlConnection** helps to connect the PostgreSQL database. Next, using **NpgsqlCommand** and **NpgsqlDataAdapter** you can process the desired query string and retrieve data from the PostgreSQL database. The **Fill** method of the **NpgsqlDataAdapter** is used to populate the retrieved data into a **DataTable** as shown in the following code snippet.

```csharp
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using Npgsql;

namespace MyWebService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PivotController : ControllerBase
    {
        private dynamic GetPostgreSQLResult()
        {
            // Replace with your own connection string.
            NpgsqlConnection connection = new NpgsqlConnection("<Enter your valid connection string here>");
            connection.Open();
            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM apxtimestamp", connection);
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            connection.Close();
            return dataTable;
        }
    }
}
```

**5.** In the **Get()** method of the **PivotController.cs** file, the **GetPostgreSQLResult** method is used to retrieve the PostgreSQL data as a DataTable, which is then serialized into JSON string using **JsonConvert.SerializeObject()**.

```csharp
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using Npgsql;

namespace MyWebService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PivotController : ControllerBase
    {
        [HttpGet(Name = "GetPostgreSQLResult")]
        public object Get()
        {
            return JsonConvert.SerializeObject(GetPostgreSQLResult());
        }

        private dynamic GetPostgreSQLResult()
        {
            // Replace with your own connection string.
            NpgsqlConnection connection = new NpgsqlConnection("<Enter your valid connection string here>");
            connection.Open();
            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM apxtimestamp", connection);
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            connection.Close();
            return dataTable;
        }
    }
}
```

**6.** Run the application and it will be hosted within the URL `https://localhost:44378`.

**7.** Finally, the retrieved data from PostgreSQL which is in the form of JSON can be found in the Web API controller available in the URL link `https://localhost:44378/Pivot`, as shown in the browser page below.

![Hosted Web API URL](../images/postgreSQL-data.png)

### Connecting the Pivot Table to a PostgreSQL using the Web API service

**1.** Create a simple Blazor Pivot Table by following the **"Getting Started"** documentation [link](../getting-started).

**2.** Map the hosted Web API's URL link `https://localhost:44378/Pivot` to the Pivot Table in **Index.razor** by using the [Url](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html?&_ga=2.200411303.844585580.1677740066-2135459383.1677740066#Syncfusion_Blazor_DataManager_Url) property under [PivotViewDataSourceSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.DataSourceSettingsModel-1.html?_ga=2.200411303.844585580.1677740066-2135459383.1677740066). This [Url](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewDataSourceSettings-1.html#Syncfusion_Blazor_PivotView_PivotViewDataSourceSettings_1_Url) property aids in the de-serialization of PostgreSQL data into instances of your model data class (aka, TValue="PostgreSQLService") while bound to the pivot table.

```cshtml
@using Syncfusion.Blazor.PivotView

<SfPivotView TValue="PostgreSQLService" Width="1000" Height="300" ShowFieldList="true">
    <PivotViewDataSourceSettings TValue="PostgreSQLService" Url="https://localhost:44378/Pivot" ExpandAll=false EnableSorting=true>
        <PivotViewColumns>
            <PivotViewColumn Name="openinghours_practice" Caption="Openinghours Practice"></PivotViewColumn>
            <PivotViewColumn Name="closinghours_practice" Caption="Closinghours Practice"></PivotViewColumn>
        </PivotViewColumns>
        <PivotViewRows>
            <PivotViewRow Name="servicetype" Caption="Service Type"></PivotViewRow>
            <PivotViewRow Name="servicecategory" Caption="Service Category"></PivotViewRow>
        </PivotViewRows>
        <PivotViewValues>
            <PivotViewValue Name="revenue" Caption="Revenue"></PivotViewValue>
        </PivotViewValues>
        <PivotViewFormatSettings>
            <PivotViewFormatSetting Name="revenue" Format="C0"></PivotViewFormatSetting>
        </PivotViewFormatSettings>
    </PivotViewDataSourceSettings>
    <PivotViewGridSettings ColumnWidth="120"></PivotViewGridSettings>
</SfPivotView>

@code {
    public class PostgreSQLService
    {
        public TimeSpan openinghours_practice { get; set; }
        public TimeSpan closinghours_practice { get; set; }
        public string servicetype { get; set; }
        public string servicecategory { get; set; }
        public int revenue { get; set; }
    }
}
```


When you run the application, the resultant pivot table will look like this.

![Blazor Pivot Table bound with PostgreSQL data](../images/blazor-pivottable-mongodb-databinding.png)

> In [this](https://github.com/SyncfusionExamples/how-to-bind-PostgreSQL-database-to-pivot-table/tree/master/Blazor) GitHub repository, you can find our Blazor Pivot Table sample for binding data from a PostgreSQL using the Web API service.