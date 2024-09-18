---
layout: post
title: Assist view in Blazor AI AssistView Component | Syncfusion
description: Checkout and learn here all about Assist view with Syncfusion Blazor AI AssistView component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: AI AssistView
documentation: ug
---

# Assist view in Blazor AI AssistView component

## Setting prompt text

You can use the `Prompt` property to define the prompt text for the AI AssistView component.

```cshtml

@using Syncfusion.Blazor.InteractiveChat

<div class="aiassist-container" style="height: 350px; width: 650px;">
    <SfAIAssistView Prompt = "What tools or apps can help me prioritize tasks?" PromptRequested="@PromptRequest"></SfAIAssistView>
</div>

@code {
    private async Task PromptRequest(AssistViewPromptRequestedEventArgs args)
    {
        await Task.Delay(1000);
        var defaultResponse = "For real-time prompt processing, connect the AI AssistView component to your preferred AI service, such as OpenAI or Azure Cognitive Services. Ensure you obtain the necessary API credentials to authenticate and enable seamless integration.";
        args.Response = defaultResponse;
    }
}

```

![Blazor AI AssistView PromptText](./images/prompt-text.png)

## Setting prompt placeholder

You can use the `PromptPlaceholder` property to set the placeholder text for the prompt textarea. The default value is `Type prompt for assistance...`.

```cshtml

@using Syncfusion.Blazor.InteractiveChat

<div class="aiassist-container" style="height: 350px; width: 650px;">
    <SfAIAssistView PromptPlaceholder="Type a message..." PromptRequested="@PromptRequest"></SfAIAssistView>
</div>

@code {
    private async Task PromptRequest(AssistViewPromptRequestedEventArgs args)
    {
        await Task.Delay(1000);
        var defaultResponse = "For real-time prompt processing, connect the AI AssistView component to your preferred AI service, such as OpenAI or Azure Cognitive Services. Ensure you obtain the necessary API credentials to authenticate and enable seamless integration.";
        args.Response = defaultResponse;
    }
}

```

![Blazor AI AssistView PromptPlaceholder](./images/prompt-placeholder.png)

## Prompt-response collection

By using the `Prompts` property, you can specify the collection of prompts and responses, allowing you to load pre-defined pairs or individual entries ensuring the AI AssistView component is initialized with the configured data.

The `Prompts` collection stores all the prompts and responses generated.

```cshtml

@using Syncfusion.Blazor.InteractiveChat

<div class="aiassist-container" style="height: 350px; width: 650px;">
    <SfAIAssistView Prompts="@prompts" PromptRequested="@PromptRequest"></SfAIAssistView>
</div>

@code {
    private List<AssistViewPrompt> prompts = new List<AssistViewPrompt>()
    {
        new AssistViewPrompt() { Prompt = "What is AI?", Response = "<div>AI stands for Artificial Intelligence, enabling machines to mimic human intelligence for tasks such as learning, problem-solving, and decision-making.</div>" }
    };
    private async Task PromptRequest(AssistViewPromptRequestedEventArgs args)
    {
        await Task.Delay(1000);
        var isPromptFound = prompts.Any(prompt => prompt.Prompt == args.Prompt);
        var promptData = prompts.FirstOrDefault(prompt => prompt.Prompt == args.Prompt);
        var defaultResponse = "For real-time prompt processing, connect the AI AssistView component to your preferred AI service, such as OpenAI or Azure Cognitive Services. Ensure you obtain the necessary API credentials to authenticate and enable seamless integration.";
        args.Response = isPromptFound ? promptData.Response : defaultResponse;
    }
}

```

![Blazor AI AssistView Prompts](./images/assistview-prompts.png)

## Adding prompt suggestions

By using the `PromptSuggestions` property, you can configure the list of suggested prompts in the AI AssistView. Users can choose from these suggestions to use as their prompts.

```cshtml

@using Syncfusion.Blazor.InteractiveChat

<div class="aiassist-container" style="height: 350px; width: 650px;">
    <SfAIAssistView PromptSuggestions="@suggestions" PromptRequested="@PromptRequest"></SfAIAssistView>
</div>

@code {
    List<string> suggestions = new List<string> { "Best practices for clean, maintainable code?", "How to optimize code editor for speed?" };
    private async Task PromptRequest(AssistViewPromptRequestedEventArgs args)
    {
        await Task.Delay(1000);
        var response1 = "Use clear naming, break code into small functions, avoid repetition, write tests, and follow coding standards.";
        var response2 = "Install useful extensions, set up shortcuts, enable linting, and customize settings for smoother development.";
        var defaultResponse = "For real-time prompt processing, connect the AI AssistView component to your preferred AI service, such as OpenAI or Azure Cognitive Services. Ensure you obtain the necessary API credentials to authenticate and enable seamless integration.";
        args.Response = args.Prompt == suggestions[0] ? response1 : args.Prompt == suggestions[1] ? response2 : defaultResponse;
    }
}

```

