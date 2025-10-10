---
layout: post
title: Multiple toasts in various positions using Blazor Toast | Syncfusion
description: Learn here all about how to show multiple toasts in various positions in Syncfusion Blazor Toast component and more.
platform: Blazor
control: Toast
documentation: ug
---

# Show multiple toasts in various positions in Blazor Toast Component

To display toasts in different positions at the same time, create multiple **SfToast** instances, each configured with its own **ToastPosition**. Each toast instance manages its own queue and position independently. Changing the position affects only toasts created after the change; toasts that are already visible are not repositioned.

For more details, see:
- Blazor Toast overview: https://blazor.syncfusion.com/documentation/toast/
- Toast position: https://blazor.syncfusion.com/documentation/toast/position
- Toast events: https://blazor.syncfusion.com/documentation/toast/events/

```cshtml
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Notifications

<SfToast @ref="WarningToastObj" Title="Warning" Content="@WarningContent">
    <ToastPosition X="Right" Y="Bottom"></ToastPosition>
    <ToastEvents OnClick="@ToastClick"></ToastEvents>
</SfToast>

<SfToast @ref="SuccessToastObj" Title="Success" Content="@SuccessContent">
    <ToastPosition X="Left" Y="Bottom"></ToastPosition>
    <ToastEvents OnClick="@ToastClick"></ToastEvents>
</SfToast>

<div class="col-lg-12 col-sm-12 col-md-12 center">
    <div style="margin: auto; text-align: center">
        <SfButton OnClick="@ShowWarningToast">Show Warning Toast</SfButton>
        <SfButton OnClick="@ShowSuccessToast">Show Success Toast</SfButton>
    </div>
</div>

@code {
    private SfToast WarningToastObj;
    private SfToast SuccessToastObj;

    private string SuccessContent { get; set; } = "The message has been sent successfully.";
    private string WarningContent { get; set; } = "There was a problem with the network connection.";

    private void ToastClick(ToastClickEventArgs args)
    {
        args.ClickToClose = true;
    }

    private async Task ShowWarningToast()
    {
        await WarningToastObj.ShowAsync();
    }

    private async Task ShowSuccessToast()
    {
        await SuccessToastObj.ShowAsync();
    }
}
```

Preview of the code snippet:
- Selecting Show Warning Toast displays a toast at the bottom-right, while Show Success Toast displays a toast at the bottom-left.
- Each toast instance maintains its own queue and position. Changing position configuration affects only subsequently shown toasts.