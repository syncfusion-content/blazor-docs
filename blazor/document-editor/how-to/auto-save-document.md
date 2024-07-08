---
layout: post
title: Auto save document in Blazor DocumentEditor Component | Syncfusion
description: Learn here to add save button in Syncfusion Blazor DocumentEditor component and much more.
platform: Blazor
control: DocumentEditor
documentation: ug
---
# Auto save document in Blazor Document editor component

In this article, we are going to see how to autosave the document to server. You can automatically save the edited content in regular intervals of time. It helps reduce the risk of data loss by saving an open document automatically at customized intervals.

The following example illustrates how to auto save the document in server.

* In the client-side, using content change event, we can automatically save the edited content in regular intervals of time. Based on `contentChanged` boolean, the document send as Docx format to server-side using [`SaveAsBlobAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DocumentEditor.SfDocumentEditor.html#Syncfusion_Blazor_DocumentEditor_SfDocumentEditor_SaveAsBlobAsync_System_Nullable_Syncfusion_Blazor_DocumentEditor_FormatType__) method.

```cshtml
@using Syncfusion.Blazor.DocumentEditor
@using System.IO
@using System.Timers

<SfDocumentEditorContainer @ref="container" EnableToolbar="true">
<DocumentEditorContainerEvents ContentChanged="OnContentChange"></DocumentEditorContainerEvents>
</SfDocumentEditorContainer>

@code {
    SfDocumentEditorContainer container;
    private Timer autoSaveTimer;
    private bool isDocumentChanged = false;

    protected override void OnInitialized()
    {
        // Set up the timer to trigger the callback every 1 second (1000 milliseconds)
        autoSaveTimer = new Timer(AutoSaveDocument, null, 1000, 1000);
    }

    private void OnContentChange()
    {
        isDocumentChanged = true; // Mark the document as changed
    }

    private async void AutoSaveDocument(object state)
    {
        if (isDocumentChanged)
        {
            await OnSave();
            isDocumentChanged = false; // Reset the flag after saving
        }
    }

    public async Task OnSave()
    {
        SfDocumentEditor editor = container.DocumentEditor;
        string base64Data = await editor.SaveAsBlobAsync(FormatType.Docx);
        byte[] data = Convert.FromBase64String(base64Data);
        // To observe the memory go down, null out the reference of base64Data variable.
        base64Data = null;
        // Word document file stream
        Stream stream = new MemoryStream(data);
        // To observe the memory go down, null out the reference of data variable.
        data = null;
        using (var fileStream = new FileStream(@"wwwroot/data/GettingStarted.docx", FileMode.Create, FileAccess.Write))
        {
            // Saving the new file in root path of application
            await stream.CopyToAsync(fileStream);
        }
        stream.Close();
        // To observe the memory go down, null out the reference of stream variable.
        stream = null;
    }

    public void Dispose()
    {
        autoSaveTimer?.Dispose(); // Dispose of the timer when the component is disposed
    }
}
```
