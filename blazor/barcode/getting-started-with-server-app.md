---
layout: post
title: Getting Started with Blazor Barcode Component in Blazor Server App
description: Checkout and learn about the documentation for getting started with Blazor Barcode Component in Blazor Server App.
platform: Blazor
component: Barcode
documentation: ug
---

# Getting Started with Blazor Barcode Component in Blazor Server App

This section briefly explains about how to include [Blazor Barcode](https://www.syncfusion.com/blazor-components/blazor-barcode) component in a Blazor Server App using [Visual Studio](https://visualstudio.microsoft.com/vs/), [Visual Studio Code](https://code.visualstudio.com/), and the [.NET CLI](https://learn.microsoft.com/en-us/dotnet/core/tools/).

### Create a new Blazor Server App 

{% tabcontents %}

{% tabcontent Visual Studio %}

Create a **Blazor Server App** by using the **Blazor Web App** template in Visual Studio via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-10.0&pivots=vs) or the [Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-integration/template-studio).

{% endtabcontent %}

{% tabcontent Visual Studio Code %}

Run the following command to create a new Blazor Server App.

```bash
dotnet new blazor -o BlazorApp --interactivity Server
```

Alternatively, create a **Blazor Server App** using Visual Studio Code via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-10.0&pivots=vsc) or the [Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-code-integration/create-project), or the [C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit) extension.

{% endtabcontent %}

{% tabcontent .NET CLI %}

Run the following command to create a new Blazor Server App.

```bash
dotnet new blazor -o BlazorApp --interactivity Server
```

{% endtabcontent %}

{% endtabcontents %}

N> Configure the appropriate [Interactive render mode](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/render-modes?view=aspnetcore-10.0#render-modes) and [Interactivity location](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-10.0&pivots=vs) while creating a Blazor Server App. For detailed information, refer to the [interactive render mode documentation](https://blazor.syncfusion.com/documentation/common/interactive-render-mode).

### Install the required Blazor packages 

Install the [Syncfusion.Blazor.BarcodeGenerator](https://www.nuget.org/packages/Syncfusion.Blazor.BarcodeGenerator/) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/) NuGet packages. All Syncfusion Blazor packages are available on [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). See the [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for details.

{% tabcontents %}

{% tabcontent Visual Studio %}

1. Go to *Tools → NuGet Package Manager → Manage NuGet Packages for Solution*.
2. Search the required NuGet packages (`Syncfusion.Blazor.BarcodeGenerator` and `Syncfusion.Blazor.Themes`) and install them.

Alternatively, you can install the same packages using the Package Manager Console with the following commands.

```bash
Install-Package Syncfusion.Blazor.BarcodeGenerator -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.Themes -Version {{ site.releaseversion }}
```

{% endtabcontent %}

{% tabcontent Visual Studio Code %}

Open the terminal and run the following commands.

```bash
dotnet add package Syncfusion.Blazor.BarcodeGenerator -v {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Themes -v {{ site.releaseversion }}
```

{% endtabcontent %}

{% tabcontent .NET CLI %}

Open the command prompt and run the following commands.

```bash
dotnet add package Syncfusion.Blazor.BarcodeGenerator -v {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Themes -v {{ site.releaseversion }}
```

{% endtabcontent %}

{% endtabcontents %}

### Add import namespaces

After the packages are installed, open the **~/_Imports.razor** file and import the `Syncfusion.Blazor` and `Syncfusion.Blazor.BarcodeGenerator` namespaces.

{% tabs %}
{% highlight C# tabtitle="~/_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.BarcodeGenerator

{% endhighlight %}
{% endtabs %}

### Register the Blazor service

Open the **Program.cs** file in Blazor Server App and register the Blazor service.

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
 
 The theme stylesheet and script can be accessed from NuGet through [Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets). Include the [stylesheet](https://blazor.syncfusion.com/documentation/appearance/themes) and [script references](https://blazor.syncfusion.com/documentation/common/adding-script-references) in the **App.razor** file.

{% tabs %}
{% highlight html tabtitle="App.razor" %}

...
<link href="_content/Syncfusion.Blazor.Themes/fluent2.css" rel="stylesheet" />
...
<script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>

{% endhighlight %}
{% endtabs %}

N> Check out the [Blazor Themes](https://blazor.syncfusion.com/documentation/appearance/themes) topic to discover various methods ([Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets), [CDN](https://blazor.syncfusion.com/documentation/appearance/themes#cdn-reference), and [CRG](https://blazor.syncfusion.com/documentation/common/custom-resource-generator)) for referencing themes in the Blazor application. Also, check out the [Adding Script Reference](https://blazor.syncfusion.com/documentation/common/adding-script-references) topic to learn different approaches for adding script references in the Blazor application.

### Add Blazor Barcode component

Open a Razor file located in the **~/Pages/*.razor** (for example, **Home.razor**) and add the [Blazor Barcode](https://www.syncfusion.com/blazor-components/blazor-barcode) component inside the razor file.

N>If the interactivity location is set to `Per page/component`, define a render mode at the top of the razor file. (For example `InteractiveServer`). If the Interactivity is set to `Global`, the render mode is automatically configured in the `App.razor` file by default.

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

@rendermode InteractiveServer

<SfBarcodeGenerator Width="200px" Height="150px" Type="@BarcodeType.Codabar" Value="123456789"></SfBarcodeGenerator>

{% endhighlight %}
{% endtabs %}

**Run the application**

{% tabcontents %}

{% tabcontent Visual Studio %}

* Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to launch the application. The Blazor Barcode component will render in your default web browser.

{% endtabcontent %}

{% tabcontent Visual Studio Code %}

* Open the terminal and run the following command.

```bash
dotnet run
```

{% endtabcontent %}

{% tabcontent .NET CLI %}

* Open the command prompt and run the following command.

```bash
dotnet run
```

{% endtabcontent %}

{% endtabcontents %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rXhpDMryUyGlVBeQ?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor Barcode Generator Component](images/blazor-barcode-generator-component.webp)" %}

N> [View Sample in GitHub](https://github.com/SyncfusionExamples/Blazor-Getting-Started-Examples/tree/main/Barcode).

## Adding QR Generator control

Add a QR code in our barcode generator component.

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

<SfQRCodeGenerator Width="200px" Height="150px"  Value="Syncfusion"></SfQRCodeGenerator>

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hthpNsBeqSYitBRy?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[QR Code Generator in Blazor Barcode Component](images/blazor-barcode-with-qr-code.webp)" %}

## Adding Data Matrix Generator control

Add a Data Matrix code in our barcode generator component.

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

<SfDataMatrixGenerator Width="200" Height="150" Value="SYNCFUSION"></SfDataMatrixGenerator>

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VDBzZMBSARZqShgQ?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Data Matrix Generator in Blazor Barcode Component](images/blazor-barcode-with-data-matrix.webp)" %}

N> Explore the [Blazor Barcode Generator example](https://blazor.syncfusion.com/demos/barcodes/default-functionalities?theme=bootstrap5) that shows you how to render and configure the barcode.

## See also

1. [Getting Started with Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor for client-side in .NET Core CLI](https://blazor.syncfusion.com/documentation/getting-started/blazor-webassembly-dotnet-cli)
2. [Getting Started with Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor for client-side in Visual Studio](https://blazor.syncfusion.com/documentation/getting-started/blazor-webassembly-visual-studio)