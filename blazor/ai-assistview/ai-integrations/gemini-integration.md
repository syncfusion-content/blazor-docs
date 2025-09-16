---
layout: post
title: Gemini Integration with Blazor AI AssistView Component | Syncfusion
description: Checkout and learn about gemini integration with Blazor AI AssistView component in Blazor WebAssembly Application.
platform: Blazor
control: AI AssistView
documentation: ug
---

# Integration of Gemini AI With Blazor AI AssistView component

The Syncfusion  AI AssistView supports integration with [Gemini](https://ai.google.dev/gemini-api/docs/quickstart), enabling advanced conversational AI features in your applications.

## Prerequisites

* Google account to generate API key on accessing `Gemini AI`
* Syncfusion AI AssistView for Blazor `Syncfusion.Blazor.InteractiveChat` installed in your project. 

## Getting Started with the AI AssistView Component

Before integrating Gemini AI, ensure that the Syncfusion AI AssistView is correctly rendered in your application:

[ Blazor Getting Started Guide](../getting-started)

## Install Dependencies

Install the Syncfusion Blazor package in the application.

```bash

Install-Package Syncfusion.Blazor.InteractiveChat

```

Install the Gemini AI package in the application.

```bash

Install-Package Mscc.GenerativeAI

```

## Generate API Key

1. Go to [Google AI Studio](https://aistudio.google.com/app/apikey) and sign in with your Google account. If you don’t have one, create a new account.

2. Once logged in, click on `Get API Key` from the left-hand menu or the top-right corner of the dashboard.

3. Click the `Create API Key` button. You’ll be prompted to either select an existing Google Cloud project or create a new one. Choose the appropriate option and proceed. 

4. After selecting or creating a project, your API key will be generated and displayed. Copy the key and store it securely, as it will only be shown once.

> `Security Note`: Never commit the API key to version control. Use environment variables or a secret manager for production.

##  Integration Gemini AI with AI AssistView

> Add your generated `API Key` at the line 

```bash

const string GeminiApiKey = 'Place your API key here';

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

![Blazor AI AssistView Gemini Integration](images/gemini-integration.png)