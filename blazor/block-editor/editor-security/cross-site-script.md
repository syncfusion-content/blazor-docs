---
layout: post
title: Cross-Site scripting in Blazor Block Editor Component | Syncfusion
description: Learn about Cross-Site Scripting (XSS) prevention and HTML sanitization features in the Blazor Block Editor component.
platform: Blazor
control: BlockEditor
documentation: ug
---

# Cross-Site scripting (XSS) prevention in Blazor Block Editor component

The Block Editor allows users to edit content securely by preventing cross-site scripting (XSS) attacks. By default, it provides built-in support to remove potentially malicious elements from editor content that could cause XSS attacks. The editor removes elements and attributes that could execute scripts, such as `<script>` tags and event handler attributes like `onmouseover`, `onclick`, and similar JavaScript execution vectors.

## Enabling XSS prevention

The [EnableHtmlSanitizer](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.SfBlockEditor.html#Syncfusion_Blazor_BlockEditor_SfBlockEditor_EnableHtmlSanitizer) property, enabled by default, activates XSS prevention. When active, the editor automatically removes potentially dangerous elements like `<script>` and attributes like `onmouseover` from the content.

The following example shows XSS prevention removing a `<script>` tag and `onmouseover` attribute:

```cshtml

@using Syncfusion.Blazor.BlockEditor;

<div id="container">
    <SfBlockEditor Blocks="@BlocksData" EnableHtmlSanitizer="true"></SfBlockEditor>
</div>
@code {
    private List<BlockModel> BlocksData = new()
    {
        new BlockModel
        {
            BlockType = BlockType.Paragraph,
            Content = new()
            {
                new ContentModel
                {
                    ContentType = ContentType.Text,
                    Content = "<div onmouseover='javascript:alert(1)'>Prevention of Cross-Site Scripting (XSS) </div> <script>alert('hi')</script>"
                }
            }
        }
    };
}

```
