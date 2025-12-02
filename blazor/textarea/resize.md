---
layout: post
title: Resize in Blazor TextArea Component | Syncfusion
description: Check out and learn about the Resize feature of the Syncfusion Blazor TextArea component and explore much more functionality.
platform: Blazor
control: TextArea
documentation: ug
---

# Resize in Blazor TextArea Component

The TextArea supports resizing so users can adjust the control to fit varying content lengths. Configure resizing behavior using the [ResizeMode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfTextArea.html#Syncfusion_Blazor_Inputs_SfTextArea_ResizeMode) property:

| Type  | Description |
| -- | -- |
| Vertical  | Enables vertical resizing to adjust the height of the TextArea. |
| Horizontal | Enables horizontal resizing to adjust the width of the TextArea. |
| Both | Enables both vertical and horizontal resizing. |
| None | Disables resizing and hides the resize handle to maintain a fixed layout. |

N> In Razor, enums are typically referenced with the @ prefix (for example, @Resize.Both).

{% tabs %}
{% highlight razor %}

<SfTextArea Placeholder='Enter the Address' ResizeMode='Resize.Both'></SfTextArea>

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hXhTjHsgMqknhFJF?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor TextArea with Resize](./images/blazor-textarea-resize.png)" %}

## Width

Customize the width of the TextArea using the [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfTextArea.html#Syncfusion_Blazor_Inputs_SfTextArea_Width) property. This property allows precise adjustment of the TextArea's width according to the specific layout requirements of the application.

{% tabs %}
{% highlight razor %}

<SfTextArea Placeholder='Enter the Address' Width="500" ResizeMode='Resize.Both'></SfTextArea>

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VZLTjRCACTsLJegK?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor TextArea with Custom Width and Resize](./images/blazor-textarea-resize-width.png)" %}