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

The keyboard shortcuts are available to perform clipboard operations efficiently within the Spreadsheet component. `Ctrl+C` copies the selected cells, `Ctrl+X` cuts the selected cells, and `Ctrl+V` pastes the content from the clipboard.

When `EnableClipboard` is set to **false**, the **Cut** and **Copy** options are removed from the user interface (Ribbon and Context Menu). In addition, shortcut keys (**Ctrl+C, Ctrl+X, Ctrl+V**) and API methods will not work. If the worksheet is protected, clipboard operations such as cut and paste are also disabled. For more information on worksheet protection, refer [here](https://blazor.syncfusion.com/documentation/spreadsheet/protection#protect-sheet).

## Cut

The **Cut** operation removes data from selected cells, rows, or columns within a worksheet and temporarily stores the content on the clipboard. When the content is pasted to a new location, the original data is deleted from its source. This behavior enables the relocation of content within the Spreadsheet.

### Cut operations via UI

The **Cut** operation can be performed through the user interface (UI) using any of the following methods:

**Using the Ribbon**

- Select a cell or range of cells to cut the content.
- Click the **Cut** button in the **Home** tab of the **Ribbon** toolbar. This action removes the selected cell or range of cells and places the content on the clipboard.

![Cut - Ribbon](images/cut-copy.png)

**Using the Context Menu**

- Select a cell or range of cells to cut the content.
- Right-click on the selected cell or range of cells.
- Choose the **Cut** option from the context menu.

![Cut - Context Menu](images/contextmenu-cut-copy.png)

### Cut operations programmatically

The [CutCellAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Spreadsheet.SfSpreadsheet.html#Syncfusion_Blazor_Spreadsheet_SfSpreadsheet_CutCellAsync_System_String_) method allows performing cut operations within any sheet. This method copies the specified cell or range and its properties (including value, format, style, etc.) to the clipboard and removes it from the sheet. It supports multiple scenarios for cutting cells or ranges. Below are the details for each scenario, including code examples and parameter information.

> The **Cut** operation will not execute if invalid or out-of-boundary cell ranges are specified. All cell references must fall within the defined worksheet boundaries to ensure successful execution of the operation.

**Cut active range**

When `CutCellAsync` method is invoked without any parameters, the content is automatically cut from the most recently selected range, provided an active selection exists. If no range is currently selected, the method defaults to cutting the content from the active cell.

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
        // Cuts content from the currently active cell or selected range in the active worksheet.
        await SpreadsheetInstance.CutCellAsync();
    }
}

{% endhighlight %}
{% endtabs %}

**Cut specific range in active sheet**

To cut content from specific cells in the active worksheet, a cell address or a range of cell addresses must be passed as a parameter to the `CutCellAsync` method. When a valid cell or range is specified, the Spreadsheet component cuts the corresponding content and places it on the clipboard, making it available for pasting in another location.

The available parameters in the `CutCellAsync` method are:

| Parameter   | Type              | Description |
|-------------|-------------------|-------------|
| cellAddress | string (optional) | Specifies the target cell or range of cells to be cut. Accepts either a single cell reference (for example, **"A1"**) or a range (for example, **"A1:B5"**) from the active worksheet. If no parameter is provided, the currently selected cell or range will be used for the **Cut** operation. |

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
        // Cuts the specified cell from the active worksheet.
        await SpreadsheetInstance.CutCellAsync("A2"); 
    }

    public async Task CutRange()
    {
        // Cuts a specified range of cells from the active worksheet.
        await SpreadsheetInstance.CutCellAsync("A1:D10");
    }
}

{% endhighlight %}
{% endtabs %}

**Cut specific range in different sheet**

To cut content from a specific worksheet, the source sheet name must be included along with the cell reference in the parameter passed to the `CutCellAsync` method. When specifying a sheet name, an exclamation mark (**!**) must be used to separate the sheet name from the cell reference. Upon execution, the Spreadsheet component cuts the designated content and places it on the clipboard, making it available for pasting in another location.

The available parameters in the `CutCellAsync` method are:

| Parameter   | Type              | Description |
|-------------|-------------------|-------------|
| cellAddress | string (optional) | Specifies the cell or range of cells to be cut. Accepts either a single cell reference (for example, **"Sheet1!A1"**) or a range (for example, **"Sheet2!A1:C5"**) from a specific worksheet. If no parameter is provided, the currently selected cell or range from the active worksheet will be used for the cut operation. |

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
        
        // Specifies the address, along with the worksheet name, from which the content will be cut.
        await SpreadsheetInstance.CutCellAsync("Sheet1!B2");
    }

    public async Task CutRangeFromSpecificSheet()
    {
        // Cuts a specified range from a specific worksheet.
        await SpreadsheetInstance.CutCellAsync("Sheet2!B3:E8");
    }
}

