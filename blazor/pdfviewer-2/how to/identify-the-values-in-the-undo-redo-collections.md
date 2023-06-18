---
layout: post
title: Identify if the Viewer has values in the Undo, Redo stack | Syncfusion
description: Learn how to identify if the Viewer has values in Undo, Redo stack in Syncfusion Blazor SfPdfViewer component and more.
platform: Blazor
control: SfPdfViewer
documentation: ug
---

# Identify if the SfPdfViewer has values in the Undo, Redo collections

Syncfusion's Blazor SfPdfViewer component allows you to identify if the SfPdfViewer has values in the Undo and Redo collections using the `CanUndo` and `CanRedo` APIs of the SfPdfViewer.

The following code example shows how to achieve this based on the Undo Redo actions.

```csharp

@using Syncfusion.Blazor.SfPdfViewer
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
<SfPdfViewer2 @ref="@viewer"
                   @bind-CanUndo="@canUndo"
                   @bind-CanRedo="@canRedo"
                   DocumentPath="@DocumentPath"
                   Height="540px"
                   Width="100%">
</SfPdfViewer2>

@code 
{
    SfPdfViewer2 viewer;
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

[View Sample in GitHub](https://github.com/SyncfusionExamples/blazor-pdf-viewer-examples/tree/master/Common/Prevent%20the%20PDF%20from%20scrolling)