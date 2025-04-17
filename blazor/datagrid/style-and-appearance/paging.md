---
layout: post
title: Paging in Blazor DataGrid control | Syncfusion
description: Learn here all about Paging in Syncfusion Blazor DataGrid control of Syncfusion Essential JS 2 and more.
platform: Blazor
control: DataGrid
documentation: ug
---

# Paging in Syncfusion Blazor DataGrid

You can customize the appearance of the paging elements in the Syncfusion Blazor DataGrid using CSS. Here are examples of how to customize the pager root element, pager container element, pager navigation elements, pager page numeric link elements, and pager current page numeric element.

## Customizing the Grid pager root element

To customize the appearance of the Grid pager root element, you can use the following CSS code:

```css
.e-grid .e-gridpager {
    font-family: cursive;
    background-color: #deecf9;
}
```
In this example, the **.e-gridpager** class targets the pager root element. You can modify the `font-family` to change the font family and `background-color` property to change the background color of the pager.

![Grid pager root element](../images/style-and-appearance/grid-pager-root-element.png)

## Customizing the Grid pager container element

To customize the appearance of the Grid pager container element, you can use the following CSS code:

```css
.e-grid .e-pagercontainer {
    border: 2px solid #00b5ff;
    font-family: cursive;
}
```

In this example, the **.e-pagercontainer** class targets the pager container element. You can modify the `border` property and `font-family` property to change the border color and font family of the pager container.

![Grid pager container element](../images/style-and-appearance/grid-pager-container-element.png)

## Customizing the Grid pager navigation elements

To customize the appearance of the Grid pager navigation elements, you can use the following CSS code:

```css
.e-grid .e-gridpager .e-prevpagedisabled,
.e-grid .e-gridpager .e-prevpage,
.e-grid .e-gridpager .e-nextpage,
.e-grid .e-gridpager .e-nextpagedisabled,
.e-grid .e-gridpager .e-lastpagedisabled,
.e-grid .e-gridpager .e-lastpage,
.e-grid .e-gridpager .e-firstpage,
.e-grid .e-gridpager .e-firstpagedisabled {
    background-color: #deecf9;
}
```

In this example, the classes **.e-prevpagedisabled, .e-prevpage, .e-nextpage, .e-nextpagedisabled, .e-lastpagedisabled, .e-lastpage, .e-firstpage,** and **.e-firstpagedisabled** target the various pager navigation elements. You can modify the `background-color` property to change the background color of these elements.

![Grid pager navigation elements](../images/style-and-appearance/grid-pager-navigation-element.png)

## Customizing the Grid pager page numeric link elements

To customize the appearance of the Grid pager current page numeric link elements, you can use the following CSS code:

```css
.e-grid .e-gridpager .e-numericitem {
    background-color: #5290cb;
    color: #ffffff;
    cursor: pointer;
    }
    
.e-grid .e-gridpager .e-numericitem:hover {
    background-color: white;
    color:  #007bff;
}
```

In this example, the **.e-numericitem** class targets the page numeric link elements. You can modify the `background-color`, `color` properties to change the background color and text color of these elements.

![Grid pager page numeric link elements](../images/style-and-appearance/pager-page-numeric-link-elements.png)

## Customizing the Grid pager current page numeric element

To customize the appearance of the Grid pager current page numeric element, you can use the following CSS code:

```css
.e-grid .e-gridpager .e-currentitem {
    background-color: #0078d7;
    color: #fff;
}
```

In this example, the **.e-currentitem** class targets the current page numeric item. You can modify the `background-color` property to change the background color of this element and `color` property to change the text color.

![Grid pager current page numeric element](../images/style-and-appearance/grid-pager-current-page-numeric-element.png)