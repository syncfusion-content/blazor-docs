---
layout: post
title: Add save button in Blazor DocumentEditor Component | Syncfusion
description: Learn how to add a save button to the toolbar in the Syncfusion Blazor DocumentEditor component and much more.
platform: Blazor
control: DocumentEditor
documentation: ug
---
# Add save button in Blazor Document editor toolbar

## To add a save button to the existing toolbar in DocumentEditorContainer

[`Blazor Word Processor`](https://www.syncfusion.com/blazor-components/blazor-word-processor) component (a.k.a Document Editor) component  allows you to add a new button to the existing items in a toolbar using [`CustomToolbarItemModel`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DocumentEditor.CustomToolbarItemModel.html) and with existing items in [`toolbarItems`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DocumentEditor.SfDocumentEditorContainer.html#Syncfusion_Blazor_DocumentEditor_SfDocumentEditorContainer_ToolbarItems) property. Newly added item click action can be defined in [`toolbarclick`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DocumentEditor.DocumentEditorContainerEvents.html#Syncfusion_Blazor_DocumentEditor_DocumentEditorContainerEvents_OnToolbarClick).

```csharp
<SfDocumentEditorContainer @ref="container" EnableToolbar=true ToolbarItems="@Items" ToolbarClick="OnToolbarClick"> 
</SfDocumentEditorContainer> 
 
@code { 
    SfDocumentEditorContainer container; 
    List<Object> Items = new List<Object> { new CustomToolbarItemModel() {"New","Open", Id = "save", Text = "Save" }, "Separator", "Undo", "Redo", "Separator", "Image", "Table", "Hyperlink", "Bookmark", "TableOfContents", "Separator", "Header", "Footer", "PageSetup", "PageNumber", "Break", "InsertFootnote", "InsertEndnote", "Separator", "Find", "Separator", "Comments", "TrackChanges", "Separator", "LocalClipboard", "RestrictEditing", "Separator", "FormFields", "UpdateFields" }; 

    private void OnToolbarClick(ClickEventArgs args)
    {
        if (args.Item.Id == "save")
        {
            container.DocumentEditor.SaveAsync("sample", SaveFormat.Docx);
        }
    }
};
```

N> Default value of `ToolbarItems` are `['New', 'Open', 'Separator', 'Undo', 'Redo', 'Separator', 'Image', 'Table', 'Hyperlink', 'Bookmark', 'TableOfContents', 'Separator', 'Header', 'Footer', 'PageSetup', 'PageNumber', 'Break', 'InsertFootnote', 'InsertEndnote', 'Separator', 'Find', 'Separator', 'Comments', 'TrackChanges', 'Separator', 'LocalClipboard', 'RestrictEditing', 'Separator', 'FormFields', 'UpdateFields' ]`.
