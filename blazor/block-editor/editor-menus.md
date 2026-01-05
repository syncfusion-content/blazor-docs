---
layout: post
title: Editor Menus in Blazor Block Editor Component | Syncfusion
description: Learn to configure Slash Command menu, Context menu, Block Action menu, and Inline Toolbar in Syncfusion Blazor Block Editor.
platform: Blazor
control: BlockEditor
documentation: ug
---

# Editor Menus in Blazor Block Editor Component

The Block Editor component includes several intuitive, context-aware menus that streamline content creation and editing. These menus provide quick access to formatting options and commands, improving user productivity.

## Slash command menu

The Slash Command menu allows users to quickly insert or transform blocks by typing `/` followed by a command. This keyboard-driven approach provides an efficient way to interact with the editor without using the mouse.

### Built-in items

The Slash Command menu comes with a set of predefined commands for all block types:

- **Headings (Level 1 to 4)**: Inserts a heading block of the corresponding level.
- **Lists (Bullet, Numbered, Checklist)**: Creates a block for the specified list type.
- **Paragraph**: Inserts a standard text block.
- **Image**: Inserts a media block for images.
- **Table**: Inserts a table block.
- **Toggle**: Creates a collapsible content block.
- **Callout**: Inserts a block for highlighting important information.
- **Utility (Divider, Quote)**: Inserts a utility block like a divider or quote block.

### Customize slash command menu

Use the [BlockEditorCommandMenu](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.BlockEditorCommandMenu.html) tag directive to modify the Slash Command menu. This lets you add custom commands, remove default items, or change the behavior of existing commands to fit application requirements.

### Events

The following events are available for the Slash Command menu:

