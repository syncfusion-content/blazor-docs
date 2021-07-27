---
layout: post
title: Globalization in Blazor DateRangePicker Component | Syncfusion
description: Learn here all about Globalization in Syncfusion Blazor DateRangePicker component and more.
platform: Blazor
control: DateRangePicker
documentation: ug
---

# Globalization in Blazor DateRangePicker Component

Globalization is the combination of  adapting the control to various languages by means of parsing and formatting the date or number `Internationalization` and also by adding cultural specific customizations and translating the text `localization`.

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

The **Localization** library allows you to localize default text content. The DateRangePicker component has static text that can be changed to other cultures (Arabic, Deutsch, French, etc.).

In the following examples, demonstrate how to enable **Localization** for DateRangePicker in server side Blazor samples. Here, we have used Resource file to translate the static text.

The Resource file is an XML file which contains the strings(key and value pairs) that you want to translate into different language. You can also refer Localization [link](https://blazor.syncfusion.com/documentation/common/localization/) to know more about how to configure and use localization in the ASP.Net Core application framework.

* Open the **Startup.cs** file and add the below configuration in the **ConfigureServices** function as follows.

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

namespace blazorCalendars
{
     public class SampleLocalizer : ISyncfusionStringLocalizer
    {

        public string Get(string key)
        {
            return this.Manager.GetString(key);
        }

        public System.Resources.ResourceManager Manager
        {
            get
            {
                return blazorCalendars.Resources.SyncfusionBlazorLocale.ResourceManager;
            }
        }
    }
}
```

* Add **.resx** file to Resource folder and enter the key value (Locale Keywords) in the **Name** column and the translated string in the Value column as follows.

| **Name** | **Value (in Deutsch culture)** |
| --- | --- |
| DateRangePicker_ApplyText | Anwenden |
| DateRangePicker_CancelText | Stornieren |
| DateRangePicker_CustomRange | Benutzerdefinierten Bereich |
| DateRangePicker_Days | Tage |
| DateRangePicker_EndLabel | Endtermin |
| DateRangePicker_Placeholder | Wählen Sie einen Datumsbereich |
| DateRangePicker_SelectedDays | Ausgewählte Tage |
| DateRangePicker_StartLabel | Anfangsdatum |

* Finally, Specify the culture for DateRangePicker using `locale` property.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDateRangePicker TValue="DateTime?" Locale="de"></SfDateRangePicker>
```

## Blazor WebAssembly

By default, the DateRangePicker week and month names are specific to the `American English` culture. It utilizes the
`Blazor Internationalization` package to parse and format the date object based on the culture by using the official [UNICODE CLDR](http://cldr.unicode.org/) JSON data.

The following steps explain how to render the DateRangePicker in German culture (‘de-DE’) in Blazor Web Assembly application.

* Open the **program.cs** file and add the below configuration in the **Builder ConfigureServices** function as follows.

```csharp
using Syncfusion.Blazor;
using Microsoft.AspNetCore.Builder;

namespace WebAssemblyLocale
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            ....
            ....
            builder.Services.Configure<RequestLocalizationOptions>(options =>
            {
                // Define the list of cultures your app will support
                var supportedCultures = new List<System.Globalization.CultureInfo>()
                {
                    new System.Globalization.CultureInfo("en-US"),
                    new System.Globalization.CultureInfo("de"),
                };

                // Set the default culture
                options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("de");

                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
                options.RequestCultureProviders = new List<Microsoft.AspNetCore.Localization.IRequestCultureProvider>() {
                 new Microsoft.AspNetCore.Localization.QueryStringRequestCultureProvider()
                };
            });
            ....
            ....
        }
    }
}
```

* Download the required locale packages to render the Blazor DateRangePicker component with specified locale.

* To download the locale definition of Blazor components, use this [link](https://github.com/syncfusion/ej2-locale).

* After downloading the `blazor-locale` package, copy the `blazor-locale` folder with required local definition file into `wwwroot` folder.

* By default, the `blazor-locale` package contains the localized text for static text present in components like button text, placeholder, tooltip, and more.

* Set the culture by using the `SetCulture` method.

```cshtml
@using Syncfusion.Blazor.Calendars
@inject HttpClient Http;

<SfDateRangePicker TValue="DateTime?" Locale="de"></SfDateRangePicker>

@code {
    [Inject]
    protected IJSRuntime JsRuntime { get; set; }
    protected override async Task OnInitializedAsync()
    {
        this.JsRuntime.Sf().LoadLocaleData(await Http.GetJsonAsync<object>("blazor-locale/src/de.json")).SetCulture("de");
    }
}
```

The output will be as follows.

![DateRangePicker](./images/de_culture.png)

## Customize the localized text

You can change the localized text of particular component by editing the `wwwroot/blazor-locale/src/{{locale name}}.json` file.

[`wwwroot/blazor-locale/src/de.json`]

```csharp
{
  "de": {
    "daterangepicker": {
        "placeholder": "Wählen Sie einen Bereich aus",
        "startLabel": "Wählen Sie Startdatum",
        "endLabel": "Wählen Sie Enddatum",
        "applyText": "Sich bewerben",
        "cancelText": "Stornieren",
        "selectedDays": "Ausgewählte Tage",
        "days": "Tage",
        "customRange": "benutzerdefinierten Bereich"
    }
  }
}
```

The output will be as follows.

![DateRangePicker](./images/de_culture_02.png)

## Right-To-Left

The DateRangePicker supports RTL (right-to-left) functionality for languages like Hebrew and Hebrew to displays
the text in the right-to-left direction. Use [EnableRtl](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDateRangePicker.html#Syncfusion_Blazor_Calendars_SfDateRangePicker_EnableRtl)
property to set the RTL direction.

The following code example initialize the DateRangePicker component in `Hebrew` culture.

```cshtml
@using Syncfusion.Blazor.Calendars
@inject HttpClient Http;

<SfDateRangePicker TValue="DateTime?" Locale="ar" EnableRtl=true></SfDateRangePicker>

@code {
    [Inject]
    protected IJSRuntime JsRuntime { get; set; }
    protected override async Task OnInitializedAsync()
    {  
        this.JsRuntime.Sf().LoadLocaleData(await Http.GetJsonAsync<object>("blazor-locale/src/ar.json")).SetCulture("ar");
    }
```

The output will be as follows.

![DateRangePicker](./images/he_culture.png)

> You can refer to our [Blazor Date Range Picker](https://www.syncfusion.com/blazor-components/blazor-daterangepicker) feature tour page for its groundbreaking feature representations. You can also explore our [Blazor Date Range Picker example](https://blazor.syncfusion.com/demos/daterangepicker/default-functionalities?theme=bootstrap4) to understand how to present and manipulate data.