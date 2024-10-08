---
layout: post
title: Import and Export annotations in Blazor SfPdfViewer | Syncfusion
description: Learn here all about import and export annotations in Syncfusion Blazor SfPdfViewer component and more.
platform: Blazor
control: SfPdfViewer
documentation: ug
---

# Import and Export annotations in Blazor SfPdfViewer Component

The SfPdfViewer control provides the support to import and export annotations using JSON object in the PDF document.

* Click the Add or Edit annotation button in the SfPdfViewer toolbar.

![Blazor SfPdfViewer with Edit Button](../../pdfviewer/images/blazor-pdfviewer-edit-button.png)

* The annotation toolbar will appear.
* Click the Comment Panel button in the annotation toolbar.

![Blazor SfPdfViewer with Comment Panel](../../pdfviewer/images/blazor-pdfviewer-edit-sticknotes-comment.png)

* The comments panel will be displayed.
* Click the **More Option** button in the comment panel container.

![Displaying More Option in Blazor SfPdfViewer](../../pdfviewer/images/blazor-pdfviewer-show-more-option.png)

## Importing annotation to the PDF document

* Click the Add or Edit annotation button in the SfPdfViewer toolbar.
* The annotation toolbar will appear.
* Click the Comment Panel button in the annotation toolbar.
* The comments panel will displayed.
* Click the **More Option** button in the comment panel container.
* Select the Import Annotations Option.

![Importing Annotation in Blazor SfPdfViewer](../../pdfviewer/images/blazor-pdfviewer-import-annotation.png)

* Then the file explorer dialog will be opened. Choose the JSON file to be imported into the loaded PDF document.

![Blazor PDFViewer with Imported Annotation](../../pdfviewer/images/blazor-pdfviewer-imported-annotation.png)

## Importing annotation using SfPdfViewer API

You can import annotations using JSON file or JSON object in code behind like the following code snippet.

```cshtml

@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.SfPdfViewer

<SfButton OnClick="@OnImportAnnotationsClick">Import Annotation</SfButton>
<SfPdfViewer2 Width="100%" Height="100%" DocumentPath="@DocumentPath" @ref="@Viewer" />

@code {
    SfPdfViewer2 Viewer;
    public string DocumentPath { get; set; } = "wwwroot/Data/PDF_Succinctly.pdf";

    public async void OnImportAnnotationsClick(MouseEventArgs args)
    {
        //The json file has been placed inside the data folder.
        byte[] bytes = System.IO.File.ReadAllBytes("wwwroot/Data/PDF_Succinctly.json");
        await Viewer.ImportAnnotationAsync(new MemoryStream(bytes));
    }
}

```

[View sample in GitHub](https://github.com/SyncfusionExamples/blazor-pdf-viewer-examples/tree/master/Annotations/Import-Export/Annotations%20as%20JSON%20object).

N>The JSON file for importing the annotation should be placed in the desired location and the path has to be provided correctly.

## Exporting annotation from the PDF document

The SfPdfViewer control provides the support to export the annotations as JSON file and JSON object using annotation toolbar.

* Click the Add or Edit annotation button in the SfPdfViewer toolbar.
* The annotation toolbar will appear.
* Click the Comment Panel button in the annotation toolbar.
* The comments panel will be displayed.
* Click the **More Option** button in the comment panel container.
* Select the Export Annotations Option.

![Exporting Annotation in Blazor SfPdfViewer](../../pdfviewer/images/blazor-pdfviewer-export-annotation.png)

N>Export annotations will be in the disabled state when the loaded PDF document does not contain any annotations.

## Exporting annotation using SfPdfViewer API

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
[View sample in GitHub](https://github.com/SyncfusionExamples/blazor-pdf-viewer-examples/tree/master/Annotations/Import-Export/Annotations%20as%20JSON%20stream%20and%20file).

## See also

* [How to import annotations as objects](../how-to/import-annotations-as-objects)