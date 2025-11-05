---
layout: post
title: Add dynamic template in Blazor Toast Component | Syncfusion
description: Checkout and learn here all about how to add dynamic template in Syncfusion Blazor Toast component and more.
platform: Blazor
control: Toast
documentation: ug
---

# Add dynamic template in Blazor Toast Component

Toast supports to change templates dynamically with displaying in multiple toasts. The toast properties can be changed while calling in the `Show` method.

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
        new ToastModel() { ContentTemplate = @<p>2 Mail has received</p>},
        new ToastModel() {  ContentTemplate = @<p>User Guest Logged in</p>},
        new ToastModel() {  ContentTemplate = @<p>Logging in as Guest</p>},
        new ToastModel() {  ContentTemplate = @<p>Ticket has reserved</p>}
    };

    private async Task ShowToast()
    {
        // Delay mandatory to update the dynamically changed Toast properties
        await Task.Delay(100);
        await this.ToastObj.ShowAsync(Messages[this.ToastFlag]);
        this.ToastFlag = ((this.ToastFlag == Messages.Length - 1) ? 0 : (this.ToastFlag + 1));
    }
}

```