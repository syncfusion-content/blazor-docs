---
layout: post
title: Managing Cell Ranges in Blazor Spreadsheet component | Syncfusion
description: Checkout and learn to manage cell range features such as formatting, autofill, and clear options in the Syncfusion Blazor Spreadsheet component and more.
platform: Blazor
control: Spreadsheet
documentation: ug
---

# Managing Cell Ranges in Blazor Spreadsheet component

A cell range refers to a group of selected cells in a Spreadsheet that can be manipulated or processed collectively.

## Cell formatting

Cell formatting enhances the visual presentation of data in a Spreadsheet by applying styles such as font changes, colors, borders, and alignment to individual cells or cell ranges. This helps in organizing and emphasizing important information effectively.

Cell formatting options include:

* **Bold** - Applies a heavier font weight to make the text stand out in the Spreadsheet.

* **Italic** - Slants the text to give it a distinct look, often used for emphasis or to highlight differences.

* **Underline** - Adds a line below the text, commonly used for emphasis or to indicate hyperlinks.

* **Strikethrough** - Draws a line through the text, often used to show completed tasks or outdated information.

* **Font Family** - Changes the typeface of the text (e.g., Arial, Calibri, Times New Roman, and more) to enhance readability or visual appeal.

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

Cell formatting can be applied to or removed from a cell or range of cells by using the formatting options available in the Ribbon toolbar under the **Home** tab.

## Autofill

Autofill is used to fill cells with data based on adjacent cells. It follows patterns from adjacent cells when available, eliminating the need to enter repeated data manually. The [AllowAutofill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Spreadsheet.SfSpreadsheet.html#Syncfusion_Blazor_Spreadsheet_SfSpreadsheet_AllowAutofill) property can be used to enable or disable the autofill support.

> * The default value of the `AllowAutofill` property is **true**.

Autofill can be performed in one of the following ways:

* Drag and drop the cell using the fill handle element.
* Use the [AutofillAsync()](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Spreadsheet.SfSpreadsheet.html#Syncfusion_Blazor_Spreadsheet_SfSpreadsheet_AutofillAsync_System_String_System_String_System_String_) method programmatically.

The available parameters in the `AutofillAsync()` method are:

| Parameter | Type | Description |
| -- | -- | -- |
| fillRange | string | Specifies the fill range. |
| dataRange | string | Specifies the data range. |
| direction | string | Specifies the direction ("Up", "Right", "Down", and "Left") to be filled. |

### Implementing autofill programmatically

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Spreadsheet

<button @onclick="AutofillRangeHandler">Autofill</button>
<SfSpreadsheet @ref="spreadsheetObj" DataSource="DataSourceBytes">
    <SpreadsheetRibbon></SpreadsheetRibbon>
</SfSpreadsheet>

@code {
    public byte[] DataSourceBytes { get; set; }
    public SfSpreadsheet spreadsheetObj;

    protected override void OnInitialized()
    {
        string filePath = "wwwroot/Sample.xlsx";
        DataSourceBytes = File.ReadAllBytes(filePath);
    }

    public async Task AutofillRangeHandler()
    {
	    // Basic usage with only the fill range parameter.
        await spreadsheetObj.AutofillAsync("B7:B8");
    }
}

{% endhighlight %}
{% endtabs %}

The following illustration demonstrates the use of autofill in the Spreadsheet component.

![Autofill: Illustration](images/autofill.gif)

## Clear

Clear support helps clear the cell contents (formulas and data) and formats (including number formats) in a Spreadsheet. When **Clear All** is applied, both the contents and the formats will be cleared simultaneously.

### Applying the clear functionality

The clear support can be applied using the following way:

* Select the **Clear** icon in the Ribbon toolbar under the **Home** tab.

| Options | Uses |
| -- | -- |
| **Clear All** | Used to clear all contents, formats, and hyperlinks. |
| **Clear Formats** | Used to clear the formats (including number formats) in a cell. |
| **Clear Contents** | Used to clear the contents (formulas and data) in a cell. |
| **Clear Hyperlinks** | Used to clear the hyperlink in a cell. |

The following image displays the clear options available in the Ribbon toolbar under the **Home** tab of the Blazor Spreadsheet.

![Clear options in the Blazor Spreadsheet](images/clear-feature.png)