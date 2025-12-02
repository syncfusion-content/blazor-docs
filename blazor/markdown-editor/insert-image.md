---
layout: post
title: Insert Image in Blazor Markdown Editor Component | Syncfusion
description: Checkout and learn here all about Insert Image in Syncfusion Blazor Markdown Editor component and more.
platform: Blazor
control: MarkdownEditor
documentation: ug
---

# How to Insert Images in Blazor Markdown Editor Component

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Markdown Editor allows users to insert images using the built-in toolbar. This feature supports embedding images from online sources directly into the editor content.

## Steps to Insert an Image

To insert an image in the Markdown Editor:

1. Click the [Image](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.RichTextEditorImageSettings.html) icon in the toolbar.
2. Enter the **URL** of the image from an online source.
3. Click the **Insert** button in the image dialog.

The image will be added to the editor content at the current cursor position.

The following example demonstrates how to enable image insertion in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Markdown Editor.

{% tabs %}
{% highlight cshtml %}

{% include_relative code-snippet/markdown-insert-image.razor %}

{% endhighlight %}
{% endtabs %}

![Image insertion using Blazor Markdown Editor toolbar](./images/blazor-markdowneditor-markdown-image.png)