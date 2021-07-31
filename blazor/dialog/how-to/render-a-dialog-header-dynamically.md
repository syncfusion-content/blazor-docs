---
layout: post
title: Render a dialog header dynamically in Blazor Dialog | Syncfusion
description: Learn here all about Render a dialog header dynamically in Syncfusion Blazor Dialog component and more.
platform: Blazor
control: Dialog
documentation: ug
---

# Render a dialog header dynamically in Blazor Dialog Component

By default, the dialog is rendered without header. You can update its header dynamically using the `Header` property.

In the following code, the dialog header is rendered on a button click.

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