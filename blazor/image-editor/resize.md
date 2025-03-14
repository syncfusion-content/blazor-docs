---
layout: post
title: Resizing with Blazor Image Editor Component | Syncfusion
description: Checkout the Resizing available in Blazor Image Editor component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: Image Editor
documentation: ug
---

# Resize in the Blazor Image Editor component

The resize feature in an Image Editor is a valuable tool that empowers users to modify the size or dimensions of an image to meet their specific requirements. Whether it's for printing, web display, or any other purpose, this feature allows users to tailor images to their desired specifications.

## Apply resize to the image 

The Image Editor control includes a [`ImageResizeAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.SfImageEditor.html#Syncfusion_Blazor_ImageEditor_SfImageEditor_ImageResizeAsync_System_Int32_System_Int32_System_Boolean_) method, which allows you to adjust the size of an image. This method takes three parameters that define how the resizing should be carried out:

* width: Specifies the resizing width of the image.

* height: Specifies the resizing height of the image.

* isAspectRatio: Specifies a boolean value indicating whether the image should maintain its original aspect ratio during resizing.
    * When set to `true`, the image maintains its original aspect ratio. The width is applied as specified, and the height is automatically adjusted to maintain the aspect ratio.
    * When set to `false`, the image is resized according to the specified width and height, without maintaining the aspect ratio.
    * The default value is `false`.

Here is an example of resizing the image using the `ImageResizeAsync` method.  

```cshtml
@using Syncfusion.Blazor.ImageEditor
@using Syncfusion.Blazor.Buttons

<div style="padding-bottom: 15px">
    <SfButton OnClick="AspectClick">Aspect Ratio</SfButton>
    <SfButton OnClick="NonAspectClick">Non Aspect Ratio</SfButton>
</div>

<SfImageEditor @ref="ImageEditor" Toolbar="customToolbarItem" Height="400">
    <ImageEditorEvents Created="CreatedAsync"></ImageEditorEvents>
</SfImageEditor>

@code {
    SfImageEditor ImageEditor;
    private List<ImageEditorToolbarItemModel> customToolbarItem = new List<ImageEditorToolbarItemModel>() {};

    private async void CreatedAsync()
    {
        await ImageEditor.OpenAsync("https://ej2.syncfusion.com/react/demos/src/image-editor/images/bridge.png");
    }

    private async void AspectClick()
    {
        await ImageEditor.ImageResizeAsync(300, 400, true);
    }

    private async void NonAspectClick()
    {
        await ImageEditor.ImageResizeAsync(400, 100, false);
    }
}
```

![Blazor Image Editor with Resize an image](./images/blazor-image-editor-resize.png)

## Resizing event

The [`ImageResizing`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.ImageEditorEvents.html#Syncfusion_Blazor_ImageEditor_ImageEditorEvents_ImageResizing) event is triggered when resizing the image. This event provides information encapsulated within an object, which includes details about the previous and current height and width of an image.

The parameter available in ResizeEventArgs is,

* [`ImageResizeEventArgs.PreviousWidth`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.ImageResizeEventArgs.html#Syncfusion_Blazor_ImageEditor_ImageResizeEventArgs_PreviousWidth) - The width of the image before resizing is performed.

* [`ImageResizeEventArgs.PreviousHeight`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.ImageResizeEventArgs.html#Syncfusion_Blazor_ImageEditor_ImageResizeEventArgs_PreviousHeight) - The height of the image before resizing is performed.

* [`ImageResizeEventArgs.Width`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.ImageResizeEventArgs.html#Syncfusion_Blazor_ImageEditor_ImageResizeEventArgs_Width) - The width of the image after resizing is performed.

* [`ImageResizeEventArgs.Height`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.ImageResizeEventArgs.html#Syncfusion_Blazor_ImageEditor_ImageResizeEventArgs_Height) - The width of the image after resizing is performed.

* [`ImageResizeEventArgs.IsAspectRatio`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.ImageResizeEventArgs.html#Syncfusion_Blazor_ImageEditor_ImageResizeEventArgs_IsAspectRatio) - The type of resizing performed such as aspect ratio or non-aspect ratio.

* [`ImageResizeEventArgs.Cancel`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.ImageResizeEventArgs.html#Syncfusion_Blazor_ImageEditor_ImageResizeEventArgs_Cancel) - Specifies a boolean value to cancel the resizing action.