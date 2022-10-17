---
layout: post
title: Customization with Blazor Message Component | Syncfusion
description: Checkout and learn about Customization with Blazor Message component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: Message
documentation: ug
---

# Customization

The Message can also be customized with its content positions and it appearance.

## Content alignment

The Message content has an different types of alignments such as **Left**, **Right** and **Center**. By default, the message content is aligned to the left. If the user wants to align the content in **Center** or **Right** for their readability, it can be achieved through the `ContentAlignment` property.

The following example demonstrates the message with different content alignments.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Notifications

<div class="msg-custom-section">
  <div class="content-section">
    <h4>Content Alignment</h4>
    <SfMessage Severity="MessageSeverity.Success">Your license has been activated successfully</SfMessage>
    <SfMessage Severity="MessageSeverity.Warning" ContentAlignment="HorizontalAlign.Center">The license will expire today</SfMessage>
    <SfMessage Severity="MessageSeverity.Error" ContentAlignment="HorizontalAlign.Right">The license key is invalid</SfMessage>
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
</style>
    
{% endhighlight %}
{% endtabs %}

![Message Content Alignment](./images/message-content-alignment.png)

## Rounded and Square

The following example show the rounded and squared appearance of the message which can be achieved through adding the `CssClass` and customizing the border styles.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Notifications

<div class="msg-custom-section">
  <div class="content-section">
  <h4>Rounded</h4>
    <SfMessage Severity="MessageSeverity.Warning" ContentAlignment="HorizontalAlign.Center" CssClass="rounded">The license will expire today</SfMessage>
    <h4>Square</h4>
    <SfMessage Severity="MessageSeverity.Error" ContentAlignment="HorizontalAlign.Right" CssClass="square">The license key is invalid</SfMessage>
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

  .msg-custom-section .e-message.rounded {
    border-radius: 5px;
  }

  .msg-custom-section .e-message.square {
    border-radius: 1px;
  }
</style>
    
{% endhighlight %}
{% endtabs %}

![Message Custom Appearance](./images/message-rounded-square.png)

## CSS Message

The Essential JS 2 Message has the following predefined classes that can be defined in the HTML elements which renders the message without any script reference.

| Class | Description |
| -------- | -------- |
| e-message | Used to represent the message styles. |
| e-msg-icon | Used to represent severity type and icon. |
| e-msg-content |  Used to represent the message content. |

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Notifications

<div class="msg-default">
    <div id="msg" class="e-message" role="alert">
      <span class="e-msg-icon"></span>
      <div class="e-msg-content">Please read the comments carefully</div>
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

  .msg-custom-section .e-message.rounded {
    border-radius: 5px;
  }

  .msg-custom-section .e-message.square {
    border-radius: 1px;
  }
</style>
    
{% endhighlight %}
{% endtabs %}

![Blazor Message Component](./images/message-default.PNG)