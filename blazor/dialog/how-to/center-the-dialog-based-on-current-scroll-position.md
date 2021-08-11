---
layout: post
title: How to Center The Dialog Based On Current Scroll Position in Blazor Dialog Component | Syncfusion
description: Checkout and learn about Center The Dialog Based On Current Scroll Position in Blazor Dialog component of Syncfusion, and more details.
platform: Blazor
control: Dialog
documentation: ug
---

# Center the dialog based on the current scroll position

The dialog is always centered based on the target container. If the target is not specified, then the dialog will be rendered based on its body and centered in the position of the current viewpoint.

In the following sample, the model dialog is centered based on its current scroll position of the page.

```cshtml

@using Syncfusion.Blazor.Popups
@using Syncfusion.Blazor.Buttons

<SfButton @onclick="@OpenDialog">Open Modal Dialog</SfButton>

<SfDialog Width="250px" IsModal="true" CssClass="e-fixed" @bind-Visible="@IsVisible">
    <DialogEvents OnOverlayClick="@OnOverlayclick">
    </DialogEvents>
    <DialogTemplates>
        <Content> This is a modal dialog </Content>
    </DialogTemplates>
    <DialogButtons>
        <DialogButton Content="OK" IsPrimary="true" OnClick="@CloseDialog" />
        <DialogButton Content="Cancel" OnClick="@CloseDialog" />
    </DialogButtons>
</SfDialog>

@code {
    private bool IsVisible { get; set; } = true;

    private void OpenDialog()
    {
        this.IsVisible = true;
    }

    private void OnOverlayclick(MouseEventArgs arg)
    {
        this.IsVisible = false;
    }
    private void CloseDialog()
    {
        this.IsVisible = false;
    }
}
<style>
    body{
        height: 1200px;
    }
</style>

```
