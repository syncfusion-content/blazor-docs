---
layout: post
title: Breadcrumb Templates with Blazor Breadcrumb component | Syncfusion
description: Breadcrumb section explain how to customize the item template and separator template to the breadcrumb items.
platform: Blazor
control: Breadcrumb
documentation: ug
---

# Templates in Blazor Breadcrumb component

The Breadcrumb component provides a way to customize the items using the [ItemTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.BreadcrumbTemplates.html#Syncfusion_Blazor_Navigations_BreadcrumbTemplates_ItemTemplate) and the separators using the [SeparatorTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.BreadcrumbTemplates.html#Syncfusion_Blazor_Navigations_BreadcrumbTemplates_SeparatorTemplate) tag directives.


## Item Template

Most of the templates used by breadcrumb are of type RenderFragment and they will be passed with parameters. You can access the parameters passed to the templates using implicit parameter named context. You can also change this implicit parameter name using Context attribute. You can get the current item in this Context attribute.

In the following example, Shopping Cart details are used as breadcrumb Items and each item is rendered as chips component using [ItemTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.BreadcrumbTemplates.html#Syncfusion_Blazor_Navigations_BreadcrumbTemplates_ItemTemplate).

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

## Separator Template

Most of the templates used by breadcrumb are of type RenderFragment and they will be passed with parameters. You can access the parameters passed to the templates using implicit parameter named context. You can also change this implicit parameter name using Context attribute. You can get the previous and next item in this Context attribute.

In the  following example, the separators are customized with icons using [SeparatorTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.BreadcrumbTemplates.html#Syncfusion_Blazor_Navigations_BreadcrumbTemplates_SeparatorTemplate).

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