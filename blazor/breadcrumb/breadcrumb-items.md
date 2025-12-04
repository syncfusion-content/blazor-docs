---
layout: post
title: Breadcrumb Items with Blazor Breadcrumb component | Syncfusion
description: Checkout and learn here all about data binding with Blazor Breadcrumb component of Syncfusion and more.
platform: Blazor
control: Breadcrumb
documentation: ug
---

# Breadcrumb Items in Blazor Breadcrumb Component

The [Blazor Breadcrumb](https://www.syncfusion.com/blazor-components/blazor-breadcrumb) supports to generate items based on the current URL by default. You can set the [BreadcrumbItem](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.BreadcrumbItem.html) tag directive or [Url](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfBreadcrumb.html#Syncfusion_Blazor_Navigations_SfBreadcrumb_Url) property to generate the items.

[BreadcrumbItem](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.BreadcrumbItem.html) has the following properties for navigation and its customizations.

* [Url](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.BreadcrumbItem.html#Syncfusion_Blazor_Navigations_BreadcrumbItem_Url) - Sets the URL of the Breadcrumb item and it will navigate when clicked.

* [IconCss](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.BreadcrumbItem.html#Syncfusion_Blazor_Navigations_BreadcrumbItem_IconCss) - Sets CSS class string to include an icon for the Breadcrumb item.

* [Text](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.BreadcrumbItem.html#Syncfusion_Blazor_Navigations_BreadcrumbItem_Text) - Sets the text content of the Breadcrumb item.

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
{% previewsample "https://blazorplayground.syncfusion.com/embed/rjBqCLsJJBaogECl?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor Breadcrumb Component](./images/blazor-Breadcrumb-tag.png)" %}

## Items based on current URL

The Breadcrumb items can be generated based on the current URL of the page when the user does not specify the Breadcrumb items using the [BreadcrumbItem](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.BreadcrumbItem.html) tag directive. The following example shows the Breadcrumb items that are auto generated based on the current URL.

```cshtml
@using Syncfusion.Blazor.Navigations

<SfBreadcrumb></SfBreadcrumb>
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/rNhUWVWJzVObSwiI?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor Breadcrumb Component](./images/blazor-Breadcrumb-current-url.png)" %}

N> This output screenshot shows the [Bind to Location](https://blazor.syncfusion.com/demos/breadcrumb/bind-to-location) sample.

## Absolute URL

You can generate the Breadcrumb items by providing the [Url](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.BreadcrumbItem.html#Syncfusion_Blazor_Navigations_BreadcrumbItem_Url) property in the component as like the below example.

```cshtml
@using Syncfusion.Blazor.Navigations

<SfBreadcrumb Url="https://blazor.syncfusion.com/demos/breadcrumb/navigation">
</SfBreadcrumb>
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LtLAMBWpzqZWfPfm?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor Breadcrumb Component](./images/blazor-Breadcrumb-static-url.png)" %}

## Add or remove the Breadcrumb items

Using the [Items](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfBreadcrumb.html#Syncfusion_Blazor_Navigations_SfBreadcrumb_Items) property of Breadcrumb, we can dynamically add or remove the items of Breadcrumb.

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
{% previewsample "https://blazorplayground.syncfusion.com/embed/BXBStMNFgGHPMWew?appbar=true&editor=true&result=true&errorlist=true&theme=bootstrap5" %}
