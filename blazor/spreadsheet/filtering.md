---
layout: post
title: Filtering in Blazor Spreadsheet Component | Syncfusion
description: Checkout and learn all about the comprehensive filter functionality in Syncfusion Blazor Spreadsheet component and much more.
platform: Blazor
control: Spreadsheet
documentation: ug
---

# Filtering in Blazor Spreadsheet component

Filtering functionality in the Blazor Spreadsheet enables focused data analysis by displaying only rows that meet specific criteria. This feature creates interactive views by hiding irrelevant rows.

Filtering can be enabled or disabled using the [AllowFiltering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Spreadsheet.SfSpreadsheet.html#Syncfusion_Blazor_Spreadsheet_SfSpreadsheet_AllowFiltering) property. The default value of this property is **true**.

N> When `AllowFiltering` is set to **false**, the filtering options are disabled in ribbon and removed from the context menu. The API methods related to this feature will no longer work. If the worksheet is protected, filter option disabled. For more information on worksheet protection, refer [here](https://blazor.syncfusion.com/documentation/spreadsheet/protection#protect-sheet).

## Filter operations

The Blazor Spreadsheet supports various filtering operations to manage and analyze data effectively. These include filtering by cell value or condition, clearing filters, and reapplying filters after data changes.

**Filter via UI**

Filtering can be accessed through the user interface (UI) using the following methods:

**Using the Ribbon**

- Select the **Home** tab in the **Ribbon** toolbar.
- Click the **Sort & Filter** icon.
- Choose the **Filter** option.

![Filter options via the Ribbon toolbar](./images/ribbon-filter.png)

**Using the Context Menu**

- Right-click the selected cell.
- Choose the **Filter** option from the context menu.
- Click the **Filter by Value of Selected Cell** option.

![Filter options via the context menu](./images/contextmenu-filter.png)


## Types of Filters

The Blazor Spreadsheet supports multiple filter types tailored to different data formats:

* **Checkbox Filters** - Display a list of distinct values with checkboxes for selection, allowing multiple values to be filtered simultaneously.
* **Text Filters** - Enable filtering based on string patterns such as **Starts With**, **Ends With**, **Contains**, **Does Not Contain**, etc.
* **Number Filters** - Apply numeric conditions including **Equals**,  **Greater Than**, **Less Than** and **Between**, etc.
* **Date Filters** -  Filter data by time-based criteria such as **Today**, **This Week**, **This Month**, **Last Year**, etc.
* **Custom Filters** - Combine multiple filter conditions using logical operators like **AND**, **OR**, etc.

## Filter range validations

When applying filters in the Blazor Spreadsheet, validation messages are displayed in specific scenarios to inform about filtering constraints:

- **Out of range validation** - If the selected cell or range falls outside the used range of the active worksheet, it is considered invalid. An **Out of Range** alert message will be displayed to indicate this limitation.

![Out of range validation message](./images/out-of-range-validation.png)

- **Multiple ranges validation** - If multiple ranges are selected for filtering, the selection is considered invalid. A **Multiple Ranges** alert message is shown to highlight this limitation.

![Multiple ranges validation message](./images/multi-range-validation.png)

## Excel-Style Filter Dialog

The Blazor Spreadsheet includes a comprehensive Excel-style filter dialog that adapts dynamically to the data type in the selected column. The filter dialog provides intuitive filtering mechanisms designed for different data types and analysis needs.

### Checkbox filters

The checkbox-based filter dialog appears when you click on a column's filter icon and provides the following features:

* **Sort options** - Provides commands for sorting data in ascending or descending order.
* **Clear filter** - Removes any filtering applied to the selected column.
* **Data type-specific filters** - Displays sub menus tailored to the column's content type, such as **Text Filters**, **Number Filters**, or **Date Filters**.
* **Search box** - Enables quick lookup of values within the filter list.
* **Select All checkbox** - Toggles the selection of all available values in the column.
* **Value checkboxes** - Lists individual checkboxes for each unique value found in the column.

![Checkbox filter](./images/checkbox-filter.png)

### Text filters

Text filters enable filtering based on specific string conditions. When applied to text-based columns, the **Text Filters** submenu provides the following operators:

| Operator | Description |
| -- | -- |
| Equal | Displays rows with cell values that exactly match the specified text. |
| Not Equal | Displays rows with cell values that do not match the specified text. |
| Starts With | Displays rows with cell values that begin with the specified text. |
| Does Not Start With | Displays rows with cell values that do not begin with the specified text. |
| Ends With | Displays rows with cell values that end with the specified text. |
| Does Not End With | Displays rows with cell values that do not end with the specified text. |
| Contains | Displays rows with cell values that include the specified text. |
| Does Not Contain | Displays rows with cell values that do not include the specified text. |
| Custom Filter | Opens a dialog for defining advanced filter conditions. Multiple criteria can be combined using logical operators such as **AND** and **OR**. Each condition supports standard text operators and custom input values, enabling precise and flexible filtering. |

![Text filter](./images/text-filter-options.png)

N> For text-based filtering, the dialog also includes a **Match Case** option. When enabled, this option applies case-sensitive filtering to the specified conditions. The **Match Case** checkbox is only displayed when filtering text data, ensuring relevance to the data type being processed.

### Number filters

Number filters provide specialized filtering options for columns containing numeric data. The **Number Filters** menu includes a range of comparison operators that support precise value-based filtering:

| Operator | Description |
| -- | -- |
| Equal | Displays rows where the cell value exactly match the specified number. |
| Not Equal | Displays rows where the cell value does not match the specified number. |
| Less Than | Displays rows where the cell value is less than the specified number. |
| Less Than Or Equal | Displays rows where the cell value is less than or equal to the specified number. |
| Greater Than | Displays rows where the cell value is greater than the specified number. |
| Greater Than Or Equal | Displays rows where the cell value falls within a specified numeric range. |
| Between | Displays rows with cell values that include the specified text. |
| Custom Filter | Opens a dialog for defining advanced numeric filter conditions. This dialog allows the combination of multiple criteria using logical operators such as **AND** and **OR**. Each condition can be configured using numeric comparison operators and custom values, enabling flexible and targeted filtering of numerical data. |

![Number filter](./images/number-filter.png)

### Date filters

The date filters provide specialized filtering options for columns containing date values. The Spreadsheet automatically detects date columns and offers both standard filtering options and date-specific filtering:

| Operator | Description |
| -- | -- |
| Equal | Displays rows where the cell value exactly match the specified value. |
| Not Equal | Displays rows where the cell value does not match the specified value. |
| Less Than | Displays rows where the date is earlier than the specified value. |
| Greater Than | Displays rows where the date is later than the specified value. |
| Between | Displays rows where the date falls within a defined date range. |
| This Month | Filters rows where the date falls within the current calendar month. |
| Last Month | Filters rows where the date falls within the previous calendar month. |
| Next Month | Filters rows where the date falls within the next calendar month. |
| This Quarter | Filters rows where the date falls within the current quarter. |
| Last Quarter | Filters rows where the date falls within the previous quarter. |
| Next Quarter | Filters rows where the date falls within the next quarter. |
| This Year | Filters rows where the date falls within the current year. |
| Last Year | Filters rows where the date falls within the previous year. |
| Next Year | Filters rows where the date falls within the next year. |
| Custom Filter | Opens a dialog to define complex date-based conditions using AND/OR logic. |

**Date hierarchy and grouping**

The Spreadsheet organizes date values into a structured, expandable hierarchy to simplify filtering and navigation. This is especially helpful when working with large datasets that span multiple months or years.

**Hierarchical Structure**

* **Year Level** - Dates are first grouped by year. For example, all dates from 2023 are grouped under **2023**.
* **Month Level** - Within each year, dates are further grouped by month. For instance, under **2023**, months like **January**, **February**, etc., are listed.
* **Day Level** - Expanding a month reveals individual day entries. For example, under **2023 → January**, dates like **10**, **15**, and **28** are shown.
* **Expand/collapse controls** - Each year and month group includes a toggle control to expand or collapse its contents. This helps reduce clutter and allows to focus on specific time periods.
* **Group selection** - Entire groups—such as a full year or a specific month—can be selected or deselected with a single click. This enables quick filtering without manually selecting each date.

This hierarchical approach makes it easier to browse, locate, and filter date-based data efficiently.

![Date filter](./images/date-filter.gif)

### Custom filter

The **Custom Filter** dialog enables advanced filtering by allowing the definition of multiple conditions using logical operators. This dialog adapts dynamically based on the data type of the column being filtered.

* **First condition**
  * **Operator dropdown** - Select a filter type such as Equals, Contains, Greater Than, or Before. The list changes based on the data type.
  * **Value field** - Enter the value to compare. This can be a word, number, or date.
* **Logical operator**
    * Choose how the two conditions should be combined:
        * **AND** – Both conditions must be true.
        * **OR** – At least one condition must be true.
* **Match case (Text only)**
    * Available only for text columns.
    * Enable this option to make the filter case-sensitive (e.g., "Apple" ≠ "apple")
* **Second condition**:
  * **Operator dropdown** - Select a second filter type. The options are the same as in the first condition and depend on the data type.
  * **Value field** - Enter the second value to compare. This supports text, numbers, or dates.

The operators available in the custom filter dialog change dynamically based on the data type:

| Data Type  | Supported Operators |
| -- | -- |
| Text | Starts With, Does Not Start With, Ends With, Does Not End With, Contains, Does Not Contain, Equals, Not Equal. |
| Number | Equals, Not Equal, Greater Than, Greater Than Or Equal, Less Than, Less Than Or Equal. |
| Date | Equals, Not Equal, Greater Than, Greater Than Or Equal, Less Than, Less Than Or Equal. |

![Custom filter](./images/custom-filter.png)

### Add current selection to filter

The **Add current selection to filter** option appears below the search box in the filter dialog. It allows multiple filter selections to be combined without clearing previous ones.

By default, applying a new filter to a column replaces any existing selections. Enabling this option ensures that new selections are added to the existing filter criteria instead of replacing them.

**How it works**
- Open the filter dialog for a column.
- Use the search box to find specific values.
- Check the Add current selection to filter box.
- Select additional values to include in the filter.
- Apply the filter. 

The new values will be added to the existing filter set.
This feature is especially useful when building complex filters incrementally without losing earlier selections.


![Add current selection to filter](./images/add-current-selection-to-filter.png)


### Mixed data handling

The Spreadsheet filter dialog intelligently handles columns containing mixed data types:

* **Automatic type detection** 
    - The system analyzes the column's content to identify the most common data type and adjusts the filter behavior accordingly.
    - **Example:** If most values in a column are numbers but a few are text, the filter treats the column as numeric and shows number-based filter options.

* **Type-based grouping** 
    - Values are grouped by type in a fixed order: 
    Boolean → Number → Date → Text → (Blank)
    - **Example:** A column with values TRUE, 100, 12/07/2025, "Done", and a blank cell will display them grouped by type in the filter list.

* **Special handling for empty values** 
    - Empty cells are shown as **(Blank)** in the filter list, making them easy to identify and select.
    - **Example:** If a column has some missing values, they appear as **(Blank)** in the filter, allowing users to include or exclude them.

* **Search across types** 
    - The search box works across all data types in the column.
    - **Example:** Typing 100 in the search box will return both the number 100 and the text "100" if both exist in the column.

* **Format preservation** 
    - The filter dialog keeps the original formatting of values (e.g., currency, date format) when displaying them.
    - **Example:** A value formatted as $1,000.00 in the spreadsheet will appear the same way in the filter list.

This advanced handling ensures effective filtering even in spreadsheets with inconsistent data types.

## Filter by cell value

The Filter by Cell Value feature enables filtering worksheet data based on a selected cell's content. This functionality streamlines data analysis by instantly displaying only rows that match the selected value.

### Filter by cell value via UI

Cell value filtering can be applied through the user interface (UI), Click on the cell that contains the value to filter by, Right-click on the selected cell to open the context menu, From the menu select **Filter**, Click **Filter by Value of Selected Cell**. 

![Cell value filtering interface](./images/contextmenu-filter.png)

### Filter by cell value programmatically

The [FilterByCellValueAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Spreadsheet.SfSpreadsheet.html#Syncfusion_Blazor_Spreadsheet_SfSpreadsheet_FilterByCellValueAsync_System_Object_System_String_) method allows filtering based on a specified value and cell address without using the UI. The available parameters in the `FilterByCellValueAsync` method are:

| Parameter | Type | Description |
| -- | -- | -- |
|cellAddress | string | Specifies the address of the cell that contains the filter criteria. This determines which column the filter will be applied to. Example: "A1" applies the filter to column A. |
| cellValue | object | The value to filter by. This can be a string, number, date, or boolean. The filter will show only rows where the cell in the specified column matches this value. Example: "New York" will display rows where column A contains "New York". |

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Spreadsheet
@using Syncfusion.Blazor.Buttons

<SfButton OnClick="ApplyFilter" Content="Filter by Value"></SfButton>

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

    public async Task ApplyFilter()
    {
        // Apply filter to column A using the value "New York".
        await SpreadsheetInstance.FilterByCellValueAsync("A1", "New York"); 
    }
}

{% endhighlight %}
{% endtabs %}


## Clear filter

The **Clear Filter** feature makes all rows visible again by removing any filters currently applied to columns. It offers flexibility by allowing filters to be cleared from a single column or from all columns at once.

### Clear filter via UI

Clear filters can be applied through the user interface (UI) using the following methods:

**Using the Ribbon**

* Click the **Home** tab in the Ribbon toolbar.
* In the **Sort & Filter** section, click **Clear**.
* All active filters will be removed from the worksheet.

![Clear filter option in Ribbon toolbar](./images/clearfilter-option-ribbon.png)

**Using the Filter Button**

* Click the filter icon in the header of a filtered column.
* In the filter dialog, click **Clear Filter**.
* The filter applied to that column will be removed.

![Clear filter option in Filter Button](./images/clearfilter-option-filterbutton.png)

**Using the Context Menu**

* Right-click any cell in a filtered column.
* Choose Filter from the context menu.
* Select **Clear From Column Name**.
* The filter applied to that column will be removed.

![Clear filter option in Context Menu](./images/clearfilter-option-contextmenu.png)

### Clear filter programmatically

The Blazor Spreadsheet provides method to programmatically clear filters that have been applied to the worksheet data.

**Clear filter by column index**

The [ClearFilterAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Spreadsheet.SfSpreadsheet.html#Syncfusion_Blazor_Spreadsheet_SfSpreadsheet_ClearFilterAsync_System_Int32_) method removes filtering from a specific column in the Spreadsheet. The available parameters in the `ClearFilterAsync` method are:

| Parameter | Type | Description |
| -- | -- | -- |
| columnIndex | int | The zero-based index of the column whose filter is to be cleared. For example, 0 refers to the first column (Column A). |

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Spreadsheet
@using Syncfusion.Blazor.Buttons

<SfButton OnClick="ClearColumnFilter" Content="Clear Filter"></SfButton>

<SfSpreadsheet @ref="@SpreadsheetInstance" DataSource="DataSourceBytes">
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

    public async Task ClearColumnFilter()
    {
        // Clear the filter applied to column A (index 0).
        await SpreadsheetInstance.ClearFilterAsync(0);
    }
}

{% endhighlight %}
{% endtabs %}


### Clear all filters

The [ClearAllFiltersAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Spreadsheet.SfSpreadsheet.html#Syncfusion_Blazor_Spreadsheet_SfSpreadsheet_ClearAllFiltersAsync) method removes all active filters from the Spreadsheet, restoring visibility to the entire dataset. This is especially useful when multiple columns are filtered and a full reset is needed.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Spreadsheet
@using Syncfusion.Blazor.Buttons

<SfButton OnClick="ClearAllFilters" Content="Clear All Filters"></SfButton>
<SfSpreadsheet @ref="@SpreadsheetInstance" DataSource="DataSourceBytes">
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

    public async Task ClearAllFilters()
    {
        // Clear all filters applied in the spreadsheet and show all rows.
        await SpreadsheetInstance.ClearAllFiltersAsync();
    }
}

{% endhighlight %}
{% endtabs %}

N> When working with filtered data, actions like `Clear All`, `Clear Content`, and `AutoFill` only affect the rows that are visible. Rows hidden by filters will stay unchanged.


## Reapply filter

The **Reapply Filter** feature updates the filtered results after changes are made to the data. It keeps the same filter settings but refreshes the view so that the latest data is shown correctly. For example, Suppose a filter is applied to show only rows where the **Status** column is set to **Approved**. If a new row is added with Approved as the status, it will not appear right away. Using Reapply Filter will refresh the filter and include the new row in the results.

### Reapply filter via UI

Reapply filter can be accessed through the user interface (UI) using the following methods:

**Using the Ribbon**

* Click the **Home** tab in the Ribbon toolbar.
* In the **Sort & Filter** section, click the **Reapply** option.
* Active filters will recalculate based on current data.

![Reapply filter option in Ribbon toolbar](./images/clearfilter-option-ribbon.png)

**Using the Context Menu**

* Right-click any cell in a filtered column.
* Choose **Filter** from the context menu.
* Select **Reapply** option.
* Active filters will recalculate based on current data.

![Reapply filter option in Context Menu](./images/clearfilter-option-contextmenu.png)

### Reapply filter programmatically

The [ReapplyFilterAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Spreadsheet.SfSpreadsheet.html#Syncfusion_Blazor_Spreadsheet_SfSpreadsheet_ReapplyFilterAsync) method updates all active filters in the Spreadsheet to reflect the latest data. It is helpful when the data has changed and the filters need to be refreshed to match the updated content.


{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Spreadsheet
@using Syncfusion.Blazor.Buttons

<SfButton OnClick="UpdateAndReapply" Content="Update Data and Reapply Filters"></SfButton>
<SfSpreadsheet @ref="@SpreadsheetInstance" DataSource="DataSourceBytes">
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

    public async Task UpdateAndReapply()
    {
        
        // Update a cell value in the spreadsheet.
        await SpreadsheetInstance.UpdateCellAsync("Sheet1!A1", "New Value");
        
        // Reapply filters to reflect the updated data.
        await SpreadsheetInstance.ReapplyFiltersAsync();
    }
}

{% endhighlight %}
{% endtabs %}
