---
layout: post
title: PDF Export in Blazor DocumentEditor Component | Syncfusion
description: Learn how to export the document as PDF in Syncfusion Blazor DocumentEditor component and much more.
platform: Blazor
control: DocumentEditor
documentation: ug
---

# How to export the document as PDF in Blazor Document Editor

In this article, we are going to see how to export the document as PDF format.

With the help of [`Syncfusion DocIO`](https://help.syncfusion.com/file-formats/docio/word-to-pdf), you can export the document as PDF.

The following way illustrates how to convert the document as PDF:

* Using [`SaveAsBlobAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DocumentEditor.SfDocumentEditor.html#Syncfusion_Blazor_DocumentEditor_SfDocumentEditor_SaveAsBlobAsync_System_Nullable_Syncfusion_Blazor_DocumentEditor_FormatType__) API, convert the document as Base64String, then convert to stream and send it to Syncfusion DocIO.
* Finally, convert the stream to PDF using [`Syncfusion.DocIORenderer.Net.Core`](https://www.nuget.org/packages/Syncfusion.DocIORenderer.Net.Core) library.

The following example code illustrates how to process the sfdt in server-side.

```c#
@using Syncfusion.Blazor.DocumentEditor
@using System.IO
@using System.Net
@using System.Text.Json
@using Syncfusion.DocIORenderer 

<button @onclick="ExportAsPdf">Export as Pdf</button>
<SfDocumentEditorContainer @ref="container" EnableToolbar=true Height="590px">
    <DocumentEditorContainerEvents Created="OnLoad"></DocumentEditorContainerEvents>
</SfDocumentEditorContainer>

@code {
        SfDocumentEditorContainer container;
        string sfdtString;

    protected override void OnInitialized()
    {
        string fileUrl = "https://www.syncfusion.com/downloads/support/directtrac/general/doc/Getting_Started1018066633.docx";
        WebClient webClient = new WebClient();
        byte[] byteArray = webClient.DownloadData(fileUrl);
        Stream stream = new MemoryStream(byteArray);
        //To observe the memory go down, null out the reference of byteArray variable.
        byteArray = null;
        WordDocument document = WordDocument.Load(stream, ImportFormatType.Docx);
        stream.Dispose();
        //To observe the memory go down, null out the reference of stream variable.
        stream = null;
        sfdtString = JsonSerializer.Serialize(document);
        document.Dispose();
        //To observe the memory go down, null out the reference of document variable.
        document = null;
    }
    public void OnLoad(object args)
    {
        SfDocumentEditor editor = container.DocumentEditor;
        editor.OpenAsync(sfdtString);
        //To observe the memory go down, null out the reference of sfdtString variable.
        sfdtString = null;
    }
    public async void ExportAsPdf()
    {
        SfDocumentEditor editor = container.DocumentEditor;
        string base64Data = await editor.SaveAsBlobAsync(FormatType.Docx);
        byte[] data = Convert.FromBase64String(base64Data);
        //To observe the memory go down, null out the reference of base64Data variable.
        base64Data = null;
        //Word document file stream
        Stream stream = new MemoryStream(data);
        //To observe the memory go down, null out the reference of data variable.
        data = null;
        Syncfusion.DocIO.DLS.WordDocument doc = new Syncfusion.DocIO.DLS.WordDocument(stream, Syncfusion.DocIO.FormatType.Docx);
        //Instantiation of DocIORenderer for Word to PDF conversion
        DocIORenderer render = new DocIORenderer();
        //Converts Word document into PDF document
        Syncfusion.Pdf.PdfDocument pdfDocument = render.ConvertToPDF(doc);
        using (var fileStream = new FileStream(@"wwwroot/data/GettingStarted.pdf", FileMode.OpenOrCreate, FileAccess.ReadWrite))
        {
            //Saves the PDF file
            pdfDocument.Save(fileStream);
            pdfDocument.Close();
            fileStream.Close();
            stream.Close();
        }
    }
}
```

Get the complete working sample in this [`link`](https://github.com/SyncfusionExamples/Export-document-as-PDF-in-Document-Editor/).