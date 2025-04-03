---
layout: post
title: Enter key customization in RichTextEditor | Syncfusion
description: Checkout and learn here all about the enter key and shift + enter key customization feature in RichTextEditor and more.
platform: Blazor
control: RichTextEditor
documentation: ug
---

# Enter and Shift-Enter Key Configuration

The Rich Text Editor allows to customize the tag that is inserted when pressing the <kbd>Enter</kbd> key and <kbd>Shift</kbd> + <kbd>Enter</kbd> key in the Rich Text Editor.

## Enter key customization

By default, the `<p>` tag is created while pressing the <kbd>Enter</kbd> key. The <kbd>Enter</kbd> key can be customized by using the [EnterKey](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.SfRichTextEditor.html#Syncfusion_Blazor_RichTextEditor_SfRichTextEditor_EnterKey) property. The [possible tags](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.EnterKeyTag.html) that can be used to customize the <kbd>Enter</kbd> key are `<p>`, `<div>`, and `<br>`.

When the <kbd>Enter</kbd> key is customized with any of the above possible values, pressing the <kbd>Enter</kbd> key in the editor will create a new tag that is configured.

N> The **pre** tag will be inserted when code format is applied. If the editor content is inside the **pre** tag, the enter key press will creates `<br>` tag. Need to press enter key twice to come out of the **pre** tag.

{% tabs %}
{% highlight cshtml %}

{% include_relative code-snippet/enter-key-customization.razor %}

{% endhighlight %}
{% endtabs %}

![Blazor RichTextEditor enter key confuguration](./images/blazor-richtexteditor-enter-key.png)

N> [View Sample](https://blazor.syncfusion.com/demos/rich-text-editor/enterkeyconfiguration)

## Shift-Enter key customization

By default, the `<br>` tag is created while pressing the <kbd>Shift</kbd> + <kbd>Enter</kbd> key. The <kbd>Shift</kbd> + <kbd>Enter</kbd> key can be customized by using the [ShiftEnterKey](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.SfRichTextEditor.html#Syncfusion_Blazor_RichTextEditor_SfRichTextEditor_ShiftEnterKey) property. The [possible tags](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.ShiftEnterKeyTag.html) that can be used to customize the <kbd>Shift</kbd> + <kbd>Enter</kbd> key are `<br>`, `<p>`, and `<div>`.

When the <kbd>Shift</kbd> + <kbd>Enter</kbd> key is customized with any of the above possible values, pressing the <kbd>Shift</kbd> + <kbd>Enter</kbd> key in the editor will create a new tag that is configured.

{% tabs %}
{% highlight cshtml %}

{% include_relative code-snippet/shift-enter-key-customization.razor %}

{% endhighlight %}
{% endtabs %}


![Blazor RichTextEditor shift + enter key confuguration](./images/blazor-richtexteditor-shift-enter-key.png)
