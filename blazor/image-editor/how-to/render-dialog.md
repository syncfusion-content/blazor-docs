---
layout: post
title: Clear an Image with Blazor Image Editor Component | Syncfusion
description: Learn here all about Clear an Image in Blazor Image Editor component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: Image Editor
documentation: ug
---

# Render Image Editor in Dialog Component

Rendering the Image Editor in a dialog involves displaying the image editor component within a modal dialog window, allowing users to edit images in a pop-up interface. This can be useful for maintaining a clean layout and providing a focused editing experience without navigating away from the current page.

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
 <SfDialog Height="75%" Width="435px" Target="#target" ShowCloseIcon="true" @bind-Visible="Visibility">
    <DialogTemplates>
        <Content>
            <div class="dialogContent">
                <SfImageEditor @ref="ImageEditor" Height="400px">
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

    private async void OpenDialogAsync() 
    { 
        this.Visibility = true;
    }

    private async void OpenAsync() 
    { 
        await ImageEditor.OpenAsync("https://ej2.syncfusion.com/react/demos/src/image-editor/images/bridge.png"); 
    }

    private void BeforeDialogOpen(BeforeOpenEventArgs args)
    {
        this.ShowButton = false;
    }

    private void DialogClosed(CloseEventArgs args)
    {
        this.ShowButton = true;
    }
}
```

![Blazor Image Editor with Resize the custom selection](../images/blazor-image-editor-dialog.jpg)