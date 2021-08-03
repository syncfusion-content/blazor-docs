---
layout: post
title: How to Model Dialog With Rte in Blazor Dialog Component | Syncfusion
description: Checkout and learn about Model Dialog With Rte in Blazor Dialog component of Syncfusion, and more details.
platform: Blazor
control: Dialog
documentation: ug
---

# Render model dialog with Rich Text Editor

This section explains how to render model dialog with the Rich Text Editor component. when you render model dialog with the Rich Text Editor component, the first row of the content will be hidden because the dialog container and its wrapper elements are styled with display as none. so, the editor’s toolbar does not get proper offset width and rendered above the edit area container. In this scenario, we could use the `refreshUI` method on the Dialog `open` event.

```cshtml

@using Syncfusion.Blazor.Popups
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.RichTextEditor

<SfButton @onclick="@OpenDialog">Open Modal Dialog</SfButton>

<SfDialog Width="500px" IsModal="true" @bind-Visible="@IsVisible">
    <DialogEvents OnOverlayClick="@OnOverlayclick" Opened="@DialogOpen">
    </DialogEvents>
    <DialogTemplates>
        <Content>
            <SfRichTextEditor @ref="RteObj"></SfRichTextEditor>
        </Content>
    </DialogTemplates>
</SfDialog>

@code {
    SfRichTextEditor RteObj;

    private bool IsVisible { get; set; } = true;

    private void OpenDialog()
    {
        this.IsVisible = true;
    }

    private void OnOverlayclick(MouseEventArgs arg)
    {
        this.IsVisible = false;
    }
    private void DialogOpen()
    {
        this.RteObj.RefreshUIAsync();
    }
}

```