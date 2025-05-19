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
* `style-src 'self' unsafe-inline` - This directive permits the use of inline styles, allowing components to apply parameters such as Width, Height, positioning, etc. Additionally, certain [components](#components-utilizing-inline-style-for-functionality) depend on inline styling to render interactive behaviors and complex layouts effectively.
* `connect-src 'self' https: wss:` - This directive enables web sockets.
* `script-src 'self' unsafe-eval` - This directive allows for the use of the `new()` and `eval()` functions. Used in animation enabled Syncfusion<sup style="font-size:70%">&reg;</sup> components.

These directives should be included in the `<head>` tag of the application's webpage, typically

* For **Blazor Web App**, inside the `<head>` of **~/Components/App.razor** file.
* For **Blazor Server application**, inside the `<head>` of
    * **~/Pages/_Host.cshtml** file for .NET 7.
    * **~/Pages/_Layout.cshtml** for .NET 6.
* For **Blazor WebAssembly App**, inside the `<head>` of **wwwroot/index.html** file.

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

## Components Utilizing Inline Style for Functionality

Some Syncfusion components use inline styles to achieve responsive layouts, precise positioning, dynamic sizing, and visual behaviors essential to their functionality. The table below lists components that depend on inline styles, along with the properties or features that require them.

| Component                | Properties/Functionalities Requiring Inline Styles                                                                 |
|--------------------------|---------------------------------------------------------------------------------------------------------------------|
| 3D Charts, TreeMap, Charts, ProgressBar, Circular Gauge, HeatMap Chart, LinaerGauge, Maps, Bullet Chart, ImageEditor, RangeSlider, Sankey, SmithChart, SparklineChart, Stock Chart                | Appearance customization, layout, and rendering.|
| Accordion, Tabs, Toolbar, Kanban, Carousel, Toast, Skeleton, Splitter                 | Height and Width.|
| DatePicker, DateTime Picker, DateRange Picker, In-place Editor, Input Mask, ListBox, MultiSelect Dropdown, Numeric TextBox, Query Builder, TextArea, TextBox, TimePicker                 | Width|
| Dashboard Layout         | Panel height, gridline styles.|
| Sidebar                  | Width and transform in normal and docker mode.|
| Stepper                  | Width and transform.|
| Dialog                   | Z-index, height, and width.|
| AutoComplete             | Width, PopupHeight, and PopupWidth.|
| Pivot Table              | Grouping bar layout, conditional formatting dialog, height and width of pivot chart and pager, cell positioning.|
| Rich Text Editor         | Height, width, font styling, toolbar styling.|
| Gantt Chart              | Taskbar Dimensions, Chart Row Layout, Timeline and Header Layout, Label Containers and Connectors, Progress Bars and Segments, Baseline and Connector Styling, Virtualization Elements.|
| Context Menu, Menu Bar             | Menu popup visibility.|
| Scheduler                | Agenda view, resource headers, appointment styling, tooltip—positioning and colors.|
| Dropdown List            | Width, PopupHeight, PopupWidth|
| Mention                  | PopupHeight and popup visibility.|
| MultiColumn ComboBox     | Width, PopupHeight, PopupWidth, Z-Index|
| Progress Button          | Spinner theme CSS|
| Rating                   | Rating fill value.|
| Spinner                  | Z-index and styling from spinner CSS theme|
| ColorPicker              | Color|
| ComboBox                 | Width, PopupHeight, and PopupWidth.|
| DataForm                 | Width, ColumnSpacing.|
| SpeedDial                | Speed dial animation and layout styles|
| Ribbon                   | filemenu and helpTemplate width for ribbon tab. |


## See also

* [Content Security Policy for ASP.NET Core Blazor](https://learn.microsoft.com/en-us/aspnet/core/blazor/security/content-security-policy?view=aspnetcore-7.0)