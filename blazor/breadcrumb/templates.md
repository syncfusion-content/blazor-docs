---
layout: post
title: Breadcrumb Templates with Blazor Breadcrumb component | Syncfusion
description: Breadcrumb section explain how to customize the item template and separator template to the Breadcrumb items.
platform: Blazor
control: Breadcrumb
documentation: ug
---

# Templates in Blazor Breadcrumb component

Blazor has templated components which accepts one or more UI segments as input that can be rendered as part of the component during component rendering. Breadcrumb is a templated blazor component, that allow you to customize various part of the UI using template parameters. It allow you to render custom components or content based on your own logic.

The available template options in Breadcrumb are as follows,

[Item template](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.BreadcrumbTemplates.html#Syncfusion_Blazor_Navigations_BreadcrumbTemplates_ItemTemplate) - Used to customize the items.

[Separator template](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.BreadcrumbTemplates.html#Syncfusion_Blazor_Navigations_BreadcrumbTemplates_SeparatorTemplate)- Used to customize the separators.

## Template context

The templates used by Breadcrumb are of type RenderFragment and they will be passed with parameters. You can access the parameters passed to the templates using implicit parameter named context. You can also change this implicit parameter name using context attribute.

## Item template

In the following example, Shopping Cart details are used as Breadcrumb items and each item is rendered as Chips component using [ItemTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.BreadcrumbTemplates.html#Syncfusion_Blazor_Navigations_BreadcrumbTemplates_ItemTemplate) tag directive. You can get the current item in this context attribute.

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

![Blazor Breadcrumb Component](./images/blazor-Breadcrumb-item-template.png)

## Separator template

In the  following example, the separators are customized with icons using [SeparatorTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.BreadcrumbTemplates.html#Syncfusion_Blazor_Navigations_BreadcrumbTemplates_SeparatorTemplate) tag directive. You can get the previous and next item in this context attribute.

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

![Blazor Breadcrumb Component](./images/blazor-breadcrumb-separator-temp.png)