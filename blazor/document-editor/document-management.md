---
layout: post
title: Document management in Blazor Document editor component | Syncfusion
description: Learn here all about Document management in Syncfusion Blazor Document editor component of Syncfusion
platform: Blazor
control: Document management 
documentation: ug
---

# Document management in Blazor Document editor control

Document Editor provides support to restrict editing. When the protected document includes range permission, then unique user or user group only authorized to edit separate text area.

## Set current user

You can use the `currentUser` property to authorize the current document user by name, email, or user group name.

The following code shows how to set currentUser

```csharp
@page "/"
@using Syncfusion.Blazor.DocumentEditor
@inject IJSRuntime JS
<SfDocumentEditorContainer @ref="container" CurrentUser="@CurrentUser" EnableToolbar="true" Height="590px">
</SfDocumentEditorContainer>

@code {
    private SfDocumentEditorContainer container;
    private string CurrentUser = "engineer@mycompany.com";
}

```

## Customize highlight color of text area

You can highlight the editable region of the current user using the `userColor` property.

The following code shows how to set userColor.

```csharp
@page "/"
@using Syncfusion.Blazor.DocumentEditor
@inject IJSRuntime JS
<SfDocumentEditorContainer @ref="container" UserColor="@UserColor" EnableToolbar="true" Height="590px">
</SfDocumentEditorContainer>

@code {
    private SfDocumentEditorContainer container;
    private string UserColor = "#fff000";
}

```

## Highlighting the editable text area

You can toggle the highlight the editable region value using the "highlightEditableRanges" property.

The following code shows how to toggle the highlight editable region value.

```csharp
@page "/"
@using Syncfusion.Blazor.DocumentEditor
@inject IJSRuntime JS
<SfDocumentEditorContainer DocumentEditorSettings="Settings" EnableToolbar="true" Height="590px">
</SfDocumentEditorContainer>

@code {
    private SfDocumentEditorContainer container;
    private DocumentEditorSettingsModel Settings = new DocumentEditorSettingsModel { HighlightEditableRanges = true };
}
 
```

## Restrict Editing Pane

Restrict Editing Pane provides the following options to manage the document:
* To apply formatting restrictions to the current document, select the allow formatting check box.
* To apply editing restrictions to the current document, select the read only check box.
* To add users to the current document, select more users option and add user from the popup dialog.
* To include range permission to the current document, select parts of the document and choose users who are allowed to freely edit them from the listed check box.
* To apply the chosen editing restrictions, click the **YES,START ENFORCING PROTECTION** button. A dialog box displays asking for a   password to protect.
* To stop protection, select **STOP PROTECTION** button. A dialog box displays asking for a password to stop protection.

The following code shows Restrict Editing Pane. To unprotect the document, use password '123'.

```csharp
@page "/"
@using Syncfusion.Blazor.DocumentEditor
@inject IJSRuntime JS
<SfDocumentEditorContainer @ref="container" CurrentUser="@CurrentUser" EnableToolbar="true" Height="590px">
    <DocumentEditorContainerEvents Created="OnLoad"></DocumentEditorContainerEvents>
</SfDocumentEditorContainer>

@code {
    private SfDocumentEditorContainer container;
    // Set the current user
    private string CurrentUser = "engineer@mycompany.com";
    // Load the document when the editor is ready
    protected async Task OnLoad(object args)
    {
        string sfdt = @"{""sfdt"":""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""}";
        await container.DocumentEditor.OpenAsync(sfdt);
    }
}

```

You can also explore our [Blazor Word Processor](https://blazor.syncfusion.com/demos/document-editor/default-functionalities) example to know how to render and configure the document editor.
