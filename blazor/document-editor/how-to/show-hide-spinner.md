---
layout: post
title: Show and hide spinner in Blazor DocumentEditor Component | Syncfusion
description: Learn show and hide spinner while opening document in Syncfusion Blazor DocumentEditor component and much more.
platform: Blazor
control: DocumentEditor
documentation: ug
---

# How to show and hide spinner in Blazor Document Editor component

Using [`Spinner`](https://blazor.syncfusion.com/documentation/spinner/getting-started) component, you can show/hide spinner while opening document in [`Blazor Word Processor`](https://www.syncfusion.com/blazor-components/blazor-word-processor) component (a.k.a Document Editor) component.

Example code snippet to show/hide spinner

```csharp
<SfButton @onclick="@ClickHandler">Show/Hide Spinner</SfButton>

<SfSpinner @bind-Visible="@VisibleProperty">
</SfSpinner>

@code{
    private bool VisibleProperty { get; set; } = false;

    private async Task ClickHandler()
    {
        this.VisibleProperty = true;
        await Task.Delay(2000);
        this.VisibleProperty = false;
    }
}
```

Refer to the following example.

```csharp
@using Syncfusion.Blazor.DocumentEditor
@using System.Net
@using Syncfusion.Blazor.Spinner
<div>
    <SfDocumentEditorContainer @ref="container" EnableToolbar=true Height="590px">
        <DocumentEditorContainerEvents Created="OnLoad"></DocumentEditorContainerEvents>
    </SfDocumentEditorContainer>
    <SfSpinner @bind-Visible="@VisibleProperty">
    </SfSpinner>
</div>

@code {
    private bool VisibleProperty { get; set; } = false;
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
        sfdtString = System.Text.Json.JsonSerializer.Serialize(document);
        document.Dispose();
        //To observe the memory go down, null out the reference of document variable.
        document = null;
    }
    public async void OnLoad(object args)
    {
        SfDocumentEditor editor = container.DocumentEditor;
        // It will make the spinner visible
        this.VisibleProperty = true;
        await editor.OpenAsync(sfdtString);
        await Task.Delay(1000);
        // It will make the spinner hide
        this.VisibleProperty = false;
        //To observe the memory go down, null out the reference of sfdtString variable.
        sfdtString = null;

    }
}
```

N> In above example, we have used Delay to hide spinner, just for demo purpose.
