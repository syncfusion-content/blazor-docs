---
layout: post
title: Clipboard in Blazor Spreadsheet component | Syncfusion
description: Checkout and learn here all about the clipboard functionalities in the Syncfusion Blazor Spreadsheet component and more.
platform: Blazor
control: Spreadsheet
documentation: ug
---

# Clipboard in Blazor Spreadsheet component

The Spreadsheet supports clipboard operations such as **Cut**, **Copy**, and **Paste**. These operations can be enabled or disabled using the [EnableClipboard](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Spreadsheet.SfSpreadsheet.html#Syncfusion_Blazor_Spreadsheet_SfSpreadsheet_EnableClipboard) property of the Spreadsheet component. By default, the `EnableClipboard` property is set to **true**.

N> When `EnableClipboard` is set to **false**, the **Cut** and **Copy** options are removed from the user interface (Ribbon and Context Menu). In addition, shortcut keys (**Ctrl+C, Ctrl+X, Ctrl+V**) and API methods will not work.

## Cut

The cut operation removes data from selected cells, rows, or columns in a sheet and temporarily stores it on the clipboard for use elsewhere. Once pasted to a new location, the original content is removed, effectively allowing users to move data within the spreadsheet.

### Cut operations via UI

The cut operation can be performed through the user interface (UI) using any of the following methods:

**Using the Ribbon**

- Select a cell or range of cells to cut the content.
- Click the **Cut** button in the **Home** tab of the **Ribbon** toolbar. This will cut the selected cell or range.

![Cut - Ribbon](images/cut-copy.png)

**Using the Context Menu**

- Select a cell or range of cells to cut the content.
- Right-click on the selected cell or range.
- Choose the **Cut** option from the context menu.

![Cut - Context Menu](images/contextmenu-cut-copy.png)

### Cut operations programmatically

The [CutCellAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Spreadsheet.SfSpreadsheet.html#Syncfusion_Blazor_Spreadsheet_SfSpreadsheet_CutCellAsync_System_String_) method allows performing cut operations within any sheet. This method copies the specified cell or range and its properties (including value, format, style, etc.) to the clipboard and removes it from the sheet. It supports multiple scenarios for cutting cells or ranges. Below are the details for each scenario, including code examples and parameter information.

> The cut operation will not execute if invalid or out-of-boundary cell ranges are provided. Ensure that all cell addresses fall within the valid worksheet boundaries.

**Cut active range**

When this method is called without any parameters, it automatically cuts the content from the last selected range if an active selection exists. If no range is currently selected, it cuts the active cell.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Spreadsheet

<button @onclick="CutActiveCell">Cut Active Cell</button>

<SfSpreadsheet @ref=SpreadsheetInstance DataSource="DataSourceBytes">
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

    public async Task CutActiveCell()
    {
        // To cut from the current cell.
        await SpreadsheetInstance.CutCellAsync();
    }
}

{% endhighlight %}
{% endtabs %}

**Cut specific range in active sheet**

To cut content from specific cells in the current active sheet, provide cell address as a parameter to the `CutCellAsync` method. When you specify a cell or range, the Spreadsheet component will cut that content and place it on the clipboard, ready for pasting elsewhere.

| Parameter   | Type              | Description |
|-------------|-------------------|-------------|
| cellAddress | string (optional) | Specifies which cell(s) to cut. Accepts either a single cell reference (e.g., `"A1"`) or a range (e.g., `"A1:B5"`) from the active sheet. If not provided, the currently selected cell or range will be cut. |

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Spreadsheet

<button @onclick="CutCell">Cut Cell</button>
<button @onclick="CutRange">Cut Range</button>

<SfSpreadsheet @ref=SpreadsheetInstance DataSource="DataSourceBytes">
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

    public async Task CutCell()
    {
        // To cut the specified cell.
        await SpreadsheetInstance.CutCellAsync("A2"); 
    }

    public async Task CutRange()
    {
        // To cut a range of cells.
        await SpreadsheetInstance.CutCellAsync("A1:D10");
    }
}

