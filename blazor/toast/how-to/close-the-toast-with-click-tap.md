---
layout: post
title: How to Close The Toast With Click Tap in Blazor Toast Component | Syncfusion
description: Checkout and learn about Close The Toast With Click Tap in Blazor Toast component of Syncfusion, and more details.
platform: Blazor
control: Toast
documentation: ug
---

# Close the toast with click/tap

By default, the toasts are expired based on the `Timeout` value. You can customize the toast hiding process with click/tap action by setting the `ToastClickEventArgs` in the clicked callback function with static Toast.

The following sample demonstrates the click/tap action in toast.

```csharp

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