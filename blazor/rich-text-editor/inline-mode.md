---
layout: post
title: Inline Mode in Rich Text Editor in Blazor | Syncfusion
description: Checkout and learn here all about Inline Mode in Syncfusion Blazor Rich Text Editor component and more.
platform: Blazor
control: RichTextEditor
documentation: ug
---

# Inline Editor in Blazor Rich Text Editor

The Rich Text Editor provides an option to display a toolbar on demand by enabling the property of [RichTextEditorInlineMode.Enable](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.RichTextEditorInlineMode.html#Syncfusion_Blazor_RichTextEditor_RichTextEditorInlineMode_Enable). When the editable text is focused or selected the inline floating toolbar appears. The commands displayed in inline toolbar can be customized by setting [RichTextEditorToolbarSettings.Items](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.RichTextEditorToolbarSettings.html#Syncfusion_Blazor_RichTextEditor_RichTextEditorToolbarSettings_Items) property.

{% tabs %}
{% highlight razor %}

{% include_relative code-snippet/inline-mode.razor %}

{% endhighlight %}
{% endtabs %}

![Blazor Rich Text Editor enabling inline mode](./images/blazor-richtexteditor-enable-inline.gif)

## Edit on select

The inline toolbar will appear only for the selected text by enabling the [RichTextEditorInlineMode.ShowOnSelection](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.RichTextEditorInlineMode.html#Syncfusion_Blazor_RichTextEditor_RichTextEditorInlineMode_ShowOnSelection) property. Otherwise the inline toolbar will not appear after clicking the editable area.

{% tabs %}
{% highlight razor %}

{% include_relative code-snippet/edit-on-select.razor %}

{% endhighlight %}
{% endtabs %}

![Blazor Rich Text Editor enabling selection](./images/blazor-richtexteditor-enable-selection.gif)

N> You can refer to our [Blazor Rich Text Editor](https://www.syncfusion.com/blazor-components/blazor-wysiwyg-rich-text-editor) feature tour page for its groundbreaking feature representations. You can also explore our [Blazor Rich Text Editor](https://blazor.syncfusion.com/demos/rich-text-editor/overview?theme=bootstrap5) example to know how to render and configure the rich text editor tools.

## See also

* [How to Configuring the toolbar position](./toolbar#configuring-the-toolbar-position)
* [How to insert link editing option in the toolbar items](./tools/link-manipulation#insert-link)
* [How to insert image editing option in the toolbar items](./tools/insert-image#uploading-and-inserting-images)
