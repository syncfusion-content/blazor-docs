---
layout: post
title: Styling and Appearance in Blazor TreeGrid Component | Syncfusion
description: Learn how to customize the styling and appearance of the Syncfusion Blazor TreeGrid component using CSS classes.
platform: Blazor
control: TreeGrid
documentation: ug
---

# Styling and Appearance in Blazor TreeGrid Component

To modify the appearance of the TreeGrid, override its default CSS styles. Below is a categorized list of CSS classes and their corresponding sections in the TreeGrid.

| Section     | CSS Class               | Purpose |
|-------------|-------------------------|---------|
| **Root**    | `e-treegrid`            | Applied to the root element of the TreeGrid control |
| **Header**  | `e-gridheader`          | Applied to the root of the header; used to style the line between header and content |
|             | `e-table`               | Applied to the header table; sets table width to 100% |
|             | `e-columnheader`        | Applied to the `tr` element in the header |
|             | `e-headercell`          | Applied to the `th` element; used to style header background and borders |
|             | `e-headercelldiv`       | Applied to the `div` inside `th`; used to style header skeleton |
| **Body**    | `e-gridcontent`         | Applied to the root of the body content; used to style background color |
|             | `e-table`               | Applied to the content table; sets table width to 100% |
|             | `e-altrow`              | Applied to alternate rows; used to style alternate row colors |
|             | `e-rowcell`             | Applied to all cells; used to style cell appearance |
|             | `e-groupcaption`        | Applied to `td` of group caption; used to style caption background |
|             | `e-selectionbackground` | Applied to selected row cells; used to style selection background |
|             | `e-hover`               | Applied to rows on hover; used to style hover effect |
| **Pager**   | `e-pager`               | Applied to the root of the pager; used to style background and font color |
|             | `e-pagercontainer`      | Applied to numeric pager items |
|             | `e-parentmsgbar`        | Applied to pager info section |
| **Summary** | `e-gridfooter`          | Applied to the root of the summary section |
|             | `e-summaryrow`          | Applied to summary rows |
|             | `e-summarycell`         | Applied to summary cells; used to style summary background |
