---
layout: post
title: Query Processing with Blazor Query Builder and AI models | Syncfusion
description: Learn how to use the Syncfusion Blazor Query Builder with OpenAI, Azure OpenAI, or Ollama to automatically organize hierarchical data. Explore to more details.
platform: Blazor
control: AI Integration
documentation: ug
keywords: Blazor Query Builder, AI query processing, Syncfusion Blazor AI
--- 

# Query Processing with Blazor Query Builder and AI models

This guide demonstrates how to use the [Syncfusion.Blazor.AI](https://www.nuget.org/packages/Syncfusion.Blazor.AI) package to automatically generate the database queries in a Syncfusion Blazor Query Builder component.

## Prerequisites

* [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)

Ensure the following NuGet packages are installed based on the selected AI service.

### For OpenAI
- Microsoft.Extensions.AI
- Microsoft.Extensions.AI.OpenAI

### For Azure OpenAI
- Microsoft.Extensions.AI
- Microsoft.Extensions.AI.OpenAI
- Azure.AI.OpenAI

### For Ollama
- Microsoft.Extensions.AI
- OllamaSharp

{% tabs %}
{% highlight C# tabtitle="Package Manager" %}

Install-Package Syncfusion.Blazor.QueryBuilder -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.Navigations -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.Grids -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.Themes -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.AI -Version {{ site.releaseversion }}
Install-Package Microsoft.Extensions.AI
Install-Package Microsoft.Extensions.AI.OpenAI  # For OpenAI or Azure OpenAI
Install-Package Azure.AI.OpenAI  # For Azure OpenAI
Install-Package OllamaSharp  # For Ollama

{% endhighlight %}
{% endtabs %}

## Add stylesheet and script resources

Include the theme stylesheet and script from NuGet via [Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets) in the `<head>` of the main page:

- For **.NET 8 or .NET 9 or .NET 10** Blazor Server App, add to **~/Components/App.razor**.

```html
<head>
    ....
    <link href="_content/Syncfusion.Blazor.Themes/tailwind.css" rel="stylesheet" />
</head>

<body>
    ....
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
</body>
```

N> Check out the [Blazor Themes](https://blazor.syncfusion.com/documentation/appearance/themes) topic to discover various methods ([Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets), [CDN](https://blazor.syncfusion.com/documentation/appearance/themes#cdn-reference), and [CRG](https://blazor.syncfusion.com/documentation/common/custom-resource-generator)) for referencing themes in Blazor application. Also, check out the [Adding Script Reference](https://blazor.syncfusion.com/documentation/common/adding-script-references) topic to learn different approaches for adding script references in Blazor application.

## Configure AI service

Choose one of the following AI services (OpenAI, Azure OpenAI, or Ollama) based on requirements:

- **OpenAI**: Cloud-based, general-purpose AI models with minimal setup.
- **Azure OpenAI**: Enterprise-grade deployment with enhanced security and scalability.
- **Ollama**: Self-hosted, privacy-focused AI models.

Follow the instructions for the selected service to register the AI model in the application.

### OpenAI

Generate an API key from OpenAI and set `openAIApiKey`. Specify the desired model (for example, `gpt-3.5-turbo`, `gpt-4`) in `openAIModel`.

- Install the required NuGet packages:

{% tabs %}
{% highlight C# tabtitle="Package Manager" %}

Install-Package Microsoft.Extensions.AI
Install-Package Microsoft.Extensions.AI.OpenAI

{% endhighlight %}
{% endtabs %}

- Add the following to the **~/Program.cs** file in the Blazor Web App:

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
builder.Services.AddSingleton<SyncfusionAIService>();
builder.Services.AddSingleton<AzureAIService>();

var app = builder.Build();

{% endhighlight %}
{% endtabs %}

### Azure OpenAI

Deploy an Azure OpenAI Service resource and model as described in [Microsoft’s documentation](https://learn.microsoft.com/en-us/azure/ai-services/openai/how-to/create-resource). Obtain values for `azureOpenAIKey`, `azureOpenAIEndpoint`, and `azureOpenAIModel`.

- Install the required NuGet packages:

{% tabs %}
{% highlight C# tabtitle="Package Manager" %}

Install-Package Microsoft.Extensions.AI
Install-Package Microsoft.Extensions.AI.OpenAI
Install-Package Azure.AI.OpenAI

{% endhighlight %}
{% endtabs %}

- Add the following to the **~/Program.cs** file in the Blazor Web App:

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
builder.Services.AddSingleton<SyncfusionAIService>();
builder.Services.AddSingleton<AzureAIService>();

var app = builder.Build();

{% endhighlight %}
{% endtabs %}

### Ollama

To use Ollama for self-hosted AI models:

1. **Download and install Ollama**: Visit [Ollama's official website](https://ollama.com) and install the application for the operating system.
2. **Install a model**: Choose a model from the [Ollama Library](https://ollama.com/library) (for example, `llama2:13b`, `mistral:7b`).
3. **Configure the application**: Provide the `Endpoint` URL (for example, `http://localhost:11434`) and `ModelName` (for example, `llama2:13b`).

- Install the required NuGet packages:

{% tabs %}
{% highlight C# tabtitle="Package Manager" %}

Install-Package Microsoft.Extensions.AI
Install-Package OllamaSharp

{% endhighlight %}
{% endtabs %}

- Add the following to the **~/Program.cs** file in the Blazor Web App:

{% tabs %}
{% highlight C# tabtitle="Blazor WebApp" hl_lines="7 8 9 11 12 13" %}

using Syncfusion.Blazor.AI;
using Microsoft.Extensions.AI;
using OllamaSharp;

var builder = WebApplication.CreateBuilder(args);

string ModelName = "MODEL_NAME";
IChatClient chatClient = new OllamaApiClient("http://localhost:11434", ModelName);
builder.Services.AddChatClient(chatClient);
builder.Services.AddSingleton<SyncfusionAIService>();
builder.Services.AddSingleton<AzureAIService>();

var app = builder.Build();

{% endhighlight %}
{% endtabs %}

- **Verify connectivity**: Ensure the Ollama server is running and accessible at the specified endpoint (for example, `http://localhost:11434`) before starting the application.

## Register Syncfusion Blazor service

Register the Syncfusion® Blazor Service in the ~/Program.cs file of your Blazor Web App.

If the **Interactive Render Mode** is set to `Server`, register the Syncfusion® Blazor service in the **~/Program.cs** file.

If the **Interactive Render Mode** is set to `WebAssembly` or `Auto`, register the Syncfusion® Blazor service in the **~/Program.cs** files of the main server project and associated .Client project.

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

## Razor component

### AI-powered Query Builder Natural Language Query Processing

Add the Natural Langauge Query processing in the Syncfusion® Blazor Query Builder component inside the **~Pages/Home.razor** file. This feature enables users to input queries in plain language, which the system then interprets to automatically generate the appropriate database queries.

{% tabs %}
{% highlight razor tabtitle="~/Home.razor" %}

@page "/"
@rendermode InteractiveServer

@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Inputs
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.QueryBuilder
@using QBwithNaturalLanguageProcessing.Service
@using Syncfusion.Blazor.Spinner
@inject AzureAIService OpenAIService


<div>
    <SfTab LoadOn="ContentLoad.Init">
        <TabItems>
            <TabItem>
                <ChildContent>
                    <TabHeader Text="Natural Language Query"></TabHeader>
                </ChildContent>
                <ContentTemplate>
                    <p class="e-text">Query</p>
                    <SfTextArea @bind-value="TextAreaValue" placeholder="Find all users who lives in California and have over 500 credits" Width="100%" RowCount="5"></SfTextArea>
                </ContentTemplate>
            </TabItem>
            <TabItem>
                <ChildContent>
                    <TabHeader Text="QueryBuilder UI"></TabHeader>
                </ChildContent>
                <ContentTemplate>
                    <SfQueryBuilder Readonly="true" TValue="User" @ref="QueryBuilderObj" DataSource="@DataSource">
                        <QueryBuilderColumns>
                            <QueryBuilderColumn Field="id" Label="ID" Type="Syncfusion.Blazor.QueryBuilder.ColumnType.Number"></QueryBuilderColumn>
                            <QueryBuilderColumn Field="name" Label="Name" Type="Syncfusion.Blazor.QueryBuilder.ColumnType.String"></QueryBuilderColumn>
                            <QueryBuilderColumn Field="email" Label="Email" Type="Syncfusion.Blazor.QueryBuilder.ColumnType.String"></QueryBuilderColumn>
                            <QueryBuilderColumn Field="address" Label="Address" Type="Syncfusion.Blazor.QueryBuilder.ColumnType.Boolean"></QueryBuilderColumn>
                            <QueryBuilderColumn Field="city" Label="City" Type="Syncfusion.Blazor.QueryBuilder.ColumnType.String"></QueryBuilderColumn>
                            <QueryBuilderColumn Field="state" Label="State" Type="Syncfusion.Blazor.QueryBuilder.ColumnType.String"></QueryBuilderColumn>
                            <QueryBuilderColumn Field="credits" Label="Credits" Type="Syncfusion.Blazor.QueryBuilder.ColumnType.Number"></QueryBuilderColumn>
                        </QueryBuilderColumns>
                    </SfQueryBuilder>
                </ContentTemplate>
            </TabItem>
        </TabItems>
    </SfTab>
    <div class="e-custom-elem">
        <SfButton Content="Run Query" CssClass="e-primary" IconCss="e-icons e-play" @onclick="GenBtnClick"></SfButton>
    </div>
    <div class="e-custom-elem">
        <span class="e-text">Results</span>
        <SfGrid TValue="User" DataSource="@GridData" AllowPaging="true">
            <SfSpinner @bind-Visible="@VisibleProperty"></SfSpinner>
            <GridEvents Created="GridCreated" TValue="User"></GridEvents>
            <GridColumns>
                <GridColumn Field=@nameof(User.id) HeaderText="ID" TextAlign="TextAlign.Right" Width="60"></GridColumn>
                <GridColumn Field=@nameof(User.name) HeaderText="Name" Width="150"></GridColumn>
                <GridColumn Field=@nameof(User.email) HeaderText="Email" TextAlign="TextAlign.Right" Width="80"></GridColumn>
                <GridColumn Field=@nameof(User.address) HeaderText="Address" Width="150"></GridColumn>
                <GridColumn Field=@nameof(User.city) HeaderText="City" Width="150"></GridColumn>
                <GridColumn Field=@nameof(User.state) HeaderText="State" Width="150"></GridColumn>
                <GridColumn Field=@nameof(User.credits) HeaderText="Credits" ></GridColumn>
            </GridColumns>
        </SfGrid>
    </div>
</div>
@code {
    public bool VisibleProperty = false;
    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public int credits { get; set; }
    }
    private static readonly string[] Names = { "John", "Jane", "Bob", "Alice", "Tom", "Sally", "Jim", "Mary", "Peter", "Nancy" };
    private static readonly string[] Cities = { "Los Angeles", "San Diego", "New York", "Chicago", "Houston", "Phoenix", "Philadelphia", "San Antonio", "Dallas", "San Jose" };
    private static readonly string[] States = { "California", "New York", "Illinois", "Texas", "Arizona", "Pennsylvania" };
    private static readonly string[] Streets = { "Elm St", "Oak St", "Maple Ave", "Pine St", "Cedar St", "Birch St" };
    private static readonly string[] Emails = { "example.com", "test.com", "demo.com" };
    public static List<User> GenerateRandomUsers(int count)
    {
        var random = new Random();
        var users = new List<User>();
        for (int i = 0; i < count; i++)
        {
            var id = i + 1;
            var name = Names[random.Next(Names.Length)];
            var email = $"{name.ToLower()}{id}@{Emails[random.Next(Emails.Length)]}";
            var address = $"{random.Next(10000)} {Streets[random.Next(Streets.Length)]}";
            var city = Cities[random.Next(Cities.Length)];
            var state = States[random.Next(States.Length)];
            var credits = random.Next(2001);
            users.Add(new User
            {
                id = id,
                name = name,
                email = email,
                address = address,
                city = city,
                state = state,
                credits = credits
            });
        }
        return users;
    }
    List<User> Users = GenerateRandomUsers(7);
    private string TextAreaValue { get; set; } = "Find all users who lives in California and have over 500 credits";
    SfQueryBuilder<User> QueryBuilderObj;
    private IEnumerable<User> GridData { get; set; }
    private IEnumerable<User> DataSource { get; set; }
    protected override void OnInitialized()
    {
        DataSource = Users;
    }
    private void GridCreated()
    {
        GridData = DataSource;
    }
    private async void GenBtnClick()
    {
        VisibleProperty = true;
        string prompt = "Create an SQL query to achieve the following task: " + TextAreaValue + " from a single table. Focus on constructing a valid SQL query that directly addresses the specified task, ensuring it adheres to standard SQL syntax for querying a single table. NOTE: Return only the SQL query without any additional explanation or commentary. The response should contain the query itself, formatted correctly and ready for execution.";
        string result = await OpenAIService.GetCompletionAsync(prompt, false);
        if (!String.IsNullOrEmpty(result))
        {
            string value = result.Split("WHERE ")[1].Split(";\n")[0];
            value = value.Replace("\n", " ");
            value = value.Replace(";", "");
            QueryBuilderObj.SetRulesFromSql(value);
            GridData = QueryBuilderObj.GetFilteredRecords().ToList().AsEnumerable<User>();
        }
        VisibleProperty = false;
        StateHasChanged();
    }
}
<style>
    #container {
        margin: 10px;
        border: 1px solid lightgray;
        border-radius: 4px;
    }
    #container .e-tab {
        margin-top: 16px;
    }
    .e-tab .e-content {
        padding: 16px;
    }
    .e-text {
        font-weight: bold;
        font-family: "Roboto", -apple-system, BlinkMacSystemFont, "Segoe UI", "Helvetica Neue", sans-serif;
        font-size: 14px;
    }
    .e-custom-elem {
        margin-bottom: 16px;
        margin-left: 16px;
        width: calc(100% - 32px);
    }
</style>

{% endhighlight %}
{% endtabs %}

## Error Handling and Troubleshooting

If the AI service fails to return a valid response, the Query Builder shows a toast in the upper-right corner: "Server is busy right now, Please try again". Common issues include:

- **Invalid API Key or Endpoint**: Verify that the `openAIApiKey`, `azureOpenAIKey`, or Ollama `Endpoint` is correct and the service is accessible.
- **Model Unavailable**: Ensure the specified `openAIModel`, `azureOpenAIModel`, or `ModelName` is deployed and supported.
- **Network Issues**: Check connectivity to the AI service endpoint, especially for self-hosted Ollama instances.
- **Large Datasets**: Processing large datasets may cause timeouts. Consider batching data or optimizing the prompt for efficiency.

## Performance Considerations

When handling large datasets, ensure the Ollama server has sufficient resources (CPU/GPU) to process requests efficiently. For datasets exceeding 10,000 records, consider splitting the data into smaller batches to avoid performance bottlenecks. Test the application with your specific dataset to determine optimal performance.

## Sample Code

A complete working example is available in the [Syncfusion Blazor AI Samples GitHub repository](https://github.com/syncfusion/smart-ai-samples).

## Live Demo

Explore the AI-powered Smart Query Builder in action by visiting the live demo:

👉 [Try the Live Demo](https://blazor.syncfusion.com/demos/pivot-table/ai-smart-pivot?theme=fluent2)