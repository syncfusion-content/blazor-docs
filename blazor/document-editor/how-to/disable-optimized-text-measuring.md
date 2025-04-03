---
layout: post
title: Text measuring in Blazor DocumentEditor Component | Syncfusion
description: Learn how to disable optimized text measuring in Syncfusion Blazor DocumentEditor component and much more.
platform: Blazor
control: DocumentEditor
documentation: ug
---

# Disable optimized text measuring in Blazor DocumentEditor component

Starting from v19.3.0.x, the accuracy of text size measurements in Document editor is improved such as to match Microsoft Word pagination for most Word documents. This improvement is included as default behavior along with an optional API [`EnableOptimizedTextMeasuring`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DocumentEditor.DocumentEditorSettingsModel.html#Syncfusion_Blazor_DocumentEditor_DocumentEditorSettingsModel_EnableOptimizedTextMeasuring) in Document editor settings.  

If you want the [`Blazor Word Processor`](https://www.syncfusion.com/blazor-components/blazor-word-processor) component (a.k.a Document Editor) component to retain the document pagination (display page-by-page) behavior like v19.2.0.x and older versions. Then you can disable this optimized text measuring improvement, by setting `false` to [`EnableOptimizedTextMeasuring`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DocumentEditor.DocumentEditorSettingsModel.html#Syncfusion_Blazor_DocumentEditor_DocumentEditorSettingsModel_EnableOptimizedTextMeasuring) property of  Blazor Document Editor component.

## Disable optimized text measuring in DocumentEditorContainer instance

The following example code illustrates how to disable optimized text measuring improvement in [`DocumentEditorContainer`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DocumentEditor.SfDocumentEditorContainer.html) instance.

```csharp

@using Syncfusion.Blazor.DocumentEditor;

<SfDocumentEditorContainer @ref="container" EnableToolbar=true DocumentEditorSettings="settings"> 
</SfDocumentEditorContainer>

@code {
    SfDocumentEditorContainer container;
    // Disable optimized text measuring improvement
    DocumentEditorSettingsModel settings = new DocumentEditorSettingsModel() { EnableOptimizedTextMeasuring = true };
}
```

## Disable optimized text measuring in DocumentEditor instance

The following example code illustrates how to disable optimized text measuring improvement in [`DocumentEditor`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DocumentEditor.SfDocumentEditor.html) instance.

```csharp

@using Syncfusion.Blazor.DocumentEditor;

<SfDocumentEditor IsReadOnly="false" DocumentEditorSettings="settings">
</SfDocumentEditor>

@code {
    // Disable optimized text measuring improvement
    DocumentEditorSettingsModel settings = new DocumentEditorSettingsModel() { EnableOptimizedTextMeasuring = true };
}
```