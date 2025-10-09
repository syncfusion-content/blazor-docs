---
layout: post
title: Icons in Blazor Message Component | Syncfusion
description: Learn how to work with icons in the Syncfusion Blazor Message component, including hiding severity icons, adding custom icons with CssClass, and showing a close icon in Blazor Server and WebAssembly apps.
platform: Blazor
control: Message
documentation: ug
---

# Icons in Blazor Message

This topic explains how to control icons in the Message component: hide default severity icons, add a custom severity icon with CSS, and show or hide the close icon.

## No Icon

By default, the Message component displays a severity icon that matches the configured severity to provide clear visual context. To hide severity icons, set the [ShowIcon](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Notifications.SfMessage.html#Syncfusion_Blazor_Notifications_SfMessage_ShowIcon) property to false. Severity styling (color/background) still applies even when the icon is hidden.

The following example demonstrates different severity messages without severity icons.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Notifications

<div class="msg-default-section">
  <div class="content-section">
    <SfMessage ShowIcon="@ShowIcon">Editing is restricted</SfMessage>
    <SfMessage Severity="MessageSeverity.Info" ShowIcon="@ShowIcon">Please read the comments carefully</SfMessage>
    <SfMessage Severity="MessageSeverity.Success" ShowIcon="@ShowIcon">Your message has been sent successfully</SfMessage>
    <SfMessage Severity="MessageSeverity.Warning" ShowIcon="@ShowIcon">There was a problem with your network connection</SfMessage>
    <SfMessage Severity="MessageSeverity.Error" ShowIcon="@ShowIcon">A problem occurred while submitting your data</SfMessage>
  </div>
</div>

@code {
  private bool ShowIcon = false;
}

<style>
  .msg-default-section .content-section {
    margin: 0 auto;
    max-width: 450px;
    padding-top: 10px;
  }

  .msg-default-section .e-message {
    margin: 10px 0;
  }
</style>
    
{% endhighlight %}
{% endtabs %}

![Blazor Message severities rendered without icons](./images/message-severity.png)

## Custom Icon

To replace the default severity icon, apply a custom CSS class with [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Notifications.SfMessage.html#Syncfusion_Blazor_Notifications_SfMessage_CssClass) and target the icon element (for example, .e-msg-icon::before). A custom glyph font (as shown) or an SVG-based approach can be used to provide a custom icon.

The following example demonstrates a message rendered with a custom severity icon.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Notifications

<div class="msg-custom-section">
  <div class="content-section">
    <h4>Custom Message with Icon</h4>
    <SfMessage  CssClass="custom">Essential JS 2 is a modern JavaScript UI Controls library that has
      been built from the ground up to be lightweight, responsive, modular and touch friendly. It is written in TypeScript and has no external dependencies. It also includes complete support for Angular, React, Vue, ASP.NET MVC and ASP.NET Core frameworks.</SfMessage>
  </div>
</div>
<style>
  .msg-custom-section .content-section {
    margin: 0 auto;
    max-width: 400px;
    padding-top: 10px;
  }

  .msg-custom-section .e-message {
    margin: 10px 0;
  }

  @font-face {
    font-family: 'Message_icons';
    src: url(data:application/x-font-ttf;charset=utf-8;base64,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) format('truetype');
    font-weight: normal;
    font-style: normal;
  }

  .custom.e-message .e-msg-icon::before {
    font-family: 'Message_icons';
    content: '\e894';
  }
</style>
    
{% endhighlight %}
{% endtabs %}

![Blazor Message with a custom severity icon](./images/message-custom-icon.png)

## Close Icon

The Message component can render with or without a close icon. The close icon dismisses the message via click or keyboard activation. By default, the close icon is not shown. To render a close icon, set [ShowCloseIcon](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Notifications.SfMessage.html#Syncfusion_Blazor_Notifications_SfMessage_ShowCloseIcon) to true. Use @bind-Visible to toggle visibility and handle the Closed callback to respond when the message is dismissed.

In the following example, messages are rendered with a close icon.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Notifications
@using Syncfusion.Blazor.Buttons

<div class="msg-icon-section">
  <div class="content-section">
    <SfButton Content="Show Default Message" CssClass="@defaultBtnClass" OnClick="@defaultClick"></SfButton>
    <SfMessage ShowIcon="@defaultIcon" Closed="@defaultClosed" ShowCloseIcon="@defaultCloseIcon" @bind-Visible="@defaultVisible">Editing is restricted</SfMessage>
    <SfButton Content="Show Info Message" CssClass="@infoBtnClass" OnClick="@infoClick"></SfButton>
    <SfMessage Severity="MessageSeverity.Info" ShowIcon="@infoIcon" ShowCloseIcon="@infoCloseIcon" Closed="@infoClosed" @bind-Visible="@infoVisible">Please read the comments carefully</SfMessage>
    <SfButton Content="Show Success Message" CssClass="@successBtnClass" OnClick="@successClick"></SfButton>
    <SfMessage Severity="MessageSeverity.Success" ShowIcon="@successIcon" ShowCloseIcon="@successCloseIcon" Closed="@successClosed" @bind-Visible="@successVisible">Your message has been sent successfully</SfMessage>
    <SfButton Content="Show Warning Message" CssClass="@warningBtnClass" OnClick="@warningClick"></SfButton>
    <SfMessage Severity="MessageSeverity.Warning" ShowIcon="@warningIcon" ShowCloseIcon="@warningCloseIcon" Closed="warningClosed" @bind-Visible="@warningVisible">There was a problem with your network connection</SfMessage>
    <SfButton Content="Show Error Message" CssClass="@errorBtnClass" OnClick="@errorClick"></SfButton>
    <SfMessage Severity="MessageSeverity.Error" ShowIcon="@errorIcon" ShowCloseIcon="@errorCloseIcon" Closed="@errorClosed" @bind-Visible="@errorVisible">A problem has been occurred while submitting your data</SfMessage>
  </div>
</div>

@code {
  private bool defaultIcon = true;
  private bool successIcon = true;
  private bool warningIcon = true;
  private bool infoIcon = true;
  private bool errorIcon = true;
  private bool defaultVisible = true;
  private bool successVisible = true;
  private bool warningVisible = true;
  private bool errorVisible = true;
  private bool infoVisible = true;
  private bool defaultCloseIcon = true;
  private bool successCloseIcon = true;
  private bool warningCloseIcon = true;
  private bool infoCloseIcon = true;
  private bool errorCloseIcon = true;
  private bool severityChecked = true;
  private bool closeIconChecked = true;
  private string defaultBtnClass = "e-outline e-primary msg-hidden";
  private string infoBtnClass = "e-outline e-primary e-info msg-hidden";
  private string successBtnClass = "e-outline e-primary e-success msg-hidden";
  private string warningBtnClass = "e-outline e-primary e-warning msg-hidden";
  private string errorBtnClass = "e-outline e-primary e-error msg-hidden";

  private void defaultClick()
  {
    this.defaultVisible = true;
    this.defaultBtnClass = "e-outline e-primary msg-hidden";
  }
  private void defaultClosed()
  {
    this.defaultBtnClass = "e-outline e-primary";
  }
  private void infoClick()
  {
    this.infoVisible = true;
    this.infoBtnClass = "e-outline e-primary e-info msg-hidden";
  }
  private void infoClosed()
  {
    this.infoBtnClass = "e-outline e-primary e-info";
  }
  private void successClick()
  {
    this.successVisible = true;
    this.successBtnClass = "e-outline e-primary e-success msg-hidden";
  }
  private void successClosed()
  {
    this.successBtnClass = "e-outline e-primary e-success";
  }
  private void warningClick()
  {
    this.warningVisible = true;
    this.warningBtnClass = "e-outline e-primary e-warning msg-hidden";
  }
  private void warningClosed()
  {
    this.warningBtnClass = "e-outline e-primary e-warning";
  }
  private void errorClick()
  {
    this.errorVisible = true;
    this.errorBtnClass = "e-outline e-primary e-error msg-hidden";
  }
  private void errorClosed()
  {
    this.errorBtnClass = "e-outline e-primary e-error";
  }
}
<style>
  .msg-icon-section .content-section {
    margin: 0 auto;
    max-width: 450px;
    padding-top: 10px;
  }

  .msg-icon-section .e-message {
    margin: 10px 0;
  }

  .msg-icon-section .e-btn {
    display: block;
    margin: 10px 0;
  }

  .msg-icon-section .e-btn.msg-hidden {
    display: none;
  }
</style>
    
{% endhighlight %}
{% endtabs %}

![Blazor Messages rendered with close icons and dismiss behavior](./images/message-close-icon.png)