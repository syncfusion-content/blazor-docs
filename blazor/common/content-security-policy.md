---
layout: post
title: Content Security Policy (CSP) - Syncfusion
description: Learn here about that how to resolve the content security policy issue in the Syncfusion Blazor Components.
platform: Blazor
component: Common
documentation: ug
---

# Content Security Policy

When using blazor components with a strict [Content-Security-Policy (CSP)](https://learn.microsoft.com/en-us/aspnet/core/blazor/security/content-security-policy?view=aspnetcore-7.0) mode enabled, some browser features are disabled. Since we’re using the following browser features, they are disabled by default.

* Syncfusion component uses `base64` as a font icon and it is not allowed in strict CSP enabled site. so that, `font-src data:` meta tag is required while using the syncfusion components.

* For the built in themes and styles, we have use the `inline styles` and `Roboto’s external font` in our components, both of which are probhibited in strict CSP. To enable them `style-src ‘self’ unsafe-inline` must be included in the meta tag.

* To enable `web sockets` to the content security policy you need to add the web socket protocol `wss:` to the `connect-src` directive.

* The `new()` and the `eval()` are blocked, which evaluates the Dynamic code evaluation while only the template is applied to the Syncfusion components. You must utilize the `script-src ‘self’ unsafe-eval` in the meta tag for enabling.

    N> The Blazor WebAssembly Mono runtime requires `unsafe-eval` directive in order to function. It is also mandatory for every project using the Syncfusion template. If your application doesn't include any syncfusion template related projects, you can remove the `unsafe-eval` directive from our `blazor server side application`. 

* The following resultant meta tag is required to overcome the CSP violation. When using syncfusion components, we should refer this directive inside the `<head>` tag.  Register this directive in **wwwroot/index.html** file in client web app and **~/Pages/_Host.cshtml** file in server application.

    ```
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