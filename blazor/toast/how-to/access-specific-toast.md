---
layout: post
title: Access specific toast in Blazor Toast Component | Syncfusion
description: Checkout and learn here all about access specific toast in Syncfusion Blazor Toast component and more.
platform: Blazor
control: Toast
documentation: ug
---

# Access specific toast in Blazor Toast Component

This section describes how to address an individual toast instance in the Syncfusion Blazor Toast component by assigning a unique key when showing a toast, and how to close that specific toast programmatically by passing the same key to the hide method.

A unique identifier can be provided via the Toast model’s **Key** when calling **ShowAsync**. The same key can be supplied to **HideAsync** to close a specific toast. The assigned key is available in the **Opened** and **Closed** events through their event arguments for event-driven control. For more information, refer to:
- SfToast component: https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Notifications.SfToast.html
- ToastModel: https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Notifications.ToastModel.html

```cshtml
@using Syncfusion.Blazor.Notifications

<div id="target">
    <SfToast @ref="toast"
             ShowCloseButton="true"
             Height="150px"
             Width="200px"
             Timeout="6000"
             Target="@target"
             Icon="e-meeting"
             Title="@title">
        <ToastEvents Opened="OnOpened"></ToastEvents>
    </SfToast>

    <div class="col-lg-12 col-sm-12 col-md-12 center">
        <div id="toastBtnContainer" style="margin: auto; text-align: center">
            <button class="e-btn" id="toastBtnShow" @onclick="ShowOnClick">Show Toast</button>
            <button class="e-btn" id="toastBtnHideAll" @onclick="HideAllOnClick">Hide All</button>
            <button class="e-btn" id="toastBtnHideOne" @onclick="HideOneOnClick">Hide Last Created</button>
        </div>
    </div>
</div>

<style>
    #toast_default .e-meeting::before {
        content: "\e705";
        font-size: 17px;
    }
</style>

@code {
    private SfToast toast;

    private string target = "#target";
    private string title = "This is Toast Title";

    // Monotonically increasing key for each toast instance created via ShowAsync
    private int key = 0;

    // Stores the last created key for demonstration of targeted hide
    private int? lastCreatedKey = null;

    private async Task ShowOnClick()
    {
        await toast.ShowAsync(new ToastModel { Key = key, Content = $"Toast Key: {key}", Timeout = 10000 });
        lastCreatedKey = key;
        key++;
    }

    // Event-driven example: close the toast immediately after it opens using the event's key
    private async Task OnOpened(ToastOpenArgs args)
    {
        // Demonstrates closing a specific toast via its assigned key
        await toast.HideAsync(args.Key);
    }

    // Hides all toasts
    private async Task HideAllOnClick()
    {
        await toast.HideAsync();
    }

    // Hides the most recently created toast (if tracked)
    private async Task HideOneOnClick()
    {
        if (lastCreatedKey.HasValue)
        {
            await toast.HideAsync(lastCreatedKey.Value);
        }
    }
}
```

Preview of the code snippet:
- Clicking “Show Toast” displays a toast with the content “Toast Key: N”, where N is the unique key assigned to that instance.
- Because the Opened event immediately calls HideAsync with the event’s key, each toast closes as soon as it opens (demonstrating targeted close).
- Clicking “Hide All” closes all active toasts.
- Clicking “Hide Last Created” attempts to close only the most recently created toast using the stored key.
