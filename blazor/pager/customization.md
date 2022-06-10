---
layout: post
title: Customization in Blazor Pager Component | Syncfusion
description: Checkout and learn here all about Customization in the Syncfusion Blazor Pager component and much more.
platform: Blazor
control: Pager
documentation: ug
---

# Customization in Pager DataGrid Component

## Custom text

The CustomText property of a pager allows you to add custom text along with numeric values in the pager numeric elements that are used for navigation in the pager control.

```csharp
@using Syncfusion.Blazor.Navigations

<SfPager ID="Pager" TotalItemsCount="75" CustomText="PageNo" PageSizes="true" PageSize="5" PageCount="5">
</SfPager>

```