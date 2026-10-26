---
layout: post
title: Multicolumn in Blazor AutoComplete | Syncfusion®
description: Render the Blazor AutoComplete popup with multiple visual columns by applying the e-multi-column CSS class and an item template to lay out the data.
platform: Blazor
control: AutoComplete
documentation: ug
---

# Multicolumn in Blazor AutoComplete

Provide two or more visual columns in the popup by applying the `e-multi-column` CSS class through the [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_CssClass) property, and render the layout using an item template. This approach uses templates and CSS to display data in multiple columns; it is not a data grid and does not add grid features.

* [ItemTemplate](https://blazor.syncfusion.com/documentation/autocomplete/templates#item-template) – Use `ItemTemplate` to define the content for each row and arrange fields into multiple visual columns in the popup.

Display custom text alignment within each column using the following built-in utility classes:

* `e-text-center`: Aligns text to the center of the column.
* `e-text-right`: Aligns text to the right side of the column.
* `e-text-left`: Aligns text to the left side of the column.

{% highlight cshtml %}

{% include_relative code-snippet/multicolumn/multicolumn-autocomplete.razor %}

{% endhighlight %}

![Blazor AutoComplete popup with multiple columns using ItemTemplate](./images/multicolumn/blazor_autocomplete_multicolumn.webp)

## Limitation of multicolumn autocomplete

The component does not support column-level features such as sorting, filtering, or resizing. The multi-column appearance is template-based and visually aligned similar to a grid; responsive behavior and widths depend on the custom CSS defined in the template.