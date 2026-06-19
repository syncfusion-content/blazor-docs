---
layout: post
title: Getting Started with Blazor Kanban in Blazor WASM App | Syncfusion
description: Checkout and learn about getting started with Blazor Kanban component in Blazor WebAssembly Application.
platform: Blazor
control: Kanban
documentation: ug
---

<!-- markdownlint-disable MD024 -->

# Getting Started with Blazor Kanban in Blazor WASM App

This guide briefly explains about how to include [Blazor Kanban](https://www.syncfusion.com/blazor-components/blazor-kanban-board) component in a Blazor WebAssembly App using [Visual Studio](https://visualstudio.microsoft.com/vs/), [Visual Studio Code](https://code.visualstudio.com/), and the [.NET CLI](https://learn.microsoft.com/en-us/dotnet/core/tools/).

> **Ready to streamline your Blazor development?** <br/>Discover the full potential of Blazor components with AI Coding Assistants. Effortlessly integrate, configure, and enhance your projects with intelligent, context-aware code suggestions, streamlined setups, and real-time insights—all seamlessly integrated into your preferred AI-powered IDEs like VS Code, Cursor, CodeStudio and more. [Explore AI Coding Assistants](https://blazor.syncfusion.com/documentation/ai-coding-assistant/overview)

## Create a new Blazor WebAssembly (Standalone) App

{% tabcontents %}

{% tabcontent Visual Studio %}

Create a **Blazor WebAssembly App** using Visual Studio via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-10.0&pivots=vs) or the [Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-integration/template-studio).

{% endtabcontent %}

{% tabcontent Visual Studio Code %}

Run the following command to create a new Blazor WebAssembly App.

{% tabs %}
{% highlight razor tabtitle="Terminal" %}

dotnet new blazorwasm -o BlazorApp

{% endhighlight %}
{% endtabs %}

Alternatively, create a **Blazor WebAssembly App** using Visual Studio Code via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-10.0&pivots=vsc) or the [Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-code-integration/create-project), or the [C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit) extension.

{% endtabcontent %}

{% tabcontent .NET CLI %}

Run the following command to create a new Blazor WebAssembly App.

{% tabs %}
{% highlight razor tabtitle="Command Prompt" %}

dotnet new blazorwasm -o BlazorApp
cd BlazorApp

{% endhighlight %}
{% endtabs %}

{% endtabcontent %}

{% endtabcontents %}

## Install the required Blazor packages

Install the [Syncfusion.Blazor.Kanban](https://www.nuget.org/packages/Syncfusion.Blazor.Kanban/) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/) NuGet packages. All Syncfusion Blazor packages are available on [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). See the [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for details.

{% tabcontents %}

{% tabcontent Visual Studio %}

1. Go to *Tools → NuGet Package Manager → Manage NuGet Packages for Solution*.
2. Search the required NuGet packages (`Syncfusion.Blazor.Kanban` and `Syncfusion.Blazor.Themes`) and install them.

Alternatively, you can install the same packages using the Package Manager Console with the following commands.

{% tabs %}
{% highlight razor tabtitle="Package Manager Console" %}

Install-Package Syncfusion.Blazor.Kanban -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.Themes -Version {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

{% endtabcontent %}

{% tabcontent Visual Studio Code %}

Open the terminal and run the following commands.

{% tabs %}
{% highlight razor tabtitle="Terminal" %}

dotnet add package Syncfusion.Blazor.Kanban -v {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Themes -v {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

{% endtabcontent %}

{% tabcontent .NET CLI %}

Open the command prompt and run the following commands.

{% tabs %}
{% highlight razor tabtitle="Command Prompt" %}

dotnet add package Syncfusion.Blazor.Kanban -v {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Themes -v {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

{% endtabcontent %}

{% endtabcontents %}

## Register the Blazor service

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

## Add stylesheet and script resources

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

## Add Blazor Kanban component

Open a Razor file located in the **~/Pages/*.razor** (for example, **Home.razor**) and add the [Blazor Kanban](https://www.syncfusion.com/blazor-components/blazor-kanban-board) component inside the razor file.

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

@using Syncfusion.Blazor.Kanban

<SfKanban TValue="TasksModel" KeyField="Status" DataSource="Tasks">
    <KanbanColumns>
        <KanbanColumn HeaderText="To Do" KeyField="@(new List<string>() {"Open"})"></KanbanColumn>
        <KanbanColumn HeaderText="In Progress" KeyField="@(new List<string>() {"InProgress"})"></KanbanColumn>
        <KanbanColumn HeaderText="Testing" KeyField="@(new List<string>() {"Testing"})"></KanbanColumn>
        <KanbanColumn HeaderText="Done" KeyField="@(new List<string>() {"Close"})"></KanbanColumn>
    </KanbanColumns>
    <KanbanCardSettings HeaderField="Title" ContentField="Summary"></KanbanCardSettings>
</SfKanban>

@code {
    public class TasksModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Status { get; set; }
        public string Summary { get; set; }
    }

    public List<TasksModel> Tasks = new List<TasksModel>()
    {
        new TasksModel { Id = "Task 1", Title = "BLAZ-29001", Status = "Open", Summary = "Analyze the new requirements gathered from the customer." },
        new TasksModel { Id = "Task 2", Title = "BLAZ-29002", Status = "Open", Summary = "Show the retrieved data from the server in grid control." },
        new TasksModel { Id = "Task 3", Title = "BLAZ-29003", Status = "InProgress", Summary = "Improve application performance" },
        new TasksModel { Id = "Task 4", Title = "BLAZ-29004", Status = "Testing", Summary = "Fix the issues reported by the customer." },
        new TasksModel { Id = "Task 5", Title = "BLAZ-29005", Status = "Testing", Summary = "Fix the issues reported in Safari browser." },
        new TasksModel { Id = "Task 6", Title = "BLAZ-29006", Status = "Close", Summary = "Analyze SQL server 2008 connection." },
        new TasksModel { Id = "Task 7", Title = "BLAZ-29007", Status = "Close", Summary = "Analyze grid control." },
        new TasksModel { Id = "Task 8", Title = "BLAZ-29008", Status = "Close", Summary = "Stored procedure for initial data binding of the grid." }
    };
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BZrxteMFgkJuRQhn?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

**Run the application**

{% tabcontents %}

{% tabcontent Visual Studio %}

Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to launch the application. The Blazor Kanban component will render in your default web browser.

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

N> You can also explore our [Blazor Kanban Board example](https://blazor.syncfusion.com/demos/kanban/overview?theme=bootstrap5) that shows you how to render and configure the Kanban Board.

## See also

* [Getting Started with Blazor for client-side in .NET Core CLI](../getting-started/blazor-webassembly-app)

* [Getting Started with Blazor for server-side in Visual Studio](../getting-started/blazor-server-side-visual-studio)

* [Getting Started with Blazor for server-side in .NET Core CLI](../getting-started/blazor-web-app)
