---
layout: post
title: Clipboard in Blazor Spreadsheet component | Syncfusion
description: Checkout and learn here about the clipboard features in the Syncfusion Blazor Spreadsheet component and more.
platform: Blazor
control: Spreadsheet
documentation: ug
---

# Clipboard in Blazor Spreadsheet component

The Spreadsheet provides support for the clipboard operations (cut, copy, and paste). Clipboard operations can be enabled or disabled by setting the [`EnableClipboard`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Spreadsheet.SfSpreadsheet.html#Syncfusion_Blazor_Spreadsheet_SfSpreadsheet_EnableClipboard) property in Spreadsheet.

> By default, the `EnableClipboard` property is true.

## Cut

It is used to cut the data from selected range of cells, rows or columns in a spreadsheet and make it available in the clipboard.

**User Interface**:

Cut can be done in one of the following ways.

* Using Cut button in the Ribbon’s HOME tab to perform cut operation.
* Using Cut option in the Context Menu.
* Using `Ctrl + X` | `Command + X` keyboard shortcut.
* Using the [`CutCellAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Spreadsheet.SfSpreadsheet.html#Syncfusion_Blazor_Spreadsheet_SfSpreadsheet_CutCellAsync_System_String_) method.

## Copy

It is used to copy the data from selected range of cells, rows or columns in a spreadsheet and make it available in the clipboard.

**User Interface**:

Copy can be done in one of the following ways.

* Using Copy button in the Ribbon’s HOME tab to perform copy operation.
* Using Copy option in the Context Menu.
* Using `Ctrl + C` | `Command + C` keyboard shortcut.
* Using the [`CopyCellAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Spreadsheet.SfSpreadsheet.html#Syncfusion_Blazor_Spreadsheet_SfSpreadsheet_CopyCellAsync_System_String_) method.

## Paste

It is used to paste the clipboard data to the selected range, rows or columns. You have the following options in Paste,

* `Paste` - You can paste only the values without formatting.

It also performs for external clipboard operation. If you perform cut and paste, clipboard data will be cleared, whereas in copy and paste the clipboard contents will be maintained. If you perform paste inside the copied range, the clipboard data will be cleared.

**User Interface**:

Paste can be done in one of the following ways.

* Using Paste button in the Ribbon’s HOME tab to perform paste operation.
* Using Paste option in the Context Menu.
* Using `Ctrl + V` | `Command + V` keyboard shortcut.
* Using the [`PasteCellAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Spreadsheet.SfSpreadsheet.html#Syncfusion_Blazor_Spreadsheet_SfSpreadsheet_PasteCellAsync_System_String_) method.

> If you use the Keyboard shortcut key for cut (`Ctrl + X`) / copy (`Ctrl + C`) from other sources, you should use `Ctrl + V` shortcut while pasting into the spreadsheet.

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

The following example shows, how to prevent the paste action in spreadsheet. In [`Pasting`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Spreadsheet.PastingEventArgs.html) event, you can set `Cancel` argument as false in paste request type.

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