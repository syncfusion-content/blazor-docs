---
layout: post
title: Localization (Multi-Language) in Blazor components | Syncfusion
description: Localization of Syncfusion Blazor UI components in Blazor Server and WebAssembly (WASM) apps and much more.
platform: Blazor
component: Common
documentation: ug
---

# Localization of Blazor Components

[Localization](https://learn.microsoft.com/en-us/aspnet/core/blazor/globalization-localization?view=aspnetcore-8.0) is the process of translating the application resources into different languages for specific cultures. You can localize the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components by adding a resource file for each language.

## Localization of Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Components

The following two steps can be used to localize Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components based on culture. You can find the example codes in the below repository,

N> [View Sample in GitHub](https://github.com/SyncfusionExamples/blazor-localization)

### Adding culture based resx files

Syncfusion<sup style="font-size:70%">&reg;</sup> components can be localized using the Resource `.resx` files. You can find the default and culture based localization files in the following GitHub repository.

N> You can get default and culture based resource files from [GitHub](https://github.com/syncfusion/blazor-locale).

Copy the default resx file (`SfResources.resx`) and the other required resx files based on the culture to be localized and add them to the **Resources** folder. If you are implementing in a .NET MAUI Blazor app, create a **LocalizationResources** folder and add them into it.

![Adding Resource Files in Blazor](images/localization-resource.png)

N> Update the localization files whenever you upgrade the Syncfusion<sup style="font-size:70%">&reg;</sup> NuGet packages in the application to avoid the issues occur due to localization strings.

After adding the resource file in the application, double click default resx (`SfResources.resx`) file and open **Resource Editor**. In the Resource Editor, change **Access Modifier** option as **Public** .

![Changing Access Modifier](images/localization-resource-file.png)

### Create and register localization service

[ISyncfusionStringLocalizer](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ISyncfusionStringLocalizer.html) which acts as a middleware to connect the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor UI components and resource files, uses [ResourceManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ISyncfusionStringLocalizer.html#Syncfusion_Blazor_ISyncfusionStringLocalizer_ResourceManager) to provide culture specific resources at runtime. Create a class implementing `ISyncfusionStringLocalizer`. In the newly created class, return the `ResourceManager` created in the above step for [ResourceManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ISyncfusionStringLocalizer.html#Syncfusion_Blazor_ISyncfusionStringLocalizer_ResourceManager) property and change [GetText](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ISyncfusionStringLocalizer.html#Syncfusion_Blazor_ISyncfusionStringLocalizer_GetText_System_String_) method to return localized string using resource manager.

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

            //For .Net Maui Blazor App
            // Replace the ApplicationNamespace with your application name.
            //return ApplicationNamespace.LocalizationResources.SfResources.ResourceManager;
        }
    }
}

{% endhighlight %}

{% endtabs %}

Register the `ISyncfusionStringLocalizer` and `Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Service` in the **~/Program.cs** file of your app.

* If you create a Blazor Web App with an **Interactive render mode** such as `WebAssembly or Auto`, you need to ensure the registration of the `SyncfusionLocalizer` and Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor services in both **~/Program.cs** files.

* For **MAUI Blazor App**, register the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Service in the **~/MauiProgram.cs** file.

{% tabs %}

{% highlight c# tabtitle="C#" hl_lines="3 5" %}

using Syncfusion.Blazor;
...
builder.Services.AddSyncfusionBlazor();
// Register the locale service to localize the  SyncfusionBlazor components.
builder.Services.AddSingleton(typeof(ISyncfusionStringLocalizer), typeof(SyncfusionLocalizer));
...

{% endhighlight %}

{% endtabs %}

## Statically set the culture

If you don't want to change culture dynamically, you can set it statically by following the procedures below.

### Blazor Web App and Blazor WASM App

In Blazor Web App and Blazor WASM app, you can set culture statically in Blazor's start option or in C# code.

#### Setting the culture Blazor's start option

The app's culture can be set in JavaScript by setting `applicationCulture` in Blazor's start option by following the steps below,

* For **.NET 8 and .NET 9**  Blazor Web Apps using any render mode (Server, WebAssembly, or Auto), prevent Blazor autostart by adding `autostart="false"` attribute to the Blazor `<script>` tag in the **~/Components/App.razor** file.

* For `Blazor WebAssembly Standalone App` , prevent Blazor autostart by adding `autostart="false"` attribute to Blazor's `<script>` tag in the **wwwroot/index.html** file.

{% tabs %}

{% highlight cshtml tabtitle="Blazor Web App" %}

<body>
    ...
    <script src="_framework/blazor.web.js" autostart="false"></script>
    ...
</body>

{% endhighlight %}

{% highlight cshtml tabtitle="Blazor WASM Standalone App" %}

<body>
    ...
    <script src="_framework/blazor.webassembly.js" autostart="false"></script>
    ...
</body>

{% endhighlight %}

{% endtabs %}

* Add the script block below Blazor's `<script>` tag and before the closing </body> tag to start blazor with specific culture.

{% tabs %}
{% highlight cshtml tabtitle="Blazor Web App" hl_lines="4 5 6 7 8 9 10" %}

<body>
    ...
    <script src="_framework/blazor.web.js" autostart="false"></script>
    <script>
        Blazor.start({
            webAssembly: {
                applicationCulture: 'de'
            }
        });
    </script>
    ...
</body>

{% endhighlight %}
{% highlight cshtml tabtitle="Blazor WASM Standalone App" hl_lines="4 5 6 7 8" %}

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

For `Blazor Web App & Blazor WASM App`, you can set culture in C# code alternative for setting the culture Blazor's start option. Set the `CultureInfo.DefaultThreadCurrentCulture` and `CultureInfo.DefaultThreadCurrentUICulture` in `Program.cs` to the same culture before line that builds and runs the `WebAssemblyHostBuilder` (`await builder.Build().RunAsync();`).

{% tabs %}

{% highlight c# tabtitle="Program.cs" %}

using System.Globalization;

CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("de-DE");
CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("de-DE");

{% endhighlight %}

{% endtabs %}


### MAUI Blazor App

In a MAUI Blazor app, you can set the culture in C# code by configuring the `CultureInfo.DefaultThreadCurrentCulture` and `CultureInfo.DefaultThreadCurrentUICulture` in `MauiProgram.cs` to the same culture. Ensure that this configuration is done before the line that builds and runs the `MauiApp.CreateBuilder()` (i.e., `return builder.Build();`).

{% tabs %}

{% highlight c# tabtitle="MauiProgram.cs" %}

using System.Globalization;

CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("de-DE");
CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("de-DE");

{% endhighlight %}

{% endtabs %}

![Localization of Blazor Component](images/blazor-localization.png)

## Dynamically set the culture

The culture can be set dynamically based on user's preference. The following example demonstrates how to use a localization cookie to store user's localization preference.

### Blazor Web App and Blazor Standalone WASM App

For `Blazor Web App and Blazor WASM Standalone App`, set the `BlazorWebAssemblyLoadAllGlobalizationData` property to true in the project file:

{% tabs %}

{% highlight xml tabtitle=".csproj" %}

<PropertyGroup>
    <BlazorWebAssemblyLoadAllGlobalizationData>true</BlazorWebAssemblyLoadAllGlobalizationData>
</PropertyGroup>

{% endhighlight %}

{% endtabs %}

* For **.NET 8 and .NET 9**  Blazor Web Apps using any render mode (Server, WebAssembly, or Auto), add JS function in `~/Components/App.razor` file (after Blazor's `<script>` tag and before the closing `</body>`), to get and set the user's selected culture in the browser local storage.

* For Blazor WASM Standalone App, add JS function in `wwwroot/index.html` file (after Blazor's `<script>` tag and before the closing `</body>`), to get and set the user's selected culture in the browser local storage.

{% tabs %}
{% highlight cshtml tabtitle="Blazor Web App" hl_lines="2 3 4 5 6 7" %}

<script src="_framework/blazor.web.js"></script>
<script>
    window.cultureInfo = {
        get: () => window.localStorage['BlazorCulture'],
        set: (value) => window.localStorage['BlazorCulture'] = value
    };
</script>

{% endhighlight %}
{% highlight cshtml tabtitle="Blazor WASM App" hl_lines="2 3 4 5 6 7" %}

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

If you create a Blazor Web App with an **Interactive render mode** such as `WebAssembly or Auto`, you need to ensure the registration of the `SyncfusionLocalizer` and Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor services in both **~/Program.cs** files.

{% tabs %}

{% highlight c# tabtitle="Program.cs" hl_lines="8 10 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26" %}

using Microsoft.JSInterop;
using System.Globalization;

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

{% endhighlight %}

{% endtabs %}

Create `CultureSwitcher` component to set the user's culture selection into browser local storage via JS interop and to force reload the page using the updated culture.

{% tabs %}

{% highlight razor tabtitle="CultureSwitcher.razor" %}

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
        new CultureInfo("de-DE"),
        new CultureInfo("fr-FR"),
        new CultureInfo("ar-AE"),
        new CultureInfo("zh-HK")
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

Add the `CultureSwitcher` component to `~/MainLayout.razor` to enable the culture switcher in all pages. If you create a Blazor Web App with an interactivity location as `Per page/component`, you need to ensure the set a render mode at the `CultureSwitcher` component instance in the `~/MainLayout.razor` file.

{% tabs %}
{% highlight razor tabtitle="Blazor Web App" %}

<div class="page">
    ....
    <main>
        <div class="top-row px-4">
            <CultureSwitcher @rendermode="@InteractiveAuto" />
            ....
        </div>
    </main>
</div>

{% endhighlight %}
{% highlight razor tabtitle="Blazor WASM Standalone App" %}

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

### Blazor Server App and Blazor Web App (Interactive Server)

Set the app's supported cultures. Also, ensure the app is configured to process controller actions by calling `AddControllers` and `MapControllers`.

If you create a Blazor Web App with an **Interactive render mode** as `Server` make sure to include the registration of SyncfusionLocalizer and Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor services in the ~/Program.cs files.

{% tabs %}

{% highlight c# tabtitle=".NET 9 & .NET 8 (~/Program.cs)" hl_lines="4 6 7 8 9 10 13 24" %}

builder.Services.AddControllers();

builder.Services.AddSyncfusionBlazor();
builder.Services.AddLocalization();

var supportedCultures = new[] { "en-US", "de-DE", "fr-FR", "ar-AE", "zh-HK" };
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
{% endtabs %}

For .NET 9 and .NET 8 set the current culture in a cookie in App component file

{% tabs %}

{% highlight C# tabtitle=".NET 9 & .NET 8 (App.razor)" %}

@using System.Globalization
@using Microsoft.AspNetCore.Localization
@code {
    [CascadingParameter]
    public HttpContext? HttpContext { get; set; }

    protected override void OnInitialized()
    {
        HttpContext?.Response.Cookies.Append(
            CookieRequestCultureProvider.DefaultCookieName,
            CookieRequestCultureProvider.MakeCookieValue(
                new RequestCulture(
                    CultureInfo.CurrentCulture,
                    CultureInfo.CurrentUICulture)));
    }
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

{% highlight razor tabtitle=".NET 9 & .NET 8 (Components/Pages/CultureSwitcher.razor)" %}

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
        new CultureInfo("de-DE"),
        new CultureInfo("fr-FR"),
        new CultureInfo("ar-AE"),
        new CultureInfo("zh-HK")
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

{% highlight razor tabtitle=".NET 9 & .NET 8 (Components/Layout/MainLayout.razor)" %}

 <div class="page">
    <div class="sidebar">
        <NavMenu />
    </div>

    <main>
        <div class="top-row px-4">
            <CultureSwitcher></CultureSwitcher>
            <a href="https://learn.microsoft.com/aspnet/core/" target="_blank">About</a>
        </div>

        <article class="content px-4">
            @Body
        </article>
    </main>
</div>
        
{% endhighlight %}

{% endtabs %}

### MAUI Blazor App

In `App.xaml.cs`, use [Preferences](https://learn.microsoft.com/en-us/dotnet/maui/platform-integration/storage/preferences?view=net-maui-8.0&tabs=windows) to retrieve the user's stored culture selection. If the storage doesn't contain a culture for the user, the code sets a default value of United States English (en-US).

{% tabs %}

{% highlight c# tabtitle="App.xaml.cs" %}

using System.Globalization;

namespace LocalizationMauiBlazor
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            var language = Preferences.Get("language", "en-US");
            var culture = new CultureInfo(language);
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;
            MainPage = new MainPage();
        }
    }
}

{% endhighlight %}

{% endtabs %}

Create `CultureSwitcher` component to store the user's culture selection via [Preferences](https://learn.microsoft.com/en-us/dotnet/maui/platform-integration/storage/preferences?view=net-maui-8.0&tabs=windows) and to force reload the page using the updated culture.

{% tabs %}

{% highlight razor tabtitle="CultureSwitcher.razor" %}

@using System.Globalization
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
        new CultureInfo("de-DE"),
        new CultureInfo("fr-FR"),
        new CultureInfo("ar-AE"),
        new CultureInfo("zh-HK")
    };

    private CultureInfo Culture
    {
        get => CultureInfo.CurrentCulture;
        set
        {
            if (CultureInfo.CurrentCulture != value)
            {
                CultureInfo.DefaultThreadCurrentCulture = value;
                CultureInfo.DefaultThreadCurrentUICulture = value;
                Preferences.Set("language", value.Name);
                NavigationManager.NavigateTo(NavigationManager.Uri, forceLoad: true);
            }
        }
    }
}

{% endhighlight %}

{% endtabs %}

Add the `CultureSwitcher` component to `Layout/MainLayout.razor` to enable the culture switcher on all pages.

{% tabs %}

{% highlight razor tabtitle="MainLayout.razor" %}

@inherits LayoutComponentBase

<div class="page">
    <div class="sidebar">
        <NavMenu />
    </div>

    <main>
        <div class="top-row px-4">
            <a href="https://learn.microsoft.com/aspnet/core/" target="_blank">About</a>
        </div>

        <article class="content px-4">
            <CultureSwitcher />
            @Body
        </article>
    </main>
</div>

{% endhighlight %}

{% endtabs %}

![Dynamically set the culture in Blazor](images/blazor-localization-dynamic-change.png)

N> [View Sample in GitHub](https://github.com/SyncfusionExamples/blazor-localization)

## Localization using database in Blazor

* [How to perform localization using database instead of resource files in Blazor?](https://support.syncfusion.com/kb/article/11465/how-to-perform-localization-using-database-instead-of-resource-files-in-blazor)

## See also
* [Statically set the culture in Blazor WASM App](https://learn.microsoft.com/en-us/aspnet/core/blazor/globalization-localization?pivots=webassembly&view=aspnetcore-6.0#statically-set-the-culture)
* [Statically set the culture in Blazor Server App](https://learn.microsoft.com/en-us/aspnet/core/blazor/globalization-localization?pivots=server&view=aspnetcore-6.0#statically-set-the-culture)
* [Dynamically set the culture by user preference in WASM App](https://learn.microsoft.com/en-us/aspnet/core/blazor/globalization-localization?pivots=webassembly&view=aspnetcore-6.0#dynamically-set-the-culture-by-user-preference)
* [Dynamically set the culture by user preference in Server App](https://learn.microsoft.com/en-us/aspnet/core/blazor/globalization-localization?pivots=server&view=aspnetcore-6.0#dynamically-set-the-culture-by-user-preference)
