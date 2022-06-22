---
layout: post
title: Behaviour Settings in Blazor Pager Component | Syncfusion
description: Checkout and learn here all about basic functionalites of render the Syncfusion Blazor Pager component and much more.
platform: Blazor
control: Pager
documentation: ug
---

# Behaviour Settings in Pager Component

## Page size

The Pager component provides an option to define the number of items to be displayed per page. This can be achieved by using the `PageSize` property. The default value of the `PageSize` property is "12".

```csharp
@using Syncfusion.Blazor.Navigations

<SfPager PageSize="5">
</SfPager>

```

## Page count

The Pager component provides an option to define the number of numeric items to be displayed in the Pager for navigation. This can be achieved by using the `PageCount` property. The default value of the `PageCount` property is "10".

```csharp
@using Syncfusion.Blazor.Navigations

<SfPager PageCount="5">
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

The Pager component provides an option to define which page to be displayed currently in the Pager. This can be achieved by using the `CurrentPage` property. The default value of the `CurrentPage` property is "1".

```csharp
@using Syncfusion.Blazor.Navigations

<SfPager CurrentPage="3">
</SfPager>

```

## Show pager message

The Pager component provides an option to show or hide the Pager information in the Pager container. This can be achieved by using the `ShowPagerMessage` property. The default value of the `ShowPagerMessage` is "true". If you set the `ShowPagerMessage` to false, then the Pager information will be hidden.

```csharp
@using Syncfusion.Blazor.Navigations

<SfPager ShowPagerMessage="true">
</SfPager>

```