---
layout: post
title:  Text-to-Speech integration with Blazor AI AssistView Component | Syncfusion
description: Checkout and learn about Text-to-Speech integration with Blazor AI AssistView component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: AI AssistView
documentation: ug
---

# Integration of Text-to-Speech with Azure OpenAI in AI AssistView


The Syncfusion Blazor AI AssistView component supports `Text-to-Speech` (TTS) functionality using the browser's Web Speech API specifically using the [SpeechSynthesisUtterance](https://developer.mozilla.org/en-US/docs/Web/API/SpeechSynthesisUtterance) interface to convert AI-generated response into spoken audio.

The Syncfusion AI AssistView supports integration with a `Text-to-Speech` (TTS) feature, which uses the browser's built-in [Web Speech API](https://developer.mozilla.org/en-US/docs/Web/API/Web_Speech_API) to convert the AI's response into speech.

## Prerequisites

Before integrating `Text-to-Speech`, ensure the following:

1. The Syncfusion AI AssistView component is properly set up in your Blazor application.
    - [Blazor Getting Started Guide](../getting-started)

2. The AI AssistView component is integrated with [Azure OpenAI](https://microsoft.github.io/PartnerResources/skilling/ai-ml-academy/resources/openai).

    - [Integration of Azure Open AI With Blazor AI AssistView component](../ai-integrations/openai-integration.md)

## Integrating Text-to-Speech with AI AssistView

To enable Text-to-Speech functionality, modify the `Home.razor` file to incorporate the Web Speech API. A custom `Read Aloud` button is added to the response toolbar using the [ResponseToolbarItem](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.InteractiveChat.ResponseToolbarItem.html) property. When clicked, the `ItemClicked` event extracts plain text from the generated AI response and use the browser SpeechSynthesis API to read it aloud.
