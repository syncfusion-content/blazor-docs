---
title: "Working with Section Formatting"
component: "Word processor"
description: "Learn section formatting supported in Blazor document editor like page size and margins, and how to customize it."
---

# Working with Section Formatting

[`Blazor Document Editor`](https://www.syncfusion.com/blazor-components/blazor-word-processor) supports various section formatting such as page size, page margins, and more.

## Page size

You can get or set the size of a section at cursor position by using the following sample code.

```javascript
documentEditor.Selection.SectionFormat.SetPageWidth(500);
documentEditor.Selection.SectionFormat.SetPageHeight(600);
```

You can change the orientation of the page by swapping the values of page width and height respectively.

## Page margins

Left and right page margin defines the gap between the document content from left and right side of the page respectively. Top and bottom page margins defines the gap between the document content from header and footer of the page respectively.
Refer to the following sample code.

```javascript
documentEditor.Selection.SectionFormat.SetLeftMargin(10);
documentEditor.Selection.SectionFormat.SetRightMargin(10);
documentEditor.Selection.SectionFormat.SetTopMargin(10);
documentEditor.Selection.SectionFormat.SetBottomMargin(10);
```

## Header distance

You can define the distance of header content from the top of the page by using the following sample code.

```javascript
documentEditor.Selection.SectionFormat.SetHeaderDistance(72);
```

## Footer distance

You can define the distance of footer content from the bottom of the page by using the following sample code.

```javascript
documentEditor.Selection.SectionFormat.SetFooterDistance(72);
```

You can also explore our [`Blazor Word Processor`](https://blazor.syncfusion.com/demos/document-editor/default-functionalities) example to know how to render and configure the document editor.