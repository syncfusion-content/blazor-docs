---
layout: post
title: Testing Blazor Applications with Playwright | Syncfusion®
description: Learn how to perform end-to-end UI testing for Syncfusion® Blazor applications using Microsoft Playwright, including testing complete workflows.
platform: Blazor
component: Common
documentation: ug
---

# Testing Syncfusion® Blazor applications with Playwright

This guide demonstrates how to integrate Syncfusion® UI components into a Blazor WebAssembly application and validate them through end‑to‑end tests using Microsoft Playwright. It provides a clear, step‑by‑step approach for building reliable and maintainable UI automation for Syncfusion® components in Blazor applications.

## Why Playwright with Syncfusion® Blazor?

- **Syncfusion® Blazor** provides rich UI components such as Buttons, Grids, and Charts for building modern web applications.
- **Playwright** enables reliable cross‑browser UI testing across Chromium, Firefox, and WebKit.
- Using Syncfusion® Blazor with Playwright, you can validate real user interactions, test complete end‑to‑end user flows, and catch UI regressions early.

## Create a Blazor project

If you already have a Blazor project configured, you can skip this section and proceed to **Install required packages**.

Otherwise, create a new Blazor application by following the Syncfusion® getting started guides [Blazor WebAssembly App](https://blazor.syncfusion.com/documentation/getting-started/blazor-webassembly-app)

## Install required packages

Open the NuGet Package Manager in Visual Studio from (*Tools → NuGet Package Manager → Manage NuGet Packages for Solution*), and install the required package.

- [Syncfusion.Blazor](https://www.nuget.org/packages/Syncfusion.Blazor/)
- [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/)

## Add Syncfusion® namespaces

Open the `_Imports.razor` file at the root of your project and import the Syncfusion® namespaces.

{% tabs %}
{% highlight razor tabtitle="_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Buttons

{% endhighlight %}
{% endtabs %}

## Register Syncfusion® Blazor service

Add the Syncfusion® Blazor service to the `Program.cs` file to enable Syncfusion® components in the application.

{% tabs %}
{% highlight c# tabtitle="Program.cs" hl_lines="1 8"% }

using Syncfusion.Blazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSyncfusionBlazor();

await builder.Build().RunAsync();

{% endhighlight %}
{% endtabs %}

## Add stylesheet and script resources

Include the theme stylesheet and script references in the `wwwroot/index.html` file.

{% tabs %}
{% highlight html  %}

<head>
    <!-- Syncfusion theme stylesheet -->
    <link href="_content/Syncfusion.Blazor.Themes/fluent2.css" rel="stylesheet" />
    <!-- Syncfusion Blazor component's script reference -->
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
</head>

{% endhighlight %}
{% endtabs %}

## Create a Syncfusion® page

Create a Razor page to demonstrate a simple Syncfusion® UI interaction that can be validated using Playwright tests.

This page contains a **Syncfusion® Button**, allowing you to verify user interaction and UI behavior during end‑to‑end testing.

{% tabs %}
{% highlight razor %}

@page "/"

@using Syncfusion.Blazor.Buttons

<PageTitle>Syncfusion Demo</PageTitle>

<h1>Syncfusion Demo</h1>

<SfButton Content="Click Sync" OnClick="@OnSyncClick"></SfButton>

<p id="sync-result">@result</p>

@code {
    private string result = "Not clicked";

    private void OnSyncClick(MouseEventArgs args)
    {
        result = "Clicked";
    }
}

{% endhighlight %}
{% endtabs %}

## Create a Playwright test project

In this step, you create a separate test project to write and manage Playwright end‑to‑end tests for your Syncfusion® Blazor application.

From the solution root directory, run the following commands to create a new test project:

{% tabs %}
{% highlight bash tabtitle=".NET CLI" %}

dotnet new nunit -o tests/E2E.Tests   
cd tests/E2E.Tests

{% endhighlight %}
{% endtabs %}

This command creates an NUnit test project named **E2E.Tests** under the tests folder, which will host all Playwright‑based UI tests.

**Install required packages**

Install the following NuGet packages into the E2E.Tests project to enable Playwright‑based end‑to‑end testing in the test project.

- [Microsoft.Playwright](https://www.nuget.org/packages/microsoft.playwright)
- [NUnit](https://www.nuget.org/packages/nunit/)
- [NUnit3TestAdapter](https://www.nuget.org/packages/NUnit3TestAdapter)
- [Microsoft.NET.Test.Sdk](https://www.nuget.org/packages/Microsoft.NET.Test.Sdk)

## Install the Playwright CLI

Playwright requires browser binaries (Chromium, Firefox, and WebKit) to run UI tests. These browsers must be installed separately after the test project is restored and built.

**Step 1: Install the Playwright CLI (if not already installed)**

Playwright provides a global .NET CLI tool for managing browser installations. 
Run the following command in a Terminal.

{% tabs %}
{% highlight bash tabtitle=" Terminal " %}

dotnet tool install --global Microsoft.Playwright.CLI

// Restore the test project
dotnet restore tests/E2E.Tests

{% endhighlight %}
{% endtabs %}

If the tool is already installed, this command can be safely skipped.

**Step 2: Install Playwright browsers**

After the CLI is available, install the required browsers by running:

{% tabs %}
{% highlight bash tabtitle=" Terminal " %}

playwright install

{% endhighlight %}
{% endtabs %}

## Create Playwright test class

Create a new C# file named `BlazorPlaywrightTests.cs` in the Playwright test project (E2E.Tests). This file contains the end‑to‑end test logic and manages the Playwright browser lifecycle.

{% tabs %}
{% highlight C# tabtitle="BlazorPlaywrightTests.cs" %}

using Microsoft.Playwright;
using NUnit.Framework;
using System.Diagnostics;
using System.Net.Http;

namespace E2E.Tests
{
    public class BlazorPlaywrightTests
    {
        private Process? _serverProcess;
        private IPlaywright? _playwright;
        private IBrowser? _browser;
        // Replace with your app URL and port from Properties/launchSettings.json in your Blazor project (look for the "applicationUrl" value).
        private readonly string _url = "http://localhost:5002";

        [OneTimeSetUp]
        public async Task OneTimeSetup()
        {
            var projectPath = @"<Absolute path to your Blazor application's .csproj file>"; // Example: @"C:\\Users\\MyBlazorApp\\MyBlazorApp.csproj";

            var psi = new ProcessStartInfo(
                "dotnet",
                $"run --project \"{projectPath}\" --urls {_url}")
            {
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            _serverProcess = Process.Start(psi);

            // wait for server to respond
            using var client = new HttpClient();
            var started = false;
            for (int i = 0; i < 30; i++)
            {
                try
                {
                    var response = await client.GetAsync(_url);
                    if (response.IsSuccessStatusCode)
                    {
                        started = true;
                        break;
                    }
                }
                catch
                {
                    // Ignore connection errors while waiting for app to start
                }
                await Task.Delay(1000);
            }

            _playwright = await Playwright.CreateAsync();
            _browser = await _playwright.Chromium.LaunchAsync(
                new BrowserTypeLaunchOptions
                {
                    Headless = true
                });
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            _browser?.CloseAsync().GetAwaiter().GetResult();
            _playwright?.Dispose();
            if (_serverProcess is { HasExited: false })
                _serverProcess.Kill(true);
        }

        [Test]
        public async Task SyncfusionButton_Works()
        {
            var page = await _browser!.NewPageAsync();
            await page.GotoAsync(_url + "/");
            await page.ClickAsync("text=Click Sync");

            var result = await page.InnerTextAsync("#sync-result");
            Assert.That(result, Is.EqualTo("Clicked"));
        }
    }
}

{% endhighlight %}
{% endtabs %}

## Run the tests

You can execute the Playwright end‑to‑end tests to validate the behavior of your Syncfusion® Blazor application.

From the solution root directory, run the following command.

{% tabs %}
{% highlight bash tabtitle="Terminal" %}

dotnet test tests/E2E.Tests

{% endhighlight %}
{% endtabs %}

This command builds the test project, launches the Blazor application, and runs all Playwright tests defined in the `BlazorPlaywrightTests.cs` file.

To visually observe the test execution, run the browser in non‑headless mode by setting `Headless = false` in the Playwright browser launch options.

{% tabs %}
{% highlight cs tabtitle="BlazorPlaywrightTests.cs" %}

_browser = await _playwright.Chromium.LaunchAsync(
    new BrowserTypeLaunchOptions
    {
        Headless = false,
        SlowMo = 50
    });

{% endhighlight %}
{% endtabs %}

This approach ensures reliable validation of Syncfusion® Blazor UI components and enables early detection of UI regressions through automated end‑to‑end testing.

## See also

- [Getting started with Syncfusion® Blazor Button in WASM app](https://blazor.syncfusion.com/documentation/button/getting-started)
- [Guide for installing Playwright Browsers (CLI)](https://playwright.dev/dotnet/docs/intro)
