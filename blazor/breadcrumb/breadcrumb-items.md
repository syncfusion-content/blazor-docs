---
layout: post
title: Breadcrumb Items in Blazor Breadcrumb | Syncfusion®
description: Generate Blazor Breadcrumb items from the current URL or populate them manually using BreadcrumbItem tag directives and the Url property.
platform: Blazor
control: Breadcrumb
documentation: ug
---

# Breadcrumb Items in Blazor Breadcrumb

The [Blazor Breadcrumb](https://www.syncfusion.com/blazor-components/blazor-breadcrumb) component supports generating items based on the current URL by default. You can set the [BreadcrumbItem](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.BreadcrumbItem.html) tag directive or the [Url](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfBreadcrumb.html#Syncfusion_Blazor_Navigations_SfBreadcrumb_Url) property on the component to generate the items.

The [BreadcrumbItem](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.BreadcrumbItem.html) tag directive has the following properties for navigation and customization.

* [Url](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.BreadcrumbItem.html#Syncfusion_Blazor_Navigations_BreadcrumbItem_Url) - Sets the URL of the Breadcrumb item and navigates to it when clicked.

* [IconCss](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.BreadcrumbItem.html#Syncfusion_Blazor_Navigations_BreadcrumbItem_IconCss) - Sets the CSS class string used to render an icon for the Breadcrumb item.

* [Text](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.BreadcrumbItem.html#Syncfusion_Blazor_Navigations_BreadcrumbItem_Text) - Sets the text content of the Breadcrumb item.

The example below shows how to define Blazor Breadcrumb items using the `BreadcrumbItem` tag directive.

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
{% previewsample "https://blazorplayground.syncfusion.com/embed/VXVRtnisfesRoRtn?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Blazor Breadcrumb Component](./images/blazor-Breadcrumb-tag.webp)" %}

## Items based on current URL

If no `<BreadcrumbItem>` tag directive is specified, the Blazor Breadcrumb generates items from the current URL. The component reads the URL from Blazor's `NavigationManager` and turns each path segment into a Blazor Breadcrumb item. Query strings and hash fragments are ignored.

The following example shows the Blazor Breadcrumb items that are auto-generated from the current URL.

```cshtml
@using Syncfusion.Blazor.Navigations

<SfBreadcrumb></SfBreadcrumb>
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/rtLRZdCsfeBjfFYF?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage="[Blazor Breadcrumb Component](./images/blazor-Breadcrumb-current-url.webp)" %}

N> This output screenshot shows the [Bind to Location](https://blazor.syncfusion.com/demos/breadcrumb/bind-to-location?theme=fluent2) sample.

## Absolute URL

Set the [Url](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfBreadcrumb.html#Syncfusion_Blazor_Navigations_SfBreadcrumb_Url) property on the `SfBreadcrumb` component to generate items from an absolute URL. Use the `Url` property on `BreadcrumbItem` (covered above) when you want each item to navigate to a different URL.

```cshtml
@using Syncfusion.Blazor.Navigations

<SfBreadcrumb Url="https://blazor.syncfusion.com/demos/breadcrumb/navigation">
</SfBreadcrumb>

```

{% previewsample "https://blazorplayground.syncfusion.com/embed/hXBxtniiTyrTqfVz?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage="[Blazor Breadcrumb Component](./images/blazor-Breadcrumb-static-url.webp)" %}

## Add or remove Blazor Breadcrumb items

Use the [Items](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfBreadcrumb.html#Syncfusion_Blazor_Navigations_SfBreadcrumb_Items) property of the Breadcrumb to dynamically add or remove items. The example below shows how to insert items before or after a target item and remove the last item at runtime.

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

{% previewsample "https://blazorplayground.syncfusion.com/embed/hjBnjRiCfIVlzcYK?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage="[Blazor Breadcrumb Component](./images/blazor-Breadcrumb-dynamic-items.webp)" %}

## See also

* [Getting started with Blazor Breadcrumb](https://blazor.syncfusion.com/documentation/breadcrumb/getting-started)
* [Breadcrumb Templates in Blazor](https://blazor.syncfusion.com/documentation/breadcrumb/templates)
* [Accessibility in Blazor Breadcrumb](https://blazor.syncfusion.com/documentation/breadcrumb/accessibility)
