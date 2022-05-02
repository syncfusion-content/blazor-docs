---
layout: post
title: Insert Page number and Navigate to specific page in Blazor DocumentEditor | Syncfusion
description: Learn how to Insert Page number and Navigate to specific page from the Syncfusion Blazor Document Editor component and much more.
platform: Blazor
control: DocumentEditor
documentation: ug
---

# How to insert page number and navigate to specific page in Blazor Document Editor component

You can insert page number and navigate to specific page in Blazor Document Editor component by following ways.

## Insert page number

You can use [`InsertFieldAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DocumentEditor.EditorModule.html#Syncfusion_Blazor_DocumentEditor_EditorModule_InsertFieldAsync_System_String_System_String_) API in Editor module to insert the Page number in current position. By default, Page number will insert in Arabic number style.

>Note: Currently, Documenteditor have options to insert page number at current cursor position.

The following example code illustrates how to insert page number in header.

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
        // To move the selection to header
        container.DocumentEditor.Selection.GoToHeaderAsync();
        // Insert page number in the current cursor position
        container.DocumentEditor.Editor.InsertFieldAsync("PAGE \\* MERGEFORMAT", "1");
    }
}

```

## Get page count

You can use [`GetPageCountAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DocumentEditor.SfDocumentEditor.html#Syncfusion_Blazor_DocumentEditor_SfDocumentEditor_GetPageCountAsync) API to gets the total number of pages in Document.

The following example code illustrates how to get the number of pages in Document.

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
        // To get the total number of pages
        Task<int> pageCount = container.DocumentEditor.GetPageCountAsync();
    }
}
```

## Navigate to specific page

You can use [`GoToPageAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DocumentEditor.SelectionModule.html#Syncfusion_Blazor_DocumentEditor_SelectionModule_GoToPageAsync_System_Double_) API in Selection module to move selection to the start of the specified page number.

The following example code illustrates how to move selection to specific page.

```csharp
@using Syncfusion.Blazor.DocumentEditor

<SfDocumentEditorContainer @ref="container" EnableToolbar=true>
    <DocumentEditorContainerEvents Created="OnCreated"></DocumentEditorContainerEvents>
</SfDocumentEditorContainer>

@code {

    SfDocumentEditorContainer container;

    public async void OnCreated(object args)
    {
        // To move selection to page number 2
        container.DocumentEditor.Selection.GoToPageAsync(2);
    }
}
```