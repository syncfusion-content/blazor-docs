---
layout: post
title: Comments in Blazor DocumentEditor Component | Syncfusion
description: Checkout and learn here all about the Comments in Syncfusion Blazor DocumentEditor component and more.
platform: Blazor
control: DocumentEditor
documentation: ug
---

# Comments in Blazor DocumentEditor Component

[`Blazor Word Processor`](https://www.syncfusion.com/blazor-components/blazor-word-processor) component (a.k.a Document Editor) component allows you to add comments to documents. You can add, navigate and remove comments using code and from the UI.

## Add a new comment

Using [`InsertCommentAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DocumentEditor.EditorModule.html#Syncfusion_Blazor_DocumentEditor_EditorModule_InsertCommentAsync_System_String_) method, comments can be inserted to the selected text.

```typescript
container.DocumentEditor.Editor.InsertCommentAsync("Test comment");
```

## Comment navigation

Next and previous comments can be navigated using the below code snippet.

```typescript
//Navigate to next comment
container.DocumentEditor.Selection.NavigateNextCommentAsync();

//Navigate to previous comment
container.DocumentEditor.Selection.NavigatePreviousCommentAsync();
```

## Delete comment

You can delete current comment in the document using [`DeleteCommentsAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DocumentEditor.EditorModule.html#Syncfusion_Blazor_DocumentEditor_EditorModule_DeleteCommentAsync) method as shown in the following code snippet.

```typescript
container.DocumentEditor.Editor.DeleteCommentAsync();
```

## Delete all comment

You can delete all the comments in the document using [`DeleteAllCommentsAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DocumentEditor.EditorModule.html#Syncfusion_Blazor_DocumentEditor_EditorModule_DeleteAllCommentsAsync) method as shown in the following code snippet.

```typescript
container.DocumentEditor.Editor.DeleteAllCommentsAsync();
```
