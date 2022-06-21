---
layout: post
title: Pager with Dropdown in Blazor Pager Component | Syncfusion
description: Checkout and learn here all about how to render the Syncfusion Blazor Pager component with dropdown and much more.
platform: Blazor
control: Pager
documentation: ug
---


# Pager Component with Dropdown

## Page size list

The Pager component provides an option to change the number of records dynamically using a dropdown list. This can be achieved by using the `PageSizes` property of the Pager. 

In the following sample, the selected value in a dropdown will be set to the `PageSize` property, and the Pager will refresh based on this new page size.

```csharp
@using Syncfusion.Blazor.Navigations

<SfPager TotalItemsCount="75" PageSizes="true" PageSize="5" PageCount="5">
</SfPager>

```