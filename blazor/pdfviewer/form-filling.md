---
layout: post
title: Form filling in Blazor PDF Viewer Component | Syncfusion
description: Checkout and learn here all about form filling in Syncfusion Blazor PDF Viewer component and much more.
platform: Blazor
control: PDF Viewer
documentation: ug
---

# Form filling in Blazor PDF Viewer Component

PDF Viewer component allows to display the form fields available in the PDF document. By using this, you can edit and download the form fields.

The form fields displayed in the PDF Viewer are:

* Text box
* Password box
* Combo box
* Check box
* Radio Button
* Signature Field
* List box

![Form Filling in Blazor PDFViewer](../pdfviewer/images/blazor-pdfviewer-form-filling.png)

## Disabling form fields

The PDF Viewer control provides an option to disable the form fields feature. The code snippet for disabling the feature is as follows.

```cshtml
@using Syncfusion.Blazor.PdfViewerServer

<SfPdfViewerServer Width="1060px" Height="500px" EnableFormFields=false />
@code{
    public string DocumentPath { get; set; } = "wwwroot/data/PDF_Succinctly.pdf";
}
```

## How to draw handwritten signature in the signature field

Signature can be added to the Signature field by using the following steps:

* Click the Signature Field in the PDF document. The signature panel will appear.

![Signature Field in Blazor PDFViewer](../pdfviewer/images/blazor-pdfviewer-signature-field.png)

* Draw the signature in the signature panel.

![Displaying Signature Panel in Blazor PDFViewer](../pdfviewer/images/blazor-pdfviewer-signature-panel.png)

* Click the **CREATE** button, the drawn signature will be added in the signature field.

![Displaying Signature in Blazor PDFViewer](../pdfviewer/images/blazor-pdfviewer-signature.png)

## Delete the signature inside the signature field

You can also delete the signature in the signature field by using Delete Option in the annotation toolbar.

![Deleting Signature in Blazor PDFViewer](../pdfviewer/images/blazor-pdfviewer-delete-signature.png)

## Import and export FormFields

The PDF Viewer control provides the support to export and import the form field data in the following formats using the methods `ImportFormFieldsAsync` and `ExportFormFieldsAsync`.

* JSON
* XFDF
* FDF
* XML 

### Importing FormFields using PDF Viewer API

```cshtml
@using Syncfusion.Blazor.PdfViewerServer
@using Syncfusion.Blazor.Buttons

<SfButton OnClick="@OnImportFormFieldsClick">Import FormFields</SfButton>
<SfPdfViewerServer @ref=Viewer Width="1060px" Height="500px" DocumentPath="@DocumentPath" />
@code
{
    SfPdfViewerServer Viewer;
    public string DocumentPath { get; set; } = "wwwroot/data/FormFillingDocument.pdf";
    public void OnImportFormFieldsClick(MouseEventArgs args)
    {
        //The json file has been placed inside the data folder.
        Viewer.ImportFormFields("wwwroot/data/ImportedFormFields.json"); 
    }
}
```

>The JSON file for importing the form fields should be placed in the desired location and the path should be provided correctly.

### Exporting FormFields from the PDF document using PDF Viewer API

```cshtml
@using Syncfusion.Blazor.PdfViewerServer
@using Syncfusion.Blazor.Buttons

<SfButton OnClick="@OnExportFormFieldsClick">Export FormFields</SfButton>
<SfPdfViewerServer Width="1060px" Height="500px" DocumentPath="@DocumentPath" @ref="@Viewer" />
@code{
    SfPdfViewerServer Viewer;
    public string DocumentPath { get; set; } = "wwwroot/data/PDF_Succinctly.pdf";
    public void OnExportFormFieldsClick(MouseEventArgs args)
    {
        Viewer.ExportFormFields();
    }
}
```

### Export and Import as XML

The following code shows how to export the form fields as XML data stream and import that data from the stream into the current PDF document via button click.

