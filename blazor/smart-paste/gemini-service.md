---
layout: post
title: Gemini AI Integration with Blazor Smart Paste Button | Syncfusion
description: Learn how to implement a custom AI service using Google's Gemini API with the Syncfusion Blazor Smart Paste Button component in a Blazor App.
platform: Blazor
control: Smart Paste Button
documentation: ug
---

# Gemini AI Integration with Blazor Smart Paste Button

The Syncfusion Blazor SmartPaste Button component enables AI-powered, context-aware content pasting into forms, typically using OpenAI or Azure OpenAI.  This guide explains how to integrate the Google Gemini AI service with the Smart Paste Button using the `IChatInferenceService` interface, enabling custom AI-driven responses in a Blazor Web App.

## Setting Up Gemini

1. **Obtain a Gemini API Key**  
   Visit [Google AI Studio](https://ai.google.dev/gemini-api/docs/api-key), sign in, and generate an API key.
2. **Review Model Specifications**  
   Refer to [Gemini Models Documentation](https://ai.google.dev/gemini-api/docs/models) for details on available models.

## Create a Gemini AI Service

Create a service class to manage interactions with the Gemini API, including authentication, request/response handling, and safety settings for the Smart Paste Button.

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

Implement the `IChatInferenceService` interface to connect the Smart Paste Button to the Gemini service, acting as a bridge for AI-generated responses.

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

## Add the Smart Paste Button

Add the Smart Paste Button to a form in the **~/Pages/Home.razor** file to test the Groq AI integration.

<<<<<<< HEAD
```razor
=======
```cshtml
>>>>>>> 32c27d577704390b597a361089e564504af90b58
@using Syncfusion.Blazor.DataForm
@using Syncfusion.Blazor.SmartComponents
@using System.ComponentModel.DataAnnotations

<SfDataForm ID="MyForm" Model="@EventRegistrationModel">
    <FormValidator>
        <DataAnnotationsValidator></DataAnnotationsValidator>
    </FormValidator>
    <FormItems>
        <FormItem Field="@nameof(EventRegistration.Name)" ID="firstname"></FormItem>
        <FormItem Field="@nameof(EventRegistration.Email)" ID="email"></FormItem>
        <FormItem Field="@nameof(EventRegistration.Phone)" ID="phonenumber"></FormItem>
        <FormItem Field="@nameof(EventRegistration.Address)" ID="address"></FormItem>
    </FormItems>
    <FormButtons>
        <SfSmartPasteButton IsPrimary="true" Content="Smart Paste" IconCss="e-icons e-paste"></SfSmartPasteButton>
    </FormButtons>
</SfDataForm>

<br>
<h4 style="text-align:center;">Sample Content</h4>
<div>
    Hi, my name is Jane Smith. You can reach me at example@domain.com or call me at +1-555-987-6543. I live at 789 Pine Avenue, Suite 12, Los Angeles, CA 90001.
</div>

@code {
    private EventRegistration EventRegistrationModel = new();

    public class EventRegistration
    {
        [Required(ErrorMessage = "Please enter your name.")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your email address.")]
        [Display(Name = "Email ID")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your mobile number.")]
        [Display(Name = "Phone Number")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Please enter your address.")]
        [Display(Name = "Address")]
        public string Address { get; set; }
    }
}
```

N> Ensure the [Syncfusion Blazor DataForm](https://blazor.syncfusion.com/documentation/data-form/getting-started-with-web-app) package is installed for form integration.

## Testing the Integration

1. Configure the Blazor Web App with the Groq AI service and Smart Paste Button as described above.
2. Add the code to **~/Pages/Home.razor**, **Program.cs**, and the `Services` folder.
3. Run the application using <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS).
4. Copy the sample content provided in the Razor file.
5. Click the **Smart Paste** button to verify that the form fields are populated correctly using the Groq AI service.

![Syncfusion Blazor Smart Paste Button with Groq AI](images/smart-paste.gif)

N> [View Sample in GitHub](https://github.com/syncfusion/smart-ai-samples).

## Troubleshooting

If the Gemini AI integration does not work, try the following:
- **No Suggestions Displayed**: Verify that the Gemini API key and model name are correct in the configuration. Check the `GeminiService` implementation for errors.
- **HTTP Request Failures**: Ensure a stable internet connection and that the Gemini API endpoint (`https://generativelanguage.googleapis.com/v1beta/models/`) is accessible. Test with HTTP/2 if compatibility issues arise.
- **Service Registration Errors**: Confirm that `GeminiService` and `GeminiInferenceService` are registered in **Program.cs**.

## See Also

- [Getting Started with Syncfusion Blazor Smart Paste Button in Blazor Web App](https://blazor.syncfusion.com/documentation/smart-paste/getting-started-webapp)
- [Customizing Smart Paste Button Suggestions](https://blazor.syncfusion.com/documentation/smart-paste/customization)