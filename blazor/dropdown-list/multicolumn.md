---
Layout: Post
Title: Multicolumn in Blazor DropDown List Component | Syncfusion
Description: Checkout and learn here all about Multicolumn in Syncfusion Blazor DropDown List component and much more.
Platform: Blazor
Control: DropDown List
Documentation: UG
---

# Multicolumn in Dropdown List 

Provide two or more columns in the popup by providing the class name `e-multi-column` and the column will be aligned as like grid. The [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_CssClass) property is used to get the output as proper alignment.

* [itemTemplate](https://blazor.syncfusion.com/documentation/dropdown-list/templates#item-template) – Using `itemTemplate`, add the columns in the popup.
* [valueTemplate](https://blazor.syncfusion.com/documentation/dropdown-list/templates#value-template) – Using `valueTemplate`, display the value of which columns to be updated.

Display the custom text alignment in each column using a built-in class like in the following code example:

* e-text-center: Displays the text in the center of the column.
* e-text-right: Displays the text in the right side of the column.
* e-text-left: Displays the text in the left side of the column.

{% highlight cshtml %}

{% include_relative code-snippet/multicolumn/multicolumn-dropdown.razor %}

{% endhighlight %}

![Blazor DropdownList with cascading](./images/multicolumn/blazor_dropdown_multicolumn.png)

## Limitation of multicolumn dropdownlist

The component will not support column filtering and sorting, and the column will be alligned as same as grid.
