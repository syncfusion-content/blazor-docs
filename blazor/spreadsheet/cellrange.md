---
layout: post
title: Cell Range Management in Blazor Spreadsheet | Syncfusion
description: Checkout and learn here about the cell range including cell formatting, autofill, and clear functionalities in the Syncfusion Blazor Spreadsheet component and more.
platform: Blazor
control: Spreadsheet
documentation: ug
---

# Cell range in Blazor Spreadsheet component

A group of cells in a sheet is known as cell range.

## Cell Formatting

Cell formatting allows you to visually emphasize data in the Spreadsheet by applying various styles and text formatting to cells or ranges of cells.

Cell formatting options include:

* **Bold** - Emphasizes text with a heavier weight to make it stand out in the Spreadsheet.

* **Italic** - Slants text to create a distinct visual appearance, often used for emphasis or differentiation.

* **Underline** - Adds a line beneath text for highlighting or indicating links.

* **Strikethrough** - Draws a line through text, often used to indicate completed tasks or obsolete data.

* **Font Family** - Changes the typeface of text (such as Arial, Calibri, Times New Roman) to improve readability or aesthetic appeal.

* **Font Size** - Adjusts the text size to create visual hierarchy or improve readability within the Spreadsheet.

* **Text Color** - Changes the color of text to enhance visual hierarchy or to color-code information.

* **Fill Color** - Adds background color to cells to organize data visually or highlight specific information.

* **Horizontal Alignment** - Controls text position from left to right within a cell. Options include Left (default for text), Center (useful for headings), and Right (default for numbers).

* **Vertical Alignment** - Controls text position from top to bottom within a cell. Options include Top, Middle (centers content vertically), and Bottom (default).

* **Wrap Text** - Displays large content as multiple lines in a single cell instead of overflowing into adjacent cells.

Cell formatting can be applied to or removed from a cell or range of cells by selecting the appropriate formatting options from the ribbon toolbar under the Home tab.

## Autofill

Autofill is used to fill the cells with data based on adjacent cells. It also follows a pattern from adjacent cells if available. There is no need to enter the repeated data manually. The [AllowAutofill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Spreadsheet.SfSpreadsheet.html#Syncfusion_Blazor_Spreadsheet_SfSpreadsheet_AllowAutofill) property can be used to enable/disable the autofill support.

> * The default value of `AllowAutofill` is **true**.

This can be done in one of the following ways:

* Drag and drop the cell using fill handle element.
* Use the `AutofillAsync()` method programmatically.

The available parameters in AutofillAsync() method are,

| Parameter | Type | Description |
| -- | -- | -- |
| fillRange | string | Specifies the fill range. |
| dataRange | string | Specifies the data range. |
| direction | string | Specifies the direction ("Up", "Right", "Down", "Left") to be filled. |

### Implementing Autofill Programmatically

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Spreadsheet

<button @onclick="AutoFillRangeHandler">Autofill</button>
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

    public async Task AutoFillRangeHandler()
    {
	    // Basic usage with only fillRange
        await spreadsheetObj.AutofillAsync("B7:B8");
    }
}

{% endhighlight %}
{% endtabs %}

## Clear

Clear feature helps to clear the cell contents (formulas and data), formats (including number formats) in a Spreadsheet. When Clear All is applied, both the contents and the formats will be cleared simultaneously.

### Apply Clear Feature

The clear feature can be applied using the following way:

* Select the clear icon in the Ribbon toolbar under the Home Tab

| Options | Uses |
| -- | -- |
| `Clear All` | Used to clear all contents, formats, and hyperlinks. |
| `Clear Formats` | Used to clear the formats (including number formats) in a cell. |
| `Clear Contents` | Used to clear the contents (formulas and data) in a cell. |
| `Clear Hyperlinks` | Used to clear the hyperlink in a cell. |
