---
layout: post
title: Custom AI Service Integration with Smart Components
description: Learn how to use IInferenceBackend to integrate custom AI services with Syncfusion Smart Components
platform: Blazor
control: Smart Paste Button
documentation: ug
---

# Custom AI Service Integration

## Overview

Syncfusion Smart Components provide built-in support for OpenAI and Azure OpenAI services. However, you can also integrate other AI services using the `IInferenceBackend` interface, which acts as a bridge between Smart Components and your custom AI service.


## IInferenceBackend Interface

The `IInferenceBackend` interface defines a simple contract for AI service integration:

```csharp
public interface IInferenceBackend
{
    Task<string> GetChatResponseAsync(ChatParameters options);
}
```

This interface enables:
- Consistent communication between components and AI services
- Easy switching between different AI providers


## Implemented AI Services

Here are examples of AI services integrated using the `IInferenceBackend` interface:

| Service | Description | Documentation |
|---------|-------------|---------------|
| Claude | Anthropic's Claude AI | [Claude Integration](claude-service.md) |
| DeepSeek | DeepSeek's AI platform | [DeepSeek Integration](deepseek-service.md) |
| Groq | Groq inference engine | [Groq Integration](groq-service.md) |
| Gemini | Google's Gemini AI | [Gemini Integration](gemini-service.md) |


## Service Registration

Register your custom implementation in `Program.cs`:

```csharp
builder.Services.AddSingleton<IInferenceBackend, YourCustomService>();
```

