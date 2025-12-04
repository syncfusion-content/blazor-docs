---
layout: post
title: Breadcrumb Templates with Blazor Breadcrumb component | Syncfusion
description: Breadcrumb section explains how to customize the item template and separator template to the Breadcrumb items.
platform: Blazor
control: Breadcrumb
documentation: ug
---

# Templates in Blazor Breadcrumb Component

Blazor has templated components which accepts one or more UI segments as input that can be rendered as part of the component during component rendering. Breadcrumb is a templated blazor component, that allow you to customize various part of the UI using template parameters. It allows you to render custom components or content based on your own logic.

The available template options in Breadcrumb are as follows,

[Item template](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.BreadcrumbTemplates.html#Syncfusion_Blazor_Navigations_BreadcrumbTemplates_ItemTemplate) - Used to customize the items.

[Separator template](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.BreadcrumbTemplates.html#Syncfusion_Blazor_Navigations_BreadcrumbTemplates_SeparatorTemplate)- Used to customize the separators.

## Template context

The templates used by Breadcrumb are of type `RenderFragment` and they will be passed with parameters. You can access the parameters passed to the templates using implicit parameter named `context`. You can also change this implicit parameter name using `Context` attribute.

## Item template

In the following example, shopping cart details are used as Breadcrumb items and each item is rendered as Chip component using [ItemTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.BreadcrumbTemplates.html#Syncfusion_Blazor_Navigations_BreadcrumbTemplates_ItemTemplate) tag directive. You can get the current item in `context` property.

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
{% previewsample "https://blazorplayground.syncfusion.com/embed/BNhUsrippKxnwhYp?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor Breadcrumb Component](./images/blazor-Breadcrumb-item-template.png)" %}

## Separator template

In the following example, the separators are customized with icons using [SeparatorTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.BreadcrumbTemplates.html#Syncfusion_Blazor_Navigations_BreadcrumbTemplates_SeparatorTemplate) tag directive. You can get the previous and next item in `context` property.

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

<style>
    .e-bullet-arrow::before {
        content: '\e763';
        font-size: 12px;
    }
</style>
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/hjLUsrWzJARuZSHz?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor Breadcrumb Component](./images/blazor-breadcrumb-separator-temp.png)" %}

## Customize Specific Item Template

The specific breadcrumb item can be customizable by adding the custom element as Child Content. In the following example, added the span element only for the breadcrumb text in breadcrumb item.

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
{% previewsample "https://blazorplayground.syncfusion.com/embed/VZBgCrsTpAvZIhgB?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor Breadcrumb Component](./images/breadcrumb-specific-item-template.png)" %}