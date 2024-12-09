---
title: "Oracle database Data Binding in Blazor Pivot Table Component | Syncfusion"
component: "Pivot Table"
description: "Learn how to bind data from a Oracle database in the Syncfusion Blazor Pivot Table and more."
---

# Oracle Data Binding

This section describes how to use [Oracle ManagedDataAccess Core](https://www.nuget.org/packages/Oracle.ManagedDataAccess.Core) to retrieve data from a Oracle database and bind it to the Blazor Pivot Table.

## Connecting a Oracle database to a Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Pivot Table

**1.** Create a simple Blazor Pivot Table by following the **"Getting Started"** documentation [link](../getting-started).

**2.** To connect a Oracle Server using the Oracle ManagedDataAccess Core in our application, we need to install the [Oracle.ManagedDataAccess.Core](https://www.nuget.org/packages/Oracle.ManagedDataAccess.Core) NuGet package. To do so, open the NuGet package manager of the project solution, search for the package **Oracle.ManagedDataAccess.Core** and install it.

![Add the NuGet package "Oracle.ManagedDataAccess.Core" to the project](../images/oracledb-nuget-package-install.png)

**3.** Next, in the **Index.razor** page, under the **OnInitialized** method, connect to Oracle database. You can get the specified database by using the **OracleConnection**. Following that, the **OracleCommand** is used to retrieve the desired collection from the database. Then populate the data collection from the **OracleCommand** into a list using the **Read** method of **OracleDataReader**.

**4.** Finally, bind the list to the [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewDataSourceSettings-1.html?&_ga=2.187712492.558891908.1675655056-779654442.1675225237#Syncfusion_Blazor_PivotView_PivotViewDataSourceSettings_1_DataSource) property in the [PivotViewDataSourceSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.DataSourceSettingsModel-1.html?_ga=2.112723776.558891908.1675655056-779654442.1675225237) and configure the report to use the Oracle database data.

```cshtml
@using System.Data
@using Oracle.ManagedDataAccess.Client
@using Syncfusion.Blazor.PivotView

<SfPivotView TValue="EmployeeDetails" Width="1000" Height="300" ShowFieldList="true">
    <PivotViewDataSourceSettings TValue="EmployeeDetails" DataSource="@dataSource" ExpandAll=false EnableSorting=true>
        <PivotViewColumns>
            <PivotViewColumn Name="JOB" Caption="Designation"></PivotViewColumn>
        </PivotViewColumns>
        <PivotViewRows>
            <PivotViewRow Name="EMPLOYEE_NAME" Caption="Employee Name"></PivotViewRow>
        </PivotViewRows>
        <PivotViewValues>
            <PivotViewValue Name="SALARY" Caption="Salary"></PivotViewValue>
            <PivotViewValue Name="COMMISSION" Caption="Commission"></PivotViewValue>
        </PivotViewValues>
        <PivotViewFormatSettings>
            <PivotViewFormatSetting Name="SALARY" Format="C0"></PivotViewFormatSetting>
            <PivotViewFormatSetting Name="COMMISSION" Format="C0"></PivotViewFormatSetting>
        </PivotViewFormatSettings>
    </PivotViewDataSourceSettings>
    <PivotViewGridSettings ColumnWidth="120"></PivotViewGridSettings>
</SfPivotView>

@code {
    private List<EmployeeDetails> dataSource { get; set; }

    protected override void OnInitialized()
    {
        List<EmployeeDetails> employeeData = new List<EmployeeDetails>();
        // Replace with your own connection string.
        string connectionString = "<Enter your valid connection string here>";
        OracleConnection connection = new OracleConnection(connectionString);
        connection.Open();
        OracleCommand command = new OracleCommand("SELECT * FROM EMPLOYEES", connection);
        using (OracleDataReader reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                employeeData.Add(new EmployeeDetails()
                {
                    DEPARTMENT_ID = Convert.ToInt32(reader["DEPARTMENT_ID"]),
                    EMPLOYEE_ID = Convert.ToInt32(reader["EMPLOYEE_ID"]),
                    EMPLOYEE_NAME = reader["EMPLOYEE_NAME"].ToString(),
                    JOB = reader["JOB"].ToString(),
                    MANAGER_ID = Convert.IsDBNull(reader["MANAGER_ID"]) ? null : Convert.ToInt32(reader["MANAGER_ID"]),
                    SALARY = Convert.ToSingle(reader["SALARY"]),
                    COMMISSION = Convert.IsDBNull(reader["COMMISSION"]) ? null : Convert.ToSingle(reader["COMMISSION"]),
                    HIREDATE = Convert.ToDateTime(reader["HIREDATE"])
                });
            }
        }
        connection.Close();   
        this.dataSource = employeeData;
    }

    public class EmployeeDetails
    {
        public int EMPLOYEE_ID { get; set; }
        public string EMPLOYEE_NAME { get; set; }
        public string JOB { get; set; }
        public int? MANAGER_ID { get; set; }
        public Single SALARY { get; set; }
        public Single? COMMISSION { get; set; }
        public int DEPARTMENT_ID { get; set; }
        public DateTime HIREDATE { get; set; }
    }
}
```

When you run the application, the resultant pivot table will look like this.

![Blazor Pivot Table bound with OracleDB data](../images/blazor-pivottable-oracledb-databinding.png)

## Connecting a Oracle database to a Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Pivot Table via Web API service

### Create a Web API service to fetch Oracle data

**1.** Open Visual Studio and create an ASP.NET Core Web App project type, naming it **MyWebService**. To create an ASP.NET Core Web application, follow the documentation [link](https://learn.microsoft.com/en-us/visualstudio/get-started/csharp/tutorial-aspnet-core?view=vs-2022).

![Create ASP.NET Core Web App project](../images/azure-asp-core-web-service-create.png)

**2.** To connect a Oracle database using the **Oracle ManagedDataAccess Core** in our application, we need to install the [Oracle.ManagedDataAccess.Core](https://www.nuget.org/packages/Oracle.ManagedDataAccess.Core) NuGet package. To do so, open the NuGet package manager of the project solution, search for the package **Oracle.ManagedDataAccess.Core** and install it.

![Add the NuGet package "Oracle.ManagedDataAccess.Core" to the project](../images/oracledb-nuget-package-install-in-web-service-app.png)

**3.** Create a Web API controller (aka, PivotController.cs) file under **Controllers** folder that helps to establish data communication with the Pivot Table.

**4.** In the Web API controller (aka, PivotController), **OracleConnection** helps to connect the Oracle database. Next, using **OracleCommand** and **OracleDataAdapter** you can process the desired query string and retrieve data from the Oracle database. The **Fill** method of the **OracleDataAdapter** is used to populate the retrieved data into a **DataTable** as shown in the following code snippet.

```csharp
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace MyWebService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PivotController : ControllerBase
    {
        private static DataTable FetchOracleResult()
        {
            // Replace with your own connection string.
            string connectionString = "<Enter your valid connection string here>";
            OracleConnection oracleConnection = new OracleConnection(connectionString);
            oracleConnection.Open();
            OracleCommand command = new OracleCommand("SELECT * FROM EMPLOYEES", oracleConnection);
            OracleDataAdapter dataAdapter = new OracleDataAdapter(command);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            oracleConnection.Close();
            return dataTable;
        }
    }
}
```

**5.** In the **Get()** method of the **PivotController.cs** file, the **FetchOracleDbResult** method is used to retrieve the Oracle data as a DataTable, which is then serialized into JSON string using **JsonConvert.SerializeObject()**.

```csharp
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace MyWebService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PivotController : ControllerBase
    {
        [HttpGet(Name = "GetOracleResult")]
        public object Get()
        {
            return JsonConvert.SerializeObject(FetchOracleResult());
        }

        private static DataTable FetchOracleResult()
        {
            // Replace with your own connection string.
            string connectionString = "<Enter your valid connection string here>";
            OracleConnection oracleConnection = new OracleConnection(connectionString);
            oracleConnection.Open();
            OracleCommand command = new OracleCommand("SELECT * FROM EMPLOYEES", oracleConnection);
            OracleDataAdapter dataAdapter = new OracleDataAdapter(command);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            oracleConnection.Close();
            return dataTable;
        }
    }
}
```

**6.** Run the application and it will be hosted within the URL `https://localhost:44346`.

**7.** Finally, the retrieved data from Oracle database which is in the form of JSON can be found in the Web API controller available in the URL link `https://localhost:44346/Pivot`, as shown in the browser page below.

![Hosted Web API URL](../images/oracledb-data.png)

### Connecting the Pivot Table to a Oracle database using the Web API service

**1.** Create a simple Blazor Pivot Table by following the **"Getting Started"** documentation [link](../getting-started).

**2.** Map the hosted Web API's URL link `https://localhost:44346/Pivot` to the Pivot Table in **Index.razor** by using the [Url](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html?&_ga=2.200411303.844585580.1677740066-2135459383.1677740066#Syncfusion_Blazor_DataManager_Url) property under [PivotViewDataSourceSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.DataSourceSettingsModel-1.html?_ga=2.200411303.844585580.1677740066-2135459383.1677740066). This [Url](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewDataSourceSettings-1.html#Syncfusion_Blazor_PivotView_PivotViewDataSourceSettings_1_Url) property aids in the de-serialization of Oracle database data into instances of your model data class (aka, TValue="EmployeeDetails") while bound to the pivot table.

```cshtml
@using Syncfusion.Blazor.PivotView

<SfPivotView TValue="EmployeeDetails" Width="1000" Height="300" ShowFieldList="true">
    <PivotViewDataSourceSettings TValue="EmployeeDetails" Url="https://localhost:44346/Pivot" ExpandAll=false EnableSorting=true>
        <PivotViewColumns>
            <PivotViewColumn Name="JOB" Caption="Designation"></PivotViewColumn>
        </PivotViewColumns>
        <PivotViewRows>
            <PivotViewRow Name="EMPLOYEE_NAME" Caption="Employee Name"></PivotViewRow>
        </PivotViewRows>
        <PivotViewValues>
            <PivotViewValue Name="SALARY" Caption="Salary"></PivotViewValue>
            <PivotViewValue Name="COMMISSION" Caption="Commission"></PivotViewValue>
        </PivotViewValues>
        <PivotViewFormatSettings>
            <PivotViewFormatSetting Name="SALARY" Format="C0"></PivotViewFormatSetting>
            <PivotViewFormatSetting Name="COMMISSION" Format="C0"></PivotViewFormatSetting>
        </PivotViewFormatSettings>
    </PivotViewDataSourceSettings>
    <PivotViewGridSettings ColumnWidth="120"></PivotViewGridSettings>
</SfPivotView>

@code {
    public class EmployeeDetails
    {
        public int EMPLOYEE_ID { get; set; }
        public string EMPLOYEE_NAME { get; set; }
        public string JOB { get; set; }
        public int? MANAGER_ID { get; set; }
        public Single SALARY { get; set; }
        public Single? COMMISSION { get; set; }
        public int DEPARTMENT_ID { get; set; }
        public DateTime HIREDATE { get; set; }
    }
}
```


When you run the application, the resultant pivot table will look like this.

![Blazor Pivot Table bound with OracleDB data](../images/blazor-pivottable-oracledb-databinding.png)

> In [this](https://github.com/SyncfusionExamples/how-to-bind-Oracle-database-to-pivot-table/tree/master/Blazor) GitHub repository, you can find our Blazor Pivot Table sample for binding data from a Oracle database using the Web API service.