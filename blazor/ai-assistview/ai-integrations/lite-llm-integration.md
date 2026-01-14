---
layout: post
title: LiteLLM Integration with Blazor AI AssistView Component | Syncfusion
description: Checkout and learn about LiteLLM integration with Blazor AI AssistView component in Blazor WebAssembly Application.
platform: Blazor
control: AI AssistView
documentation: ug
domainurl: ##DomainURL##
---

# Integrate AI AssistView with LiteLLM

The **AI AssistView** component can also be integrated with [LiteLLM](https://docs.litellm.ai/docs), an open-source proxy that provides a unified, OpenAI-compatible API for multiple LLM providers such as [OpenAI](https://openai.com) and [Azure OpenAI](https://azure.microsoft.com/en-us/products/ai-foundry/models/openai).

In this setup:
* **AI AssistView** serves as the user interface for entering prompts.
* Prompts are sent to the **LiteLLM proxy**, which forwards them to the configured LLM provider.
* The LLM provider processes the prompt and returns a response through LiteLLM.
* This enables **natural language understanding** and **context-aware responses** without changing the AssistView integration logic, as LiteLLM uses the same OpenAI-style API.

## Prerequisites

Before starting, ensure you have the following:

* **OpenAI Account**: Access to OpenAI services and a generated **API key**.

* **Python**: Required to run the **LiteLLM proxy**.

* **Syncfusion AI AssistView**: Package [Syncfusion Blazor package](https://www.nuget.org/packages/Syncfusion.Blazor.InteractiveChat) installed.

* **Markdig**: For parsing Markdown responses.

```bash

Nuget\Install-Package Markdig

```

## Set Up the AI AssistView Component

Follow the [Getting Started](../getting-started) guide to configure and render the AI AssistView component in the application and that prerequisites are met.

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

Security note: In production, use a secret manager for the API key and restrict CORS origins. The optional `master_key` can add proxy-level authentication—set `LITELLM_API_KEY` in the Blazor code to match if enabled.

## Configure AI AssistView with LiteLLM

To integrate **LiteLLM** with the **Syncfusion AI AssistView** component, modify the razor file in your Blazor application. The component will send user prompts to the LiteLLM proxy, which forwards them to the configured LLM provider (e.g., **OpenAI** or **Azure OpenAI**) and returns natural language responses.

In the following example:

* The [PromptRequested](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.InteractiveChat.SfAIAssistView.html#Syncfusion_Blazor_InteractiveChat_SfAIAssistView_PromptRequested) event sends the user prompt to the LiteLLM proxy at `/v1/chat/completions`. 
* The proxy uses the **model alias** defined in `config.yaml` (e.g., `openai/gpt-4o-mini`) and routes the request to the actual LLM provider. 
* The response is parsed as **Markdown** using the `Markdig` library and displayed in the AI AssistView component.

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

## Run and Test

### Start the proxy:

Navigate to your project root and run the following command to start the proxy:

```bash
pip install "litellm[proxy]"
litellm --config "./config.yaml" --port 4000 --host 0.0.0.0
```

### Start the application:

In a separate terminal window, navigate to your project folder and start the Blazor application:

```bash
dotnet run
```

Open your app to interact with the AI AssistView component integrated with LiteLLM.

## Troubleshooting

* `401 Unauthorized`: Verify your `API_KEY` and model deployment name.
* `Model not found`: Ensure model matches `model_name` in `config.yaml`.
* `CORS issues`: Configure `router_settings.cors_allow_origins` properly.