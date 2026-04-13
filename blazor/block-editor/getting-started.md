---
layout: post
title: Getting Started with Syncfusion Blazor Block Editor
description: Learn how to get started with the Blazor Block Editor component in Blazor Web App using Visual Studio, Visual Studio Code, or the .NET CLI.
platform: Blazor
control: BlockEditor
documentation: ug
---

# Getting Started with Blazor Block Editor in Blazor Web App

The Blazor Block Editor is a modular, block-based content editor component that enables rich, structured content creation. It provides an intuitive interface for building documents, articles, and collaborative content using customizable blocks such as headings, paragraphs, lists, and more.

This section explains how to integrate the [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Block Editor](https://www.syncfusion.com/blazor-components/blazor-block-editor) component into a Blazor Web App using [Visual Studio](https://visualstudio.microsoft.com/vs/), [Visual Studio Code](https://code.visualstudio.com/), and the [.NET CLI](https://learn.microsoft.com/en-us/dotnet/core/tools/).

{% tabcontents %}

{% tabcontent Visual Studio %}

## Prerequisites

* [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)

## Create a new Blazor Web App in Visual Studio

Create a **Blazor Web App** using Visual Studio via the [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-10.0&pivots=vs) or the [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-integration/template-studio). For detailed instructions, refer to the [Blazor Web App Getting Started](https://blazor.syncfusion.com/documentation/getting-started/blazor-web-app) documentation.

{% endtabcontent %}

{% tabcontent Visual Studio Code %}

## Prerequisites

* [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)

## Create a new Blazor Web App in Visual Studio Code

Create a **Blazor Web App** using Visual Studio Code via the [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-10.0&pivots=vsc) or the [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-code-integration/create-project). For detailed instructions, refer to the [Blazor Web App Getting Started](https://blazor.syncfusion.com/documentation/getting-started/blazor-web-app?tabcontent=visual-studio-code) documentation.

For example, in a Blazor Web App with the `Auto` interactive render mode, use the following commands in the integrated terminal (<kbd>Ctrl</kbd>+<kbd>`</kbd>).

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

Install the latest version of [.NET SDK](https://dotnet.microsoft.com/en-us/download). If you previously installed the SDK, you can determine the installed version by executing the following command in a command prompt (Windows) or terminal (macOS) or command shell (Linux).

{% tabs %}
{% highlight c# tabtitle=".NET CLI" %}

dotnet --version

{% endhighlight %}
{% endtabs %}

## Create a Blazor Web App using .NET CLI

Run the following command to create a new Blazor Web App in a command prompt (Windows) or terminal (macOS/Linux). For detailed instructions, refer to the [Blazor Web App Getting Started](https://blazor.syncfusion.com/documentation/getting-started/blazor-web-app?tabcontent=.net-cli) documentation.

For example, in a Blazor Web App with the `Auto` interactive render mode, use the following commands:

{% tabs %}
{% highlight c# tabtitle="Blazor Web App" %}

dotnet new blazor -o BlazorWebApp -int Auto
cd BlazorWebApp
cd BlazorWebApp.Client

{% endhighlight %}
{% endtabs %}

This command creates a new Blazor Web App and places it in a new directory called `BlazorWebApp` inside the current location. See the [Create a Blazor App](https://dotnet.microsoft.com/en-us/learn/aspnet/blazor-tutorial/create) and [dotnet new CLI command](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?pivots=cli&view=aspnetcore-10.0) topics for more details.

{% endtabcontent %}

{% endtabcontents %}

N> Configure the appropriate [Interactive render mode](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/render-modes?view=aspnetcore-10.0#render-modes) and [Interactivity location](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-10.0&pivots=vs) while creating a Blazor Web App. For detailed information, refer to the [interactive render mode documentation](https://blazor.syncfusion.com/documentation/common/interactive-render-mode).

### Install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor packages

Install [Syncfusion.Blazor.BlockEditor](https://www.nuget.org/packages/Syncfusion.Blazor.BlockEditor/) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/) NuGet packages in your project using the NuGet Package Manager in Visual Studio (*Tools → NuGet Package Manager → Manage NuGet Packages for Solution*), or the integrated terminal in Visual Studio Code (`dotnet add package`), or the .NET CLI.

Alternatively, run the following commands in the Package Manager Console to achieve the same.

{% tabs %}
{% highlight C# tabtitle="Package Manager" %}

Install-Package Syncfusion.Blazor.BlockEditor -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.Themes -Version {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

If using the `WebAssembly` or `Auto` render modes in the Blazor Web App, install these packages in the client project.

N> All Syncfusion Blazor packages are available on [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). See the [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for details.

## Add import namespaces

After the packages are installed, open the **~/_Imports.razor** file in the client project and import the `Syncfusion.Blazor` and `Syncfusion.Blazor.BlockEditor` namespaces.

{% tabs %}
{% highlight C# tabtitle="~/_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.BlockEditor

{% endhighlight %}
{% endtabs %}

## Register Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor service

Register the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor service in the **Program.cs** file of your Blazor Web App.

{% tabs %}
{% highlight c# tabtitle="Program.cs" %}

....
using Syncfusion.Blazor;
....
builder.Services.AddSyncfusionBlazor();
....

{% endhighlight %}
{% endtabs %}

## Add stylesheet and script resources

The theme stylesheet and script can be accessed from NuGet through [Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets). Include the stylesheet and script references in the **~/Components/App.razor** file.

```html

<link href="_content/Syncfusion.Blazor.Themes/fluent2.css" rel="stylesheet" />
....
<script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>

```

N> Check out the [Blazor Themes](https://blazor.syncfusion.com/documentation/appearance/themes) topic to discover various methods ([Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets), [CDN](https://blazor.syncfusion.com/documentation/appearance/themes#cdn-reference), and [CRG](https://blazor.syncfusion.com/documentation/common/custom-resource-generator)) for referencing themes in the Blazor application. Also, check out the [Adding Script Reference](https://blazor.syncfusion.com/documentation/common/adding-script-references) topic to learn different approaches for adding script references in the Blazor application.

## Add Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Block Editor component

Add the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Block Editor component in the **~/Components/Pages/*.razor** file. If the interactivity location is set to `Per page/component` in the Web App, define a render mode at the top of the `~Pages/*.razor` file. (For example, `InteractiveServer`, `InteractiveWebAssembly` or `InteractiveAuto`).

N> If the **Interactivity Location** is set to `Global` with `Auto` or `WebAssembly`, the render mode is automatically configured in the `App.razor` file by default.

{% tabs %}
{% highlight razor %}

@* Define desired render mode here *@
@rendermode InteractiveAuto

{% endhighlight %}
{% endtabs %}

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

<SfBlockEditor></SfBlockEditor>

{% endhighlight %}
{% endtabs %}

* Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to launch the application. This renders the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Block Editor component in the default web browser.

{% previewsample "https://blazorplayground.syncfusion.com/embed/LNLIsrhAgbKCOpbZ?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor BlockEditor Default.](images/blazor-block-editor-default.webp)" %}

## Configure blocks

The Block Editor uses a block-based content structure where each block represents a specific content type (heading, paragraph, list, etc.). The [Blocks](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.SfBlockEditor.html#Syncfusion_Blazor_BlockEditor_SfBlockEditor_Blocks) property manages and configures these blocks, allowing full control over the content structure and presentation.

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

<SfBlockEditor @bind-Blocks="blockDataOverview">
</SfBlockEditor>

@code {
    private List<BlockModel> blockDataOverview = new EditorBlockData().GetBlockDataOverview();

    public class EditorBlockData
    {
        public List<BlockModel> GetBlockDataOverview()
        {
            List<BlockModel> blockDataOverview = new List<BlockModel>
            {
                new BlockModel
                {
                    BlockType = BlockType.Heading,
                    Properties = new HeadingBlockSettings{ Level=2 },
                    Content =
                    {
                        new ContentModel
                        {
                            ContentType = ContentType.Text,
                            Content = "Getting Started with Block Editor"
                        }
                    }
                },
                new BlockModel
                {
                    BlockType = BlockType.Paragraph,
                    Content =
                    {
                        new ContentModel { ContentType = ContentType.Text, Content = "Welcome to" },
                        new ContentModel { ContentType = ContentType.Text, Content = " Block Editor", Properties = new TextContentSettings { Styles = new StyleModel { Bold = true } } },
                        new ContentModel { ContentType = ContentType.Text, Content = " - your flexible, modular workspace for creating rich, structured content. Whether you're drafting documents, brainstorming ideas, or collaborating with your team, Block Editor makes it simple and intuitive." }
                    }
                },
                new BlockModel { BlockType = BlockType.Paragraph, Content = new List<ContentModel>() }
            };
            return blockDataOverview;
        }
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rNBSiBVATWtpaEWo?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor Block Editor Component](images/blazor-block-editor-component.webp)" %}

N> [View Sample in GitHub](https://github.com/SyncfusionExamples/Blazor-Getting-Started-Examples/tree/main/BlockEditor)