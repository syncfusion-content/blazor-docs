---
layout: post
title: Embed in Blazor BlockEditor Component | Syncfusion
description: Checkout and learn about Embed with Blazor BlockEditor component in Blazor WebAssembly App.
platform: Blazor
control: BlockEditor
documentation: ug
---

# Embed Blocks in Blazor BlockEditor component

Block Editor supports addition of embeds to help you organize, showcase contents and format your content effectively.

## Image Block

You can use the `Image` block to showcase an image content within your editor.

### Configure image block

You can render Image blocks by setting the [BlockType] property as `Image`. By setting the `Properties` property, you can configure the image source, allowed file types, and display dimensions etc.

The image [Properties] property supports the following options:

| Property | Description | Default Value |
|----------|-------------|---------------|
| SaveFormat | Specifies the format to save the image | Base64 |
| Src | Specifies the image path | ' '|
| AllowedTypes | Specifies the allowed image file types that can be uploaded | ['.jpg', '.jpeg', '.png'] |
| Width | Specifies the display width of the image | ' ' |
| Height | Specifies the display height of the image | ' '|
| MinWidth | Specifies the minimum width of the image in pixels or as a string unit | 40|
| MaxWidth | Specifies the maximum width of the image in pixels or as a string unit | ' '|
| MinHeight | Specifies the minimum height of the image in pixels or as a string unit | 40|
| MaxHeight | Specifies the maximum height of the image in pixels or as a string unit | ' '|
| AltText | Specifies the alternative text to be displayed when the image cannot be loaded | ' '|
| CssClass | Specifies one or more CSS classes to be applied to the image element | ' ' |
| ReadOnly | Specifies whether the image is in read-only mode | false

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