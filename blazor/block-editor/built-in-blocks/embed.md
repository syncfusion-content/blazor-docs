---
layout: post
title: Embed in Blazor Block Editor Component | Syncfusion
description: Learn about embedding images and visual content in the Syncfusion Blazor Block Editor component for Blazor Server and WebAssembly applications.
platform: Blazor
control: BlockEditor
documentation: ug
---

# Embed Blocks in Blazor Block Editor component

The Block Editor supports the addition of embeds to help you organize and showcase visual content effectively.

## Adding an Image Block

You can use the [Image](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.BlockType.html#Syncfusion_Blazor_BlockEditor_BlockType_Image) block to showcase an image content within your editor.

### Configure Image Block

You can render an [Image](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.BlockType.html#Syncfusion_Blazor_BlockEditor_BlockType_Image) block by setting the [BlockType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.BlockType.html) property to [Image](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.BlockType.html#Syncfusion_Blazor_BlockEditor_BlockType_Image) in the block model. The [Properties](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.BlockModel.html#Syncfusion_Blazor_BlockEditor_BlockModel_Properties) property allows you to configure the image source, allowed file types, display dimensions, and more.

#### Global Image Settings

You can configure global settings for image blocks using the [BlockEditorImageBlock](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.BlockEditorImageBlock.html) tag directive. This ensures consistent behavior for all images in the editor.

The [BlockEditorImageBlock](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.BlockEditorImageBlock.html) tag directive supports the following options:

| Property | Description | Default Value |
|----------|-------------|---------------|
| SaveFormat | Specifies the format to save the image. | `Base64` |
| AllowedTypes | Specifies allowed image file types for upload. | `['.jpg', '.jpeg', '.png']` |
| Width | Specifies the default display width of the image. | `auto` |
| Height | Specifies the default display height of the image. | `auto` |
| EnableResize | Enables or disables image resizing. | `true` |
| MinWidth | Minimum width allowed for resizing. | `''` |
| MaxWidth | Maximum width allowed for resizing. | `''` |
| MinHeight | Minimum height allowed for resizing. | `''` |
| MaxHeight | Maximum height allowed for resizing. | `''` |

#### Configure Image Block Properties

The [Image](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.BlockType.html#Syncfusion_Blazor_BlockEditor_BlockType_Image) block [Properties](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.BlockModel.html#Syncfusion_Blazor_BlockEditor_BlockModel_Properties) property supports the following options:

| Property | Description | Default Value |
|----------|-------------|---------------|
| Src | Specifies the image path. | `''` |
| Width | Specifies the display width of the image. | `''` |
| Height | Specifies the display height of the image. | `''` |
| AltText | Specifies the alternative text to display when the image cannot be loaded. | `''` |

```cshtml

@using Syncfusion.Blazor.BlockEditor

<div id="container">
    <SfBlockEditor Blocks="BlockData"></SfBlockEditor>
</div>

@code {
    private List<BlockModel> BlockData = new()
    {
        new BlockModel
        {
            BlockType = BlockType.Image,
            Properties = new ImageBlockSettings {Src = "https://cdn.syncfusion.com/ej2/richtexteditor-resources/RTE-Overview.png", AltText = "Sample image"}
        },
        new BlockModel
        {
            BlockType = BlockType.Paragraph,
            Content = new() {new ContentModel{ContentType = ContentType.Text, Content = "You can customize images further by configuring properties like allowedTypes for file upload restrictions, saveFormat for storage preferences, and cssClass for custom styling."}}
        }
    };
}

```

![Blazor Block Editor Image Block](./../images/image-block.png)