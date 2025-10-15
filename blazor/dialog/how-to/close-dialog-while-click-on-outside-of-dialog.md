---
layout: post
title: Close Blazor Dialog when clicking outside of its region | Syncfusion
description: Learn here all about closing the Blazor Dialog Component when clicking outside of its region and more.
platform: Blazor
control: Dialog
documentation: ug
---

# Close Blazor Dialog Component When Clicking Outside of Its Region

By default, the Dialog can be closed by pressing `Esc` key or by clicking the close icon on the right side of the Dialog header. It can also be closed by clicking outside of the Dialog using `Visible` property. Set the `CloseOnEscape` property value to `false` to prevent closing of the dialog when pressing `Esc` key.

The following example closes the Dialog when the overlay is clicked by handling the `OnOverlayModalClick` event and setting the bound `Visible` property to `false`.

N> The [OnOverlayModalClick](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.DialogEvents.html#Syncfusion_Blazor_Popups_DialogEvents_OnOverlayModalClick) event will only be triggered if the [IsModal](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.SfDialog.html#Syncfusion_Blazor_Popups_SfDialog_IsModal) property is set to `true`.

```cshtml

@using Syncfusion.Blazor.Popups
@using Syncfusion.Blazor.Buttons

<SfButton @onclick="@OpenDialog">Open Dialog</SfButton>

<div id="target">
    <SfDialog Target="#target" Width="300px" IsModal="true" ShowCloseIcon="true" CloseOnEscape="false" @bind-Visible="@IsVisible">
        <DialogEvents OnOverlayModalClick="@OverlayClick"></DialogEvents>
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

    private void OverlayClick(OverlayModalClickEventArgs args)
    {
        this.IsVisible = false;
    }

    private void CloseDialog()
    {
        this.IsVisible = false;
    }
}

```