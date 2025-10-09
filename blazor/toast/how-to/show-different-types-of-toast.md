---
layout: post
title: Show different types of toast in Blazor Toast Component | Syncfusion
description: Checkout and learn here all about how to show different types of toast in Syncfusion Blazor Toast component and more.
platform: Blazor
control: Toast
documentation: ug
---

# Show different types of toast in Blazor Toast Component

The Blazor Toast component provides predefined visual styles that can be applied using the CssClass property to represent different notification types. Use these styles to convey status and intent consistently across the application.

| Class | Description |
| -------- | -------- |
| `e-toast-success` | Indicates a successful or completed action |
| `e-toast-info` | Conveys informational or neutral messages |
| `e-toast-warning` | Highlights cautionary messages that may require attention |
| `e-toast-danger` | Signals errors or critical issues |

These classes style the toast appearance and can be combined with other custom classes as needed. Behavior such as Timeout, position, and content is configured independently.

```cshtml

@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Notifications

<SfToast @ref="ToastObj" Title="@ToastTitle" Content="@ToastContent" CssClass="@ToastCssClass">
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
    private string ToastTitle = "";
    private string ToastContent = "";
    private string ToastCssClass = "";

    private class ToastOption
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string CssClass { get; set; }
    }

    private ToastOption[] Toasts = new ToastOption[] {
        new ToastOption { Title = "Warning !", Content = "There was a problem with your network connection.", CssClass = "e-toast-warning" },
        new ToastOption { Title = "Success !", Content = "Your message has been sent successfully.", CssClass = "e-toast-success" },
        new ToastOption { Title = "Error !", Content = "A problem has been occurred while submitting your data.", CssClass = "e-toast-danger" },
        new ToastOption { Title = "Information !", Content = "Please read the comments carefully.", CssClass = "e-toast-info" }
    };

    private async Task ShowToast()
    {
        this.ToastTitle = this.Toasts[this.ToastFlag].Title;
        this.ToastContent = this.Toasts[this.ToastFlag].Content;
        this.ToastCssClass = this.Toasts[this.ToastFlag].CssClass;
        await Task.Delay(100);
        await this.ToastObj.ShowAsync();
        this.ToastFlag = ((this.ToastFlag == Toasts.Length - 1) ? 0 : (this.ToastFlag + 1));
    }
}

```