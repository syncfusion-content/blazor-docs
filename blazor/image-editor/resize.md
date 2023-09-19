---
layout: post
title: Resizing with Blazor Image Editor Component | Syncfusion
description: Checkout the Resizing available in Blazor Image Editor component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: Image Editor
documentation: ug
---

# Resize

The resize feature in an Image Editor is a valuable tool that empowers users to modify the size or dimensions of an image to meet their specific requirements. Whether it's for printing, web display, or any other purpose, this feature allows users to tailor images to their desired specifications.

## Apply resize to the image 

The Image Editor control includes a [`ImageResizeAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.SfImageEditor.html#Syncfusion_Blazor_ImageEditor_SfImageEditor_ImageResizeAsync_System_Nullable_System_Int32__System_Nullable_System_Int32__System_Nullable_System_Boolean__) method, which allows you to adjust the size of an image. This method takes three parameters that define how the resizing should be carried out:

* width: Specifies the resizing width of the image.

* height: Specifies the resizing height of the image.

* isAspectRatio: Specifies a boolean value indicating whether the image should maintain its original aspect ratio during resizing. When set to true, the image will be resized while preserving its aspect ratio 

Here is an example of resizing the image using the [`ImageResizeAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.SfImageEditor.html#Syncfusion_Blazor_ImageEditor_SfImageEditor_ImageResizeAsync_System_Nullable_System_Int32__System_Nullable_System_Int32__System_Nullable_System_Boolean__) method.  

```cshtml
@using Syncfusion.Blazor.ImageEditor

<SfImageEditor @ref="ImageEditor" Toolbar="customToolbarItem" Height="400">
    <ImageEditorEvents Created="OpenAsync"></ImageEditorEvents>
</SfImageEditor>

@code {
    SfImageEditor ImageEditor;
    private List<ImageEditorToolbarItemModel> customToolbarItem = new List<ImageEditorToolbarItemModel>()
    {
        new ImageEditorToolbarItemModel { Name = "Resize" },
        new ImageEditorToolbarItemModel { Name = "Confirm" },
        new ImageEditorToolbarItemModel { Name = "Reset" },
        new ImageEditorToolbarItemModel { Name = "Save" }
    };

    private async void OpenAsync()
    {
        await ImageEditor.OpenAsync("nature.png");
    }

}
```

![Blazor Image Editor with Filter an image](./images/blazor-image-editor-resize.png)

## Resizing event

The [`ImageResizeEventArgs`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.ImageResizeEventArgs.html) event is triggered when resizing the image. This event provides information encapsulated within an object, which includes details about the previous and current height and width of an image.

The parameter available in ResizeEventArgs is,

* [`ImageResizeEventArgs.previousWidth`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.ImageResizeEventArgs.html#Syncfusion_Blazor_ImageEditor_ImageResizeEventArgs_PreviousWidth) - The width of the image before resizing is performed.

* [`ImageResizeEventArgs.previousHeight`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.ImageResizeEventArgs.html#Syncfusion_Blazor_ImageEditor_ImageResizeEventArgs_PreviousHeight) - The height of the image before resizing is performed.

* [`ImageResizeEventArgs.width`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.ImageResizeEventArgs.html#Syncfusion_Blazor_ImageEditor_ImageResizeEventArgs_Width) - The width of the image after resizing is performed.

* [`ImageResizeEventArgs.height`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.ImageResizeEventArgs.html#Syncfusion_Blazor_ImageEditor_ImageResizeEventArgs_Height) - The width of the image after resizing is performed.

* [`ImageResizeEventArgs.isAspectRatio`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.ImageResizeEventArgs.html#Syncfusion_Blazor_ImageEditor_ImageResizeEventArgs_IsAspectRatio) - The type of resizing performed such as aspect ratio or non-aspect ratio.

* [`ImageResizeEventArgs.cancel`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.ImageResizeEventArgs.html#Syncfusion_Blazor_ImageEditor_ImageResizeEventArgs_Cancel) - Specifies a boolean value to cancel the resizing action.