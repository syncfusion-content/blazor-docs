---
layout: post
title: View the created PDF document | Syncfusion
description: Learn here all about View the created PDF document in Syncfusion Blazor PDF Viewer component and more.
platform: Blazor
control: PDF Viewer
documentation: ug
---

# View the created PDF document

The Syncfusion's Blazor PDF Viewer component allows you to view the created PDF document using the [**Created**](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PdfViewer.PdfViewerEvents.html#Syncfusion_Blazor_PdfViewer_PdfViewerEvents_Created) event.

The following code example shows how to view the created PDF document.

```csharp

<SfPdfViewerServer ID="pdfviewer" @ref="@PdfViewer" DocumentPath="@documentPath">
    <PdfViewerEvents Created="created"></PdfViewerEvents>
</SfPdfViewerServer>

@code{

    public SfPdfViewerServer PdfViewer { get; set; }
    public string documentPath { get; set; }
    private void created()
    {
        var document = new PdfDocument();
        byte[] bytes;
        //Add a new page to the PDF document.
        PdfPage page = document.Pages.Add();
        //Create a textbox field and add the properties.
        PdfTextBoxField textBoxField = new PdfTextBoxField(page, "FirstName");
        textBoxField.Bounds = new RectangleF(0, 0, 100, 20);
        textBoxField.ToolTip = "First Name";
        //Add the form field to the document.
        document.Form.Fields.Add(textBoxField);
        //stream.Position = 0;

        var stream = new MemoryStream();

        //Save the document.
        document.Save(stream);
        bytes = stream.ToArray();
        string base64string = Convert.ToBase64String(bytes);
        documentPath = "data:application/pdf;base64," + base64string;
        //close the document
        document.Close(true);
    }
}

```

Find the sample [How to view the created PDF document](https://www.syncfusion.com/downloads/support/directtrac/general/ze/BlazorServerApp-view_PDF_document-1060268841)
