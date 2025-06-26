---
layout: post
title: Gemini AI Service with Smart Components in Blazor App | Syncfusion
description: Learn how to implement a custom AI service using Google's Gemini API with Syncfusion Smart Components in a Blazor App.
control: Smart Paste Button
documentation: ug
---

# Getting Started with Smart Components using Gemini AI Service

This guide provides step-by-step instructions for integrating and using Syncfusion's Smart Components with Gemini AI services in your Blazor App.

## Prerequisites

Before you begin, ensure you have:

* [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)
* [Gemini API Key](https://ai.google.dev/gemini-api/docs/api-key) - Obtain an API key from Google AI Studio


## Models

For a complete list of models and their capabilities, visit the [Gemini Models Documentation](https://ai.google.dev/gemini-api/docs/models).

## Getting Started for Gemini AI with SmartPasteButton

After completing this setup, you can:

1. [Add Smart Components to your Blazor pages](https://blazor.syncfusion.com/documentation/smart-paste/getting-started)
2. [Configure form annotations for better AI understanding](https://blazor.syncfusion.com/documentation/smart-paste/annotation)
3. [Customize the appearance and behavior of Smart Components](https://blazor.syncfusion.com/documentation/smart-paste/customization)

---

## Step 1: Create a Gemini AI Service

The `GeminiService` class serves as the foundation for integrating Gemini AI into your Blazor application. This service manages:

* API communication with Gemini endpoints
* Request/response handling
* Message formatting
* Safety settings configuration

### Implementation Steps

1. Create a new class file named `GeminiService.cs` in your project
2. Add the following implementation:

```csharp
public class GeminiService
{
    // HTTP client configuration for optimal performance
    private static readonly Version _httpVersion = HttpVersion.Version30;
    private static readonly HttpClient HttpClient = new HttpClient(new SocketsHttpHandler
    {
        PooledConnectionLifetime = TimeSpan.FromMinutes(30),
        EnableMultipleHttp2Connections = true,
    })
    {
        DefaultRequestVersion = _httpVersion
    };

    // Configuration settings
    private const string ApiKey = "YOUR_API_KEY_HERE";
    private const string ModelName = "YOUR_MODEL_NAME"; 

    // JSON serialization settings
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };

    public GeminiService()
    {
        // Set up authentication headers
        HttpClient.DefaultRequestHeaders.Clear();
        HttpClient.DefaultRequestHeaders.Add("x-goog-api-key", ApiKey);
    }

    // Main method for interacting with Gemini API
    public async Task<string> CompleteAsync(IList<ChatMessage> chatMessages)
    {
        // Construct the API endpoint URL
        var requestUri = $"https://generativelanguage.googleapis.com/v1beta/models/{ModelName}:generateContent";
        
        // Prepare the request parameters
        var parameters = BuildGeminiChatParameters(chatMessages);
        var payload = new StringContent(
            JsonSerializer.Serialize(parameters, JsonOptions), 
            Encoding.UTF8, 
            "application/json"
        );

        try
        {
            // Send request and process response
            using var response = await HttpClient.PostAsync(requestUri, payload);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<GeminiResponseObject>(json, JsonOptions);

            // Extract and return the generated text
            return result?.Candidates?.FirstOrDefault()?.Content?.Parts?.FirstOrDefault()?.Text 
                ?? "No response from model.";
        }
        catch (Exception ex) when (ex is HttpRequestException or JsonException)
        {
            throw new InvalidOperationException("Gemini API error.", ex);
        }
    }

    private GeminiChatParameters BuildGeminiChatParameters(IList<ChatMessage> messages)
    {
        // Convert chat messages to Gemini's format
        var contents = messages.Select(m => new ResponseContent(
            m.Text, 
            m.Role == ChatRole.User ? "user" : "model"
        )).ToList();

        // Configure request parameters including safety settings
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

To efficiently communicate with the Gemini AI API, we need to define a set of C# classes that map to Gemini's JSON request and response format. These models ensure type safety and provide a clean interface for working with the API.

1. Create a new file named `GeminiModels.cs` in your project
2. Add the following model classes:

```csharp
// Represents a text segment in the API communication
public class Part
{
    public string Text { get; set; }
}

// Contains an array of text parts
public class Content
{
    public Part[] Parts { get; init; } = Array.Empty<Part>();
}

// Represents a generated response candidate
public class Candidate
{
    public Content Content { get; init; } = new();
}

// The main response object from Gemini API
public class GeminiResponseObject
{
    public Candidate[] Candidates { get; init; } = Array.Empty<Candidate>();
}

// Represents a message in the chat conversation
public class ResponseContent
{
    public List<Part> Parts { get; init; }
    public string Role { get; init; }  // "user" or "model"

    public ResponseContent(string text, string role)
    {
        Parts = new List<Part> { new Part { Text = text } };
        Role = role;
    }
}

// Configuration for text generation
public class GenerationConfig
{
    // Controls randomness (0.0 to 1.0)
    public int Temperature { get; init; } = 0;
    
    // Limits token consideration (1 to 40)
    public int TopK { get; init; } = 0;
    
    // Nucleus sampling threshold (0.0 to 1.0)
    public int TopP { get; init; } = 0;
    
    // Maximum tokens in response
    public int MaxOutputTokens { get; init; } = 2048;
    
    // Sequences that stop generation
    public List<string> StopSequences { get; init; } = new();
}

// Controls content filtering
public class SafetySetting
{
    // Harm category to filter
    public string Category { get; init; } = string.Empty;
    
    // Filtering threshold level
    public string Threshold { get; init; } = string.Empty;
}

// Main request parameters for Gemini API
public class GeminiChatParameters
{
    // Chat message history
    public List<ResponseContent> Contents { get; init; } = new();
    
    // Generation settings
    public GenerationConfig GenerationConfig { get; init; } = new();
    
    // Content safety filters
    public List<SafetySetting> SafetySettings { get; init; } = new();
}
```


## Step 3: Create a Custom AI Service

The Syncfusion Smart Components are designed to work with different AI backends through the `IChatInferenceService` interface. This section shows you how to create a custom implementation that connects the Smart Components to the Gemini AI service.

### Understanding the Interface

The `IChatInferenceService` interface is the bridge between Syncfusion Smart Components and AI services:

1. Create a new file named `MyCustomService.cs`
2. Add the following implementation:

```csharp
using Syncfusion.Blazor.AI;

public class MyCustomService : IChatInferenceService
{
    private readonly GeminiService _geminiService;

    public MyCustomService(GeminiService geminiService)
    {
        _geminiService = geminiService;
    }

    public Task<string> GenerateResponseAsync(ChatParameters options)
    {
        // Forward the chat parameters to our Gemini service
        return _geminiService.CompleteAsync(options.Messages);
    }
}
```

## Step 4: Configure the Blazor App

Configure your Blazor application to use the Gemini AI service with Syncfusion Smart Components. This involves registering necessary services and setting up the dependency injection container.

```CSharp

using Syncfusion.Blazor.SmartComponents;
using Syncfusion.Blazor.AI;
var builder = WebApplication.CreateBuilder(args);

....

builder.Services.AddSyncfusionBlazor();
builder.Services.AddSyncfusionSmartComponents();
builder.Services.AddSingleton<GeminiService>();
builder.Services.AddSingleton<IChatInferenceService, MyCustomService>();

var app = builder.Build();
....

```
