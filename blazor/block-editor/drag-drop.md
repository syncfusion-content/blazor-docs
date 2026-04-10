---
layout: post
title: Drag and Drop in Blazor Block Editor Component | Syncfusion
description: Checkout and learn about Drag and Drop with Syncfusion Blazor Block Editor component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: BlockEditor
documentation: ug
---

# Drag and drop in Blazor Block Editor component

The drag and drop feature in the Block Editor allows users to intuitively rearrange content blocks by dragging them to different positions within the editor.

## Enable Drag and Drop

You can control the drag and drop functionality within the Block Editor using the [EnableDragAndDrop](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.SfBlockEditor.html#Syncfusion_Blazor_BlockEditor_SfBlockEditor_EnableDragAndDrop) property. This feature is enabled by default.

## Dragging blocks

When drag and drop is enabled, users can rearrange blocks in the following ways:

The Block Editor supports both single and multiple block dragging. Users can drag individual blocks or select multiple blocks and drag them together to a new position.

- **Single Block Dragging**: To drag a single block, hover over it to reveal the drag handle. Click and hold the handle, then drag the block to a new position.

- **Multiple Block Dragging**: To move multiple blocks, first select the desired blocks. Once selected, click and drag the entire group to a new location.

During the drag operation, a visual indicator will show precisely where the blocks will be placed when dropped, ensuring accurate placement.

Below sample demonstrates the usage of drag and drop feature in the editor.

```cshtml
@using Syncfusion.Blazor.BlockEditor

<SfBlockEditor Blocks="BlockData" EnableDragAndDrop="true"> </SfBlockEditor>

@code {

    private List<BlockModel> BlockData = new()
    {
        new BlockModel
        {
            BlockType = BlockType.Paragraph,
            Content = new() {new ContentModel {ContentType = ContentType.Text, Content = "Block 1" }}
        },
        new BlockModel
        {
            BlockType = BlockType.Paragraph,
            Content = new() {new ContentModel {ContentType = ContentType.Text, Content = "Block 2" }}
        },
        new BlockModel
        {
            BlockType = BlockType.Paragraph,
            Content = new() {new ContentModel {ContentType = ContentType.Text, Content = "Block 3" }}
        }
    };
}
```

![Blazor Block Editor DragDrop](./images/drag-drop.webp)