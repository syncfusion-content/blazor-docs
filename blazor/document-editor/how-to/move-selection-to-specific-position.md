---
layout: post
title: Move to selection position in Blazor DocumentEditor | Syncfusion
description: Learn how to Move to selection position in Syncfusion Blazor DocumentEditor component and much more.
platform: Blazor
control: DocumentEditor
documentation: ug
---

# Move selection to specific position in ##Platform_Name## Document editor

Using [`SelectAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DocumentEditor.SelectionModule.html#Syncfusion_Blazor_DocumentEditor_SelectionModule_SelectAsync_System_String_System_String_) API in selection module, You can set cursor position to anywhere in the document.

## Selects content based on start and end hierarchical index

Hierarchical index will be in below format.

`sectionIndex;blockIndex;offset`

The following code snippet illustrate how to select using hierarchical index.

```csharp
<button @onclick="SelectText">Select Text</button>
<SfDocumentEditorContainer @ref="container" EnableToolbar="true"  Height="590px" >
</SfDocumentEditorContainer>
@code {
    SfDocumentEditorContainer container;

    // It will select the specified Position
    public async void SelectText()
    {
        // Selection will occur between provided start and end offset
        await container.DocumentEditor.Editor.InsertTextAsync("Welcome");
        // The below code will select the letters “We” from inserted text “Welcome”
        await container.DocumentEditor.Selection.SelectAsync("0;0;0", "0;0;2");
    }
}
```

The following table illustrates about Hierarchical index in detail.

| Element |Hierarchical Format | Explanation |
|-----------------|-------------|----|
|Move selection to Paragraph |sectionIndex;blockIndex;offset <br>**Ex:** 0;0;0|It moves the cursor to the start of paragraph.|
|Move selection to Table|sectionIndex;tableIndex;rowIndex;cellIndex;blockIndex;offset <br>**Ex:** 0;0;0;0;1;0|It moves the cursor to the second paragraph which is inside first row and cell of table.|
|Move selection to header|pageIndex;H;sectionIndex;blockIndex;offset<br>**Ex:** 1;H;0;0;0|It moves cursor to the header in second page.|
|Move selection to Footer|pageIndex;F;sectionIndex;blockIndex;offset<br>**Ex:** 1;F;0;0;0|It moves cursor to the footer in second page.|

## Get the selection start and end hierarchical index

Using [`GetStartOffsetAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DocumentEditor.SelectionModule.html#Syncfusion_Blazor_DocumentEditor_SelectionModule_GetStartOffsetAsync), you can get start hierarchical index which denotes the start index of current selection. Similarly, using [`GetEndOffsetAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DocumentEditor.SelectionModule.html#Syncfusion_Blazor_DocumentEditor_SelectionModule_GetEndOffsetAsync), you can get end hierarchical index which denotes the end index of current selection.

The following code snippet illustrate how to get the selection start and end offset on selection changes in document.


```csharp
<SfDocumentEditorContainer @ref="container" EnableToolbar="true"  Height="590px" SelectionChanged="selectionChange">
</SfDocumentEditorContainer>
@code {
    SfDocumentEditorContainer container;
    private string startOffset;
    private string endOffset;

    // Event gets triggered on selection change in document
    public async void selectionChange()
    {
        //Get the start index of current selection
        startOffset = await container.DocumentEditor.Selection.GetStartOffsetAsync();
        //Get the end index of current selection
        endOffset = await container.DocumentEditor.Selection.GetEndOffsetAsync();
    }
}
```