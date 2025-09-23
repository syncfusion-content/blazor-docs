---
layout: post
title:  Open AI Integration with Blazor AI AssistView Component | Syncfusion
description: Checkout and learn about Open AI integration with Blazor AI AssistView component in Blazor WebAssembly Application.
platform: Blazor
control: AI AssistView
documentation: ug
---

# Integration of Open AI With Blazor AI AssistView component

The Syncfusion  AI AssistView supports integration with [OpenAI](https://platform.openai.com/docs/overview), enabling advanced conversational AI features in your applications.

## Prerequisites

- OpenAI account and an API key to access the OpenAI API

- Syncfusion AI AssistView for Blazor `Syncfusion.Blazor.InteractiveChat` installed in the project

## Getting Started with the AI AssistView Component

Before integrating OpenAI, ensure the Syncfusion AI AssistView component renders correctly in the application:

[ Blazor Getting Started Guide](../getting-started)

## Install Dependencies

Install the Syncfusion Blazor package in the application.

```bash

Install-Package Syncfusion.Blazor.InteractiveChat

```

Install the Open AI AI package in the application.

```bash

Install-Package OpenAI

```

## Generate API Key

1. Go to [Open AI](https://platform.openai.com/docs/overview) and sign in. Create an account if one does not exist.

2. Once signed in, open the profile menu and select API Keys.  

3. Select + `Create new secret key`, optionally provide a name, and confirm to generate the key. 

4. Copy the key and store it securely; it is shown only once.

> `Security Note`: Never commit the API key to version control. Use environment variables or a secret manager for production.

##  Integration Open AI with AI AssistView

- Add the generated API key to the `openaiApiKey` variable used in the example below

```bash

const string openaiApiKey  = 'Place your API key here';

```

{% tabs %}
{% highlight razor %}

<div class="aiassist-container" style="height: 350px; width: 650px;">
    <SfAIAssistView @ref="sfAIAssistView" ID="aiAssistView" PromptSuggestions="@promptSuggestions" PromptRequested="@OnPromptRequest">
        <AssistViews>
            <AssistView>
                <BannerTemplate>
                    <div class="banner-content">
                        <div class="e-icons e-assistview-icon"></div>
                        <h3>AI Assistance</h3>
                        <i>To get started, provide input or choose a suggestion.</i>
                    </div>
                </BannerTemplate>
            </AssistView>
        </AssistViews>
        <AssistViewToolbar ItemClicked="ToolbarItemClicked">
            <AssistViewToolbarItem Type="ItemType.Spacer"></AssistViewToolbarItem>
            <AssistViewToolbarItem IconCss="e-icons e-refresh"></AssistViewToolbarItem>
        </AssistViewToolbar>
    </SfAIAssistView>
</div>

@code {
    private SfAIAssistView sfAIAssistView = new SfAIAssistView();
    private List<string> promptSuggestions = new List<string>
    {
        "What are the best tools for organizing my tasks?",
        "How can I maintain work-life balance effectively?"
    };
    private string openaiApiKey = "";
    private async Task OnPromptRequest(AssistViewPromptRequestedEventArgs args)
    {
        try
        {
            var openAiClient = new OpenAIClient(openaiApiKey);
            var chatClient = openAiClient.GetChatClient("gpt-4o-mini");

            OpenAI.Chat.ChatCompletion completion = await chatClient.CompleteChatAsync(args.Prompt);
            string responseText = completion.Content[0].Text;
            var pipeline = new MarkdownPipelineBuilder()
                .UseAdvancedExtensions()
                .UsePipeTables()
                .UseTaskLists()
                .Build();
            // Add the response to the AIAssistView
            await Task.Delay(1000); // Simulate delay as in original code
            args.Response = Markdown.ToHtml(responseText, pipeline);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching Open AI response: {ex.Message}");
            await Task.Delay(1000);
            args.Response = "⚠️ Something went wrong while connecting to the AI service. Please check your API key or try again later.";
        }
    }

    private void ToolbarItemClicked(AssistViewToolbarItemClickedEventArgs args)
    {
        sfAIAssistView.Prompts.Clear();
        StateHasChanged();
    }
}

{% endhighlight %}
{% endtabs %}

![Blazor AI AssistView Open AI Integration](./images/openai-integration.png)