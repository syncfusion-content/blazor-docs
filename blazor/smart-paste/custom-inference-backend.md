---
layout: post
title: Custom AI Service Integration with Syncfusion Smart Paste
description: Learn how to integrate custom AI services with the Syncfusion Blazor Smart Paste Button using the IChatInferenceService interface for AI-driven form filling.
platform: Blazor
control: Smart Paste Button
documentation: ug
---

# Custom AI Service Integration with Blazor Smart Paste Button

The Syncfusion Blazor Smart Paste Button leverages AI to parse clipboard content and populate form fields, enhancing user productivity. By default, it supports OpenAI and Azure OpenAI services, but you can integrate custom AI services using the `IChatInferenceService` interface. This interface facilitates communication between the Smart Paste Button and your custom AI provider, enabling precise mapping of clipboard data to form fields.

## IChatInferenceService Interface

The `IChatInferenceService` interface defines a contract for integrating AI services with the Smart Paste Button, enabling the component to process clipboard data for form field mapping.

```csharp
public interface IChatInferenceService
{
    Task<string> GenerateResponseAsync(ChatParameters options);
}
```

The `GenerateResponseAsync` method takes `ChatParameters` (containing clipboard data and form field metadata) and returns a string response from the AI service, which the Smart Paste Button uses to populate form fields.

## Simple Implementation of a Custom AI Service

Below is a sample implementation of a mock AI service named `MockAIService`. This service demonstrates how to implement the `IChatInferenceService` interface by returning sample, context-aware responses. You can replace the logic with your own AI integration.

```csharp
using Syncfusion.Blazor.AI;
using System.Threading.Tasks;

public class MockAIService : IChatInferenceService
{
    public Task<string> GenerateResponseAsync(ChatParameters options)
    {

    }
}
```

## Registering the Custom AI Service

Register the custom AI service in the **~/Program.cs** file of your Blazor Web App:

```csharp
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Syncfusion.Blazor;
using Syncfusion.Blazor.AI;
using Syncfusion.Blazor.SmartComponents;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSyncfusionBlazor();
builder.Services.AddSyncfusionSmartComponents();
builder.Services.AddSingleton<IChatInferenceService, MockAIService>();

var app = builder.Build();
// ...
```

## Testing the Custom AI Integration

1. Configure the Blazor Web App Server with the Smart Paste Button and custom AI service as described above.
2. Add the code to **~/Pages/Home.razor** and ensure **Program.cs** includes the service registrations.
3. Run the application using <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS).
4. Copy the sample content provided in the Razor file.
5. Click the **Smart Paste** button to verify that the form fields are populated correctly using the custom AI service.

![Syncfusion Blazor Smart Paste Button with Custom AI](images/smart-paste.gif)

## Implemented AI Services

Here are examples of AI services integrated using the `IChatInferenceService` interface:

| Service | Documentation |
|---------|---------------|
| Claude | [Claude Integration](claude-service) |
| DeepSeek | [DeepSeek Integration](deepseek-service) |
| Groq | [Groq Integration](groq-service) |
| Gemini | [Gemini Integration](gemini-service) |

## Troubleshooting

If the custom AI integration does not work as expected, try the following:
- **Fields Not Populating**: Verify that the custom AI service’s endpoint, model, and API key are correct in `appsettings.json`. Ensure the `GenerateResponseAsync` method returns valid data.
- **Service Registration Errors**: Confirm that `CustomAIService` and `CustomInferenceService` are registered in **Program.cs** after `AddSyncfusionBlazor`.
- **AI Parsing Errors**: Check the AI service’s response format and ensure it matches the expected `CustomAIResponse` structure. Test the API independently to verify connectivity.

## See Also

- [Getting Started with Syncfusion Blazor Smart Paste Button in Blazor Web App](https://blazor.syncfusion.com/documentation/smart-paste/getting-started-webapp)
- [Syncfusion Blazor DataForm Documentation](https://blazor.syncfusion.com/documentation/data-form/getting-started-with-web-app)
