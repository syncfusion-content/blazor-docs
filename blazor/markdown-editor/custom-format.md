---
layout: post
title: Customize Markdown Syntax in Blazor Markdown Editor | Syncfusion
description: Learn how to customize Markdown syntax in the Syncfusion Blazor Markdown Editor component, including formatting options, toolbar customization, and more.
platform: Blazor
control: MarkdownEditor
documentation: ug
---

# Customizing Markdown Syntax in Blazor Markdown Editor Component

The Rich Text Editor allows you to customize the Markdown syntax by overriding its default behavior. You can configure custom Markdown syntax using the following properties:
- [RichTextEditorMarkdownOptions.ListSyntax](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.RichTextEditorMarkdownOptions.html#Syncfusion_Blazor_RichTextEditor_RichTextEditorMarkdownOptions_ListSyntax)
- [RichTextEditorMarkdownOptions.FormatSyntax](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.RichTextEditorMarkdownOptions.html#Syncfusion_Blazor_RichTextEditor_RichTextEditorMarkdownOptions_FormatSyntax)
- [RichTextEditorMarkdownOptions.SelectionSyntax](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.RichTextEditorMarkdownOptions.html#Syncfusion_Blazor_RichTextEditor_RichTextEditorMarkdownOptions_SelectionSyntax)

## Defining Custom Markdown Formatting

You can define custom symbols for various Markdown formatting options:

* Use `+` for unordered lists instead of `-`.
* Use `__text__` for bold text instead of `**text**`.
* Use `_text_` for italic text instead of `*text*`.

The following example demonstrates how to customize Markdown tags in the editor:

{% tabs %}
{% highlight cshtml %}

{% include_relative code-snippet/markdown-custom-formats.razor %}

{% endhighlight %}
{% endtabs %}

![Blazor RichTextEditor markdown custom list](./images/blazor-richtexteditor-markdown-custom-list.png)

![Blazor RichTextEditor markdown custom format](./images/blazor-richtexteditor-markdown-custom-formats.png)

![Blazor RichTextEditor markdown custom selection](./images/blazor-richtexteditor-markdown-custom-bold.png)
