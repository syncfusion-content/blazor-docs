---
layout: post
title: Getting Started with the Predefined Dialogs in Blazor | Syncfusion
description: Check out and learn about getting started with the predefined dialogs in the Blazor WebAssembly Application.
platform: Blazor
control: Predefined Dialogs
documentation: ug
---

# Getting Started with Predefined Dialogs in Blazor

This section explains how to include predefined dialogs in a Blazor WebAssembly app using Visual Studio and Visual Studio Code.

{% tabcontents %}

{% tabcontent Visual Studio %}

## Prerequisites

* [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)

## Create a new Blazor App in Visual Studio

Create a **Blazor WebAssembly App** using Visual Studio via [Microsoft templates](https://learn.microsoft.com/aspnet/core/blazor/tooling?pivots=vs) or the [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor extension](https://blazor.syncfusion.com/documentation/visual-studio-integration/template-studio).

## Install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Popups and Themes NuGet in the App

To add the Blazor predefined dialog component, open the NuGet Package Manager in Visual Studio (Tools → NuGet Package Manager → Manage NuGet Packages for Solution), then search for and install [Syncfusion.Blazor.Popups](https://www.nuget.org/packages/Syncfusion.Blazor.Popups) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/). Alternatively, use the following Package Manager commands:

{% tabs %}
{% highlight C# tabtitle="Package Manager" %}

Install-Package Syncfusion.Blazor.Popups -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.Themes -Version {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

N> Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components are available on NuGet. Refer to the [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for the list of available packages and component details. A valid Syncfusion license must be registered in the application. For guidance, see the licensing overview in the Syncfusion documentation.

{% endtabcontent %}

{% tabcontent Visual Studio Code %}

## Prerequisites

* [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)

## Create a new Blazor App in Visual Studio Code

Create a **Blazor WebAssembly App** using Visual Studio Code via [Microsoft templates](https://learn.microsoft.com/aspnet/core/blazor/tooling?pivots=vsc) or the [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor extension](https://blazor.syncfusion.com/documentation/visual-studio-code-integration/create-project).

Alternatively, create a WebAssembly application using the following commands in the terminal(<kbd>Ctrl</kbd>+<kbd>`</kbd>).

{% tabs %}

{% highlight c# tabtitle="Blazor WASM App" %}

dotnet new blazorwasm -o BlazorApp
cd BlazorApp

{% endhighlight %}

{% endtabs %}

## Install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Popups and Themes NuGet in the App

* Press <kbd>Ctrl</kbd>+<kbd>`</kbd> to open the integrated terminal in Visual Studio Code.
* Ensure the terminal is in the project root directory where the `.csproj` file is located.
* Run the following commands to install the [Syncfusion.Blazor.Popups](https://www.nuget.org/packages/Syncfusion.Blazor.Popups) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/) packages and restore dependencies.

{% tabs %}

{% highlight c# tabtitle="Package Manager" %}

dotnet add package Syncfusion.Blazor.Popups -v {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Themes -v {{ site.releaseversion }}
dotnet restore

{% endhighlight %}

{% endtabs %}

N> Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components are available on NuGet. Refer to the [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for the list of available packages and component details. A valid Syncfusion license must be registered in the application. For guidance, see the licensing overview in the Syncfusion documentation.

{% endtabcontent %}

{% endtabcontents %}

## Register Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Service and Syncfusion<sup style="font-size:70%">&reg;</sup> Dialog Service

Open **~/_Imports.razor** and import the `Syncfusion.Blazor` and `Syncfusion.Blazor.Popups` namespaces.

{% tabs %}
{% highlight razor tabtitle="~/_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Popups

{% endhighlight %}
{% endtabs %}

Now, register the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor service in the **~/Program.cs** file of the Blazor WebAssembly app.

{% tabs %}
{% highlight C# tabtitle="~/Program.cs" hl_lines="1 2 7 8" %}

using Syncfusion.Blazor
using Syncfusion.Blazor.Popups

// Add services to the container.

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<SfDialogService>();
builder.Services.AddSyncfusionBlazor();
await builder.Build().RunAsync();
....

{% endhighlight %}
{% endtabs %}

## Add stylesheet and script resources

The theme stylesheet and script are provided by NuGet through [Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets). Include the stylesheet and script references in the `<head>` section of **~/wwwroot/index.html**.

```html
<head>
    ....
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
</head>
```
N> See [Blazor Themes](https://blazor.syncfusion.com/documentation/appearance/themes) to explore different methods ([Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets), [CDN](https://blazor.syncfusion.com/documentation/appearance/themes#cdn-reference), and [CRG](https://blazor.syncfusion.com/documentation/common/custom-resource-generator)) for referencing themes in a Blazor application. Also, see [Adding Script Reference](https://blazor.syncfusion.com/documentation/common/adding-script-references) for approaches to include script references.

## Add Blazor Dialog Provider

`SfDialogProvider` opens predefined dialogs based on `SfDialogService` settings from anywhere in the application. Add `SfDialogProvider` in `MainLayout.razor` or in a specific page, but include it only once in the app. When added to `MainLayout.razor`, predefined dialogs can be opened from anywhere in the application. When added to a specific page, dialogs can be opened only within that page.

* Now, add `SfDialogProvider` in the **~/_MainLayout.razor** file.

{% tabs %}
{% highlight razor tabtitle=".NET 8 (~/_MainLayout.razor)" %}

<Syncfusion.Blazor.Popups.SfDialogProvider/>

{% endhighlight %}
{% endtabs %}

## Open Predefined Dialog

After adding `SfDialogService` and `SfDialogProvider`, open predefined dialogs from anywhere in the application using [AlertAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.SfDialogService.html#Syncfusion_Blazor_Popups_SfDialogService_AlertAsync_System_String_System_String_Syncfusion_Blazor_Popups_DialogOptions_), [ConfirmAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.SfDialogService.html#Syncfusion_Blazor_Popups_SfDialogService_ConfirmAsync_System_String_System_String_Syncfusion_Blazor_Popups_DialogOptions_), or [PromptAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.SfDialogService.html#Syncfusion_Blazor_Popups_SfDialogService_PromptAsync_System_String_System_String_Syncfusion_Blazor_Popups_DialogOptions_) methods in [SfDialogService](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.SfDialogService.html).

### Show alert dialog

An alert dialog is used to display errors, warnings, or informational messages that require user acknowledgment. This is achieved using the [DialogService.AlertAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.SfDialogService.html#Syncfusion_Blazor_Popups_SfDialogService_AlertAsync_System_String_System_String_Syncfusion_Blazor_Popups_DialogOptions_) method. The alert dialog displays an `OK` button. When the user selects `OK`, the alert dialog closes.

In the following example, an alert dialog is displayed when a Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor [Button](https://blazor.syncfusion.com/documentation/button/getting-started) is clicked.

{% tabs %}
{% highlight razor %}

{% include_relative code-snippet/alert-dialog.razor %}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hZBfNsKZLmlnIlwK?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Alert Dialog](./images/blazor-alert-dialog.png)" %}

### Show confirm dialog

A confirm dialog displays a specified message along with `OK` and `Cancel` buttons and returns a boolean value based on the user action. Selecting `OK` returns `true`; selecting `Cancel` returns `false`. This can be achieved using the [DialogService.ConfirmAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.SfDialogService.html#Syncfusion_Blazor_Popups_SfDialogService_ConfirmAsync_System_String_System_String_Syncfusion_Blazor_Popups_DialogOptions_) method. It is typically used to get user approval before a critical action. After the user responds, the dialog closes automatically.

In the following example, the confirm dialog is displayed and returns a value based on the `OK` or `Cancel` button click.

{% tabs %}
{% highlight razor %}

{% include_relative code-snippet/confirm-dialog.razor %}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hZhTZigXBFzGkGUJ?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Confirm Dialog](./images/blazor-confirm-dialog.png)" %}

### Show prompt dialog

A prompt dialog is used to get input from the user using the [DialogService.PromptAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.SfDialogService.html#Syncfusion_Blazor_Popups_SfDialogService_PromptAsync_System_String_System_String_Syncfusion_Blazor_Popups_DialogOptions_) method. Selecting `OK` returns the input value; selecting `Cancel` returns `null`. After the user responds, the dialog closes automatically.

In the following example, the prompt dialog is displayed and returns a value based on the `OK` or `Cancel` button click.

{% tabs %}
{% highlight razor %}

{% include_relative code-snippet/prompt-dialog.razor %}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BXhfZiKjVvxKZQrI?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Prompt Dialog](./images/blazor-prompt-dialog.png)" %}