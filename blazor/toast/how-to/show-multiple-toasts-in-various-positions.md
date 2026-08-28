---
layout: post
title: How to show toasts at various positions in Blazor Toast | Syncfusion
description: Display multiple Blazor Toast notifications at different positions by creating separate toast instances.
platform: Blazor
control: Toast
documentation: ug
---

# How to show toasts at various positions in Blazor Toast

By default, the positions of the new toasts are only updated after the visible toasts have been destroyed. If there is a need to display multiple toasts with different positions, initiate another toast.

The following sample demonstrates adding multiple toasts in different positions.

```cshtml

@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Notifications

<SfToast @ref="WarningToastObj" Title="Warning !" Content="@WarningContent">
    <ToastPosition X="Right" Y="Bottom"></ToastPosition>
    <ToastEvents OnClick="@ToastClick"></ToastEvents>
</SfToast>

<SfToast @ref="SuccessToastObj" Title="Success !" Content="@SuccessContent">
    <ToastPosition X="Left" Y="Bottom"></ToastPosition>
    <ToastEvents OnClick="@ToastClick"></ToastEvents>
</SfToast>

<div class="col-lg-12 col-sm-12 col-md-12 center">
    <div style="margin: auto; text-align: center">
        <SfButton @onclick="@ShowWarningToast"> Show Warning Toast </SfButton>
        <SfButton @onclick="@ShowSuccessToast"> Show Success Toast </SfButton>
    </div>
</div>

@code {
    SfToast WarningToastObj;
    SfToast SuccessToastObj;

    private string SuccessContent { get; set; } = "Your message has been sent successfully.";
    private string WarningContent { get; set; } = "There was a problem with your network connection.";

    private void ToastClick(ToastClickEventArgs args)
    {
        args.ClickToClose = true;
    }

    private async Task ShowWarningToast()
    {
       await this.WarningToastObj.ShowAsync();
    }

    private async Task ShowSuccessToast()
    {
        await this.SuccessToastObj.ShowAsync();
    }
}

```