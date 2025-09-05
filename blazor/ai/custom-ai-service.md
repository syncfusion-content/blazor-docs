---
layout: post
title: Using Custom AI Services with Syncfusion Blazor AI | Syncfusion
description: Learn how to set up and use Syncfusion.Blazor.AI with custom AI providers, including configuration, integration steps, and practical examples.
platform: Blazor
control: AI Integration
documentation: ug
---

# Using Custom AI Services with Syncfusion Blazor AI package (DeepSeek Example)

This section helps to configuring and using the **Syncfusion.Blazor.AI** package with a **custom AI service** by implementing the `IChatInferenceService` interface, using DeepSeek as an example. This extensibility allows you to integrate DeepSeek or any custom AI provider into your Blazor applications, enhancing Syncfusion Blazor components with tailored AI functionalities.

## Prerequisites
- Install the **Syncfusion.Blazor.AI** NuGet package.
- Obtain a DeepSeek API key from the [DeepSeek platform](https://platform.deepseek.com).
- Ensure your Blazor application meets the [System Requirements](https://blazor.syncfusion.com/documentation/system-requirements).

## Configuration
To use DeepSeek as a custom AI service, implement the `IChatInferenceService` interface and configure it in your `Program.cs` file using `AIServiceCredentials` to provide the API key, deployment name, and endpoint.

### Steps
1. **Implement the Custom AI Service**:
   Create a class that implements the `IChatInferenceService` interface for DeepSeek. The implementation below uses the provided DeepSeek code, modified to utilize `AIServiceCredentials` from `Program.cs`.

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

2. **Register the Custom AI Service**:
   Open your Blazor application's `Program.cs` and configure the DeepSeek AI service with `AIServiceCredentials`.

```csharp
builder.Services.AddSingleton(new AIServiceCredentials
{
    ApiKey = "your-deepseek-api-key", // Replace with your DeepSeek API key
    DeploymentName = "deepseek-chat", // Specify the model (e.g., "deepseek-chat", "deepseek-coder")
});

// Register the custom inference backend
builder.Services.AddSingleton<IChatInferenceService, DeepSeekAIService>();
```

3. **Include Required Namespaces**:
   Ensure the required Syncfusion Blazor namespaces are included in your `Program.cs`:

```csharp
using Syncfusion.Blazor.AI;
```



