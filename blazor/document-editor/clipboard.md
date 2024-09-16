---
layout: post
title: Clipboard in Blazor DocumentEditor Component | Syncfusion
description: Checkout and learn here all about Clipboard in Syncfusion Blazor DocumentEditor component and much more.
platform: Blazor
control: DocumentEditor
documentation: ug
---

# Clipboard in Blazor DocumentEditor Component

[Blazor Word Processor](https://www.syncfusion.com/blazor-components/blazor-word-processor) component (a.k.a Document Editor) provides built-in support for clipboard operations such as cut, copy, and paste. You can perform the clipboard operations using keyboard shortcuts, touch, and keyboard interactions. Also, the same functionalities can be invoked programmatically.

There is a built-in clipboard (local clipboard) with this Word processor component, which allows the users to perform cut, copy, and paste faster. If you want to use system clipboard instead of local clipboard, turn off the local clipboard by setting the [`EnableLocalPaste`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DocumentEditor.SfDocumentEditor.html#Syncfusion_Blazor_DocumentEditor_SfDocumentEditor_EnableLocalPaste) to false.

If you need to copy or paste the contents from other applications, use system clipboard. To copy or paste the contents within the Word processor component, use local clipboard.

Let’s see how to invoke each clipboard operations using code.

## Copy

You can copy the selected contents using the [`CopyAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DocumentEditor.SelectionModule.html#Syncfusion_Blazor_DocumentEditor_SelectionModule_CopyAsync) method as shown in the following code example.

```cshtml
@using Syncfusion.Blazor.DocumentEditor

<button @onclick="CopyClick">Copy</button>
<SfDocumentEditorContainer @ref="container" EnableToolbar=true></SfDocumentEditorContainer>

@code {
    SfDocumentEditorContainer container;
    protected async void CopyClick(object args)
    {
        await container.DocumentEditor.Selection.CopyAsync();
    }
}
```

## Cut

You can cut the selected content using the ['Cut'](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DocumentEditor.EditorModule.html#Syncfusion_Blazor_DocumentEditor_EditorModule_CutAsync) method as shown in the following code example.

```cshtml
@using Syncfusion.Blazor.DocumentEditor

<button @onclick="CutClick">Cut</button>
<SfDocumentEditorContainer @ref="container" EnableToolbar=true></SfDocumentEditorContainer>

@code {
    SfDocumentEditorContainer container;
    protected async void CutClick(object args)
    {
        await container.DocumentEditor.Editor.CutAsync();
    }
}

```

## Paste

## Local paste

The following code example shows how to perform the paste operation from the local clipboard.

```cshtml
@using Syncfusion.Blazor.DocumentEditor

<button @onclick="PasteClick">Paste</button>
<SfDocumentEditorContainer @ref="container" EnableToolbar=true EnableLocalPaste=true></SfDocumentEditorContainer>
@code {
    SfDocumentEditorContainer container;
    protected async void PasteClick(object args)
    {
        await container.DocumentEditor.Editor.PasteAsync();
    }
}

```

You can also explore our [Blazor Word Processor](https://blazor.syncfusion.com/demos/document-editor/default-functionalities?theme=bootstrap5) example to know how to render and configure the document editor.
