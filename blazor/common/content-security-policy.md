---
layout: post
title: Content Security Policy (CSP) - Syncfusion
description: Learn how to use Syncfusion Blazor components with a strict Content Security Policy (CSP) in Blazor Web App, Blazor WebAssembly (WASM), and Blazor Server.
platform: Blazor
control: Common
documentation: ug
---

# Syncfusion® Blazor components with a strict Content Security Policy

Content Security Policy (CSP) is a browser security feature that helps protect against cross-site scripting (XSS) and data injection by limiting the allowed sources for scripts, styles, images, fonts, and other resources.

CSP directives should be included in the `<head>` tag of the application's webpage, typically

* For **.NET 8, .NET 9 and .NET 10** Blazor Web Apps using any render mode (Server, WebAssembly, or Auto), inside the `<head>` of the **~/Components/App.razor** file.

* For **Blazor WebAssembly Standalone App**, inside the `<head>` of the **wwwroot/index.html** file.

Syncfusion® Blazor components now offer improved support for strict **Content Security Policy (CSP)** implementations, strengthening application security against threats like cross-site scripting (XSS) and data injection attacks.

Now we have introduced **strict CSP compatibility** for **over 80 components**. Default functionalities across these components now operate seamlessly under a strict CSP configuration without requiring unsafe directives such as `'unsafe-eval'` or `'unsafe-inline'` in many scenarios. 

This enhancement allows developers to enforce modern, secure browser policies more easily while retaining full component capabilities in Blazor Server, WebAssembly, and hybrid (Auto) render modes.

### Recommended CSP Directives for Strict CSP implemented Syncfusion® Blazor Components 

The following CSP configurations are **tested and recommended** for Syncfusion® Blazor components that support strict CSP (Refer Supported list below).

#### For Blazor Interactive Server App


```html
<meta http-equiv="Content-Security-Policy"
      content="base-uri 'self';
               default-src 'self';
               connect-src 'self' https: ws: wss:;
               img-src 'self' data: https:;
               object-src 'none';
               script-src 'self';
               style-src 'self';    
               font-src 'self' data:;
               upgrade-insecure-requests;">

```

#### For Blazor Interactive WebAssembly App and Wasm Standalone App


```html
<meta http-equiv="Content-Security-Policy"
      content="base-uri 'self';
               default-src 'self';
               connect-src 'self' https: ws: wss:;
               img-src 'self' data: https:;
               object-src 'none';
               script-src 'self' 'wasm-unsafe-eval';
               style-src 'self';    
               font-src 'self' data:;
               upgrade-insecure-requests;">

```
> **Note:**  The [wasm-unsafe-eval](https://developer.mozilla.org/en-US/docs/Web/HTTP/Reference/Headers/Content-Security-Policy/script-src#unsafe_webassembly_execution) source expression is mandatory for Blazor WebAssembly and Blazor Web App applications, as it enables the browser to compile and execute WebAssembly modules required by the Blazor Mono runtime on the client. Without this directive, modern browsers will block WebAssembly execution, preventing the Blazor runtime from initializing correctly.


## Constraints and Considerations

While Syncfusion® Blazor components are progressively moving toward full strict CSP compliance, certain scenarios still require the **`style-src 'unsafe-inline'`** directive. You must include this directive in your CSP configuration if your application falls into any of the following scenarios:

**Scenario 1: Components that require CSP relaxation**

Certain components inherently rely on dynamic or inline style injection and cannot function under a strict CSP without `'unsafe-inline'`. Refer to the **Components Requiring CSP Relaxation** 

#### Components Requiring CSP Relaxation

| Category                                | Components                                                                
|-------------------------------------------|---------------------------------------------------------------------------|
| **Data Visualization**    | • Charts<br>• 3D Charts<br>• Stock Chart<br>• Bullet Chart<br>• Range Selector<br>• Sankey<br>• Sparkline Chart<br>• Smith Chart |
| **File Viewers & Editors**                  | • Block Editor<br>• Rich Text Editor |
| **Interactive Chat**              | • Chat UI |
| **File Management**        | • File Manager|
| **Layout**        | • Card |
| **Diagrams and Maps**        | • Diagram |
| **Kanban**        | • Kanban |




**Scenario 2: Components with feature limitations**

Some components are largely strict CSP-compliant, but specific features within them require inline styles. If your application uses any component listed in the **Feature-Limited Components** table below, the `'unsafe-inline'` directive is required.

#### Feature-Limited Components

| Category | Components |
|----------|------------|
| Data Management | • [Pivot Table](../pivot-table/content-security-policy) |
| Scheduling & Calendars | • [Gantt Chart](../gantt-chart/content-security-policy) |
| Data Visualization | • [Circular Gauge](../circular-gauge/content-security-policy)<br>• [Heatmap Chart](../heatmap-chart/content-security-policy) |
| Navigations| • [TreeView](../treeview/content-security-policy) |
| Diagrams and Maps | •  [Maps](../maps/content-security-policy) |

**Scenario 3: Inline styles passed via `InputAttributes` or `HtmlAttributes`**

If you pass a `style` key with an inline style value through the `InputAttributes` or `HtmlAttributes` parameter dictionary, the browser will block those styles under a strict CSP.

```cshtml
@* Example that requires 'unsafe-inline' *@
<SfTextBox InputAttributes='@(new Dictionary<string, object> { { "style", "width:200px;" } })' />
```

> **Recommendation:** Avoid passing inline styles through `InputAttributes` or `HtmlAttributes`. Use the component's built-in properties (such as `Width` and `Height`) for dimensions, or apply custom styling by overriding the relevant CSS classes in your application's stylesheet. This keeps your CSP as strict as possible.

If your application falls under any of the above scenarios, apply the following CSP configuration:

```html
<meta http-equiv="Content-Security-Policy"
      content="base-uri 'self';
               default-src 'self';
               connect-src 'self' https: ws: wss:;
               img-src 'self' data: https:;
               object-src 'none';
               script-src 'self';
               style-src 'self' 'unsafe-inline';
               font-src 'self' data:;
               upgrade-insecure-requests;">
```

> **Note:** The [wasm-unsafe-eval](https://developer.mozilla.org/en-US/docs/Web/HTTP/Reference/Headers/Content-Security-Policy/script-src#unsafe_webassembly_execution) source expression is mandatory for Blazor WebAssembly and Blazor Web App applications. It enables the browser to compile and execute WebAssembly modules required by the Blazor Mono runtime. Without this directive, modern browsers will block WebAssembly execution, preventing the Blazor runtime from initializing correctly.
