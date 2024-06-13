---
layout: post
title: Resize in Blazor TextArea Component | Syncfusion
description: Check out and learn about the Resize feature of the Syncfusion Blazor TextArea component and explore much more functionality.
platform: Blazor
control: Textarea
documentation: ug
---

# Resize in Blazor TextArea Component

The TextArea allows users to input and edit large amounts of text. Resizing this component effectively can enhance the user experience and accommodate varying content needs. This resizing behavior can be enabled and configured using the [ResizeMode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfTextArea.html#Syncfusion_Blazor_Inputs_SfTextArea_ResizeMode) API, which offers several options for resizing the TextArea:

| Type  | Description |
| -- | -- |
| Vertical  | Allows users to adjust the height of the TextArea vertically. It is suitable when users want to resize the TextArea only along the vertical axis, accommodating varying amounts of text input. |
| Horizontal | Users can adjust the width of the TextArea horizontally. This option is helpful for accommodating longer lines of text without altering the height of the control. |
| Both | Allows users to adjust both the height and width of the TextArea, offering maximum flexibility in resizing. It is ideal for situations where users need precise control over the dimensions of the TextArea. |
| None | Disables the resizing in the TextArea. This option is ideal for situations where maintaining a consistent layout is critical, and resizing by users is unnecessary. |

{% tabs %}
{% highlight razor %}

<SfTextArea Placeholder='Enter the Address' ResizeMode='Resize.Both'></SfTextArea>

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hXhTjHsgMqknhFJF?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor TextArea with Floating Label](./images/blazor-textarea-resize.png)" %}

## Width

You can easily customize the width of the TextArea using the [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfTextArea.html#Syncfusion_Blazor_Inputs_SfTextArea_Width) property. This property allows precise adjustment of the TextArea's width according to the specific layout requirements of the application.

{% tabs %}
{% highlight razor %}

<SfTextArea Placeholder='Enter the Address' Width="500" ResizeMode='Resize.Both'></SfTextArea>

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VZLTjRCACTsLJegK?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor TextArea with Resize](./images/blazor-textarea-resize-width.png)" %}
