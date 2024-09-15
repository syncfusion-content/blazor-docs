---
layout: post
title: Create a Blazor WebAssembly Application with Prerendering | Syncfusion
description: Checkout and learn here all about creating a Blazor WebAssembly Application with Prerendering and much more.
platform: Blazor
component: Common
documentation: ug
---

# How to Create a Blazor WebAssembly Application with Prerendering?

This section explains how to enable prerendering to a Blazor WebAssembly application.

## Prerequisites

[.NET 5.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/5.0) or later.

## Create a new project for Blazor WebAssembly ASP.NET Core Hosted application

1. Create a new [Blazor WebAssembly ASP.NET Core Hosted application](https://blazor.syncfusion.com/documentation/getting-started/blazor-core-hosted#create-a-blazor-aspnet-core-hosted-webassembly-app-in-visual-studio).

2. Delete `~/wwwroot/index.html` file in the Client project.

3. Remove the below line from Client project's `~/Program.cs` file.

    ```c#
    // builder.RootComponents.Add<App>("#app");
    ```

4. Add `~/Pages/_Host.cshtml` file in the Server project.

    ![Add Host.cshtml file in Server app](images/wasm-prerender-host-file.png)

5. Copy and paste the below code content in the `~/Server/Pages/_Host.cshtml` file.

    ```cshtml
    @page "/"
    @namespace BlazorWebAssemblyHosted.Client.Pages
    @addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers
    @{
        Layout = null;
    }

    <!DOCTYPE html>
    <html>

    <head>
        <meta charset="utf-8" />
        <meta name="viewport" content="width=device-width, initial-scale=1.0" />
        <title>BlazorWebAssemblyHosted</title>
        <base href="~/" />
        <link rel="stylesheet" href="css/bootstrap/bootstrap.min.css" />
        <link href="css/bootstrap/bootstrap.min.css" rel="stylesheet" />
        <link href="css/app.css" rel="stylesheet" />
        <link href="BlazorWebAssemblyHosted.Client.styles.css" rel="stylesheet" />
        <link href="_content/Syncfusion.Blazor.Themes/bootstrap4.css" rel="stylesheet" />
    </head>

    <body>

        <component type="typeof(App)" render-mode="WebAssemblyPrerendered" />

        <script src="_framework/blazor.webassembly.js"></script>
    </body>

    </html>
    ```

6. Open `Program.cs` file in the Server project and change endpoint of `MapFallbackToFile` configuration from `index.html` to `/_Host`.

    ```c#
        ....
        app.UseEndpoints(endpoints =>
            {
                ....
                ....
                endpoints.MapFallbackToFile("/_Host"); // Previously it was mapped into "index.html".
            });
    ```

7. Add Syncfusion Blazor service in the `~/Server/Program.cs` file.

    ```c#
    using Syncfusion.Blazor;
    ....
    builder.Services.AddSyncfusionBlazor();

    ```

8. If you don't inject and use `HttpClient` DI on your index page, you can run the application and the component will render in the web browser with prerendering mode.

    The created [Blazor WebAssembly ASP.NET Core Hosted application](../introduction#create-a-new-project-for-blazor-webassembly-aspnet-core-hosted-application) has injected the `HttpClient` DI and fetch the data from server for SfGrid component data source. So, refer to the next topic to resolve the `HttpClient` error on prerendering mode.

### Resolving HttpClient errors on WebAssembly prerendering

When the index page is injected with the `HttpClient` and tried to prerender on the server, the client will not establish its connection at that time. So, it will throw the runtime exceptions.

E> ***InvalidOperationException***: An invalid request URI was provided. The request URI must either be an absolute URI or BaseAddress must be set.

The Syncfusion Blazor service has registered the HttpClient service itself by default. When you run the `WebAssemblyPrerendered` mode application, it tries to get the WebAPI with its absolute URI or BaseAddress.

If you configure with absolute URI in the `~/Client/Pages/Index.razor` file, you will face another runtime error.

```c#
protected override async Task OnInitializedAsync()
{
    forecasts = await Http.GetFromJsonAsync<WeatherForecast[]>("http://localhost:44376/WeatherForecast");
}
```

E> ***SocketException***: An existing connection was forcibly closed by the remote host. <br />
***IOException***: Unable to read data from the transport connection: An existing connection was forcibly closed by the remote host <br />
***HttpRequestException***: An error occurred while sending the request.

We are trying to use HTTP from Server to get the fetch data. But, it is also not possible in the prerender mode because of the client is not yet established.

Refer to the below steps to resolve these issues and make the app running with HttpClient in the prerendering mode.

1. Create a public interface in the `~/Shared/WeatherForecast.cs` file on the Shared project to abstract the API call.

    ```c#
    using System.Threading.Tasks;

    public interface IWeatherForecastService
    {
        Task<WeatherForecast[]> GetForecastAsync();
    }
    ```

2. Create a class file `~/Client/Shared/WeatherForecastService.cs` and inherit the class with the new interface `IWeatherForecastService`. Here, the override method `GetForecastAsync` will fetch the data using HTTP Get action.

    ```c#
    using System.Net.Http;
    using System.Net.Http.Json;
    using System.Threading.Tasks;
    using BlazorWebAssemblyHosted.Shared;

    namespace BlazorWebAssemblyHosted.Client.Shared
    {
        public class WeatherForecastService : IWeatherForecastService
        {
            private readonly HttpClient httpClient;

            public WeatherForecastService(HttpClient http)
            {
                httpClient = http;
            }

            public async Task<WeatherForecast[]> GetForecastAsync()
            {
                return await httpClient.GetFromJsonAsync<WeatherForecast[]> ("WeatherForecast");
            }
        }
    }
    ```

3. create a new class file with same class name on the Server project and inherit with the interface `IWeatherForecastService`. Here, the existing API `~/Server/Controller/WeatherForecastController.cs` data creation process moved into the override method `GetForecastAsync`.

    ```c#
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using BlazorWebAssemblyHosted.Shared;

    namespace BlazorWebAssemblyHosted.Server.Shared
    {
        public class WeatherForecastService : IWeatherForecastService
        {
            private static readonly string[] Summaries = new[]
            {
                "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy",   "Hot", "Sweltering", "Scorching"
            };

            public async Task<WeatherForecast[]> GetForecastAsync()
            {
                var rng = new Random();
                return Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)]
                }).ToArray();
            }
        }
    }
    ```

4. Now, the API controller will have the below changes on `~/Server/Controller/WeatherForecastController.cs` file.

    ```c#
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using BlazorWebAssemblyHosted.Shared;

    namespace BlazorWebAssemblyHosted.Server.Controllers
    {
        [ApiController]
        [Route("[controller]")]
        public class WeatherForecastController : ControllerBase
        {
            private readonly IWeatherForecastService weatherForecastService;

            public WeatherForecastController(IWeatherForecastService    weatherService)
            {
                weatherForecastService = weatherService;
            }

            [HttpGet]
            public async Task<IEnumerable<WeatherForecast>> Get()
            {
                return await weatherForecastService.GetForecastAsync();
            }
        }
    }
    ```

5. Register the services in both Client and Server project `~/Program.cs`file.

    ```c#
    ....
    using Syncfusion.Blazor;

    ....
    builder.Services.AddSyncfusionBlazor();

    ```

6. Now, change the DI injection from `HttpClient` to `IWeatherForecastService` on the `~/Client/Pages/Index.razor` file.

    ```cshtml
    @using BlazorWebAssemblyHosted.Shared
    @inject IWeatherForecastService  WeatherForecastService

    ....
    ....

    @code {
        private WeatherForecast[] forecasts;

        protected override async Task OnInitializedAsync()
        {
            forecasts = await WeatherForecastService.GetForecastAsync();
        }
    }
    ```

7. Run the application by pressing `F5` key. The Server prerendering will get the data from its local service, and when it renders on the Client, the HTTP Get request will be sent to get the data.

## See Also

* [Prerender on ASP.NET Core Razor Component](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/prerendering-and-integration?view=aspnetcore-7.0&pivots=webassembly)
* [Stateful Reconnection After Prerendering](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/lifecycle?view=aspnetcore-7.0#stateful-reconnection-after-prerendering)