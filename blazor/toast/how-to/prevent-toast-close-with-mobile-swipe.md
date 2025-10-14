---
layout: post
title: Prevent toast close with mobile swipe in Blazor Toast | Syncfusion
description: Learn here all about how to prevent toast close with mobile swipe in Syncfusion Blazor Toast component and more.
platform: Blazor
control: Toast
documentation: ug
---

# Prevent toast close with mobile swipe in Blazor Toast Component
This page explains how to prevent a toast from closing when swiped on mobile devices using the Syncfusion Blazor Toast component. The approach cancels only swipe-initiated dismissal; other close actions (such as Timeout, close button, or programmatic HideAsync) continue to work unless handled separately.

To prevent swipe-based dismissal, handle the **BeforeClose** event and set the event argument’s **Cancel** property to true when the **RequestType** equals "swipe". For details, refer to the component documentation and API:
- Blazor Toast overview: https://blazor.syncfusion.com/documentation/toast/
- Toast events: https://blazor.syncfusion.com/documentation/toast/events/
- ToastBeforeCloseArgs API: https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Notifications.ToastBeforeCloseArgs.html

```cshtml
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Notifications

<SfToast @ref="ToastRef" Title="Adaptive Tiles Meeting" Content="@ToastContent">
    <ToastEvents BeforeClose="OnBeforeClose"></ToastEvents>
    <ToastPosition X="Center"></ToastPosition>
</SfToast>

<div class="col-lg-12 col-sm-12 col-md-12 center">
    <div id="toastBtnDefault" style="margin:auto; text-align:center">
        <SfButton OnClick="ShowToast">Show Toast</SfButton>
    </div>
</div>

@code {
    private SfToast ToastRef;
    private string ToastContent = "Conference Room 01 / Building 135 10:00 AM–10:30 AM";

    private async Task ShowToast()
    {
        await ToastRef.ShowAsync();
    }

    private void OnBeforeClose(ToastBeforeCloseArgs args)
    {
        if (args.RequestType == "swipe")
        {
            args.Cancel = true;
        }
    }
}
```

Preview of the code snippet:
- Swiping over the toast on a mobile device does not close the toast.
- Other dismissal triggers (Timeout, close button, HideAsync) still close the toast as expected.