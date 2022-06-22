---
layout: post
title: Customization in Blazor Pager Component | Syncfusion
description: Checkout and learn here all about how to customize the elements of Syncfusion Blazor Pager component and much more.
platform: Blazor
control: Pager
documentation: ug
---

# Customization in Pager Component

## Custom text

The Pager component provides an option to define custom text along with numeric items. This can be achieved by using the `CustomText` property.

```csharp
@using Syncfusion.Blazor.Navigations

<SfPager ID="Pager" TotalItemsCount="75" CustomText="PageNo" PageSizes="true" PageSize="5" PageCount="5">
</SfPager>

```

## Custom CSS

To modify the Pager's appearance, you need to override the default CSS of the Pager. This can be achieved by using the `CssClass` property.

In the following sample, the value for the `CssClass` property is set as custom CSS, and this root class is used to customize the Pager appearance.

```csharp
@using Syncfusion.Blazor.Navigations

<SfPager PageCount="5" PageSize="5" TotalItemsCount=50 CssClass=customCss>
</SfPager>

<style>

    .e-pager.customCss .e-currentitem.e-numericitem.e-focused, .e-pager.customCss .e-currentitem{
        background: #2bbbad;
        color: #f6f3f1;
        border-bottom: 0px;
        border-radius: 0.125rem;
        outline-style: auto;
    }
        
</style>
```