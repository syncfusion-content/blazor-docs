---
layout: post
title: Bookmarks in Blazor DocumentEditor Component | Syncfusion
description: Checkout and learn here all about the Bookmarks in Syncfusion Blazor DocumentEditor component and more.
platform: Blazor
control: DocumentEditor
documentation: ug
---

# Bookmarks in Blazor DocumentEditor Component

Bookmark is a powerful tool that helps you to mark a place in the document to find again easily. You can enter many bookmarks in the document and give each one a unique name to identify easily.

[`Blazor Word Processor`](https://www.syncfusion.com/blazor-components/blazor-word-processor) component (a.k.a Document Editor) component provides built-in dialog and using code to add, delete, and navigate bookmarks within the document. To add a bookmark, select a portion of text in the document. After that, jump to the location or add links to it within the document using built-in hyperlink dialog. You can also delete bookmarks from a document.

>Bookmark names need to begin with a letter. They can include both numbers and letters, but not spaces. To separate the words, use an underscore.
>Bookmark names starting with an underscore are called hidden bookmarks. For example, bookmarks generated for table of contents.

You can open the bookmark dialog using Bookmark options in toolbar. You can also explore our [`Blazor Word Processor - Bookmark`](https://blazor.syncfusion.com/demos/document-editor/hyperlinks-and-bookmarks) example to know more about bookmark.


## Add bookmark

Using [`InsertBookmarkAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DocumentEditor.EditorModule.html#Syncfusion_Blazor_DocumentEditor_EditorModule_InsertBookmarkAsync_System_String_) method, Bookmark can be added to the selected text.

```typescript
container.DocumentEditor.Editor.InsertBookmarkAsync("Bookmark1");
```

## Select Bookmark

You can select the bookmark in the document using [`SelectBookmarkAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DocumentEditor.SelectionModule.html#Syncfusion_Blazor_DocumentEditor_SelectionModule_SelectBookmarkAsync_System_String_) method by providing Bookmark name to select as shown in the following code snippet.

```typescript
container.DocumentEditor.Selection.SelectBookmarkAsync("Bookmark1");
```

## Delete Bookmark

You can delete bookmark in the document using [`DeleteBookmarkAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DocumentEditor.EditorModule.html#Syncfusion_Blazor_DocumentEditor_EditorModule_DeleteBookmarkAsync_System_String_) method as shown in the following code snippet.

```typescript
container.DocumentEditor.Editor.DeleteBookmarkAsync("Bookmark1");
```

## Get Bookmark

You can get all the bookmarks in the document using [`GetBookmarksAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DocumentEditor.SelectionModule.html#Syncfusion_Blazor_DocumentEditor_SelectionModule_GetBookmarksAsync_System_Boolean_) method as shown in the following code snippet.

```typescript
container.DocumentEditor.Selection.GetBookmarksAsync(false);
```

>Note: Parameter denotes is include hidden bookmarks. If false, ignore hidden bookmark.