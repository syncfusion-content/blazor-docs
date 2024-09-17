---
layout: post
title: Methods in Blazor AI AssistView Component | Syncfusion
description: Checkout and learn here all about Methods with Syncfusion Blazor AI AssistView component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: AI AssistView
documentation: ug
---

# Methods in Blazor AI AssistView component

## Executing prompt

You can use the `ExecutePromptAsync` method to execute the prompts dynamically in the AI AssistView. It accepts prompts as string values, which triggers the `PromptRequested` event and update the response using the `Response` property in the event callback actions.

```cshtml
@using Syncfusion.Blazor.InteractiveChat

<div class="aiassist-container" style="height: 350px; width: 650px;">
    <button id="executePrompt" @onclick="GenerateContent">Execute Prompt</button>
    <SfAIAssistView @ref="AIAssist" PromptRequested="PromptRequest"></SfAIAssistView>
</div>

@code {
    private SfAIAssistView AIAssist;
    private async Task GenerateContent()
    {
        await AIAssist.ExecutePromptAsync("What is the current temperature?");
    }
    private async Task PromptRequest(AssistViewPromptRequestedEventArgs args)
    {
        await Task.Delay(1000);
        var defaultResponse = "For real-time prompt processing, connect the AI AssistView component to your preferred AI service, such as OpenAI or Azure Cognitive Services. Ensure you obtain the necessary API credentials to authenticate and enable seamless integration.";
        args.Response = defaultResponse;
    }
}
<style>
    #executePrompt {
        margin-bottom: 10px;
        border: none;
        border-radius: 4px;
        padding: 5px 10px;
    }
</style>
```