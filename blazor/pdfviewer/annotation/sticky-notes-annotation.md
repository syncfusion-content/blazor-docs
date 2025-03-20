---
layout: post
title: Sticky notes annotations in Blazor PDF Viewer Component | Syncfusion
description: Checkout and learn here all about sticky notes annotations in Syncfusion Blazor PDF Viewer component and more.
platform: Blazor
control: PDF Viewer
documentation: ug
---

N> Syncfusion recommends using [Blazor PDF Viewer (NextGen)](https://blazor.syncfusion.com/documentation/pdfviewer-2/getting-started/server-side-application) Component which provides fast rendering of pages and improved performance. Also, there is no need of external Web service for processing the files and ease out the deployment complexity. It can be used in Blazor Server, WASM and MAUI applications without any changes.

# Sticky notes annotations in Blazor PDF Viewer Component

The PDF Viewer control provides the options to add, edit, and delete the sticky note annotations in the PDF document.

![StickyNotes Annotation in Blazor PDFViewer](../../pdfviewer/images/blazor-pdfviewer-stickynotes-annotation.png)

## Adding a sticky note annotation to the PDF document

Sticky note annotations can be added to the PDF document using the annotation toolbar.

* Click the **Comments** button in the PDF Viewer toolbar. A toolbar appears below it.
* Click the position, where you want to add sticky note annotation in the PDF document.
* Sticky note annotation will be added in the clicked positions.

![Adding StickyNotes in Blazor PDFViewer Toolbar](../../pdfviewer/images/blazor-pdfviewer-add-stickynotes-in-toolbar.png)

Annotation comments can be added to the PDF document using the comment panel.

* Select a Sticky note annotation in the PDF document and right-click it.
* Select Comment option in the context menu that appears.
* Now, you can add Comments, Reply, and Status using Comment Panel.

![Blazor PDFViewer with StickyNotes Comment](../../pdfviewer/images/blazor-pdfviewer-stickynotes-comment.png)

## Editing the properties of the sticky note annotation

### Editing opacity

The opacity of the annotation can be edited using the range slider provided in the Edit Opacity tool.

![StickyNotes Opacity in Blazor PDFViewer](../../pdfviewer/images/blazor-pdfviewer-stickynotes-opacity.png)

### Editing comments

The comment, comment reply, and comment status of the annotation can be edited using the Comment Panel.

* Open the comment panel using the Comment Panel button displayed in the annotation toolbar.

![Editing StickyNotes Comment in Blazor PDFViewer](../../pdfviewer/images/blazor-pdfviewer-edit-sticknotes-comment.png)

You can modify or delete the comments or comments replay and it’s status using the menu option provided in the comment panel.

![StickyNotes Editing in Blazor PDFViewer](../../pdfviewer/images/blazor-pdfviewer-editing-stickynotes.png)

## Setting default properties during control initialization

The properties of the sticky note annotation can be set before creating the control using StickyNoteSettings.

After editing the default opacity using the Edit Opacity tool, they will be changed to the selected values.

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

The PDF Viewer control provides an option to disable the sticky note annotations feature.

```cshtml
@using Syncfusion.Blazor.PdfViewerServer
@using Syncfusion.Blazor.PdfViewer

<SfPdfViewerServer DocumentPath="@DocumentPath" EnableStickyNotesAnnotation=false>
</SfPdfViewerServer>

@code{
    private string DocumentPath { get; set; } = "wwwroot/Data/PDF_Succinctly.pdf";
}

```

N> You can refer to the [Blazor PDF Viewer](https://www.syncfusion.com/blazor-components/blazor-pdf-viewer) feature tour page for its groundbreaking feature representations. You can also explore the [Blazor PDF Viewer example](https://blazor.syncfusion.com/demos/pdf-viewer-2/default-functionalities?theme=bootstrap5) to understand how to explain core features of PDF Viewer.