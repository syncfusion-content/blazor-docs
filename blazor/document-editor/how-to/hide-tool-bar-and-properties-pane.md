---
layout: post
title: Hide the default tool bar and properties pane in Blazor DocumentEditor | Syncfusion
description: Learn how to hide the default tool bar properties pane in the Syncfusion Blazor Document Editor component and much more.
platform: Blazor
control: DocumentEditor
documentation: ug
---

# How to hide the default tool bar and properties pane in Blazor Document Editor component

**Document editor container** provides the main document view area along with the built-in toolbar and properties pane.

**Document editor** provides just the main document view area. Here, the user can compose, view, and edit the Word documents. You may prefer to use this component when you want to design your own UI options for your application.

## Hide the properties pane

By default, Document editor container has built-in properties pane which contains options for formatting text, table, image and header and footer. You can use [`ShowPropertiesPane`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DocumentEditor.SfDocumentEditorContainer.html#Syncfusion_Blazor_DocumentEditor_SfDocumentEditorContainer_ShowPropertiesPane) API in `DocumentEditorContainer` to hide the properties pane.

The following example code illustrates how to hide the properties pane.

```csharp
@using Syncfusion.Blazor.DocumentEditor

<SfDocumentEditorContainer @ref="container" EnableToolbar=true ShowPropertiesPane="false">

</SfDocumentEditorContainer>
```

>Note: Positioning and customizing the properties pane in Document editor container is not possible. Instead, you can hide the exiting properties pane and create your own pane using public API's.

## Hide the toolbar

You can use [`EnableToolbar`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DocumentEditor.SfDocumentEditorContainer.html#Syncfusion_Blazor_DocumentEditor_SfDocumentEditorContainer_EnableToolbar) API in `DocumentEditorContainer` to hide the existing toolbar.

The following example code illustrates how to hide the existing toolbar.

```csharp
@using Syncfusion.Blazor.DocumentEditor

<SfDocumentEditorContainer @ref="container" EnableToolbar=false ShowPropertiesPane="false">
    
</SfDocumentEditorContainer>
```

## See Also

* [How to customize the toolbar](../../document-editor/how-to/customize-tool-bar)