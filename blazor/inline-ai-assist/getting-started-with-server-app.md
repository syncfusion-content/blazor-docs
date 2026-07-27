---
layout: post
title: Getting Started with Blazor Inline AI Assist Server App | Syncfusion
description: Check out the documentation for getting started with Blazor Inline AI Assist Component in Blazor Server App.
platform: Blazor
control: Inline AI Assist
documentation: ug
---

# Getting Started with Inline AI Assist Component in Blazor Server App

This section briefly explains how to include the [Blazor Inline AI Assist](https://www.syncfusion.com/blazor-components/blazor-inline-ai-assist) component in a Blazor Server App using [Visual Studio](https://visualstudio.microsoft.com/vs/), [Visual Studio Code](https://code.visualstudio.com/), and the [.NET CLI](https://learn.microsoft.com/en-us/dotnet/core/tools/).

## Create a new Blazor Server App 

{% tabcontents %}

{% tabcontent Visual Studio %}

Create a **Blazor Server App** by using the **Blazor Web App** template in Visual Studio via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-10.0&pivots=vs) or the [Syncfusion® Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-integration/template-studio).

{% endtabcontent %}

{% tabcontent Visual Studio Code %}

Run the following command to create a new Blazor Server App.

{% tabs %}
{% highlight razor tabtitle="Terminal" %}

dotnet new blazor -o BlazorApp --interactivity Server
cd BlazorApp

{% endhighlight %}
{% endtabs %}

Alternatively, create a **Blazor Server App** using Visual Studio Code via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-10.0&pivots=vsc) or the [Syncfusion® Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-code-integration/create-project), or the [C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit) extension.

{% endtabcontent %}

{% tabcontent .NET CLI %}

Run the following command to create a new Blazor Server App.

{% tabs %}
{% highlight razor tabtitle="Command Prompt" %}

dotnet new blazor -o BlazorApp --interactivity Server
cd BlazorApp

{% endhighlight %}
{% endtabs %}

{% endtabcontent %}

{% endtabcontents %}

N> Configure the appropriate [Interactive render mode](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/render-modes?view=aspnetcore-10.0#render-modes) and [Interactivity location](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-10.0&pivots=vs) while creating a Blazor Server App. For detailed information, refer to the [interactive render mode documentation](https://blazor.syncfusion.com/documentation/common/interactive-render-mode).

## Install the required Blazor packages

Install the [Syncfusion.Blazor.InteractiveChat](https://www.nuget.org/packages/Syncfusion.Blazor.InteractiveChat/) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/) NuGet packages. All Syncfusion Blazor packages are available on [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). See the [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for details.

{% tabcontents %}

{% tabcontent Visual Studio %}

1. Go to *Tools → NuGet Package Manager → Manage NuGet Packages for Solution*.
2. Search the required NuGet packages (`Syncfusion.Blazor.InteractiveChat` and `Syncfusion.Blazor.Themes`) and install them.

Alternatively, you can install the same packages using the Package Manager Console with the following commands.

{% tabs %}
{% highlight razor tabtitle="Package Manager Console" %}

Install-Package Syncfusion.Blazor.InteractiveChat -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.Themes -Version {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

{% endtabcontent %}

{% tabcontent Visual Studio Code %}

Open the terminal and run the following commands.

{% tabs %}
{% highlight razor tabtitle="Terminal" %}

dotnet add package Syncfusion.Blazor.InteractiveChat -v {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Themes -v {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

{% endtabcontent %}

{% tabcontent .NET CLI %}

Open the command prompt and run the following commands.

{% tabs %}
{% highlight razor tabtitle="Command Prompt" %}

dotnet add package Syncfusion.Blazor.InteractiveChat -v {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Themes -v {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

{% endtabcontent %}

{% endtabcontents %}

## Add import namespaces

After the packages are installed, open the **~/Components/_Imports.razor** file and import the `Syncfusion.Blazor` and `Syncfusion.Blazor.InteractiveChat` namespaces.

{% tabs %}
{% highlight C# tabtitle="_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.InteractiveChat

{% endhighlight %}
{% endtabs %}

## Register the Blazor service

Open the **Program.cs** file in Blazor Server App and register the Blazor service.

{% tabs %}
{% highlight C# tabtitle="Program.cs" %}

....
using Syncfusion.Blazor;
....
builder.Services.AddSyncfusionBlazor();
....

{% endhighlight %}
{% endtabs %}

## Add stylesheet and script resources
 
The theme stylesheet and script can be accessed from NuGet through [Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets). Include the [stylesheet](https://blazor.syncfusion.com/documentation/appearance/themes) and [script references](https://blazor.syncfusion.com/documentation/common/adding-script-references) in the **~/Components/App.razor** file.

{% tabs %}
{% highlight html tabtitle="App.razor" %}

...
<link href="_content/Syncfusion.Blazor.Themes/fluent2.css" rel="stylesheet" />
...
<script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>

{% endhighlight %}
{% endtabs %}

## Add Blazor Inline AI Assist component

Open a Razor file located in the **~/Components/Pages/*.razor** (for example, **Home.razor**) and add the [Blazor Inline AI Assist](https://www.syncfusion.com/blazor-components/blazor-inline-ai-assist) component inside the razor file.

N> If the interactivity location is set to `Per page/component`, define a render mode at the top of the razor file. (For example `InteractiveServer`). If the Interactivity is set to `Global`, the render mode is automatically configured in the `App.razor` file by default.

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

@rendermode InteractiveServer
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
@code 
{
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

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BNrRXQrXKASSLToH?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Blazor Inline AI Assist sample](./images/inline-ai-assist-sample.webp)" %}

## Run the application

{% tabcontents %}

{% tabcontent Visual Studio %}

Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to launch the application. The [Blazor Inline AI Assist](https://www.syncfusion.com/blazor-components/blazor-inline-ai-assist) component will render in your default web browser.

{% endtabcontent %}

{% tabcontent Visual Studio Code %}

Open the terminal and run the following command.

{% tabs %}
{% highlight razor tabtitle="Terminal" %}

dotnet run

{% endhighlight %}
{% endtabs %}

{% endtabcontent %}

{% tabcontent .NET CLI %}

Open the command prompt and run the following command.

{% tabs %}
{% highlight razor tabtitle="Command Prompt" %}

dotnet run

{% endhighlight %}
{% endtabs %}

{% endtabcontent %}

{% endtabcontents %}

## Response display modes

Responses can be shown in two modes: `Inline` (updates content in-place) and `Popup` (shows responses in a floating popup). Toggle this behavior with the `ResponseMode` property.

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

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
@code 
{
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

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/htrdtwBjgTZSOjQm?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Blazor Inline AI Assist response modes](./images/inline-ai-assist-response-modes.webp)" %}

> **Note:** Starting from version 33.1x, when a user submits a prompt to the Inline AI Assist, the component automatically scrolls and focuses on the latest prompt and response. This behavior eliminates the need for users to manually scroll down to see the new response, ensuring they always view the most recent AI response without interruption. Prior to version 33.1x, the previous responses remained visible when new responses were added. 
