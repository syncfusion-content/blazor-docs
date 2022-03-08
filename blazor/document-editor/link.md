---
layout: post
title: Hyperlink in Blazor DocumentEditor Component | Syncfusion
description: Checkout and learn here all about Hyperlink and its functionality in Syncfusion Blazor DocumentEditor component and more.
platform: Blazor
control: DocumentEditor
documentation: ug
---

# Hyperlink in Blazor DocumentEditor Component

[Blazor Document Editor](https://www.syncfusion.com/blazor-components/blazor-word-processor) supports hyperlink field. You can link a part of the document content to Internet or file location, mail address, or any text within the document.

## Navigate a hyperlink

[Blazor Document Editor](https://www.syncfusion.com/blazor-components/blazor-word-processor) triggers [`requestNavigate`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DocumentEditor.DocumentEditorEvents.html#Syncfusion_Blazor_DocumentEditor_DocumentEditorEvents_OnRequestNavigate) event whenever user clicks Ctrl key or tap a hyperlink within the document. This event provides necessary details about link type, navigation URL, and local URL (if any) as arguments, and allows you to easily customize the hyperlink navigation functionality. 

Refer to the following example.

```cshtml
<SfDocumentEditor ID="cont" IsReadOnly="false" EnableEditor="true" EnableSelection="true" @ref="container" Height="590px">
    <DocumentEditorEvents OnRequestNavigate="OnRequestNavigate" Created="OnCreated" ></DocumentEditorEvents>
</SfDocumentEditor>

@code {

    SfDocumentEditorContainer container;

    // Add event listener for requestNavigate event to customize hyperlink navigation functionality
    public void OnRequestNavigate(RequestNavigateEventArgs args)
    {
        if (args.LinkType != HyperlinkType.Bookmark)
        {
            string link = args.NavigationLink;
            if (args.LocalReference.Length > 0)
            {
                link += '#' + args.LocalReference;
            }
            //Customize your code here.
            
            args.IsHandled = true;
        }
    }

}

```

If the selection is in hyperlink, trigger this event by calling [`NavigateHyperlinkAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DocumentEditor.SelectionModule.html#Syncfusion_Blazor_DocumentEditor_SelectionModule_NavigateHyperlinkAsync) method of ‘Selection’ instance. Refer to the following example.

```csharp
 container.DocumentEditor.Selection.NavigateHyperlinkAsync();
```

## Copy link

[Blazor Document Editor](https://www.syncfusion.com/blazor-components/blazor-word-processor) copies link text of a hyperlink field to the clipboard if the selection is in hyperlink. Refer to the following example.

```csharp
container.DocumentEditor.Selection.CopyHyperlinkAsync();
```

## Add hyperlink

To create a basic hyperlink in the document, press `ENTER` / `SPACEBAR` / `SHIFT + ENTER` / `TAB` key after typing the address, for instance `http://www.google.com`. Document Editor automatically converts this address to a hyperlink field. The text can be considered as a valid URL if it starts with any of the following.

> `<http://>`<br>
> `<https://>`<br>
> `file:///`<br>
> `www.`<br>
> `mail to:`<br>

Also Document Editor expose API [`InsertHyperlinkAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DocumentEditor.EditorModule.html#Syncfusion_Blazor_DocumentEditor_EditorModule_InsertHyperlinkAsync_System_String_System_String_)to insert hyperlink.

Refer to the following sample code.

```csharp
container.DocumentEditor.Editor.InsertHyperlinkAsync("https://www.google.com", "Google");
```

## Remove hyperlink

To remove link from hyperlink in the document, press Backspace key at the end of a hyperlink. By removing the link, it will be converted as plain text. You can use [`RemoveHyperlinkAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DocumentEditor.EditorModule.html#Syncfusion_Blazor_DocumentEditor_EditorModule_RemoveHyperlinkAsync) method of ‘Editor’ instance if the selection is in hyperlink. Refer to the following example.

```csharp
container.DocumentEditor.Editor.RemoveHyperlinkAsync();
```

## Hyperlink dialog

[Blazor Document Editor](https://www.syncfusion.com/blazor-components/blazor-word-processor) provides dialog support to insert or edit a hyperlink. 

Refer to the following example to open Hyperlink dialog.

```csharp
container.DocumentEditor.ShowDialog(DialogType.Hyperlink);
```

You can use the following keyboard shortcut to open the hyperlink dialog if the selection is in hyperlink.

| Key Combination | Description |
|-----------------|-------------|
|Ctrl + K | Open hyperlink dialog that allows you to create or edit hyperlink|