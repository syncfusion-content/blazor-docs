---
layout: post
title: Getting Started with TreeGrid in Blazor WASM App | Syncfusion
description: Learn about getting started with Blazor TreeGrid component in Blazor WebAssembly Application.
platform: Blazor
control: TreeGrid
documentation: ug
---

# Getting Started with Blazor TreeGrid in Blazor WASM App

This section explains how to include [Blazor TreeGrid](https://www.syncfusion.com/blazor-components/blazor-tree-grid) component in a Blazor WebAssembly App using [Visual Studio](https://visualstudio.microsoft.com/vs/), [Visual Studio Code](https://code.visualstudio.com/), and the [.NET CLI](https://learn.microsoft.com/en-us/dotnet/core/tools/).

{% tabcontents %}

{% tabcontent Visual Studio %}

## Prerequisites

The following software and tools must be installed before proceeding:

| Software/Tool | Version | Purpose |
|---|---|---|
| **Visual Studio** | 2022 (17.8 or later) | IDE for building Blazor applications |
| **.NET SDK** | 8.0 or later | Runtime and compilation framework |

### System Requirements

- **RAM**: Minimum 4 GB (8 GB recommended)
- **Disk Space**: Minimum 2 GB free space
- **Internet Connection**: Required for downloading NuGet packages

## Create a new Blazor WebAssembly App in Visual Studio

1. Open **Visual Studio 2022** (version 17.8 or later).
2. Click **Create a new project** in the start window.
3. Search for **Blazor WebAssembly App** template and select it.
4. Click **Next** to proceed.
5. Enter the project name (for example, `TreeGridWasmApp`).
6. Select the project location and solution settings.
7. Click **Next** to continue.
8. Select **.NET 8.0** (or the latest installed version) as the target framework.
9. Click **Create** to generate the project.

## Install Syncfusion Blazor TreeGrid

1. Open the **NuGet Package Manager Console**:
   - Navigate to **Tools → NuGet Package Manager → Package Manager Console**

2. Run the following commands in the Package Manager Console:

{% tabs %}
{% highlight C# tabtitle="Package Manager" %}

Install-Package Syncfusion.Blazor.TreeGrid -Version 24.1.36
Install-Package Syncfusion.Blazor.Themes -Version 24.1.36

{% endhighlight %}
{% endtabs %}

3. Press Enter to execute each command.
4. Wait for the packages to download and install.

{% endtabcontent %}

{% tabcontent Visual Studio Code %}

## Prerequisites

The following software and tools must be installed before proceeding:

| Software/Tool | Version | Purpose |
|---|---|---|
| **Visual Studio Code** | Latest | Alternative lightweight editor |
| **.NET SDK** | 8.0 or later | Runtime and compilation framework |

## Create a new Blazor WebAssembly App in Visual Studio Code

1. Open a terminal or command prompt.
2. Navigate to the desired project location.
3. Run the following command to create a new Blazor WebAssembly App:

{% tabs %}
{% highlight c# tabtitle="Blazor WASM App" %}

dotnet new blazorwasm -o TreeGridWasmApp
cd TreeGridWasmApp

{% endhighlight %}
{% endtabs %}

## Install Syncfusion Blazor TreeGrid

1. Open a terminal or command prompt in the project directory.
2. Run the following commands:

{% tabs %}
{% highlight c# tabtitle="Blazor WASM App" %}

dotnet add package Syncfusion.Blazor.TreeGrid --version 24.1.36
dotnet add package Syncfusion.Blazor.Themes --version 24.1.36
dotnet restore

{% endhighlight %}
{% endtabs %}

{% endtabcontent %}

{% tabcontent .NET CLI %}

## Prerequisites

The following software and tools must be installed before proceeding:

| Software/Tool | Version | Purpose |
|---|---|---|
| **.NET SDK** | 8.0 or later | Runtime and compilation framework |

## Create a new Blazor WebAssembly App using .NET CLI

1. Open a terminal or command prompt.
2. Navigate to the desired project location.
3. Run the following command to create a new Blazor WebAssembly App:

{% tabs %}
{% highlight c# tabtitle="Blazor WASM App" %}

dotnet new blazorwasm -o TreeGridWasmApp
cd TreeGridWasmApp

{% endhighlight %}
{% endtabs %}

## Install Syncfusion Blazor TreeGrid

1. Open a terminal or command prompt.
2. Navigate to the project directory containing the `.csproj` file.
3. Run the following commands:

{% tabs %}
{% highlight c# tabtitle="Blazor WASM App" %}

dotnet add package Syncfusion.Blazor.TreeGrid --version 24.1.36
dotnet add package Syncfusion.Blazor.Themes --version 24.1.36
dotnet restore

{% endhighlight %}
{% endtabs %}

{% endtabcontent %}

{% endtabcontents %}

---

## Register Syncfusion Blazor Services

**Add Import Namespaces**

1. Open the `_Imports.razor` file in the project root.

2. Add the following namespaces at the end of the file:

```razor
@using Syncfusion.Blazor
@using Syncfusion.Blazor.TreeGrid
```

3. Save the file.

**Register Syncfusion Services in Program.cs**

1. Open the `Program.cs` file.

2. Add the Syncfusion service registration after the existing service configurations:

```csharp
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Syncfusion.Blazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Register Syncfusion Blazor service
builder.Services.AddSyncfusionBlazor();

await builder.Build().RunAsync();
```

3. Save the file.

---

## Add stylesheet and script resources

The theme stylesheet and script can be accessed from NuGet through [Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets). Include the stylesheet and script references within the `<head>` section of the **~/index.html** file.

```html
<head>
    ....
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>

    <!--Blazor TreeGrid Component script reference.-->
    <!-- <script src="_content/Syncfusion.Blazor.TreeGrid/scripts/sf-treegrid.min.js" type="text/javascript"></script> -->
</head>
```

N> Check out the [Blazor Themes](https://blazor.syncfusion.com/documentation/appearance/themes) topic to discover various methods ([Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets), [CDN](https://blazor.syncfusion.com/documentation/appearance/themes#cdn-reference), and [CRG](https://blazor.syncfusion.com/documentation/common/custom-resource-generator)) for referencing themes in Blazor application. Also, check out the [Adding Script Reference](https://blazor.syncfusion.com/documentation/common/adding-script-references) topic to learn different approaches for adding script references in Blazor application.

## Add Syncfusion® Blazor TreeGrid component

1. Navigate to the `Pages` folder.

2. Open the `Home.razor` file (or create `TreeGrid.razor`).

3. Add the component markup.

```razor
<SfTreeGrid DataSource="@TreeData" 
    IdMapping="TaskId" 
    ParentIdMapping="ParentId" 
    TreeColumnIndex="1">
</SfTreeGrid>
```

**Note:** The `@rendermode` directive is not required for standalone Blazor WebAssembly apps as the render mode is configured globally.

---

## Define Row Data

1. In the `Home.razor` file, replace the content with the following:

```razor
@page "/"
@using Syncfusion.Blazor.TreeGrid
@using Syncfusion.Blazor.Grids
<h1>Project Management Dashboard</h1>

<SfTreeGrid DataSource="@TreeData" IdMapping="TaskId" ParentIdMapping="ParentId" TreeColumnIndex="1">
    <TreeGridColumns>
        <TreeGridColumn Field="TaskId" HeaderText="Task ID" Width="80" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="TaskName" HeaderText="Task Name" Width="200"></TreeGridColumn>
        <TreeGridColumn Field="StartDate" HeaderText="Start Date" Type="Syncfusion.Blazor.Grids.ColumnType.DateOnly" Format="d" Width="100" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="Duration" HeaderText="Duration (Days)" Width="100" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="Progress" HeaderText="Progress (%)" Width="100" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="Priority" HeaderText="Priority" Width="80"></TreeGridColumn>
    </TreeGridColumns>
</SfTreeGrid>

@code {
    public class TaskData
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public DateTime? StartDate { get; set; }
        public int Duration { get; set; }
        public int Progress { get; set; }
        public string Priority { get; set; }
        public int? ParentId { get; set; }
    }

    public List<TaskData> TreeData = new List<TaskData>();

    protected override void OnInitialized()
    {
        TreeData.Add(new TaskData 
        { 
            TaskId = 1, 
            TaskName = "Project Launch", 
            StartDate = new DateTime(2026, 02, 01),
            Duration = 30,
            Progress = 40,
            Priority = "High",
            ParentId = null 
        });

        TreeData.Add(new TaskData 
        { 
            TaskId = 2, 
            TaskName = "Planning & Design", 
            StartDate = new DateTime(2026, 02, 01),
            Duration = 14,
            Progress = 80,
            Priority = "High",
            ParentId = 1 
        });

        TreeData.Add(new TaskData 
        { 
            TaskId = 3, 
            TaskName = "Requirements Analysis", 
            StartDate = new DateTime(2026, 02, 01),
            Duration = 5,
            Progress = 100,
            Priority = "High",
            ParentId = 2 
        });

        TreeData.Add(new TaskData 
        { 
            TaskId = 4, 
            TaskName = "Development", 
            StartDate = new DateTime(2026, 02, 15),
            Duration = 12,
            Progress = 10,
            Priority = "High",
            ParentId = 1 
        });

        TreeData.Add(new TaskData 
        { 
            TaskId = 5, 
            TaskName = "Backend Development", 
            StartDate = new DateTime(2026, 02, 15),
            Duration = 7,
            Progress = 15,
            Priority = "High",
            ParentId = 4 
        });

        TreeData.Add(new TaskData 
        { 
            TaskId = 6, 
            TaskName = "Frontend Development", 
            StartDate = new DateTime(2026, 02, 18),
            Duration = 4,
            Progress = 5,
            Priority = "Medium",
            ParentId = 4 
        });
    }
}
```

2. Save the file.

---

## Define Columns

The TreeGrid displays data in columns. Each column maps to a property in the data model through the `Field` property.

1. In the `Home.razor` file, locate the `<TreeGridColumns>` section.

2. Review the existing column definitions:

```razor
<TreeGridColumns>
    <TreeGridColumn Field="TaskId" HeaderText="Task ID" Width="80" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
    <TreeGridColumn Field="TaskName" HeaderText="Task Name" Width="200"></TreeGridColumn>
    <TreeGridColumn Field="StartDate" HeaderText="Start Date" Type="Syncfusion.Blazor.Grids.ColumnType.Date" Format="yMd" Width="120"></TreeGridColumn>
    <TreeGridColumn Field="Duration" HeaderText="Duration (Days)" Width="100" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
    <TreeGridColumn Field="Progress" HeaderText="Progress (%)" Width="100" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
    <TreeGridColumn Field="Priority" HeaderText="Priority" Width="80"></TreeGridColumn>
</TreeGridColumns>
```

**Column Properties**

| Property | Purpose | Values |
|---|---|---|
| **Field** | Maps column to data property | Property name from data model |
| **HeaderText** | Column header display text | Any string value |
| **Width** | Column width | Pixels (e.g., "80") or percentage (e.g., "20%") |
| **TextAlign** | Text alignment in cells | Left, Center, Right |

> **Note:** The `TreeColumnIndex="1"` property on the SfTreeGrid component specifies that the tree expand/collapse icons appear in the `TaskName` column (second column).

---

## Enable paging

The paging feature enables users to view the TreeGrid records in a paged view. It can be enabled by setting the  [AllowPaging](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_AllowPaging) property to true. The pager can be customized using the [PageSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_PageSettings) property.

In root-level paging mode, paging is based on the root-level rows only, i.e., it ignores the child row count and it can be enabled by using the [PageSettings.PageSizeMode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridPageSettings.html#Syncfusion_Blazor_TreeGrid_TreeGridPageSettings_PageSizeMode) property.

```razor
<SfTreeGrid DataSource="@TreeData" 
    IdMapping="TaskId" 
    ParentIdMapping="ParentId" 
    TreeColumnIndex="1"
    AllowPaging="true">
    <TreeGridPageSettings PageSizeMode="PageSizeMode.Root" PageSize="10"></TreeGridPageSettings>
    <TreeGridColumns>
        <!-- Column definitions -->
    </TreeGridColumns>
</SfTreeGrid>
```

## Enable sorting

The sorting feature enables ordering records. It can be enabled by setting the  [AllowSorting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_AllowSorting) property to `true`.

```razor
<SfTreeGrid DataSource="@TreeData" 
    IdMapping="TaskId" 
    ParentIdMapping="ParentId" 
    TreeColumnIndex="1"
    AllowPaging="true"
    AllowSorting="true">
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/rtLzNMKDzGDJVWCD?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor TreeGrid](images/blazor-treegrid.png)" %}

N> [View Sample in GitHub](https://github.com/SyncfusionExamples/Blazor-Getting-Started-Examples/tree/main/TreeGrid).

## Handling exceptions

Exception handling in TreeGrid identifies exceptions and notifies them through the [OnActionFailure](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridEvents-1.html#Syncfusion_Blazor_TreeGrid_TreeGridEvents_1_OnActionFailure) event. When configuring the TreeGrid or enabling specific features through its API, mistakes can occur. Use the `OnActionFailure` event to handle these exceptions. This event triggers when such mistakes happen. The `OnActionFailure` event handles various scenarios, including:

* For CRUD operations, row drag and drop, and persisting the selection, ensure the [IsPrimaryKey](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridColumn.html#Syncfusion_Blazor_TreeGrid_TreeGridColumn_IsPrimaryKey) property is mapped to a unique data column. Failure to do so will cause an exception.
* [Paging](https://blazor.syncfusion.com/documentation/treegrid/paging) is not supported with [Virtualization](https://blazor.syncfusion.com/documentation/treegrid/virtualization). Enabling `Paging` with `Virtualization` will result in an exception.
* To render the TreeGrid, map either the [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_DataSource) or [Columns](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_Columns) property. Failure to do so will result in an exception.
* Freeze columns by mapping either [IsFrozen](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridColumn.html#Syncfusion_Blazor_TreeGrid_TreeGridColumn_IsFrozen) or [FrozenColumns](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_FrozenColumns). Enabling both properties simultaneously will result in an exception.
* The [DetailTemplate](https://blazor.syncfusion.com/documentation/treegrid/rows/detail-template) is not supported with `Virtualization` and `Stacked Header`. Enabling them with these features will result in an exception.

* The [FrozenRows](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_FrozenRows) and `FrozenColumns` are not supported with [RowTemplate](https://blazor.syncfusion.com/documentation/treegrid/rows/row-template), `DetailTemplate`, and [Cell Editing](https://blazor.syncfusion.com/documentation/treegrid/editing/cell-editing). Enabling them with these features will result in an exception.

* In `Stacked Header`, the [Freeze](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridColumn.html#Syncfusion_Blazor_TreeGrid_TreeGridColumn_Freeze) direction is incompatible with [Column Reordering](https://blazor.syncfusion.com/documentation/treegrid/columns/column-reorder).  
* [Selection](https://blazor.syncfusion.com/documentation/treegrid/selection) functionality is not supported when using `RowTemplate`. Enabling both properties simultaneously will result in an exception.
* Set the [TreeColumnIndex](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_TreeColumnIndex) value to display the tree structure. Make sure the value does not exceed the total column count, or it will result in an exception.
* For `Virtualization`, do not specify height and width in percentages. Using percentages will result in an error.
* When using the default filter ([FilterBar](https://blazor.syncfusion.com/documentation/treegrid/filtering/filter-bar)) type, do not apply the other [FilterType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.FilterType.html) to columns within the same TreeGrid, as this will result in an exception.
* In TreeGrid, avoid enabling [IdMapping](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_IdMapping) and [ChildMapping](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_ChildMapping) simultaneously. Enabling both properties at the same time will result in an exception.
* The [ShowCheckbox](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridColumn.html#Syncfusion_Blazor_TreeGrid_TreeGridColumn_ShowCheckbox) property is supported only on the tree column. Defining it elsewhere will result in an exception.
* The [TextAlign](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridColumn.html#Syncfusion_Blazor_TreeGrid_TreeGridColumn_TextAlign) right is not applicable for tree columns in the TreeGrid.  Enabling right alignment for tree columns will result in an exception.

The following code example shows how to use the [OnActionFailure](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridEvents-1.html#Syncfusion_Blazor_TreeGrid_TreeGridEvents_1_OnActionFailure) event in the TreeGrid control to display an exception when `IsPrimaryKey` is not configured properly in the TreeGrid.

```razor
@if (!string.IsNullOrEmpty(ErrorMessage))
{
    <div style="color: red; padding: 10px; border: 1px solid red;">
        <strong>Error:</strong> @ErrorMessage
    </div>
}

<SfTreeGrid DataSource="@TreeData" 
    IdMapping="TaskId" 
    ParentIdMapping="ParentId" 
    TreeColumnIndex="1"
    AllowPaging="true"
    AllowSorting="true">
    <TreeGridEvents TValue="TaskData" OnActionFailure="@OnActionFailure"></TreeGridEvents>
    <!-- ... -->
</SfTreeGrid>

@code {
    public string ErrorMessage { get; set; } = "";

    public void OnActionFailure(FailureEventArgs args)
    {
        ErrorMessage = args.Error?.Message ?? "An unknown error occurred";
        StateHasChanged();
    }
    // ...
}
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/hNVztHsLJVPJfMvO?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## See also

* [Getting Started with Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor for Server-Side in .NET Core CLI](https://blazor.syncfusion.com/documentation/getting-started/blazor-web-app)
* [Getting Started with Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor for Client-Side in Visual Studio](https://blazor.syncfusion.com/documentation/getting-started/blazor-webassembly-visual-studio)
* [Getting Started with Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor for Client-Side in .NET Core CLI](https://blazor.syncfusion.com/documentation/getting-started/blazor-webassembly-app)
* [Getting Started with Syncfusion<sup style="font-size:70%">&reg;</sup> JavaScript documentation](https://ej2.syncfusion.com/documentation/treegrid/getting-started)
* [Getting Started with Syncfusion<sup style="font-size:70%">&reg;</sup> JavaScript (ES5) documentation](https://ej2.syncfusion.com/javascript/documentation/treegrid/getting-started)
* [Getting Started with Syncfusion<sup style="font-size:70%">&reg;</sup> Angular documentation](https://ej2.syncfusion.com/angular/documentation/treegrid/getting-started)
* [Getting Started with Syncfusion<sup style="font-size:70%">&reg;</sup> React documentation](https://ej2.syncfusion.com/react/documentation/treegrid/getting-started)
* [Getting Started with Syncfusion<sup style="font-size:70%">&reg;</sup> Vue documentation](https://ej2.syncfusion.com/vue/documentation/treegrid/getting-started)
* [Getting Started with Syncfusion<sup style="font-size:70%">&reg;</sup> ASP.NET Core documentation](https://ej2.syncfusion.com/aspnetcore/documentation/tree-grid/getting-started-core)
* [Getting Started with Syncfusion<sup style="font-size:70%">&reg;</sup> ASP.NET MVC documentation](https://ej2.syncfusion.com/aspnetmvc/documentation/tree-grid/getting-started-mvc)
