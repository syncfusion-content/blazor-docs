---
layout: post
title: Getting Started with Blazor Mention in Blazor WASM App | Syncfusion
description: Check out and learn about getting started with Blazor Mention component in Blazor WebAssembly Application.
platform: Blazor
control: Mention
documentation: ug
---

# Getting Started with Blazor Mention in Blazor WASM App

This section briefly explains about how to include [Blazor Mention](https://www.syncfusion.com/blazor-components/blazor-mention) component in a Blazor WebAssembly App using [Visual Studio](https://visualstudio.microsoft.com/vs/), [Visual Studio Code](https://code.visualstudio.com/), and the [.NET CLI](https://learn.microsoft.com/en-us/dotnet/core/tools/).

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

Install [Syncfusion.Blazor.DropDowns](https://www.nuget.org/packages/Syncfusion.Blazor.DropDowns/) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/) NuGet packages. All Syncfusion Blazor packages are available on [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). See the [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for details.

{% tabcontents %}

{% tabcontent Visual Studio %}

1. Go to *Tools → NuGet Package Manager → Manage NuGet Packages for Solution*.
2. Search the required NuGet packages (`Syncfusion.Blazor.DropDowns` and `Syncfusion.Blazor.Themes`) and install them.

Alternatively, you can install the same packages using the Package Manager Console with the following commands.

{% tabs %}
{% highlight razor tabtitle="Package Manager Console" %}

Install-Package Syncfusion.Blazor.DropDowns -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.Themes -Version {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

{% endtabcontent %}

{% tabcontent Visual Studio Code %}

Open the terminal and run the following commands.

{% tabs %}
{% highlight razor tabtitle="Terminal" %}

dotnet add package Syncfusion.Blazor.DropDowns -v {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Themes -v {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

{% endtabcontent %}

{% tabcontent .NET CLI %}

Open the command prompt and run the following commands.

{% tabs %}
{% highlight razor tabtitle="Command Prompt" %}

dotnet add package Syncfusion.Blazor.DropDowns -v {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Themes -v {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

{% endtabcontent %}

{% endtabcontents %}

### Add import namespaces

After the packages are installed, open the **~/_Imports.razor** file and import the `Syncfusion.Blazor` and `Syncfusion.Blazor.DropDowns` namespaces.

{% tabs %}
{% highlight C# tabtitle="~/_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.DropDowns

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

### Add Blazor Mention component

Open a Razor file located in the **~/Pages/*Index.razor** and add the [Blazor Mention](https://www.syncfusion.com/blazor-components/blazor-mention) component inside the razor file.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.DropDowns

<SfMention TItem="PersonData" DataSource="@EmailData">
    <TargetComponent>
        <div id="commentsMention" placeHolder="Type @@ and tag user" ></div>
    </TargetComponent>
    <ChildContent>
        <MentionFieldSettings Text="Name"></MentionFieldSettings>
    </ChildContent>
</SfMention>
<style>
    #commentsMention {
        min-height: 100px;
        border: 1px solid #D7D7D7;
        border-radius: 4px;
        padding: 8px;
        font-size: 14px;
        width: 600px;
    }

    div#commentsMention[placeholder]:empty:before {
        content: attr(placeholder);
        color: #555;
    }
</style>
@code {
    public class PersonData
    {
        public string Name { get; set; }
        public string EmailId { get; set; }
        public string EmployeeImage { get; set; }
    }
    List<PersonData> EmailData = new List<PersonData> {
    new PersonData() { Name="Selma Rose", EmployeeImage="7", EmailId="selma@gmail.com" },
    new PersonData() { Name="Russo Kay", EmployeeImage="8", EmailId="russo@gmail.com" },
    new PersonData() { Name="Camden Kate", EmployeeImage="9", EmailId="camden@gmail.com" }
  };
}

{% endhighlight %}
{% endtabs %}

**Run the application**

{% tabcontents %}

{% tabcontent Visual Studio %}

Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to launch the application. The Blazor Mention component will render in your default web browser.

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

{% previewsample "https://blazorplayground.syncfusion.com/embed/VXVTNCAjLjgvQOEF?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor Mention Component](images/blazor-mention.webp)" %}

### Mention target

The `Target` property of the Mention component allows you to specify an element on the page to which the mention element should be attached. This can be useful when you want to display the mention element in a specific location on the page. For example, you might use the `Target` property to attach the mention element to a specific div element or to a specific input field or to a specific textarea field. To specify the target element, you can pass a CSS selector, a DOM element.

In the bellow example, the `Target` property of the Mention component is set to the CSS selector `#mentionTarget`, which matches the textarea element with an id of `mentionTarget`. The mention element will be appended to the textarea element as a child element, allowing the user to select or mention a specific entity within the textarea.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.DropDowns

<textarea id="mentionTarget" placeHolder="Type @@ and tag user"></textarea>

<SfMention TItem="PersonData" Target="#mentionTarget" DataSource="@EmailData">
    <ChildContent>
        <MentionFieldSettings Text="Name"></MentionFieldSettings>
    </ChildContent>
</SfMention>
<style>
    #mentionTarget {
        min-height: 100px;
        border: 1px solid #D7D7D7;
        border-radius: 4px;
        padding: 8px;
        font-size: 14px;
        width: 600px;
    }

    div#mentionTarget[placeholder]:empty:before {
        content: attr(placeholder);
        color: #555;
    }
</style>
@code {
    public class PersonData
    {
        public string Name { get; set; }
        public string EmailId { get; set; }
        public string EmployeeImage { get; set; }
    }
    List<PersonData> EmailData = new List<PersonData> {
    new PersonData() { Name="Selma Rose", EmployeeImage="7", EmailId="selma@gmail.com" },
    new PersonData() { Name="Russo Kay", EmployeeImage="8", EmailId="russo@gmail.com" },
    new PersonData() { Name="Camden Kate", EmployeeImage="9", EmailId="camden@gmail.com" }
  };
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LNrfXCADhtJlNdUr?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor Mention target](images/blazor-mention-target.webp)" %}

### See also

* [Getting Started with Blazor for Client-Side in .NET Core CLI](https://blazor.syncfusion.com/documentation/getting-started/blazor-webassembly-dotnet-cli)
* [Getting Started with Blazor for Server-side in Visual Studio](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-visual-studio)
* [Getting Started with Blazor for Server-Side in .NET Core CLI](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-dotnet-cli)