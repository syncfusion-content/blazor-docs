---
layout: post
title: Getting started with Syncfusion TextBox Component in Blazor Web App
description: Check out the documentation for getting started with Syncfusion Blazor TextBox Components in Blazor Web App.
platform: Blazor
control: TextBox
documentation: ug
---

# Getting Started with Blazor TextBox in Blazor Web App

This section explains how to include the [Blazor TextBox](https://www.syncfusion.com/blazor-components/blazor-textbox) component in a Blazor Web App using [Visual Studio](https://visualstudio.microsoft.com/vs/), Visual Studio Code, and the .NET CLI.

{% tabcontents %}

{% tabcontent Visual Studio %}

## Prerequisites

* [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)

## Create a new Blazor Web App in Visual Studio

Create a **Blazor Web App** using Visual Studio 2022 via [Microsoft templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-8.0&pivots=vs) or the [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-integration/template-studio). For detailed instructions, refer to [this Blazor Web App Getting Started](https://blazor.syncfusion.com/documentation/getting-started/blazor-web-app) documentation.

Configure the appropriate [interactive render mode](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/render-modes?view=aspnetcore-8.0#render-modes) and [interactivity location](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-8.0&pivots=vs) when creating the app.

![Create Blazor Web App dialog in Visual Studio](images/blazor-create-web-app.png)

## Install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Inputs and Themes NuGet in the App

To add the TextBox component, open the NuGet Package Manager in Visual Studio (Tools → NuGet Package Manager → Manage NuGet Packages for Solution), then search for and install [Syncfusion.Blazor.Inputs](https://www.nuget.org/packages/Syncfusion.Blazor.Inputs) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/).

If using the WebAssembly or Auto interactive render mode, install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor NuGet packages in the Client project.

Alternatively, use the following Package Manager commands:

{% tabs %}
{% highlight C# tabtitle="Package Manager" %}

Install-Package Syncfusion.Blazor.Inputs -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.Themes -Version {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

N> Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components are available on nuget.org. See the [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) article for the package list and component details.

{% endtabcontent %}

{% tabcontent Visual Studio Code %}

## Prerequisites

* [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)

## Create a new Blazor Web App in Visual Studio Code

Create a **Blazor Web App** using Visual Studio Code via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-8.0&pivots=vsc) or the [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-code-integration/create-project). For detailed instructions, refer to [this Blazor Web App Getting Started](https://blazor.syncfusion.com/documentation/getting-started/blazor-web-app?tabcontent=visual-studio-code) documentation.

Configure the interactive render mode and interactivity location during project setup. For details, see [interactive render mode](https://blazor.syncfusion.com/documentation/common/interactive-render-mode).

For example, with the Auto interactive render mode:

{% tabs %}
{% highlight c# tabtitle="Blazor Web App" %}

dotnet new blazor -o BlazorWebApp -int Auto
cd BlazorWebApp
cd BlazorWebApp.Client

{% endhighlight %}
{% endtabs %}

## Install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Inputs and Themes NuGet in the App

When using WebAssembly or Auto interactive render modes, install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor NuGet packages in the Client project.

* Press <kbd>Ctrl</kbd>+<kbd>`</kbd> to open the integrated terminal in Visual Studio Code.
* Ensure the terminal is in the project root directory that contains the `.csproj` file.
* Run the following commands to install [Syncfusion.Blazor.Inputs](https://www.nuget.org/packages/Syncfusion.Blazor.Inputs) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/), and restore dependencies.

{% tabs %}

{% highlight c# tabtitle="Package Manager" %}

dotnet add package Syncfusion.Blazor.Inputs -v {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Themes -v {{ site.releaseversion }}
dotnet restore

{% endhighlight %}

{% endtabs %}

N> Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components are available on nuget.org. See the [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) article for the package list and component details.

{% endtabcontent %}

{% tabcontent .NET CLI %}

## Prerequisites

Install the latest [.NET SDK](https://dotnet.microsoft.com/en-us/download). To verify the installed version, run the following command in a command prompt (Windows), terminal (macOS), or shell (Linux).

{% tabs %}
{% highlight c# tabtitle=".NET CLI" %}

dotnet --version

{% endhighlight %}
{% endtabs %}

## Create a Blazor Web App using .NET CLI

Run the following command to create a new Blazor Web App. For step-by-step guidance, see the [Blazor Web App getting started](https://blazor.syncfusion.com/documentation/getting-started/blazor-web-app?tabcontent=.net-cli) article.

Configure the interactive render mode and interactivity location during project setup. For details, see [interactive render mode](https://blazor.syncfusion.com/documentation/common/interactive-render-mode).

For example, in a Blazor Web App with `Auto` interactive render mode, use the following commands:

{% tabs %}
{% highlight c# tabtitle=".NET CLI" %}

dotnet new blazor -o BlazorApp -int Auto
cd BlazorApp
cd BlazorApp.Client

{% endhighlight %}
{% endtabs %}

This command creates a new Blazor Web App in a directory named `BlazorApp` in the current location. See [Create a Blazor app](https://dotnet.microsoft.com/en-us/learn/aspnet/blazor-tutorial/create) and [dotnet new CLI](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?pivots=linux-macos&view=aspnetcore-8.0) for more information.

## Install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Inputs and Themes NuGet in the App

To add the TextBox component, run the following commands to install [Syncfusion.Blazor.Inputs](https://www.nuget.org/packages/Syncfusion.Blazor.Inputs/) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/). See [Install and manage packages using the dotnet CLI](https://learn.microsoft.com/en-us/nuget/consume-packages/install-use-packages-dotnet-cli) for more details.

If using WebAssembly or Auto interactive render modes, install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor NuGet packages in the Client project.

{% tabs %}
{% highlight c# tabtitle=".NET CLI" %}

dotnet add package Syncfusion.Blazor.Inputs --version {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Themes --version {{ site.releaseversion }}
dotnet restore

{% endhighlight %}
{% endtabs %}

N> Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components are available on nuget.org. See the [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) article for the package list and component details.

{% endtabcontent %}

{% endtabcontents %}

## Add Import Namespaces

Open the **~/_Imports.razor** file from the client project and import the `Syncfusion.Blazor` and `Syncfusion.Blazor.Inputs` namespaces.

{% tabs %}
{% highlight C# tabtitle="~/_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Inputs

{% endhighlight %}
{% endtabs %}

## Register Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Service

Register the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Service in the **~/Program.cs** file of your Blazor Web App.

If your Blazor Web App uses `WebAssembly` or `Auto` interactive render modes, you must register the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor service in the **~/Program.cs** files of the main `server` project and associated `.Client` project.

{% tabs %}
{% highlight c# tabtitle="Server(~/_Program.cs)" hl_lines="3 11" %}

...
...
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();
builder.Services.AddSyncfusionBlazor();

var app = builder.Build();
....

{% endhighlight %}
{% highlight c# tabtitle="Client(~/_Program.cs)" hl_lines="2 5" %}

...
using Syncfusion.Blazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddSyncfusionBlazor();

await builder.Build().RunAsync();

{% endhighlight %}
{% endtabs %}

## Add stylesheet and script resources

The theme stylesheet and script are provided via [Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets). Add the stylesheet in the <head> and the script at the end of the <body> in Components/App.razor as shown below. Use a single theme file (for example, bootstrap5, material, or tailwind).

```html
<head>
    ....
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
</head>

<body>
    ....
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>

    //Blazor TextBox Component script reference.
    <!-- <script src="_content/Syncfusion.Blazor.Inputs/scripts/sf-textbox.min.js" type="text/javascript"></script> -->
</body>
```

N> See [Blazor themes](https://blazor.syncfusion.com/documentation/appearance/themes) for theme options and delivery methods ([Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets), [CDN](https://blazor.syncfusion.com/documentation/appearance/themes#cdn-reference), and [CRG](https://blazor.syncfusion.com/documentation/common/custom-resource-generator)). For adding scripts, see [Adding script references](https://blazor.syncfusion.com/documentation/common/adding-script-references). If styles or scripts do not appear, build/restore the solution and verify static web assets are available.

## Add Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor TextBox component

Add the TextBox component to a Razor page under the Pages folder (for example, Pages/Home.razor) in either the Server or Client project. If the interactivity location is Per page/component, define a render mode at the top of the component as shown:

| Interactivity location | RenderMode | Code |
| --- | --- | --- |
| Per page/component | Auto | @rendermode InteractiveAuto |
|  | WebAssembly | @rendermode InteractiveWebAssembly |
|  | None | --- |

N> If the interactivity location is set to Global and the render mode is Auto or WebAssembly, the render mode is configured in App.razor by default.

{% tabs %}
{% highlight razor %}

@* desired render mode define here *@
@rendermode InteractiveAuto

{% endhighlight %}
{% endtabs %}

{% tabs %}
{% highlight razor %}

<SfTextBox Placeholder='First Name'></SfTextBox>

{% endhighlight %}
{% endtabs %}

* Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to run the app. The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor TextBox renders in the default web browser.

{% previewsample "https://blazorplayground.syncfusion.com/embed/rjrJZMAtTozPjvlK?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor TextBox Component](./images/blazor-textbox.png)" %}

N> [View Sample in GitHub](https://github.com/SyncfusionExamples/Blazor-Getting-Started-Examples/tree/main/TextBox/BlazorWebApp).

## Adding icons to the Blazor TextBox

Add an icon to the TextBox using the [AddIconAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfTextBox.html#Syncfusion_Blazor_Inputs_SfTextBox_AddIconAsync_System_String_System_String_System_Collections_Generic_Dictionary_System_String_System_Object__) method. The following example shows how to append an icon.

```cshtml
@using Syncfusion.Blazor.Inputs

<div id="sample" style="margin:130px auto;width:300px">
    <SfTextBox @ref=@TextBoxDropDownObj
               Created="@AddDateIcon"
               Placeholder="Enter Date"
               FloatLabelType="@FloatLabelType.Auto">
    </SfTextBox>
</div>


@code {
    SfTextBox TextBoxDropDownObj { get; set; }

    private async void AddDateIcon()
    {
        if (TextBoxDropDownObj != null)
        {
            //Add icon to the TextBox
            await TextBoxDropDownObj.AddIconAsync("append", "e-icons e-date-icon");
}
    }
}
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/VXryXaVqqmBfrsXR?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor TextBox with Icon](./images/blazor-textbox-icons.png)" %}

## Floating label

The floating label moves the label above the TextBox when the control is focused or contains a value. Enable the floating label by setting the [FloatLabelType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfTextBox.html#Syncfusion_Blazor_Inputs_SfTextBox_FloatLabelType) property.

{% tabs %}
{% highlight razor %}

<SfTextBox Placeholder='First Name' FloatLabelType='@FloatLabelType.Auto'></SfTextBox>

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LjLTZWUjzeHZgdPK?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor TextBox with Floating Label](./images/blazor-textbox-float-label.png)" %}

## See Also

* [Getting Started with Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Web Assembly App in Visual Studio or .NET CLI](../getting-started/blazor-webassembly-app)
* [Getting Started with Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Web App in Visual Studio or .NET CLI](../getting-started/blazor-web-app)