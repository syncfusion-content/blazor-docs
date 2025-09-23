---
layout: post
title: Navigation in Blazor Breadcrumb component | Syncfusion
description: Checkout and learn here all about Navigation with Blazor Breadcrumb component of Syncfusion and more.
platform: Blazor
control: Breadcrumb
documentation: ug
---

# Navigation in Blazor Breadcrumb Component

By default, [Blazor Breadcrumb](https://www.syncfusion.com/blazor-components/blazor-breadcrumb) items support navigation using both relative and absolute URLs. You can also implement custom navigation logic by setting the [EnableNavigation](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfBreadcrumb.html#Syncfusion_Blazor_Navigations_SfBreadcrumb_EnableNavigation) property to `false`.

## Relative URL

Relative URLs can be specified using the [Url](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.BreadcrumbItem.html#Syncfusion_Blazor_Navigations_BreadcrumbItem_Url) property of a [BreadcrumbItem](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.BreadcrumbItem.html). This allows navigation within the same application or website structure. 

The following example demonstrates Breadcrumb items configured with relative URLs:

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
{% previewsample "https://blazorplayground.syncfusion.com/embed/LXrUCBsJJKhvVXTj?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor Breadcrumb with Relative URLs](./images/blazor-Breadcrumb-relative-url.png)

## Absolute URLs

Absolute URLs can be specified using the [Url](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.BreadcrumbItem.html#Syncfusion_Blazor_Navigations_BreadcrumbItem_Url) property of a [BreadcrumbItem](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.BreadcrumbItem.html). This enables navigation to external websites or specific, full paths within an application.

The following example demonstrates Breadcrumb items configured with absolute URLs:

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
{% previewsample "https://blazorplayground.syncfusion.com/embed/VXhKsrifpggirdDv?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor Breadcrumb with Absolute URLs](./images/blazor-Breadcrumb-absolute-url.png)

## Enable Navigation for the Last Breadcrumb Item

By default, the last item in a breadcrumb trail represents the current page and is generally not navigable. However, you can enable navigation for the last Breadcrumb item by setting the[EnableActiveItemNavigation](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfBreadcrumb.html#Syncfusion_Blazor_Navigations_SfBreadcrumb_EnableActiveItemNavigation) property to `true`. This can be useful in specific scenarios where the "current page" link should also be clickable.

The following example demonstrates enabling navigation for the last Breadcrumb item:

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
{% previewsample "https://blazorplayground.syncfusion.com/embed/VtrKWhMpfqgKOtmL?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor Breadcrumb with Last Item Navigation Enabled](./images/blazor-Breadcrumb-enable-navigation.png)