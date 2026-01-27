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

In this section, you will learn step by step how to:

* Consume data from a SQL Server database using Dapper, a lightweight object mapper.
* Bind the retrieved data to the Syncfusion® Blazor DataGrid component so that records can be displayed in a structured grid format.
* Perform CRUD operations (Create, Read, Update, Delete) directly from the DataGrid by connecting it with a custom adaptor that interacts with the database.

This approach combines the simplicity and performance of Dapper for data access with the rich UI features of the Syncfusion® Blazor DataGrid, enabling you to build a responsive and interactive application that supports inline editing, sorting, filtering, and paging.


## Prerequisite software

* Visual Studio 2026 (or later) installed and configured for Blazor development.

* MS SQL Server (2017 or later) available to host the sample database.

## Creating Blazor application

* Open Visual Studio and follow the steps in the [documentation](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-visual-studio) to create the Blazor Server Application.

## Creating the database

First, create a database named `BugTracker` and a table named `Bugs` to hold the list of bugs.

1. Open SQL Server 2022 / latest version.
2. Now, create a new database named `BugTracker`.
3. Right-click on the created database and select New Query.
4. Use the following SQL query to create a table named Bugs.

```
Create Table Bugs(
Id BigInt Identity(1,1) Primary Key Not Null,
Summary Varchar(400) Not Null,
BugPriority Varchar(100) Not Null,
Assignee Varchar(100),
BugStatus Varchar(100) Not Null)
```

Now, the table design will look like below.

![Bug Table Design in Blazor](../images/bug-table-design.png)

## Adding Dapper package and creating a model class

To use Dapper and access database in the application, you need to install the following `NuGet` packages.

Run the following commands in the Package Manager Console.

* The following command enable us to use Dapper in our application.

    ```
    Install-Package Dapper -Version 2.1.24

    ```

* The following command provide database access classes such as  `SqlConnection`, `SqlCommand`, etc. Also provides data provider for MS SQL Server.

    ```
    Install-Package Microsoft.Data.SqlClient
    ```

Most of the ORMs provide scaffolding options to create model classes. Dapper doesn’t have any in-built scaffolding option. So, you need to create model class manually. Here, you are creating a class named `Bug.cs` in the `Data` folder as follows.

```c#

namespace {Your namespace}
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

![Bug Model Class in Blazor](../images/bug-model-class.png)

## Creating data access layer

Before creating a data access layer, you need to set the connection string of our database in the `appsettings.json` file as follows.

```cshtml

"ConnectionStrings": {
  "BugTrackerDatabase": "Server= {Your Server Name};Database=BugTracker;Integrated Security=True"
}

