---
layout: post
title: Table Blocks in Blazor Block Editor Component | Syncfusion
description: Checkout and learn about Table Blocks in Syncfusion Blazor Block Editor component and more.
platform: Blazor
control: Block Editor
documentation: ug
---

# Table Blocks in Blazor Block Editor component

The Syncfusion Block Editor allows you to render structured data in rows and columns by setting the block's `BlockType` property to `Table`. You can customize the table layout, header, row numbers, and define columns and rows using the `Properties` property.

### Configure Table Block

For Table blocks, you can configure layout and structure using the `Properties` property. This property supports the following options:

| Property | Description | Default Value |
|----------|-------------|---------------|
| width | Specifies the display width of the table. | `100%` |
| enableHeader | Specifies whether to enable header for the table. | `true` |
| enableRowNumbers | Specifies whether to enable row numbers for the table. | `true` |
| readOnly | Specifies whether to render the table in read-only mode, disabling edits. | `false` |
| columns | Defines the columns of the table, including their types and headers. | `[]` |
| rows | Defines the rows of the table, each containing cells tied to columns. | `[]` |

The following example demonstrates how to pre-configure a `Table` block in the editor.

```cshtml
@using Syncfusion.Blazor.BlockEditor

<SfBlockEditor Blocks="@BlockData"></SfBlockEditor>

@code {
    private List<BlockModel> BlockData = new List<BlockModel>
    {
        new BlockModel
        {
            BlockType = BlockType.Table,
            Properties = new TableBlockSettings
            {
                Columns =
                {
                    new TableColumnModel
                    {
                        ID = "col1"
                    },
                    new TableColumnModel
                    {
                        ID = "col2"
                    }
                },
                Rows =
                {
                    new TableRowModel
                    {
                        ID = "row1",
                        Cells =
                        {
                            new TableCellModel
                            {
                                ColumnId = "col1",
                                Blocks =
                                {
                                    new BlockModel
                                    {
                                        ID = "c1_p",
                                        BlockType = BlockType.Paragraph,
                                        Content = {new ContentModel{ID = "c1_t",ContentType = ContentType.Text, Content = "Cell1"}}
                                    }
                                }
                            },
                            new TableCellModel
                            {
                                ColumnId = "col2",
                                Blocks =
                                {
                                    new BlockModel
                                    {
                                        ID = "c2_p",
                                        BlockType = BlockType.Paragraph,
                                        Content = {new ContentModel{ID = "c2_t",ContentType = ContentType.Text, Content = "Cell2"}}
                                    }
                                }
                            }
                        }
                    },
                    new TableRowModel
                    {
                        ID = "row2",
                        Cells =
                        {
                            new TableCellModel
                            {
                                ColumnId = "col1",
                                Blocks =
                                {
                                    new BlockModel
                                    {
                                        ID = "c3_p",
                                        BlockType = BlockType.Paragraph,
                                        Content = {new ContentModel{ID = "c3_t",ContentType = ContentType.Text, Content = "Cell3"}}
                                    }
                                }
                            },
                            new TableCellModel
                            {
                                ColumnId = "col2",
                                Blocks =
                                {
                                    new BlockModel
                                    {
                                        ID = "c4_p",
                                        BlockType = BlockType.Paragraph,
                                        Content = {new ContentModel{ID = "c4_t",ContentType = ContentType.Text, Content = "Cell4"}}
                                    }
                                }
                            }
                        }
                    }
                }
            }
        },
        new BlockModel
        {
            BlockType = BlockType.Paragraph,
            Content ={new ContentModel{ContentType = ContentType.Text, Content = "This is a paragraph block example."}}
        }
    };
}
```

![Blazor Block Editor Table Block](./images/table-block.png)