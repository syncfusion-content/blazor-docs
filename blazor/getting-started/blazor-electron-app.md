---
layout: post
title: Creating Desktop App using Blazor and Electron Framework | Syncfusion
description: Check out the documentation for creating desktop application using Blazor and Electron Framework with Syncfusion Blazor Components in Visual Studio.
platform: Blazor
component: Common
documentation: ug
---

# Creating Desktop Application using Blazor and Electron

This section explains how to create and run desktop applications using Blazor and Electron Framework with Syncfusion Blazor components.

## What is Electron?

[Electron](https://www.electronjs.org/) framework for building cross-platform desktop applications with web technologies. It utilizes `Node.js` and the `Chromium` rendering engine to run a web application on a desktop shell.

## Create a Blazor server-side application

You can create Blazor Server application using either CLI or Visual Studio referring the below links

* [Create Blazor server application using CLI](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-dotnet-cli)

* [Create Blazor Server application using Visual Studio](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-visual-studio)
 
## Configure Electron in Blazor App

You can run the below commands either in **Visual Studio Developer Command Prompt** or **CLI** based on the tool you are using for development.

1.Install [ElectronNET.API](https://www.nuget.org/packages/ElectronNET.API/) NuGet package in the application.

```
dotnet add package ElectronNET.API
```

2.Create a local .NET tool manifest file by running the following command. This will create a manifest file in the **~/.config/dotnet-tools.json** location. 

```
dotnet new tool-manifest
```

![.NET tool manifest file](images\electron\net-tool-manifest.png)

3.Install the electronize tool locally in the project by running the below command.

```
dotnet tool install ElectronNET.CLI
```

![Electron NET CLI](images\electron\net-cli.png)

4.Run the below command to configure Electron.NET manifest tool and update the launch profile of the application.

```
dotnet electronize init
```
![Update launch profile](images\electron\update-launch-profile.png)

5.To integrate `Electron.NET` in the application add the below code in **~/Program.cs** file of the application.

{% tabs %}
{% highlight c# tabtitle=".NET 6 & .NET 7 (~/Program.cs)" hl_lines="2 9 10" %}

using Syncfusion.Blazor;
using ElectronNET.API;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
...
builder.Services.AddSyncfusionBlazor();
builder.Services.AddElectron();
builder.WebHost.UseElectron(args);

var app = builder.Build();
....

{% endhighlight %}
{% highlight c# tabtitle=".NET 5 & .NET 3.X (~/Program.cs)" hl_lines="1 12" %}

using ElectronNET.API;

public class Program
{
    .....
    .....

    public static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
    .ConfigureWebHostDefaults(webBuilder =>
    {
        webBuilder.UseElectron(args);
        webBuilder.UseStartup<Startup>();
    });
}

{% endhighlight %}
{% endtabs %}

6.To open the Electron window add the below code in the **~/Startup.cs** file of .NET 3.X and .NET 5 applications, in **~/Program.cs** file of .NET 6 applications.

{% tabs %}
{% highlight c# tabtitle=".NET 6 & .NET 7 (~/Program.cs)" hl_lines="9 10 12 13 14 15" %}

using ElectronNET.API;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
...
builder.WebHost.UseElectron(args);

if (HybridSupport.IsElectronActive)
{
    // Open the Electron-Window here
    Task.Run(async () => {
        var window = await Electron.WindowManager.CreateWindowAsync();
    });
}

var app = builder.Build();
....

{% endhighlight %}
{% highlight c# tabtitle=".NET 5 and .NET 3.X (~/Startup.cs)" hl_lines="13 14 15" %}

using ElectronNET.API;

public class Startup
{
    ……
    ……

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        ……
        ……
        // Open the Electron-Window
            Task.Run(async () => {
                var window = await Electron.WindowManager.CreateWindowAsync();
            });
    }
}

{% endhighlight %}
{% endtabs %}

7.Run the application using the below command.

```
dotnet electronize start
```

![Electron app output](images\electron\electron-grid-output.png)

N> To close the electron app when closed the electron window add the below code in **//Open the Electron-Window** in step 6 in the **~/Startup.cs** file of .NET 3.X and .NET 5 applications, in **~/Program.cs** file of .NET 6 applications.

{% tabs %}
{% highlight c# tabtitle=".NET 6 & .NET 7 (~/Program.cs)" hl_lines="14 15 16" %}

using ElectronNET.API;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
...
builder.WebHost.UseElectron(args);

if (HybridSupport.IsElectronActive)
{
    // Open the Electron-Window
    Task.Run(async () => {
        var window = await Electron.WindowManager.CreateWindowAsync();
        window.OnClosed += () => {
            Electron.App.Quit();
        };
    });
}

var app = builder.Build();
....

{% endhighlight %}
{% highlight c# tabtitle=".NET 5 and .NET 3.X (~/Startup.cs)" hl_lines="15 16 17" %}

using ElectronNET.API;

public class Startup
{
    ……
    ……

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        ……
        ……
        // Open the Electron-Window
        Task.Run(async () => {
            var window = await Electron.WindowManager.CreateWindowAsync();
            window.OnClosed += () => {
                Electron.App.Quit();
            };
        });
    }
}

{% endhighlight %}
{% endtabs %}

8.Run the below command lines to do production builds based on platform

```
dotnet electronize build /target win
dotnet electronize build /target osx
dotnet electronize build /target linux
```

N> [View the complete Blazor Server electron application with Syncfusion controls on GitHub](https://github.com/SyncfusionExamples/blazor-electron-app)
