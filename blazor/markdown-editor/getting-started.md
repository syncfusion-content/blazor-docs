---
layout: post
title: Getting Started Blazor Markdown Editor in Blazor WASM App| Syncfusion
description: Checkout and learn about getting started with the Markdown Editor in Blazor WebAssembly Application.
platform: Blazor
control: MarkdownEditor
documentation: ug
---

<!-- markdownlint-disable MD024 -->

# Getting Started with Blazor Markdown Editor in Blazor WASM App

This section briefly explains about how to include [Blazor Markdown Editor](https://www.syncfusion.com/blazor-components/blazor-rich-text-editor) component in a Blazor WebAssembly App using [Visual Studio](https://visualstudio.microsoft.com/vs/), [Visual Studio Code](https://code.visualstudio.com/), and the [.NET CLI](https://learn.microsoft.com/en-us/dotnet/core/tools/).

N> Explore our [Blazor Markdown Editor](https://blazor.syncfusion.com/demos/markdown-editor/overview?theme=bootstrap5) example to knows how to render and configure the Markdown editor tools.

### Create a new Blazor WASM App

{% tabcontents %}

{% tabcontent Visual Studio %}

Create a **Blazor WebAssembly App** using Visual Studio via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-10.0&pivots=vs) or the [Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-integration/template-studio). For detailed instructions, refer to the [Blazor WebAssembly App Getting Started](https://blazor.syncfusion.com/documentation/getting-started/blazor-webassembly-app) documentation.

{% endtabcontent %}

{% tabcontent Visual Studio Code %}

Run the following command to create a new Blazor WebAssembly App.

{% tabs %}
{% highlight razor tabtitle="Terminal" %}

dotnet new blazorwasm -o BlazorApp

{% endhighlight %}
{% endtabs %}

Alternatively, create a **Blazor WebAssembly App** using Visual Studio Code via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-10.0&pivots=vsc), the [Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-code-integration/create-project), or the [C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit) extension.

{% endtabcontent %}

{% tabcontent .NET CLI %}

Run the following command to create a new Blazor WebAssembly App.

{% tabs %}
{% highlight razor tabtitle="Command Prompt" %}

dotnet new blazorwasm -o BlazorApp

{% endhighlight %}
{% endtabs %}

{% endtabcontent %}

{% endtabcontents %}

### Install the required Blazor packages

Install [Syncfusion.Blazor.RichTextEditor](https://www.nuget.org/packages/Syncfusion.Blazor.RichTextEditor) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes) NuGet packages. All Syncfusion Blazor packages are available on [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). See the [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for details.

{% tabcontents %}

{% tabcontent Visual Studio %}

1. Go to *Tools → NuGet Package Manager → Manage NuGet Packages for Solution*.
2. Search the required NuGet packages (`Syncfusion.Blazor.RichTextEditor` and `Syncfusion.Blazor.Themes`) and install them.

Alternatively, you can install the same packages using the Package Manager Console with the following commands.

{% tabs %}
{% highlight razor tabtitle="Package Manager Console" %}

Install-Package Syncfusion.Blazor.RichTextEditor -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.Themes -Version {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

{% endtabcontent %}

{% tabcontent Visual Studio Code %}

Open the terminal and run the following commands.

{% tabs %}
{% highlight razor tabtitle="Terminal" %}

dotnet add package Syncfusion.Blazor.RichTextEditor -v {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Themes -v {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

{% endtabcontent %}

{% tabcontent .NET CLI %}

Open the command prompt and run the following commands.

{% tabs %}
{% highlight razor tabtitle="Command Prompt" %}

dotnet add package Syncfusion.Blazor.RichTextEditor -v {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Themes -v {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

{% endtabcontent %}

{% endtabcontents %}

### Add import namespaces

After the packages are installed, open the **~/_Imports.razor** file and import the `Syncfusion.Blazor` and `Syncfusion.Blazor.RichTextEditor` namespaces.

{% tabs %}
{% highlight C# tabtitle="~/_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.RichTextEditor

{% endhighlight %}
{% endtabs %}

### Register the Blazor service

Open the **Program.cs** file in Blazor WebAssembly App and register the Blazor service.

{% tabs %}
{% highlight C# tabtitle="Program.cs" %}

....
using Syncfusion.Blazor;
....
builder.Services.AddSyncfusionBlazor();
....

{% endhighlight %}
{% endtabs %}

### Add stylesheet and script resources

The theme stylesheet and script can be accessed from NuGet through [Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets). Include the [stylesheet](https://blazor.syncfusion.com/documentation/appearance/themes) and [script references](https://blazor.syncfusion.com/documentation/common/adding-script-references) in the **~wwwroot/index.html** file.

{% tabs %}
{% highlight html tabtitle="index.html" %}

...
<link href="_content/Syncfusion.Blazor.Themes/fluent2.css" rel="stylesheet" />
...
<script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>

{% endhighlight %}
{% endtabs %}

N> Check out the [Blazor Themes](https://blazor.syncfusion.com/documentation/appearance/themes) topic to discover various methods ([Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets), [CDN](https://blazor.syncfusion.com/documentation/appearance/themes#cdn-reference), and [CRG](https://blazor.syncfusion.com/documentation/common/custom-resource-generator)) for referencing themes in the Blazor application. Also, check out the [Adding Script Reference](https://blazor.syncfusion.com/documentation/common/adding-script-references) topic to learn different approaches for adding script references in the Blazor application.

### Add Blazor Markdown Editor component

Open a Razor file located in the **~/Pages/*Index.razor** and add the [Blazor Markdown Editor](https://www.syncfusion.com/blazor-components/blazor-rich-text-editor) component inside the razor file.

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

@using Syncfusion.Blazor.RichTextEditor

<SfRichTextEditor EditorMode="EditorMode.Markdown" value="@MarkdownValue"></SfRichTextEditor>

@code {
    private string MarkdownValue { get; set; } = @"Rich Text Editor formats text instantly using toolbar actions, whereas Markdown uses syntax to apply formatting. Markdown editing is supported when editorMode is set to **markdown**, allowing formatting via toolbar or keyboard. Custom Markdown syntax can also be added. This sample uses the <b>Marked</b> library to convert Markdown to HTML. [Sample link](https://blazor.syncfusion.com/demos/markdown-editor/overview).";

}

{% endhighlight %}
{% endtabs %}

**Run the application**

{% tabcontents %}

{% tabcontent Visual Studio %}

Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to launch the application. The Blazor Scheduler component will render in your default web browser.

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

{% previewsample "https://blazorplayground.syncfusion.com/embed/LjLxZIVksPOJhmrP?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor Markdown Editor Component](./images/blazor-markdownteditor.webp)" %}

### See also

* [Getting Started with Blazor for webassembly](../getting-started/blazor-webassembly-app)

* [Getting Started with Blazor for client-side in .NET Core CLI](../getting-started/blazor-webassembly-dotnet-cli)

* [Getting Started with Blazor for server-side in .NET Core CLI](../getting-started/blazor-server-side-dotnet-cli)

* [How to insert special characters](https://blazor.syncfusion.com/demos/rich-text-editor/insert-special-characters?theme=bootstrap5)

* [Blog posting using Rich Text Editor](https://blazor.syncfusion.com/demos/rich-text-editor/usecase?theme=bootstrap5)

* [Accessibility in Rich text editor](https://blazor.syncfusion.com/documentation/rich-text-editor/accessibility)

* [Keyboard support in Rich text editor](https://blazor.syncfusion.com/documentation/rich-text-editor/keyboard-support)

* [Globalization in Rich text editor](https://blazor.syncfusion.com/documentation/rich-text-editor/globalization)