{% endhighlight %}
{% endtabs %}

## Copy

The **Copy** operation duplicates data from a selected range of cells, rows, or columns within a worksheet and temporarily stores it on the clipboard. Unlike the **Cut** operation, copying retains the original content in its source location, allowing the data to be reused without modification.

### Copy operations via UI

The copy operation can be performed through the user interface (UI) using any of the following methods:

**Using the Ribbon**

- Select the cell or range of cells to copy.
- Click the **Copy** button in the **Home** tab of the **Ribbon** toolbar. This action duplicates the selected cell or range of cells and places the content on the clipboard.

![Copy - Ribbon](images/cut-copy.png)

**Using the Context Menu**

- Select the cell or range of cells to copy.
- Right-click on the selected cell or range of cells.
- Choose the **Copy** option from the context menu.

![Copy - Context Menu](images/contextmenu-cut-copy.png)

### Copy operations programmatically

The [CopyCellAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Spreadsheet.SfSpreadsheet.html#Syncfusion_Blazor_Spreadsheet_SfSpreadsheet_CopyCellAsync_System_String_) method enables performing copy operations within any sheet. This method copies the specified cell or range of cells along with its properties (including value, format, style, etc.) to the clipboard. It supports multiple scenarios for copying cells or ranges. Below are the details for each scenario, including code examples and parameter information.

> The **Copy** operation will not execute if invalid or out-of-boundary cell ranges are specified. All cell addresses must fall within the valid boundaries of the worksheet to ensure successful execution of the operation.

**Copy active range**

When `CopyCellAsync` method is invoked without any parameters, the content is automatically copied from the most recently selected range, provided an active selection exists. If no range is selected, the method defaults to copying the content from the active cell.

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
        // Copies content from the currently active cell or selected range in the active worksheet.
        await SpreadsheetInstance.CopyCellAsync();
    }
}

{% endhighlight %}
{% endtabs %}

**Copy specific range in active sheet**

To copy content from specific cells in the active worksheet, a cell address or a range of cell addresses must be provided as a parameter to the `CopyCellAsync` method. When a valid cell or range is specified, the Spreadsheet component copies the corresponding content and places it on the clipboard, making it available for pasting in another location.

The available parameters in the `CopyCellAsync` method are:

| Parameter   | Type              | Description |
|-------------|-------------------|-------------|
| cellAddress | string (optional) | Specifies the cell or range of cells to be copied. Accepts either a single cell reference from the active worksheet (for example, **"A1"**) or a range (for example, **"A1:B5"**). If no parameter is provided, the currently selected cell or range will be used for the copy operation. |

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
        // The specified cell is copied from the active worksheet.
        await SpreadsheetInstance.CopyCellAsync("A2"); 
    }

    public async Task CopyRange()
    {
        // A specified range of cells is copied from the active worksheet.
        await SpreadsheetInstance.CopyCellAsync("A1:D10");
    }
}

{% endhighlight %}
{% endtabs %}

**Copy specific range in different sheet**

To copy content from a specific worksheet, the source sheet name must be included along with the cell reference in the parameter passed to the `CopyCellAsync` method. When specifying the sheet name, an exclamation mark (**!**) is used to separate it from the cell reference. The Spreadsheet component performs the copy operation and places the content on the clipboard, making it available for pasting into another location.

The available parameters in the `CopyCellAsync` method are:

| Parameter   | Type              | Description |
|-------------|-------------------|-------------|
| cellAddress | string (optional) | Specifies the cell or range of cells to be copied. Accepts either a single cell reference from a specific worksheet (for example, **"Sheet1!A1"**) or a range of cells (for example, **"Sheet2!A1:C5"**). If no value is provided, the currently selected cell or range from the active worksheet will be used for the copy operation. |

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
        // The cell address, including the sheet name, is copied from the specified worksheet.
        await SpreadsheetInstance.CopyCellAsync("Sheet1!B2");
    }

    public async Task CopyRangeFromSpecificSheet()
    {
        // A specified range of cells is copied from the designated worksheet.
        await SpreadsheetInstance.CopyCellAsync("Sheet2!B3:E8");
    }
}

{% endhighlight %}
{% endtabs %}

## Paste

The paste operation inserts data from the clipboard into a selected range of cells, rows, or columns, retaining all relevant details such as values, formats, and styles. When performing a **Cut** followed by **Paste**, the clipboard is cleared after the data is transferred. In contrast, with a **Copy** followed by **Paste**, the clipboard contents remain available for reuse. 

**External clipboard** support is provided, allowing content to be pasted not only from within the spreadsheet but also from external sources such as Google Sheets, Microsoft Excel, Word documents, plain text files, and web pages.

### Paste operations via UI

