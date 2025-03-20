---
layout: post
title: Customization of Blazor Rich Text Editor Dialog | Syncfusion
description: Check out and learn here all about DialogSettings in Syncfusion Blazor RichTextEditor component and more. 
platform: Blazor
control: RichTextEditor
documentation: ug
---

# Customization of Blazor Rich Text Editor Dialog

The Blazor Rich Text Editor allows for improved customization of the dialogs by configuring the RichTextEditorDialogSettings property. This addition enables users to control the behavior and appearance of the underlying dialogs within the RichTextEditor. the following list of options has been provided.

| Options | Description |
|----------------|---------|
|IsModel|Accepts a boolean value and determines whether the dialog operates in modal or modeless mode.|
|Target|Specifies the target element for the dialog component.|
|ZIndex|Allows adjustment of the Z-index value for the dialog component.|

{% tabs %}
{% highlight cshtml %}

{% include_relative code-snippet/dialog-settings.razor %}

{% endhighlight %}
{% endtabs %}

![Blazor RichTextEditor DialogSettings](./images/dialog-settings.png)

## See also

* [How to edit the quick toolbar settings](../toolbar#audio-quick-toolbar)
* [How to use link editing option in the toolbar items](../tools#insert-link)
