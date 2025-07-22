---
layout: post
title: Hyperlink in the Blazor Spreadsheet component | Syncfusion
description: Checkout and learn how to insert, edit, and remove hyperlink in the Syncfusion Blazor Spreadsheet component and more.
platform: Blazor
control: Spreadsheet
documentation: ug
---

# Hyperlink in Blazor Spreadsheet component

Hyperlinks in the Blazor Spreadsheet enable interactive navigation within and outside spreadsheets. This feature creates clickable links that connect to external web URLs, specific cells within the current worksheet, or cells in other worksheets.


Enable or disable hyperlink functionality in the Spreadsheet using AllowHyperlink property. The default value for the [AllowHyperlink](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Spreadsheet.SfSpreadsheet.html#Syncfusion_Blazor_Spreadsheet_SfSpreadsheet_AllowHyperLink) property is **true**.

N> When `AllowHyperlink` is set to **false**, the hyperlink options are removed from the interface (ribbon and context menu), but existing hyperlinks will still function.


## Insert hyperlink

Hyperlink make worksheet cells clickable and connected to:
* **Web URLs**: Link to websites like https://www.syncfusion.com
* **Cell references**: Link to another cell in the same sheet, like `A1` or `B5:C10`
* **Sheet references**: Link to cells in other sheets, like `Sheet2!A1`

Adding hyperlinks creates interactive elements that improve navigation and connect data to external sources. Linked cells appear with special formatting (usually underlined and colored text) to indicate they are clickable.


### Insert hyperlink via the UI

Hyperlink can be inserted through the Spreadsheet UI using any of the following methods:

1.Using the Ribbon:

* Select the cell or range for adding a hyperlink
* Click the Insert tab in the Ribbon toolbar
* Click the Link option
* Complete the hyperlink information in the 
* Click Insert button to add hyperlink to the selected cell or range

![Insert tab in the Ribbon toolbar with the Link option highlighted](images/insert-hyperlink-using-ribbon.gif)

2.Using the Context Menu:

* Right-click on the selected cell
* Choose Hyperlink from the context menu
* Complete the hyperlink information in the dialog
* Click Insert button to add hyperlink to the selected cell or range

![Hyperlink dialog box displaying options for inserting a web URL](images/insert-hyperlink-using-contextmenu.gif)

N> Keyboard shortcut `Ctrl + K` can be used to quickly open the Insert Hyperlink dialog without using the UI elements. This shortcut works regardless of whether accessing hyperlink functionality through the ribbon or context menu.


### Insert hyperlink programmatically

Hyperlink can be added programmatically using the [AddHyperlinkAsync()](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Spreadsheet.SfSpreadsheet.html#Syncfusion_Blazor_Spreadsheet_SfSpreadsheet_AddHyperlinkAsync_System_String_System_String_System_String_) method. This method allows adding hyperlinks to cells or ranges without using the UI.

The available parameters in the `AddHyperlinkAsync()` method are:

| Parameter | Type | Description |
| -- | -- | -- |
| hyperlink | string | The URL or cell reference destination. |
| cellAddress | string | The cell or range where the hyperlink should be added. |
| displayText | string | (Optional) The text to display in the cell. |

## Basic Examples
{% tabs %}
{% highlight razor%}
// Add a web URL hyperlink to a single cell
await spreadsheetObj.AddHyperlinkAsync("https://www.syncfusion.com", "A1", "Syncfusion Website");

// Add a cell reference hyperlink
await spreadsheetObj.AddHyperlinkAsync("D10", "B5", "Go to Summary");

// Add a sheet reference hyperlink
await spreadsheetObj.AddHyperlinkAsync("Sheet2!B5", "A2", "View Details");

// Add a hyperlink to multiple cells
await spreadsheetObj.AddHyperlinkAsync("https://www.syncfusion.com", "A2:A5", "Documentation");

{% endhighlight %}
{% endtabs %}

## Edge cases:
{% tabs %}
{% highlight razor%}
// Web URLs are automatically formatted with https:// if protocol is missing
await spreadsheetObj.AddHyperlinkAsync("syncfusion.com", "A1");  // Becomes https://syncfusion.com

// When displayText is omitted, the hyperlink is used as display text
await spreadsheetObj.AddHyperlinkAsync("https://www.syncfusion.com", "B1");

// Adding hyperlink to a non-existent sheet reference will not cause error
// but the link may not work correctly when clicked
await spreadsheetObj.AddHyperlinkAsync("NonExistentSheet!A1", "C1", "Invalid Sheet");

// Adding hyperlink to cells with existing values will update the display text
// if displayText parameter is provided
await spreadsheetObj.AddHyperlinkAsync("https://www.syncfusion.com", "D1", "New Text");

{% endhighlight %}
{% endtabs %}

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Spreadsheet

<button @onclick="AddHyperlinkHandler">Add Hyperlink</button>
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

    public async Task AddHyperlinkHandler()
    {
	    await spreadsheetObj.AddHyperlinkAsync("https://www.syncfusion.com/blazor-components/blazor-spreadsheet","A2:A5");
    }
}

{% endhighlight %}
{% endtabs %}

N> The [AddHyperlinkAsync()](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Spreadsheet.SfSpreadsheet.html#Syncfusion_Blazor_Spreadsheet_SfSpreadsheet_AddHyperlinkAsync_System_String_System_String_System_String_) method won't work if the `AllowHyperlink` property is set to **false**.

## Edit hyperlink

Hyperlinks in a spreadsheet can be editable to update the destination or the display text. This includes:

* **Changing the Web URL**: Update the hyperlink to point to a different website or online resource.

* **Editing the Display Text**: Change the text in the cell without affecting the link destination.

* **Updating Cell References**: Modify the hyperlink to point to a different cell in the same sheet (e.g., from A1 to B5).

* **Linking to Another Sheet**: Redirect the hyperlink to a different sheet by modifying the sheet name in the reference (e.g., from Sheet1!A1 to Sheet2!C3).

### Edit hyperlink via the UI

Hyperlink can be edited through the Spreadsheet UI using any of the following methods:

1.Using the Ribbon:

* Select the cell containing the hyperlink
* Click the **Insert** tab in the Ribbon toolbar
* Click the **Link** option
* Make changes to the hyperlink information in the dialog
* Click **Update** to apply changes

2.Using the Context Menu:

* Right-click on the cell containing the hyperlink
* Choose **Edit Hyperlink** from the context menu
* Make changes to the hyperlink information in the dialog
* Click **Update** to apply changes


![Edit hyperlink dialog with options to modify an existing link](images/edit-hyperlink-dialogbox.png)

N> **Quick Tip:** You can use the keyboard shortcut `Ctrl + K` to quickly open the Edit Hyperlink dialog without going through menus.

N> **Important:** When editing hyperlinks to other sheets, make sure the target sheet actually exists in your workbook. Links to non-existent sheets will cause errors when clicked.

## Remove hyperlink

Removing hyperlinks disconnects cells from their linked destinations while preserving the display text. This operation removes only the link functionality, not the content itself.

### Remove hyperlink via the UI

To remove a hyperlink using the Spreadsheet interface:

1.Select the cell containing the hyperlink to be removed

2.Right-click the cell to display the context menu

3.Click **Remove Hyperlink** option from the context menu

![Remove Hyperlink option in the cell context menu](images/remove-hyperlink.png)

N> **Efficiency Tip:** Select multiple cells with hyperlinks at once (like `A1:D5`) to remove all hyperlinks in a single operation. This saves time when cleaning up many hyperlinks.

### Remove hyperlink programmatically

Hyperlinks can be removed programmatically using the [RemoveHyperlinkAsync()](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Spreadsheet.SfSpreadsheet.html#Syncfusion_Blazor_Spreadsheet_SfSpreadsheet_RemoveHyperlinkAsync_System_String_) method. This method removes hyperlink functionality from specified cells or ranges.

The available parameters in the `RemoveHyperlinkAsync()` method are:

| Parameter | Type | Description |
| -- | -- | -- |
| cellAddress | string | The cell or range from which to remove hyperlinks. |

## Basic Examples
{% tabs %}
{% highlight razor%}

// Remove hyperlink from a single cell
await spreadsheetObj.RemoveHyperlinkAsync("A1");

// Remove hyperlinks from a range of cells
await spreadsheetObj.RemoveHyperlinkAsync("A1:C5");

// Remove hyperlink from a cell in a specific sheet
await spreadsheetObj.RemoveHyperlinkAsync("Sheet2!D10");

// Remove hyperlinks from a range in a specific sheet
await spreadsheetObj.RemoveHyperlinkAsync("Sheet3!A1:A20");

{% endhighlight %}
{% endtabs %}

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Spreadsheet

<button @onclick="RemoveHyperlinkHandler">Remove Hyperlink</button>
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

    public async Task RemoveHyperlinkHandler()
    {
	    await spreadsheetObj.RemoveHyperlinkAsync("A2:A5");
    }
}

{% endhighlight %}
{% endtabs %}

N> The [RemoveHyperlinkAsync()](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Spreadsheet.SfSpreadsheet.html#Syncfusion_Blazor_Spreadsheet_SfSpreadsheet_RemoveHyperlinkAsync_System_String_)  is safe for any cell selection. Cells without hyperlinks are simply skipped with no errors.