---
layout: post
title: CRG in Blazor - Syncfusion
description: Check out the documentation for CRG in Blazor
platform: Blazor
component: Common
documentation: ug
---

# Custom Resource Generator

W> Starting with version 18.3.0.35 (Volume 3, 2020), the Syncfusion Blazor library is integrated with the JavaScript Isolation feature of Blazor. So, the CRG online tool is no longer needed for your production environment and it is deprecated now. That is, the Syncfusion Blazor library itself handles the Syncfusion interop scripts and it is no longer needs to be added manually in the layout page (_Host.cshtml/index.html) for production. You can still use the [ThemeStudio](http://ej2.syncfusion.com/themestudio/) online web application to customize and generate the Syncfusion Blazor themes for a specific set of components.

Syncfusion provides an option to generate a selective component's interop script and styles using the [`Custom Resource Generator`](https://blazor.syncfusion.com/crg) (CRG) web tool.

![Custom resource generator preview for Blazor](images/custom-resource-generator-preview.png)

## Search and select the component list

Search and select the required Syncfusion Blazor UI components from the CRG to generate a specific set of component resources.

Refer to the following steps to search and select the components in CRG:

1. Navigate to the Custom Resource Generator (CRG) application at [`CRG`](https://blazor.syncfusion.com/crg).

2. Type the required component name in the search bar, and then select the checkbox. The dependency of the selected component is resolved in the application itself, so you do not need to choose each dependent component manually.

    ![Search and select Syncfusion Blazor UI components](images/search-non-injectable.png)

3. Click the expand icon, and then select the required features for the specific set of components.

    ![Select feature-based script in the supported components](images/select-injectable-module.png)

4. If the entire features of the component are needed, then click the specific component's checkbox to select all features.

    ![Select all features in the component](images/select-all-injectable.png)

5. Select the required built-in themes from the **Select Themes** option. This provides an option to select more than one theme.

    ![Select the built-in themes](images/select-inbuilt-themes.png)

## Download the selected component resources

After selecting the required component resources, download the custom interop script and styles from CRG.

Refer to the following steps to download the custom resources in CRG:

1. Click the **DOWNLOAD** button at the bottom of the page. Select the **Minified** option to generate the minified file output for production.

    ![Download option](images/download-option.png)

2. Change the file name as needed, and then click **GENERATE** button in the pop-up.

    ![Export popup for generation custom resources](images/export-popup.png)

3. Now, the bundling process for the selected components will be started, and the output will be downloaded as a zip file.

    ![blazor Bundle custom resources](images/bundling-custom-resources.png)

4. The final output contains the custom interop script and styles for the selected components and an **import.json** file, which stores the current settings.

    ![Final output of customized resources](images/customized-resources.png)

## How to use custom resources in the Blazor application

W> Starting with version 18.3.0.35 (Volume 3, 2020), the following configuration is no longer needed for the production environment. You can use the default [getting started](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-visual-studio-2019/#importing-syncfusion-blazor-component-in-the-application) configuration in production mode.

1. Copy or paste the downloaded custom resources in the Blazor application `~/wwwroot` folder.

2. Set `DisableScriptManager` as true in `AddSyncfusionBlazor` service in `~/Startup.cs` file for Blazor Server app or `~/Program.cs` file for Blazor WebAssembly app.

    **Blazor Server App (~/Startup.cs)**

{% tabs %}

{% highlight c# %}

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddRazorPages();
        services.AddServerSideBlazor();

        // Set DisableScriptManager as true to load custom  scripts
        services.AddSyncfusionBlazor(true);

        services.AddSingleton<WeatherForecastService>();
    }

{% endhighlight %}

{% endtabs %}

**Blazor WebAssembly App (~/Program.cs)**

{% tabs %}

{% highlight c# %}

    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args)    ;
        ....
        ....

        // Set DisableScriptManager as true to load custom  scripts
        builder.Services.AddSyncfusionBlazor(true);

        await builder.Build().RunAsync();
    }

{% endhighlight %}

{% endtabs %}

3. Now, manually add the custom interop script and styles in the `~/Pages/_Host.cshtml` for Blazor Server app or `~/wwwroot/index.html` for Blazor WebAssembly app.

{% tabs %}

{% highlight html %}

    <head>
        ....
        ....
        <link href="material.css" rel="stylesheet" />
        <script src="syncfusion-blazor.min.js" type="text/javascript"></script>
    </head>

{% endhighlight %}

{% endtabs %}

4. Run the application and it will load the resources with application required components.

## Import previously generated settings into CRG

To add more components or upgrade the latest Syncfusion Blazor library resources, it is not necessary to generate from the scratch in the CRG. Just import the old **import.json** file, make the changes, and then download it again from the CRG application.

Refer to the following steps to import previous settings in CRG:

1. Click the **IMPORT SETTINGS** button at the bottom of the page.

    ![Import option in CRG](images/import-option.png)

2. Upload the **import.json** file, so that the previously stored data will be restored in the CRG application. Now, add more components and export the resources again.

    ![blazor Previous changes restored](images/previous-changes-restored.png)
