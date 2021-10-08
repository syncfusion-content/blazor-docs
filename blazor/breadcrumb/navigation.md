---
layout: post
title: Navigation with Blazor Breadcrumb Component | Syncfusion
description: Checkout and learn about Navigation with Blazor Breadcrumb component of Syncfusion, and more details.
platform: Blazor
control: Breadcrumb
documentation: ug
---

# Navigation

The Breadcrumb item navigates to the path while clicking the item. To enable navigation, `Url` property was bound to the items.

## URL

In the Breadcrumb component, the item represents the url. The Breadcrumb items can be provided with either relative or absolute URL.

### Relative URL

The Breadcrumb items with relative URL contain only the path but do not locate the path or server. The following example represents the breadcrumb items with relative url.

```cshtml
@using Syncfusion.Blazor.Navigations

<SfBreadcrumb EnableNavigation="false">
    <BreadcrumbItems>
        <BreadcrumbItem Text="Home" Url="https://blazor.syncfusion.com/demos/breadcrumb/default-functionalities"></BreadcrumbItem>
        <BreadcrumbItem Text="Breadcrumb" Url="https://blazor.syncfusion.com/demos/breadcrumb/bind-to-location"></BreadcrumbItem>
        <BreadcrumbItem Text="Default" Url="https://blazor.syncfusion.com/demos/breadcrumb/template-and-customization"></BreadcrumbItem>
        <BreadcrumbItem Text="Icons" Url="https://blazor.syncfusion.com/demos/breadcrumb/events"></BreadcrumbItem>
        <BreadcrumbItem Text="Navigation" Url="https://blazor.syncfusion.com/demos/breadcrumb/keyboard-navigation"></BreadcrumbItem>
        <BreadcrumbItem Text="Overflow" Url="https://blazor.syncfusion.com/demos/breadcrumb/address-bar"></BreadcrumbItem>
    </BreadcrumbItems>
</SfBreadcrumb>
```

Output be like

![Blazor Breadcrumb Component](./images/blazor-Breadcrumb-relative-url.png)

### Absolute URL

The Breadcrumb items with Static URL contain the path and locate to the resource if the static url is bound to the breadcrumb item. The following example represents the breadcrumb items with static url.

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

Output be like

![Blazor Breadcrumb Component](./images/blazor-Breadcrumb-absolute-url.png)

## Enable navigation for last Breadcrumb item

The feature enables the last item of the Breadcrumb component by setting the `EnableActiveItemNavigation` property to true. In the following example, the last item of the `Breadcrumb` was enabled.

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

Output be like

![Blazor Breadcrumb Component](./images/blazor-Breadcrumb-enable-navigation.png)

<!-- ## Open URL in new page or tab

To open the breadcrumb item in a new page or tab, set the target property of the required item url to blank in the Breadcrumb component. In the following example, the target property of `All Component` item url was set to blank by using the `ItemRendering` event which locates to the path in the new tab.

```cshtml
@using Syncfusion.Blazor.Navigations

<SfBreadcrumb EnableNavigation="false" ItemRendering="@ItemRendering">
    <BreadcrumbItems>
        <BreadcrumbItem Text="Home" Url="https://blazor.syncfusion.com/documentation/breadcrumb/introduction"></BreadcrumbItem>
        <BreadcrumbItem Text="Getting" Url="https://blazor.syncfusion.com/documentation/breadcrumb/getting-started"></BreadcrumbItem>
        <BreadcrumbItem Text="Icons" Url="https://blazor.syncfusion.com/documentation/breadcrumb/icons"></BreadcrumbItem>
        <BreadcrumbItem Text="Navigation" Url="https://blazor.syncfusion.com/documentation/breadcrumb/navigation"></BreadcrumbItem>
        <BreadcrumbItem Text="Overflow" Url="https://blazor.syncfusion.com/documentation/breadcrumb/overflow"></BreadcrumbItem>
    </BreadcrumbItems>
</SfBreadcrumb>
@code {
    private void ItemRendering(BreadcrumbItemRenderingEventArgs args) {
      
    }
}
```

Output be like

![Blazor Breadcrumb Component](./images/blazor-Breadcrumb-open-url.png) -->