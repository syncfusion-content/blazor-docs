---
layout: post
title: Getting started with Syncfusion AI Query Builder in Blazor Web App
description: Checkout and learn here all about Getting started with Syncfusion Blazor Query Builder component using AI in Blazor Web App and more.
platform: Blazor
control: QueryBuilder
documentation: ug
---

# Getting Started with AI Query Builder

This section briefly explains about how to add the Blazor Query Builder component using AI in a Blazor Web App using [Visual Studio](https://visualstudio.microsoft.com/vs/) and [Visual Studio code](https://code.visualstudio.com/).

{% tabcontents %}

{% tabcontent Visual Studio %}

## Prerequisites

* [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)
* [OpenAI](https://help.openai.com/en/articles/4936850-where-do-i-find-my-openai-api-key) or [Azure OpenAI Account](https://learn.microsoft.com/en-us/azure/ai-services/openai/how-to/create-resource)

N> Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Smart Components are compatible with both `OpenAI` and `Azure OpenAI`, and fully support Server Interactivity mode apps.

## Create a new Blazor Web App in Visual Studio

Create a **Blazor Web App** using Visual Studio 2022 via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-10.0) or the [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-integration/template-studio).

## Install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor NuGet in the App

To add the **Blazor Smart TextArea** component in the app, open the NuGet package manager in Visual Studio (*Tools → NuGet Package Manager → Manage NuGet Packages for Solution*), then search and install [Syncfusion.Blazor.SmartComponents](https://www.nuget.org/packages?q=Syncfusion.Blazor.SmartComponents), [Syncfusion.Blazor.QueryBuilder](https://www.nuget.org/packages/Syncfusion.Blazor.QueryBuilder) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/).

Alternatively, run the following commands in the Package Manager Console to achieve the same.

{% tabs %}
{% highlight C# tabtitle="Package Manager" %}

Install-Package Syncfusion.Blazor.SmartComponents -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.QueryBuilder -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.Themes -Version {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

N> Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components are available in [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). Refer to the [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for the available NuGet packages list with component details.

{% endtabcontent %}

{% tabcontent Visual Studio Code %}

## Prerequisites

* [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)
* [OpenAI](https://help.openai.com/en/articles/4936850-where-do-i-find-my-openai-api-key) or [Azure OpenAI Account](https://learn.microsoft.com/en-us/azure/ai-services/openai/how-to/create-resource)

N> Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Smart Components are compatible with both `OpenAI` and `Azure OpenAI`, and fully support Server Interactivity mode apps.

## Create a new Blazor Web App in Visual Studio Code

Create a **Blazor Web App** using Visual Studio Code via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-10.0&pivots=vsc) or the [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-code-integration/create-project).

Configure the appropriate interactive render mode and interactivity location when setting up a Blazor Web App. For detailed information, refer to the [interactive render mode documentation](https://blazor.syncfusion.com/documentation/common/interactive-render-mode).

{% tabs %}
{% highlight c# tabtitle="Blazor Web App" %}

dotnet new blazor -o BlazorApp -int Server
cd BlazorApp

{% endhighlight %}
{% endtabs %}

N> For more information on creating a **Blazor Web App** with various interactive modes and locations, refer to this [link](https://blazor.syncfusion.com/documentation/getting-started/blazor-web-app?tabcontent=visual-studio-code#render-interactive-modes).

## Install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Layouts and Themes NuGet in the App

* Press <kbd>Ctrl</kbd>+<kbd>`</kbd> to open the integrated terminal in Visual Studio Code.
* Ensure in the project root directory where the `.csproj` file is located.
* Run the following command to install a [Syncfusion.Blazor.SmartComponents](https://www.nuget.org/packages?q=Syncfusion.Blazor.SmartComponents), [Syncfusion.Blazor.QueryBuilder](https://www.nuget.org/packages/Syncfusion.Blazor.QueryBuilder) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/) NuGet packages and ensure all dependencies are installed.

{% tabs %}
{% highlight c# tabtitle="Package Manager" %}

dotnet add package Syncfusion.Blazor.SmartComponents -v {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.QueryBuilder -v {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Themes -v {{ site.releaseversion }}
dotnet restore

{% endhighlight %}
{% endtabs %}

N> Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components are available in [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). Refer to [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for available NuGet packages list with component details.

{% endtabcontent %}

{% endtabcontents %}

## Register Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Service

| Interactive Render Mode | Description |
| -- | -- |
| Server | Open **~/_import.razor** file, which is located in the `Components` folder.|

Import the `Syncfusion.Blazor` and `Syncfusion.Blazor.SmartComponents` namespace.

{% tabs %}
{% highlight razor tabtitle="~/_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.SmartComponents

{% endhighlight %}
{% endtabs %}

If the **Interactive Render Mode** is set to `Server`, your project will contain a single **~/Program.cs** file. So, you should register the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Service only in that **~/Program.cs** file.

{% tabs %}
{% highlight C# tabtitle="Blazor Server App" hl_lines="3 10" %}

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSyncfusionBlazor();

var app = builder.Build();
....

{% endhighlight %}
{% endtabs %}

## Configure AI Service

Follow the instructions below to register an AI model in your application.

### OpenAI

For **OpenAI**, create an API key and place it at `openAIApiKey`. The value for `openAIModel` is the model you wish to use (e.g., `gpt-3.5-turbo`, `gpt-4`, etc.).

* Install the following NuGet packages to your project:

{% tabs %}

{% highlight c# tabtitle="Package Manager" %}

Install-Package Microsoft.Extensions.AI
Install-Package Microsoft.Extensions.AI.OpenAI

{% endhighlight %}

{% endtabs %}

* To configure the AI service, add the following settings to the **~/Program.cs** file in your Blazor Server app.

{% tabs %}
{% highlight C# tabtitle="Blazor Server App" hl_lines="7 8 9 11 12 13" %}

using Syncfusion.Blazor.SmartComponents;
using Syncfusion.Blazor.AI;
using Microsoft.Extensions.AI;
using OpenAI;
var builder = WebApplication.CreateBuilder(args);

....

builder.Services.AddSyncfusionBlazor();

string openAIApiKey = "API-KEY";
string openAIModel = "OPENAI_MODEL";
OpenAIClient openAIClient = new OpenAIClient(openAIApiKey);
IChatClient openAIChatClient = openAIClient.GetChatClient(openAIModel).AsIChatClient();
builder.Services.AddChatClient(openAIChatClient);

builder.Services.AddSyncfusionSmartComponents()
.InjectOpenAIInference();

var app = builder.Build();
....

{% endhighlight %}
{% endtabs %}

### Azure OpenAI

For **Azure OpenAI**, first [deploy an Azure OpenAI Service resource and model](https://learn.microsoft.com/en-us/azure/ai-services/openai/how-to/create-resource), then values for `azureOpenAIKey`, `azureOpenAIEndpoint` and `azureOpenAIModel` will all be provided to you.

* Install the following NuGet packages to your project:

{% tabs %}

{% highlight c# tabtitle="Package Manager" %}

Install-Package Microsoft.Extensions.AI
Install-Package Microsoft.Extensions.AI.OpenAI
Install-Package Azure.AI.OpenAI

{% endhighlight %}

{% endtabs %}

* To configure the AI service, add the following settings to the **~/Program.cs** file in your Blazor Server app.

{% tabs %}
{% highlight C# tabtitle="Blazor Server App" hl_lines="7 8 9 11 12 13" %}

using Syncfusion.Blazor.SmartComponents;
using Syncfusion.Blazor.AI;
using Azure.AI.OpenAI;
using Microsoft.Extensions.AI;
using System.ClientModel;

var builder = WebApplication.CreateBuilder(args);

....

builder.Services.AddSyncfusionBlazor();

string azureOpenAIKey = "AZURE_OPENAI_KEY";
string azureOpenAIEndpoint = "AZURE_OPENAI_ENDPOINT";
string azureOpenAIModel = "AZURE_OPENAI_MODEL";
AzureOpenAIClient azureOpenAIClient = new AzureOpenAIClient(
     new Uri(azureOpenAIEndpoint),
     new ApiKeyCredential(azureOpenAIKey)
);
IChatClient azureOpenAIChatClient = azureOpenAIClient.GetChatClient(azureOpenAIModel).AsIChatClient();
builder.Services.AddChatClient(azureOpenAIChatClient);

builder.Services.AddSyncfusionSmartComponents()
.InjectOpenAIInference();

var app = builder.Build();
....

{% endhighlight %}
{% endtabs %}


N> From version 28.2.33 to 30.2.6, the Azure.AI.OpenAI package has been removed from the SmartComponents dependency. To use Azure OpenAI, please install the [Azure.AI.OpenAI](https://www.nuget.org/packages/Azure.AI.OpenAI) package separately in your Blazor application.

### Ollama

To use Ollama for running self-hosted models:

1. **Download and install Ollama**  
   Visit [Ollama's official website](https://ollama.com) and install the application appropriate for your operating system.

2. **Install the desired model from the Ollama library**  
   You can browse and install models from the [Ollama Library](https://ollama.com/library) (e.g., `llama2:13b`, `mistral:7b`, etc.).

3. **Configure your application**

   - Provide the `Endpoint` URL where the model is hosted (e.g., `http://localhost:11434`).
   - Set `ModelName` to the specific model you installed (e.g., `llama2:13b`).

* Install the following NuGet packages to your project:

{% tabs %}

{% highlight c# tabtitle="Package Manager" %}

Install-Package Microsoft.Extensions.AI
Install-Package OllamaSharp

{% endhighlight %}

{% endtabs %}

* Add the following settings to the **~/Program.cs** file in your Blazor Server app.

{% tabs %}
{% highlight C# tabtitle="Blazor Server App" hl_lines="7 8 9 11 12 13" %}

using Syncfusion.Blazor.SmartComponents;
using Syncfusion.Blazor.AI;
using Microsoft.Extensions.AI;
using OllamaSharp;
var builder = WebApplication.CreateBuilder(args);

....

builder.Services.AddSyncfusionBlazor();

string ModelName = "MODEL_NAME";
IChatClient chatClient = new OllamaApiClient("http://localhost:11434", ModelName);
builder.Services.AddChatClient(chatClient);

builder.Services.AddSyncfusionSmartComponents()
.InjectOpenAIInference();

var app = builder.Build();
....

{% endhighlight %}
{% endtabs %}

## Add stylesheet and script resources

The theme stylesheet and script can be accessed from NuGet through [Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets). Include the stylesheet reference in the `<head>` section and the script reference at the end of the `<body>` in the **~/Components/App.razor** file as shown below:

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

## Add Natural Language Query Processing to Blazor Query Builder

Add the Natural Langauge Query processing to Syncfusion® Blazor Query Builder component in the **~Pages/Home.razor** file.

{% tabs %}
{% highlight razor tabtitle="~/Home.razor" %}

@page "/"
@rendermode InteractiveServer

@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Inputs
@using Syncfusion.Blazor.QueryBuilder
@using QBwithNaturalLanguageProcessing.Service
@inject AzureAIService OpenAIService


<div id="control-section">
    <SfTextArea @bind-value="TextAreaValue" placeholder="Find all users who lives in California and have over 500 credits" Width="100%" RowCount="5"></SfTextArea>
    <SfQueryBuilder Readonly="true" TValue="User" @ref="QueryBuilderObj" DataSource="@DataSource">
        <QueryBuilderColumns>
            <QueryBuilderColumn Field=@nameof(User.id) Label="ID" Type="Syncfusion.Blazor.QueryBuilder.ColumnType.Number"></QueryBuilderColumn>
            <QueryBuilderColumn Field=@nameof(User.name) Label="Name" Type="Syncfusion.Blazor.QueryBuilder.ColumnType.String"></QueryBuilderColumn>
            <QueryBuilderColumn Field=@nameof(User.email) Label="Email" Type="Syncfusion.Blazor.QueryBuilder.ColumnType.String"></QueryBuilderColumn>
            <QueryBuilderColumn Field=@nameof(User.address) Label="Address" Type="Syncfusion.Blazor.QueryBuilder.ColumnType.Boolean"></QueryBuilderColumn>
            <QueryBuilderColumn Field=@nameof(User.city) Label="City" Type="Syncfusion.Blazor.QueryBuilder.ColumnType.String"></QueryBuilderColumn>
            <QueryBuilderColumn Field=@nameof(User.state) Label="State" Type="Syncfusion.Blazor.QueryBuilder.ColumnType.String"></QueryBuilderColumn>
            <QueryBuilderColumn Field=@nameof(User.credits) Label="Credits" Type="Syncfusion.Blazor.QueryBuilder.ColumnType.Number"></QueryBuilderColumn>
        </QueryBuilderColumns>
    </SfQueryBuilder>
    <div class="e-custom-elem">
        <SfButton Content="Run Query" CssClass="e-primary" IconCss="e-icons e-play" @onclick="GenBtnClick"></SfButton>
    </div>
</div>

@code{
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
    private IEnumerable<User> DataSource { get; set; }
    protected override void OnInitialized()
    {
        DataSource = Users;
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
        }
        VisibleProperty = false;
        StateHasChanged();
    }
}

<style>
    .e-custom-elem {
        margin-bottom: 16px;
        margin-left: 16px;
        width: calc(100% - 32px);
    }
</style>

{% endhighlight %}
{% endtabs %}

* Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to launch the application. This will render the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor AI Query Builder component in the default web browser.



N> [View Sample in GitHub](https://github.com/syncfusion/smart-ai-samples).