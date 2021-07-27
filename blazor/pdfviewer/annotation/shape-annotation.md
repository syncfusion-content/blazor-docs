---
layout: post
title: Shape annotations in Blazor PDF Viewer Component | Syncfusion
description: Learn here all about Shape annotations in Syncfusion Blazor PDF Viewer component and more.
platform: Blazor
control: PDF Viewer
documentation: ug
---

# Shape annotations in Blazor PDF Viewer Component

The PDF Viewer control provides the options to add, edit and delete the shape annotations. The shape annotation types supported in the PDF Viewer control are:

* Line
* Arrow
* Rectangle
* Circle
* Polygon

![ShapeAnnotation](../../pdfviewer/images/shape_annot.png)

## Adding a shape annotation to the PDF document

Shape annotations can be added to the PDF document using the annotation toolbar.

* Click the **Edit Annotation** button in the PDF Viewer toolbar.  A toolbar appears below it.
* Click the **Shape Annotation** dropdown button. A dropdown pop-up will appear and shows the shape annotations to be added.
* Select the shape types to be added to the page in the dropdown pop-up. It enables the selected shape annotation mode.
* You can add the shapes over the pages of the PDF document.

In the pan mode, if the shape annotation mode is entered, the PDF Viewer control will switch to text select mode.

![ShapeTool](../../pdfviewer/images/shape_toolbar.png)

Refer to the following code snippet to switch to circle annotation mode.

```cshtml
@using Syncfusion.Blazor.PdfViewerServer
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.PdfViewer

<SfButton OnClick="OnClick">Click Here</SfButton>
<SfPdfViewerServer DocumentPath="@DocumentPath" @ref="viewer" Width="1060px" Height="500px">
</SfPdfViewerServer>

@code{
    SfPdfViewerServer viewer;

    public void OnClick(MouseEventArgs args)
    {
        viewer.SetAnnotationMode(AnnotationType.Circle);
    }
    private string DocumentPath { get; set; } = "wwwroot/Data/PDF_Succinctly.pdf";
}
```

## Editing the properties of the shape annotation

The fill color, stroke color, thickness and opacity of the shape annotation can be edited using the Edit color tool, Edit stroke color tool, Edit thickness tool and Edit opacity tool in the annotation toolbar.

### Editing fill color

The fill color of the annotation can be edited using the color palette provided in the Edit Color tool.

![ShapeFillColor](../../pdfviewer/images/shape_fillColor.png)

### Editing stroke color

The stroke color of the annotation can be edited using the color palette provided in the Edit Stroke Color tool.

![ShapeStrokeColor](../../pdfviewer/images/shape_strokecolor.png)

### Editing thickness

The thickness of the border of the annotation can be edited using the range slider provided in the Edit Thickness tool.

![ShapeThickness](../../pdfviewer/images/shape_thickness.png)

### Editing opacity

The opacity of the annotation can be edited using the range slider provided in the Edit Opacity tool.

![ShapeOpacity](../../pdfviewer/images/shape_opacity.png)

### Editing the line properties

The properties of the line shapes such as line and arrow annotations can be edited using the Line Properties window. It can be opened by selecting the Properties option in the context menu that appears on right clicking the line and arrow annotations.

Refer to the following code snippet to set the default annotation settings.

![ShapeProperty](../../pdfviewer/images/shape_lineprty.png)

## Setting default properties during control initialization

The properties of the shape annotations can be set before creating the control using LineSettings, ArrowSettings, RectangleSettings, CircleSettings, and PolygonSettings.

```cshtml
@using Syncfusion.Blazor
@using Syncfusion.Blazor.PdfViewerServer
<SfPdfViewerServer @ref="@viewer" DocumentPath="@DocumentPath" LineSettings="@LineSettings" ArrowSettings="@ArrowSettings" RectangleSettings="@RectangleSettings" CircleSettings="@CircleSettings" PolygonSettings="@PolygonSettings">
</SfPdfViewerServer>
@code{
    SfPdfViewerServer viewer;
    private string DocumentPath { get; set; } = "wwwroot/Data/PDF_Succinctly.pdf";
    PdfViewerLineSettings LineSettings = new PdfViewerLineSettings { FillColor="blue", Opacity = 0.6 ,StrokeColor="green"};
    PdfViewerArrowSettings ArrowSettings = new PdfViewerArrowSettings { FillColor="green", Opacity = 0.6 ,StrokeColor="blue"};
    PdfViewerRectangleSettings RectangleSettings = new PdfViewerRectangleSettings { FillColor="yellow", Opacity = 0.6 ,StrokeColor="orange" };
    PdfViewerCircleSettings CircleSettings = new PdfViewerCircleSettings { FillColor = "orange", Opacity = 0.6, StrokeColor = "pink" };
    PdfViewerPolygonSettings PolygonSettings = new PdfViewerPolygonSettings {FillColor="pink", Opacity = 0.6 ,StrokeColor="yellow" };
}
```