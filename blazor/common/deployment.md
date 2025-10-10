---
layout: post
title: Deployment in Blazor | AOT | Syncfusion
description: Learn how to publish and deploy Blazor Web App, Blazor WASM, Blazor Server Apps with Syncfusion Blazor components, including self-contained deployment and AOT.
platform: Blazor
control: Common
documentation: ug
---

# Deployment in Blazor

This section provides information about deploying Blazor applications with Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components.

For more information, see [Host and deploy ASP.NET Core Blazor](https://learn.microsoft.com/en-us/aspnet/core/blazor/host-and-deploy).

## Publish Blazor Application with Visual Studio

* Right-click on the project in the `Solution Explorer` and select `Publish`.

![Solution Explorer in Blazor](./images/publish.png)

* Then, select the `Folder` option and select the publishing target location.

![Publish Location in Blazor](./images/folder.png)

* Check the configuration as Release by clicking the `Advanced...` option below the target location.

![Release Configuration in Blazor](./images/config.png)

* For Blazor Server App, consider setting Deployment mode to `Self-Contained` when the hosting environment doesn't have the required .NET runtime installed.

![Deploy Mode in Blazor](./images/deploy.png)

* Then, click `Save` and `Publish`.

    N> Refer [here](https://learn.microsoft.com/en-us/visualstudio/deployment/quickstart-deploy-aspnet-web-app?view=vs-2019&tabs=azure) for publishing the application to Azure App Service using Visual Studio.  

## Publish Blazor Application with CLI

Package the application and its dependencies into a folder for deployment by using the `dotnet publish` command.

Run the following command from the project directory.

{% tabs %}
{% highlight c# tabtitle=".NET CLI" %}

dotnet publish -c Release

{% endhighlight %}
{% endtabs %}

For Blazor Server CLI deployment:

{% tabs %}
{% highlight c# tabtitle=".NET CLI" %}

dotnet publish -c Release --self-contained true -r win-x86

{% endhighlight %}
{% endtabs %}

Refer to [dotnet publish arguments](https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-publish#arguments) to learn about optional arguments. Use the following command to specify the output directory path.

{% tabs %}
{% highlight c# tabtitle=".NET CLI" %}

dotnet publish -c Release -o <output directory>

{% endhighlight %}
{% endtabs %}

N> If the output directory is not specified, it defaults to `./bin/[configuration]/[framework]/publish/` for a **framework-dependent deployment** and `./bin/[configuration]/[framework]/[runtime]/publish/` for a **self-contained deployment**.

If the path is relative, the output directory generated is relative to the project file location, not to the current working directory. Now, the published folder can be hosted in IIS or Azure app service.

## Ahead-of-time (AOT) compilation in Blazor WebAssembly

Blazor WebAssembly supports ahead-of-time (AOT) compilation, which improves runtime performance at the expense of a larger app size. For details and enable steps, see [Ahead-of-time (AOT) compilation](https://learn.microsoft.com/en-us/aspnet/core/blazor/host-and-deploy/webassembly/?view=aspnetcore-8.0&tabs=windows#ahead-of-time-aot-compilation).

### Enable AOT in the application

To enable AOT compilation in the application, add `RunAOTCompilation` options with value to `true` in the Blazor WebAssembly app's project file.

{% tabs %}
{% highlight c# tabtitle="~.csproj" %}

<PropertyGroup>
    <RunAOTCompilation>true</RunAOTCompilation>
</PropertyGroup>

{% endhighlight %}
{% endtabs %}

## See also

* [Host and deploy Blazor](https://learn.microsoft.com/en-us/aspnet/core/blazor/host-and-deploy)
* [Host and deploy Blazor Server](https://learn.microsoft.com/en-us/aspnet/core/blazor/host-and-deploy/server/)
* [Host and deploy ASP.NET Core Blazor WebAssembly](https://learn.microsoft.com/en-us/aspnet/core/blazor/host-and-deploy/webassembly)
* [Publish a web app to Azure App Service using Visual Studio](https://learn.microsoft.com/en-us/visualstudio/deployment/quickstart-deploy-aspnet-web-app?view=vs-2022&tabs=azure)
* [Deploy ASP.NET Core apps to Azure App Service](https://learn.microsoft.com/en-us/aspnet/core/host-and-deploy/azure-apps)
* [Deploy Blazor WASM App to Cloudflare](https://www.syncfusion.com/blogs/post/easily-deploy-a-blazor-webassembly-app-to-cloudflare)
* [Publish a Blazor WebAssembly App and .NET API with Azure Static Web Apps](https://learn.microsoft.com/en-us/training/modules/publish-app-service-static-web-app-api-dotnet/)
