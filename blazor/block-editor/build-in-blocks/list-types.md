---
layout: post
title: Lists in Blazor BlockEditor Component | Syncfusion
description: Checkout and learn about List Blocks with Blazor BlockEditor component in Blazor WebAssembly App.
platform: Blazor
control: BlockEditor
documentation: ug
---

# Lists in Blazor blockEditor component

List blocks in the BlockEditor component are used to organize content into structured lists. You can render List blocks by setting the [BlockType] property as `BulletList`, `NumberedList`, or `Checklist`. Bullet lists and numbered lists are ideal for unordered and ordered items, respectively, while checklist blocks enable interactive to-do lists with checkable items.

## Configure bullet list 

You can render Bullet List block by setting the [BlockType] property as `BulletList`. This block type is used for unordered lists.

### Type

```cshtml
// Adding bulletlist block
    new BlockModel
    {
        BlockType = BlockType.BulletList,
        Content = {new ContentModel{ContentType = ContentType.Text, Content = "your content"}}
    }
```

### Configure placeholder

You can configure placeholder text for block using the [Placeholder] property. This text appears when the block is empty. The default placeholder for bullet list is  `Add item`.

```cshtml
// Adding placeholder value
    new BlockModel
    {
        BlockType = BlockType.BulletList,
        Properties = new BulletListBlockSettings {Placeholder = "bullet"},
        Content = {new ContentModel{ContentType = ContentType.Text, Content = "your content"}}
    }
```

## Configure numbered list

You can render Numbered List block by setting the [BlockType] property as  `NumberedList`.This block type is used for ordered lists.

```cshtml
// Adding numberedlist block
    new BlockModel
    {
        BlockType = BlockType.NumberedList,
        Content = {new ContentModel{ContentType = ContentType.Text, Content = "your content"}}
    }
```

### Configure placeholder

You can configure placeholder text for block using the [Placeholder] property. This text appears when the block is empty. The default placeholder for numbered list is  `Add item`.

```cshtml
// Adding placeholder value
    new BlockModel
    {
        BlockType = BlockType.BulletList,
        Properties = new NumberedListBlockSettings {Placeholder = "number"},
        Content = {new ContentModel{ContentType = ContentType.Text, Content = "your content"}}
    }
```

## Configure checklist

You can render Check List block by setting the [BlockType] property as `Checklist`. This block type is used for creating interactive to-do lists.

```cshtml
// Adding checklist block 
    new BlockModel
    {
        BlockType = BlockType.Checklist,
        Content = {new ContentModel{ContentType = ContentType.Text, Content = "your content"}}
    }
```

### Configure checked state

For blocks that support selection states such as `CheckList`, you can configure the checked state using the `Properties` property with [IsChecked].

By default, the [IsChecked] property is set to `false`.

```cshtml
@using Syncfusion.Blazor.BlockEditor

<div class="paste-blockeditor">
    <SfBlockEditor Blocks="BlockData"></SfBlockEditor>
</div>

@code {
    private List<BlockModel> BlockData = new List<BlockModel>
    {
        new BlockModel
        {
            BlockType = BlockType.Paragraph,
            Content = {new ContentModel{ContentType = ContentType.Text, Content = "Task List:"}}
        },
        new BlockModel
        {
            BlockType = BlockType.Checklist,
            Content = {new ContentModel{ContentType = ContentType.Text, Content = "Completed task (checked)"}},
            Properties = new ChecklistBlockSettings {IsChecked = true}
        },
        new BlockModel
        {
            BlockType = BlockType.Checklist,
            Content = {new ContentModel{ContentType = ContentType.Text, Content = "Pending task (unchecked)"}},
            Properties = new ChecklistBlockSettings {IsChecked = false}
        },
        new BlockModel
        {
            BlockType = BlockType.Checklist,
            Content = {new ContentModel{ContentType = ContentType.Text, Content = "High priority task"}},
            Properties = new ChecklistBlockSettings {IsChecked = true}
        },
        new BlockModel
        {
            BlockType = BlockType.Checklist,
            Content = {new ContentModel{ContentType = ContentType.Text, Content = "Low priority task"}},
            Properties = new ChecklistBlockSettings {IsChecked = false}
        }
    };
}

```

![Blazor BlockEditor Block IsChecked](./images/is-checked.png)

### Configure placeholder

You can configure placeholder text for block using the [Placeholder] property. This text appears when the block is empty. The default placeholder for check list is  `To Do`.

```cshtml
// Adding placeholder value
    new BlockModel
    {
        BlockType = BlockType.Checklist,
        Properties = new ChecklistBlockSettings {Placeholder = "check"},
        Content = {new ContentModel{ContentType = ContentType.Text, Content = "your content"}}
    }
```

## Configure list blocks

Below example illustrates how to render the different types of list blocks in the Block Editor.

```cshtml

@using Syncfusion.Blazor.BlockEditor

<div class="paste-blockeditor">
    <SfBlockEditor Blocks="BlockData"></SfBlockEditor>
</div>

@code {
    private List<BlockModel> BlockData = new List<BlockModel>
    {
        new BlockModel
        {
            BlockType = BlockType.BulletList,
            Content = {new ContentModel{ContentType = ContentType.Text, Content = "Features of the Block Editor"}}
        },
        new BlockModel
        {
            BlockType = BlockType.NumberedList,
            Content = {new ContentModel{ContentType = ContentType.Text, Content = "Step 1: Initialize the Block Editor"}}
        },
        new BlockModel
        {
            BlockType = BlockType.Checklist,
            Content = {new ContentModel{ContentType = ContentType.Text, Content = "Review documentation"}},
            Properties = new ChecklistBlockSettings {IsChecked = true}
        },
        new BlockModel
        {
            BlockType = BlockType.Checklist,
            Content = {new ContentModel{ContentType = ContentType.Text, Content = "Implement drag and drop functionality"}},
            Properties = new ChecklistBlockSettings {IsChecked = false}
        }
    };
}

```

![Blazor BlockEditor List Blocks](./images/list-blocks.png)