{% endhighlight %}
{% endtabs %}

**Cut specific range in different sheet**

To cut content from a specific sheet, include the source sheet name along with the cell reference in the parameter to the `CutCellAsync()` method. When specifying a sheet name, use an exclamation mark (`!`) to separate it from the cell reference, and the Spreadsheet component will cut that content and place it on the clipboard, ready for pasting elsewhere.

| Parameter   | Type              | Description |
|-------------|-------------------|-------------|
| cellAddress | string (optional) | Specifies which cell(s) to cut. Accepts either a single cell reference (e.g., `"Sheet1!A1"`) or a range (e.g., `"Sheet2!A1:C5"`) from a specific sheet. If not provided, the currently selected cell or range will be cut. |

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Spreadsheet

<button @onclick="CutCellFromSpecificSheet">Cut Cell from Specific Sheet</button>
<button @onclick="CutRangeFromSpecificSheet">Cut Range from Specific Sheet</button>

<SfSpreadsheet @ref=SpreadsheetInstance DataSource="DataSourceBytes">
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

    public async Task CutCellFromSpecificSheet()
    {
        // The address, along with the sheet name, to be cut.
        await SpreadsheetInstance.CutCellAsync("Sheet1!B2");
    }

    public async Task CutRangeFromSpecificSheet()
    {
        // To cut a range from a specific sheet.
        await SpreadsheetInstance.CutCellAsync("Sheet2!B3:E8");
    }
}

{% endhighlight %}
{% endtabs %}

## Copy

The copy operation duplicates data from a selected range of cells, rows, or columns within a sheet and temporarily stores it on the clipboard for use elsewhere. Unlike the **Cut** operation, copying retains the original content in its location.

### Copy operations via UI

The copy operation can be performed through the user interface (UI) using any of the following methods:

**Using the Ribbon**

- Select the cell or range to copy.
- Click the **Copy** button in the **Home** tab of the **Ribbon** toolbar. This will copy the current active cell or range.

![Copy - Ribbon](images/cut-copy.png)

**Using the Context Menu**

- Select the cell or range to copy.
- Right-click on the selected cell or range.
- Choose the **Copy** option from the context menu.

![Copy - Context Menu](images/contextmenu-cut-copy.png)

### Copy operations programmatically

The [CopyCellAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Spreadsheet.SfSpreadsheet.html#Syncfusion_Blazor_Spreadsheet_SfSpreadsheet_CopyCellAsync_System_String_) method enables performing copy operations within any sheet. This method copies the specified cell or range along with its properties (including value, format, style, etc.) to the clipboard. It supports multiple scenarios for copying cells or ranges. Below are the details for each scenario, including code examples and parameter information.

> The copy operation will not execute if invalid or out-of-boundary cell ranges are provided. Ensure that all cell addresses fall within the valid worksheet boundaries.

**Copy active range**

When this method is called without any parameters, the method automatically copies the content from the last selected range if an active selection exists. If no range is selected, it copies the active cell.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Spreadsheet

<button @onclick="CopyActiveCell">Copy Active Cell</button>

<SfSpreadsheet @ref=SpreadsheetInstance DataSource="DataSourceBytes">
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

    public async Task CopyActiveCell()
    {
        // To copy from the current cell.
        await SpreadsheetInstance.CopyCellAsync();
    }
}

{% endhighlight %}
{% endtabs %}

**Copy specific range in active sheet**

To copy content from specific cells in the current active sheet, provide cell address as a parameter to the `CopyCellAsync` method. When you specify a cell or range, the Spreadsheet component will copy that content and place it on the clipboard, ready for pasting elsewhere.

| Parameter   | Type              | Description |
|-------------|-------------------|-------------|
| cellAddress | string (optional) | Specifies which cell(s) to copy. Accepts either a single cell from the active sheet (e.g., `"A1"`) or a cell range (e.g., `"A1:B5"`). If not provided, the currently selected cell or range will be copied. |

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Spreadsheet

