---
layout: post
title:  Azure Open AI with Blazor AI AssistView Component | Syncfusion
description: Checkout and learn about Azure Open AI with Blazor AI AssistView component in Blazor WebAssembly Application.
platform: Blazor
control: AI AssistView
documentation: ug
---

# Integration of Azure OpenAI With Blazor AI AssistView component

The Syncfusion AI AssistView supports integration with [Azure Open AI](https://microsoft.github.io/PartnerResources/skilling/ai-ml-academy/resources/openai), enabling advanced conversational AI features in your applications.

## Prerequisites

- An Azure subscription with an Azure OpenAI resource
- A deployed chat completion model (for example, gpt-4o-mini) with:
  - Endpoint URL
  - API key
  - Deployment name
- Syncfusion AI AssistView for Blazor `Syncfusion.Blazor.InteractiveChat` installed in the project

## Getting Started with the AI AssistView Component

Before integrating Azure OpenAI, ensure the Syncfusion AI AssistView component renders correctly in the application:

[Blazor Getting Started Guide](../getting-started)

## Install Dependencies

Install the Syncfusion Blazor package in the application.

```bash

Install-Package Syncfusion.Blazor.InteractiveChat

```

Install the Markdown rendering package used to convert model responses to HTML.

```bash
Install-Package Markdig
```

Note: The sample below uses HttpClient directly and does not require the Azure/OpenAI SDKs.

## Generate API Key and Endpoint (Azure OpenAI)

1. In the Azure Portal, open your Azure OpenAI resource.

2. Navigate to Resource Management > Keys and Endpoint.

3. Copy an API key and the Endpoint URL.

4. Ensure you have a Deployment Name for a chat-capable model (for example, gpt-4o-mini).

Security Note: Never commit secrets to source control. Use environment variables or a secret manager for production.

## Integration: Azure OpenAI with AI AssistView

- Configure your Azure OpenAI endpoint, API key, and deployment name in your Program.cs (or using your preferred configuration mechanism).

- Register the service for dependency injection.

- Inject and use the service in your Razor component.

{% tabs %}
{% highlight c# tabtitle="razor" %}

@using AIAssistView_AzureAI.Components.Services
@using Syncfusion.Blazor.InteractiveChat
@using Syncfusion.Blazor.Navigations
@inject AzureOpenAIService OpenAIService

<div class="aiassist-container" style="height: 450px; width: 650px;">
    <SfAIAssistView @ref="assistView" ID="aiAssistView" PromptSuggestions="@promptSuggestions" PromptRequested="@PromptRequest">
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
    private SfAIAssistView assistView;
    private string finalResponse { get; set; }
    private List<string> promptSuggestions = new List<string>
    {
        "What are the best tools for organizing my tasks?",
        "How can I maintain work-life balance effectively?"
    };

    private async Task PromptRequest(AssistViewPromptRequestedEventArgs args)
    {
        // Reset the response for this prompt
        var lastIdx = assistView.Prompts.Count - 1;
        assistView.Prompts[lastIdx].Response = string.Empty;
        finalResponse = string.Empty;
        try
        {
            await foreach (var chunk in OpenAIService.GetChatResponseStreamAsync(args.Prompt))
            {
                await UpdateResponse(args, chunk);
            }

            args.Response = finalResponse;
        }
        catch (Exception ex)
        {
            args.Response = $"Error: {ex.Message}";
        }
    }

    private async Task UpdateResponse(AssistViewPromptRequestedEventArgs args, string response)
    {
        var lastIdx = assistView.Prompts.Count - 1;
        await Task.Delay(10); // Small delay for UI updates
        assistView.Prompts[lastIdx].Response += response.Replace("\n", "<br>");
        finalResponse = assistView.Prompts[lastIdx].Response;
        StateHasChanged();
    }

    private void ToolbarItemClicked(AssistViewToolbarItemClickedEventArgs args)
    {
        assistView.Prompts.Clear();
        StateHasChanged();
    }
}

{% endhighlight %}
{% highlight c# tabtitle="cs" %}

using System.Text.Json;
using Markdig;
using System.Text.RegularExpressions;

namespace AIAssistView_AzureAI.Components.Services
{
    public class AzureOpenAIService
    {
        private readonly HttpClient _httpClient;
        private readonly string _endpoint;
        private readonly string _apiKey;
        private readonly string _deploymentName;

        public AzureOpenAIService(HttpClient httpClient, string endpoint, string apiKey, string deploymentName)
        {
            _httpClient = httpClient;
            _endpoint = endpoint;
            _apiKey = apiKey;
            _deploymentName = deploymentName;
        }
        
        public async IAsyncEnumerable<string> GetChatResponseStreamAsync(string prompt)
        {
            var request = new
            {
                messages = new[] { new { role = "user", content = prompt } },
                max_tokens = 500,
            };

            var url = $"{_endpoint}/openai/deployments/{_deploymentName}/chat/completions?api-version=2024-02-15-preview";
            _httpClient.DefaultRequestHeaders.Add("api-key", _apiKey);

            Stream responseStream = null;
            List<string> results = new List<string>();

            try
            {
                var response = await _httpClient.PostAsJsonAsync(url, request);

                if (response.IsSuccessStatusCode)
                {
                    responseStream = await response.Content.ReadAsStreamAsync();
                    using var jsonDocument = JsonDocument.Parse(responseStream);
                    var choices = jsonDocument.RootElement.GetProperty("choices");
                    if (choices.GetArrayLength() > 0)
                    {
                        var content = choices[0].GetProperty("message").GetProperty("content").GetString();
                        var htmlContent = Markdown.ToHtml(content);
                        htmlContent = Regex.Replace(htmlContent, @"\s+", " ").Trim();
                        // Collect each character to the results list before yielding
                        foreach (var chunk in htmlContent)
                        {
                            results.Add(chunk.ToString());
                        }
                    }
                    else
                    {
                        results.Add("Error: No choices returned in the response.");
                    }
                }
                else
                {
                    var error = await response.Content.ReadAsStringAsync();
                    results.Add($"Error: {error}");
                }
            }
            catch (Exception ex)
            {
                // Collect the error message to be yielded later
                results.Add($"Error: {ex.Message}");
            }
            finally
            {
                if (responseStream != null)
                {
                    responseStream.Dispose();
                }
            }

            // Now yield each collected result
            foreach (var result in results)
            {
                yield return result;
            }
        }
    }
}

{% endhighlight %}
{% highlight c# tabtitle="Server(~/_Program.cs)" %}

var endpoint = "https://azure-testresource.openai.azure.com";
var apiKey = "<Your API Key>"; // Replace with your API key;
var deploymentName = "gpt-4o-mini";

{% endhighlight %}
{% endtabs %}

![Blazor AI AssistView Open AI Integration](./images/openai-integration.png)