---
layout: post
title: Globalization in Blazor RichTextEditor Component | Syncfusion
description: Checkout and learn here all about Globalization in Syncfusion Blazor RichTextEditor component and more.
platform: Blazor
control: RichTextEditor
documentation: ug
---

# Globalization and Localization

## Localization

The [Rich Text Editor](https://www.syncfusion.com/blazor-components/blazor-rich-text-editor) component can be localized. Refer to the [Blazor Localization](https://blazor.syncfusion.com/documentation/common/localization) topic to localize Syncfusion Blazor components.

## Globalization

### Enable RTL mode

Specify the direction of the Rich Text Editor component using the [EnableRtl](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.SfRichTextEditor.html#Syncfusion_Blazor_RichTextEditor_SfRichTextEditor_EnableRtl) property. Writing systems will require Arabic, Hebrew, and more. The direction can be switched to right-to-left.

N> The `EnableRtl` property will not change based on the current culture.

{% tabs %}
{% highlight cshtml %}

@using Syncfusion.Blazor.RichTextEditor

<SfRichTextEditor EnableRtl="true" />

{% endhighlight %}
{% endtabs %}

![Blazor RichTextEditor right to left toolbar](./images/blazor-richtexteditor-right-to-left.png)

N> You can refer to our [Blazor Rich Text Editor](https://www.syncfusion.com/blazor-components/blazor-rich-text-editor) feature tour page for its groundbreaking feature representations. You can also explore our [Blazor Rich Text Editor](https://blazor.syncfusion.com/demos/rich-text-editor/overview?theme=bootstrap5) example to know how to render and configure the rich text editor tools.