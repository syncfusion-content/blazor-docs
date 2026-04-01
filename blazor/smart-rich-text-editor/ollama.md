---
layout: post
title: Ollama Configuration for Blazor Smart Rich Text Editor | Syncfusion
description: Step-by-step guide to configure Ollama for the Syncfusion Blazor Smart Rich Text Editor, covering installation, client setup, and usage examples for local AI.
platform: Blazor
control: Smart Rich Text Editor
documentation: ug
---

# Ollama Configuration

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Smart Rich Text Editor supports Ollama for running open-source models locally. This is ideal for privacy-conscious applications and development environments.

## What is Ollama?

Ollama is a lightweight, open-source framework for running large language models locally on your machine. It provides:

- **Privacy**: All processing happens locally
- **No API costs**: No cloud service fees
- **Offline capability**: Works without internet connection
- **Model variety**: Access to many open-source models
- **Easy setup**: Simple installation and management

## Prerequisites

* Windows 10/11, macOS, or Linux
* At least 8GB RAM (16GB+ recommended)
* GPU support optional but recommended for performance
* Docker (optional, for containerized deployment)

## Installation

### Step 1: Download and Install Ollama

Visit [Ollama's Official Website](https://ollama.com) and download the installer for your operating system.

#### Windows

1. Download the Windows installer
2. Run the installer and follow the setup wizard
3. Accept default installation path or customize
4. Complete installation

#### macOS

1. Download the macOS installer
2. Open the `.dmg file`
3. Drag Ollama to Applications folder
4. Launch from Applications

#### Linux

Use the installation script:

```bash
curl https://ollama.ai/install.sh | sh
```

### Step 2: Verify Installation

Open a terminal/command prompt and verify:

```bash
ollama --version
```

### Step 3: Start Ollama Service

#### Windows

Ollama starts automatically. Access at `http://localhost:11434`

#### macOS/Linux

Start the Ollama service:

```bash
ollama serve
```

## Installing Models

### Available Models

Browse available models at [Ollama Library](https://ollama.com/library)

Popular models for text generation:

- **Mistral**: `mistral` - Fast, efficient
- **Llama 2**: `llama2` - General purpose
- **Neural Chat**: `neural-chat` - Conversational
- **Orca Mini**: `orca-mini` - Lightweight
- **Dolphin**: `dolphin-mixtral` - Advanced

### Install a Model

```bash
ollama pull mistral
```

This downloads and prepares the model (may take several minutes).

### List Installed Models

```bash
ollama list
```

### Run a Model Directly

Test the model:

```bash
ollama run mistral
```

Type your prompt and press Enter. Type `/bye` to exit.

## Configuration in Blazor

> **Note**: OllamaSharp is a community package for local model integration. Ensure compliance with your organization's policy on third-party NuGet packages before using in production.

### Installation

Install required NuGet packages:

{% tabs %}
{% highlight c# tabtitle="Package Manager" %}

Install-Package Syncfusion.Blazor.SmartRichTextEditor
Install-Package Syncfusion.Blazor.Themes
Install-Package Microsoft.Extensions.AI
Install-Package OllamaSharp

{% endhighlight %}
{% endtabs %}

### Setup in Program.cs

```csharp
using Syncfusion.Blazor;
using Syncfusion.Blazor.AI;
using Microsoft.Extensions.AI;
using OllamaSharp;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSyncfusionBlazor();

// Configure Ollama
string ollamaEndpoint = "http://localhost:11434";
string modelName = "mistral"; // or any other installed model

// Create Ollama client
IOllamaApiClient ollamaClient = new OllamaApiClient(ollamaEndpoint, modelName);

// Convert to IChatClient
IChatClient chatClient = ollamaClient;

builder.Services.AddChatClient(chatClient);

// Register Smart Rich Text Editor Components with Azure OpenAI
builder.Services.AddSingleton<IChatInferenceService, SyncfusionAIService>();

var app = builder.Build();

// ... rest of setup
```

### Add to _Imports.razor

```razor
@using Syncfusion.Blazor
@using Syncfusion.Blazor.SmartRichTextEditor
```

### Use Ollama AI with Smart Rich Text Editor Component

```razor
@page "/editor"
@using Syncfusion.Blazor.SmartRichTextEditor

<SfSmartRichTextEditor>
    <AssistViewSettings Placeholder="Edit with local AI assistance..."/>
    <div>
        <h3>Ollama + Smart Rich Text Editor</h3>
        <p>Use AI Commands to improve selected text or change tone.</p>
        <ul>
            <li>Select text and request suggestions</li>
            <li>Press Alt+Enter for AI Query</li>
        </ul>
    </div>
</SfSmartRichTextEditor>
```

## Configuration Options

### Custom Endpoint

If Ollama runs on different host/port:

```csharp
string ollamaEndpoint = "http://192.168.1.100:11434";
IOllamaApiClient ollamaClient = new OllamaApiClient(ollamaEndpoint, "mistral");
```

### Model Parameters

Configure model behavior:

```csharp
// Create client with parameters
IOllamaApiClient ollamaClient = new OllamaApiClient("http://localhost:11434", "mistral");

// Set parameters (varies by OllamaSharp version)
var request = new GenerateRequest
{
    Model = "mistral",
    Prompt = "Your prompt",
    Temperature = 0.7f,
    TopK = 40,
    TopP = 0.9f,
};
```

### Dynamic Model Selection

```csharp
// Read model name from configuration
string modelName = builder.Configuration["Ollama:ModelName"] ?? "mistral";
string endpoint = builder.Configuration["Ollama:Endpoint"] ?? "http://localhost:11434";

IOllamaApiClient ollamaClient = new OllamaApiClient(endpoint, modelName);
```

## Docker Deployment

### Docker Compose Setup

```yaml
version: '3.8'
services:
  ollama:
    image: ollama/ollama:latest
    ports:
      - "11434:11434"
    volumes:
      - ollama_data:/root/.ollama
    environment:
      - OLLAMA_HOST=0.0.0.0:11434

volumes:
  ollama_data:
```

### Start with Docker

```bash
docker-compose up -d
```

### Pull Models in Container

```bash
docker exec -it <container-id> ollama pull mistral
```

## Advanced Configuration

### Multiple Models

Run different models for different purposes:

```csharp
// For general editing
var generalClient = new OllamaApiClient("http://localhost:11434", "mistral");

// For code-related tasks
var codeClient = new OllamaApiClient("http://localhost:11434", "neural-chat");

// Conditionally use based on context
IChatClient chatClient = useForCode ? codeClient : generalClient;
```

## Performance Optimization

### Tips for Better Performance

1. **Use GPU Acceleration**
   - NVIDIA GPUs: Install CUDA toolkit
   - AMD GPUs: Install ROCm
   - Intel GPUs: Install Intel oneAPI

2. **Increase Memory Allocation**
   ```bash
   # Linux/macOS
   export OLLAMA_NUM_PARALLEL=1
   ollama serve
   ```

3. **Choose Efficient Models**
   - Mistral is fastest
   - `Orca-mini` for lightweight deployment
   - `Dolphin-mixtral` for best quality

4. **Implement Caching**
   - Cache common prompts
   - Reuse model responses

5. **Optimize Request Size**
   - Keep prompts concise
   - Limit response length with max tokens

## Troubleshooting

### Connection Issues

**Error: Unable to connect to Ollama**

1. Verify Ollama is running:
   ```bash
   curl http://localhost:11434/api/tags
   ```

2. Check endpoint configuration in Program.cs

3. If running on different machine, update endpoint URL

### Model Issues

**Model not found**
```bash
# List available models
ollama list

# Pull the model
ollama pull mistral
```

**Out of memory errors**
- Use smaller models (`orca-mini`, `mistral`)
- Close other applications
- Restart Ollama service

### Performance Issues

**Slow response times**
- Check CPU/GPU usage
- Enable GPU acceleration if available
- Use faster models
- Increase system RAM

## Model Recommendations

| Use Case | Model | Pros | Cons |
|----------|-------|------|------|
| General editing | Mistral | Fast, good quality | Less context |
| Content creation | Llama 2 | Balanced | Larger model |
| Code assistance | Neural-chat | Good reasoning | Slower |
| Lightweight | Orca-mini | Very fast | Limited capability |
| Best quality | Dolphin-mixtral | Excellent | Resource heavy |

## Security Considerations

### Local Processing Benefits

- All data stays on your machine
- No external API calls
- Compliance with data regulations
- Full control over data retention

### Best Practices

1. Restrict network access to Ollama
2. Use firewall rules if networked
3. Keep Ollama updated
4. Monitor resource usage

## See also

* [Getting Started with Smart Rich Text Editor](getting-started.md)
* [OpenAI Configuration](openai-service.md)
* [Azure OpenAI Configuration](azure-openai-service.md)
* [AI Features and Customization](ai-features.md)
* [Ollama Official Documentation](https://ollama.ai/docs)