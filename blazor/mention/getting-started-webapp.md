---
layout: post
title: Mention Getting started with Blazor Web App Component | Syncfusion
description: Learn here all about Blazor Mention Getting started with Web App in Syncfusion component and more.
platform: Blazor
control: Mention
documentation: ug
---

# Getting started with Blazor Mention Component in Blazor Web App

This section briefly explains about how to include `Blazor Mention` component in your Blazor Web App using [Visual Studio](https://visualstudio.microsoft.com/vs/).

## Prerequisites

* [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)

## Create a new Blazor Web App

You can create a **Blazor Web App** using Visual Studio 2022 via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-8.0) or the [Syncfusion Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-integration/template-studio).

You need to configure the corresponding [Interactive render mode](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/render-modes?view=aspnetcore-8.0#render-modes) and [Interactivity location](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-8.0&pivots=windows) while creating a Blazor Web Application.

## Install Syncfusion Blazor DropDowns and Themes NuGet in the App

To add **Blazor Mention** component in the app, open the NuGet package manager in Visual Studio (*Tools → NuGet Package Manager → Manage NuGet Packages for Solution*), search and install [Syncfusion.Blazor.DropDowns](https://www.nuget.org/packages/Syncfusion.Blazor.DropDowns) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/).

If you utilize `WebAssembly or Auto` render modes in the Blazor Web App need to be install Syncfusion Blazor components NuGet packages within the client project.

Alternatively, you can utilize the following package manager command to achieve the same.

{% tabs %}
{% highlight C# tabtitle="Package Manager" %}

Install-Package Syncfusion.Blazor.DropDowns -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.Themes -Version {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

N> Syncfusion Blazor components are available in [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). Refer to [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for available NuGet packages list with component details.

## Register Syncfusion Blazor Service

Open **~/_Imports.razor** file and import the `Syncfusion.Blazor` and `Syncfusion.Blazor.DropDowns` namespace .

```cshtml

@using Syncfusion.Blazor
@using Syncfusion.Blazor.DropDowns

```

Now, register the Syncfusion Blazor Service in the **~/Program.cs** file of your Blazor Web App.

If you select an **Interactive render mode** as `WebAssembly` or `Auto`, you need to register the Syncfusion Blazor service in both **~/Program.cs** files of your Blazor Web App.

```cshtml

....
using Syncfusion.Blazor;
....
builder.Services.AddSyncfusionBlazor();
....

```

## Add stylesheet and script resources

The theme stylesheet and script can be accessed from NuGet through [Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets). Include the stylesheet reference in the `<head>` section and the script reference at the end of the `<body>` in the **~/Components/App.razor** file as shown below:

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

N> Check out the [Blazor Themes](https://blazor.syncfusion.com/documentation/appearance/themes) topic to discover various methods ([Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets), [CDN](https://blazor.syncfusion.com/documentation/appearance/themes#cdn-reference), and [CRG](https://blazor.syncfusion.com/documentation/common/custom-resource-generator)) for referencing themes in your Blazor application. Also, check out the [Adding Script Reference](https://blazor.syncfusion.com/documentation/common/adding-script-references) topic to learn different approaches for adding script references in your Blazor application.

## Add Syncfusion Blazor Mention component

Add the Syncfusion Blazor Mention component in the **~Pages/.razor** file. If an interactivity location as `Per page/component` in the web app, define a render mode at the top of the `~Pages/.razor` component, as follows:

{% tabs %}
{% highlight razor %}

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

* Press <kbd>ctrl</kbd>+<kbd>F5</kbd> or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to launch the application. This will render the Syncfusion Blazor Mention component in your default web browser.

{% previewsample "https://blazorplayground.syncfusion.com/embed/VXVTNCAjLjgvQOEF?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor Mention Component](images/blazor-mention.png)" %}

N> [View Sample in GitHub](https://github.com/SyncfusionExamples/Blazor-Getting-Started-Examples/tree/main/Mention/BlazorWebApp).

## Mention target

The `Target` property of the Mention component allows you to specify an element on the page to which the mention element should be attached. This can be useful when you want to display the mention element in a specific location on the page. For example, you might use the `Target` property to attach the mention element to a specific div element or to a specific input field or to a specific textarea field. To specify the target element, you can pass a CSS selector, a DOM element.

In the bellow example, the `Target` property of the Mention component is set to the CSS selector `#mentionTarget`, which matches the textarea element with an id of `mentionTarget`. The mention element will be appended to the textarea element as a child element, allowing the user to select or mention a specific entity within the textarea.

{% highlight razor %}

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

{% previewsample "https://blazorplayground.syncfusion.com/embed/LNrfXCADhtJlNdUr?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor Mention target](images/blazor-mention-target.png)" %}

## See also

* [Getting Started with Syncfusion Blazor for Client-Side in .NET Core CLI](https://blazor.syncfusion.com/documentation/getting-started/blazor-webassembly-dotnet-cli)
* [Getting Started with Syncfusion Blazor for Server-side in Visual Studio](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-visual-studio)
* [Getting Started with Syncfusion Blazor for Server-Side in .NET Core CLI](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-dotnet-cli)