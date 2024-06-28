---
layout: post
title: Working with Text Formatting in Blazor DocumentEditor | Syncfusion
description: Learn here all about Working with Text Formatting in Syncfusion Blazor DocumentEditor component and more.
platform: Blazor
control: DocumentEditor
documentation: ug
---

# Working with Text Formatting in Blazor DocumentEditor Component

[Blazor Document Editor](https://www.syncfusion.com/blazor-components/blazor-word-processor) supports several formatting options for text like bold, italic, font color, highlight color, and more. This section describes how to modify the formatting for selected text in detail.

## Bold

The bold formatting for selected text can be get or set by using the following sample code.

```csharp
//Gets the value for bold formatting of selected text.
bool bold = await documentEditor.Selection.CharacterFormat.GetBoldAsync();
//Sets bold formatting for selected text.
await documentEditor.Selection.CharacterFormat.SetBoldAsync(true);
```

You can toggle the bold formatting based on existing value at selection. Refer to the following sample code.

```csharp
await documentEditor.Editor.ToggleBoldAsync();
```

## Italic

The Italic formatting for selected text can be get or set by using the following sample code.

```csharp
//Gets the value for italic formatting of selected text.
bool italic = await documentEditor.Selection.CharacterFormat.GetItalicAsync();
//Sets italic formatting for selected text.
await documentEditor.Selection.CharacterFormat.SetItalicAsync(true);
```

You can toggle the Italic formatting based on existing value at selection. Refer to the following sample code.

```csharp
await documentEditor.Editor.ToggleItalicAsync();
```

## Underline property

The underline style for selected text can be get or set by using the following sample code.

```csharp
//Gets the value for underline formatting of selected text.
Underline underline = await documentEditor.Selection.CharacterFormat.GetUnderlineAsync();
//Sets underline formatting for selected text.
await documentEditor.Selection.CharacterFormat.SetUnderlineAsync(Underline.Single);
```

You can toggle the underline style of selected text based on existing value at selection by specifying a value. Refer to the following sample code.

```csharp
await documenteditor.Editor.ToggleUnderlineAsync(Underline.Single);
```

## Strikethrough property

The strikethrough style for selected text can be get or set by using the following sample code.

```csharp
//Gets the value for strikethrough formatting of selected text.
Strikethrough strikethrough = await documentEditor.Selection.CharacterFormat.GetStrikethroughAsync();
//Sets strikethrough formatting for selected text.
await documentEditor.Selection.CharacterFormat.SetStrikethroughAsync(Strikethrough.SingleStrike);
```

You can toggle the strikethrough style of selected text based on existing value at selection by specifying a value. Refer to the following sample code.

```csharp
await documentEditor.Editor.ToggleStrikethroughAsync(Strikethrough.SingleStrike);
```

## Superscript property

The selected text can be made superscript by using the following sample code.

```csharp
//Gets the value for baseline alignment formatting of selected text.
BaselineAlignment baselineAlignment = await documentEditor.Selection.CharacterFormat.GetBaselineAlignmentAsync();
//Sets baseline alignment formatting for selected text.
await documentEditor.Selection.CharacterFormat.SetBaselineAlignmentAsync(BaselineAlignment.Superscript);
```

Toggle the selected text as superscript or normal using the following sample code.

```csharp
await documentEditor.Editor.ToggleSuperscriptAsync();
```

## Subscript property

The selected text can be made subscript by using the following sample code.

```csharp
await documentEditor.Selection.CharacterFormat.SetBaselineAlignmentAsync(BaselineAlignment.Subscript);
```

Toggle the selected text as subscript or normal using the following sample code.

```csharp
await documentEditor.Editor.ToggleSubscriptAsync();
```

You can make a subscript or superscript text as normal using the following code.

```csharp
await documentEditor.Selection.CharacterFormat.SetBaselineAlignmentAsync(BaselineAlignment.Normal);
```

## Size

The size of selected text can be get or set using the following code.

```csharp
await documentEditor.Selection.CharacterFormat.SetFontSizeAsync(32);
```

## Color

The color of selected text can be get or set using the following code.

```csharp
await documentEditor.Selection.CharacterFormat.SetFontColorAsync("Pink");
await documentEditor.Selection.CharacterFormat.SetFontColorAsync("FFC0CB");
```

## Font

The font style of selected text can be get or set using the following sample code.

```csharp
await documentEditor.Selection.CharacterFormat.SetFontFamilyAsync("Arial");
```

## Highlight color

The highlight color of the selected text can be get or set using the following sample code.

```csharp
await documentEditor.Selection.CharacterFormat.SetHighlightColorAsync(HighlightColor.Pink);
```

You can also explore our [Blazor Word Processor](https://blazor.syncfusion.com/demos/document-editor/default-functionalities) example to know how to render and configure the document editor.
