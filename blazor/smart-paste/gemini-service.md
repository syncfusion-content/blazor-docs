---
layout: post
title: Custom AI Service with Syncfusion Smart Components in Blazor Web App
description: Learn how to integrate and use the Syncfusion component in a Blazor Web App with Gemini AI services.
platform: Blazor
control: Smart Paste Button
documentation: ug
---

# Getting Started with Smart Components with Gemini Service

This guide provides step-by-step instructions to integrate and use the Syncfusion Smart Paste Button and Smart Text Area components in a Blazor Web App, powered by Gemini AI services.

---

## Prerequisites

Before you begin, ensure you have the following:

1. **Gemini API Key**  
   Obtain an API key by visiting the [Gemini API Documentation](https://ai.google.dev/gemini-api/docs/api-key).

2. **Understanding Gemini Models**  
   To know about the available Gemini models by visiting the [Gemini Models Documentation](https://ai.google.dev/gemini-api/docs/models).

---

## Step 1: Create a Gemini AI Service

The `GeminiService` class serves as the central point for interacting with the Gemini API. It handles request creation, sending, and processing the response to extract the generated content.

### Implementation

```csharp
public class GeminiService
{
    private static readonly Version _httpVersion = HttpVersion.Version30;

    private static readonly HttpClient HttpClient = new HttpClient(new SocketsHttpHandler
    {
        PooledConnectionLifetime = TimeSpan.FromMinutes(30),
        EnableMultipleHttp2Connections = true,
    })
    {
        DefaultRequestVersion = _httpVersion
    };

    private const string ApiKey = "YOUR_API_KEY_HERE";
    private const string ModelName = "gemini-2.0-flash";

    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };

    public GeminiService()
    {
        HttpClient.DefaultRequestHeaders.Clear();
        HttpClient.DefaultRequestHeaders.Add("x-goog-api-key", ApiKey);
    }

    public async Task<string> CompleteAsync(IList<ChatMessage> chatMessages)
    {
        var requestUri = $"https://generativelanguage.googleapis.com/v1beta/models/{ModelName}:generateContent";
        var parameters = BuildGeminiChatParameters(chatMessages);
        var payload = new StringContent(JsonSerializer.Serialize(parameters, JsonOptions), Encoding.UTF8, "application/json");

        try
        {
            using var response = await HttpClient.PostAsync(requestUri, payload);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<GeminiResponseObject>(json, JsonOptions);

            return result?.Candidates?.FirstOrDefault()?.Content?.Parts?.FirstOrDefault()?.Text ?? "No response from model.";
        }
        catch (Exception ex) when (ex is HttpRequestException or JsonException)
        {
            throw new InvalidOperationException("Gemini API error.", ex);
        }
    }

    private GeminiChatParameters BuildGeminiChatParameters(IList<ChatMessage> messages)
    {
        var contents = messages.Select(m => new ResponseContent(m.Text, m.Role == ChatRole.User ? "user" : "model")).ToList();

        return new GeminiChatParameters
        {
            Contents = contents,
            GenerationConfig = new GenerationConfig
            {
                MaxOutputTokens = 2000,
                StopSequences = new() { "END_INSERTION", "NEED_INFO", "END_RESPONSE" }
            },
            SafetySettings = new()
            {
                new() { Category = "HARM_CATEGORY_HARASSMENT", Threshold = "BLOCK_ONLY_HIGH" },
                new() { Category = "HARM_CATEGORY_HATE_SPEECH", Threshold = "BLOCK_ONLY_HIGH" },
                new() { Category = "HARM_CATEGORY_SEXUALLY_EXPLICIT", Threshold = "BLOCK_ONLY_HIGH" },
                new() { Category = "HARM_CATEGORY_DANGEROUS_CONTENT", Threshold = "BLOCK_ONLY_HIGH" }
            }
        };
    }
}
```

## Step 2: Define Request and Response Models
To maintain clarity and adhere to object-oriented principles, define custom types for the request and response models.

```CSharp
public class Part
{
    public string Text { get; set; }
}

public class Content
{
    public Part[] Parts { get; init; } = Array.Empty<Part>();
}

public class Candidate
{
    public Content Content { get; init; } = new();
}

public class GeminiResponseObject
{
    public Candidate[] Candidates { get; init; } = Array.Empty<Candidate>();
}

public class ResponseContent
{
    public List<Part> Parts { get; init; }
    public string Role { get; init; }

    public ResponseContent(string text, string role)
    {
        Parts = new List<Part> { new Part { Text = text } };
        Role = role;
    }
}

public class GenerationConfig
{
    public int Temperature { get; init; } = 0;
    public int TopK { get; init; } = 0;
    public int TopP { get; init; } = 0;
    public int MaxOutputTokens { get; init; } = 2048;
    public List<string> StopSequences { get; init; } = new();
}

public class SafetySetting
{
    public string Category { get; init; } = string.Empty;
    public string Threshold { get; init; } = string.Empty;
}

public class GeminiChatParameters
{
    public List<ResponseContent> Contents { get; init; } = new();
    public GenerationConfig GenerationConfig { get; init; } = new();
    public List<SafetySetting> SafetySettings { get; init; } = new();
}
```

## Step 3: Create a Custom AI Service
If you want to use a backend other than OpenAI or Azure OpenAI, implement the `IInferenceBackend` interface and use your custom type in Program.cs.

```CSharp
public class MyCustomService : IInferenceBackend
{
    private readonly GeminiService _geminiService;

    public MyCustomService(GeminiService geminiService)
    {
        _geminiService = geminiService;
    }

    public Task<string> GetChatResponseAsync(ChatParameters options)
    {
        return _geminiService.CompleteAsync(options.Messages);
    }
}
```

## Step 4: Configure the Blazor App
Update the `Program.cs` file to register the required services.

```CSharp

using Syncfusion.Blazor.SmartComponents;
var builder = WebApplication.CreateBuilder(args);

....

builder.Services.AddSyncfusionBlazor();
builder.Services.AddSyncfusionSmartComponents();
builder.Services.AddSingleton<GeminiService>();
builder.Services.AddSingleton<IInferenceBackend, MyCustomService>();

var app = builder.Build();
....

```

You have successfully integrated the Syncfusion SmartComponent with Gemini AI services in your Blazor Web App. 