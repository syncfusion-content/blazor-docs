---
layout: post
title: Show Dialog with full screen in Blazor Dialog Component | Syncfusion
description: Checkout and learn here all about Show Dialog with full screen in Syncfusion Blazor Dialog component and more.
platform: Blazor
control: Dialog
documentation: ug
---

# Show Dialog with full screen in Blazor Dialog Component

You can show the dialog in full screen by passing `true` as argument to the dialog [`ShowAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.SfDialog.html#Syncfusion_Blazor_Popups_SfDialog_ShowAsync_System_Nullable_System_Boolean__) method. By using the [`Visible`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.SfDialog.html#Syncfusion_Blazor_Popups_SfDialog_Visible) property, you can prevent the dialog from showing initially.

```cshtml

@using Syncfusion.Blazor.Popups
@using Syncfusion.Blazor.Buttons

<SfButton @onclick="@OpenDialog">Open FullScreen Dialog</SfButton>

<SfDialog @ref="DialogRef" Width="250px" ShowCloseIcon="true" Visible="false">
    <DialogTemplates>
        <Header> Dialog </Header>
        <Content> This is a Dialog with button and primary button </Content>
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
        await this.DialogRef.ShowAsync(true);
    }

    private async Task CloseDialog()
    {
        await this.DialogRef.HideAsync();
    }
}

```

{% previewsample "https://blazorplayground.syncfusion.com/embed/BjVejlWlClMfIggp?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor FullScreen Dialog](./images/blazor-fullscreen-dialog.gif)" %}