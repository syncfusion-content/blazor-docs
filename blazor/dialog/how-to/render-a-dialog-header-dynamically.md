---
layout: post
title: Render a dialog header dynamically in Blazor Dialog | Syncfusion
description: Learn here all about rendering a dialog header dynamically in Syncfusion Blazor Dialog component and more.
platform: Blazor
control: Dialog
documentation: ug
---

# Render a dialog header dynamically in Blazor Dialog Component

By default, the Dialog renders without a header. The header can be added or updated at runtime by binding a string to the `Header` property.

In the following example, selecting the button updates the value bound to `Header`, which immediately renders the header. The Dialog visibility is managed via `@bind-Visible`.

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

![Blazor Dialog without Header](../images/blazor-dialog-without-header.png)