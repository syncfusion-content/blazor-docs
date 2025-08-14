---
layout: post
title: How to use strict CSP in Blazor SfPdfViewer | Syncfusion
description: Learn here all about how to use the Content Security Policy in Syncfusion Blazor SfPdfViewer component.
platform: Blazor
control: SfPdfViewer
documentation: ug
---

# How to use strict CSP in Blazor SfPdfViewer Component

Content Security Policy (CSP) is a security feature implemented by web browsers that helps to protect against attacks such as cross-site scripting (XSS) and data injection. It limits the sources from which content can be loaded on a web page.

To enable strict [Content Security Policy (CSP)](https://csp.withgoogle.com/docs/strict-csp.html), certain browser features are disabled by default. In order to use Syncfusion PDF Viewer control with strict CSP mode, it is essential to include following directives in the CSP meta tag.

* Syncfusion PDF Viewer control are rendered with calculated **inline styles** and **base64** font icons, which are blocked on a strict CSP-enabled site. To allow them, add the [`style-src 'self' 'unsafe-inline' blob:;`](https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Security-Policy/style-src) and [`font-src 'self' data:;`](https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Security-Policy/font-src) directives in the meta tag as follows.

* Syncfusion **material** and **tailwind** built-in themes contain a reference to the [`Roboto's external font`](https://fonts.googleapis.com/css?family=Roboto:400,500), which is also blocked. To allow them, add the [`external font`](https://fonts.googleapis.com/css?family=Roboto:400,500) reference to the [`style-src`](https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Security-Policy/style-src) and [`font-src`](https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Security-Policy/font-src) directives in the above meta tag.

* Syncfusion PDF Viewer control uses **web workers** and makes network connections, which are blocked on a strict CSP-enabled site. To allow them, add the [`worker-src 'self' blob:;`](https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Security-Policy/worker-src) and [`connect-src 'self' https://cdn.syncfusion.com data:;`](https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Security-Policy/connect-src) directives in the above meta tag.

* For JavaScript execution and WebAssembly operations, the [`script-src 'self' 'unsafe-inline' 'unsafe-eval' https://cdn.syncfusion.com blob:;`](https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Security-Policy/script-src) directive is required to allow inline scripts, eval operations, and blob-based scripts.

The resultant meta tag is included within the `<head>` tag and resolves the CSP violation on the application's side when utilizing Syncfusion PDF Viewer control with material and tailwind themes.

{% tabs %}
{% highlight razor tabtitle="HTML" %}
<head>
    <meta http-equiv="Content-Security-Policy" content="default-src 'self';
    frame-src 'self' blob:;
    script-src 'self' 'unsafe-inline' 'unsafe-eval' https://cdn.syncfusion.com blob:;
    style-src 'self' 'unsafe-inline' blob: https://cdn.syncfusion.com https://fonts.googleapis.com;
    img-src 'self' blob: data:;
    worker-src 'self' blob:;
    connect-src 'self' https://cdn.syncfusion.com data:;
    font-src 'self' data: https://fonts.googleapis.com/ https://fonts.gstatic.com/;" />
</head>
{% endhighlight %}
{% endtabs %}

N> In accordance with the latest security practices, the Syncfusion PDF Viewer control requires `'unsafe-eval'` in the script-src directive for proper JavaScript execution and WebAssembly operations. The `worker-src` directive is also essential for web worker functionality used by the PDF Viewer. Make sure to update your CSP meta tags to include these directives for optimal functionality and security compliance.

### Please find the usage of each directives:

| Directive                          | Usage                                                                                                                                                                                                                  |
|------------------------------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| `default-src 'self';`              | Sets the default policy for loading resources. `'self'` means only allow resources from the same origin (same domain).                                                                                                 |
| `script-src 'self' 'unsafe-inline' 'unsafe-eval' https://cdn.syncfusion.com blob:;` | Defines where JavaScript code can come from. `'self'` allows scripts from the same origin. `'unsafe-inline'` allows inline scripts. `'unsafe-eval'` allows eval() operations needed for WebAssembly. `blob:` allows loading scripts from Blob URLs. |
| `worker-src 'self' blob:;`         | Controls where workers can be loaded from. `'self'` allows same-origin workers. `blob:` allows blob-based workers, common in PDF viewers and heavy JS applications.                                                     |
| `connect-src 'self' https://cdn.syncfusion.com data:;` | Controls where the application can make network requests, such as `fetch()`, XHR, and WebSockets. `'self'` restricts to the same origin, with additional allowances for Syncfusion CDN and data URLs. |
| `style-src 'self' 'unsafe-inline' blob: https://cdn.syncfusion.com https://fonts.googleapis.com;` | Defines the sources for stylesheets. `'self'` restricts to the same origin. `'unsafe-inline'` allows inline styles. `blob:` allows dynamically generated styles. External font CDNs are also allowed. |
| `font-src 'self' data: https://fonts.googleapis.com/ https://fonts.gstatic.com/;` | Controls where fonts can be loaded from. `'self'` allows local fonts. `data:` allows inline fonts (base64 embedded), and the URLs allow loading from external font CDNs. |
| `img-src 'self' blob: data:;`      | Controls where images can be loaded from. `'self'` restricts to the same origin. `blob:` allows blob-based images. `data:` allows inline images (base64).                                                            |
| `frame-src 'self' blob:;`          | Controls where frames can be loaded from. `'self'` allows same-origin frames. `blob:` allows blob-based frames, which may be used by the PDF Viewer for certain operations.                                          |

[View sample in GitHub](https://github.com/SyncfusionExamples/blazor-pdf-viewer-examples/tree/master/Common/Pdfviewer%20Sample%20With%20CSP).