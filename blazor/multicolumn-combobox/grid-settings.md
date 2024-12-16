---
layout: post
title: Grid settings with Syncfusion Blazor MultiColumn ComboBox
description: Checkout and learn here all about Gridlines in Syncfusion Blazor MultiColumn ComboBox component and much more details.
platform: Blazor
control: MultiColumn ComboBox
documentation: ug
---

# Grid Settings in Blazor MultiColumn ComboBox Component

## Setting the gridlines

Grid lines refer to the visual lines displayed between rows and columns in a grid-like structure. You can customize how these lines appear by using the [GridLines](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.SfMultiColumnComboBox-2.html#Syncfusion_Blazor_MultiColumnComboBox_SfMultiColumnComboBox_2_GridLines) property. This allows for control over the visibility of horizontal, vertical, both, or no grid lines at all. The default value is Default.

The following example configures the GridLines property to show both horizontal and vertical lines in the dropdown popup.

{% highlight cshtml %}

{% include_relative code-snippet/grid-settings/gridlines.razor %}

{% endhighlight %}

## Setting alternate rows

The [EnableAltRow](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.SfMultiColumnComboBox-2.html#Syncfusion_Blazor_MultiColumnComboBox_SfMultiColumnComboBox_2_EnableAltRow) property controls whether the rows in the grid are styled with alternating colors. This property helps in improving readability by differentiating rows visually. When enabled, every other row will be rendered with a different style, while all rows will have the same styling if this property is disabled.

The following example enables alternate row styling, where every other row will have a different style.

{% highlight cshtml %}

{% include_relative code-snippet/grid-settings/enable-alt-row.razor %}

{% endhighlight %}

## Resizing the column

The Column resizing allows users to adjust the width of columns in the MultiColumn ComboBox by dragging the edge of the column header. The [AllowColumnResizing](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.SfMultiColumnComboBox-2.html#Syncfusion_Blazor_MultiColumnComboBox_SfMultiColumnComboBox_2_AllowColumnResizing) property. This property is useful for providing flexibility in adjusting the grid layout based on user preferences.

The following example enables column resizing, allowing users to adjust the width of the columns by dragging the header edges.

{% highlight cshtml %}

{% include_relative code-snippet/grid-settings/allow-column-resizing.razor %}

{% endhighlight %}

## TextWrap for header and content

The TextWrap in the Blazor `MultiColumn ComboBox` ensures proper wrapping of text within both headers and data content. By enabling `EnableTextWrap`, you can manage how text appears when it exceeds the available space.

**Key features**
* **TextWrapElement**: This is an enum(Header,Content ,Both) Defines the element where text wrapping is applied.

* **TextOverflowMode**:This is an enum(Ellipsis ,EllipsisWithTooltip) Defines truncates the cell content when it overflows its area.

The following example enables text wrapping for the header in the Blazor MultiColumn ComboBox, ensuring that longer text is properly displayed without overflowing.

{% highlight cshtml %}

{% include_relative code-snippet/grid-settings/text-wrap.razor %}

{% endhighlight %}

![Blazor MultiColumn ComboBox with Text Wrap](./images/blazor_multicolumn_combobox_text_wrap.gif)
