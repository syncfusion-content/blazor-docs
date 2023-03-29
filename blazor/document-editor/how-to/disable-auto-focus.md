---
layout: post
title: How to disable auto focus in in Blazor DocumentEditor Component | Syncfusion
description: Checkout and learn here all about How to disable and enable auto focus in Syncfusion Blazor DocumentEditor component and much more.
platform: Blazor
control: DocumentEditor
documentation: ug
---

# How to disable auto focus in Syncfusion JavaScript Document Editor component.

Document Editor gets focused automatically when the page loads. If you want the Document editor not to be focused automatically it can be customized.

The following example illustrates to disable the auto focus in DocumentEditorContainer.

```csharp
@using Syncfusion.Blazor.DocumentEditor

<SfDocumentEditorContainer @ref="container" EnableToolbar=true EnableAutoFocus=false></SfDocumentEditorContainer>
```

>Note: Default value of [`enableAutoFocus`] property is `true`.

The following example illustrates to disable the auto focus in DocumentEditor.

```csharp
@using Syncfusion.Blazor.DocumentEditor
<SfDocumentEditorContainer @ref="container" EnableToolbar=true EnableAutoFocus=false></SfDocumentEditorContainer>
```

>Note: Default value of [`enableAutoFocus`]property is `true`.