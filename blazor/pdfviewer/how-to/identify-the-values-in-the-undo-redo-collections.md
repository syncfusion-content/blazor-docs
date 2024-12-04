---
layout: post
title: Identify if the Viewer has values in the Undo, Redo stack | Syncfusion&reg;
description: Learn how to identify if the Viewer has values in Undo, Redo stack in Syncfusion&reg; Blazor PDF Viewer component and more.
platform: Blazor
control: PDF Viewer
documentation: ug
---

# Identify if the PDF Viewer has values in the Undo, Redo collections

Syncfusion&reg; Blazor PDF Viewer component allows you to identify if the PDF Viewer has values in the Undo and Redo collections using the `CanUndo` and `CanRedo` APIs of the PDF Viewer.

The following code example shows how to achieve this based on the Undo Redo actions.

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
    
    // Event triggers on Undo button click.
    private async Task undo()
    {
        // API to perform Undo action.
        await viewer.UndoAsync();
    }

    // Event triggers on Redo button click.
    private async Task redo()
    {
        // API to perform Redo action.
        await viewer.RedoAsync();
    }
}

```