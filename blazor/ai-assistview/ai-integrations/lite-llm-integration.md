---
layout: post
title: LiteLLM Integration with Blazor AI AssistView Component | Syncfusion
description: Checkout and learn about LiteLLM integration with Blazor AI AssistView component in Blazor WebAssembly Application.
platform: Blazor
control: AI AssistView
documentation: ug
domainurl: ##DomainURL##
---

# Integrate LiteLLM with Blazor AI AssistView Component

The AI AssistView component can be integrated with [LiteLLM](https://docs.litellm.ai/docs/), an open-source proxy that provides a unified OpenAI-compatible API for multiple LLM providers such as [OpenAI](https://openai.com) and [Azure OpenAI](https://azure.microsoft.com/en-us/products/ai-foundry/models/openai). The AI AssistView component serves as a user interface where prompts are sent to the LiteLLM proxy, which forwards them to the configured LLM provider. This enables natural language understanding and context-aware responses.

## Prerequisites

Before starting, ensure you have the following:

* **OpenAI Account**: For generating an OpenAI API key to use with LiteLLM.

* **Python**: Version 3.8 or higher, to run the LiteLLM proxy.

* **Syncfusion AI AssistView**: Package [Syncfusion Blazor package](https://www.nuget.org/packages/Syncfusion.Blazor.InteractiveChat) installed.

* [Markdig](https://www.nuget.org/packages/Markdig) package: For parsing Markdown responses.

## Set Up the AI AssistView Component

Follow the [Getting Started](../getting-started) guide to configure and render the AI AssistView component in the application and that prerequisites are met.

## Install Dependencies

Install the required packages:

* Install the LiteLLM proxy via pip in your Python environment.

```bash

pip install "litellm[proxy]"

```
* Install the Markdig nuget packages in the application.

```bash

Nuget\Install-Package Markdig

```

## Configure the LiteLLM Proxy

* **Set Environment Variable**: Set your OpenAI API key as an environment variable for security (e.g.,`export OPENAI_API_KEY=<your-openai-api-key>` on macOS/Linux or `set OPENAI_API_KEY=<your-openai-api-key>` on Windows). Avoid hard-coding the key in files.

* **Create config.yaml**: In your project root, create a `config.yaml` file to define the model alias and routing. This exposes an OpenAI-compatible endpoint at `http://localhost:4000/v1/chat/completions`.

{% tabs %}
{% highlight yaml tabtitle="config.yaml" %}
```yaml
model_list:
  - model_name: openai/gpt-4o-mini      # Alias your frontend will use
    LiteLLM_params:
      model: gpt-4o-mini                # OpenAI base model name
      api_key: OS.environ/OPENAI_API_KEY

router_settings:
  # Optional: master_key for proxy authentication
  # master_key: test_key
  cors:
    - "*"
  cors_allow_origins:
    - "*"
```
{% endhighlight %}
{% endtabs %}

* **Start the Proxy**: 
Run the following command in your project root to start the LiteLLM proxy:

```bash

litellm --config "./config.yaml" --port 4000 --host 0.0.0.0

```
Security note: In production, use a secret manager for the API key and restrict CORS origins. The optional `master_key` can add proxy-level authentication—set `LITELLM_API_KEY` in the Blazor code to match if enabled.

## LiteLLM with AI AssistView

Modify the razor file to integrate LiteLLM with the AI AssistView component.

* Update your optional LiteLLM master key (if enabled) securely in the configuration:

```bash
const string liteLlmApiKey = "";
```

{% tabs %}
{% highlight razor %}
@page "/aiassistview-features"
@rendermode InteractiveAuto
@using Syncfusion.Blazor.InteractiveChat
@using Syncfusion.Blazor.Navigations
@using Markdig
@using System.Text.Json
@using System.Text
@inject HttpClient Http
<SfAIAssistView @ref="sfAIAssistView" ID="aiAssistView" PromptSuggestions="@promptSuggestions" PromptRequested="@OnPromptRequest">
    <AssistViews>
        <AssistView>
            <BannerTemplate>
                <div class="banner-content">
                    <div class="e-icons e-assistview-icon"></div>
                    <h3>How can I help you today?</h3>
                </div>
            </BannerTemplate>
        </AssistView>
    </AssistViews>
    <AssistViewToolbar ItemClicked="ToolbarItemClicked">
        <AssistViewToolbarItem Type="ItemType.Spacer"></AssistViewToolbarItem>
        <AssistViewToolbarItem IconCss="e-icons e-refresh"></AssistViewToolbarItem>
    </AssistViewToolbar>
</SfAIAssistView>

@code {
    private SfAIAssistView? sfAIAssistView;
    private List<string> promptSuggestions = new List<string>
    {
        "How do I prioritize my tasks?",
        "How can I improve my time management skills?"
    };
    private readonly string liteLlmHost = "http://localhost:4000";
    private readonly string liteLlmApiKey = ""; // If your LiteLLM proxy uses a master_key, set this to the same value; otherwise, leave as empty string

    // Handle user prompt: call LiteLLM proxy
    private async Task OnPromptRequest(AssistViewPromptRequestedEventArgs args)
    {
        try
        {
            var url = $"{liteLlmHost.TrimEnd('/')}/v1/chat/completions";
            var headers = new Dictionary<string, string>
            {
                { "Content-Type", "application/json" }
            };
            if (!string.IsNullOrEmpty(liteLlmApiKey))
            {
                headers.Add("Authorization", $"Bearer {liteLlmApiKey}");
            }

            var requestBody = new
            {
                model = "openai/gpt-4o-mini", // Must match model_name in config.yaml
                messages = new[] { new { role = "user", content = args.Prompt } },
                temperature = 0.7,
                max_tokens = 300,
                stream = false
            };

            Http.DefaultRequestHeaders.Clear();
            foreach (var header in headers)
            {
                Http.DefaultRequestHeaders.Add(header.Key, header.Value);
            }

            var json = JsonSerializer.Serialize(requestBody);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await Http.PostAsync(url, content);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"HTTP {response.StatusCode}");
            }

            var responseContent = await response.Content.ReadAsStringAsync();
            using var document = JsonDocument.Parse(responseContent);
            var responseText = document.RootElement
                .GetProperty("choices")[0]
                .GetProperty("message")
                .GetProperty("content")
                .GetString()?.Trim() ?? "No response received.";

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
            Console.WriteLine($"Error fetching LiteLLM response: {ex.Message}");
            await Task.Delay(1000);
            args.Response = "⚠️ Something went wrong while connecting to the AI service. Please check your LiteLLM proxy, model name, or try again later.";
        }
    }

    private void ToolbarItemClicked(AssistViewToolbarItemClickedEventArgs args)
    {
        sfAIAssistView?.Prompts.Clear();
        StateHasChanged();
    }
}
{% endhighlight %}
{% endtabs %}