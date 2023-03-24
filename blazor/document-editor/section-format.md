---
layout: post
title: Section Formatting in Blazor DocumentEditor Component | Syncfusion
description: Learn here all about working with section formatting in Syncfusion Blazor DocumentEditor component and more.
platform: Blazor
control: DocumentEditor
documentation: ug
---

# Working with Section Formatting in Blazor DocumentEditor Component

[Blazor Document Editor](https://www.syncfusion.com/blazor-components/blazor-word-processor) supports various section formatting such as page size, page margins, and more.

## Page size

You can get or set the size of a section at cursor position by using the following sample code.

```csharp
documentEditor.Selection.SectionFormat.SetPageWidth(500);
documentEditor.Selection.SectionFormat.SetPageHeight(600);
```

You can change the orientation of the page by swapping the values of page width and height respectively.

## Page margins

Left and right page margin defines the gap between the document content from left and right side of the page respectively. Top and bottom page margins defines the gap between the document content from header and footer of the page respectively.
Refer to the following sample code.

```csharp
documentEditor.Selection.SectionFormat.SetLeftMargin(10);
documentEditor.Selection.SectionFormat.SetRightMargin(10);
documentEditor.Selection.SectionFormat.SetTopMargin(10);
documentEditor.Selection.SectionFormat.SetBottomMargin(10);
```

## Header distance

You can define the distance of header content from the top of the page by using the following sample code.

```csharp
documentEditor.Selection.SectionFormat.SetHeaderDistance(72);
```

## Footer distance

You can define the distance of footer content from the bottom of the page by using the following sample code.

```csharp
documentEditor.Selection.SectionFormat.SetFooterDistance(72);
```

## Columns

You can define the number of columns, column width, and space between columns for the pages in a section.

The following code example illustrates how to define the two columns layout for the pages in a section.

```csharp
var column = new SelectionColumnFormat(container.documentEditor.selection);
column.width = 216;
column.space = 36;
container.documentEditor.selection.sectionFormat.columns = [column, column];
container.documentEditor.selection.sectionFormat.lineBetweenColumns = true;
```

## Breaks

You can insert Column break

The following code indicate that the text following the column break will begin in the next column

```csharp
container.documentEditor.editor.insertColumnBreak();
```

You can insert next page section break to start the new section on the next page

The following code example illustrates how to insert a next page section break

```csharp
container.documentEditor.editor.insertSectionBreak(SectionBreakType.NewPage);
```

You can insert continuous section break to start the new section on the same page

The following code example illustrates how to insert a continuous section break

```csharp
container.documentEditor.editor.insertSectionBreak(SectionBreakType.Continuous);
```

You can also explore our [Blazor Word Processor](https://blazor.syncfusion.com/demos/document-editor/default-functionalities) example to know how to render and configure the document editor.
