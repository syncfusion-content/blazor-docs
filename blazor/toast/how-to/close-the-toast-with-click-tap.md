---
layout: post
title: Close the toast with click/tap in Blazor Toast Component | Syncfusion
description: Checkout and learn here all about how to close the toast with click/tap in Syncfusion Blazor Toast component and more.
platform: Blazor
control: Toast
documentation: ug
---

# Close the toast with click/tap in Blazor Toast Component

By default, toasts automatically close based on the **TimeOut** value. To close a toast when it is clicked or tapped, handle the **OnClick** event and set **ClickToClose** to true in the **ToastClickEventArgs**. To require user-initiated dismissal only, set **TimeOut** to 0 to create a sticky toast and use click or tap to close it.

- Component overview: https://blazor.syncfusion.com/documentation/toast/
- API reference (SfToast): https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Notifications.SfToast.html
- API reference (ToastEvents): https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Notifications.ToastEvents.html
- API reference (ToastClickEventArgs): https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Notifications.ToastClickEventArgs.html

```cshtml
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Notifications

<SfToast @ref="ToastObj" Title="Alert" Content="@ToastContent" TimeOut="0">
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
        ToastContent = Contents[ToastFlag];
        await Task.Delay(100);
        await ToastObj.ShowAsync();
        ToastFlag = (ToastFlag != Contents.Length - 1) ? (ToastFlag + 1) : 0;
    }
    
    public void OnClickHandler(ToastClickEventArgs args)
    {
        args.ClickToClose = true;
    }
}
```

Preview of the code snippet:
- Clicking the “Show Toast” button displays a sticky toast (TimeOut = 0) at the bottom-right of the page.
- Each click cycles through predefined messages (for example: “Welcome User”, “Upload in progress”, “Upload success”).
- Clicking or tapping the toast closes it immediately because **ClickToClose** is enabled via the **OnClick** event.