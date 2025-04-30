---
layout: post
title: Aggregate in Blazor DataGrid | Syncfusion
description: Learn here all about aggregate in Syncfusion Blazor DataGrid of Syncfusion Essential JS 2 and more.
platform: Blazor
control: DataGrid
documentation: ug
---

# Aggregate in Syncfusion Blazor DataGrid

You can customize the appearance of aggregate elements in the Syncfusion Blazor DataGrid using CSS. Below are examples of how to customize the aggregate root element and the aggregate cell elements.

## Customizing the aggregate root element

To customize the appearance of the Grid's aggregate root elements, you can use the following CSS code:

```css
.e-grid .e-gridfooter {
    font-family: cursive;
}
```

In this example, the **e-gridfooter** class represents the root element of the aggregate row in the Grid footer. You can modify the `font-family` property to change the font of the aggregate root element.

![Customize aggregate root element](../images/style-and-appearance/aggregate-root-element.png)

## Customizing the aggregate cell elements

To customize the appearance of the Grid's aggregate cell elements (summary row cell elements), you can use the following CSS code:

```css
.e-grid .e-summaryrow .e-summarycell {
    background-color: #deecf9;
}
```

In this example, the **e-summaryrow** class represents the summary row containing aggregate cells, and the **e-summarycell** class targets individual aggregate cells within the summary row. You can modify the `background-color` property to change the `color` of the aggregate cell elements.

![Customize aggregate cell element](../images/style-and-appearance/aggregate-cell-element.png)