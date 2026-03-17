---
layout: post
title: Azure OpenAI Configuration for Syncfusion Smart Rich Text Editor
description: Configure Azure OpenAI for Syncfusion Blazor Smart Rich Text Editor: authentication, client setup, DI registration, and usage examples.
platform: Blazor
control: Smart Rich Text Editor
documentation: ug
---

# Azure OpenAI Configuration

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Smart Rich Text Editor supports Azure OpenAI for enterprise-grade AI capabilities with enhanced security and compliance features.

## Prerequisites

* Active Azure subscription
* Azure OpenAI Service resource deployed
* Deployed model (e.g., gpt-4, gpt-35-turbo)
* Azure credentials with necessary permissions

## Deploy Azure OpenAI Service

### Step 1: Create Azure OpenAI Resource

1. Sign in to [Azure Portal](https://portal.azure.com/)
2. Click **Create a resource**
3. Search for **Azure OpenAI**
4. Click **Create**
5. Fill in the resource details:
   - **Subscription**: Select your subscription
   - **Resource group**: Create or select existing
   - **Region**: Choose appropriate region
   - **Name**: Give your resource a unique name
   - **Pricing tier**: Select S0 or higher

### Step 2: Deploy a Model

1. Go to **Azure AI Studio** (https://oai.azure.com/)
2. Select your Azure OpenAI resource
3. Navigate to **Deployments**
4. Click **Create new deployment**
5. Configure:
   - **Deployment name**: e.g., `gpt-35-turbo-deployment`
   - **Model name**: Select model (e.g., `gpt-35-turbo`, `gpt-4`)
   - **Model version**: Choose version
   - **Deployment type**: Standard

### Step 3: Obtain Credentials

From your Azure OpenAI resource in Azure Portal, copy:
- **Endpoint**: `https://<resource-name>.openai.azure.com/`
- **Key**: Found under **Keys and Endpoint**
- **Deployment name**: Created in Step 2

## Installation

Install required NuGet packages:

{% tabs %}
{% highlight c# tabtitle="Package Manager" %}

Install-Package Syncfusion.Blazor.SmartRichTextEditor
Install-Package Syncfusion.Blazor.Themes
Install-Package Microsoft.Extensions.AI
Install-Package Microsoft.Extensions.AI.OpenAI
Install-Package Azure.AI.OpenAI

{% endhighlight %}
{% endtabs %}

## Configuration

### Step 1: Setup in Program.cs

Add the following configuration to your **Program.cs** file:

```csharp
using Syncfusion.Blazor;
using Syncfusion.Blazor.AI;
using Azure.AI.OpenAI;
using Microsoft.Extensions.AI;
using System.ClientModel;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// Register Syncfusion Blazor Service
builder.Services.AddSyncfusionBlazor();

// Configure Azure OpenAI
string azureOpenAIKey = "your-azure-key";
string azureOpenAIEndpoint = "https://your-resource-name.openai.azure.com/";
string azureOpenAIDeployment = "your-deployment-name";

AzureOpenAIClient azureOpenAIClient = new AzureOpenAIClient(
    new Uri(azureOpenAIEndpoint),
    new ApiKeyCredential(azureOpenAIKey)
);

IChatClient azureOpenAIChatClient = azureOpenAIClient
    .GetChatClient(azureOpenAIDeployment)
    .AsIChatClient();

builder.Services.AddChatClient(azureOpenAIChatClient);

// Register Smart Rich Text Editor Components with Azure OpenAI
builder.Services.AddSingleton<IChatInferenceService, SyncfusionAIService>();

var app = builder.Build();

// ... rest of your application setup
```

### Step 2: Add Imports to _Imports.razor

Update **~/_Imports.razor**:

```razor
@using Syncfusion.Blazor
@using Syncfusion.Blazor.SmartRichTextEditor
```

### Step 3: Use Azure OpenAI with Smart Rich Text Editor Component

```razor
@page "/editor"
@using Syncfusion.Blazor.SmartRichTextEditor

<SfSmartRichTextEditor>
    <AssistViewSettings Placeholder="Start typing for AI assistance..."/>
    <div>
        <strong>Tips:</strong>
        <ul>
            <li>Select text and click AI Commands for quick improvements</li>
            <li>Press Alt+Enter to open AI Query dialog</li>
            <li>Use AI to fix grammar, adjust tone, or rephrase content</li>
        </ul>
        <p>Welcome to the Smart Rich Text Editor — try selecting a sentence to see AI suggestions.</p>
    </div>
</SfSmartRichTextEditor>
```

## Using Configuration Files

### appsettings.json

Store Azure credentials in configuration:

```json
{
  "AzureOpenAI": {
    "Key": "your-azure-key",
    "Endpoint": "https://your-resource-name.openai.azure.com/",
    "DeploymentName": "your-deployment-name"
  }
}
```

### Reading from Configuration

```csharp
string azureOpenAIKey = builder.Configuration["AzureOpenAI:Key"];
string azureOpenAIEndpoint = builder.Configuration["AzureOpenAI:Endpoint"];
string azureOpenAIDeployment = builder.Configuration["AzureOpenAI:DeploymentName"];

AzureOpenAIClient azureOpenAIClient = new AzureOpenAIClient(
    new Uri(azureOpenAIEndpoint),
    new ApiKeyCredential(azureOpenAIKey)
);

IChatClient azureOpenAIChatClient = azureOpenAIClient
    .GetChatClient(azureOpenAIDeployment)
    .AsIChatClient();

builder.Services.AddChatClient(azureOpenAIChatClient);
```

## Using User Secrets

For development environment:

```bash
dotnet user-secrets init
dotnet user-secrets set "AzureOpenAI:Key" "your-azure-key"
dotnet user-secrets set "AzureOpenAI:Endpoint" "https://your-resource-name.openai.azure.com/"
dotnet user-secrets set "AzureOpenAI:DeploymentName" "your-deployment-name"
```

## Advanced Configuration

### Model Parameters

Customize Azure OpenAI behavior:

```csharp
builder.Services.AddSingleton<IChatInferenceService, SyncfusionAIService>();
    .ConfigureAzureOpenAI(options =>
    {
        options.MaxTokens = 500;
        options.Temperature = 0.7f;
        options.TopP = 0.9f;
        options.FrequencyPenalty = 0.5f;
        options.PresencePenalty = 0.5f;
    });
```

### Multiple Deployments

For production with multiple model deployments:

```csharp
// Create clients for different deployments
var gpt35Client = azureOpenAIClient
    .GetChatClient("gpt-35-turbo-deployment")
    .AsIChatClient();

var gpt4Client = azureOpenAIClient
    .GetChatClient("gpt-4-deployment")
    .AsIChatClient();

// Register based on use case
builder.Services.AddKeyedSingleton<IChatClient>("gpt-35-turbo", gpt35Client);
builder.Services.AddKeyedSingleton<IChatClient>("gpt-4", gpt4Client);
```

## Supported Models

Azure OpenAI supports various models:

| Model | Deployment Name | Use Case |
|-------|-----------------|----------|
| GPT-4 | `gpt-4` | Complex reasoning, high quality |
| GPT-4 Turbo | `gpt-4-turbo` | Latest capabilities, balanced cost |
| GPT-3.5 Turbo | `gpt-35-turbo` | Fast responses, cost-effective |

## Security Features

### Benefits of Azure OpenAI

1. **Enterprise Security**
   - Virtual Network support
   - Private endpoints
   - Azure security standards

2. **Compliance**
   - HIPAA compliance
   - SOC 2 compliance
   - Data residency options

3. **Access Control**
   - Azure AD integration
   - Role-based access control
   - Managed identities

4. **Monitoring**
   - Azure Monitor integration
   - Detailed logging
   - Usage analytics

### Managed Identity (Recommended)

For enhanced security using Managed Identity:

```csharp
// Enable Managed Identity in Azure
// In Program.cs
using Azure.Identity;

var credential = new DefaultAzureCredential();
string azureOpenAIEndpoint = "https://your-resource-name.openai.azure.com/";
string azureOpenAIDeployment = "your-deployment-name";

AzureOpenAIClient azureOpenAIClient = new AzureOpenAIClient(
    new Uri(azureOpenAIEndpoint),
    credential
);

IChatClient azureOpenAIChatClient = azureOpenAIClient
    .GetChatClient(azureOpenAIDeployment)
    .AsIChatClient();

builder.Services.AddChatClient(azureOpenAIChatClient);
```

## Troubleshooting

### Common Issues

**Error: ResourceNotFound (404)**
- Verify endpoint URL is correct
- Check resource name matches your Azure resource
- Ensure resource exists in specified region

**Error: InvalidAuthenticationTokenTenant (401)**
- Verify API key is correct
- Check key hasn't expired
- Ensure using the correct region's key

**Error: Model not found (404)**
- Verify deployment name matches your Azure deployment
- Check deployment is active and ready
- Ensure model is properly deployed

**Timeout Issues**
- Check Azure OpenAI resource capacity
- Verify network connectivity
- Consider timeout configuration

## Monitoring and Analytics

### Azure Monitor Integration

Monitor your Smart Rich Text Editor usage:

1. Go to your Azure OpenAI resource
2. Click **Monitoring** > **Metrics**
3. View metrics:
   - Requests per minute
   - Token usage
   - Response latency
   - Error rates

### Application Insights

Add Application Insights for detailed tracing:

```csharp
builder.Services.AddApplicationInsightsTelemetry();
```

## Cost Optimization

### Tips for Azure OpenAI

1. **Right-size deployments**: Use appropriate TPM (tokens per minute)
2. **Monitor usage**: Check metrics regularly
3. **Use appropriate models**: GPT-3.5-turbo for most cases
4. **Implement caching**: Reduce repeated requests
5. **Batch operations**: Process multiple requests efficiently

## See also

* [Getting Started with Smart Rich Text Editor](getting-started.md)
* [OpenAI Configuration](openai-service.md)
* [AI Features and Customization](ai-features.md)
* [Azure OpenAI Documentation](https://learn.microsoft.com/en-us/azure/ai-services/openai/)