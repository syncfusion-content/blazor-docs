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

### Recommended CSP Directives for Syncfusion Blazor Components 

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
> **Note:**  The wasm-unsafe-eval source expression is mandatory for Blazor WebAssembly and Blazor Web App applications, as it enables the browser to compile and execute WebAssembly modules required by the Blazor Mono runtime on the client. Without this directive, modern browsers will block WebAssembly execution, preventing the Blazor runtime from initializing correctly.

## Constraints and Considerations : 

If your application includes Syncfusion components that are not explicitly marked as Strict CSP implemented, you must include the style-src 'unsafe-inline' directive in your Content Security Policy.

Refer to the list of supported components to verify Strict CSP compatibility. We have also outlined the features that currently require additional CSP directives.

| Category                        | Fully Strict CSP Compliant                  | Partial CSP Compliance                          |                                 |
|---------------------------------|---------------------------------------------|-------------------------------------------------|---------------------------------|
|                                 |                                             | **HTML Attributes Support**                     | **Other Functionalities**       |
| **DATA MANAGEMENT**             | DataGrid, Pager                             |                                                 | Pivot Table, Tree Grid, Query Builder, ListView |
| **DATA VISUALIZATION**          | QRCodeGenerator, TreeMap                    |                                                 | Charts, 3D Chart, Stock Chart, Circular Gauge, Linear Gauge, HeatMap Chart, Range Selector, Bullet Chart, Sparkline Charts, Sankey, Smith Chart, Barcode Generator |
| **SCHEDULING & CALENDARS**      | Gantt Chart, Calendar                       | DatePicker, DateRangePicker, DateTime Picker, TimePicker | Scheduler                       |
| **DROPDOWNS**                   | Dropdown Tree                               |                                                 | Dropdown List, MultiSelect Dropdown, ListBox, ComboBox, AutoComplete, Mention, MultiColumn ComboBox |
| **FILE VIEWERS & EDITORS**      |                                             | File Manager (SanitizeHtmlAttributes issue)     | Rich Text Editor, Image Editor, Markdown Editor, In-place Editor, File Upload |
| **LAYOUT**                      | Dashboard Layout, Splitter, Stepper, Tabs, Accordion |                                         | Dialog, Tooltip, Card, Media Query, Timeline, Avatar, Predefined Dialogs |
| **INPUTS**                      | Radio Button, CheckBox, Toggle Switch Button, Floating Action Button, Speed Dial, Progress Button | TextBox, TextArea, Numeric TextBox, Input Mask, DatePicker, DateRangePicker, DateTime Picker, TimePicker | Range Slider, OTP Input, Color Picker, Signature, Rating, Chips |
| **DIAGRAMS AND MAPS**           |                                             |                                                 | Diagram, Maps                   |
| **BUTTONS & ACTIONS**           | Button, Split Button, Dropdown Menu         |                                                 | Button Group, Color Palette     |
| **NOTIFICATIONS**               | Toast, Message, Skeleton                    |                                                 | Progress Bar, Badge, Spinner    |
| **NAVIGATION**                  | Ribbon                                      | TreeView            | Tabs, Sidebar, Toolbar, Context Menu, AppBar, Breadcrumb, Carousel, Stepper, File Manager |
| **FORMS**                       |                                             |                                                 | Data Form                       |
| **KANBAN**                      |                                             |                                                 | Kanban                          |
| **INTERACTIVE CHAT**            | AIAssistView, Speech To Text                |         |                                 |
| **SMART COMPONENTS**            | Smart Paste Button, Smart TextArea (preview)  |                                          |  |


Certain components are not currently fully compliant with Strict CSP requirements. Applications using the components listed below must include the style-src 'unsafe-inline' directive as part of their CSP configuration.

>**Important:** CSP compliance remains a key security priority. We are actively working toward achieving complete Strict CSP compatibility for all components, and updates will be provided incrementally through upcoming security patch releases.

| Category                          | Components                                                                 | Primary Blocker / Reason                                                                                          |
|-----------------------------------|----------------------------------------------------------------------------|-------------------------------------------------------------------------------------------------------------------|
| **Charts & Advanced Visualizations** | Charts, 3D Charts, Stock Chart, BulletChart, Range Selector, Sankey,Sparkline Charts, Smith Chart | Internal `<style>` tags are used to dynamically apply theme-specific styles, keyboard accessibility enhancements, and series rendering behaviors. Broad refactoring required across the charting engine. |
| **Block Editor**                  | Block Editor                                                               | Pending integration of CSP-related changes from the core team.                                                    |
| **Interactive Chat**              | Chat UI                                                                    | Currently relies on the Virtualize Blazor component, which introduces CSP conflicts. Migration to a custom virtualization implementation is required. |
| **Navigation & Layout**           | Avatar, MediaQuery                                                         | Not assessed or not applicable in the current strict CSP verification scope.                                      |
| **Unverified / Pending Assessment** | DataManager, ProgressBar, , Pivot Table, AutoComplete, Badge, ButtonGroup, Color Picker, ComboBox, Data Form, Dialog, Dropdown List, File Upload, ImageEditor, In-place Editor, ListBox, Mention, MultiColumn ComboBox, MultiSelect Dropdown, OtpInput, Query Builder, Range Slider, Rating, Signature, Spinner, Kanban, Rich Text Editor, Diagram, AppBar, Breadcrumb, Card, Carousel, Context Menu, Menu Bar, Scheduler, Sidebar, Toolbar, ListView, Tree Grid | No CSP verification status or comments recorded in the current assessment cycle.
