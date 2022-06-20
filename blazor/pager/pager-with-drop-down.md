---
layout: post
title: Pager with Dropdown in Blazor Pager Component | Syncfusion
description: Checkout and learn here all about Pager with Dropdown in the Syncfusion Blazor Pager component and much more.
platform: Blazor
control: Pager
documentation: ug
---


# Pager Component with Dropdown

## Page size list

The PageSizes property of the Pager control allows an option to have multiple options of page size values. By enabling PageSizes, a dropdown will render in a pager with the current page size as the selected value in the dropdown.

The selected value in a dropdown will be set to the PageSize property and the pager will refresh based on this new page size.

```csharp
@using Syncfusion.Blazor.Navigations

<SfPager TotalItemsCount="75" PageSizes="true" PageSize="5" PageCount="5">
</SfPager>

```