<button @onclick="CopyCell">Copy Cell</button>
<button @onclick="CopyRange">Copy Range </button>

<SfSpreadsheet @ref=SpreadsheetInstance DataSource="DataSourceBytes">
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

    public async Task CopyCell()
    {
        // To copy the specified cell.
        await SpreadsheetInstance.CopyCellAsync("A2"); 
    }

    public async Task CopyRange()
    {
        // To copy a range of cells.
        await SpreadsheetInstance.CopyCellAsync("A1:D10");
    }
}

{% endhighlight %}
{% endtabs %}

**Copy specific range in different sheet**

To copy content from a specific sheet, include the source sheet name along with the cell reference in the parameter to the `CopyCellAsync` method. When specifying a sheet name, use an exclamation mark (`!`) to separate it from the cell reference, and the Spreadsheet component will copy that content and place it on the clipboard, ready for pasting elsewhere.

| Parameter   | Type              | Description |
|-------------|-------------------|-------------|
| cellAddress | string (optional) | Specifies which cell(s) to copy. Accepts either a single cell from a specific sheet (e.g., `"Sheet1!A1"`) or a cell range (e.g., `"Sheet2!A1:C5"`). If not provided, the currently selected cell or range will be copied. |

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Spreadsheet

<button @onclick="CopyCellFromSpecificSheet">Copy Cell from Specific Sheet</button>
<button @onclick="CopyRangeFromSpecificSheet">Copy Range from Specific Sheet</button>

<SfSpreadsheet @ref=SpreadsheetInstance DataSource="DataSourceBytes">
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

    public async Task CopyCellFromSpecificSheet()
    {
        // The address, along with the sheet name, to be copied.
        await SpreadsheetInstance.CopyCellAsync("Sheet1!B2");
    }

    public async Task CopyRangeFromSpecificSheet()
    {
        // To copy a range from a specific sheet.
        await SpreadsheetInstance.CopyCellAsync("Sheet2!B3:E8");
    }
}

{% endhighlight %}
{% endtabs %}

## Paste

The paste operation inserts data from the clipboard into a selected range of cells, rows, or columns, retaining all relevant details such as values, formats, and styles. When performing a **Cut** followed by **Paste**, the clipboard is cleared after the data is transferred. In contrast, with a **Copy** followed by **Paste**, the clipboard contents remain available for reuse. 

External clipboard support is also provided, enabling users to paste content not only from within the spreadsheet but also from outside sources such as Google Sheets, Microsoft Excel, Word documents, plain text files, and web pages.

### Paste operations via UI

The paste operation can be performed through the user interface (UI) using any of the following methods:

**Using the Ribbon**

- Select a range of cells or click on a cell.
- Click the **Paste** button in the **Home** tab of the **Ribbon** toolbar. This will paste the values that were cut or copied from the clipboard into the selected range. If no values are on the clipboard, the **Paste** option will be disabled.

![Paste - Ribbon](./images/cutcopypaste.png)

**Using the Context Menu**

- Select a range of cells or click on a cell.
- Right-click and choose the **Paste** option from the context menu. If no values are on the clipboard, the **Paste** option will be disabled.

![Paste - Context Menu](./images/contextcutcopypaste.png)

### Paste operations programmatically

The [PasteCellAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Spreadsheet.SfSpreadsheet.html#Syncfusion_Blazor_Spreadsheet_SfSpreadsheet_PasteCellAsync_System_String_) method pastes the clipboard content into a specified cell or range and preserves all associated properties (including value, format, style, etc.).

> The paste operation will not execute if invalid or out-of-boundary cell ranges are provided. Ensure that all cell addresses fall within the valid worksheet boundaries.

**Paste to active range**

When this method is called without any parameters, it automatically pastes the content to the last selected range if an active selection exists. If no range is selected, it pastes to the active cell.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Spreadsheet

<button @onclick="PasteActiveCell">Paste to Active Cell</button>

<SfSpreadsheet @ref=SpreadsheetInstance DataSource="DataSourceBytes">
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

    public async Task PasteActiveCell()
    {
        // To paste to the current cell.
        await SpreadsheetInstance.PasteCellAsync();
    }
}

