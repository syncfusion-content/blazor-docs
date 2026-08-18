---
layout: post
title: Style and Appearance in Blazor Breadcrumb | Syncfusion®
description: Customize the Blazor Breadcrumb appearance by overriding its default CSS classes or by building a custom theme with the Syncfusion Theme Studio.
platform: Blazor
control: Breadcrumb
documentation: ug
---

# Style and Appearance in Blazor Breadcrumb

To modify the Breadcrumb appearance, override the default CSS classes of the component. The table below lists the available CSS classes and the section of the Breadcrumb each one targets. You can also create a custom theme for the component using the [Theme Studio](https://blazor.syncfusion.com/themestudio/).

## CSS classes

| CSS Class | Targets | Purpose |
| --- | --- | --- |
| `.e-breadcrumb` | Root container | Customizes the background of the entire Breadcrumb. |
| `.e-breadcrumb .e-breadcrumb-item` | Each item | Customizes the background of a Breadcrumb item. |
| `.e-breadcrumb .e-breadcrumb-text` | Item label | Customizes the color of a Breadcrumb item's text. |
| `.e-breadcrumb .e-breadcrumb-link` | Item anchor | Customizes the color and text decoration of a Breadcrumb item's link. |
| `.e-breadcrumb .e-breadcrumb-icon` | Item icon | Customizes the color of a Breadcrumb item's icon. |
| `.e-breadcrumb .e-breadcrumb-separator` | Item separator | Customizes the color and style of the Breadcrumb separator. |
| `.e-breadcrumb .e-breadcrumb-item.e-disabled` | Disabled item | Customizes the appearance of a disabled Breadcrumb item. |

N> To scope a custom style to a single Breadcrumb instance, apply a custom class (for example, `CssClass="e-custom"`) to the component and prefix each selector with that class: `.e-custom.e-breadcrumb .e-breadcrumb-text { ... }`.

## Customizing the appearance

Use the following CSS to customize the background, text color, icon color, and separator color of the Breadcrumb. Place the `<style>` block in the same `.razor` file (or in a global stylesheet under `wwwroot/css/`) so the styles are applied when the component renders.

```cshtml
@using Syncfusion.Blazor.Navigations

<SfBreadcrumb class="e-custom">
    <BreadcrumbItems>
        <BreadcrumbItem IconCss="e-icons e-home"></BreadcrumbItem>
        <BreadcrumbItem IconCss="e-icons e-folder-open" Text="Open" Url="https://blazor.syncfusion.com/demos/datagrid/overview"></BreadcrumbItem>
        <BreadcrumbItem IconCss="e-icons e-file-new" Text="New"></BreadcrumbItem>
    </BreadcrumbItems>
</SfBreadcrumb>

<style>
    .e-custom.e-breadcrumb .e-breadcrumb-item {
        background: antiquewhite;
    }
    .e-custom.e-breadcrumb .e-breadcrumb-text {
        color: lime !important;
    }
    .e-custom.e-breadcrumb .e-breadcrumb-icon {
        color: indianred !important;
    }
    .e-custom.e-breadcrumb .e-breadcrumb-separator {
        color: blue;
    }
    .e-custom.e-breadcrumb {
        background-color: azure;
    }
</style>
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/BDBdDniWTeEdrtCZ?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage="[Blazor Breadcrumb with Style and Appearance](./images/blazor-breadcrumb-style-and-appearance.webp)" %}

## See also

* [Getting started with Blazor Breadcrumb](https://blazor.syncfusion.com/documentation/breadcrumb/getting-started)
* [Breadcrumb Items in Blazor](https://blazor.syncfusion.com/documentation/breadcrumb/breadcrumb-items)
* [Breadcrumb Templates in Blazor](https://blazor.syncfusion.com/documentation/breadcrumb/templates)
* [Accessibility in Blazor Breadcrumb](https://blazor.syncfusion.com/documentation/breadcrumb/accessibility)