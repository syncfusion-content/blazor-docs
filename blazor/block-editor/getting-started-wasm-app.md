---
layout: post
title: Getting Started with Syncfusion Blazor Block Editor in WASM
description: Get started with Blazor Block Editor in Blazor WebAssembly App using Visual Studio, Visual Studio Code, or .NET CLI.
platform: Blazor
control: BlockEditor
documentation: ug
---

# Getting Started with Blazor Block Editor Component

The Blazor Block Editor is a modular, block-based content editor component that enables rich, structured content creation. It provides an intuitive interface for building documents, articles, and collaborative content using customizable blocks such as headings, paragraphs, lists, and more. The WebAssembly deployment model allows the editor to run entirely in the browser, providing a responsive client-side experience.

This section explains how to integrate the [Blazor Block Editor](https://www.syncfusion.com/blazor-components/blazor-block-editor) component into a Blazor WebAssembly App using [Visual Studio](https://visualstudio.microsoft.com/vs/), [Visual Studio Code](https://code.visualstudio.com/), and the [.NET CLI](https://learn.microsoft.com/en-us/dotnet/core/tools/).

{% tabcontents %}

{% tabcontent Visual Studio %}

## Prerequisites

* [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)

## Create a new Blazor App in Visual Studio

Create a **Blazor WebAssembly App** using Visual Studio via the [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-10.0&pivots=vs) or the [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-integration/template-studio). For detailed instructions, refer to the [Blazor WASM App Getting Started](https://blazor.syncfusion.com/documentation/getting-started/blazor-webassembly-app) documentation.

{% endtabcontent %}

{% tabcontent Visual Studio Code %}

## Prerequisites

* [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)

## Create a new Blazor App in Visual Studio Code

Create a **Blazor WebAssembly App** using Visual Studio Code via the [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-10.0&pivots=vsc) or the [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-code-integration/create-project). For detailed instructions, refer to the [Blazor WASM App Getting Started](https://blazor.syncfusion.com/documentation/getting-started/blazor-webassembly-app?tabcontent=visual-studio-code) documentation.

Alternatively, create a WebAssembly application by using the following command in the integrated terminal (<kbd>Ctrl</kbd>+<kbd>`</kbd>):

{% tabs %}

{% highlight c# tabtitle="Blazor WASM App" %}

dotnet new blazorwasm -o BlazorApp
cd BlazorApp

{% endhighlight %}

{% endtabs %}

{% endtabcontent %}

{% tabcontent .NET CLI %}

## Prerequisites

Install the latest version of [.NET SDK](https://dotnet.microsoft.com/en-us/download). If the .NET SDK is already installed, determine the installed version by running the following command in a command prompt (Windows), terminal (macOS), or command shell (Linux).

{% tabs %}
{% highlight c# tabtitle=".NET CLI" %}

dotnet --version

{% endhighlight %}
{% endtabs %}

## Create a Blazor WebAssembly App using .NET CLI

Run the following command to create a new Blazor WebAssembly App in a command prompt (Windows) or terminal (macOS/Linux). For detailed instructions, refer to the [Blazor WASM App Getting Started](https://blazor.syncfusion.com/documentation/getting-started/blazor-webassembly-app?tabcontent=.net-cli) documentation.

{% tabs %}
{% highlight c# tabtitle=".NET CLI" %}

dotnet new blazorwasm -o BlazorApp
cd BlazorApp

{% endhighlight %}
{% endtabs %}

{% endtabcontent %}

{% endtabcontents %}

### Install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor packages

Install [Syncfusion.Blazor.BlockEditor](https://www.nuget.org/packages/Syncfusion.Blazor.BlockEditor/) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/) NuGet packages into your project.

Alternatively, run the following commands in the Package Manager Console to achieve the same.

{% tabs %}
{% highlight C# tabtitle="Package Manager" %}

Install-Package Syncfusion.Blazor.BlockEditor -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.Themes -Version {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

N> All Syncfusion Blazor packages are available on [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). See the [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for details.

## Add Import Namespaces

After the packages are installed, open the **~/_Imports.razor** file and import the `Syncfusion.Blazor` and `Syncfusion.Blazor.BlockEditor` namespaces.

{% tabs %}
{% highlight C# tabtitle="~/_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.BlockEditor

{% endhighlight %}
{% endtabs %}

## Register Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Service

Register the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Service in the **Program.cs** file of the Blazor WebAssembly App.

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

The theme stylesheet and script can be accessed from NuGet through [Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets). Include the stylesheet and script references in the **~/index.html** file.

```html

<link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
<script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>

```

N> Check out the [Blazor Themes](https://blazor.syncfusion.com/documentation/appearance/themes) topic to discover various methods ([Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets), [CDN](https://blazor.syncfusion.com/documentation/appearance/themes#cdn-reference), and [CRG](https://blazor.syncfusion.com/documentation/common/custom-resource-generator)) for referencing themes in the Blazor application. Also, check out the [Adding Script Reference](https://blazor.syncfusion.com/documentation/common/adding-script-references) topic to learn different approaches for adding script references in the Blazor application.

## Add Blazor Block Editor Component

Add the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Block Editor component in the **~/Pages/Index.razor** file.

{% tabs %}
{% highlight razor %}

<SfBlockEditor></SfBlockEditor>

{% endhighlight %}
{% endtabs %}

* Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to launch the application. This renders the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Block Editor component in the default web browser.

{% previewsample "https://blazorplayground.syncfusion.com/embed/LNLIsrhAgbKCOpbZ?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor BlockEditor Default.](images/blazor-block-editor-default.png)" %}

## Configure blocks

The Block Editor uses a block-based content structure where each block represents a specific content type (heading, paragraph, list, etc.). The [Blocks](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.SfBlockEditor.html#Syncfusion_Blazor_BlockEditor_SfBlockEditor_Blocks) property manages and configures these blocks, allowing full control over the content structure and presentation.

{% tabs %}
{% highlight razor %}

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
                    Properties = new HeadingBlockSettings { Level = 2 },
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/rNBSiBVATWtpaEWo?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor Block Editor Component](images/blazor-block-editor-component.png)" %}

N> [View Sample in GitHub](https://github.com/SyncfusionExamples/Blazor-Getting-Started-Examples/tree/main/BlockEditor)