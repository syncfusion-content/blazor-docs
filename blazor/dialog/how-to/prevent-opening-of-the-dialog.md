---
layout: post
title: Open a Dialog on condition in Blazor Dialog Component | Syncfusion
description: Checkout and learn here all about Open a Dialog on condition in Syncfusion Blazor Dialog component and more.
platform: Blazor
control: Dialog
documentation: ug
---

# Open a Dialog on condition in Blazor Dialog Component

You can prevent opening of the dialog by setting the `OnOpen` event argument cancel value to true. In the following sample, the success dialog is opened when you enter the username value with minimum 4 characters. Otherwise, it will not be opened.

```cshtml

@using Syncfusion.Blazor.Popups
@using Syncfusion.Blazor.Buttons

<div class="login-form">
    <div class='wrap'>
        <div id="heading">Sign In</div>
        <div id="input-container">
            <div class="e-float-input e-input-group">
                <input id="username" type="text" @bind-value="@UserName" @onfocus="@OnFocus" required />
                <span class="e-float-line"></span>
                <label class="e-float-text">Username</label>
            </div>
            <div class="e-float-input e-input-group">
                <input id="password" type="password" @bind-value="@Password" @onfocus="@OnFocus" required />
                <span class="e-float-line"></span>
                <label class="e-float-text">Password</label>
            </div>
        </div>
        @if (!string.IsNullOrEmpty(this.ErrorMessage))
        {
            <div class="error-container">
                @ErrorMessage
            </div>
        }
        <div class="button-container">
            <SfButton @onclick="@OnSubmit">Log In</SfButton>
        </div>
    </div>
</div>
<SfDialog ID="dialog" IsModal="true" Width="280px" @bind-Visible="@Visibility">
    <DialogTemplates>
        <Header> Success </Header>
        <Content> Congratulations! Login Success </Content>
    </DialogTemplates>
    <DialogButtons>
        <DialogButton Content="Dismiss" IsPrimary="true" OnClick="@CloseDialog" />
    </DialogButtons>
    <DialogEvents OnOpen="@Validation"></DialogEvents>
</SfDialog>

<style>
    .wrap {
        box-sizing: border-box;
        margin: 0 auto;
        padding: 20px 30px;
        width: 340px;
        background: #f7f7f7;
    }

    #input-container .e-float-input { /* csslint allow: adjoining-classes */
        margin: 17px 0;
    }

    .wrap #input-container .e-control e-btn { /* csslint allow: adjoining-classes */
        margin: 3% 26%;
    }

    .button-container {
        padding: 20px 0 0;
        width: 100%;
    }

        .button-container .e-btn { /* csslint allow: adjoining-classes */
            width: 100%;
            height: 36px;
        }

    #heading {
        color: #333;
        font-weight: bold;
        margin: 0 0 15px;
        text-align: center;
        font-size: 20px;
    }

    .login-form {
        width: 340px;
        margin: 50px auto;
    }

    #dialog.e-dialog .e-footer-content {
        text-align: center;
    }

    .error-container {
        color: red;
    }
</style>

@code {
    private string UserName { get; set; } = "";
    private string Password { get; set; } = "";
    private bool Visibility { get; set; } = false;
    private string ErrorMessage { get; set; } = "";

    private void OnSubmit()
    {
        this.Visibility = true;
    }

    private void CloseDialog()
    {
        this.Visibility = false;
    }

    private void OnFocus()
    {
        this.ErrorMessage = "";
    }

    private void Validation(BeforeOpenEventArgs args)
    {
        if (this.UserName == "" && this.Password == "")
        {
            args.Cancel = true;
            this.Visibility = false;
            this.ErrorMessage = "Enter the Username and Password";
        }
        else if (this.UserName == "")
        {
            args.Cancel = true;
            this.Visibility = false;
            this.ErrorMessage = "Enter the username";
        }
        else if (this.Password == "")
        {
            args.Cancel = true;
            this.Visibility = false;
            this.ErrorMessage = "Enter the password";
        }
        else if (this.UserName.Length < 4)
        {
            args.Cancel = true;
            this.Visibility = false;
            this.ErrorMessage = "Username must contain minimum 4 characters";
        }
        else
        {
            args.Cancel = false;
            this.UserName = "";
            this.Password = "";
        }
    }
}

```
