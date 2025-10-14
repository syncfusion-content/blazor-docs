---
layout: post
title: Floating Label in Blazor TextArea Component | Syncfusion
description: Checkout and learn about the Floating Label of the Syncfusion Blazor Textarea component and much more.
platform: Blazor
control: TextArea
documentation: ug
---

# Floating Label in Blazor TextArea Component

The floating label functionality in the TextArea component displays the placeholder as a floating label above the TextArea while the user interacts with it, improving readability and conserving space in forms. Use the [FloatLabelType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfTextArea.html#Syncfusion_Blazor_Inputs_SfTextArea_FloatLabelType) property to control this behavior. By default, the floating label is disabled (Never).

The options below describe when the label floats and typical usage patterns:

| Type  | Description |
| -- | -- |
| Auto  | The label floats above the TextArea when it receives focus or input. If a value is present, the label remains floated after blur; if empty, it returns to its initial position. |
| Always | The label always remains floating above the TextArea, regardless of user interaction or value. |
| Never | The label never floats; it remains in its default position within the TextArea. |

{% tabs %}
{% highlight razor %}

<SfTextArea Placeholder='Enter the Address' FloatLabelType='@FloatLabelType.Auto'></SfTextArea>

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VXLTjdiKszhkOkia?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor TextArea with Floating Label](./images/blazor-textarea-float-label.png)" %}