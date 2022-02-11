---
layout: post
title: Print in Blazor DocumentEditor Component | Syncfusion
description: Checkout and learn here all about the Print functionality in Syncfusion Blazor DocumentEditor component and more.
platform: Blazor
control: DocumentEditor
documentation: ug
---

# Print in Blazor DocumentEditor Component

To print the document, use the [`PrintAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DocumentEditor.SfDocumentEditor.html#Syncfusion_Blazor_DocumentEditor_SfDocumentEditor_PrintAsync) method from document editor instance.

Refer to the following example for print.

```csharp
@using Syncfusion.Blazor.DocumentEditor

<button @onclick="OnPrint">Print</button>
<SfDocumentEditorContainer @ref="container" EnableToolbar=true></SfDocumentEditorContainer>

@code {

    SfDocumentEditorContainer container;
    protected void OnPrint(object args)
    {
        container.DocumentEditor.PrintAsync();
    }
}
```

## Improve print quality

Document editor provides an option to improve the print quality using [`PrintDevicePixelRatio`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DocumentEditor.DocumentEditorSettingsModel.html#Syncfusion_Blazor_DocumentEditor_DocumentEditorSettingsModel_PrintDevicePixelRatio) in Document editor settings. Document editor using canvas approach to render content. Then, canvas are converted to image and it process for print. Using PrintDevicePixelRatio API, you can increase the image quality based on your requirement.

The following example code illustrates how to improve the print quality in Document editor container.

```csharp
<SfDocumentEditorContainer ID="cont" @ref="container" EnableToolbar="true" DocumentEditorSettings="settings" Height="590px">
</SfDocumentEditorContainer>

@code {

    SfDocumentEditorContainer container;
    DocumentEditorSettingsModel settings = new DocumentEditorSettingsModel() { PrintDevicePixelRatio = 2 };

}
```

>Note: By default, printDevicePixelRatio value is 1.