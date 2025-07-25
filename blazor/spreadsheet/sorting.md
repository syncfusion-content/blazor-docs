---
layout: post
title: Sorting in Blazor Spreadsheet Component | Syncfusion.
description: Checkout and learn here about sorting functionality in Syncfusion Blazor Spreadsheet component and much more.
platform: Blazor
component: Spreadsheet
documentation: ug
---

# Sorting in Blazor Spreadsheet component

The Blazor Spreadsheet supports sorting functionality that allows data within a worksheet to be organized either in ascending or descending order. This feature is particularly useful for enhancing data readability and facilitating analysis by arranging values based on selected columns.

To control the sorting functionality, the [AllowSorting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Spreadsheet.SfSpreadsheet.html#Syncfusion_Blazor_Spreadsheet_SfSpreadsheet_AllowSorting) property can be used to enable or disable sorting operations in the Spreadsheet. The default value of the `AllowSorting` property is **true**.

N> When `AllowSorting` is set to **false**, sorting options are removed from the interface (Ribbon and Context Menu), and API methods related to this feature will not work. If the worksheet is protected, the sort option will also be disabled. For more information on worksheet protection, refer [here](https://blazor.syncfusion.com/documentation/spreadsheet/protection#protect-sheet).

## Sort operations

The Blazor Spreadsheet supports two types of sort orders that help organize data for easier analysis and presentation:

* **Ascending** - Arranges data from lowest to highest (A to Z, 0 to 9).
* **Descending** - Arranges data from highest to lowest (Z to A, 9 to 0).

### Sort by active cell

When a sort operation is initiated without an explicitly selected range, the Spreadsheet automatically identifies the **used range** of the worksheet. The used range consists of all contiguous cells that contain data. Sorting is then applied to this range using the column of the **active cell** as the sort key.

This behavior ensures that the entire dataset is sorted cohesively, maintaining row integrity and preventing data misalignment.

**Example**

If the active cell is located in column C and no range is selected, the Spreadsheet will sort all rows within the used range based on the values in column C.

### Sort by selected range

When a specific range is selected prior to initiating a sort operation, the Spreadsheet restricts the sort to the selected range only. The column of the active cell within the selected range is used as the sort key. This approach enables targeted sorting of a subset of data without affecting the rest of the worksheet.

**Example**

If the range B2:D10 is selected and the active cell is in column D, the Spreadsheet will sort only the rows within B2:D10 based on the values in column D.

### Sort via UI

Sorting can be performed through the user interface (UI) using any of the following methods:

**Using the Ribbon**

- Select a cell or range of cells to sort.
- Click the **Home** tab in the **Ribbon** toolbar.
- Click the **Sort & Filter** icon.
- Choose either **Ascending** or **Descending** from the dropdown menu.

![Sort options via the Ribbon toolbar](./images/ribbon-sort.png)

**Using the Context Menu**

- Select a cell or range of cells to sort.
- Right-click on the selected range to open the context menu.
- Hover over the **Sort** option.
- Select either **Ascending** or **Descending** from the submenu.

![Sort options via the context menu](./images/contextmenu-sort.png)

**Using the Filter dialog**

If filtering is enabled, sorting can also be performed through the Filter Dialog. To know more about filtering, refer [here](https://blazor.syncfusion.com/documentation/spreadsheet/filtering).

- Apply a **Filter** to the desired column.
- Click the filter icon in the column header.
- In the Filter Dialog, choose either **Sort Ascending** or **Sort Descending**.
- The sort will be applied to the entire used range based on the selected column.

![Sort options via the filter dialog](./images/filter-dialog-sort.gif)

### Sort range programmatically

The [SortRangeAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Spreadsheet.SfSpreadsheet.html#Syncfusion_Blazor_Spreadsheet_SfSpreadsheet_SortRangeAsync_System_String_System_String_System_String_) method enables sorting of a specified range of cells based on values in a specific column. This method provides a programmatic way to sort data without using the UI. The available parameters in the `SortRangeAsync` method are:

| Parameter | Type | Description |
| -- | -- | -- |
| startColumn | string | Specifies the **column** from which the sorting operation begins. This is typically a column letter such as **B**. The sorting will be based on the values in this column, and the rest of the range will be rearranged accordingly. |
| selectedRange | string | Defines the **range of cells** to be sorted. The range should be specified in standard Excel format (e.g., "D10:B2"). The sorting will be applied to all cells within this range. |
| sortDirection | string | Indicates the direction of the sort. Accepts `asc` for ascending order or `desc` for descending order. If not specified, the default is **asc**. |

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Spreadsheet

<button @onclick="SortDataHandler">Sort Data</button>

<SfSpreadsheet @ref="SpreadsheetInstance" DataSource="DataSourceBytes">
    <SpreadsheetRibbon></SpreadsheetRibbon>
</SfSpreadsheet>

@code {

    public byte[] DataSourceBytes { get; set; }
    public SfSpreadsheet SpreadsheetInstance;

    protected override void OnInitialized()
    {
        string filePath = "wwwroot/Sample.xlsx";
        DataSourceBytes = File.ReadAllBytes(filePath);
    }

    public async Task SortDataHandler()
    {
        // This command sorts data in range A1:C5 based on column A in ascending order.
        await SpreadsheetInstance.SortRangeAsync("A", "A1:C5", "Ascending");
    }
}

{% endhighlight %}
{% endtabs %}
