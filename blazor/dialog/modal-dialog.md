---
layout: post
title: Modal in Blazor Dialog Component | Syncfusion
description: Checkout and learn here all about Modal in Syncfusion Blazor Dialog component and much more details.
platform: Blazor
control: Dialog
documentation: ug
---

# Modal in Blazor Dialog Component

A modal dialog prevents users from interacting with the rest of the application until the dialog is closed. The [IsModal](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.SfDialog.html#Syncfusion_Blazor_Popups_SfDialog_IsModal) property enables modal behavior by displaying an overlay behind the Dialog, ensuring users must complete their interaction with the Dialog before accessing other application content.

```cshtml
@using Syncfusion.Blazor.Popups
@using Syncfusion.Blazor.Buttons

<SfButton @onclick="@OpenDialog">Open Modal Dialog</SfButton>

<SfDialog Width="250px" IsModal="true" @bind-Visible="@IsVisible" Content="This is a modal dialog"></SfDialog>

@code {
    private bool IsVisible { get; set; } = false;

    private void OpenDialog()
    {
        this.IsVisible = true;
    }
}
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/hZheNlMgpKvYKqGE?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}
![Modal in Blazor Dialog](./images/blazor-modal-dialog.png)

## Handling Overlay Click Events

The [OnOverlayModalClick](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.DialogEvents.html#Syncfusion_Blazor_Popups_DialogEvents_OnOverlayModalClick) event triggers when users click on the dialog's overlay area. This event provides access to the [OverlayModalClickEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.OverlayModalClickEventArgs.html) object, enabling custom functionality such as closing the dialog when users click outside the dialog content or implementing validation before allowing the dialog to close.

### Close Dialog When Clicking Outside of Its Region

The following example demonstrates how to close a modal dialog when the user clicks on the overlay area outside the dialog content. This provides an intuitive way for users to dismiss the dialog without requiring explicit close button interaction.

{% tabs %}
{% highlight cshtml %}

@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Popups

<SfButton @onclick="@OpenDialog">Open Modal Dialog</SfButton>

<SfDialog Width="250px" IsModal="true" @bind-Visible="@IsVisible" Content="This is a modal dialog">
    <DialogEvents OnOverlayModalClick="@OnOverlayclick"></DialogEvents>
</SfDialog>

@code {
    private bool IsVisible { get; set; } = true;

    private void OpenDialog()
    {
        this.IsVisible = true;
    }

    private void OnOverlayclick(OverlayModalClickEventArgs arg)
    {
        this.IsVisible = false;
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VZLeDFCMTCuSnnRi?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5"  %}
![Blazor Dialog with Modal Overlay](./images/blazor-dialog-modal-closes.gif)