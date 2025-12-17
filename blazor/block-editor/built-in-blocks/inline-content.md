---
layout: post
title: Inline content in Blazor Block Editor Component | Syncfusion
description: Checkout and learn about Inline content with Syncfusion Blazor Block Editor component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: BlockEditor
documentation: ug
---

# Inline Content in Blazor Block Editor component

In the Syncfusion Block Editor, all content is organized within blocks. Each block contains a [Content](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.ContentModel.html#Syncfusion_Blazor_BlockEditor_ContentModel_Content) property, which is a list of [ContentModel](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.ContentModel.html) that defines the text and functionality within that block.

Each [ContentModel](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.ContentModel.html) is an object with properties such as [ID](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.ContentModel.html#Syncfusion_Blazor_BlockEditor_ContentModel_ID), [ContentType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.ContentModel.html#Syncfusion_Blazor_BlockEditor_ContentModel_ContentType), [Content](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.ContentModel.html#Syncfusion_Blazor_BlockEditor_ContentModel_Content), and [Properties](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.ContentModel.html#Syncfusion_Blazor_BlockEditor_ContentModel_Properties), allowing for granular control over its appearance and behavior.

## Setting content type

The Block Editor supports several inline content types through the [ContentType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.ContentModel.html#Syncfusion_Blazor_BlockEditor_ContentModel_ContentType) enum, which can be set using the [ContentType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.ContentModel.html#Syncfusion_Blazor_BlockEditor_ContentModel_ContentType) property.

| Built-in Content Type  | Description                         |
|------------------------|-------------------------------------|
| Text                   | Represents plain text content.      |
| Link                   | Represents a hyperlink.             |
| Mention                | Represents a user mention.          |
| Label                  | Represents a label or tag.          |

By default, the content type is set to [Text](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.ContentType.html#Syncfusion_Blazor_BlockEditor_ContentType_Text).

## Configure text content

To configure text content, set the [ContentType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.ContentModel.html#Syncfusion_Blazor_BlockEditor_ContentModel_ContentType) property to [Text](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.ContentType.html#Syncfusion_Blazor_BlockEditor_ContentType_Text). This is the default content type if none is specified.

### ContentType

```cshtml
// Adding inline text
    new BlockModel
    {
        BlockType = BlockType.Paragraph,
        Content = {new ContentModel{ContentType = ContentType.Text, Content = "Inline text"}}
    }   
```

## Configure hyperlink

To create a hyperlink, set the [ContentType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.ContentModel.html#Syncfusion_Blazor_BlockEditor_ContentModel_ContentType) property to [Link](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.ContentType.html#Syncfusion_Blazor_BlockEditor_ContentType_Link). You can configure the link's URL using the [Properties](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.ContentModel.html#Syncfusion_Blazor_BlockEditor_ContentModel_Properties) property.

### Configure link properties

Link settings control the behavior and properties of hyperlinks in your content. You can configure link settings using the [Properties](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.ContentModel.html#Syncfusion_Blazor_BlockEditor_ContentModel_Properties) property which accepts the following options:

| Property | Description | Default Value |
|----------|-------------|---------------|
| Url | Specifies the destination URL of the link. | `''` |

### ContentType and Properties

```cshtml
    new BlockModel
    {
        BlockType = BlockType.Paragraph,
        Content = {new ContentModel{ContentType = ContentType.Link, Content = "hyperlinks", Properties = new LinkContentSettings { Url = "https://ej2.syncfusion.com/documentation"}}}
    }
```

## Configure label

To render labels, set the [ContentType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.ContentModel.html#Syncfusion_Blazor_BlockEditor_ContentModel_ContentType) property to [Label](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.ContentType.html#Syncfusion_Blazor_BlockEditor_ContentType_Label). Specify the [LabelID](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.LabelContentSettings.html#Syncfusion_Blazor_BlockEditor_LabelContentSettings_LabelID) of the particular label in [Properties](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.ContentModel.html#Syncfusion_Blazor_BlockEditor_ContentModel_Properties) to render a label.

### Built-in items

The Block Editor comes with different built-in label items. These includes:

-   **Progress**: In-progress, On-hold, Done
-   **Priority**: High, Medium, Low

### Global label settings

You can configure global settings for all label inline contents using the [BlockEditorLabel](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.BlockEditorLabel.html) tag directive.

The [BlockEditorLabel](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.BlockEditorLabel.html) tag directive supports the following options:

| Property | Description |
|----------|-------------|
| TriggerChar | Specifies the character that opens the label suggestions popup. |
| Items | Specifies the label items. |

#### Trigger Character configuration

Use the [TriggerChar](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.BlockEditorLabel.html#Syncfusion_Blazor_BlockEditor_BlockEditorLabel_TriggerChar) property to define the character that opens the label suggestions popup. The default trigger character is `$`.

#### Label items configuration

Define the available labels using the [Items](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.BlockEditorLabel.html#Syncfusion_Blazor_BlockEditor_BlockEditorLabel_Items) property present in the [BlockEditorLabel](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.BlockEditorLabel.html) tag directive. When a user types the trigger character, a popup will show matching items.

Each item supports the following properties:

| Property                     | Description                                         |
| -----------------------------| --------------------------------------------------- |
| [ID](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.LabelItemModel.html#Syncfusion_Blazor_BlockEditor_LabelItemModel_ID)                         | A unique identifier for the label.                  |
| [Text](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.LabelItemModel.html#Syncfusion_Blazor_BlockEditor_LabelItemModel_Text)                       | The display text for the label.                     |
| [GroupBy](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.LabelItemModel.html#Syncfusion_Blazor_BlockEditor_LabelItemModel_GroupBy)                    | The category name for grouping similar labels.      |
| [LabelColor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.LabelItemModel.html#Syncfusion_Blazor_BlockEditor_LabelItemModel_LabelColor)                 | The background color of the label.                  |
| [IconCss](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.LabelItemModel.html#Syncfusion_Blazor_BlockEditor_LabelItemModel_IconCss)                    | A CSS class for an icon to display with the label.  |


When users type the trigger character, a popup will appear showing matching label items from which they can select. The selected label will be inserted into the content as a Label content item.

#### Customize label

You can customize the labels by using the [Properties](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.ContentModel.html#Syncfusion_Blazor_BlockEditor_ContentModel_Properties) property along with [ContentType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.ContentModel.html#Syncfusion_Blazor_BlockEditor_ContentModel_ContentType) as [Label](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.ContentType.html#Syncfusion_Blazor_BlockEditor_ContentType_Label).

#### ContentType and Properties

```cshtml
// Adding inline label
    new BlockModel
    {
        BlockType = BlockType.Paragraph,
        Content = {new ContentModel{ContentType = ContentType.Label, Properties = new LabelContentSettings {
            LabelID = "progress"
        }}}
    }
```

#### Using labels with group headers

Labels with the same [GroupBy](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.LabelItemModel.html#Syncfusion_Blazor_BlockEditor_LabelItemModel_GroupBy) value will be grouped together in the label selection popup:

## Configure mention

Mentions are references to users or entities that can be inserted into your content. You can configure mention content by setting the type property to [Mention](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.ContentType.html#Syncfusion_Blazor_BlockEditor_ContentType_Mention). Specify the [UserID](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.MentionContentSettings.html#Syncfusion_Blazor_BlockEditor_MentionContentSettings_UserID) of particular user in [Properties](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.ContentModel.html#Syncfusion_Blazor_BlockEditor_ContentModel_Properties) to render a mention.

Mentions are typically triggered by the `@` character and are linked to the [Users](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.SfBlockEditor.html#Syncfusion_Blazor_BlockEditor_SfBlockEditor_Users) collection defined in the Block Editor.

The below sample demonstrates the usage of Mention and Label types in the Block Editor.

```cshtml

@using Syncfusion.Blazor.BlockEditor

<div id="container">
    <SfBlockEditor Blocks="BlockData" Users="@BlockUser"></SfBlockEditor>
</div>

@code {
    private List<UserModel> BlockUser = new List<UserModel>
    {
        new UserModel {ID = "user1", User = "John Doe"}
    };
    private List<BlockModel> BlockData = new List<BlockModel>
    {
        new BlockModel
        {
            BlockType = BlockType.Heading,
            Properties = new HeadingBlockSettings {Level = 2},
            Content = {new ContentModel {ContentType = ContentType.Text, Content = "Different Content Types"}}
        },
        new BlockModel
        {
            BlockType = BlockType.Paragraph,
            Content =[
                new ContentModel{ContentType = ContentType.Text, Content = "The Block Editor supports various content types: "},
                new ContentModel{ContentType = ContentType.Link, Content = "hyperlinks", Properties = new LinkContentSettings { Url = "https://ej2.syncfusion.com/documentation/"} },
                new ContentModel{ContentType = ContentType.Text, Content = ", inline "},
                new ContentModel{ContentType = ContentType.Text, Content = "\nUser mentions like"},
                new ContentModel{ContentType = ContentType.Mention, Properties = new MentionContentSettings() { UserID = "user1" } },
                new ContentModel{ContentType = ContentType.Text, Content = ", and labels such as"},
                new ContentModel{ContentType = ContentType.Label, Properties = new LabelContentSettings {LabelID = "progress" } },
                new ContentModel{ContentType = ContentType.Text, Content = "."},
            ]
        }
    };
}

```

## Applying Inline Styles

The Block Editor allows you to apply rich formatting to block contents using the [Styles](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.TextContentSettings.html#Syncfusion_Blazor_BlockEditor_TextContentSettings_Styles) property.

The [Styles](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.TextContentSettings.html#Syncfusion_Blazor_BlockEditor_TextContentSettings_Styles) property supports the following options:

| Style Property            | Description                                | Default Value |
| ------------------------- | ------------------------------------------ | ------------- |
| [Bold](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.StyleModel.html#Syncfusion_Blazor_BlockEditor_StyleModel_Bold)                    | Makes the text bold.                       | `false`       |
| [Italic](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.StyleModel.html#Syncfusion_Blazor_BlockEditor_StyleModel_Italic)                  | Makes the text italicized.                 | `false`       |
| [Underline](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.StyleModel.html#Syncfusion_Blazor_BlockEditor_StyleModel_Underline)               | Adds an underline to the text.             | `false`       |
| [Strikethrough](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.StyleModel.html#Syncfusion_Blazor_BlockEditor_StyleModel_Strikethrough)           | Adds a line through the text.              | `false`       |
| [Color](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.StyleModel.html#Syncfusion_Blazor_BlockEditor_StyleModel_Color)                   | Sets the text color (HEX or RGBA format).  | `''`          |
| [BackgroundColor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.StyleModel.html#Syncfusion_Blazor_BlockEditor_StyleModel_BackgroundColor)         | Sets the background color for the text.    | `''`          |
| [Superscript](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.StyleModel.html#Syncfusion_Blazor_BlockEditor_StyleModel_Superscript)             | Renders the text as superscript.           | `false`       |
| [Subscript](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.StyleModel.html#Syncfusion_Blazor_BlockEditor_StyleModel_Subscript)               | Renders the text as subscript.             | `false`       |
| [Uppercase](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.StyleModel.html#Syncfusion_Blazor_BlockEditor_StyleModel_Uppercase)               | Converts the text to uppercase.            | `false`       |
| [Lowercase](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.StyleModel.html#Syncfusion_Blazor_BlockEditor_StyleModel_Lowercase)               | Converts the text to lowercase.            | `false`       |
| [InlineCode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.StyleModel.html#Syncfusion_Blazor_BlockEditor_StyleModel_InlineCode)              | Converts the text to inline code.          | `false`       |

You can apply one or more of these styles to any supported content element for rich text formatting.

```cshtml

@using Syncfusion.Blazor.BlockEditor

<div id="container">
    <SfBlockEditor Blocks="BlockData"></SfBlockEditor>
</div>

@code {
    private List<BlockModel> BlockData = new List<BlockModel>
    {
        new BlockModel
        {
            BlockType = BlockType.Heading,
            Properties= new HeadingBlockSettings {Level = 2},
            Content = {new ContentModel {ContentType = ContentType.Text, Content = "Content Styling Options"}}
        },
        new BlockModel
        {
            BlockType = BlockType.Paragraph,
            Content =[ 
                new ContentModel{ContentType = ContentType.Text, Content = "Bold text: ", Properties = new TextContentSettings { Styles = new StyleModel { Bold = true, Color = "#1976d2"}}},
                new ContentModel{ContentType = ContentType.Text, Content = "This text is bold.", Properties = new TextContentSettings { Styles = new StyleModel { Bold = true}}}
            ]
        },
        new BlockModel
        {
            BlockType = BlockType.Paragraph,
            Content =[
                new ContentModel{ContentType = ContentType.Text, Content = "Italic text: ", Properties = new TextContentSettings { Styles = new StyleModel { Bold = true, Color = "#1976d2"}}},
                new ContentModel{ContentType = ContentType.Text, Content = "This text is italicized.", Properties = new TextContentSettings { Styles = new StyleModel { Italic = true}}}
            ]
        },
        new BlockModel
        {
            BlockType = BlockType.Paragraph,
            Content =[
                new ContentModel{ContentType = ContentType.Text, Content = "Text with color: ", Properties = new TextContentSettings { Styles = new StyleModel { Bold = true, Color = "#1976d2"}}},
                new ContentModel{ContentType = ContentType.Text, Content = "This text has custom color.", Properties = new TextContentSettings { Styles = new StyleModel { Color = "#e91e63"}}}
            ]
        },
        new BlockModel
        {
            BlockType = BlockType.Paragraph,
            Content =[
                new ContentModel{ContentType = ContentType.Text, Content = "Text with background: ", Properties = new TextContentSettings { Styles = new StyleModel { Bold = true, Color = "#1976d2"}}},
                new ContentModel{ContentType = ContentType.Text, Content = "This text has background color.", Properties = new TextContentSettings { Styles = new StyleModel { BackgroundColor = "#fff9c4"}}}
            ]
        },
        new BlockModel
        {
            BlockType = BlockType.Paragraph,
            Content =[
                new ContentModel{ContentType = ContentType.Text, Content = "Multiple styles: ", Properties = new TextContentSettings { Styles = new StyleModel { Bold = true, Color = "#1976d2"}}},
                new ContentModel{ContentType = ContentType.Text, Content = "This text combines multiple styles.", Properties = new TextContentSettings { Styles = new StyleModel { Bold = true, Italic = true, Underline = true, Color = "#4caf50"}}}
            ]
        }
    };
}

```

![Blazor Block Editor Content Styles](./../images/content-styles.png)