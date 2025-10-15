---
layout: post
title: State Persistence in Syncfusion Blazor Dialog Component
description: Learn how to implement and manage state persistence in the Syncfusion Blazor Dialog component to maintain dialog state across interactions.
platform: Blazor
control: Dialog
documentation: ug
---

# Enable State Persistence in Blazor Dialog Component

To retain the Blazor Dialog component’s size, position, and other UI states across page reloads and future sessions, set the [EnablePersistence](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.SfDialog.html#Syncfusion_Blazor_Popups_SfDialog_EnablePersistence) property to true. Persistence stores the dialog state in browser local storage using the dialog’s unique ID, so ensure each persisted dialog has a stable `ID` value. Clearing local storage or changing the ID resets the persisted settings.

The [AllowPrerender](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.SfDialog.html#Syncfusion_Blazor_Popups_SfDialog_AllowPrerender) property is optional and controls whether dialog DOM elements remain in the page when the dialog is hidden. Keeping `AllowPrerender` true preserves the DOM between show/hide cycles, which can reduce re-rendering and improve perceived responsiveness, but it does not affect persistence across page reloads.

## Example: Persistent Dialog

The following code demonstrates how to configure a dialog with state persistence:


```cshtml

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

{% previewsample "https://blazorplayground.syncfusion.com/embed/rXrytlWbCFhMvNqK?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}
![Blazor Dialog State Persistence](./images/blazor-dialog-state-persistent.gif)