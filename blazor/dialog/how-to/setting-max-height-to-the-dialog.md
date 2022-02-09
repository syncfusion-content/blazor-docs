---
layout: post
title: Setting Maximum Height property to the Dialog in Blazor Dialog component | Syncfusion
description: Checkout and learn here all about setting MaxHeight to the Dialog in Syncfusion Blazor Dialog component and more.
platform: Blazor
control: Dialog
documentation: ug
---

# Setting maximum height to the Dialog

By default, the MaxHeight for the Dialog is calculated based on the target. If the target is not specified externally, the Dialog consider the body as target and will calculate the MaxHeight based on it. We have an option to set the MaxHeight of the Dialog in the [OnOpen](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.DialogEvents.html#Syncfusion_Blazor_Popups_DialogEvents_OnOpen) event.

{% highlight razor %}

@using Syncfusion.Blazor.Popups
@using Syncfusion.Blazor.Buttons

<SfButton @onclick="@OpenDialog">Open FullScreen Dialog</SfButton>

<SfDialog @ref="DialogRef" Width="800px" ShowCloseIcon="true" Visible="false">
    <DialogEvents OnOpen="onOpen"></DialogEvents>
    <DialogTemplates>
        <Header> Dialog </Header>
        <Content> This is a Dialog with MaxHeight property </Content>
    </DialogTemplates>
    <DialogButtons>
        <DialogButton Content="OK" IsPrimary="true" OnClick="@CloseDialog" />
        <DialogButton Content="Cancel" OnClick="@CloseDialog" />
    </DialogButtons>
</SfDialog>

@code {
    SfDialog DialogRef;
    private async Task OpenDialog()
    {
        await this.DialogRef.ShowAsync();
    }
    private async Task CloseDialog()
    {
        await this.DialogRef.HideAsync();
    }
    private void onOpen(BeforeOpenEventArgs args)
    {
        // setting maximum height to the Dialog
        args.MaxHeight = "300px";
    }
}

{% endhighlight %}
