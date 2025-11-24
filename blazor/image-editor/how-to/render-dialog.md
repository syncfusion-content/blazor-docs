---
layout: post
title: Render Image Editor in a Dialog Component | Syncfusion
description: Render the Blazor Image Editor in a modal dialog for a focused, space-saving editing experience in Blazor Server and WebAssembly applications.
platform: Blazor
control: Image Editor
documentation: ug
---

# Render Image Editor in Dialog Component

Rendering the Image Editor in a dialog displays the component within a modal window, enabling image editing in a pop-up interface. This approach helps maintain a clean layout and provides a focused editing experience without navigating away from the current page.

```cshtml
@using Syncfusion.Blazor.ImageEditor
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Popups
@using Syncfusion.Blazor.Inputs

<div style="padding-bottom: 15px">
    <SfButton OnClick="OpenDialog">Edit Image</SfButton>
</div>

<div class="control-section" id="target" style="height: 500px">
    <SfDialog Width="600px" Height="500px" Target="#target" ShowCloseIcon="true" @bind-Visible="IsDialogVisible">
        <DialogEvents Opened="OnDialogOpened" Closed="OnDialogClosed"></DialogEvents>
        <DialogTemplates>
            <Content>
                <div class="dialog-content">
                    @if (IsImageEditorOpened)
                    {
                        <SfImageEditor @ref="ImageEditor" Height="400px">
                            <ImageEditorEvents Created="OnImageEditorCreated"></ImageEditorEvents>
                        </SfImageEditor>
                    }
                </div>
            </Content>
        </DialogTemplates>
    </SfDialog>
</div>

@code {
    private bool IsDialogVisible { get; set; } = false;
    private bool IsImageEditorOpened { get; set; } = false;
    private SfImageEditor ImageEditor;

    private void OpenDialog()
    {
        IsDialogVisible = true;
    }

    private void OnDialogOpened()
    {
        IsImageEditorOpened = true;
    }

    private void OnDialogClosed()
    {
        IsImageEditorOpened = false;
    }

    private async void OnImageEditorCreated()
    {
        await ImageEditor.OpenAsync("https://ej2.syncfusion.com/react/demos/src/image-editor/images/bridge.png");
    }
}
```

![Blazor Image Editor rendered in a dialog](../images/blazor-image-editor-dialog.jpg)