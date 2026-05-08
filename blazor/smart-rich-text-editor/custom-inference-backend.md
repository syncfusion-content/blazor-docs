---
layout: post
title: Custom Inference Backend for Syncfusion Smart Rich Text Editor
description: Learn how to configure custom AI inference back-ends for the Syncfusion Blazor Smart Rich Text Editor component.
platform: Blazor
control: Smart Rich Text Editor
documentation: ug
---

# Custom Inference Backend

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Smart Rich Text Editor supports custom inference back-ends, allowing you to integrate with proprietary AI services or internal AI infrastructure.

## Overview

Custom back-ends enable:

- Integration with internal AI services
- Compliance with corporate data policies
- Custom model fine-tuning
- Specialized domain models
- Proprietary inference engines

## Prerequisites

* Existing AI/ML inference service
* API endpoint for inference
* Authentication credentials (if required)
* Understanding of your backend's API format

## Creating a Custom Backend

### Step 1: Implement IChatClient Interface

Create a custom class implementing `IChatClient`:

```csharp
using Microsoft.Extensions.AI;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace YourNamespace.AI
{
    public class CustomAIBackend : IChatClient
    {
        private readonly string _endpoint;
        private readonly string _apiKey;
        private readonly HttpClient _httpClient;

        public CustomAIBackend(string endpoint, string apiKey)
        {
            _endpoint = endpoint;
            _apiKey = apiKey;
            _httpClient = new HttpClient();
        }

        public async ValueTask<ChatCompletion> CompleteAsync(
            IList<ChatMessage> chatMessages, 
            ChatOptions? options = null,
            CancellationToken cancellationToken = default)
        {
            // Format request for your custom backend
            var requestBody = new
            {
                messages = ConvertChatMessages(chatMessages),
                max_tokens = options?.MaxCompletionTokens ?? 500,
                temperature = options?.Temperature ?? 0.7f
            };

            // Call your custom endpoint
            var request = new HttpRequestMessage(HttpMethod.Post, _endpoint)
            {
                Content = new StringContent(
                    System.Text.Json.JsonSerializer.Serialize(requestBody),
                    System.Text.Encoding.UTF8,
                    "application/json"
                )
            };

            // Add authentication if needed
            if (!string.IsNullOrEmpty(_apiKey))
            {
                request.Headers.Add("Authorization", $"Bearer {_apiKey}");
            }

            var response = await _httpClient.SendAsync(request, cancellationToken);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var result = System.Text.Json.JsonSerializer.Deserialize<CustomBackendResponse>(responseContent);

            return new ChatCompletion(new ChatMessage(
                ChatRole.Assistant,
                result?.choices?[0]?.message?.content ?? "No response"
            ));
        }

        private object ConvertChatMessages(IList<ChatMessage> messages)
        {
            return messages.Select(m => new
            {
                role = m.Role.ToString().ToLower(),
                content = m.Content?[0]?.Text ?? string.Empty
            }).ToList();
        }

        public void Dispose()
        {
            _httpClient?.Dispose();
        }
    }

    public class CustomBackendResponse
    {
        public Choice[]? choices { get; set; }
    }

    public class Choice
    {
        public Message? message { get; set; }
    }

    public class Message
    {
        public string? content { get; set; }
    }
}
```

### Step 2: Register in Program.cs

Register your custom backend:

```csharp
using Syncfusion.Blazor;
using Syncfusion.Blazor.AI;
using YourNamespace.AI;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSyncfusionBlazor();

// Register custom backend - load from configuration
string customEndpoint = builder.Configuration["CustomAI:Endpoint"] 
    ?? throw new InvalidOperationException("CustomAI:Endpoint not configured");
string customApiKey = builder.Configuration["CustomAI:ApiKey"] 
    ?? throw new InvalidOperationException("CustomAI:ApiKey not configured");

var customBackend = new CustomAIBackend(customEndpoint, customApiKey);
builder.Services.AddSingleton<IChatClient>(customBackend);

// Register Smart Rich Text Editor Components
builder.Services.AddSingleton<IChatInferenceService, SyncfusionAIService>();

var app = builder.Build();

// ... rest of setup
```

### Step 3: Use in Blazor Component

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.SmartRichTextEditor

<SfSmartRichTextEditor>
    <AssistViewSettings Placeholder="Edit with custom AI..." />
    <div>
        <h3>Welcome to the AI-assisted editor</h3>
        <p>Try selecting a sentence and use AI Commands to improve tone or clarity.</p>
        <ul>
            <li>Select text and request suggestions</li>
            <li>Press Alt+Enter for AI Query</li>
        </ul>
    </div>
