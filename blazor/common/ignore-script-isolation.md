---
layout: post
title: Ignore script isolation in Blazor - Syncfusion
description: Learn here about that how to enable the ignore script isolation process in the Syncfusion Blazor Components
platform: Blazor
component: Common
documentation: ug
---

# Ignore script isolation

The Syncfusion Blazor Provides an alternative support to refer the component scripts externally from the application. It is used to increase initial load performance. This support is applicable from 19.2.* version. If `IgnoreScriptIsolation` is set to `true` in `AddSyncfusionBlazor()`, the Syncfusion Blazor components will disable the dynamic script loading, instead of this it uses the external scripts reference from the application.

## How to refer the component scripts externally on Blazor Application

Set `IgnoreScriptIsolation` as true in `AddSyncfusionBlazor` service in `~/Startup.cs` file for Blazor Server app or `~/Program.cs` file for Blazor WebAssembly app.

   **Blazor Server App (~/Startup.cs)**  
   
    ```csharp
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddRazorPages();
        services.AddServerSideBlazor();

        // Set IgnoreScriptIsolation as true to load custom  scripts
        services.AddSyncfusionBlazor(options => {
            options.IgnoreScriptIsolation = true;
            });

        services.AddSingleton<WeatherForecastService>();
    }
    ```

   **Blazor WebAssembly App (~/Program.cs)**

    ```csharp
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        ....
        ....

        // Set IgnoreScriptIsolation as true to load custom  scripts
        builder.Services.AddSyncfusionBlazor(options => {
            options.IgnoreScriptIsolation = true;
            });

        await builder.Build().RunAsync();
    }
    ```

Once we set the `IgnoreScriptIsolation` as `true` in our Syncfusion Blazor Service, manually add the external script reference in `~/Pages/_Host.cshtml` for Blazor Server app or `~/wwwroot/index.html` for Blazor WebAssembly app.

**Ways of adding external script references**
  
	1. The Syncfusion provides a combined script with all tools and major Blazor components by excluding PDF Viewer, and Document Editor components

		```html
		<script  src="_content/Syncfusion.Blazor/scripts/syncfusion-blazor.min.js"  type="text/javascript"></script>
		```
    2. If we refer the component Individual package, the Combined Script available in Syncfusion.Blazor.Core packages,

       ```html
       <script  src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js"  type="text/javascript"></script>
       ```    
	3. The same script files can be referred through the CDN version. This can be available in both version specific and unversioned files.
 

   **Version specified script file**
   		```html
		  <script  src="https://cdn.syncfusion.com/blazor/{:version:}/syncfusion-blazor.min.js"  type="text/javascript"></script>
		```

   **Version not specified script file**
        ```html
		<script  src="https://cdn.syncfusion.com/blazor/syncfusion-blazor.min.js"  type="text/javascript"></script>
		```

    4. Select the required component resources and download the custom script from the [CRG](https://crg.syncfusion.com/) site and refer the custom script reference in  your application. For more details refer [this CRG documentation](https://blazor.syncfusion.com/documentation/common/custom-resource-generator#how-to-use-custom-resources-in-the-blazor-application).

    ```html
    <script src="Path for CRG generated script" type="text/javascript"></script>
    ```
**External Script Reference for PDF Viewer and DocumentEditor Component**

PDF Viewer and Document Editor component scripts are not available in `syncfusion-blazor.min.js` file. If we use the PDF viewer or document editor component refer the below script reference in your application end.

> PDF Viewer and Document Editor component scripts are only available after 19.3.* version. Incase if you use PDF Viewer or Document Editor component in your application using 19.2.* version, it automatically refer the dynamic script in our application end.

    1. Refer the component Individual package reference, 

       ```html
       <script  src="_content/Syncfusion.Blazor.PdfViewer/scripts/syncfusion-blazor-pdfviewer.min.js"  type="text/javascript"></script>
       <script  src="_content/Syncfusion.Blazor.WordProcessor/scripts/syncfusion-blazor-documenteditor.min.js"  type="text/javascript"></script>
       ```    
	2. The same script files can be referred through the CDN version. This can be available in both version specific and unversioned files.

  **Version specified script file**
		```html
       <script  src="https://cdn.syncfusion.com/blazor/{:version:}/syncfusion-blazor-pdfviewer.min.js"  type="text/javascript"></script>
       <script  src="https://cdn.syncfusion.com/blazor/{:version:}/syncfusion-blazor-documenteditor.min.js"  type="text/javascript"></script>
		```

   **Version not specified script file**
        ```html
          <script  src="https://cdn.syncfusion.com/blazor/syncfusion-blazor-pdfviewer.min.js"  type="text/javascript"></script>
          <script  src="https://cdn.syncfusion.com/blazor/syncfusion-blazor-documenteditor.min.js"  type="text/javascript"></script>
		```
    3. CRG script reference support also provided for PDF Viewer and Document editor components from `19.3.*` version. Select the required component resources and download the custom script from the [CRG](https://crg.syncfusion.com/) site and refer the custom script reference in  your application.

        ```html
           <script src="Path for CRG generated script" type="text/javascript"></script>
        ```

