---
layout: post
title: Measurement annotations in Blazor PDF Viewer Component | Syncfusion
description: Checkout and learn here all about measurement annotations in Syncfusion Blazor PDF Viewer component and more.
platform: Blazor
control: PDF Viewer
documentation: ug
---

N> Syncfusion recommends using [Blazor PDF Viewer (NextGen)](https://blazor.syncfusion.com/documentation/pdfviewer-2/getting-started/server-side-application) Component which provides fast rendering of pages and improved performance. Also, there is no need of external Web service for processing the files and ease out the deployment complexity. It can be used in Blazor Server, WASM and MAUI applications without any changes.

# Measurement annotations in Blazor PDF Viewer Component

The PDF Viewer provides the options to add measurement annotations. The page annotations can be measured with the help of measurement annotation. The supported measurement annotations in the PDF Viewer control are:

* Distance
* Perimeter
* Area
* Radius
* Volume

![Calibrate Annotation in Blazor PDFViewer](../../pdfviewer/images/blazor-pdfviewer-calibrate-annotation.png)

## Adding measurement annotations to the PDF document

The measurement annotations can be added to the PDF document using the annotation toolbar.

* Click the **Edit Annotation** button in the PDF Viewer toolbar. A toolbar appears below it.
* Click the **measurement Annotation** dropdown button. A dropdown pop-up will appear and shows the measurement annotations to be added.
* Select the measurement type to be added to the page in the dropdown pop-up. It enables the selected measurement annotation mode.
* You can measure and add the annotation over the pages of the PDF document.

In the pan mode, if the measurement annotation mode is entered, the PDF Viewer control will switch to text select mode.

![Adding Calibrate in Blazor PDFViewer Toolbar](../../pdfviewer/images/blazor-pdfviewer-add-calibrate-in-toolbar.png)


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
        viewer.SetAnnotationMode(AnnotationType.Distance);
    }
    private string DocumentPath { get; set; } = "wwwroot/Data/PDF_Succinctly.pdf";
}
```

## Editing the properties of measurement annotation

The fill color, stroke color, thickness, and opacity of the measurement annotation can be edited using the Edit Color tool, Edit Stroke Color tool, Edit Thickness tool, and Edit Opacity tool in the annotation toolbar.

### Editing fill color

The fill color of the annotation can be edited using the color palette provided in the Edit Color tool.

![Editing Calibrate FillColor in Blazor PDFViewer](../../pdfviewer/images/blazor-pdfviewer-calibrate-fillcolor.png)

### Editing stroke color

The stroke color of the annotation can be edited using the color palette provided in the Edit Stroke Color tool.

![Editing Calibrate StrokeColor in Blazor PDFViewer](../../pdfviewer/images/blazor-pdfviewer-calibrate-stroke-color.png)

### Editing thickness

The thickness of the border of the annotation can be edited using the range slider provided in the Edit thickness tool.

![Editing Calibrate Thickness in Blazor PDFViewer](../../pdfviewer/images/blazor-pdfviewer-calibrate-thickness.png)

### Editing opacity

The opacity of the annotation can be edited using the range slider provided in the Edit Opacity tool.

![Editing Calibrate Opacity in Blazor PDFViewer](../../pdfviewer/images/blazor-pdfviewer-calibrate-opacity.png)

### Editing the line properties

The properties of the line shapes such as distance and perimeter annotations can be edited using the Line properties window. It can be opened by selecting the Properties option in the context menu that appears on right-clicking the distance and perimeter annotations.

![Editing Calibrate Property in Blazor PDFViewer](../../pdfviewer/images/blazor-pdfviewer-calibrate-property.png)

## Setting default properties during control initialization

The properties of the shape annotations can be set before creating the control using distanceSettings, perimeterSettings, areaSettings, radiusSettings and volumeSettings.

```cshtml
@using Syncfusion.Blazor
@using Syncfusion.Blazor.PdfViewerServer
<SfPdfViewerServer @ref="@viewer" DocumentPath="@DocumentPath" DistanceSettings="@DistanceSettings" PerimeterSettings="@PerimeterSettings" AreaSettings="@AreaSettings" RadiusSettings="@RadiusSettings" VolumeSettings="@VolumeSettings">
</SfPdfViewerServer>
@code{
    SfPdfViewerServer viewer;
    private string DocumentPath { get; set; } = "wwwroot/Data/PDF_Succinctly.pdf";
    PdfViewerDistanceSettings DistanceSettings = new PdfViewerDistanceSettings { FillColor="blue", Opacity = 0.6 ,StrokeColor="green",LineHeadEndStyle=LineHeadStyle.Closed,LineHeadStartStyle=LineHeadStyle.Round};
    PdfViewerPerimeterSettings PerimeterSettings = new PdfViewerPerimeterSettings { FillColor="green", Opacity = 0.6 ,StrokeColor="blue"};
    PdfViewerAreaSettings AreaSettings = new PdfViewerAreaSettings { FillColor="yellow", Opacity = 0.6 ,StrokeColor="orange" };
    PdfViewerVolumeSettings VolumeSettings = new PdfViewerVolumeSettings { FillColor = "orange", Opacity = 0.6, StrokeColor = "pink" };
    PdfViewerRadiusSettings RadiusSettings = new PdfViewerRadiusSettings {FillColor="pink", Opacity = 0.6 ,StrokeColor="yellow" };
}
```

## Editing scale ratio and unit of the measurement annotation

The scale ratio and unit of measurement can be modified using the scale ratio option provided in the context menu of the PDF Viewer control.

![Editing Calibrate Scale Ratio in Blazor PDFViewer](../../pdfviewer/images/blazor-pdfviewer-calibrate-scaleratio.png)

The Units of measurements support for the measurement annotations in the PDF Viewer are

* Inch
* Millimeter
* Centimeter
* Point
* Pica
* Feet

![Calibrate Scale Dialog in Blazor PDFViewer](../../pdfviewer/images/blazor-pdfviewer-calibrate-scale-dialog.png)

## Setting default scale ratio settings during control initialization

The properties of scale ratio for measurement annotation can be set before creating the control using ScaleRatioSettings as shown in the following code snippet,

```cshtml
@using Syncfusion.Blazor
@using Syncfusion.Blazor.PdfViewerServer
<SfPdfViewerServer @ref="@viewer" DocumentPath="@DocumentPath" MeasurementSettings="@MeasurementSettings" >
</SfPdfViewerServer>
@code{
    SfPdfViewerServer viewer;
    private string DocumentPath { get; set; } = "wwwroot/Data/PDF_Succinctly.pdf";
    PdfViewerMeasurementSettings MeasurementSettings = new PdfViewerMeasurementSettings { ScaleRatio=2,ConversionUnit=CalibrationUnit.Cm};
}
```

N> You can refer to the [Blazor PDF Viewer](https://www.syncfusion.com/blazor-components/blazor-pdf-viewer) feature tour page for its groundbreaking feature representations. You can also explore the [Blazor PDF Viewer example](https://blazor.syncfusion.com/demos/pdf-viewer/default-functionalities?theme=bootstrap4) to understand how to explain core features of PDF Viewer.