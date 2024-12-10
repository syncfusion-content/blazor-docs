---
layout: post
title: Create PDF document in the SfPdfViewer created event | Syncfusion
description: Learn here all about how to create PDF document in the created event of Syncfusion Blazor SfPdfViewer component and more.
platform: Blazor
control: SfPdfViewer
documentation: ug
---

# Create PDF document in the created event of SfPdfViewer Component

You can create PDF document in the SfPdfViewer's `Created` event and load the same document in the viewer.

The following code example shows how to create PDF document and load that document in SfPdfViewer.

```cshtml
@using Syncfusion.Blazor.SfPdfViewer
@using Syncfusion.Pdf;
@using Syncfusion.Pdf.Interactive;
@using System.IO;
@using Syncfusion.Drawing;

<SfPdfViewer2 DocumentPath="@DocumentPath" Height="100%" Width="100%">
    <PdfViewerEvents Created="created"></PdfViewerEvents>
</SfPdfViewer2>


@code{

    public SfPdfViewer2 PdfViewer { get; set; }

    //Sets the PDF document path for initial loading.
    public string DocumentPath { get; set; }

    //This event triggers when the SfPdfViewer is created.
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
        DocumentPath = "data:application/pdf;base64," + base64string;
        //close the document
        document.Close(true);
    }
}
```

[View sample in GitHub](https://github.com/SyncfusionExamples/blazor-pdf-viewer-examples/tree/master/Common/Create%20PDF%20using%20base%20library).

## See also

* [Events in Blazor SfPdfViewer Component](../events)