---
layout: post
title: Getting Started with Syncfusion Smart Rich Text Editor in Web App
description: Learn how to create and run Syncfusion Blazor Smart Rich Text Editor component in Blazor Web App with server interactivity.
platform: Blazor
control: Smart Rich Text Editor
documentation: ug
---

# Getting Started with Smart Rich Text Editor in Blazor Web App

This section explains how to add the [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Smart Rich Text Editor](https://www.syncfusion.com/blazor-components/blazor-smart-rich-text-editor) component in your Blazor Web App using [Visual Studio](https://visualstudio.microsoft.com/vs/), [Visual Studio Code](https://code.visualstudio.com/), and the [.NET CLI](https://learn.microsoft.com/en-us/dotnet/core/tools/).

{% tabcontents %}

{% tabcontent Visual Studio %}

## Prerequisites

* [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)

## Create a new Blazor Web App in Visual Studio

Create a **Blazor Web App** using Visual Studio via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-10.0&pivots=vs) or the [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-integration/template-studio). For detailed instructions, refer to the [Blazor Web App Getting Started](https://blazor.syncfusion.com/documentation/getting-started/blazor-web-app) documentation.

{% endtabcontent %}

{% tabcontent Visual Studio Code %}

## Prerequisites

* [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)

## Create a new Blazor Web App in Visual Studio Code

Create a **Blazor Web App** using Visual Studio Code via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-10.0&pivots=vsc) or the [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-code-integration/create-project). For detailed instructions, refer to the [Blazor Web App Getting Started](https://blazor.syncfusion.com/documentation/getting-started/blazor-web-app?tabcontent=visual-studio-code) documentation.

For example, in a Blazor Web App with the `Auto` interactive render mode, use the following commands in the integrated terminal (<kbd>Ctrl</kbd>+<kbd>`</kbd>):

{% tabs %}
{% highlight c# tabtitle="Blazor Web App" %}

dotnet new blazor -o BlazorWebApp -int Auto
cd BlazorWebApp
cd BlazorWebApp.Client

{% endhighlight %}
{% endtabs %}

{% endtabcontent %}

{% tabcontent .NET CLI %}

## Prerequisites

Install the latest version of [.NET SDK](https://dotnet.microsoft.com/en-us/download). If you previously installed the SDK, determine the installed version by executing the following command in a command prompt (Windows) or terminal (macOS) or command shell (Linux).

{% tabs %}
{% highlight c# tabtitle=".NET CLI" %}

dotnet --version

{% endhighlight %}
{% endtabs %}

## Create a Blazor Web App using .NET CLI

Run the following command to create a new Blazor Web App in a command prompt (Windows) or terminal (macOS) or command shell (Linux). For detailed instructions, refer to the [Blazor Web App Getting Started](https://blazor.syncfusion.com/documentation/getting-started/blazor-web-app?tabcontent=.net-cli) documentation.

For example, in a Blazor Web App with the `Auto` interactive render mode, use the following commands:

{% tabs %}
{% highlight c# tabtitle="Blazor Web App" %}

dotnet new blazor -o BlazorWebApp -int Auto
cd BlazorWebApp
cd BlazorWebApp.Client

{% endhighlight %}
{% endtabs %}

{% endtabcontent %}

{% endtabcontents %}

N> Configure the appropriate [Interactive render mode](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/render-modes?view=aspnetcore-10.0#render-modes) and [Interactivity location](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-10.0&pivots=vs) while creating a Blazor Web App. For detailed information, refer to the [interactive render mode documentation](https://blazor.syncfusion.com/documentation/common/interactive-render-mode).


## Install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Smart Rich Text Editor and Themes NuGet

Install the following NuGet packages in your project:

* [Syncfusion.Blazor.SmartRichTextEditor](https://www.nuget.org/packages?q=Syncfusion.Blazor.SmartRichTextEditor)
* [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/)

You can install these packages using different methods as shown below:

{% tabcontents %}

{% tabcontent Visual Studio %}

## Steps
1. In Visual Studio Navigate to:

   **Tools → NuGet Package Manager → Manage NuGet Packages for Solution**
2. Search for the required packages.
3. Select the package and click **Install**.

{% endtabcontent %}

{% tabcontent Visual Studio (Package Manager Console) %}

## Steps
1. In Visual Studio Navigate to:

   **Tools → NuGet Package Manager → Package Manager Console**
2. Run the following commands:

{% tabs %}
{% highlight C# tabtitle="Install Packages" %}

Install-Package Syncfusion.Blazor.SmartRichTextEditor -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.Themes -Version {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

{% endtabcontent %}

{% tabcontent Visual Studio Code / .NET CLI %}

## Steps
1. Open your project.
2. Open the terminal:
   - In Visual Studio Code: use the integrated terminal (<kbd>Ctrl</kbd> + <kbd>`</kbd>)
   - Or use any system terminal for CLI
3. Run the following commands:

{% tabs %}
{% highlight C# tabtitle="Install Packages" %}

dotnet add package Syncfusion.Blazor.SmartRichTextEditor --version {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Themes --version {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

{% endtabcontent %}

{% endtabcontents %}

N> Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components are available in [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). Refer to [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for available NuGet packages list with component details.

## Register Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Service

Open **~/_Imports.razor** file in the Components folder and import the `Syncfusion.Blazor` and `Syncfusion.Blazor.SmartRichTextEditor` namespace.

{% tabs %}
{% highlight razor tabtitle="~/Components/_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.SmartRichTextEditor

{% endhighlight %}
{% endtabs %}

Now, register the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Service in the **~/Program.cs** file of your Blazor Web App.

{% tabs %}
{% highlight C# tabtitle="Program.cs" hl_lines="3 10" %}

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

Install the following NuGet packages to your project:

* [Microsoft.Extensions.AI](https://www.nuget.org/packages/Microsoft.Extensions.AI)
* [Microsoft.Extensions.AI.OpenAI](https://www.nuget.org/packages/Microsoft.Extensions.AI.OpenAI)

You can install these packages using different methods as shown below:

{% tabcontents %}

{% tabcontent Visual Studio %}

## Steps
1. In Visual Studio Navigate to:

   **Tools → NuGet Package Manager → Manage NuGet Packages for Solution**
2. Search for the required packages.
3. Select the package and click **Install**.

{% endtabcontent %}

{% tabcontent Visual Studio (Package Manager Console) %}

## Steps
1. In Visual Studio Navigate to:

   **Tools → NuGet Package Manager → Package Manager Console**
2. Run the following commands:

{% tabs %}
{% highlight C# tabtitle="Install Packages" %}

Install-Package Microsoft.Extensions.AI
Install-Package Microsoft.Extensions.AI.OpenAI

{% endhighlight %}
{% endtabs %}

{% endtabcontent %}

{% tabcontent Visual Studio Code / .NET CLI %}

## Steps
1. Open your project.
2. Open the terminal:
   - In Visual Studio Code: use the integrated terminal (<kbd>Ctrl</kbd> + <kbd>`</kbd>)
   - Or use any system terminal for CLI
3. Run the following commands:

{% tabs %}
{% highlight C# tabtitle="Install Packages" %}

dotnet add package Microsoft.Extensions.AI
dotnet add package Microsoft.Extensions.AI.OpenAI

{% endhighlight %}
{% endtabs %}

{% endtabcontent %}

{% endtabcontents %}

* For **OpenAI**, obtain an API key from [OpenAI](https://help.openai.com/en/articles/4936850-where-do-i-find-my-openai-api-key) and specify the desired model (e.g., `gpt-3.5-turbo`, `gpt-4`). Store the API key securely in a configuration file.

* To configure the AI service, add the following settings to the **~/Program.cs** file in your Blazor Web app.

{% tabs %}
{% highlight C# tabtitle="Program.cs" hl_lines="3 4 5 15 16 17 18 19 20 21 22" %}

using Syncfusion.Blazor;
using Syncfusion.Blazor.AI;
using Microsoft.Extensions.AI;
using OpenAI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddSyncfusionBlazor();

string openAIApiKey = "API-KEY";
string openAIModel = "OPENAI_MODEL";
OpenAIClient openAIClient = new OpenAIClient(openAIApiKey);
IChatClient openAIChatClient = openAIClient.GetChatClient(openAIModel).AsIChatClient();
builder.Services.AddChatClient(openAIChatClient);

builder.Services.AddSingleton<IChatInferenceService, SyncfusionAIService>();

var app = builder.Build();

// ... rest of configuration

{% endhighlight %}
{% endtabs %}

### Azure OpenAI

Install the following NuGet packages to your project:

* [Microsoft.Extensions.AI](https://www.nuget.org/packages/Microsoft.Extensions.AI)
* [Microsoft.Extensions.AI.OpenAI](https://www.nuget.org/packages/Microsoft.Extensions.AI.OpenAI)
* [Azure.AI.OpenAI](https://www.nuget.org/packages/Azure.AI.OpenAI)

You can install these packages using different methods as shown below:

{% tabcontents %}

{% tabcontent Visual Studio %}

## Steps
1. In Visual Studio Navigate to:

   **Tools → NuGet Package Manager → Manage NuGet Packages for Solution**
2. Search for the required packages.
3. Select the package and click **Install**.

{% endtabcontent %}

{% tabcontent Visual Studio (Package Manager Console) %}

## Steps
1. In Visual Studio Navigate to:

   **Tools → NuGet Package Manager → Package Manager Console**
2. Run the following commands:

{% tabs %}
{% highlight C# tabtitle="Install Packages" %}

Install-Package Microsoft.Extensions.AI
Install-Package Microsoft.Extensions.AI.OpenAI
Install-Package Azure.AI.OpenAI

{% endhighlight %}
{% endtabs %}

{% endtabcontent %}

{% tabcontent Visual Studio Code / .NET CLI %}

## Steps
1. Open your project.
2. Open the terminal:
   - In Visual Studio Code: use the integrated terminal (<kbd>Ctrl</kbd> + <kbd>`</kbd>)
   - Or use any system terminal for CLI
3. Run the following commands:

{% tabs %}
{% highlight C# tabtitle="Install Packages" %}

dotnet add package Microsoft.Extensions.AI
dotnet add package Microsoft.Extensions.AI.OpenAI
dotnet add package Azure.AI.OpenAI

{% endhighlight %}
{% endtabs %}

{% endtabcontent %}

{% endtabcontents %}

* For **Azure OpenAI**, first [deploy an Azure OpenAI Service resource and model](https://learn.microsoft.com/en-us/azure/ai-services/openai/how-to/create-resource), then values for `azureOpenAIKey`, `azureOpenAIEndpoint` and `azureOpenAIModel` will all be provided to you.

* To configure the AI service, add the following settings to the **~/Program.cs** file in your Blazor Web app.

{% tabs %}
{% highlight C# tabtitle="Program.cs" hl_lines="3 4 5 6 16 17 18 19 20 21 22 23 24 25 26 27" %}

using Syncfusion.Blazor;
using Syncfusion.Blazor.AI;
using Azure.AI.OpenAI;
using Microsoft.Extensions.AI;
using System.ClientModel;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

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

builder.Services.AddSingleton<IChatInferenceService, SyncfusionAIService>();

var app = builder.Build();

// ... rest of configuration

{% endhighlight %}
{% endtabs %}

N> To configure other AI services, refer to the following sections [Ollama AI Service](https://blazor.syncfusion.com/documentation/smart-rich-text-editor/ollama) and [Custom AI Service](https://blazor.syncfusion.com/documentation/smart-rich-text-editor/custom-inference-backend).

## Add stylesheet and script resources

The theme stylesheet and script can be accessed from NuGet through [Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets). Reference the stylesheet and script in the `<head>` of the main page:

* For **Blazor Web App**, include it in the **~/Components/App.razor** file.

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

N> Check out the [Blazor Themes](https://blazor.syncfusion.com/documentation/appearance/themes) topic to discover various methods ([Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets), [CDN](https://blazor.syncfusion.com/documentation/appearance/themes#cdn-reference), and [CRG](https://blazor.syncfusion.com/documentation/common/custom-resource-generator)) for referencing themes in your Blazor application. Also, check out the [Adding Script Reference](https://blazor.syncfusion.com/documentation/common/adding-script-references) topic to learn different approaches for adding script references in your Blazor application.

## Add Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Smart Rich Text Editor component

Add the Syncfusion<sup style="font-size:70%">&reg;</sup> **Blazor Smart Rich Text Editor** component in the **~/Components/Pages/Home.razor** or any other page file.

N> Notice the `@rendermode InteractiveServer` directive on the page. This is required for Blazor Web App to enable server-side interactivity.

{% tabs %}
{% highlight razor tabtitle="~/Components/Pages/Home.razor" %}

@rendermode InteractiveServer
@using Syncfusion.Blazor.SmartRichTextEditor

<SfSmartRichTextEditor>
    <h2>Welcome to Smart Rich Text Editor</h2>
    <p>This editor showcases AI-assisted content enhancement. Try selecting text and utilizing the AI tools to refine your writing.</p>
    <p>Use the <strong>Smart Action</strong> dropdown toolbar to summarize, expand, or adjust the tone. Press <kbd>Alt</kbd>+<kbd>Enter</kbd> to open the AI Query dialog.</p>
    <ul>
       <li><strong>Purpose:</strong> Create clear and concise documentation snippets.</li>
       <li><strong>Tone:</strong> Professional yet approachable.</li>
       <li><strong>Example:</strong> Transform this paragraph into bullet points using AI.</li>
    </ul>
    <AssistViewSettings Placeholder="Start typing or use AI assistance to enhance your content..." />
</SfSmartRichTextEditor>

{% endhighlight %}
{% endtabs %}

* To launch the application, press <kbd>Ctrl</kbd>+<kbd>F5</kbd> in Visual Studio, run `dotnet run` from the CLI or integrated terminal in VS Code, or use the Run command in your preferred IDE to render the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Smart Rich Text Editor component in the default web browser.

* Start typing content and use the AI tools in the toolbar to enhance your editing experience.

* Use <kbd>Alt</kbd>+<kbd>Enter</kbd> to open the AI Query dialog for content improvement.

N> When using the .NET CLI or Visual Studio Code, ensure that you run the application from the **server (host) project directory**, not from the `.Client` project. The client project does not run independently and is hosted by the server application.

![Syncfusion Smart Rich Text Editor - Output](images/smart-rich-text-editor-overview.gif)

N> [View Sample in GitHub](https://github.com/syncfusion/smart-ai-samples).

## See also

* [Getting Started with Smart Rich Text Editor in Server App](https://blazor.syncfusion.com/documentation/smart-rich-text-editor/getting-started)
* [Rich Text Editor Documentation](https://blazor.syncfusion.com/documentation/rich-text-editor)
* [Blazor Web App Documentation](https://learn.microsoft.com/en-us/aspnet/core/blazor/hybrid)