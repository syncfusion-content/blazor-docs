---
layout: post
title: Content Security Policy (CSP) - Syncfusion
description: Learn here about that how use Syncfusion Blazor Components with strict Content Security Policy (CSP).
platform: Blazor
component: Common
documentation: ug
---

# Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Components with Strict Content Security Policy (CSP)

Content Security Policy (CSP) is a security feature implemented by web browsers that helps to protect against attacks such as cross-site scripting (XSS) and data injection. It does this by limiting the sources from which certain types of content can be loaded on a webpage.

When enabling strict Content Security Policy (CSP), some browser features are disabled by default. In order to use Syncfusion<sup style="font-size:70%">&reg;</sup> blazor components with strict CSP mode, certain directives must be included in the CSP meta tag. These directives allow to use certain features that are necessary for Syncfusion<sup style="font-size:70%">&reg;</sup> blazor components to function properly.

To use Syncfusion<sup style="font-size:70%">&reg;</sup> blazor components with strict CSP mode, the following directives must be included in the CSP meta tag:

* `font-src data:` - This directive allows for the use of `base64` encoded font icons.
* `style-src 'self' unsafe-inline` - This directive permits the use of inline styles, allowing components to apply parameters such as Width, Height, positioning, etc. Additionally, certain components depend on inline styling to render dynamic behaviors and responsive UI design.
* `connect-src 'self' https: wss:` - This directive enables web sockets.
* `script-src 'self' unsafe-eval` - This directive allows for the use of the `new()` and `eval()` functions. Used in animation enabled Syncfusion<sup style="font-size:70%">&reg;</sup> components.

These directives should be included in the `<head>` tag of the application's webpage, typically

* For **.NET 8 and .NET 9**  Blazor Web Apps using any render mode (Server, WebAssembly, or Auto), inside the `<head>` of **~/Components/App.razor** file.

* For **Blazor WebAssembly Standalone App**, inside the `<head>` of **wwwroot/index.html** file.

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

if you are referencing script and style references from CDN, then add CDN domain reference in CSP meta tag.

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
