---
layout: post
title: Controlling Editor Access in Blazor Rich Text Editor Component | Syncfusion
description: Checkout and learn here all about Controlling Editor Access in Syncfusion Blazor Rich Text Editor component and more.
platform: Blazor
control: RichTextEditor
documentation: ug
---

# Controlling Editor Access in Blazor Rich Text Editor Component

## Read-only mode

The Rich Text Editor control offers a read-only mode that prevents you from editing the content while still allowing them to view it. This feature is particularly useful when you want to display formatted content without permitting modifications.

To enable the read-only mode, set the [Readonly](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.SfRichTextEditor.html#Syncfusion_Blazor_RichTextEditor_SfRichTextEditor_Readonly) property to `true`. 

This will allow you to view the content without making any modifications.

Please refer to the sample and code snippets below to demonstrate how to enable the read-only mode in the Rich Text Editor.

{% tabs %}
{% highlight cshtml %}

{% include_relative code-snippet/read-only-mode.razor %}

{% endhighlight %}
{% endtabs %}
