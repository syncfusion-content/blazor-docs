---
layout: post
title: How to Update Value in Blazor RichTextEditor Component | Syncfusion
description: Checkout and learn about how to update value in Blazor RichTextEditor component of Syncfusion, and more details.
platform: Blazor
control: RichTextEditor
documentation: ug
---

# Capture ctrl+s to update the value

To achieve this, the `keydown` event has to be bound to the Rich Text Editor content and the `ctrl + s` key press is captured using its `keyCode`. In the `keydown` event handler, the `updateValue` method is called to update the `value` property and then the content is saved in the required database using the same.

```cshtml

@using Syncfusion.Blazor.RichTextEditor

<div class="control-section">
    <SfRichTextEditor ID="defalt_RTE" ref="rteObj" onkeydown="@onKeydown" >
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
            <li><p> Allows preview of modified content before saving it.</p></li>
        </ul>
    </SfRichTextEditor>
</div>

@functions {
    SfRichTextEditor rteObj;

    public static object[] tools = new object[] {
        "Bold", "Italic", "Underline", "StrikeThrough",
        "FontName", "FontSize", "FontColor", "BackgroundColor",
        "LowerCase", "UpperCase", "|",
        "Formats", "Alignments", "OrderedList", "UnorderedList",
        "Outdent", "Indent", "|", "CreateTable",
        "CreateLink", "Image", "|", "ClearFormat", "Print",
        "SourceCode", "FullScreen", "|", "Undo", "Redo"
    };
    public void onKeydown(KeyboardEventArgs arg) {
        if (arg.Key == "s" && arg.CtrlKey == true) {
            this.rteObj.UpdateValue();
            var value = this.rteObj.Value;
        }
    }
}

```