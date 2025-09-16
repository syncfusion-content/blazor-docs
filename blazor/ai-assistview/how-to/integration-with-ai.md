---
layout: post
title: Integration | Blazor AI AssistView component | Syncfusion
description: Checkout and learn about Integration with Microsoft.Extensions.AI and Keyboard interaction with Blazor AI AssistView component and more details.
platform: Blazor
control: AI AssistView
documentation: ug
---

# Integration of Microsoft.Extensions.AI with AI AssistView component

The Syncfusion<sup style="font-size:70%">&reg;</sup> AI AssistView component supports integration with the `Microsoft.Extensions.AI` framework, enabling seamless communication with various large language models (LLMs) such as `Azure OpenAI`, `OpenAI`, and more.

`The Microsoft.Extensions.AI` simplifies integration with different models, requiring minimal configuration changes depending on the provider. The following example demonstrates integration using `Azure OpenAI`.

N> The Microsoft AI extension libraries are currently in preview, and breaking changes may occur. Ensure that you use compatible versions to avoid integration issues.

### Getting started with AI AssistView

Before integrating `AI AssistView` with `Microsoft.Extensions.AI`, ensure the SfAIAssistView component is rendered by following the appropriate project guideline:

* [Blazor Web App](../getting-started-webapp)
* [Blazor WASM App](../getting-started)

### Prerequisites for Microsoft.Extensions.AI integration

To add the required NuGet packages, use the NuGet package manager in Visual Studio (*Tools → NuGet Package Manager → Manage NuGet Packages for Solution*) search and install the following:

* `Azure.AI.OpenAI`
* `Azure.Identity`
* `Microsoft.Extensions.AI`
* `Microsoft.Extensions.AI.OpenAI`
* `Markdig`

Alternatively, run the following commands in your terminal:

{% tabs %}
{% highlight C# tabtitle="Package Manager" %}

dotnet add package Azure.AI.OpenAI
dotnet add package Azure.Identity
dotnet add package Microsoft.Extensions.AI
dotnet add package Microsoft.Extensions.AI.OpenAI
dotnet add package Markdig

{% endhighlight %}
{% endtabs %}

### Configure services in Program.cs

Register the `Azure OpenAI` client and Syncfusion<sup style="font-size:70%">&reg;</sup> AI AssistView component within the Blazor application.

{% tabs %}
{% highlight c# tabtitle="~/_Program.cs" hl_lines="2 9" %}

using Syncfusion.Blazor;
using Microsoft.Extensions.AI;
using Azure.AI.OpenAI;
using Azure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Set Azure OpenAI configuration
var endpoint = "https://azure-testresource.openai.azure.com";
var apiKey = "YOUR_API_KEY"; // Replace with your actual key;
var deploymentName = "gpt-4o-mini";

var credential = new AzureKeyCredential(apiKey);

// Register Azure OpenAI chat client
builder.Services.AddChatClient(
    new AzureOpenAIClient(new Uri(endpoint), credential)
        .GetChatClient(deploymentName)
        .AsIChatClient()
);

// Register Syncfusion Blazor components
builder.Services.AddSyncfusionBlazor();

var app = builder.Build();

{% endhighlight %}
{% endtabs %}

### AI AssistView with IChatClient

The Syncfusion<sup style="font-size:70%">&reg;</sup> `AI AssistView` component is built to seamlessly integrate with external AI services. When the `IChatClient` is registered via `Microsoft.Extensions.AI`, the component automatically uses it to handle user prompts without any additional configuration.

In the following example, the user input is processed using the injected `IChatClient`. The AI model's response is returned in Markdown format which is converted to HTML using the `Markdig` library before rendering in the AI AssistView component.

{% tabs %}
{% highlight razor %}

@rendermode InteractiveServer

@using Syncfusion.Blazor.InteractiveChat
@using Microsoft.Extensions.AI
@using Markdig;
@using System.Text.RegularExpressions;
@inject IChatClient ChatClient

<div style="height: 350px; width: 650px;">
    <SfAIAssistView PromptRequested="@OnPromptRequested"></SfAIAssistView>
</div>

@code {
    
    private async Task OnPromptRequested(AssistViewPromptRequestedEventArgs args)
    {
        // Send the user’s prompt to the AI model
        var chatResponse = await ChatClient.GetResponseAsync(args.Prompt, new ChatOptions());
        // Convert markdown to HTML
        var htmlContent = Markdown.ToHtml(chatResponse.Text);
        // Clean up extra whitespace
        htmlContent = Regex.Replace(htmlContent, @"\s+", " ").Trim();
        // Set the cleaned HTML as the response
        args.Response = htmlContent;
    }
}

{% endhighlight %}
{% endtabs %}

![AI AssistView with IChatClient](../images/ai-assistview-ichatclient.png)