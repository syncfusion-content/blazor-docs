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

Grid lines are the visual dividers shown between rows and columns in the popup’s grid layout. Configure their appearance using the [GridLines](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.SfMultiColumnComboBox-2.html#Syncfusion_Blazor_MultiColumnComboBox_SfMultiColumnComboBox_2_GridLines) property to show horizontal lines, vertical lines, both, or none. The default value is `Default`.

The following example configures the GridLines property to show both horizontal and vertical lines in the dropdown popup.

{% highlight cshtml %}

{% include_relative code-snippet/grid-settings/gridlines.razor %}

{% endhighlight %}

## Setting alternate rows

The [EnableAltRow](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.SfMultiColumnComboBox-2.html#Syncfusion_Blazor_MultiColumnComboBox_SfMultiColumnComboBox_2_EnableAltRow) property enables alternating row styles to improve readability. When enabled, every other row uses an alternate style; when disabled, all rows share the same style. The default value is `false`.

The following example enables alternate row styling, where every other row has a different style.

{% highlight cshtml %}

{% include_relative code-snippet/grid-settings/enable-alt-row.razor %}

{% endhighlight %}

## Resizing the column

Column resizing lets users adjust column widths by dragging the edge of a column header. Enable this behavior with the [AllowColumnResizing](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.SfMultiColumnComboBox-2.html#Syncfusion_Blazor_MultiColumnComboBox_SfMultiColumnComboBox_2_AllowColumnResizing) property. This provides flexibility to tailor the popup layout to the data and available space.

The following example enables column resizing, allowing users to adjust the width of the columns by dragging the header edges.

{% highlight cshtml %}

{% include_relative code-snippet/grid-settings/allow-column-resizing.razor %}

{% endhighlight %}

## TextWrap for header and content

Text wrapping ensures longer text in headers and cell content is displayed neatly within the available space. Enable wrapping with the `EnableTextWrap` property and configure behavior as needed.

Key features
* TextWrapElement: enum (Header, Content, Both) that specifies where text wrapping is applied.
* TextOverflowMode: enum (Ellipsis, EllipsisWithTooltip) that specifies how overflowed content is handled—truncate with an ellipsis or show an ellipsis with a tooltip.

The following example enables text wrapping for the header in the Blazor MultiColumn ComboBox, ensuring that longer text is displayed without overflowing.

{% highlight cshtml %}

{% include_relative code-snippet/grid-settings/text-wrap.razor %}

{% endhighlight %}

![Blazor MultiColumn ComboBox with Text Wrap](./images/blazor_multicolumn_combobox_text_wrap.gif)