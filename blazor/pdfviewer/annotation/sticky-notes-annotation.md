---
layout: post
title: Sticky notes annotations in Blazor PDF Viewer Component | Syncfusion
description: Checkout and learn here all about Sticky notes annotations in Syncfusion Blazor PDF Viewer component and more.
platform: Blazor
control: PDF Viewer
documentation: ug
---

# Sticky notes annotations in Blazor PDF Viewer Component

The PDF Viewer control provides the options to add, edit, and delete the sticky note annotations in the PDF document.

![StickyNotesAnnotation](../../pdfviewer/images/stickynotes_annotation.png)

## Adding a sticky note annotation to the PDF document

Sticky note annotations can be added to the PDF document using the annotation toolbar.

* Click the **Comments** button in the PDF Viewer toolbar. A toolbar appears below it.
* Click the position, where you want to add sticky note annotation in the PDF document.
* Sticky note annotation will be added in the clicked positions.

![StickyNotesTool](../../pdfviewer/images/stickynotes_tool.png)

Annotation comments can be added to the PDF document using the comment panel.

* Select a Sticky note annotation in the PDF document and right-click it.
* Select Comment option in the context menu that appears.
* Now, you can add Comments, Reply, and Status using Comment Panel.
* Now, you can add Comments, Reply, and Status using Comment Panel

![StickyNotesComment](../../pdfviewer/images/stickynotes_comment.png)

## Editing the properties of the sticky note annotation

### Editing opacity

The opacity of the annotation can be edited using the range slider provided in the Edit Opacity tool.

![StickyNotesOpacity](../../pdfviewer/images/sticky_opacity.png)

### Editing comments

The comment, comment reply, and comment status of the annotation can be edited using the Comment Panel.

* Open the comment panel using the Comment Panel button showing in the annotation toolbar.

![StickyNotesComment](../../pdfviewer/images/commentPanel.png)

You can modify or delete the comments or comments replay and it’s status using the menu option provided in the comment panel.

![StickyNotesEdit](../../pdfviewer/images/sticky_editbtn.png)

## Setting default properties during control initialization

The properties of the sticky note annotation can be set before creating the control using StickyNoteSettings.

After editing the default opacity using the Edit Opacity tool, they will be changed to the selected values. Refer to the following code snippet to set the default sticky note annotation settings.

```cshtml
@using Syncfusion.Blazor
@using Syncfusion.Blazor.PdfViewerServer

<SfPdfViewerServer @ref="@viewer" DocumentPath="@DocumentPath" StickyNotesSettings="@StickyNotesSettings" >
</SfPdfViewerServer>

@code{
    SfPdfViewerServer viewer;
    private string DocumentPath { get; set; } = "wwwroot/Data/PDF_Succinctly.pdf";
    PdfViewerStickyNotesSettings StickyNotesSettings = new PdfViewerStickyNotesSettings {Author="Syncfusion"};
}

```

## Disabling sticky note annotations

The PDF Viewer control provides an option to disable the sticky note annotations feature. The code snippet for disabling the feature is as follows.

```cshtml
@using Syncfusion.Blazor.PdfViewerServer
@using Syncfusion.Blazor.PdfViewer

<SfPdfViewerServer DocumentPath="@DocumentPath" EnableStickyNotesAnnotation=false>
</SfPdfViewerServer>

@code{
    private string DocumentPath { get; set; } = "wwwroot/Data/PDF_Succinctly.pdf";
}

```

> You can refer to our [Blazor PDF Viewer](https://www.syncfusion.com/blazor-components/blazor-pdf-viewer) feature tour page for its groundbreaking feature representations. You can also explore our [Blazor PDF Viewer example](https://blazor.syncfusion.com/demos/pdf-viewer/default-functionalities?theme=bootstrap4) to understand how to explains core features of PDF Viewer.