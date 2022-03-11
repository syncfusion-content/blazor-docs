---
layout: post
title: Layout type in in Blazor DocumentEditor Component | Syncfusion
description: Checkout and learn here all about change layout type in Syncfusion Blazor DocumentEditor component and much more.
platform: Blazor
control: DocumentEditor
documentation: ug
---

# Change document view in Blazor DocumentEditor Component

[`Blazor Word Processor`](https://www.syncfusion.com/blazor-components/blazor-word-processor) component (a.k.a Document Editor) component allows you to change the view to web layout and print using the  [`layoutType`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DocumentEditor.LayoutType.html#fields) property with the supported [`LayoutType`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DocumentEditor.LayoutType.html).

```typescript
<SfDocumentEditorContainer @ref="editor" EnableToolbar="true" Height="590px" LayoutType="LayoutType.Continuous">
</SfDocumentEditorContainer>
```

>Note: Default value of `LayoutType` in DocumentEditorContainer component is `Pages`.