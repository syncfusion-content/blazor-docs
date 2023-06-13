---
layout: post
title: Localization (Multi-Language) in Blazor components | Syncfusion
description: Localization of Syncfusion Blazor UI components in Blazor Server and WebAssembly (WASM) apps and much more.
platform: Blazor
component: Common
documentation: ug
---

# Localization of Blazor Components

Localization is the process of translating the application resources into different languages for specific cultures. You can localize the Syncfusion Blazor components by adding a resource file for each language.

## Localization of Syncfusion Blazor Components

The following two steps can be used to localize Syncfusion Blazor components based on culture. You can find the example codes in the below repository,

N> [View Sample in GitHub](https://github.com/SyncfusionExamples/blazor-localization)

### Adding culture based resx files

Syncfusion components can be localized using the Resource `.resx` files. You can find the default and culture based localization files in the following GitHub repository.

N> You can get default and culture based resource files from [GitHub](https://github.com/syncfusion/blazor-locale).

Copy default resx file (`SfResources.resx`) and the other required resx files based on the culture to be localized and add it into **Resources** folder. 

![Adding Resource Files in Blazor](images/localization-resource.png)

N> Update the localization files whenever you upgrade the Syncfusion NuGet packages in the application to avoid the issues occur due to localization strings.

After adding the resource file in the application, double click default resx (`SfResources.resx`) file and open **Resource Editor**. In the Resource Editor, change **Access Modifier** option as **Public** to generate `designer.cs` file.

![Changing Access Modifier](images/localization-resource-file.png)

### Create and register localization service

[ISyncfusionStringLocalizer](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ISyncfusionStringLocalizer.html) which acts as a middleware to connect the Syncfusion Blazor UI components and resource files, uses [ResourceManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ISyncfusionStringLocalizer.html#Syncfusion_Blazor_ISyncfusionStringLocalizer_ResourceManager) to provide culture specific resources at runtime. Create a class implementing `ISyncfusionStringLocalizer`. In the newly created class, return the `ResourceManager` created in the above step for [ResourceManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ISyncfusionStringLocalizer.html#Syncfusion_Blazor_ISyncfusionStringLocalizer_ResourceManager) property and change [GetText](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ISyncfusionStringLocalizer.html#Syncfusion_Blazor_ISyncfusionStringLocalizer_GetText_System_String_) method to return localized string using resource manager.

In the following code, `SyncfusionLocalizer` class implements `ISyncfusionStringLocalizer` interface and `ResourceManager` configured to return the cached ResourceManager instance of default resource file created in **Adding culture based resx files** step. 

{% tabs %}

{% highlight c# tabtitle="SyncfusionLocalizer.cs" %}

using Syncfusion.Blazor;

public class SyncfusionLocalizer : ISyncfusionStringLocalizer
{
    public string GetText(string key)
    {
        return this.ResourceManager.GetString(key);
    }

    public System.Resources.ResourceManager ResourceManager
    {
        get
        {
            // Replace the ApplicationNamespace with your application name.
            return ApplicationNamespace.Resources.SfResources.ResourceManager;
        }
    }
}

{% endhighlight %}

{% endtabs %}

Register the `ISyncfusionStringLocalizer` implementation to localize the Syncfusion Blazor components based on resources files added in application.

* For **Blazor Server App**, register the Syncfusion Blazor Service as follows,
    * For **.NET 6 and .NET 7** app, open the **~/Program.cs** file and register the Syncfusion Blazor Service.
    * For **.NET 5 and .NET 3.X** app, open the **~/Startup.cs** file and register the Syncfusion Blazor Service.
* For **Blazor WebAssembly App**, register the Syncfusion Blazor Service in the client web app of **~/Program.cs** file.

{% tabs %}

{% highlight c# tabtitle="C#" hl_lines="4" %}

...
builder.Services.AddSyncfusionBlazor();
// Register the locale service to localize the  SyncfusionBlazor components.
builder.Services.AddSingleton(typeof(ISyncfusionStringLocalizer), typeof(SyncfusionLocalizer));
...

{% endhighlight %}

{% endtabs %}

## Statically set the culture

If you don't want to change culture dynamically, you can set it statically by following the procedures below. 

### Blazor Server App

* For **.NET 6** app, specify the static culture in **~/Program.cs** file.
* For **.NET 5 and .NET 3.X** app, specify the static culture in **~/Startup.cs** file.

{% tabs %}

{% highlight c# tabtitle=".NET 6 & .NET 7 (~/Program.cs)" hl_lines="3" %}

...
var app = builder.Build();
app.UseRequestLocalization("de");
...

{% endhighlight %}

{% highlight c# tabtitle=".NET 5 and .NET 3.X (~/Startup.cs)" hl_lines="4" %}

public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    ...
    app.UseRequestLocalization("de");
    ...
}

{% endhighlight %}

{% endtabs %}

### Blazor WASM App

In Blazor WASM app, you can set culture statically in Blazor's start option or in C# code.

#### Setting the culture Blazor's start option

The app's culture can be set in JavaScript by setting `applicationCulture` in Blazor's start option by following the steps below,

* In `wwwroot/index.html`, prevent Blazor autostart by adding `autostart="false"` attribute to Blazor's `<script>` tag.

{% tabs %}

{% highlight cshtml tabtitle="wwwroot/index.html" %}

<body>
    ...
    <script src="_framework/blazor.webassembly.js" autostart="false"></script>
    ...
</body>

{% endhighlight %}

{% endtabs %}

* Add the script block below Blazor's `<script>` tag and before the closing </body> tag to start blazor with specific culture. 

{% tabs %}

{% highlight cshtml tabtitle="wwwroot/index.html" hl_lines="4 5 6 7 8" %}

<body>
    ...
    <script src="_framework/blazor.webassembly.js" autostart="false"></script>
    <script>
        Blazor.start({
            applicationCulture: 'de'
        });
    </script>
    ...
</body>

{% endhighlight %}

{% endtabs %}

#### Setting the culture in C# code

You can set culture in C# code alternative for setting the culture Blazor's start option. Set the `CultureInfo.DefaultThreadCurrentCulture` and `CultureInfo.DefaultThreadCurrentUICulture` in `Program.cs` to the same culture before line that builds and runs the `WebAssemblyHostBuilder` (`await builder.Build().RunAsync();`).

{% tabs %}

{% highlight c# tabtitle="Program.cs" %}

using System.Globalization;

CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("de");
CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("de");

{% endhighlight %}

{% endtabs %}

![Localization of Blazor Component](images/blazor-localization.png)

## Dynamically set the culture

The culture can be set dynamically based on user's preference. The following example demonstrates how to use a localization cookie to store user's localization preference.

### Blazor Server App

Set the app's supported cultures. Also, ensure the app is configured to process controller actions by calling `AddControllers` and `MapControllers`. 

{% tabs %}

{% highlight c# tabtitle=".NET 6 & .NET 7 (~/Program.cs)" hl_lines="7 11 13 14 15 16 17 20 31" %}

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddControllers();

builder.Services.AddSyncfusionBlazor();
//Register the Syncfusion locale service to localize Syncfusion Blazor components.
builder.Services.AddSingleton(typeof(ISyncfusionStringLocalizer), typeof(SyncfusionLocalizer));

var supportedCultures = new[] { "en-US", "de", "fr", "ar", "zh" };
var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture(supportedCultures[0])
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);

var app = builder.Build();
app.UseRequestLocalization(localizationOptions);
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");   
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

{% endhighlight %}

{% highlight c# tabtitle=".NET 5 and .NET 3.X (~/Startup.cs)" hl_lines="7 12 13" %}

public class Startup
{
    ...
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddRazorPages();
        services.AddControllers();
        services.AddServerSideBlazor();
        services.AddSingleton<WeatherForecastService>();
        services.AddSyncfusionBlazor();
        //Register the Syncfusion locale service to localize Syncfusion Blazor components.
        services.AddSingleton(typeof(ISyncfusionStringLocalizer), typeof(SyncfusionLocalizer));
        services.Configure<RequestLocalizationOptions>(options =>
        {
            // Define the list of cultures your app will support
            var supportedCultures = new List<CultureInfo>()
            {
                new CultureInfo("en-US"),
                new CultureInfo("de"),
                new CultureInfo("fr"),
                new CultureInfo("ar"),
                new CultureInfo("zh"),
            };
            // Set the default culture
            options.DefaultRequestCulture = new RequestCulture("en-US");
            options.SupportedCultures = supportedCultures;
            options.SupportedUICultures = supportedCultures;
        });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseRequestLocalization(app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>().Value);
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapBlazorHub();
            endpoints.MapFallbackToPage("/_Host");
        });
    }
}
{% endhighlight %}

{% endtabs %}

Set the current culture in a cookie immediately after opening <body> tag of `Pages/_Host.cshtml`.

{% tabs %}

{% highlight c# tabtitle=".NET 6 (_Host.cshtml)" hl_lines="5 6 7 8 9 10" %}
@using Microsoft.AspNetCore.Localization
@using System.Globalization
@{
    Layout = "_Layout";
    this.HttpContext.Response.Cookies.Append(
        CookieRequestCultureProvider.DefaultCookieName,
        CookieRequestCultureProvider.MakeCookieValue(
            new RequestCulture(
                CultureInfo.CurrentCulture,
                CultureInfo.CurrentUICulture)));
}
{% endhighlight %}

{% highlight c# tabtitle=".NET 3.X, .NET 5 and .NET 7 (_Host.cshtml)" hl_lines="6 7 8 9 10 11" %}
@using Microsoft.AspNetCore.Http
@using Microsoft.AspNetCore.Localization
@using System.Globalization
@{
    Layout = null;
    HttpContext.Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(
                    new RequestCulture(
                        CultureInfo.CurrentCulture,
                        CultureInfo.CurrentUICulture)));
}

{% endhighlight %}

{% endtabs %}

To provide UI to allow a user to select a culture, use a redirect-based approach with a localization cookie. The app persists the user's selected culture via a redirect to a controller. The controller sets the user's selected culture into a cookie and redirects the user back to the original URI.

{% tabs %}

{% highlight c# tabtitle="Controllers/CultureController.cs" %}

using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

[Route("[controller]/[action]")]
public class CultureController : Controller
{
    public IActionResult SetCulture(string culture, string redirectUri)
    {
        if (culture != null)
        {
            HttpContext.Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(
                    new RequestCulture(culture)));
        }
        return LocalRedirect(redirectUri);
    }
}

{% endhighlight %}

{% endtabs %}

Create `CultureSwitcher` component and place it inside shared folder to perform the initial redirection when the user selects a culture. 

{% tabs %}

{% highlight razor tabtitle="Shared/CultureSwitcher.razor" %}

@using  System.Globalization
@inject NavigationManager NavigationManager
@inject HttpClient Http

<p>
    <label>
        Select your locale:
        <select @bind="Culture">
            @foreach (var culture in supportedCultures)
            {
                <option value="@culture">@culture.DisplayName</option>
            }
        </select>
    </label>
</p>

@code {

    private CultureInfo[] supportedCultures = new[]
    {
        new CultureInfo("en-US"),
        new CultureInfo("de"),
        new CultureInfo("fr"),
        new CultureInfo("ar"),
        new CultureInfo("zh")
    };

    protected override void OnInitialized()
    {
        Culture = CultureInfo.CurrentCulture;
    }

    private CultureInfo Culture
    {
        get => CultureInfo.CurrentCulture;
        set
        {
            if (CultureInfo.CurrentCulture != value)
            {
                var uri = new Uri(NavigationManager.Uri)
                    .GetComponents(UriComponents.PathAndQuery, UriFormat.Unescaped);
                var cultureEscaped = Uri.EscapeDataString(value.Name);
                var uriEscaped = Uri.EscapeDataString(uri);

                NavigationManager.NavigateTo(
                    $"Culture/SetCulture?culture={cultureEscaped}&redirectUri={uriEscaped}",
                    forceLoad: true);
            }
        }
    }
}

{% endhighlight %}

{% endtabs %}

Add the `CultureSwitcher` component to `Shared/MainLayout.razor` to enable the culture switcher in all pages.

{% tabs %}

{% highlight razor tabtitle="Shared/MainLayout.razor" %}

<div class="page">
    <div class="sidebar">
        <NavMenu />
    </div>

    <main>
        <div class="top-row px-4">
            <CultureSwitcher />
            <a href="https://docs.microsoft.com/aspnet/" target="_blank">About</a>
        </div>

        <article class="content px-4">
            @Body
        </article>
    </main>
</div>

{% endhighlight %}

{% endtabs %}

### Blazor WASM App

Set the `BlazorWebAssemblyLoadAllGlobalizationData` property to true in the project file:

{% tabs %}

{% highlight xml tabtitle=".csproj" %}

<PropertyGroup>
    <BlazorWebAssemblyLoadAllGlobalizationData>true</BlazorWebAssemblyLoadAllGlobalizationData>
</PropertyGroup>

{% endhighlight %}

{% endtabs %}

Add JS function in `wwwroot/index.html` file (after Blazor's `<script>` tag and before the closing `</body>`), to get and set the user's selected culture in the browser local storage.

{% tabs %}

{% highlight cshtml tabtitle="wwwroot/index.html" hl_lines="3 4 5 6" %}

<script src="_framework/blazor.webassembly.js"></script>
<script>
    window.cultureInfo = {
        get: () => window.localStorage['BlazorCulture'],
        set: (value) => window.localStorage['BlazorCulture'] = value
    };
</script>

{% endhighlight %}

{% endtabs %}

In `Program.cs` use JS interop to call above function and retrieve the user's culture selection from local storage. If local storage doesn't contain a culture for the user, the code sets a default value of United States English (en-US).

{% tabs %}

{% highlight c# tabtitle=".NET 6 (Program.cs)" hl_lines="9 13 14 15 16 17 1819 20 21 22 23 24 25 26 27" %}

using Microsoft.JSInterop;
using System.Globalization;

...

builder.Services.AddSyncfusionBlazor();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
//Register the Syncfusion locale service to localize Syncfusion Blazor components.
builder.Services.AddSingleton(typeof(ISyncfusionStringLocalizer), typeof(SyncfusionLocalizer));

var host = builder.Build();

//Setting culture of the application
var jsInterop = host.Services.GetRequiredService<IJSRuntime>();
var result = await jsInterop.InvokeAsync<string>("cultureInfo.get");
CultureInfo culture;
if (result != null)
{
    culture = new CultureInfo(result);
}
else
{
    culture = new CultureInfo("en-US");
    await jsInterop.InvokeVoidAsync("cultureInfo.set", "en-US");
}
CultureInfo.DefaultThreadCurrentCulture = culture;
CultureInfo.DefaultThreadCurrentUICulture = culture;

await builder.Build().RunAsync();

{% endhighlight %}

{% highlight c# tabtitle=".NET 5 and .NET 3.X (Program.cs)" hl_lines="13 17 18 19 20 21 22 23 24 25 26 27 28 29 30 31" %}

using Microsoft.JSInterop;
using System.Globalization;

namespace SyncfusionWasmLocalization
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            ...
            builder.Services.AddSyncfusionBlazor();
            //Register the Syncfusion locale service to localize Syncfusion Blazor components.
            builder.Services.AddSingleton(typeof(ISyncfusionStringLocalizer), typeof(SyncfusionLocalizer));

            var host = builder.Build();

            //Setting culture of the application
            var jsInterop = host.Services.GetRequiredService<IJSRuntime>();
            var result = await jsInterop.InvokeAsync<string>("cultureInfo.get");
            CultureInfo culture;
            if (result != null)
            {
                culture = new CultureInfo(result);
            }
            else
            {
                culture = new CultureInfo("en-US");
                await jsInterop.InvokeVoidAsync("cultureInfo.set", "en-US");
            }
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;

            await builder.Build().RunAsync();
        }
    }
}

{% endhighlight %}

{% endtabs %}

Create `CultureSwitcher` component to set the user's culture selection into browser local storage via JS interop and to force reload the page using the updated culture.

{% tabs %}

{% highlight razor tabtitle="CultureSwitcher.razor" %}

@using  System.Globalization
@inject IJSRuntime JSRuntime
@inject NavigationManager NavigationManager
@using  System.Globalization
@inject IJSRuntime JSRuntime
@inject NavigationManager NavigationManager

<select @bind="Culture">
    @foreach (var culture in supportedCultures)
    {
        <option value="@culture">@culture.DisplayName</option>
    }
</select>

@code {
    private CultureInfo[] supportedCultures = new[]
    {
        new CultureInfo("en-US"),
        new CultureInfo("de"),
        new CultureInfo("fr"),
        new CultureInfo("ar"),
        new CultureInfo("zh")
    };

    private CultureInfo Culture
    {
        get => CultureInfo.CurrentCulture;
        set
        {
            if (CultureInfo.CurrentCulture != value)
            {
                var js = (IJSInProcessRuntime)JSRuntime;
                js.InvokeVoid("cultureInfo.set", value.Name);

                NavigationManager.NavigateTo(NavigationManager.Uri, forceLoad: true);
            }
        }
    }
}

{% endhighlight %}

{% endtabs %}

Add the `CultureSwitcher` component to `Shared/MainLayout.razor` to enable the culture switcher in all pages.

{% tabs %}

{% highlight razor tabtitle="MainLayout.razor" %}

<div class="page">
    ....
    <main>
        <div class="top-row px-4">
            <CultureSwitcher />
            <a href="https://docs.microsoft.com/aspnet/" target="_blank">About</a>
        </div>
    </main>
</div>

{% endhighlight %}

{% endtabs %}

![Dynamically set the culture in Blazor](images/blazor-localization-dynamic-change.png)

N> [View Sample in GitHub](https://github.com/SyncfusionExamples/blazor-localization)

## Localization using database in Blazor

* [How to perform localization using database instead of resource files in Blazor?](https://support.syncfusion.com/kb/article/11465/how-to-perform-localization-using-database-instead-of-resource-files-in-blazor)

## See also
* [Statically set the culture in Blazor WASM App](https://docs.microsoft.com/en-us/aspnet/core/blazor/globalization-localization?pivots=webassembly&view=aspnetcore-6.0#statically-set-the-culture)
* [Statically set the culture in Blazor Server App](https://docs.microsoft.com/en-us/aspnet/core/blazor/globalization-localization?pivots=server&view=aspnetcore-6.0#statically-set-the-culture)
* [Dynamically set the culture by user preference in WASM App](https://docs.microsoft.com/en-us/aspnet/core/blazor/globalization-localization?pivots=webassembly&view=aspnetcore-6.0#dynamically-set-the-culture-by-user-preference)
* [Dynamically set the culture by user preference in Server App](https://docs.microsoft.com/en-us/aspnet/core/blazor/globalization-localization?pivots=server&view=aspnetcore-6.0#dynamically-set-the-culture-by-user-preference)

