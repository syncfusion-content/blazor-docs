---
layout: post
title: How to enable ruler in Document Edior
description: Learn how to enable ruler in Angular Document Editor component.
platform: Blazor
control: DocumentEditor
documentation: ug
---

# Enable ruler

## How to enable ruler in Document Editor component

Using ruler we can refer to setting specific margins, tab stops, or indentations within a document to ensure consistent formatting in Document Editor.

Example code snippet to show/hide ruler

```csharp
<button @onclick="ClickHandler">Show/Hide Ruler</button>

<div>
    <SfDocumentEditorContainer @ref="container" EnableToolbar=true Height="590px" DocumentEditorSettings="@settings">      
    </SfDocumentEditorContainer>    
</div>

@code {
    SfDocumentEditorContainer container;
     public DocumentEditorSettingsModel settings = new DocumentEditorSettingsModel() { ShowRuler = true };
    private bool VisibleProperty { get; set; } = false;
    SfDocumentEditorContainer container;
    string sfdtString;

    private void ClickHandler()
    {
         container.DocumentEditorSettings.ShowRuler = !container.DocumentEditorSettings.ShowRuler;
    }   
}
```


