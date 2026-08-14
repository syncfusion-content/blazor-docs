---
layout: post
title: Navigation in Blazor Breadcrumb | Syncfusion®
description: Enable or disable built-in navigation for Blazor Breadcrumb items via the EnableNavigation property, or wire up custom navigation handlers.
platform: Blazor
control: Breadcrumb
documentation: ug
---

# Navigation in Blazor Breadcrumb

By default, [Blazor Breadcrumb](https://www.syncfusion.com/blazor-components/blazor-breadcrumb) items support navigation for relative or absolute URLs. Set the [EnableNavigation](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfBreadcrumb.html#Syncfusion_Blazor_Navigations_SfBreadcrumb_EnableNavigation) property to `false` to handle navigation yourself (for example, by using the [ItemClick](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfBreadcrumb.html) event with `NavigationManager`).

## Relative URL

Set a relative URL in the [Url](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.BreadcrumbItem.html#Syncfusion_Blazor_Navigations_BreadcrumbItem_Url) property of the [BreadcrumbItem](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.BreadcrumbItem.html). In the following example, the items use relative URLs.

```cshtml
@using Syncfusion.Blazor.Navigations

<SfBreadcrumb>
    <BreadcrumbItems>
        <BreadcrumbItem Text="Home" Url="../"></BreadcrumbItem>
        <BreadcrumbItem Text="Breadcrumb" Url="./breadcrumb/getting-started"></BreadcrumbItem>
        <BreadcrumbItem Text="Default" Url="../"></BreadcrumbItem>
        <BreadcrumbItem Text="Icons" Url="./breadcrumb/icons"></BreadcrumbItem>
        <BreadcrumbItem Text="Navigation" Url="./breadcrumb/navigation"></BreadcrumbItem>
        <BreadcrumbItem Text="Overflow" Url="./breadcrumb/overflow"></BreadcrumbItem>
    </BreadcrumbItems>
</SfBreadcrumb>
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/hjhHXRMMfeIkqkdX?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage="[Blazor Breadcrumb Component](./images/blazor-Breadcrumb-relative-url.webp)" %}

## Absolute URL

Set an absolute URL in the `Url` property of the `BreadcrumbItem`. Use absolute URLs when items should navigate to external sites or to a known absolute path.

```cshtml
@using Syncfusion.Blazor.Navigations

<SfBreadcrumb>
    <BreadcrumbItems>
        <BreadcrumbItem Text="Home" Url="https://blazor.syncfusion.com/documentation/breadcrumb/introduction"></BreadcrumbItem>
        <BreadcrumbItem Text="Getting" Url="https://blazor.syncfusion.com/documentation/breadcrumb/getting-started"></BreadcrumbItem>
        <BreadcrumbItem Text="Icons" Url="https://blazor.syncfusion.com/documentation/breadcrumb/icons"></BreadcrumbItem>
        <BreadcrumbItem Text="Navigation" Url="https://blazor.syncfusion.com/documentation/breadcrumb/navigation"></BreadcrumbItem>
        <BreadcrumbItem Text="Overflow" Url="https://blazor.syncfusion.com/documentation/breadcrumb/overflow"></BreadcrumbItem>
    </BreadcrumbItems>
</SfBreadcrumb>
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/rtrHtdMCfoHqDSRD?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage="[Blazor Breadcrumb Component](./images/blazor-Breadcrumb-absolute-url.webp)" %}

## Enable navigation for the last Breadcrumb item

By default, the last (active) Breadcrumb item is not clickable because it represents the current page. Set the [EnableActiveItemNavigation](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfBreadcrumb.html#Syncfusion_Blazor_Navigations_SfBreadcrumb_EnableActiveItemNavigation) property to `true` to make the last item navigable.

```cshtml
@using Syncfusion.Blazor.Navigations

<SfBreadcrumb EnableActiveItemNavigation="true">
    <BreadcrumbItems>
        <BreadcrumbItem Text="Home" Url="https://blazor.syncfusion.com/documentation/breadcrumb/introduction"></BreadcrumbItem>
        <BreadcrumbItem Text="Getting" Url="https://blazor.syncfusion.com/documentation/breadcrumb/getting-started"></BreadcrumbItem>
        <BreadcrumbItem Text="Icons" Url="https://blazor.syncfusion.com/documentation/breadcrumb/icons"></BreadcrumbItem>
        <BreadcrumbItem Text="Navigation" Url="https://blazor.syncfusion.com/documentation/breadcrumb/navigation"></BreadcrumbItem>
        <BreadcrumbItem Text="Overflow" Url="https://blazor.syncfusion.com/documentation/breadcrumb/overflow"></BreadcrumbItem>
    </BreadcrumbItems>
</SfBreadcrumb>
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/BDhnNdMWpenddqUg?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage="[Blazor Breadcrumb Component](./images/blazor-Breadcrumb-enable-navigation.webp)" %}

## See also

* [Getting started with Blazor Breadcrumb](https://blazor.syncfusion.com/documentation/breadcrumb/getting-started)
* [Breadcrumb Items in Blazor](https://blazor.syncfusion.com/documentation/breadcrumb/breadcrumb-items)
* [Breadcrumb Templates in Blazor](https://blazor.syncfusion.com/documentation/breadcrumb/templates)
* [Accessibility in Blazor Breadcrumb](https://blazor.syncfusion.com/documentation/breadcrumb/accessibility)
