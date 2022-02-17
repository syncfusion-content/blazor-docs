---
layout: post
title: Read only by default in Blazor DocumentEditor Component | Syncfusion
description: Learn how to open a document in read only mode by default in Syncfusion Blazor DocumentEditor component and much more.
platform: Blazor
control: DocumentEditor
documentation: ug
---

# How to Open document in read only in Blazor DocumentEditor component

In this article, we are going to see how to open a document in read only mode by default [`Blazor Word Processor`](https://www.syncfusion.com/blazor-components/blazor-word-processor) component (a.k.a Document Editor) component.

The following code example illustrate how to open a document in read only mode.

```csharp

@using Syncfusion.Blazor.DocumentEditor
@using System.IO
@using System.Net
@using Newtonsoft.Json



    <SfDocumentEditorContainer @ref="container" EnableToolbar=true Height="590px">
        <DocumentEditorContainerEvents Created="OnLoad" DocumentChanged="OnDocumentChanged"></DocumentEditorContainerEvents>
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
        sfdtString = JsonConvert.SerializeObject(document);
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
    public void OnDocumentChanged()
    {
        //Enable read only mode inside `documentChange` event.
        container.RestrictEditing = true;
    }

}

```
>Note: You can use the [`RestrictEditing`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DocumentEditor.SfDocumentEditorContainer.html#Syncfusion_Blazor_DocumentEditor_SfDocumentEditorContainer_RestrictEditing) in DocumentEditorContainer and [`IsReadOnly`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DocumentEditor.SfDocumentEditor.html#Syncfusion_Blazor_DocumentEditor_SfDocumentEditor_IsReadOnly) in DocumentEditor based on your requirement to change component to read only mode.