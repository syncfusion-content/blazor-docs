---
layout: post
title: Enable or disable the custom undo redo button | Syncfusion
description: Learn how to enable or disable the custom undo redo button in Syncfusion Blazor PDF Viewer component and more.
platform: Blazor
control: PDF Viewer
documentation: ug
---

# Enable or disable the custom undo redo button

The Syncfusion's Blazor PDF Viewer component allows you to enable or disable the custom undo or redo buttons based on the undo redo actions using the `CanUndo` and `CanRedo` APIs of the PDF Viewer.

The following code example shows how to enable or disable the custom undo redo button based on the undo redo actions.

```csharp

@using Syncfusion.Blazor.PdfViewer
@using Syncfusion.Blazor.PdfViewerServer
@using Syncfusion.Blazor.Buttons

@if (canUndo)
{
    <button @onclick="undo">Undo</button>
}
else
{
    <button @onclick="undo" disabled>Undo</button>
}
@if (canRedo)
{
    <button @onclick="redo">Redo</button>
}
else
{
    <button @onclick="redo" disabled>Redo</button>
}
<SfPdfViewerServer @ref="@viewer"
                   @bind-CanUndo="@canUndo"
                   @bind-CanRedo="@canRedo"
                   DocumentPath="@DocumentPath"
                   Height="540px"
                   Width="100%">
</SfPdfViewerServer>

@code 
{
    SfPdfViewerServer viewer;
    bool canUndo = true;
    bool canRedo = true;
    private string DocumentPath { get; set; } = "wwwroot/Data/PDF_Succinctly.pdf";
    
    // Event triggers while clicking the undo button.
    private async Task undo()
    {
        // API to perform Undo action.
        await viewer.UndoAsync();
    }

    // Event triggers while clicking the redo button.
    private async Task redo()
    {
        // API to perform Undo action.
        await viewer.RedoAsync();
    }
}

```