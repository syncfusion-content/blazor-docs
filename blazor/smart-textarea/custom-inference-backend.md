---
layout: post
title: Custom AI Service Integration with Syncfusion Smart Components
description: Learn how to use IChatInferenceService to integrate custom AI services with Syncfusion Smart Components
platform: Blazor
control: Smart TextArea
documentation: ug
---

# Custom AI Service Integration

## Overview

Syncfusion Smart Components provide built-in support for OpenAI and Azure OpenAI services. However, you can also integrate other AI services using the `IChatInferenceService` interface, which acts as a bridge between Smart Components and your custom AI service.


## IChatInferenceService Interface

The `IChatInferenceService` interface defines a simple contract for AI service integration:

```csharp
public interface IChatInferenceService
{
    Task<string> GenerateResponseAsync(ChatParameters options);
}
```

This interface enables:
- Consistent communication between components and AI services
- Easy switching between different AI providers


## Implemented AI Services

Here are examples of AI services integrated using the `IChatInferenceService` interface:

| Service | Documentation |
|---------|---------------|
| Claude | [Claude Integration](claude-service) |
| DeepSeek | [DeepSeek Integration](deepseek-service) |
| Groq | [Groq Integration](groq-service) |
| Gemini | [Gemini Integration](gemini-service) |


## Service Registration

Register your custom implementation in `Program.cs`:

```csharp
using Syncfusion.Blazor.AI;
builder.Services.AddSingleton<IChatInferenceService, YourCustomService>();
```

