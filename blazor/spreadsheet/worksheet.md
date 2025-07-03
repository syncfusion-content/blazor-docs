---
layout: post
title: Worksheet operations in Blazor Spreadsheet component | Syncfusion
description: Checkout and learn here about the comprehensive worksheet management functionalities in the Syncfusion Blazor Spreadsheet component and more.
platform: Blazor
control: Spreadsheet
documentation: ug
---

# Worksheet in Blazor Spreadsheet component

A worksheet is a collection of cells organized in the form of rows and columns that allows for storing, formatting, and manipulating data.

## Insert sheet

The Spreadsheet component provides support for inserting new sheets. New sheets can be dynamically inserted through the following methods:

* Click the `+` icon button in the **Sheet** tab. This will insert a new empty sheet next to current active sheet.

* Right click on a **Sheet** tab, and then select **Insert** option from the context menu to insert a new empty sheet after the current active sheet.

* Using [InsertSheetAsync()](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Spreadsheet.SfSpreadsheet.html#Syncfusion_Blazor_Spreadsheet_SfSpreadsheet_InsertSheetAsync_System_Nullable_System_Int32__System_Nullable_System_Int32__) method.

### Insert sheet programmatically

The `InsertSheetAsync()` method enables programmatic insertion of multiple sheets at the desired index. The following code example illustrates how to insert a sheet programmatically.

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
        // Inserts new sheets from index 1 to 3.
        await SpreadsheetRef.InsertSheetAsync(1,3);
    }
}

{% endhighlight %}
{% endtabs %}

The following image illustrates the insert sheet options in the Spreadsheet.

![Add sheet option](images/addsheet.png)

![Insert sheet context menu](images/insert-sheet-option.png)

## Delete sheet

The Spreadsheet component provides support for removing existing worksheets. The existing worksheet can be dynamically deleted through the following methods:

* Right click on a **Sheet** tab, and then select **Delete** option from context menu.

* Using [DeleteSheetAsync()](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Spreadsheet.SfSpreadsheet.html#Syncfusion_Blazor_Spreadsheet_SfSpreadsheet_DeleteSheetAsync_System_Nullable_System_Int32__) method.

### Delete sheet programmatically

The sheets can be programmatically deleted at the desired index using the `DeleteSheetAsync()` method. The following code example illustrates how to delete a sheet programmatically.

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
        // To delete the first sheet.
        await SpreadsheetRef.DeleteSheetAsync(0);
    }
}

{% endhighlight %}
{% endtabs %}

The following image illustrates the delete sheet option in the Spreadsheet. 

![Delete sheet option](images/delete-sheet-option.png)

## Rename sheet

The Spreadsheet component provides support for renaming worksheets. Existing worksheets can be dynamically renamed by right-clicking on a **Sheet** tab, and then selecting the **Rename** option from the context menu. 

The following image illustrates the rename sheet option in the Spreadsheet.

![Rename sheet option](images/rename-sheet-option.png)

## Hide sheet

The Spreadsheet component provides support for hiding worksheets. Hiding worksheets helps prevent unauthorized or accidental changes to the file. Existing worksheets can be dynamically hidden by right-clicking on a **Sheet** tab that should be hidden, then selecting the **Hide** option from the context menu. The selected sheet will be hidden from view but will remain in the workbook.

The following image illustrates the hide sheet option in the Spreadsheet.

![Hide sheet option](images/hide-sheet-option.png)

## Unhide sheet

The Spreadsheet component also provides functionality to restore hidden worksheets to view. Hidden worksheets appear in a disabled state within the sheet selection menu. To make a hidden sheet visible again, click on the **Sheet** tab list icon and then click the hidden sheet. The previously hidden sheet will reappear in the sheet tab collection and become available for editing.

The following image illustrates the sheet selection menu showing a visible sheet (Sheet1) and a disabled hidden sheet (Sheet2).

![Unhide sheet option](images/unhide-sheet-option.png)

## Move sheet

The Spreadsheet component allows for rearranging the order of worksheets by moving them to different positions. Sheets can be moved in the following methods:

* Click and hold on a **Sheet** tab, then drag it to the desired position.

* Right click on a **Sheet** tab and select **Move Left** or **Move Right** options from the context menu to reposition the sheet accordingly.

* Using [MoveSheetAsync()](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Spreadsheet.SfSpreadsheet.html#Syncfusion_Blazor_Spreadsheet_SfSpreadsheet_MoveSheetAsync_System_Nullable_System_Int32__System_Int32_) method.

### Move sheet programmatically

The `MoveSheetAsync()` method can be used to move a sheet from one index position to another programmatically.

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

The following images illustrates the move sheet options in the Spreadsheet.

![Move Left sheet option](images/move-left-option.png)
![Move Right sheet option](images/move-right-option.png)

## Duplicate sheet

The Spreadsheet component provides functionality to create an exact copy of an existing worksheet. Duplicating a worksheet is helpful when creating multiple sheets with similar content or structure. Sheets can be duplicated using the following methods:

* Right click on a **Sheet** tab that needs to be duplicated and select **Duplicate** option from the context menu.

* Using [DuplicateSheetAsync()](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Spreadsheet.SfSpreadsheet.html#Syncfusion_Blazor_Spreadsheet_SfSpreadsheet_DuplicateSheetAsync_System_Nullable_System_Int32__) method.

### Duplicate sheet programmatically

The `DuplicateSheetAsync()` method can be used to create a copy of a sheet programmatically. The duplicate sheet will be inserted after the source sheet by default.

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

The following image illustrates the duplicate sheet option in the Spreadsheet.

![Duplicate sheet option](images/duplicate-sheet-option.png)