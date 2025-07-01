---
layout: post
title: Clipboard in Blazor Spreadsheet component | Syncfusion
description: Checkout and learn here all about the clipboard functionalities in the Syncfusion Blazor Spreadsheet component and more.
platform: Blazor
control: Spreadsheet
documentation: ug
---

# Clipboard in Blazor Spreadsheet component

The Spreadsheet provides support for the clipboard operations (cut, copy, and paste). Clipboard operations can be enabled or disabled by setting the [`EnableClipboard`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Spreadsheet.SfSpreadsheet.html#Syncfusion_Blazor_Spreadsheet_SfSpreadsheet_EnableClipboard) property in Spreadsheet.

> By default, the `EnableClipboard` property is set to **true**.

## Cut

Cuts data from a selected range of cells, rows, or columns in a sheet and places it on the clipboard for use elsewhere.

**Cutting Data in Spreadsheet**

The cut operation can be performed through multiple methods:

* Select the **Cut** button in the **HOME** tab of the Ribbon toolbar to execute the cut operation.
* Right-click and select the **Cut** option from the context menu.
* Press the keyboard shortcut `Ctrl + X `(Windows) or `Command + X `(Mac).
* Using the [`CutCellAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Spreadsheet.SfSpreadsheet.html#Syncfusion_Blazor_Spreadsheet_SfSpreadsheet_CutCellAsync_System_String_) method.

## Copy

Copies data from a selected range of cells, rows, or columns in a sheet and places it on the clipboard for use elsewhere.

**Copying Data in Spreadsheet**

The copy operation can be performed through multiple methods:

* Select the **Copy** button in the **HOME** tab of the Ribbon toolbar to execute the copy operation.
* Right-click and select the **Copy** option from the context menu.
* Press the keyboard shortcut `Ctrl + C` (Windows) or `Command + C` (Mac).
* Using the [`CopyCellAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Spreadsheet.SfSpreadsheet.html#Syncfusion_Blazor_Spreadsheet_SfSpreadsheet_CopyCellAsync_System_String_) method.

## Paste

Pastes data from the clipboard into a selected range of cells, rows, or columns. This includes all information such as values and formatting.

Supports external clipboard functionality. When using cut and paste, the clipboard is cleared after pasting. With copy and paste, the clipboard contents remain unchanged.

**Pasting Data in Spreadsheet**:

The paste operation can be performed through multiple methods:

* Select the **Paste** button in the **HOME** tab of the Ribbon toolbar to execute the paste operation.
* Right-click and select the **Paste** option from the context menu.
* Press the keyboard shortcut `Ctrl + V` (Windows) or `Command + V` (Mac).
* Using the [`PasteCellAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Spreadsheet.SfSpreadsheet.html#Syncfusion_Blazor_Spreadsheet_SfSpreadsheet_PasteCellAsync_System_String_) method.

> When using the keyboard shortcut keys for cut (`Ctrl + X`) or copy (`Ctrl + C`) from external sources, use the `Ctrl + V` shortcut to paste content into the Spreadsheet.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
 
@using Syncfusion.Blazor.Spreadsheet
@using Syncfusion.Blazor.SplitButtons

<SfDropDownButton Content="Clipboard">
    <DropDownMenuItems>
        <DropDownMenuItem Text="Copy"></DropDownMenuItem>
        <DropDownMenuItem Text="Cut"></DropDownMenuItem>
        <DropDownMenuItem Text="Paste"></DropDownMenuItem>
    </DropDownMenuItems>
    <DropDownButtonEvents ItemSelected="ItemSelected">
    </DropDownButtonEvents>
</SfDropDownButton>

<SfSpreadsheet @ref="SpreadsheetRef" DataSource="DataSourceBytes">
    <SpreadsheetRibbon></SpreadsheetRibbon>
</SfSpreadsheet>
 
@code {
    public byte[] DataSourceBytes { get; set; }

    public SfSpreadsheet SpreadsheetRef { get; set; }

    protected override void OnInitialized()
    {
        string filePath = "wwwroot/Sample.xlsx";
        DataSourceBytes = File.ReadAllBytes(filePath);
    }

    private async Task ItemSelected(MenuEventArgs args)
    {
        if (args.Item.Text == "Cut")
        {
            await SpreadsheetRef.CutCellAsync();
        }

        if (args.Item.Text == "Copy")
        {
            await SpreadsheetRef.CopyCellAsync();
        }

        if (args.Item.Text == "Paste")
        {
            await SpreadsheetRef.PasteCellAsync();
        } 
    }
}
 
{% endhighlight %}
{% endtabs %}

## Prevent the paste functionality

The following example illustrates how to prevent the paste action in Spreadsheet. In the [`Pasting`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Spreadsheet.PastingEventArgs.html) event, setting the `Cancel` argument to **true** prevents the paste operation.
{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
 
@using Syncfusion.Blazor.Spreadsheet
@using Syncfusion.Blazor.SplitButtons

<SfDropDownButton Content="Clipboard">
    <DropDownMenuItems>
        <DropDownMenuItem Text="Copy"></DropDownMenuItem>
        <DropDownMenuItem Text="Cut"></DropDownMenuItem>
        <DropDownMenuItem Text="Paste"></DropDownMenuItem>
    </DropDownMenuItems>
    <DropDownButtonEvents ItemSelected="ItemSelected">
    </DropDownButtonEvents>
</SfDropDownButton>

<SfSpreadsheet @ref="SpreadsheetRef" DataSource="DataSourceBytes">
    <SpreadsheetRibbon></SpreadsheetRibbon>
    <SpreadsheetEvents Pasting="OnBeforePasteHandler"></SpreadsheetEvents>
</SfSpreadsheet>
 
@code {
    public byte[] DataSourceBytes { get; set; }

    public SfSpreadsheet SpreadsheetRef { get; set; }

    protected override void OnInitialized()
    {
        string filePath = "wwwroot/Sample.xlsx";
        DataSourceBytes = File.ReadAllBytes(filePath);
    }

    private async Task ItemSelected(MenuEventArgs args)
    {
        if (args.Item.Text == "Cut")
        {
            await SpreadsheetRef.CutCellAsync();
        }

        if (args.Item.Text == "Copy")
        {
            await SpreadsheetRef.CopyCellAsync();
        }

        if (args.Item.Text == "Paste")
        {
            await SpreadsheetRef.PasteCellAsync();
        } 
    }

    public void OnBeforePasteHandler(PastingEventArgs args)
    {
        // To cancel the paste action.
        args.Cancel = true;
    }
}
 
{% endhighlight %}
{% endtabs %}