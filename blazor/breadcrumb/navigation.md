---
layout: post
title: Navigation with Blazor Breadcrumb component | Syncfusion
description: Checkout and learn about Navigation with Blazor Breadcrumb component of Syncfusion, and more details.
platform: Blazor
control: Breadcrumb
documentation: ug
---

# Navigation in Blazor Breadcrumb Component

Breadcrumb navigations support you to provide relative or absolute URL for breadcrumb items, enable navigation for the last item of the Breadcrumb component, and open URL in a new tab or new page.

## URL

In the Breadcrumb component, the item represents the URL. The breadcrumb items can be provided with either relative or absolute URL.

### Relative URL

The [Url](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.BreadcrumbItem.html#Syncfusion_Blazor_Navigations_BreadcrumbItem_Url) property of the items contains a portion of the full path which is based on its relation to the current path where it is linked. In the following example, the items represent only the relative URL path.

```cshtml
@using Syncfusion.Blazor.Navigations

<SfBreadcrumb EnableNavigation="false">
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

![Blazor Breadcrumb Component](./images/blazor-Breadcrumb-relative-url.png)

### Absolute URL

The [Url](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.BreadcrumbItem.html#Syncfusion_Blazor_Navigations_BreadcrumbItem_Url) property of the items contains the full path or entire address of the page. In the following example, the items represent absolute URL.

```cshtml
@using Syncfusion.Blazor.Navigations

<SfBreadcrumb EnableNavigation="false">
    <BreadcrumbItems>
        <BreadcrumbItem Text="Home" Url="https://blazor.syncfusion.com/documentation/breadcrumb/introduction"></BreadcrumbItem>
        <BreadcrumbItem Text="Getting" Url="https://blazor.syncfusion.com/documentation/breadcrumb/getting-started"></BreadcrumbItem>
        <BreadcrumbItem Text="Icons" Url="https://blazor.syncfusion.com/documentation/breadcrumb/icons"></BreadcrumbItem>
        <BreadcrumbItem Text="Navigation" Url="https://blazor.syncfusion.com/documentation/breadcrumb/navigation"></BreadcrumbItem>
        <BreadcrumbItem Text="Overflow" Url="https://blazor.syncfusion.com/documentation/breadcrumb/overflow"></BreadcrumbItem>
    </BreadcrumbItems>
</SfBreadcrumb>
```

![Blazor Breadcrumb Component](./images/blazor-Breadcrumb-absolute-url.png)

## Enable navigation for last Breadcrumb item

Breadcrumb enables the navigation for the last item by setting the [EnableActiveItemNavigation](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfBreadcrumb.html#Syncfusion_Blazor_Navigations_SfBreadcrumb_EnableActiveItemNavigation) property to true. In the following example, the last item of the `Breadcrumb` is  enabled.

```cshtml
@using Syncfusion.Blazor.Navigations

<SfBreadcrumb EnableNavigation="false" EnableActiveItemNavigation="true">
    <BreadcrumbItems>
        <BreadcrumbItem Text="Home" Url="https://blazor.syncfusion.com/documentation/breadcrumb/introduction"></BreadcrumbItem>
        <BreadcrumbItem Text="Getting" Url="https://blazor.syncfusion.com/documentation/breadcrumb/getting-started"></BreadcrumbItem>
        <BreadcrumbItem Text="Icons" Url="https://blazor.syncfusion.com/documentation/breadcrumb/icons"></BreadcrumbItem>
        <BreadcrumbItem Text="Navigation" Url="https://blazor.syncfusion.com/documentation/breadcrumb/navigation"></BreadcrumbItem>
        <BreadcrumbItem Text="Overflow" Url="https://blazor.syncfusion.com/documentation/breadcrumb/overflow"></BreadcrumbItem>
    </BreadcrumbItems>
</SfBreadcrumb>
```

![Blazor Breadcrumb Component](./images/blazor-Breadcrumb-enable-navigation.png)
