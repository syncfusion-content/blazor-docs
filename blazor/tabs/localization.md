---
layout: post
title: Localization in Blazor Tabs Component | Syncfusion
description: Learn here all about Localization in Syncfusion Blazor Tabs component and more.
platform: Blazor
control: Tabs
documentation: ug
---

# Localization in Blazor Tabs Component

Localization library allows to localize the default text content of
Tab. In Tab, the close button's tooltip text alone will be localize based on culture.

| Locale key | en-US (default) |
|------|------|
| closeButtonTitle | Close |

## Blazor Server Side

The static local texts in the Tabs component can be changed to other culture by referring the Resource file. You can refer more details about localization [here](../../common/localization/). By default, Tabs is set to follow the English culture ('en-US'). The following steps explains how to render the Tabs in German culture ('de-DE').

* Open the **Startup.cs** file and add the below configuration in the **ConfigureServices** function as follows.

```csharp
using Syncfusion.Blazor;
using System.Globalization;
using Microsoft.AspNetCore.Localization;

namespace TabLocalization
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
                    new CultureInfo("de-DE")
                };
                // set the default culture
                options.DefaultRequestCulture = new RequestCulture("de-DE");
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

> Add [`UseRequestLocalization()`](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/localization?view=aspnetcore-3.0#localization-middleware) middle-ware in Configure method in **Startup.cs** file to get browser Culture Information.

* Then, write a **class** by inheriting **ISyncfusionStringLocalizer** interface and override the `ResourceManager` property to get the resource file details from the application end.

```csharp
using Syncfusion.Blazor;

namespace TabLocalization
{
     public class SampleLocalizer : ISyncfusionStringLocalizer
    {
        public string GetText(string key)
        {
            return this.ResourceManager.GetString(key);
        }

        public System.Resources.ResourceManager ResourceManager
        {
            get
            {
                return TabLocalization.Resources.SyncfusionBlazorLocale.ResourceManager;
            }
        }
    }
}
```

* Add **.resx** file to [`Resource`](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/localization?view=aspnetcore-3.0#resource-files) folder and that file contains the key value pair of locale content in the following format.

```csharp
<Component_Name>_<Feature_Name>_<Locale_Key>
```

* Finally, specify add the Tabs in razor page as in the following code example.

```cshtml
@using Syncfusion.Blazor.Navigations

<SfTab ShowCloseButton="true">
    <TabItems>
        <TabItem Content="Twitter is an online social networking service that enables users to send and read short 140-charactermessages called tweets.Registered users can read and post tweets, but those who are unregistered can only readthem.Users access Twitter through the website interface, SMS or mobile device app Twitter Inc. is based in SanFrancisco and has more than 25 offices around the world.Twitter was created in March 2006 by Jack Dorsey,Evan Williams, Biz Stone, and Noah Glass and launched in July 2006. The service rapidly gained worldwide popularity,with more than 100 million users posting 340 million tweets a day in 2012.The service also handled 1.6 billionsearch queries per day.">
          <ChildContent>
                <TabHeader Text="Twitter">
                </TabHeader>
            </ChildContent>
        </TabItem>
        <TabItem Content="Facebook is an online social networking service headquartered in Menlo Park, California. Its website waslaunched on February 4, 2004, by Mark Zuckerberg with his Harvard College roommates and fellow students EduardoSaverin, Andrew McCollum, Dustin Moskovitz and Chris Hughes.">
          <ChildContent>
                <TabHeader Text="Facebook">
                </TabHeader>
            </ChildContent>
        </TabItem>
        <TabItem Content="WhatsApp Messenger is a proprietary cross-platform instant messaging client for smartphones that operatesunder a subscription business model.It uses the Internet to send text messages, images, video, user location andaudio media messages to other users using standard cellular mobile numbers. As of February 2016, WhatsApp had a userbase of up to one billion,[10] making it the most globally popular messaging application.WhatsApp Inc., based inMountain View, California, was acquired by Facebook Inc.on February 19, 2014, for approximately US$19.3 billion.">
          <ChildContent>
                <TabHeader Text="Whatsapp">
                </TabHeader>
            </ChildContent>
        </TabItem>
    </TabItems>
