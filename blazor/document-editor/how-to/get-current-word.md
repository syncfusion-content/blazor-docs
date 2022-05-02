---
layout: post
title: Select and retrieve current word and Paragraph in Blazor DocumentEditor | Syncfusion
description: Learn how to select and retrieve current word and Paragraph in the Syncfusion Blazor Document Editor component and much more.
platform: Blazor
control: DocumentEditor
documentation: ug
---

# How to select and retrieve the word and paragraph in current cursor position in Blazor Document Editor component

You can get the current word or paragraph content from the Blazor Document Editor component as plain text and SFDT (rich text).

## Select and get the word in current cursor position

You can use [`SelectCurrentWordAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DocumentEditor.SelectionModule.html#Syncfusion_Blazor_DocumentEditor_SelectionModule_SelectCurrentWordAsync_System_Boolean_) API in selection module to select the current word at cursor position and use [`GetTextAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DocumentEditor.SelectionModule.html#Syncfusion_Blazor_DocumentEditor_SelectionModule_GetTextAsync) API to get the selected content as plain text from Blazor Document Editor component.

The following example code illustrates how to select and get the current word as plain text.

```csharp
@using Syncfusion.Blazor.DocumentEditor

<SfDocumentEditorContainer @ref="container" EnableToolbar=true>
    <DocumentEditorContainerEvents Created="OnCreated"></DocumentEditorContainerEvents>
</SfDocumentEditorContainer>

@code {

    SfDocumentEditorContainer container;

    public async void OnCreated(object args)
    {
        // To insert text in cursor position
        container.DocumentEditor.Editor.InsertTextAsync("Document editor");
        // To select the current word in document
        container.DocumentEditor.Selection.SelectCurrentWordAsync();
        // To get the selected content as text
        string selectedContent = await container.DocumentEditor.Selection.GetTextAsync();
    }
}
```

To get the bookmark content as SFDT (rich text), please check this [`link`](../../document-editor/how-to/get-the-selected-content/#get-the-selected-content-as-sfdt-rich-text)

## Select and get the paragraph in current cursor position

You can use [`SelectParagraphAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DocumentEditor.SelectionModule.html#Syncfusion_Blazor_DocumentEditor_SelectionModule_SelectParagraphAsync) API in selection module to select the current paragraph at cursor position and use [`GetTextAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DocumentEditor.SelectionModule.html#Syncfusion_Blazor_DocumentEditor_SelectionModule_GetTextAsync) API or [`GetSfdtAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DocumentEditor.SelectionModule.html#Syncfusion_Blazor_DocumentEditor_SelectionModule_GetSfdtAsync) API to get the selected content as plain text or SFDT from Blazor Document Editor component.

The following example code illustrates how to select and get the current paragraph as SFDT.

```csharp
@using Syncfusion.Blazor.DocumentEditor

<SfDocumentEditorContainer @ref="container" EnableToolbar=true>
    <DocumentEditorContainerEvents Created="OnCreated"></DocumentEditorContainerEvents>
</SfDocumentEditorContainer>

@code {

    SfDocumentEditorContainer container;

    public async void OnCreated(object args)
    {
        // To insert text in cursor position
        container.DocumentEditor.Editor.InsertTextAsync("Document editor");
        // To select the current paragraph in document
        container.DocumentEditor.Selection.SelectParagraphAsync();
        // To get the selected content as SFDT
        string selectedContent = await container.DocumentEditor.Selection.GetSfdtAsync();
    }
}
```