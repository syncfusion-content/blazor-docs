---
layout: post
title: Getting Started with Blazor Electron App in Visual Studio | Syncfusion
description: Check out the documentation for getting started with Blazor Electron App and Syncfusion Blazor Components in Visual Studio and much more.
platform: Blazor
component: Common
documentation: ug
---

# Getting Started with Blazor Electron Application

This section explains how to create and run the Blazor Electron app with Syncfusion Blazor components.

## What is Electron App

[Electron](https://www.electronjs.org/) framework supports building cross-platform desktop applications with web technologies. It utilizes Node.js and the Chromium rendering engine to run a web application on a desktop shell.

## Create a Blazor server-side application

You can create Blazor Server application using either CLI or Visual Studio referring the below links

* [Create Blazor server application using CLI](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-dotnet-cli)

* [Create Blazor Server application using Visual Studio](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-visual-studio)
 
 ## Add Blazor DataGrid component

* Open **~/_Imports.razor** file or any other page under the `~/Pages` folder where the component is to be added and import the **Syncfusion.Blazor.Grid** namespace.

{% tabs %}
{% highlight razor tabtitle="~/Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Grids

{% endhighlight %}
{% endtabs %}

* Now, add the Syncfusion DataGrid component in razor file. Here, the DataGrid component is added in the **~/Pages/Index.razor** file under the **~/Pages** folder.

{% tabs %}
{% highlight razor %}

<SfGrid DataSource="@Orders" />

@code{
    public List<Order> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 5).Select(x => new Order()
        {
            OrderID = 0 + x,
            CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
        }).ToList();
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }

    }
}

{% endhighlight %}
{% endtabs %}

Now, the Blazor server application with Sycnfusion Grid component is created.

![Blazor DataGrid Component](images\electron\server-syncfusion-grid.png)

## Configure Electron SetUp in the application

You can run the below commands either in Visual Studio command prompt or CLI depends on the preparation of the application.

1. Install [ElectronNET.API](https://www.nuget.org/packages/ElectronNET.API/) NuGet package in the application running below command

```

dotnet add package ElectronNET.API

```

2. Create a local .NET tool manifest file by running the following command. This will create a manifest file in the **~/.config/dotnet-tools.json** location. 

```

dotnet new tool-manifest

```
![Local dotnet tool](images\electron\net-tool-manifest.png)

3. Install the electronize tool locally in the project by running the below command.

```

dotnet tool install ElectronNET.CLI

```
![Electron NET CLI](images\electron\net-cli.png)

4. Run the below command to configure Electron.NET manifest tool and update the launch profile of the application.

```

dotnet electronize init

```
![Update launch profile](images\electron\update-launch-profile.png)

5. To integrate Electron.NET in the application add the below code in **~/Program.cs** file of the application.

{% tabs %}
{% highlight c# tabtitle=".NET 6 (~/Program.cs)" hl_lines="2 9 10" %}

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
{% highlight c# tabtitle=".NET 5 and .NET 3.X (~/Program.cs)" hl_lines="1 12" %}

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

6. To open the Electron window add the below code in the **~/Startup.cs** file of .NET 3.X and .NET 5 applications, in **~/Program.cs** file of .NET 6 applications.

{% tabs %}
{% highlight c# tabtitle=".NET 6 (~/Program.cs)" hl_lines="9 10 12 13 14 15" %}

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

7. Run the application using the below command.

```

dotnet electronize start

```
![Electron app output](images\electron\electron-grid-output.png)

> To close the electron app when closed the electron window add the below code in the application.

{% tabs %}
{% highlight c# hl_lines="3 4 5" %}

Task.Run(async () => {
        var window = await Electron.WindowManager.CreateWindowAsync();
        window.OnClosed += () => {
            Electron.App.Quit();
        };
    });

{% endhighlight %}
{% endtabs %}

8. Run the below command lines to do production builds based on platform

```

dotnet electronize build /target win
dotnet electronize build /target osx
dotnet electronize build /target linux

```

> [View the complete Blazor Server electron application with Syncfusion controls on GitHub](https://github.com/SyncfusionExamples/blazor-electron-app)