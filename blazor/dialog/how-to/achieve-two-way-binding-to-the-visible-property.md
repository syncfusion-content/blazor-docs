---
layout: post
title: Binding the Visible Property in Blazor Dialog Component | Syncfusion
description: Learn here all about achieving two-way binding using the visible property in Syncfusion Blazor Dialog component and more.
platform: Blazor
control: Dialog
documentation: ug
---

# Two-way Binding Using the Visible Property in Blazor Dialog Component

## Two-way binding

The `Visible` property in the Blazor Dialog supports two-way binding. To keep the dialog hidden on page load, bind the property with `@bind-Visible` to a boolean field initialized to `false`.

Bind the `Visible` property as shown below to show or hide the Dialog when the CheckBox state changes.

```cshtml

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
