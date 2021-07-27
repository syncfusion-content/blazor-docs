---
layout: post
title: Working with Text Formatting in Blazor DocumentEditor Component | Syncfusion
description: Learn here all about Working with Text Formatting in Syncfusion Blazor DocumentEditor component and more.
platform: Blazor
control: DocumentEditor
documentation: ug
---

# Working with Text Formatting in Blazor DocumentEditor Component

[`Blazor Document Editor`](https://www.syncfusion.com/blazor-components/blazor-word-processor) supports several formatting options for text like bold, italic, font color, highlight color, and more. This section describes how to modify the formatting for selected text in detail.

## Bold

The bold formatting for selected text can be get or set by using the following sample code.

```javascript

//Gets the value for bold formatting of selected text.
bool bold = await documentEditor.Selection.CharacterFormat.GetBold();
//Sets bold formatting for selected text.
documentEditor.Selection.CharacterFormat.SetBold(true);

```

You can toggle the bold formatting based on existing value at selection. Refer to the following sample code.

```javascript
documentEditor.Editor.ToggleBold();
```

## Italic

The Italic formatting for selected text can be get or set by using the following sample code.

```javascript
documentEditor.Selection.CharacterFormat.SetItalic(true);
```

You can toggle the Italic formatting based on existing value at selection. Refer to the following sample code.

```javascript
documentEditor.Editor.ToggleItalic();
```

## Underline property

The underline style for selected text can be get or set by using the following sample code.

```javascript
documentEditor.Editor.ToggleUnderline(Underline.Single);
```

You can toggle the underline style of selected text based on existing value at selection by specifying a value. Refer to the following sample code.

```javascript
documenteditor.Editor.ToggleUnderline('Single');
```

## Strikethrough property

The strikethrough style for selected text can be get or set by using the following sample code.

```javascript
documentEditor.Editor.ToggleStrikethrough(Strikethrough.SingleStrike);
```

You can toggle the strikethrough style of selected text based on existing value at selection by specifying a value. Refer to the following sample code.

```javascript
documentEditor.Editor.ToggleStrikethrough(Strikethrough.SingleStrike);
```

## Superscript property

The selected text can be made superscript by using the following sample code.

```javascript
documentEditor.Selection.CharacterFormat.SetBaselineAlignment(BaselineAlignment.Superscript);
```

Toggle the selected text as superscript or normal using the following sample code.

```javascript
documentEditor.Editor.ToggleSuperscript();
```

## Subscript property

The selected text can be made subscript by using the following sample code.

```javascript
documentEditor.Selection.CharacterFormat.SetBaselineAlignment(BaselineAlignment.Subscript);
```

Toggle the selected text as subscript or normal using the following sample code.

```javascript
documentEditor.Editor.ToggleSubscript();
```

You can make a subscript or superscript text as normal using the following code.

```javascript
documentEditor.Selection.CharacterFormat.SetBaselineAlignment(BaselineAlignment.Normal);
```

## Size

The size of selected text can be get or set using the following code.

```javascript
documentEditor.Selection.CharacterFormat.SetFontSize(32);
```

## Color

The color of selected text can be get or set using the following code.

```javascript
documentEditor.Selection.CharacterFormat.SetFontColor("Pink");
documentEditor.Selection.CharacterFormat.SetFontColor("FFC0CB");
```

## Font

The font style of selected text can be get or set using the following sample code.

```javascript
documentEditor.Selection.CharacterFormat.SetFontFamily("Arial");
```

## Highlight color

The highlight color of the selected text can be get or set using the following sample code.

```javascript
documentEditor.Selection.CharacterFormat.SetHighlightColor(HighlightColor.Pink);
```

You can also explore our [`Blazor Word Processor`](https://blazor.syncfusion.com/demos/document-editor/default-functionalities) example to know how to render and configure the document editor.