---
layout: post
title: Undo redo in Blazor Block Editor Component | Syncfusion
description: Checkout and learn about Undo redo with Syncfusion Blazor Block Editor component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: BlockEditor
documentation: ug
---

# Undo redo in Blazor Block Editor component

The undo/redo feature in Block Editor enables users to revert or reapply changes made to the content, offering a safety net for edits and enhancing the overall editing experience.

## Keyboard shortcuts

| Action | Windows | Mac | Description |
|------------|--------------|---------|-----------------|
| Undo       | Ctrl + Z     | ⌘ + Z   | Reverts the last action. |
| Redo       | Ctrl + Y     | ⌘ + Y | Reapplies the last undone action. |

## Configuring Undo/Redo stack

The Block Editor stores a history of actions, allowing users to perform undo and redo operations. By default, it saves up to `30` actions. You can customize this limit using the `UndoRedoStack` property to control the maximum number of steps that can be undone or redone.

The example below sets the undo/redo history limit to `20` actions.


```cshtml

@using Syncfusion.Blazor.BlockEditor;

<div id="container">
    <SfBlockEditor ID="blockeditor" Blocks="@BlocksData" UndoRedoStack=20>
    </SfBlockEditor>
</div>
@code {
    private List<BlockModel> BlocksData = new List<BlockModel>
    {
        new BlockModel
        {
            ID = "block-1",
            BlockType = BlockType.Heading,
            Properties = new HeadingBlockSettings { Level = 1 },
            Content = new List<ContentModel>
            {
                new ContentModel
                {
                    ContentType = ContentType.Text,
                    Content = "Undo/Redo Demo"
                }
            }
        },
        new BlockModel
        {
            ID = "block-2",
            BlockType = BlockType.Paragraph,
            Content = new List<ContentModel>
            {
                new ContentModel
                {
                    ContentType = ContentType.Text,
                    Content = "Try adding new blocks or modifying content below:"
                }
            }
        },
        new BlockModel
        {
            ID = "block-3",
            BlockType = BlockType.Paragraph,
            Content = new List<ContentModel>
            {
                new ContentModel
                {
                    ContentType = ContentType.Text,
                    Content = "1. Undo stack set to maximum 40 actions\n2. Press Ctrl+Z to undo\n3. Press Ctrl+Y to redo\n4. Actions include text edits, block moves, additions, deletions"
                }
            }
        }
    };
}
<style>
    #container {
        margin: 50px;
        gap: 20px;
        display: flex;
        flex-direction: column;
        align-items: center;
    }
</style>


```

![Blazor Block Editor Undo Redo](./images/undo-redo.png)
