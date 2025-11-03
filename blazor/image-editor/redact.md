---
layout: post
title: Redact with Blazor Image Editor Component | Syncfusion
description: Checkout the Redact available in Blazor Image Editor component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: Image Editor
documentation: ug
---

# Redact in the Blazor Image Editor component

The redact feature in an Image Editor is a valuable tool that empowers users to conceal sensitive information by applying blur or pixel effects to specific areas of an image. This feature is particularly valuable for protecting privacy and complying with data protection regulations, making it easier to securely share images without compromising sensitive information.

## Apply redact to the image

The Image Editor control includes a [`DrawRedactAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.SfImageEditor.html#Syncfusion_Blazor_ImageEditor_SfImageEditor_DrawRedactAsync_Syncfusion_Blazor_ImageEditor_RedactType_System_Double_System_Double_System_Double_System_Double_System_Int32_) method, which allows you to draw redaction on an image. This method takes six parameters that define how the redact should be carried out:

* redactType: Specifies the type of redaction to be drawn on the image such as blur or pixelate. If not specified, the redaction drawing is initiated with the default blur value.

* startX: Specifies x-coordinate of redaction. If not specified, the redaction drawing is initiated with the first parameter.

* startY: Specifies y-coordinate of redaction. If not specified it draws redaction from the center point of the image.

* width: Specifies the width of redaction. The default value is 100.

* height: Specifies the height of redaction. The default value is 50.

* value: Specifies the blur value for blur-type redaction or the pixel size for pixelate-type redaction. Defaults to 20 since the default redaction is blur.

## Selecting a redact

The Image Editor control includes a [`SelectRedactAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.SfImageEditor.html#Syncfusion_Blazor_ImageEditor_SfImageEditor_SelectRedactAsync_System_String_) method, which allows you to select a redaction based on the given redaction id. Use [`GetRedactsAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.SfImageEditor.html#Syncfusion_Blazor_ImageEditor_SfImageEditor_GetRedactsAsync) method to get the redaction id which is then passed to perform selection. This method takes one parameter that define how the redact should be carried out:

* id: Specifies the redact id to select a redact on an image.

## Deleting a redact

The Image Editor control includes a [`DeleteRedactAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.SfImageEditor.html#Syncfusion_Blazor_ImageEditor_SfImageEditor_DeleteRedactAsync_System_String_) method, which allows you to delete a redaction based on the given redaction id. Use [`GetRedactsAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.SfImageEditor.html#Syncfusion_Blazor_ImageEditor_SfImageEditor_GetRedactsAsync) method to get the redaction id which is then passed to perform selection. This method takes one parameter that define how the redact should be carried out:

* id: Specifies the redact id to delete a redact on an image.

## Updating a redact

The Image Editor control includes a [`UpdateRedactAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.SfImageEditor.html#Syncfusion_Blazor_ImageEditor_SfImageEditor_UpdateRedactAsync_Syncfusion_Blazor_ImageEditor_RedactSettings_System_Boolean_) method, which allows you to update the existing redacts by changing its height, width, blur, and pixel size in the component. Use [`GetRedactsAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.SfImageEditor.html#Syncfusion_Blazor_ImageEditor_SfImageEditor_GetRedactsAsync) method to get the redacts which is then passed to change the options of a redacts. This method takes two parameters that define how the redact should be carried out:

* setting: Specifies the redact settings to be updated for the shape on an image.

* isSelected: Specifies to show the redacts in the selected state.

## Getting redacts

The Image Editor control includes a [`GetRedactsAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.SfImageEditor.html#Syncfusion_Blazor_ImageEditor_SfImageEditor_GetRedactsAsync) method, which allows you to get all the redact details which is drawn on an image editor.

Here's an example demonstrating how to draw, select, delete, update, and get redacts on an image using the [`DrawRedactAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.SfImageEditor.html#Syncfusion_Blazor_ImageEditor_SfImageEditor_DrawRedactAsync_System_Nullable_System_Int32__System_Nullable_System_Int32__System_Nullable_System_Boolean__), [`SelectRedactAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.SfImageEditor.html#Syncfusion_Blazor_ImageEditor_SfImageEditor_SelectRedactAsync_System_String_), [`DeleteRedactAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.SfImageEditor.html#Syncfusion_Blazor_ImageEditor_SfImageEditor_DeleteRedactAsync_System_String_), [`UpdateRedactAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.SfImageEditor.html#Syncfusion_Blazor_ImageEditor_SfImageEditor_UpdateRedactAsync_Syncfusion_Blazor_ImageEditor_RedactSettings_System_Boolean_) and [`GetRedactsAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.SfImageEditor.html#Syncfusion_Blazor_ImageEditor_SfImageEditor_GetRedactsAsync) methods.

```cshtml
@using Syncfusion.Blazor.ImageEditor
@using Syncfusion.Blazor.Buttons

<div style="padding-bottom: 15px">
    <SfButton OnClick="addRedact">Add Redact</SfButton>
    <SfButton OnClick="updateRedact">Update Redact</SfButton>
    <SfButton OnClick="selectRedact">Select Redact</SfButton>
    <SfButton OnClick="deleteRedact">Delete Redact</SfButton>
</div>

<SfImageEditor @ref="ImageEditor" Toolbar="customToolbarItem" Height="400">
<ImageEditorEvents Created="OpenAsync"></ImageEditorEvents>
</SfImageEditor>
@code {
    private SfImageEditor ImageEditor;
    private List<ImageEditorToolbarItemModel> customToolbarItem = new List<ImageEditorToolbarItemModel>() { };
    private async void OpenAsync()
    {
        await ImageEditor.OpenAsync("https://ej2.syncfusion.com/react/demos/src/image-editor/images/bridge.png");
    }
    private async void addRedact()
    {
        ImageDimension Dimension = await ImageEditor.GetImageDimensionAsync();
        await ImageEditor.DrawRedactAsync(RedactType.Blur, Dimension.X.Value + 100, Dimension.Y.Value + 100, 200, 300);
    }
    private async void updateRedact()
    {
        RedactSettings[] redacts = await ImageEditor.GetRedactsAsync();
        if (redacts.Length > 0) {
            redacts[redacts.Length - 1].BlurIntensity = 100;
           await  ImageEditor.UpdateRedactAsync(redacts[redacts.Length - 1]);
        }
    }
    private async void selectRedact()
    {
        RedactSettings[] redacts = await ImageEditor.GetRedactsAsync();
        if (redacts.Length > 0) {
            await ImageEditor.SelectRedactAsync(redacts[redacts.Length - 1].ID);
        }
    }
    private async void deleteRedact()
    {
        RedactSettings[] redacts = await ImageEditor.GetRedactsAsync();
        if (redacts.Length > 0) {
            await ImageEditor.DeleteRedactAsync(redacts[redacts.Length - 1].ID);
        }
    }
}
```

![Blazor Image Editor with Redaction](./images/blazor-image-editor-redact.png)