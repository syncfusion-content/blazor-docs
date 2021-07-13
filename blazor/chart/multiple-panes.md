---
layout: post
title: Multiple Panes in Blazor Chart Component | Syncfusion 
description: Learn about Multiple Panes in Blazor Chart component of Syncfusion, and more details.
platform: Blazor
control: Chart
documentation: ug
---

# Multiple Panes

Chart area can be divided into multiple panes using [`Rows`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartRow.html) and
[`Columns`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartColumn.html).

## Rows

To split the chart area vertically into number of rows, use [`Rows`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartRow.html) property of the chart.

* You can allocate space for each row by using the [`Height`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartRow.html#Syncfusion_Blazor_Charts_ChartRow_Height)
property. The value can be either in percentage or in pixel.
* To associate a vertical axis to a particular row, specify its index to
[`RowIndex`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCommonAxis.html#Syncfusion_Blazor_Charts_ChartCommonAxis_RowIndex) property of the axis.
* To customize each row bottom line, use [`Border`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartRow.html#Syncfusion_Blazor_Charts_ChartRow_Border) property.

{% aspTab template="chart/axis/multiple-panes/row", sourceFiles="row.razor" %}

{% endaspTab %}

![Rows](images/multiple-panes/row.png)

For spanning the vertical axis along multiple row, you can use [`Span`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCommonAxis.html#Syncfusion_Blazor_Charts_ChartCommonAxis_Span) property of the axis.

{% aspTab template="chart/axis/multiple-panes/row-span", sourceFiles="row-span.razor" %}

{% endaspTab %}

![Rows](images/multiple-panes/row-span.png)

## Columns

To split the chart area horizontally into number of columns, use [`Columns`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartColumn.html) property of the chart.

* You can allocate space for each column by using the [`Width`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartColumn.html#Syncfusion_Blazor_Charts_ChartColumn_Width)
property. The given width can be either in percentage or in pixel.
* To associate a horizontal axis to a particular column, specify its index to
[`ColumnIndex`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCommonAxis.html#Syncfusion_Blazor_Charts_ChartCommonAxis_ColumnIndex) property of the axis.
* To customize each column bottom line, use [`Border`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartColumn.html#Syncfusion_Blazor_Charts_ChartColumn_Border) property.

{% aspTab template="chart/axis/multiple-panes/column", sourceFiles="column.razor" %}

{% endaspTab %}

![Columns](images/multiple-panes/Column.png)

For spanning the horizontal axis along multiple column, you can use [`Span`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartAxis.html#Syncfusion_Blazor_Charts_ChartAxis_Span) property of an axis.

{% aspTab template="chart/axis/multiple-panes/column-span", sourceFiles="column-span.razor" %}

{% endaspTab %}

![Columns](images/multiple-panes/Column-span.png)

> Note: You can refer to our [`Blazor Charts`](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations. You can also explore our [`Blazor Chart example`](https://blazor.syncfusion.com/demos/chart/line?theme=bootstrap4) to knows various chart types and how to represent time-dependent data, showing trends in data at equal intervals.

## See Also

* [Data label](./data-labels)
* [Tooltip](./tool-tip)
* [Marker](./data-markers)