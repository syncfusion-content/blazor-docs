---
layout: post
title: Breadcrumb Items with Blazor Breadcrumb component | Syncfusion
description: Checkout and learn about data binding with Blazor Breadcrumb component of Syncfusion, and more details.
platform: Blazor
control: Breadcrumb
documentation: ug
---

# Breadcrumb Items in Blazor Breadcrumb component

The Breadcrumb supports to generate items based on the current URL by default. You can set the [BreadcrumbItems](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.BreadcrumbItems.html) tag directive or [`Url`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfBreadcrumb.html#Syncfusion_Blazor_Navigations_SfBreadcrumb_Url) property to generate the items.

You can generate the items using [BreadcrumbItems](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.BreadcrumbItems.html) tag directive where each [BreadcrumbItem](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.BreadcrumbItem.html) needs to be defined inside [BreadcrumbItems](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.BreadcrumbItems.html) tag. [BreadcrumbItem](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.BreadcrumbItem.html) provide below properties for navigation and customization. 

* [Url](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.BreadcrumbItem.html#Syncfusion_Blazor_Navigations_BreadcrumbItem_Url) - To sets the URL of the Breadcrumb item and that will be navigated when clicked.

* [IconCss](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.BreadcrumbItem.html#Syncfusion_Blazor_Navigations_BreadcrumbItem_IconCss) - To sets a CSS class string to include an icon for the Breadcrumb item.

* [Text](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.BreadcrumbItem.html#Syncfusion_Blazor_Navigations_BreadcrumbItem_Url) - To sets the text content of the Breadcrumb item.

```cshtml
@using Syncfusion.Blazor.Navigations

<SfBreadcrumb>
    <BreadcrumbItems>
        <BreadcrumbItem Text="Home" Url="https://blazor.syncfusion.com/demos/"></BreadcrumbItem>
        <BreadcrumbItem Text="Components" Url="https://blazor.syncfusion.com/demos/datagrid/overview"></BreadcrumbItem>
        <BreadcrumbItem Text="Navigations" Url="https://blazor.syncfusion.com/demos/breadcrumb/default-functionalities"></BreadcrumbItem>
        <BreadcrumbItem Text="Breadcrumb" Url="./breadcrumb/default-functionalities"></BreadcrumbItem>
    </BreadcrumbItems>
</SfBreadcrumb>
```

![Blazor Breadcrumb Component](./images/blazor-Breadcrumb-tag.png)

## Items based on current URL

The Breadcrumb items can be generated based on the current URL of the page when the user does not specify the Breadcrumb items using the [BreadcrumbItems](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.BreadcrumbItems.html) tag directive. The following example shows the Breadcrumb items that are generated based on the current URL.

```cshtml
@using Syncfusion.Blazor.Navigations

<SfBreadcrumb></SfBreadcrumb>
```

![Blazor Breadcrumb Component](./images/blazor-Breadcrumb-current-url.png)

> This output screenshot shows the [Bind to Location](https://blazor.syncfusion.com/demos/breadcrumb/bind-to-location) sample.

> The Breadcrumb component will be rendered based on the current URL, when the Breadcrumb items are not specified.

## Absolute URL

You can generate the Breadcrumb items by providing the [Url](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.BreadcrumbItem.html#Syncfusion_Blazor_Navigations_BreadcrumbItem_Url) property in the component.

The following example shows the Breadcrumb items generated from the provided URL in the component.

```cshtml
@using Syncfusion.Blazor.Navigations

<SfBreadcrumb Url="https://blazor.syncfusion.com/demos/breadcrumb/navigation">
</SfBreadcrumb>
```

![Blazor Breadcrumb Component](./images/blazor-Breadcrumb-static-url.png)
