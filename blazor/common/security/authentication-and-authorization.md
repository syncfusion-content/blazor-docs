---
title: Authentication and Authorization in Blazor Components | Syncfusion®
description: Learn how to secure Blazor components with authentication and authorization in Blazor Server and WebAssembly applications.
platform: blazor
component: common
documentation: ug
---

# Authentication and Authorization for Blazor Components

This guide explains how to secure [Blazor components](https://www.syncfusion.com/blazor-components) using [authentication and authorization](https://learn.microsoft.com/en-us/aspnet/core/blazor/security). This enables you to control what users can see and interact with through UI-level security, while also protecting backend data access through data-level security.

## Prerequisites

* [.NET SDK](https://dotnet.microsoft.com/en-us/download/dotnet) 8.0 or later (examples in this guide use .NET 10).
* [Visual Studio](https://visualstudio.microsoft.com/downloads/) 2022 or later or [Visual Studio Code](https://code.visualstudio.com/) with [C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit) extension.

If you already have a Blazor project, proceed to the package installation section. Otherwise, create one using one of the following Blazor getting started guides.

* [Getting Started with Blazor WebAssembly App](https://blazor.syncfusion.com/documentation/getting-started/blazor-webassembly-app)
* [Getting Started with Blazor Server App](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-visual-studio)

## Install required packages

Install required packages in your project using the NuGet Package Manager in Visual Studio (*Tools → NuGet Package Manager → Manage NuGet Packages for Solution*), or the integrated terminal in Visual Studio Code (`dotnet add package`), or the .NET CLI.

**Microsoft packages:**

* [Microsoft.AspNetCore.Identity.UI](https://www.nuget.org/packages/Microsoft.AspNetCore.Identity.UI/)
* [Microsoft.AspNetCore.Identity.EntityFrameworkCore](https://www.nuget.org/packages/Microsoft.AspNetCore.Identity.EntityFrameworkCore) 
* [Microsoft.EntityFrameworkCore.Design](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Design)
* [Microsoft.EntityFrameworkCore.Tools](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Tools)
* [Microsoft.VisualStudio.Web.CodeGeneration.Design](https://www.nuget.org/packages/Microsoft.VisualStudio.Web.CodeGeneration.Design)

**Syncfusion packages:**

* [Syncfusion.Blazor.Grid](https://www.nuget.org/packages/Syncfusion.Blazor.Grid)
* [Syncfusion.Blazor.Schedule](https://www.nuget.org/packages/Syncfusion.Blazor.Schedule)
* [Syncfusion.Blazor.Navigations](https://www.nuget.org/packages/Syncfusion.Blazor.Navigations)
* [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes)

## Add required namespaces

Open the `~/_Imports.razor` file and add the required Blazor namespaces.

{% tabs %}
{% highlight c# tabtitle="~/_Imports.razor" %}

@using Microsoft.AspNetCore.Components.Authorization
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Schedule
@using Syncfusion.Blazor.Navigations

{% endhighlight %}
{% endtabs %}

## Add stylesheet and script resources

The theme stylesheet and script can be accessed from NuGet through [Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets). Include the [stylesheet](https://blazor.syncfusion.com/documentation/appearance/themes) and [script references](https://blazor.syncfusion.com/documentation/common/adding-script-references) in the **App.razor** file.

{% tabs %}
{% highlight html tabtitle="App.razor"  %}

<head>
    ...
    <!-- Blazor theme stylesheet -->
    <link href="_content/Syncfusion.Blazor.Themes/fluent2.css" rel="stylesheet" />
    ...
</head>
<body>
    ...
    <!-- Blazor core script (required for UI components) -->
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js"></script>
    ...
</body>

{% endhighlight %}
{% endtabs %}

## Configuring authentication and authorization

This guide uses authentication and authorization in a Blazor Server application with [ASP.NET Core Identity](https://learn.microsoft.com/en-us/aspnet/core/security/authentication/identity?view=aspnetcore-10.0&tabs=visual-studio). To set up ASP.NET Core Identity, refer to the following [guide](https://blazor.syncfusion.com/documentation/common/authentication/blazor-asp-net-core-identity). This approach provides a standard and recommended way to manage user authentication, roles, and access control within a Blazor Server application, and can be further extended based on application requirements such as external login providers or advanced authorization scenarios.

## Authentication with Blazor components

This section explains how to implement **UI-level** and **data-level authorization** in [Blazor components](https://www.syncfusion.com/blazor-components) such as [Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid), [Blazor Scheduler](https://www.syncfusion.com/blazor-components/blazor-scheduler), and [Blazor TreeView](https://www.syncfusion.com/blazor-components/blazor-treeview). UI-level authentication is demonstrated across all components using `<AuthorizeView>` to control the visibility of UI elements based on the user’s authentication state.

For data-level security, [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html) is configured to include **Bearer tokens** in API requests, enabling secure access to protected backend endpoints for components such as **Blazor DataGrid** and **Blazor Scheduler**. In this example, the **Blazor TreeView** component uses local data and focuses only on UI-level authentication.

### Configure Bearer Token for API Requests

To securely access protected APIs, include a **Bearer token** in the request headers using [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html).

**Generating token**

Create the token service file under the Services folder. In this example, use `TokenService.cs` as the file name.

{% tabs %}
{% highlight cs tabtitle="TokenService.cs" %}


public class TokenService
{
    // Replace this method with your actual token retrieval or generation logic
    public string GenerateToken()
    {
        // Replace this with your actual token generation logic.
        return Guid.NewGuid().ToString(); 
    }
}

{% endhighlight %}
{% endtabs %}

**Retrieve the token**

Inject `TokenService` into your `.razor` component, then call `TokenService.GenerateToken()` inside a lifecycle method such as `OnInitializedAsync`, as shown in the component examples below.

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

@inject TokenService TokenService

@code {
    private string? token;

    protected override Task OnInitializedAsync()
    {
        token = TokenService.GenerateToken();
        return Task.CompletedTask;
    }
}

{% endhighlight %}
{% endtabs %}


### Blazor DataGrid component

The [Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) can be secured by using the [SfDataManager.Headers](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html#Syncfusion_Blazor_DataManager_Headers) property, which enables the component to send authenticated requests to protected APIs. This ensures that the UI behavior (via `<AuthorizeView>`) is aligned with the underlying data access rules.

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Data
@inject TokenService TokenService

<h3>DataGrid</h3>

<AuthorizeView>
    <Authorized Context="authContext">
        <SfGrid TValue="Order" AllowPaging="true">
            @* Replace with your actual protected API endpoint *@
            <SfDataManager Url="https://your-api.com/api/orders/" Adaptor="Adaptors.WebApiAdaptor" Headers="@HeaderData"></SfDataManager>
            <GridPageSettings PageSize="10"></GridPageSettings>
            <GridColumns>
                <GridColumn Field="@nameof(Order.OrderID)" HeaderText="Order ID" IsPrimaryKey="true" Width="120"></GridColumn>
                <GridColumn Field="@nameof(Order.CustomerID)" HeaderText="Customer Name" Width="150"></GridColumn>
                <GridColumn Field="@nameof(Order.OrderDate)" HeaderText="Order Date" Format="d" Type="ColumnType.Date" Width="130"></GridColumn>
                <GridColumn Field="@nameof(Order.Freight)" HeaderText="Freight" Format="C2" Width="120"></GridColumn>
            </GridColumns>
        </SfGrid>
        <p>Hello, @authContext.User.Identity?.Name!</p>
    </Authorized>
    <NotAuthorized>
        <p>Please log in to view the DataGrid.</p>
        <a href="Identity/Account/Login">Log in</a>
    </NotAuthorized>
</AuthorizeView>

@code {
    private Dictionary<string, string> HeaderData { get; } = new Dictionary<string, string>();

    protected override Task OnInitializedAsync()
    {
        var token = TokenService.GenerateToken();
        HeaderData["Authorization"] = $"Bearer {token}";
        return Task.CompletedTask;
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string? CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

### Blazor Scheduler component

The [Blazor Scheduler](https://www.syncfusion.com/blazor-components/blazor-scheduler) uses [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html) to send authenticated requests and retrieve event data securely from protected APIs. This ensures that only authorized users can access protected data from the API.

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

@using Syncfusion.Blazor.Schedule
@using Syncfusion.Blazor.Data
@inject TokenService TokenService

<AuthorizeView>
    <Authorized>
        <SfSchedule TValue="AppointmentData" Height="550px" SelectedDate="@currentDate">
            <ScheduleEventSettings TValue="AppointmentData">
                @* Replace with your actual protected API endpoint *@
                <SfDataManager Url="https://your-api.com/api/schedule" Headers="@HeaderData" Adaptor="Adaptors.WebApiAdaptor"></SfDataManager>
            </ScheduleEventSettings>
            <ScheduleViews>
                <ScheduleView Option="View.Month"></ScheduleView>
            </ScheduleViews>
        </SfSchedule>
    </Authorized>
    <NotAuthorized>
        <p>Authentication required to view schedule.</p>
        <a href="Identity/Account/Login">Log in</a>
    </NotAuthorized>
</AuthorizeView>

@code {
    private DateTime currentDate = DateTime.Today;
    private Dictionary<string, string> HeaderData { get; } = new Dictionary<string, string>();

    protected override Task OnInitializedAsync()
    {
        var token = TokenService.GenerateToken();
        HeaderData["Authorization"] = $"Bearer {token}";
        return Task.CompletedTask;
    }

    public class AppointmentData
    {
        public int Id { get; set; }
        public string? Subject { get; set; }
        public string? Location { get; set; }
        public string? Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool? IsAllDay { get; set; }
        public string? CategoryColor { get; set; }
        public string? RecurrenceRule { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

### Blazor TreeView component

The following example demonstrates UI-level authorization using `<AuthorizeView>`. [Blazor TreeView](https://www.syncfusion.com/blazor-components/blazor-treeview) in this sample uses local data. For data-bound TreeView scenarios (e.g., async data loading from an API), apply the same `SfDataManager + Bearer token` pattern shown in the [Blazor DataGrid component](#blazor-datagrid-component) and [Blazor Scheduler component](#blazor-scheduler-component) sections.

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

@using Syncfusion.Blazor.Navigations

<AuthorizeView>
    <Authorized Context="authContext">
        <SfTreeView TValue="MailItem">
            <TreeViewFieldsSettings TValue="MailItem" Id="Id" DataSource="@MyFolder" Text="FolderName" ParentID="ParentId" HasChildren="HasSubFolders" Expanded="Expanded">
            </TreeViewFieldsSettings>
        </SfTreeView>
        <p>Welcome, @authContext.User.Identity?.Name!</p>
        <form method="post" action="Identity/Account/LogOut">
            <AntiforgeryToken />
            <button type="submit">Log out</button>
        </form>
    </Authorized>
    <NotAuthorized>
        <p>Log in to access the TreeView.</p>
        <a href="Identity/Account/Login">Log in</a>
        <a href="Identity/Account/Register">Register</a>
    </NotAuthorized>
</AuthorizeView>

@code {

    public class MailItem
    {
        public string? Id { get; set; }
        public string? ParentId { get; set; }
        public string? FolderName { get; set; }
        public bool Expanded { get; set; }
        public bool HasSubFolders { get; set; }
    }

   private List<MailItem> MyFolder = new List<MailItem>();

   protected override void OnInitialized()
   {
        // Load hierarchical folder data
        LoadFolderData();
   }

   private void LoadFolderData()
   {
        MyFolder.Add(new MailItem { Id = "1", FolderName = "Inbox", HasSubFolders = true, Expanded = true });
        MyFolder.Add(new MailItem { Id = "2", ParentId = "1", FolderName = "Categories", Expanded = true, HasSubFolders = true });
        MyFolder.Add(new MailItem { Id = "3", ParentId = "2", FolderName = "Primary" });
        MyFolder.Add(new MailItem { Id = "4", ParentId = "2", FolderName = "Social" });
        MyFolder.Add(new MailItem { Id = "5", ParentId = "2", FolderName = "Promotions" });
    }
}

{% endhighlight %}
{% endtabs %}

## Run the application

Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to launch the application.

Alternatively, run the application using the following .NET CLI command from the project root directory.

{% tabs %}
{% highlight bash tabtitle=".NET CLI" %}

dotnet run

{% endhighlight %}
{% endtabs %}

**Expected behavior**
* Blazor components should render **only for authorized users**.
* If the user is not authenticated, the application should display **Register or Log in** options instead of the Blazor components.
* After a successful login, the user should be able to view the Blazor components such as **Blazor DataGrid, Blazor Scheduler, and Blazor TreeView** while navigating across different pages.

**Output:**
![Blazor Authentication And Authorization](./authentication-authorization.webp)

## See also

* [Getting started with Blazor DataGrid](https://blazor.syncfusion.com/documentation/datagrid/getting-started-with-server-app)
* [Getting started with Blazor Scheduler](https://blazor.syncfusion.com/documentation/scheduler/getting-started-with-server-app)
* [Getting started with Blazor TreeView](https://blazor.syncfusion.com/documentation/treeview/getting-started-with-server-app)
* [Blazor Server app with authentication](https://learn.microsoft.com/en-us/aspnet/core/blazor/security/?view=aspnetcore-10.0&tabs=visual-studio)
