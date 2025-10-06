---
layout: post
title: CDN fallback in Blazor - Syncfusion
description: Learn how to handle content delivery network (CDN) fallbacks in Blazor Web App, Blazor Server, and Blazor WebAssembly (WASM) apps using Static Web Assets.
platform: Blazor
control: Common
documentation: ug
---

# CDN fallback in Blazor application

This section explains how to reference fallback [scripts](https://blazor.syncfusion.com/documentation/common/adding-script-references#static-web-assets) and [stylesheets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets) from Static Web Assets when the CDN is unavailable in a Blazor application.

## Blazor Web App

For **.NET 8 and .NET 9** Blazor Web Apps using any render mode (Server, WebAssembly, or Auto), reference script and stylesheet fallback from [Static Web Assets](https://blazor.syncfusion.com/documentation/common/adding-script-references#static-web-assets) as shown below.

### Script fallback

Check the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor object to determine whether scripts are loaded. If they are not loaded, create a script tag and reference the scripts from Static Web Assets inside the `<body>` of the **~/Components/App.razor** file in the Server App, as shown below.

{% tabs %}
{% highlight cshtml tabtitle="~/App.razor" %}

<body>
    ...
    <script src="https://cdn.syncfusion.com/blazor/{{ site.blazorversion }}/syncfusion-blazor.min.js" type="text/javascript"></script>
    <script>
    if (!window.sfBlazor) { // the Syncfusion Blazor object is not present
        var fallbackScript = document.createElement("script");
        fallbackScript.setAttribute("src", "_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js"); // path to static assets from the individual NuGet packages
        document.getElementsByTagName("body")[0].appendChild(fallbackScript);
    }
    </script>
</body>

{% endhighlight %}
{% endtabs %}

### Stylesheet fallback

Reference the theme stylesheet inside the `<head>` of the **~/Components/App.razor** file in the Server App, as shown below.

{% tabs %}
{% highlight cshtml %}

<head>
    ...
    <link rel="stylesheet" href="https://cdn.syncfusion.com/blazor/{{ site.blazorversion }}/styles/bootstrap5.css"
    asp-fallback-href="_content/Syncfusion.Blazor.Themes/bootstrap5.css"
    asp-fallback-test-class="e-control"
    asp-fallback-test-property="font-size"
    asp-fallback-test-value="12px" />
</head>

{% endhighlight %}
{% endtabs %}

## Blazor WebAssembly Standalone App

For Blazor WebAssembly Standalone App, reference script and stylesheet fallback from [Static Web Assets](https://blazor.syncfusion.com/documentation/common/adding-script-references#static-web-assets) as shown below.

### Script fallback

Check the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor object to determine whether scripts are loaded. If they are not loaded, create a script tag and reference the scripts from Static Web Assets inside the `<head>` of the **wwwroot/index.html** file in the client app, as shown below.

{% tabs %}
{% highlight cshtml tabtitle="~/index.html" %}

<head>
    ...
    <script src="https://cdn.syncfusion.com/blazor/{{ site.blazorversion }}/syncfusion-blazor.min.js" type="text/javascript"></script>
    <script>
    if (!window.sfBlazor) { // the Syncfusion Blazor object is not present
        var fallbackScript = document.createElement("script");
        fallbackScript.setAttribute("src", "_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js"); // path to static assets from the Syncfusion package
        document.getElementsByTagName("head")[0].appendChild(fallbackScript);
    }
    </script>
</head>

{% endhighlight %}
{% endtabs %}

### Stylesheet fallback

Reference the theme stylesheet inside the `<head>` of the **wwwroot/index.html** file in the client app, as shown below.

{% tabs %}
{% highlight cshtml tabtitle="~/index.html" %}

<head>
    ...
    <link href="https://cdn.syncfusion.com/blazor/{{ site.blazorversion }}/styles/bootstrap5.css" rel="stylesheet" />
</head>

<body>
    ...
    <script>
    function cdnStyleTest() {
        var testElem = document.createElement("div");
        testElem.className = "e-control"; // Syncfusion themes provides the e-control class
        document.body.appendChild(testElem);
        var testFontSize = window.getComputedStyle(testElem).getPropertyValue("font-size");
        if (testFontSize !== "12px") {
            // CDN failed
            var fallbackStyle = document.createElement("link");
            fallbackStyle.setAttribute("rel", "stylesheet");
            fallbackStyle.setAttribute("type", "text/css");
            fallbackStyle.setAttribute("href", "_content/Syncfusion.Blazor.Themes/bootstrap5.css"); // URL to the static asset from the individual NuGet packages
            document.getElementsByTagName("head")[0].appendChild(fallbackStyle);
            }
            document.body.removeChild(testElem);
        }
        cdnStyleTest();
    </script>
</body>

{% endhighlight %}
{% endtabs %}
