---
layout: post
title: Hide properties pane in Blazor DocumentEditor | Syncfusion
description: Learn how to hide the properties pane in the Syncfusion Blazor Document Editor component and much more.
platform: Blazor
control: DocumentEditor
documentation: ug
---

# How to hide properties pane in Blazor Document Editor

By default, Document editor container has built-in properties pane which contains options for formatting text, table, image and header and footer. You can use [`ShowPropertiesPane`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DocumentEditor.SfDocumentEditorContainer.html#Syncfusion_Blazor_DocumentEditor_SfDocumentEditorContainer_ShowPropertiesPane) API in [`DocumentEditorContainer`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DocumentEditor.SfDocumentEditorContainer.html) to hide the properties pane.

The following example code illustrates how to hide the properties pane.

```csharp
@using Syncfusion.Blazor.DocumentEditor

<SfDocumentEditorContainer @ref="container" ShowPropertiesPane="false">

</SfDocumentEditorContainer>
```

N> Positioning and customizing the properties pane in Document editor container is not possible. Instead, you can hide the exiting properties pane and create your own pane using public API's.