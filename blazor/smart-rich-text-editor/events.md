---
layout: post
title: AssistViewSettings Events in Syncfusion Smart Rich Text Editor
description: Reference for AssistViewSettings events, arguments, and examples to handle prompt submissions, streaming responses, popup lifecycle, and toolbar actions.
platform: Blazor
control: Smart Rich Text Editor
documentation: ug
---

# AssistViewSettings Events

## AIPromptRequested
**Type:** `EventCallback<AssistViewPromptRequestedEventArgs>`

Fires when the user submits a prompt. This is where you process the user input and send it to your AI backend.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.SmartRichTextEditor
@using Syncfusion.Blazor.InteractiveChat

<SfSmartRichTextEditor>
    <AssistViewSettings AIPromptRequested="AIPromptRequested" />
</SfSmartRichTextEditor>

@code {
    private async Task AIPromptRequested(AssistViewPromptRequestedEventArgs args)
    {
        // Your required action here
    }
}

{% endhighlight %}
{% endtabs %}

---

## AIResponseStopped
**Type:** `EventCallback<ResponseStoppedEventArgs>`

Fires when the user clicks "Stop" during a streaming response.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.SmartRichTextEditor
@using Syncfusion.Blazor.InteractiveChat

<SfSmartRichTextEditor>
    <AssistViewSettings AIResponseStopped="AIResponseStopped" />
</SfSmartRichTextEditor>

@code {
    private async Task AIResponseStopped(ResponseStoppedEventArgs args)
    {
        // Your required action here
    }
}

{% endhighlight %}
{% endtabs %}

---

## AIToolbarItemClicked
**Type:** `EventCallback<AssistViewToolbarItemClickedEventArgs>`

Fires when the user clicks a toolbar button (Insert, Copy, Regenerate, etc.).

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.SmartRichTextEditor
@using Syncfusion.Blazor.InteractiveChat

<SfSmartRichTextEditor>
    <AssistViewSettings AIToolbarItemClicked="AIToolbarItemClicked" />
</SfSmartRichTextEditor>

@code {
    private async Task AIToolbarItemClicked(AssistViewToolbarItemClickedEventArgs args)
    {
        // Your required action here
    }
}

{% endhighlight %}
{% endtabs %}

---

## AIPopupOpening
**Type:** `EventCallback<BeforeOpenEventArgs>`

Fires before the AI Assistant popup opens. Use to validate permissions or prefetch data.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.SmartRichTextEditor
@using Syncfusion.Blazor.Popups

<SfSmartRichTextEditor>
    <AssistViewSettings AIPopupOpening="AIPopupOpening" />
</SfSmartRichTextEditor>

@code {
    private async Task AIPopupOpening(BeforeOpenEventArgs args)
    {
        // Your required action here
    }
}

{% endhighlight %}
{% endtabs %}

**Event Args Properties:**
- `Cancel` — Set to true to prevent opening

---

## AIPopupClosing
**Type:** `EventCallback<BeforeCloseEventArgs>`

Fires before the AI Assistant popup closes. Use to save state or confirm before closing.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.SmartRichTextEditor
@using Syncfusion.Blazor.Popups

<SfSmartRichTextEditor>
    <AssistViewSettings AIPopupClosing="AIPopupClosing" />
</SfSmartRichTextEditor>

@code {
    private async Task AIPopupClosing(BeforeCloseEventArgs args)
    {
        // Your required action here
    }
}

{% endhighlight %}
{% endtabs %}

**Event Args Properties:**
- `Cancel` — Set to true to prevent closing

---

## See Also

* [Properties](property.md)
* [Methods](method.md)
* [Appearance](appearance.md)