---
layout: post
title: Severities with Blazor Message Component | Syncfusion
description: Checkout and learn about Severities with Blazor Message component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: Message
documentation: ug
---

# Severities in Blazor Message

Severity indicates the importance and context of a message. The component supports multiple severity levels configured via the [Severity](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Notifications.SfMessage.html#Syncfusion_Blazor_Notifications_SfMessage_Severity) property on the message (using the MessageSeverity enum). Severity affects the visual style (colors and icon). The default severity is Normal. To hide the severity icon while retaining the style, use the [ShowIcon](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Notifications.SfMessage.html#Syncfusion_Blazor_Notifications_SfMessage_ShowIcon) property.

The available severity types are Normal, Success, Info, Warning, and Error.

The following example demonstrates messages rendered with each severity level.

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

![Blazor Message severity examples with icons for Normal, Info, Success, Warning, and Error](./images/message-severity-icon.png)