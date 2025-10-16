---
layout: post
title: Floating Label in Blazor TextArea Component | Syncfusion
description: Checkout and learn about the Floating Label of the Syncfusion Blazor Textarea component and much more.
platform: Blazor
control: TextArea
documentation: ug
---

# Floating Label in Blazor TextArea Component

The floating label displays the placeholder as a label above the TextArea while the user interacts with it, improving readability and saving space in forms. Control this behavior using the [FloatLabelType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfTextArea.html#Syncfusion_Blazor_Inputs_SfTextArea_FloatLabelType) property. By default, the floating label is disabled (Never).

The following options describe when the label floats and typical usage patterns:

| Type  | Description |
| -- | -- |
| Auto  | The label floats above the TextArea on focus or input. If a value is present, it remains floated after blur; if empty, it returns to its initial position. |
| Always | The label remains floating above the TextArea at all times, regardless of interaction or value. |
| Never | The label does not float and stays in its default placeholder position. |

{% tabs %}
{% highlight razor %}

<SfTextArea Placeholder='Enter the Address' FloatLabelType='@FloatLabelType.Auto'></SfTextArea>

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VXLTjdiKszhkOkia?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor TextArea with Floating Label](./images/blazor-textarea-float-label.png)" %}