---
layout: post
title: Localization in Blazor Range Slider Component | Syncfusion 
description: Learn about Localization in Blazor Range Slider component of Syncfusion, and more details.
platform: Blazor
control: Range Slider
documentation: ug
---

# Localization

The `Localization` library allows you to localize default text content of the Slider. The slider control has static text on some features (like increase and decrease button) that can be changed to other cultures (Arabic, Deutsch, French, etc.) by defining the `Locale` value.

## Blazor server side

Add `UseRequestLocalization` middle-ware in Configure method in **Startup.cs** file to get browser Culture Info.

Refer the following code to add configuration in Startup.cs file

```csharp
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;

namespace BlazorApplication
{
    public class Startup
    {
        ....
        ....

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRequestLocalization();
            ....
            ....
        }
    }
}
```

The following sample, demonstrate how to enable **Localization** for Slider in server side Blazor samples. Here, we have used Resource file to translate the static text.

The Resource file is an XML file which contains the strings(key and value pairs) that you want to translate into different language. You can also refer Localization [link](https://blazor.syncfusion.com/documentation/common/localization/) to know more about how to configure and use localization in the Blazor framework.

Open the **Startup.cs** file and add the below configuration in the **ConfigureServices** function as follows.

```csharp
using Syncfusion.Blazor;
using System.Globalization;
using Microsoft.AspNetCore.Localization;

namespace BlazorApplication
{
    public class Startup
    {
        ....
        ....
        public void ConfigureServices(IServiceCollection services)
        {
            ....
            ....
            services.AddSyncfusionBlazor();
            services.AddLocalization(options => options.ResourcesPath = "Resources");
            services.Configure<RequestLocalizationOptions>(options =>
            {
                // define the list of cultures your app will support
                var supportedCultures = new List<CultureInfo>()
                {
                    new CultureInfo("de")
                };
                // set the default culture
                options.DefaultRequestCulture = new RequestCulture("de");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
                options.RequestCultureProviders = new List<IRequestCultureProvider>() {
                 new QueryStringRequestCultureProvider() // Here, You can also use other localization provider
                };
            });
            services.AddSingleton(typeof(ISyncfusionStringLocalizer), typeof(SampleLocalizer));
        }
    }
}
```

* Then, write a **class** by inheriting **ISyncfusionStringLocalizer** interface and override the Manager property to get the resource file details from the application end.

```csharp
using Syncfusion.Blazor;

namespace BlazorApplication
{
     public class SampleLocalizer : ISyncfusionStringLocalizer
    {
        // To get the locale key from mapped resources file
        public string GetText(string key)
        {
            return this.ResourceManager.GetString(key);
        }
        // To access the resource file and get the exact value for locale key
        public System.Resources.ResourceManager ResourceManager
        {
            get
            {
                // Replace the ApplicationNamespace with your application name.
                return BlazorApplication.Resources.SyncfusionBlazorLocale.ResourceManager;
            }
        }
    }
}
```

* Add **.resx** file to Resource folder and enter the key value (Locale Keywords) in the **Name** column and the translated string in the **Value** column as follows.

| **Name** | **Value (in Deutsch culture)** |
| --- | --- |
| Slider_DecrementTitle | verringern |
| Slider_IncrementTitle | Erhöhen, ansteigen |

* Finally, Specify the culture for Slider using `Locale` property.

```csharp
@using Syncfusion.Blazor.Inputs

<SfSlider Value="30" ShowButtons="true" Step="10" Locale="de"></SfSlider>
```

## Blazor WebAssembly

The following sample, demonstrate how to enable **Localization** for Slider in client side Blazor samples.

* Open the **Program.cs** file and add the below configuration in the **Main** function as follows.

```csharp
using Syncfusion.Blazor;
using System.Globalization;

namespace WebAssemblyLocale
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            ....
            ....
            builder.Services.AddSyncfusionBlazor();

            // Register the Syncfusion locale service to customize the  SyncfusionBlazor component locale culture
            builder.Services.AddSingleton(typeof(ISyncfusionStringLocalizer), typeof(SampleLocalizer));

            // Set the default culture of the application
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("de");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("de");

            await builder.Build().RunAsync();
        }
    }
}
```

* Then, create a **~/Shared/SampleLocalizer.cs** file and implement **ISyncfusionStringLocalizer** interface for the class and add Locale Keywords in the **.resx** file at Resource folder.

```csharp
using Syncfusion.Blazor;

namespace WebAssemblyLocale
{
    public class SampleLocalizer : ISyncfusionStringLocalizer
    {
        // To get the locale key from mapped resources file
        public string GetText(string key)
        {
            return this.ResourceManager.GetString(key);
        }
        // To access the resource file and get the exact value for locale key
        public System.Resources.ResourceManager ResourceManager
        {
            get
            {
                // Replace the ApplicationNamespace with your application name.
                return WebAssemblyLocale.Resources.SyncfusionBlazorLocale.ResourceManager;
            }
        }
    }
}
```

* Now, Specify the culture for Slider using `Locale` property.

```csharp
@using Syncfusion.Blazor.Inputs

<SfSlider Value="30" ShowButtons="true" Step="10" Locale="de"></SfSlider>
```

The output will be as follows.

![Localizatio](./images/localization.gif)