The paste operation can be performed through the user interface (UI) using any of the following methods:

**Using the Ribbon**

- A cell must be selected or a range of cells highlighted before initiating the paste operation.
- The **Paste** button located in the **Home** tab of the **Ribbon** toolbar must be clicked to perform the paste action.
- The values previously cut or copied from the clipboard will be inserted into the selected range.
- If the clipboard does not contain any values, the **Paste** option will remain disabled.

![Paste - Ribbon](./images/cutcopypaste.png)

**Using the Context Menu**

- A cell must be clicked or a range of cells selected before initiating the paste operation.
- The **Paste** option must be selected from the context menu accessed via right-click.
- The values previously cut or copied from the clipboard will be inserted into the selected range.
- If the clipboard does not contain any values, the **Paste** option will remain disabled.

![Paste - Context Menu](./images/contextcutcopypaste.png)

### Paste operations programmatically

The [PasteCellAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Spreadsheet.SfSpreadsheet.html#Syncfusion_Blazor_Spreadsheet_SfSpreadsheet_PasteCellAsync_System_String_) method pastes the clipboard content into a specified cell or range of cells and preserves all associated properties (including value, format, style, etc.). When the source range is larger than the specified target range, all data from the source will still be pasted. The paste operation automatically extends beyond the defined target boundaries and overrides the content in the expanded area to match the full dimensions of the source.

**Example**
- Source Range: **"Sheet1!A1:C3"** (3 rows × 3 columns)
- Target Range: **"Sheet2!B2"** (single cell)

In this case, although only a single cell is selected as the target, the paste operation overrides the range **"Sheet2!B2:D4"** to match the full 3×3 source content.

> The **Paste** operation will not be executed if invalid or out-of-boundary cell ranges are specified. All cell addresses must fall within the valid boundaries of the worksheet to ensure successful execution of the paste action.

**Paste to active range**

When the `PasteCellAsync` method is invoked without any parameters, the content is automatically pasted into the last selected range, provided an active selection exists. If no range is selected, the content is pasted into the active cell.

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
        // The content is pasted into the currently active cell or range.
        await SpreadsheetInstance.PasteCellAsync();
    }
}

{% endhighlight %}
{% endtabs %}

**Paste to specific range in active sheet**

To paste content into specific range in the current active sheet, provide the target cell address as a parameter to the `PasteCellAsync` method. A valid cell selection must exist prior to executing the paste operation. Either a single cell or a range of cells can be specified as the destination.

The available parameters in the `PasteCellAsync` method are:

| Parameter   | Type              | Description |
|-------------|-------------------|-------------|
| cellAddress | string (optional) | Specifies the target cell or range of cells for pasting clipboard content. Accepts either a single cell reference (for example, **"A1"**) or a range of cells (for example, **"A1:B5"**) from the active worksheet. A valid cell selection must exist prior to executing the paste operation. If no parameter is provided, the currently selected cell or range will be used as the paste destination. |

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Spreadsheet

<button @onclick="PasteCell">Paste Cell</button>
<button @onclick="PasteRange">Paste Range</button>
<button @onclick="CopyAndPasteOversizedRange">Copy and Paste Oversized Range</button>

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
        // The clipboard content is pasted into the specified cell.
        await SpreadsheetInstance.PasteCellAsync("A2"); 
    }

    public async Task PasteRange()
    {
        // The clipboard content is pasted into the specified range of cells.
        await SpreadsheetInstance.PasteCellAsync("A2:B5"); 
    }
    
    // A larger source range is copied and pasted into a smaller target range.
    public async Task CopyAndPasteOversizedRange()
    {
        // A range containing 7 rows is copied from the source.
        await SpreadsheetInstance.CopyCellAsync("F3:F9");
        
        // The content is pasted into a smaller 3-row target range. All 7 rows will be pasted, extending beyond the specified range.
        await SpreadsheetInstance.PasteCellAsync("A5:A7");
    }
}

{% endhighlight %}
{% endtabs %}

**Paste to specific range in different sheet**

To paste content into a specific sheet, include the target sheet name along with the cell reference as a parameter to the `PasteCellAsync` method. When specifying a sheet name, use an exclamation mark (**!**) to separate it from the cell reference.

The available parameters in the `PasteCellAsync` method are:

| Parameter   | Type              | Description |
|-------------|-------------------|-------------|
| cellAddress | string (optional) | Specifies the target cell or range of cells for pasting clipboard content. Accepts either a single cell reference from a specific worksheet (for example, **"Sheet1!A1"**) or a range of cells (for example, **"Sheet2!A1:C5"**). A valid cell selection must exist before executing the paste operation. If no parameter is provided, the currently selected cell or range will be used as the paste destination. |

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Spreadsheet