![Blazor AI AssistView PromptSuggestions](./images/assistview-suggestions.png)

### Adding suggestion headers

You can use the `PromptSuggestionsHeader` property to set the header text for the prompt suggestions in the AI AssistView.

```cshtml

@using Syncfusion.Blazor.InteractiveChat

<div class="aiassist-container" style="height: 350px; width: 650px;">
    <SfAIAssistView PromptSuggestions="@suggestions" PromptSuggestionsHeader="Suggested Prompts" PromptRequested="@PromptRequest"></SfAIAssistView>
</div>

@code {
    List<string> suggestions = new List<string> { "Best practices for clean, maintainable code?", "How to optimize code editor for speed?" };
    private async Task PromptRequest(AssistViewPromptRequestedEventArgs args)
    {
        await Task.Delay(1000);
        var response1 = "Use clear naming, break code into small functions, avoid repetition, write tests, and follow coding standards.";
        var response2 = "Install useful extensions, set up shortcuts, enable linting, and customize settings for smoother development.";
        var defaultResponse = "For real-time prompt processing, connect the AI AssistView component to your preferred AI service, such as OpenAI or Azure Cognitive Services. Ensure you obtain the necessary API credentials to authenticate and enable seamless integration.";
        args.Response = args.Prompt == suggestions[0] ? response1 : args.Prompt == suggestions[1] ? response2 : defaultResponse;
    }
}

```

![Blazor AI AssistView PromptSuggestionsHeader](./images/assistview-suggestion-header.png)

## Adding prompt iconCSS

You can customize the appearance of the prompter avatar by using the `PromptIconCss` property.

```cshtml

@using Syncfusion.Blazor.InteractiveChat

<div class="aiassist-container" style="height: 350px; width: 650px;">
    <SfAIAssistView Prompts="@prompts" PromptRequested="@PromptRequest" PromptIconCss="e-icons e-user"></SfAIAssistView>
</div>

@code {
    private List<AssistViewPrompt> prompts = new List<AssistViewPrompt>()
    {
        new AssistViewPrompt() { Prompt = "What is AI?", Response = "<div>AI stands for Artificial Intelligence, enabling machines to mimic human intelligence for tasks such as learning, problem-solving, and decision-making.</div>" }
    };
    private async Task PromptRequest(AssistViewPromptRequestedEventArgs args)
    {
        await Task.Delay(1000);
        var isPromptFound = prompts.Any(prompt => prompt.Prompt == args.Prompt);
        var promptData = prompts.FirstOrDefault(prompt => prompt.Prompt == args.Prompt);
        var defaultResponse = "For real-time prompt processing, connect the AI AssistView component to your preferred AI service, such as OpenAI or Azure Cognitive Services. Ensure you obtain the necessary API credentials to authenticate and enable seamless integration.";
        args.Response = isPromptFound ? promptData.Response : defaultResponse;
    }
}

```

![Blazor AI AssistView PromptIcon](./images/assistview-prompt-icon.png)

## Adding response iconCSS

You can use the `ResponseIconCss` property to customize the appearance of the responder avatar. By default, the `e-assistview-icon` class is added as the built-in AI AssistView response icon.

```cshtml

@using Syncfusion.Blazor.InteractiveChat

<div class="aiassist-container" style="height: 350px; width: 650px;">
    <SfAIAssistView Prompts="@prompts" PromptRequested="@PromptRequest" ResponseIconCss="e-icons e-star-filled"></SfAIAssistView>
</div>

@code {
    private List<AssistViewPrompt> prompts = new List<AssistViewPrompt>()
    {
        new AssistViewPrompt() { Prompt = "What is AI?", Response = "<div>AI stands for Artificial Intelligence, enabling machines to mimic human intelligence for tasks such as learning, problem-solving, and decision-making.</div>" }
    };
    private async Task PromptRequest(AssistViewPromptRequestedEventArgs args)
    {
        await Task.Delay(1000);
        var isPromptFound = prompts.Any(prompt => prompt.Prompt == args.Prompt);
        var promptData = prompts.FirstOrDefault(prompt => prompt.Prompt == args.Prompt);
        var defaultResponse = "For real-time prompt processing, connect the AI AssistView component to your preferred AI service, such as OpenAI or Azure Cognitive Services. Ensure you obtain the necessary API credentials to authenticate and enable seamless integration.";
        args.Response = isPromptFound ? promptData.Response : defaultResponse;
    }
}

```

![Blazor AI AssistView ResponseIconCss](./images/assistview-response-icon.png)
