---
layout: post
title: How to render a dialog header dynamically in Blazor Dialog | Syncfusion®
description: Render the Blazor Dialog header dynamically by binding the Header content to a variable that changes in response to user input or events.
platform: Blazor
control: Dialog
documentation: ug
---

# How to render a dialog header dynamically in Blazor Dialog

By default, the dialog is rendered without a header. You can update its header dynamically using the [Header](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.SfDialog.html#Syncfusion_Blazor_Popups_SfDialog_Header) property.

In the following code, the dialog header is rendered on a button click.

```cshtml

@using Syncfusion.Blazor.Popups
@using Syncfusion.Blazor.Buttons

<SfButton @onclick="@OpenDialog">Open Dialog</SfButton>
<SfButton @onclick="@RenderHeader">Render Dynamic Header</SfButton>

<SfDialog Header="@Header" Width="250px" @bind-Visible="@IsVisible">
    <DialogTemplates>
        <Content>This is a dialog without header</Content>
    </DialogTemplates>
    <DialogButtons>
        <DialogButton Content="OK" IsPrimary="true" OnClick="@CloseDialog" />
        <DialogButton Content="Cancel" OnClick="@CloseDialog" />
    </DialogButtons>
</SfDialog>

@code {
    private string Header { get; set; }
    private bool IsVisible { get; set; } = true;

    private void OpenDialog()
    {
        this.IsVisible = true;
    }

    private void CloseDialog()
    {
        this.IsVisible = false;
    }

    private void RenderHeader()
    {
        this.Header = "Dynamic Header";
    }
}

```



![Blazor Dialog without Header](../images/blazor-dialog-without-header.webp)
