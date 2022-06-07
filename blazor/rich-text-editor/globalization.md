---
layout: post
title: Globalization in Blazor RichTextEditor Component | Syncfusion
description: Checkout and learn here all about Globalization in Syncfusion Blazor RichTextEditor component and more.
platform: Blazor
control: RichTextEditor
documentation: ug
---

# Globalization

## Enable RTL mode 

Specifies the direction of the Rich Text Editor component using the `EnableRtl` property. For writing systems will require Arabic, Hebrew, and more. The direction can be switched to right-to-left.

> `EnableRtl` property will not change, based on current culture.

{% tabs %}
{% highlight razor tabtitle="~/rtl.razor" %}

@using Syncfusion.Blazor.RichTextEditor

<SfRichTextEditor EnableRtl="true" />

{% endhighlight %}
{% endtabs %}

![Right to Left in Blazor RichTextEditor](./images/blazor-richtexteditor-right-to-left.png)

> You can refer to our [Blazor Rich Text Editor](https://www.syncfusion.com/blazor-components/blazor-wysiwyg-rich-text-editor) feature tour page for its groundbreaking feature representations. You can also explore our [Blazor Rich Text Editor](https://blazor.syncfusion.com/demos/rich-text-editor/overview?theme=bootstrap4) example to know how to render and configure the rich text editor tools.