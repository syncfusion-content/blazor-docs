---
layout: post
title: Breadcrumb Icons with Blazor Breadcrumb component | Syncfusion
description: Breadcrumb allows the end user to place the icons on Breadcrumb items and navigate to other webpages while clicking the Breadcrumb items.
platform: Blazor
control: Breadcrumb
documentation: ug
---

# Icons in Blazor Breadcrumb Component

The [Blazor Breadcrumb](https://www.syncfusion.com/blazor-components/blazor-breadcrumb) component supports the inclusion of icons, images, and SVG elements to enhance the visual representation of its items. These visual cues improve navigation clarity and user experience.

## Breadcrumb with font icon

To display a font icon on a Breadcrumb item, set the [IconCss](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.BreadcrumbItem.html#Syncfusion_Blazor_Navigations_BreadcrumbItem_IconCss) property to `e-icons` with the required icon's class name.

```cshtml
@using Syncfusion.Blazor.Navigations

<SfBreadcrumb>
    <BreadcrumbItems>
        <BreadcrumbItem IconCss="e-icons e-home" Url="https://blazor.syncfusion.com/demos/"></BreadcrumbItem>
        <BreadcrumbItem Text="Components" Url="https://blazor.syncfusion.com/demos/datagrid/overview"></BreadcrumbItem>
        <BreadcrumbItem Text="Navigations" Url="https://blazor.syncfusion.com/demos/menu-bar/default-functionalities"></BreadcrumbItem>
        <BreadcrumbItem Text="Breadcrumb" Url="./breadcrumb/default-functionalities"></BreadcrumbItem>
    </BreadcrumbItems>
</SfBreadcrumb>
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/rDLgWLMTfUsCSUjG?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor Breadcrumb with Font Icons](./images/blazor-Breadcrumb-items.png)

N> By default, icons are positioned to the left side of the item text.

## Breadcrumb with image

Images can be incorporated into Breadcrumb items using the [IconCss](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.BreadcrumbItem.html#Syncfusion_Blazor_Navigations_BreadcrumbItem_IconCss) property. In the following example, an image is added to a Breadcrumb item with specific height and width by using `e-image-home` CSS class.

```cshtml
@using Syncfusion.Blazor.Navigations

<SfBreadcrumb>
    <BreadcrumbItems>
        <BreadcrumbItem IconCss="e-image-home" Url="https://blazor.syncfusion.com/demos/"></BreadcrumbItem>
        <BreadcrumbItem Text="Components" Url="https://blazor.syncfusion.com/demos/datagrid/overview"></BreadcrumbItem>
        <BreadcrumbItem Text="Navigations" Url="https://blazor.syncfusion.com/demos/menu-bar/default-functionalities"></BreadcrumbItem>
        <BreadcrumbItem Text="Breadcrumb" Url="./breadcrumb/default-functionalities"></BreadcrumbItem>
    </BreadcrumbItems>
</SfBreadcrumb>

<style>
    .e-image-home {
        background-image: url(/home.png);
        height: 20px;
        width: 20px;
    }
</style>
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/rjhgsLMppKsTBQHd?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor Breadcrumb with Image](./images/image.png)

## Breadcrumb with SVG image

To add an SVG image to a Breadcrumb item, use the [IconCss](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.BreadcrumbItem.html#Syncfusion_Blazor_Navigations_BreadcrumbItem_IconCss) property with a custom CSS class. In the following example, SVG image is added to the Breadcrumb item with height and width by using `e-svg-home` class.

```cshtml
@using Syncfusion.Blazor.Navigations

<SfBreadcrumb>
    <BreadcrumbItems>
        <BreadcrumbItem IconCss="e-svg-home" Url="https://blazor.syncfusion.com/demos/"></BreadcrumbItem>
        <BreadcrumbItem Text="Components" Url="https://blazor.syncfusion.com/demos/datagrid/overview"></BreadcrumbItem>
        <BreadcrumbItem Text="Navigations" Url="https://blazor.syncfusion.com/demos/menu-bar/default-functionalities"></BreadcrumbItem>
        <BreadcrumbItem Text="Breadcrumb" Url="./breadcrumb/default-functionalities"></BreadcrumbItem>
    </BreadcrumbItems>
</SfBreadcrumb>

<style>
    .e-svg-home {
        background-image: url('/home.svg');
        height: 20px;
        width: 20px;
    }
</style>
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BDrgsLCJfAixuNYA?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Breadcrumb with SVG Image](./images/svg.PNG)

## Icon only

To display Breadcrumb items consisting solely of icons, provide the [IconCss](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.BreadcrumbItem.html#Syncfusion_Blazor_Navigations_BreadcrumbItem_IconCss) property for each `BreadcrumbItem` without specifying the `Text` property.

The following example demonstrates Breadcrumb items rendered only with icons:

```cshtml
@using Syncfusion.Blazor.Navigations

<SfBreadcrumb>
    <BreadcrumbItems>
        <BreadcrumbItem IconCss="e-icons e-home"></BreadcrumbItem>
        <BreadcrumbItem IconCss="e-icons e-folder-open"></BreadcrumbItem>
        <BreadcrumbItem IconCss="e-icons e-file-new"></BreadcrumbItem>
    </BreadcrumbItems>
</SfBreadcrumb>
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BNrgWrWTTqsOeruV?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Breadcrumb with Icons Only](./images/icon-only.PNG)

## Show icon only for first item
To display an icon exclusively for the first item in the Breadcrumb, set the [IconCss](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.BreadcrumbItem.html#Syncfusion_Blazor_Navigations_BreadcrumbItem_IconCss) property for the first `BreadcrumbItem` and omit it for subsequent items.

The following example demonstrates an icon only for the initial Breadcrumb item:

```cshtml
@using Syncfusion.Blazor.Navigations

<SfBreadcrumb>
    <BreadcrumbItems>
        <BreadcrumbItem IconCss="e-icons e-home" Url="https://blazor.syncfusion.com/demos/"></BreadcrumbItem>
        <BreadcrumbItem Text="Components" Url="https://blazor.syncfusion.com/demos/datagrid/overview"></BreadcrumbItem>
        <BreadcrumbItem Text="Navigations" Url="https://blazor.syncfusion.com/demos/menu-bar/default-functionalities"></BreadcrumbItem>
        <BreadcrumbItem Text="Breadcrumb" Url="./breadcrumb/default-functionalities"></BreadcrumbItem>
    </BreadcrumbItems>
</SfBreadcrumb>
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LXLgChsTfKrhKYox?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor Breadcrumb with First Item Icon Only](./images/blazor-Breadcrumb-items.png)