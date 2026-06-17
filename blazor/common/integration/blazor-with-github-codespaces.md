---
layout: post
title: Integrating Blazor DataGrid with GitHub Codespaces | Syncfusion
description: Step by step guide to integrate Blazor DataGrid in a Blazor Web App using GitHub Codespaces with development container setup and cloud based execution.
platform: Blazor
control: Common
documentation: ug
---

# Integrating Blazor DataGrid with GitHub Codespaces

This article explains how to integrate the **[Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid)** and run it seamlessly in **[GitHub Codespaces](https://docs.github.com/en/codespaces/about-codespaces/what-are-codespaces)**.

GitHub Codespaces provides a cloud-based development environment that eliminates the need for local setup and enables instant development in Visual Studio Code directly in the browser.

## Prerequisites

Before getting started, ensure you have the following:

* A [GitHub](https://github.com/) account
* Access to [GitHub Codespaces](https://docs.github.com/en/codespaces)

## Configure a Development Container for .NET 10 and Blazor

To run the [Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) seamlessly in GitHub Codespaces, you need to configure a development container with the **.NET 10 SDK** and support for **ASP.NET Core and Blazor development**.

GitHub Codespaces automatically detects and applies settings from the `.devcontainer/devcontainer.json` file when launching a codespace. To ensure the environment is configured correctly, include this file in your repository before creating a codespace.

### Prerequisites for devcontainer setup

* A local Git client installed on your machine
* Your repository cloned locally or access to create files via GitHub web interface

### Create the devcontainer configuration

#### Step 1: Clone your repository

Clone your GitHub repository to your local machine:

{% tabs %}
{% highlight bash tabtitle="Terminal" %}

git clone <your-repo-url>
cd <your-repo>

{% endhighlight %}
{% endtabs %}

You can also create files directly in GitHub by navigating to your repository and selecting **Add file → Create new file**.

#### Step 2: Create the `.devcontainer` folder

Create a folder named `.devcontainer` at the root level of your repository.

{% tabs %}
{% highlight bash tabtitle="Terminal" %}

mkdir .devcontainer

{% endhighlight %}
{% endtabs %}

#### Step 3: Add the `devcontainer.json` file

Inside the `.devcontainer` folder, create a file named `devcontainer.json` and add the following configuration.

{% tabs %}
{% highlight json tabtitle=".devcontainer/devcontainer.json" %}

{
  "name": ".NET 10 Blazor + Syncfusion",

  "image": "mcr.microsoft.com/devcontainers/dotnet:10.0",

  "features": {
    "ghcr.io/devcontainers/features/github-cli:1": {}
  },

  "customizations": {
    "vscode": {
      "extensions": [
        "ms-dotnettools.csharp",
        "ms-dotnettools.csdevkit",
        "ms-dotnettools.vscodeintellicode-csharp",
        "ms-dotnettools.blazor-tools",
        "ms-azuretools.vscode-docker",
        "GitHub.codespaces"
      ]
    }
  },

  "forwardPorts": [5000, 5001],

  "portsAttributes": {
    "5000": {
      "label": "Blazor HTTP",
      "onAutoForward": "openBrowser",
      "requireLocalPort": false
    },
    "5001": {
      "label": "Blazor HTTPS",
      "onAutoForward": "silent",
      "requireLocalPort": false
    }
  },

  "postCreateCommand": "dotnet workload install wasm-tools",

  "postStartCommand": "dotnet restore || true",

  "updateContentCommand": "dotnet workload update",

  "remoteUser": "vscode",

  "remoteEnv": {
    "DOTNET_SYSTEM_GLOBALIZATION_INVARIANT": "false",
    "ASPNETCORE_ENVIRONMENT": "Development",
    "ASPNETCORE_URLS": "http://0.0.0.0:5000;https://0.0.0.0:5001",
    "DOTNET_CLI_TELEMETRY_OPTOUT": "true"
  },

  "waitFor": "postCreateCommand"
}

{% endhighlight %}
{% endtabs %}

### Key configuration details

* **Base image**: Uses the official .NET 10 development container image
* **Features**: Includes GitHub CLI for repository operations within Codespaces
* **VS Code extensions**: Installs C# development tools, Blazor tools, and Docker support automatically
* **Dual-port forwarding**: Exposes both HTTP (5000) and HTTPS (5001) for maximum compatibility
* **WebAssembly (WASM) tools**: Installs Blazor WebAssembly development tools via `workload install`
* **Environment variables**: Configures .NET globalization, development environment, and both protocol URLs
* **Post-create command**: Automatically restores NuGet packages and installs required workloads after container setup
* **Post-start restoration**: Runs `dotnet restore` on each container start, and the `|| true` ensures the container startup succeeds even if the restore encounters warnings or conflicts.

This configuration ensures your Codespaces environment is fully ready to build and run Blazor applications without any manual setup.

#### Step 4: Commit and push to GitHub

Commit the `.devcontainer` folder to your repository.

{% tabs %}
{% highlight bash tabtitle="Terminal" %}

git add .devcontainer/devcontainer.json
git commit -m "Add devcontainer configuration for Blazor development with Syncfusion"
git push origin main

{% endhighlight %}
{% endtabs %}

## Launch GitHub Codespaces

Now that the devcontainer configuration is available in your repository, launch GitHub Codespaces:

1. Open your GitHub repository in the browser.
2. Click on the **Code** button.
3. Select the **Codespaces** tab.
4. Click **Create codespace on main**.

GitHub Codespaces will automatically:

* Provision a cloud-based development environment
* Detect the `.devcontainer/devcontainer.json` configuration
* Install and configure the .NET 10 development container
* Install required VS Code extensions (C#, Blazor tools, Docker, and GitHub CLI)
* Execute the post-create command to restore NuGet packages
* Install Blazor WebAssembly workload tools
* Launch Visual Studio Code in the browser

After Codespaces has finished initializing, open the terminal and ensure there are no setup errors. In some cases, the output of the post-create command may not be visible. To confirm that the setup completed successfully, you can run the application or verify that the required workloads have been installed.

## Create a Blazor project

Once the Codespaces environment has fully loaded, open the terminal and navigate to the root directory of your repository. Then run the following commands to create a new **Blazor Web App (Interactive Server)**.

{% tabs %}
{% highlight bash tabtitle=".NET CLI" %}

dotnet new blazor -o BlazorApp --interactivity Server
cd BlazorApp

{% endhighlight %}
{% endtabs %}

## Install Blazor NuGet packages

Install the [Syncfusion.Blazor.Grid](https://www.nuget.org/packages/Syncfusion.Blazor.Grid/) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/) NuGet packages. All Syncfusion Blazor packages are available on [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). See the [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for details.

{% tabs %}

{% highlight bash tabtitle=".NET CLI" %}

dotnet add package Syncfusion.Blazor.Grid -v {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Themes -v {{ site.releaseversion }}
dotnet restore

{% endhighlight %}

{% endtabs %}

## Add required namespaces

After the packages are installed, open the `~/_Imports.razor` file and import the `Syncfusion.Blazor` and `Syncfusion.Blazor.Grids` namespaces.

{% tabs %}
{% highlight razor tabtitle="_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Grids

{% endhighlight %}
{% endtabs %}

## Register Blazor service

Open the `~/Program.cs` file in Blazor Web App and register the Blazor service to enable Blazor components in the application.

{% tabs %}
{% highlight C# tabtitle="Program.cs" hl_lines="1 9" %}

using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Register Blazor service
builder.Services.AddSyncfusionBlazor();

var app = builder.Build();

{% endhighlight %}

{% endtabs %}

## Add stylesheet and script resources

The theme stylesheet and script can be accessed from NuGet through [Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets). Include the [stylesheet](https://blazor.syncfusion.com/documentation/appearance/themes) and [script references](https://blazor.syncfusion.com/documentation/common/adding-script-references) in the `~/App.razor` file.

{% tabs %}
{% highlight html tabtitle="App.razor" %}

<head>
    ...
    <link href="_content/Syncfusion.Blazor.Themes/fluent2.css" rel="stylesheet" />
</head>

<body>
    ...
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
</body>

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

dotnet run --urls=http://0.0.0.0:5000;https://0.0.0.0:5001

{% endhighlight %}

{% endtabs %}

### Access the application

After running:

1. Codespaces automatically detects the running ports.
2. Open the **Ports** panel in the VS Code bottom panel.
3. Click **Open in Browser** on the HTTP port (5000) for the best experience.

The Blazor application will load with the DataGrid.

## Expected behavior

* The DataGrid loads with 10 order records
* Fully interactive UI runs inside the browser

## See also

* [Getting Started with Blazor DataGrid in Blazor Web App](https://blazor.syncfusion.com/documentation/datagrid/getting-started-with-web-app)
* [Getting Started with Blazor DataGrid in Blazor WASM](https://blazor.syncfusion.com/documentation/datagrid/getting-started)
