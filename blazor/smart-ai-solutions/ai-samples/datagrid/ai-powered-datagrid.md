---
layout: post
title: Generate AI insights with Blazor DataGrid and AI models | Syncfusion
description: Learn how to use Syncfusion Blazor DataGrid with Azure OpenAI or Ollama to analyze sales orders, generate AI insights, and highlight flagged records.
platform: Blazor
control: AI Integration
documentation: ug
keywords: Blazor DataGrid, AI insights, sales order analysis, Syncfusion Blazor AI
---

# Generate AI insights with Blazor DataGrid and AI models

This guide demonstrates how to use the [Syncfusion.Blazor.AI](https://www.nuget.org/packages/Syncfusion.Blazor.AI) package to analyze sales order data and generate AI-powered business insights in the **[Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid)** component. The [Syncfusion.Blazor.AI](https://www.nuget.org/packages/Syncfusion.Blazor.AI) package enables seamless integration with AI models to process and summarize data, while Azure OpenAI or Ollama can be used to generate structured, JSON‑based insights such as an executive summary, key trends, recommendations, and flagged order IDs. In the following example, the application analyzes sales orders, highlights flagged records, and presents actionable business insights.

If you have not created a Blazor application yet, refer to the [Blazor getting started guide](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-visual-studio) to create a project.

## Prerequisites

Install the required Syncfusion and AI service NuGet packages based on the selected AI service.

### For Azure OpenAI

- [Microsoft.Extensions.AI](https://www.nuget.org/packages/Microsoft.Extensions.AI)
- [Microsoft.Extensions.AI.OpenAI](https://www.nuget.org/packages/Microsoft.Extensions.AI.OpenAI)
- [Azure.AI.OpenAI](https://www.nuget.org/packages/Azure.AI.OpenAI)

{% tabs %}
{% highlight C# tabtitle="Package Manager" %}

Install-Package Microsoft.Extensions.AI
Install-Package Microsoft.Extensions.AI.OpenAI
Install-Package Azure.AI.OpenAI

{% endhighlight %}
{% endtabs %}

### For Ollama

- [Microsoft.Extensions.AI](https://www.nuget.org/packages/Microsoft.Extensions.AI)
- [OllamaSharp](https://www.nuget.org/packages/OllamaSharp)

{% tabs %}
{% highlight C# tabtitle="Package Manager" %}

Install-Package Microsoft.Extensions.AI
Install-Package OllamaSharp

{% endhighlight %}
{% endtabs %}

### Syncfusion packages

- [Syncfusion.Blazor.Grid](https://www.nuget.org/packages/Syncfusion.Blazor.Grid)
- [Syncfusion.Blazor.Buttons](https://www.nuget.org/packages/Syncfusion.Blazor.Buttons)
- [Syncfusion.Blazor.Spinner](https://www.nuget.org/packages/Syncfusion.Blazor.Spinner)
- [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes)
- [Syncfusion.Blazor.AI](https://www.nuget.org/packages/Syncfusion.Blazor.AI)

{% tabs %}
{% highlight C# tabtitle="Package Manager" %}

Install-Package Syncfusion.Blazor.Grid -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.Buttons -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.Spinner -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.Themes -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.AI -Version {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

## Add stylesheet and script resources

Include the Blazor theme stylesheet and required scripts using NuGet through [Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets).

Add the stylesheet and script references to **~/Components/App.razor** for Blazor Web Apps using the Interactive Server render mode.

{% tabs %}
{% highlight html tabtitle="App.razor" %}

<head>
    ....
    <!-- Blazor theme stylesheet -->
    <link href="_content/Syncfusion.Blazor.Themes/fluent2.css" rel="stylesheet" />
</head>

<body>
    ....
    <!-- Blazor core script (required for most components, including DataGrid) -->
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
</body>

{% endhighlight %}
{% endtabs %}

N> Explore the [Blazor Themes](https://blazor.syncfusion.com/documentation/appearance/themes) topic for methods to reference themes ([Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets), [CDN](https://blazor.syncfusion.com/documentation/appearance/themes#cdn-reference), or [CRG](https://blazor.syncfusion.com/documentation/common/custom-resource-generator)). Refer to the [Adding Script Reference](https://blazor.syncfusion.com/documentation/common/adding-script-references) topic for different approaches to adding script references in your Blazor application.

## Configure AI service

Choose one of the following AI services based on your requirements:
- **Azure OpenAI**: Enterprise-grade deployment with enhanced security and scalability.
- **Ollama**: Self-hosted, privacy-focused AI models.

Follow the instructions for the selected service to register the AI model in the application.

### Azure OpenAI

Deploy an Azure OpenAI Service resource and model as described in [Microsoft's documentation](https://learn.microsoft.com/en-us/azure/ai-services/openai/how-to/create-resource). Obtain values for `azureOpenAIKey`, `azureOpenAIEndpoint`, and `azureOpenAIModel`.

Add the following to the **~/Program.cs** file in the Blazor Web App.

{% tabs %}
{% highlight C# tabtitle="Program.cs" hl_lines="8 9 10 11 12 13 14" %}

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
2. **Install a model**: Choose a model from the [Ollama Library](https://ollama.com/library) (for example, `llama2:13b`, `mistral:7b`).
3. **Configure the application**: Provide the `Endpoint` URL (for example, `http://localhost:11434`) and `modelName` (for example, `llama2:13b`).

Add the following to the **~/Program.cs** file in the Blazor Web App.

{% tabs %}
{% highlight C# tabtitle="Program.cs" hl_lines="7 8 9 10" %}

using Syncfusion.Blazor.AI;
using Microsoft.Extensions.AI;
using OllamaSharp;

var builder = WebApplication.CreateBuilder(args);

string modelName = "MODEL_NAME";
IChatClient chatClient = new OllamaApiClient("http://localhost:11434", modelName);
builder.Services.AddChatClient(chatClient);
builder.Services.AddSingleton<IChatInferenceService, SyncfusionAIService>();

var app = builder.Build();

{% endhighlight %}
{% endtabs %}

N> Ensure the Ollama server is running and accessible at the specified endpoint (for example, `http://localhost:11434`) before starting the application.

## Register Blazor service

Add the Blazor service to the **~/Program.cs** file. The configuration depends on the app's **Interactive Render Mode**:

- **Server mode**: Register the service in the single **~/Program.cs** file.
- **WebAssembly or Auto mode**: Register the service in both the server-side **~/Program.cs** and client-side **~/Program.cs** files.

{% tabs %}
{% highlight C# tabtitle="Server (~/_Program.cs)" hl_lines="1 8" %}

using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();
builder.Services.AddSyncfusionBlazor();

var app = builder.Build();

{% endhighlight %}
{% highlight C# tabtitle="Client (~/_Program.cs)" hl_lines="1 4" %}

using Syncfusion.Blazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddSyncfusionBlazor();

await builder.Build().RunAsync();

{% endhighlight %}
{% endtabs %}

## Configure render mode

If your app's interactivity location is set to **Per page/component**, add the required render mode directive at the top of each `~/Pages/*.razor` file that uses interactive components.

{% tabs %}
{% highlight razor tabtitle="Server" %}

@rendermode InteractiveServer

{% endhighlight %}
{% highlight razor tabtitle="WebAssembly" %}

@rendermode InteractiveWebAssembly

{% endhighlight %}
{% highlight razor tabtitle="Auto" %}

@rendermode InteractiveAuto

{% endhighlight %}
{% endtabs %}

N> If the interactivity location is set to **Global**, no per-page directive is required.

## How AI models integrate with Blazor DataGrid

This sample demonstrates how to use the **[Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid)** to analyze sales order data and generate business insights with AI models. The AI service returns structured JSON that includes an executive summary, key trends, recommendations, and flagged order IDs. While the request is being processed, a loading spinner is displayed, and the grid highlights the rows identified by the AI.

The sample loads sales order data in `Home.razor.cs` and sends it to the AI service when the user selects **Generate AI Insights**.

### Workflow

- **Sample data**: A list of `SalesOrder` records is created with fields such as `OrderId`, `Customer`, `Region`, `Category`, `Sales`, `Profit`, and `OrderDate`.
- **AI request**: The grid data is serialized to JSON and passed to `IChatInferenceService`.
- **Structured response**: The prompt instructs the model to return JSON only with the following properties:
  - `summary`
  - `keyTrends`
  - `recommendations`
  - `flaggedOrderIds`
- **Response handling**: The returned text is cleaned, deserialized, and stored in the `AiInsights` model.
- **Row highlighting**: The `OnQueryCellInfo` event checks each row's `OrderId` and applies a highlight style to the flagged records.
- **Insight display**: The summary, trends, and recommendations are displayed below the grid, and any errors are shown if the AI request fails.

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

@page "/"

@inject IChatInferenceService AIService
@using Syncfusion.Blazor.AI
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Spinner

<div class="ai-grid-shell">
    <SfGrid @ref="GridRef"
            TValue="SalesOrder"
            DataSource="@orders"
            AllowTextWrap="true">
        <GridTemplates>
            <ToolbarTemplate>
                <SfButton CssClass="e-primary" IsPrimary="true" Disabled="@isLoading"
                          OnClick="GenerateInsightsAsync">
                    @(isLoading ? "Generating..." : "Generate AI Insights")
                </SfButton>
            </ToolbarTemplate>
        </GridTemplates>

        <GridEvents TValue="SalesOrder" QueryCellInfo="OnQueryCellInfo"></GridEvents>

        <GridColumns>
            <GridColumn Field="@nameof(SalesOrder.OrderId)" HeaderText="Order ID" IsPrimaryKey="true" Width="110"></GridColumn>
            <GridColumn Field="@nameof(SalesOrder.Customer)" HeaderText="Customer" Width="140"></GridColumn>
            <GridColumn Field="@nameof(SalesOrder.Region)" HeaderText="Region" Width="110"></GridColumn>
            <GridColumn Field="@nameof(SalesOrder.Category)" HeaderText="Category" Width="120"></GridColumn>
            <GridColumn Field="@nameof(SalesOrder.Sales)" HeaderText="Sales" TextAlign="TextAlign.Right" Format="C0" Width="110"></GridColumn>
            <GridColumn Field="@nameof(SalesOrder.Profit)" HeaderText="Profit" TextAlign="TextAlign.Right" Format="C0" Width="110"></GridColumn>
            <GridColumn Field="@nameof(SalesOrder.OrderDate)" HeaderText="Order Date" Format="d" Width="130"></GridColumn>
        </GridColumns>
    </SfGrid>

    <SfSpinner Visible="@isLoading"></SfSpinner>

    @if (!string.IsNullOrWhiteSpace(errorMessage))
    {
        <div class="error-box">@errorMessage</div>
    }

    @if (insight is not null)
    {
        <div class="insight-grid">
            <div class="insight-card">
                <h4>Executive Summary</h4>
                <p>@insight.Summary</p>
            </div>

            <div class="insight-card">
                <h4>Key Trends</h4>
                <ul>
                    @foreach (var item in insight.KeyTrends)
                    {
                        <li>@item</li>
                    }
                </ul>
            </div>

            <div class="insight-card">
                <h4>Recommendations</h4>
                <ul>
                    @foreach (var item in insight.Recommendations)
                    {
                        <li>@item</li>
                    }
                </ul>
            </div>
        </div>
    }
</div>

<style>
    .ai-grid-shell { display: grid; gap: 1rem; }
    .insight-grid { display: grid; gap: 1rem; grid-template-columns: repeat(auto-fit, minmax(240px, 1fr)); }
    .insight-card { border: 1px solid #d1d5db; border-radius: 8px; padding: 1rem; background: #fff; }
    .error-box { padding: .75rem 1rem; border-radius: 6px; background: #fee2e2; color: #991b1b; }
    .ai-highlight-cell { background: #fff7ed; color: #9a3412; font-weight: 600; }
</style>

{% endhighlight %}
{% highlight C# tabtitle="Home.razor.cs" %}

using Microsoft.Extensions.AI;
using Syncfusion.Blazor.AI;
using Syncfusion.Blazor.Grids;
using System.Text.Json;

namespace AISamples.Components.Pages;

public partial class Home
{
    private List<SalesOrder> orders = new();
    private AiInsights? insight;
    private bool isLoading;
    private string errorMessage = string.Empty;
    private HashSet<string> highlightedOrderIds = new(StringComparer.OrdinalIgnoreCase);
    private SfGrid<SalesOrder>? GridRef;

    protected override void OnInitialized()
    {
        orders = new List<SalesOrder>
        {
            new() { OrderId = "SO-1001", Customer = "Northwind", Region = "West", Category = "Bikes", Sales = 12000, Profit = 3200, OrderDate = new DateTime(2026, 1, 5) },
            new() { OrderId = "SO-1002", Customer = "Contoso", Region = "East", Category = "Accessories", Sales = 3400, Profit = 980, OrderDate = new DateTime(2026, 1, 8) },
            new() { OrderId = "SO-1003", Customer = "Adventure Works", Region = "West", Category = "Clothing", Sales = 8600, Profit = 1400, OrderDate = new DateTime(2026, 1, 11) },
            new() { OrderId = "SO-1004", Customer = "Fabrikam", Region = "South", Category = "Bikes", Sales = 1500, Profit = -220, OrderDate = new DateTime(2026, 1, 13) },
            new() { OrderId = "SO-1005", Customer = "Northwind", Region = "North", Category = "Electronics", Sales = 24200, Profit = 6700, OrderDate = new DateTime(2026, 1, 15) },
            new() { OrderId = "SO-1006", Customer = "Contoso", Region = "East", Category = "Clothing", Sales = 1900, Profit = 120, OrderDate = new DateTime(2026, 1, 18) },
            new() { OrderId = "SO-1007", Customer = "Adventure Works", Region = "West", Category = "Accessories", Sales = 5400, Profit = 1650, OrderDate = new DateTime(2026, 1, 22) },
            new() { OrderId = "SO-1008", Customer = "Fabrikam", Region = "South", Category = "Electronics", Sales = 7800, Profit = 400, OrderDate = new DateTime(2026, 1, 24) },
            new() { OrderId = "SO-1009", Customer = "Northwind", Region = "Central", Category = "Bikes", Sales = 18900, Profit = 5100, OrderDate = new DateTime(2026, 1, 27) },
            new() { OrderId = "SO-1010", Customer = "Contoso", Region = "North", Category = "Accessories", Sales = 2200, Profit = 180, OrderDate = new DateTime(2026, 1, 29) },
            new() { OrderId = "SO-1011", Customer = "Adventure Works", Region = "South", Category = "Clothing", Sales = 4600, Profit = 760, OrderDate = new DateTime(2026, 2, 2) },
            new() { OrderId = "SO-1012", Customer = "Fabrikam", Region = "West", Category = "Electronics", Sales = 30500, Profit = 9200, OrderDate = new DateTime(2026, 2, 5) }
        };
    }

    private async Task GenerateInsightsAsync()
    {
        isLoading = true;
        errorMessage = string.Empty;
        insight = null;
        highlightedOrderIds.Clear();

        try
        {
            string payload = JsonSerializer.Serialize(orders);

            string prompt =
                "Analyze the following sales orders and return JSON only in this exact schema:\n\n" +
                "{\n" +
                "  \"summary\": \"string\",\n" +
                "  \"keyTrends\": [\"string\"],\n" +
                "  \"recommendations\": [\"string\"],\n" +
                "  \"flaggedOrderIds\": [\"SO-1001\"]\n" +
                "}\n\n" +
                "Writing requirements:\n" +
                "- Use clear, professional, customer-friendly language that is easy to understand.\n" +
                "- Avoid vague wording such as 'varied performance' or 'some trends'.\n" +
                "- Avoid confusing shorthand or bracketed value pairs like 'SO-1012 ($30,500, $9,200 profit)'.\n" +
                "- When referencing an order, always write it in a readable format like:\n" +
                "  'Order SO-1012: Sales $30,500 and profit $9,200.'\n" +
                "- If profit is negative, write it clearly as a loss, for example:\n" +
                "  'Order SO-1004: Sales $1,500 and a loss of $220.'\n" +
                "- The summary must clearly state the top-performing category, the weakest category, and any profit concerns.\n" +
                "- keyTrends must contain 3 to 5 specific, easy-to-read bullets.\n" +
                "- Each key trend must explain what the numbers mean in plain language and must reference exact categories, regions, customers, or order IDs.\n" +
                "- recommendations must contain 3 to 5 specific, actionable bullets.\n" +
                "- Each recommendation must be practical, specific, and tied to a category, region, customer, or order ID.\n" +
                "- flaggedOrderIds is MANDATORY and must ALWAYS be included.\n" +
                "- flaggedOrderIds must contain ALL Order IDs with negative profit or clearly low profit.\n" +
                "- flaggedOrderIds values MUST exactly match the OrderId values from the data (for example: \"SO-1004\").\n" +
                "- If no orders are negative or low-profit, return flaggedOrderIds as an empty array: [].\n" +
                "- Never omit flaggedOrderIds.\n" +
                "- Include sales and profit amounts where relevant, but always explain them clearly.\n" +
                "- Keep the content concise, polished, and suitable for business review.\n" +
                "- Return JSON only. Do not include markdown, code fences, or any extra text.\n\n" +
                "Data:\n" +
                payload;

            ChatParameters parameters = new()
            {
                Messages =
                [
                    new ChatMessage(ChatRole.User, prompt)
                ]
            };

            string result = await AIService.GenerateResponseAsync(parameters);
            result = CleanJson(result);

            insight = JsonSerializer.Deserialize<AiInsights>(
                result,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (insight is not null)
            {
                highlightedOrderIds = new HashSet<string>(insight.FlaggedOrderIds, StringComparer.OrdinalIgnoreCase);
                if (GridRef is not null)
                {
                    await GridRef.Refresh();
                }
            }
        }
        catch (Exception ex)
        {
            errorMessage = $"AI insight generation failed: {ex.Message}";
        }
        finally
        {
            isLoading = false;
            await InvokeAsync(StateHasChanged);
        }
    }

    private void OnQueryCellInfo(QueryCellInfoEventArgs<SalesOrder> args)
    {
        if (highlightedOrderIds.Contains(args.Data.OrderId))
        {
            args.Cell.AddClass(new[] { "ai-highlight-cell" });
        }
    }

    private static string CleanJson(string value)
    {
        return value.Replace("```json", string.Empty, StringComparison.OrdinalIgnoreCase)
                    .Replace("```", string.Empty, StringComparison.OrdinalIgnoreCase)
                    .Trim();
    }

    public class SalesOrder
    {
        public string OrderId { get; set; } = string.Empty;
        public string Customer { get; set; } = string.Empty;
        public string Region { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public decimal Sales { get; set; }
        public decimal Profit { get; set; }
        public DateTime OrderDate { get; set; }
    }

    public class AiInsights
    {
        public string Summary { get; set; } = string.Empty;
        public List<string> KeyTrends { get; set; } = new();
        public List<string> Recommendations { get; set; } = new();
        public List<string> FlaggedOrderIds { get; set; } = new();
    }
}

{% endhighlight %}
{% endtabs %}

## Error handling and reliability in AI-powered DataGrids

If the AI service fails to return a valid response, the [Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) displays an appropriate error message to inform the user. To ensure reliability and a smooth user experience, consider handling the following common scenarios:

- **Invalid configuration**: Ensure the API key, endpoint, and model name are valid and accessible.
- **Model unavailable**: Ensure the specified `azureOpenAIModel` or `modelName` is deployed and supported.
- **Network or service issues**: Verify connectivity to the AI service, including self‑hosted endpoints.
- **Timeouts and large datasets**: Large requests may cause delays or timeouts, so consider batching data or optimizing prompts.
- **Invalid AI responses**: Validate AI output before applying results to the DataGrid.
- **Rate limits**: Handle throttling gracefully by retrying or informing the user.
- **Fallback behavior**: Allow the DataGrid to continue displaying data if AI processing fails.

N> In addition to standard errors, applications should **validate AI responses**, **handle rate limits**, and provide graceful fallback behavior to **ensure a reliable user experience**.

## Performance considerations

When handling large datasets, ensure the Ollama server has sufficient resources (CPU/GPU) to process requests efficiently. For datasets exceeding 10,000 records, consider splitting the data into smaller batches to avoid performance bottlenecks. Test the application with your specific dataset to determine optimal performance.

![AI-powered DataGrid in Blazor](../images/ai-powered-blazor-datagrid.webp)
