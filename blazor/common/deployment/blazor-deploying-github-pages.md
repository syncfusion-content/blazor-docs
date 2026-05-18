---
layout: post
title: Deploying Blazor WASM with Blazor Components to GitHub Pages
description: Guide to deploying Blazor Components to GitHub Pages with complete configuration and examples.
platform: Blazor
control: Common
documentation: ug
---

# Deploying Blazor Components to GitHub Pages

This guide demonstrates how to deploy [Blazor components](https://www.syncfusion.com/blazor-components) to [GitHub Pages](https://docs.github.com/en/pages/getting-started-with-github-pages/configuring-a-publishing-source-for-your-github-pages-site) in a Blazor WebAssembly application. It includes steps for publishing the application, configuring client-side routing, and hosting the application.

## Prerequisites

* [.NET SDK 10.0](https://dotnet.microsoft.com/en-us/download/visual-studio-sdks)
* [Visual Studio](https://visualstudio.microsoft.com/downloads/) 2022 or later or [Visual Studio Code](https://code.visualstudio.com/) with [C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit) extension
* [GitHub account](https://github.com/)

If you haven't created your Blazor app yet, follow the [Blazor getting started guide](https://blazor.syncfusion.com/documentation/getting-started/blazor-webassembly-app) to create a Blazor WebAssembly project.

## Create GitHub repository

Follow the below steps to create GitHub repository for deploying Blazor application.

* Go to [GitHub](https://github.com). Sign in using your GitHub account credentials.
* From the GitHub homepage, click the **"+"** icon in the top‑right corner and select **New repository**.
* Enter a repository name:
     * For a **user** or **organization site**: `<username>.github.io`
     * For a **project site**: any repository name (for example, `blazor-demo`)
* Select **Public** visibility.
* Click **Create Repository** button to create the repository.

## Configure Blazor DataGrid component

### Install required packages

To add the Blazor DataGrid component, install the required packages through NuGet Package Manager in Visual Studio (*Tools → NuGet Package Manager → Manage NuGet Packages for Solution*), or the integrated terminal in Visual Studio Code (`dotnet add package`), or the .NET CLI.

* [Syncfusion.Blazor.Grid](https://www.nuget.org/packages/Syncfusion.Blazor.Grid)
* [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/)

You can install the required packages by using the following .NET CLI commands.

{% tabs %}
{% highlight bash tabtitle=".NET CLI" %}

dotnet add package Syncfusion.Blazor.Grid -v {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Themes -v {{ site.releaseversion }}
dotnet restore

{% endhighlight %}
{% endtabs %}

### Add required namespaces

Open the `~/_Imports.razor` file and import the `Syncfusion.Blazor`, `Syncfusion.Blazor.Grids` namespaces.

{% tabs %}
{% highlight razor tabtitle="~/_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Grids

{% endhighlight %}
{% endtabs %}

### Register Blazor service

Add the Blazor service to the `~/Program.cs` file to enable Blazor components in the application.

{% tabs %}
{% highlight cs tabtitle="~/Program.cs" %}

...
using Syncfusion.Blazor;
...
builder.Services.AddSyncfusionBlazor();
...

{% endhighlight %}
{% endtabs %}

### Add stylesheet and script resources

Add the Blazor theme CSS and required scripts to the `~/wwwroot/index.html` file.

{% tabs %}
{% highlight html tabtitle="index.html" %}

<head>
    <!-- Blazor theme stylesheet -->
    <link href="_content/Syncfusion.Blazor.Themes/fluent2.css" rel="stylesheet" />
</head>
<body>
    <!-- Blazor core script (required for UI components, including DataGrid) -->
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
    <!-- Blazor WebAssembly script reference -->
  <script src="_framework/blazor.webassembly.js"></script>
</body>

{% endhighlight %}
{% endtabs %}

### DataGrid component example

This sample demonstrates how to use the [Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) component to display a list of orders. It also helps confirm that the DataGrid is correctly integrated and functioning as expected for deployment scenarios.

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

@page "/"

@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders">
  <GridColumns>
      <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID"></GridColumn>
      <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
      <GridColumn Field=@nameof(Order.OrderDate) HeaderText="Order Date" Format="d"></GridColumn>
      <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2"></GridColumn>
  </GridColumns>
</SfGrid>

@code{
    public List<Order> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 10).Select(x => new Order()
        {
            OrderID = 1000 + x,
            CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
            Freight = 2 * x,
            OrderDate = DateTime.Now.AddDays(-x),
        }).ToList();
    }

    public class Order {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

## Configuration changes for GitHub Pages

### Disable fingerprinting and compression

Edit `.csproj` and add the following properties to the first `<PropertyGroup>` element.

{% tabs %}
{% highlight xml tabtitle=".csproj" %}

<PropertyGroup>
  <TargetFramework>net10.0</TargetFramework>
  <!-- Disable hashed file names for GitHub Pages compatibility -->
  <StaticWebAssetFingerprintingEnabled>false</StaticWebAssetFingerprintingEnabled>
  <!-- Disable .br / .gz compression files -->
  <BlazorEnableCompression>false</BlazorEnableCompression>
</PropertyGroup>

{% endhighlight %}
{% endtabs %}

### Update base path for relative routing

GitHub Pages hosts applications as subfolders under a user or organization domain. Update `wwwroot/index.html` to use relative paths.

{% tabs %}
{% highlight razor tabtitle="index.html" %}

<!-- BEFORE -->
<base href="/" />

<!-- AFTER -->
<base href="./" />

{% endhighlight %}
{% endtabs %}

This change ensures that all relative paths work correctly when the app is served from GitHub Pages.

### Create `404.html` for SPA route fallback

GitHub Pages does not understand client-side Blazor routes. When a user navigates directly to a Blazor route (e.g., `/counter`), GitHub Pages cannot find a matching file and returns a 404 error. The `404.html` file below redirects such requests to `index.html`, allowing Blazor's client-side router to handle the navigation.

Create `wwwroot/404.html` file.

{% tabs %}
{% highlight html tabtitle="404.html" %}

<!DOCTYPE html>
<html>
<head>
  <meta http-equiv="refresh" content="0; url=./index.html">
</head>
<body></body>
</html>

{% endhighlight %}
{% endtabs %}

**How it works:** The meta refresh redirects all 404s to `index.html`, allowing the Blazor WebAssembly router to handle navigation based on the current URL.

## Deployment workflow

### Run the application locally

Before deployment, test the application locally to ensure all components render correctly. Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to launch the application.

Alternatively, run the application using the following .NET CLI command from the project root directory.

{% tabs %}
{% highlight bash tabtitle=".NET CLI" %}

dotnet run

{% endhighlight %}
{% endtabs %}

**Expected behavior:**
- The application loads without errors.
- Blazor components render with correct styles and fonts.
- Navigation between pages works as expected.
- No JavaScript console errors appear.

### Commit to GitHub

Initialize a git repository and commit your source code to the **main branch**.

{% tabs %}
{% highlight cs tabtitle="Git CLI" %}

git init
git add .
git commit -m "Initial commit"
git remote add origin https://github.com/<username>/<repository-name>.git
git branch -M main
git push -u origin main

{% endhighlight %}
{% endtabs %}

These commands create a local repository, commit your code, add the remote URL, rename the branch to `main`, and push to GitHub.

### Publish for GitHub Pages

Publish the application in Release mode with fingerprinting and compression disabled.

{% tabs %}
{% highlight bash tabtitle=".NET CLI" %}

dotnet publish -c Release -p:StaticWebAssetFingerprintingEnabled=false -p:BlazorEnableCompression=false -o publish

{% endhighlight %}
{% endtabs %}

This produces an optimized `publish/wwwroot` directory ready for deployment. The explicit property flags override any project file settings to ensure correct behavior.

### Deploy to GitHub pages branch

Navigate to the published `wwwroot` directory and push the output files to the branch (e.g., `github-pages`) to deploy the application on GitHub Pages.

{% tabs %}
{% highlight cs tabtitle="Git CLI" %}

cd publish\wwwroot
New-Item -ItemType File -Path .nojekyll -Force
git init
git checkout -b github-pages
git add .
git commit -m "Deploy Blazor WASM to GitHub Pages"
git remote add origin https://github.com/<username>/<repository-name>.git
git push -f origin github-pages

{% endhighlight %}
{% endtabs %}

The above commands navigate to the published output directory and create a file to ensure that Blazor framework files are served correctly. They then initialize a Git repository and create a `github-pages` branch. All generated files are added and committed, and the repository is linked to GitHub. Finally, the content is pushed to the `github-pages` branch to deploy the application on GitHub Pages.

### Enable GitHub Pages

Configure your repository to serve the branch by following the steps below.

1. Go to your repository on GitHub.
2. Navigate to **Settings** → **Pages**.
3. Under **Source**, select:
   - **Branch:** `branch-name`
   - **Folder:** `/ (root)`
4. Click **Save**.

Your application will be live at a GitHub Pages within minutes.

## See Also

* [Getting started with Blazor WebAssembly App](https://blazor.syncfusion.com/documentation/getting-started/blazor-webassembly-app)
* [Getting started with Blazor DataGrid component](https://blazor.syncfusion.com/documentation/datagrid/getting-started)
* [Blazor WebAssembly Hosting and Deployment](https://learn.microsoft.com/en-us/aspnet/core/blazor/host-and-deploy/webassembly/github-pages?view=aspnetcore-10.0)
* [GitHub Pages Configuration](https://docs.github.com/en/pages/getting-started-with-github-pages/about-github-pages)