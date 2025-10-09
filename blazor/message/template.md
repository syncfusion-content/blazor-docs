---
layout: post
title: Template with Blazor Message Component | Syncfusion
description: Learn how to use templated content in the Syncfusion Blazor Message component by placing custom Razor/HTML (headings, paragraphs, buttons) between SfMessage tags in Blazor Server and WebAssembly apps.
platform: Blazor
control: Message
documentation: ug
---

# Template in Blazor Message

The Message component supports templated content, allowing custom structure and elements. Place any valid Razor or HTML—such as headings, paragraphs, or buttons—between the `SfMessage` tags. Severity, icon visibility, and the close icon can still be configured when using templated content.

The following example customizes message content with HTML elements and Blazor Buttons, added directly inside the `SfMessage` tags. The example also demonstrates toggling visibility via a Show button and a Dismiss action.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Notifications
@using Syncfusion.Blazor.Buttons

<div class="msg-template-section">
    <div class="content-section">
        <SfButton Content='Show pull request' CssClass="@showBtnClass" OnClick="@showClick"></SfButton>
        <SfMessage Severity="MessageSeverity.Success" Visible="@visible">
            <h1>Merged pull request</h1>
            <p>Pull request #41 merged after a successful build</p>
            <SfButton CssClass='e-link' Content='View commit'></SfButton>
            <SfButton CssClass='e-link' Content='Dismiss' OnClick="@dismissClick"></SfButton>
        </SfMessage>
    </div>
</div>
@code {
  public string showBtnClass = "e-outline e-primary e-success msg-hidden";
  public bool visible = true;
  public void showClick()
  {
    this.visible = true;
    this.showBtnClass = "e-outline e-primary e-success msg-hidden";
  }
  public void dismissClick()
  {
    this.visible = false;
    this.showBtnClass = "e-outline e-primary e-success";
  }
}

<style>
.msg-template-section .content-section {
  margin: 0 auto;
  max-width: 450px;
  padding-top: 20px;
}

.msg-template-section .e-btn.msg-hidden {
  display: none;
}

.msg-template-section .e-message h1 {
  margin: 0;
  font-size: 16px;
  font-weight: 600;
  line-height: 1.25;
}

.msg-template-section .e-message .e-msg-icon {
  padding: 0 4px;
  margin-top: 3px;
}

.msg-template-section .e-message p {
  margin: 8px 0 4px;
}

.msg-template-section .e-message .e-btn {
  padding: 0;
}
</style>
    
{% endhighlight %}
{% endtabs %}

![Blazor Message with custom templated content and action buttons](./images/message-template.png)