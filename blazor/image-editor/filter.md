---
layout: post
title: Filter with Blazor Image Editor Component | Syncfusion
description: Checkout the Filter available in Blazor Image Editor component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: Image Editor
documentation: ug
---

# Filters in the Blazor Image Editor component

Filters are pre-defined effects that can be applied to an image to alter its appearance or mood. Image filters can be used to add visual interest or to enhance certain features of the image. Some common types of image filters include cold, warm, chrome, sepia, and invert.

## Apply filter effect

The [`ApplyImageFilterAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.SfImageEditor.html#Syncfusion_Blazor_ImageEditor_SfImageEditor_ApplyImageFilterAsync_Syncfusion_Blazor_ImageEditor_ImageFilterOption_) method is utilized to apply filters to an image. By passing the desired filter type as the first parameter of the method, specified as [`ImageFilterOption`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.ImageFilterOption.html) the method applies the corresponding filter to the image. This allows for easy and convenient application of various filters to enhance or modify the image based on the chosen filter type.

The `ApplyImageFilterAsync` method is used to perform filtering by specifying the type of filter as `ImageFilterOption` and send it a first parameter of the method.

Here is an example of filtering using the `ApplyImageFilterAsync` method.

```cshtml
@using Syncfusion.Blazor.ImageEditor
@using Syncfusion.Blazor.Buttons

<div style="padding-bottom: 15px">
    <SfButton OnClick="ChromeClick">Chrome</SfButton>
    <SfButton OnClick="ColdClick">Cold</SfButton>
    <SfButton OnClick="WarmClick">Warm</SfButton>
    <SfButton OnClick="GrayscaleClick">Grayscale</SfButton>
    <SfButton OnClick="SepiaClick">Sepia</SfButton>
    <SfButton OnClick="InvertClick">Invert</SfButton>
</div>

<SfImageEditor @ref="ImageEditor" Toolbar="customToolbarItem" Height="400">
    <ImageEditorEvents Created="OpenAsync"></ImageEditorEvents>
</SfImageEditor>

@code {
    SfImageEditor ImageEditor;
    private List<ImageEditorToolbarItemModel> customToolbarItem = new List<ImageEditorToolbarItemModel>() { };

    private async void OpenAsync()
    {
        await ImageEditor.OpenAsync("https://ej2.syncfusion.com/react/demos/src/image-editor/images/bridge.png");
    }

    private async void ChromeClick()
    {
        await ImageEditor.ApplyImageFilterAsync(ImageFilterOption.Chrome);
    }

    private async void ColdClick()
    {
        await ImageEditor.ApplyImageFilterAsync(ImageFilterOption.Cold);
    }

    private async void WarmClick()
    {
        await ImageEditor.ApplyImageFilterAsync(ImageFilterOption.Warm);
    }

    private async void GrayscaleClick()
    {
        await ImageEditor.ApplyImageFilterAsync(ImageFilterOption.Grayscale);
    }

    private async void SepiaClick()
    {
        await ImageEditor.ApplyImageFilterAsync(ImageFilterOption.Sepia);
    }

    private async void InvertClick()
    {
        await ImageEditor.ApplyImageFilterAsync(ImageFilterOption.Invert);
    }
}
```

![Blazor Image Editor with Filter an image](./images/blazor-image-editor-filter.jpg)

### Image filtering event

The [`ImageFiltering`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.ImageEditorEvents.html#Syncfusion_Blazor_ImageEditor_ImageEditorEvents_ImageFiltering) event is triggered when applying filtering on the image. This event is passed an object that contains information about the filtering event, such as the type of filtering.

The parameter available in the [`ImageFilterEventArgs`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.ImageFilterEventArgs.html) event is,

ImageFilterEventArgs.Filter - The type of filtering as ImageFilterOption to be applied in the image editor.

ImageFilterEventArgs.Cancel – Specifies to cancel the filtering action.
