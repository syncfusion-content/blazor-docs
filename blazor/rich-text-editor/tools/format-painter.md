---
layout: post
title: Format Painter in Blazor RichTextEditor Component | Syncfusion
description: Checkout and learn here all about Format Painter in Syncfusion Blazor RichTextEditor component and more.
platform: Blazor
control: RichTextEditor
documentation: ug
---

# Format Painter

The Rich Text Editor allows you to copy and apply text formatting using the Format Painter tool. You can enable and customize this feature using the [RichTextEditorFormatPainterSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.RichTextEditorFormatPainterSettings.html)  tag directive within the [SfRichTextEditor] component. The Format Painter tool can be accessed via the toolbar or using keyboard shortcuts to replicate formatting styles from one text block to another.

This sample demonstrates how to enable the Format Painter tool in the Blazor Rich Text Editor and configure its behavior.

Customization options for the format painter are available through the [RichTextEditorFormatPainterSettings] property.

## Configuring format painter tool in toolbar

You can add the FormatPainter tool in the Rich Text Editor using the RichTextEditorToolbarSettings [Items](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.RichTextEditorToolbarSettings.html#Syncfusion_Blazor_RichTextEditor_RichTextEditorToolbarSettings_Items) property.

N> In Blazor, Rich Text Editor features are enabled using feature-specific child components. To use the Format Painter feature, include the [RichTextEditorFormatPainterSettings] directive within the [SfRichTextEditor] component.

By double-clicking the format painter toolbar button, [sticky] mode will be enabled. In sticky mode, the format painter will be disabled when the user clicks the [Escape] key again.

The following code example shows how to add the format painter tool in the Rich Text Editor.

{% tabs %}
{% highlight razor %}

{% include_relative code-snippet/format-painter.razor %}

{% endhighlight %}
{% endtabs %}

## Customizing copy and paste format

You can customize the format painter tool in the Rich Text Editor using the [RichTextEditorFormatPainterSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.RichTextEditorFormatPainterSettings.html) tag directive within the [SfRichTextEditor] component. .

The [AllowedFormats](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.RichTextEditorFormatPainterSettings.html#Syncfusion_Blazor_RichTextEditor_RichTextEditorFormatPainterSettings_AllowedFormats) property helps you to specify tag names that allow the formats to be copied from the selected text. For instance, you can include formats from the selected text using tags like [p;] [h1;] [h2;] [h3;] [div;] [ul;] [ol;] [li;] [span;] [strong;] [em;] [code;]. The following example demonstrates how to customize this functionality.

Similarly, with the [DeniedFormats](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.RichTextEditorFormatPainterSettings.html#Syncfusion_Blazor_RichTextEditor_RichTextEditorFormatPainterSettings_DeniedFormats) property, you can utilize the selectors to prevent specific formats from being pasted onto the selected text. The table below illustrates the selectors and their respective usage.

| Type | Description        | Selector                           | Usage                                                              |
|------|--------------------|------------------------------------|--------------------------------------------------------------------|
| ()   | Class Selector     | h3(e-rte-block-blue-text)          | The class name `e-rte-block-blue-text` of H3 element is not copied. |
| []   | Attribute Selector | span[title]                        | The title attribute of span element is not copied.                 |
| {}   | Style Selector     | span{background-color, color}      | The background-color and color styles of span element is not copied. |

Using the [DeniedFormats] property following styles are denied copying from the selected text such as [h3(e-rte-block-blue-text){background-color,padding}[title];] [li{color};] [span(e-inline-text-highlight)[title];] [strong{color}(e-rte-strong-bg)].

Below is an example illustrating how to define the [AllowedFormats] and [DeniedFormats] settings for the Format Painter in the Rich Text Editor.

{% tabs %}
{% highlight razor %}

{% include_relative code-snippet/format-painter-properties.razor %}

{% endhighlight %}
{% endtabs %}

## Shortcut keys for copy and paste format

For more details on keyboard navigation, refer to the [Keyboard support](/blazor/rich-text-editor/accessibility/#keyboard-support) documentation.

N> The format painter retains the formatting after application making it possible to apply the same formatting multiple times by using the <kbd>Alt</kbd> + <kbd>Shift</kbd> + <kbd>v</kbd> keyboard shortcut.

Additionally, You can perform the format painter actions programmatically using the [executeCommand](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.SfRichTextEditor.html#Syncfusion_Blazor_RichTextEditor_SfRichTextEditor_ExecuteCommand_Syncfusion_Blazor_RichTextEditor_ToolbarCommand_System_String_) method.