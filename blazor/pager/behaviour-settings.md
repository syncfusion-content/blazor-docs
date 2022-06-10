---
layout: post
title: Behaviour Settings in Blazor Pager Component | Syncfusion
description: Checkout and learn here all about Behaviour Settings in the Syncfusion Blazor Pager component and much more.
platform: Blazor
control: Pager
documentation: ug
---

# Behaviour Settings in Pager DataGrid Component

## Page size

The PageSize property of the Pager control allows an option to get or set a value that indicates whether to define the number of records displayed per page.

```csharp
@using Syncfusion.Blazor.Navigations

<SfPager PageSize="5">
</SfPager>

```

## Page count

The PageCount property of the Pager control allows an option to get or set a value that indicates whether to define the number of pages displayed in the pager for navigation.

```csharp
@using Syncfusion.Blazor.Navigations

<SfPager PageCount="5">
</SfPager>

```

## Total pages

The TotalPages property of the Pager control allows an option to get or set a value for the total number of pages in the Pager. The TotalPages value is calculated based on page size and total items.

```csharp
@using Syncfusion.Blazor.Navigations

<SfPager TotalPages="1">
</SfPager>

```

## Total items count

The TotalItemsCount property of the Pager control allows an option to get the value of the total number of records which are bound to a data item.

```csharp
@using Syncfusion.Blazor.Navigations

<SfPager TotalItemsCount="75">
</SfPager>

```

## Current page

The CurrentPage property of the Pager control allows an option to get or set a value that indicates whether to define which page to display currently in the pager.

```csharp
@using Syncfusion.Blazor.Navigations

<SfPager CurrentPage="1">
</SfPager>

```

## Page size list

The PageSizes property of the Pager control allows an option to have multiple options of page size values. By enabling PageSizes, a dropdown will render in a pager with the current page size as the selected value in the dropdown.

The selected value in a dropdown will be set to the PageSize property and the pager will refresh based on this new page size.

```csharp
@using Syncfusion.Blazor.Navigations

<SfPager TotalItemsCount="75" PageSizes="true" PageSize="5" PageCount="5">
</SfPager>

```