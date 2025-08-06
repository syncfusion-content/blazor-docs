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

```

> The Web API hosted link `https://services.syncfusion.com/react/production/api/documenteditor/` utilized in the Document Editor's serviceUrl property is intended solely for demonstration and evaluation purposes. For production deployment, please host your own web service with your required server configurations. You can refer and reuse the [GitHub Web Service example](https://github.com/SyncfusionExamples/EJ2-DocumentEditor-WebServices) or [Docker image](https://hub.docker.com/r/syncfusion/word-processor-server) for hosting your own web service and use for the serviceUrl property.

## See Also

* [How to protect the document in form filling mode](../document-editor/form-fields#protect-the-document-in-form-filling-mode)
* [How to protect the document in comments only mode](../document-editor/comments#protect-the-document-in-comments-only-mode)
* [How to protect the document in track changes only mode](../document-editor/track-changes#protect-the-document-in-track-changes-only-mode)
