---
layout: post
title: Creating Desktop Apps using Blazor and Electron.NET (using ElectronNET.Core)
description: Check out the documentation for creating a desktop application using Blazor Server and the modern ElectronNET.Core framework with Syncfusion Blazor Components.
platform: Blazor
component: Common
documentation: ug
---

# Creating Desktop Application using Blazor and Electron

This section explains how to create and run a cross‑platform desktop application using **Blazor Server** and the **ElectronNET.Core** framework with **Syncfusion<sup style="font-size:70%">®</sup> Blazor components**.

N> ElectronNET.Core is the modern fork of the Electron.NET approach that supports recent .NET versions. This guide targets **Blazor Server (server interactivity)** inside an Electron shell.

## What is Electron?

[Electron](https://www.electronjs.org/) is a framework for building cross-platform desktop applications with web technologies. It utilizes `Node.js` and the `Chromium` rendering engine to run a web application in a desktop shell.

## Prerequisites

- .NET 10 SDK (LTS) 
- Node.js 22.x or later
- Supported OS for .NET 10: Windows 10+, macOS 12+, Ubuntu 20.04+
- Editor/IDE: Visual Studio 2022 or later, or VS Code

## Create a Blazor Server Application

Create a new **Blazor Web App** (with **Server** interactivity) using the .NET CLI or Visual Studio.

N> In .NET 8+, the recommended approach is the unified **Blazor Web App** template with **Interactive Server** render mode. This guide uses server-side interactivity.

- [Create a Blazor Server application by using the CLI](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-visual-studio?tabcontent=.net-cli)  
- [Create a Blazor Server application by using Visual Studio](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-visual-studio)

## Configure Electron.NET in Your Blazor App (using ElectronNET.Core)

Run the following commands in either the **Visual Studio Developer Command Prompt** or any **command-line interface (CLI)**.

### 1. Install the ElectronNET.Core NuGet packages

{% tabs %}

{% highlight c# tabtitle="Package Manager" %}

dotnet add package ElectronNET.Core
dotnet add package ElectronNET.Core.AspNet
dotnet restore

{% endhighlight %}

{% endtabs %}

### 2. Update Program.cs to Integrate Electron.NET

Replace `YourProjectName` in the code below with your actual root namespace used by the App component (see `App.razor` or `_Imports.razor`).

{% tabs %}
{% highlight c# tabtitle="NET 10 (~/Program.cs)" hl_lines="2 3 4 5 15 18 21 22 23 24 25 26 27 28 29 30 32 34 35 36 40 49" %}

...
using Syncfusion.Blazor;
using Syncfusion.Licensing;
using ElectronNET.API;
using ElectronNET.API.Entities;

...

// Syncfusion licensing
SyncfusionLicenseProvider.RegisterLicense("YOUR LICENSE KEY");

...

// Syncfusion services
builder.Services.AddSyncfusionBlazor();

// Electron services
builder.Services.AddElectron();

// Electron window bootstrap (modern ElectronNET.Core)
builder.UseElectron(args, async () =>
{
    var options = new BrowserWindowOptions
    {
        Width = 1200,
        Height = 800,
        Show = false,
        AutoHideMenuBar = true,
        // IsRunningBlazor = true,   // Optional: enable if Blazor script loading issues occur.
    };

    var window = await Electron.WindowManager.CreateWindowAsync(options);

    window.OnReadyToShow += () => window.Show();
    window.OnClosed += () => Electron.App.Quit();
});

...

app.UseStaticFiles(); // Required for serving assets like _content/ (Syncfusion).

...

// app.UseHttpsRedirection();   <-- Do NOT enable for Electron app

...

// Map the root Razor Components app
app.MapRazorComponents<YourProjectName.Components.App>()
    .AddInteractiveServerRenderMode();

app.Run();

{% endhighlight %}
{% endtabs %}


### 3. Add Runtime Identifiers to Support Cross‑Platform Builds

Add the following property to your project’s `.csproj` file:

{% tabs %}

{% highlight c# tabtitle="csproj" hl_lines="3"  %}

<PropertyGroup>
    ...
    <RuntimeIdentifiers>win-x64;linux-x64;osx-x64;osx-arm64</RuntimeIdentifiers>
</PropertyGroup>

{% endhighlight %}

{% endtabs %}

### 4. Add electron-builder.json (Required for ElectronNET.Core)

ElectronNET.Core requires this file for packaging your desktop application.
Create a file named `electron-builder.json` inside your project’s `Properties` folder and add the following code.

{% tabs %}

{% highlight c# tabtitle="~/electron-builder.json" %}

{
  "appId": "com.companyname.blazorelectronapp",
  "productName": "Blazor Electron App",
  "directories": {
    "output": "dist-electron"
  },
  "files": [
    "**/*"
  ],
  "win": {
    "target": "nsis"
  },
  "mac": {
    "target": "dmg"
  },
  "linux": {
    "target": "AppImage"
  }
}

{% endhighlight %}

{% endtabs %}


### Run the application

```
dotnet run
```
![Blazor Electron App with .NET 10](images/blazor-server-electron.png)

### Publish and Build Desktop Packages

```
Windows: dotnet publish -r win-x64 -c Release
macOS: dotnet publish -r osx-x64 -c Release
Linux: dotnet publish -r linux-x64 -c Release
```

