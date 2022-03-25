---
layout: post
title: CDN fallback in Blazor - Syncfusion
description: Learn here about Content Delivery Network (CDN) fallback in Blazor Server and WebAssembly (WASM) apps.
platform: Blazor
component: Common
documentation: ug
---

# CDN fallback in Blazor application.

This section provides information about the CDN fallback and how to refer fallback scripts and style sheet from [Static Web Assets](https://blazor.syncfusion.com/documentation/common/adding-script-references#static-web-assets) for Blazor application.

## Blazor Server App

* CDN links can be down by connection issues or some other problems. This will cause the site looks broken. Follow the below steps to resolve these issues in the Blazor application.

* If you are using CDN for style sheet references then you have to add style sheet fallback from [Static Web Assets](https://blazor.syncfusion.com/documentation/common/adding-script-references#static-web-assets) by using the [link tag helper](https://docs.microsoft.com/en-us/aspnet/core/mvc/views/tag-helpers/built-in/link-tag-helper?view=aspnetcore-6.0).

* Syncfusion theme provides the `e-control` class. You can check the style from provided class by using link tag helper property. 

For example, Here Style sheet CDN link is broken by adding the string `test` to the theme name.

* **~/Pages/_Host.cshtml** file for **.NET 5 and .NET 3.X**.
* **~/Pages/_Layout.cshtml** for **.NET 6**.

{% tabs %}
{% highlight cshtml tabtitle=".NET 6 (~/_Layout.cshtml)" %}

<head>
    ...
    <link rel="stylesheet" href="https://cdn.syncfusion.com/blazor/{{ site.blazor }}/styles/bootstrap5-test.css"
    asp-fallback-href="_content/Syncfusion.Blazor/styles/bootstrap5.css"
    asp-fallback-test-class="e-control"
    asp-fallback-test-property="font-size"
    asp-fallback-test-value="12px" />
</head>

{% endhighlight %}
{% highlight cshtml tabtitle=".NET 5 and .NET 3.X (~/_Host.cshtml)" %}

<head>
    ...
    <link rel="stylesheet" href="https://cdn.syncfusion.com/blazor/{{ site.blazor }}/styles/bootstrap5-test.css"
    asp-fallback-href="_content/Syncfusion.Blazor/styles/bootstrap5.css"
    asp-fallback-test-class="e-control"
    asp-fallback-test-property="font-size"
    asp-fallback-test-value="12px" />
</head>

{% endhighlight %}
{% endtabs %}

> You can also use below [script](#script-fallback) and [style sheet](#style-sheet-fallback) fallback for blazor server app.

## Blazor WebAssembly App

For Blazor WebAssembly app, refer the script and style sheet fallback from [Static Web Assets](https://blazor.syncfusion.com/documentation/common/adding-script-references#static-web-assets) inside the Script tag like below.

### Script fallback

You can check the Syncfusion Blazor object for script fallback whether scripts are loaded or not. If it's not loaded create a script tag and refer scripts externally inside the `<head>` of **wwwroot/index.html** file in client web app, use the code below. Here CDN script link is broken by adding the string `test` to it.

{% tabs %}
{% highlight cshtml tabtitle="~/index.html" %}

<head>
    ...
    <script src="https://cdn.syncfusion.com/blazor/{{ site.blazor }}/syncfusion-blazor.min-test.js" type="text/javascript"></script>
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

## Style sheet fallback

You can refer the theme style sheet inside the `<head>` of **wwwroot/index.html** file in client web app like below. Here CDN style sheet is broken by add string `test` to it.

{% tabs %}
{% highlight cshtml tabtitle="~/index.html" %}

<head>
    ...
    <link href="https://cdn.syncfusion.com/blazor/19.4.56/styles/material-test.css" rel="stylesheet" />
</head>

<body>
    ...
    <script>
    function cdnScriptTest() {
        var testElem = document.createElement("div");
        testElem.className = "e-control"; // Syncfusion themes provides the e-control class
        document.body.appendChild(testElem);
        var testFontSize = window.getComputedStyle(testElem).getPropertyValue("font-size");
        if (testFontSize !== "12px") {
            // CDN failed
            var fallbackStyle = document.createElement("link");
            fallbackStyle.setAttribute("rel", "stylesheet");
            fallbackStyle.setAttribute("type", "text/css");
            fallbackStyle.setAttribute("href", "_content/Syncfusion.Blazor/styles/bootstrap5.css"); // URL to the static asset from the Syncfusion package
            document.getElementsByTagName("head")[0].appendChild(fallbackStyle);
            }
            document.body.removeChild(testElem);
        }
        cdnScriptTest();
    </script>
</body>

{% endhighlight %}
{% endtabs %}
