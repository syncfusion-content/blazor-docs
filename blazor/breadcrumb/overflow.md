---
layout: post
title: Breadcrumb Overflow with Blazor Breadcrumb component | Syncfusion
description: Overflow section in Blazor Breadcrumb explains how to limit the number of breadcrumb items to be displayed.
platform: Blazor
control: Breadcrumb
documentation: ug
---

# Overflow Mode in Blazor Breadcrumb component

In the Breadcrumb component, [MaxItems](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfBreadcrumb.html#Syncfusion_Blazor_Navigations_SfBreadcrumb_MaxItems) and [OverflowMode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfBreadcrumb.html#Syncfusion_Blazor_Navigations_SfBreadcrumb_OverflowMode) properties were used to limit the number of breadcrumb items to be displayed.

The following overflow modes are available in the Breadcrumb component.

[Default](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.BreadcrumbOverflowMode.html#Syncfusion_Blazor_Navigations_BreadcrumbOverflowMode_Default) - Specified [MaxItems](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfBreadcrumb.html#Syncfusion_Blazor_Navigations_SfBreadcrumb_MaxItems) count will be visible and the remaining items will be hidden. While clicking on the previous item, the hidden item will become visible.

[Collapsed](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.BreadcrumbOverflowMode.html#Syncfusion_Blazor_Navigations_BreadcrumbOverflowMode_Collapsed) - Only the first and last items will be visible, and the remaining items will be hidden in the collapsed icon. When the collapsed icon is clicked, all items will become visible.

In the following example, the [MaxItems](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfBreadcrumb.html#Syncfusion_Blazor_Navigations_SfBreadcrumb_MaxItems) is set as 3 with OverflowMode as Default. To prevent breadcrumb item navigation, the [EnableNavigation](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfBreadcrumb.html#Syncfusion_Blazor_Navigations_SfBreadcrumb_EnableNavigation) property has been set to false in the Breadcrumb component.

```cshtml
@using Syncfusion.Blazor.Navigations

<SfBreadcrumb MaxItems="3" EnableNavigation="false">
    <BreadcrumbItems>
        <BreadcrumbItem Text="Home" Url="https://blazor.syncfusion.com/documentation/breadcrumb/introduction"></BreadcrumbItem>
        <BreadcrumbItem Text="Getting" Url="https://blazor.syncfusion.com/documentation/breadcrumb/getting-started"></BreadcrumbItem>
        <BreadcrumbItem Text="Icons" Url="https://blazor.syncfusion.com/documentation/breadcrumb/icons"></BreadcrumbItem>
        <BreadcrumbItem Text="Navigation" Url="https://blazor.syncfusion.com/documentation/breadcrumb/navigation"></BreadcrumbItem>
        <BreadcrumbItem Text="Overflow" Url="https://blazor.syncfusion.com/documentation/breadcrumb/overflow"></BreadcrumbItem>
    </BreadcrumbItems>
    <BreadcrumbTemplates>
        <SeparatorTemplate>
            <span class="e-icons e-arrow"></span>
        </SeparatorTemplate>
    </BreadcrumbTemplates>
</SfBreadcrumb>

<style>
    .e-arrow:before {
        content: "\e748";
    }
</style>
```

![Blazor Breadcrumb Component](./images/blazor-breadcrumb-overflow.png)