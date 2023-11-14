---
layout: post
title: Content Security Policy (CSP) - Syncfusion
description: Learn here about that how use Syncfusion Blazor Components with strict Content Security Policy (CSP).
platform: Blazor
component: Common
documentation: ug
---

# Syncfusion Blazor Components with Strict Content Security Policy (CSP)

Content Security Policy (CSP) is a security feature implemented by web browsers that helps to protect against attacks such as cross-site scripting (XSS) and data injection. It does this by limiting the sources from which certain types of content can be loaded on a webpage.

When enabling strict Content Security Policy (CSP), some browser features are disabled by default. In order to use Syncfusion blazor components with strict CSP mode, certain directives must be included in the CSP meta tag. These directives allow to use certain features that are necessary for Syncfusion blazor components to function properly.

To use Syncfusion blazor components with strict CSP mode, the following directives must be included in the CSP meta tag:

* `font-src data:` - This directive allows for the use of `base64` encoded font icons.
* `style-src 'self' unsafe-inline` - This directive allows for the use of inline styles and external fonts.
* `script-src 'self' unsafe-eval blob:` - This directive allows for the use of the `new()` and `eval()` functions, as well as loading scripts from Blob URLs. Used in animation enabled Syncfusion components.

These directives should be included in the `<head>` tag of the application's webpage, typically

* For **Blazor Server application**, inside the `<head>` of

    * **~/Pages/_Host.cshtml** file for .NET 7.
    * **~/Pages/_Layout.cshtml** for .NET 6.

{% tabs %}
{% highlight cshtml tabtitle=".NET 6 (~/_Layout.cshtml)" hl_lines="9 10" %}

<head>
    ...
    <meta http-equiv="Content-Security-Policy" content="
        script-src 'self' 'unsafe-eval' blob:;
        style-src 'self' 'unsafe-inline';
        img-src data: blob: https:;
        font-src 'self' data:;" />
    ...
</head>

{% endhighlight %}
{% highlight cshtml tabtitle=".NET 7 (~/_Host.cshtml)" hl_lines="9 10" %}

<head>
    ...
    <meta http-equiv="Content-Security-Policy" content="
        script-src 'self' 'unsafe-eval' blob:;
        style-src 'self' 'unsafe-inline';
        img-src data: blob: https:;
        font-src 'self' data:;" />
    ...
</head>

{% endhighlight %}
{% endtabs %}

* For **Blazor WebAssembly App**, inside the `<head>` of **wwwroot/index.html** file.

{% tabs %}
{% highlight html tabtitle="~/index.html" hl_lines="9 10" %}
<head>
    ...
    <meta http-equiv="Content-Security-Policy" content="
        script-src 'self' 'unsafe-eval' blob:;
        style-src 'self' 'unsafe-inline';
        img-src data: blob: https:;
        font-src 'self' data:;" />
    ...
</head>
{% endhighlight %}
{% endtabs %}

if you are referencing script and style references from CDN, then add CDN domain reference in CSP meta tag.

* Blazor Server App

{% tabs %}

{% highlight cshtml tabtitle=".NET 6 (~/_Layout.cshtml)" hl_lines="9 10" %}

<head>
    ...
    <meta http-equiv="Content-Security-Policy" content="
        script-src 'self' 'unsafe-eval' https://cdn.syncfusion.com blob:;
        style-src 'self' 'unsafe-inline' https://cdn.syncfusion.com;
        img-src data: blob: https:;
        font-src 'self' data:;" />
    ...
</head>

{% endhighlight %}

{% highlight cshtml tabtitle=".NET 7 (~/_Host.cshtml)" hl_lines="9 10" %}

<head>
    ...
    <meta http-equiv="Content-Security-Policy" content="
        script-src 'self' 'unsafe-eval' https://cdn.syncfusion.com blob:;
        style-src 'self' 'unsafe-inline' https://cdn.syncfusion.com;
        img-src data: blob: https:;
        font-src 'self' data:;" />
    ...
</head>

{% endhighlight %}

{% endtabs %}


* Blazor WebAssembly App

{% tabs %}
{% highlight html tabtitle="~/index.html" hl_lines="9 10" %}

<head>
    ...
    <meta http-equiv="Content-Security-Policy" content="
        script-src 'self' 'unsafe-eval' https://cdn.syncfusion.com blob:;
        style-src 'self' 'unsafe-inline' https://cdn.syncfusion.com;
        img-src data: blob: https:;
        font-src 'self' data:;" />
    ...
</head>

{% endhighlight %}

{% endtabs %}

## See also

* [Content Security Policy for ASP.NET Core Blazor](https://learn.microsoft.com/en-us/aspnet/core/blazor/security/content-security-policy?view=aspnetcore-7.0)
