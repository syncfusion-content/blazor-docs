---
layout: post
title: Managing Cell Ranges in Blazor Spreadsheet component | Syncfusion
description: Learn about the cell range features like formatting, autofill, and clear options in the Syncfusion Blazor Spreadsheet component and more.
platform: Blazor
control: Spreadsheet
documentation: ug
---

# Managing Cell Ranges in Blazor Spreadsheet component

A cell range is a group of selected cells in a Spreadsheet that you can work with together.

## Cell Formatting

Cell formatting enhances the visual presentation of data in a Spreadsheet by applying styles such as font changes, colors, borders, and alignment to individual cells or cell ranges. This helps in organizing and emphasizing important information effectively.

Cell formatting options include:

* **Bold** - Applies a heavier font weight to make the text stand out in the Spreadsheet.

* **Italic** - Slants the text to give it a distinct look, often used for emphasis or to highlight differences.

* **Underline** - Adds a line below the text, commonly used for emphasis or to indicate hyperlinks.

* **Strikethrough** - Draws a line through the text, often used to show completed tasks or outdated information.

* **Font Family** - Changes the typeface of the text (e.g., Arial, Calibri, Times New Roman) to enhance readability or visual appeal.

* **Font Size** - Adjusts the size of the text to create visual hierarchy or improve readability in the Spreadsheet.

* **Font Color** - Changes the color of the text to improve visual hierarchy or to organize information using color codes.

* **Fill Color** - Adds color to the cell background to visually organize data or highlight important information.

* **Horizontal Alignment** - Controls the position of text from left to right within a cell. Options include:
    * **Left** - Default for text
    * **Center** - Useful for headings
    * **Right** - Default for numbers

* **Vertical Alignment** - Controls the position of text from top to bottom within a cell. Options include:
    * **Top** – Aligns content to the top of the cell
    * **Middle** – Centers content vertically
    * **Bottom** – Default alignment

* **Wrap Text** - Displays long content on multiple lines within a single cell, preventing it from overflowing into adjacent cells.

Cell formatting can be applied to or removed from a cell or range of cells by using the formatting options available in the ribbon toolbar under the Home tab.

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

The following animation demonstrates how to use autofill in the Spreadsheet component:

![Autofill feature demonstration](images/autofill.gif)

## Clear

Clear feature helps to clear the cell contents (formulas and data), formats (including number formats) in a Spreadsheet. When `Clear All` is applied, both the contents and the formats will be cleared simultaneously.

### Applying the Clear Feature

The clear feature can be applied using the following way:

* Select the clear icon in the Ribbon toolbar under the Home Tab

| Options | Uses |
| -- | -- |
| `Clear All` | Used to clear all contents, formats, and hyperlinks. |
| `Clear Formats` | Used to clear the formats (including number formats) in a cell. |
| `Clear Contents` | Used to clear the contents (formulas and data) in a cell. |
| `Clear Hyperlinks` | Used to clear the hyperlink in a cell. |

The following image displays the clear options available in the Ribbon toolbar under the Home tab of the Blazor Spreadsheet.

![Clear feature options in Blazor Spreadsheet](images/clear-feature.png)