---
layout: post
title: Sorting in Blazor Spreadsheet Component | Syncfusion.
description: Learn about the sorting support in Syncfusion Blazor Spreadsheet component and how to organize your data efficiently.
platform: Blazor
component: Spreadsheet
documentation: ug
---

# Sorting in Blazor Spreadsheet component

The Syncfusion Blazor Spreadsheet provides comprehensive sorting capabilities for organizing worksheet data through UI interactions.

The Blazor Spreadsheet component includes built-in support for sorting cell ranges in ascending or descending order. To enable sorting in the Spreadsheet, the [`AllowSorting`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Spreadsheet.SfSpreadsheet.html#Syncfusion_Blazor_Spreadsheet_SfSpreadsheet_AllowSorting) property can be used to enable or disable the sorting.
>  The default value for `AllowSorting` property is **true**.

## Sort by Active Cell

The sort operation uses the column of the active cell as the primary sort criterion. Whether you select multiple cells or a single cell, the Blazor Spreadsheet component sorts all related data based on the values in the active cell's column. The range sort can be done in any of the following ways:

1. **Using Ribbon Toolbar**:
   - Select the `Sort & Filter` icon from the **Home** tab
   - Click `Ascending` or `Descending`

   ![UI showing ribbon sort option](./images/ribbon-sort.png)
2. **Using Context Menu**:
   - Right-click the selected range
   - Choose **Sort** > `Ascending` or `Descending`

   ![UI showing contextmenu sort option](./images/contextmenu-sort.png)

The cell values can be sorted in the following orders:
* Ascending
* Descending

## Sort Operations

The following animation illustrates basic sorting operations in the Spreadsheet component, including selecting data, using the `Sort` options from the context menu, and viewing the sorted results. Sorting arranges data based on the active cell's column while maintaining row relationships.

![sorting](./images/sorting.gif)
