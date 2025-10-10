---
layout: post
title: Show different types of toast in Blazor Toast Component | Syncfusion
description: Checkout and learn here all about how to show different types of toast in Syncfusion Blazor Toast component and more.
platform: Blazor
control: Toast
documentation: ug
---

# Show different types of toast in Blazor Toast Component

The Blazor Toast component provides predefined visual styles that can be applied using the **CssClass** property to represent different notification types. These styles help convey status and intent consistently across an application.

For more details, see:
- Blazor Toast overview: https://blazor.syncfusion.com/documentation/toast/
- SfToast CssClass API: https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Notifications.SfToast.html#Syncfusion_Blazor_Notifications_SfToast_CssClass

| Class | Description |
| -------- | -------- |
| `e-toast-success` | Indicates a successful or completed action |
| `e-toast-info` | Conveys informational or neutral messages |
| `e-toast-warning` | Highlights cautionary messages that may require attention |
| `e-toast-danger` | Signals errors or critical issues |

These classes style the toast appearance and can be combined with other custom classes as needed. Behavior such as **Timeout**, position, and content is configured independently.

```cshtml
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Notifications

<SfToast @ref="ToastObj" Title="@ToastTitle" Content="@ToastContent" CssClass="@ToastCssClass">
    <ToastPosition X="Right" Y="Bottom"></ToastPosition>
</SfToast>

<div class="col-lg-12 col-sm-12 col-md-12 center">
    <div style="margin: auto; text-align: center">
        <SfButton OnClick="ShowToast">Show Toast</SfButton>
    </div>
</div>

@code {
    private SfToast ToastObj;

    private int ToastFlag = 0;
    private string ToastTitle = string.Empty;
    private string ToastContent = string.Empty;
    private string ToastCssClass = string.Empty;

    private class ToastOption
    {
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string CssClass { get; set; } = string.Empty;
    }

    private readonly ToastOption[] Toasts = new ToastOption[] {
        new ToastOption { Title = "Warning",      Content = "There was a problem with the network connection.",            CssClass = "e-toast-warning" },
        new ToastOption { Title = "Success",      Content = "The message has been sent successfully.",                     CssClass = "e-toast-success" },
        new ToastOption { Title = "Error",        Content = "A problem occurred while submitting the data.",               CssClass = "e-toast-danger" },
        new ToastOption { Title = "Information",  Content = "Please read the comments carefully.",                         CssClass = "e-toast-info" }
    };

    private async Task ShowToast()
    {
        ToastTitle = Toasts[ToastFlag].Title;
        ToastContent = Toasts[ToastFlag].Content;
        ToastCssClass = Toasts[ToastFlag].CssClass;

        await ToastObj.ShowAsync();

        ToastFlag = (ToastFlag == Toasts.Length - 1) ? 0 : (ToastFlag + 1);
    }
}
```

Preview of the code snippet:
- Selecting Show Toast displays a toast using one of the predefined visual styles (success, info, warning, or danger).
- Each click cycles through the styles, demonstrating how the **CssClass** property changes appearance while behavior (position, content, and timeout) remains independent.