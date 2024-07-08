---
layout: post
title: Table Formatting in Blazor DocumentEditor Component | Syncfusion
description: Learn here all about working with table formatting in Syncfusion Blazor DocumentEditor component and more.
platform: Blazor
control: DocumentEditor
documentation: ug
---

# Working with Table Formatting in Blazor DocumentEditor Component

[Blazor Document Editor](https://www.syncfusion.com/blazor-components/blazor-word-processor) customizes the formatting of table, or table cells such as table width, cell margins, cell spacing, background color, and table alignment. This section describes how to customize these formatting for selected cells, rows, or table in detail.

## Cell margins

You can customize the cell margins by using the following sample code.

```csharp
//To change the left margin.
await documentEditor.Selection.CellFormat.SetLeftMarginAsync(5);
//To change the right margin.
await documentEditor.Selection.CellFormat.SetRightMarginAsync(5);
//To change the top margin.
await documentEditor.Selection.CellFormat.SetTopMarginAsync(5);
//To change the bottom margin.
await documentEditor.Selection.CellFormat.SetBottomMarginAsync(5);
```

You can also define the default cell margins for a table. If the specific cell margin value is not defined explicitly in the cell formatting, the corresponding value will be retrieved from default cells margin of the table. Refer to the following sample code.

```csharp
//To change the left margin.
await documentEditor.Selection.TableFormat.SetLeftMarginAsync(5);
//To change the right margin.
await documentEditor.Selection.TableFormat.SetRightMarginAsync(5);
//To change the top margin.
await documentEditor.Selection.TableFormat.SetTopMarginAsync(5);
//To change the bottom margin.
await documentEditor.Selection.TableFormat.SetBottomMarginAsync(5);
```

## Background color

You can explicitly set the background color of selected cells using the following sample code.

```csharp
await documentEditor.Selection.CellFormat.SetBackgroundAsync("#E0E0E0");
```

Refer to the following sample code to customize the background color of the table.

```csharp
await documentEditor.Selection.TableFormat.SetBackgroundAsync("#E0E0E0");
```

## Cell spacing

Refer to the following sample code to customize the spacing between each cell in a table.

```csharp
await documentEditor.Selection.TableFormat.SetCellSpacingAsync(2);
```

## Cell vertical alignment

The content is aligned within a table cell to `Top`, `Center`, or `Bottom`. You can customize this property of selected cells. Refer to the following sample code.

```csharp
await documentEditor.Selection.CellFormat.SetVerticalAlignmentAsync(CellVerticalAlignment.Bottom);
```

## Table alignment

The tables are aligned in document editor to `Left`, `Right`, or `Center`. Refer to the following sample code.

```csharp
await documentEditor.Selection.TableFormat.SetTableAlignmentAsync(TableAlignment.Center);
```

## Cell width

Set the desired width of table cells that will be considered when the table is layouted. Refer to the following sample code.

```cshtml
@using Syncfusion.Blazor.DocumentEditor;
<SfDocumentEditor @ref="documentEditor" IsReadOnly=false EnableEditor=true EnableSelection=true>
    <DocumentEditorContainerEvents Created="OnLoad"></DocumentEditorContainerEvents>
</SfDocumentEditor>

@code {
    SfDocumentEditor documentEditor;
    protected async void OnLoad(object args)
    {
        await documentEditor.Editor.InsertTableAsync(2, 2);
        await documentEditor.Selection.CellFormat.SetPreferredWidthAsync(100);
        await documentEditor.Selection.CellFormat.SetPreferredWidthTypeAsync(WidthType.Point);
    }
}
```

## Table width

You can set the desired width of a table in `Point` or `Percent` type. Refer to the following sample code.

```cshtml
@using Syncfusion.Blazor.DocumentEditor
<SfDocumentEditor @ref="documentEditor" IsReadOnly=false EnableEditor=true EnableSelection=true>
    <DocumentEditorContainerEvents Created="OnLoad"></DocumentEditorContainerEvents>
</SfDocumentEditor>

@code {
    SfDocumentEditor documentEditor;
    protected async void OnLoad(object args)
    {
        await documentEditor.Editor.InsertTableAsync(2, 2);
        await documentEditor.Selection.TableFormat.SetPreferredWidthAsync(300);
        await documentEditor.Selection.TableFormat.SetPreferredWidthTypeAsync(WidthType.Point);
    }
}
```

## Working with row formatting

Document editor allows various row formatting such as height and repeat header.

## Row height

You can customize the height of a table row as `Auto`, `AtLeast`, or `Exactly`. Refer to the following sample code.

```cshtml
@using Syncfusion.Blazor.DocumentEditor
<SfDocumentEditor @ref="documentEditor" IsReadOnly=false EnableEditorHistory=true EnableEditor=true EnableSelection=true>
    <DocumentEditorContainerEvents Created="OnLoad"></DocumentEditorContainerEvents>
</SfDocumentEditor>

@code {
    SfDocumentEditor documentEditor;
    protected async void OnLoad(object args)
    {
        await documentEditor.Editor.InsertTableAsync(2, 2);
        await documentEditor.Selection.RowFormat.SetHeightAsync(20);
        await documentEditor.Selection.RowFormat.SetHeightTypeAsync(HeightType.Exactly);
    }
}
```

## Header row

The header row describes the content of a table. A table can optionally have a header row. Only the first row of a table can be the header row. If the cursor position is at first row of the table, then you can define whether it is a header row or not using the following sample code.

```csharp
await documentEditor.Selection.RowFormat.SetIsHeaderAsync(true);
```

## Allow row break across pages

This property is valid if a table row does not fit in the current page during table layout. It defines whether a table row can be allowed to break. If the value is false, the entire row will be moved to the start of next page. You can modify this property for selected rows using the following sample code.

```csharp
await documentEditor.Selection.RowFormat.SetAllowBreakAcrossPagesAsync(false);
```

### Title

Document Editor expose API to get or set the table title of the selected table. Refer to the following sample code to set title.

```csharp
await documentEditor.Selection.TableFormat.SetTitleAsync("Shipping Details");
```

### Description

Document Editor expose API to get or set the table description of the selected image. Refer to the following sample code to set description.

```csharp
await documentEditor.Selection.TableFormat.SetDescriptionAsync("Freight cost and shipping details");
```

You can also explore our [Blazor Word Processor](https://blazor.syncfusion.com/demos/document-editor/default-functionalities) example to know how to render and configure the document editor.
