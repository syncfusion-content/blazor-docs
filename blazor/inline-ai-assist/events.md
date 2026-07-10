---
layout: post
title: Events in Blazor Inline AI Assist Control | Syncfusion
description: Checkout and learn about Events with Blazor Inline AI Assist component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: Inline AI Assist
documentation: ug
---

# Events in Blazor Inline AI Assist control

This section describes the Inline AI Assist events that will be triggered when appropriate actions are performed. The following events are available in the Inline AI Assist control.

## Created

The Inline AI Assist control triggers the `Created` event when the control rendering is completed.

{% tabs %}
{% highlight razor tabtitle="razor" %}

@using Syncfusion.Blazor.InteractiveChat

<div class="container" style="height: 350px; width: 650px;">
    <SfInlineAIAssist Created="OnCreated"></SfInlineAIAssist>
</div>
@code {
    private void OnCreated(object args)
    {
        // Your required actions here
    }
}

{% endhighlight %}
{% endtabs %}

## PromptRequested

The `PromptRequested` event is triggered when the prompt request is made in the Inline AI Assist control.

{% tabs %}
{% highlight razor tabtitle="razor" %}

@using Syncfusion.Blazor.InteractiveChat

<div class="container" style="height: 350px; width: 650px;">
    <SfInlineAIAssist PromptRequested="OnPromptRequested"></SfInlineAIAssist>
</div>
@code {
    private void OnPromptRequested(PromptRequestedEventArgs args)
    {
        // Your required actions here
    }
}

{% endhighlight %}
{% endtabs %}

## Opened

The `Opened` event is triggered when the Inline AI Assist popup is opened.

{% tabs %}
{% highlight razor tabtitle="razor" %}

@using Syncfusion.Blazor.InteractiveChat

<div class="container" style="height: 350px; width: 650px;">
    <SfInlineAIAssist Opened="OnOpened"></SfInlineAIAssist>
</div>
@code {
    private void OnOpened(OpenEventArgs args)
    {
        // Your required actions here
    }
}

{% endhighlight %}
{% endtabs %}

### Closed

The `Closed` event is triggered when the Inline AI Assist popup is closed.

{% tabs %}
{% highlight razor tabtitle="razor" %}

@using Syncfusion.Blazor.InteractiveChat

<div class="container" style="height: 350px; width: 650px;">
    <SfInlineAIAssist Closed="OnClosed"></SfInlineAIAssist>
</div>
@code {
    private void OnClosed(CloseEventArgs args)
    {
        // Your required actions here
    }
}

{% endhighlight %}
{% endtabs %}