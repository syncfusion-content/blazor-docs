---
layout: post
title: Deploying Blazor WebAssembly with Syncfusion Components to GitHub Pages
description: Guide to deploying Syncfusion Blazor Components to GitHub Pages with complete configuration and examples.
platform: Blazor
control: Common
documentation: ug
---

# Deploying Syncfusion® Blazor Components to GitHub Pages

This guide demonstrates how to deploy a Blazor WebAssembly application with [Syncfusion components](https://www.syncfusion.com/blazor-components) to GitHub Pages.

## Prerequisites

* [.NET SDK 10.0](https://dotnet.microsoft.com/en-us/download/visual-studio-sdks)
* [Visual Studio](https://visualstudio.microsoft.com/downloads/) 2022 or later or [Visual Studio Code](https://code.visualstudio.com/) with [C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit) extension
* [GitHub account](https://github.com/)

If you haven't created your Blazor app yet, follow the [Blazor getting started guide](https://blazor.syncfusion.com/documentation/getting-started/blazor-webassembly-app) to create a Blazor WebAssembly project. 

## Create GitHub repository

Follow the below steps to create GitHub repository for deploying blazor application.

* Go to [GitHub](https://github.com). Sign in using your GitHub account credentials.
* From the GitHub homepage, click the **"+"** icon in the top‑right corner and select **New repository**.
* Enter a repository name that matches your Blazor deployment path. And select **Public** visibility.
* Click **Create Repository** button to create the repository.

## Create Syncfusion® DataGrid component

### Install required packages

To add the Blazor DataGrid component, open the NuGet Package Manager in Visual Studio (*Tools → NuGet Package Manager → Manage NuGet Packages for Solution*), then search and install the NuGet package listed below.

* [Syncfusion.Blazor.Grid](https://www.nuget.org/packages/Syncfusion.Blazor.Grid)
* [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/)

### Add required namespaces

Open the `~/_Imports.razor` file and import the `Syncfusion.Blazor`, `Syncfusion.Blazor.Grids` namespaces.

{% tabs %}
{% highlight razor tabtitle="~/_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Grids

{% endhighlight %}
{% endtabs %}

### Register Syncfusion® Blazor service

Add the Syncfusion Blazor service to the `~/Program.cs` file to enable Syncfusion components into the application.


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

Add the Syncfusion theme CSS and required scripts to the `~/Components/App.razor` file.

{% tabs %}
{% highlight html tabtitle="App.razor" %}

<head>
     <!-- Syncfusion theme style sheet -->
    <link href="_content/Syncfusion.Blazor.Themes/fluent2.css" rel="stylesheet" />
</head>
<body>
    <!-- Syncfusion Blazor script reference -->
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js"></script>
    <!-- Blazor WebAssembly script reference -->
  <script src="_framework/blazor.webassembly.js"></script>
</body>

{% endhighlight %}
{% endtabs %}

N> Syncfusion provides multiple theme variants, allowing selection of the theme that best aligns with the application's UI design. Additional theme options and customization details are available in the [theming documentation](https://blazor.syncfusion.com/documentation/appearance/themes).

### DataGrid component example

This sample demonstrates the [Syncfusion DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) component to deploy.

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

@page "/"

@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders">
  <GridColumns>
      <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID"></GridColumn>
      <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
      <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d"></GridColumn>
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

Edit `.csproj` and add the following properties to the first `<PropertyGroup>` element:

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

N> These settings are **required** for GitHub Pages deployment. Fingerprinting creates unpredictable file names, and compression creates .br/.gz variants that GitHub Pages cannot serve correctly. Disabling these ensures stable asset paths and predictable client-side references.

### Update base path for relative routing

GitHub Pages hosts applications as subfolders under a user or organization domain. Update `wwwroot/index.html` to use relative paths:

{% tabs %}
{% highlight razor tabtitle="index.html" %}

<!-- BEFORE -->
<base href="/" />

<!-- AFTER -->
<base href="./" />

{% endhighlight %}
{% endtabs %}

This change ensures that all relative paths work correctly when the app is served from `https://<username>.github.io/<repo>/`.

### Create `404.html` for SPA route fallback

GitHub Pages does not understand client-side Blazor routes. Create `wwwroot/404.html` to redirect all 404 errors back to `index.html`:

{% tabs %}
{% highlight razor tabtitle="404.html" %}

<!DOCTYPE html>
<html>
<head>
  <meta http-equiv="refresh" content="0; url=./index.html">
</head>
<body></body>
</html>

{% endhighlight %}
{% endtabs %}

When a user navigates directly to a Blazor route (e.g., `/counter`), GitHub Pages returns a 404. This file redirects to `index.html`, allowing Blazor's client-side router to handle the route correctly.

## Deployment workflow

### Run the application locally

Before deployment, test the application locally to ensure all components render correctly. Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to launch the application.

**Expected behavior:**
- The application loads without errors.
- Syncfusion components render with correct styles and fonts.
- Navigation between pages works as expected.
- No JavaScript console errors appear.

### Commit to GitHub

Initialize a git repository and commit your source code to the main branch:

{% tabs %}
{% highlight cs tabtitle="Git CLI" %}

git init
git add .
git commit -m "Initial commit"
git remote add origin https://github.com/<you>/<repo>.git
git branch -M main
git push -u origin main

{% endhighlight %}
{% endtabs %}

These commands create a local repository, commit your code, add the remote URL, rename the branch to `main`, and push to GitHub.

### Publish for GitHub Pages

Publish the application in Release mode with fingerprinting and compression disabled:

{% tabs %}
{% highlight bash tabtitle=".NET CLI" %}

dotnet publish -c Release -p:StaticWebAssetFingerprintingEnabled=false -p:BlazorEnableCompression=false -o publish

{% endhighlight %}
{% endtabs %}

This produces an optimized `publish/wwwroot` directory ready for deployment. The explicit property flags override any project file settings to ensure correct behavior.

### Deploy to Github pages branch

Navigate to the published wwwroot directory and push to the branch. In the following use `gh-pages` as a branch name.

{% tabs %}
{% highlight cs tabtitle="Git CLI" %}

cd publish\wwwroot
New-Item -ItemType File -Path .nojekyll -Force
git init
git checkout -b gh-pages
git add .
git commit -m "Deploy Blazor WASM to GitHub Pages"
git remote add origin https://github.com/<username>/<repo>.git
git push -f origin gh-pages

{% endhighlight %}
{% endtabs %}

**What each command does:**

* `New-Item -ItemType File -Path .nojekyll -Force` Creates a `.nojekyll` marker file that prevents GitHub Pages from processing the content with Jekyll.
* `git init` Initializes a new git repository in the published directory.
* `git checkout -b gh-pages` Creates and checks out the `gh-pages` branch.
* `git add .` Stages all files for commit.
* `git commit -m "..."` Commits the static files.
* `git push -f origin gh-pages` Force-pushes to the remote `gh-pages` branch (use `-f` only on first deployment).

### Enable GitHub Pages

Configure your repository to serve the `gh-pages` branch:

1. Go to your repository on GitHub.
2. Navigate to **Settings** → **Pages**.
3. Under **Source**, select:
   - **Branch:** `gh-pages`
   - **Folder:** `/ (root)`
4. Click **Save**.

Your application will be live at `https://<username>.github.io/<repo>/` within minutes.

## See Also

* [Blazor WebAssembly Hosting and Deployment](https://learn.microsoft.com/en-us/aspnet/core/blazor/host-and-deploy/webassembly/github-pages?view=aspnetcore-10.0)
* [Syncfusion Blazor Components Documentation](https://blazor.syncfusion.com/documentation/getting-started/blazor-webassembly-app)
* [GitHub Pages Configuration](https://docs.github.com/en/pages/getting-started-with-github-pages/about-github-pages)
* [Getting started with DataGrid component](https://blazor.syncfusion.com/documentation/datagrid/getting-started)
