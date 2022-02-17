---
layout: post
title: Customize the toolbar in Blazor DocumentEditor Component | Syncfusion
description: Learn how to Customize the existing toolbar in Syncfusion Blazor DocumentEditor component and much more.
platform: Blazor
control: DocumentEditor
documentation: ug
---
# Customize existing toolbar in Blazor DocumentEditor Component

## How to customize existing toolbar in DocumentEditorContainer

[`Blazor Word Processor`](https://www.syncfusion.com/blazor-components/blazor-word-processor) component (a.k.a Document Editor) component allows you to customize(add, show, hide, enable, and disable) existing items in a toolbar.

* Add - New items can defined by [`CustomToolbarItemModel`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DocumentEditor.CustomToolbarItemModel.html) and with existing items in [`toolbarItems`](../api/document-editor-container/#toolbaritems) property. Newly added item click action can be defined in [`toolbarclick`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DocumentEditor.DocumentEditorContainerEvents.html#Syncfusion_Blazor_DocumentEditor_DocumentEditorContainerEvents_OnToolbarClick).

* Show, Hide - Existing items can be shown or hidden using the [`toolbarItems`](../../api/document-editor-container/#toolbaritems) property. Pre-defined toolbar items are available with [`ToolbarItem`](../../api/document-editor/toolbaritem/).

* Enable, Disable -  Toolbar items can be enabled or disable using [`EnableItemAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DocumentEditor.ToolbarModule.html#Syncfusion_Blazor_DocumentEditor_ToolbarModule_EnableItemAsync_System_Int32_System_Boolean_)

```csharp
<SfDocumentEditorContainer @ref="container" EnableToolbar=true ToolbarItems="@Items">
</SfDocumentEditorContainer>


@code {
    SfDocumentEditorContainer container;

    string[] Items = new string[4] { "New", "Undo", "Redo", "Comments"};
}
```

>Note: Default value of `ToolbarItems` are `['New', 'Open', 'Separator', 'Undo', 'Redo', 'Separator', 'Image', 'Table', 'Hyperlink', 'Bookmark', 'TableOfContents', 'Separator', 'Header', 'Footer', 'PageSetup', 'PageNumber', 'Break', 'InsertFootnote', 'InsertEndnote', 'Separator', 'Find', 'Separator', 'Comments', 'TrackChanges', 'Separator', 'LocalClipboard', 'RestrictEditing', 'Separator', 'FormFields', 'UpdateFields']`.