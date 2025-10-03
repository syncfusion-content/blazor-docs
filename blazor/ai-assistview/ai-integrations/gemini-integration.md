---
layout: post
title: Gemini Integration with Blazor AI AssistView Component | Syncfusion
description: Checkout and learn about gemini integration with Blazor AI AssistView component in Blazor WebAssembly Application.
platform: Blazor
control: AI AssistView
documentation: ug
---

# Integration of Gemini AI With Blazor AI AssistView component

The Syncfusion AI AssistView supports integration with [Gemini](https://ai.google.dev/gemini-api/docs/quickstart), enabling advanced conversational AI features in applications.

## Prerequisites

* Google account to generate an API key for accessing [Gemini AI](https://ai.google.dev/gemini-api/docs/quickstart)
* Syncfusion AI AssistView for Blazor package [Syncfusion.Blazor.InteractiveChat](https://www.nuget.org/packages/Syncfusion.Blazor.InteractiveChat) installed in the project.
* [Markdig](https://www.nuget.org/packages/Markdig) package available in the project for Markdown-to-HTML conversion (required by the sample code).

## Getting Started with the AI AssistView Component

Before integrating Gemini AI, ensure that the Syncfusion AI AssistView renders correctly in the application and that prerequisites are met:

[Blazor Getting Started Guide](../getting-started)

## Install Dependencies

Install the Syncfusion Blazor package in the application.

```bash

Nuget\Install-Package Syncfusion.Blazor.InteractiveChat

```

Install the Gemini AI package in the application.

```bash

Nuget\Install-Package Mscc.GenerativeAI

```

## Generate API Key

1. Go to [Google AI Studio](https://aistudio.google.com/app/api-keys) and sign in with a google account. Create a new account if needed.

2. Select `Get API key` from the left menu or the top-right of the dashboard.

3. Choose `Create API key`. Select an existing google cloud project or create a new one, then proceed.

4. After creating or selecting a project, an API key is generated and displayed. Copy the key and store it securely, as it may be shown only once.

> Security note: Do not commit API keys to version control. Use environment variables, a secret manager, or a server-side proxy in production.

##  Integration Gemini AI with AI AssistView

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
    private readonly string geminiApiKey = "";
    private async Task OnPromptRequest(AssistViewPromptRequestedEventArgs args)
    {
        try
        {
            var gemini = new GoogleAI(apiKey: geminiApiKey);
            var model = gemini.GenerativeModel(model: "gemini-1.5-flash");
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