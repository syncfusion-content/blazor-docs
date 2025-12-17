---
layout: post
title: Cross-Site scripting in Blazor Block Editor Component | Syncfusion
description: Checkout and learn here all about Cross-Site scripting with Syncfusion Blazor Block Editor component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: BlockEditor
documentation: ug
---

# Cross-Site scripting (XSS) prevention in Blazor Block Editor component

The Block Editor allows users to edit the content with security by preventing cross-site scripting (XSS). By default, it provides built-in support to remove elements from editor content that cause XSS attacks. The editor removes the elements based on the attributes if it is possible to execute a script.

## Enabling XSS prevention

The [EnableHtmlSanitizer](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.SfBlockEditor.html#Syncfusion_Blazor_BlockEditor_SfBlockEditor_EnableHtmlSanitizer), enabled by default, activates XSS prevention. When active, the editor automatically removes elements like `<script>` and attributes like `onmouseover` from the content.
The following example shows XSS prevention removing a `<script>` tag and `onmouseover` attribute:

```cshtml

@using Syncfusion.Blazor.BlockEditor;

<div id="container">
    <SfBlockEditor Blocks="@BlocksData" EnableHtmlSanitizer=true></SfBlockEditor>
</div>
@code {
    private List<BlockModel> BlocksData = new List<BlockModel>
    {
        new BlockModel
        {
            BlockType = BlockType.Paragraph,
            Content = new List<ContentModel>
            {
                new ContentModel
                {
                    ContentType = ContentType.Text,
                    Content = "<div onmouseover='javascript:alert(1)'>Prevention of Cross Sit Scripting (XSS) </div> <script>alert('hi')</script>"
                }
            }
        }
    };
}

```
