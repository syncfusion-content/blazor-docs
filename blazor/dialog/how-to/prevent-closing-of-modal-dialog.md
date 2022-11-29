---
layout: post
title: Prevent closing of Modal Blazor Dialog | Syncfusion
description: Learn here all about how to prevent modal dialog from closing in Syncfusion Blazor Dialog component and more.
platform: Blazor
control: Dialog
documentation: ug
---

# Prevent Closing of Modal Dialog in Blazor Dialog Component

You can prevent closing of modal dialog by setting the `OnClose` event argument cancel value to `true`. In the following sample, the dialog is closed when you enter the username value with minimum 4 characters. Otherwise, it will not be closed.

```cshtml

@using Syncfusion.Blazor.Popups
@using Syncfusion.Blazor.Buttons

<SfButton @onclick="@OpenDialog">Open Dialog</SfButton>

<SfDialog ID="dialog" IsModal="true" Width="300px" @bind-Visible="@IsVisible">
    <DialogTemplates>
        <Header>
            <div id="heading">Sign In</div>
        </Header>
        <Content>
            <div id='input-container'>
                <div class="e-float-input e-input-group">
                    <input id="username" type="text" @bind="@UserName" required />
                    <span class="e-float-line"></span>
                    <label class="e-float-text">Username</label>
                </div>
            </div>
            <div class='form-group'>
                <div class="e-float-input e-input-group">
                    <input id="password" type="text" @bind="@Password" required />
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
        </Content>
    </DialogTemplates>
    <DialogButtons>
        <DialogButton Content="Log In" IsPrimary="true" OnClick="@OnSubmit" />
    </DialogButtons>
    <DialogEvents OnClose="@Validation"></DialogEvents>
</SfDialog>

<style>
    #dialog.e-dialog .e-dlg-header-content .e-dlg-header {
        text-align: center;
        width: 100%;
        color: #333;
        font-weight: bold;
        font-size: 20px;
    }

    #input-container .e-float-input { /* csslint allow: adjoining-classes */
        margin: 17px 0;
    }

    .e-footer-content {
        padding: 20px 0 0;
        width: 100%;
    }

    .e-dialog .e-footer-content .e-btn {
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

    #dialog.e-dialog .e-footer-content {
        padding: 0 18px 18px;
    }

        #dialog.e-dialog .e-footer-content .e-btn {
            margin-left: 0;
        }

    .error-container {
        color: red;
    }
</style>

@code {
    private string UserName { get; set; } = "";
    private string Password { get; set; } = "";
    private bool IsVisible { get; set; } = true;
    private string ErrorMessage { get; set; } = "";

    private void OpenDialog()
    {
        this.IsVisible = true;
    }

    private void OnSubmit()
    {
        this.IsVisible = false;
    }

    private void Validation(BeforeCloseEventArgs args)
    {
        if (UserName == "" && Password == "")
        {
            args.Cancel = true;
            this.IsVisible = true;
            this.ErrorMessage = "Enter the Username and Password";
        }
        else if (UserName == "")
        {
            args.Cancel = true;
            this.IsVisible = true;
            this.ErrorMessage = "Enter the username";
        }
        else if (Password == "")
        {
            args.Cancel = true;
            this.IsVisible = true;
            this.ErrorMessage = "Enter the password";
        }
        else if (UserName.Length < 4)
        {
            args.Cancel = true;
            this.IsVisible = true;
            this.ErrorMessage = "Username must be minimum 4 characters";
        }
        else
        {
            args.Cancel = false;
            UserName = "";
            Password = "";
        }
    }
}

```



![Preventing Close Dialog in Blazor Dialog Component](../images/blazor-datagrid-prevent-dialog.png)