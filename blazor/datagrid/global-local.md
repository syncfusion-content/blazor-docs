---
layout: post
title: Globalization in Blazor DataGrid | Syncfusion
description: Learn all about globalization and right-to-left text support in the Syncfusion Blazor DataGrid component.
platform: Blazor
control: DataGrid
documentation: ug
---

# Globalization in Blazor DataGrid

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid supports globalization to make applications accessible across regions and languages. Content can be displayed in the preferred culture with localized texts and culture-aware formats for a better user experience.

## Localization

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid supports localization, allowing customization of static texts used in the Grid for different languages or cultures. Text labels such as `group drop area text` and `pager information` can be localized to cultures like Arabic, Deutsch, French, and more. For detailed instructions, refer to the Blazor Localization documentation: [Localization](https://blazor.syncfusion.com/documentation/common/localization).

A subset of localizable strings used by the DataGrid is listed below.

**Data Rendering**

Locale key words |Text | Example 
-----|-----|-----
Grid_EmptyRecord | No records to display | ![Locale empty record](images/globalization/locale-empty-record.png)
Grid_EmptyDataSourceError | DataSource must not be empty at initial load since columns are generated from dataSource in AutoGenerate Column Grid

**Columns**

Locale key words |Text | Example 
-----|-----|-----
Grid_True | true | ![Locale true](images/globalization/locale-true.png)
Grid_False | false | ![Locale false](images/globalization/locale-false.png)

**ColumnChooser**

Locale key words |Text | Example 
-----|-----|-----
Grid_Columnchooser | Columns | ![Locale column chooser](images/globalization/locale-column-chooser.png)
Grid_ChooseColumns | Choose Column | ![Locale choose columns](images/globalization/locale-choose-columns.png)

**Editing**

Locale key words |Text | Example 
-----|-----|-----
Grid_Add | Add | ![Locale add](images/globalization/locale-add.png)
Grid_Edit| Edit | ![Locale edit](images/globalization/locale-edit.png)
Grid_Cancel| Cancel | ![Locale cancel](images/globalization/locale-cancel.png)
Grid_Update| Update | ![Locale update](images/globalization/locale-update.png)
Grid_Delete | Delete | ![Locale delete](images/globalization/locale-delete.png)
Grid_Save | Save | ![Locale save](images/globalization/locale-save.png)
Grid_EditOperationAlert | No records selected for edit operation | ![Locale edit operation alert](images/globalization/locale-edit-operation-alert.png)
Grid_DeleteOperationAlert | No records selected for delete operation | ![Locale delete operation alert](images/globalization/locale-delete-operation-alert.png)
Grid_SaveButton | Save | ![Locale save button](images/globalization/locale-save-button.png)
Grid_OKButton | OK | ![Locale ok button](images/globalization/locale-ok-button.png)
Grid_CancelButton | Cancel | ![Locale cancel button](images/globalization/locale-cancel-button.png)
Grid_EditFormTitle | Details of | ![Locale edit form title](images/globalization/locale-edit-form-title.png)
Grid_AddFormTitle | Add New Record | ![Locale add form title](images/globalization/locale-add-form-title.png)
Grid_BatchSaveConfirm | Are you sure you want to save changes? | ![Locale batch save confirm](images/globalization/locale-batch-save-confirm.png)
Grid_BatchSaveLostChanges | Unsaved changes will be lost. Are you sure you want to continue? | ![Locale batch save lost changes](images/globalization/locale-batch-save-lost-changes.png)
Grid_ConfirmDelete | Are you sure you want to Delete Record? | ![Locale confirm delete](images/globalization/locale-confirm-delete.png)
Grid_CancelEdit | Are you sure you want to Cancel the changes? | ![Locale cancel edit](images/globalization/locale-cancel-edit.png)

**Grouping**

Locale key words |Text | Example 
-----|-----|-----
Grid_GroupDropArea | Drag a column header here to group its column | ![Locale group drop area](images/globalization/locale-group-drop-area.png)
Grid_UnGroup | Click here to ungroup | ![Locale ungroup](images/globalization/locale-un-group.png)
Grid_GroupDisable | Grouping is disabled for this column | ![Locale group disabled](images/globalization/locale-group-disable.png)
Grid_Item | item | ![Locale item](images/globalization/locale-item.png)
Grid_Items | items | ![Locale items](images/globalization/locale-items.png)
Grid_UnGroupButton | Click here to ungroup |
Grid_GroupDescription | Press Ctrl space to group | ![Locale group description](images/globalization/locale-group-description.png)

**Filtering**

Locale key words |Text | Example 
-----|-----|-----
Grid_InvalidFilterMessage | Invalid Filter Data
Grid_FilterbarTitle | \s filter bar cell | ![Locale filter bar title](images/globalization/locale-filterbar-title.png)
Grid_Matchs | No Matches Found | ![Locale no matches](images/globalization/locale-matchs.png)
Grid_FilterButton | Filter | ![Locale filter button](images/globalization/locale-filter-button.png)
Grid_ClearButton | Clear | ![Locale clear button](images/globalization/locale-clear-button.png)
Grid_StartsWith | Starts With | ![Locale starts with](images/globalization/locale-starts-with.png)
Grid_EndsWith | Ends With | ![Locale ends with](images/globalization/locale-ends-with.png)
Grid_Contains | Contains | ![Locale contains](images/globalization/locale-contains.png)
Grid_Equal | Equal | ![Locale equal](images/globalization/locale-equal.png)
Grid_NotEqual | Not Equal | ![Locale not equal](images/globalization/locale-not-equal.png)
Grid_LessThan | Less Than | ![Locale less than](images/globalization/locale-less-than.png)
Grid_LessThanOrEqual | Less Than Or Equal | ![Locale less than or equal](images/globalization/locale-less-than-or-equal.png)
Grid_GreaterThan | Greater Than | ![Locale greater than](images/globalization/locale-greater-than.png)
Grid_GreaterThanOrEqual | Greater Than Or Equal | ![Locale greater than or equal](images/globalization/locale-greater-than-or-equal.png)
Grid_ChooseDate | Choose a Date | ![Locale choose date](images/globalization/locale-choose-date.png)
Grid_EnterValue | Enter the value | ![Locale enter value](images/globalization/locale-enter-value.png)
Grid_SelectAll | Select All | ![Locale select all](images/globalization/locale-select-all.png)
Grid_Blanks | Blanks | ![Locale blanks](images/globalization/locale-blanks.png)
Grid_FilterTrue | True | ![Locale filter true](images/globalization/locale-filter-true.png)
Grid_FilterFalse | False | ![Locale filter false](images/globalization/locale-filter-false.png)
Grid_NoResult | No Matches Found | ![Locale no result](images/globalization/locale-no-result.png)
Grid_ClearFilter | Clear Filter | ![Locale clear filter](images/globalization/locale-clear-filter.png)
Grid_NumberFilter | Number Filters | ![Locale number filter](images/globalization/locale-number-filter.png)
Grid_TextFilter | Text Filters | ![Locale text filter](images/globalization/locale-text-filter.png)
Grid_DateFilter | Date Filters | ![Locale date filter](images/globalization/locale-date-filter.png)
Grid_DateTimeFilter | DateTime Filters | ![Locale date time filter](images/globalization/locale-date-time-filter.png)
Grid_MatchCase | Match Case | ![Locale match case](images/globalization/locale-match-case.png)
Grid_Between | Between | ![Locale between](images/globalization/locale-between.png)
Grid_CustomFilter | Custom Filter | ![Locale custom filter](images/globalization/locale-custom-filter.png)
Grid_CustomFilterPlaceHolder | Enter the value | ![Locale custom filter placeholder](images/globalization/locale-custom-filter-placeholder.png)
Grid_CustomFilterDatePlaceHolder | Choose a date | ![Locale custom filter date placeholder](images/globalization/locale-custom-filter-date-placeholder.png)
Grid_AND | AND | ![Locale and](images/globalization/locale-AND.png)
Grid_OR | OR | ![Locale or](images/globalization/locale-OR.png)
Grid_ShowRowsWhere | Show rows where: | ![Locale show rows where](images/globalization/locale-show-rows-where.png)

**Searching**

Locale key words |Text | Example 
-----|-----|-----
Grid_Search | Search | ![Locale search](images/globalization/locale-search.png)
Grid_SearchColumns | search columns

**Toolbar**

Locale key words |Text | Example 
-----|-----|-----
Grid_Print | Print | ![Locale print](images/globalization/locale-print.png)
Grid_Pdfexport | PDF Export | ![Locale pdf export](images/globalization/locale-pdfexport.png)
Grid_Excelexport | Excel Export | ![Locale excel export](images/globalization/locale-excelexport.png)
Grid_Csvexport | CSV Export | ![Locale csv export](images/globalization/locale-csvexport.png)

**ColumnMenu**

Locale key words |Text | Example 
-----|-----|-----
Grid_FilterMenu | Filter | ![Locale filter menu](images/globalization/locale-filter-menu.png)
Grid_AutoFitAll | Autofit all columns |
Grid_AutoFit | Autofit this column |

**ContextMenu**

Locale key words |Text | Example 
-----|-----|-----
Grid_Copy | Copy | ![Locale copy](images/globalization/locale-copy.png)
Grid_Group | Group by this column | ![Locale group by column](images/globalization/locale-group.png)
Grid_Ungroup | Ungroup by this column | ![Locale ungroup by column](images/globalization/locale-ungroup.png)
Grid_autoFitAll | Auto Fit all columns | ![Locale autofit all columns](images/globalization/locale-autofit-all.png)
Grid_autoFit | Auto Fit this column | ![Locale autofit column](images/globalization/locale-autofit.png)
Grid_Export | Export | ![Locale export](images/globalization/locale-export.png)
Grid_FirstPage | First Page | ![Locale first page](images/globalization/locale-first-page.png)
Grid_LastPage | Last Page | ![Locale last page](images/globalization/locale-last-page.png)
Grid_PreviousPage | Previous Page | ![Locale previous page](images/globalization/locale-previous-page.png)
Grid_NextPage | Next Page | ![Locale next page](images/globalization/locale-next-page.png)
Grid_SortAscending | Sort Ascending | ![Locale sort ascending](images/globalization/locale-sort-ascending.png)
Grid_SortDescending | Sort Descending | ![Locale sort descending](images/globalization/locale-sort-descending.png)
Grid_EditRecord | Edit Record | ![Locale edit record](images/globalization/locale-edit-record.png)
Grid_DeleteRecord | Delete Record | ![Locale delete record](images/globalization/locale-delete-record.png)

### Switch the different localization

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid allows switching the localization from one culture to another at runtime. This is useful when the culture needs to be changed based on user preference or application context. For more details, see [Dynamically set the culture](https://blazor.syncfusion.com/documentation/common/localization#dynamically-set-the-culture).

To switch to a different localization, follow these steps:

**Step 1: Create a Blazor web app**
 
Create a `Blazor Web App` named LocalizationSample using Visual Studio 2022, either via [Microsoft Templates](https://learn.microsoft.com/aspnet/core/blazor/tooling) or the [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-integration/template-studio). Configure the appropriate [interactive render mode](https://learn.microsoft.com/aspnet/core/blazor/components/render-modes#render-modes) and [interactivity location](https://learn.microsoft.com/aspnet/core/blazor/tooling?pivots=windows).

**Step 2: Install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid and Themes NuGet packages**
 
To add the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid, open NuGet Package Manager (*Tools → NuGet Package Manager → Manage NuGet Packages for Solution*), then install [Syncfusion.Blazor.Grid](https://www.nuget.org/packages/Syncfusion.Blazor.Grid/) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/).
 
If the Blazor Web App uses WebAssembly or Auto render modes, install the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor NuGet packages in the client project.
 
Alternatively, use the following Package Manager commands:
 
```powershell
Install-Package Syncfusion.Blazor.Grid -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.Themes -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.Buttons -Version {{ site.releaseversion }}
```
 
> Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components are available on [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). Refer to the [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for a complete list of available packages.
 
**Step 3: Register Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor service**
 
- Open the **~/_Imports.razor** file and import the required namespaces.
 
```cs
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons
```
  
**Step 4: Add stylesheet and script resources**
 
Include the theme stylesheet and script references in the **~/Components/App.razor** file for a Blazor Web App.
 
```html
<head>
    ....
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
</head>
....
<body>
    ....
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
</body>
```
 
> * Refer to the [Blazor Themes](https://blazor.syncfusion.com/documentation/appearance/themes) topic for various methods to include themes (Static Web Assets, CDN, or CRG).
> * Set the rendermode to `InteractiveServer` or `InteractiveAuto` in the Blazor Web App configuration.

**Step 5: Create and register localization service**

Create a **SyncfusionLocalizer.cs** file and add the following code. For detailed steps on creating and registering a localization service, refer to the [Localization](https://blazor.syncfusion.com/documentation/common/localization#create-and-register-localization-service) documentation.

{% tabs %}
{% highlight cs tabtitle="SyncfusionLocalizer.cs" %}

using Syncfusion.Blazor;

namespace LocalizationSample.Client
{
    public class SyncfusionLocalizer : ISyncfusionStringLocalizer
    {
        // To get the locale key from mapped resources file
        public string GetText(string key)
        {
            return this.ResourceManager.GetString(key);
        }

        // To access the resource file and get the exact value for locale key

        public System.Resources.ResourceManager ResourceManager
        {
            get
            {
                // Replace the ApplicationNamespace with your application name.
                return LocalizationSample.Client.Resources.SfResources.ResourceManager;
            }
        }
    }
}

{% endhighlight %}
{% endtabs %}

**Step 6: Configure ~/Program.cs file**

- **Set the culture of the application:** In the client-side **~/Program.cs**, use JavaScript interop to retrieve the user's culture from local storage. If none is found, set the default to en-US.
- **Register services:** Register the SyncfusionLocalizer and Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor services in **~/Program.cs**.

{% tabs %}
{% highlight cs tabtitle="Program.cs" %}

using LocalizationSample.Client;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;
using Syncfusion.Blazor;
using System.Globalization;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Register the Syncfusion Blazor services.
builder.Services.AddSyncfusionBlazor();

//Register the Syncfusion locale service to localize Syncfusion Blazor components.
builder.Services.AddSingleton(typeof(ISyncfusionStringLocalizer), typeof(SyncfusionLocalizer));
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("YOUR LICENSE KEY");
var host = builder.Build();

//Setting culture of the application.
var jsInterop = host.Services.GetRequiredService<IJSRuntime>();
var result = await jsInterop.InvokeAsync<string>("cultureInfo.get");
CultureInfo culture;
if (result != null)
{
    culture = new CultureInfo(result);
}
else
{
    culture = new CultureInfo("en-US");
    await jsInterop.InvokeVoidAsync("cultureInfo.set", "en-US");
}
CultureInfo.DefaultThreadCurrentCulture = culture;
CultureInfo.DefaultThreadCurrentUICulture = culture;
await builder.Build().RunAsync();

{% endhighlight %}
{% endtabs %}

**Step 7: In the project file, add the following code:**

```
<PropertyGroup>
    <BlazorWebAssemblyLoadAllGlobalizationData>true</BlazorWebAssemblyLoadAllGlobalizationData>
</PropertyGroup>

```
 
**Step 8: Add JavaScript function for culture management**

For a Blazor Web App, add the following JavaScript function to the **~/Components/App.razor** file (after the Blazor `<script>` tag and before the closing `</body>`). This function retrieves and sets the user's selected culture in the browser's local storage.

{% tabs %}
{% highlight cs tabtitle="~/Components/App.razor" %}

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <base href="/" />
    <link rel="stylesheet" href="bootstrap/bootstrap.min.css" />
    <link rel="stylesheet" href="app.css" />
    <link rel="stylesheet" href="LocalizationSample.styles.css" />
    <link rel="icon" type="image/png" href="favicon.png" />
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
    <HeadOutlet />
</head>
<body>
    <Routes />
    <script src="_framework/blazor.web.js"></script>
    <script>
        window.cultureInfo = {
            get: () => window.localStorage['BlazorCulture'],
            set: (value) => window.localStorage['BlazorCulture'] = value
        };
    </script>
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
</body>
</html>

{% endhighlight %}
{% endtabs %}

**Step 9: Configure culture switching with Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid** 

In the **Counter.razor** file, add the following code to change the culture and display a Grid with a button to switch between English (en-US) and French (fr-FR):
 
{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@page "/counter"
@rendermode InteractiveAuto
@using System.Globalization
@inject IJSRuntime JSRuntime
@inject NavigationManager NavigationManager
@using LocalizationSample.Client.Data

<div style="padding: 10px 10px">
    <SfButton CssClass="e-outline" @onclick='() => ChangeCulture("en-US")' Content="Change to English (en-US)"></SfButton>
    <SfButton CssClass="e-outline" style="margin-left: 5px;" @onclick='() => ChangeCulture("fr-FR")' Content="Change to French (fr-FR)"></SfButton>
</div>

<SfGrid DataSource="@Orders" AllowFiltering="true" AllowPaging="true" Height="315">
    <GridFilterSettings Type="Syncfusion.Blazor.Grids.FilterType.Menu"></GridFilterSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="130"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCountry) HeaderText="Ship Country" Width="130"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<OrderData> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
    }

    private async Task ChangeCulture(string culture)
    {
        await JSRuntime.InvokeVoidAsync("cultureInfo.set", culture);
        NavigationManager.NavigateTo(NavigationManager.Uri, forceLoad: true);
    }
}
 
{% endhighlight %}
{% endtabs %}


**Step 10: Create a model class**

Create a new folder named `Data`. Then add a model class named `OrderData.cs` in the `Data` folder to represent the order data.

{% tabs %}
{% highlight cs tabtitle="OrderData.cs" %}

namespace LocalizationSample.Client.Data
{
    public class OrderData
    {
        public OrderData(int orderID, string customerID, double freight, string shipCity, string shipCountry)
        {
            this.OrderID = orderID;
            this.CustomerID = customerID;
            this.Freight = freight;
            this.ShipCity = shipCity;
            this.ShipCountry = shipCountry;
        }
        public static List<OrderData> GetAllRecords()
        {
            return new List<OrderData>
            {
                new OrderData(10248, "VINET", 32.38, "Reims", "France"),
                new OrderData(10249, "TOMSP", 11.61, "Münster", "Germany"),
                new OrderData(10250, "HANAR", 65.83, "Rio de Janeiro", "Brazil"),
                new OrderData(10251, "VICTE", 41.34, "Lyon", "France"),
                new OrderData(10252, "SUPRD", 51.30, "Charleroi", "Belgium"),
                new OrderData(10253, "HANAR", 58.17, "Rio de Janeiro", "Brazil"),
                new OrderData(10254, "CHOPS", 22.98, "Bern", "Switzerland"),
                new OrderData(10255, "RICSU", 148.33, "Genève", "France"),
                new OrderData(10256, "WELLI", 13.97, "Resende", "Brazil"),
                new OrderData(10257, "HILAA", 81.91, "San Cristóbal", "Mexico"),
                new OrderData(10258, "ERNSH", 140.51, "Graz", "Austria"),
                new OrderData(10259, "CENTC", 3.25, "México D.F.", "Mexico"),
                new OrderData(10260, "OTTIK", 55.09, "Köln", "Germany"),
                new OrderData(10261, "QUEDE", 3.05, "Rio de Janeiro", "Brazil"),
                new OrderData(10262, "RATTC", 48.29, "Albuquerque", "USA")
            };
        }
        public int OrderID { get; set; }
        public string CustomerID { get; set; }
        public double Freight { get; set; }
        public string ShipCity { get; set; }
        public string ShipCountry { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

**Step 11: Run the application**
 
When the application runs, the Grid displays localized content and formats based on the current culture.

![Switch to a different localization](images/globalization/switch.png)

## Right to Left - RTL

The Right-to-left (RTL) feature switches the text direction and layout from left-to-right to right-to-left. This is beneficial for languages written and read right to left, such as `Arabic`, `Farsi`, and `Urdu`. Enabling RTL improves usability and accessibility for these languages.

To enable RTL in the Grid, set the [EnableRtl](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_EnableRtl) property. This switches text direction and layout to right-to-left.

To achieve this, follow the steps below:

**Step 1:** Follow the steps from Step 1 to Step 5 in the following [link](https://blazor.syncfusion.com/documentation/datagrid/global-local#switch-the-different-localization), then continue with the steps below: [Switch the different localization](https://blazor.syncfusion.com/documentation/datagrid/global-local#switch-the-different-localization)

**Step 2: Configure ~/Program.cs file**

Register the SyncfusionLocalizer and Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor services in both ~/Program.cs files.
 
{% tabs %}
{% highlight cs tabtitle="Program.cs" %}

using LocalizationSample.Client;
using Syncfusion.Blazor;

builder.Services.AddSyncfusionBlazor();
builder.Services.AddSingleton(typeof(ISyncfusionStringLocalizer), typeof(SyncfusionLocalizer));

{% endhighlight %}
{% endtabs %}

**Step 3: Setting the culture in Blazor start option**

- Add the `autostart="false"` attribute to the Blazor <script> tag to prevent Blazor from starting automatically.
- Add the script block below Blazor’s `<script>` tag and before the closing `</body>` tag to start Blazor with a specific culture.
- Use the `Blazor.start` method and set `applicationCulture` to the desired culture code.

{% tabs %}
{% highlight cs tabtitle="~/Components/App.razor" %}

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <base href="/" />
    <link rel="stylesheet" href="bootstrap/bootstrap.min.css" />
    <link rel="stylesheet" href="app.css" />
    <link rel="stylesheet" href="LocalizationSample.styles.css" />
    <link rel="icon" type="image/png" href="favicon.png" />
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
    <HeadOutlet />
</head>
<body>
    <Routes />
    <script src="_framework/blazor.web.js" autostart="false"></script>
    <script>
        Blazor.start({
            webAssembly: {
                applicationCulture: 'ar'
            }
        });
    </script>
</body>
</html>

{% endhighlight %}
{% endtabs %}

**Step 4: Enable or disable RTL mode using toggle Switch**

The [Toggle Switch Button](https://blazor.syncfusion.com/documentation/toggle-switch-button) is added to enable or disable the RTL feature for the Arabic (ar-AE) locale. When the switch is toggled, the [ValueChange](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfSwitch-1.html#Syncfusion_Blazor_Buttons_SfSwitch_1_ValueChange) event is triggered, and the [EnableRtl](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_EnableRtl) property of the Grid is updated accordingly.

{% tabs %}
{% highlight razor tabtitle="Counter.razor" %}

@page "/counter"
@rendermode InteractiveAuto

@using LocalizationSample.Client.Models

<div style="display: flex; align-items: center; gap: 10px; padding: 10px;">
    <label style="margin: 0;">Enable or Disable RTL Mode</label>
    <SfSwitch ValueChange="Change" TChecked="bool"></SfSwitch>
</div>


<SfGrid @ref="Grid" DataSource="@Orders" AllowSorting="true" AllowGrouping="true" AllowFiltering="true" ShowColumnMenu="true" ShowColumnChooser="true" AllowPaging="true" Height="315" EnableRtl="@isRTLEnabled" Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Update", "Cancel" })">
    <GridFilterSettings Type="Syncfusion.Blazor.Grids.FilterType.Menu"></GridFilterSettings>
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true" Mode="EditMode.Normal"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="130"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCountry) HeaderText="Ship Country" Width="130"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    private SfGrid<OrderData> Grid;

    public List<OrderData> Orders { get; set; }
    public bool isRTLEnabled { get; set; } = false;

    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
    }

    private void Change(Syncfusion.Blazor.Buttons.ChangeEventArgs<bool> args)
    {
        isRTLEnabled = args.Checked;
        Grid.Refresh();
    }
}
 
{% endhighlight %}
{% endtabs %}

**Step 5: Create a model class**

Create a new folder named **Models**. Then add a model class named `OrderData.cs` in the `Models` folder to represent the order data.

{% tabs %}
{% highlight cs tabtitle="OrderData.cs" %}

namespace LocalizationSample.Client.Models
{
    public class OrderData
    {
        public OrderData(int orderID, string customerID, double freight, string shipCity, string shipCountry)
        {
            this.OrderID = orderID;
            this.CustomerID = customerID;
            this.Freight = freight;
            this.ShipCity = shipCity;
            this.ShipCountry = shipCountry;
        }
        public static List<OrderData> GetAllRecords()
        {
            return new List<OrderData>
            {
                new OrderData(10248, "VINET", 32.38, "Reims", "France"),
                new OrderData(10249, "TOMSP", 11.61, "Münster", "Germany"),
                new OrderData(10250, "HANAR", 65.83, "Rio de Janeiro", "Brazil"),
                new OrderData(10251, "VICTE", 41.34, "Lyon", "France"),
                new OrderData(10252, "SUPRD", 51.30, "Charleroi", "Belgium"),
                new OrderData(10253, "HANAR", 58.17, "Rio de Janeiro", "Brazil"),
                new OrderData(10254, "CHOPS", 22.98, "Bern", "Switzerland"),
                new OrderData(10255, "RICSU", 148.33, "Genève", "France"),
                new OrderData(10256, "WELLI", 13.97, "Resende", "Brazil"),
                new OrderData(10257, "HILAA", 81.91, "San Cristóbal", "Mexico"),
                new OrderData(10258, "ERNSH", 140.51, "Graz", "Austria"),
                new OrderData(10259, "CENTC", 3.25, "México D.F.", "Mexico"),
                new OrderData(10260, "OTTIK", 55.09, "Köln", "Germany"),
                new OrderData(10261, "QUEDE", 3.05, "Rio de Janeiro", "Brazil"),
                new OrderData(10262, "RATTC", 48.29, "Albuquerque", "USA")
            };
        }
        public int OrderID { get; set; }
        public string CustomerID { get; set; }
        public double Freight { get; set; }
        public string ShipCity { get; set; }
        public string ShipCountry { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

**Step 6: Run the application**
 
When the application runs, the Grid reflects RTL layout and text direction according to the selected culture.

![Right to left layout enabled](images/globalization/enable-rtl.png)