---
layout: post
title: Customize font family dropdown in Blazor DocumentEditor Component | Syncfusion
description: Learn how to Customize font family dropdown in Syncfusion Blazor DocumentEditor component and much more.
platform: Blazor
control: DocumentEditor
documentation: ug
---

# How to customize the font family drop down in Blazor DocumentEditor Component

[`Blazor Word Processor`](https://www.syncfusion.com/blazor-components/blazor-word-processor) component (a.k.a Document Editor) component provides an options to customize the font family drop down list values using [`Fontfamilies`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DocumentEditor.DocumentEditorSettingsModel.html#Syncfusion_Blazor_DocumentEditor_DocumentEditorSettingsModel_FontFamilies) in Document editor settings. Fonts which are added in fontFamilies of [`DocumentEditorSettings`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DocumentEditor.SfDocumentEditorContainer.html#Syncfusion_Blazor_DocumentEditor_SfDocumentEditorContainer_DocumentEditorSettings) will be displayed on font drop down list of text properties pane and font dialog.

Similarly, you can use [`DocumentEditorSettings`] property for DocumentEditor also.

The following example code illustrates how to change the font families in Document editor container.

```typescript

<SfDocumentEditorContainer @ref="container" Height="590px" DocumentEditorSettings="settings">
</SfDocumentEditorContainer>

@code {

    SfDocumentEditorContainer container;
    DocumentEditorSettingsModel settings = new DocumentEditorSettingsModel() { FontFamilies = new string[4]{"Algerian","Arial","Calibri","Windings" } };
}
```

Output will be like below:

![Font](../images/font-family.png)