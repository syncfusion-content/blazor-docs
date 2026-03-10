---
title: Authentication and Authorization in Syncfusion Blazor Components
description: Learn how to secure Syncfusion Blazor components using authentication and authorization in Blazor Server and WebAssembly applications.
platform: blazor
component: common
documentation: ug
---

# Authentication and Authorization in Syncfusion Blazor Components

Authentication verifies the identity of a user, while authorization determines the level of access and actions the user can perform. Syncfusion Blazor components support both UI-level and data-level security, allowing you to control what users see and which operations they can perform. This guide explains how to secure Syncfusion Blazor components using authentication and authorization. It demonstrates UI-level and data-level security with examples from the DataGrid, Scheduler, and TreeView components.

## Authentication

Authentication establishes who the user is within your Blazor application. Blazor typically uses cookie based authentication for Server apps and token-based systems or BFF(Backend-for-Frontend) patterns for WebAssembly. Syncfusion components consume user identity information through Blazor's `AuthenticationStateProvider` to securely load or restrict data.

## Authorization

Authorization determines which Syncfusion components or features a user is allowed to access after successful authentication. Blazor enables authorization through role checks, policies, and UI filtering with <AuthorizeView>. Syncfusion components use these values to enable or disable features, hide UI, or protect API-driven data access.

## Key Differences Between Authentication and Authorization

The following table summarizes the functional and behavioral differences between authentication and authorization in a Blazor and Syncfusion context:

| Aspect               | Authentication                           | Authorization                                  |
|----------------------|-------------------------------------------|------------------------------------------------|
| **Purpose**          | Verify the user identity            | Grant/deny access to resources / features                |
| **Timing**           | Happens first                             | Happens after authentication                   |
| **Blazor Tools**     | `AuthenticationStateProvider`             | `<AuthorizeView>`, `[Authorize]`               |
| **Syncfusion Integration** | Add Bearer token to `SfDataManager.Headers` for remote data | Show/hide components and toggle features per role/policy     |

## Applying Authentication and Authorization to Syncfusion Components

Syncfusion components can be secured at two layers:

* **UI-Level Authorization**: Use `<AuthorizeView>` to conditionally render components based on user roles.
* **Data-Level Authentication**: Pass Bearer tokens to `SfDataManager` when requesting protected API data.

Combine both layers for complete protection. 

N> This authentication and authorization pattern applies to all Syncfusion components (Grid, Charts, Scheduler, TreeView, etc.). The examples shown can be adapted to any Syncfusion component by using the same `<AuthorizeView>` and `SfDataManager` pattern.

## Using Syncfusion Components

All examples use `<AuthorizeView>` for UI-level security and `SfDataManager` with Bearer tokens for data-level authentication. 

**Prerequisites**: For setting up a Blazor Server or WebAssembly app with ASP.NET Core Identity, refer to [Blazor Server App with Authentication](https://www.syncfusion.com/blogs/post/easy-steps-create-a-blazor-server-app-with-authentication). This guide assumes Identity is already configured in your project.

### DataGrid

The DataGrid can be secured by limiting visibility to authenticated users and enabling editing only for users with elevated roles. Tokens included in the SfDataManager headers allow the grid to securely load data from protected APIs. This ensures both UI behavior and data access align with authorization requirements.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Data
@inject HttpClient HttpClient
@inject IJSRuntime JS
 
<h3> DataGrid</h3>

<AuthorizeView>
    <Authorized Context="authContext">
      
            <SfGrid TValue="Order" AllowPaging="true">
            <GridPageSettings PageSize="10"></GridPageSettings>
            <SfDataManager Headers="@HeaderData" Url="/api/proxy/Orders" Adaptor="Adaptors.WebApiAdaptor"></SfDataManager>
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
    
    // Use an empty header collection — proxy will add token if configured on the server.
    private Dictionary<string, string> HeaderData { get; } = new Dictionary<string, string>();

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

The Scheduler component supports secure viewing and editing based on user roles, allowing you to restrict modification permissions while still displaying the schedule to authenticated users. It retrieves data through SfDataManager, ensuring that only authorized users receive protected event information. This approach combines UI control and backend security to safeguard sensitive scheduling data.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Schedule
@using Syncfusion.Blazor.Data
@using System.Net.Http.Headers


<AuthorizeView>
    <Authorized>
        <SfSchedule TValue="AppointmentData" Height="550px" SelectedDate="@currentDate" Readonly="true">
            <ScheduleEventSettings TValue="AppointmentData" DataSource="@appointments">
                <ScheduleViews>
                    <ScheduleView Option="View.Month"></ScheduleView>
                </ScheduleViews>
            </ScheduleEventSettings>
        </SfSchedule>
    </Authorized>
    <NotAuthorized>
        <p>Authentication required to view schedule.</p>
        <a href="Identity/Account/Login">Log in</a>
    </NotAuthorized>
</AuthorizeView>

@code {
    DateTime currentDate = DateTime.Today;
   // Use a local list and fetch from the proxy in OnInitializedAsync.
   private Dictionary<string, string> HeaderData { get; } = new Dictionary<string, string>();
   private List<AppointmentData> appointments = new();

    protected override async Task OnInitializedAsync()
    {
        try
        {
            // Our proxy returns the schedule array (or extracts it), so fetch and bind directly.
            var result = await Http.GetFromJsonAsync<List<AppointmentData>>("http://localhost:5287/api/proxy/Schedule");
            if (result != null) appointments = result;
        }
        catch (Exception ex)
        {
            // Log to server console for now
            Console.WriteLine($"Failed loading schedule: {ex.Message}");
        }
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

The TreeView component supports secure rendering by only displaying the hierarchical view to authenticated users. Drag-and-drop or editing features can be restricted based on user roles, allowing greater control over modification of hierarchical data. This ensures sensitive structures are accessible only to users with appropriate permissions.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Navigations
@inject AuthenticationStateProvider AuthenticationStateProvider

<AuthorizeView>
    <Authorized>
        <SfTreeView TValue="MailItem" AllowDragAndDrop="@canEdit">
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
    private bool canEdit = false;
    
    public class MailItem
    {
        public string? Id { get; set; }
        public string? ParentId { get; set; }
        public string? FolderName { get; set; }
        public bool Expanded { get; set; }
        public bool HasSubFolders { get; set; }
    }

    List<MailItem> MyFolder = new();

    protected override async Task OnInitializedAsync()
    {
        // Retrieve current user's authentication state
        var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
        var user = authState.User;
        
        // Check if user has permission to edit (drag/drop enabled only for Editors)
        canEdit = user.IsInRole("Editor");
        
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

## See Also

* [Blazor Server App with Authentication](https://www.syncfusion.com/blogs/post/easy-steps-create-a-blazor-server-app-with-authentication) 
* [AuthenticationStateProvider](https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.components.authorization.authenticationstateprovider) 

