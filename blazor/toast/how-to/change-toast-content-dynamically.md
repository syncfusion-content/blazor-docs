---
layout: post
title: Show toast content dynamically in Blazor Toast Component | Syncfusion
description: Checkout and learn here all about how to show toast content dynamically in Syncfusion Blazor Toast component and more.
platform: Blazor
control: Toast
documentation: ug
---

# Show toast content dynamically in Blazor Toast Component

The Blazor Toast component supports updating its content dynamically for newly displayed toasts. Update the bound Content value before invoking ShowAsync so that each toast reflects the latest content. If the content is changed immediately before showing a toast, a brief delay may be used to ensure the state update is applied prior to the ShowAsync call.

```cshtml

@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Notifications

<SfToast @ref="ToastObj" Title="Alert" Content="@ToastContent">
    <ToastPosition X="Right" Y="Bottom"></ToastPosition>
</SfToast>

<div class="col-lg-12 col-sm-12 col-md-12 center">
    <div style="margin: auto; text-align: center">
        <SfButton @onclick="@ShowToast"> Show Toast </SfButton>
    </div>
</div>

@code {
    SfToast ToastObj;

    private int ToastFlag = 0;
    private string ToastContent = "";
    private string[] Contents = new string[] {
        "Welcome User",
        "Upload in progress",
        "Upload success",
        "Profile updated",
        "Profile picture changed",
        "Password changed"
    };

    private async Task ShowToast()
    {
        this.ToastContent = this.Contents[this.ToastFlag];
        await Task.Delay(100);
        await this.ToastObj.ShowAsync();
        this.ToastFlag = ((this.ToastFlag != 5) ? (this.ToastFlag + 1) : 0);
    }
}

```