---
layout: post
title: AssistViewSettings Methods in Syncfusion Smart Rich Text Editor
description: Comprehensive reference for AssistViewSettings methods with examples to show/hide the AI popup, execute prompts, stream/update responses, and manage history.
platform: Blazor
control: Smart Rich Text Editor
documentation: ug
---

# AssistViewSettings Methods

Using the public methods, you can build custom workflows with the AI Assistant. Actions such as retrieving conversation history, executing prompts, updating responses, showing or hiding the AI Assistant, and clearing conversation history can all be achieved using the following public methods programmatically.

| Method | Description |
|--------|-------------|
| `GetAIPromptHistoryAsync()` | Retrieves all saved prompts and responses from the conversation history. The history remains saved after the AI Assistant popup is closed. Returns a Task with an array of AssistViewPrompt objects. |
| `ExecuteAIPromptAsync(prompt: string)` | Sends a prompt to the AI Assistant programmatically. The prompt text is executed as if the user typed it directly. |
| `UpdateAIResponseAsync(outputResponse: string, isFinalUpdate?: boolean)` | Updates or streams the AI response display. Use for custom streaming implementations. Set isFinalUpdate to true when streaming is complete. |
| `ShowAIPopupAsync()` | Opens the AI Assistant popup and initiates a new conversation session. |
| `HideAIPopupAsync()` | Closes the AI Assistant popup. |
| `ClearAIPromptHistoryAsync()` | Deletes all conversation history and resets the AI Assistant to a clean state. |

---

## Complete Example Using All Methods

The following example demonstrates how to use all AssistViewSettings methods together in a single button click handler to create a comprehensive workflow:

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.SmartRichTextEditor
@using Syncfusion.Blazor.InteractiveChat
@using Syncfusion.Blazor.Buttons

<div style="padding-bottom: 15px">
    <SfButton @onclick="ShowPopupAsync">Show AI Popup</SfButton>
    <SfButton @onclick="ExecutePromptAsync">Execute AI Prompt</SfButton>
    <SfButton @onclick="ClearHistoryAsync">Clear AI History</SfButton>
    <SfButton @onclick="UpdateResponseAsync">Update AI Response</SfButton>
    <SfButton @onclick="HidePopupAsync">Hide AI Popup</SfButton>
    <SfButton @onclick="GetHistoryAsync">Get AI History</SfButton>
</div>
<SfSmartRichTextEditor>
    <AssistViewSettings @ref="AssistViewSettings" Placeholder="Ask AI to enhance your content..." />
</SfSmartRichTextEditor>
@code {
    private AssistViewSettings AssistViewSettings;

    private async Task ShowPopupAsync()
    {
        await AssistViewSettings.ShowAIPopupAsync();
    }

    private async Task ExecutePromptAsync()
    {
        await AssistViewSettings.ExecuteAIPromptAsync("Write a professional summary about AI");
    }

    private async Task ClearHistoryAsync()
    {
        await AssistViewSettings.ClearAIPromptHistoryAsync();
    }

    private async Task UpdateResponseAsync()
    {
        string customResponse = "This is a custom AI-generated response added programmatically via UpdateAIResponseAsync().";
        await AssistViewSettings.UpdateAIResponseAsync(customResponse, true);
    }

    private async Task HidePopupAsync()
    {
        await AssistViewSettings.HideAIPopupAsync();
    }

    private async Task GetHistoryAsync()
    {
        AssistViewPrompt[] history = await AssistViewSettings.GetAIPromptHistoryAsync();
    }
}

{% endhighlight %}
{% endtabs %}

---

## See Also

* [Properties](property.md)
* [Appearance](appearance.md)
* [Events](events.md)