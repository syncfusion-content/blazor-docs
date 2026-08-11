---
layout: post
title: Templates in Blazor Breadcrumb | Syncfusion®
description: Customize the Blazor Breadcrumb with item and separator templates to render custom content and visual structure between Breadcrumb entries.
platform: Blazor
control: Breadcrumb
documentation: ug
---

# Templates in Blazor Breadcrumb

Blazor has templated components that accept one or more UI segments and render them as part of the component. The [Blazor Breadcrumb](https://www.syncfusion.com/blazor-components/blazor-breadcrumb) is a templated component that lets you customize parts of its UI through template parameters. Use templates to render custom components or content based on your own logic.

The available template options in the Blazor Breadcrumb are:

* [ItemTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.BreadcrumbTemplates.html#Syncfusion_Blazor_Navigations_BreadcrumbTemplates_ItemTemplate) - Customizes each Breadcrumb item.
* [SeparatorTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.BreadcrumbTemplates.html#Syncfusion_Blazor_Navigations_BreadcrumbTemplates_SeparatorTemplate) - Customizes the separator between items.

## Template context

The templates used by Breadcrumb are of type `RenderFragment` and they will be passed with parameters. You can access the parameters passed to the templates using implicit parameter named `context`. You can also change this implicit parameter name using `Context` attribute.

## Item template

In the following example, shopping cart details are used as Breadcrumb items and each item is rendered as a `SfChip` using the `ItemTemplate` tag directive. Access the current item through the `context` parameter.

```cshtml
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.Buttons

<SfBreadcrumb class="e-breadcrumb-chips">
    <BreadcrumbItems>
        <BreadcrumbItem Text="Cart"></BreadcrumbItem>
        <BreadcrumbItem Text="Billing"></BreadcrumbItem>
        <BreadcrumbItem Text="Shipping"></BreadcrumbItem>
        <BreadcrumbItem Text="Payment"></BreadcrumbItem>
    </BreadcrumbItems>
    <BreadcrumbTemplates>
        <ItemTemplate>
            <SfChip>
                <ChipItems>
                    <ChipItem Text="@context.Text" Enabled="true"></ChipItem>
                </ChipItems>
            </SfChip>
        </ItemTemplate>
    </BreadcrumbTemplates>
</SfBreadcrumb>
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/VXLRZdCCpxDqpuWZ?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage="[Blazor Breadcrumb Component](./images/blazor-Breadcrumb-item-template.webp)" %}

N> The `ItemTemplate` replaces the default item rendering. If you want users to be able to click the item, you must render an anchor or button yourself and bind the `Url` from `context.Url`. To use `SfChip`, add the `Syncfusion.Blazor.Buttons` NuGet package.

## Separator template

In the following example, the separators are customized with an icon using the `SeparatorTemplate` tag directive. Access the previous and next items through the `context.CurrentItem` and `context.NextItem` properties.

```cshtml
@using Syncfusion.Blazor.Navigations

<SfBreadcrumb>
    <BreadcrumbItems>
        <BreadcrumbItem Text="Cart"></BreadcrumbItem>
        <BreadcrumbItem Text="Billing"></BreadcrumbItem>
        <BreadcrumbItem Text="Shipping"></BreadcrumbItem>
        <BreadcrumbItem Text="Payment"></BreadcrumbItem>
    </BreadcrumbItems>
    <BreadcrumbTemplates>
        <SeparatorTemplate>
            <span class="e-icons e-bullet-arrow"></span>
        </SeparatorTemplate>
    </BreadcrumbTemplates>
</SfBreadcrumb>
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/hXBntHMMzHDnPVbH?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage="[Blazor Breadcrumb Component](./images/blazor-breadcrumb-separator-temp.webp)" %}

## Customize a specific item

Customize a single Breadcrumb item by providing custom content as the `BreadcrumbItem` child content. The default `Text` rendering is replaced by your custom content. In the following example, a `<span>` element with a label and link is rendered only on the last item.

```cshtml
@using Syncfusion.Blazor.Navigations

<SfBreadcrumb EnableNavigation="false" class="e-specific-item-template" ActiveItem="@SpecificTemplateActiveItem">
    <BreadcrumbItems>
        <BreadcrumbItem Text="Home" Url="https://blazor.syncfusion.com/demos/" />
        <BreadcrumbItem Text="Components" Url="https://blazor.syncfusion.com/demos/datagrid/overview" />
        <BreadcrumbItem Text="Navigations" Url="https://blazor.syncfusion.com/demos/menu-bar/default-functionalities" />
        <BreadcrumbItem>
            <span class="e-searchfor-text">
                <span style="margin-right: 5px">Search for:</span>
                <a class="e-breadcrumb-text" href="./breadcrumb/default-functionalities" onclick="return false">Breadcrumb</a>
            </span>
        </BreadcrumbItem>
    </BreadcrumbItems>
</SfBreadcrumb>

@code{
    private string SpecificTemplateActiveItem = "";
}

<style>
    @@font-face {
        font-family: 'e-bicons';
        src: url(data:application/x-font-ttf;charset=utf-8;base64,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) format('truetype');
        font-weight: normal;
        font-style: normal;
    }

    .e-searchfor-text {
        display: flex;
        align-items: center;
        font-size: 14px;
        font-weight: normal;
    }

    .e-searchfor-text .e-breadcrumb-text {
        padding-left: 0;
    }

    .e-bigger .e-searchfor-text {
        font-size: 16px
    }

    .fabric .e-searchfor-text,
    .fabric-dark .e-searchfor-text,
    .highcontrast .e-searchfor-text {
        font-size: 18px;
    }

    .e-bigger.fabric .e-searchfor-text,
    .e-bigger.fabric-dark .e-searchfor-text,
    .e-bigger.highcontrast .e-searchfor-text {
        font-size: 21px;
    }

    .e-specific-item-template .e-breadcrumb-item:last-child a:hover {
        text-decoration: underline;
    }
</style>
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/VXhHXRWipdWiDWGo?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage="[Blazor Breadcrumb Component](./images/breadcrumb-specific-item-template.webp)" %}

N> When you supply child content for a `BreadcrumbItem`, the `Text` and `Url` properties are ignored. To make the link clickable, use Blazor's `@onclick` with `NavigationManager.NavigateTo(context.Url)` instead of the legacy `onclick` HTML attribute, which requires interactive render mode.

## See also

* [Getting started with Blazor Breadcrumb](https://blazor.syncfusion.com/documentation/breadcrumb/getting-started)
* [Breadcrumb Items in Blazor](https://blazor.syncfusion.com/documentation/breadcrumb/breadcrumb-items)
* [Styles and Appearance in Blazor Breadcrumb](https://blazor.syncfusion.com/documentation/breadcrumb/style-and-appearance)
* [Accessibility in Blazor Breadcrumb](https://blazor.syncfusion.com/documentation/breadcrumb/accessibility)
