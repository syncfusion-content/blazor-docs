---
layout: post
title: Open save with Blazor Image Editor Component | Syncfusion
description: Checkout the Open save available in Blazor Image Editor component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: Image Editor
documentation: ug
---


# Open and Save in the Blazor Image Editor component

The [Blazor Image Editor](https://www.syncfusion.com/blazor-components/blazor-image-editor) component supports to import an image into the canvas, it must first be converted into a blob object. The Uploader component can be used to facilitate the process of uploading an image from the user interface. Once the image has been uploaded, it can then be converted into a blob and drawn onto the canvas.

## Open an image

The [`OpenAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.SfImageEditor.html#Syncfusion_Blazor_ImageEditor_SfImageEditor_OpenAsync_System_Object_) method in the Blazor Image Editor component offers the capability to open an image by providing it in different formats. This method accepts various types of arguments, such as a base64-encoded string, raw image data, or a hosted/online URL. You can pass either the file name or the actual image data as an argument to the [`OpenAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.SfImageEditor.html#Syncfusion_Blazor_ImageEditor_SfImageEditor_OpenAsync_System_Object_) method, and it will load the specified image into the image editor component. This flexibility allows you to work with images from different sources and formats, making it easier to integrate and manipulate images within the Image Editor component.

Note: To load the image in the image editor, the image is placed within the application's "wwwroot" folder.

```cshtml
@using Syncfusion.Blazor.ImageEditor 

<SfImageEditor @ref="ImageEditor" Toolbar="customToolbarItem" Height="400">
    <ImageEditorEvents Created="OpenAsync"></ImageEditorEvents>
</SfImageEditor> 

@code { 
    SfImageEditor ImageEditor; 
    private List<ImageEditorToolbarItemModel> customToolbarItem = new List<ImageEditorToolbarItemModel>() { }; 

    private async void OpenAsync() 
    { 
        await ImageEditor.OpenAsync("nature.png"); 
    } 
}
```

![Blazor Image Editor with Opening an image](./images/blazor-image-editor-open.png)

## Supported image formats

The Blazor Image Editor component supports three common image formats: PNG, JPEG, and SVG. These formats allow you to work with a wide range of image files within the image editor.

When it comes to saving the edited image, the default file type is set as PNG. This means that when you save the edited image without specifying a different file type, it will be saved as a PNG file. However, it's important to note that the Image Editor typically provides options or methods to specify a different file type if desired. This allows you to save the edited image in formats other than the default PNG, such as JPEG or SVG, based on your specific requirements or preferences. 

### Save as image

The [`ExportAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.SfImageEditor.html#Syncfusion_Blazor_ImageEditor_SfImageEditor_ExportAsync_System_String_Syncfusion_Blazor_ImageEditor_ImageEditorFileType_) method in the Blazor Image Editor component is used to save the modified image as an image, and it accepts a file name and file type as parameters. The file type parameter supports PNG, JPEG, and SVG and the default file type is PNG. Users are allowed to save an image with a specified file name, file type, and image quality. This enhancement provides more control over the output, ensuring that users can save their work exactly as they need it.

In the following example, the [`ExportAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.SfImageEditor.html#Syncfusion_Blazor_ImageEditor_SfImageEditor_ExportAsync_System_String_Syncfusion_Blazor_ImageEditor_ImageEditorFileType_) method is used in the button click event.

```cshtml
@using Syncfusion.Blazor.ImageEditor
@using Syncfusion.Blazor.Buttons

<div style="padding-bottom: 15px">
    <SfButton OnClick="ExportAsync">Export</SfButton>
</div>
<SfImageEditor @ref="ImageEditor" Toolbar="customToolbarItem" Height="400">
    <ImageEditorEvents Created="OpenAsync"></ImageEditorEvents>
</SfImageEditor> 

@code { 
    SfImageEditor ImageEditor; 
    private List<ImageEditorToolbarItemModel> customToolbarItem = new List<ImageEditorToolbarItemModel>() { }; 

    private async void OpenAsync() 
    { 
        await ImageEditor.OpenAsync("nature.png"); 
    }

    private async void ExportAsync()
    {
        await ImageEditor.ExportAsync("Syncfusion", ImageEditorFileType.PNG);
    }
}
```

![Blazor Image Editor with Save an image](./images/blazor-image-editor-export.png)

### Save as image in server

The [`GetImageDataUrlAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.SfImageEditor.html#Syncfusion_Blazor_ImageEditor_SfImageEditor_GetImageDataUrlAsync) method in the Blazor Image Editor component is used to gets the current image data url from the Image Editor component

The value returned from this method is used to save the edited image to database as well as open in our image editor using The [`OpenAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.SfImageEditor.html#Syncfusion_Blazor_ImageEditor_SfImageEditor_OpenAsync_System_Object_)method.

N> Increase the connection buffer size in Blazor Image Editor component

The Syncfusion's Blazor Image Editor component allows to increase the connection buffer size by adding the below service in program.cs file if the size of the image is too large.

```cshtml
builder.Services.AddServerSideBlazor().AddHubOptions(o => { o.MaximumReceiveMessageSize = 102400000; });
```

### File opened event

The [`FileOpened`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.ImageEditorEvents.html#Syncfusion_Blazor_ImageEditor_ImageEditorEvents_FileOpened) event is triggered in the Blazor Image Editor component after an image is successfully loaded. It provides the [`FileOpenEventArgs`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.FileOpenEventArgs.html) as the event argument, which contains two specific arguments:

[`FileName`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.FileOpenEventArgs.html#Syncfusion_Blazor_ImageEditor_FileOpenEventArgs_FileName): This argument is a string that contains the file name of the opened image. It represents the name of the file that was selected or provided when loading the image into the Image Editor.

[`FileType`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.FileOpenEventArgs.html#Syncfusion_Blazor_ImageEditor_FileOpenEventArgs_FileType): This argument is a string that contains the type of the opened image. It specifies the format or file type of the image that was loaded, such as PNG, JPEG, or SVG. 

By accessing these arguments within the [`FileOpened`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.ImageEditorEvents.html#Syncfusion_Blazor_ImageEditor_ImageEditorEvents_FileOpened) event handler, you can retrieve information about the loaded image, such as its file name and file type. This can be useful for performing additional actions or implementing logic based on the specific image that was opened in the Image Editor component. 

### Saving event

The [`Saving`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.ImageEditorEvents.html#Syncfusion_Blazor_ImageEditor_ImageEditorEvents_Saving) event is triggered in the Blazor Image Editor component when an image is being saved to the local disk. It provides the [`SaveEventArgs `](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.SaveEventArgs.html) as the event argument, which includes the following specific arguments:

[`FileName`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.SaveEventArgs.html#Syncfusion_Blazor_ImageEditor_SaveEventArgs_FileName): This argument is a string that holds the file name of the saved image. It represents the name of the file that will be used when saving the image to the local disk.

[`FileType`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.SaveEventArgs.html#Syncfusion_Blazor_ImageEditor_SaveEventArgs_FileType): This argument is a string indicating the type or format of the saved image. It specifies the desired file type in which the image will be saved, such as PNG, JPEG, or SVG.

[`Cancel`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.SaveEventArgs.html#Syncfusion_Blazor_ImageEditor_SaveEventArgs_Cancel): This argument is a boolean value that can be set to true in order to cancel the saving action. By default, it is set to false, allowing the saving process to proceed. However, if you want to prevent the saving action from occurring, you can set Cancel to true within the event handler.

By accessing these arguments within the Saving event handler, you can retrieve information about the file name and file type of the image being saved. Additionally, you have the option to cancel the saving action if necessary.

### Created event

The [`Created`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.ImageEditorEvents.html#Syncfusion_Blazor_ImageEditor_ImageEditorEvents_Created) event is triggered once the Blazor Image Editor component is created. This event serves as a notification that the component has been fully initialized and is ready to be used. It provides a convenient opportunity to render the Image Editor with a predefined set of initial settings, including the image, annotations, and transformations.

In the following example, the [`Created`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.ImageEditorEvents.html#Syncfusion_Blazor_ImageEditor_ImageEditorEvents_Created) event is used to load an image.

```cshtml
@using Syncfusion.Blazor.ImageEditor 

<SfImageEditor @ref="ImageEditor" Toolbar="customToolbarItem" Height="400">
    <ImageEditorEvents Created="OpenAsync"></ImageEditorEvents>
</SfImageEditor> 

@code { 
    SfImageEditor ImageEditor; 
    private List<ImageEditorToolbarItemModel> customToolbarItem = new List<ImageEditorToolbarItemModel>() { }; 

    private async void OpenAsync() 
    { 
        await ImageEditor.OpenAsync("nature.png"); 
    } 
}
```

![Blazor Image Editor with Opening an image](./images/blazor-image-editor-open.png)

### Destroyed event

The [`Destroyed`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.ImageEditorEvents.html#Syncfusion_Blazor_ImageEditor_ImageEditorEvents_Destroyed) event is triggered once the Blazor Image Editor component is destroyed or removed from the application. This event serves as a notification that the component and its associated resources have been successfully cleaned up and are no longer active.

### Reset an image

The [`ResetAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.SfImageEditor.html#Syncfusion_Blazor_ImageEditor_SfImageEditor_ResetAsync) method in the Blazor Image Editor component provides the capability to undo all the changes made to an image and revert it back to its original state. This method is particularly useful when multiple adjustments, annotations, or transformations have been applied to an image and you want to start over with the original, unmodified version of the image. 

By invoking the [`ResetAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.SfImageEditor.html#Syncfusion_Blazor_ImageEditor_SfImageEditor_ResetAsync) method, any modifications or edits made to the image will be undone, and the image will be restored to its initial state. This allows you to easily discard any changes and begin again with the fresh, unaltered image.
