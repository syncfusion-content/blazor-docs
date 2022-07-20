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

[Rich Text Editor](https://www.syncfusion.com/blazor-components/blazor-wysiwyg-rich-text-editor) component can be localized. Refer to [Blazor Localization](https://blazor.syncfusion.com/documentation/common/localization) topic to localize Syncfusion Blazor components.

## Globalization

### Enable RTL mode 

Specifies the direction of the Rich Text Editor component using the [EnableRtl](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.SfRichTextEditor.html#Syncfusion_Blazor_RichTextEditor_SfRichTextEditor_EnableRtl) property. For writing systems will require Arabic, Hebrew, and more. The direction can be switched to right-to-left.

> `EnableRtl` property will not change, based on current culture.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.RichTextEditor

<SfRichTextEditor EnableRtl="true" />

{% endhighlight %}
{% endtabs %}

![Right to Left in Blazor RichTextEditor](./images/blazor-richtexteditor-right-to-left.png)

> You can refer to our [Blazor Rich Text Editor](https://www.syncfusion.com/blazor-components/blazor-wysiwyg-rich-text-editor) feature tour page for its groundbreaking feature representations. You can also explore our [Blazor Rich Text Editor](https://blazor.syncfusion.com/demos/rich-text-editor/overview?theme=bootstrap4) example to know how to render and configure the rich text editor tools.