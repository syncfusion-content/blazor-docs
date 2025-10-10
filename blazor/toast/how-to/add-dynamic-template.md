---
layout: post
title: Add dynamic template in Blazor Toast Component | Syncfusion
description: Checkout and learn here all about how to add dynamic template in Syncfusion Blazor Toast component and more.
platform: Blazor
control: Toast
documentation: ug
---

# Add dynamic template in Blazor Toast Component

The Syncfusion Blazor Toast component supports rendering dynamic templates for individual notifications. Provide a **ContentTemplate** in the **ToastModel** passed to **ShowAsync** to display a unique template for each toast. Toast properties can also be customized per toast when invoking **ShowAsync**, enabling different content and appearance across multiple toasts shown in sequence.

- Component: SfToast — https://blazor.syncfusion.com/documentation/api/syncfusion.blazor.notifications/sftoast
- Model: ToastModel — https://blazor.syncfusion.com/documentation/api/syncfusion.blazor.notifications/toastmodel
- Method: ShowAsync — see methods on SfToast page above
- Position: ToastPosition — https://blazor.syncfusion.com/documentation/api/syncfusion.blazor.notifications/toastposition

```cshtml
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Notifications

<SfToast @ref="ToastObj">
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

    private ToastModel[] Messages = new ToastModel[] {
        new ToastModel() { ContentTemplate = @<p>2 Mail has received</p> },
        new ToastModel() { ContentTemplate = @<p>User Guest Logged in</p> },
        new ToastModel() { ContentTemplate = @<p>Logging in as Guest</p> },
        new ToastModel() { ContentTemplate = @<p>Ticket has reserved</p> }
    };

    private async Task ShowToast()
    {
        // Optional short delay ensures dynamically changed toast properties are applied before showing.
        await Task.Delay(100);
        await ToastObj.ShowAsync(Messages[ToastFlag]);
        ToastFlag = (ToastFlag == Messages.Length - 1) ? 0 : (ToastFlag + 1);
    }
}
```

Preview of the code snippet:
- Clicking the Show Toast button displays a toast in the bottom-right corner of the page.
- Each click cycles through the predefined dynamic templates, showing messages such as:
  - “2 Mail has received”
  - “User Guest Logged in”
  - “Logging in as Guest”
  - “Ticket has reserved”
- The toast position is set to Right-Bottom via ToastPosition.