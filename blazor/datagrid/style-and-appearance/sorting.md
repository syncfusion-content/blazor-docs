---
layout: post
title: Aggregate in Blazor DataGrid control | Syncfusion
description: Learn here all about Aggregate in Syncfusion Blazor DataGrid control of Syncfusion Essential JS 2 and more.
platform: Blazor
control: DataGrid
documentation: ug
---

# Sorting in Syncfusion Blazor DataGrid

You can customize the appearance of the sorting icons and multi sorting icons in the Syncfusion Blazor DataGrid using CSS. You can use the available Syncfusion [icons](../../appearance/icons/#material) based on your theme. Here's how to do it:

## Customizing the Grid sorting icon

To customize the sorting icon that appears in the Grid header when sorting is applied, you can use the following CSS code:

```css
.e-grid .e-icon-ascending::before {
    content: '\e7a3'; /* Icon code for ascending order */
}
.e-grid .e-icon-descending::before {
    content: '\e7b6'; /* Icon code for descending order */
}
```
In this example, the **.e-icon-ascending::before** class targets the sorting icon for ascending order, and the **.e-icon-descending::before** class targets the sorting icon for descending order.

![Grid sorting icon](../images/style-and-appearance/grid-sorting-icons.png)

## Customizing the Grid multi sorting icon

To customize the multi sorting icon that appears in the Grid header when multiple columns are sorted, you can use the following CSS code:

```css
.e-grid .e-sortnumber {
    background-color: #deecf9;
    font-family: cursive;
}
```

In this example, the **.e-sortnumber** class targets the background color and font family of the multi sorting icon. You can modify the `background-color` and `font-family` properties to customize the appearance of the multi sorting icon.

![Grid multi sorting icon](../images/style-and-appearance/grid-multi-sorting-icon.png)