{% endhighlight %}
{% endtabs %}

**Paste to specific range in active sheet**

To paste content into specific range in the current active sheet, provide the target cell address as a parameter to the `PasteCellAsync` method. You can specify either a single cell or a range of cells as the destination. When the source range (copied content) is larger than the specified target range, all data from the source will still be pasted, automatically extending beyond the specified target boundaries to accommodate all content.

| Parameter   | Type              | Description |
|-------------|-------------------|-------------|
| cellAddress | string (optional) | Specifies the target cell(s) for pasting clipboard content. Accepts either a single cell (e.g., `"A1"`) or a cell range (e.g., `"A1:B5"`) from the active sheet. If not provided, the currently selected cell or range will be used as the paste destination. |

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Spreadsheet

<button @onclick="PasteCell">Paste Cell</button>
<button @onclick="PasteRange">Paste Range</button>
<button @onclick="CopyLargerRangeThanTarget">Copy Large Range to Smaller Target</button>

<SfSpreadsheet @ref=SpreadsheetInstance DataSource="DataSourceBytes">
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

    public async Task PasteCell()
    {
        // To paste to the specified cell.
        await SpreadsheetInstance.PasteCellAsync("A2"); 
    }

    public async Task PasteRange()
    {
        // To paste to the specified range.
        await SpreadsheetInstance.PasteCellAsync("A2:B5"); 
    }
    
    // Copy a large range and paste to smaller range.
    public async Task CopyLargerRangeThanTarget()
    {
        // Copy a 7-row range.
        await SpreadsheetInstance.CopyCellAsync("F3:F9");
        
        // Paste to a smaller 3-row range. All 7 rows will be pasted, extending beyond the specified range.
        await SpreadsheetInstance.PasteCellAsync("A5:A7");
    }
}

{% endhighlight %}
{% endtabs %}

**Paste to specific range in different sheet**

To paste content into a specific sheet, include the target sheet name along with the cell reference as a parameter to the `PasteCellAsync` method. When specifying a sheet name, use an exclamation mark (!) to separate it from the cell reference. When the source range (copied content) is larger than the specified target range, all data will still be pasted completely, extending beyond the specified target boundaries to accommodate all content.

| Parameter   | Type              | Description |
|-------------|-------------------|-------------|
| cellAddress | string (optional) | Specifies the target cell(s) for pasting clipboard content. Accepts either a single cell from a specific sheet (e.g., `"Sheet1!A1"`) or a cell range (e.g., `"Sheet2!A1:C5"`). If not provided, the currently selected cell or range will be used as the paste destination. |

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Spreadsheet

<button @onclick="CopyPasteCellBetweenSheets">Copy and Paste: Cell between Sheets</button>
<button @onclick="CopyPasteRangeBetweenSheets">Copy and Paste: Range between Sheets</button>

<SfSpreadsheet @ref=SpreadsheetInstance DataSource="DataSourceBytes">
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

    public async Task CopyPasteCellBetweenSheets()
    {
        // The address, along with the sheet name, to be pasted.
        await SpreadsheetInstance.PasteCellAsync("Sheet1!B2");
    }

    // Copy from one sheet and paste to another without switching sheets.
    public async Task CopyPasteRangeBetweenSheets()
    {
        // Copy value from "Sheet1".
        await SpreadsheetInstance.CopyCellAsync("Sheet1!A1:A5");
        
        // Paste to "Sheet2" without switching to it.
        await SpreadsheetInstance.PasteCellAsync("Sheet2!C3");
    }
}

{% endhighlight %}
{% endtabs %}

## Events

The Syncfusion Blazor Spreadsheet provides two events that are triggered during the clipboard action such as [CutCopyActionBegin](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Spreadsheet.CutCopyActionBeginEventArgs.html) and  [Pasting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Spreadsheet.PastingEventArgs.html). These events can be used to perform any custom actions before the clipboard action starts.

