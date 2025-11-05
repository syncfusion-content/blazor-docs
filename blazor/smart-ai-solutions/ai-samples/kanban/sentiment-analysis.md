---
layout: post
title: Sentiment Analysis in Blazor Kanban | Syncfusion
description: Learn how to use Syncfusion Blazor Kanban with AI to analyze the emotional tone of tasks using sentiment analysis.
platform: Blazor
control: AI Integration
documentation: ug
keywords: Blazor Kanban, AI sentiment analysis, Syncfusion Blazor AI
---

# Sentiment Analysis in Blazor Kanban Component

This guide demonstrates how to use the [**Syncfusion.Blazor.AI**](https://www.nuget.org/packages/Syncfusion.Blazor.AI) package to perform sentiment analysis in the Syncfusion Blazor Kanban component. The AI integration enables automatic detection of emotional tone in task descriptions, helping teams prioritize and respond to tasks more effectively. These capabilities are powered by AI models hosted via services like OpenAI, Azure OpenAI, or Ollama.

## Prerequisites

Ensure the following NuGet packages are installed based on your chosen AI service:

### For OpenAI
- **Microsoft.Extensions.AI**
- **Microsoft.Extensions.AI.OpenAI**

### For Azure OpenAI
- **Microsoft.Extensions.AI**
- **Microsoft.Extensions.AI.OpenAI**
- **Azure.AI.OpenAI**

### For Ollama
- **Microsoft.Extensions.AI**
- **OllamaSharp**

{% tabs %}
{% highlight C# tabtitle="Package Manager" %}

Install-Package Syncfusion.Blazor.Kanban -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.Themes -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.AI -Version {{ site.releaseversion }}
Install-Package Microsoft.Extensions.AI
Install-Package Microsoft.Extensions.AI.OpenAI  # For OpenAI or Azure OpenAI
Install-Package Azure.AI.OpenAI  # For Azure OpenAI
Install-Package OllamaSharp  # For Ollama

{% endhighlight %}
{% endtabs %}

## Add Stylesheet and Script Resources

Include the theme stylesheet and script from NuGet via [Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets) in the `<head>` of your main page:

- For **.NET 6** Blazor Server apps, add to **~/Pages/_Layout.cshtml**.
- For **.NET 8 or .NET 9** Blazor Server apps, add to **~/Components/App.razor**.

```html
<head>
    <link href="_content/Syncfusion.Blazor.Themes/tailwind.css" rel="stylesheet" />
</head>
<body>
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
</body>
```

N> Explore the [Blazor Themes](https://blazor.syncfusion.com/documentation/appearance/themes) topic for methods to reference themes ([Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets), [CDN](https://blazor.syncfusion.com/documentation/appearance/themes#cdn-reference), or [CRG](https://blazor.syncfusion.com/documentation/common/custom-resource-generator)). Refer to the [Adding Script Reference](https://blazor.syncfusion.com/documentation/common/adding-script-references) topic for different approaches to adding script references in your Blazor application.

## Configure AI Service

Choose one of the following AI services (OpenAI, Azure OpenAI, or Ollama) based on your requirements:
- **OpenAI**: Best for cloud-based, general-purpose AI models with minimal setup.
- **Azure OpenAI**: Ideal for enterprise-grade deployments with enhanced security and scalability.
- **Ollama**: Suitable for self-hosted, privacy-focused AI models.

Follow the instructions for your selected service to register the AI model in your application.

### OpenAI

Generate an API key from OpenAI and set `openAIApiKey`. Specify the desired model (e.g., `gpt-3.5-turbo`, `gpt-4`) in `openAIModel`.

- Install the required NuGet packages:

{% tabs %}
{% highlight C# tabtitle="Package Manager" %}

Install-Package Microsoft.Extensions.AI
Install-Package Microsoft.Extensions.AI.OpenAI

{% endhighlight %}
{% endtabs %}

- Add the following to the **~/Program.cs** file in your Blazor WebApp:

{% tabs %}
{% highlight C# tabtitle="Blazor WebApp" hl_lines="7 8 9 11 12 13" %}

using Syncfusion.Blazor.AI;
using Microsoft.Extensions.AI;
using OpenAI;

var builder = WebApplication.CreateBuilder(args);

string openAIApiKey = "API-KEY";
string openAIModel = "OPENAI_MODEL";
OpenAIClient openAIClient = new OpenAIClient(openAIApiKey);
IChatClient openAIChatClient = openAIClient.GetChatClient(openAIModel).AsIChatClient();
builder.Services.AddChatClient(openAIChatClient);
builder.Services.AddSingleton<IChatInferenceService, SyncfusionAIService>();

var app = builder.Build();

{% endhighlight %}
{% endtabs %}

### Azure OpenAI

Deploy an Azure OpenAI Service resource and model as described in [Microsoft's documentation](https://learn.microsoft.com/en-us/azure/ai-services/openai/how-to/create-resource). Obtain values for `azureOpenAIKey`, `azureOpenAIEndpoint`, and `azureOpenAIModel`.

- Install the required NuGet packages:

{% tabs %}
{% highlight C# tabtitle="Package Manager" %}

Install-Package Microsoft.Extensions.AI
Install-Package Microsoft.Extensions.AI.OpenAI
Install-Package Azure.AI.OpenAI

{% endhighlight %}
{% endtabs %}

- Add the following to the **~/Program.cs** file in your Blazor WebApp:

{% tabs %}
{% highlight C# tabtitle="Blazor WebApp" hl_lines="7 8 9 11 12 13" %}

using Syncfusion.Blazor.AI;
using Azure.AI.OpenAI;
using Microsoft.Extensions.AI;
using System.ClientModel;

var builder = WebApplication.CreateBuilder(args);

string azureOpenAIKey = "AZURE_OPENAI_KEY";
string azureOpenAIEndpoint = "AZURE_OPENAI_ENDPOINT";
string azureOpenAIModel = "AZURE_OPENAI_MODEL";
AzureOpenAIClient azureOpenAIClient = new AzureOpenAIClient(
     new Uri(azureOpenAIEndpoint),
     new ApiKeyCredential(azureOpenAIKey)
);
IChatClient azureOpenAIChatClient = azureOpenAIClient.GetChatClient(azureOpenAIModel).AsIChatClient();
builder.Services.AddChatClient(azureOpenAIChatClient);
builder.Services.AddSingleton<IChatInferenceService, SyncfusionAIService>();

var app = builder.Build();

{% endhighlight %}
{% endtabs %}

### Ollama

To use Ollama for self-hosted AI models:

1. **Download and install Ollama**: Visit [Ollama's official website](https://ollama.com) and install the application for your operating system.
2. **Install a model**: Choose a model from the [Ollama Library](https://ollama.com/library) (e.g., `llama2:13b`, `mistral:7b`).
3. **Configure the application**: Provide the `Endpoint` URL (e.g., `http://localhost:11434`) and `ModelName` (e.g., `llama2:13b`).

- Install the required NuGet packages:

{% tabs %}
{% highlight C# tabtitle="Package Manager" %}

Install-Package Microsoft.Extensions.AI
Install-Package OllamaSharp

{% endhighlight %}
{% endtabs %}

- Add the following to the **~/Program.cs** file in your Blazor WebApp:

{% tabs %}
{% highlight C# tabtitle="Blazor WebApp" hl_lines="7 8 9 11 12 13" %}

using Syncfusion.Blazor.AI;
using Microsoft.Extensions.AI;
using OllamaSharp;

var builder = WebApplication.CreateBuilder(args);

string ModelName = "MODEL_NAME";
IChatClient chatClient = new OllamaApiClient("http://localhost:11434", ModelName);
builder.Services.AddChatClient(chatClient);
builder.Services.AddSingleton<IChatInferenceService, SyncfusionAIService>();

var app = builder.Build();

{% endhighlight %}
{% endtabs %}

- **Verify connectivity**: Ensure the Ollama server is running and accessible at the specified endpoint (e.g., `http://localhost:11434`) before starting the application.

## Register Syncfusion Blazor Service

Add the Syncfusion Blazor service to your **~/Program.cs** file. The configuration depends on your app's **Interactive Render Mode**:

- **Server Mode**: Register the service in the single **~/Program.cs** file.
- **WebAssembly or Auto Mode**: Register the service in both the server-side **~/Program.cs** and client-side **~/Program.cs** files.

{% tabs %}
{% highlight C# tabtitle="Server (~/_Program.cs)" hl_lines="3 11" %}

using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();
builder.Services.AddSyncfusionBlazor();

var app = builder.Build();

{% endhighlight %}
{% highlight C# tabtitle="Client (~/_Program.cs)" hl_lines="2 5" %}

using Syncfusion.Blazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddSyncfusionBlazor();

await builder.Build().RunAsync();

{% endhighlight %}
{% endtabs %}

## Razor Component

This section demonstrates how to implement sentiment analysis in the Syncfusion Blazor Kanban component using AI. The AI Assistant evaluates the emotional tone of each task description and displays a corresponding emoji (😊, 😐, 😞) to help teams quickly assess the mood or urgency of tasks. This can be especially useful in agile workflows where emotional context can influence task priority and team communication.

(`Home.razor`)

```razor
@using Syncfusion.Blazor.Kanban
@using Syncfusion.Blazor.SplitButtons
@using Syncfusion.Blazor.Calendars
@using Syncfusion.Blazor.Inputs
@using Syncfusion.Blazor.DropDowns
@using AISamples.Components.Models
@using AISamples.Components.Service
@inject AzureAIService OpenAIService

<div id="ai-button" style="margin: 10px">
    <SfProgressButton Content="@Content" OnClick="@GetScore" EnableProgress="false">
        <ProgressButtonEvents OnBegin="Begin" OnEnd="End"></ProgressButtonEvents>
    </SfProgressButton>
</div>
<div class="col-lg-12 control-section">
    <div class="kanban">
        <SfKanban KeyField="Category" DataSource="@Pizza">
            <KanbanColumns>
                @foreach (ColumnModel item in columnData)
                {
                    <KanbanColumn HeaderText="@item.HeaderText" KeyField="@item.KeyField" />
                }
            </KanbanColumns>
            <KanbanCardSettings HeaderField="Id" ContentField="Description">
                <Template>
                    @{
                        PizzaDataModel card = (PizzaDataModel)context;
                        <div class="card-template">
                            <div class="card-template-wrap">
                                <table class="card-template-wrap table-fixed-layout">
                                    <colgroup>
                                        <col style="width:35px">
                                    </colgroup>
                                    <tbody>
                                        <tr>
                                            <td class="e-image">
                                                <img src=@card.ImageURL alt="logo" />
                                            </td>
                                            <td class="e-title">
                                                <div class="e-card-stacked">
                                                    <div class="e-card-header">
                                                        <div class="e-card-header-caption">
                                                            <div class="e-card-header-title e-tooltip-text">@card.Title</div>
                                                        </div>
                                                    </div>
                                                    <div class="e-card-content" style="line-height:2.75em">
                                                        <table class="card-template-wrap">
                                                            <tbody>
                                                                <tr class="e-tooltip-text">
                                                                    @if (card.Category == "Menu" || card.Category == "Order" || card.Category == "Ready to Serve")
                                                                    {
                                                                        <td colspan="2">
                                                                            <div class="e-description">@(card.Category == "Menu" ? card.Description : card.OrderID)</div>
                                                                        </td>
                                                                    }
                                                                    else
                                                                    {
                                                                        <td colspan="2">
                                                                            <table>
                                                                                <tr>
                                                                                    <td colspan="2"><div class="e-description">@card.OrderID</div></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <label class="e-date">Deliver:</label>
                                                                                        <span class="e-display">@card.Date?.ToString("MM/dd/yyyy")</span>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    }
                                                                </tr>
                                                                <tr>
                                                                    @if (card.Category != "Menu")
                                                                    {
                                                                        if (card.Category == "Order")
                                                                        {
                                                                            <td><div class="e-preparingText e-tooltip-text">Preparing</div></td>
                                                                            <td class="e-prepare">
                                                                                <div class="e-time e-tooltip-text">
                                                                                    <div class="e-icons e-clock"></div>
                                                                                    <div class="e-mins">15 mins</div>
                                                                                </div>
                                                                            </td>
                                                                        }
                                                                        if (card.Category == "Ready to Serve")
                                                                        {
                                                                            <td><div class="e-readyText e-tooltip-text">Ready to Serve</div></td>
                                                                            <td class="e-prepare">
                                                                                <div class="e-time e-tooltip-text">
                                                                                    <div class="e-icons e-clock"></div>
                                                                                    <div class="e-mins">5 mins</div>
                                                                                </div>
                                                                            </td>
                                                                        }
                                                                        if (card.Category == "Delivered" || card.Category == "Served")
                                                                        {
                                                                            <td><div class="e-deliveredText e-tooltip-text">Delivered</div></td>
                                                                            if (ShowScore)
                                                                            {
                                                                                <td class="e-prepare">
                                                                                    <div class="e-time e-tooltip-text">
                                                                                        <div class="e-icons e-clock"></div>
                                                                                        <div class="e-rating">@card.Emoji</div>
                                                                                    </div>
                                                                                </td>
                                                                            }
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        <td><div class="e-size e-tooltip-text">@card.Size</div></td>
                                                                        <td><div class="e-price e-tooltip-text">@card.Price</div></td>
                                                                    }
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </div>
                                                </div>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    }
                </Template>
            </KanbanCardSettings>
            <KanbanDialogSettings>
                <Template>
                    @{
                        PizzaDataModel data = (PizzaDataModel)context;
                        <table>
                            <tbody>
                                <tr>
                                    <td class="e-label">ID</td>
                                    <td>
                                        <SfTextBox CssClass="e-field" Value="@data.Id" Enabled="false"></SfTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="e-label">Category</td>
                                    <td>
                                        <SfDropDownList @ref="CategoryRef" TValue="string" TItem="DropDownModel" CssClass="e-field" DataSource="@CategoryData" @bind-Value="@data.Category">
                                            <DropDownListFieldSettings Text="Value" Value="Value"></DropDownListFieldSettings>
                                        </SfDropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="e-label">Title</td>
                                    <td>
                                        <SfTextBox CssClass="e-field" @bind-Value="@data.Title"></SfTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="e-label">Size</td>
                                    <td>
                                        <SfTextBox CssClass="e-field" @bind-Value="@data.Size"></SfTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="e-label">Description</td>
                                    <td>
                                        <SfTextBox @ref="DescriptionRef" CssClass="e-field" Multiline="true" @bind-Value="@data.Description"></SfTextBox>
                                    </td>
                                </tr>
                                <tr id="DateRow">
                                    <td class="e-label">Deliver</td>
                                    <td>
                                        <SfDatePicker TValue="DateTime?" @bind-Value='@data.Date' Format="MM/dd/yyyy" ID="Date"></SfDatePicker>
                                    </td>
                                </tr>
                                @if (data.Category == "Delivered")
                                {
                                    <tr>
                                        <td class="e-label">Feedback</td>
                                        <td>
                                            <SfTextBox CssClass="e-field" @bind-Value="@data.Feedback" Multiline="true"></SfTextBox>
                                        </td>
                                    </tr>
                                }
                            </tbody>
                        </table>
                    }
                </Template>
            </KanbanDialogSettings>
        </SfKanban>
    </div>
</div>

```

`Home.razor.cs`

```csharp

using System.Text.Json;
using AISamples.Components.Models;
using Syncfusion.Blazor.DropDowns;
using Syncfusion.Blazor.Inputs;
using Syncfusion.Blazor.Kanban;

namespace AISamples.Components.Pages
{
    public partial class Home
    {
        SfDropDownList<string, DropDownModel> CategoryRef;
        SfTextBox DescriptionRef;
        private string SelectedAPI = "Open AI";
        private bool ShowScore = false;
        private bool IsSpinner = false;
        private List<PizzaDataModel> Pizza = new PizzaDataModel().GetPizzaData();
        public string Content = "Check Customer Sentiments";
        private async Task GetScore()
        {
            this.IsSpinner = true;
            string result = "";
            string json = JsonSerializer.Serialize(Pizza, new JsonSerializerOptions { WriteIndented = true });
            var description = "Provide a SentimentScore out of 5 (whole numbers only) based on the Feedback. If the feedback is null, do not give a SentimentScore. Use the dataset provided below to make recommendations. NOTE: Return the data in JSON format with all fields included, and return only JSON data, no explanatory text." + json;
            result = await OpenAIService.GetCompletionAsync(description);
            string data = result.Replace("```json", "").Replace("```", "").Replace("\r", "").Replace("\n", "").Replace("\t", "").Trim();
            this.Pizza = JsonSerializer.Deserialize<List<PizzaDataModel>>(data);
            this.IsSpinner = false;
            foreach(var item in Pizza)
            {
                if(item.SentimentScore > 0 && item.SentimentScore <= 2)
                {
                    item.Emoji = "😢";
                }
                else if (item.SentimentScore > 3 && item.SentimentScore <= 5)
                {
                    item.Emoji = "😀";
                }
                else if (item.SentimentScore == 3)
                {
                    item.Emoji = "😐";
                }
            }
            this.ShowScore = true;
            StateHasChanged();
        }
        private List<DropDownModel> CategoryData = new List<DropDownModel>()
        {
            new DropDownModel { Id = 0, Value = "Menu" },
            new DropDownModel { Id = 1, Value = "Order" },
            new DropDownModel { Id = 2, Value = "Ready to Serve" },
            new DropDownModel { Id = 3, Value = "Delivered"},
            new DropDownModel { Id = 3, Value = "Served"},
        };
        private class DropDownModel
        {
            public int Id { get; set; }
            public string Value { get; set; }
        }
        private List<ColumnModel> columnData = new List<ColumnModel>() {
            new ColumnModel(){ HeaderText= "Menu", KeyField= new List<string>() { "Menu" } },
            new ColumnModel(){ HeaderText= "Order", KeyField= new List<string>() { "Order" } },
            new ColumnModel(){ HeaderText= "Ready to Serve", KeyField= new List<string>() { "Ready to Serve"} },
            new ColumnModel(){ HeaderText= "Delivered", KeyField=new List<string>() {  "Delivered", "Served" } }
        };
        public void Begin(Syncfusion.Blazor.SplitButtons.ProgressEventArgs args)
        {
            Content = "Analyzing...";
        }
        public async Task End(Syncfusion.Blazor.SplitButtons.ProgressEventArgs args)
        {
            while (this.IsSpinner)
            {
                await Task.Delay(1000);
            }
            Content = "Check Cusotomer Sentiments";
        }
    }
}
```

## Error Handling and Troubleshooting

If the AI service fails to return a valid response, the Kanban will display an error message ("Oops! Please try again!"). Common issues include:

- **Invalid API Key or Endpoint**: Verify that the `openAIApiKey`, `azureOpenAIKey`, or Ollama `Endpoint` is correct and the service is accessible.
- **Model Unavailable**: Ensure the specified `openAIModel`, `azureOpenAIModel`, or `ModelName` is deployed and supported.
- **Network Issues**: Check connectivity to the AI service endpoint, especially for self-hosted Ollama instances.
- **Large Prompts**: Processing large text inputs may cause timeouts. Consider reducing the prompt size or optimizing the request for efficiency.

## Performance Considerations

When handling large text content, ensure the Ollama server has sufficient resources (CPU/GPU) to process requests efficiently. For long-form content or batch operations, consider splitting the input into smaller segments to avoid performance bottlenecks. Test the application with your specific use case to determine optimal performance.

## Sample Code

A complete working example is available in the [Syncfusion Blazor AI Samples GitHub repository](https://github.com/syncfusion/smart-ai-samples).

![Kanban AI Assistant - Output](../../ai/images/sentiment-analysis.gif)