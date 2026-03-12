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

Syncfusion Blazor components now offer improved support for strict **Content Security Policy (CSP)** implementations, strengthening application security against threats like cross-site scripting (XSS) and data injection attacks.

Now we have introduced **strict CSP compatibility** for **over 80 components**. Default functionalities across these components now operate seamlessly under a strict CSP configuration without requiring unsafe directives such as `'unsafe-eval'` or `'unsafe-inline'` in many scenarios. 

This enhancement allows developers to enforce modern, secure browser policies more easily while retaining full component capabilities in Blazor Server, WebAssembly, and hybrid (Auto) render modes.

### Recommended CSP Directives for Strict Csp implemented Syncfusion Blazor Components 

The following CSP configurations are **tested and recommended** for Syncfusion Blazor components that support strict CSP (Refer Supported list below).

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

If your application includes Syncfusion components that are not explicitly marked as Strict CSP implemented, you must include the **style-src 'unsafe-inline' directive** in your Content Security Policy.

Refer to the list of supported components to verify Strict CSP compatibility. We have also outlined the features that currently require additional CSP directives.

### Component Categories Overview

Below is an updated overview highlighting CSP compliance status based on the latest verification:

>**Important:** HTMLAttribute/InputAttributes Parameter Limitations Under Strict CSP
When using a strict Content Security Policy (CSP), support for inline style attributes is not currently available. Support for inline style attributes will be added in a future weekly patch release.
Please refer to upcoming Syncfusion release notes for updates.



### Data Management

| Fully Strict CSP Compliant | HTML Attributes (Inline Styles Not Supported) | Feature Limitation |
|----------------------------|------------------------|--------------------------|
| DataGrid, Pager, Tree Grid, Query Builder | — | Pivot Table |

---


### Scheduling & Calendars

| Fully Strict CSP Compliant | HTML Attributes (Inline Styles Not Supported) | Feature Limitation |
|----------------------------|------------------------|--------------------------|
| Scheduler, Calendar, Gantt Chart | DatePicker, DateRangePicker, DateTime Picker, TimePicker | — |

---


### File Viewers & Editors & File management

| Fully Strict CSP Compliant | HTML Attributes (Inline Styles Not Supported) | Feature Limitation |
|----------------------------|------------------------|--------------------------|
| File Upload | Imageditor | |

---


### Layout Components

| Fully Strict CSP Compliant | HTML Attributes (Inline Styles Not Supported) | Feature Limitation |
|----------------------------|------------------------|--------------------------|
| Dashboard Layout, Splitter, Card, Timeline | Dialog, Tooltip |  |

---

### Notifications and DataForm

| Fully Strict CSP Compliant | HTML Attributes (Inline Styles Not Supported) | Feature Limitation |
|----------------------------|------------------------|--------------------------|
|Toast, Spinner, Message, Skeleton, ProgressBar, DataForm |  | — |

---

### Data Visualization, Diagram and Maps

| Fully Strict CSP Compliant |HTML Attributes (Inline Styles Not Supported) | Feature Limitation |
|----------------------------|------------------------|--------------------------|
| BarcodeGenerator, Linear Gauge, TreeMap |  — | Circular Gauge, Maps |

---

### Buttons and Actions

| Fully Strict CSP Compliant | HTML Attributes (Inline Styles Not Supported) | Feature Limitation |
|----------------------------|------------------------|--------------------------|
|SplitButton, Toggle Switch Button, Button Group, Button, Progress Button, Floating Action Button, Speed Dial  | DropDown Menu, Chips  | - |

---


### Dropdowns

| Fully Strict CSP Compliant | HTML Attributes (Inline Styles Not Supported) | Feature Limitation |
|----------------------------|------------------------|--------------------------|
|Dropdown Tree, Mention, ListBox | MultiColumn Combobox, Dropdown List, AutoComplete, ComboBox, Multiselect Dropdown | — |
   
---


### Inputs

| Fully Strict CSP Compliant | HTML Attributes (Inline Styles Not Supported) | Feature Limitation|
|----------------------------|------------------------|--------------------------|
| RangeSlider, Radio Button, Checkbox, Speech to text | In-Place Editor, TextBox, TextArea, Numeric TextBox, OtpInput, Inputmask, Color picker, Color palatte | -  |

---


### Navigation & Actions

| Fully Strict CSP Compliant | HTML Attributes (Inline Styles Not Supported) | Feature Limitation |
|----------------------------|------------------------|--------------------------|
| |TreeView | |

---



### Smart Components

| Fully Strict CSP Compliant | HTML Attributes (Inline Styles Not Supported) | Feature Limitation |
|----------------------------|------------------------|--------------------------|
| Smart Paste Button, Smart TextArea | -  | - |

---

### INTERACTIVE CHAT

| Fully Strict CSP Compliant | HTML Attributes (Inline Styles Not Supported) | Feature Limitation |
|----------------------------|------------------------|--------------------------|
| AI Assist View| - | - |

---


## Constraints and Considerations : 

Some components are not currently fully compliant with Strict CSP requirements. Applications using the components listed below must include the style-src 'unsafe-inline' directive as part of their CSP configuration.


#### Components Requiring CSP Relaxation

| Category                          | Components                                                                
|-----------------------------------|----------------------------------------------------------------------------|
| **Charts & Advanced Visualizations** | Charts, 3D Charts, Stock Chart, BulletChart, Range Selector, Sankey,Sparkline Charts, Smith Chart, Diagram 
| **Editors and Kanban**                  | Block Editor , RichtextEditor, Kanban                                                                                                                  |
| **Interactive Chat**              | Chat UI                                                                    |



>**Important:** CSP compliance remains a key security priority. We are actively working toward achieving complete Strict CSP compatibility for all components, and updates will be provided incrementally through upcoming security patch releases.

### Best Practices

 - Apply the strictest CSP policy feasible for your application
 - Avoid using 'unsafe-inline' unless explicitly required
 - Track Syncfusion release notes for CSP-related improvements