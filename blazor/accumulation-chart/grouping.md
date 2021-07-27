---
title: "Grouping in Blazor Accumulation Charts component | Syncfusion"

component: "Accumulation Charts"

description: "Learn here all about Grouping of Syncfusion Accumulation Charts (SfAccumulationChart) component and more."
---

<!-- markdownlint-disable MD036 -->

# Grouping

The value set to the [`GroupTo`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartSeries.html#Syncfusion_Blazor_Charts_AccumulationChartSeries_GroupTo) property can be used to club/group a few points in the series. Points with a value less than [`GroupTo`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartSeries.html#Syncfusion_Blazor_Charts_AccumulationChartSeries_GroupTo) are grouped together and displayed as a single point with the label **Others**. In addition, the property value can be set in percentage (percentage of total data points value).

{% aspTab template="chart/accumulation-charts/grouping/group", sourceFiles="group.razor" %}

{% endaspTab %}

![Grouping](images/grouping/group-razor.png)

## Pie Grouping

**Broken Slice**

The points that have been grouped together will appear as a single slice with the label **Others**, which will explode and break into separate slices when clicked.

{% aspTab template="chart/accumulation-charts/grouping/custom", sourceFiles="custom.razor" %}

{% endaspTab %}

![Broken Slice](images/grouping/custom-razor.png)

**Group Mode**

 When the [`GroupMode`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartSeries.html#Syncfusion_Blazor_Charts_AccumulationChartSeries_GroupMode) property is set to [`Point`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.GroupMode.html#Syncfusion_Blazor_Charts_GroupMode_Point) the points are displayed as seperate slices accoding to the [`GroupTo`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartSeries.html#Syncfusion_Blazor_Charts_AccumulationChartSeries_GroupTo) value. The remaining points will be grouped into a single slice and displayed.

{% aspTab template="chart/accumulation-charts/grouping/groupmode", sourceFiles="groupmode.razor" %}

{% endaspTab %}

![Group Mode](images/grouping/groupmode-razor.png)

> Refer to our [`Blazor Charts`](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations and also explore our [`Blazor Accumulation Chart Example`](https://blazor.syncfusion.com/demos/chart/pie?theme=bootstrap4) to know various features of accumulation charts and how it is used to represent numeric proportional data.

* [Data Label](./data-labels)
* [Tooltip](./tool-tip)
* [Legend](./legend)