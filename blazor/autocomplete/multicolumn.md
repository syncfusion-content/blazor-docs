---
layout: post
title: Multicolumn in Blazor AutoComplete List Component | Syncfusion
description: Checkout and learn here all about AutoComplete in Syncfusion Blazor AutoComplete component and more.
platform: Blazor
control: AutoComplete
documentation: ug
---

# Multicolumn in AutoComplete

Provide two or more columns in the popup by using the class name `e-multi-column` to the [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_CssClass) property  and the column will be aligned like grid.

* [ItemTemplate](https://blazor.syncfusion.com/documentation/autocomplete/templates#item-template) – Using `ItemTemplate`, add the columns in the popup.

Display the custom text alignment in each column using a built-in class like in the following code example:

* `e-text-center`: Displays the text in the center of the column.
* `e-text-right`: Displays the text in the right side of the column.
* `e-text-left`: Displays the text in the left side of the column.

{% highlight cshtml %}

{% include_relative code-snippet/multicolumn/multicolumn-autocomplete.razor %}

{% endhighlight %}

![Blazor AutoComplete with Multicolumn](./images/multicolumn/blazor_autocomplete_multicolumn.png)

## Limitation of multicolumn autocomplete

The component will not support column filtering and sorting, and the column will be alligned as same as grid.