<button @onclick="PasteCellToTargetSheet">Paste</button>

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

    public async Task PasteCellToTargetSheet()
    {
        // The cell address, including the sheet name, is used as the paste destination
        await SpreadsheetInstance.PasteCellAsync("Sheet1!B2");
    }    
}

{% endhighlight %}
{% endtabs %}

## Events

The Blazor Spreadsheet provides events that are triggered during the clipboard action such as [CutCopyActionBegin](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Spreadsheet.CutCopyActionBeginEventArgs.html) and  [Pasting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Spreadsheet.PastingEventArgs.html). These events can be used to perform any custom actions before the clipboard action starts or interacted with, allowing for validation, customization, and response handling.

* **CutCopyActionBegin** - `CutCopyActionBegin` event is triggered before a cut or copy operation is initiated.
* **Pasting** - `Pasting` event is triggered prior to the initiation of a paste operation.

### CutCopyActionBegin

The `CutCopyActionBegin` event is triggered before a copy or cut operation is performed in the spreadsheet. This event allows inspection, validation, or cancellation of the operation based on custom business logic.

**Purpose**

This event addresses scenarios that require monitoring or restriction of clipboard operations, such as preventing sensitive data from being copied, logging clipboard activities for audit and compliance purposes, enforcing custom validation rules for designated cells or ranges, and restricting cut operations while allowing copy functionality.

**Event Arguments**

The `CutCopyActionBeginEventArgs` includes the following properties:

| Event Arguments | Description |
|----------------|-------------|
| ClipboardAction | Specifies the type of clipboard operation in progress. Returns a value from the **ClipboardAction** enumeration, such as **ClipboardAction.Cut** or **ClipboardAction.Copy**. |
| CopiedRange | Represents the full address of the cell range involved in the clipboard operation. Includes the worksheet name and range in A1 notation (e.g., **"Sheet1!A1:B5"**). |
| Cancel | Indicates whether the clipboard operation should be cancelled. Set to **true** to prevent the cut or copy action from proceeding. |

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
 
@using Syncfusion.Blazor.Spreadsheet

<SfSpreadsheet DataSource="DataSourceBytes">
    <SpreadsheetRibbon></SpreadsheetRibbon>
    <SpreadsheetEvents CutCopyActionBegin="OnCutCopyActionBegin" ></SpreadsheetEvents>
</SfSpreadsheet>
 
@code {
    public byte[] DataSourceBytes { get; set; }
    
    protected override void OnInitialized()
    {
        string filePath = "wwwroot/Sample.xlsx";
        DataSourceBytes = File.ReadAllBytes(filePath);
    }

    public void OnCutCopyActionBegin(CutCopyActionBeginEventArgs args)
    {
        // Cancels the cut or copy operation.
        args.Cancel = true;
    }
}
 
{% endhighlight %}
{% endtabs %}

### Pasting

The `Pasting` event is triggered before data is pasted into the spreadsheet. This event allows inspection and validation of the paste operation before it is completed, with options to modify or cancel the operation entirely.

**Purpose**

This event is applicable in scenarios that require control over paste operations, such as validating data before allowing paste actions, restricting paste functionality to specific worksheets or cell ranges, applying data transformation rules during paste execution, and enforcing data integrity through oversight of paste operations.

**Event Arguments**

The `PastingEventArgs` includes the following properties:

| Event Arguments | Description |
|----------------|-------------|
| ExternalClipboardData | An array of strings containing raw text data from external sources (like Excel or Google Sheets), with each element representing a row of data. Set to **null** when copying from within the workbook. |
| CopiedRange | A string in the format **"SheetName!Range"** (e.g., **"Sheet1!A1:A10"**) representing the source location of the copied or cut content. Set to **null** when pasting external content. |
| PasteRange | A string in the format **"SheetName!Range"** specifying the target cell range where content will be pasted. |
| Cancel | A boolean value that can be set to **true** to prevent the paste operation, allowing event handlers to control the paste behavior. The default value is **false**. |

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
 
@using Syncfusion.Blazor.Spreadsheet

<SfSpreadsheet DataSource="DataSourceBytes">
    <SpreadsheetRibbon></SpreadsheetRibbon>
    <SpreadsheetEvents Pasting="OnPasting" ></SpreadsheetEvents>
</SfSpreadsheet>
 
@code {
    public byte[] DataSourceBytes { get; set; }   

    protected override void OnInitialized()
    {
        string filePath = "wwwroot/Sample.xlsx";
        DataSourceBytes = File.ReadAllBytes(filePath);
    }

    public void OnPasting(PastingEventArgs args)
    {
        // Cancels the paste operation if the target range includes "A1:B5".
        if (args.PasteRange.Contains("A1:B5"))
        {
            args.Cancel = true;
        }

        // Checks external clipboard data for restricted content.
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