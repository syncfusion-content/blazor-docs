---
layout: post
title: Managing Cell Ranges in Blazor Spreadsheet component | Syncfusion
description: Checkout and learn to manage cell range features such as formatting, autofill, and clear options in the Syncfusion Blazor Spreadsheet component and more.
platform: Blazor
control: Spreadsheet
documentation: ug
---

# Managing Cell Ranges in Blazor Spreadsheet component

A cell range in the Spreadsheet component refers to a group of selected cells that can be manipulated or processed collectively. Cell ranges are used for applying formatting, performing autofill operations, or clearing content, enabling efficient data management and presentation.

## Cell formatting

Cell formatting enhances the visual presentation of data within the Spreadsheet component by applying styles to individual cells or cell ranges. Styles include font modifications, colors, borders, and alignment, which help organize and emphasize critical information effectively. Formatting options improve readability, create visual hierarchies, and highlight key data points.

N> To enable formatting options in a protected sheet, the **Format cells** checkbox must be selected in the protection dialog sheet options. To know more about worksheet protection settings, refer [here](https://blazor.syncfusion.com/documentation/spreadsheet/protection#protection-settings-in-a-protected-sheet) 

### Available formatting options

Formatting options in the Spreadsheet component include several stylistic and positional attributes, each serving a specific purpose in data presentation. These options are accessible through the Ribbon toolbar under the **Home** tab.

**Bold**

Bold formatting applies a heavier font weight to text within selected cells. This style makes text stand out, often used to emphasize headers or critical values in the Spreadsheet component.

**Italic**

Italic formatting slants text to create a distinct appearance. This style is commonly applied to highlight differences or provide emphasis within a cell range.

**Underline**

Underline formatting adds a line beneath the text. This style is typically used to indicate hyperlinks or to emphasize specific content within the Spreadsheet component.

**Strikethrough**

Strikethrough formatting draws a horizontal line through the text. This style is often used to mark completed tasks or indicate outdated information in a cell range.

**Font Family**

Font family changes the typeface of text, such as Arial, Calibri, or Times New Roman. Different typefaces enhance readability or align with specific visual design requirements in the Spreadsheet.

**Font Size**

Font size adjustments modify the text size to create a visual hierarchy or improve readability. Larger sizes are often used for headers, while smaller sizes suit detailed data entries.

**Font Color**

Font color changes the text color to improve visual organization or apply color-coded categorization. This formatting option helps differentiate data types or highlight specific values.

**Fill Color**

Fill color applies a background color to cells. This formatting option visually organizes data or highlights critical information, making it easier to identify key areas in the Spreadsheet.

**Horizontal Alignment**

Horizontal alignment controls the left-to-right positioning of content within a cell. Available options include:

* **Left** - Aligns content to the left side, typically used for text data.

* **Center** - Positions content in the middle, often applied to headings.

* **Right** - Aligns content to the right, commonly used for numerical data.

**Vertical Alignment**

Vertical alignment adjusts the top-to-bottom positioning of content within a cell. Available options include:

* **Top** – Aligns content to the top of the cell, useful for multiline text.
    
* **Middle** – Centers content vertically, often used for balanced presentation.

* **Bottom** – Aligns content to the bottom, serving as the default alignment.

**Wrap Text**

Wrap text formatting displays long content across multiple lines within a single cell. This prevents content from overflowing into adjacent cells, maintaining a clean layout.

## Autofill

Autofill functionality in the Spreadsheet component enables filling cells with data based on patterns derived from adjacent cells. This feature eliminates the need for manual entry of repetitive data, improving efficiency. The [AllowAutofill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Spreadsheet.SfSpreadsheet.html#Syncfusion_Blazor_Spreadsheet_SfSpreadsheet_AllowAutofill) property controls whether autofill is enabled. By default, this property is set to **true**.

> * If the `AllowAutofill` property is set to **false**, the autofill fill handle is not displayed in the UI, and programmatic autofill operations using the [AutofillAsync()](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Spreadsheet.SfSpreadsheet.html#Syncfusion_Blazor_Spreadsheet_SfSpreadsheet_AutofillAsync_System_String_System_String_System_String_) method will not execute.
> * If the sheet is protected, autofill is only applicable to unlocked ranges when performed through the UI or programmatically. To know more about worksheet protection, refer [here](https://blazor.syncfusion.com/documentation/spreadsheet/protection#protect-sheet).

Autofill can be performed in two ways: through the user interface (UI) by dragging the fill handle or programmatically using the `AutofillAsync` method.

### Autofill via UI

Autofill can be performed in the UI by dragging the fill handle, a small square at the bottom-right corner of a selected cell or range, which serves as the control point for initiating autofill operations. The following steps outline the process:

* Select a cell or range containing the data to be used as the source for autofill.

* Hover over the fill handle until the cursor changes to a crosshair, a plus-shaped pointer, indicating that the fill handle is ready to be dragged.

* Drag the fill handle in the desired direction (up, down, left, or right) to fill the target range with data based on the source pattern.

This method automatically detects patterns, such as numerical sequences or text repetitions, and applies them to the filled range.

![Autofill Illustration](images/autofill.gif)

### Autofill programmatically

Autofill can be implemented programmatically using the `AutofillAsync` method. This method supports specifying the fill range, data source range, and direction of the fill operation. The operation is skipped if the invalid range addresses are provided.

| Parameter | Type | Description |
| -- | -- | -- |
| fillRange | string | Specifies the range to fill (e.g., "A1:A10"). Must be a valid cell range address. |
| dataRange | string (optional) | Specifies the source data range (e.g., "A1"). If not provided, the active cell is used. |
| direction | string (optional)| An enum value from the `AutofillDirection` class that indicates the direction of the fill operation. Valid values are `Up`, `Right`, `Down`, or `Left`. Default is `Down`. |

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Spreadsheet

<button @onclick="AutofillRangeHandler">Autofill</button>
<SfSpreadsheet @ref="SpreadsheetRef" DataSource="DataSourceBytes">
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

    public async Task AutofillRangeHandler()
    {
	    // Basic autofill on range B7:B8 using the active cell with default direction (Down).
        await SpreadsheetRef.AutofillAsync("B7:B8");

        // Autofill range B1:E1 using B1 as the data source, filling rightward.
        await SpreadsheetRef.AutofillAsync("B1:E1", "B1", AutofillDirection.Right);

        // Autofill range A1:A10 using A1 as the data source, filling downward.
        await SpreadsheetRef.AutofillAsync("A1:A10", "A1", AutofillDirection.Down);
    }
}

{% endhighlight %}
{% endtabs %}

## Clear

The Spreadsheet component provides functionality to clear cell contents, formats, and hyperlinks. This functionality allows precise control over the removal of data, formatting, or links within selected cells or ranges. The **Clear All** option removes all contents, formats, and hyperlinks simultaneously from the specified range.

### Clear options

Four distinct clear options are available in the Spreadsheet component. Each option targets specific elements within the selected cells or range, as described below:

* **Clear All**: Removes all contents (formulas and data), formats (including number formats), and hyperlinks from the selected range.

* **Clear Formats**: Removes only the formats, such as number formats, fonts, and cell styles, while preserving contents and hyperlinks.

* **Clear Contents**: Removes only the contents, including formulas and data, while retaining formats and hyperlinks.

* **Clear Hyperlinks**: Removes only the hyperlinks, leaving contents and formats intact.

### Applying clear functionality

To apply clear functionality via the UI, the following steps are performed:

* Select the cell or range of cells to clear.

* Click the **Clear** icon in the **Home** tab of the Ribbon toolbar and choose the desired option (**Clear All**, **Clear Formats**, **Clear Contents**, or **Clear Hyperlinks**).

![Clear options in the Blazor Spreadsheet](images/clear-feature.png)

### Clear functionality in protected sheets

When a sheet is protected, restrictions apply to the clear functionality. The **Clear All** and **Clear Contents** options are enabled only for unlocked ranges. To enable **Clear Formats** for unlocked ranges, the **Format cells** checkbox must be selected in the protection dialog sheet options. Similarly, to enable **Clear Hyperlinks** for unlocked ranges, the **Insert hyperlinks** checkbox must be selected in the protection dialog sheet options.

N> To know more about worksheet protection settings, refer [here](https://blazor.syncfusion.com/documentation/spreadsheet/protection#protection-settings-in-a-protected-sheet) 