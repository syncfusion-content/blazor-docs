---
layout: post
title: Severities with Blazor Message Component | Syncfusion
description: Checkout and learn about Severities with Blazor Message component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: Message
documentation: ug
---

# Severities in Blazor Message

The severity denotes the importance and context of the message to the user. The message contains different severity types. Use the `Severity` property, to display the messages with different severity levels.

The available severity types are **Normal**, **Success**, **Info**, **Warning** and **Error**. The default severity type for messages is **Normal**.

The following example demonstrates the messages with different severity types.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Notifications

<div class="msg-default-section">
  <div class="content-section">
    <SfMessage>Editing is restricted</SfMessage>
    <SfMessage Severity="MessageSeverity.Info">Please read the comments carefully</SfMessage>
    <SfMessage Severity="MessageSeverity.Success">Your message has been sent successfully</SfMessage>
    <SfMessage Severity="MessageSeverity.Warning">There was a problem with your network connection</SfMessage>
    <SfMessage Severity="MessageSeverity.Error">A problem has been occurred while submitting your data</SfMessage>
  </div>
</div>
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

![Message Severity with Icons](./images/message-severity-icon.png)

By default, severity icons can be displayed according to the severity types to make the user more understandable by visual information rather than text. To hide the severity icons, set the `ShowIcon` property to `false`.

The following example demonstrates the different severity messages without the severity icons.

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

![Message Severity with No Icons](./images/message-severity.png)