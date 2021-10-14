---
layout: post
title: Breadcrumb Icons with Blazor Breadcrumb component | Syncfusion
description: Breadcrumb allows the end user to place the icons on breadcrumb items and navigate to other webpages while clicking the Breadcrumb items.
platform: Blazor
control: Breadcrumb
documentation: ug
---

# Icons in Blazor Breadcrumb component

The Breadcrumb component contains an icon/image to provide a visual representation of an item.

## Icon in breadcrumb item

To load the icon on the breadcrumb item, set the [IconCss](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.BreadcrumbItem.html#Syncfusion_Blazor_Navigations_BreadcrumbItem_IconCss) property.

### Breadcrumb with Font Icon

To place the font icon on the breadcrumb item, set the [IconCss](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.BreadcrumbItem.html#Syncfusion_Blazor_Navigations_BreadcrumbItem_IconCss) property to `e-icons` with the required icon CSS. By default, the icon is positioned to the left side of the item.

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

![Blazor Breadcrumb Component](./images/blazor-Breadcrumb-items.png)

### Breadcrumb with Image

In the Breadcrumb component, images can be added for the items using the [class] attribute. In the following example, an image was added to the breadcrumb item by using the IconCss class `e-image` and specifying height and width.

```cshtml
@using Syncfusion.Blazor.Navigations

<SfBreadcrumb>
    <BreadcrumbItems>
        <BreadcrumbItem class="e-image-home" Url="https://blazor.syncfusion.com/demos/"></BreadcrumbItem>
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

![Blazor Breadcrumb Component](./images/image.png)

### Breadcrumb with SVG Image

In the Breadcrumb component, SVG image can be added for the items using the [class] attribute. In the following example, SVG image was added to the breadcrumb item by using the IconCss class `e-image` and specifying height and width.

```cshtml
@using Syncfusion.Blazor.Navigations

<SfBreadcrumb>
    <BreadcrumbItems>
        <BreadcrumbItem class="e-svg-home" Url="https://blazor.syncfusion.com/demos/"></BreadcrumbItem>
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

![Breadcrumb Sample](./images/svg.PNG)

## Icon Only

To display only icons for the items, add icons using the [IconCss](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.BreadcrumbItem.html#Syncfusion_Blazor_Navigations_BreadcrumbItem_IconCss) property. In the following example, breadcrumb items were demonstrated with only icons by providing the [IconCss](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.BreadcrumbItem.html#Syncfusion_Blazor_Navigations_BreadcrumbItem_IconCss) property.

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

![Breadcrumb Sample](./images/icon-only.PNG)

## Show icon only for first item

To show icon only for the first item in the Breadcrumb component, add icons to the first item using the [IconCss](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.BreadcrumbItem.html#Syncfusion_Blazor_Navigations_BreadcrumbItem_IconCss) property. In the following example, the icon was provided only for the first item by setting the [IconCss](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.BreadcrumbItem.html#Syncfusion_Blazor_Navigations_BreadcrumbItem_IconCss) property.

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

![Blazor Breadcrumb Component](./images/blazor-Breadcrumb-items.png)