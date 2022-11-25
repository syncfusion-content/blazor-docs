---
layout: post
title: Multicolumn in Blazor DropDown List Component | Syncfusion
description: Checkout and learn here all about Multicolumn in Syncfusion Blazor DropDown List component and much more.
platform: Blazor
control: DropDown List
documentation: ug
---

# Multicolumn in Dropdown List 

Provide two or more columns in the popup by using the class name `e-multi-column` to the [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_CssClass) property  and the column will be aligned like grid.

* [ItemTemplate](https://blazor.syncfusion.com/documentation/dropdown-list/templates#item-template) – Using `ItemTemplate`, add the columns in the popup.
* [ValueTemplate](https://blazor.syncfusion.com/documentation/dropdown-list/templates#value-template) – Using `ValueTemplate`, display the value of which columns to be updated.

Display the custom text alignment in each column using a built-in class like in the following code example:

* `e-text-center`: Displays the text in the center of the column.
* `e-text-right`: Displays the text in the right side of the column.
* `e-text-left`: Displays the text in the left side of the column.

{% highlight cshtml %}

{% include_relative code-snippet/multicolumn/multicolumn-dropdown.razor %}

{% endhighlight %}

![Blazor DropdownList with Multicolumn](./images/multicolumn/blazor_dropdown_multicolumn.png)

## Limitation of multicolumn dropdownlist

The component will not support column filtering and sorting, and the column will be alligned as same as grid.
