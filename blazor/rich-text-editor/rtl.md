---
layout: post
title: Rtl in Blazor RichTextEditor Component | Syncfusion 
description: Learn about Rtl in Blazor RichTextEditor component of Syncfusion, and more details.
platform: Blazor
control: RichTextEditor
documentation: ug
---

# RTL support

## RTL

Specifies the direction of the Rich Text Editor component using the `enableRtl` property. For writing systems that require it like Arabic, Hebrew, etc., the direction can be switched to right-to-left.

> `enableRtl` property will not change based on `locale` property.

```csharp

@using Syncfusion.Blazor.RichTextEditor

<SfRichTextEditor ID="defalt_RTE" EnableRtl="@EnableRtl">
    <RichTextEditorToolbarSettings Items="@tools"></RichTextEditorToolbarSettings>
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

@functions {
    private bool EnableRtl { get; set; } = true;

    public static object[] tools = new object[]{
        "Bold", "Italic", "Underline", "StrikeThrough",
        "FontName", "FontSize", "FontColor", "BackgroundColor",
        "LowerCase", "UpperCase", "|",
        "Formats", "Alignments", "OrderedList", "UnorderedList",
        "Outdent", "Indent", "|", "CreateTable",
        "CreateLink", "Image", "|", "ClearFormat", "Print",
        "SourceCode", "FullScreen", "|", "Undo", "Redo"
    };
}

```

> You can refer to our [Blazor Rich Text Editor](https://www.syncfusion.com/blazor-components/blazor-wysiwyg-rich-text-editor) feature tour page for its groundbreaking feature representations. You can also explore our [Blazor Rich Text Editor](https://blazor.syncfusion.com/demos/rich-text-editor/overview?theme=bootstrap4) example to knows how to render and configure the rich text editor tools.