```cshtml
<SfButton OnClick="@ExportAsStream">Export XML</SfButton>
<SfButton OnClick="@ImportFromStream">Import XML</SfButton>
<SfPdfViewerServer @ref=Viewer DocumentPath="@DocumentPath" />

@code 
{
    SfPdfViewerServer Viewer;
    public string DocumentPath { get; set; } = "wwwroot/data/FormDesigner.pdf";
    Stream stream;

    // Event triggers while clicking the Export XML button.
    public async void ExportAsStream()
    {
        // Export the form fields data as stream.
        stream = await Viewer.ExportFormFieldsAsync(FormFieldDataFormat.Xml);
    }

    // Event triggers while clicking the Import XML button.
    public async void ImportFromStream()
    {
        // Import the form fields data from the stream into the current PDF document.
        await Viewer.ImportFormFieldsAsync(stream, FormFieldDataFormat.Xml);
    }
}

```

### Export and Import as FDF

The following code shows how to export the form fields as FDF data stream and import that data from the stream into the current PDF document via button click.

```cshtml
<SfButton OnClick="@ExportAsStream">Export FDF</SfButton>
<SfButton OnClick="@ImportFromStream">Import FDF</SfButton>
<SfPdfViewerServer @ref=Viewer DocumentPath="@DocumentPath" />

@code 
{
    SfPdfViewerServer Viewer;
    public string DocumentPath { get; set; } = "wwwroot/data/FormDesigner.pdf";
    Stream stream;

    // Event triggers while clicking the Export FDF button.
    public async void ExportAsStream()
    {
        // Export the form fields data as stream.
        stream = await Viewer.ExportFormFieldsAsync(FormFieldDataFormat.Fdf);
    }

    // Event triggers while clicking the Import FDF button.
    public async void ImportFromStream()
    {
        // Import the form fields data from the stream into the current PDF document.
        await Viewer.ImportFormFieldsAsync(stream, FormFieldDataFormat.Fdf);
    }
}

```

###  Export and Import as XFDF

The following code shows how to export the form fields as XFDF data stream and import that data from the stream into the current PDF document via button click.

```cshtml
<SfButton OnClick="@ExportAsStream">Export XFDF</SfButton>
<SfButton OnClick="@ImportFromStream">Import XFDF</SfButton>
<SfPdfViewerServer @ref=Viewer DocumentPath="@DocumentPath" />

@code 
{
    SfPdfViewerServer Viewer;
    public string DocumentPath { get; set; } = "wwwroot/data/FormDesigner.pdf";
    Stream stream;

    // Event triggers while clicking the Export XFDF button.
    public async void ExportAsStream()
    {
        // Export the form fields data as stream.
        stream = await Viewer.ExportFormFieldsAsync(FormFieldDataFormat.Xfdf);
    }

    // Event triggers while clicking the Import XFDF button.
    public async void ImportFromStream()
    {
        // Import the form fields data from the stream into the current PDF document.
        await Viewer.ImportFormFieldsAsync(stream, FormFieldDataFormat.Xfdf);
    }
}

```

### Export and Import as JSON

The following code shows how to export the form fields as JSON data stream and import that data from the stream into the current PDF document via button click.

```cshtml
<SfButton OnClick="@ExportAsStream">Export JSON</SfButton>
<SfButton OnClick="@ImportFromStream">Import JSON</SfButton>
<SfPdfViewerServer @ref=Viewer DocumentPath="@DocumentPath" />

@code 
{
    SfPdfViewerServer Viewer;
    public string DocumentPath { get; set; } = "wwwroot/data/FormDesigner.pdf";
    Stream stream;

    // Event triggers while clicking the Export JSON button.
    public async void ExportAsStream()
    {
        // Export the form fields data as stream.
        stream = await Viewer.ExportFormFieldsAsync(FormFieldDataFormat.Json);
    }

    // Event triggers while clicking the Import JSON button.
    public async void ImportFromStream()
    {
        // Import the form fields data from the stream into the current PDF document.
        await Viewer.ImportFormFieldsAsync(stream, FormFieldDataFormat.Json);
    }
}

```

> N The form field data will be exported as stream and that data from the stream will be imported in to the current PDF document.

> You can refer to the [Blazor PDF Viewer](https://www.syncfusion.com/blazor-components/blazor-pdf-viewer) feature tour page for its groundbreaking feature representations. You can also explore the [Blazor PDF Viewer example](https://blazor.syncfusion.com/demos/pdf-viewer/default-functionalities?theme=bootstrap4) to understand how to explain core features of PDF Viewer.