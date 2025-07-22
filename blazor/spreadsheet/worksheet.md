---
layout: post
title: Worksheet operations in Blazor Spreadsheet component | Syncfusion
description: Checkout and learn here about the comprehensive worksheet management functionalities in the Syncfusion Blazor Spreadsheet component and more.
platform: Blazor
control: Spreadsheet
documentation: ug
---

# Worksheet in Blazor Spreadsheet component

A worksheet is a collection of cells organized in the form of rows and columns that allows for storing, formatting, and manipulating data. This feature supports data organization across multiple sheets, making it suitable for scenarios like managing department-wise records, financial reports, or project data in separate sheets.

N> If the workbook is protected, operations like **inserting**, **deleting**, **renaming**, **hiding**, **unhiding**, **moving**, or **duplicating** sheets are disabled through both the user interface (UI) and code. To know more about workbook protection, refer [here](./protection#protect-workbook).

## Insert sheet

The Insert sheet feature in the Syncfusion Blazor Spreadsheet component allows adding new sheets to a workbook, enabling better organization of data across multiple sheets. This feature can be accessed through the user interface (UI) or programmatically, offering flexibility based on the application's requirements.

### Insert sheet via UI

To add or insert a new sheet using the UI, follow these steps:

* Click the `+` icon button in the **Sheet** tab. This will insert a new empty sheet next to current active sheet.
![Add sheet option](images/addsheet.png)

* Right click on a **Sheet** tab, and then select **Insert** option from the context menu to insert a new empty sheet after the current active sheet.
![Insert sheet context menu](images/insert-sheet-option.png)

### Insert sheet programmatically

The [InsertSheetAsync()](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Spreadsheet.SfSpreadsheet.html#Syncfusion_Blazor_Spreadsheet_SfSpreadsheet_InsertSheetAsync_System_Nullable_System_Int32__System_Nullable_System_Int32__) method allows adding one or more sheets to a workbook using code. It supports two main scenarios: adding multiple sheets with default names or adding a single sheet with a custom name. Below are the details for each scenario, including code examples and parameter information.

**Insert multiple sheets at a specific index**

This method inserts one or more sheets at a specified position in the workbook with default names (e.g., Sheet1, Sheet2). For example, if the spreadsheet has three sheets named Sheet1, Sheet2, and Sheet3, adding two sheets at position 1 results in: Sheet1, Sheet4, Sheet5, Sheet2, Sheet3. If no position is provided, the sheets are added at the end of the workbook. This is ideal for scenarios requiring multiple sheets, such as organizing large datasets or creating templates for repetitive tasks.

| Parameter | Type | Description |
| -- | -- | -- |
| index | int (optional) | The zero-based index where the sheets will be inserted. If not specified, sheets are added at the end of the workbook. If the specified index is invalid (e.g., negative or beyond the workbook's sheet count), no action occurs. |
| count | int (optional) | The number of sheets to add. Defaults to 1 if not specified. |

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Spreadsheet

<button @onclick="InsertSheetHandler">Insert Sheet</button>

<SfSpreadsheet @ref=SpreadsheetRef DataSource="DataSourceBytes">
    <SpreadsheetRibbon></SpreadsheetRibbon>
</SfSpreadsheet>

@code {

    public byte[] DataSourceBytes { get; set; }
    public SfSpreadsheet SpreadsheetRef;

    protected override void OnInitialized()
    {
        string filePath = "wwwroot/Sample.xlsx";
        DataSourceBytes = File.ReadAllBytes(filePath);
    }

    public async Task InsertSheetHandler()
    {
        // // Insert 2 sheets at index 1.
        await SpreadsheetRef.InsertSheetAsync(1,2);
    }
}

{% endhighlight %}
{% endtabs %}

**Insert a single sheet with a user-defined name**

This method inserts a single sheet at a specified position with a user-defined name. Only one sheet is added per method call. It is useful for creating sheets with meaningful names, such as "Budget" or "Inventory," to improve workbook clarity.

| Parameter | Type | Description |
| -- | -- | -- |
| index | int | The zero-based index where the sheet will be inserted. If the specified index is invalid (e.g., negative or beyond the workbook's sheet count), no action occurs. |
| sheetName | string | The name for the new sheet. |

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Spreadsheet

<button @onclick="InsertSheetHandler">Insert Sheet</button>

<SfSpreadsheet @ref=SpreadsheetRef DataSource="DataSourceBytes">
    <SpreadsheetRibbon></SpreadsheetRibbon>
</SfSpreadsheet>

@code {

    public byte[] DataSourceBytes { get; set; }
    public SfSpreadsheet SpreadsheetRef;

    protected override void OnInitialized()
    {
        string filePath = "wwwroot/Sample.xlsx";
        DataSourceBytes = File.ReadAllBytes(filePath);
    }

    public async Task InsertSheetHandler()
    {
        // Insert a sheet at index 1 with a user-defined name.
        await SpreadsheetRef.InsertSheetAsync(1,"Sales");
    }
}

{% endhighlight %}
{% endtabs %}

## Delete sheet

The Spreadsheet component supports removing sheets from a spreadsheet. When the workbook contains only one sheet, the delete option is disabled in the interface, and no action occurs during programmatic deletion attempts. Sheets can be deleted using the interface or programmatically, based on application requirements.

### Delete sheet via UI

To remove a sheet using the interface, follow these steps:

* Right click on a **Sheet** tab, and then select **Delete** option from context menu. This removes the selected sheet from the workbook. 

![Delete sheet option](images/delete-sheet-option.png)

### Delete sheet programmatically

Sheets can be deleted at a specific index using the [DeleteSheetAsync()](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Spreadsheet.SfSpreadsheet.html#Syncfusion_Blazor_Spreadsheet_SfSpreadsheet_DeleteSheetAsync_System_Nullable_System_Int32__) method. It supports two main scenarios: delete sheet by index or delete sheet by name. Below are the details for each scenario, including code examples and parameter information.

**Delete sheet by index**

This method deletes the sheet at the specified index. This is ideal for scenarios where the sheet's position in the workbook is known, such as removing the first or last sheet programmatically.

| Parameter | Type | Description |
| -- | -- | -- |
| index | int (optional) | The zero-based index of the sheet to delete. If no index is provided, the active sheet is deleted. If the index is invalid (e.g., negative or beyond the workbook's sheet count) or the workbook has only one sheet, no action occurs. |

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Spreadsheet

<button @onclick="DeleteSheetHandler">Delete Sheet</button>

<SfSpreadsheet @ref=SpreadsheetRef DataSource="DataSourceBytes">
    <SpreadsheetRibbon></SpreadsheetRibbon>
</SfSpreadsheet>

@code {

    public byte[] DataSourceBytes { get; set; }
    public SfSpreadsheet SpreadsheetRef;

    protected override void OnInitialized()
    {
        string filePath = "wwwroot/Sample.xlsx";
        DataSourceBytes = File.ReadAllBytes(filePath);
    }

    public async Task DeleteSheetHandler()
    {
        // Remove sheet at index 0.
        await SpreadsheetRef.DeleteSheetAsync(0);
    }
}

{% endhighlight %}
{% endtabs %}

**Delete sheet by name**

This method deletes the sheet with the specified name. This is useful when the sheet's name is known, such as removing a sheet named "Budget" or "Sales".

| Parameter | Type | Description |
| -- | -- | -- |
| sheetName | string | The name of the sheet to delete. If the name does not exist or the workbook has only one sheet, The name of the sheet to delete. If the name does not exist or the workbook has only one sheet, no action occurs. |

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Spreadsheet

<button @onclick="DeleteSheetHandler">Delete Sheet</button>

<SfSpreadsheet @ref=SpreadsheetRef DataSource="DataSourceBytes">
    <SpreadsheetRibbon></SpreadsheetRibbon>
</SfSpreadsheet>

@code {

    public byte[] DataSourceBytes { get; set; }
    public SfSpreadsheet SpreadsheetRef;

    protected override void OnInitialized()
    {
        string filePath = "wwwroot/Sample.xlsx";
        DataSourceBytes = File.ReadAllBytes(filePath);
    }

    public async Task DeleteSheetHandler()
    {
        // Remove sheet named "Sales".
        await SpreadsheetRef.DeleteSheetAsync("Sales");
    }
}

{% endhighlight %}
{% endtabs %}

## Rename sheet

The Rename Sheet feature allows assigning user-defined names to sheets for better organization. Sheet names must be unique within the workbook, and renaming does not affect data or formulas. This feature is essential for improving workbook clarity, especially in complex workbooks with multiple sheets.

To rename a sheet:

* Right-click a **Sheet** tab and select **Rename** from the context menu. Enter a new name and press **Enter** or click **update** to confirm.

![Rename sheet option](images/rename-sheet-option.png)

## Hide sheet

Hiding sheets in the Spreadsheet component prevents unauthorized access or accidental changes. Hidden sheets remain in the workbook, retaining all data, formulas, and functionality, but are not visible in the interface.

To hide a sheet:

* Right-click a **Sheet** tab and select the **Hide** option from the context menu. 

**Notes**

* The **Hide** option is available only if the workbook has more than one visible sheet, ensuring at least one sheet remains visible.

* Hidden sheets can still be referenced in formulas and calculations.

* Access the sheet selection menu to view all sheets, including hidden ones.

![Hide sheet option](images/hide-sheet-option.png)

## Unhide sheet

The Spreadsheet component allows restoring hidden sheets to view. Hidden sheets appear in a disabled state within the sheet selection menu. 

To make a hidden sheet visible again:

* Click on the **Sheet** tab list icon and then click the hidden sheet. 

The sheet will reappear in the sheet tab collection and become available for editing.

![Unhide sheet option](images/unhide-sheet-option.png)

## Move sheet

The Spreadsheet component allows reordering sheets by moving them to different positions within the workbook. This feature helps organize sheets in a preferred sequence for better navigation and workflow efficiency. Sheets can be moved using the interface or programmatically, based on application needs.

### Move sheet via UI

To move a sheet using the interface, follow these steps:

* Click and hold on a **Sheet** tab, then drag it to the desired position.

* Right click on a **Sheet** tab and select **Move Left** or **Move Right** options from the context menu to reposition the sheet accordingly.

**Move Right** is enabled only if a sheet exists to the right, and **Move Left** is enabled only if a sheet exists to the left.

![Move Left sheet option](images/move-left-option.png)
![Move Right sheet option](images/move-right-option.png)

### Move sheet programmatically

The [MoveSheetAsync()](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Spreadsheet.SfSpreadsheet.html#Syncfusion_Blazor_Spreadsheet_SfSpreadsheet_MoveSheetAsync_System_Nullable_System_Int32__System_Int32_) method moves a sheet from one index to another programmatically.

| Parameter | Type | Description |
| -- | -- | -- |
| sourceIndex | int | The zero-based index of the sheet to move. If invalid (e.g., negative or beyond sheet count), no action occurs. |
| destinationIndex | int | The zero-based index where the sheet will be moved. If invalid, no action occurs. |

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Spreadsheet

<button @onclick="MoveSheetHandler">Move Sheet</button>

<SfSpreadsheet @ref=SpreadsheetRef DataSource="DataSourceBytes">
    <SpreadsheetRibbon></SpreadsheetRibbon>
</SfSpreadsheet>

@code {

    public byte[] DataSourceBytes { get; set; }
    public SfSpreadsheet SpreadsheetRef;

    protected override void OnInitialized()
    {
        string filePath = "wwwroot/Sample.xlsx";
        DataSourceBytes = File.ReadAllBytes(filePath);
    }

    public async Task MoveSheetHandler()
    {
        // Move sheet from index 0 to index 2.
        await SpreadsheetRef.MoveSheetAsync(0, 2);
    }
}

{% endhighlight %}
{% endtabs %}

## Duplicate sheet

The Spreadsheet component allows creating an exact copy of a sheet. Duplicating a sheet helps when making multiple sheets with similar content or structure. The duplicate sheet gets a unique name, typically appending a number (e.g., "Sheet1" becomes "Sheet1 (2)"). Sheets can be duplicate using the interface or programmatically, based on application needs.

### Duplicate sheet via UI

To duplicate a sheet using the interface, follow these steps:

* Right click on a **Sheet** tab that needs to be duplicated and select **Duplicate** option from the context menu.

![Duplicate sheet option](images/duplicate-sheet-option.png)

### Duplicate sheet programmatically

The [DuplicateSheetAsync()](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Spreadsheet.SfSpreadsheet.html#Syncfusion_Blazor_Spreadsheet_SfSpreadsheet_DuplicateSheetAsync_System_Nullable_System_Int32__) method can be used to create a copy of a sheet programmatically. The duplicate sheet will be inserted after the source sheet by default.

| Parameter | Type | Description |
| -- | -- | -- |
| index | int (optional) | The zero-based index of the sheet to duplicate. If no index is provided, the active sheet is duplicated. If the index is invalid (e.g., negative or beyond sheet count), no action occurs. |

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Spreadsheet

<button @onclick="DuplicateSheetHandler">Duplicate Sheet</button>

<SfSpreadsheet @ref=SpreadsheetRef DataSource="DataSourceBytes">
    <SpreadsheetRibbon></SpreadsheetRibbon>
</SfSpreadsheet>

@code {

    public byte[] DataSourceBytes { get; set; }
    public SfSpreadsheet SpreadsheetRef;

    protected override void OnInitialized()
    {
        string filePath = "wwwroot/Sample.xlsx";
        DataSourceBytes = File.ReadAllBytes(filePath);
    }

    public async Task DuplicateSheetHandler()
    {
        // Duplicate the sheet at index 0.
        await SpreadsheetRef.DuplicateSheetAsync(0);
    }
}

{% endhighlight %}
{% endtabs %}