|Name|Args|Description|
|---|---|---|
|[Filtering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.BlockEditorCommandMenu.html#Syncfusion_Blazor_BlockEditor_BlockEditorCommandMenu_Filtering)|CommandFilteringEventArgs|Triggers when the user types to filter the command menu items.|
|[ItemSelect](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.BlockEditorCommandMenu.html#Syncfusion_Blazor_BlockEditor_BlockEditorCommandMenu_ItemSelect)|CommandItemSelectEventArgs|Triggers when the user clicks on a command menu item.|

The following example demonstrates how to customize the Slash Command menu with custom commands.

```cshtml
@using Syncfusion.Blazor.BlockEditor

<div id="container">
    <SfBlockEditor Blocks="@BlocksData">
        <BlockEditorCommandMenu PopupHeight="400px" 
                                PopupWidth="350px" 
                                Commands="@Commands" 
                                ItemSelect="@ItemSelect" 
                                Filtering="@Filtering">
        </BlockEditorCommandMenu>
    </SfBlockEditor>
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
                    Content = "Type '/' anywhere in this editor to open the custom slash command menu."
                }
            }
        }
    };

    private List<CommandItemModel> Commands = new List<CommandItemModel>
    {
        new CommandItemModel
        {
            ID = "line-cmd",
            Type = BlockType.Divider,
            GroupBy = "Utility",
            Label = "Insert a Line",
            IconCss = "e-icons e-divider"
        },
        new CommandItemModel
        {
            ID = "timestamp-cmd",
            GroupBy = "Actions",
            Label = "Insert Timestamp",
            IconCss = "e-icons e-schedule"
        }
    };

    private void ItemSelect(CommandItemSelectEventArgs args)
    {
        // Handle custom command actions based on args.Item.ID
    }

    private void Filtering(CommandFilteringEventArgs args)
    {
        // Filter commands based on args.Text
    }
}
```

## Context menu

The Context menu appears when a user right-clicks within a specific block. It provides context-aware actions relevant to the clicked block or content. Use this menu for actions that apply to the entire block or selected content within it.

### Built-in items

The Context menu offers the following built-in options:

- **Undo/Redo**: Reverses or reapplies the last action.
- **Cut/Copy/Paste**: Standard clipboard actions for selected content.
- **Indent**: Increases or decreases the indent level of the selected block.
- **Link**: Adds or edits a hyperlink for the selected text.

### Customize context menu

Use the [BlockEditorContextMenu](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.BlockEditorContextMenu.html) tag directive to customize the Context menu. This lets you add specific actions or modify existing items based on application needs.

### Events

The following events are available for the Context menu:

|Name|Args|Description|
|---|---|---|
|[Opening](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.BlockEditorContextMenu.html#Syncfusion_Blazor_BlockEditor_BlockEditorContextMenu_Opening)|ContextMenuOpeningEventArgs|Triggers before the context menu opens.|
|[Closing](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.BlockEditorContextMenu.html#Syncfusion_Blazor_BlockEditor_BlockEditorContextMenu_Closing)|ContextMenuClosingEventArgs|Triggers before the context menu closes.|
|[ItemSelect](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.BlockEditorContextMenu.html#Syncfusion_Blazor_BlockEditor_BlockEditorContextMenu_ItemSelect)|ContextMenuItemSelectEventArgs|Triggers when a context menu item is clicked.|

The following example demonstrates how to customize the Context menu with additional menu items.

```cshtml
@using Syncfusion.Blazor.BlockEditor

<div id="container">
    <SfBlockEditor Blocks="@BlocksData">
        <BlockEditorContextMenu Enable="true" 
                                ShowItemOnClick="true" 
                                Items="@CustomContextMenuItems" 
                                ItemSelect="@ItemSelect" 
                                Opening="@Opening" 
                                Closing="@Closing">
        </BlockEditorContextMenu>
    </SfBlockEditor>
</div>

@code {
    private List<BlockModel> BlocksData = new List<BlockModel>
    {
        new BlockModel
        {
            BlockType = BlockType.Heading,
            Properties = new HeadingBlockSettings { Level = 1 },
            Content = new List<ContentModel>
            {
                new ContentModel
                {
                    ContentType = ContentType.Text,
                    Content = "Context Menu Demo"
                }
            }
        },
        new BlockModel
        {
            BlockType = BlockType.Quote,
            Content = new List<ContentModel>
            {
                new ContentModel
                {
                    ContentType = ContentType.Text,
                    Content = "Right-click anywhere in this editor to open the custom context menu. Try different areas and blocks."
                }
            }
        }
    };

    private List<ContextMenuItemModel> CustomContextMenuItems = new List<ContextMenuItemModel>
    {
        new ContextMenuItemModel
        {
            ID = "format-menu",
            Text = "Format",
            IconCss = "e-icons e-format-painter",
            Items = new List<ContextMenuItemModel>
            {
                new ContextMenuItemModel { ID = "bold-item", Text = "Bold", IconCss = "e-icons e-bold" },
                new ContextMenuItemModel { ID = "italic-item", Text = "Italic", IconCss = "e-icons e-italic" },
                new ContextMenuItemModel { ID = "underline-item", Text = "Underline", IconCss = "e-icons e-underline" }
            }
        },
        new ContextMenuItemModel { Separator = true },
        new ContextMenuItemModel
        {
            ID = "statistics-item",
            Text = "Block Statistics",
            IconCss = "e-icons e-chart"
        },
        new ContextMenuItemModel
        {
            ID = "export-item",
            Text = "Export Options",
            IconCss = "e-icons e-export",
            Items = new List<ContextMenuItemModel>
            {
                new ContextMenuItemModel { ID = "export-json", Text = "Export as JSON", IconCss = "e-icons e-file-json" },
                new ContextMenuItemModel { ID = "export-html", Text = "Export as HTML", IconCss = "e-icons e-file-html" },
                new ContextMenuItemModel { ID = "export-pdf", Text = "Export as PDF", IconCss = "e-icons e-file-pdf" }
            }
        }
    };

    private void ItemSelect(ContextMenuItemSelectEventArgs args)
    {
        // Handle custom menu item actions
    }

    private void Opening(ContextMenuOpeningEventArgs args)
    {
        // Modify menu items before opening based on context
    }

    private void Closing(ContextMenuClosingEventArgs args)
    {
        // Perform cleanup actions when menu closes
    }
}
```

## Block action menu

The Block Action menu appears next to a block when hovering over it and clicking the drag handle icon. It offers quick actions specific to that block. Use this menu for block-level operations like moving, duplicating, or deleting blocks, as opposed to the Context menu which handles content-level actions.

### Built-in items

The Block Action menu provides convenient actions for managing individual blocks:

- **Duplicate**: Creates an exact copy of the current block.
- **Delete**: Removes the block from the editor.
- **Move Up**: Moves the block one position higher.
- **Move Down**: Moves the block one position lower.

### Customize block action menu

Use the [BlockEditorActionMenu](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.BlockEditorActionMenu.html) tag directive to customize the Block Action menu. This lets you add block-specific commands that are relevant to the application, allowing for a highly tailored user experience.

#### Show or Hide tooltip

By default, a tooltip is displayed when the user hovers over an action item. Show or hide the tooltip using the [EnableTooltip](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.BlockEditorActionMenu.html#Syncfusion_Blazor_BlockEditor_BlockEditorActionMenu_EnableTooltip) property in the [BlockEditorActionMenu](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.BlockEditorActionMenu.html) tag directive.

### Events

The following events are available for the Block action menu:

|Name|Args|Description|
|---|---|---|
|[Opening](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.BlockEditorActionMenu.html#Syncfusion_Blazor_BlockEditor_BlockEditorActionMenu_Opening)|ActionMenuOpeningEventArgs|Triggers when the block action menu is opened.|
|[Closing](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.BlockEditorActionMenu.html#Syncfusion_Blazor_BlockEditor_BlockEditorActionMenu_Closing)|ActionMenuClosingEventArgs|Triggers when the block action menu is closed.|
|[ItemSelect](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.BlockEditorActionMenu.html#Syncfusion_Blazor_BlockEditor_BlockEditorActionMenu_ItemSelect)|ActionMenuItemSelectEventArgs|Triggers when a block action menu item is clicked.|

The following example demonstrates how to customize the Block Action menu with custom action items.

```cshtml
@using Syncfusion.Blazor.BlockEditor

<div id="container">
    <SfBlockEditor Blocks="@BlocksData">
        <BlockEditorActionMenu Enable="true" 
                               PopupWidth="180px" 
                               PopupHeight="110px" 
                               EnableTooltip="true" 
                               Items="@BlockActionMenuItems" 
                               ItemSelect="@ItemSelect" 
                               Opening="@Opening" 
                               Closing="@Closing">
        </BlockEditorActionMenu>
    </SfBlockEditor>
</div>

@code {
    private List<BlockModel> BlocksData = new List<BlockModel>
    {
        new BlockModel
        {
            BlockType = BlockType.Heading,
            Properties = new HeadingBlockSettings { Level = 1 },
            Content = new List<ContentModel>
            {
                new ContentModel
                {
                    ContentType = ContentType.Text,
                    Content = "Block Action Menu Demo"
                }
            }
        },
        new BlockModel
        {
            BlockType = BlockType.Quote,
            Content = new List<ContentModel>
            {
                new ContentModel
                {
                    ContentType = ContentType.Text,
                    Content = "Hover over blocks and click the drag handle icon to access the custom block action menu with additional options."
                }
            }
        }
    };

    private List<BlockActionItemModel> BlockActionMenuItems = new List<BlockActionItemModel>
    {
        new BlockActionItemModel
        {
            ID = "highlight-action",
            Label = "Highlight Block",
            IconCss = "e-icons e-highlight",
            Tooltip = "Highlight this block"
        },
        new BlockActionItemModel
        {
            ID = "copy-content-action",
            Label = "Copy Content",
            IconCss = "e-icons e-copy",
            Tooltip = "Copy block content to clipboard"
        },
        new BlockActionItemModel
        {
            ID = "block-info-action",
            Label = "Block Info",
            IconCss = "e-icons e-circle-info",
            Tooltip = "Show block information"
        }
    };

    private void ItemSelect(ActionMenuItemSelectEventArgs args)
    {
        // Handle custom block action based on selected item
    }

    private void Opening(ActionMenuOpeningEventArgs args)
    {
        // Conditionally show/hide menu items based on block type
    }

    private void Closing(ActionMenuClosingEventArgs args)
    {
        // Cleanup when menu closes
    }
}
```

## Inline toolbar

The Inline Toolbar appears when text is selected in the editor, providing quick access to common text formatting actions that apply to inline content.

### Built-in items

The Inline Toolbar includes the following built-in formatting options:

- **Text Styles**: Bold, Italic, Underline, and Strikethrough.
- **Superscript/Subscript**: For mathematical or scientific notations.
- **Case Conversion**: Changes text to uppercase or lowercase.
- **Text Color**: Changes the color of the selected text.
- **Background Color**: Changes the background color of the selected text.

### Customize inline toolbar

Use the [BlockEditorInlineToolbar](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.BlockEditorInlineToolbar.html) tag directive to customize the Inline Toolbar by adding or removing formatting options based on application needs.

### Events

The following events are available for the Inline Toolbar:

|Name|Args|Description|
|---|---|---|
|[ItemClick](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.BlockEditorInlineToolbar.html#Syncfusion_Blazor_BlockEditor_BlockEditorInlineToolbar_ItemClick)|InlineToolbarItemClickEventArgs|Triggers when the user clicks on an inline toolbar item.|

The following example demonstrates how to customize the Inline Toolbar with specific formatting options.

```cshtml
@using Syncfusion.Blazor.BlockEditor

<div id="container">
    <SfBlockEditor Blocks="@BlocksData">
        <BlockEditorInlineToolbar Enable="true" 
                                  PopupWidth="100px" 
                                  Items="@CustomToolbarItems" 
                                  ItemClick="@ItemClick">
        </BlockEditorInlineToolbar>
    </SfBlockEditor>
</div>

@code {
    private List<BlockModel> BlocksData = new List<BlockModel>
    {
        new BlockModel
        {
            BlockType = BlockType.Heading,
            Properties = new HeadingBlockSettings { Level = 1 },
            Content = new List<ContentModel>
            {
                new ContentModel
                {
                    ContentType = ContentType.Text,
                    Content = "Inline Toolbar Demo"
                }
            }
        },
        new BlockModel
        {
            BlockType = BlockType.Paragraph,
            Content = new List<ContentModel>
            {
                new ContentModel
                {
                    ContentType = ContentType.Text,
                    Content = "Select any text in this editor to display the custom inline toolbar with formatting options."
                }
            }
        }
    };

    private List<InlineToolbarItemModel> CustomToolbarItems = new List<InlineToolbarItemModel>
    {
        new InlineToolbarItemModel
        {
            Command = CommandName.Bold
        },
        new InlineToolbarItemModel
        {
            Command = CommandName.Italic
        }
    };

    private void ItemClick(InlineToolbarItemClickEventArgs args)
    {
        // Handle toolbar item click actions
        // Access formatting command via args.Item.Command
    }
}
```
