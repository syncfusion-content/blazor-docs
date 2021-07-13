---
layout: post
title: How to Achieve Two Way Binding To The Visible Property in Blazor Dialog Component | Syncfusion
description: Checkout and learn about Achieve Two Way Binding To The Visible Property in Blazor Dialog component of Syncfusion, and more details.
platform: Blazor
control: Dialog
documentation: ug
---

# Achieve two-way binding to the visible property

## Two-way binding

The `Visible` property is enabled by default and has two-way binding capabilities in Blazor dialog. To prevent the dialog from showing on-page load, set the property to `false` using the `@bind-Visible` attribute.

Bind the `Visible` property as mentioned below to show/hide the dialog on CheckBox state change.

```csharp

@using Syncfusion.Blazor.Popups
@using Syncfusion.Blazor.Buttons

<div id="target" class="col-lg-12 control-section">
    <div class="row">
        <SfCheckBox Label="Show/Hide Dialog" @bind-Checked="@Visibility"></SfCheckBox>
    </div>
    <SfDialog Width="400px" ShowCloseIcon="true" @bind-Visible="@Visibility">
        <DialogTemplates>
            <Header> Update Required!!! </Header>
            <Content> Would you like to install the latest updates? </Content>
        </DialogTemplates>
        <DialogButtons>
            <DialogButton Content="Update" IsPrimary="true" OnClick="@CloseDialog" />
            <DialogButton Content="Later" IsPrimary="false" OnClick="@CloseDialog" />
        </DialogButtons>
    </SfDialog>
</div>

<style>
    #target {
        min-height: 300px;
    }
</style>

@code{
    private bool Visibility { get; set; } = false;

    private void CloseDialog()
    {
        this.Visibility = false;
    }
}

```