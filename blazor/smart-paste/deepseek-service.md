---
layout: post
title: DeepSeek AI Integration with Blazor Smart Paste Button | Syncfusion
description: Learn how to integrate the Syncfusion Blazor Smart Paste Button with DeepSeek AI services in a Blazor App.
platform: Blazor
control: Smart Paste Button
documentation: ug
---

# DeepSeek AI Integration with Blazor Smart Paste Button

The Syncfusion Blazor SmartPaste Button component enables AI-powered, context-aware content pasting into forms, typically using OpenAI or Azure OpenAI.  This guide explains how to integrate the DeepSeek AI service with the Smart Paste Button using the `IChatInferenceService` interface, enabling custom AI-driven responses in a Blazor Web App.

## Setting Up DeepSeek

1. **Obtain a DeepSeek API Key**  
   Create an account at [DeepSeek Platform](https://platform.deepseek.com), sign in, and navigate to [API Keys](https://platform.deepseek.com/api_keys) to generate an API key.
2. **Review Model Specifications**  
   Refer to [DeepSeek Models Documentation](https://api-docs.deepseek.com/quick_start/pricing) for details on available models (e.g., `deepseek-chat`).

## Create a DeepSeek AI Service

Create a service class to manage interactions with the DeepSeek API, including authentication and response processing for the Smart Paste Button.

1. Create a `Services` folder in your project.
2. Add a new file named `DeepSeekAIService.cs` in the `Services` folder.
3. Implement the service as shown below, storing the API key securely in a configuration file or environment variable (e.g., `appsettings.json`).

{% tabs %}
{% highlight c# tabtitle="DeepSeekAIService.cs" %}

using System.Net;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.AI;

public class DeepSeekAIService
{
    private readonly string _apiKey;
    private readonly string _modelName = "deepseek-chat"; // Example model
    private readonly string _endpoint = "https://api.deepseek.com/chat/completions";
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

{% endhighlight %}
{% endtabs %}

N> Store the DeepSeek API key in `appsettings.json` (e.g., `{ "DeepSeek": { "ApiKey": "your-api-key" } }`) or as an environment variable to ensure security.

## Define Request and Response Models

Define C# classes to match the DeepSeek API’s JSON request and response format.

1. Create a new file named `DeepSeekModels.cs` in the `Services` folder.
2. Add the following model classes:

{% tabs %}
{% highlight c# tabtitle="DeepSeekModels.cs" %}

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

{% endhighlight %}
{% endtabs %}

## Create a Custom AI Service

Implement the `IChatInferenceService` interface to connect the Smart Paste Button to the DeepSeek service, acting as a bridge for AI-generated responses.

1. Create a new file named `DeepSeekInferenceService.cs` in the `Services` folder.
2. Add the following implementation:

{% tabs %}
{% highlight c# tabtitle="DeepSeekInferenceService.cs" %}

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

{% endhighlight %}
{% endtabs %}

## Configure the Blazor App

Register the DeepSeek service and `IChatInferenceService` implementation in the dependency injection container.

Update the **~/Program.cs** file as follows:

{% tabs %}
{% highlight c# tabtitle="~/Program.cs" hl_lines="3 10 11" %}

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

{% endhighlight %}
{% endtabs %}

## Add the Smart Paste Button

Add the Smart Paste Button to a form in the **~/Pages/Home.razor** file to test the Groq AI integration.

{% tabs %}
{% highlight c# tabtitle="~/Pages/Home.razor" %}

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

{% endhighlight %}
{% endtabs %}

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

If the DeepSeek AI integration does not work, try the following:
- **No Suggestions Displayed**: Verify that the DeepSeek API key and model name are correct in the configuration. Check the `DeepSeekAIService` implementation for errors.
- **HTTP Request Failures**: Ensure a stable internet connection and that the DeepSeek API endpoint (`https://api.deepseek.com/v1/chat/completions`) is accessible. Test with HTTP/2 if compatibility issues arise.
- **Service Registration Errors**: Confirm that `DeepSeekAIService` and `DeepSeekInferenceService` are registered in **Program.cs**.

## See Also

- [Getting Started with Syncfusion Blazor Smart Paste Button in Blazor Web App](https://blazor.syncfusion.com/documentation/smart-paste/getting-started-webapp)
- [Customizing Smart Paste Button Suggestions](https://blazor.syncfusion.com/documentation/smart-paste/customization)
