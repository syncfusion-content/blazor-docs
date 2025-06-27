---
layout: post
title: Filtering in Blazor Spreadsheet Component | Syncfusion
description: Learn all about the comprehensive filter feature in Syncfusion Blazor Spreadsheet Component including cell value filtering and more
platform: Blazor
control: Spreadsheet
documentation: ug
---

# Filter in Blazor Spreadsheet Component

The Blazor Spreadsheet component supports filtering capability to display only relevant rows based on specified criteria, facilitating data analysis. The [`AllowFiltering`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Spreadsheet.SfSpreadsheet.html#Syncfusion_Blazor_Spreadsheet_SfSpreadsheet_AllowFiltering) property can be used to enable or disable the filtering.

> The default value for the `AllowFiltering` property is **true**.

By default, the filtering capability is available in the Spreadsheet component, enabling users to apply, remove, and customize filters directly from the UI.

## Accessing Filter Options Through UI

The Blazor Spreadsheet provides a simple and intuitive interface to apply filters to data ranges:

- **Ribbon Toolbar**: Select the `Sort & Filter` icon from the **Home** tab to enable filtering on the selected range or sheet.

![UI showing ribbon filter option](./images/ribbon-filter.png)

- **Context Menu**: Right-click a cell and choose the Filter options from the context menu.

![UI showing contextmenu filter option](./images/contextmenu-filter.png)


- **Programmatic Filtering**: The [`FilterByCellValueAsync()`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Spreadsheet.SfSpreadsheet.html#Syncfusion_Blazor_Spreadsheet_SfSpreadsheet_FilterByCellValueAsync_System_Object_System_String_) method enables filtering data based on specific criteria by accepting a filter value and cell range as parameters. This allows filtering operations to be triggered directly through code, providing an alternative to the built-in user interface controls.

Once filtering is enabled, filter icons appear in each column header of the selected range. When clicked, these icons display a dialog that presents filtering options organized by unique values and conditional criteria, allowing for precise data filtering.

## Filter Context Menu Options

The Blazor Spreadsheet component provides the following filtering options through the context menu for efficient data management:

- **Filter By Value of Selected Cell**: Quickly filters to show only rows with values matching the selected cell
- **Clear Filter From "[Column Name]"**: Removes filtering from the specified column
- **Reapply**: Updates filtered results to match current data values while preserving the existing filter criteria

## Filter by Cell value

Filtering by cell value in the Blazor Spreadsheet component provides a quick way to isolate and display only specific data that matches a selected value. 

To filter rows by a specific cell's value:

- Right-click the target cell
- Select `Filter By Value of Selected Cell` from the context menu.
- The Spreadsheet automatically applies filtering to display only rows containing the selected value in the corresponding column

![UI showing contextmenu filter by cell value option](./images/filterbycellvalue-filter.png)

## Clearing Filters

The clearing filters functionality in the Blazor Spreadsheet component restores the complete dataset view after applying filters. This capability ensures seamless transitions between filtered and unfiltered data views without losing any information.

Filters applied to columns can be cleared in the following ways:

- Click the `Sort & Filter` icon from the **Home** tab in the ribbon toolbar
- Select the Clear option to remove all active filters simultaneously


![UI showing ribbon clear filter option](./images/clearfilter-option-ribbon.png)

## Reapply Filters

The reapply filters functionality in the Blazor Spreadsheet component provides an essential mechanism for maintaining accurate filtered views when working with dynamic data. 

After data modifications:

- Click `Reapply` button under the `Sort & Filter` icon from the **Home** tab in the ribbon toolbar
- Right-click on a filtered cell and select the `Reapply` option from the context menu.


![UI showing ribbon reapply option](./images/reapplyfilter-option-ribbon.png)

## Implement Filtering Programmatically

The Blazor Spreadsheet component supports programmatic filtering using the [`FilterByCellValueAsync()`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Spreadsheet.SfSpreadsheet.html#Syncfusion_Blazor_Spreadsheet_SfSpreadsheet_FilterByCellValueAsync_System_Object_System_String_) method. This method applies filtering based on the predicate and range specified in the arguments.

The following code example shows filter functionality in the Spreadsheet component:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Spreadsheet

<button @onclick="ApplyFilter">Filter by Value</button>
<SfSpreadsheet @ref="spreadsheetObj" DataSource="DataSourceBytes">
    <SpreadsheetRibbon></SpreadsheetRibbon>
</SfSpreadsheet>

@code {
    public byte[] DataSourceBytes { get; set; }
    SfSpreadsheet spreadsheetObj;

    protected override void OnInitialized()
    {
        string filePath = "wwwroot/Sample.xlsx";
        DataSourceBytes = File.ReadAllBytes(filePath);
    }

     public async Task ApplyFilter()
    {
        await spreadsheetObj.FilterByCellValueAsync("New York", "A1"); // Filter column A for "New York"
    }
}

{% endhighlight %}
{% endtabs %}


