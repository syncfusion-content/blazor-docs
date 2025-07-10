---
layout: post
title: Claude AI Service with Smart Components in Blazor App | Syncfusion
description: Learn how to integrate and use the Syncfusion component in a Blazor Web App with Claude AI services.
platform: Blazor
control: Smart Paste Button
documentation: ug
---

# Getting Started with Smart Components using Claude AI

This guide walks you through integrating Anthropic's Claude AI with Syncfusion Smart Components in your Blazor App. 

## Prerequisites

Before you begin, ensure you have:

* [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)
* Claude account and API key (see setup instructions below)

### Setting Up Claude

1. **Create an Anthropic Account**
   * Visit [Anthropic Console](https://console.anthropic.com)
   * Sign up for a new account

2. **Get Your API Key**
   * Navigate to [API Keys](https://console.anthropic.com/settings/keys)
   * Click "Create Key"

### Models

For detailed specifications and capabilities, visit the [Claude Models Documentation](https://docs.anthropic.com/claude/docs/models-overview).

---

## Getting Started for Claude AI with SmartPasteButton

After completing this setup, you can:

1. [Add Smart Components to your Blazor pages](https://blazor.syncfusion.com/documentation/smart-paste/getting-started)
2. [Configure form annotations for better AI understanding](https://blazor.syncfusion.com/documentation/smart-paste/annotation)
3. [Customize the appearance and behavior of Smart Components](https://blazor.syncfusion.com/documentation/smart-paste/customization)

---

## Step 1: Create a Claude AI Service

In this step, we'll create a service that handles all communication with Claude's AI. This service is to:

* Manage secure API authentication
* Send prompts to Claude's models
* Process AI responses

### Implementation Steps

1. Create a new file named `ClaudeAIService.cs`
2. Add the required namespaces for HTTP and JSON handling
3. Implement the service class following the code below

```csharp
using Microsoft.Extensions.AI;
using System.Net;
using System.Text;
using System.Text.Json;
public class ClaudeAIService
{
    private const string ApiKey = "Your API Key";
    private const string ModelName = "Your Model Name";
    private const string Endpoint = "https://api.anthropic.com/v1/messages";

    private static readonly HttpClient HttpClient = new(new SocketsHttpHandler
    {
        PooledConnectionLifetime = TimeSpan.FromMinutes(30),
        EnableMultipleHttp2Connections = true,
    })
    {
        DefaultRequestVersion = HttpVersion.Version30
    };

    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };

    public ClaudeAIService()
    {
        if (!HttpClient.DefaultRequestHeaders.Contains("x-api-key"))
        {
            HttpClient.DefaultRequestHeaders.Clear();
            HttpClient.DefaultRequestHeaders.Add("x-api-key", ApiKey);
            HttpClient.DefaultRequestHeaders.Add("anthropic-version", "2023-06-01");
        }
    }

    public async Task<string> CompleteAsync(IList<ChatMessage> chatMessages)
    {

    var requestBody = new ClaudeChatRequest
    {
        Model = ModelName,
        Max_tokens = 1000,
        Messages = chatMessages.Select(m => new ClaudeMessage
        {
            Role = m.Role == ChatRole.User ? "user" : "assistant",
            Content = m.Text
        }).ToList(),
        Stop_sequences = new() { "END_INSERTION", "NEED_INFO", "END_RESPONSE" }
    };

    var json = JsonSerializer.Serialize(requestBody, JsonOptions);
    var content = new StringContent(json, Encoding.UTF8, "application/json");

    try
        {
            var response = await HttpClient.PostAsync(Endpoint, content);
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            var responseObject = JsonSerializer.Deserialize<ClaudeChatResponse>(responseString, JsonOptions);

            return responseObject?.Content?.FirstOrDefault()?.Text ?? "No response from Claude model.";
        }
        catch (Exception ex) when (ex is HttpRequestException || ex is JsonException)
        {
            throw new InvalidOperationException("Failed to communicate with Claude API.", ex);
        }
    }
}
```

## Step 2: Define Request and Response Models

To effectively communicate with Claude's API, we need to define structured models for our requests and responses. These models ensure type safety and make the code more maintainable.

### Request Models
The request models define the structure of data we send to Claude.

### Response Models
The response models handle Claude's API responses.

```CSharp
public class ClaudeChatRequest
{
    public string Model { get; set; }
    public int Max_tokens { get; set; }
    public List<ClaudeMessage> Messages { get; set; }
    public List<string> Stop_sequences { get; set; }
}

public class ClaudeMessage
{
    public string Role { get; set; } // "user" or "assistant"
    public string Content { get; set; }
}

// Claude response format
public class ClaudeChatResponse
{
    public List<ClaudeContentBlock> Content { get; set; }
}

public class ClaudeContentBlock
{
    public string Text { get; set; }
}
```

## Step 3: Create a Custom AI Service

To integrate Claude with Syncfusion Smart Components, you need to implement the `IChatInferenceService` interface. This interface acts as a bridge between Syncfusion's components and Claude's AI capabilities.

The `IChatInferenceService` interface is designed to allow custom AI service implementations. It defines the contract for how Syncfusion components communicate with AI services:

1. Create a new file named `MyCustomService.cs` 
2. Add the Syncfusion namespace
3. Implement the interface as shown below

```CSharp
using Syncfusion.Blazor.AI;
public class MyCustomService : IChatInferenceService
{
    private readonly ClaudeService _ClaudeService;

    public MyCustomService(ClaudeAIService ClaudeService)
    {
        _ClaudeService = ClaudeService;
    }

    public Task<string> GenerateResponseAsync(ChatParameters options)
    {
        return _ClaudeService.CompleteAsync(options.Messages);
    }
}
```


## Step 4: Configure the Blazor App

Configure your Blazor application to use the Claude AI service with Syncfusion Smart Components. This involves registering necessary services and setting up the dependency injection container.

```CSharp

using Syncfusion.Blazor.SmartComponents;
using Syncfusion.Blazor.AI;
var builder = WebApplication.CreateBuilder(args);

....

builder.Services.AddSyncfusionBlazor();
builder.Services.AddSyncfusionSmartComponents();
builder.Services.AddSingleton<ClaudeAIService>();
builder.Services.AddSingleton<IChatInferenceService, MyCustomService>();

var app = builder.Build();
....

```