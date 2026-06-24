---
layout: post
title: Enable Chunk Messages in Blazor Rich Text Editor | Syncfusion®
description: Learn how to process large HTML content in Blazor RichTextEditor without increasing the SignalR hub MaximumReceiveMessageSize.
platform: Blazor
control: RichTextEditor
documentation: ug
---

# Process large HTML content without increasing maximum message size

The Blazor **Rich Text Editor** component supports processing large HTML content without increasing the SignalR hub maximum receive message size (`MaximumReceiveMessageSize`, default 32 KB) by using chunk messaging.

Enable this behavior by setting the [EnableChunkMessages](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.SfRichTextEditor.html#Syncfusion_Blazor_RichTextEditor_SfRichTextEditor_EnableChunkMessages) property to `true`. The default value is `false`.

When `EnableChunkMessages` is enabled, the Rich Text Editor splits large HTML content into smaller chunks and processes them sequentially. This significantly improves reliability when pasting large content under SignalR message size limits. 

### Example

The following example shows how to enable chunk messaging in the Rich Text Editor:

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

@using Syncfusion.Blazor.RichTextEditor

<SfRichTextEditor EnableChunkMessages="true">
    EnableChunkMessages - sends large HTML content in chunks without increasing SignalR hub MaximumReceiveMessageSize (32 KB).
</SfRichTextEditor>

{% endhighlight %}
{% endtabs %}