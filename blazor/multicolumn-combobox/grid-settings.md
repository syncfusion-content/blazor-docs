---
layout: post
title: Grid settings with Syncfusion Blazor MultiColumn ComboBox
description: Checkout and learn here all about Gridlines in Syncfusion Blazor MultiColumn ComboBox component and much more details.
platform: Blazor
control: MultiColumn ComboBox
documentation: ug
---

# Grid Settings in Blazor MultiColumn ComboBox Component

## Setting the  grid lines

Grid lines refer to the visual lines displayed between rows and columns in a grid-like structure. You can customize how these lines appear by using the [GridLines](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.SfMultiColumnComboBox-2.html#Syncfusion_Blazor_MultiColumnComboBox_SfMultiColumnComboBox_2_GridLines) property. This allows for control over the visibility of horizontal, vertical, both, or no grid lines at all. The default value is Default.

The following example configures the GridLines property to show both horizontal and vertical lines in the dropdown popup.

{% highlight cshtml %}

{% include_relative code-snippet/grid-settings/gridlines.razor %}

{% endhighlight %}

## Setting AllowColumnResizing

The Column resizing allows users to adjust the width of columns in the MultiColumn ComboBox by dragging the edge of the column header. The [AllowColumnResizing](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.SfMultiColumnComboBox-2.html#Syncfusion_Blazor_MultiColumnComboBox_SfMultiColumnComboBox_2_AllowColumnResizing) property. This property is useful for providing flexibility in adjusting the grid layout based on user preferences.

The following example enables column resizing, allowing users to adjust the width of the columns by dragging the header edges.

{% highlight cshtml %}

{% include_relative code-snippet/grid-settings/allow-column-resizing.razor %}

{% endhighlight %}
