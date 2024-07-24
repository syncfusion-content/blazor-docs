---
layout: post
title: Customize context menu in Blazor DocumentEditor Component | Syncfusion
description: Learn how to customize context menu with document editor in real time scenarios like create simple word processor in Syncfusion Blazor DocumentEditor component.
platform: Blazor
control: DocumentEditor
documentation: ug
---

# Context menu customization in Blazor DocumentEditor Component

## How to customize context menu in Document Editor

[`Blazor Word Processor`](https://www.syncfusion.com/blazor-components/blazor-word-processor) component (a.k.a Document Editor) allows you to add custom option in context menu. It can be achieved by using the [`AddCustomMenu()`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DocumentEditor.ContextMenuModule.html#Syncfusion_Blazor_DocumentEditor_ContextMenuModule_AddCustomMenu_System_Collections_Generic_List_Syncfusion_Blazor_DocumentEditor_MenuItemModel__System_Boolean_System_Boolean_) method and custom action is defined using the [`ContextMenuItemSelected`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DocumentEditor.DocumentEditorEvents.html#Syncfusion_Blazor_DocumentEditor_DocumentEditorEvents_ContextMenuItemSelected)

### Add Custom Option

The following code shows how to add custom option in context menu.

```csharp
@using Syncfusion.Blazor.DocumentEditor
@inject Microsoft.AspNetCore.Components.NavigationManager UriHelper
@inject IJSRuntime JSRuntime;

<SfDocumentEditorContainer @ref="container" Height="590px">
    <DocumentEditorContainerEvents Created="OnCreated" ContextMenuItemSelected="OnContentMenuSelect"></DocumentEditorContainerEvents>
</SfDocumentEditorContainer>

@code {
    SfDocumentEditorContainer container;

    public void OnCreated(object args)
    {
        SfDocumentEditor documentEditor = container.DocumentEditor;
        List<Syncfusion.Blazor.DocumentEditor.MenuItemModel> contentMenuItem = new List<Syncfusion.Blazor.DocumentEditor.MenuItemModel>
        {
           new Syncfusion.Blazor.DocumentEditor.MenuItemModel { Text="Search In Google", Id= "search_in_google", IconCss="e-icons e-de-ctnr-find" }
        };
        documentEditor.ContextMenu.AddCustomMenu(contentMenuItem, true, false);
    }

    public async Task OnContentMenuSelect(CustomContentMenuEventArgs args)
    {
        if (args.Id.EndsWith("search_in_google"))
        {
            string selectedText = await container.DocumentEditor.Selection.GetTextAsync();
            string url = "http://google.com/search?q=" + selectedText;
            await JSRuntime.InvokeAsync<object>("open", new object[2] { url, "_blank" });
        }
    }
}
```

### Customize custom option in context menu

[`Blazor Word Processor`](https://www.syncfusion.com/blazor-components/blazor-word-processor) component (a.k.a Document Editor) allows you to customize the added custom option and also to hide/show default context menu.

#### Hide default context menu items

The following code shows how to hide default context menu and add custom option in context menu.

```csharp
<SfDocumentEditorContainer @ref="container" Height="590px">
    <DocumentEditorContainerEvents Created="OnCreated"></DocumentEditorContainerEvents>
</SfDocumentEditorContainer>

@code {
    SfDocumentEditorContainer container;

    public void OnCreated(object args)
    {
        SfDocumentEditor documentEditor = container.DocumentEditor;
        List<Syncfusion.Blazor.DocumentEditor.MenuItemModel> contentMenuItem = new List<Syncfusion.Blazor.DocumentEditor.MenuItemModel>
        {
           new Syncfusion.Blazor.DocumentEditor.MenuItemModel { Text="Search In Google", Id= "search_in_google", IconCss="e-icons e-de-ctnr-find" }
        };
        documentEditor.ContextMenu.AddCustomMenu(contentMenuItem, false, false);
    }
}
```

You can also explore our [Blazor Word Processor - Context Menu](https://blazor.syncfusion.com/demos/document-editor/custom-context-menu?theme=bootstrap5) example to know how to render and configure the document editor.