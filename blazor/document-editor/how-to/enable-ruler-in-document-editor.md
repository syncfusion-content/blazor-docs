---
layout: post
title: How to enable Ruler in Blazor DocumentEditor Component | Syncfusion
description: Learn how to show or hide ruler component in Syncfusion Blazor Document Editor component and much more.
platform: Blazor
control: DocumentEditor
documentation: ug
---

# Enable ruler in Document Editor

## How to enable ruler in Document Editor Container component

Using ruler we can refer to setting specific margins, tab stops, or indentations within a document to ensure consistent formatting in Document Editor Container.

The following example illustrates how to enable ruler in Document Editor Container.

```csharp
<button @onclick="ClickHandler">Show/Hide Ruler</button>

<div>
    <SfDocumentEditorContainer @ref="container" EnableToolbar=true Height="590px" DocumentEditorSettings="@settings">      
    </SfDocumentEditorContainer>    
</div>

@code {
    SfDocumentEditorContainer container;
    public DocumentEditorSettingsModel settings = new DocumentEditorSettingsModel() { ShowRuler = true };   
    
    private void ClickHandler()
    {
         container.DocumentEditorSettings.ShowRuler = !container.DocumentEditorSettings.ShowRuler;
    }   
}
```


