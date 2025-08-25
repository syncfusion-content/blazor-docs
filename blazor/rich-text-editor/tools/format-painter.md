---
layout: post
title: Format Painter in Blazor RichTextEditor Component | Syncfusion
description: Checkout and learn here all about Format Painter in Syncfusion Blazor RichTextEditor component and more.
platform: Blazor
control: RichTextEditor
documentation: ug
---

# Format Painter

The format painter tool enables users to replicate formatting from one text segment and apply it to another. It can be accessed through the toolbar or via keyboard shortcuts, allowing the transfer of styles from individual words to entire paragraphs. Customization options are available through the [RichTextEditorFormatPainterSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.RichTextEditorFormatPainterSettings.html) property.

## Configuring format painter tool in toolbar

You can add the `FormatPainter` tool in the Rich Text Editor using the [RichTextEditorToolbarSettings.Items](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.RichTextEditorToolbarSettings.html#Syncfusion_Blazor_RichTextEditor_RichTextEditorToolbarSettings_Items) property.

By double-clicking the format painter toolbar button, `sticky` mode will be enabled. In sticky mode, the format painter remains active until the `Escape` key is pressed again to disable it.

The following code example shows how to add the format painter tool in the Rich Text Editor.

{% tabs %}
{% highlight razor %}

{% include_relative code-snippet/format-painter.razor %}

{% endhighlight %}
{% endtabs %}

## Customizing copy and paste format

You can customize the format painter tool in the Rich Text Editor using the [RichTextEditorFormatPainterSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.html) property.

The [AllowedFormats](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.RichTextEditorFormatPainterSettings.html#Syncfusion_Blazor_RichTextEditor_RichTextEditorFormatPainterSettings_AllowedFormats) property helps you to specify tag names that allow the formats to be copied from the selected text. For instance, you can include formats from the selected text using tags like `[p;]` `[h1;]` `[h2;]` `[h3;]` `[div;]` `[ul;]` `[ol;]` `[li;]` `[span;]` `[strong;]` `[em;]` `[code;]`. The following example demonstrates how to customize this functionality.

Similarly, with the [DeniedFormats](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.RichTextEditorFormatPainterSettings.html#Syncfusion_Blazor_RichTextEditor_RichTextEditorFormatPainterSettings_DeniedFormats) property, you can utilize the selectors to prevent specific formats from being pasted onto the selected text. The table below illustrates the selectors and their respective usage.

| Type | Description        | Selector                           | Usage                                                              |
|------|--------------------|------------------------------------|--------------------------------------------------------------------|
| ()   | Class Selector     | h3(e-rte-block-blue-text)          | The class name `e-rte-block-blue-text` of H3 element is not copied. |
| []   | Attribute Selector | span[title]                        | The title attribute of span element is not copied.                 |
| {}   | Style Selector     | span{background-color, color}      | The background-color and color styles of span element is not copied. |

Using the `DeniedFormats` property following styles are denied copying from the selected text such as `h3(e-rte-block-blue-text){background-color,padding}[title];` `li{color};` `span(e-inline-text-highlight)[title];` `strong{color}(e-rte-strong-bg)`.

Below is an example illustrating how to define the `AllowedFormats` and `DeniedFormats` settings for the format painter in the Rich Text Editor.

{% tabs %}
{% highlight razor %}

{% include_relative code-snippet/format-painter-properties.razor %}

{% endhighlight %}
{% endtabs %}

## Shortcut keys for copy and paste format

For more details on keyboard navigation, refer to the [Keyboard support](https://blazor.syncfusion.com/documentation/rich-text-editor/keyboard-support) documentation.

> The format painter retains the formatting after application making it possible to apply the same formatting multiple times by using the <kbd>Alt</kbd> + <kbd>Shift</kbd> + <kbd>v</kbd> keyboard shortcut.

Additionally, You can perform the format painter actions programmatically using the [ExecuteCommandAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.SfRichTextEditor.html#Syncfusion_Blazor_RichTextEditor_SfRichTextEditor_ExecuteCommandAsync_Syncfusion_Blazor_RichTextEditor_CommandName_Syncfusion_Blazor_RichTextEditor_FormatPainterParams_Syncfusion_Blazor_RichTextEditor_ExecuteCommandOption_) public method.