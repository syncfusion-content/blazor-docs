---
layout: post
title: Hyperlinks in Blazor Spreadsheet component | Syncfusion
description: Checkout and learn how to insert, edit, and remove hyperlinks in the Syncfusion Blazor Spreadsheet component and more.
platform: Blazor
control: Spreadsheet
documentation: ug
---

# Hyperlink in Blazor Spreadsheet component

Hyperlink is used to navigate to web links or cell reference within the sheet or to other sheets in Spreadsheet. The [AllowHyperLink](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Spreadsheet.SfSpreadsheet.html#Syncfusion_Blazor_Spreadsheet_SfSpreadsheet_AllowHyperLink) property can be used to enable or disable hyperlink functionality. 

> * The default value for `AllowHyperLink` property is **true**.

## Insert Hyperlink

Hyperlinks can be inserted in a worksheet cell for quick access to related information.

### Insert Hyperlink from user interface

In the active Spreadsheet, click the cell where a hyperlink should be created. Insert hyperlink can be done by any of the following ways:

* Select the INSERT tab in the Ribbon toolbar and choose the `Link` option.

* Right click the cell and then click Hyperlink option in the context menu.

* Use `Ctrl + K` keyboard shortcut to apply the hyperlink.

### Insert Hyperlink programmatically

To add hyperlinks programmatically in the Spreadsheet component, the `AddHyperLinkAsync` method can be used.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Spreadsheet

<button @onclick="AddHyperlinkHandler">Add Hyperlink</button>
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

    public async Task AddHyperlinkHandler()
    {
	    await spreadsheetObj.AddHyperLinkAsync("https://www.syncfusion.com/blazor-components/blazor-spreadsheet","A2:A5")
    }
}

{% endhighlight %}
{% endtabs %}

## Edit Hyperlink

Existing hyperlinks in the workbook can be changed by modifying the destination or the text that is used to represent it.

### Edit Hyperlink from user interface

In the active Spreadsheet, select the cell that contains the hyperlink that needs to be changed. Editing the hyperlink while opening the dialog can be done by any one of the following ways:

* Select the INSERT tab in the Ribbon toolbar and choose the `Link` option.

* Right click the cell and then click Edit Hyperlink option in the context menu, or press Ctrl+K.

* In the Edit Link dialog box, make the desired changes, and click UPDATE.

## Remove Hyperlink

* Performing this operation removes a hyperlink without losing the display text.

### Remove Hyperlink from user interface

In the active Spreadsheet, click the cell where a hyperlink should be removed. Remove hyperlink can be done by any of the following ways:

* Right click the cell and then click Remove Hyperlink option in the context menu.

### Remove Hyperlink programmatically

To remove hyperlinks programmatically in the Spreadsheet component, the `RemoveHyperLinkAsync()` method can be used.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Spreadsheet

<button @onclick="RemoveHyperlinkHandler">Remove Hyperlink</button>
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

    public async Task RemoveHyperlinkHandler()
    {
	    await spreadsheetObj.RemoveHyperLinkAsync("A2:A5");
    }
}

{% endhighlight %}
{% endtabs %}