* **CutCopyActionBegin** - [CutCopyActionBegin](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Spreadsheet.CutCopyActionBeginEventArgs.html) event is triggered before a cut or copy operation begins.
* **Pasting** - [Pasting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Spreadsheet.PastingEventArgs.html) event is triggered before a paste operation begins.

**CutCopyActionBegin Event**

The `CutCopyActionBegin` event is triggered before a cut or copy operation begins. This event provides details about the operation and allows for cancellation if required.


**Event Arguments**

The `CutCopyActionBeginEventArgs` includes the following properties:

| Event Arguments | Description |
|----------------|-------------|
| Action | An enum value from the ClipboardAction class that indicates whether the operation is `ClipboardAction.Cut` or `ClipboardAction.Copy`. |
| CopiedRange | A string representing the range being copied, including the sheet name (e.g., "Sheet1!A1:B5"). |
| Cancel | A boolean value that can be set to true to prevent the operation. |

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
 
@using Syncfusion.Blazor.Spreadsheet

<SfSpreadsheet @ref="SpreadsheetInstance" DataSource="DataSourceBytes">
    <SpreadsheetRibbon></SpreadsheetRibbon>
    <SpreadsheetEvents CutCopyActionBegin="OnCutCopyActionBegin" ></SpreadsheetEvents>
</SfSpreadsheet>
 
@code {
    public byte[] DataSourceBytes { get; set; }
    public SfSpreadsheet SpreadsheetInstance { get; set; }

    protected override void OnInitialized()
    {
        string filePath = "wwwroot/Sample.xlsx";
        DataSourceBytes = File.ReadAllBytes(filePath);
    }

    public void OnCutCopyActionBegin(CutCopyActionBeginEventArgs args)
    {
        // To cancel the cut or copy action.
        args.Cancel = true;
    }
}
 
{% endhighlight %}
{% endtabs %}

**Pasting Event**

The `Pasting` event is triggered before a paste operation begins. It provides information about the paste operation and allows you to validate or cancel it.

**Event Arguments**

The `PastingEventArgs` includes the following properties:

| Event Arguments | Description |
|----------------|-------------|
| ExternalClipboardData | An array of strings containing raw text data from external sources (like Excel or Google Sheets), with each element representing a row of data. Set to null when copying from within the workbook. |
| CopiedRange | A string in the format "SheetName!Range" (e.g., "Sheet1!A1:A10") representing the source location of the copied or cut content. Set to null when pasting external content. |
| PasteRange | A string in the format "SheetName!Range" specifying the target cell range where content will be pasted. |
| Cancel | A boolean value that can be set to true to prevent the paste operation, allowing event handlers to control the paste behavior. The default value is <c>false</c>. |

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
 
@using Syncfusion.Blazor.Spreadsheet

<SfSpreadsheet @ref="SpreadsheetInstance" DataSource="DataSourceBytes">
    <SpreadsheetRibbon></SpreadsheetRibbon>
    <SpreadsheetEvents Pasting="OnBeforePaste" ></SpreadsheetEvents>
</SfSpreadsheet>
 
@code {
    public byte[] DataSourceBytes { get; set; }
    public SfSpreadsheet SpreadsheetInstance { get; set; }

    protected override void OnInitialized()
    {
        string filePath = "wwwroot/Sample.xlsx";
        DataSourceBytes = File.ReadAllBytes(filePath);
    }

    public void OnBeforePaste(PastingEventArgs args)
    {
        // Prevent pasting into a specific range
        if (args.PasteRange.Contains("A1:B5"))
        {
            args.Cancel = true;
        }

        // Validate external content
        if (args.ExternalClipboardData != null)
        {
            foreach (var line in args.ExternalClipboardData)
            {
                if (line.Contains("Confidential"))
                {
                    args.Cancel = true;
                    break;
                }
            }
        }
    }
}
 
{% endhighlight %}
{% endtabs %}