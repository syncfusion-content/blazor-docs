---
title: Authentication and Authorization in Syncfusion Blazor Components
description: Learn how to secure Syncfusion Blazor components with authentication and authorization in Blazor Server and WebAssembly applications.
platform: blazor
component: common
documentation: ug
---

# Authentication and Authorization in Syncfusion® Blazor Components

This guide shows how to secure Syncfusion Blazor components with authentication and authorization. It covers UI-level security (to control what users see and interact with) and data-level security (to protect backend data access), with examples using the [DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) and [Scheduler](https://www.syncfusion.com/blazor-components/blazor-scheduler) for both, and the [TreeView](https://www.syncfusion.com/blazor-components/blazor-treeview) for UI-level only.

Authentication verifies a user's identity. Authorization then determines the access levels and actions the user can perform. Syncfusion Blazor components integrate with Blazor's built-in authentication and authorization features to enable both UI-level and data-level security.

## What is authentication?

Authentication verifies a user's identity in your Blazor application. Blazor apps often use cookie-based authentication where a signed cookie is stored in the browser and validated server-side for each request. For WebAssembly apps, use token-based systems like JSON Web Tokens (JWTs). Another option is the Backend-for-Frontend (BFF) pattern, where a server manages authentication on behalf of the client. In this pattern, the BFF acts as an intermediary that handles token exchange and manages sensitive credentials server-side, preventing tokens from being exposed to browser JavaScript.

Syncfusion components access user identity information through Blazor's `AuthenticationStateProvider`. This allows secure data loading or feature restriction based on the user's identity.

## What is authorization?

Authorization determines which Syncfusion components or features a user is allowed to access after successful authentication. Blazor supports authorization via:

* **Role checks:** Verify user group membership (e.g., 'Admin').
* **Policies:** Custom rules, such as requiring multiple roles or claims (key-value attributes in the user's identity, like 'department=Engineering').
* **UI filtering:** Use the `<AuthorizeView>` component to show or hide content.

## Key differences between authentication and authorization

The following table summarizes the functional and behavioral differences between authentication and authorization in a Blazor and Syncfusion context:

| Aspect | Authentication | Authorization |
|---|---|---|
| **Purpose** | Verifies user identity. | Grants or denies access to resources and features. |
| **Timing**  | Happens first | Happens after authentication |
| **Blazor Tools** | `AuthenticationStateProvider` | `<AuthorizeView>`, `[Authorize]` |
| **Syncfusion Integration** | Access user identity via `AuthenticationStateProvider` for data loading. | UI-level: Use `<AuthorizeView>` to conditionally render components. Data-level: Add Bearer tokens to `SfDataManager.Headers` for secure API calls. |

## Applying authentication and authorization to Syncfusion® components

Syncfusion components can be secured at two layers:

* **UI-level authorization**: Use `<AuthorizeView>` to conditionally render components based on user roles.
* **Data-level authentication**: Use authentication tokens (Bearer tokens) in `SfDataManager` to enforce access to protected API data.

For full security, combine UI-level and data-level approaches. The following examples demonstrate this with Syncfusion components.

N> This `<AuthorizeView>` and `SfDataManager` pattern applies to most data-bound Syncfusion components, such as DataGrid, Charts, Scheduler, and TreeView. For non data-bound ones (e.g., Button), use only `<AuthorizeView>`.

## Using Syncfusion® components

All examples use `<AuthorizeView>` for UI-level security. DataGrid and Scheduler also include `SfDataManager` with Bearer tokens for data-level authentication. TreeView uses local data.

If you already have a Blazor project, proceed to the package installation section. Otherwise, create one using Syncfusion’s Blazor getting started guides.

* [WebAssembly getting started](https://blazor.syncfusion.com/documentation/getting-started/blazor-webassembly-app)
* [Server getting started](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-visual-studio)

### Prerequisites

* [.NET SDK](https://dotnet.microsoft.com/en-us/download/visual-studio-sdks) 8.0 or later; Examples use .NET 10.
* [Visual Studio](https://visualstudio.microsoft.com/downloads/) 2022 or later or Visual Studio Code with [C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit) extension.
* [AuthorizeView](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.components.authorization.authorizeview), [AuthenticationStateProvider](https://learn.microsoft.com/en-us/aspnet/core/blazor/security/authentication-state), and token-based data requests require the Blazor authentication pipeline to be configured.

### Install required packages:

Use NuGet Package Manager (*Tools → NuGet Package Manager → Manage NuGet Packages for Solution*) and install the following packages:

**Microsoft packages:**

* [Microsoft.AspNetCore.Identity.UI](https://www.nuget.org/packages/Microsoft.AspNetCore.Identity.UI/)
* [Microsoft.AspNetCore.Authorization](https://www.nuget.org/packages/Microsoft.AspNetCore.Authorization/)

**Syncfusion packages:**

* [Syncfusion.Blazor.Grid](https://www.nuget.org/packages/Syncfusion.Blazor.Grid)
* [Syncfusion.Blazor.Schedule](https://www.nuget.org/packages/Syncfusion.Blazor.Schedule)
* [Syncfusion.Blazor.Navigations](https://www.nuget.org/packages/Syncfusion.Blazor.Navigations)
* [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes)

### Add required namespaces

Open the `~Components/_Imports.razor` file and import the `Syncfusion.Blazor`, `Syncfusion.Blazor.Grids`, `Syncfusion.Blazor.Schedule`, `Syncfusion.Blazor.Navigations` namespaces.

{% tabs %}
{% highlight razor tabtitle="~/_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Schedule
@using Syncfusion.Blazor.Navigations

{% endhighlight %}
{% endtabs %}

### Add stylesheet and script resources

Add the Syncfusion theme CSS and required scripts to the `~/Components/App.razor` file.

{% tabs %}
{% highlight html  %}

<head>
     <!-- Syncfusion theme style sheet -->
    <link href="_content/Syncfusion.Blazor.Themes/fluent2.css" rel="stylesheet" />
</head>
<body>
    <!-- Syncfusion Blazor component's script reference -->
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js"></script>
</body>

{% endhighlight %}
{% endtabs %}

N> Syncfusion provides multiple theme variants, allowing selection of the theme that best aligns with the application's UI design. Additional theme options and customization details are available in the [theming documentation](https://blazor.syncfusion.com/documentation/appearance/themes).

### Configuring authentication and authorization

**Step 1. Wrap the application's router in App.razor:**

{% tabs %}
{% highlight razor %}
<CascadingAuthenticationState>
    <Router AppAssembly="@typeof(App).Assembly" />
</CascadingAuthenticationState>

{% endhighlight %}
{% endtabs %}

**Step 2. Inject the authentication provider where needed (eg., in a .razor file):**

{% tabs %}
{% highlight razor %}

@inject AuthenticationStateProvider AuthStateProvider

{% endhighlight %}
{% endtabs %}

**Step 3. Register authentication and syncfusion® services in Program.cs:**

{% tabs %}
{% highlight cs %}

using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Identity;
using Syncfusion.Blazor;
...
builder.Services.AddAuthentication(IdentityConstants.ApplicationScheme)
    .AddCookie(IdentityConstants.ApplicationScheme);
builder.Services.AddAuthorization();
// This class is scaffolded by the Blazor Server Identity template.
// If using a custom provider, replace with your own AuthenticationStateProvider implementation.
builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
// Add Syncfusion Blazor services
builder.Services.AddSyncfusionBlazor();
 
{% endhighlight %}
{% endtabs %}

### DataGrid

The DataGrid can be secured by using the `SfDataManager.Headers` property, which allows the grid to load data securely from protected APIs. This ensures that the UI behavior (via `<AuthorizeView>`) is aligned with the underlying data access rules.

N> 
* For testing only, add a Bearer token to `appsettings.json` under the section `ExternalApi:BearerToken`. Never commit tokens to source control. 
 *  For production, retrieve the token dynamically from the authenticated user's claims using `AuthenticationStateProvider` instead of static configuration.

{% tabs %}
{% highlight json %}

{
  "ExternalApi": {
    "BearerToken": "YOUR-TOKEN-HERE"
  }
}

{% endhighlight %}
{% endtabs %}

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Data
@inject IConfiguration Configuration

<h3> DataGrid</h3>

<AuthorizeView>
    <Authorized Context="authContext">
            <SfGrid TValue="Order" AllowPaging="true">
            <!-- Replace with your actual protected API endpoint -->
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

    protected override async Task OnInitializedAsync()
    {
        // Retrieve Bearer token from configuration (for testing only)
        var token = Configuration["ExternalApi:BearerToken"];
        if (!string.IsNullOrEmpty(token)) HeaderData["Authorization"] = $"Bearer {token}";
        await base.OnInitializedAsync();
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

### Scheduler

The Scheduler uses `SfDataManager` to fetch events. This ensures only authorized users get protected data from the API.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Schedule
@using Syncfusion.Blazor.Data
@inject IConfiguration Configuration

<AuthorizeView>
    <Authorized>
        <SfSchedule TValue="AppointmentData" Height="550px" SelectedDate="@currentDate">
            <ScheduleEventSettings TValue="AppointmentData">
                <!-- Replace with your actual protected API endpoint -->
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
    DateTime currentDate = DateTime.Today;
    private Dictionary<string, string> HeaderData { get; } = new Dictionary<string, string>();
   
    protected override async Task OnInitializedAsync()
    {
        var token = Configuration["ExternalApi:BearerToken"];
        if (!string.IsNullOrEmpty(token)) HeaderData["Authorization"] = $"Bearer {token}";
        await base.OnInitializedAsync();
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

### TreeView

The following TreeView example demonstrates a Blazor Server app configured with authentication, ensuring that the entire TreeView component is only accessible to authenticated users.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Navigations

<AuthorizeView>
    <Authorized Context="context">
        <SfTreeView TValue="MailItem">
            <TreeViewFieldsSettings TValue="MailItem" Id="Id" DataSource="@MyFolder" Text="FolderName" ParentID="ParentId" HasChildren="HasSubFolders" Expanded="Expanded">
            </TreeViewFieldsSettings>
        </SfTreeView>
        <p>Welcome, @context.User.Identity?.Name!</p>
        <form method="post" action="Identity/Account/LogOut">
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

    List<MailItem> MyFolder = new List<MailItem>();

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

**Expected behavior**
* Syncfusion components should render **only for authorized users**.
* If the user is not authenticated, the application should display **Register or Login** options instead of the Syncfusion components.
* After a successful login, the user should be able to view the Syncfusion components such as **DataGrid, Scheduler, and TreeView** while navigating across different pages.

**Output:**
![Blazor Authentication And Authorization](./authentication-authorization.webp)

## See also

* [Blazor Server app with authentication](https://learn.microsoft.com/en-us/aspnet/core/blazor/security/?view=aspnetcore-10.0&tabs=visual-studio) 
* [AuthenticationStateProvider](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.components.authorization.authenticationstateprovider) 

