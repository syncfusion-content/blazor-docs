---
layout: post
title: Pager with Dropdown in Blazor Pager Component | Syncfusion
description: Checkout and learn here all about how to render the Syncfusion Blazor Pager component with dropdown and much more.
platform: Blazor
control: Pager
documentation: ug
---


# Pager with Dropdown in Blazor Pager Component

## Page size list

The Pager component provides an option to change the number of items dynamically using a dropdown list. This can be achieved by using the [PageSizes](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfPager.html#Syncfusion_Blazor_Navigations_SfPager_PageSizes) property of the Pager. 

In the following sample, the selected value in a dropdown will be set to the [PageSize](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfPager.html#Syncfusion_Blazor_Navigations_SfPager_PageSize) property, and the Pager will refresh based on this new page size.

```csharp
@using Syncfusion.Blazor.Navigations

<SfPager TotalItemsCount="75" PageSizes=@pagesizes PageSize="5" NumericItemsCount="3" ShowAllInPageSizes="true">
</SfPager>

@code {
    public List<int> pagesizes = new List<int> { 5, 10, 12, 20 };
}

```

![Blazor Pager with Dropdown.](./images/blazor-pager-with-drop-down.png)