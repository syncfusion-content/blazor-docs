---
layout: post
title: Breadcrumb Icons with Blazor Breadcrumb component | Syncfusion®
description: Breadcrumb allows the end user to place the icons on Breadcrumb items and navigate to other webpages while clicking the Breadcrumb items.
platform: Blazor
control: Breadcrumb
documentation: ug
---

# Icons in Blazor Breadcrumb

The [Blazor Breadcrumb](https://www.syncfusion.com/blazor-components/blazor-breadcrumb) component supports font icons, images, and SVG icons to provide a visual representation of each item.

N> Before using font icons, make sure the Syncfusion icon CSS is referenced in your application. See the [Syncfusion Blazor getting-started guide](https://blazor.syncfusion.com/documentation/breadcrumb/getting-started) for setup details.

## Breadcrumb with font icon

Set the [IconCss](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.BreadcrumbItem.html#Syncfusion_Blazor_Navigations_BreadcrumbItem_IconCss) property to `e-icons` plus the icon's class name to render a font icon on a Breadcrumb item. By default, the icon is positioned to the left side of the item.

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

{% previewsample "https://blazorplayground.syncfusion.com/embed/hZLRDniWfSAqnGJs?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage="[Blazor Breadcrumb Component](./images/blazor-breadcrumb-items.webp)" %}

N> For the full list of available icon classes, see the [Syncfusion Blazor icons library](https://blazor.syncfusion.com/documentation/appearance/icons).

## Breadcrumb with image

Add an image to a Breadcrumb item by setting `IconCss` to a custom class that targets an image asset. Place the image file in the `wwwroot` folder (for example, `wwwroot/images/home.png`) and reference it from CSS.

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

{% previewsample "https://blazorplayground.syncfusion.com/embed/rXBnNxCifygwoTNj?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage="[Blazor Breadcrumb Component](./images/image.webp)" %}

## Breadcrumb with SVG image

Add an SVG image to a Breadcrumb item by setting the `IconCss` property to a class that targets an SVG asset. Place the SVG file in the `wwwroot` folder (for example, `wwwroot/images/home.svg`) and reference it from CSS.

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

{% previewsample "https://blazorplayground.syncfusion.com/embed/hXrHXnMWpSzhjofy?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage="[Breadcrumb Sample](./images/svg.webp)" %}

## Icon only

Use the `IconCss` property to display only an icon for a Breadcrumb item. When the `Text` property is not set, only the icon is rendered.

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

{% previewsample "https://blazorplayground.syncfusion.com/embed/LNLdXdCiTSJSQSdB?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage="[Breadcrumb Sample](./images/icon-only.webp)" %}

N> For icon-only items, set an `aria-label` (via the `HtmlAttributes` parameter) so screen readers can announce the action. See [Accessibility in Blazor Breadcrumb](https://blazor.syncfusion.com/documentation/breadcrumb/accessibility) for details.

## Show icon only for first item

To show the icon only on the first Breadcrumb item, set `IconCss` on the first item and `Text` on the remaining items. The following example shows a home icon on the first item and text on the rest.

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

{% previewsample "https://blazorplayground.syncfusion.com/embed/hZrdZxMMfoJYQwyj?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage="[Blazor Breadcrumb Component](./images/blazor-breadcrumb-items.webp)" %}

## See also

* [Getting started with Blazor Breadcrumb](https://blazor.syncfusion.com/documentation/breadcrumb/getting-started)
* [Breadcrumb Items in Blazor](https://blazor.syncfusion.com/documentation/breadcrumb/breadcrumb-items)
* [Breadcrumb Templates in Blazor](https://blazor.syncfusion.com/documentation/breadcrumb/templates)
* [Accessibility in Blazor Breadcrumb](https://blazor.syncfusion.com/documentation/breadcrumb/accessibility)
