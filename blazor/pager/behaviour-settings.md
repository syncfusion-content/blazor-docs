---
layout: post
title: Behaviour Settings in Blazor Pager Component | Syncfusion
description: Checkout here and learn about all the basic functionalities of rendering the Syncfusion Blazor Pager component and much more.
platform: Blazor
control: Pager
documentation: ug
---

# Behaviour Settings in Pager Component

This section briefly explains how to calculate the total number of items available in the assigned data collection, which is used to render the elements (numeric items and navigation buttons) of the Pager component.

## Page size

The Pager component provides an option to define the number of items to be displayed per page. This can be achieved by using the `PageSize` property. The default value of the `PageSize` property is "12."

```csharp
@using Syncfusion.Blazor.Navigations

<SfPager PageSize="5" TotalItemsCount="20">
</SfPager>

```

## Numeric items count

The Pager component provides an option to define the number of numeric items to be displayed in the Pager for navigation. This can be achieved by using the `NumericItemsCount` property. The default value of the `NumericItemsCount` property is "10."

```csharp
@using Syncfusion.Blazor.Navigations

<SfPager NumericItemsCount="5" TotalItemsCount="20" PageSize="4">
</SfPager>

```

## Total items count

The Pager component provides an option to define the total number of items available in the assigned data collection, which is used to render the elements(numeric items, navigation buttons) of Pager component. This can be achieved by using the `TotalItemsCount` property of the Pager.

```csharp
@using Syncfusion.Blazor.Navigations

<SfPager TotalItemsCount="75">
</SfPager>

```

## Current page

Blazor Pager component support to define which page to be displayed currently in the Pager using the `CurrentPage` property. The default value of the `CurrentPage` property is "1".

```csharp
@using Syncfusion.Blazor.Navigations

<SfPager CurrentPage="3" TotalItemsCount="20" PageSize="4" NumericItemsCount="5">
</SfPager>

```

## Show pager message

The Pager component provides an option to show or hide the Pager information in the Pager container. This can be achieved by using the `ShowPagerMessage` property. The default value of the `ShowPagerMessage` is "true". If you set the `ShowPagerMessage` to false, then the Pager information will be hidden.

```csharp
@using Syncfusion.Blazor.Navigations

<SfPager ShowPagerMessage="true" PageSize="4" NumericItemsCount="5" TotalItemsCount="20">
</SfPager>

```

![Show Blazor Pager Message](./images/blazor-pager-message.png)