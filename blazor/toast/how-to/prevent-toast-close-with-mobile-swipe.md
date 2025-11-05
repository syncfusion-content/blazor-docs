---
layout: post
title: Prevent toast close with mobile swipe in Blazor Toast | Syncfusion
description: Learn here all about how to prevent toast close with mobile swipe in Syncfusion Blazor Toast component and more.
platform: Blazor
control: Toast
documentation: ug
---

# Prevent toast close with mobile swipe in Blazor Toast Component

The toast close can be prevented with mobile swipe action by setting `OnClose` argument cancel value to true while argument type is swipe. The following code shows how to prevent toast close with mobile swipe.

The following sample demonstrates preventing toast close with mobile swipe element displaying with custom code blocks.

```cshtml

@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Notifications

<SfToast ID="toast_default" @ref="ToastObj" Title="Adaptive Tiles Meeting" Content="@ToastContent">
    <ToastEvents OnClose="@OnClose"></ToastEvents>
    <ToastPosition X="Center"></ToastPosition>
</SfToast>

<div class="col-lg-12 col-sm-12 col-md-12 center">
    <div id="toastBtnDefault" style="margin: auto;text-align: center">
        <SfButton @onclick="@ShowToast"> Show Toast </SfButton>
    </div>
</div>

<style>
    #toast_default .e-meeting::before {
        content: "\e705";
        font-size: 17px;
    }
</style>

@code {
    SfToast ToastObj;

        private string ToastContent = "Conference Room 01 / Building 135 10:00 AM-10:30 AM";

        private async Task ShowToast()
        {
            await this.ToastObj.ShowAsync();
        }
        private void OnClose(ToastBeforeCloseArgs args)
        {
            if (args.RequestType == "swipe")
            {
                args.Cancel = true;
            }
        }
    }


```