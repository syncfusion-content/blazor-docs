---
layout: post
title: Variants with Blazor Message Component | Syncfusion
description: Checkout and learn about Variants with Blazor Message component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: Message
documentation: ug
---

# Variants in Blazor Message

The Message has predefined appearance variants for different visual representations. The variants of the message can be changed based on the [Variant](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Notifications.SfMessage.html#Syncfusion_Blazor_Notifications_SfMessage_Variant) property.

The available variants are **Text**, **Outlined** and **Filled**. The default variant type for messages is **Text**.
* **Text** - The severity is differentiated using a text color and a light background color.
* **Outlined** - The severity is differentiated using a text color and a border without a background.
* **Filled** - The severity is differentiated using a text color and a dark background color.

The following example demonstrates the default message with different variant types.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Notifications

<div class="msg-variant-section">
	<div class="content-section">
    <h4>Filled</h4>
    <SfMessage Variant="MessageVariant.Filled">Editing is restricted</SfMessage>
    <SfMessage Severity="MessageSeverity.Info" Variant="MessageVariant.Filled">Please read the comments carefully</SfMessage>
    <SfMessage Severity="MessageSeverity.Success" Variant="MessageVariant.Filled">Your message has been sent successfully</SfMessage>
    <SfMessage Severity="MessageSeverity.Warning" Variant="MessageVariant.Filled">There was a problem with your network connection</SfMessage>
    <SfMessage Severity="MessageSeverity.Error" Variant="MessageVariant.Filled">A problem occurred while submitting your data</SfMessage>
  </div>
	  <div class="content-section">
      <h4>Outlined</h4>
      <SfMessage Variant="MessageVariant.Outlined">Editing is restricted</SfMessage>
      <SfMessage Severity="MessageSeverity.Info" Variant="MessageVariant.Outlined">Please read the comments carefully</SfMessage>
      <SfMessage Severity="MessageSeverity.Success" Variant="MessageVariant.Outlined">Your message has been sent successfully</SfMessage>
      <SfMessage Severity="MessageSeverity.Warning" Variant="MessageVariant.Outlined">There was a problem with your network connection</SfMessage>
      <SfMessage Severity="MessageSeverity.Error" Variant="MessageVariant.Outlined">A problem occurred while submitting your data</SfMessage>
    </div>
    <div class="content-section">
      <h4>Text</h4>
      <SfMessage>Editing is restricted</SfMessage>
      <SfMessage Severity="MessageSeverity.Info">Please read the comments carefully</SfMessage>
      <SfMessage Severity="MessageSeverity.Success">Your message has been sent successfully</SfMessage>
      <SfMessage Severity="MessageSeverity.Warning">There was a problem with your network connection</SfMessage>
      <SfMessage Severity="MessageSeverity.Error">A problem occurred while submitting your data</SfMessage>
    </div>    
</div>

<style>
.msg-variant-section .content-section {
  margin: 0 auto;
  max-width: 520px;
  padding-top: 10px;
}

.msg-variant-section .e-message {
  margin: 10px;
}

.msg-variant-section {
  display: flex;
}
</style>
    
{% endhighlight %}
{% endtabs %}

![Message Filled Variant](./images/variants-filled.png)

![Message Outlined Variant](./images/variants-outlined.png)

![Message Text Variant](./images/variants-text.png)