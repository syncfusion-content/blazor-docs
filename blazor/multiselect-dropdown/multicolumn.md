---
layout: post
title: Multicolumn in Blazor MultiSelect Component | Syncfusion
description: Checkout and learn here all about Multicolumn in Syncfusion Blazor MultiSelect component and much more.
platform: Blazor
control: MultiSelect
documentation: ug
---

# Multicolumn MultiSelect Dropdown

Provide two or more columns in the popup by using the class name `e-multi-column` to the [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfMultiSelect-2.html#Syncfusion_Blazor_DropDowns_SfMultiSelect_2_CssClass) property  and the column will be aligned like grid.

* [ItemTemplate](https://blazor.syncfusion.com/documentation/multiselect-dropdown/templates#item-template) – Using `ItemTemplate`, add the columns in the popup.
* [ValueTemplate](https://blazor.syncfusion.com/documentation/multiselect-dropdown/templates#value-template) – Using `ValueTemplate`, display the value of which columns to be updated.

Display the custom text alignment in each column using a built-in class like in the following code example:

* `e-text-center`: Displays the text in the center of the column.
* `e-text-right`: Displays the text in the right side of the column.
* `e-text-left`: Displays the text in the left side of the column.

{% highlight cshtml %}

{% include_relative code-snippet/multicolumn/multicolumn-dropdown.razor %}

{% endhighlight %}

![Blazor MultiSelect with Multicolumn](./images/multicolumn/blazor_multiselect_multicolumn.png)

## How to Display MultiColumn Item and CheckBox Inline

To ensure the checkbox and item details are aligned perfectly on the same line, you can apply the following CSS styles. These styles position the checkbox within the template, making it inline with the item details:

 ```css
    .e-popup.e-multi-select-list-wrapper .e-list-item .e-checkbox-wrapper {
     position: absolute;
     top: 10px;
     left: 5px;
   }
```

## Limitation of multicolumn multiselect dropdown

The component will not support column filtering and sorting, and the column will be aligned as same as grid.