</SfTab>
```

## Blazor Web Assembly

The following steps explain you to set `de-DE` culture for Tabs in web assembly application.

1. Add the Localization service configuration in the `~/Program.cs` file.

    ```csharp
    using Syncfusion.Blazor;
    using Microsoft.JSInterop;
    using System.Globalization;
    using TabLocalization.Shared;

    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            .....
            .....

            builder.Services.AddSyncfusionBlazor();

            #region Localization
            // Register the Syncfusion locale service to customize the  SyncfusionBlazor component locale culture
            builder.Services.AddSingleton(typeof(ISyncfusionStringLocalizer), typeof(SyncfusionLocalizer));

            // Set the default culture of the application
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("de-DE");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("de-DE");
            #endregion

            await builder.Build().RunAsync();
        }
    }
    ```

2. Create `~/Shared/SyncfusionLocalizer.cs` file and implement `ISyncfusionStringLocalizer` to the class. This acts as a middleware to connect the Syncfusion Blazor UI components and resource files.

    > Map the `SfResources.ResourceManager` to this interface `ResourceManager`.

    ```csharp
    using Syncfusion.Blazor;

    public class SyncfusionLocalizer : ISyncfusionStringLocalizer
    {
        // To get the locale key from mapped resources file
        public string GetText(string key)
        {
            return this.ResourceManager.GetString(key);
        }

        // To access the resource file and get the exact value for locale key

        public System.Resources.ResourceManager ResourceManager {
            get
            {
                return TabLocalization.Resources.SfResources.ResourceManager;
            }
        }
    }
    ```

3. Add the resource files in the `~/Resources` folder. The locale resource files for different cultures are available in this [GitHub](https://github.com/syncfusion/blazor-locale) repository. You can get any culture resource file from there and utilize it in your application.

    After adding the resource file in the application we need to generate the designer class for the resources. To generate the designer class, open the default `resx` file in Visual Studio, and set its `Access Modifier` to `Public`. This will create an entry in your `.csproj` file similar to the following.

    ```csharp
    <ItemGroup>
      <Compile Update="Resources\SfResources.Designer.cs">
        <DesignTime>True</DesignTime>
        <AutoGen>True</AutoGen>
        <DependentUpon>SfResources.resx</DependentUpon>
      </Compile>
    </ItemGroup>

    <ItemGroup>
      <EmbeddedResource Update="Resources\SfResources.resx">
        <Generator>PublicResXFileCodeGenerator</Generator>
        <LastGenOutput>SfResources.Designer.cs</LastGenOutput>
      </EmbeddedResource>
    </ItemGroup>
    ```

4. Add the custom JavaScript interop function to get or set the culture in `~/wwwrooot/index.html`.

    ```html
    <body>
        .....
        .....

        <script src="_framework/blazor.webassembly.js"></script>

        <script>
            window.cultureInfo = {
                get: () => window.localStorage['BlazorCulture'],
                set: (value) => window.localStorage['BlazorCulture'] = value
            };
        </script>
    </body>
    ```

5. Finally, add the Tabs in razor page as in the following code example.

```cshtml
@using Syncfusion.Blazor.Navigations

<SfTab ShowCloseButton="true">
    <TabItems>
        <TabItem Content="Twitter is an online social networking service that enables users to send and read short 140-charactermessages called tweets.Registered users can read and post tweets, but those who are unregistered can only readthem.Users access Twitter through the website interface, SMS or mobile device app Twitter Inc. is based in SanFrancisco and has more than 25 offices around the world.Twitter was created in March 2006 by Jack Dorsey,Evan Williams, Biz Stone, and Noah Glass and launched in July 2006. The service rapidly gained worldwide popularity,with more than 100 million users posting 340 million tweets a day in 2012.The service also handled 1.6 billionsearch queries per day.">
          <ChildContent>
                <TabHeader Text="Twitter">
                </TabHeader>
            </ChildContent>
        </TabItem>
        <TabItem Content="Facebook is an online social networking service headquartered in Menlo Park, California. Its website waslaunched on February 4, 2004, by Mark Zuckerberg with his Harvard College roommates and fellow students EduardoSaverin, Andrew McCollum, Dustin Moskovitz and Chris Hughes.">
          <ChildContent>
                <TabHeader Text="Facebook">
                </TabHeader>
            </ChildContent>
        </TabItem>
        <TabItem Content="WhatsApp Messenger is a proprietary cross-platform instant messaging client for smartphones that operatesunder a subscription business model.It uses the Internet to send text messages, images, video, user location andaudio media messages to other users using standard cellular mobile numbers. As of February 2016, WhatsApp had a userbase of up to one billion,[10] making it the most globally popular messaging application.WhatsApp Inc., based inMountain View, California, was acquired by Facebook Inc.on February 19, 2014, for approximately US$19.3 billion.">
          <ChildContent>
                <TabHeader Text="Whatsapp">
                </TabHeader>
            </ChildContent>
        </TabItem>
    </TabItems>
</SfTab>
```

Output be like the below.

![Tab Localization](./images/localization.png)