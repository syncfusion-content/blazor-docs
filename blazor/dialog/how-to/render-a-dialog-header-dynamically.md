---
layout: post
title: How to Render A Dialog Header Dynamically in Blazor Dialog Component | Syncfusion
description: Checkout and learn about Render A Dialog Header Dynamically in Blazor Dialog component of Syncfusion, and more details.
platform: Blazor
control: Dialog
documentation: ug
---

# Render a dialog header dynamically

By default, the dialog is rendered without header. You can update its header dynamically using the `Header` property.

> In the following code, the dialog header is rendered on a button click.

```csharp

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

The output will be as follows.

![dialog](../images/dialog-without-header.png)