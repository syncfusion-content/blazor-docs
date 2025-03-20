---
layout: post
title: Getting Started with SfPdfViewer in Blazor Web App | Syncfusion
description: Learn how to getting started with SfPdfViewer control in Blazor Web App. You can view and comment on PDFs in ease and also can fill fields.
platform: Blazor
control: SfPdfViewer
documentation: ug
---

# View PDF files using PDF Viewer Component in the Blazor Web app

This section briefly explains about how to include `Syncfusion's Blazor PDF Viewer (Next Gen)` component in your Blazor Web App using [Visual Studio](https://visualstudio.microsoft.com/vs/).

## Prerequisites

* [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)

## Create a new Blazor Web App in Visual Studio

You can create a **Blazor Web App** using Visual Studio 2022 via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-8.0) or the [Syncfusion Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-integration/template-studio).

You need to configure the corresponding [Interactive render mode](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/render-modes?view=aspnetcore-8.0#render-modes) and [Interactivity location](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-8.0&pivots=windows) while creating a Blazor Web Application.

## Install Blazor SfPdfViewer and Themes NuGet package in Blazor Web App

To add **Blazor PDF Viewer (Next Gen)** component in the app, open the NuGet package manager in Visual Studio (*Tools → NuGet Package Manager → Manage NuGet Packages for Solution*), search and install [Syncfusion.Blazor.SfPdfViewer](https://www.nuget.org/packages/Syncfusion.Blazor.SfPdfViewer/) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/).

If you utilize `WebAssembly or Auto` render modes in the Blazor Web App need to be install Syncfusion Blazor components NuGet packages within the client project.

Alternatively, you can utilize the following package manager command to achieve the same.

{% tabs %}
{% highlight C# tabtitle="Package Manager" %}

Install-Package Syncfusion.Blazor.SfPdfViewer -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.Themes -Version {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

N> Syncfusion Blazor components are available in [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). Refer to [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for available NuGet packages list with component details.

## Register Syncfusion Blazor Service

* In the **~/_Imports.razor** file, add the following namespaces:

{% tabs %}
{% highlight razor tabtitle="~/_Imports.razor" %}

@using Syncfusion.Blazor;
@using Syncfusion.Blazor.SfPdfViewer;

{% endhighlight %}
{% endtabs %}

* Register the Syncfusion Blazor Service in the **~/Program.cs** file of your App. If you select an **Interactive render mode** as `WebAssembly` or `Auto`, you need to register the following Blazor service in both **~/Program.cs** files of your Blazor Web App.

```cshtml

....
using Syncfusion.Blazor;

....
// call AddHubOptions method to server side project only
builder.Services.AddServerSideBlazor().AddHubOptions(o => { o.MaximumReceiveMessageSize = 102400000; });
builder.Services.AddMemoryCache();
builder.Services.AddSyncfusionBlazor();

```

## Adding stylesheet and script

Add the stylesheet reference in the `<head>` section and the script reference at the end of the `<body>` in the **~/Components/App.razor** file as shown below:

```html
<head>
    ....
    <!-- Syncfusion Blazor PDF Viewer (Next Gen) control's theme style sheet -->
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
</head>

<body>
    ....
    <!-- Syncfusion Blazor PDF Viewer (Next Gen) control's scripts -->
    <script src="_content/Syncfusion.Blazor.SfPdfViewer/scripts/syncfusion-blazor-sfpdfviewer.min.js" type="text/javascript"></script>
</body>
```
## Adding Blazor PDF Viewer (Next Gen) Component

Add the Syncfusion PDF Viewer (Next Gen) component in the in the **~Pages/.razor** file.

If you have set the interactivity location to `Per page/component` in the web app, ensure that you define a render mode at the top of the Syncfusion Blazor component-included razor page as follows:

{% tabs %}
{% highlight razor %}

@* Your App render mode define here *@
@rendermode InteractiveAuto

{% endhighlight %}
{% endtabs %}

{% tabs %}
{% highlight razor %}

<SfPdfViewer2 DocumentPath="https://cdn.syncfusion.com/content/pdf/pdf-succinctly.pdf"
              Height="100%"
              Width="100%">
</SfPdfViewer2>

{% endhighlight %}
{% endtabs %}

N> If you don't provide the `DocumentPath` property value, the PDF Viewer (Next Gen) component will be rendered without loading the PDF document. Users can then use the **open** option from the toolbar to browse and open the PDF as required.

## Run the application

Run the application, and the PDF file will be displayed using Syncfusion's Blazor PDF Viewer (Next Gen) component in your browser.

![Blazor SfPdfViewer Component](GettingStarted_images/blazor-pdfviewer.png)

N> [View Sample in GitHub](https://github.com/SyncfusionExamples/Blazor-Getting-Started-Examples/tree/main/PDFViewer%20%202/BlazorWebApp).

## See also

* [Getting Started with Blazor PDF Viewer (Next Gen) Component in Blazor WASM App](./web-assembly-application)

* [Getting Started with Blazor PDF Viewer (Next Gen) Component in WSL mode](./wsl-application)

* [Learn different ways to add script reference in Blazor Application](https://blazor.syncfusion.com/documentation/common/adding-script-references)