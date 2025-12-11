---
layout: post
title: Embed in Blazor BlockEditor Component | Syncfusion
description: Checkout and learn about Embed in Syncfusion Blazor BlockEditor component and more.
platform: Blazor
control: BlockEditor
documentation: ug
---

# Embed Blocks in Blazor BlockEditor component

The Block Editor supports the addition of embeds to help you organize and showcase visual content effectively.

## Adding an Image Block

You can use the `Image` block to showcase an image content within your editor.

### Configure Image Block

You can render an `Image` block by setting the [BlockType] property to `Image` in the block model. The `Properties` property allows you to configure the image source, allowed file types, display dimensions, and more.

#### Global Image Settings

You can configure global settings for image blocks using the `ImageBlockSettings` property in the Block Editor root configuration. This ensures consistent behavior for image uploads, resizing, and display.

The `ImageBlockSettings` property supports the following options:

| Property | Description | Default Value |
|----------|-------------|---------------|
| saveFormat | Specifies the format to save the image. | `Base64` |
| allowedTypes | Specifies allowed image file types for upload. | `['.jpg', '.jpeg', '.png']` |
| width | Specifies the default display width of the image. | `auto` |
| height | Specifies the default display height of the image. | `auto` |
| enableResize | Enables or disables image resizing. | `true` |
| minWidth | Minimum width allowed for resizing. | `''` |
| maxWidth | Maximum width allowed for resizing. | `''` |
| minHeight | Minimum height allowed for resizing. | `''` |
| maxHeight | Maximum height allowed for resizing. | `''` |

#### Configure Image Block Properties

The `Image` block [Properties] property supports the following options:

| Property | Description | Default Value |
|----------|-------------|---------------|
| src | Specifies the image path. | `''` |
| width | Specifies the display width of the image. | `''` |
| height | Specifies the display height of the image. | `''` |
| altText | Specifies the alternative text to display when the image cannot be loaded. | `''` |

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
            BlockType = BlockType.Image,
            Properties = new ImageBlockSettings {Src = "https://cdn.syncfusion.com/ej2/richtexteditor-resources/RTE-Overview.png", AltText = "Sample image"}
        },
        new BlockModel
        {
            BlockType = BlockType.Paragraph,
            Content = {new ContentModel{ContentType = ContentType.Text, Content = "You can customize images further by configuring properties like allowedTypes for file upload restrictions, saveFormat for storage preferences, and cssClass for custom styling."}}
        }
    };
}

```

![Blazor BlockEditor Image Block](./images/image-block.png)