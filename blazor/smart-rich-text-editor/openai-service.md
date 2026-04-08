---
layout: post
title: OpenAI Configuration for Blazor Smart Rich Text Editor | Syncfusion
description: Configure OpenAI for Syncfusion Blazor Smart Rich Text Editor API keys, client setup, DI registration, usage examples, and best practices.
platform: Blazor
control: Smart Rich Text Editor
documentation: ug
---

# OpenAI Configuration

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Smart Rich Text Editor supports OpenAI's GPT models for intelligent content assistance.

## Prerequisites

* Active OpenAI account with API access
* Valid API key from OpenAI
* Internet connectivity to access OpenAI services

## Get Your OpenAI API Key

1. Visit [OpenAI Platform](https://platform.openai.com/)
2. Sign in with your OpenAI account (create one if needed)
3. Navigate to **API Keys** section
4. Click **Create new secret key**
5. Copy and securely store your API key

## Supported Models

OpenAI offers various models for different use cases:

- `gpt-4-turbo`: Most capable, latest model
- `gpt-4`: Advanced reasoning and complex tasks
- `gpt-3.5-turbo`: Fast and cost-effective
- `gpt-3.5-turbo-16k`: Extended context window

> **Note**: Model availability and names may change. Refer to [OpenAI documentation](https://developers.openai.com/api/docs/models) for current options.

## Installation

Install the required NuGet packages:

{% tabs %}
{% highlight c# tabtitle="Package Manager" %}

Install-Package Syncfusion.Blazor.SmartRichTextEditor
Install-Package Syncfusion.Blazor.Themes
Install-Package Microsoft.Extensions.AI
Install-Package Microsoft.Extensions.AI.OpenAI

{% endhighlight %}
{% endtabs %}

## Configuration

### Step 1: Setup in Program.cs

Add the following configuration to your **Program.cs** file:

```csharp
using Syncfusion.Blazor;
using Syncfusion.Blazor.AI;
using Microsoft.Extensions.AI;
using OpenAI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// Register Syncfusion Blazor Service
builder.Services.AddSyncfusionBlazor();

// Configure OpenAI - load from configuration
string openAIApiKey = builder.Configuration["OpenAI:ApiKey"] 
    ?? throw new InvalidOperationException("OpenAI:ApiKey not configured");
string openAIModel = builder.Configuration["OpenAI:Model"] ?? "gpt-3.5-turbo";

OpenAIClient openAIClient = new OpenAIClient(openAIApiKey);
IChatClient openAIChatClient = openAIClient.GetChatClient(openAIModel).AsIChatClient();
builder.Services.AddSingleton<IChatClient>(openAIChatClient);

// Register Smart Rich Text Editor Components with OpenAI
builder.Services.AddSingleton<IChatInferenceService, SyncfusionAIService>();


var app = builder.Build();

// ... rest of your application setup
```

### Step 2: Add Imports to _Imports.razor

Update **~/_Imports.razor** to include necessary namespaces:

{% tabs %}
{% highlight razor tabtitle="~/Components/_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.SmartRichTextEditor

{% endhighlight %}
{% endtabs %}

### Step 3: Use OpenAI with Smart Rich Text Editor Component

Add the Smart Rich Text Editor to your Blazor page:

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.SmartRichTextEditor

<SfSmartRichTextEditor>
    <AssistViewSettings Placeholder="Start typing or use AI assistance..."/>
    <div>
        <strong>Tips:</strong>
        <ul>
            <li>Select text and click "AI Commands" for quick improvements</li>
            <li>Press Alt+Enter to open AI Query dialog</li>
            <li>Use AI to fix grammar, adjust tone, or rephrase content</li>
        </ul>
    </div>
</SfSmartRichTextEditor>

{% endhighlight %}
{% endtabs %}

## Using Environment Variables

For security, store your API key in environment variables:

### Windows

```powershell
$env:OPENAI_API_KEY = "your-api-key"
```

### Linux/macOS

```bash
export OPENAI_API_KEY="your-api-key"
```

### Reading from Environment in Program.cs

```csharp
string openAIApiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY") 
    ?? throw new InvalidOperationException("OpenAI API key not found in environment variables");
```

## Using User Secrets

For development, use User Secrets:

```bash
dotnet user-secrets init
dotnet user-secrets set "OpenAI:ApiKey" "your-api-key"
```

Access in Program.cs:

```csharp
var openAIApiKey = builder.Configuration["OpenAI:ApiKey"];
```

## Advanced Configuration

### Model Parameters

Customize OpenAI model behavior:

```csharp
builder.Services.AddSingleton<IChatInferenceService, SyncfusionAIService>();
    .ConfigureOpenAI(options =>
    {
        options.MaxTokens = 500;           // Limit response length
        options.Temperature = 0.7f;         // Creativity level (0-2)
        options.TopP = 0.9f;               // Diversity control
        options.FrequencyPenalty = 0.5f;   // Repeat penalty
        options.PresencePenalty = 0.5f;    // New topic penalty
    });
```

### Parameter Explanation

| Parameter | Range | Default | Description |
|-----------|-------|---------|-------------|
| MaxTokens | 1-4096 | 500 | Maximum length of AI response |
| Temperature | 0-2 | 0.7 | Higher = more creative, Lower = more focused |
| TopP | 0-1 | 0.9 | Nucleus sampling - controls diversity |
| FrequencyPenalty | -2-2 | 0 | Reduces likelihood of repetition |
| PresencePenalty | -2-2 | 0 | Encourages new topics |

## Troubleshooting

### Common Issues

**Authentication Error: 401 Unauthorized**
- Verify API key is correct
- Check API key is still valid and hasn't expired
- Ensure API key has necessary permissions

**Rate Limit Error: 429 Too Many Requests**
- Reduce request frequency
- Implement request throttling
- Check usage limits on OpenAI account

**Model Not Found Error**
- Verify model name is correct (check [model list](https://developers.openai.com/api/docs/models))
- Ensure model is available in your region/account

**No Response from AI**
- Check internet connectivity
- Verify API key permissions
- Review OpenAI service status

## Cost Optimization

### Tips for Reducing Costs

1. **Use Efficient Models**: `gpt-3.5-turbo` is significantly cheaper than `gpt-4`
2. **Limit Token Count**: Set reasonable `MaxTokens` values
3. **Implement Caching**: Cache common requests
4. **Monitor Usage**: Track API calls and costs
5. **Batch Operations**: Process multiple requests efficiently

## Security Best Practices

1. **Never hardcode API keys** - Use environment variables or secure configuration
2. **Use User Secrets** for development - Not for production
3. **Implement Rate Limiting** - Prevent abuse of your application
4. **Validate User Input** - Before sending to OpenAI
5. **Review Content** - Always review AI-generated content before publishing
6. **Set Spending Limits** - Configure usage limits on OpenAI account

## See also

* [Getting Started with Smart Rich Text Editor](getting-started.md)
* [AI Features and Customization](ai-features.md)
* [Azure OpenAI Configuration](azure-openai-service.md)
* [Ollama Configuration](ollama.md)
* [OpenAI Documentation](https://developers.openai.com/api/docs)