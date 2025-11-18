---
layout: post
title: Fullscreen Mode in Blazor RichTextEditor | Syncfusion
description: Checkout and learn here all about Fullscreen Mode in Syncfusion Blazor Rich Text Editor component and more.
platform: Blazor
control: RichTextEditor
documentation: ug
---

# Fullscreen Mode in Blazor Rich Text Editor Component

The Fullscreen mode allows the Rich Text Editor to expand and occupy the entire browser viewport. This provides a distraction-free editing experience and more space to work with content and toolbar features.

You can enable fullscreen mode using the `FullScreen` icon toolbar button. Once activated, the editor transitions into fullscreen view, hiding other page elements and maximizing the editing area.

## How it works

Click the fullscreen icon in the toolbar to toggle fullscreen mode. When enabled, the editor:

- Expands to fill the entire browser window.
- Adjusts its layout to optimize space for content and tools.
- Can be exited by clicking the same icon again or pressing the `Esc` key.

{% tabs %}
{% highlight razor %}

{% include_relative code-snippet/fullscreen.razor %}

{% endhighlight %}
{% endtabs %}

![Blazor RichTextEditor fullscreen](../images/blazor-richtexteditor-fullscreen.png)