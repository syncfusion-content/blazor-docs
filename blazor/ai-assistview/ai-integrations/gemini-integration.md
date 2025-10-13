---
layout: post
title: Gemini Integration with Blazor AI AssistView Component | Syncfusion
description: Checkout and learn about gemini integration with Blazor AI AssistView component in Blazor WebAssembly Application.
platform: Blazor
control: AI AssistView
documentation: ug
---

# Gemini AI With Blazor AI AssistView component

The Syncfusion AI AssistView integrates with [Gemini](https://ai.google.dev/gemini-api/docs/quickstart), to enable advanced conversational AI features in applications.

## Prerequisites

* The Syncfusion AI AssistView component is setup in the application:

    * [Blazor Getting Started Guide](../getting-started)

* Google account to generate an API key for accessing [Gemini AI](https://ai.google.dev/gemini-api/docs/quickstart)

* [Markdig](https://www.nuget.org/packages/Markdig) package available in the project for Markdown-to-HTML conversion (required by the sample code).

## Install Dependencies

* Install the Gemini AI package in the application.

```bash

Nuget\Install-Package Mscc.GenerativeAI

```

## Generate API Key

1. Go to [Google AI Studio](https://aistudio.google.com/app/apikey) and sign in with your google account. Create one if you do not have it.

2. Select `Get API key` from the left menu or the top-right of the dashboard.

3. Choose an existing Google Cloud project or create a new one, then click `Create API key`. 

4. Copy the generated API key and store it securely. It may be shown only once.

> Security note: Do not commit API keys to version control. Use environment variables, a secret manager, or a server-side proxy in production.

## Gemini AI with AI AssistView

* Add the generated API key in the following line.

```bash

const string GeminiApiKey = 'Place your API key here';

```

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.InteractiveChat
@using Syncfusion.Blazor.Navigations
@using Mscc.GenerativeAI
@using Markdig

<div class="aiassist-container" style="height: 350px; width: 650px;">
// Initializes the AI Assist component
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
    // Initialize Gemini API
    private readonly string geminiApiKey = "";
    // Handle user prompt: call Gemini model
    private async Task OnPromptRequest(AssistViewPromptRequestedEventArgs args)
    {
        try
        {
            var gemini = new GoogleAI(apiKey: geminiApiKey); // Replace with your Gemini API key
            var model = gemini.GenerativeModel(model: "gemini-2.5-flash"); // Select the Gemini model (update model name as needed)
            var response = await model.GenerateContent(args.Prompt);
            var responseText = response.Text;
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
            Console.WriteLine($"Error fetching Gemini response: {ex.Message}");
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

![Blazor AI AssistView Gemini Integration](../images/gemini-integration.png)