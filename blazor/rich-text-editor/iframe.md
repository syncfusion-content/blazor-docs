---
layout: post
title: IFrame Rendering in Blazor RichTextEditor Component | Syncfusion
description: Checkout and learn here all about IFrame Rendering in Syncfusion Blazor RichTextEditor component and more.
platform: Blazor
control: RichTextEditor
documentation: ug
---

# IFrame Rendering in Blazor RichTextEditor Component

When the `RichTextEditorIframeSettings` option is enabled, the Rich Text Editor creates the iframe element as the content area on component initialization, it is used to display and edit the content. In content area, the editor displays only the body tag of a `<iframe>` document.

```csharp

@using Syncfusion.Blazor.RichTextEditor

<SfRichTextEditor>
    <RichTextEditorIFrameSettings Enable="true" />
    <p>The Rich Text Editor component is WYSIWYG ('what you see is what you get') editor that provides the best user experience to create and update the content. Users can format their content using standard toolbar commands.</p>
    <p><b> Key features:</b></p>
    <ul>
    <li><p> Provides <b>IFRAME</b> and <b>DIV</b> modes </p></li>
    <li><p> Capable of handling markdown editing.</p></li>
    <li><p> Contains a modular library to load the necessary functionality on demand.</p></li>
    <li><p> Provides a fully customizable toolbar.</p></li>
    <li><p> Provides HTML view to edit the source directly for developers.</p></li>
    <li><p> Supports third - party library integration.</p></li>
    </ul>
</SfRichTextEditor>

```

The output will be as follows.

![Iframe](./images/iframe-default.png)

## IFrame attributes

The editor allows you to pass an additional attribute to body tag of a `<iframe>` element using `Attributes` fields of `RichTextEditorIframeSettings` property. This property contains name/value pairs in string format. It is used to override the default appearance of the content area.

```csharp

@using Syncfusion.Blazor.RichTextEditor

<SfRichTextEditor>
    <RichTextEditorIFrameSettings Enable="true" Attributes="@IframeAttributes" />
    <p>The Rich Text Editor component is WYSIWYG ('what you see is what you get') editor that provides the best user experience to create and update the content. Users can format their content using standard toolbar commands.</p>
    <p><b> Key features:</b></p>
    <ul>
        <li><p> Provides <b>IFRAME</b> and <b>DIV</b> modes </p></li>
        <li><p> Capable of handling markdown editing.</p></li>
        <li><p> Contains a modular library to load the necessary functionality on demand.</p></li>
        <li><p> Provides a fully customizable toolbar.</p></li>
        <li><p> Provides HTML view to edit the source directly for developers.</p></li>
        <li><p> Supports third - party library integration.</p></li>
    </ul>
</SfRichTextEditor>

@code {
    private Dictionary<string, object> IframeAttributes = new Dictionary<string, object>() {
        { "style", "background: lightgray;" }
    };
}

```

## Adding external CSS/Script File

The editor offers you to add external CSS file to style the `<iframe>` element. Easily change the appearance of editor’s content using an external CSS file using `Resources - Styles` field in the `RichTextEditorIframeSettings` property.

Likewise, add the external script file to the `<iframe>` element using `Resources - Scripts` field of `RichTextEditorIframeSettings` to provide the additional functionalities to the Rich Text Editor.

```csharp

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

```

> You can refer to our [Blazor Rich Text Editor](https://www.syncfusion.com/blazor-components/blazor-wysiwyg-rich-text-editor) feature tour page for its groundbreaking feature representations. You can also explore our [Blazor Rich Text Editor](https://blazor.syncfusion.com/demos/rich-text-editor/overview?theme=bootstrap4) example to knows how to render and configure the rich text editor tools.

## See Also

* [How to change the editor mode](./editor-modes/#markdown-editor)