---
layout: post
title: Getting started with Syncfusion AI AssistView in Blazor Web App
description: Check out the documentation for getting started with Syncfusion Blazor AI AssistView Components in Blazor Web App.
platform: Blazor
control: AI AssistView
documentation: ug
---

# Getting Started with Blazor AI AssistView in Blazor Web App

This section explains how to add the [Blazor AI AssistView](https://www.syncfusion.com/blazor-components/blazor-ai-assistview) component to a Blazor Web App using [Visual Studio](https://visualstudio.microsoft.com/vs/) and Visual Studio Code.

{% tabcontents %}

{% tabcontent Visual Studio %}

## Prerequisites

* [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)

## Create a new Blazor Web App in Visual Studio

You can create a **Blazor Web App** using Visual Studio 2022 via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-8.0&pivots=vs) or the [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-integration/template-studio).

When creating the application, configure the appropriate [Interactive render mode](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/render-modes?view=aspnetcore-8.0#render-modes) and [Interactivity location](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-8.0&pivots=vs) to ensure proper behavior of Blazor components.

## Install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor InteractiveChat and Themes NuGet in the App

To add the **Blazor AI AssistView** component, open the NuGet package manager in Visual Studio (*Tools → NuGet Package Manager → Manage NuGet Packages for Solution*), then search for and install `Syncfusion.Blazor.InteractiveChat` and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/).

If you utilize `WebAssembly or Auto` render modes in the Blazor Web App need to be install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components NuGet packages within the client project.

Alternatively, use the following commands in the Package Manager Console:

