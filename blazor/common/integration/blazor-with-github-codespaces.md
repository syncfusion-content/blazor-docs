---
layout: post
title: Integrating Blazor DataGrid with GitHub Codespaces | Syncfusion
description: Step-by-step guide to set up and run Blazor DataGrid using GitHub Codespaces.
platform: Blazor
control: Common
documentation: ug
---

# Integrating Blazor DataGrid with GitHub Codespaces

This article provides step-by-step instructions on how to integrate the **[Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid)** and run it seamlessly using **[GitHub Codespaces](https://docs.github.com/en/codespaces/about-codespaces/what-are-codespaces)**.

GitHub Codespaces provides a cloud-based development environment, eliminating the need for local setup and enabling instant development using Visual Studio Code in the browser.

## Prerequisites

Before getting started, ensure you have the following:

* A [GitHub](https://github.com/) account
* Access to [GitHub Codespaces](https://docs.github.com/en/codespaces)

## Configure Dev Container for .NET 10 and Blazor

To run the [Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) in GitHub Codespaces, you need to configure a development container that includes the .NET 10 SDK and supports ASP.NET Core development.

Create a folder named `.devcontainer` at the root level of your repository and add a file named `devcontainer.json` with the following configuration.

{% tabs %}

{% highlight json tabtitle=".devcontainer/devcontainer.json" %}

{
  "name": "Blazor Codespaces - .NET 10",
  "image": "mcr.microsoft.com/devcontainers/dotnet:1-10.0",
  "features": {},
  "customizations": {
    "vscode": {
      "extensions": [
        "ms-dotnettools.csharp",
        "ms-dotnettools.csdevkit",
        "ms-azuretools.vscode-docker"
      ]
    }
  },
  "forwardPorts": [5000, 5001],
  "portsAttributes": {
    "5001": {
      "label": "Blazor App (HTTPS)",
      "onAutoForward": "openBrowser"
    }
  },
  "postCreateCommand": "dotnet restore",
  "remoteUser": "vscode"
}

{% endhighlight %}

{% endtabs %}

### Key configuration details

* **Base image**: Uses the official .NET 10 development container image  
* **VS Code extensions**: Installs C# and .NET development tools automatically  
* **Port forwarding**: Exposes HTTPS port 5001 for the Blazor application  
* **Post-create command**: Restores project dependencies after container setup  

This configuration ensures your Codespaces environment is fully ready to build and run Syncfusion Blazor applications.

## Launch GitHub Codespaces

1. Open your GitHub repository.
2. Click on the **Code** button.
3. Select the **Codespaces** tab.
4. Click **Create codespace on main**.

GitHub Codespaces will automatically:

* Provision a cloud-based development environment
* Install required dependencies (based on `.devcontainer`)
* Configure the development container
* Launch Visual Studio Code in the browser

## Create a Blazor project

Once the Codespaces environment loads, open the terminal and navigate to the root level of your repository and create a new Blazor application by following the [Getting started guide](https://blazor.syncfusion.com/documentation/getting-started/blazor-web-app) for a **Blazor Web App (Interactive Server)**.

## Install Blazor NuGet packages

Install the following NuGet packages from the project folder (where the `.csproj` file is located) to use the [Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) component. All Syncfusion Blazor packages are available on [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). See the [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for details.

* [Syncfusion.Blazor.Grid](https://www.nuget.org/packages/Syncfusion.Blazor.Grid)
* [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/)

{% tabs %}

{% highlight bash tabtitle=".NET CLI" %}

dotnet add package Syncfusion.Blazor.Grid -v {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Themes -v {{ site.releaseversion }}
dotnet restore

{% endhighlight %}

{% endtabs %}


## Add required namespaces

After the packages are installed, update the required namespaces in `~/Components/_Imports.razor` file.

{% tabs %}

{% highlight razor tabtitle="_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Grids

{% endhighlight %}

{% endtabs %}

## Register Blazor service

Open the `Program.cs` file in Blazor Web App and register the Blazor service to enable Blazor components in the application.

{% tabs %}

{% highlight c# tabtitle="Program.cs" hl_lines="1 9" %}

using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Register Syncfusion Blazor service
builder.Services.AddSyncfusionBlazor();

var app = builder.Build();

{% endhighlight %}

{% endtabs %}

## Add stylesheet and script resources

The theme stylesheet and script can be accessed from NuGet through [Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets). Include the [stylesheet](https://blazor.syncfusion.com/documentation/appearance/themes) and [script references](https://blazor.syncfusion.com/documentation/common/adding-script-references) in the `App.razor` file.

{% tabs %}

{% highlight html tabtitle="App.razor" %}

<head>
    ...
    <link href="_content/Syncfusion.Blazor.Themes/fluent2.css" rel="stylesheet" />
</head>

<body>
    ...
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js"></script>
</body>

{% endhighlight %}

{% endtabs %}

## Configure render mode (Server)

Add the Server render mode to the Razor page.

{% tabs %}

{% highlight razor %}

@rendermode InteractiveServer

{% endhighlight %}

{% endtabs %}

## Add Blazor DataGrid component

Open a Razor file located in the `~/Pages/*.razor` (for example, `Home.razor`) and add the [Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) component inside the razor file.

{% tabs %}

{% highlight razor tabtitle="Home.razor" %}

@page "/"
@rendermode InteractiveServer

<h3>Blazor DataGrid in Codespaces</h3>

<SfGrid DataSource="@Orders" />

@code {
    public List<Order> Orders { get; set; }

    protected override void OnInitialized()
    {
        var customers = new string[] { "James Hopper", "Michael Smith", "Sarah Johnson", "Robert Davis", "Emily Wilson" };
        var cities = new string[] { "New York", "Los Angeles", "Chicago", "Houston", "Phoenix" };
        var rng = new Random();
        Orders = Enumerable.Range(1, 10).Select(x => new Order()
        {
            OrderID = 1000 + x,
            CustomerName = customers[rng.Next(customers.Length)],
            ShipCity = cities[rng.Next(cities.Length)],
            Freight = Math.Round(10.5 + (x * 7.3), 2),
            OrderDate = DateTime.Now.AddDays(-x),
        }).ToList();
    }

    public class Order {
        public int? OrderID { get; set; }
        public string CustomerName { get; set; }
        public string ShipCity { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }
}

{% endhighlight %}

{% endtabs %}

## Run the application in Codespaces

In the Codespaces terminal, run:

{% tabs %}

{% highlight bash tabtitle=".NET CLI" %}

dotnet run --urls=https://0.0.0.0:5001

{% endhighlight %}

{% endtabs %}

### Access the application

After running:

1. Codespaces automatically detects the running port.
2. Open the **Ports** panel.
3. Click **Open in Browser** for the exposed port.

The Blazor application will load with the DataGrid.

## Expected behavior

* The DataGrid loads with 10 employee records
* Paging and sorting are enabled
* Fully interactive UI runs inside the browser

## Codespaces configuration details

Ensure your repository includes a `.devcontainer/devcontainer.json` file with:

* .NET SDK installation
* Port forwarding configuration
* Recommended VS Code extensions for C# and Blazor

## Benefits of using Codespaces

### No local setup required

Develop and run Blazor applications directly in the browser.

### Consistent development environment

All developers work with the same configuration.

### Faster onboarding

New developers can start instantly without environment setup.

### Cloud-based execution

Access your project from anywhere without dependency issues.

## Use cases

Using Syncfusion Blazor DataGrid with GitHub Codespaces enables:

### Rapid development

Build and test DataGrid features instantly in a cloud environment.

### Team collaboration

Share repository access and allow others to launch identical environments.

### Training and demos

Provide ready-to-use environments for learning and demonstrations.

### Cloud-first development

Integrate easily with GitHub workflows and CI/CD pipelines.

## See also

* [Getting Started with Blazor DataGrid](https://blazor.syncfusion.com/documentation/datagrid/getting-started-with-web-app)
* [GitHub Codespaces Documentation](https://docs.github.com/en/codespaces)
* [Syncfusion Blazor Components Overview](https://www.syncfusion.com/blazor-components)