</SfSmartRichTextEditor>

{% endhighlight %}
{% endtabs %}

## Advanced Implementation

### With Configuration Support

```csharp
public class CustomAIBackend : IChatClient
{
    private readonly IConfiguration _configuration;
    private readonly string _endpoint;
    private readonly string _apiKey;
    private readonly HttpClient _httpClient;

    public CustomAIBackend(IConfiguration configuration)
    {
        _configuration = configuration;
        _endpoint = _configuration["CustomAI:Endpoint"] 
            ?? throw new InvalidOperationException("CustomAI:Endpoint not configured");
        _apiKey = _configuration["CustomAI:ApiKey"] 
            ?? throw new InvalidOperationException("CustomAI:ApiKey not configured");
        _httpClient = new HttpClient();
    }

    public async ValueTask<ChatCompletion> CompleteAsync(
        IList<ChatMessage> chatMessages, 
        ChatOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        // Implementation...
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        _httpClient?.Dispose();
    }
}
```

### Configuration in appsettings.json

```json
{
  "CustomAI": {
    "Endpoint": "https://your-ai-service.com/api/inference",
    "ApiKey": "${CustomAI_ApiKey}",
    "MaxRetries": 3,
    "TimeoutSeconds": 30
  }
}
```

> **Note**: Store sensitive credentials in user secrets or environment variables, not in appsettings.json

### Registration with Configuration

```csharp
var customBackend = new CustomAIBackend(builder.Configuration);
builder.Services.AddSingleton<IChatClient>(customBackend);
```

## Streaming Responses

For better UX with custom back-ends:

```csharp
public class StreamingCustomAIBackend : IChatClient
{
    private readonly string _endpoint;
    private readonly HttpClient _httpClient;

    public StreamingCustomAIBackend(string endpoint)
    {
        _endpoint = endpoint;
        _httpClient = new HttpClient();
    }

    public async ValueTask<ChatCompletion> CompleteAsync(
        IList<ChatMessage> chatMessages,
        ChatOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, _endpoint);
        request.Content = new StringContent(
            System.Text.Json.JsonSerializer.Serialize(new { messages = chatMessages }),
            System.Text.Encoding.UTF8,
            "application/json"
        );

        // Enable streaming
        request.Headers.Add("Accept", "text/event-stream");

        var response = await _httpClient.SendAsync(
            request,
            HttpCompletionOption.ResponseHeadersRead,
            cancellationToken
        );

        using var stream = await response.Content.ReadAsStreamAsync(cancellationToken);
        using var reader = new System.IO.StreamReader(stream);

        var fullContent = new System.Text.StringBuilder();

        while (!reader.EndOfStream)
        {
            var line = await reader.ReadLineAsync();
            if (line?.StartsWith("data: ") == true)
            {
                var data = line.Substring("data: ".Length);
                var chunk = System.Text.Json.JsonSerializer.Deserialize<StreamChunk>(data);
                if (chunk?.content != null)
                {
                    fullContent.Append(chunk.content);
                }
            }
        }

        return new ChatCompletion(new ChatMessage(
            ChatRole.Assistant,
            fullContent.ToString()
        ));
    }

    public void Dispose()
    {
        _httpClient?.Dispose();
    }

    private class StreamChunk
    {
        public string? content { get; set; }
    }
}
```

## Error Handling

Implement robust error handling:

```csharp
public class RobustCustomAIBackend : IChatClient
{
    private readonly string _endpoint;
    private readonly HttpClient _httpClient;
    private readonly ILogger<RobustCustomAIBackend> _logger;
    private readonly int _maxRetries = 3;

    public RobustCustomAIBackend(string endpoint, ILogger<RobustCustomAIBackend> logger)
    {
        _endpoint = endpoint;
        _logger = logger;
        _httpClient = new HttpClient();
    }

    public async ValueTask<ChatCompletion> CompleteAsync(
        IList<ChatMessage> chatMessages,
        ChatOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        for (int attempt = 1; attempt <= _maxRetries; attempt++)
        {
            try
            {
                return await AttemptCompletion(chatMessages, options, cancellationToken);
            }
            catch (HttpRequestException ex) when (attempt < _maxRetries)
            {
                _logger.LogWarning($"Attempt {attempt} failed: {ex.Message}. Retrying...");
                await Task.Delay(TimeSpan.FromSeconds(attempt * 2), cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Unrecoverable error: {ex.Message}");
                throw;
            }
        }

        throw new InvalidOperationException("Failed to get response after max retries");
    }

    private async ValueTask<ChatCompletion> AttemptCompletion(
        IList<ChatMessage> chatMessages,
        ChatOptions? options,
        CancellationToken cancellationToken)
    {
        using var cts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
        cts.CancelAfter(TimeSpan.FromSeconds(30)); // 30 second timeout

        var request = new HttpRequestMessage(HttpMethod.Post, _endpoint);
        // ... request setup ...

        var response = await _httpClient.SendAsync(request, cts.Token);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        return ParseResponse(content);
    }

    private ChatCompletion ParseResponse(string content)
    {
        try
        {
            var result = System.Text.Json.JsonSerializer.Deserialize<CustomResponse>(content);
            return new ChatCompletion(new ChatMessage(
                ChatRole.Assistant,
                result?.output ?? "No response"
            ));
        }
        catch (System.Text.Json.JsonException ex)
        {
            _logger.LogError($"Failed to parse response: {ex.Message}");
            throw;
        }
    }

    public void Dispose()
    {
        _httpClient?.Dispose();
    }

    private class CustomResponse
    {
        public string? output { get; set; }
    }
}
```

