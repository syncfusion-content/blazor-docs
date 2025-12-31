---
layout: post
title: Controlling Editor Access | Blazor Block Editor Component | Syncfusion
description: Learn about controlling editor access and implementing read-only mode in the Syncfusion Blazor Block Editor component for Blazor Server and WebAssembly applications.
platform: Blazor
control: BlockEditor
documentation: ug
---

# Controlling Editor Access in Blazor Block Editor component

The Syncfusion Blazor Block Editor provides a read-only mode to control user interaction with the editor. This allows users to view formatted content without editing. These features are useful for displaying content without modifications or temporarily restricting input, such as when presenting archived documents, previewing content, or restricting editing permissions.

## Read-only mode

Read-only mode prevents users from editing the content in the Block Editor while preserving the ability to view formatted text. This feature is particularly useful when you want to display formatted content without permitting modifications.

To enable the read-only mode, set the [ReadOnly](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.SfBlockEditor.html#Syncfusion_Blazor_BlockEditor_SfBlockEditor_ReadOnly) property to `true`. The content remains viewable with its formatting intact, but editing is restricted.

The following example demonstrates how to enable read-only mode in the Block Editor:

```cshtml

@using Syncfusion.Blazor.BlockEditor;

<div id="container">
    <SfBlockEditor Blocks="@BlocksData" ReadOnly="true"></SfBlockEditor>
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
                    Content = "The Block Editor supports various content types. When the ReadOnly property is set to true, it prevents users from editing the content, making the editor display-only."
                }
            }
        }
    };
}

```
