---
layout: post
title: IFrame Rendering in Blazor RichTextEditor Component | Syncfusion
description: Checkout and learn here all about IFrame Rendering in Syncfusion Blazor RichTextEditor component and more.
platform: Blazor
control: RichTextEditor
documentation: ug
---

# Iframe Editable in Blazor RichTextEditor Component

When the [`RichTextEditorIframeSettings`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.RichTextEditorIFrameSettings.html) option is enabled, the Rich Text Editor creates the iframe element as the content area on component initialization, it is used to display and edit the content. In content area, the editor displays only the body tag of a `<iframe>` document.

{% tabs %}
{% highlight razor tabtitle="~/iframe.razor" %}

@using Syncfusion.Blazor.RichTextEditor

<SfRichTextEditor>
    <RichTextEditorIFrameSettings Enable="true" />
    <p>The Rich Text Editor component is WYSIWYG ('what you see is what you get') editor that provides the best user experience to create and update the content. Users can format their content using standard toolbar commands.</p>
</SfRichTextEditor>

{% endhighlight %}
{% endtabs %}

![Blazor RichTextEditor with IFrame](./images/blazor-richtexteditor-iframe.png)

## IFrame attributes

The editor allows to pass an additional attribute to body tag of a `<iframe>` element using [`Attributes`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.RichTextEditorIFrameSettings.html#Syncfusion_Blazor_RichTextEditor_RichTextEditorIFrameSettings_Attributes) fields of [`RichTextEditorIframeSettings`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.RichTextEditorIFrameSettings.html) property. This property contains name or value pairs in string format. It is used to override the default appearance of the content area.

{% tabs %}
{% highlight razor tabtitle="~/iframe-attribute.razor" %}

{% include_relative code-snippet/iframe-attribute.razor %}

{% endhighlight %}
{% endtabs %}

![Blazor RichTextEditor with IFrame Attribute](./images/blazor-richtexteditor-iframe-attribute.png)


## Adding external CSS/Script file

The editor offers to add external CSS file to style the `<iframe>` element. Easily change the appearance of editor’s content using an external CSS file using `Resources - Styles` field in the [`RichTextEditorIframeSettings`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.RichTextEditorIFrameSettings.html) property.

Likewise, add the external script file to the `<iframe>` element using `Resources - Scripts` field of [`RichTextEditorIframeSettings`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.RichTextEditorIFrameSettings.html) to provide the additional functionalities to the Rich Text Editor.


{% tabs %}
{% highlight razor tabtitle="~/adding-css-script.razor" %}

@using Syncfusion.Blazor.RichTextEditor

<SfRichTextEditor>
    <RichTextEditorIFrameSettings Enable="true" Resources="@Resources" />
    <p>Rich Text Editor allows to insert images from online source as well as local computer where you want to insert the image in your content.</p>
    <p><b>Get started Quick Toolbar to click on the image</b></p>
    <p>It is possible to add custom style on the selected image inside the Rich Text Editor through quick toolbar.</p>
    <img alt='Logo' style='width: 300px; height: 300px; transform: rotate(0deg);' src='https://blazor.syncfusion.com/demos/images/RichTextEditor/RTEImage-Feather.png' />
</SfRichTextEditor>

@code {
    private ResourcesModel Resources { get; set; } = new ResourcesModel()
    {
        Styles = new string[] { "/styles.css" },
        Scripts = new string[] { "/script.js" }
    };
}

{% endhighlight %}
{% endtabs %}

![Blazor RichTextEditor with External css/script](./images/blazor-richtexteditor-iframe-external-CSS-script.png)

> You can refer to our [Blazor Rich Text Editor](https://www.syncfusion.com/blazor-components/blazor-wysiwyg-rich-text-editor) feature tour page for its groundbreaking feature representations. You can also explore our [Blazor Rich Text Editor](https://blazor.syncfusion.com/demos/rich-text-editor/overview?theme=bootstrap4) example to knows how to render and configure the rich text editor tools.

## See Also

* [How to change the editor mode](./editor-modes/#markdown-editor)