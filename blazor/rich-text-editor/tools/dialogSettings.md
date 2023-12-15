---
layout: post
title: Customization of Blazor Rich Text Editor Dialog | Syncfusion
description: Check out and learn about DialogSettings option in Syncfusion Blazor RichTextEditor component and more.
platform: Blazor
control: RichTextEditor
documentation: ug
---

# Customization of Blazor Rich Text Editor Dialog

The integration of the child component allows for improved customization of the RichTextEditor in the Blazor component. With this, you can now directly control the RichTextEditor's dialogs.

{% tabs %}
{% highlight cshtml %}

{% include_relative code-snippet/dialog-settings.razor %}

{% endhighlight %}
{% endtabs %}

![Blazor RichTextEditor DialogSettings](../images/dialog-settings.png)

## The child component exposes three essential properties:
1. IsModel: Accepts a Boolean value. Determines whether the dialog operates in modal or modeless mode.
2. Target: Specifies the target element for the dialog component.
3. ZIndex Property: Allows adjustment of the Z-index value for the dialog component.

## See also

* [How to edit the quick toolbar settings](../toolbar#audio-quick-toolbar)
* [How to use link editing option in the toolbar items](../tools#insert-link)