---
layout: post
title: Show toast content dynamically in Blazor Toast Component | Syncfusion
description: Checkout and learn here all about how to show toast content dynamically in Syncfusion Blazor Toast component and more.
platform: Blazor
control: Toast
documentation: ug
---

# Show toast content dynamically in Blazor Toast Component

This page explains how to update toast content dynamically for newly displayed toasts in the Syncfusion Blazor Toast component.

The **SfToast** component supports updating its **Content** parameter dynamically. Set or update the bound **Content** value before calling **ShowAsync** so each newly displayed toast reflects the latest message. If the content is changed immediately prior to showing a toast, a brief delay can ensure the state is applied before invoking **ShowAsync**.

- Component overview: https://blazor.syncfusion.com/documentation/toast/
- API reference (SfToast): https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Notifications.SfToast.html

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
    private string ToastContent = string.Empty;
    private readonly string[] Contents = new string[] {
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
Preview of the code snippet:
- Clicking the “Show Toast” button displays a toast at the bottom-right of the page.
- Each click cycles through the predefined messages (for example: “Welcome User”, “Upload in progress”, “Upload success”).
- The toast title is “Alert” and the body content reflects the latest value assigned to the **Content** parameter prior to calling **ShowAsync**.