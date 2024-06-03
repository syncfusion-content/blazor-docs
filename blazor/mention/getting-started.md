---
layout: post
title: Getting Started with Blazor Mention Component | Syncfusion
description: Checkout and learn about getting started with Blazor Mention component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: Mention
documentation: ug
---

# Getting Started with Blazor Mention Component

This section briefly explains about how to include `Blazor Mention` component in your Blazor Server App and Blazor WebAssembly App using Visual Studio.

To get started quickly with Blazor Mention, check on the following video:

{% youtube
"youtube:https://www.youtube.com/watch?v=5Jdi2AfZKC8"%}

## Prerequisites

* [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)

## Create a new Blazor App in Visual Studio

You can create a **Blazor Server App** or **Blazor WebAssembly App** using Visual Studio via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-7.0) or the [Syncfusion Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-integration/template-studio).

## Install Syncfusion Blazor DropDowns and Themes NuGet in the App

To add **Blazor Mention** component in the app, open the NuGet package manager in Visual Studio (*Tools → NuGet Package Manager → Manage NuGet Packages for Solution*), search and install [Syncfusion.Blazor.DropDowns](https://www.nuget.org/packages/Syncfusion.Blazor.DropDowns) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/). Alternatively, you can utilize the following package manager command to achieve the same.

{% tabs %}
{% highlight C# tabtitle="Package Manager" %}

Install-Package Syncfusion.Blazor.DropDowns -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.Themes -Version {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

N> Syncfusion Blazor components are available in [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). Refer to [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for available NuGet packages list with component details.

## Register Syncfusion Blazor Service

Open **~/_Imports.razor** file and import the `Syncfusion.Blazor` and `Syncfusion.Blazor.DropDowns` namespace.

{% tabs %}
{% highlight razor tabtitle="~/_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.DropDowns

{% endhighlight %}
{% endtabs %}

Now, register the Syncfusion Blazor Service in the **~/Program.cs** file of your Blazor Server App or Blazor WebAssembly App.

{% tabs %}
{% highlight C# tabtitle="Blazor Server App" hl_lines="3 10" %}

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSyncfusionBlazor();

var app = builder.Build();
....

{% endhighlight %}
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

## Add stylesheet and script resources

The theme stylesheet and script can be accessed from NuGet through [Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets). Reference the stylesheet and script in the `<head>` of the main page as follows:

* For **.NET 6** Blazor Server app, include it in **~/Pages/_Layout.cshtml** file.

* For **.NET 7** Blazor Server app, include it in the **~/Pages/_Host.cshtml** file.

* For Blazor WebAssembly app, include it in the **~/index.html** file.

```html
<head>
    ....
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
</head>
```
N> Check out the [Blazor Themes](https://blazor.syncfusion.com/documentation/appearance/themes) topic to discover various methods ([Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets), [CDN](https://blazor.syncfusion.com/documentation/appearance/themes#cdn-reference), and [CRG](https://blazor.syncfusion.com/documentation/common/custom-resource-generator)) for referencing themes in your Blazor application. Also, check out the [Adding Script Reference](https://blazor.syncfusion.com/documentation/common/adding-script-references) topic to learn different approaches for adding script references in your Blazor application.

## Add Syncfusion Blazor Mention component

Add the Syncfusion Blazor Mention component in the **~/Pages/Index.razor** file.

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
