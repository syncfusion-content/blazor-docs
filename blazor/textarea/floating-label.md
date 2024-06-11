---
layout: post
title: Floating Label with ##Platform_Name## Textarea control | Syncfusion
description: Checkout and learn about Floating Label with ##Platform_Name## Textarea control of Syncfusion Essential JS 2 and more details.
platform: Blazor
control: Floating Label
publishingplatform: ##Platform_Name##
documentation: ug
domainurl: ##DomainURL##
---

# Floating Label in ##Platform_Name## TextArea Component

The floating label functionality in the TextArea Component allows the placeholder text to float above the TextArea while the user interacts with it, providing a more intuitive user experience. This feature can be achieved using the [floatLabelType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfTextArea.html#Syncfusion_Blazor_Inputs_SfTextArea_FloatLabelType) API, which offers various options for defining the floating behavior:

| Type  | Description |
| -- | -- |
| Auto  | The label floats above the TextArea when it receives focus or input, returning to its initial position when the TextArea loses focus and contains no value. |
| Always | The label always remains floating above the TextArea, regardless of user interaction. |
| Never | The label never floats; it remains in its default position within the TextArea. |

{% tabs %}
{% highlight razor %}

<SfTextArea Placeholder='First Name' FloatLabelType='@FloatLabelType.Auto'></SfTextArea>

{% endhighlight %}
{% endtabs %}