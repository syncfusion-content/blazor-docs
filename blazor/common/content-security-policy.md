---
layout: post
title: Content Security Policy (CSP) - Syncfusion
description: Learn here about that how to resolve the content security policy issue in the Syncfusion Blazor Components.
platform: Blazor
component: Common
documentation: ug
---

# Content Security Policy

Content Security Policy (CSP) is a security feature implemented by web browsers that helps to protect against attacks such as cross-site scripting (XSS) and data injection. It does this by limiting the sources from which certain types of content can be loaded on a webpage.

When using blazor components with CSP enabled in strict mode, some browser features may be disabled by default. This is because these features may potentially be exploited by attackers. In order to use Syncfusion blazor components with CSP in strict mode, certain directives must be included in the CSP meta tag. These directives allow for the use of certain features that are necessary for Syncfusion blazor components to function properly.

## Enabling CSP with Syncfusion Blazor Components

To use Syncfusion blazor components with CSP in strict mode, the following directives must be included in the CSP meta tag:

* `font-src data:` - This directive allows for the use of `base64` encoded font icons.
* `style-src 'self' unsafe-inline` - This directive allows for the use of inline styles and external fonts.
* `connect-src 'self' https: wss:` - This directive enables web sockets.
* `script-src 'self' unsafe-eval` - This directive allows for the use of the `new()` and `eval()` functions.

It is important to note that the `unsafe-eval` directive is required for the Blazor WebAssembly Mono runtime and is also mandatory for any project using Syncfusion templates. If your application does not include any Syncfusion templates, the `unsafe-eval` directive can be removed from the CSP meta tag for server-side applications.

The resulting meta tag should be included in the <head> tag of your webpage, and should be registered in the `wwwroot/index.html` file in a client web app, and in the `~/Pages/_Host.cshtml` file in a server application.

```html
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
```

## See also

* [Content Security Policy for ASP.NET Core Blazor](https://learn.microsoft.com/en-us/aspnet/core/blazor/security/content-security-policy?view=aspnetcore-7.0)