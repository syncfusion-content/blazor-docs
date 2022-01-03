---
layout: post
title: Enter and Shift-Enter keys tag customization in Blazor RichTextEditor | Syncfusion
description: Checkout and learn here all about the Enter key and Shift + Enter key customization feature in Syncfusion Blazor RichTextEditor component and more.
platform: Blazor
control: RichTextEditor
documentation: ug
---

# Enter and Shift-Enter Key's Customization in Blazor RichTextEditor

The Rich Text Editor allows to customize the tag that is inserted when pressing the <kbd>Enter</kbd> key and <kbd>Shift</kbd> + <kbd>Enter</kbd> key in the Rich Text Editor.

## Enter key customization

By default, the `<p>` tag is created while pressing the <kbd>Enter</kbd> key. The tag created while pressing the <kbd>Enter</kbd> key can be customized by using the [EnterKey](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.SfRichTextEditor.html#Syncfusion_Blazor_RichTextEditor_SfRichTextEditor_EnterKey) property. The possible tags that can be used to customize the <kbd>Enter</kbd> key are `<p>`, `<div>`, and `<br>`.

When the <kbd>Enter</kbd> key is customized with any of the above possible values, pressing the <kbd>Enter</kbd> key in the editor will create a new tag that is configured.


{% highlight cshtml %}

{% include_relative code-snippet/enter-key-customization.razor %}

{% endhighlight %}

> [Blazor Enter Key Configuration Demo](https://blazor.syncfusion.com/demos/rich-text-editor/enterkeyconfiguration)

## Shift-Enter key customization

By default, the `<br>` tag is created while pressing the <kbd>Shift</kbd> + <kbd>Enter</kbd> key. The tag created while pressing the <kbd>Shift</kbd> + <kbd>Enter</kbd> key can be customized by using the [ShiftEnterKey](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.SfRichTextEditor.html#Syncfusion_Blazor_RichTextEditor_SfRichTextEditor_ShiftEnterKey) property. The possible tags that can be used to customize the <kbd>Shift</kbd> + <kbd>Enter</kbd> key are `<br>`, `<p>`, and `<div>`.

When the <kbd>Shift</kbd> + <kbd>Enter</kbd> key is customized with any of the possible values, pressing the <kbd>Shift</kbd> + <kbd>Enter</kbd> key in the editor will create a new tag that is configured.

{% highlight cshtml %}

{% include_relative code-snippet/shift-enter-key-customization.razor %}

{% endhighlight %}
