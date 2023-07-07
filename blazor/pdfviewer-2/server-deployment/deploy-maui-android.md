---
layout: post
title: Deploy SfPdfViewer in Blazor android MAUI | Syncfusion
description: Checkout and learn here all about how to deploy SfPdfViewer in Blazor android MAUI in Syncfusion Blazor SfPdfViewer component and much more details.
platform: Blazor
control: SfPdfViewer
documentation: ug
---

# How To Deploy SfPdfViewer in Blazor android MAUI

This section briefly explains about how to deploy [Blazor SfPdfViewer](https://www.syncfusion.com/blazor-components/blazor-pdf-viewer) component in your blazor android MAUI App using Visual Studio.

## Prerequisites

To use the MAUI project templates, install the Mobile development with .NET extension for Visual Studio. For more details, refer [here](https://docs.microsoft.com/en-us/dotnet/MAUI/get-started/installation).

## Deploy SfPdfViewer into Blazor android MAUI application

1. Start Visual Studio and select **Create a new project**.

2. For a Blazor MAUI application experience, choose the **.NET MAUI Blazor App** template. Select **Next**. 
![Create-new-blazor-server-app](images/start-window-create-new-project.png)

3. Provide a **Project Name** and confirm that the *Location* is correct. Select Next. 
![Set-project-name](images/Set-project-name-andriod.png)

4. In the **Additional information** dialog, set the target framework and create the project.
![Set-target-framework](images/Additional_information.png)

## Install Blazor SfPdfViewer NuGet package in Blazor android MAUI application

Syncfusion Blazor components are available in [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). To use Syncfusion Blazor components in the application, add reference to the corresponding NuGet. Refer to [NuGet packages topic](https://blazor.syncfusion.com/documentation/nuget-packages) for available NuGet packages list with component details and [Benefits of using individual NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages#benefits-of-using-individual-nuget-packages).

Install the [Syncfusion.Blazor.SfPdfViewer](https://www.nuget.org/packages/Syncfusion.Blazor.SfPdfViewer) NuGet package as a reference to your project from the [NuGet.org](https://www.nuget.org/packages?q=syncfusion.blazor).

![Install the PDF Syncfusion.Blazor.SfPdfViewer package](images/nuget-package-android.png)

## Register Syncfusion Blazor Service

Open **~/_Imports.razor** file and import the **Syncfusion.Blazor.SfPdfViewer** namespaces.

{% tabs %}
{% highlight razor tabtitle="~/_Imports.razor" %}

@using Syncfusion.Blazor 
@using Syncfusion.Blazor.SfPdfViewer

{% endhighlight %}
{% endtabs %}

* Open the **~/MauiProgram.cs** file and register the Syncfusion Blazor Service.

{% tabs %}
{% highlight c# tabtitle="~/MauiProgram.cs" hl_lines="3 18 24" %}

using Microsoft.Extensions.Logging;
using MauiBlazorAndroid.Data;
using Syncfusion.Blazor;

namespace MauiBlazorAndroid;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder.UseMauiApp<App>().ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});

		builder.Services.AddMauiBlazorWebView();
        builder.Services.AddMemoryCache();
#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif
		builder.Services.AddSingleton<WeatherForecastService>();
        builder.Services.AddSyncfusionBlazor();
		return builder.Build();
	}
}

{% endhighlight %}
{% endtabs %}

## Adding Style Sheet

Add the theme style sheet as below in the sever web app.

* Add the Syncfusion bootstrap5 theme in the `<head>` of the **~/wwwroot/index.html** file.

{% tabs %}
{% highlight html %}

<head>
    <!-- Syncfusion Blazor SfPdfViewer controls theme style sheet -->
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
</head>

{% endhighlight %}
{% endtabs %}

> Checkout the [Blazor Themes topic](https://blazor.syncfusion.com/documentation/appearance/themes) to learn different ways ([Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets), [CDN](https://blazor.syncfusion.com/documentation/appearance/themes#cdn-reference) and [CRG](https://blazor.syncfusion.com/documentation/common/custom-resource-generator)) to refer themes in Blazor application, and to have the expected appearance for Syncfusion Blazor components. Here, the theme is referred using [Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets). Refer to [Enable static web assets usage](https://blazor.syncfusion.com/documentation/appearance/themes#enable-static-web-assets-usage) topic to use static assets in your project.

## Adding Script Reference

 In this getting started walk-through, the required scripts are referred using [Static Web Assets](https://blazor.syncfusion.com/documentation/common/adding-script-references#static-web-assets) externally inside the `<head>` as follows. Refer to [Enable static web assets usage](https://blazor.syncfusion.com/documentation/common/adding-script-references#enable-static-web-assets-usage) topic to use static assets in your project.

* Add the script in the `<head>` of the **~/wwwroot/index.html** file.

{% tabs %}
{% highlight html %}

<head>
    <!-- Syncfusion Blazor SfPdfViewer controls theme style sheet -->
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
    <!-- Syncfusion Blazor SfPdfViewer controls scripts -->
    <script src="_content/Syncfusion.Blazor.SfPdfViewer/scripts/syncfusion-blazor-sfpdfviewer.min.js" type="text/javascript"></script>
</head>

{% endhighlight %}
{% endtabs %}

> Checkout [Adding Script Reference topic](https://blazor.syncfusion.com/documentation/common/adding-script-references) to learn different ways to add script reference in Blazor Application. 

> Syncfusion recommends to reference scripts using [Static Web Assets](https://blazor.syncfusion.com/documentation/common/adding-script-references#static-web-assets), [CDN](https://blazor.syncfusion.com/documentation/common/adding-script-references#cdn-reference) and [CRG](https://blazor.syncfusion.com/documentation/common/custom-resource-generator) by [disabling JavaScript isolation](https://blazor.syncfusion.com/documentation/common/adding-script-references#disable-javascript-isolation) for better loading performance of the Blazor application.

## Adding Blazor SfPdfViewer Component

Add the Syncfusion SfPdfViewer component in the **~/Pages/Index.razor** file.

{% tabs %}
{% highlight razor %}

@page "/"

<SfPdfViewer2 @ref="viewer" DocumentPath="@DocumentPath" Height="100%" Width="100%"></SfPdfViewer2>

@code {
    SfPdfViewer2 viewer;
    private string DocumentPath { get; set; } = "";

    protected override void OnInitialized()
    {
        string basePath = "MauiBlazorAndroid.wwwroot.data.pdf_succinctly.pdf";

        Stream DocumentStream = this.GetType().Assembly.GetManifestResourceStream(basePath);
        DocumentStream.Position = 0;
        using (MemoryStream memoryStream = new MemoryStream())
        {
            DocumentStream.CopyTo(memoryStream);
            byte[] bytes = memoryStream.ToArray();
            string base64String = Convert.ToBase64String(bytes);
            string base64prefix = "data:application/pdf;base64,";
            //Assigned the base64 path to the PDF document path.
            DocumentPath = $"{base64prefix}{base64String}";
        }
        base.OnInitialized();
    }
}
{% endhighlight %}
{% endtabs %}

N> When developing a Blazor Android MAUI application, it is need to pass the `DocumentPath` to the SfPdfViewer component as a `base64 string`. This ensures that the application can retrieve and render the PDF document correctly within the SfPdfViewer.

## Run the SfPdfViewer in Blazor android MAUI application

To run the SfPdfViewer in a Blazor Android MAUI application using the Android emulator, follow these steps:

![Run Windows machine](images/emulator.png)

**step 1** Set up the necessary dependencies, SDKs, and tools for Blazor Android MAUI on your Windows machine. Ensure that you have     installed the required `Android SDK licenses`. If any errors occur during installation, follow the provided prompts or instructions to resolve them.

![android-sdk-liscence](images/android-sdk-liscence.png)

**step 2** Install and launch the Android Device Manager. Open the Android SDK Manager, go to the `SDK Tools` tab, select the `Android Device Manager` checkbox, and click `Apply` or `OK`. This will allow you to create, manage, and launch Android Virtual Devices (AVDs) for testing and running Android applications.

![picxel emulator](images/pixcel-emulator.png)

**step 3** Make sure the Android emulator is running. Launch the Android Device Manager and create or select an existing AVD to run the emulator.

Now launch the project again in emulator mode it will render the SfPdfViewer using Blazor android MAUI application

N> If you encounter any errors while using the Android Emulator, you can refer to the following link for troubleshooting guidance[Troubleshooting Android Emulator](https://learn.microsoft.com/en-us/dotnet/maui/android/emulator/troubleshooting)

![Blazor SfPdfViewer Component](images/blazor-pdfviewer.png)

>[View Sample in GitHub]().