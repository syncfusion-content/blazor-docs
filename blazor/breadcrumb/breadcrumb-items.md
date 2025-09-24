---
layout: post
title: Breadcrumb Items in Blazor Breadcrumb component | Syncfusion
description: Checkout and learn here all about data binding with Blazor Breadcrumb component of Syncfusion and more.
platform: Blazor
control: Breadcrumb
documentation: ug
---

# Breadcrumb Items in Blazor Breadcrumb Component

The Syncfusion [Blazor Breadcrumb](https://www.syncfusion.com/blazor-components/blazor-breadcrumb) component supports to generate items based on the current URL by default. Alternatively, breadcrumb items can be manually defined using the[BreadcrumbItem](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.BreadcrumbItem.html) tag directive or by setting the [Url](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfBreadcrumb.html#Syncfusion_Blazor_Navigations_SfBreadcrumb_Url) property.

[BreadcrumbItem](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.BreadcrumbItem.html) has the following properties for navigation and its customizations.

* [Url](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.BreadcrumbItem.html#Syncfusion_Blazor_Navigations_BreadcrumbItem_Url) - Sets the URL of the Breadcrumb item, which is used for navigation when the item is clicked. This can be an absolute or relative URL.

* [IconCss](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.BreadcrumbItem.html#Syncfusion_Blazor_Navigations_BreadcrumbItem_IconCss) - Assigns a CSS class string to include an icon next to the breadcrumb item's text.

* [Text](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.BreadcrumbItem.html#Syncfusion_Blazor_Navigations_BreadcrumbItem_Text) - Specifies the display text content for the breadcrumb item.

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
{% previewsample "https://blazorplayground.syncfusion.com/embed/rjBqCLsJJBaogECl?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor Breadcrumb Component](./images/blazor-Breadcrumb-tag.png)

## Items based on current URL

The Breadcrumb component can automatically generate its items based on the segments of the current page's URL. This provides a convenient way to create dynamic breadcrumbs without manual item definition. When the `SfBreadcrumb` is instantiated without any [BreadcrumbItem](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.BreadcrumbItem.html) directives, it inspects the current URL and generates breadcrumb items accordingly. Each segment of the URL becomes a breadcrumb item, and the text is typically derived from the URL segment

```cshtml
@using Syncfusion.Blazor.Navigations

<SfBreadcrumb></SfBreadcrumb>

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/rXhpNiBSgmQNkpCP?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor Breadcrumb Component](./images/blazor-Breadcrumb-current-url.png)

N> This output screenshot shows the [Bind to Location](https://blazor.syncfusion.com/demos/breadcrumb/bind-to-location) sample.

## Absolute URL

The Breadcrumb component can also be instructed to generate its items by parsing a specific URL provided via the [Url](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.BreadcrumbItem.html#Syncfusion_Blazor_Navigations_BreadcrumbItem_Url) property property of the `<SfBreadcrumb>` component as like the below example.

```cshtml
@using Syncfusion.Blazor.Navigations

<SfBreadcrumb Url="https://blazor.syncfusion.com/demos/breadcrumb/navigation">
</SfBreadcrumb>
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LtLAMBWpzqZWfPfm?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor Breadcrumb Component](./images/blazor-Breadcrumb-static-url.png)

## Add or remove the Breadcrumb items

The Breadcrumb component allows programmatic manipulation of its items using the [Items](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfBreadcrumb.html#Syncfusion_Blazor_Navigations_SfBreadcrumb_Items) property of Breadcrumb, so items in the breadcrumb can be dynamically add or remove from the Breadcrumb.

```cshtml
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.Buttons

<SfBreadcrumb class="e-custom" Items="@items">
</SfBreadcrumb>

<SfButton OnClick="AddBefore">Insert - before </SfButton>
<SfButton OnClick="AddAfter">Insert - After </SfButton>
<SfButton OnClick="Remove">Remove </SfButton>

@code{
    List<BreadcrumbItem> items = new List<BreadcrumbItem>
    {
        new BreadcrumbItem { IconCss = "e-icons e-home"},
        new BreadcrumbItem { Text = "Open", IconCss = "e-icons e-folder-open", Url = "https://blazor.syncfusion.com/demos/datagrid/overview"},
        new BreadcrumbItem { Text = "New", IconCss = "e-icons e-file-new"}
    };

    private void AddBefore()
    {
        var index = items.IndexOf(items.Where(item => item.Text == "Open").FirstOrDefault());
        items.Insert(index, new BreadcrumbItem {Text = "Save", IconCss = "e-icons e-save"});
    }

    private void AddAfter()
    {
        var index = items.IndexOf(items.Where(item => item.Text == "New").FirstOrDefault());
        items.Insert((index + 1), new BreadcrumbItem { Text = "Delete", IconCss = "e-icons e-delete" });
    }

    private void Remove()
    {
        items.RemoveAt(items.Count() - 1);
    }
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BtVSjuVgKFaADUnm?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}
