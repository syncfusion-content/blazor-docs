---
title: Authentication and Authorization in Syncfusion Blazor Components
description: Learn how to secure Syncfusion Blazor components with authentication and authorization in Blazor Server and WebAssembly applications.
platform: blazor
component: common
documentation: ug
---

# Authentication and Authorization in Syncfusion Blazor Components

This guide shows how to secure Syncfusion Blazor components with authentication and authorization. It covers UI-level security (to control what users see and interact with) and data-level security (to protect backend data access), with examples using the DataGrid and Scheduler for both, and the TreeView for UI-level only.

Authentication verifies a user's identity. Authorization then determines the access levels and actions the user can perform. Syncfusion Blazor components integrate with Blazor's built-in authentication and authorization features to enable both UI-level and data-level security.

## Authentication

Authentication establishes who the user is within your Blazor application. Blazor apps often use cookie-based authentication where a server stores user session information in browser cookies for Server-hosted apps. For WebAssembly apps, use token-based systems like JSON Web Tokens (JWTs). Another option is the Backend-for-Frontend (BFF) pattern, where a server manages authentication on behalf of the client. This pattern keeps sensitive logic server-side, reducing client exposure.

Syncfusion components access user identity information through Blazor's `AuthenticationStateProvider`. This allows secure data loading or feature restriction based on the user's identity.

## Authorization

Authorization determines which Syncfusion components or features a user is allowed to access after successful Authentication. Blazor supports authorization via:

* **Role checks:** Verify user group membership (e.g., 'Admin').
* **Policies:** Custom rules, such as requiring multiple roles or claims (key-value attributes in the user's identity, like 'department=Engineering').
* **UI filtering:** Use the `<AuthorizeView>` component to show or hide content.

## Key Differences Between Authentication and Authorization

The following table summarizes the functional and behavioral differences between Authentication and Authorization in a Blazor and Syncfusion context:

| Aspect | Authentication | Authorization |
|---|---|---|
| **Purpose** | Verifies user identity. | Grants or denies access to resources and features. |
| **Timing**  | Happens first | Happens after Authentication |
| **Blazor Tools** | `AuthenticationStateProvider` | `<AuthorizeView>`, `[Authorize]` |
| **Syncfusion Integration** | Access user identity via `AuthenticationStateProvider` for data loading. | Use `<AuthorizeView>` to show/hide components. Add tokens to `SfDataManager.Headers` for API calls. |

## Applying Authentication and Authorization to Syncfusion Components

Syncfusion components can be secured at two layers:

* **UI-Level Authorization**: Use `<AuthorizeView>` to conditionally render components based on user roles.
* **Data-Level Authentication**: Use authentication tokens (Bearer tokens) in `SfDataManager` to enforce access to protected API data.

For full security, combine UI-level and data-level approaches. The following examples demonstrate this with Syncfusion components.

N> This `<AuthorizeView>` and `SfDataManager` pattern applies to most data-bound Syncfusion components, such as Grid, Charts, Scheduler, and TreeView. For non-data-bound ones (e.g., Button), use only `<AuthorizeView>`.

## Using Syncfusion Components

All examples use `<AuthorizeView>` for UI-level security. DataGrid and Scheduler also include `SfDataManager` with Bearer tokens for data-level Authentication. TreeView uses local data.

### Prerequisite

Components such as `AuthorizeView`, `AuthenticationStateProvider`, and token-based data requests require the Blazor authentication pipeline to be configured.

**Install Required Package:**

In your project directory, run **dotnet add package Microsoft.AspNetCore.Identity.UI** to enable Identity services.

**1. Wrap the application's router in App.razor:**

{% tabs %}
{% highlight razor %}
<CascadingAuthenticationState>
    <Router AppAssembly="@typeof(App).Assembly" />
</CascadingAuthenticationState>

{% endhighlight %}
{% endtabs %}

**2. Inject the authentication provider where needed (eg., in a .razor file):**

{% tabs %}
{% highlight razor %}

@inject AuthenticationStateProvider AuthStateProvider

{% endhighlight %}
{% endtabs %}

**3. Register authentication services in Program.cs:**

{% tabs %}
{% highlight cs %}

using Microsoft.AspNetCore.Identity.UI;

...
builder.Services.AddAuthentication(IdentityConstants.ApplicationScheme)
    .AddCookie(IdentityConstants.ApplicationScheme);

builder.Services.AddAuthorization();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();

{% endhighlight %}
{% endtabs %}

### DataGrid

The DataGrid can be secured by limiting visibility to authenticated users and enabling editing only for users with elevated roles. Include tokens in the `SfDataManager.Headers` property. This lets the grid load data securely from protected APIs. It aligns UI behavior (via `<AuthorizeView>`) with data access rules.

N> For testing, add a Bearer token to `appsettings.json` under the section `ExternalApi:BearerToken`. Never commit tokens to source control. For production, Retrieve dynamic tokens from `AuthenticationStateProvider`.

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
            <SfDataManager Url="https://blazor.syncfusion.com/services/production/api/Orders/" Adaptor="Adaptors.WebApiAdaptor" Headers="@HeaderData"></SfDataManager>
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
                <SfDataManager Url="https://blazor.syncfusion.com/services/production/api/schedule" Headers="@HeaderData" Adaptor="Adaptors.WebApiAdaptor"></SfDataManager>
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

The following TreeView example demonstrates a Blazor Server App configured with authentication, ensuring that the entire TreeView component is only accessible to authenticated users.

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

## See Also

* [Blazor Server App with Authentication](https://learn.microsoft.com/en-us/aspnet/core/blazor/security/?view=aspnetcore-10.0&tabs=visual-studio) 
* [AuthenticationStateProvider](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.components.authorization.authenticationstateprovider?view=aspnetcore-10.0) 

