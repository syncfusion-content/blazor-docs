---
layout: post
title: Methods in Blazor AI AssistView | Syncfusion®
description: Execute prompts dynamically in Blazor AI AssistView using ExecutePromptAsync method to trigger PromptRequested event callbacks.
platform: Blazor
control: AI AssistView
documentation: ug
---

# Methods in Blazor AI AssistView

## Executing prompt

You can use the [ExecutePromptAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.InteractiveChat.SfAIAssistView.html#Syncfusion_Blazor_InteractiveChat_SfAIAssistView_ExecutePromptAsync_System_String_) method to execute the prompts dynamically in the AI AssistView. It accepts prompts as string values, which triggers the [PromptRequested](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.InteractiveChat.SfAIAssistView.html#Syncfusion_Blazor_InteractiveChat_SfAIAssistView_PromptRequested) event and performs the callback actions.

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