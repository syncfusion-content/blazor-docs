---
layout: post
title: Resizable editor in Blazor RichTextEditor Component | Syncfusion
description: Checkout and learn here all about Auto save editor in Syncfusion Blazor RichTextEditor component and much more.
platform: Blazor
control: RichTextEditor
documentation: ug
---
 ## Resizable Editor 

 This feature allows the editor to be resized dynamically. The users can enable or disable this feature using the [`EnableResize`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.SfRichTextEditor.html#Syncfusion_Blazor_RichTextEditor_SfRichTextEditor_EnableResize) property in the Rich Text Editor. If [`EnableResize`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.SfRichTextEditor.html#Syncfusion_Blazor_RichTextEditor_SfRichTextEditor_EnableResize) is set to true, the Rich Text Editor component creates grip at the bottom right corner, which allows resizing the component in the diagonal direction. The following sample demonstrates the resizable feature.

### Enabling the resizable support

To render the Rich Text Editor in the resizable mode, set the [`EnableResize`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.SfRichTextEditor.html#Syncfusion_Blazor_RichTextEditor_SfRichTextEditor_EnableResize) property to true.

{% tabs %}
{% highlight razor tabtitle="~/resize-editor.razor" %}

@using Syncfusion.Blazor.RichTextEditor

<SfRichTextEditor EnableResize="true">
    <p>Rich Text Editor allows to insert images from online source as well as local computer where you want to insert the image in your content.</p><p><b>Get started Quick Toolbar to click on the image</b></p><p>It is possible to add custom style on the selected image inside the Rich Text Editor through quick toolbar.</p><img alt='Logo' style='width: 300px; height: 300px; transform: rotate(0deg);' src='images/RichTextEditor/RTEImage-Feather.png' />
</SfRichTextEditor>

{% endhighlight %}
{% endtabs %}

{% highlight cshtml %}

{% include_relative code-snippet/resize-editor.razor %}

{% endhighlight %}

![Resizing in Blazor RichTextEditor](./images/blazor-richtexteditor-resizing.png)
