---
layout: post
title: Binding the visible property in Blazor Dialog Component | Syncfusion
description: Learn here all about achieving two-way binding using the visible property in Syncfusion Blazor Dialog component and more.
platform: Blazor
control: Dialog
documentation: ug
---

# Two-way binding using the visible property in Blazor Dialog Component

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