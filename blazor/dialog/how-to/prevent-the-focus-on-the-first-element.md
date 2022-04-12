---
layout: post
title: Prevent the focus on the first element in Blazor Dialog | Syncfusion
description: Learn here all about Preventing the focus on the first element in Syncfusion Blazor Dialog component and more.
platform: Blazor
control: Dialog
documentation: ug
---

# Prevent the focus on the first element in Blazor Dialog Component

By default, the Blazor dialog focuses on the first elements of the content area which can be active and focusable. You can prevent this default focusing behavior using the `Opened` event and by enabling the `PreventFocus` argument.

Bind the Opened event and enable the PreventFocus argument within an event like the following example.

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