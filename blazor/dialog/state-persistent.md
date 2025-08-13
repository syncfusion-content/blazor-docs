---
layout: post
title: State Persistence in Syncfusion Blazor Dialog Component
description: Checkout and learn here all about state persistence in Syncfusion Blazor Dialog component
platform: Blazor
control: Dialog
documentation: ug
---

# Enable State Persistence in Blazor Dialog Component

To ensure the Blazor Dialog component retains its size and position across page reloads and reopen actions, set the [`EnablePersistence`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.SfDialog.html#Syncfusion_Blazor_Popups_SfDialog_EnablePersistence) property to `true`. Additionally, enable the [`AllowPrerender`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.SfDialog.html#Syncfusion_Blazor_Popups_SfDialog_AllowPrerender) property to maintain the dialog's DOM elements even when it is hidden.

By default, `AllowPrerender` is set to `false`, which means the dialog's DOM elements are removed when hidden and re-rendered upon showing. Setting it to `true` retains the dialog's elements in the DOM, preserving its state such as position and size between show/hide operations.

## Example: Persistent Dialog

The following code demonstrates how to configure a dialog with state persistence:


```razor

@using Syncfusion.Blazor.Popups
@using Syncfusion.Blazor.Buttons

<SfButton @onclick="@OpenDialog">Open Dialog</SfButton>

<SfDialog @ref="DialogRef" Visible="false"
    ID="myDialog"
    EnableResize="true"
    AllowDragging="true"
    ShowCloseIcon="true"
    EnablePersistence="true"
    AllowPrerender="true"
    >
    <DialogTemplates>
        <Header>Dialog header</Header>
        <Content>
            Dialog State Persistence
        </Content>
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
}

```

{% previewsample "https://blazorplayground.syncfusion.com/embed/rDVIjPsCTufucdGL?appbar=true&editor=true&result=true&errorlist=true&theme=bootstrap5" %}
![Blazor Dialog State Persistence](./images/blazor-dialog-state-persistent.gif)