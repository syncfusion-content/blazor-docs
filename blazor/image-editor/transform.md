---
layout: post
title: Transform with Blazor Image Editor Component | Syncfusion
description: Checkout the Transform available in Blazor Image Editor component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: Image Editor
documentation: ug
---

# Transform in the Blazor Image Editor Component

The [Blazor Image Editor](https://www.syncfusion.com/blazor-components/blazor-image-editor) component provides a range of transformation options for manipulating both the image and its annotations. These options include rotation, flipping, zooming, and panning. These transformations offer flexibility in adjusting the image and enhancing its visual appearance. 

## Rotate an image

The [`RotateAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.SfImageEditor.html#Syncfusion_Blazor_ImageEditor_SfImageEditor_RotateAsync_System_Int32_) method allows to rotate the image and with annotations by a specific number of degrees clockwise or anti-clockwise. This method takes a single parameter: the angle of rotation in degrees. A positive value will rotate the image clockwise, while a negative value will rotate it anti-clockwise. 

```cshtml
@using Syncfusion.Blazor.ImageEditor
@using Syncfusion.Blazor.Buttons

<div style="padding-bottom: 15px">
    <SfButton OnClick="RotateAsync">Rotate</SfButton>
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

    private async void RotateAsync()
    {
        await ImageEditor.RotateAsync(90);
    }
}
```

![Blazor Image Editor with Rotate an image](./images/blazor-image-editor-rotate.jpg)

## Flip an image

The [`FlipAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.SfImageEditor.html#Syncfusion_Blazor_ImageEditor_SfImageEditor_FlipAsync_Syncfusion_Blazor_ImageEditor_ImageEditorDirection_) method, which allows you to flip the image with annotations either horizontally or vertically. This method takes a single parameter of type ImageEditorDirection, which specifies the direction in which the flip operation should be applied. 

The [`ImageEditorDirection`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.ImageEditorDirection.html) parameter accepts two values: 'Horizontal' and 'Vertical'. When you choose 'Horizontal', the image and annotations will be flipped along the horizontal axis, resulting in a mirror effect. On the other hand, selecting 'Vertical' will flip them along the vertical axis, producing a vertical mirror effect. 

Here is an example of flipping an image in a button click event. 

```cshtml
@using Syncfusion.Blazor.ImageEditor
@using Syncfusion.Blazor.Buttons

<div style="padding-bottom: 15px">
    <SfButton OnClick="FlipAsync">Flip</SfButton>
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

    private async void FlipAsync()
    {
        await ImageEditor.FlipAsync(ImageEditorDirection.Horizontal);
    }
}
```

![Blazor Image Editor with Flip an image](./images/blazor-image-editor-flip.jpg)

## Straightening in the Blazor Image Editor

The straightening feature in an Image Editor allows users to adjust an image by rotating it clockwise or counter clockwise. The rotating degree value should be within the range of -45 to +45 degrees for accurate straightening. Positive values indicate clockwise rotation, while negative values indicate counter clockwise rotation.

### Apply straightening to the image 

The Blazor Image Editor includes a [`StraightenImageAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.SfImageEditor.html#Syncfusion_Blazor_ImageEditor_SfImageEditor_StraightenImageAsync_System_Int32_) method that allows users to adjust an image by rotating it clockwise or counter clockwise. The rotating degree value should be within the range of -45 to +45 degrees for accurate straightening. Positive values indicate clockwise rotation, while negative values indicate counter clockwise rotation. Which allows you to adjust the degree of an image. This method takes one parameter that define how the straightening should be carried out:

* degree: Specifies the amount of rotation for straightening the image. Positive values indicate clockwise rotation, while negative values indicate counterclockwise rotation.

Here is an example of straightening the image.

```cshtml
@using Syncfusion.Blazor.ImageEditor
@using Syncfusion.Blazor.Buttons
 
<SfImageEditor @ref="ImageEditor" Height="400">
    <ImageEditorEvents Created="OpenAsync"></ImageEditorEvents>
</SfImageEditor>
 
@code {
    SfImageEditor ImageEditor;
    private async void OpenAsync()
    {
        await ImageEditor.OpenAsync("nature.png");
    }
}
```

![Blazor Image Editor with Straighten](./images/blazor-image-editor-straighten.png)

## Zoom in or out an image 

The [`ZoomAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.SfImageEditor.html#Syncfusion_Blazor_ImageEditor_SfImageEditor_ZoomAsync_System_Double_Syncfusion_Blazor_ImageEditor_ImageEditorPoint_) method allows to magnify an image. This method allows one to zoom in and out of the image and provides a more detailed view of the image's hidden areas. This method takes two parameters to perform zooming. 

* zoomFactor - Specifies a value to controlling the level of magnification applied to the image.

* zoomPoint - Specifies x and y coordinates of a point as ImageEditorPoint on image to perform zooming.

### Maximum and Minimum zoom level 

The [`MaxZoomFactor`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.ImageEditorZoomSettings.html#Syncfusion_Blazor_ImageEditor_ImageEditorZoomSettings_MaxZoomFactor) property is a useful feature in the Image Editor that allows you to define the maximum level of zoom permitted for an image. This property sets a limit on how much the image can be magnified, preventing excessive zooming that may result in a loss of image quality or visibility. 

By default, the [`MaxZoomFactor`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.ImageEditorZoomSettings.html#Syncfusion_Blazor_ImageEditor_ImageEditorZoomSettings_MaxZoomFactor) value is set to 10, meaning that the image can be zoomed in up to 10 times its original size. This ensures that the zooming functionality remains within reasonable bounds and maintains the integrity of the image. 

The [`MinZoomFactor`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.ImageEditorZoomSettings.html#Syncfusion_Blazor_ImageEditor_ImageEditorZoomSettings_MinZoomFactor) property allows you to specify the minimum level of zoom that is allowed for an image. By setting this property, you can prevent the image from being zoomed out beyond a certain point, ensuring that it remains visible and usable even at the smallest zoom level. 

By default, the [`MinZoomFactor`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.ImageEditorZoomSettings.html#Syncfusion_Blazor_ImageEditor_ImageEditorZoomSettings_MinZoomFactor) value is set to 0.1, meaning that the image can be zoomed out up to 10 times from its original size. 

Here is an example of specifying [`MinZoomFactor`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.ImageEditorZoomSettings.html#Syncfusion_Blazor_ImageEditor_ImageEditorZoomSettings_MinZoomFactor) and [`MaxZoomFactor`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.ImageEditorZoomSettings.html#Syncfusion_Blazor_ImageEditor_ImageEditorZoomSettings_MaxZoomFactor) property in [`ImageEditorZoomSettings`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.ImageEditorZoomSettings.html) options in an image editor.

```cshtml
@using Syncfusion.Blazor.ImageEditor
@using Syncfusion.Blazor.Buttons

<div style="padding-bottom: 15px">
    <SfButton OnClick="ZoomInAsync">Zoom In </SfButton>
    <SfButton OnClick="ZoomOutAsync">Zoom Out </SfButton>
</div>

<SfImageEditor @ref="ImageEditor" Toolbar="customToolbarItem" Height="400">
    <ImageEditorZoomSettings MaxZoomFactor="MaxZoomFactor" MinZoomFactor="MinZoomFactor"></ImageEditorZoomSettings>
    <ImageEditorEvents Created="OpenAsync"></ImageEditorEvents>
</SfImageEditor>

@code {
    SfImageEditor ImageEditor;
    double ZoomLevel = 1;
    double MinZoomFactor = 0.1;
    double MaxZoomFactor = 30;
    private List<ImageEditorToolbarItemModel> customToolbarItem = new List<ImageEditorToolbarItemModel>() { };

    private async void OpenAsync()
    {
        await ImageEditor.OpenAsync("nature.png");
    }

    private async void ZoomInAsync()
    {
        if (ZoomLevel < 1)
        {
            ZoomLevel += 0.1;
        }
        else
        {
            ZoomLevel += 1;
        }
        if (ZoomLevel > MaxZoomFactor)
        {
            ZoomLevel = MaxZoomFactor;
        }
        await ImageEditor.ZoomAsync(ZoomLevel);
    }

    private async void ZoomOutAsync()
    {
        if (ZoomLevel <= 1)
        {
            ZoomLevel -= 0.1;
        }
        else
        {
            ZoomLevel -= 1;
        }
        if (ZoomLevel < MinZoomFactor)
        {
            ZoomLevel = MinZoomFactor;
        }
        await ImageEditor.ZoomAsync(ZoomLevel);
    }
}
```

![Blazor Image Editor with Zoom](./images/blazor-image-editor-zoom.jpg)

### Enable the specific types of zooming

Using the [`ZoomTrigger`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.ImageEditorZoomSettings.html#Syncfusion_Blazor_ImageEditor_ImageEditorZoomSettings_ZoomTrigger) property of [`ImageEditorZoomSettings`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.ImageEditorZoomSettings.html), We can set one or more specific types of zoom actions like pinch, mouse wheel, commands, and toolbar options.

```cshtml
@using Syncfusion.Blazor.ImageEditor

<SfImageEditor @ref="ImageEditor" Height="450">
    <ImageEditorEvents Created="Created"></ImageEditorEvents>
    <ImageEditorZoomSettings MinZoomFactor="0.1" MaxZoomFactor="50" ZoomTrigger="ZoomTrigger.Pinch | ZoomTrigger.MouseWheel"></ImageEditorZoomSettings>
</SfImageEditor>

@code {
    SfImageEditor ImageEditor;

    private async void Created()
    {
        await ImageEditor.OpenAsync("bridge.png");
    }
}

```
![Blazor Image Editor with ZoomWheel](./images/blazor-image-editor-zoomwheel.png)

## Panning an image

The Blazor Image Editor allows to pan an image when the image exceeds the canvas size or selection range. When zooming in on an image or applying a selection for cropping, it is common for the image to exceed the size of the canvas or exceed the selection range. So, the panning is used to view the entire image, by clicking on the canvas and dragging it in the direction they want to move.

### OnPanStart and OnPanEnd event 

The [`OnPanStart`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.ImageEditorEvents.html#Syncfusion_Blazor_ImageEditor_ImageEditorEvents_OnPanStart) event is activated when the user begins dragging the image within the canvas, and the [`OnPanEnd`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.ImageEditorEvents.html#Syncfusion_Blazor_ImageEditor_ImageEditorEvents_OnPanEnd) event is triggered once the panning action is completed. These events provide an opportunity to perform specific actions, such as updating the image's position, in response to the panning gesture. And these event uses [`PanEventArgs`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.PanEventArgs.html) to handle the panning panning action when the user starts dragging the image. 

The parameter available in the [`OnPanStart`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.ImageEditorEvents.html#Syncfusion_Blazor_ImageEditor_ImageEditorEvents_OnPanStart) and [`OnPanEnd`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.ImageEditorEvents.html#Syncfusion_Blazor_ImageEditor_ImageEditorEvents_OnPanEnd) events are, 

PanEventArgs.StartPoint - The x and y coordinates as ImageEditorPoint for the start point. 

PanEventArgs.Endpoint - The x and y coordinates as ImageEditorPoint for the end point. 

PanEventArgs.Cancel – Specifies the boolean value to cancel the panning action. 

## Zooming event 

The [`Zooming`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.ImageEditorEvents.html#Syncfusion_Blazor_ImageEditor_ImageEditorEvents_Zooming) event is triggered when performing zooming the image. This event can be used to perform certain actions, such as updating the position of the image. This event is passed an object that contains information about the zooming event, such as the amount of zooming performed. And this event uses [`ZoomEventArgs`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.ZoomEventArgs.html) to handle the zooming action in the image.

The parameter available in the [`Zooming`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.ImageEditorEvents.html#Syncfusion_Blazor_ImageEditor_ImageEditorEvents_Zooming) event is, 

* ZoomEventArgs.ZoomPoint - The x and y coordinates as ImageEditorPoint for the zoom point. 

* ZoomEventArgs.PreviousZoomFactor - The previous zoom factor applied in the image editor. 

* ZoomEventArgs.CurrentZoomFactor - The current zoom factor to be applied in the image editor. 

* ZoomEventArgs.Cancel – Specify a boolean value to cancel the zooming action. 

* ZoomEventArgs.ZoomTrigger - The type of zooming performed in the image editor. 

## Rotating event 

The [`Rotating`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.ImageEditorEvents.html#Syncfusion_Blazor_ImageEditor_ImageEditorEvents_Rotating) event is triggered when performing rotating / straightening the image. This event is passed an object that contains information about the rotating event, such as the amount of rotation performed. And this event uses [`RotateEventArgs`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.RotateEventArgs.html) to handle the rotating action in the image.

The parameter available in the [`Rotating`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.ImageEditorEvents.html#Syncfusion_Blazor_ImageEditor_ImageEditorEvents_Rotating) event is, 

* RotateEventArgs.PreviousDegree: The degree of rotation before the recent rotation action was applied in the Image Editor. 

* RotateEventArgs.CurrentDegree: The current degree of rotation after the rotation action has been performed in the Image Editor. 

RotateEventArgs.Cancel – Specifies a boolean value to cancel the rotating action. 

## Flipping event 

The [`Flipping`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.ImageEditorEvents.html#Syncfusion_Blazor_ImageEditor_ImageEditorEvents_Flipping) event is triggered when performing flipping the image. This event is passed an object that contains information about the flipping event, such as the amount of flip performed. And this event uses [`FlipEventArgs`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.FlipEventArgs.html) to handle the flipping action in the image.

The parameter available in the [`Flipping`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.ImageEditorEvents.html#Syncfusion_Blazor_ImageEditor_ImageEditorEvents_Flipping) event is, 

* FlipEventArgs.Direction - The flip direction as ImageEditorDirection to be applied in the image editor.

* FlipEventArgs.PreviousDirection - The previous flip direction, represented as ImageEditorDirection, applied within the image editor.

* FlipEventArgs.Cancel - Specifies a boolean value to cancel the flip action.
