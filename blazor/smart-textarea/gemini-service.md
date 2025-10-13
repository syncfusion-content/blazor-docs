---
layout: post
title: Gemini AI Integration with Blazor Smart TextArea | Syncfusion
description: Learn how to implement a custom AI service using Google's Gemini API with the Syncfusion Blazor Smart TextArea component in a Blazor App.
platform: Blazor
control: Smart TextArea
documentation: ug
---

# Gemini AI Integration with Blazor Smart TextArea

The Syncfusion Blazor Smart TextArea component provides AI-powered autocompletion for context-aware text input, typically using OpenAI or Azure OpenAI. This guide explains how to integrate the Google Gemini AI service with the Smart TextArea using the `IChatInferenceService` interface, enabling custom AI-driven responses in a Blazor Web App.

## Setting Up Gemini

1. **Obtain a Gemini API Key**  
   Visit [Google AI Studio](https://ai.google.dev/gemini-api/docs/api-key), sign in, and generate an API key.
2. **Review Model Specifications**  
   Refer to [Gemini Models Documentation](https://ai.google.dev/gemini-api/docs/models) for details on available models.

## Create a Gemini AI Service

Create a service class to manage interactions with the Gemini API, including authentication, request/response handling, and safety settings for the Smart TextArea.

1. Create a `Services` folder in your project.
2. Add a new file named `GeminiService.cs` in the `Services` folder.
3. Implement the service as shown below, storing the API key securely in a configuration file or environment variable (e.g., `appsettings.json`).

```csharp
using System.Net;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.AI;

public class GeminiService
{
    private readonly string _apiKey;
    private readonly string _modelName = "gemini-1.5-flash"; // Example model
    private readonly string _endpoint = "https://generativelanguage.googleapis.com/v1beta/models/";
    private static readonly HttpClient HttpClient = new(new SocketsHttpHandler
    {
        PooledConnectionLifetime = TimeSpan.FromMinutes(30),
        EnableMultipleHttp2Connections = true
    })
    {
        DefaultRequestVersion = HttpVersion.Version20 // Fallback to HTTP/2 for compatibility
    };
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };

    public GeminiService(IConfiguration configuration)
    {
        _apiKey = configuration["Gemini:ApiKey"] ?? throw new ArgumentNullException("Gemini API key is missing.");
        HttpClient.DefaultRequestHeaders.Clear();
        HttpClient.DefaultRequestHeaders.Add("x-goog-api-key", _apiKey);
    }

    public async Task<string> CompleteAsync(IList<ChatMessage> chatMessages)
    {
        var requestUri = $"{_endpoint}{_modelName}:generateContent";
        var parameters = BuildGeminiChatParameters(chatMessages);
        var payload = new StringContent(
            JsonSerializer.Serialize(parameters, JsonOptions),
            Encoding.UTF8,
            "application/json"
        );

        try
        {
            using var response = await HttpClient.PostAsync(requestUri, payload);
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<GeminiResponseObject>(json, JsonOptions);
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
        var contents = messages.Select(m => new ResponseContent(
            m.Text,
            m.Role == ChatRole.User ? "user" : "model"
        )).ToList();

        return new GeminiChatParameters
        {
            Contents = contents,
            GenerationConfig = new GenerationConfig
            {
                MaxOutputTokens = 2000,
                StopSequences = new List<string> { "END_INSERTION", "NEED_INFO", "END_RESPONSE" } // Configurable stop sequences
            },
            SafetySettings = new List<SafetySetting>
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

N> Store the Gemini API key in `appsettings.json` (e.g., `{ "Gemini": { "ApiKey": "your-api-key" } }`) or as an environment variable to ensure security. The `SafetySettings` filter harmful content; adjust thresholds based on your application’s needs.

## Define Request and Response Models

Define C# classes to match the Gemini API’s JSON request and response format.

1. Create a new file named `GeminiModels.cs` in the `Services` folder.
2. Add the following model classes:

```csharp
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

## Create a Custom AI Service

Implement the `IChatInferenceService` interface to connect the Smart TextArea to the Gemini service, acting as a bridge for AI-generated responses.

1. Create a new file named `GeminiInferenceService.cs` in the `Services` folder.
2. Add the following implementation:

```csharp
using Syncfusion.Blazor.AI;
using System.Threading.Tasks;

public class GeminiInferenceService : IChatInferenceService
{
    private readonly GeminiService _geminiService;

    public GeminiInferenceService(GeminiService geminiService)
    {
        _geminiService = geminiService;
    }

    public async Task<string> GenerateResponseAsync(ChatParameters options)
    {
        return await _geminiService.CompleteAsync(options.Messages);
    }
}
```

## Configure the Blazor App

Register the Gemini service and `IChatInferenceService` implementation in the dependency injection container.

Update the **~/Program.cs** file as follows:

```csharp
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Syncfusion.Blazor;
using Syncfusion.Blazor.AI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSyncfusionBlazor();
builder.Services.AddSyncfusionSmartComponents();
builder.Services.AddSingleton<GeminiService>();
builder.Services.AddSingleton<IChatInferenceService, GeminiInferenceService>();

var app = builder.Build();
// ...
```

## Use Gemini AI with Smart TextArea

Add the Smart TextArea component to a Razor file (e.g., `~/Pages/Home.razor`) to use Gemini AI for autocompletion:

<<<<<<< HEAD
```razor
=======
```cshtml
>>>>>>> 32c27d577704390b597a361089e564504af90b58
@using Syncfusion.Blazor.SmartComponents

<SfSmartTextArea UserRole="@userRole" UserPhrases="@userPhrases" Placeholder="Enter your queries here" @bind-Value="prompt" Width="75%" RowCount="5">
</SfSmartTextArea>

@code {
    private string? prompt;
    // Defines the context for AI autocompletion
    private string userRole = "Customer support representative";
    // Predefined phrases for AI to suggest during typing
    private string[] userPhrases = [
        "Thank you for reaching out.",
        "Please provide more details.",
        "We are investigating your issue."
    ];
}
```

## Test the Integration

1. Ensure all services are registered in **Program.cs** and the Smart TextArea is added to a Razor file.
2. Run the application using <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS).
3. Type phrases like "Thank" or "Please provide" in the Smart TextArea to verify that Gemini AI generates appropriate suggestions.
4. Check that suggestions appear as configured (e.g., inline or pop-up, based on the `ShowSuggestionOnPopup` setting).

![Smart TextArea with Gemini AI](images/smart-textarea.gif)

## Troubleshooting

If the Gemini AI integration does not work, try the following:
- **No Suggestions Displayed**: Verify that the Gemini API key and model name are correct in the configuration. Check the `GeminiService` implementation for errors.
- **HTTP Request Failures**: Ensure a stable internet connection and that the Gemini API endpoint (`https://generativelanguage.googleapis.com/v1beta/models/`) is accessible. Test with HTTP/2 if compatibility issues arise.
- **Service Registration Errors**: Confirm that `GeminiService` and `GeminiInferenceService` are registered in **Program.cs**.

## See Also

- [Getting Started with Syncfusion Blazor Smart TextArea in Blazor Web App](https://blazor.syncfusion.com/documentation/smart-textarea/getting-started-webapp)
- [Customizing Smart TextArea Suggestions](https://blazor.syncfusion.com/documentation/smart-textarea/customization)
