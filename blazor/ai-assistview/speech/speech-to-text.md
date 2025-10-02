---
layout: post
title: Speech-to-Text integration with Blazor AI AssistView Component | Syncfusion
description: Checkout and learn about Speech-to-Text integration with Blazor AI AssistView component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: AI AssistView
documentation: ug
---

# Integration of Speech-to-Text with Azure OpenAI in AI AssistView

The Syncfusion Blazor AI AssistView component supports `Speech-to-Text` functionality through the browser's [Web Speech API](https://developer.mozilla.org/en-US/docs/Web/API/Web_Speech_API), enabling conversion of spoken words into text using the device's microphone.

## Prerequisites

Before integrating `Speech-to-Text`, ensure the following:

1. The Syncfusion AI AssistView component is properly set up in your Blazor application.
    - [Blazor Getting Started Guide](../getting-started)

2. The AI AssistView component is integrated with [Azure OpenAI](https://microsoft.github.io/PartnerResources/skilling/ai-ml-academy/resources/openai).

    - [Integration of Azure Open AI With Blazor AI AssistView component](../ai-integrations/openai-integration.md)

## Integrating Speech-to-Text with AI AssistView

To enable Speech-to-Text functionality, modify the `Home.razor` file to incorporate the Web Speech API. The SpeechToText component listens for microphone input, transcribes spoken words, and updates the AI AssistView's editable footer with the transcribed text. The transcribed text is then sent as a prompt to the Azure OpenAI service via the AI AssistView component.
