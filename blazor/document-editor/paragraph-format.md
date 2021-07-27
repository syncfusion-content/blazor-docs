---
layout: post
title: Working with Paragraph Formatting in Blazor DocumentEditor Component | Syncfusion
description: Learn here all about Working with Paragraph Formatting in Syncfusion Blazor DocumentEditor component and more.
platform: Blazor
control: DocumentEditor
documentation: ug
---

# Working with Paragraph Formatting in Blazor DocumentEditor Component

[`Blazor Document Editor`](https://www.syncfusion.com/blazor-components/blazor-word-processor) supports various paragraph formatting options such as text alignment, indentation, paragraph spacing, and more.

## Indentation

You can modify the left or right indentation of selected paragraphs using the following sample code.

```javascript
documentEditor.Selection.ParagraphFormat.SetLeftIndent(24);
documentEditor.Selection.ParagraphFormat.SetRightIndent(24);
```

## Special indentation

You can define special indent for first line of the paragraph using the following sample code.

```javascript
documentEditor.Selection.ParagraphFormat.SetFirstLineIndent(24);
```

## Increase indent

You can increase the left indent of selected paragraphs by a factor of 36 points using the following sample code.

```javascript
documentEditor.Editor.IncreaseIndent();
```

## Decrease indent

You can decrease the left indent of selected paragraphs by a factor of 36 points using the following sample code.

```javascript
documentEditor.Editor.DecreaseIndent();
```

## Text alignment

You can get or set the text alignment of selected paragraphs using the following sample code.

```javascript
documentEditor.Selection.ParagraphFormat.SetTextAlignment(TextAlignment.Center);
```

You can toggle the text alignment of selected paragraphs by specifying a value using the following sample code.

```javascript
documentEditor.Editor.ToggleTextAlignment(TextAlignment.Center);
```

## Line spacing and its type

You can define the line spacing and its type for selected paragraphs using the following sample code.

```javascript
documentEditor.Selection.ParagraphFormat.SetLineSpacingType(LineSpacingType.AtLeast);
documentEditor.Selection.ParagraphFormat.SetLineSpacing(6);
```

## Paragraph spacing

You can define the spacing before or after the paragraph by using the following sample code.

```javascript
documentEditor.Selection.ParagraphFormat.SetBeforeSpacing(24);
documentEditor.Selection.ParagraphFormat.SetAfterSpacing(24);
```

You can also explore our [`Blazor Word Processor`](https://blazor.syncfusion.com/demos/document-editor/default-functionalities) example to know how to render and configure the document editor.