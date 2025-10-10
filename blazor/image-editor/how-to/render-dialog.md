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
    @if (this.ShowButton)
    {
        <SfButton OnClick="OpenDialogAsync">Open Image</SfButton>
    }
</div>

<SfDialog MinHeight="400px" Width="340px" Target="#target" ShowCloseIcon="true" @bind-Visible="Visibility">
    <DialogTemplates>
        <Content>
            <div class="dialogContent">
                <SfImageEditor @ref="ImageEditor" Height="300px">
                </SfImageEditor>
            </div>
        </Content>
    </DialogTemplates>
    <DialogEvents OnOpen="@BeforeDialogOpen" Opened="OpenAsync" Closed="@DialogClosed"></DialogEvents>
</SfDialog>

@code {
    private bool Visibility { get; set; } = false;
    private bool ShowButton { get; set; } = true;
    SfImageEditor ImageEditor;

    private void OpenDialogAsync()
    {
        this.Visibility = true;
    }

    private async void OpenAsync()
    {
        await ImageEditor.OpenAsync("https://ej2.syncfusion.com/react/demos/src/image-editor/images/bridge.png");
        ImageEditor.RefreshAsync();
    }

    private void BeforeDialogOpen(Syncfusion.Blazor.Popups.BeforeOpenEventArgs args)
    {
        this.ShowButton = false;
    }

    private void DialogClosed(Syncfusion.Blazor.Popups.CloseEventArgs args)
    {
        this.ShowButton = true;
    }
}
```

![Blazor Image Editor rendered in a dialog](../images/blazor-image-editor-dialog.jpg)