{% tabs %}
{% highlight C# tabtitle="Package Manager" %}

Install-Package Syncfusion.Blazor.InteractiveChat -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.Themes -Version {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

N> Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components are available on [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). Refer to the [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for a complete list of available packages.

{% endtabcontent %}

{% tabcontent Visual Studio Code %}

## Prerequisites

* [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)

## Create a new Blazor Web App in Visual Studio Code

You can create a **Blazor Web App** using Visual Studio Code via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-8.0&pivots=vsc) or the [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-code-integration/create-project).

When creating the application, you must configure the appropriate [Interactive render mode](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/render-modes?view=aspnetcore-8.0#render-modes) and [Interactivity location](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-8.0&pivots=vsc).

For instance, to create a Blazor Web App with the `Auto` interactive render mode, use the following commands:

{% tabs %}
{% highlight c# tabtitle="Blazor Web App" %}

dotnet new blazor -o BlazorWebApp -int Auto
cd BlazorWebApp
cd BlazorWebApp.Client

{% endhighlight %}
{% endtabs %}

N> For more information on creating a **Blazor Web App** with various interactive modes and locations, refer to this [link](https://blazor.syncfusion.com/documentation/getting-started/blazor-web-app?tabcontent=visual-studio-code#render-interactive-modes).

## Install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor InteractiveChat and Themes NuGet in the App

If you utilize `WebAssembly` or `Auto` render modes in the Blazor Web App need to be install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components NuGet packages within the client project.

* Press <kbd>Ctrl</kbd>+<kbd>`</kbd> to open the integrated terminal in Visual Studio Code.
* Ensure you’re in the project root directory where your `.csproj` file is located.
* Run the following command to install a [Syncfusion.Blazor.InteractiveChat](https://www.nuget.org/packages/Syncfusion.Blazor.InteractiveChat) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/) NuGet package and ensure all dependencies are installed.

{% tabs %}

{% highlight c# tabtitle="Package Manager" %}

dotnet add package Syncfusion.Blazor.InteractiveChat -v {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Themes -v {{ site.releaseversion }}
dotnet restore

{% endhighlight %}

{% endtabs %}

N> Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components are available on [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). Refer to the [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for a complete list of available packages.

{% endtabcontent %}

{% endtabcontents %}

## Register Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Service

First, import the `Syncfusion.Blazor` and `Syncfusion.Blazor.InteractiveChat` namespace.

| Interactive Render Mode | File Location |
|---|---|
| `WebAssembly` or `Auto`  | `~/_Imports.razor` (Client Project) |
| `Server` | `~/Components/_Imports.razor` (Server Project) |

{% tabs %}
{% highlight C# tabtitle="~/_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.InteractiveChat

{% endhighlight %}
{% endtabs %}

Now, register the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Service in the **~/Program.cs** file of your Blazor Web App.

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

## Add Stylesheet and Script Resources

Reference the theme stylesheet and script from the NuGet package using [Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets). Add the stylesheet link in the `<head>` section and the script reference at the end of the `<body>` in the `~/Components/App.razor` file.

```html
<head>
    ....
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
</head>

<body>
    ....
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
</body>
```

N> Check out the [Blazor Themes](https://blazor.syncfusion.com/documentation/appearance/themes) topic to discover various methods ([Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets), [CDN](https://blazor.syncfusion.com/documentation/appearance/themes#cdn-reference), and [CRG](https://blazor.syncfusion.com/documentation/common/custom-resource-generator)) for referencing themes in your Blazor application. Also, check out the [Adding Script Reference](https://blazor.syncfusion.com/documentation/common/adding-script-references) topic to learn different approaches for adding script references.

## Add Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor AI AssistView Component

Add the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor AI AssistView component in the **~Pages/.razor** file. If an interactivity location as `Per page/component` in the web app, define a render mode at the top of the `~Pages/.razor` component, as follows:

| Interactivity Location | RenderMode | Code Snippet |
| --- | --- | --- |
| Per page/component | Auto | `@rendermode InteractiveAuto` |
| | WebAssembly | `@rendermode InteractiveWebAssembly` |
| | Server | `@rendermode InteractiveServer` |
| Global | Not required | --- |

N> If an **Interactivity Location** is set to `Global` and the **Render Mode** is set to `Auto` or `WebAssembly` or `Server`, the render mode is configured in the `App.razor` file by default.

{% tabs %}
{% highlight razor %}

@* desired render mode define here *@
@rendermode InteractiveAuto

{% endhighlight %}
{% endtabs %}

{% tabs %}
{% highlight razor %}

<div class="aiassist-container" style="height: 350px; width: 650px;">
    <SfAIAssistView></SfAIAssistView>
</div>

{% endhighlight %}
{% endtabs %}

* Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to launch the application. The  Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor AI AssistView component will be rendered in your default web browser.

{% previewsample "https://blazorplayground.syncfusion.com/embed/rZrfCjiMCTRHTGzR?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor AI AssistView Component](./images/ai-assistview-component.png)" %}

## Configure Suggestions and Responses

Use the [PromptSuggestions](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.InteractiveChat.SfAIAssistView.html#Syncfusion_Blazor_InteractiveChat_SfAIAssistView_PromptSuggestions) property to define a list of interactive prompts for users. Handle the [PromptRequested](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.InteractiveChat.SfAIAssistView.html#Syncfusion_Blazor_InteractiveChat_SfAIAssistView_PromptRequested) event to provide a custom response when a prompt is submitted. If no matching prompt is found, a default response can be displayed.

{% tabs %}
{% highlight razor %}

<div class="aiassist-container" style="height: 350px; width: 650px;">
    <SfAIAssistView PromptSuggestions="@promptSuggestions" PromptRequested="@PromptRequest"></SfAIAssistView>
</div>

@code {
    List<string> promptSuggestions = new List<string> { "How do I prioritize my tasks?", "How can I improve my time management skills?" };
    public class AssistModel
    {
        public string Prompt { get; set; }
        public string Response { get; set; }
    }
    private List<AssistModel> prompts = new List<AssistModel>()
    {
        new AssistModel() { Prompt = "How do I prioritize my tasks?", Response = "Prioritize tasks by urgency and impact: tackle high-impact tasks first, delegate when possible, and break large tasks into smaller steps. For more assistance, feel free to ask—I’m here to help!" },
        new AssistModel() { Prompt = "How can I improve my time management skills?", Response = "To improve time management skills, try setting clear goals, using a planner or digital tools, prioritizing tasks, breaking tasks into smaller steps, and minimizing distractions. Regularly review and adjust your approach for better efficiency" }
    };
    private async Task PromptRequest(AssistViewPromptRequestedEventArgs args)
    {
        await Task.Delay(3000);
        var isPromptFound = prompts.Any(prompt => prompt.Prompt == args.Prompt);
        var promptData = prompts.FirstOrDefault(prompt => prompt.Prompt == args.Prompt);
        var defaultResponse = "For real-time prompt processing, connect the AI AssistView component to your preferred AI service, such as OpenAI or Azure Cognitive Services. Ensure you obtain the necessary API credentials to authenticate and enable seamless integration.";
        args.Response = isPromptFound ? promptData.Response : defaultResponse;
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BjhTCNsCMKFGRhuU?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor AI AssistView default prompt](./images/default-prompt.png)" %}

N> [View Sample in GitHub](https://github.com/SyncfusionExamples/Blazor-Getting-Started-Examples/tree/main/AIAssistView).