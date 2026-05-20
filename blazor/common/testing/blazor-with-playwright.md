---
layout: post
title: Blazor Components E2E Test Automation with Playwright | Syncfusion®
description: Learn to automate end-to-end testing of Syncfusion Blazor components using Playwright and NUnit in a .NET WebAssembly app.
platform: Blazor
component: Common
documentation: ug
---

# End-to-End Test Automation for Blazor Components with Playwright

This guide explains how to integrate [Blazor components](https://www.syncfusion.com/blazor-components) into a **Blazor WebAssembly Standalone App** and validate them through end‑to‑end tests using [Playwright](https://playwright.dev/dotnet).

Playwright enables automated end‑to‑end (E2E) testing by simulating real user interactions such as clicking, typing, and navigation across the application. These tests can be executed repeatedly to verify complete UI workflows and ensure that Blazor components behave as expected.

## Create a Blazor project

If you already have a Blazor project configured, you can skip this section and proceed to [Install required packages](#install-required-packages).

Otherwise, create a new Blazor application by following the [Getting started guide](https://blazor.syncfusion.com/documentation/getting-started/blazor-webassembly-app) for a **Blazor WebAssembly Standalone App**.

## Install required packages

Install the following NuGet packages to use the **Blazor components**.

- [Syncfusion.Blazor.Grid](https://www.nuget.org/packages/Syncfusion.Blazor.Grid)
- [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/)

You can install the required packages by using the following .NET CLI commands.

{% tabs %}
{% highlight bash tabtitle=".NET CLI" %}

dotnet add package Syncfusion.Blazor.Grid -v {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Themes -v {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

## Add required namespaces

Open the `_Imports.razor` file at the root of your project and import the namespaces.

{% tabs %}
{% highlight razor tabtitle="_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Grids

{% endhighlight %}
{% endtabs %}

## Register the Blazor service

Add the Blazor service to the `Program.cs` file to enable Blazor components in the application.

{% tabs %}
{% highlight c# tabtitle="Program.cs" hl_lines="1 7" %}

using Syncfusion.Blazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
....
builder.Services.AddSyncfusionBlazor();

await builder.Build().RunAsync();

{% endhighlight %}
{% endtabs %}

## Add stylesheet and script resources

Include the theme stylesheet and script references in the `wwwroot/index.html` file.

{% tabs %}
{% highlight html %}

<head>
    ....
    <!-- Theme stylesheet -->
    <link href="_content/Syncfusion.Blazor.Themes/fluent2.css" rel="stylesheet" />
    <!-- Blazor core component's script reference -->
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
</head>

{% endhighlight %}
{% endtabs %}

## Connect the Blazor DataGrid component

Add the [Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) to a `.razor` page in your application to enable interactive UI functionality that can be tested using Playwright.

The Blazor DataGrid includes paging functionality, enabling you to verify user interactions and UI behavior through end‑to‑end testing.


{% tabs %}
{% highlight razor tabtitle="Pages/Home.razor" %}

@page "/"

<SfGrid DataSource="@Orders" AllowPaging="true">
    <GridPageSettings PageSize="12"></GridPageSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" Width="120" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText="Order Date" Width="130" Format="d" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Width="120" Format="C2" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipCountry) HeaderText="Ship Country" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<Order> Orders { get; set; } = new List<Order>();

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(i => new Order
        {
            OrderID = 1000 + i,
            CustomerID = (new[] { "Maria", "Ana", "Antonio", "Thomas", "Peter", "Anne", "Berglund", "Fin" })[i % 8],
            OrderDate = DateTime.Now.AddDays(-i),
            Freight = i * 50.5m,
            ShipCountry = (new[] { "USA", "Germany", "Brazil", "France", "UK", "Spain", "Italy", "Argentina" })[i % 8]
        }).ToList();
    }

    public class Order
    {
        public int OrderID { get; set; }
        public string CustomerID { get; set; } = "";
        public DateTime OrderDate { get; set; }
        public decimal Freight { get; set; }
        public string ShipCountry { get; set; } = "";
    }
}

{% endhighlight %}
{% endtabs %}

## Create a Playwright test project

In this step, you create a separate test project to write and manage Playwright end‑to‑end tests for your Blazor application.

From the solution root directory, run the following commands to create a new test project:

{% tabs %}
{% highlight bash tabtitle=".NET CLI" %}

# Create the NUnit test project
dotnet new nunit -o tests/E2E.Tests

# Move into the test project directory
cd tests/E2E.Tests

{% endhighlight %}
{% endtabs %}

This command creates an NUnit test project named **E2E.Tests** under the `tests` folder, which will host all Playwright based UI tests.

**Install required packages**

Install the following NuGet packages into the **E2E.Tests** project to enable Playwright based end‑to‑end testing in the test project.

- [Microsoft.Playwright.NUnit](https://www.nuget.org/packages/Microsoft.Playwright.NUnit)
- [Microsoft.NET.Test.Sdk](https://www.nuget.org/packages/Microsoft.NET.Test.Sdk)

You can install the required packages by using the following .NET CLI commands.

{% tabs %}
{% highlight bash tabtitle=".NET CLI" %}

dotnet add package Microsoft.Playwright.NUnit
dotnet add package Microsoft.NET.Test.Sdk

{% endhighlight %}
{% endtabs %}

## Exclude the test project from the Blazor app build

If your Playwright test project is located inside the main Blazor project directory, you must exclude it from the main project’s build process.

To do this, add the following configuration to your `<yourProjectName>.csproj` file:

{% tabs %}
{% highlight xml tabtitle=".csproj" %}

  <ItemGroup>
    <Compile Remove="tests\**" />
  </ItemGroup>

{% endhighlight %}
{% endtabs %}

## Install the Playwright browsers

Run the following commands from the **test project directory**.

**Step 1: Build the test project**

First, build the test project. This step generates the required Playwright installation script (`playwright.ps1`) inside the `bin` folder.

{% tabs %}
{% highlight bash tabtitle=".NET CLI" %}

dotnet build

{% endhighlight %}
{% endtabs %}

**Step 2: Install required browsers**

Next, install the Playwright browsers (Chromium, Firefox, and WebKit) by running the generated script.

{% tabs %}
{% highlight bash tabtitle=".NET CLI" %}

pwsh bin/Debug/net10.0/playwright.ps1 install

{% endhighlight %}
{% endtabs %}

N> This example uses `net10.0`. Update the path to match your project's target framework.

If pwsh is not available, you can install it from the [official PowerShell site](https://learn.microsoft.com/en-us/powershell/scripting/install/install-powershell).

Alternatively, you can use Windows PowerShell (`powershell.exe`).

{% tabs %}
{% highlight bash tabtitle=".NET CLI" %}

powershell -ExecutionPolicy Bypass -File "bin\Debug\net10.0\playwright.ps1" install

{% endhighlight %}
{% endtabs %}

N> The `-ExecutionPolicy Bypass` option allows the script to run without being blocked by system security settings.

## Create Playwright test class

Create a new C# file named `BlazorPlaywrightTests.cs` in the Playwright test project **E2E.Tests**. This file contains the end‑to‑end test logic and manages the Playwright browser lifecycle.

{% tabs %}
{% highlight c# tabtitle="BlazorPlaywrightTests.cs" %}

using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using System.Diagnostics;

namespace E2E.Tests
{
    [TestFixture]
    public class BlazorPlaywrightTests : PageTest
    {
        private Process? _serverProcess;
        // Replace this with your app's URL and port from Properties/launchSettings.json (applicationUrl).
        private readonly string _url = "http://localhost:5228";

        [OneTimeSetUp]
        public async Task StartBlazorApp()
        {
            var projectPath = @"<Absolute path to your Blazor application's .csproj file>"; // Example: @"C:\Users\MyBlazorApp\MyBlazorApp.csproj";

            var psi = new ProcessStartInfo("dotnet", $"run --project \"{projectPath}\" --urls {_url}")
            {
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            _serverProcess = Process.Start(psi);

            // Wait for the app to respond before running tests.
            using var client = new HttpClient();
            var started = false;
            for (int i = 0; i < 90; i++)
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
                    // Ignore connection errors while the app is starting up.
                }
                await Task.Delay(1000);
            }

            if (!started)
                throw new InvalidOperationException($"The Blazor application did not start at {_url}.");
        }

        [OneTimeTearDown]
        public void StopBlazorApp()
        {
            if (_serverProcess is { HasExited: false })
                _serverProcess.Kill(true);
            _serverProcess?.Dispose();
        }

        [Test]
        public async Task GridPaging_Works()
        {
            await Page.GotoAsync(_url + "/");

            // Wait for the DataGrid to render.
            await Expect(Page.Locator(".e-grid")).ToBeVisibleAsync();

            // Get the first Order ID on page 1.
            var firstOrderOnPage1 = await Page.Locator(".e-grid tbody tr:first-child td:first-child").InnerTextAsync();

            // Click the next page button.
            await Page.Locator(".e-pager .e-next").ClickAsync();

            // Verify the first row has changed, confirming that pagination works.
            var firstOrderOnPage2 = await Page.Locator(".e-grid tbody tr:first-child td:first-child").InnerTextAsync();
            Assert.That(firstOrderOnPage2, Is.Not.EqualTo(firstOrderOnPage1));
        }    
    }
}

{% endhighlight %}
{% endtabs %}

## Run the tests

You can execute the Playwright end‑to‑end tests to validate the behavior of your Blazor application.

From the **test project directory**, run the following command to execute all tests.

{% tabs %}
{% highlight bash tabtitle=".NET CLI" %}

dotnet test

{% endhighlight %}
{% endtabs %}

This command builds and runs the test project. The **StartBlazorApp** method in `BlazorPlaywrightTests.cs` automatically starts the Blazor application before the tests execute.

After running the tests, the Blazor application starts automatically, the browser opens and loads the app, and the DataGrid is displayed on the page. The test simulates user interaction by navigating between pages and verifies that the data changes correctly, confirming that the paging functionality works as expected. If everything is configured properly, the test execution completes successfully with a **Passed** status in the console, indicating that the components behave correctly.

[Playwright test](./images/playwright-testcase.webp)

N> Before running the tests, ensure the projectPath variable in `BlazorPlaywrightTests.cs` is set to the absolute path of your Blazor application.

This approach ensures reliable validation of [Blazor components](https://www.syncfusion.com/blazor-components) and enables early detection of UI regressions through automated end‑to‑end testing.

## See also

- [Getting started with Blazor DataGrid in WASM app](https://blazor.syncfusion.com/documentation/datagrid/getting-started)
- [Guide for installing Playwright Browsers (CLI)](https://playwright.dev/dotnet/docs/browsers)

