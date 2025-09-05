---
layout: post
title: Using Azure OpenAI with Syncfusion Blazor AI | Syncfusion
description: Learn how to set up and use Syncfusion.Blazor.AI with Azure OpenAI for AI-powered features in your Blazor apps, including configuration and examples.
platform: Blazor
control: AI Integration
documentation: ug
---

# Azure OpenAI Integration with Syncfusion Blazor AI

## Introduction

This section demonstrates configuring and using the [Syncfusion.Blazor.AI](https://www.nuget.org/packages/Syncfusion.Blazor.AI) package with [Azure OpenAI](https://learn.microsoft.com/en-us/azure/ai-services/openai/how-to/create-resource) to enable AI functionalities in Blazor applications. The package provides seamless integration with Azure OpenAI's API, empowering Syncfusion Blazor components with intelligent features such as natural language querying, data analysis, and content processing.

## Prerequisites

Before integrating Azure OpenAI with your Blazor application, ensure you have:

* Installed the following NuGet packages:
{% tabs %}
{% highlight C# tabtitle="Package Manager" %}

Install-Package Syncfusion.Blazor.AI -Version {{ site.releaseversion }}
Install-Package Microsoft.Extensions.AI
Install-Package Microsoft.Extensions.AI.OpenAI
Install-Package Azure.AI.OpenAI

{% endhighlight %}
{% endtabs %}
* [Deployed an Azure OpenAI Service resource and model](https://learn.microsoft.com/en-us/azure/ai-services/openai/how-to/create-resource) to obtain values for `apiKey`, `deploymentName` and `endpoint`
* Met the [System Requirements](https://blazor.syncfusion.com/documentation/system-requirements) for Syncfusion Blazor components
* Configured secure credential storage using Azure Key Vault or environment variables

## Configuration Steps

Follow these steps to configure Azure OpenAI as your AI provider:

### Register AI Services in Program.cs

Open your Blazor application's `Program.cs` file and add the following configuration:

```csharp
// Add required namespaces
using Syncfusion.Blazor.AI;
using Azure.AI.OpenAI;
using Microsoft.Extensions.AI;
using System.ClientModel;

// Register Azure OpenAI credentials
string azureOpenAiKey = "AZURE_OPENAI_KEY";
string azureOpenAiEndpoint = "AZURE_OPENAI_ENDPOINT";
string azureOpenAiModel = "AZURE_OPENAI_MODEL";
AzureOpenAIClient azureOpenAIClient = new AzureOpenAIClient(
     new Uri(azureOpenAiEndpoint),
     new ApiKeyCredential(azureOpenAiKey)
);
IChatClient azureOpenAiChatClient = azureOpenAIClient.GetChatClient(azureOpenAiModel).AsIChatClient();
builder.Services.AddChatClient(azureOpenAiChatClient);

// Register the inference service
builder.Services.AddSingleton<IChatInferenceService, SyncfusionAIService>();
```

## Natural Language Querying with Azure OpenAI

This example demonstrates using the **Syncfusion.Blazor.AI** package with Azure OpenAI to enable natural language querying in a Blazor application. The application features a Syncfusion Tab component with a textarea for entering natural language queries, a QueryBuilder component to visualize the generated query rules, and a Grid component to display filtered results based on the query processed by Azure OpenAI.

### Prerequisites

- Install the following NuGet packages:
{% tabs %}
{% highlight C# tabtitle="Package Manager" %}

Install-Package Syncfusion.Blazor.Grid -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.Themes -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.AI -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.QueryBuilder -Version {{ site.releaseversion }}
Install-Package Microsoft.Extensions.AI
Install-Package Microsoft.Extensions.AI.OpenAI
Install-Package Azure.AI.OpenAI

{% endhighlight %}
{% endtabs %}
- Ensure your Blazor application meets the [System Requirements](https://blazor.syncfusion.com/documentation/system-requirements).
- Add the following to `App.razor` for Syncfusion themes and scripts:
  
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

### Register Syncfusion Blazor Service

Register the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Service in the **~/Program.cs** file of your Blazor Web App.

If the **Interactive Render Mode** is set to `WebAssembly` or `Auto`, you need to register the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor service in both **~/Program.cs** files of your Blazor Web App.

{% tabs %}
{% highlight c# tabtitle="Server(~/_Program.cs)" hl_lines="3 11" %}

...
...
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();
builder.Services.AddSyncfusionBlazor();

var app = builder.Build();
....

{% endhighlight %}
{% highlight c# tabtitle="Client(~/_Program.cs)" hl_lines="2 5" %}

...
using Syncfusion.Blazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddSyncfusionBlazor();

await builder.Build().RunAsync();

{% endhighlight %}
{% endtabs %}

If the **Interactive Render Mode** is set to `Server`, your project will contain a single **~/Program.cs** file. So, you should register the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Service only in that **~/Program.cs** file.

{% tabs %}
{% highlight c# tabtitle="~/_Program.cs" hl_lines="2 9" %}

...
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddSyncfusionBlazor();

var app = builder.Build();
....

{% endhighlight %}
{% endtabs %}

### Razor Component (`Home.razor`)
```csharp
@page "/"

@using Syncfusion.Blazor.QueryBuilder
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Spinner
@using Syncfusion.Blazor.AI
@inject IChatInferenceService AzureAIService

<title>Syncfusion - Smart Natural Language Querying</title>
<SfTab LoadOn="ContentLoad.Init">
    <TabItems>
        <TabItem>
            <ChildContent>
                <TabHeader Text="Natural Language Query"></TabHeader>
            </ChildContent>
            <ContentTemplate>
                <span class="e-text">Query</span>
                <textarea id="text-area" @bind="TextAreaValue" placeholder="Find all users who lives in California and have over 500 credits"></textarea>
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
            <GridColumn Field=@nameof(User.id) HeaderText="ID" TextAlign="TextAlign.Right"></GridColumn>
            <GridColumn Field=@nameof(User.name) HeaderText="Name"></GridColumn>
            <GridColumn Field=@nameof(User.email) HeaderText="Email" TextAlign="TextAlign.Right"></GridColumn>
            <GridColumn Field=@nameof(User.address) HeaderText="Address"></GridColumn>
            <GridColumn Field=@nameof(User.city) HeaderText="City"></GridColumn>
            <GridColumn Field=@nameof(User.state) HeaderText="State"></GridColumn>
            <GridColumn Field=@nameof(User.credits) HeaderText="Credits"></GridColumn>
        </GridColumns>
    </SfGrid>
</div>

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
    #text-area {
        width: 100%;
        height: 100px;
        margin-top: 5px;
        margin-bottom: 0px;
        padding: 10px;
        border: 1px solid #ccc;
        border-radius: 4px;
        resize: none;
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
```

(`Home.razor.cs`)
```csharp
using Microsoft.Extensions.AI;
using Syncfusion.Blazor.AI;
using Syncfusion.Blazor.QueryBuilder;

namespace AzureOpenAIExample.Components.Pages
{
    public partial class Home
    {
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

        private string TextAreaValue { get; set; } = "Find all users who lives in Los Angeles and have over 500 credits";
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

            ChatParameters chatParameters = new ChatParameters
            {
                Messages = new List<ChatMessage>
                {
                    new ChatMessage(ChatRole.User, prompt)
                }
            };
            string result = await AzureAIService.GenerateResponseAsync(chatParameters);

            string value = result.Split("WHERE ")[1].Split(";\n")[0];
            value = value.Replace("\n", " ");
            value = value.Replace(";", "");
            QueryBuilderObj.SetRulesFromSql(value);
            GridData = QueryBuilderObj.GetFilteredRecords().ToList().AsEnumerable<User>();
            StateHasChanged();
            VisibleProperty = false;
        }
    }
}
```

![Natural Query Language - Output](images/natural-languagequery.gif)

## How It Works

The example above demonstrates how to use Azure OpenAI with Syncfusion Blazor components for natural language query processing:

1. **Setup**: Configuring the Azure OpenAI service in `Program.cs` with appropriate credentials.
2. **Component Integration**: Using the `IChatInferenceService` to process natural language queries.
3. **Prompt Engineering**: Creating appropriate prompts for the AI model to convert natural language to SQL.
4. **Response Processing**: Parsing the SQL response and applying it to the QueryBuilder component.

### Key Components

- **IChatInferenceService**: Injected to interact with the Azure OpenAI models.
- **ChatParameters**: Configures the AI request, including system prompt and user messages.
- **GenerateResponseAsync**: Sends the request to Azure OpenAI and retrieves the response asynchronously.
- **UI Components**: Syncfusion Tab, QueryBuilder, and Grid components work together with the AI service.
