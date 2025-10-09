---
layout: post
title: Access specific toast in Blazor Toast Component | Syncfusion
description: Checkout and learn here all about access specific toast in Syncfusion Blazor Toast component and more.
platform: Blazor
control: Toast
documentation: ug
---

# Access specific toast in Blazor Toast Component

In the Toast component, an individual toast can be addressed by assigning a unique Key value in the ToastModel when showing the toast. To close a specific toast, pass the same Key to the HideAsync method. The assigned Key can be retrieved from the Opened and Closed events through the event arguments.

In the following example, each toast is closed by calling the HideAsync method with the Key value returned in the Opened event.

```cshtml

@using Syncfusion.Blazor.Notifications

<div id="target">
    <SfToast @ref="toast" ShowCloseButton="true" Height="150px" Width="200px" Timeout="60" Target="@target" Icon="e-meeting" Title="@title" >
        <ToastEvents Opened="OnOpen"></ToastEvents>
    </SfToast>
    <div class="col-lg-12 col-sm-12 col-md-12 center">
        <div id="toastBtnDefault" style="margin: auto;text-align: center">
            <button class="e-btn" id="toastBtnShow" @onclick="showOnclick">Show Toasts</button>
            <button class="e-btn" id="toastBtnHide" @onclick="hideOnclick">Hide All</button>
            <button class="e-btn" id="toastBtnHide" @onclick="HideOnclick">Hide</button>
        </div>
    </div>
</div>

<style>
    #toast_default .e-meeting::before {
        content: "\e705";
        font-size: 17px;
    }
</style>

@code{
        SfToast toast;

        private string target = "#target";
        private string title = "This is Toast Title";

        private int key { get; set; } = 0;
        private async Task showOnclick()
        {
            await this.toast.ShowAsync( new ToastModel {Key = key , Content = key.ToString() , Timeout = 10000 });
            key++;
        }

        private async Task OnOpen(ToastOpenArgs args)
        {
            await this.toast.HideAsync(args.Key);
        }

    private async Task HideOnclick()
    {
        await this.toast.HideAsync();
    }
    private async Task hideOnclick()
    {
        await this.toast.HideAsync("All");
    }
}

```