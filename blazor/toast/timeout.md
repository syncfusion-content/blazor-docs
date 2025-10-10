---
layout: post
title: Timeout in Blazor Toast Component | Syncfusion
description: Checkout and learn here all about timeout in Syncfusion Blazor Toast component and much more details.
platform: Blazor
control: Toast
documentation: ug
---

# Timeout in Blazor Toast Component

The toast display duration is controlled by the `Timeout` property, expressed in milliseconds. A toast remains visible until the timeout elapses if there is no interaction.

- The `Timeout` duration can be visually represented using a [progress bar](./config#progress-bar).
- The `ExtendedTimeout` property specifies how long the toast remains visible after pointer hover.

N> To allow dismissal at any time, enable the `ShowCloseButton` property.

```cshtml
@using Syncfusion.Blazor.Inputs
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Notifications

<div class="control-section toast-default-section">
    <SfToast @ref="ToastObj"
             Title="Notification"
             Width="230"
             Height="250"
             Content="@ToastContent"
             Timeout="@ToastTimeOut"
             ExtendedTimeout="2000"
             ShowCloseButton="true">
        <ToastPosition X="Right" Y="Bottom"></ToastPosition>
        <ToastButtons>
            <ToastButton Content="Dismiss" OnClick="@HideToast"></ToastButton>
            <ToastButton Content="Snooze"></ToastButton>
        </ToastButtons>
    </SfToast>

    <div class="col-lg-12 col-sm-12 col-md-12 center">
        <div id="toastBtnDefault" style="margin: auto; text-align: center">
            <div id="textbox-contain" style="text-align: initial; display: inline-block;">
                <SfTextBox @bind-Value="TextBoxVal"
                           FloatLabelType="FloatLabelType.Auto"
                           Placeholder="Enter timeout (ms)">
                </SfTextBox>
            </div>
            <SfButton CssClass="e-primary" @onclick="ShowToast">Show Toast</SfButton>
        </div>
    </div>
    <br /><br />
    <div id='result'></div>
</div>

<style>
    #elementToastTime .e-toast-message {
        padding: 10px;
        text-align: center;
    }

    #textbox-contain {
        text-align: initial;
        display: inline-block
    }
</style>

@code {
    private SfToast ToastObj;
    private int ToastTimeOut { get; set; } = 0;
    private string TextBoxVal { get; set; } = "0";
    private string ToastContent { get; set; } =
        "<p><img src='https://blazor.syncfusion.com/demos/images/toast/laura.png' alt='profile image'></p>";

    private async Task ShowToast()
    {
        if (!int.TryParse(TextBoxVal, out var parsed))
        {
            parsed = 0;
        }
        ToastTimeOut = parsed;
        await ToastObj.ShowAsync();
    }

    private async Task HideToast()
    {
        await ToastObj.HideAsync();
    }
}
```

![Timeout in Blazor Toast](./images/blazor-toast-timeout.png)

## Static toast

To prevent auto-hide and keep the toast visible until dismissed, set the `Timeout` property to zero (`0`).

```cshtml
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Notifications

<SfToast @ref="ToastObj" Timeout="0" Title="Notification" Content="@ToastContent">
    <ToastPosition X="Right"></ToastPosition>
</SfToast>

<div class="col-lg-12 col-sm-12 col-md-12 center">
    <div id="toastBtnDefault" style="margin: auto; text-align: center">
        <SfButton CssClass="e-primary" @onclick="ShowToast">Show Toast</SfButton>
    </div>
</div>

<style>
    #elementToastTime .e-toast-message {
        padding: 10px;
        text-align: center;
    }
</style>

@code {
    private SfToast ToastObj;
    private string ToastContent = "This toast remains visible until dismissed.";

    private async Task ShowToast()
    {
        await ToastObj.ShowAsync();
    }
}
```

![Timeout in Blazor Static Toast](./images/blazor-static-toast-timeout.png)