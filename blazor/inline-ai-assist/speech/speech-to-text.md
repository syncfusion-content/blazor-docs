---
layout: post
title: Speech To Text in Blazor Inline AI Assist | Syncfusion®
description: Checkout and learn about Speech-to-Text configuration with Blazor Inline AI Assist component in Blazor Server App and Blazor Application.
platform: Blazor
control: Inline AI Assist
documentation: ug
---

# Speech To Text in Blazor Inline AI Assist

The Blazor Inline AI Assist component integrates `Speech-to-Text` functionality through the browser's [Web Speech API](https://developer.mozilla.org/en-US/docs/Web/API/Web_Speech_API). This enables the conversion of spoken words into text using the device's microphone, allowing users to interact with the Inline AI Assist through voice input and submit prompts without typing.

## Prerequisites

Before integrating `Speech-to-Text`, ensure the following:

1. The Inline AI Assist component is properly set up in your Blazor application.
    - [Blazor Getting Started Guide](../getting-started-webapp)

2. The Inline AI Assist component is integrated with Azure OpenAI.
    - [Integration of Azure OpenAI With Blazor Inline AI Assist component](../ai-integrations/openai-integration.md)

## Configure Speech-to-Text

To enable Speech-to-Text functionality in the Blazor Inline AI Assist component, add the `<InlineAIAssistSpeechToText>` child tag with `Enable="true"` to the `<SfInlineAIAssist>` component.

The `<InlineAIAssistSpeechToText>` tag renders a microphone icon in the Inline AI Assist popup's built-in editor. When clicked, it listens to audio input from the device's microphone, transcribes spoken words into text using the browser's [SpeechRecognition](https://developer.mozilla.org/en-US/docs/Web/API/SpeechRecognition) API, and populates the prompt editor with the recognized text.

### Configuration Options

* **[`Enable`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.InteractiveChat.InlineAIAssistSpeechToText.html#Syncfusion_Blazor_InteractiveChat_InlineAIAssistSpeechToText_Enable)**: Set to `true` to enable the Speech-to-Text feature in the Inline AI Assist popup.
* **[`Language`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.InteractiveChat.InlineAIAssistSpeechToText.html#Syncfusion_Blazor_InteractiveChat_InlineAIAssistSpeechToText_Language)**: Specifies the language for speech recognition. For example:

    * `en-US` for American English
    * `fr-FR` for French

* **[`AllowInterimResults`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.InteractiveChat.InlineAIAssistSpeechToText.html#Syncfusion_Blazor_InteractiveChat_InlineAIAssistSpeechToText_AllowInterimResults)**: Set to `true` to receive real-time (interim) recognition results, or `false` to receive only final results.

```cshtml
@using Syncfusion.Blazor.InteractiveChat
@using Syncfusion.Blazor.Buttons

<style>
    #editableText {
        width: 100%;
        min-height: 120px;
        max-height: 300px;
        overflow-y: auto;
        font-size: 16px;
        padding: 12px;
        border-radius: 4px;
        border: 1px solid;
    }
</style>
<div class="container" style="height: 350px; width: 650px;">
    <SfButton id="summarizeButton" IsPrimary="true" Style="margin-bottom: 10px;" @onclick="OnSummarizeClick">Content Summarize</SfButton>
    <div id="editableText" contenteditable="true">
        @((MarkupString)editableContent)
    </div>
    <SfInlineAIAssist @ref="inlineAssist" RelateTo="#summarizeButton" PromptRequested="OnPromptRequestAsync">
		<InlineAIAssistSpeechToText Enable="true"></InlineAIAssistSpeechToText>
        <ResponseActions ItemSelect="OnItemSelectAsync"></ResponseActions>
    </SfInlineAIAssist>
</div>
@code {
    private SfInlineAIAssist inlineAssist = new SfInlineAIAssist();
    private string editableContent = @"<p>Inline AI Assist component provides intelligent text processing capabilities that enhance user productivity. It leverages advanced natural language processing to understand context and deliver precise suggestions. Users can seamlessly integrate AI-powered features into their applications.</p>
        <p>With real-time response streaming and customizable prompts, developers can create interactive experiences. The component supports multiple response modes including inline editing and popup-based interactions.</p>";
    private async Task OnPromptRequestAsync(PromptRequestedEventArgs args)
    {
        await Task.Delay(1000);
        string defaultResponse = "For real-time prompt processing, connect the Inline AI Assist component to your preferred AI service, such as OpenAI or Azure Cognitive Services. Ensure you obtain the necessary API credentials to authenticate and enable seamless integration.";
        await inlineAssist.UpdateResponseAsync(defaultResponse);
    }
    private async Task OnItemSelectAsync(ResponseItemSelectEventArgs args)
    {
        if (args.Item.Label == "Accept")
        {
            var lastPrompt = inlineAssist?.Prompts.LastOrDefault();
            if (lastPrompt != null && !string.IsNullOrEmpty(lastPrompt.Response))
            {
                editableContent = $"<p>{lastPrompt.Response}</p>";
            }
            await inlineAssist!.HidePopupAsync();
        }
        else if (args.Item.Label == "Discard")
        {
            await inlineAssist!.HidePopupAsync();
        }
    }
    private async Task OnSummarizeClick()
    {
        await inlineAssist.ShowPopupAsync();
    }
}
```

![Integrating Speech-to-Text with Inline AI Assist](../images/inline-assist-stt.webp)

## Error Handling

The `SpeechToText` component provides events to handle errors that may occur during speech recognition. For more information, refer to the [Error Handling](https://blazor.syncfusion.com/documentation/speech-to-text/speech-recognition#error-handling) section in the documentation.

## Browser Compatibility

The `SpeechToText` component relies on the [Speech Recognition API](https://developer.mozilla.org/en-US/docs/Web/API/SpeechRecognition), which has limited browser support. Refer to the [Browser Compatibility](https://blazor.syncfusion.com/documentation/speech-to-text/speech-recognition#browser-support) section for detailed information.
