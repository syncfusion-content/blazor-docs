---
layout: post
title: Add Icons to Dialog Buttons in Blazor Dialog Component | Syncfusion
description: Checkout and learn here all about how to add icons to Dialog buttons in Syncfusion Blazor Dialog component and more.
platform: Blazor
control: Dialog
documentation: ug
---

# Add Icons to Dialog Buttons in Blazor Dialog Component

Icons can be added to dialog footer buttons using either the DialogButtons collection or the FooterTemplate within DialogTemplates. Use the IconCss property or icon span elements to apply Syncfusion icon classes (e-icons) or custom font icons via CSS.

The following example customizes dialog footer buttons with icons using the DialogButtons collection on SfDialog. Icons are applied using the IconCss property. This sample initializes IsVisible to true to display the dialog on first render; the Open Dialog button can be used to reopen it after closing.

```cshtml

@using Syncfusion.Blazor.Popups
@using Syncfusion.Blazor.Buttons

<SfButton @onclick="@OpenDialog">Open Dialog</SfButton>

<SfDialog Width="300px" ShowCloseIcon="true" CloseOnEscape="true" @bind-Visible="@IsVisible">
    <DialogTemplates>
        <Header>
            <div>Delete Multiple Items</div>
        </Header>
        <Content>
            <div>Are you sure you want to permanently delete all of these items?</div>
        </Content>
    </DialogTemplates>
    <DialogButtons>
        <DialogButton Content="Yes" IsPrimary="true" IconCss="e-icons e-ok-icon" OnClick="@CloseDialog" />
        <DialogButton Content="No" IconCss="e-icons e-close-icon" OnClick="@CloseDialog" />
    </DialogButtons>
</SfDialog>

<style>
    a, a:hover, .highcontrast #dialog a, .highcontrast #dialog a:hover {
        color: inherit;
        text-decoration: none;
    }

    .e-btn-icon.e-icons.e-ok-icon.e-icon-left:before {
        content: '\e7ff';
    }

    .e-btn-icon.e-icons.e-close-icon.e-icon-left:before {
        content: '\e825';
    }
</style>

@code {
    private bool IsVisible { get; set; } = true;

    private void OpenDialog()
    {
        this.IsVisible = true;
    }

    private void CloseDialog()
    {
        this.IsVisible = false;
    }
}

```

The following example customizes dialog footer buttons with icons using the FooterTemplate. Icons are added as span elements with icon classes, giving full control over layout and styling.

```cshtml

@using Syncfusion.Blazor.Popups
@using Syncfusion.Blazor.Buttons

<SfButton @onclick="@OpenDialog">Open Dialog</SfButton>

<SfDialog Width="300px" ShowCloseIcon="true" CloseOnEscape="true" @bind-Visible="@IsVisible">
    <DialogTemplates>
        <Header> Delete Multiple Items </Header>
        <Content> Are you sure you want to permanently delete all of these items? </Content>
        <FooterTemplate>
            <SfButton CssClass="e-primary e-flat" @onclick="@CloseDialog">
                <span class='e-btn-icon e-icons e-ok-icon e-icon-left'></span>Yes
            </SfButton>
            <SfButton CssClass="e-flat" @onclick="@CloseDialog">
                <span class='e-btn-icon e-icons e-close-icon e-icon-left'></span>No
            </SfButton>
        </FooterTemplate>
    </DialogTemplates>
</SfDialog>

<style>
    a, a:hover, .highcontrast #dialog a, .highcontrast #dialog a:hover {
        color: inherit;
        text-decoration: none;
    }

    .e-btn-icon.e-icons.e-ok-icon.e-icon-left:before {
        content: '\e7ff';
    }

    .e-btn-icon.e-icons.e-close-icon.e-icon-left:before {
        content: '\e825';
    }
</style>

@code {
    private bool IsVisible { get; set; } = true;

    private void OpenDialog()
    {
        this.IsVisible = true;
    }

    private void CloseDialog()
    {
        this.IsVisible = false;
    }
}

```

![Adding Icons to Blazor Dialog Button](../images/blazor-dialog-button-with-icon.png)