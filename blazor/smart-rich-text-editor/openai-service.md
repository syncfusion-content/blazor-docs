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

## Set Up the Smart Rich Text Editor Component

Follow the [Getting Started](https://blazor.syncfusion.com/documentation/smart-rich-text-editor/getting-started-webapp) guide to configure and render the Smart Rich Text Editor component in the application and that prerequisites are met.

## Installation

Install the following NuGet packages to your project:

* [Microsoft.Extensions.AI](https://www.nuget.org/packages/Microsoft.Extensions.AI)
* [Microsoft.Extensions.AI.OpenAI](https://www.nuget.org/packages/Microsoft.Extensions.AI.OpenAI)

You can install these packages using different methods as shown below:

{% tabcontents %}

{% tabcontent Visual Studio %}

## Steps
1. In Visual Studio Navigate to:

   **Tools → NuGet Package Manager → Manage NuGet Packages for Solution**
2. Search for the required packages.
3. Select the package and click **Install**.

{% endtabcontent %}

{% tabcontent Visual Studio (Package Manager Console) %}

## Steps
1. In Visual Studio Navigate to:

   **Tools → NuGet Package Manager → Package Manager Console**
2. Run the following commands:

{% tabs %}
{% highlight C# tabtitle="Install Packages" %}

Install-Package Microsoft.Extensions.AI
Install-Package Microsoft.Extensions.AI.OpenAI

{% endhighlight %}
{% endtabs %}

{% endtabcontent %}

{% tabcontent Visual Studio Code / .NET CLI %}

## Steps
1. Open your project.
2. Open the terminal:
   - In Visual Studio Code: use the integrated terminal (<kbd>Ctrl</kbd> + <kbd>`</kbd>)
   - Or use any system terminal for CLI
3. Run the following commands:

{% tabs %}
{% highlight C# tabtitle="Install Packages" %}

dotnet add package Microsoft.Extensions.AI
dotnet add package Microsoft.Extensions.AI.OpenAI

{% endhighlight %}
{% endtabs %}

{% endtabcontent %}

{% endtabcontents %}

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

// Configure OpenAI
string openAIApiKey = "Your API Key";
string openAIModel = "Your Model Name";
OpenAIClient openAIClient = new OpenAIClient(openAIApiKey);
IChatClient openAIChatClient = openAIClient.GetChatClient(openAIModel).AsIChatClient();
builder.Services.AddSingleton<IChatClient>(openAIChatClient);

// Register Smart Rich Text Editor Components with OpenAI
builder.Services.AddSingleton<IChatInferenceService, SyncfusionAIService>();

var app = builder.Build();

// ... rest of your application setup
```

### Step 2: Use OpenAI with Smart Rich Text Editor Component

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

* [Getting Started with Smart Rich Text Editor](https://blazor.syncfusion.com/documentation/smart-rich-text-editor/getting-started-webapp)
* [Azure OpenAI Configuration](https://blazor.syncfusion.com/documentation/smart-rich-text-editor/azure-openai-service)
* [Ollama Configuration](https://blazor.syncfusion.com/documentation/smart-rich-text-editor/ollama)
* [OpenAI Documentation](https://developers.openai.com/api/docs)