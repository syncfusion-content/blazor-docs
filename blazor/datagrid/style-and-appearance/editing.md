---
layout: post
title: Editing in DataGrid control | Syncfusion
description: Learn here all about Editing in Syncfusion DataGrid control of Syncfusion Essential JS 2 and more.
platform: Blazor
control: DataGrid
documentation: ug
---

# Editing in Syncfusion Blazor DataGrid

You can customize the appearance of editing-related elements in the Syncfusion Blazor DataGrid using CSS. Below are examples of how to customize various editing-related elements.

## Customizing the edited and added row element

To customize the appearance of edited and added row table elements in the Grid, you can use the following CSS code:

```css
.e-grid .e-editedrow table, .e-grid .e-addedrow table {
	    background-color: #62b2eb;
}
```
In this example, the .**e-editedrow** class represents the edited row element, and the **.e-addedrow** class represents the added row element. You can modify the `background-color` property to change the color of these row table elements.

![Customizing the added row element](../images/style-and-appearance/edited-added-row-element.png)
![Customizing the edited row element](../images/style-and-appearance/edited-added-row-element-2.png)

## Customizing the edited row input element

To customize the appearance of edited row input elements in the Grid, you can use the following CSS code:

```css

.e-grid .e-gridform .e-rowcell .e-input-group .e-input {
    font-family: cursive;
    color:rgb(214, 33, 123)
}

```
In this example, the **.e-gridform** class represents the editing form, and the **.e-input** class represents the input elements within the form. You can modify the `font-family` property to change the font and `color` property  to change text color of the input elements.

![Customizing the edited and added row element](../images/style-and-appearance/edited-row-input-element.png)

## Customizing the edit dialog header element

To customize the appearance of the edit dialog header element in the Grid, you can use the following CSS code:

```css

.e-edit-dialog .e-dlg-header-content {
    background-color: #deecf9;
}

```
In this example, the **.e-edit-dialog** class represents the edit dialog, and the **.e-dlg-header-content** class targets the header content within the dialog. You can modify the `background-color` property to change the color of the header element.

![Customizing the edit dialog header element](../images/style-and-appearance/edit-dialog-header-element.png)

## Customizing the command column buttons

To customize the appearance of command column buttons such as edit, delete, update, and cancel, you can use the following CSS code:

```css

.e-grid .e-delete::before ,.e-grid .e-cancel-icon::before{
    color: #f51717;
}
.e-grid .e-edit::before, .e-grid .e-update::before {
    color: #077005;
}

```
In this example, the **.e-edit, .e-delete, .e-update, and .e-cancel-icon** classes represent the respective command column buttons. You can modify the `color` property to change the color of these buttons.

![Customize command column button](../images/style-and-appearance/commandbutton-1.png)
![Customize command column button](../images/style-and-appearance/commandbutton-2.png)