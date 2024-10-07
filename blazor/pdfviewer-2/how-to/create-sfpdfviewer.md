---
layout: post
title: View the created PDF document | Syncfusion
description: Learn here all about View the created PDF document in Syncfusion Blazor SfPdfviewer component and more.
platform: Blazor
control: SfPdfviewer
documentation: ug
---

# View the created PDF document

The Syncfusion's Blazor SfPdfviewer component allows you to view the created PDF document using the [**Created**](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SfPdfViewer.PdfViewerEvents.html#Syncfusion_Blazor_SfPdfViewer_PdfViewerEvents_Created) event.

The following code example shows how to view the created PDF document.

```cshtml

<SfPdfViewer2 ID="pdfviewer" 
              @ref="@PdfViewer" 
              DocumentPath="@documentPath"
              Height="100%"
              Width="100%">
    <PdfViewerEvents Created="created"></PdfViewerEvents>
</SfPdfViewer2>

@code{

    public SfPdfViewer2 PdfViewer { get; set; }
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

[View sample in GitHub](https://github.com/SyncfusionExamples/blazor-pdf-viewer-examples/tree/master/Common/Create%20PDF%20using%20base%20library)

## See also

* [How to create SfPdfViewer Component in a Splitter Component](./create-sfpdfviewer-in-a-splitter-component)

* [How to create a SfPdfViewer within a popup window in Blazor](./create-sfpdfviewer-in-a-popup-window)

* [How to get PDF document's data](./get-data-from-sfpdfviewer)