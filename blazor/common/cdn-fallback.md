---
layout: post
title: CDN fallback in Blazor - Syncfusion
description: Learn here about content delivery network (CDN) fallback handling in Blazor Server and WebAssembly (WASM) apps.
platform: Blazor
component: Common
documentation: ug
---

# CDN fallback in Blazor application

This section provides information about how to refer fallback [scripts](https://blazor.syncfusion.com/documentation/common/adding-script-references#static-web-assets) and [style sheet](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets) from **Static Web Assets** when CDN is not available in Blazor application.

## Blazor Web App

For **.NET 8 and .NET 9**  Blazor Web Apps using any render mode (Server, WebAssembly, or Auto), refer the script and style sheet fallback from [Static Web Assets](https://blazor.syncfusion.com/documentation/common/adding-script-references#static-web-assets) inside the Script tag like below.

### Script fallback

You can check the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor object for script fallback whether scripts are loaded or not. If it's not loaded, create a script tag and refer scripts externally inside the `<body>` of **~/Components/App.razor** file in server side app as in the below code.

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

You can refer the theme stylesheet inside the `<head>` of **~/Components/App.razor** file in server side app like below.

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

For Blazor WebAssembly Standalone app, refer the script and style sheet fallback from [Static Web Assets](https://blazor.syncfusion.com/documentation/common/adding-script-references#static-web-assets) inside the Script tag like below.

### Script fallback

You can check the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor object for script fallback whether scripts are loaded or not. If it's not loaded, create a script tag and refer scripts externally inside the `<head>` of **wwwroot/index.html** file in client web app as in the below code.

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

You can refer the theme stylesheet inside the `<head>` of **wwwroot/index.html** file in client web app like below.

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
