---
layout: post
title: Disable drag and drop in Blazor DocumentEditor Component | Syncfusion
description: Checkout and learn here all about the Disable drag and drop in Syncfusion Blazor DocumentEditor component and more.
platform: Blazor
control: DocumentEditor
documentation: ug
---

# How to disable drag and drop in document editor in Blazor Document editor component

You can customize the drag and drop option (enable and disable) using allowDragAndDrop property in Document editor settings. 

The following example illustrates to customize the drag and drop option.

```csharp

@using Syncfusion.Blazor.DocumentEditor;

<SfDocumentEditorContainer @ref="container" EnableToolbar=true DocumentEditorSettings="settings"> 
</SfDocumentEditorContainer>

@code {
    SfDocumentEditorContainer container;
    // Disable optimized text measuring improvement
    DocumentEditorSettingsModel settings = new DocumentEditorSettingsModel() { allowDragAndDrop = false };
}

```

>Note: Default value of allowDragAndDrop property is `true` .

You can also explore our [Blazor Word Processor](https://blazor.syncfusion.com/demos/document-editor/default-functionalities) example to know how to render and configure the document editor.