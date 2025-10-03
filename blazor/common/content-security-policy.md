---
layout: post
title: Content Security Policy (CSP) - Syncfusion
description: Learn how to use Syncfusion Blazor components with a strict Content Security Policy (CSP) in Blazor Web App, Blazor WebAssembly (WASM), and Blazor Server.
platform: Blazor
control: Common
documentation: ug
---

# Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components with a strict Content Security Policy (CSP)

Content Security Policy (CSP) is a browser security feature that helps protect against cross-site scripting (XSS) and data injection by limiting the allowed sources for scripts, styles, images, fonts, and other resources.

When enforcing a strict CSP, some browser features are blocked by default. To use Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components under a strict CSP, include specific directives in the CSP policy so required runtime behaviors continue to work.

Include the following directives in the CSP policy for Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components:

* `font-src data:` – Allows `base64`-encoded font icons.
* `style-src 'self' 'unsafe-inline'` – Permits inline styles. Some components use inline styling for sizing, positioning, and dynamic UI behavior.
* `connect-src 'self' https: wss:` – Enables WebSockets and HTTPS connections.
* `script-src 'self' 'unsafe-eval'` – Permits dynamic code evaluation required by certain features (for example, animation logic).

These directives should be included in the `<head>` tag of the application's webpage, typically

* For **.NET 8 and .NET 9** Blazor Web Apps using any render mode (Server, WebAssembly, or Auto), inside the `<head>` of the **~/Components/App.razor** file.

* For **Blazor WebAssembly Standalone App**, inside the `<head>` of the **wwwroot/index.html** file.

{% tabs %}
{% highlight c# hl_lines="9 10" %}

<head>
    ...
    <meta http-equiv="Content-Security-Policy"
        content="base-uri 'self';
        default-src 'self';
        connect-src 'self' https: wss:;
        img-src data: https:;
        object-src 'none';
        script-src 'self' 'unsafe-eval';
        style-src 'self' 'unsafe-inline';
        font-src 'self' data:;
        upgrade-insecure-requests;">
    ...
</head>

{% endhighlight %}
{% endtabs %}

If referencing scripts and styles from a CDN, add the CDN domain to the CSP policy (for example, include the Syncfusion CDN under `script-src` and `style-src`).

{% tabs %}
{% highlight c# hl_lines="9 10" %}

<head>
    ...
    <meta http-equiv="Content-Security-Policy"
        content="base-uri 'self';
        default-src 'self';
        connect-src 'self' https: wss:;
        img-src data: https:;
        object-src 'none';
        script-src 'self' 'unsafe-eval' https://cdn.syncfusion.com/blazor/;
        style-src 'self' 'unsafe-inline' https://cdn.syncfusion.com/blazor/;
        font-src 'self' data:;
        upgrade-insecure-requests;">
    ...
</head>

{% endhighlight %}
{% endtabs %}

## See also

* [Content Security Policy for ASP.NET Core Blazor](https://learn.microsoft.com/en-us/aspnet/core/blazor/security/content-security-policy?view=aspnetcore-9.0)
