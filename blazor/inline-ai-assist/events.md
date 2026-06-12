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

## created

The Inline AI Assist control triggers the `created` event when the control rendering is completed.

```cshtml

<div class="container">
    <ejs-inlineaiassist id="inline-assist" created="onCreated"></ejs-inlineaiassist>
</div>

<script>
    function created() {
        // Your required actions here
    }
</script>

```

## promptRequest

The `promptRequest` event is triggered when the prompt request is made in the Inline AI Assist control.

```cshtml

<div class="container">
    <ejs-inlineaiassist id="inline-assist" promptRequest="onPromptRequest"></ejs-inlineaiassist>
</div>

<script>
    function onPromptRequest() {
        // Your required actions here
    }
</script>

```

## open

The `open` event is triggered when the Inline AI Assist popup is opened.

```cshtml

<div class="container">
    <ejs-inlineaiassist id="inline-assist" open="onOpen"></ejs-inlineaiassist>
</div>

<script>
    function onOpen() {
        // Your required actions here
    }
</script>

```

### close

The `close` event is triggered when the Inline AI Assist popup is closed.

```cshtml

<div class="container">
    <ejs-inlineaiassist id="inline-assist" close="onClose"></ejs-inlineaiassist>
</div>

<script>
    function onClose() {
        // Your required actions here
    }
</script>

```