```
![Connection String in appsettings](../images/connection-string-appsettings.png)

Now, right-click the `Data` folder and select `Class` to create a new class named `BugDataAccessLayer.cs`. Replace this class with the following code, which contains code to handle CRUD in the `Bugs` table.

In the following example,

* In the constructor of the `BugDataAccessLayer`, `IConfiguration` is injected, which helps us to get the connection string provided in the `appsettings.json`.
* `GetBugsAsync` method performs select operation and returns a list of bugs from the Bugs table.
* `AddBugAsync` method inserts a new bug into the Bugs table.
* `UpdateBugAsync` method updates the given bug object in the table.
* `RemoveBugAsync` method removes the given bug by Id.

{% highlight c# %}

public class BugDataAccessLayer
{
    public IConfiguration Configuration;
    private const string BUGTRACKER_DATABASE = "BugTrackerDatabase";
    private const string SELECT_BUG = "select * from bugs";
    public BugDataAccessLayer(IConfiguration configuration)
    {
        Configuration = configuration; //Inject configuration to access Connection string from appsettings.json.
    }

    public async Task<List<Bug>> GetBugsAsync()
    {
        using (IDbConnection db = new SqlConnection(Configuration.GetConnectionString(BUGTRACKER_DATABASE)))
        {
            db.Open();
            IEnumerable<Bug> result = await db.QueryAsync<Bug>(SELECT_BUG);
            return result.ToList();
        }
    }

    public async Task<int> GetBugCountAsync()
    {
        using (IDbConnection db = new SqlConnection(Configuration.GetConnectionString(BUGTRACKER_DATABASE)))
        {
            db.Open();
            int result = await db.ExecuteScalarAsync<int>("select count(*) from bugs");
            return result;
        }
    }

    public async Task AddBugAsync(Bug bug)
    {
        using (IDbConnection db = new SqlConnection(Configuration.GetConnectionString(BUGTRACKER_DATABASE)))
        {
            db.Open();
            await db.ExecuteAsync("insert into bugs (Summary, BugPriority, Assignee, BugStatus) values (@Summary, @BugPriority, @Assignee, @BugStatus)", bug);
        }
    }

    public async Task UpdateBugAsync(Bug bug)
    {
        using (IDbConnection db = new SqlConnection(Configuration.GetConnectionString(BUGTRACKER_DATABASE)))
        {
            db.Open();
            await db.ExecuteAsync("update bugs set Summary=@Summary, BugPriority=@BugPriority, Assignee=@Assignee, BugStatus=@BugStatus where id=@Id", bug);
        }
    }

    public async Task RemoveBugAsync(int bugid)
    {
        using (IDbConnection db = new SqlConnection(Configuration.GetConnectionString(BUGTRACKER_DATABASE)))
        {
            db.Open();
            await db.ExecuteAsync("delete from bugs Where id=@BugId", new { BugId = bugid });
        }
    }
}

{% endhighlight %}

Now, register `BugDataAccessLayer` as scoped service in the `Program.cs` file as follows.

```cshtml
....
builder.Services.AddScoped<BugDataAccessLayer>();

```

## Adding Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid component

To add **Blazor DataGrid** component in the app, open the NuGet package manager in Visual Studio (*Tools → NuGet Package Manager → Manage NuGet Packages for Solution*), search and install [Syncfusion.Blazor.Grid](https://www.nuget.org/packages/Syncfusion.Blazor.Grid/) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/).

Alternatively, you can utilize the following package manager command to achieve the same.

{% tabs %}
{% highlight C# tabtitle="Package Manager" %}

Install-Package Syncfusion.Blazor.Grid -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.Themes -Version {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

N> Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components are available in [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). Refer to [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for available NuGet packages list with component details.

Open `_Import.razor` file and add the following namespaces which are required to use the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid Component in this application.

{% highlight razor %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Data

{% endhighlight %}

Open `Program.cs` file in your application and register the Syncfusion<sup style="font-size:70%">&reg;</sup> service.

```cshtml

....
using Syncfusion.Blazor;
....
builder.Services.AddSyncfusionBlazor();
....

