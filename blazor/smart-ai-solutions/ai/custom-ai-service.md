---
layout: post
<<<<<<< HEAD
title: Using Custom AI Services with Syncfusion Blazor AI | Syncfusion
description: Learn how to set up and use Syncfusion.Blazor.AI with custom AI providers, including configuration, integration steps, and practical examples.
=======
title: Custom AI Service Integration with Syncfusion Blazor AI | Syncfusion
description: Learn how to configure and use Syncfusion Blazor AI with custom AI providers, such as DeepSeek, to enable AI-driven features in Blazor applications.
>>>>>>> 32c27d577704390b597a361089e564504af90b58
platform: Blazor
control: AI Integration
documentation: ug
---

# Custom AI Service Integration with Syncfusion® Blazor AI

<<<<<<< HEAD
## Introduction

This section demonstrates configuring and using the [Syncfusion.Blazor.AI](https://www.nuget.org/packages/Syncfusion.Blazor.AI) package with a **custom AI service** by implementing the `IChatInferenceService` interface, using DeepSeek as an example. This extensibility feature empowers developers to integrate any AI provider into Blazor applications, enabling Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components to work with specialized or proprietary AI services beyond the standard providers.

## Prerequisites

Before you begin integrating a custom AI service with your Blazor application, ensure you have:

* Installed the [Syncfusion.Blazor.AI](https://www.nuget.org/packages/Syncfusion.Blazor.AI) package via NuGet
=======
The [Syncfusion Blazor AI](https://www.nuget.org/packages/Syncfusion.Blazor.AI) library enables integration with custom AI providers by implementing the `IChatInferenceService` interface, using DeepSeek as an example. This extensibility feature allows developers to connect Blazor applications to proprietary or specialized AI services, such as enterprise-specific models or local AI servers, enhancing Syncfusion Blazor components with tailored AI functionality like text generation or data processing.

## Prerequisites

To integrate a custom AI service with a Blazor application, ensure the following:
- The following NuGet package is installed:
>>>>>>> 32c27d577704390b597a361089e564504af90b58
{% tabs %}
{% highlight C# tabtitle="Package Manager" %}

Install-Package Syncfusion.Blazor.AI -Version {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}
<<<<<<< HEAD

* Obtained an API key from your chosen AI provider (DeepSeek in this example) from the [DeepSeek platform](https://platform.deepseek.com)
* Met the [System Requirements](https://blazor.syncfusion.com/documentation/system-requirements) for Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components
* Understanding of HTTP client usage and JSON serialization in .NET applications

## Configuration Steps

Follow these steps to integrate a custom AI service with Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor AI:

### Implement the Custom AI Service
   Create a class that implements the `IChatInferenceService` interface for DeepSeek. The implementation below uses the provided DeepSeek code, modified to utilize `AIServiceCredentials` from `Program.cs`.
=======
- An API key is obtained from the chosen AI provider (e.g., DeepSeek via the [DeepSeek API documentation](https://platform.deepseek.com)).
- The [Syncfusion Blazor system requirements](https://blazor.syncfusion.com/documentation/system-requirements) are met.
- Familiarity with HTTP client usage and JSON serialization in .NET applications.

## Configuration Steps

### Implement the Custom AI Service

Create a class that implements the `IChatInferenceService` interface for the custom AI provider. The example below demonstrates DeepSeek integration using `AIServiceCredentials` for secure configuration management.
>>>>>>> 32c27d577704390b597a361089e564504af90b58

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
<<<<<<< HEAD
    private readonly AIServiceCredentials _credentials;

    public DeepSeekAIService(HttpClient httpClient, AIServiceCredentials credentials)
    {
        _httpClient = httpClient;
        _credentials = credentials;
=======
    private readonly string _apiKey = "Your API Key";
    private readonly string _modelName = "deepseek-chat"; // Example model

    public DeepSeekAIService(HttpClient httpClient)
    {
        _httpClient = httpClient;
>>>>>>> 32c27d577704390b597a361089e564504af90b58
    }

    public async Task<string> GenerateResponseAsync(ChatParameters options)
    {
        var requestBody = new
        {
<<<<<<< HEAD
            model = _credentials.DeploymentName ?? "deepseek-chat", // Use deployment name from credentials
=======
            model = _modelName, // Use deployment name from credentials
>>>>>>> 32c27d577704390b597a361089e564504af90b58
            messages = options.Messages.Select(m => new { role = m.Role.ToString().ToLower(), content = m.Content }).ToArray(),
            temperature = options.Temperature,
            max_tokens = options.MaxTokens
        };

        var requestContent = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");
<<<<<<< HEAD
        if (!string.IsNullOrEmpty(_credentials.ApiKey))
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _credentials.ApiKey);
        }

        var response = await _httpClient.PostAsync(_credentials.Endpoint?.ToString() ?? "https://api.deepseek.com/v1/chat/completions", requestContent);
=======
        if (!string.IsNullOrEmpty(_apiKey))
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);
        }

        var response = await _httpClient.PostAsync("https://api.deepseek.com/v1/chat/completions", requestContent);
>>>>>>> 32c27d577704390b597a361089e564504af90b58
        response.EnsureSuccessStatusCode();

        var responseJson = await response.Content.ReadAsStringAsync();
        using var doc = JsonDocument.Parse(responseJson);
        return doc.RootElement.GetProperty("choices")[0].GetProperty("message").GetProperty("content").GetString();
    }
}
```

### Register the Custom AI Service

<<<<<<< HEAD
   Open your Blazor application's `Program.cs` and configure the DeepSeek AI service with `AIServiceCredentials`.
=======
Update the Blazor application's `Program.cs` to configure the DeepSeek AI service with `AIServiceCredentials`.
>>>>>>> 32c27d577704390b597a361089e564504af90b58

```csharp
using Syncfusion.Blazor.AI;

<<<<<<< HEAD
builder.Services.AddSingleton(new AIServiceCredentials
{
    ApiKey = "your-deepseek-api-key", // Replace with your DeepSeek API key
    DeploymentName = "deepseek-chat", // Specify the model (e.g., "deepseek-chat", "deepseek-coder")
});

// Register the custom inference backend
builder.Services.AddSingleton<IChatInferenceService, DeepSeekAIService>();
```

## Custom AI Integration with Syncfusion<sup style="font-size:70%">&reg;</sup> Components
The `GenerateResponseAsync` method in the DeepSeekAIService class serves as the core interface for AI communication. This method:

1. **Formats Requests:** Converts Syncfusion<sup style="font-size:70%">&reg;</sup> AI parameters into the custom provider's expected format
2. **Handles Authentication:** Manages API key authentication securely
3. **Processes Responses:** Parses the provider's response format into standard AI responses

## See Also

- [Overview](https://blazor.syncfusion.com/documentation/smart-ai-solutions/ai/overview)
- [OpenAI Integration](https://blazor.syncfusion.com/documentation/smart-ai-solutions/ai/openai)
- [Azure OpenAI Integration](https://blazor.syncfusion.com/documentation/smart-ai-solutions/ai/azure-openai)
- [Ollama Integration](https://blazor.syncfusion.com/documentation/smart-ai-solutions/ai/ollama)
- [Smart TextArea](https://blazor.syncfusion.com/documentation/smart-textarea/getting-started)
- [Smart Paste Button](https://blazor.syncfusion.com/documentation/smart-paste/getting-started)
=======
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
>>>>>>> 32c27d577704390b597a361089e564504af90b58
