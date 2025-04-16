---
layout: post
title: Selection in Blazor DataGrid control | Syncfusion
description: Learn here all about Selection in Syncfusion Blazor DataGrid control of Syncfusion Essential JS 2 and more.
platform: Blazor
control: DataGrid
documentation: ug
---

# Selection in Syncfusion Blazor DataGrid

You can customize the appearance of the selection in the Syncfusion Blazor DataGrid using CSS. Here are examples of how to customize the row selection background, cell selection background, and column selection background.

## Customizing the row selection background

To customize the appearance of row selection, you can use the following CSS code:

```css
.e-grid td.e-selectionbackground {
    background-color: #00b7ea;
}
```
In this example, the **.e-selectionbackground** class targets the background color of the row selection. You can modify the `background-color` property to change the background color of the selected rows.

![Row selection](../images/style-and-appearance/row-selection.png)

## Customizing the cell selection background

To customize the appearance of cell selection, you can use the following CSS code:

```css
.e-grid td.e-cellselectionbackground {
    background-color: #00b7ea;
}
```

In this example, the **.e-cellselectionbackground** class targets the background color of the cell selection. You can modify the `background-color` property to change the background color of the selected cells.

![Cell selection](../images/style-and-appearance/cell-selection.png)