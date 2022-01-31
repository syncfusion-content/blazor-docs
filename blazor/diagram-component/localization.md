---
layout: post
title: Localization in the Blazor Diagram Component | Syncfusion
description: Checkout and learn  all about Localization in the Syncfusion Blazor Diagram component and much more.
platform: Blazor
control: Diagram Component
documentation: ug
---

# Localization in Blazor Diagram Component

The static text of the Diagram was translated using a Resource file (**.resx**).

The Resource file is an XML file that contains the strings (key and value pairs) that you want to translate. For further information on how to configure and use localization in the ASP.NET Core application framework, see the [Localization](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/localization?view=aspnetcore-3.0) link.

* Add the **.resx** file to the [Resources](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/localization?view=aspnetcore-3.0#resource-files) folder and fill in the **Name** column with the key value (Locale Keywords) and the translated string in the **Value** column.

## Blazor server side

Add `UseRequestLocalization` middle-ware in Configure method in **Startup.cs** file to obtain browser Culture Info.

Refer to the following code to add the configuration in the Startup.cs file

```csharp
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;

namespace BlazorApplication
{
    public class Startup
    {
        ....
        ....

      #region Localization
            app.UseRequestLocalization(app.ApplicationServices. GetService<IOptions<RequestLocalizationOptions>>().Value);
            #endregion
    }
}
```

The following example demonstrates how to enable **Localization** for the Diagram in server side Blazor samples. Here, we have used Resource file to translate the static text.

* Open the **Startup.cs** file and add the following configuration in the **ConfigureServices** function. 

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
               #region Localization
            // Set the resx file folder path to access
            services.AddLocalization(options => options.ResourcesPath = "Resources")    ;
            services.AddSyncfusionBlazor();
            // Register the Syncfusion locale service to customize the SyncfusionBlazor component’s locale culture
            services.AddSingleton(typeof(ISyncfusionStringLocalizer), typeof    (SyncfusionLocalizer));
            services.Configure<RequestLocalizationOptions>(options =>
            {
                // Set the french culture
                var supportedCultures = new List<CultureInfo>()
                {
                    new CultureInfo("fr")
                };
                // Set the default culture
                options.DefaultRequestCulture = new RequestCulture("en-US");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });
            #endregion
            }
        }
    }
    ```

* Then, write a **class** by inheriting **ISyncfusionStringLocalizer** interface and override the Manager property to get the resource file details from the application end.

    ```csharp
    using Syncfusion.Blazor;

     public class SyncfusionLocalizer : ISyncfusionStringLocalizer
    {
        // To get the locale key from mapped resources file
        public string GetText(string key)
        {
            return this.ResourceManager.GetString(key);
        }

        // To access the resource file and get the exact value for the locale key

        public System.Resources.ResourceManager ResourceManager {
            get
            {
                // Replace the ApplicationNamespace with your application name.
                return ApplicationNamespace.Resources.SfResources.ResourceManager;
            }
        }
    }
    ```

* Diagram has support to localize the Tooltip of Nodes/Connector. The following code illustrates how to provide localization support for Tooltip.

    | **Name** | **Value (in French culture)** |
    | --- | --- |
    | DiagramComponent_X | X |
    | DiagramComponent_Y | Oui |

    * Add **.resx** file to Resource folder and enter the key value (Locale Keywords) in the **Name** column and the translated string in the Value column as follows.


    ```cshtml
   @using Syncfusion.Blazor.Diagram

    <SfDiagramComponent @ref="diagram" Width="100%" Height="700px" Nodes="Nodes"/>

   @code
       { 
            public SfDiagramComponent diagram;
            DiagramObjectCollection<Node> Nodes = new DiagramObjectCollection<Node>();
            protected override void OnInitialized()
            {
                Node node = new Node()
                {
                    ID = "node3",
                    Width = 100,
                    Height = 100,
                    OffsetX = 700,
                    OffsetY = 400,
                    Annotations = new DiagramObjectCollection<ShapeAnnotation>()
                {
                new ShapeAnnotation()
                {
                    Content="Process"
                }
            }
                };
                Nodes.Add(node);
     }

    ```

## Blazor WebAssembly

The following steps explain how to render the Diagram in French culture (fr) in the Blazor Web Assembly application.

* Open the **program.cs** file and add the following configuration to the **Builder ConfigureServices** function.

    ```csharp
    using Syncfusion.Blazor;
    using Microsoft.AspNetCore.Builder;

    namespace WebAssemblyLocale
    {
        public class Program
        {
           public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            .....
            .....

            builder.Services.AddSyncfusionBlazor();

            #region Localization
            // Register the Syncfusion locale service to customize the  SyncfusionBlazor component’s locale culture
            builder.Services.AddSingleton(typeof(ISyncfusionStringLocalizer), typeof(SyncfusionLocalizer));

            // Set the default culture of the application
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en-US");

            // Set the french culture
            CultureInfo.DefaultThreadCurrentCulture =   new CultureInfo("fr");
            CultureInfo.DefaultThreadCurrentUICulture =   new CultureInfo("fr");
            
            #endregion

            await builder.Build().RunAsync();
        }
    }
    ```



```cshtml
 @using Syncfusion.Blazor.Diagram

    <SfDiagramComponent @ref="diagram" Width="100%" Height="700px" Nodes="Nodes"/>

   @code
       { 
            public SfDiagramComponent diagram;
            DiagramObjectCollection<Node> Nodes = new DiagramObjectCollection<Node>();
            protected override void OnInitialized()
            {
                Node node = new Node()
                {
                    ID = "node3",
                    Width = 100,
                    Height = 100,
                    OffsetX = 700,
                    OffsetY = 400,
                    Annotations = new DiagramObjectCollection<ShapeAnnotation>()
                {
                new ShapeAnnotation()
                {
                    Content="Process"
                }
            }
                };
                Nodes.Add(node);
            }
     }
```

The output will be as follows.

![Localization in Blazor Diagram](images/Localization.png)