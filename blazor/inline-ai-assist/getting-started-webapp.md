---
layout: post
title: Getting started with Inline AI Assist in Blazor Web App | Syncfusion®
description: Check out the documentation for getting started with Blazor Inline AI Assist Components in Blazor Web App.
platform: Blazor
control: Inline AI Assist
documentation: ug
---

# Getting Started with Blazor Inline AI Assist in Blazor Web App

This section briefly explains about how to include Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Inline AI Assist component in a Blazor Web App using [Visual Studio](https://visualstudio.microsoft.com/vs/), [Visual Studio Code](https://code.visualstudio.com/), and the [.NET CLI](https://learn.microsoft.com/en-us/dotnet/core/tools/).

{% tabcontents %}

{% tabcontent Visual Studio %}

## Prerequisites

* [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)

## Create a new Blazor Web App in Visual Studio

Create a **Blazor Web App** using Visual Studio via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-10.0&pivots=vs) or the [Syncfusion® Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-integration/template-studio). For detailed instructions, refer to the [Blazor Web App Getting Started](https://blazor.syncfusion.com/documentation/getting-started/blazor-web-app) documentation.

{% endtabcontent %}

{% tabcontent Visual Studio Code %}

## Prerequisites

* [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)

## Create a new Blazor Web App in Visual Studio Code

Create a **Blazor Web App** using Visual Studio Code via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-10.0&pivots=vsc) or the [Syncfusion® Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-code-integration/create-project). For detailed instructions, refer to the [Blazor Web App Getting Started](https://blazor.syncfusion.com/documentation/getting-started/blazor-web-app?tabcontent=visual-studio-code) documentation.

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

## Install required Blazor packages

Install [Syncfusion.Blazor.InteractiveChat](https://www.nuget.org/packages/Syncfusion.Blazor.InteractiveChat) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/) NuGet packages in your project using the NuGet Package Manager in Visual Studio (*Tools → NuGet Package Manager → Manage NuGet Packages for Solution*), or the integrated terminal in Visual Studio Code (`dotnet add package`), or the .NET CLI.

Alternatively, run the following commands in the Package Manager Console to achieve the same.

{% tabs %}
{% highlight C# tabtitle="Package Manager" %}

Install-Package Syncfusion.Blazor.InteractiveChat -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.Themes -Version {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

If using the `WebAssembly` or `Auto` render modes in the Blazor Web App, install these packages in the client project.

N> All Syncfusion Blazor packages are available on [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). See the [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for details.

## Add import namespaces

After the packages are installed, open the **~/_Imports.razor** file in the client project and import the `Syncfusion.Blazor` and `Syncfusion.Blazor.InteractiveChat` namespaces.

{% tabs %}
{% highlight C# tabtitle="~/_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.InteractiveChat

{% endhighlight %}
{% endtabs %}

## Register Blazor service

Register the Blazor service in the **Program.cs** file of your Blazor Web App.

{% tabs %}
{% highlight c# tabtitle="Program.cs" %}

....
using Syncfusion.Blazor;
....
builder.Services.AddSyncfusionBlazor();
....

{% endhighlight %}
{% endtabs %}

N> If the **Interactive Render Mode** is set to `WebAssembly` or `Auto`, register the Blazor service in **Program.cs** files of both the server and client projects in your Blazor Web App.

## Add stylesheet and script resources

The theme stylesheet and script can be accessed from NuGet through [Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets). Include the stylesheet and script references in the **~/Components/App.razor** file.

```html

<link href="_content/Syncfusion.Blazor.Themes/fluent2.css" rel="stylesheet" />
....
<script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>

```

N> Check out the [Blazor Themes](https://blazor.syncfusion.com/documentation/appearance/themes) topic to discover various methods ([Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets), [CDN](https://blazor.syncfusion.com/documentation/appearance/themes#cdn-reference), and [CRG](https://blazor.syncfusion.com/documentation/common/custom-resource-generator)) for referencing themes in your Blazor application. Also, check out the [Adding Script Reference](https://blazor.syncfusion.com/documentation/common/adding-script-references) topic to learn different approaches for adding script references in your Blazor application.

## Add Blazor Inline AI Assist component

Add the Blazor Inline AI Assist component in the **~/Components/Pages/*.razor** file. If the interactivity location is set to `Per page/component` in the Web App, define a render mode at the top of the `~/Pages/*.razor` file. (For example, `InteractiveServer`, `InteractiveWebAssembly`, or `InteractiveAuto`). Use the `RelateTo` property to position the Inline AI Assist relative to a specific DOM element, and the `Target` property to specify the element where the component should be appended. Both properties accept either a CSS selector string (for example, .container or #id) or an HTMLElement instance.

N> If the **Interactivity Location** is set to `Global` with `Auto` or `WebAssembly`, the render mode is automatically configured in the `App.razor` file by default.

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

```razor
@* desired render mode define here *@
@rendermode InteractiveAuto

@using Syncfusion.Blazor.InteractiveChat

<style>
    #editableText {
        width: 100%;
        min-height: 120px;
        max-height: 300px;
        overflow-y: auto;
        font-size: 16px;
        padding: 12px;
        border-radius: 4px;
        border: 1px solid;
    }
</style>
<div id="container" style="height: 350px; width: 650px;">
    <button id="summarizeButton" style="margin-bottom: 10px;" @onclick="ShowPopup"> Content Summarize </button>
    <div id="editableText" contenteditable="true">
        <p>
            Inline AI Assist component provides intelligent text processing
            capabilities that enhance user productivity. It leverages advanced
            natural language processing to understand context and deliver
            precise suggestions. Users can seamlessly integrate AI-powered
            features into their applications.
        </p>
        <p>
            With real-time response streaming and customizable prompts,
            developers can create interactive experiences. The component
            supports multiple response modes including inline editing and
            popup-based interactions.
        </p>
    </div>
    <SfInlineAIAssist @ref="inlineAssist" RelateTo="#summarizeButton" Target="#container" PromptRequested="PromptRequest">
    </SfInlineAIAssist>
</div>
@code {
    private SfInlineAIAssist inlineAssist = new();
    private async Task PromptRequest(PromptRequestedEventArgs args)
    {
        await Task.Delay(1000);
        string defaultResponse =
            "For real-time prompt processing, connect the Inline AI Assist component to your preferred AI service, such as OpenAI or Azure Cognitive Services. Ensure you obtain the necessary API credentials to authenticate and enable seamless integration.";
        await inlineAssist.UpdateResponseAsync(defaultResponse);
    }
    private async Task ShowPopup()
    {
        await inlineAssist.ShowPopupAsync();
    }
}
```

{% endhighlight %}
{% endtabs %}

{% previewsample "(https://blazorplayground.syncfusion.com/embed/BjhTCNsCMKFGRhuU?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5)" backgroundimage "[Blazor Inline AI Assist sample](./images/inline-ai-assist-sample.webp)" %}

To launch the application, press <kbd>Ctrl</kbd>+<kbd>F5</kbd> in Visual Studio, run `dotnet run` from the CLI or integrated terminal in VS Code, or use the Run command in your preferred IDE to render the Blazor Inline AI Assist component in the default web browser.

## Response display modes

Responses can be shown in two modes: `Inline` (updates content in-place) and `Popup` (shows responses in a floating popup). Toggle this behavior with the `ResponseMode` property.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

```razor
@using Syncfusion.Blazor.InteractiveChat
@using Syncfusion.Blazor.Buttons
<style>
    #editableText {
        width: 100%;
        min-height: 120px;
        max-height: 300px;
        overflow-y: auto;
        font-size: 16px;
        padding: 12px;
        border-radius: 4px;
        border: 1px solid;
    }
</style>
<div class="container" style="height: 350px; width: 650px;">
    <div style="margin-bottom: 10px;">
        <label for="responseMode">Response Mode:</label>
        <select id="responseMode" @onchange="OnResponseModeChangeAsync">
            <option value="Popup">Popup</option>
            <option value="Inline">Inline</option>
        </select>
    </div>
    <SfButton id="summarizeButton" IsPrimary="true" Style="margin-bottom: 10px;" @onclick="OnSummarizeClick">Content Summarize</SfButton>
    <div id="editableText" contenteditable="true">
        @((MarkupString)editableContent)
    </div>
    <SfInlineAIAssist @ref="inlineAssist" ResponseMode="@currentResponseMode" RelateTo="#summarizeButton" PromptRequested="OnPromptRequestAsync"> <ResponseActions ItemSelect="OnItemSelectAsync"></ResponseActions>
    </SfInlineAIAssist>
</div>
@code {
    private SfInlineAIAssist inlineAssist = new SfInlineAIAssist();
    private ResponseDisplayMode currentResponseMode = ResponseDisplayMode.Popup;
    private string editableContent = @"<p>Inline AI Assist component provides intelligent text processing capabilities that enhance user productivity. It leverages advanced natural language processing to understand context and deliver precise suggestions. Users can seamlessly integrate AI-powered features into their applications.</p>
        <p>With real-time response streaming and customizable prompts, developers can create interactive experiences. The component supports multiple response modes including inline editing and popup-based interactions.</p>";
    private async Task OnPromptRequestAsync(PromptRequestedEventArgs args)
    {
        await Task.Delay(1000);
        string defaultResponse = "For real-time prompt processing, connect the Inline AI Assist component to your preferred AI service, such as OpenAI or Azure Cognitive Services. Ensure you obtain the necessary API credentials to authenticate and enable seamless integration.";
        await inlineAssist.UpdateResponseAsync(defaultResponse);
    }
    private async Task OnItemSelectAsync(ResponseItemSelectEventArgs args)
    {
        if (args.Item.Label == "Accept")
        {
            var lastPrompt = inlineAssist?.Prompts.LastOrDefault();
            if (lastPrompt != null && !string.IsNullOrEmpty(lastPrompt.Response))
            {
                editableContent = $"<p>{lastPrompt.Response}</p>";
            }
            await inlineAssist!.HidePopupAsync();
        }
        else if (args.Item.Label == "Discard")
        {
            await inlineAssist!.HidePopupAsync();
        }
    }
    private async Task OnSummarizeClick()
    {
        await inlineAssist.ShowPopupAsync();
    }

    private async Task OnResponseModeChangeAsync(ChangeEventArgs args)
    {
        if (Enum.TryParse<ResponseDisplayMode>(args.Value?.ToString(), out var mode))
        {
            currentResponseMode = mode;
            await InvokeAsync(StateHasChanged);
            await inlineAssist.ShowPopupAsync();
        }
    }
}
```

{% endhighlight %}
{% endtabs %}

{% previewsample "(https://blazorplayground.syncfusion.com/embed/BjhTCNsCMKFGRhuU?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5)" backgroundimage "[Blazor Inline AI Assist response modes](./images/inline-ai-assist-response-modes.webp)" %}

> **Note:** Starting from version 33.1x, when a user submits a prompt to the Inline AI Assist, the component automatically scrolls and focuses on the latest prompt and response. This behavior eliminates the need for users to manually scroll down to see the new response, ensuring they always view the most recent AI response without interruption. Prior to version 33.1x, the previous responses remained visible when new responses were added.