## Example: Internal AI Service Integration

### Scenario: Company-Internal AI API

```csharp
public class CorporateAIBackend : IChatClient
{
    private readonly string _internalEndpoint;
    private readonly string _bearerToken;
    private readonly HttpClient _httpClient;
    private readonly ILogger _logger;

    public CorporateAIBackend(string endpoint, string token, ILogger logger)
    {
        _internalEndpoint = endpoint;
        _bearerToken = token;
        _logger = logger;
        _httpClient = new HttpClient();
        _httpClient.Timeout = TimeSpan.FromSeconds(60);
    }

    public async ValueTask<ChatCompletion> CompleteAsync(
        IList<ChatMessage> chatMessages,
        ChatOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        try
        {
            var requestBody = new
            {
                messages = chatMessages.Select(m => new
                {
                    role = m.Role == ChatRole.User ? "user" : "assistant",
                    content = m.Content?[0]?.Text ?? string.Empty
                }),
                parameters = new
                {
                    temperature = options?.Temperature ?? 0.7f,
                    max_tokens = options?.MaxCompletionTokens ?? 1000
                }
            };

            var request = new HttpRequestMessage(HttpMethod.Post, _internalEndpoint);
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _bearerToken);
            request.Content = new StringContent(
                System.Text.Json.JsonSerializer.Serialize(requestBody),
                System.Text.Encoding.UTF8,
                "application/json"
            );

            var response = await _httpClient.SendAsync(request, cancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError($"API Error: {response.StatusCode}");
                throw new InvalidOperationException($"AI service returned: {response.StatusCode}");
            }

            var content = await response.Content.ReadAsStringAsync(cancellationToken);
            var result = System.Text.Json.JsonSerializer.Deserialize<CorporateResponse>(content);

            return new ChatCompletion(new ChatMessage(
                ChatRole.Assistant,
                result?.result?.text ?? "Unable to generate response"
            ));
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error calling corporate AI: {ex.Message}");
            throw;
        }
    }

    public void Dispose()
    {
        _httpClient?.Dispose();
    }

    private class CorporateResponse
    {
        public ResultData? result { get; set; }
    }

    private class ResultData
    {
        public string? text { get; set; }
    }
}
```

## Testing Your Custom Backend

### Unit Test Example

```csharp
[TestClass]
public class CustomAIBackendTests
{
    [TestMethod]
    public async Task CompleteAsync_WithValidMessages_ReturnsResponse()
    {
        // Arrange
        var backend = new CustomAIBackend("https://test-endpoint.com", "test-key");
        var messages = new List<ChatMessage>
        {
            new ChatMessage(ChatRole.User, "Hello")
        };

        // Act
        var result = await backend.CompleteAsync(messages);

        // Assert
        Assert.IsNotNull(result);
        Assert.IsNotNull(result.Content);
    }

    [TestMethod]
    public async Task CompleteAsync_WithInvalidEndpoint_ThrowsException()
    {
        // Arrange
        var backend = new CustomAIBackend("https://invalid-endpoint.com", "test-key");
        var messages = new List<ChatMessage>
        {
            new ChatMessage(ChatRole.User, "Test")
        };

        // Act & Assert
        await Assert.ThrowsExceptionAsync<Exception>(
            () => backend.CompleteAsync(messages).AsTask()
        );
    }
}
```

## See also

* [Getting Started with Smart Rich Text Editor](getting-started.md)
* [OpenAI Configuration](openai-service.md)
* [Azure OpenAI Configuration](azure-openai-service.md)
* [Ollama Configuration](ollama.md)
* [AI Features and Customization](ai-features.md)