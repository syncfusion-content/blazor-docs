---
layout: post
title: Import and Export annotations in Blazor SfPdfViewer2 | Syncfusion
description: Learn here all about import and export annotations in Syncfusion Blazor SfPdfViewer2 component and more.
platform: Blazor
control: SfPdfViewer2
documentation: ug
---

# Import and Export annotations in Blazor SfPdfViewer2 Component

The SfPdfViewer2 control provides the support to import and export annotations using JSON object in the PDF document.

* Click the Add or Edit annotation button in the SfPdfViewer2 toolbar.

![Blazor PDFViewer with Edit Button](../../pdfviewer/images/blazor-pdfviewer-edit-button.png)

* The annotation toolbar will appear.

* Click the Comment Panel button in the annotation toolbar.

![Blazor PDFViewer with Comment Panel](../../pdfviewer/images/blazor-pdfviewer-edit-sticknotes-comment.png)

* The comments panel will be displayed.

* Click the **More Option** button in the comment panel container.

![Displaying More Option in Blazor PDFViewer](../../pdfviewer/images/blazor-pdfviewer-show-more-option.png)

## Importing annotation to the PDF document

* Click the Add or Edit annotation button in the SfPdfViewer2 toolbar.

* The annotation toolbar will appear.

* Click the Comment Panel button in the annotation toolbar.

* The comments panel will displayed.

* Click the **More Option** button in the comment panel container.

* Select the Import Annotations Option.

![Importing Annotation in Blazor PDFViewer](../../pdfviewer/images/blazor-pdfviewer-import-annotation.png)

* Then the file explorer dialog will be opened. Choose the JSON file to be imported into the loaded PDF document.

![Blazor PDFViewer with Imported Annotation](../../pdfviewer/images/blazor-pdfviewer-imported-annotation.png)

## Importing annotation using SfPdfViewer2 API

You can import annotations using JSON file or JSON object in code behind like the following code snippet.

```cshtml

```

N> [View sample in GitHub](https://github.com/SyncfusionExamples/blazor-pdf-viewer-examples/tree/master/Annotations/Import-Export/Annotations%20as%20JSON%20stream%20and%20file).

N>The JSON file for importing the annotation should be placed in the desired location and the path has to be provided correctly.

## Exporting annotation from the PDF document

The SfPdfViewer2 control provides the support to export the annotations as JSON file and JSON object using annotation toolbar.

* Click the Add or Edit annotation button in the SfPdfViewer2 toolbar.
* The annotation toolbar will appear.
* Click the Comment Panel button in the annotation toolbar.
* The comments panel will be displayed.
* Click the **More Option** button in the comment panel container.
* Select the Export Annotations Option.

![Exporting Annotation in Blazor PDFViewer](../../pdfviewer/images/blazor-pdfviewer-export-annotation.png)

N>Export annotations will be in the disabled state when the loaded PDF document does not contain any annotations.

## Exporting annotation using SfPdfViewer2 API

You can export annotations as JSON file in code behind like the following code snippet.

```cshtml

@using Syncfusion.Blazor.SfPdfViewer
@using Syncfusion.Blazor.Buttons

<SfButton OnClick="@OnExportAnnotationsClick">Export Annotation</SfButton>
<SfPdfViewer2 Width="100%" Height="100%" DocumentPath="@DocumentPath" @ref="@Viewer" />

@code {
    SfPdfViewer2 Viewer;

    public string DocumentPath { get; set; } = "wwwroot/data/PDF_Succinctly.pdf";

    public async void OnExportAnnotationsClick(MouseEventArgs args)
    {
        await Viewer.ExportAnnotationAsync();
    }
}

```
N> [View sample in GitHub]().