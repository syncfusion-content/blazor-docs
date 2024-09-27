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

## Export and import annotations programatically

The PDF Viewer control provides the support to export and import annotations programatically in the following formats using the methods `ImportAnnotationAsync`, `ExportAnnotationAsync`, `ExportAnnotationsAsObjectAsync`.

* XFDF
* JSON

### Export and import as JSON

#### Export as JSON 

Using the `ExportAnnotationAsync` method, the annotation data can be exported in the specified data format. 

The following code explains how to export the annotation data as JSON.

```cshtml

@using Syncfusion.Blazor.SfPdfViewer
@using Syncfusion.Blazor.Buttons

@* Button to import annotations*@
<SfButton OnClick="@OnExportAnnotationsClick">Export Annotation as JSON</SfButton>

<SfPdfViewer2 Width="100%" Height="100%" DocumentPath="@DocumentPath" @ref="@Viewer" />
@code {
    SfPdfViewer2 Viewer;
    public string DocumentPath { get; set; } = "wwwroot/data/PDF_Succinctly.pdf";

    // Event handler for export annotations button click
    public async void OnExportAnnotationsClick(MouseEventArgs args)
    {
        await Viewer.ExportAnnotationAsync(AnnotationDataFormat.Json);
    }
}

```

[View sample in GitHub](https://github.com/SyncfusionExamples/blazor-pdf-viewer-examples/tree/master/Annotations/Import-Export/Annotations%20as%20JSON%20stream%20and%20file%20-%20SfPdfViewer).

#### Import as JSON 

Using the `ImportAnnotationAsync` method, the annotation data can be imported in the specified data format. 

The following code explains how to import the annotation data as JSON.

```cshtml


@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.SfPdfViewer

@* Button to import annotations*@
<SfButton OnClick="@OnImportAnnotationsClick">Import Annotation as JSON</SfButton>

<SfPdfViewer2 Width="100%" Height="100%" DocumentPath="@DocumentPath" @ref="@Viewer" />

@code {

    SfPdfViewer2 Viewer;
    public string DocumentPath { get; set; } = "wwwroot/Data/PDF_Succinctly.pdf";

    // Event handler for import annotations button click
    public async void OnImportAnnotationsClick(MouseEventArgs args)
    {
        await Viewer.ImportAnnotationAsync("wwwroot/Data/PDF_Succinctly.json");

    }
}

```

### Export and import as XFDF

#### Export as XFDF 

Using the `ExportAnnotationAsync` method, the annotation data can be exported in the specified data format. 

The following code explains how to export the annotation data as XFDF.

```cshtml

@using Syncfusion.Blazor.SfPdfViewer
@using Syncfusion.Blazor.Buttons

<SfButton OnClick="@OnExportAnnotationsClick">Export Annotation as XFDF</SfButton>

<SfPdfViewer2 Width="100%" Height="100%" DocumentPath="@DocumentPath" @ref="@Viewer" />

@code {
    SfPdfViewer2 Viewer;

    public string DocumentPath { get; set; } = "wwwroot/Data/PDF_Succinctly.pdf";

    // Event handler for export annotations button click
    public async void OnExportAnnotationsClick(MouseEventArgs args)
    {
        await Viewer.ExportAnnotationAsync(AnnotationDataFormat.Xfdf);
    }
}

```

#### Import as XFDF 

Using the `ImportAnnotationAsync` method, the annotation data can be imported in the specified data format. 

The following code explains how to import the annotation data as XFDF.

```cshtml

@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.SfPdfViewer

@* Button to import annotations*@
<SfButton OnClick="@OnImportAnnotationsClick">Import Annotation as XFDF</SfButton>

<SfPdfViewer2 Width="100%" Height="100%" DocumentPath="@DocumentPath" @ref="@Viewer" />

@code {

    SfPdfViewer2 Viewer;
    public string DocumentPath { get; set; } = "wwwroot/Data/PDF_Succinctly.pdf";

    // Event handler for import annotations button click
    public async void OnImportAnnotationsClick(MouseEventArgs args)
    {
        await Viewer.ImportAnnotationAsync("wwwroot/Data/PDF_Succinctly.Xfdf");

    }
}

```

### Export and import as Object

The SfPdfViewer control supports exporting the annotation data as an object, and the exported data will be imported into the current PDF document from the object. Using the `ExportAnnotationAsync` method, the annotation data can be exported in the specified data format. 

The following code shows how to export the annotation data as an object and import the annotation data from that object into the current PDF document via a button click.

```cshtml

@using Syncfusion.Blazor.SfPdfViewer
@using Syncfusion.Blazor.Buttons

<SfButton OnClick="@ExportasObject">Export as Object</SfButton>

<SfButton OnClick="@ImportasObject">Import as Object</SfButton>

<SfPdfViewer2 Width="100%" Height="100%" DocumentPath="@DocumentPath" @ref="@Viewer" />

@code {
    SfPdfViewer2 Viewer;
    public object ExportObject;

    public string DocumentPath { get; set; } = "wwwroot/Data/PDF_Succinctly.pdf";

    // Event handler for export annotations button click
    public async void ExportasObject(MouseEventArgs args)
    {
        ExportObject = await Viewer.ExportAnnotationsAsObjectAsync();
    }

    // Event handler for import annotations button click
    public async void ImportasObject(MouseEventArgs args)
    {
        await Viewer.ImportAnnotationAsync(ExportObject);
    }
}

```

### Import as base64 string

The following code snippet explains how the import annotation in SfPdfViewer as base64 string. 

```cshtml

@using Syncfusion.Blazor.SfPdfViewer
@using Syncfusion.Blazor.Buttons

<SfButton OnClick="@ImportasBase64">Import as Base 64</SfButton>

<SfPdfViewer2 Width="100%" Height="100%" DocumentPath="@DocumentPath" @ref="@Viewer" />

@code {
    SfPdfViewer2 Viewer;

    public string DocumentPath { get; set; } = "wwwroot/Data/PDF_Succinctly.pdf";

    // Event handler for import annotations button click
    public async void ImportasBase64(MouseEventArgs args)
    {
        Stream stream = await GetDocumentAsStream("wwwroot/Data/PDF_Succinctly.json");
        MemoryStream memoryStream = new MemoryStream();
        await stream.CopyToAsync(memoryStream);
        memoryStream.Position = 0;
        string base64 = Convert.ToBase64String(memoryStream.ToArray());
        await Viewer.ImportAnnotationAsync(base64);
    }

    private async Task<Stream> GetDocumentAsStream(string documentPath)
    {
        Stream stream = new MemoryStream();
        try
        {
            string newDocumentPath = documentPath;
            if (System.IO.File.Exists("wwwroot/" + documentPath))
            {
                FileStream fileStream = new FileStream("wwwroot/" + documentPath, FileMode.Open, FileAccess.Read);
                MemoryStream memoryStream = new MemoryStream();
                await fileStream.CopyToAsync(memoryStream);
                memoryStream.Position = 0;
                stream = memoryStream;
                return stream;
            }
            return stream;
        }
        catch
        {
            return stream;
        }
    }
}

```

## See also

* [How to import annotations as objects](../how-to/import-annotations-as-objects)