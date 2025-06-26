---
layout: post
title: Worksheet Operations in Blazor Spreadsheet component | Syncfusion
description: Checkout and learn here about the comprehensive worksheet management functionalities in the Syncfusion Blazor Spreadsheet component and more.
platform: Blazor
control: Spreadsheet
documentation: ug
---

# Worksheet in Blazor Spreadsheet component

A worksheet is a collection of cells organized in the form of rows and columns that allows for storing, formatting, and manipulating data.

## Insert Sheet

A sheet can be dynamically inserted in one of the following ways,

* Click the `+` icon button in the sheet tab. This will insert a new empty sheet next to current active sheet.

* Right click on a sheet tab, and then select `Insert` option from the context menu to insert a new empty sheet after the current active sheet.

* Use the [InsertSheetAsync()](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Spreadsheet.SfSpreadsheet.html#Syncfusion_Blazor_Spreadsheet_SfSpreadsheet_InsertSheetAsync_System_Nullable_System_Int32__System_Nullable_System_Int32__) method to programmatically insert one or more sheets at the desired index.

### Insert a sheet programmatically

A sheet is a collection of cells organized in the form of rows and columns that allows for storing, formatting, and manipulating data. The [InsertSheetAsync()](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Spreadsheet.SfSpreadsheet.html#Syncfusion_Blazor_Spreadsheet_SfSpreadsheet_InsertSheetAsync_System_Nullable_System_Int32__System_Nullable_System_Int32__) method is used to programmatically insert one or more sheets at the desired index.

The following code example shows how to insert a sheet programmatically.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Spreadsheet

<button @onclick="InsertSheetHandler">Insert Sheet</button>
<SfSpreadsheet @ref=spreadsheetObj DataSource="DataSourceBytes">
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

    public async Task InsertSheetHandler()
    {
        // Inserts new sheets from index 1 to 3
        await spreadsheetObj.InsertSheetAsync(1,3);
    }
}

{% endhighlight %}
{% endtabs %}

The following image illustrates the insert sheet options in the Syncfusion Blazor Spreadsheet component.

![UI showing add sheet option](images/addsheet.png)

![UI showing Insert sheet option](images/insert-sheet-option.png)

## Delete Sheet

The Spreadsheet component provides support for removing existing worksheets. The existing worksheet can be dynamically deleted by the following way,

* Right click on a sheet tab, and then select `Delete` option from context menu.

* Using [DeleteSheetAsync()](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Spreadsheet.SfSpreadsheet.html#Syncfusion_Blazor_Spreadsheet_SfSpreadsheet_DeleteSheetAsync_System_Nullable_System_Int32__) method to delete the sheets.

### Delete a sheet programmatically

Sheets can be programmatically deleted at the desired index using the [DeleteSheetAsync()](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Spreadsheet.SfSpreadsheet.html#Syncfusion_Blazor_Spreadsheet_SfSpreadsheet_DeleteSheetAsync_System_Nullable_System_Int32__) method.

The following code example shows how to delete a sheet programmatically.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Spreadsheet

<button @onclick="DeleteSheetHandler">Delete Sheet</button>
<SfSpreadsheet @ref=spreadsheetObj DataSource="DataSourceBytes">
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

    public async Task DeleteSheetHandler()
    {
        await spreadsheetObj.DeleteSheetAsync(0);
    }
}

{% endhighlight %}
{% endtabs %}

The following image shows the Delete sheet option in the Syncfusion Blazor Spreadsheet component. 

![UI showing Delete sheet option](images/delete-sheet-option.png)

## Rename sheet

An existing worksheet can be dynamically renamed in the following way,

* Right click on a sheet tab, and then select `Rename` option from the context menu.

The following image shows the Rename sheet option in the Syncfusion Blazor Spreadsheet component.

![UI showing Rename sheet option](images/rename-sheet-option.png)

## Sheet visibility

Hiding a worksheet can help prevent unauthorized or accidental changes to the file.

* Right click on a sheet tab that should be hidden. Select the "Hide" option from the context menu. The selected sheet will be hidden from view but will remain in the workbook.

The following image shows the hide sheet option in the Syncfusion Blazor Spreadsheet component.

![UI showing Hide sheet option](images/hide-sheet-option.png)

## Move sheet

The Spreadsheet component allows for rearranging the order of worksheets by moving them to different positions. Sheets can be moved in the following ways:

* Click and hold on a sheet tab, then drag it to the desired position.

* Right click on a sheet tab and select `Move Left` or `Move Right` options from the context menu to reposition the sheet accordingly.

* Use the [MoveSheetAsync()](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Spreadsheet.SfSpreadsheet.html#Syncfusion_Blazor_Spreadsheet_SfSpreadsheet_MoveSheetAsync_System_Nullable_System_Int32__System_Int32_) method to programmatically move sheets within the workbook.

### Move sheet programmatically

The [MoveSheetAsync()](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Spreadsheet.SfSpreadsheet.html#Syncfusion_Blazor_Spreadsheet_SfSpreadsheet_MoveSheetAsync_System_Nullable_System_Int32__System_Int32_) method can be used to move a sheet from one index position to another programmatically.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Spreadsheet

<button @onclick="MoveSheetHandler">Move Sheet</button>
<SfSpreadsheet @ref=spreadsheetObj DataSource="DataSourceBytes">
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

    public async Task MoveSheetHandler()
    {
        // Move sheet from index 0 to index 2
        await spreadsheetObj.MoveSheetAsync(0, 2);
    }
}

{% endhighlight %}
{% endtabs %}

The following images show the Move sheet options in the Syncfusion Blazor Spreadsheet component.

![UI showing Move Left sheet option](images/move-left-option.png)
![UI showing Move Right sheet option](images/move-right-option.png)

## Duplicate sheet

The Spreadsheet component provides functionality to create an exact copy of an existing worksheet. Duplicating a worksheet is helpful when creating multiple sheets with similar content or structure. Sheets can be duplicated in the following ways:

* Right click on a sheet tab that needs to be duplicated and select `Duplicate` option from the context menu.

* Use the [DuplicateSheetAsync()](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Spreadsheet.SfSpreadsheet.html#Syncfusion_Blazor_Spreadsheet_SfSpreadsheet_DuplicateSheetAsync_System_Nullable_System_Int32__) method to programmatically create a copy of an existing sheet.

### Duplicate a sheet programmatically

The [DuplicateSheetAsync()](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Spreadsheet.SfSpreadsheet.html#Syncfusion_Blazor_Spreadsheet_SfSpreadsheet_DuplicateSheetAsync_System_Nullable_System_Int32__) method can be used to create a copy of a sheet programmatically. The duplicate sheet will be inserted after the source sheet by default.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Spreadsheet

<button @onclick="DuplicateSheetHandler">Duplicate Sheet</button>
<SfSpreadsheet @ref=spreadsheetObj DataSource="DataSourceBytes">
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

    public async Task DuplicateSheetHandler()
    {
        // Duplicate the sheet at index 0
        await spreadsheetObj.DuplicateSheetAsync(0);
    }
}

{% endhighlight %}
{% endtabs %}

The following image shows the Duplicate sheet option in the Syncfusion Blazor Spreadsheet component.

![UI showing Duplicate sheet option](images/duplicate-sheet-option.png)