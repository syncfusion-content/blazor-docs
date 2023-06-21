---
layout: post
title: Deployment in Blazor | AOT | Syncfusion
description: Learn here all about deploying the Blazor application with Syncfusion Blazor Components and much more.
platform: Blazor
component: Common
documentation: ug
---

# Deployment in Blazor

This section provides information about deploying Blazor applications with the Syncfusion Blazor components. 

Refer to [Host and deploy ASP.NET Core Blazor](https://docs.microsoft.com/en-us/aspnet/core/blazor/host-and-deploy/) topic for more information.

## Publish Blazor Application with Visual Studio

* Right-click on the project in the `Solution Explorer` and select `Publish`.

![Solution Explorer in Blazor](./images/publish.png)

* Then, select the `Folder` option and select the publishing target location.

![Publish Location in Blazor](./images/folder.png)

* Check the configuration as Release by clicking the `Advanced...` option below the target location.

![Release Configuration in Blazor](./images/config.png)

* For `Blazor Server side application`, set Deployment Mode as `Self-Contained`. Because some dependencies are not loaded properly when the published folder is hosted.

![Deploy Mode in Blazor](./images/deploy.png)

* Then, click `Save` and `Publish`.

    N> Refer [here](https://docs.microsoft.com/en-us/visualstudio/deployment/quickstart-deploy-to-azure?view=vs-2019) for publishing the application to Azure App Service using Visual Studio.  

## Publish Blazor Application with CLI

Packing the application and its dependencies into a folder for deployment to a hosting system by using the `dotnet publish` command.

For CLI deployment, run the following command from your root directory.

{% tabs %}
{% highlight c# tabtitle=".NET CLI" %}

dotnet publish -c Release

{% endhighlight %}
{% endtabs %}

For Blazor Server CLI deployment.

{% tabs %}
{% highlight c# tabtitle=".NET CLI" %}

dotnet publish -c Release --self-contained true -r win-x86

{% endhighlight %}
{% endtabs %}

Refer to the [dotnet publish - arguments](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-publish?tabs=netcore21#arguments) to learn about various optional arguments. Use the following command to specify the path for the output directory.

{% tabs %}
{% highlight c# tabtitle=".NET CLI" %}

dotnet publish -c Release -o <output directory>

{% endhighlight %}
{% endtabs %}

N> If the output directory is not specified, it defaults to `./bin/[configuration]/[framework]/publish/` for a **framework-dependent deployment** and `./bin/[configuration]/[framework]/[runtime]/publish/` for a **self-contained deployment**.

If the path is relative, the output directory generated is relative to the project file location, not to the current working directory. Now, the published folder can be hosted in IIS or Azure app service.

## Ahead-of-time (AOT) compilation in Blazor WebAssembly

Blazor WebAssembly supports ahead-of-time (AOT) compilation which provides improved runtime performance at the expense of a larger app size. Refer to [Ahead-of-time (AOT) compilation](https://docs.microsoft.com/en-us/aspnet/core/blazor/host-and-deploy/webassembly?view=aspnetcore-6.0#ahead-of-time-aot-compilation) topic to learn more about how it works and how to enable. 

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

* [Host and Deploy Blazor](https://docs.microsoft.com/en-us/aspnet/core/blazor/host-and-deploy/)
* [Host and deploy Blazor Server](https://docs.microsoft.com/en-us/aspnet/core/blazor/host-and-deploy/server)
* [Host and deploy ASP.NET Core Blazor WebAssembly](https://docs.microsoft.com/en-us/aspnet/core/blazor/host-and-deploy/webassembly)
* [Publish a Web app to Azure App Service using Visual Studio](https://docs.microsoft.com/en-us/visualstudio/deployment/quickstart-deploy-aspnet-web-app)
* [Deploy ASP.NET Core apps to Azure App Service](https://docs.microsoft.com/en-us/aspnet/core/host-and-deploy/azure-apps/)
* [Deploy Blazor WASM App to Cloudflare](https://www.syncfusion.com/blogs/post/easily-deploy-a-blazor-webassembly-app-to-cloudflare.aspx)
* [Publish a Blazor WebAssembly app and .NET API with Azure Static Web Apps](https://docs.microsoft.com/en-us/learn/modules/publish-app-service-static-web-app-api-dotnet/)
