---
layout: post
title: Stamp annotations in Blazor PDF Viewer Component | Syncfusion
description: Checkout and learn here all about Stamp annotations in Syncfusion Blazor PDF Viewer component and more.
platform: Blazor
control: PDF Viewer
documentation: ug
---

# Stamp annotations in Blazor PDF Viewer Component

The PDF Viewer control provides options to add, edit, delete and rotate the following stamp annotation in the PDF documents:

* Dynamic
* Sign Here
* Standard Business
* Custom Stamp

![StampAnnotation](../../pdfviewer/images/stamp_annot.png)

## Adding stamp annotations to the PDF document

The stamp annotations can be added to the PDF document using the annotation toolbar.

* Click the **Edit Annotation** button in the PDF Viewer toolbar. A toolbar appears below it.
* Click the **Stamp Annotation** dropdown button. A dropdown pop-up will appear and shows the stamp annotations to be added.

![StampTool](../../pdfviewer/images/stamp_tool.png)

* Select the annotation type to be added to the page in the pop-up.

![StampPopup](../../pdfviewer/images/selectstamp_annot.png)

* You can add the annotation over the pages of the PDF document.

In the pan mode, if the stamp annotation mode is entered, the PDF Viewer control will switch to text select mode.

## Adding custom stamp to the PDF document

* Click the **Edit Annotation** button in the PDF Viewer toolbar. A toolbar appears below it.
* Click the **Stamp Annotation** dropdown button. A dropdown pop-up will appear and shows the stamp annotations to be added.
* Click the Custom Stamp button.

![CustomStamp](../../pdfviewer/images/customstamp.png)

* The file explorer dialog will appear, choose the image and then add the image in the PDF page.

>The JPG and JPEG image format are only supported in custom stamp annotations.

## Setting default properties during control initialization

The properties of the stamp annotation can be set before creating the control using StampSettings.

After editing the default opacity using the Edit Opacity tool, they will be changed to the selected values.
Refer to the following code snippet to set the default sticky note annotation settings.

```cshtml
@using Syncfusion.Blazor
@using Syncfusion.Blazor.PdfViewerServer
<SfPdfViewerServer @ref="@viewer" DocumentPath="@DocumentPath" StampSettings="@StampSettings" >
</SfPdfViewerServer>
@code{
    SfPdfViewerServer viewer;
    private string DocumentPath { get; set; } = "wwwroot/Data/PDF_Succinctly.pdf";
    PdfViewerStampSettings StampSettings = new PdfViewerStampSettings {Opacity=0.3,Author="Blazor" };

}
```