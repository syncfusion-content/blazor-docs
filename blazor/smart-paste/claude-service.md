---
layout: post
title: Claude AI Integration with Blazor Smart Paste Button | Syncfusion
description: Learn how to integrate the Syncfusion Blazor Smart Paste Button with Claude AI services in a Blazor App.
platform: Blazor
control: Smart Paste Button
documentation: ug
---

# Claude AI Integration with Blazor Smart Paste Button

The Syncfusion Blazor SmartPaste Button component enables AI-powered, context-aware content pasting into forms, typically using OpenAI or Azure OpenAI.  This guide explains how to integrate the Anthropic Claude AI service with the Smart Paste Button using the `IChatInferenceService` interface, enabling custom AI-driven responses in a Blazor Web App.

## Setting Up Claude

1. **Create an Anthropic Account**  
   Visit [Anthropic Console](https://console.anthropic.com), sign up, and complete the verification process.
2. **Obtain an API Key**  
   Navigate to [API Keys](https://console.anthropic.com/settings/keys) and click "Create Key."
3. **Review Model Specifications**  
   Refer to [Claude Models Documentation](https://docs.anthropic.com/claude/docs/models-overview) for details on available models.

## Create a Claude AI Service

Create a service class to manage interactions with the Claude API, including authentication and response processing for the Smart Paste Button.

1. Create a `Services` folder in your project.
2. Add a new file named `ClaudeAIService.cs` in the `Services` folder.
3. Implement the service as shown below, storing the API key securely in a configuration file or environment variable (e.g., `appsettings.json`).

```csharp
using System.Net;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.AI;

public class ClaudeAIService
{
    private readonly string _apiKey;
    private readonly string _modelName = "claude-3-5-sonnet-20241022"; // Example model
    private readonly string _endpoint = "https://api.anthropic.com/v1/messages";
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

    public ClaudeAIService(IConfiguration configuration)
    {
        _apiKey = configuration["Claude:ApiKey"] ?? throw new ArgumentNullException("Claude API key is missing.");
        if (!HttpClient.DefaultRequestHeaders.Contains("x-api-key"))
        {
            HttpClient.DefaultRequestHeaders.Clear();
            HttpClient.DefaultRequestHeaders.Add("x-api-key", _apiKey);
            HttpClient.DefaultRequestHeaders.Add("anthropic-version", "2023-06-01"); // Check latest version in Claude API docs
        }
    }

    public async Task<string> CompleteAsync(IList<ChatMessage> chatMessages)
    {
        var requestBody = new ClaudeChatRequest
        {
            Model = _modelName,
            Max_tokens = 1000, // Maximum tokens in response
            Messages = chatMessages.Select(m => new ClaudeMessage
            {
                Role = m.Role == ChatRole.User ? "user" : "assistant",
                Content = m.Text
            }).ToList(),
            Stop_sequences  = new List<string> { "END_INSERTION", "NEED_INFO", "END_RESPONSE" } // Configurable stop sequences
        };

        var content = new StringContent(JsonSerializer.Serialize(requestBody, JsonOptions), Encoding.UTF8, "application/json");

        try
        {
            var response = await HttpClient.PostAsync(_endpoint, content);
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

N> Store the Claude API key in `appsettings.json` (e.g., `{ "Claude": { "ApiKey": "your-api-key" } }`) or as an environment variable to ensure security. Verify the `anthropic-version` header in [Claude API Documentation](https://docs.anthropic.com/claude/docs) for the latest version.

## Define Request and Response Models

Define C# classes to match the Claude API’s JSON request and response format.

1. Create a new file named `ClaudeModels.cs` in the `Services` folder.
2. Add the following model classes:

```csharp
public class ClaudeChatRequest
{
    public string Model { get; set; }
    public int Max_tokens { get; set; }
    public List<ClaudeMessage> Messages { get; set; }
    public List<string> Stop_sequences  { get; set; }
}

public class ClaudeMessage
{
    public string Role { get; set; }
    public string Content { get; set; }
}

public class ClaudeChatResponse
{
    public List<ClaudeContentBlock> Content { get; set; }
}

public class ClaudeContentBlock
{
    public string Text { get; set; }
}
```

## Create a Custom AI Service

Implement the `IChatInferenceService` interface to connect the Smart Paste Button to the Claude service, acting as a bridge for AI-generated responses.

1. Create a new file named `ClaudeInferenceService.cs` in the `Services` folder.
2. Add the following implementation:

```csharp
using Syncfusion.Blazor.AI;
using System.Threading.Tasks;

public class ClaudeInferenceService : IChatInferenceService
{
    private readonly ClaudeAIService _claudeService;

    public ClaudeInferenceService(ClaudeAIService claudeService)
    {
        _claudeService = claudeService;
    }

    public async Task<string> GenerateResponseAsync(ChatParameters options)
    {
        return await _claudeService.CompleteAsync(options.Messages);
    }
}
```

## Configure the Blazor App

Register the Claude service and `IChatInferenceService` implementation in the dependency injection container.

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
builder.Services.AddSingleton<ClaudeAIService>();
builder.Services.AddSingleton<IChatInferenceService, ClaudeInferenceService>();

var app = builder.Build();
// ...
```

## Add the Smart Paste Button

Add the Smart Paste Button to a form in the **~/Pages/Home.razor** file to test the Groq AI integration.

```cshtml
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

If the Claude AI integration does not work, try the following:
- **No Suggestions Displayed**: Verify that the Claude API key and model name are correct in the configuration. Check the `ClaudeAIService` implementation for errors.
- **HTTP Request Failures**: Ensure a stable internet connection and that the Claude API endpoint (`https://api.anthropic.com/v1/messages`) is accessible. Test with HTTP/2 if compatibility issues arise.
- **Service Registration Errors**: Confirm that `ClaudeAIService` and `ClaudeInferenceService` are registered in **Program.cs**.

## See Also

- [Getting Started with Syncfusion Blazor Smart Paste Button in Blazor Web App](https://blazor.syncfusion.com/documentation/smart-paste/getting-started-webapp)
- [Customizing Smart Paste Button Suggestions](https://blazor.syncfusion.com/documentation/smart-paste/customization)

