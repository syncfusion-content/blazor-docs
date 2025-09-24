---
layout: post
title: Getting Stared with Blazor SpeechToText | Syncfusion
description: Checkout and learn about getting started with Blazor SpeechToText in Blazor WASM App using Visual Studio and more.
platform: Blazor
control: SpeechToText
documentation: ug
---

<!-- markdownlint-disable MD040 -->

# Getting Started with Blazor SpeechToText in a Blazor WASM App

This section explains how to add the [Blazor SpeechToText](https://www.syncfusion.com/blazor-components) component to a Blazor WebAssembly application using either Visual Studio or Visual Studio Code.

{% tabcontents %}

{% tabcontent Visual Studio %}

## Prerequisites

* [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)

## Create a new Blazor App in Visual Studio

Create a **Blazor WebAssembly App** in Visual Studio by using either the standard [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-7.0) or the [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-integration/template-studio).

## Install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Inputs NuGet in the App

To add the **Blazor SpeechToText** component to the app, open the NuGet package manager in Visual Studio (*Tools → NuGet Package Manager → Manage NuGet Packages for Solution*), search for and install [Syncfusion.Blazor.Inputs](https://www.nuget.org/packages). Alternatively, use the following package manager command to install it.

{% tabs %}
{% highlight C# tabtitle="Package Manager" %}

Install-Package Syncfusion.Blazor.Inputs -Version {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

N> Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components are available in [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). Refer to [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for available NuGet packages list with component details.

{% endtabcontent %}

{% tabcontent Visual Studio Code %}

## Prerequisites

* [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)

## Create a new Blazor App in Visual Studio Code

Create a **Blazor WebAssembly App** using Visual Studio Code via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-7.0&pivots=vsc) or the [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-code-integration/create-project).

Alternatively, you can create the application using the following command in the terminal(<kbd>Ctrl</kbd>+<kbd>`</kbd>).

{% tabs %}

{% highlight c# tabtitle="Blazor WASM App" %}

dotnet new blazorwasm -o BlazorApp
cd BlazorApp

{% endhighlight %}

{% endtabs %}

## Install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Inputs NuGet in the App

* Press <kbd>Ctrl</kbd>+<kbd>`</kbd> to open the integrated terminal in Visual Studio Code.
* Ensure you’re in the project root directory where your `.csproj` file is located.
* Run the following command to install a [Syncfusion.Blazor.Inputs](https://www.nuget.org/packages/Syncfusion.Blazor.Inputs) NuGet package and ensure all dependencies are installed.

{% tabs %}

{% highlight c# tabtitle="Package Manager" %}

dotnet add package Syncfusion.Blazor.Inputs -v {{ site.releaseversion }}
dotnet restore

{% endhighlight %}

{% endtabs %}

N> Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components are available in [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). Refer to [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for available NuGet packages list with component details.

{% endtabcontent %}

{% endtabcontents %}

## Register Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Service

Open the **~/_Imports.razor** file and add the `Syncfusion.Blazor` namespace.

{% tabs %}
{% highlight razor tabtitle="~/_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Inputs

{% endhighlight %}
{% endtabs %}

Next, register the Syncfusion Blazor Service in the **~/Program.cs** file. This enables the use of Syncfusion components in the application.

{% tabs %}
{% highlight C# tabtitle="Blazor WebAssembly App" hl_lines="3 11" %}

using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Syncfusion.Blazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddSyncfusionBlazor();
await builder.Build().RunAsync();
....

{% endhighlight %}
{% endtabs %}

## Add script references

Reference the script from the NuGet package, which is available as a [Static Web Asset](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets), by adding the following line to the `<head>` section of your main page.

* For a Blazor WebAssembly app, modify the **~/wwwroot/index.html** file.

```html
<head>
    ....
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
</head>
```
N> To learn about other ways to add script references, see the [Adding Script Reference](https://blazor.syncfusion.com/documentation/common/adding-script-references) topic.

## Add Blazor SpeechToText component

Add the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor SpeechToText component to the **~/Pages/Index.razor** file.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Inputs

<div class="speechtext-container">
    <SfSpeechToText @bind-Transcript="@transcript"></SfSpeechToText>
    <SfTextArea RowCount="5" ColumnCount="50" @bind-Value="@transcript" ResizeMode="Resize.None" Placeholder="Transcribed text will be shown here..."></SfTextArea>
</div>

<style>
    .speechtext-container {
        margin: 50px auto;
        gap: 20px;
        display: flex;
        flex-direction: column;
        align-items: center;
    }
</style>

@code {
    string transcript = "";
}

{% endhighlight %}
{% endtabs %}

*   Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to launch the application. The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor SpeechToText component will be rendered in your default web browser.

![Blazor SpeechToText Component](images/getting-started.png)

> The [SpeechToText](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfSpeechToText.html) component requires an internet connection and a browser that supports the [SpeechRecognition](https://developer.mozilla.org/en-US/docs/Web/API/SpeechRecognition) Web Speech API.

## Add button content

Use the [Text](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SpeechToTextButtonSettings.html#Syncfusion_Blazor_Inputs_SpeechToTextButtonSettings_Text) property to display the start listening text and [StopStateText](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SpeechToTextButtonSettings.html#Syncfusion_Blazor_Inputs_SpeechToTextButtonSettings_StopStateText) property to display the stop listening text by using the [ButtonSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfSpeechToText.html#Syncfusion_Blazor_Inputs_SfSpeechToText_ButtonSettings) property.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Inputs

<div class="speechtext-container">
    <SfSpeechToText ButtonSettings="@buttonSettings" @bind-Transcript="@transcript"></SfSpeechToText>
    <SfTextArea RowCount="5" ColumnCount="50" @bind-Value="@transcript" ResizeMode="Resize.None" Placeholder="Transcribed text will be shown here..."></SfTextArea>
</div>

<style>
    .speechtext-container {
        margin: 50px auto;
        gap: 20px;
        display: flex;
        flex-direction: column;
        align-items: center;
    }
</style>

@code {
    string transcript = "";
    SpeechToTextButtonSettings buttonSettings = new SpeechToTextButtonSettings()
    {
        Text = "Start Listening", // Displays when idle
        StopStateText = "Stop Listening" // Displays when speech recognition is active
    };
}

{% endhighlight %}
{% endtabs %}

![Blazor SpeechToText with Button Content Start text](images/btn-content-start.png)
![Blazor SpeechToText with Button Content Stop text](images/btn-content-stop.png)

## See Also

* [Getting Started with Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor for Client-Side in .NET Core CLI](https://blazor.syncfusion.com/documentation/getting-started/blazor-webassembly-dotnet-cli)
* [Getting Started with Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor for Server-Side in Visual Studio](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-visual-studio)
* [Getting Started with Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor for Server-Side in .NET Core CLI](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-dotnet-cli)
