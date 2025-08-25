---
layout: post
title: Groq AI Service with Smart Components in Blazor App | Syncfusion
description: Learn how to implement a custom AI service using Groq API with Syncfusion Smart Components in a Blazor App.
control: Smart Paste Button
documentation: ug
---

# Getting Started with Smart Components using Groq AI Service

This guide provides step-by-step instructions for integrating and using Syncfusion's Smart Components with Groq AI services in your Blazor App. 

## Prerequisites

Before you begin, ensure you have:

* [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)
* Groq account and API key (see setup instructions below)

### Setting Up Groq

1. **Create a Groq Account**
   * Visit [Groq Cloud Console](https://console.groq.com)
   * Sign up for a new account or sign in
   * Complete the verification process

2. **Get Your API Key**
   * Navigate to [API Keys](https://console.groq.com/keys) in the Groq Console
   * Click "Create API Key"

### Models

For detailed model specifications and capabilities, visit the [Groq Models Documentation](https://console.groq.com/docs/models).

## Getting Started for Groq AI with SmartPasteButton

After completing this setup, you can:

1. [Add Smart Components to your Blazor pages](https://blazor.syncfusion.com/documentation/smart-paste/getting-started)
2. [Configure form annotations for better AI understanding](https://blazor.syncfusion.com/documentation/smart-paste/annotation)
3. [Customize the appearance and behavior of Smart Components](https://blazor.syncfusion.com/documentation/smart-paste/customization)

---

## Step 1: Create a Groq AI Service

In this step, we'll create a service class that handles all interactions with the Groq API. This service will:

* Manage API authentication
* Send chat messages to Groq's LLM models
* Process responses for use in your application

### Implementation Steps

1. Create a new file named `GroqService.cs` in your project's `Services` folder
2. Add the required namespaces for HTTP and JSON handling
3. Implement the service class following the code below


```csharp

using System.Net;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.AI;
public class GroqService
{
   private const string ApiKey = "Your API key";
   private const string ModelName = "Your Model Name";
   private const string Endpoint = "https://api.groq.com/openai/v1/chat/completions";

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

   public GroqService()
   {
      if (!HttpClient.DefaultRequestHeaders.Contains("Authorization"))
      {
            HttpClient.DefaultRequestHeaders.Clear();
            HttpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {ApiKey}");
      }
   }

   public async Task<string> CompleteAsync(IList<ChatMessage> chatMessages)
   {
      var requestPayload = new GroqChatParameters
      {
            Model = ModelName,
            Messages = chatMessages.Select(m => new Message
            {
               Role = m.Role == ChatRole.User ? "user" : "assistant",
               Content = m.Text
            }).ToList(),
            Stop = new() { "END_INSERTION", "NEED_INFO", "END_RESPONSE" }
      };

      var content = new StringContent(JsonSerializer.Serialize(requestPayload, JsonOptions), Encoding.UTF8, "application/json");

      try
      {
            var response = await HttpClient.PostAsync(Endpoint, content);
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            var responseObject = JsonSerializer.Deserialize<GroqResponseObject>(responseString, JsonOptions);

            return responseObject?.Choices?.FirstOrDefault()?.Message?.Content ?? "No response from model.";
      }
      catch (Exception ex) when (ex is HttpRequestException || ex is JsonException)
      {
            throw new InvalidOperationException("Failed to communicate with Groq API.", ex);
      }
   }
}


```

## Step 2: Define Request and Response Models

To communicate effectively with the Groq API, we need to define C# classes that map to Groq's API format. 

1. Create a new file named `GroqModels.cs` in your project
2. Add the following model classes that represent the API contract

### Key Components

* **Message**: Represents a single chat message with role and content
* **GroqChatParameters**: The main request object sent to Groq
* **GroqResponseObject**: The response received from Groq
* **Choice**: Represents a single response option from the model

```CSharp
public class Choice
{
    public Message Message { get; set; }
}

public class Message
{
    public string Role { get; set; }
    public string Content { get; set; }
}

public class GroqChatParameters
{
    public string Model { get; set; }
    public List<Message> Messages { get; set; }
    public List<string> Stop { get; set; }
}

public class GroqResponseObject
{
    public string Model { get; set; }
    public List<Choice> Choices { get; set; }
}
```

## Step 3: Create a Custom AI Service

Create a bridge between Syncfusion's Smart Components and our Groq service. This enables the Smart Components to use Groq's AI capabilities through a `IChatInferenceService` interface.

The `IChatInferenceService` interface is part of Syncfusion's infrastructure that allows Smart Components to work with different AI providers:

1. Create a new file named `MyCustomService.cs` 
2. Add the Syncfusion namespace
3. Implement the interface as shown below


```CSharp
using Syncfusion.Blazor.AI;
public class MyCustomService : IChatInferenceService
{
    public GroqService _groqServices;
    public MyCustomService(GroqService groqServices) {
        _groqServices = groqServices;
    }
    public Task<string> GenerateResponseAsync(ChatParameters options)
    {
        return _groqServices.CompleteAsync(options.Messages);
        throw new NotImplementedException();
    }
}
```

## Step 4: Configure the Blazor App

Configure your Blazor application to use the Groq AI service with Syncfusion Smart Components. This involves registering necessary services and setting up the dependency injection container.

```CSharp

using Syncfusion.Blazor.SmartComponents;
using Syncfusion.Blazor.AI;
var builder = WebApplication.CreateBuilder(args);

....

builder.Services.AddSyncfusionBlazor();
builder.Services.AddSyncfusionSmartComponents();
builder.Services.AddSingleton<GroqService>();
builder.Services.AddSingleton<IChatInferenceService, MyCustomService>();

var app = builder.Build();
....

```

