---
layout: post
title: Toolbar Configuration in Blazor Rich Text Editor | Syncfusion
description: Checkout and learn here all about Toolbar in Syncfusion Blazor Rich Text Editor component and much more.
platform: Blazor
control: RichTextEditor
documentation: ug
---

# Toolbar types in Blazor Rich Text Editor

The Rich Text Editor toolbar provides a collection of tools such as Bold, Italic, and text alignment buttons used to format the content.

You can customize the toolbar configurations by using the [RichTextEditorToolbarSettings.Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.RichTextEditorToolbarSettings.html#Syncfusion_Blazor_RichTextEditor_RichTextEditorToolbarSettings_Type) property. The types of toolbar are:

1. Expand
2. MultiRow
3. Scrollable
4. Popup 

## Expand toolbar

The [Expand](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.ToolbarType.html#Syncfusion_Blazor_RichTextEditor_ToolbarType_Expand) toolbar hides overflowing items in the next line using the  property. By clicking the expand arrow, you can view the overflowing toolbar items. The default mode of toolbar is `Expand`.

{% tabs %}
{% highlight razor %}

{% include_relative code-snippet/expand-toolbar.razor %}

{% endhighlight %}
{% endtabs %}

![Blazor RichTextEditor expand toolbar](./images/blazor-richtexteditor-expand-toolbar.webp)

## Multi-row toolbar

The [MultiRow](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.ToolbarType.html#Syncfusion_Blazor_RichTextEditor_ToolbarType_MultiRow) toolbar displays items in multiple rows, ensuring all items are always visible.

{% tabs %}
{% highlight razor %}

{% include_relative code-snippet/multirow-toolbar.razor %}

{% endhighlight %}
{% endtabs %}

![Blazor RichTextEditor multirow toolbar](./images/blazor-richtexteditor-multirow-toolbar.webp)

## Scrollable toolbar

The [Scrollable](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.ToolbarType.html#Syncfusion_Blazor_RichTextEditor_ToolbarType_Scrollable) toolbar displays items in a single row with horizontal scrolling enabled.

{% tabs %}
{% highlight razor %}

{% include_relative code-snippet/scrollable-toolbar.razor %}

{% endhighlight %}
{% endtabs %}

![Blazor RichTextEditor multirow toolbar](./images/blazor-richtexteditor-scrollable-toolbar.webp)

## Popup toolbar

The [Popup](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.ToolbarType.html#Syncfusion_Blazor_RichTextEditor_ToolbarType_Popup) toolbar property displays items in a popup container, ideal for limited space or smaller screens.

{% tabs %}
{% highlight razor %}

{% include_relative code-snippet/popup-toolbar.razor %}

{% endhighlight %}
{% endtabs %}

![Blazor RichTextEditor multirow toolbar](./images/blazor-richtexteditor-popup-toolbar.webp)

## Configuring a Floating toolbar

By default, toolbar is float at the top of the Rich Text Editor on scrolling. It can be customized by specifying the offset of the floating toolbar from documents top position using [FloatingToolbarOffset](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.SfRichTextEditor.html#Syncfusion_Blazor_RichTextEditor_SfRichTextEditor_FloatingToolbarOffset).

You can enable or disable the floating toolbar using [RichTextEditorToolbarSettings.EnableFloating](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.RichTextEditorToolbarSettings.html#Syncfusion_Blazor_RichTextEditor_RichTextEditorToolbarSettings_EnableFloating) property.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.RichTextEditor

<SfRichTextEditor Height="250px">
    <RichTextEditorToolbarSettings EnableFloating="true" />
    <h2>Welcome to the Syncfusion Rich Text Editor</h2><p>The Rich Text Editor, a WYSIWYG (what you see is what you get) editor, is a user interface that allows you to create, edit, and format rich text content. You can try out a demo of this editor here.</p><h3>Do you know the key features of the editor?</h3>
    <ul><li>Basic features include headings, block quotes, numbered lists, bullet lists, and support to insert images, tables, audio, and video.</li> <li>Inline styles include <b>bold</b>, <em>italic</em>, <span style="text-decoration: underline">underline</span>, <span style="text-decoration: line-through">strikethrough</span>, <a class="e-rte-anchor" href="https://blazor.syncfusion.com/demos/rich-text-editor/overview?theme=material3" title="https://blazor.syncfusion.com/demos/rich-text-editor/overview?theme=material3" aria-label="Open in new window">hyperlinks</a>,<code>InlineCode</code> and more.</li> <li>The toolbar has multi-row, expandable, and scrollable modes. The Editor supports an inline toolbar, a floating toolbar, and custom toolbar items.</li></ul>
</SfRichTextEditor>

{% endhighlight %}
{% endtabs %}

![Blazor RichTextEditor floating toolbar](./images/blazor-richtexteditor-floating.toolbar.webp)

## See also

* [Customizing Rich Text Editor Toolbar Styles](https://blazor.syncfusion.com/documentation/rich-text-editor/style#customizing-the-toolbar-appearance)
* [Implementing Inline Editing](https://blazor.syncfusion.com/documentation/rich-text-editor/inline-mode)
* [Customizing Accessibility Shortcut Keys](https://blazor.syncfusion.com/documentation/rich-text-editor/keyboard-support#custom-key-config)