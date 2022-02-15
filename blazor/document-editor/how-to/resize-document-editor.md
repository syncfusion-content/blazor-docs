---
layout: post
title: Resize in Blazor DocumentEditor Component | Syncfusion
description: Learn how to change the height and width of Syncfusion Blazor DocumentEditor component and much more.
platform: Blazor
control: DocumentEditor
documentation: ug
---

# How to change height and width of Blazor Document Editor component

In this article, we are going to see how to change height and width of Document editor.

## Change height of Document Editor

[`Blazor Word Processor`](https://www.syncfusion.com/blazor-components/blazor-word-processor) component (a.k.a Document Editor) component initially render with default height. You can change height of document editor using [`Height`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DocumentEditor.SfDocumentEditorContainer.html#Syncfusion_Blazor_DocumentEditor_SfDocumentEditorContainer_Height) property, the value which is in pixel.

The following example code illustrates how to change height of Document Editor.

```csharp

    <SfDocumentEditorContainer @ref="container" EnableToolbar=true Height="590px">
    </SfDocumentEditorContainer>

```

Similarly, you can use [`Height`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DocumentEditor.SfDocumentEditor.html#Syncfusion_Blazor_DocumentEditor_SfDocumentEditor_Height) property for Document Editor also.

## Change width of Document Editor

[`Blazor Word Processor`](https://www.syncfusion.com/blazor-components/blazor-word-processor) component (a.k.a Document Editor) initially render with default width. You can change width of document editor using [`Width`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DocumentEditor.SfDocumentEditorContainer.html#Syncfusion_Blazor_DocumentEditor_SfDocumentEditorContainer_Width) property, the value which is in percent.

The following example code illustrates how to change width of Document Editor.

```csharp
 <SfDocumentEditorContainer @ref="container" EnableToolbar=true Height="590px" Width="80%">
  </SfDocumentEditorContainer>
```

Similarly, you can use [`Width`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DocumentEditor.SfDocumentEditor.html#Syncfusion_Blazor_DocumentEditor_SfDocumentEditor_Width) property for Document Editor also.

## Resize Document Editor

Using [`ResizeAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DocumentEditor.SfDocumentEditorContainer.html#Syncfusion_Blazor_DocumentEditor_SfDocumentEditorContainer_ResizeAsync_System_Nullable_System_Double__System_Nullable_System_Double__) method, you change height and width of Document editor.