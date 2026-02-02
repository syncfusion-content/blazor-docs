---
layout: post
title: Typography Blocks in Blazor Block Editor Component | Syncfusion
description: Learn about typography blocks like paragraphs, headings, quotes, and callouts in the Blazor Block Editor component.
platform: Blazor
control: BlockEditor
documentation: ug
---

# Typography Blocks in Blazor Block Editor Component

Typography blocks are essential for organizing and presenting text-based content. The Block Editor component supports various structural blocks—such as Paragraph, Heading, Collapsible (CollapsibleParagraph and CollapsibleHeading), Divider, Quote, and Callout—to help you format and structure content effectively.

## Configure paragraph block

Paragraph blocks are the most common type, used for standard text content. They serve as the default block type and provide basic text formatting options. To render a Paragraph block, set the [BlockType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.BlockType.html) property to [Paragraph](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.BlockType.html#Syncfusion_Blazor_BlockEditor_BlockType_Paragraph).

### BlockType

```cshtml
// Adding paragraph block
    new BlockModel
    {
        BlockType = BlockType.Paragraph,
        Content = {new ContentModel{ContentType = ContentType.Text, Content = "This is a paragraph block example."}}
    }
```

The below sample demonstrates the configuration of paragraph block in the Block Editor.

```cshtml
@using Syncfusion.Blazor.BlockEditor

<SfBlockEditor Blocks="BlockData"></SfBlockEditor>

@code {
    private List<BlockModel> BlockData = new()
    {
        new BlockModel
        {
            BlockType = BlockType.Paragraph,
            Content = new() {new ContentModel{ContentType = ContentType.Text, Content = "This is a paragraph block example."}}
        }
    };
}
```

![Blazor Block Editor Paragraph Block](./../images/paragraph-block.png)


### Configure placeholder

You can configure placeholder text for block using the [Placeholder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.ParagraphBlockSettings.html#Syncfusion_Blazor_BlockEditor_ParagraphBlockSettings_Placeholder) property. This text appears when the block is empty. The default placeholder for the paragraph block is `Write something or ‘/’ for commands.`.

### BlockType and Properties

```cshtml
// Adding placeholder
    new BlockModel
    {
        BlockType = BlockType.Paragraph,
        Properties = new ParagraphBlockSettings {Placeholder = "Start typing..."}
    }
```

The below sample demonstrates the configuration of placeholder in the Block Editor for the paragraph block.

```cshtml
@using Syncfusion.Blazor.BlockEditor

<SfBlockEditor Blocks="@BlockData"></SfBlockEditor>

@code {
    private List<BlockModel> BlockData = new()
    {
        new BlockModel
        {
            BlockType = BlockType.Paragraph,
            Content = new() {new ContentModel{ContentType = ContentType.Text, Content = "This is a sample paragraph block."}}
        },
        new BlockModel
        {
            BlockType = BlockType.Paragraph,
            Properties = new ParagraphBlockSettings { Placeholder = "Start typing your notes or press \" /\" for commands..." }
        },
    };
}
```

![Blazor Block Editor Paragraph placeholder](./../images/paragraph-placeholder.png)

## Configure heading block

Heading blocks create document titles and section headers. These blocks help structure content hierarchically, making it easier to read and navigate. Render a Heading block by setting the [BlockType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.BlockType.html) property to [Heading](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.BlockType.html#Syncfusion_Blazor_BlockEditor_BlockType_Heading).

### Configuring levels

Set the heading level using the [Level](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.HeadingBlockSettings.html#Syncfusion_Blazor_BlockEditor_HeadingBlockSettings_Level) property, with `1` being the highest level (title) and `4` being the lowest (subsection).

### BlockType and Properties

```cshtml
//Adding Heading block
    new BlockModel
    {
        BlockType = BlockType.Heading,
        Properties = new HeadingBlockSettings { Level = 1}
    }
```

The following sample demonstrates the configuration of a heading block in the Block Editor.

```cshtml
@using Syncfusion.Blazor.BlockEditor

<SfBlockEditor Blocks="@BlockData"></SfBlockEditor>

@code {
    private List<BlockModel> BlockData = new()
    {
        new BlockModel
        {
            BlockType = BlockType.Heading,
            Properties = new HeadingBlockSettings { Level = 1},
            Content = new() {new ContentModel{ContentType = ContentType.Text, Content = "Main Document Title"}}
        },
        new BlockModel
        {
            BlockType = BlockType.Heading,
            Properties = new HeadingBlockSettings { Level = 2},
            Content = new() {new ContentModel{ContentType = ContentType.Text, Content = "Chapter Overview"}}
        },
        new BlockModel
        {
            BlockType = BlockType.Heading,
            Properties = new HeadingBlockSettings { Level = 3},
            Content = new() {new ContentModel{ContentType = ContentType.Text, Content = "Section Introduction"}}
        },
        new BlockModel
        {
            BlockType = BlockType.Heading,
            Properties = new HeadingBlockSettings { Level = 4},
            Content = new() {new ContentModel{ContentType = ContentType.Text, Content = "Sub-section Details"}}
        },
    };
}
```

![Blazor Block Editor Heading Blocks](./../images/heading-block.png)

### Configure placeholder

You can configure placeholder text for block using the [Placeholder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.HeadingBlockSettings.html#Syncfusion_Blazor_BlockEditor_HeadingBlockSettings_Placeholder) property. This text appears when the block is empty. The default placeholder for heading block is `Heading{level}`.

```cshtml
//Adding Placeholder value to blocktype
    new BlockModel
    {
        BlockType = BlockType.Heading,
        Properties = new HeadingBlockSettings { Level = 1, Placeholder = "Heading1" }
    }
```

## Configure collapsible blocks

You can render Collapsible blocks by setting the [BlockType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.BlockType.html) property as [CollapsibleParagraph](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.BlockType.html#Syncfusion_Blazor_BlockEditor_BlockType_CollapsibleParagraph) or [CollapsibleHeading](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.BlockType.html#Syncfusion_Blazor_BlockEditor_BlockType_CollapsibleHeading). Collapsible blocks allow users to expand or collapse sections, providing a way to hide or show content as needed.

### Configure levels

You can configure the CollapsibleHeading using the property [Level](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.CollapsibleHeadingBlockSettings.html#Syncfusion_Blazor_BlockEditor_CollapsibleHeadingBlockSettings_Level) inside the [Properties](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.BlockModel.html#Syncfusion_Blazor_BlockEditor_BlockModel_Properties) property . The levels can be varied from `Level: 1` to `Level: 4`.

### Configure children

The Block Editor supports hierarchical content structures through the `Children` property. This property can be achieved through [Properties](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.BlockModel.html#Syncfusion_Blazor_BlockEditor_BlockModel_Properties) property that allows you to create nested blocks, which is applicable only for Callout and Collapsible blocks.

Child blocks can be configured with all the same properties as top-level blocks.

### Configure expanded state

You can control whether a block is expanded or collapsed using the [IsExpanded](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.CollapsibleHeadingBlockSettings.html#Syncfusion_Blazor_BlockEditor_CollapsibleHeadingBlockSettings_IsExpanded) property. By default, this property is set to `false`, meaning the block will be collapsed initially. This setting is only applicable to Collapsible blocks.

### BlockType and Properties

```cshtml
//Configure collapsibleHeading block
    new BlockModel
    {
        BlockType = BlockType.CollapsibleHeading,
        Properties = new CollapsibleHeadingBlockSettings { Level = 1, IsExpanded = true, Children = new List<BlockModel> { //Your content to be here.. } }
    }
// Configuring CollapsibleParagraph block
    new BlockModel
    {
        BlockType = BlockType.CollapsibleParagraph,
        Properties = new CollapsibleParagraphBlockSettings { Children = new List<BlockModel> { //Your content to be here.. } }
    }
```

This example shows how to configure [CollapsibleHeading](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.BlockType.html#Syncfusion_Blazor_BlockEditor_BlockType_CollapsibleHeading) and [CollapsibleParagraph](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.BlockType.html#Syncfusion_Blazor_BlockEditor_BlockType_CollapsibleParagraph) blocks.

```cshtml
@using Syncfusion.Blazor.BlockEditor

<SfBlockEditor Blocks="@BlockData"></SfBlockEditor>

@code {
    private List<BlockModel> BlockData = new()
    {
        new BlockModel
        {
            BlockType = BlockType.CollapsibleHeading,
            Content = new() {new ContentModel{ContentType = ContentType.Text, Content = "Collapsible Section"}},
            Properties = new CollapsibleHeadingBlockSettings { Level = 1, IsExpanded = true, Children = new()
            {
                new BlockModel
                {
                    BlockType = BlockType.Paragraph,
                    Content = new() {new ContentModel{ContentType = ContentType.Text, Content = "This content is inside a toggle section and can be collapsed."}}
                }
            } }
        },
        new BlockModel
        {
            BlockType = BlockType.CollapsibleParagraph,
            Content = new() {new ContentModel{ContentType = ContentType.Text, Content = "Toggle paragraph section"}},
            Properties = new CollapsibleParagraphBlockSettings { IsExpanded = false, Children = new()
            {
                new BlockModel
                {
                    BlockType = BlockType.Paragraph,
                    Content = new() {new ContentModel{ContentType = ContentType.Text, Content = "This content is initially hidden because isExpanded is set to false."}}
                }
            } }
        }
    };
}
```

![Blazor Block Editor Toggle Blocks](./../images/toggle-blocks.png)

### Configure placeholder

You can configure placeholder text for block using the [CollapsibleHeading Placeholder][https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.CollapsibleHeadingBlockSettings.html#Syncfusion_Blazor_BlockEditor_CollapsibleHeadingBlockSettings_Placeholder] and [CollapsibleParagraph Placeholder][https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.CollapsibleParagraphBlockSettings.html#Syncfusion_Blazor_BlockEditor_CollapsibleParagraphBlockSettings_Placeholder] property. This text appears when the block is empty. The default placeholder for collapsible heading and collapsible paragraph is `Collapsible Heading{level}` and `Collapsible Paragraph` respectively.

```cshtml
// Adding placeholder value to collapsible heading
new BlockModel
{
    BlockType = BlockType.CollapsibleHeading,
    Properties = new CollapsibleParagraphBlockSettings { Level = 2, Placeholder = "Heading block" }
}
//Adding placeholder value for collapsible paragraph
new BlockModel
{
    BlockType = BlockType.CollapsibleParagraph,
    Properties = new CollapsibleParagraphBlockSettings { Placeholder = "Collapsible Paragraph" }
}
```

## Configure divider block

A Divider block inserts a horizontal line to separate content. Render it by setting the [BlockType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.BlockType.html) to [Divider](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.BlockType.html#Syncfusion_Blazor_BlockEditor_BlockType_Divider).

This sample shows how to place a divider between two blocks.

```cshtml
@using Syncfusion.Blazor.BlockEditor

<SfBlockEditor Blocks="@BlockData"></SfBlockEditor>

@code {
    private List<BlockModel> BlockData = new()
    {
        new BlockModel
        {
            BlockType = BlockType.Paragraph,
            Content = new() {new ContentModel{ContentType = ContentType.Text, Content = "This section discusses the features of the Block Editor."}}
        },
        new BlockModel
        {
          BlockType = BlockType.Divider  
        },
        new BlockModel
        {
            BlockType = BlockType.Paragraph,
            Content = new() {new ContentModel{ContentType = ContentType.Text, Content = "This section covers implementation details and usage examples."}}
        }
    };
}
```

![Blazor Block Editor Divider Block](./../images/divider-block.png)

## Configure quote block

Quote blocks are styled for displaying quotations or excerpts. Render a Quote block by setting the [BlockType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.BlockType.html) to [Quote](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.BlockType.html#Syncfusion_Blazor_BlockEditor_BlockType_Quote).

The following sample shows how to configure a quote block.

```cshtml
@using Syncfusion.Blazor.BlockEditor

<SfBlockEditor Blocks="@BlockData"></SfBlockEditor>

@code {
    private List<BlockModel> BlockData = new()
    {
        new BlockModel
        {
            BlockType = BlockType.Quote,
            Content = new() {new ContentModel{ContentType = ContentType.Text, Content = "The greatest glory in living lies not in never falling, but in rising every time we fall."}}
        }
    };
}
```

![Blazor Block Editor Quote Block](./../images/quote-block.png)

### Configure placeholder

You can configure placeholder text for block using the [Placeholder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.QuoteBlockSettings.html#Syncfusion_Blazor_BlockEditor_QuoteBlockSettings_Placeholder) property. This text appears when the block is empty. The default placeholder for quote block is `Write a quote`.

```cshtml
// Adding placeholder value to block type
new BlockModel
{
    BlockType = BlockType.Quote,
    Properties = new QuoteBlockSettings { Placeholder = "Quote"}
}
```

## Configure callout block

Callout blocks highlight important information such as notes, warnings, or tips. Render one by setting the [BlockType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.BlockType.html) to [Callout](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.BlockType.html#Syncfusion_Blazor_BlockEditor_BlockType_Callout).

The following sample adds a callout block to the editor.

```cshtml
@using Syncfusion.Blazor.BlockEditor

<SfBlockEditor Blocks="@BlockData"></SfBlockEditor>

@code {
    private List<BlockModel> BlockData = new()
    {
        new BlockModel
        {
            BlockType = BlockType.Callout,
            Properties = new CalloutBlockSettings { 
                Children = new()
                {
                    new BlockModel
                    {
                        BlockType = BlockType.Paragraph,
                        Content = new() { new ContentModel{ ContentType = ContentType.Text, Content = "Important information: This is a callout block used to highlight important content." }}
                    }
                }
                
            }
        }
    };
}
```

![Blazor Block Editor Callout Block](./../images/callout-block.png)

### Configure children

The Block Editor supports hierarchical content structures through the [Children](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.ChildrenBlockSettings.html#Syncfusion_Blazor_BlockEditor_ChildrenBlockSettings_Children) property. This property allows you to create nested blocks, which is applicable only for Callout and Collapsible blocks.

Child blocks can be configured with all the same properties as top-level blocks.

### Configure parent id

The Block Editor supports hierarchical content through the [Children](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.ChildrenBlockSettings.html#Syncfusion_Blazor_BlockEditor_ChildrenBlockSettings_Children) property, which is available for [Callout](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.BlockType.html#Syncfusion_Blazor_BlockEditor_BlockType_Callout) and `Collapsible` blocks. To establish a clear parent-child relationship, the [ParentID](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.BlockModel.html#Syncfusion_Blazor_BlockEditor_BlockModel_ParentID) of each child block must match the [ID](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.BlockModel.html#Syncfusion_Blazor_BlockEditor_BlockModel_ID) of its parent block.

This structure is essential for maintaining nested relationships within the editor. The following sample demonstrates how to create a nested hierarchy.

```cshtml
@using Syncfusion.Blazor.BlockEditor

<SfBlockEditor Blocks="@BlockData"></SfBlockEditor>

@code {
    private List<BlockModel> BlockData = new()
    {
        new BlockModel
        {
            ID = "security-callout",
            BlockType = BlockType.Callout,
            Properties = new CalloutBlockSettings { 
                Children = new()
                {
                    new BlockModel
                    {
                        ID = "security-title",
                        ParentID = "security-callout",
                        BlockType = BlockType.Heading,
                        Properties = new HeadingBlockSettings { Level = 3},
                        Content = new() { new ContentModel{ ContentType = ContentType.Text, Content = "Security Notice" }}
                    },
                    new BlockModel
                    {
                        ID = "security-warning",
                        ParentID = "security-callout",
                        BlockType = BlockType.Paragraph,
                        Content = new() { new ContentModel{ ContentType = ContentType.Text, Content = "Always validate user input before processing to prevent security vulnerabilities." }}
                    },
                    new BlockModel
                    {
                        ID = "security-tips",
                        ParentID = "security-callout",
                        BlockType = BlockType.Paragraph,
                        Content = new() { new ContentModel{ ContentType = ContentType.Text, Content = "Use HTTPS for all data transmission" }},
                        Indent = 1
                    },
                    new BlockModel
                    {
                        ID = "security-tips-2",
                        ParentID = "security-callout",
                        BlockType = BlockType.Paragraph,
                        Content = new() { new ContentModel{ ContentType = ContentType.Text, Content = "Implement proper authentication mechanisms" }},
                        Indent = 1
                    },
                    new BlockModel
                    {
                        ID = "security-tips-3",
                        ParentID = "security-callout",
                        BlockType = BlockType.Paragraph,
                        Content = new() { new ContentModel{ ContentType = ContentType.Text, Content = "Regularly update dependencies and libraries" }},
                        Indent = 1
                    },
                }
                
            }
        }
    };
}
```

![Blazor Block Editor Children](./../images/children.png)
