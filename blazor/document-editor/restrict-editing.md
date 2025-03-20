---
layout: post
title: Restrict editing in Blazor DocumentEditor Component | Syncfusion
description: Checkout and learn here all about Restrict editing in Syncfusion Blazor DocumentEditor component and more.
platform: Blazor
control: DocumentEditor
documentation: ug
---

# Restrict editing in Blazor DocumentEditor Component

This [Blazor Word Processor control](https://www.syncfusion.com/blazor-components/blazor-word-processor) (DocumentEditor) provides 2 types of restriction for editing:
* Read-only: Allows all the users to view the document contents but not make changes to it.
* Allows changes to certain portion of the document: Allows the users to edit to certain portion of the document.

## Read only

The following code example shows how to restrict or protect editing for the entire content (show as read-only).

```cshtml
@using Syncfusion.Blazor.DocumentEditor

<button @onclick="ReadOnly">Read Only</button>
<SfDocumentEditorContainer @ref="container" EnableToolbar=true></SfDocumentEditorContainer>

@code {
    SfDocumentEditorContainer container;

    public void ReadOnly(object args)
    {
        container.RestrictEditing = true;
    }
}
```

## Allows changes to certain portion of the document

Also, at some situations, you might need to allow changes for a certain portion of the document alone. Microsoft Word allows you to [make changes to parts of a Word document](https://support.microsoft.com/en-us/office/allow-changes-to-parts-of-a-protected-document-187ed01c-8795-43e1-9fd0-c9fca419dadf?ui=en-us&rs=en-us&ad=us). Likewise, the document editor control allows the users to make changes to certain parts of a document using similar user interface.

![Disabling Restrict Editing in Blazor DocumentEditor](./images/blazor-document-editor-disable-edit-restriction.png)

![Enabling Restrict Editing in Blazor DocumentEditor](./images/blazor-document-editor-enable-edit-restriction.png)

You can also explore our [Blazor Word Processor](https://blazor.syncfusion.com/demos/document-editor/default-functionalities) example to know how to render and configure the document editor.
