---
layout: post
title: Insert text and rich-text in Blazor DocumentEditor | Syncfusion
description: Learn how to insert text, paragraph and rich-text content in Blazor Document Editor component and much more.
platform: Blazor
control: DocumentEditor
documentation: ug
---

# Insert text , paragraph and rich-text content in Blazor DocumentEditor

You can insert the text, paragraph and rich-text content in Blazor Document Editor component.

## Insert text in current cursor position

You can use [`InsertTextAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DocumentEditor.EditorModule.html#Syncfusion_Blazor_DocumentEditor_EditorModule_InsertTextAsync_System_String_) API in editor module to insert the text in current cursor position.

The following example code illustrates how to add the text in current selection.

```csharp
// It will insert the provided text in current selection
await container.DocumentEditor.Editor.InsertTextAsync("Syncfusion");

<button @onclick="InsertText">Insert Text</button>
<SfDocumentEditorContainer @ref="container" EnableToolbar="true"  Height="590px" >
</SfDocumentEditorContainer>
@code {
    SfDocumentEditorContainer container;

    // It will insert the provided text in current selection
    public async void InsertText()
    {
        await container.DocumentEditor.Editor.InsertTextAsync("Syncfusion");
    }
}
```

## Insert paragraph in current cursor position

To insert new paragraph at current selection, you can can use [`InsertTextAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DocumentEditor.EditorModule.html#Syncfusion_Blazor_DocumentEditor_EditorModule_InsertTextAsync_System_String_) API with parameter as `\r\n` or `\n`.

The following example code illustrates how to add the new paragraph in current selection.

```csharp
// It will add the new paragraph in current selection
await container.DocumentEditor.Editor.InsertTextAsync("\n");
```

## Insert the rich-text content

To insert the HTML content, you have to convert the HTML content to SFDT Format and then use [`PasteAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DocumentEditor.EditorModule.html#Syncfusion_Blazor_DocumentEditor_EditorModule_PasteAsync_System_String_System_Nullable_Syncfusion_Blazor_DocumentEditor_PasteOptions__) API to insert the sfdt at current cursor position.

N> HTML string should be well formatted HTML. [`DocIO`](https://help.syncfusion.com/file-formats/docio/html) support only well formatted XHTML.  

The following example illustrates how to insert the HTML content at current cursor position.

* Refer to the following example for Converting the HTML content to SFDT and then insert it in current position using Pasts API.

```csharp
@using Syncfusion.Blazor.DocumentEditor
@using System.Text.Json

<SfDocumentEditorContainer @ref="container" EnableToolbar=true>
    <DocumentEditorContainerEvents Created="OnCreated"></DocumentEditorContainerEvents>
</SfDocumentEditorContainer>

@code {
    SfDocumentEditorContainer container;

    public async void OnCreated(object args)
    {
        string htmltags = "<?xml version='1.0' encoding='utf - 8'?><!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Strict//EN''http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd'><html xmlns ='http://www.w3.org/1999/xhtml' xml:lang='en' lang ='en'><body><h1>The img element</h1><img src='https://www.w3schools.com/images/lamp.jpg' alt ='Lamp Image' width='500' height='600'/></body></html>";
        // You can also load HTML file/string .
        Syncfusion.Blazor.DocumentEditor.WordDocument document = Syncfusion.Blazor.DocumentEditor.WordDocument.LoadString(htmltags, ImportFormatType.Html); // Convert the HTML to SFDT format.
        string sfdtString = JsonSerializer.Serialize(document);
        document.Dispose();
        // Insert the sfdt content in cursor position using paste API
        await container.DocumentEditor.Editor.PasteAsync(sfdtString);
    }
}
```

N> The above example illustrates inserting HTML content. Similarly, you can insert any rich-text content by converting any of the supported file formats (DOCX, DOC, WordML, HTML, RTF) to SFDT.