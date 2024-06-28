---
layout: post
title: Get selected content in Blazor DocumentEditor Component | Syncfusion
description: Learn how to get the selected content from the Syncfusion Blazor Document Editor component as plain text or SFDT (rich text) and much more.
platform: Blazor
control: DocumentEditor
documentation: ug
---

# How to get the selected content in Blazor Document Editor component

You can get the selected content from the Blazor Document Editor component as plain text and SFDT (rich text).

## Get the selected content as plain text

You can use [`GetTextAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DocumentEditor.SelectionModule.html#Syncfusion_Blazor_DocumentEditor_SelectionModule_GetTextAsync) API to get the selected content as plain text from Blazor Document Editor component.

The following example code illustrates how to add search in google option in context menu for the selected text.

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
            // To get the selected content as plain text
            string selectedText = await container.DocumentEditor.Selection.GetTextAsync();
            string url = "http://google.com/search?q=" + selectedText;
            await JSRuntime.InvokeAsync<object>("open", new object[2] { url, "_blank" });
        }
    }
}
```

You can add the following custom options using this API,

* Save or export the selected text as text file.
* Search the selected text in Google or other search engines.
* Show synonyms for the selected word in context menu and replace with selected synonym using the setter method of same API.

## Get the selected content as SFDT (rich text)

You can use [`GetSfdtAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DocumentEditor.SelectionModule.html#Syncfusion_Blazor_DocumentEditor_SelectionModule_GetSfdtAsync) API to get the selected content as plain text from Blazor Document Editor component.

The following example code illustrates how to get the content of a bookmark and export it as SFDT.

```csharp
@using Syncfusion.Blazor.DocumentEditor

<SfDocumentEditorContainer @ref="container" EnableToolbar=true Height="590px">
    <DocumentEditorContainerEvents Created="OnLoad"></DocumentEditorContainerEvents>
</SfDocumentEditorContainer>

@code {
    SfDocumentEditorContainer container;
    string sfdtString;

    public async void OnLoad(object args)
    {
        // To insert text in cursor position
        await container.DocumentEditor.Editor.InsertTextAsync("Document editor");
        // To select all the content in document
        await container.DocumentEditor.Selection.SelectAllAsync();
        // Insert bookmark to selected content
        await container.DocumentEditor.Editor.InsertBookmarkAsync("Bookmark1");
        //Select the bookmark
        await container.DocumentEditor.Selection.SelectBookmarkAsync("Bookmark1");
        // To get the selected content as sfdt
        string selectedContent =await container.DocumentEditor.Selection.GetSfdtAsync();
        // Insert the sfdt content in cursor position using paste API
        await container.DocumentEditor.Editor.PasteAsync(selectedContent);
    }
}
```

You can add the following custom options using this API,

* Save or export the selected content as SFDT file.
* Get the content of a bookmark in Word document as SFDT by selecting a bookmark using [`SelectBookmarkAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DocumentEditor.SelectionModule.html#Syncfusion_Blazor_DocumentEditor_SelectionModule_SelectBookmarkAsync_System_String_) API.
* Create template content that can be inserted to multiple documents in cursor position using [`PasteAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DocumentEditor.EditorModule.html#Syncfusion_Blazor_DocumentEditor_EditorModule_PasteAsync_System_String_System_Nullable_Syncfusion_Blazor_DocumentEditor_PasteOptions__) API.