---
layout: post
title: Format code block using toolbar in Blazor RichTextEditor | Syncfusion
description: Learn here all about formatting code block using toolbar button in Syncfusion Blazor RichTextEditor component and more.
platform: Blazor
control: RichTextEditor
documentation: ug
---

# Format code block using toolbar in Blazor RichTextEditor Component

You can configure code block formatting as a separate toolbar button by adding the **InsertCode** Command within the `RichTextEditorToolbarSettings` - `Items` property. The InsertCode button has a toggle state to apply code block formatting to the editor and remove code block formatting from the editor.

The following code will configure the InsertCode button in toolbar and set the background color to “pre” tag for highlighting the code block.

```cshtml

@using Syncfusion.Blazor.RichTextEditor

<SfRichTextEditor>
    <RichTextEditorToolbarSettings Items="@Tools" />
        <p>The Rich Text Editor component is WYSIWYG ('what you see is what you get') editor that provides the best user experience to create and update the content. Users can format their content using standard toolbar commands.</p>
        <p><b> Key features:</b></p>
        <ul>
            <li><p> Provides <b>IFRAME</b> and <b>DIV</b> modes </p></li>
            <li><p> Capable of handling markdown editing.</p></li>
            <li><p> Contains a modular library to load the necessary functionality on demand.</p></li>
            <li><p> Provides a fully customizable toolbar.</p></li>
            <li><p> Provides HTML view to edit the source directly for developers.</p></li>
            <li><p> Supports third - party library integration.</p></li>
            <li><p> Allows preview of modified content before saving it.</p></li>
        </ul>
</SfRichTextEditor>

<style>
    .e-richtexteditor .e-rte-content .e-content pre {
        padding: 10px;
        background: #F4F5F7 !important;
    }
</style>

@code{
    private List<ToolbarItemModel> Tools = new List<ToolbarItemModel>()
    {
        new ToolbarItemModel() { Command = ToolbarCommand.InsertCode }
    };
}

```

The output will be as follows.

![Format Code Block in Blazor RichTextEditor](../images/blazor-richtexteditor-format-code-block.png)