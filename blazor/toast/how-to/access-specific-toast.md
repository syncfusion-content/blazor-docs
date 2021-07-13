---
layout: post
title: How to Access Specific Toast in Blazor Toast Component | Syncfusion
description: Checkout and learn about Access Specific Toast in Blazor Toast component of Syncfusion, and more details.
platform: Blazor
control: Toast
documentation: ug
---

# Access Specific Toast

In the toast, we can access the particular toast by passing the `Key` value in `ShowModels`, and the `Key` should be unique in `ShowModels`. To close the specific toast, you also need to pass the corresponding toast `Key` value in the `Hide` method.

You can get the added `Key` value in the toast `Opened` and `Closed` event.

In the following example, Toast is closed by calling the `Hide` method with the key value that is returned in the `Opened` event

```csharp

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
