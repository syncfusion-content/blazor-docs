# Ignore script isolation

The Syncfusion Blazor Provides an optional support to refer the component scripts externally from the application end to increase initial load performance. If `IgnoreScriptIsolation` is set to `true` in `AddSyncfusionBlazor()`, the Syncfusion Blazor components will disable the built-in script isolation and use application-level scripts.

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

**Ways of adding external script references**
  
	1. The Syncfusion provides a combined script with all tools and major Blazor components by excluding PDF Viewer, and Document Editor components

		```html
		<script  src="_content/Syncfusion.Blazor/scripts/syncfusion-blazor.min.js"  type="text/javascript"></script>
		```
    2. If we refer the component Individual package, the Combined Script available in Syncfusion.Blazor.Core packages,

       ```html
       <script  src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js"  type="text/javascript"></script>
       ```    
	3. Refer to the CDN script reference below.
 
		```html
		<script  src="https://cdn.syncfusion.com/blazor/{:version:}/syncfusion-blazor.min.js"  type="text/javascript"></script>
		```
    4. Generate a required component script and styles from Blazor custom resource generator([Blazor CRG](https://blazor.syncfusion.com/crg)) and refer to them in your application.

    ```html
    <script src="Path for CRG generated script" type="text/javascript"></script>
    ```
**External Script Reference for PdfViewer and DocumentEditor Component**

PDF Viewer and Document Editor component scripts are not available in `syncfusion-blazor.min.js` file. If we use the Pdfviewer or document editor component refer the below script reference in your application end.


    1. Refer the component Individual package reference, 

       ```html
       <script  src="_content/Syncfusion.Blazor.PdfViewer/scripts/syncfusion-blazor-pdfviewer.min.js"  type="text/javascript"></script>
       <script  src="_content/Syncfusion.Blazor.WordProcessor/scripts/syncfusion-blazor-documenteditor.min.js"  type="text/javascript"></script>
       ```    
	2. Refer to the CDN script reference below.
 
		```html
		<script  src="https://cdn.syncfusion.com/blazor/{:version:}/syncfusion-blazor-pdfviewer.min.js"  type="text/javascript"><script>
        <script  src="https://cdn.syncfusion.com/blazor/{:version:}/syncfusion-blazor-documenteditor.min.js"  type="text/javascript"></script>
        ```
