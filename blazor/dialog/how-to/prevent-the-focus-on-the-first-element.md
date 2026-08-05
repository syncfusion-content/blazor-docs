---
layout: post
title: Prevent the focus on the first element in Blazor Dialog | Syncfusion®
description: Learn here all about Preventing the focus on the first element in Blazor Dialog component and much more details.
platform: Blazor
control: Dialog
documentation: ug
---

# Prevent the focus on the first element in Blazor Dialog Component

By default, the Blazor dialog focuses on the first focusable element of the content area when it opens. You can prevent this default focusing behavior using the `Opened` event and by setting the [PreventFocus](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.OpenEventArgs.html#Syncfusion_Blazor_Popups_OpenEventArgs_PreventFocus) argument on the `OpenEventArgs`.

Bind the Opened event and set the PreventFocus argument to true, as shown in the following example.

```cshtml

@using Syncfusion.Blazor.Popups
@using Syncfusion.Blazor.Buttons

<SfButton @onclick="@OpenDialog">Open Dialog</SfButton>

<SfDialog Width="300px" @bind-Visible="@IsVisible">
    <DialogEvents Opened="@onOpen"></DialogEvents>
    <DialogTemplates>
        <Header> Sign In </Header>
        <Content>
            <div class='form-group'>
                <label for='email'>Email:</label>
                <input type='email' class='form-control' id='email'>
            </div>
            <div class='form-group'>
                <label for='comment'>Password:</label>
                <input type='password' class='form-control' id='password'>
            </div>
        </Content>
    </DialogTemplates>
    <DialogButtons>
        <DialogButton Content="OK" IsPrimary="true" OnClick="@CloseDialog" />
        <DialogButton Content="Cancel" OnClick="@CloseDialog" />
    </DialogButtons>
</SfDialog>

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

    private void onOpen(OpenEventArgs args)
    {
        args.PreventFocus = true;
    }
}

```
