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

```csharp
await container.DocumentEditor.Editor.InsertCommentAsync("Test comment");
```

## Comment navigation

Next and previous comments can be navigated using the below code snippet.

```csharp
//Navigate to next comment
await container.DocumentEditor.Selection.NavigateNextCommentAsync();

//Navigate to previous comment
await container.DocumentEditor.Selection.NavigatePreviousCommentAsync();
```

## Delete comment

You can delete current comment in the document using [`DeleteCommentsAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DocumentEditor.EditorModule.html#Syncfusion_Blazor_DocumentEditor_EditorModule_DeleteCommentAsync) method as shown in the following code snippet.

```csharp
await container.DocumentEditor.Editor.DeleteCommentAsync();
```

## Delete all comment

You can delete all the comments in the document using [`DeleteAllCommentsAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DocumentEditor.EditorModule.html#Syncfusion_Blazor_DocumentEditor_EditorModule_DeleteAllCommentsAsync) method as shown in the following code snippet.

```csharp
await container.DocumentEditor.Editor.DeleteAllCommentsAsync();
```

## Protect the document in comments only mode

Document Editor provides support for protecting the document with `CommentsOnly` protection. In this protection, user allowed to add or edit comments alone in the document.

Document editor provides an option to protect and unprotect document using [`EnforceProtectionAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DocumentEditor.EditorModule.html#Syncfusion_Blazor_DocumentEditor_EditorModule_EnforceProtectionAsync_System_String_Syncfusion_Blazor_DocumentEditor_ProtectionType_) and [`StopProtectionAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DocumentEditor.EditorModule.html#Syncfusion_Blazor_DocumentEditor_EditorModule_StopProtectionAsync_System_String_) API.

The following example code illustrates how to enforce and stop protection in Document editor container.

```csharp
@using Syncfusion.Blazor.DocumentEditor

<button @onclick="protectDocument">Protection</button>
<SfDocumentEditorContainer @ref="container" EnableToolbar=true></SfDocumentEditorContainer>

@code {
    SfDocumentEditorContainer container;
    protected async void protectDocument(object args)
    {
        //enforce protection
        await container.DocumentEditor.Editor.EnforceProtectionAsync("123", ProtectionType.CommentsOnly);
        //stop the document protection
        await container.DocumentEditor.Editor.StopProtectionAsync("123");
    }
}
```

Comment only protection can be enabled in UI by using `Restrict Editing pane`

![Enable comment only protection](images/commentsonly.png)

N> In enforce Protection method, first parameter denotes password and second parameter denotes protection type. Possible values of protection type are `NoProtection |ReadOnly |FormFieldsOnly |CommentsOnly`. In stop protection method, parameter denotes the password.