```

Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor provides different themes. They are:

* Bootstrap4
* Material
* Fabric
* Bootstrap
* High Contrast

In this demo application, the Bootstrap4 theme will be used.

* For **.NET 7** app, add theme in the `<head>` of the **~/Pages/_Host.cshtml** file.

* For **.NET 6** app, add theme in the `<head>` of the **~/Pages/_Layout.cshtml** file.


{% highlight cshtml %}
<head>
    ....
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap4.css" rel="stylesheet" />
</head>

{% endhighlight %}

Also, include the script reference in the following files

* For **.NET 7** app, add script reference at end of the `<body>` section of the **~/Pages/_Host.cshtml** file.

* For **.NET 6** app, add script reference at end of the `<body>` section of the **~/Pages/_Layout.cshtml** file.

{% highlight cshtml %}
<body>
    ....
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
</body>
{% endhighlight %}

In previous steps, you have successfully configured the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor package in the application. Now, you can add the DataGrid Component to the `index.razor` page of your app.

{% highlight cshtml %}

<SfGrid>
</SfGrid>

{% endhighlight %}

## Binding data to the DataGrid component

Now, get SQL data using Dapper and bind it to the DataGrid component. To bind the database table to Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid, use the [custom data binding feature](https://blazor.syncfusion.com/documentation/datagrid/custom-binding) here.

The following points must be considered for creating a custom adaptor.

* Our custom adaptor must extend the `DataAdaptor` class.
* Override available CRUD methods to handle data querying and manipulation.
* Register our custom adaptor class as a service in the `Program.cs`.

Now, create a new class named `BugDataAdaptor.cs` under the `Data` folder and replace the following code in that class.

In the following code example,

* Extended `BugDataAdaptor` class with `DataAdaptor` base class.
* Injected `BugDataAccessLayer` instance to perform data operations.

{% highlight c# %}

public class BugDataAdaptor: DataAdaptor
{
    private BugDataAccessLayer _dataLayer;
    public BugDataAdaptor(BugDataAccessLayer bugDataAccessLayer)
    {
        _dataLayer = bugDataAccessLayer;
    }

    public override async Task<object> ReadAsync(DataManagerRequest dataManagerRequest, string key = null)
    {
        List<Bug> bugs = await _dataLayer.GetBugsAsync();
        int count = await _dataLayer.GetBugCountAsync();
        return dataManagerRequest.RequiresCounts ? new DataResult() { Result = bugs, Count = count } : (object)bugs;
    }
}

{% endhighlight %}

Now, Open the `Program.cs` file in the application and register the `BugDataAdaptor` class.

{% tabs %}
{% highlight c# tabtitle="~/Program.cs" hl_lines="4"%}

....
builder.Services.AddScoped<BugDataAccessLayer>();
builder.Services.AddSyncfusionBlazor();
builder.Services.AddScoped<BugDataAdaptor>();
.....

{% endhighlight %}
{% endtabs %}

Now, you need to add the `SfDataManager` in Grid for binding the data to the Grid and added column definition.

In the following code example,

* Defined `SfDataManager` component to provide data source to the grid. You can see that we have specified the `AdaptorInstance` property with the type of the custom adaptor we created in the previous step and mentioned the `Adaptor` property as `Adaptors.CustomAdaptor`.

* `TValue` is specified as `Bug` class.

{% highlight razor %}

<SfGrid TValue="Bug">
    <SfDataManager AdaptorInstance="typeof(BugDataAdaptor)" Adaptor="Adaptors.CustomAdaptor"></SfDataManager>
</SfGrid>

{% endhighlight %}

Grid columns can be defined using the [GridColumn](https://blazor.syncfusion.com/documentation/datagrid/columns) component. Next, you can create columns using the following code. Let's explore the properties used and their applications.

{% highlight razor %}

<SfGrid TValue="Bug">
    <SfDataManager AdaptorInstance="typeof(BugDataAdaptor)" Adaptor="Adaptors.CustomAdaptor"></SfDataManager>
    <GridColumns>
        <GridColumn Field="@nameof(Bug.Id)" IsPrimaryKey="true" Visible="false"></GridColumn>
        <GridColumn Field="@nameof(Bug.Summary)" Width="100"></GridColumn>
        <GridColumn Field="@nameof(Bug.BugPriority)" HeaderText="Priority" Width="100"></GridColumn>
        <GridColumn Field="@nameof(Bug.Assignee)" Width="100"></GridColumn>
        <GridColumn Field="@nameof(Bug.BugStatus)" HeaderText="Status" Width="100"></GridColumn>
    </GridColumns>
</SfGrid>

{% endhighlight %}

Now, the DataGrid will look like this while running the application. The displayed records are fetched from the database.

![Bug Grid Data in Blazor](../images/bug-grid-data.png)

## Handling CRUD operations with our Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid component

You can enable editing in the grid component using the [GridEditSettings](https://blazor.syncfusion.com/documentation/datagrid/editing) component. Grid provides various modes of editing options such as Inline/Normal, Dialog, and Batch editing. Refer to the following documentation for your reference.

[Grid Editing in Blazor](https://blazor.syncfusion.com/documentation/datagrid/editing#editing)

N> Normal editing is the default edit mode for the DataGrid component. You need to set the IsPrimaryKey property of Column as True for a particular column, whose value is a unique value for editing purposes.

Here, we are using inline edit mode and the [Toolbar](https://blazor.syncfusion.com/documentation/datagrid/tool-bar) property to show toolbar items for editing.

{% highlight razor %}

<SfGrid TValue="Bug" Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Update", "Cancel" })">
    <SfDataManager AdaptorInstance="typeof(BugDataAdaptor)" Adaptor="Adaptors.CustomAdaptor"></SfDataManager>
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true"></GridEditSettings>
    <GridColumns>
        <GridColumn Field="@nameof(Bug.Id)" IsPrimaryKey="true" Visible="false"></GridColumn>
        <GridColumn Field="@nameof(Bug.Summary)" Width="100"></GridColumn>
        <GridColumn Field="@nameof(Bug.BugPriority)" HeaderText="Priority" Width="100"></GridColumn>
        <GridColumn Field="@nameof(Bug.Assignee)" Width="100"></GridColumn>
        <GridColumn Field="@nameof(Bug.BugStatus)" HeaderText="Status" Width="100"></GridColumn>
    </GridColumns>
</SfGrid>

{% endhighlight %}

You have already created CRUD operations methods in the data access layer section itself. Now, you are going to call those methods while performing CRUD actions in DataGrid.

## Insert a row

Add the following codes(`InsertAsync`) in the `BugDataAdaptor`(CustomAdaptor) class to perform insert operation.

{% highlight c# %}

public override async Task<object> InsertAsync(DataManager dataManager, object data, string key)
{
    await _dataLayer.AddBugAsync(data as Bug);
    return data;
}

{% endhighlight %}

To insert a new row, click the `Add` toolbar button. The new record edit form will look like below.

![Insert a row in Grid](../images/insert-a-row.png)

Clicking the `Update` toolbar button will call the `InsertAsync` method of our `BugDataAdaptor` to insert the record in the `Bug` table. Now, the successfully inserted record in the grid will look like below.

![After inserting a row in Grid](../images/after-inserting-a-row.png)

## Update a row

Add the following codes (`UpdateAsync`) in the `BugDataAdaptor`(CustomAdaptor) class to perform update operation.

{% highlight c# %}

public override async Task<object> UpdateAsync(DataManager dataManager, object data, string keyField, string key)
{
    await _dataLayer.UpdateBugAsync(data as Bug);
    return data;
}

{% endhighlight %}

To edit a row, select any row and click the `Edit` toolbar button. The edit form will look like below.

![Updating a row in Grid](../images/updating-a-row.png)

Here, the `Status` field value is changed from `Not started` to `In progress`. Clicking the `Update` toolbar button will call the `UpdateAsync` method of `BugDataAdaptor` to update the record in the `Bug` table. Now, the successfully updated record in the grid will look like below.

![After updating a row in Grid](../images/after-updating.png)

## Delete a row

Add the following codes(`RemoveAsync`) in the `BugDataAdaptor`(CustomAdaptor) class to perform update operation.

{% highlight c# %}

public override async Task<object> RemoveAsync(DataManager dataManager, object primaryKeyValue, string keyField, string key)
{
    await _dataLayer.RemoveBugAsync(Convert.ToInt32(primaryKeyValue));
    return primaryKeyValue;
}

{% endhighlight %}

To delete a row, select any row and click the `Delete` toolbar button. Clicking the `Delete` toolbar button will call the `RemoveAsync` method of our `BugDataAdaptor` to update the record in the `Bug` table.

N> Find the sample from this [Github](https://github.com/SyncfusionExamples/blazor-datagrid-dapper-crud) location.

## See also

* [Create Blazor CRUD Application with PostgreSQL and Dapper](https://www.syncfusion.com/blogs/post/create-blazor-crud-application-with-postgresql-and-dapper.aspx)
