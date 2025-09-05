Apply
---
layout: post
title: Using Custom AI Services with Syncfusion Blazor AI | Syncfusion
description: Learn how to set up and use Syncfusion.Blazor.AI with custom AI providers, including configuration, integration steps, and practical examples.
platform: Blazor
control: AI Integration
documentation: ug
---

# Custom AI Service Integration with Syncfusion Blazor AI

## Introduction

This section demonstrates configuring and using the [Syncfusion.Blazor.AI](https://www.nuget.org/packages/Syncfusion.Blazor.AI) package with a **custom AI service** by implementing the `IChatInferenceService` interface, using DeepSeek as an example. This extensibility feature empowers developers to integrate any AI provider into Blazor applications, enabling Syncfusion Blazor components to work with specialized or proprietary AI services beyond the standard providers.

## Prerequisites

Before integrating a custom AI service with your Blazor application, ensure you have:

* Installed the following NuGet packages:
{% tabs %}
{% highlight C# tabtitle="Package Manager" %}

Install-Package Syncfusion.Blazor.AI -Version {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}
* Obtained an API key from your chosen AI provider (DeepSeek in this example) from the [DeepSeek platform](https://platform.deepseek.com)
* Met the [System Requirements](https://blazor.syncfusion.com/documentation/system-requirements) for Syncfusion Blazor components
* Understanding of HTTP client usage and JSON serialization in .NET applications

## Configuration Steps

Follow these steps to integrate a custom AI service with Syncfusion Blazor AI:

### Implement the Custom AI Service

Create a class that implements the `IChatInferenceService` interface for your custom AI provider. The implementation below demonstrates DeepSeek integration using `AIServiceCredentials` for secure configuration management.


```csharp
using Microsoft.Extensions.AI;
using Syncfusion.Blazor.AI;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

public class DeepSeekAIService : IChatInferenceService
{
    private readonly HttpClient _httpClient;
    private readonly AIServiceCredentials _credentials;

    public DeepSeekAIService(HttpClient httpClient, AIServiceCredentials credentials)
    {
        _httpClient = httpClient;
        _credentials = credentials;
    }

    public async Task<string> GenerateResponseAsync(ChatParameters options)
    {
        var requestBody = new
        {
            model = _credentials.DeploymentName ?? "deepseek-chat", // Use deployment name from credentials
            messages = options.Messages.Select(m => new { role = m.Role.ToString().ToLower(), content = m.Content }).ToArray(),
            temperature = options.Temperature,
            max_tokens = options.MaxTokens
        };

        var requestContent = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");
        if (!string.IsNullOrEmpty(_credentials.ApiKey))
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _credentials.ApiKey);
        }

        var response = await _httpClient.PostAsync(_credentials.Endpoint?.ToString() ?? "https://api.deepseek.com/v1/chat/completions", requestContent);
        response.EnsureSuccessStatusCode();

        var responseJson = await response.Content.ReadAsStringAsync();
        using var doc = JsonDocument.Parse(responseJson);
        return doc.RootElement.GetProperty("choices")[0].GetProperty("message").GetProperty("content").GetString();
    }
}
```

### Register the Custom AI Service

   Open your Blazor application's `Program.cs` and configure the DeepSeek AI service with `AIServiceCredentials`.

```csharp
using Syncfusion.Blazor.AI;

builder.Services.AddSingleton(new AIServiceCredentials
{
    ApiKey = "your-deepseek-api-key", // Replace with your DeepSeek API key
    DeploymentName = "deepseek-chat", // Specify the model (e.g., "deepseek-chat", "deepseek-coder")
});

// Register the custom inference backend
builder.Services.AddSingleton<IChatInferenceService, DeepSeekAIService>();
```

## Custom AI Integration with Syncfusion Components
The `GenerateResponseAsync` method in the DeepSeekAIService class serves as the core interface for AI communication. This method:

1. **Formats Requests:** Converts Syncfusion AI parameters into the custom provider's expected format
2. **Handles Authentication:** Manages API key authentication securely
3. **Processes Responses:** Parses the provider's response format into standard AI responses

## See Also

- [Overview](https://blazor.syncfusion.com/documentation/smart-ai-solutions/ai/overview)
- [OpenAI Integration](https://blazor.syncfusion.com/documentation/smart-ai-solutions/ai/openai)
- [Azure OpenAI Integration](https://blazor.syncfusion.com/documentation/smart-ai-solutions/ai/azure-openai)
- [Ollama Integration](https://blazor.syncfusion.com/documentation/smart-ai-solutions/ai/ollama)
- [Smart TextArea](https://blazor.syncfusion.com/documentation/smart-textarea/getting-started)
- [Smart Paste Button](https://blazor.syncfusion.com/documentation/smart-paste/getting-started)