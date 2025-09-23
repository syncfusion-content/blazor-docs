---
layout: post
title: DeepSeek AI Integration with Blazor Smart TextArea | Syncfusion
description: Learn how to integrate the Syncfusion Blazor Smart TextArea with DeepSeek AI services in a Blazor App.
platform: Blazor
control: Smart TextArea
documentation: ug
---

# DeepSeek AI Integration with Blazor Smart TextArea

The Syncfusion Blazor Smart TextArea component provides AI-powered autocompletion for context-aware text input, typically using OpenAI or Azure OpenAI. This guide explains how to integrate the DeepSeek AI service with the Smart TextArea using the `IChatInferenceService` interface, enabling custom AI-driven responses in a Blazor Web App.

## Setting Up DeepSeek

1. **Obtain a DeepSeek API Key**  
   Create an account at [DeepSeek Platform](https://platform.deepseek.com), sign in, and navigate to [API Keys](https://platform.deepseek.com/api_keys) to generate an API key.
2. **Review Model Specifications**  
   Refer to [DeepSeek Models Documentation](https://api-docs.deepseek.com/quick_start/pricing) for details on available models (e.g., `deepseek-chat`).

## Create a DeepSeek AI Service

Create a service class to manage interactions with the DeepSeek API, including authentication and response processing for the Smart TextArea.

1. Create a `Services` folder in your project.
2. Add a new file named `DeepSeekAIService.cs` in the `Services` folder.
3. Implement the service as shown below, storing the API key securely in a configuration file or environment variable (e.g., `appsettings.json`).

```csharp
using System.Net;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.AI;

public class DeepSeekAIService
{
    private readonly string _apiKey;
    private readonly string _modelName = "deepseek-chat"; // Example model
    private readonly string _endpoint = "https://api.deepseek.com/v1/chat/completions";
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

    public DeepSeekAIService(IConfiguration configuration)
    {
        _apiKey = configuration["DeepSeek:ApiKey"] ?? throw new ArgumentNullException("DeepSeek API key is missing.");
        if (!HttpClient.DefaultRequestHeaders.Contains("Authorization"))
        {
            HttpClient.DefaultRequestHeaders.Clear();
            HttpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiKey}");
        }
    }

    public async Task<string> CompleteAsync(IList<ChatMessage> chatMessages)
    {
        var requestBody = new DeepSeekChatRequest
        {
            Model = _modelName,
            Temperature = 0.7f, // Controls response randomness (0.0 to 1.0)
            Messages = chatMessages.Select(m => new DeepSeekMessage
            {
                Role = m.Role == ChatRole.User ? "user" : "system", // Align with DeepSeek API roles
                Content = m.Text
            }).ToList()
        };

        var content = new StringContent(JsonSerializer.Serialize(requestBody, JsonOptions), Encoding.UTF8, "application/json");

        try
        {
            var response = await HttpClient.PostAsync(_endpoint, content);
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

N> Store the DeepSeek API key in `appsettings.json` (e.g., `{ "DeepSeek": { "ApiKey": "your-api-key" } }`) or as an environment variable to ensure security.

## Define Request and Response Models

Define C# classes to match the DeepSeek API’s JSON request and response format.

1. Create a new file named `DeepSeekModels.cs` in the `Services` folder.
2. Add the following model classes:

```csharp
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

## Create a Custom AI Service

Implement the `IChatInferenceService` interface to connect the Smart TextArea to the DeepSeek service, acting as a bridge for AI-generated responses.

1. Create a new file named `DeepSeekInferenceService.cs` in the `Services` folder.
2. Add the following implementation:

```csharp
using Syncfusion.Blazor.AI;
using System.Threading.Tasks;

public class DeepSeekInferenceService : IChatInferenceService
{
    private readonly DeepSeekAIService _deepSeekService;

    public DeepSeekInferenceService(DeepSeekAIService deepSeekService)
    {
        _deepSeekService = deepSeekService;
    }

    public async Task<string> GenerateResponseAsync(ChatParameters options)
    {
        return await _deepSeekService.CompleteAsync(options.Messages);
    }
}
```

## Configure the Blazor App

Register the DeepSeek service and `IChatInferenceService` implementation in the dependency injection container.

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
builder.Services.AddSingleton<DeepSeekAIService>();
builder.Services.AddSingleton<IChatInferenceService, DeepSeekInferenceService>();

var app = builder.Build();
// ...
```

## Use DeepSeek AI with Smart TextArea

Add the Smart TextArea component to a Razor file (e.g., `~/Pages/Home.razor`) to use DeepSeek AI for autocompletion:

```razor
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
3. Type phrases like "Thank" or "Please provide" in the Smart TextArea to verify that DeepSeek AI generates appropriate suggestions.
4. Check that suggestions appear as configured (e.g., inline or pop-up, based on the `ShowSuggestionOnPopup` setting).

![Smart TextArea with DeepSeek AI](images/smart-textarea.gif)

## Troubleshooting

If the DeepSeek AI integration does not work, try the following:
- **No Suggestions Displayed**: Verify that the DeepSeek API key and model name are correct in the configuration. Check the `DeepSeekAIService` implementation for errors.
- **HTTP Request Failures**: Ensure a stable internet connection and that the DeepSeek API endpoint (`https://api.deepseek.com/v1/chat/completions`) is accessible. Test with HTTP/2 if compatibility issues arise.
- **Service Registration Errors**: Confirm that `DeepSeekAIService` and `DeepSeekInferenceService` are registered in **Program.cs**.

## See Also

- [Getting Started with Syncfusion Blazor Smart TextArea in Blazor Web App](https://blazor.syncfusion.com/documentation/smart-textarea/getting-started-webapp)
- [Customizing Smart TextArea Suggestions](https://blazor.syncfusion.com/documentation/smart-textarea/customization)
