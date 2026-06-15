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

The Inline AI Assist control triggers the [Created](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.InteractiveChat.SfAIAssistView.html#Syncfusion_Blazor_InteractiveChat_SfAIAssistView_Created) event when the control rendering is completed.

```cshtml
<div class="container">
    <ejs-inlineaiassist id="inline-assist" Created="onCreated"></ejs-inlineaiassist>
</div>
<script>
    function Created() {
        // Your required actions here
    }
</script>
```

## PromptRequest

The `PromptRequest` event is triggered when the prompt request is made in the Inline AI Assist control.

```cshtml
<div class="container">
    <ejs-inlineaiassist id="inline-assist" PromptRequest="onPromptRequest"></ejs-inlineaiassist>
</div>
<script>
    function onPromptRequest() {
        // Your required actions here
    }
</script>
```

## Open

The `Open` event is triggered when the Inline AI Assist popup is opened.

```cshtml
<div class="container">
    <ejs-inlineaiassist id="inline-assist" Open="onOpen"></ejs-inlineaiassist>
</div>
<script>
    function onOpen() {
        // Your required actions here
    }
</script>
```

### Close

The `Close` event is triggered when the Inline AI Assist popup is closed.

```cshtml
<div class="container">
    <ejs-inlineaiassist id="inline-assist" Close="onClose"></ejs-inlineaiassist>
</div>
<script>
    function onClose() {
        // Your required actions here
    }
</script>
```