---
layout: post
title: Multicolumn in Blazor DropDown List Component | Syncfusion
description: Checkout and learn here all about Multicolumn in Syncfusion Blazor DropDown List component and much more.
platform: Blazor
control: DropDown List
documentation: ug
---

# Multicolumn in Dropdown List 

You can provide two or more columns in the popup by providing the class name “e-multi-column” and the column will be aligned as like grid. CssClass property is used to get the output as proper alignment.

* [itemTemplate](https://blazor.syncfusion.com/documentation/dropdown-list/templates#item-template) – Using item template, you can add the columns in the popup.
* [valueTemplate](https://blazor.syncfusion.com/documentation/dropdown-list/templates#value-template) – Using value template, you can display the value of which columns to be updated.

{% highlight cshtml %}

{% include_relative code-snippet/multicolumn/multicolumn-dropdown.razor %}

{% endhighlight %}

![Blazor DropdownList with cascading](./images/multicolumn/blazor_dropdown_multicolumn.png)

## Limitation of multicolumn dropdownlist

The component will not support column filtering and sorting and the column will be alligned as same like grid.
