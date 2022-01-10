---
layout: post
title: Render Model Dialog with Rte in Blazor Dialog Component | Syncfusion
description: Checkout and learn here all about Model Dialog with Rte in Syncfusion Blazor Dialog component and more.
platform: Blazor
control: Dialog
documentation: ug
---

# Render Model Dialog with Rich Text Editor

This section explains how to render model dialog with the Rich Text Editor component. When you render model dialog with the Rich Text Editor component, the first row of the content will be hidden because the dialog container and its wrapper elements are styled with display as none. So, the editor’s toolbar does not get proper offset width and rendered above the edit area container. In this scenario, you can use the `refreshUI` method on the Dialog `open` event.

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