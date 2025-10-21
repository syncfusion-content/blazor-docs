---
layout: post
title: Undo and Redo with Blazor Image Editor Component | Syncfusion
description: Explore undo and redo features in the Blazor Image Editor component for Blazor Server and WebAssembly applications.
platform: Blazor
control: Image Editor
documentation: ug
---

# Undo and redo in the Blazor Image Editor component

The undo and redo functionalities enable reversing and reapplying editing actions performed on an image. These capabilities are essential for maintaining control and flexibility during the editing process.

In the Blazor Image Editor component, the undo and redo history has a fixed capacity of 16 steps. The editor tracks the most recent 16 actions performed on the image. When the history reaches its maximum capacity, any new action removes the oldest action from the history.

## Undo the action

The undo action reverts the most recent editing action or a series of actions to their previous state. When the undo command is triggered, the image editor undoes the last applied modification, restoring the image to its prior state. The undo action is useful for correcting mistakes, removing unwanted changes, or testing different editing options without permanently altering the image.

## Redo the action

The redo action reapplies previously undone actions or modifications to the image. When the redo command is triggered, the image editor reapplies the last action that was undone, returning the image to the state it was in after the action was initially applied. The redo action is useful for repeating an action that was previously undone or restoring changes that were temporarily reversed.

Here is an example of undoing and redoing the action using the [UndoAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.SfImageEditor.html#Syncfusion_Blazor_ImageEditor_SfImageEditor_UndoAsync) and [RedoAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.SfImageEditor.html#Syncfusion_Blazor_ImageEditor_SfImageEditor_RedoAsync) method.

```cshtml
@using Syncfusion.Blazor.ImageEditor
@using Syncfusion.Blazor.Buttons

<div style="padding-bottom: 15px">
    <SfButton OnClick="DrawTextAsync">Draw Text</SfButton>
    <SfButton OnClick="UndoAsync">Undo</SfButton>
    <SfButton OnClick="RedoAsync">Redo</SfButton>
</div>

<SfImageEditor @ref="ImageEditor" Toolbar="customToolbarItem" Height="400">
    <ImageEditorEvents Created="OpenAsync"></ImageEditorEvents>
</SfImageEditor>

@code {
    SfImageEditor ImageEditor;
    private List<ImageEditorToolbarItemModel> customToolbarItem = new List<ImageEditorToolbarItemModel>() { };

    private async void OpenAsync()
    {
        await ImageEditor.OpenAsync("https://ej2.syncfusion.com/react/demos/src/image-editor/images/bridge.png");
    }

    private async void DrawTextAsync()
    {
        ImageDimension Dimension = await ImageEditor.GetImageDimensionAsync();
        await ImageEditor.DrawTextAsync(Dimension.X.Value + 100, Dimension.Y.Value + 100);
    }

    private async void UndoAsync()
    {
        await ImageEditor.UndoAsync();
    }

    private async void RedoAsync()
    {
        await ImageEditor.RedoAsync();
    }
}
```

![Blazor Image Editor showing undo and redo actions](./images/blazor-image-editor-undo-redo.jpg)
