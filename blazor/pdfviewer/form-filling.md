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

The PDF Viewer control provides the support to import and export form fields using a JSON object in the PDF document.

## Importing FormFields using PDF Viewer API

```cshtml
@using Syncfusion.Blazor.PdfViewerServer
@using Syncfusion.Blazor.Buttons

<SfButton OnClick="@OnImportFormFieldsClick">Import FormFields</SfButton>
<SfPdfViewerServer @ref=Viewer Width="1060px" Height="500px" DocumentPath="@DocumentPath" />
@code{
        SfPdfViewerServer Viewer;
public string DocumentPath { get; set; } = "wwwroot/data/FormFillingDocument.pdf";
    public void OnImportFormFieldsClick(MouseEventArgs args)
    {
        Viewer.ImportFormFields("wwwroot/data/ImportedFormFields.json"); //The json file has been placed inside the data folder.
    }
}
```

>The JSON file for importing the form fields should be placed in the desired location and the path should be provided correctly.

## Exporting FormFields from the PDF document using PDF Viewer API

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

> You can refer to the [Blazor PDF Viewer](https://www.syncfusion.com/blazor-components/blazor-pdf-viewer) feature tour page for its groundbreaking feature representations. You can also explore the [Blazor PDF Viewer example](https://blazor.syncfusion.com/demos/pdf-viewer/default-functionalities?theme=bootstrap4) to understand how to explain core features of PDF Viewer.