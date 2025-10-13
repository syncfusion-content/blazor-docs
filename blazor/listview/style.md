---
layout: post
title: CSS Structure in Blazor ListView Component | Syncfusion
description: Checkout and learn here all about CSS Structure in Syncfusion Blazor ListView component and much more.
platform: Blazor
control: Listview
documentation: ug
---

# CSS Structure in Blazor ListView Component

This section provides the core CSS structure and examples that can be used to modify the appearance of the Syncfusion Blazor ListView component according to specific design preferences.

## Customizing ListView

Use the following CSS to customize the ListView.

```CSS

.e-listview {
    border: 5px solid rgb(173, 255, 47);
}

```

## Customizing the list items

Use the following CSS to customize the items of ListView.

```CSS

.e-listview .e-list-item {
    text-align: center;
    color: pink;
    background-color: #2fa1ff;
}

```

## Customizing ListView's header

Use the following CSS to customize the header of ListView component.

```CSS

.e-listview .e-list-header{
    color: #2fa1ff;
    justify-content: center;
}

```

## Customizing Group Header of ListView

Use the following CSS to customize the category of the group items.

```CSS

.e-listview .e-list-group-item {
    color: rgb(173, 255, 47);
    background-color: maroon;
    text-align: end;
}

```

## Customizing the hover state of ListView component

Use the following CSS to customize the list item when hovering.

### Customizing ListView Hover State with the Checkbox Checked

```CSS

.e-listview .e-list-item.e-hover.e-active.e-checklist {
    color: rgb(83, 5, 79);
    background-color: rgb(173, 255, 47);
}

```

### Customizing ListView Hover State

```CSS

.e-listview .e-list-item.e-hover {
    color:red;
    background-color: rgb(173, 255, 47);
}

```

## Customizing Selected Item of ListView Component

Use the following CSS to customize the selected list item.

### Customizing ListView's Selected Item with the Checkbox Checked

```CSS

.e-listview .e-list-item.e-checklist.e-focused.e-active {
    color: rgb(83, 5, 79);
    background-color: rgb(0, 15, 100);
}

```

### Customizing ListView's Selected Item

```CSS

.e-listview .e-list-item.e-focused {
    color: #2fa1ff;
    background-color: rgb(0, 15, 100);
}

```