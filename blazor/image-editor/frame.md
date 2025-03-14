---
layout: post
title: Frame with Blazor Image Editor Component | Syncfusion
description: Checkout the Frame available in Blazor Image Editor component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: Image Editor
documentation: ug
---

# Frames in the Blazor Image Editor component

The frame feature in an Image Editor provides users with the capability to add decorative borders or frames around their images. Frames are a visual design element that can enhance the overall appearance and appeal of an image.

## Apply frame to the Image

The [`DrawFrameAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.SfImageEditor.html#Syncfusion_Blazor_ImageEditor_SfImageEditor_DrawFrameAsync_Syncfusion_Blazor_ImageEditor_FrameType_System_String_System_String_System_Int32_System_Int32_System_Int32_System_Int32_Syncfusion_Blazor_ImageEditor_FrameLineStyle_System_Int32_) method is a function designed to enable the application of various frame options to an image. This method simplifies the process of adding decorative frames, such as mat, bevel, line, hook, and inset, to an image by allowing users to specify their desired frame type.

Depending on the frame type selected, users may have additional customization options, such as adjusting the frame's thickness, color, texture, or other attributes. This allows for fine-tuning the appearance of the frame to match the image's theme or the user's preferences

The `DrawFrameAsync` method in the Image Editor control takes nine parameters to define the properties of the frame to the image:

* frameType - Specified the image data or url of the image to be inserted.

* color - Specifies the color for the frame.

* gradientColor - Specifies the gradient color for the frame.

* size - Specifies the size of the frame.

* inset - Specifies the inset value for line, hook, and inset type frames.

* offset - Specifies the offset value for line and inset type frames.

* borderRadius - Specifies the border radius for line type frame.

* frameLineStyle - Specifies the frame line style for line type frame.

* lineCount - Specifies the line count for the line type frame.

Here is an example of Frame using the `DrawFrameAsync` method.

```cshtml
@using Syncfusion.Blazor.ImageEditor
@using Syncfusion.Blazor.Buttons

<div style="padding-bottom: 15px">
    <SfButton OnClick="MatClick">Mat</SfButton>
    <SfButton OnClick="BevelClick">Bevel</SfButton>
    <SfButton OnClick="LineClick">Line</SfButton>
    <SfButton OnClick="InsetClick">Inset</SfButton>
    <SfButton OnClick="HookClick">Hook</SfButton>
</div>

<SfImageEditor @ref="ImageEditor" Toolbar="customToolbarItem" Height="400">
    <ImageEditorEvents Created="CreatedAsync"></ImageEditorEvents>
</SfImageEditor>

@code {
    SfImageEditor ImageEditor;
    private List<ImageEditorToolbarItemModel> customToolbarItem = new List<ImageEditorToolbarItemModel>() { };

    private async void CreatedAsync()
    {
        await ImageEditor.OpenAsync("https://ej2.syncfusion.com/react/demos/src/image-editor/images/bridge.png");
    }

    private async void MatClick()
    {
        await ImageEditor.DrawFrameAsync(FrameType.Mat, "red", "blue", 20, 20, 20, 20, FrameLineStyle.Solid, 1);
    }

    private async void BevelClick()
    {
        await ImageEditor.DrawFrameAsync(FrameType.Bevel, "red", "blue", 20, 20, 20, 20, FrameLineStyle.Solid, 1);
    }

    private async void LineClick()
    {
        await ImageEditor.DrawFrameAsync(FrameType.Line, "red", "blue", 20, 20, 20, 20, FrameLineStyle.Solid, 1);
    }

    private async void InsetClick()
    {
        await ImageEditor.DrawFrameAsync(FrameType.Inset, "red", "blue", 20, 20, 20, 20, FrameLineStyle.Solid, 1);
    }

    private async void HookClick()
    {
        await ImageEditor.DrawFrameAsync(FrameType.Hook, "red", "blue", 20, 20, 20, 20, FrameLineStyle.Solid, 1);
    }
}
```

![Blazor Image Editor with Frame an image](./images/blazor-image-editor-frame.png)

## Frame changing event

The [`FrameChanging`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.ImageEditorEvents.html#Syncfusion_Blazor_ImageEditor_ImageEditorEvents_FrameChanging) event is triggered when applying frame on the image. This event provides information encapsulated within an object, which includes details about the frame applied in an image. This information encompasses:

Frame Type: This indicates the specific type of frame being applied, whether it's a mat, bevel, line, or hook.

Customization Values: These values contain information about any adjustments or modifications made to the frame. For instance, if the frame can be customized with attributes like color, size, or style, these details are conveyed within the event object.

The parameter available in the [`FrameChangeEventArgs`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.FrameChangeEventArgs.html) is

* [`FrameChangeEventArgs.PreviousFrameSetting`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.FrameChangeEventArgs.html#Syncfusion_Blazor_ImageEditor_FrameChangeEventArgs_PreviousFrameSetting) - The frame settings including size, color, inset, offset, gradient color which is applied before changing the frame.

* [`FrameChangeEventArgs.CurrentFrameSetting`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.FrameChangeEventArgs.html#Syncfusion_Blazor_ImageEditor_FrameChangeEventArgs_CurrentFrameSetting) - The frame settings including size, color, inset, offset, gradient color which is going to apply after changing the frame.

* [`FrameChangeEventArgs.Cancel`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.FrameChangeEventArgs.html#Syncfusion_Blazor_ImageEditor_FrameChangeEventArgs_Cancel) - Specifies a boolean value to cancel the frame changing action.