---
layout: post
title: Custom AI Service Integration with Syncfusion Blazor AI | Syncfusion
description: Learn how to configure and use Syncfusion Blazor AI with custom AI providers, such as DeepSeek, to enable AI-driven features in Blazor applications.
platform: Blazor
control: AI Integration
documentation: ug
---

# Custom AI Service Integration with Syncfusion Blazor AI

The [Syncfusion Blazor AI](https://www.nuget.org/packages/Syncfusion.Blazor.AI) library enables integration with custom AI providers by implementing the `IChatInferenceService` interface, using DeepSeek as an example. This extensibility feature allows developers to connect Blazor applications to proprietary or specialized AI services, such as enterprise-specific models or local AI servers, enhancing Syncfusion Blazor components with tailored AI functionality like text generation or data processing.

## Prerequisites

To integrate a custom AI service with a Blazor application, ensure the following:
- The following NuGet package is installed:
{% tabs %}
{% highlight C# tabtitle="Package Manager" %}

Install-Package Syncfusion.Blazor.AI -Version {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}
- An API key is obtained from the chosen AI provider (e.g., DeepSeek via the [DeepSeek API documentation](https://platform.deepseek.com)).
- The [Syncfusion Blazor system requirements](https://blazor.syncfusion.com/documentation/system-requirements) are met.
- Familiarity with HTTP client usage and JSON serialization in .NET applications.

## Configuration Steps

### Implement the Custom AI Service

Create a class that implements the `IChatInferenceService` interface for the custom AI provider. The example below demonstrates DeepSeek integration using `AIServiceCredentials` for secure configuration management.

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
    private readonly string _apiKey = "Your API Key";
    private readonly string _modelName = "deepseek-chat"; // Example model

    public DeepSeekAIService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> GenerateResponseAsync(ChatParameters options)
    {
        var requestBody = new
        {
            model = _modelName, // Use deployment name from credentials
            messages = options.Messages.Select(m => new { role = m.Role.ToString().ToLower(), content = m.Content }).ToArray(),
            temperature = options.Temperature,
            max_tokens = options.MaxTokens
        };

        var requestContent = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");
        if (!string.IsNullOrEmpty(_apiKey))
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);
        }

        var response = await _httpClient.PostAsync("https://api.deepseek.com/v1/chat/completions", requestContent);
        response.EnsureSuccessStatusCode();

        var responseJson = await response.Content.ReadAsStringAsync();
        using var doc = JsonDocument.Parse(responseJson);
        return doc.RootElement.GetProperty("choices")[0].GetProperty("message").GetProperty("content").GetString();
    }
}
```

### Register the Custom AI Service

Update the Blazor application's `Program.cs` to configure the DeepSeek AI service with `AIServiceCredentials`.

```csharp
using Syncfusion.Blazor.AI;

// Register the custom inference service
builder.Services.AddSingleton<IChatInferenceService, DeepSeekAIService>();
```

## How It Works

This example illustrates how the Syncfusion Blazor AI library integrates with a custom AI service (DeepSeek):

1. **Setup**: Implement and register the custom AI service in `Program.cs` using secure credentials.
2. **Component Integration**: Inject `IChatInferenceService` to process AI requests within Syncfusion components like Smart TextArea.
3. **Request Formatting**: Convert Syncfusion AI parameters into the custom provider’s API format (e.g., DeepSeek’s JSON structure).
4. **Response Processing**: Parse the provider’s response and update the component (e.g., displaying text suggestions).

### Key Components
- **IChatInferenceService**: Interface for interacting with custom AI providers.
- **AIServiceCredentials**: Syncfusion class for managing API keys, endpoints, and model names.
- **GenerateResponseAsync**: Sends asynchronous requests to the custom AI provider and retrieves responses.

## Error Handling
- **Invalid API Key**: Ensure the API key is valid and stored securely in environment variables or a configuration service.
- **Rate Limits**: Check the custom AI provider’s documentation (e.g., [DeepSeek API docs](https://platform.deepseek.com)) for rate limit details.
- **Network or Parsing Errors**: Handle HTTP or JSON errors gracefully, as shown in the `DeepSeekAIService` implementation.
