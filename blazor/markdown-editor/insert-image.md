---
layout: post
title: Insert Image in Blazor Markdown Editor Component | Syncfusion
description: Checkout and learn here all about Insert Image in Syncfusion Blazor Markdown Editor component and more.
platform: Blazor
control: MarkdownEditor
documentation: ug
---

# Insert Images in Blazor Markdown Editor Component

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Markdown Editor allows users to insert images using the toolbar. This feature enables embedding images from online sources into the editor content.

## Steps to Insert an Image  

Follow these steps to add an image in the Markdown editor:

1. Click the [Image](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.RichTextEditorImageSettings.html) icon in the toolbar.
2. Enter the **URL** of the image from an online source.
3. Click the **Insert** button in the image dialog.

The image will be added to the editor content at the cursor position.

The following example demonstrates how to enable image insertion in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Markdown Editor.

{% tabs %}
{% highlight cshtml %}

{% include_relative code-snippet/markdown-insert-image.razor %}

{% endhighlight %}
{% endtabs %}

![Blazor Markdown Editor markdown image](./images/blazor-markdowneditor-markdown-image.png)