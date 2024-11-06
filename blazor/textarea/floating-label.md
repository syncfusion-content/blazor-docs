---
layout: post
title: Floating Label in Blazor TextArea Component | Syncfusion
description: Checkout and learn about the Floating Label of the Syncfusion Blazor Textarea component and much more.
platform: Blazor
control: Textarea
documentation: ug
---

# Floating Label in Blazor TextArea Component

The floating label functionality in the TextArea Component allows the placeholder text to float above the TextArea while the user interacts with it, providing a more intuitive user experience. This feature can be achieved using the [FloatLabelType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfTextArea.html#Syncfusion_Blazor_Inputs_SfTextArea_FloatLabelType) API, which offers various options for defining the floating behavior:

| Type  | Description |
| -- | -- |
| Auto  | The label floats above the TextArea when it receives focus or input, returning to its initial position when the TextArea loses focus and contains no value. |
| Always | The label always remains floating above the TextArea, regardless of user interaction. |
| Never | The label never floats; it remains in its default position within the TextArea. |

{% tabs %}
{% highlight razor %}

<SfTextArea Placeholder='Enter the Address' FloatLabelType='@FloatLabelType.Auto'></SfTextArea>

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VXLTjdiKszhkOkia?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor TextArea with Floating Label](./images/blazor-textarea-float-label.png)" %}