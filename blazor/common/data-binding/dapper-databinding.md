---
layout: post
title: Bind data using Dapper and perform CRUD operations | Syncfusion
component: "DataGrid component and DataManager"
description: How to consume data from SQL database using Dapper, bind it to a Syncfusion Component, and perform CRUD operations.
component: Common
documentation: ug
platform: Blazor
---

# How to Bind Data Using Dapper and Perform CRUD Operations

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor [DataGrid](https://blazor.syncfusion.com/documentation/datagrid/getting-started) component supports integration with [Dapper](https://github.com/DapperLib/Dapper) for efficient data access and manipulation. This integration enables binding data from a SQL Server database to the DataGrid and performing **create**, **read**, **update**, and **delete** (**CRUD**) operations with minimal overhead.

**Dapper** is a lightweight object-relational mapper (**ORM**) that provides high-performance data access by mapping query results to strongly typed models without the complexity of full-featured ORMs.

## Prerequisite software

The following software components are required to implement data binding with Dapper and Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid:

* [Visual Studio 2022 or later](https://visualstudio.microsoft.com/downloads/) (latest version with .NET 10 support)
* [.NET 8 or later](https://dotnet.microsoft.com/en-us/download/dotnet)
* [Microsoft SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

Ensure that the development environment is configured with the latest updates for Visual Studio and SQL Server, and install .NET 8.0 or a newer version for compatibility with current features.

## Creating the Blazor application

Create a Blazor Web App using Visual Studio 2022 with [Microsoft Blazor templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-10.0&pivots=vs) or the [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-integration/template-studio) for streamlined project creation.

1. Open **Visual Studio 2022**.
2. Select Create a new project.
3. Choose the **Blazor Web App** template.
4. Configure project options such as **name**, **location**, and **.NET version**.
5. Set [interactive render mode](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/render-modes?view=aspnetcore-10.0#render-modes) to **Auto**.
6. Define [interactivity location](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-10.0&pivots=vs#interactivity-location) as **Per page/component** or **Global** based on requirements.

N> **Recommendation**: Use **Auto** render mode for hybrid interactivity and flexibility. This configuration allows components to switch seamlessly between **server** and **client** rendering..

## Creating the database

Create a SQL Server database to store bug tracking information:

**Launch SQL Server Management Studio (SSMS)**

1. Open the **Windows Start Menu** and search for **SQL Server Management Studio**.
2. Click the **SSMS icon** to launch the application.
3. In the Connect to Server dialog:

    * **Server type**: Database Engine
    * **Server name**: Enter your SQL Server instance name (e.g., localhost or .\SQLEXPRESS).
    * **Authentication**: Choose **Windows Authentication** or **SQL Server Authentication**.

4. Click Connect.

If SSMS is not installed, download it from [Download SQL Server Management Studio](https://learn.microsoft.com/en-us/ssms/install/install).

**Create Database and Table**

1. In **SSMS**, right-click **Databases** in Object Explorer and select **New Database**.
2. Enter **BugTracker** as the database name and click **OK**.
3. Expand the BugTracker database, right-click **Tables**, and select **New Query**.
4. Paste and execute the following SQL script to create the Bugs table:

```

CREATE TABLE Bugs (
    Id BIGINT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    Summary VARCHAR(400) NOT NULL,
    BugPriority VARCHAR(100) NOT NULL,
    Assignee VARCHAR(100),
    BugStatus VARCHAR(100) NOT NULL
);

```

![Bug Table Design in Blazor](../images/bug-table-design.png)

The Bugs table stores details such as **summary**, **priority**, **assignee**, and **status** for each bug record.

For SQL Server installation, refer to[ Microsoft SQL Server Downloads](https://www.microsoft.com/en-us/sql-server/sql-server-downloads).

## Adding Dapper package and creating the model class

1. **Install Required NuGet Packages**

In the server-side project, install:

* [Dapper](https://www.nuget.org/packages/Dapper/) – Provides lightweight object mapping for SQL queries.
*  [Microsoft.Data.SqlClient](https://www.nuget.org/packages/Microsoft.Data.SqlClient/) – Enables SQL Server connectivity.

**Options to install**:


* **Using NuGet Package Manager in Visual Studio**:

Navigate to: Tools → NuGet Package Manager → Manage NuGet Packages for Solution.

* **Using Package Manager Console**:

{% tabs %}
{% highlight C# tabtitle="Package Manager" %}

    Install-Package Dapper -Version 2.1.24
    Install-Package Microsoft.Data.SqlClient

{% endhighlight %}
{% endtabs %}

The **Microsoft.Data.SqlClient** package provides classes such as **SqlConnection** and **SqlCommand** for database access.

2. **Creating the Model Class**

Dapper does not include scaffolding for model generation. Create a model manually to represent the database table. For example, create a class named **Bug.cs** in the **Data** folder:


```c#


namespace YourNamespace
{
    public class Bug
    {
        public int Id { get; set; }
        public string Summary { get; set; }
        public string BugPriority { get; set; }
        public string Assignee { get; set; }
        public string BugStatus { get; set; }
    }
}


```
This class defines strongly typed properties corresponding to the columns in the **Bugs** table.

![Bug Model Class in Blazor](../images/bug-model-class.png)

## Creating the data access layer

1. Configure the Connection String

Add the connection string in **appsettings.json**:

```cshtml


"ConnectionStrings": {
    "BugTrackerDatabase": "Server={Your Server Name};Database=BugTracker;Integrated Security=True"
}


```
![Connection String in appsettings](../images/connection-string-appsettings.png)

2. **Create the Data Access Layer Class**

In the **Data** folder, create a class named **BugDataAccessLayer.cs** to handle CRUD operations using **Dapper**.


3. **Implement CRUD Methods**

Add the following code in **BugDataAccessLayer.cs**:

{% highlight c# %}

p
public class BugDataAccessLayer
{
    private readonly IConfiguration _configuration;
    private const string BugTrackerDatabase = "BugTrackerDatabase";
    private const string SelectBugQuery = "SELECT * FROM Bugs";

    public BugDataAccessLayer(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<List<Bug>> GetBugsAsync()
    {
        using IDbConnection db = new SqlConnection(_configuration.GetConnectionString(BugTrackerDatabase));
        IEnumerable<Bug> result = await db.QueryAsync<Bug>(SelectBugQuery);
        return result.ToList();
    }

    public async Task<int> GetBugCountAsync()
    {
        using IDbConnection db = new SqlConnection(_configuration.GetConnectionString(BugTrackerDatabase));
        return await db.ExecuteScalarAsync<int>("SELECT COUNT(*) FROM Bugs");
    }

    public async Task AddBugAsync(Bug bug)
    {
        using IDbConnection db = new SqlConnection(_configuration.GetConnectionString(BugTrackerDatabase));
        await db.ExecuteAsync("INSERT INTO Bugs (Summary, BugPriority, Assignee, BugStatus) VALUES (@Summary, @BugPriority, @Assignee, @BugStatus)", bug);
    }

    public async Task UpdateBugAsync(Bug bug)
    {
        using IDbConnection db = new SqlConnection(_configuration.GetConnectionString(BugTrackerDatabase));
        await db.ExecuteAsync("UPDATE Bugs SET Summary=@Summary, BugPriority=@BugPriority, Assignee=@Assignee, BugStatus=@BugStatus WHERE Id=@Id", bug);
    }

    public async Task RemoveBugAsync(int bugId)
    {
        using IDbConnection db = new SqlConnection(_configuration.GetConnectionString(BugTrackerDatabase));
        await db.ExecuteAsync("DELETE FROM Bugs WHERE Id=@BugId", new { BugId = bugId });
    }
}


{% endhighlight %}

3. Register the Service

Add the following line in **Program.cs**:

{% tabs %}
{% highlight c# tabtitle="Program.cs" %}

builder.Services.AddScoped<BugDataAccessLayer>();

{% endhighlight %}
{% endtabs %}

## Adding Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid component

**Steps**:

1. **Install Required NuGet Packages**

* Use **NuGet Package Manager** in Visual Studio or Package Manager Console to install:

    * [Syncfusion.Blazor.Grid](https://www.nuget.org/packages/Syncfusion.Blazor.Grid/)
    * [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/)

* Package Manager Console commands:

{% tabs %}
{% highlight C# tabtitle="Package Manager" %}

Install-Package Syncfusion.Blazor.Grid -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.Themes -Version {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

> Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components are available on [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). Refer to [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) for a complete list.

2. **Add Required Namespaces**

Add the required namespaces in **_Imports.razor**:

{% tabs %}
{% highlight C# tabtitle="_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Data

{% endhighlight %}
{% endtabs %}

Register Syncfusion<sup style="font-size:70%">&reg;</sup> services in **Program.cs**:

{% tabs %}
{% highlight C# tabtitle="Program.cs" %}

using Syncfusion.Blazor;

builder.Services.AddSyncfusionBlazor();

{% endhighlight %}
{% endtabs %}

3. **Add Theme Stylesheet**

Include the Syncfusion theme in the <head> section:

{% highlight cshtml %}

<link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />

{% endhighlight %}

Add this stylesheet in the following locations based on the project type:

* **Blazor Web App**: **~/Components/App.razor**
* **Blazor WebAssembly**: **wwwroot/index.html**
* **Blazor Server**: **~/Pages/_Host.cshtml**

4. **Add Script Reference**

Include the Syncfusion script at the end of the <body>:

{% highlight cshtml %}

<script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>

{% endhighlight %}

5. **Add DataGrid Component**

Insert the [DataGrid](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html) component in **Index.razor**:

{% tabs %}
{% highlight razor %}
<SfGrid>

</SfGrid>
{% endhighlight %}
{% endtabs %}

## Binding data to the DataGrid component

To bind SQL Server data retrieved via Dapper to the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid, implement a custom data adaptor.

1. **Create a Custom Adaptor Class**

In the **Data** folder, create a class named **BugDataAdaptor.cs** and extend the **DataAdaptor** base class:

{% highlight c# %}


public class BugDataAdaptor : DataAdaptor
{
    private readonly BugDataAccessLayer _dataLayer;

    public BugDataAdaptor(BugDataAccessLayer dataLayer)
    {
        _dataLayer = dataLayer;
    }

    public override async Task<object> ReadAsync(DataManagerRequest request, string key = null)
    {
        List<Bug> bugs = await _dataLayer.GetBugsAsync();
        int count = await _dataLayer.GetBugCountAsync();
        return request.RequiresCounts ? new DataResult { Result = bugs, Count = count } : (object)bugs;
    }
}


{% endhighlight %}

2. **Register the Custom Adaptor**

In **Program.cs**, register the adaptor as a scoped service:

{% tabs %}
{% highlight c# tabtitle="~/Program.cs" hl_lines="4"%}

builder.Services.AddScoped<BugDataAdaptor>();

{% endhighlight %}
{% endtabs %}

3. **Add SfDataManager in the Grid**

In **Index.razor**, configure the DataGrid to use the custom adaptor:


{% highlight razor %}

<SfGrid TValue="Bug">
    <SfDataManager AdaptorInstance="typeof(BugDataAdaptor)" Adaptor="Adaptors.CustomAdaptor"></SfDataManager>
</SfGrid>

{% endhighlight %}

4. **Define Grid Columns**

Configure columns using the [GridColumn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html) component:

{% highlight razor %}

<SfGrid TValue="Bug">
    <SfDataManager AdaptorInstance="typeof(BugDataAdaptor)" Adaptor="Adaptors.CustomAdaptor"></SfDataManager>
    <GridColumns>
        <GridColumn Field="@nameof(Bug.Id)" IsPrimaryKey="true" Visible="false"></GridColumn>
        <GridColumn Field="@nameof(Bug.Summary)" Width="150"></GridColumn>
        <GridColumn Field="@nameof(Bug.BugPriority)" HeaderText="Priority" Width="120"></GridColumn>
        <GridColumn Field="@nameof(Bug.Assignee)" Width="120"></GridColumn>
        <GridColumn Field="@nameof(Bug.BugStatus)" HeaderText="Status" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

{% endhighlight %}

![Bug Grid Data in Blazor](../images/bug-grid-data.png)

## Handling CRUD operations in the DataGrid

Enable [editing](https://blazor.syncfusion.com/documentation/datagrid/editing) in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid using the [GridEditSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEditSettings.html) component and implement CRUD logic in the custom adaptor.

**Enable Editing**

Configure editing in the grid using `GridEditSettings`. The grid supports multiple editing modes such as [Inline](https://blazor.syncfusion.com/documentation/datagrid/in-line-editing), [Dialog](https://blazor.syncfusion.com/documentation/datagrid/dialog-editing), and [Batch](https://blazor.syncfusion.com/documentation/datagrid/batch-editing). The example below uses Inline mode with the [Toolbar](https://blazor.syncfusion.com/documentation/datagrid/tool-bar) property to show toolbar items for editing.

{% highlight razor %}

<SfGrid TValue="Bug" Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Update", "Cancel" })">
    <SfDataManager AdaptorInstance="typeof(BugDataAdaptor)" Adaptor="Adaptors.CustomAdaptor"></SfDataManager>
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true"></GridEditSettings>
    <GridColumns>
        <GridColumn Field="@nameof(Bug.Id)" IsPrimaryKey="true" Visible="false"></GridColumn>
        <GridColumn Field="@nameof(Bug.Summary)" Width="150"></GridColumn>
        <GridColumn Field="@nameof(Bug.BugPriority)" HeaderText="Priority" Width="120"></GridColumn>
        <GridColumn Field="@nameof(Bug.Assignee)" Width="120"></GridColumn>
        <GridColumn Field="@nameof(Bug.BugStatus)" HeaderText="Status" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

{% endhighlight %}

## Insert a record

When the **Add** button is clicked and the form is submitted, the **InsertAsync** method is executed. This method inserts a new bug record into the database:

![Insert a row in Grid](../images/insert-a-row.png)

{% highlight c# %}

public override async Task<object> InsertAsync(DataManager dataManager, object data, string key)
{
    await _dataLayer.AddBugAsync(data as Bug);
    return data;
}

{% endhighlight %}

![After inserting a row in Grid](../images/after-inserting-a-row.png)

## Update a record

When the **Edit** button is used and changes are saved, the **UpdateAsync** method updates the selected bug record:

![Updating a row in Grid](../images/updating-a-row.png)

{% highlight c# %}

public override async Task<object> UpdateAsync(DataManager dataManager, object data, string keyField, string key)
{
    await _dataLayer.UpdateBugAsync(data as Bug);
    return data;
}

{% endhighlight %}

![After updating a row in Grid](../images/after-updating.png)

## Delete a row

When the **Delete** button is clicked, the **RemoveAsync** method deletes the selected bug record by its primary key:

{% highlight c# %}

public override async Task<object> RemoveAsync(DataManager dataManager, object primaryKeyValue, string keyField, string key)
{
    await _dataLayer.RemoveBugAsync(Convert.ToInt32(primaryKeyValue));
    return primaryKeyValue;
}

{% endhighlight %}

N> Find the sample at this [GitHub repository](https://github.com/SyncfusionExamples/blazor-datagrid-dapper-crud).

## See also

* [Create Blazor CRUD Application with PostgreSQL and Dapper](https://www.syncfusion.com/blogs/post/create-blazor-crud-application-with-postgresql-and-dapper.aspx)
* [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid Documentation](https://blazor.syncfusion.com/documentation/datagrid/getting-started)
* [Custom Data Binding in Blazor DataGrid](https://blazor.syncfusion.com/documentation/datagrid/connecting-to-adaptors/custom-adaptor)
