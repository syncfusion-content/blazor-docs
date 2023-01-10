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

When using Syncfusion blazor components with strict Content Security Policy (CSP), some browser features are disabled by default. This is because these features may potentially be exploited by attackers. In order to use Syncfusion blazor components with strict CSP mode, certain directives must be included in the CSP meta tag. These directives allow to use certain features that are necessary for Syncfusion blazor components to function properly.

To use Syncfusion blazor components with strict CSP mode, the following directives must be included in the CSP meta tag:

* `font-src data:` - This directive allows for the use of `base64` encoded font icons.
* `style-src 'self' unsafe-inline` - This directive allows for the use of inline styles and external fonts.
* `connect-src 'self' https: wss:` - This directive enables web sockets.
* `script-src 'self' unsafe-eval` - This directive allows for the use of the `new()` and `eval()` functions.

To enable the Blazor WebAssembly Mono runtime,`unsafe-eval` directive is mandatory for the Blazor WebAssembly project.

In our syncfusion component, setTimeout() function is used for animations functionality. so that, `unsafe-eval` is necessary for those components.

The resulting meta tag should be included in the <head> tag of your webpage, and should be registered in the `wwwroot/index.html` file in a Blazor WebAssembly application, and in the `~/Pages/_Host.cshtml` file in a Blazor Server application.

        N> If your application does not include any animation related syncfusion component, the `unsafe-eval` directive is not needed for CSP meta tag.

```html
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
```

## See also

* [Content Security Policy for ASP.NET Core Blazor](https://learn.microsoft.com/en-us/aspnet/core/blazor/security/content-security-policy?view=aspnetcore-7.0)
