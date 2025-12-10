---
layout: post
title: Blocks in Blazor BlockEditor Component | Syncfusion
description: Checkout and learn about Blocks with Blazor BlockEditor component in Blazor WebAssembly App.
platform: Blazor
control: BlockEditor
documentation: ug
---

# Blocks in Blazor BlockEditor component

The Block Editor component enables you to create block-based content editing solution using various types of blocks. The [Blocks] property allows you to define and manage the content structure of your editor.

## Blocks

Blocks are the fundamental building elements of the Block Editor. Each block represents a distinct content unit such as a `paragraph`, `heading`, `list`, or specialized content like `code snippets` or `images`. The Block Editor organizes content as a collection of `blocks`, allowing for better structure and formatting options.

You can configure blocks with various properties such as [ID], [Type], [Content], [Children] and more to create rich, structured editor.

## Block types

The Block Editor supports multiple block types. Each block type offers different formatting and functionality options:

| Built-in Block Types                    | Description                                       |
|-----------------------------------------|---------------------------------------------------|
| Paragraph                               | Default block type for regular text content.      |
| Heading1 to Heading4                    | Different levels of headings for document structure.|
| Checklist                               | Interactive to-do lists with checkable items.     |
| BulletList                              | Unordered lists with bullet points.               |
| NumberedList                            | Ordered lists with sequential numbering.          |
| Code                                    | Formatted code blocks with syntax highlighting.   |
| Quote                                   | Styled block for quotations.                      |
| Callout                                 | Highlighted block for important information.      |
| Divider                                 | Horizontal separator line.                        |
| CollapsibleParagraph and CollapsibleHeading1-4    | Collapsible content blocks.                       |
| Image                                   | Block for displaying images.                      |
| Template                                | Predefined custom templates.                      |

## Configure indent

You can specify the indentation level of a block using the [Indent] property. This property accepts a numeric value that determines how deeply a block is nested from the left margin.

By default, the [Indent] property is set to `0`.

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
            Content = {new ContentModel{ContentType = ContentType.Text, Content = "This is a paragraph with no indentation (indent: 0)"}},
            Indent = 0
        },
        new BlockModel
        {
            BlockType = BlockType.Paragraph,
            Content = {new ContentModel{ContentType = ContentType.Text, Content = "This paragraph has one level of indentation (indent: 1)"}},
            Indent = 1
        },
        new BlockModel
        {
            BlockType = BlockType.Paragraph,
            Content = {new ContentModel{ContentType = ContentType.Text, Content = "This paragraph has two levels of indentation (indent: 2)"}},
            Indent = 2
        },
        new BlockModel
        {
            BlockType = BlockType.Paragraph,
            Content = {new ContentModel{ContentType = ContentType.Text, Content = "Back to no indentation"}},
            Indent = 0
        }
    };
}

```

![Blazor BlockEditor Blocks Indent](./images/indent.png)

## Configure CSS Class

You can apply custom styling to individual blocks using the [CssClass] property. This property accepts a string containing one or more CSS class names.

Custom CSS classes allow you to define specialized styling for specific blocks in your editor.

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
            BlockType = BlockType.Heading,
            Properties = new HeadingBlockSettings { Level = 1 },
            Content = {new ContentModel{ContentType = ContentType.Text, Content = "Custom CSS Classes in Block Editor"}}
        },
        new BlockModel
        {
            BlockType = BlockType.Paragraph,
            Content = {new ContentModel{ContentType = ContentType.Text, Content = "Default paragraph block"}}
        },
        new BlockModel
        {
            BlockType = BlockType.Paragraph,
            Content = {new ContentModel{ContentType = ContentType.Text, Content = "This is an info block"}},
            CssClass = "info-block"
        },
        new BlockModel
        {
            BlockType = BlockType.Paragraph,
            Content = {new ContentModel{ContentType = ContentType.Text, Content = "This is a warning block"}},
            CssClass = "warning-block"
        },
        new BlockModel
        {
            BlockType = BlockType.Paragraph,
            Content = {new ContentModel{ContentType = ContentType.Text, Content = "This is a success block"}},
            CssClass = "success-block"
        },
        new BlockModel
        {
            BlockType = BlockType.Paragraph,
            Content = {new ContentModel{ContentType = ContentType.Text, Content = "This is a error block"}},
            CssClass = "error-block"
        },
        new BlockModel
        {
            BlockType = BlockType.Paragraph,
            Content = {new ContentModel{ContentType = ContentType.Text, Content = "This is a custom font block"}},
            CssClass = "custom-font"
        }
    };
}

```

![Blazor BlockEditor Blocks CssClass](./images/cssClass.png)
