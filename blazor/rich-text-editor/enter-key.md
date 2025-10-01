---
layout: post
title: Enter key customization in Rich Text Editor | Syncfusion
description: Checkout and learn here all about the enter key and shift + enter key customization feature in RichTextEditor and more.
platform: Blazor
control: RichTextEditor
documentation: ug
---

# Enter and Shift-Enter Key Configuration

The Rich Text Editor allows to customize the tag that is inserted when pressing the <kbd>Enter</kbd> key and <kbd>Shift</kbd> + <kbd>Enter</kbd> key in the in the editor.

## Enter key customization

By default, pressing the <kbd>Enter</kbd> key inserts a `<p>` tag. The <kbd>Enter</kbd> key behavior can be customized using the [EnterKey]T(https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.SfRichTextEditor.html#Syncfusion_Blazor_RichTextEditor_SfRichTextEditor_EnterKey) property. The [possible tags](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.EnterKeyTag.html) are `<p>`, `<div>`, and `<br>`.

When configured, pressing the <kbd>Enter</kbd> key inserts the specified tag.

N> The **pre** tag will be inserted when code format is applied. If the editor content is inside the **pre** tag, the enter key press will creates `<br>` tag. Need to press enter key twice to come out of the **pre** tag.

{% tabs %}
{% highlight cshtml %}

{% include_relative code-snippet/enter-key-customization.razor %}

{% endhighlight %}
{% endtabs %}

![Blazor Rich Text Editor Enter key configuration](./images/blazor-richtexteditor-enter-key.png)

N> [View Sample](https://blazor.syncfusion.com/demos/rich-text-editor/enterkeyconfiguration)

## Shift-Enter key customization

By default, pressing <kbd>Shift</kbd> + <kbd>Enter</kbd> inserts a `<br>` tag. This behavior can be customized using the [ShiftEnterKey](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.SfRichTextEditor.html#Syncfusion_Blazor_RichTextEditor_SfRichTextEditor_ShiftEnterKey) property. The [possible tags](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.ShiftEnterKeyTag.html) are `<br>`, `<p>`, and `<div>`.

When configured, pressing <kbd>Shift</kbd> + <kbd>Enter</kbd> inserts the specified tag.

{% tabs %}
{% highlight cshtml %}

{% include_relative code-snippet/shift-enter-key-customization.razor %}

{% endhighlight %}
{% endtabs %}


![Blazor Rich Text Editor Shift+Enter key configuration](./images/blazor-richtexteditor-shift-enter-key.png)