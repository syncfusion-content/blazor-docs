---
layout: post
title: How to Close Dialog While Click On Outside Of Dialog in Blazor Dialog Component | Syncfusion
description: Checkout and learn about Close Dialog While Click On Outside Of Dialog in Blazor Dialog component of Syncfusion, and more details.
platform: Blazor
control: Dialog
documentation: ug
---

# Close dialog while click on outside of dialog

By default, dialog can be closed by pressing `Esc` key and clicking the close icon at the right of dialog header. It can also be closed by clicking outside of the dialog using `Visible` property.
Set the `CloseOnEscape` property value to `false` to prevent closing of the dialog when pressing `Esc` key.

In the following code, dialog is closed when clicking outside the dialog area using `Visible` property.

```csharp

@using Syncfusion.Blazor.Popups
@using Syncfusion.Blazor.Buttons

<SfButton @onclick="@OpenDialog">Open Dialog</SfButton>

<div id="target">
    <SfDialog Target="#target" Width="300px" IsModal="true" ShowCloseIcon="true" CloseOnEscape="false" @bind-Visible="@IsVisible">
        <DialogEvents OnOverlayClick="@OverlayClick"></DialogEvents>
        <DialogTemplates>
            <Header> Delete Multiple Items</Header>
            <Content> Are you sure you want to permanently delete all of these items? </Content>
        </DialogTemplates>
        <DialogButtons>
            <DialogButton Content="Yes" IsPrimary="true" OnClick="@CloseDialog" />
            <DialogButton Content="No" OnClick="@CloseDialog" />
        </DialogButtons>
    </SfDialog>
</div>

<style>
    #target {
        min-height: 450px;
        height: 100%;
    }
</style>

@code {
    private bool IsVisible { get; set; } = true;

    private void OpenDialog()
    {
        this.IsVisible = true;
    }

    private void OverlayClick(MouseEventArgs args)
    {
        this.IsVisible = false;
    }
}

```