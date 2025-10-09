---
layout: post
title: Close the toast with click/tap in Blazor Toast Component | Syncfusion
description: Checkout and learn here all about how to close the toast with click/tap in Syncfusion Blazor Toast component and more.
platform: Blazor
control: Toast
documentation: ug
---

# Close the toast with click/tap in Blazor Toast Component

By default, toasts automatically close based on the Timeout value. To close a toast when it is clicked or tapped, handle the OnClick event and set ClickToClose to true in the ToastClickEventArgs. To require user-initiated dismissal only, set Timeout to 0 to create a sticky toast and use click or tap to close it.

The following sample demonstrates closing a toast through a click or tap action.

```cshtml

@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Notifications

<SfToast @ref="ToastObj" Title="Alert" Content="@ToastContent">
    <ToastEvents OnClick="@OnClickHandler"></ToastEvents>
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
    
    public void OnClickHandler(ToastClickEventArgs args)
    {
        args.ClickToClose = true;
    }
}

```