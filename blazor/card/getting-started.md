---
layout: post
title: Getting Started with Blazor Card Component | Syncfusion
description: Checkout and learn more about getting started with Blazor Card component of Syncfusion.
platform: Blazor
control: Card
documentation: ug
---

<!-- markdownlint-disable MD040 -->

# Getting Started with Blazor Card Component

This section briefly explains about how to include a [Card](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Cards.SfCard.html) in your Blazor server-side application. You can refer to our Getting Started with [Syncfusion Blazor for Server-Side in Visual Studio 2019](https://blazor.syncfusion.com/documentation/getting-started/blazor-webassembly-visual-studio-2019/) page for the introduction and configuring the common specifications.

To get start quickly with Blazor Card component, you can check on this video.
{% youtube
"youtube:https://www.youtube.com/watch?v=k8KSZIf5VPs"%}

## Importing Syncfusion Blazor component in the application

1. Install **Syncfusion.Blazor.Card** NuGet package to the application by using the **NuGet Package Manager**.

2. You can add the client-side style resources from NuGet package in the **HEAD** element of the **~/Pages/_Host.cshtml** page.

```cshtml
<head>
    <environment include="Development">
    ....
    ....
        <link href="_content/Syncfusion.Blazor/styles/fabric.css" rel="stylesheet" />
        <!---CDN--->
        @*<link href="https://cdn.syncfusion.com/blazor/18.4.42/styles/fabric.css" rel="stylesheet" />*@
   </environment>
</head>

```

> For Internet Explorer 11 kindly refer the polyfills. Refer the [documentation](../common/how-to/render-blazor-server-app-in-ie/) for more information.

```cshtml
<head>
   <environment include="Development">
      <link href="_content/Syncfusion.Blazor/styles/fabric.css" rel="stylesheet" />
      <script src="https://github.com/Daddoon/Blazor.Polyfill/releases/download/3.0.1/blazor.polyfill.min.js"></script>
  </environment>
</head>

```

## Adding component package to the application

Open `**~/_Imports.razor` file and import the `Syncfusion.Blazor.**`

```cshtml
@using Syncfusion.Blazor.Cards
```

## Add SyncfusionBlazor service in Startup.cs

Open the **Startup.cs** file and add services required by Syncfusion components by using the **service.AddSyncfusionBlazor()** method. Add this method in the **ConfigureServices** function as follows.

```csharp

using Syncfusion.Blazor;
namespace BlazorApplication
{
    public class Startup
    {
        ....
        ....
        public void ConfigureServices(IServiceCollection services)
        {
            ....
            ....
            services.AddSyncfusionBlazor();
        }
    }
}
```

## Adding Card component

To initialize the Card component, add the below code to your **Index.razor** view page which is present under **~/Pages** folder.

```cshtml
<SfCard> Sample Card </SfCard>
```

## Adding a header and content

1. You can create Card with a header in a specific structure. For adding header, you can use `CardHeader` tag and in that `Title` and `SubTitle` can be given.

2. Also content will be added by using `CardContent` tag.

```cshtml
@using Syncfusion.Blazor.Cards

<div class="control-section">
    <div class="row">
        <div class="col-xs-6 col-sm-6 col-lg-6 col-md-6">
            <SfCard>
                <CardHeader Title="Debunking Five Data Science Myths" SubTitle="By John Doe | Jan 20, 2018" />
                <CardContent Content="Tech evangelists are currently pounding their pulpits about all things AI, machine learning, analytics—anything that sounds like the future and probably involves lots of numbers. Many of these topics can be grouped under the intimidating term data science." />
            </SfCard>
        </div>
    </div>
</div>
```

## Run the application

After successful compilation of your application, the Syncfusion Blazor Card component will render in the web browser.

![Blazor Card Component](images/blazor-card-component.png)