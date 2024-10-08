---
layout: post
title: Create PDF document in the PDF Viewer created event | Syncfusion
description: Learn here all about how to create PDF document in the created event of Syncfusion Blazor PDF Viewer component and more.
platform: Blazor
control: PDF Viewer
documentation: ug
---

# Create PDF document in created event of Blazor PDF Viewer Component

You can create PDF document in the PDFViewer's created event and load the same document in the viewer.

The following code example shows how to create PDF document and load that document in PDFViewer.

```cshtml
@using Syncfusion.Blazor.PdfViewer
@using Syncfusion.Blazor.PdfViewerServer
@using Syncfusion.Pdf;
@using Syncfusion.Pdf.Interactive;
@using System.IO;
@using Syncfusion.Drawing;

<SfPdfViewerServer @ref="@PdfViewer" DocumentPath="@documentPath">
    <PdfViewerEvents Created="created"></PdfViewerEvents>
</SfPdfViewerServer>

@code{

    public SfPdfViewerServer PdfViewer { get; set; }

    //Sets the PDF document path for initial loading.
    public string documentPath { get; set; }

    //This event triggers when the PDFViewer is created.
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
        var stream = new MemoryStream();
        //Save the document.
        document.Save(stream);
        bytes = stream.ToArray();
        string base64string = Convert.ToBase64String(bytes);
        //Sets the document path as base64 string.
        documentPath = "data:application/pdf;base64," + base64string;
        //close the document
        document.Close(true);
    }
}
```

N> [View sample in GitHub](https://github.com/SyncfusionExamples/blazor-pdf-viewer-classic-examples/tree/master/Common/Create%20PDF%20using%20base%20library).
