---
layout: post
title: Severities in Blazor Message | Syncfusion
description: Display Blazor Message with Normal, Success, Info, Warning, or Error severity levels using the Severity property.
platform: Blazor
control: Message
documentation: ug
---

# Severities in the Blazor Message Component

The severity denotes the importance and context of the message to the user. The message contains different severity types. Use the [Severity](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Notifications.SfMessage.html#Syncfusion_Blazor_Notifications_SfMessage_Severity) property to display the messages with different severity levels.

The available severity types are listed below:

- **[Normal](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Notifications.MessageSeverity.html)**: Use for general-purpose messages that do not require special emphasis.
- **[Success](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Notifications.MessageSeverity.html)**: Use to indicate that an operation or action has completed successfully.
- **[Info](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Notifications.MessageSeverity.html)**: Use to provide additional information, guidance, or helpful instructions to users.
- **[Warning](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Notifications.MessageSeverity.html)**: Use to alert users to a potential issue or condition that requires attention but does not prevent them from continuing.
- **[Error](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Notifications.MessageSeverity.html)**: Use to indicate that an operation has failed or cannot be completed.

The default severity type for messages is **[Normal](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Notifications.MessageSeverity.html)**.

The following example demonstrates the severity of the messages.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Notifications

<div class="msg-default-section">
  <div class="content-section">
    <SfMessage Severity="MessageSeverity.Normal">Editing is restricted</SfMessage>
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

![Message Severity with Icons](./images/message-severity-icon.webp)

## Dynamically Update Severity in Blazor Message

In addition to setting a fixed severity, you can dynamically update the message severity by binding the [Severity](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Notifications.SfMessage.html#Syncfusion_Blazor_Notifications_SfMessage_Severity) property to a C# variable. This approach is useful when the message state depends on user actions, application logic, or server responses.

The following example demonstrates how to change the message severity at runtime using buttons.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Notifications

<div class="message-severity-container">
    <SfMessage Severity="@CurrentSeverity">
        @MessageText
    </SfMessage>

    <div class="button-group">
        <button class="success-btn" @onclick="ShowSuccess">Success</button>
        <button class="warning-btn" @onclick="ShowWarning">Warning</button>
        <button class="error-btn" @onclick="ShowError">Error</button>
    </div>
</div>

@code {
    private MessageSeverity CurrentSeverity = MessageSeverity.Info;
    private string MessageText = "Please review the details.";

    private void ShowSuccess()
    {
        CurrentSeverity = MessageSeverity.Success;
        MessageText = "Data saved successfully.";
    }

    private void ShowWarning()
    {
        CurrentSeverity = MessageSeverity.Warning;
        MessageText = "Some fields require attention.";
    }

    private void ShowError()
    {
        CurrentSeverity = MessageSeverity.Error;
        MessageText = "Failed to save the data.";
    }
}

<style>
    .message-severity-container {
        max-width: 600px;
        margin: 20px auto;
    }

    .button-group {
        display: flex;
        gap: 10px;
        margin-top: 12px;
    }

    .success-btn {
        border: none;
        border-radius: 20px;
        padding: 8px 16px;
        background: #d1fae5;
        color: #065f46;
        cursor: pointer;
    }

    .warning-btn {
        border: none;
        border-radius: 20px;
        padding: 8px 16px;
        background: #fef3c7;
        color: #92400e;
        cursor: pointer;
    }

    .error-btn {
        border: none;
        border-radius: 20px;
        padding: 8px 16px;
        background: #fee2e2;
        color: #991b1b;
        cursor: pointer;
    }
</style>

{% endhighlight %}
{% endtabs %}