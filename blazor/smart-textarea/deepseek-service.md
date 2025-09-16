---
layout: post
title: Deepseek AI Service with Smart Components in Blazor App | Syncfusion
description: Learn how to integrate and use the Syncfusion component in a Blazor Web App with DeepSeek AI services.
platform: Blazor
control: Smart TextArea
documentation: ug
---

# Getting Started with Smart Components using DeepSeek AI

This guide demonstrates how to integrate DeepSeek's powerful AI capabilities with Syncfusion<sup style="font-size:70%">&reg;</sup> Smart Components in your Blazor App. 

## Prerequisites

Before you begin, ensure you have:

* [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)
* DeepSeek account and API key (see setup instructions below)

### Setting Up DeepSeek

1. **DeepSeek API Access**
   * Create a DeepSeek account at [platform.deepseek.com](https://platform.deepseek.com)
   * Navigate to [API Keys](https://platform.deepseek.com/api_keys)

2. **DeepSeek Models**

   For detailed specifications and pricing, visit the [DeepSeek Models Documentation](https://api-docs.deepseek.com/quick_start/pricing).


---

## Getting Started for DeepSeek AI with SmartTextArea

After completing this setup, you can:

1. [Add Smart TextArea to your Blazor pages](https://blazor.syncfusion.com/documentation/smart-textarea/getting-started)
2. [Customize Smart TextArea features](https://blazor.syncfusion.com/documentation/smart-textarea/customization)

---

## Step 1: Create a DeepSeek AI Service

The `DeepSeekAIService` class is responsible for managing all interactions with the DeepSeek API. This service:

### Implementation Steps

1. Create a new file named `DeepSeekAIService.cs`
2. Add the following using statements for required dependencies
3. Implement the service class as shown below

```csharp
using System.Text;
using System.Text.Json;
using System.Net;
using Microsoft.Extensions.AI;
public class DeepSeekAIService
{
    private const string ApiKey = "Your API Key";
    private const string ModelName = "Your Model Name";
    private const string Endpoint = "https://api.deepseek.com/v1/chat/completions";

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

    public DeepSeekAIService()
    {
        if (!HttpClient.DefaultRequestHeaders.Contains("Authorization"))
        {
            HttpClient.DefaultRequestHeaders.Clear();
            HttpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {ApiKey}");
        }
    }

    public async Task<string> CompleteAsync(IList<ChatMessage> chatMessages)
    {
        var requestBody = new DeepSeekChatRequest
        {
            Model = ModelName,
            Temperature = 0.7f,
            Messages = chatMessages.Select(m => new DeepSeekMessage
            {
                Role = m.Role == ChatRole.User ? "user" : "system",
                Content = m.Text
            }).ToList()
        };


        var json = JsonSerializer.Serialize(requestBody, JsonOptions);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        try
        {
            var response = await HttpClient.PostAsync(Endpoint, content);
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            var responseObject = JsonSerializer.Deserialize<DeepSeekChatResponse>(responseString, JsonOptions);

            return responseObject?.Choices?.FirstOrDefault()?.Message?.Content ?? "No response from DeepSeek.";
        }
        catch (Exception ex) when (ex is HttpRequestException || ex is JsonException)
        {
                
            throw new InvalidOperationException("Failed to communicate with DeepSeek API.", ex);
        }
    }
}
```

## Step 2: Define Request and Response Models

To effectively communicate with DeepSeek's API, we need to create strongly-typed models that represent the request and response data structures. 

Create a new file named `DeepSeekModels.cs` with the following models:

```CSharp
public class DeepSeekMessage
{
    public string Role { get; set; }
    public string Content { get; set; }
}

public class DeepSeekChatRequest
{
    public string Model { get; set; }
    public float Temperature { get; set; }
    public List<DeepSeekMessage> Messages { get; set; }
}

public class DeepSeekChatResponse
{
    public List<DeepSeekChoice> Choices { get; set; }
}

public class DeepSeekChoice
{
    public DeepSeekMessage Message { get; set; }
}
```

## Step 3: Create a Custom AI Service

To integrate DeepSeek with Syncfusion<sup style="font-size:70%">&reg;</sup> Smart Components, we'll create a custom implementation of the `IChatInferenceService` interface. This interface acts as a bridge between Syncfusion<sup style="font-size:70%">&reg;</sup> components and your AI service.

The `IChatInferenceService` interface is the bridge between Syncfusion<sup style="font-size:70%">&reg;</sup> Smart Components and AI services:

1. Create a new file named `MyCustomService.cs`
2. Add the following implementation:

```csharp
using Syncfusion.Blazor.AI;
public class MyCustomService : IChatInferenceService
{
    private readonly DeepSeekAIService _DeepSeekService;

    public MyCustomService(DeepSeekAIService DeepSeekService)
    {
        _DeepSeekService = DeepSeekService;
    }

    public Task<string> GenerateResponseAsync(ChatParameters options)
    {
        return _DeepSeekService.CompleteAsync(options.Messages);
    }
}
```

## Step 4: Configure the Blazor App

Configure your Blazor application to use the DeepSeek AI service with Syncfusion<sup style="font-size:70%">&reg;</sup> Smart Components. This involves registering necessary services and setting up the dependency injection container.

```CSharp

using Syncfusion.Blazor.SmartComponents;
using Syncfusion.Blazor.AI;
var builder = WebApplication.CreateBuilder(args);

....

builder.Services.AddSyncfusionBlazor();
builder.Services.AddSyncfusionSmartComponents();
builder.Services.AddSingleton<DeepSeekAIService>();
builder.Services.AddSingleton<IChatInferenceService, MyCustomService>();

var app = builder.Build();
....

```
