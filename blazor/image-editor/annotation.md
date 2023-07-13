---
layout: post
title: Annotation with Blazor Image Editor Component | Syncfusion
description: Checkout the Annotation available in Blazor Image Editor component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: Image Editor
documentation: ug
---

# Annotations in the Blazor Image Editor component

The [Blazor Image Editor](https://www.syncfusion.com/blazor-components/blazor-image-editor) component allows adding annotations to the image, including text, freehand drawings, and shapes like rectangles, ellipses, arrows, paths, and lines. This gives the flexibility to mark up the image with notes, sketches, and other visual elements as needed. These annotation tools can help to communicate and share ideas more effectively.

## Text annotation

Text annotation feature in the Blazor Image Editor component provides the capability to add and customize labels, captions, and other text elements directly onto the image. With this feature, you can easily insert text at specific locations within the image and customize various aspects of the text to meet your requirements.

You have control over the customization options including text content, font family, font style and font size for the text annotation.

### Add a text

The [`DrawTextAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.SfImageEditor.html#Syncfusion_Blazor_ImageEditor_SfImageEditor_DrawTextAsync_System_Nullable_System_Double__System_Nullable_System_Double__System_String_System_String_System_Nullable_System_Int32__System_Boolean_System_Boolean_System_String_) method in the Blazor Image Editor component allows you to insert a text annotation into the image with specific customization options. This method accepts the following parameters:

* x - Specifies the x-coordinate of the text, determining its horizontal position within the image.

* y - Specifies the y-coordinate of the text, determining its vertical position within the image.

* text - Specifies the actual text content to be added to the image.

* fontFamily - Specifies the font family of the text, allowing you to choose a specific typeface or style for the text.

* fontSize - Specifies the font size of the text, determining its relative size within the image.

* bold - Specifies whether the text should be displayed in bold style. Set to true for bold text, and false for regular text.

* italic - Specifies whether the text should be displayed in italic style. Set to true for italic text, and false for regular text.

* color - Specifies the font color of the text, allowing you to define the desired color using appropriate color values or names.

By utilizing the [`DrawTextAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.SfImageEditor.html#Syncfusion_Blazor_ImageEditor_SfImageEditor_DrawTextAsync_System_Nullable_System_Double__System_Nullable_System_Double__System_String_System_String_System_Nullable_System_Int32__System_Boolean_System_Boolean_System_String_) method with these parameters, you can precisely position and customize text annotations within the image. This provides the flexibility to add labels, captions, or other text elements with specific font styles, sizes, and colors, enhancing the visual presentation and clarity of the image. 

Here is an example of adding a text in a button click using [`DrawTextAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.SfImageEditor.html#Syncfusion_Blazor_ImageEditor_SfImageEditor_DrawTextAsync_System_Nullable_System_Double__System_Nullable_System_Double__System_String_System_String_System_Nullable_System_Int32__System_Boolean_System_Boolean_System_String_) method. 

In the following example, you can using the DrawTextAsync method in the button click event.

```cshtml
@using Syncfusion.Blazor.ImageEditor
@using Syncfusion.Blazor.Buttons

<div style="padding-bottom: 15px">
    <SfButton OnClick="DrawTextAsync">Draw Text</SfButton>
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

    private async void DrawTextAsync()
    {
        ImageDimension Dimension = await ImageEditor.GetImageDimensionAsync();
        await ImageEditor.DrawTextAsync(Dimension.X, Dimension.Y, "Syncfusion");
    }
}
```

![Blazor Image Editor with Draw text an image](./images/blazor-image-editor-draw-text.png)

### Multiline text

The [`DrawTextAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.SfImageEditor.html#Syncfusion_Blazor_ImageEditor_SfImageEditor_DrawTextAsync_System_Nullable_System_Double__System_Nullable_System_Double__System_String_System_String_System_Nullable_System_Int32__System_Boolean_System_Boolean_System_String_) method in the Blazor Image Editor component is commonly used to insert text annotations into an image. If the provided text parameter contains a newline character (\n), the text will be automatically split into multiple lines, with each line appearing on a separate line in the annotation. 

Here is an example of adding a multiline text in a button click using [`DrawTextAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.SfImageEditor.html#Syncfusion_Blazor_ImageEditor_SfImageEditor_DrawTextAsync_System_Nullable_System_Double__System_Nullable_System_Double__System_String_System_String_System_Nullable_System_Int32__System_Boolean_System_Boolean_System_String_) method.

```cshtml
@using Syncfusion.Blazor.ImageEditor
@using Syncfusion.Blazor.Buttons

<div style="padding-bottom: 15px">
    <SfButton OnClick="DrawTextAsync">Draw Text</SfButton>
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

    private async void DrawTextAsync()
    {
        ImageDimension Dimension = await ImageEditor.GetImageDimensionAsync();
        await ImageEditor.DrawTextAsync(Dimension.X, Dimension.Y, "Enter\nText");
    }
}
```

![Blazor Image Editor with Draw multiline text an image](./images/blazor-image-editor-draw-multiline-text.png)

### Delete a text

The [`DeleteShapeAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.SfImageEditor.html#Syncfusion_Blazor_ImageEditor_SfImageEditor_DeleteShapeAsync_System_String_) method allows you to remove a text annotation from the Blazor Image Editor component. To use this method, you need to pass the [`ID`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.ShapeSettings.html#Syncfusion_Blazor_ImageEditor_ShapeSettings_ID) of the annotation as a parameter. 

The [`ID`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.ShapeSettings.html#Syncfusion_Blazor_ImageEditor_ShapeSettings_ID) is a unique identifier assigned to each text annotation within the Blazor Image Editor. It serves as a reference to a specific annotation, enabling targeted deletion of the desired text element. By specifying the [`ID`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.ShapeSettings.html#Syncfusion_Blazor_ImageEditor_ShapeSettings_ID) associated with the text annotation you want to remove, you can effectively delete it from the image editor.

To retrieve the inserted text annotations, you can utilize the [`GetShapesAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.SfImageEditor.html#Syncfusion_Blazor_ImageEditor_SfImageEditor_GetShapesAsync) method, which provides a collection of annotations represented by [`ShapeSettings`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.ShapeSettings.html). This method allows you to access and work with the annotations that have been inserted into the image.

Here is an example of deleting a text in a button click using [`DeleteShapeAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.SfImageEditor.html#Syncfusion_Blazor_ImageEditor_SfImageEditor_DeleteShapeAsync_System_String_) method. 

```cshtml
@using Syncfusion.Blazor.ImageEditor
@using Syncfusion.Blazor.Buttons

<div style="padding-bottom: 15px">
    <SfButton OnClick="DrawTextAsync">Draw Text</SfButton>
    <SfButton OnClick="DeleteShapeAsync">Delete Text</SfButton>
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

    private async void DrawTextAsync()
    {
        ImageDimension Dimension = await ImageEditor.GetImageDimensionAsync();
        await ImageEditor.DrawTextAsync(Dimension.X, Dimension.Y, "Enter\nText");
    }

    private async void DeleteShapeAsync()
    {
        await ImageEditor.DeleteShapeAsync("shape_1");
    }
}
```

![Blazor Image Editor with Delete text an image](./images/blazor-image-editor-delete-text.png)

### Customize a text color 

The [ShapeChanging](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.ImageEditorEvents.html#Syncfusion_Blazor_ImageEditor_ImageEditorEvents_ShapeChanging) event in the Blazor Image Editor component is triggered when a text annotation is being modified or changed through the toolbar interaction. This event provides an opportunity to make alterations to the text's color and font family by adjusting the relevant properties. 

By leveraging the [ShapeChanging](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.ImageEditorEvents.html#Syncfusion_Blazor_ImageEditor_ImageEditorEvents_ShapeChanging) event, you can enhance the customization options for text annotations and provide a more tailored and interactive experience within the Image Editor component. 

Here is an example of changing the text color using the [ShapeChanging](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.ImageEditorEvents.html#Syncfusion_Blazor_ImageEditor_ImageEditorEvents_ShapeChanging) event.

```cshtml
@using Syncfusion.Blazor.ImageEditor

<SfImageEditor @ref="ImageEditor" Height="400" Toolbar="customToolbarItem">
    <ImageEditorEvents Created="OpenAsync" ShapeChanging="ShapeChanging"></ImageEditorEvents>
</SfImageEditor>

@code {
    SfImageEditor ImageEditor;
    private List<ImageEditorToolbarItemModel> customToolbarItem = new List<ImageEditorToolbarItemModel>()
    {
        new ImageEditorToolbarItemModel { Name = "Annotation" },
        new ImageEditorToolbarItemModel { Name = "Reset" },
        new ImageEditorToolbarItemModel { Name = "Confirm" }
    };

    private async void OpenAsync()
    {
        await ImageEditor.OpenAsync("nature.png");
    }

    private void ShapeChanging(ShapeChangeEventArgs args)
    {
        if (args.CurrentShapeSettings.Type == ShapeType.Text)
        {
            args.CurrentShapeSettings.Color = "red";
        }
    }
}
```

![Blazor Image Editor with Custom text an image](./images/blazor-image-editor-custom-text.png)
        
## Freehand drawing

The Freehand Draw annotation tool in the Blazor Image Editor component is a versatile feature that allows users to draw and sketch directly on the image using mouse or touch input. This tool provides a flexible and creative way to add freehand drawings or annotations to the image. 

To enable or disable the freehand drawing option, the Blazor Image Editor component provides two methods: 

[`EnableFreehandDrawAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.SfImageEditor.html#Syncfusion_Blazor_ImageEditor_SfImageEditor_EnableFreehandDrawAsync_System_Boolean_): This method is used to enable the freehand drawing option in the Image Editor. Once enabled, users can start drawing freely on the image using their mouse or touch input. 

[`DisableFreehandDrawAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.SfImageEditor.html#Syncfusion_Blazor_ImageEditor_SfImageEditor_DisableFreehandDrawAsync_System_Boolean_): This method is used to disable the freehand drawing option in the Image Editor. When disabled, users will no longer be able to perform freehand drawings on the image. 

Here is an example of using the [`EnableFreehandDrawAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.SfImageEditor.html#Syncfusion_Blazor_ImageEditor_SfImageEditor_EnableFreehandDrawAsync_System_Boolean_) and [`DisableFreehandDrawAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.SfImageEditor.html#Syncfusion_Blazor_ImageEditor_SfImageEditor_DisableFreehandDrawAsync_System_Boolean_) methods in a button click event. 

```cshtml
@using Syncfusion.Blazor.ImageEditor
@using Syncfusion.Blazor.Buttons

<div style="padding-bottom: 15px">
    <SfButton OnClick="EnableFreehandDrawAsync">Enable Freehand Draw</SfButton>
    <SfButton OnClick="DisableFreehandDrawAsync">Disable Freehand Draw</SfButton>
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

    private async void EnableFreehandDrawAsync()
    {
        await ImageEditor.EnableFreehandDrawAsync();
    }

    private async void DisableFreehandDrawAsync()
    {
        await ImageEditor.DisableFreehandDrawAsync();
    }
}
```

![Blazor Image Editor with Freehandraw](./images/blazor-image-editor-Freehanddraw.png)

### Adjust a stroke width and color

The [ShapeChanging](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.ImageEditorEvents.html#Syncfusion_Blazor_ImageEditor_ImageEditorEvents_ShapeChanging) event in the Blazor Image Editor component is triggered when a freehand annotation is being modified or changed through the toolbar interaction. This event provides an opportunity to make alterations to the freehand annotation’s color and stroke width by adjusting the relevant properties.

By leveraging the [ShapeChanging](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.ImageEditorEvents.html#Syncfusion_Blazor_ImageEditor_ImageEditorEvents_ShapeChanging) event, you can enhance the customization options for freehand annotations and provide a more tailored and interactive experience within the Blazor Image Editor component.

Here is an example of changing the freehand draw stroke width and color using the [ShapeChanging](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.ImageEditorEvents.html#Syncfusion_Blazor_ImageEditor_ImageEditorEvents_ShapeChanging) event.


```cshtml
@using Syncfusion.Blazor.ImageEditor

<SfImageEditor @ref="ImageEditor" Height="400" Toolbar="customToolbarItem">
    <ImageEditorEvents Created="OpenAsync" ShapeChanging="ShapeChanging"></ImageEditorEvents>
</SfImageEditor>

@code {
    SfImageEditor ImageEditor;
    private List<ImageEditorToolbarItemModel> customToolbarItem = new List<ImageEditorToolbarItemModel>()
    {
        new ImageEditorToolbarItemModel { Name = "Annotation" },
        new ImageEditorToolbarItemModel { Name = "Reset" },
        new ImageEditorToolbarItemModel { Name = "Confirm" }
    };

    private async void OpenAsync()
    {
        await ImageEditor.OpenAsync("nature.png");
    }

    private void ShapeChanging(ShapeChangeEventArgs args)
    {
        if (args.CurrentShapeSettings.Type == ShapeType.FreehandDraw)
        {
            args.CurrentShapeSettings.StrokeColor = "red";
            args.CurrentShapeSettings.StrokeWidth = 4;
        }
    }
}
```

![Blazor Image Editor with Adjust the stroke width and color](./images/blazor-image-editor-adjust-stroke-color.png)

### Delete a freehand drawing

The [`DeleteShapeAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.SfImageEditor.html#Syncfusion_Blazor_ImageEditor_SfImageEditor_DeleteShapeAsync_System_String_) method allows you to remove a freehand annotation from the Blazor Image Editor component. To use this method, you need to pass the [`ID`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.ShapeSettings.html#Syncfusion_Blazor_ImageEditor_ShapeSettings_ID) of the annotation as a parameter. 

The [`ID`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.ShapeSettings.html#Syncfusion_Blazor_ImageEditor_ShapeSettings_ID) is a unique identifier assigned to each freehand annotation within the Blazor Image Editor. It serves as a reference to a specific annotation, enabling targeted deletion of the desired text element. By specifying the [`ID`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.ShapeSettings.html#Syncfusion_Blazor_ImageEditor_ShapeSettings_ID) associated with the text annotation you want to remove, you can effectively delete it from the image editor.

To retrieve the inserted freehand drawings, you can utilize the [`GetShapesAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.SfImageEditor.html#Syncfusion_Blazor_ImageEditor_SfImageEditor_GetShapesAsync) method, which provides a collection of annotations represented by [`ShapeSettings`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.ShapeSettings.html). This method allows you to access and work with the annotations that have been inserted into the image.

Here is an example of deleting a freehand annotation in a button click using [`DeleteShapeAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.SfImageEditor.html#Syncfusion_Blazor_ImageEditor_SfImageEditor_DeleteShapeAsync_System_String_) method. 


```cshtml
@using Syncfusion.Blazor.ImageEditor
@using Syncfusion.Blazor.Buttons

<div style="padding-bottom: 15px">
    <SfButton OnClick="EnableFreehandDrawAsync">Enable Freehand Draw</SfButton>
    <SfButton OnClick="DeleteShapeAsync">Delete Shape</SfButton>
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

    private async void EnableFreehandDrawAsync()
    {
        await ImageEditor.EnableFreehandDrawAsync();
    }

    private async void DeleteShapeAsync()
    {
        await ImageEditor.DeleteShapeAsync("pen_1");
    }
}
```

![Blazor Image Editor with Delete Freehanddraw an image](./images/blazor-image-editor-delete-shape.png)

## Shape Annotation

The Blazor Image Editor component provides the ability to add shape annotations to an image. These shape annotations include rectangles, ellipses, arrows, paths, and lines, allowing you to highlight, emphasize, or mark specific areas or elements within the image.

### Add a rectangle /ellipse / line / arrow / path

The [`DrawRectangleAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.SfImageEditor.html#Syncfusion_Blazor_ImageEditor_SfImageEditor_DrawRectangleAsync_System_Nullable_System_Double__System_Nullable_System_Double__System_Nullable_System_Int32__System_Nullable_System_Int32__System_Nullable_System_Int32__System_String_System_String_) method is used to draw rectangle in the Blazor Image Editor component. Rectangle annotations are valuable tools for highlighting, emphasizing, or marking specific areas of an image to draw attention or provide additional context.

The [`DrawRectangleAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.SfImageEditor.html#Syncfusion_Blazor_ImageEditor_SfImageEditor_DrawRectangleAsync_System_Nullable_System_Double__System_Nullable_System_Double__System_Nullable_System_Int32__System_Nullable_System_Int32__System_Nullable_System_Int32__System_String_System_String_) method in the Image Editor component takes seven parameters to define the properties of the rectangle annotation: 

* x: Specifies the x-coordinate of the top-left corner of the rectangle. 

* y: Specifies the y-coordinate of the top-left corner of the rectangle. 

* width: Specifies the width of the rectangle. 

* height: Specifies the height of the rectangle. 

* strokeWidth: Specifies the stroke width of the rectangle's border. 

* strokeColor: Specifies the stroke color of the rectangle's border. 

* fillColor: Specifies the fill color of the rectangle.

The [`DrawEllipseAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.SfImageEditor.html#Syncfusion_Blazor_ImageEditor_SfImageEditor_DrawEllipseAsync_System_Nullable_System_Double__System_Nullable_System_Double__System_Nullable_System_Double__System_Nullable_System_Double__System_Nullable_System_Double__System_String_System_String_) method in the Blazor Image Editor component is used to draw an ellipse. Ellipse annotations are valuable for highlighting, emphasizing, or marking specific areas of an image.

The [`DrawEllipseAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.SfImageEditor.html#Syncfusion_Blazor_ImageEditor_SfImageEditor_DrawEllipseAsync_System_Nullable_System_Double__System_Nullable_System_Double__System_Nullable_System_Double__System_Nullable_System_Double__System_Nullable_System_Double__System_String_System_String_) method in the Image Editor component takes seven parameters to define the properties of the ellipse annotation: 

* x: Specifies the x-coordinate of the center of the ellipse. 

* y: Specifies the y-coordinate of the center of the ellipse. 

* radiusX: Specifies the horizontal radius (radiusX) of the ellipse. 

* radiusY: Specifies the vertical radius (radiusY) of the ellipse. 

* strokeWidth: Specifies the width of the ellipse's stroke (border). 

* strokeColor: Specifies the color of the ellipse's stroke (border). 

* fillColor: Specifies the fill color of the ellipse. 

The [`DrawLineAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.SfImageEditor.html#Syncfusion_Blazor_ImageEditor_SfImageEditor_DrawLineAsync_System_Nullable_System_Double__System_Nullable_System_Double__System_Nullable_System_Double__System_Nullable_System_Double__System_Nullable_System_Double__System_String_) method is used to draw line in the Blazor Image Editor component. Line annotations are valuable for highlighting, emphasizing, or marking specific areas of an image.

The [`DrawLineAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.SfImageEditor.html#Syncfusion_Blazor_ImageEditor_SfImageEditor_DrawLineAsync_System_Nullable_System_Double__System_Nullable_System_Double__System_Nullable_System_Double__System_Nullable_System_Double__System_Nullable_System_Double__System_String_) method in the Image Editor component takes seven parameters to define the properties of the ellipse annotation:

* startX - Specifies the x-coordinate of the start point.

* startY - Specifies the y-coordinate of the start point.

* endX - Specifies the x-coordinate of the end point.

* endY - Specifies the y-coordinate of the end point.

* strokeWidth - Specifies the stroke width of the line.

* strokeColor - Specifies the stroke color of the line.


The ['DrawArrowAsync'](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.SfImageEditor.html#Syncfusion_Blazor_ImageEditor_SfImageEditor_DrawArrowAsync_System_Nullable_System_Double__System_Nullable_System_Double__System_Nullable_System_Double__System_Nullable_System_Double__System_Nullable_System_Double__System_String_Syncfusion_Blazor_ImageEditor_ImageEditorArrowHeadType_Syncfusion_Blazor_ImageEditor_ImageEditorArrowHeadType_) method is used to draw arrow in the Blazor Image Editor component. Arrow annotations are valuable for highlighting, emphasizing, or marking specific areas of an image.

The ['DrawArrowAsync'](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.SfImageEditor.html#Syncfusion_Blazor_ImageEditor_SfImageEditor_DrawArrowAsync_System_Nullable_System_Double__System_Nullable_System_Double__System_Nullable_System_Double__System_Nullable_System_Double__System_Nullable_System_Double__System_String_Syncfusion_Blazor_ImageEditor_ImageEditorArrowHeadType_Syncfusion_Blazor_ImageEditor_ImageEditorArrowHeadType_) method in the Image Editor component takes seven parameters to define the properties of the ellipse annotation:

* startX - Specifies the x-coordinate of the start point.

* startY - Specifies the y-coordinate of the start point.

* endX - Specifies the x-coordinate of the end point.

* endY - Specifies the y-coordinate of the end point.

* strokeWidth - Specifies the stroke width of the arrow.

* strokeColor - Specifies the stroke color of the arrow.

* arrowStart - Specifies the arrowhead as ImageEditorArrowHeadType at the start of arrow.

* arrowEnd - Specifies the arrowhead as ImageEditorArrowHeadType at the end of the arrow.

The ['DrawPathAsync'](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.SfImageEditor.html#Syncfusion_Blazor_ImageEditor_SfImageEditor_DrawPathAsync_Syncfusion_Blazor_ImageEditor_ImageEditorPoint___System_Nullable_System_Double__System_String_) method is used to draw path in the Blazor Image Editor component. Line annotations are valuable for highlighting, emphasizing, or marking specific areas of an image.

The ['DrawPathAsync'](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.SfImageEditor.html#Syncfusion_Blazor_ImageEditor_SfImageEditor_DrawPathAsync_Syncfusion_Blazor_ImageEditor_ImageEditorPoint___System_Nullable_System_Double__System_String_) method in the Image Editor component takes three parameters to define the properties of the ellipse annotation:

* points - Specifies collection of x and y coordinates as ImageEditorPoint to draw a path.

* strokeWidth - Specifies the stroke width of the path.

* strokeColor - Specifies the stroke color of the path.

Here is an example of inserting rectangle, ellipse, arrow, path, and line in a button click event.

```cshtml
@using Syncfusion.Blazor.ImageEditor
@using Syncfusion.Blazor.Buttons

<div style="padding-bottom: 15px">
    <SfButton OnClick="RectangleAsync">Draw Rectangle</SfButton>
    <SfButton OnClick="EllipseAsync">Draw Ellipse</SfButton>
    <SfButton OnClick="ArrowAsync">Draw Arrow</SfButton>
    <SfButton OnClick="PathAsync">Draw Path</SfButton>
    <SfButton OnClick="LineAsync">Draw Line</SfButton>
</div>

<SfImageEditor @ref="ImageEditor" Toolbar="customToolbarItem" Height="400">
    <ImageEditorEvents Created="CreatedAsync"></ImageEditorEvents>
</SfImageEditor>

@code {
    SfImageEditor ImageEditor;
    private List<ImageEditorToolbarItemModel> customToolbarItem = new List<ImageEditorToolbarItemModel>() { };
    private ImageEditorPoint[] points = new ImageEditorPoint[] { new ImageEditorPoint { X = 400, Y = 200 }, new ImageEditorPoint { X = 500, Y = 300 }, new ImageEditorPoint { X = 350, Y = 400 } };

    private async void CreatedAsync()
    {
        await ImageEditor.OpenAsync("nature.png");
    }

    private async void RectangleAsync()
    {
        await ImageEditor.DrawRectangleAsync(250, 50, 120, 120, 4, "#fff", "blue");
    }

    private async void EllipseAsync()
    {
        await ImageEditor.DrawEllipseAsync(500, 50, 70, 70, 4, "#fff", "green");
    }

    private async void ArrowAsync()
    {
        await ImageEditor.DrawArrowAsync(250, 200, 400, 200, 5, "red", ImageEditorArrowHeadType.Circle);
    }

    private async void PathAsync()
    {
        await ImageEditor.DrawPathAsync(points, 5, "yellow");
    }

    private async void LineAsync()
    {
        await ImageEditor.DrawLineAsync(250, 300, 400, 400, 5, "brown");
    }
}
```

![Blazor Image Editor with Annotation an image](./images/blazor-image-editor-annotation.png)

## Delete a shape 

The [`DeleteShapeAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.SfImageEditor.html#Syncfusion_Blazor_ImageEditor_SfImageEditor_DeleteShapeAsync_System_String_) method allows you to remove a shape annotation from the Blazor Image Editor component. To use this method, you need to pass the [`ID`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.ShapeSettings.html#Syncfusion_Blazor_ImageEditor_ShapeSettings_ID) of the annotation as a parameter. 

The [`ID`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.ShapeSettings.html#Syncfusion_Blazor_ImageEditor_ShapeSettings_ID) is a unique identifier assigned to each shape annotation within the Blazor Image Editor. It serves as a reference to a specific annotation, enabling targeted deletion of the desired text element. By specifying the [`ID`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.ShapeSettings.html#Syncfusion_Blazor_ImageEditor_ShapeSettings_ID) associated with the text annotation you want to remove, you can effectively delete it from the image editor.

To retrieve the inserted shapes, you can utilize the [`GetShapesAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.SfImageEditor.html#Syncfusion_Blazor_ImageEditor_SfImageEditor_GetShapesAsync) method, which provides a collection of annotations represented by [`ShapeSettings`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.ShapeSettings.html). This method allows you to access and work with the annotations that have been inserted into the image.

Here is an example of deleting rectangle, ellipse, arrow, path, and line in a button click event.

```cshtml
@using Syncfusion.Blazor.ImageEditor
@using Syncfusion.Blazor.Buttons

<div style="padding-bottom: 15px">
    <SfButton OnClick="DrawTextAsync">Draw Text</SfButton>
    <SfButton OnClick="DeleteShapeAsync">Delete Shape</SfButton>
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

    private async void DrawTextAsync()
    {
        ImageDimension Dimension = await ImageEditor.GetImageDimensionAsync();
        await ImageEditor.DrawTextAsync(Dimension.X, Dimension.Y, "Enter\nText");
    }

    private async void DeleteShapeAsync()
    {
        await ImageEditor.DeleteShapeAsync("shape_1");
    }
}
```

![Blazor Image Editor with Delete text an image](./images/blazor-image-editor-delete-text.png)