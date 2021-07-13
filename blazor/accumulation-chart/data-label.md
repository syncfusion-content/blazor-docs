---
layout: post
title: Data Label in Blazor Accumulation Chart Component | Syncfusion 
description: Learn about Data Label in Blazor Accumulation Chart component of Syncfusion, and more details.
platform: Blazor
control: Accumulation Chart
documentation: ug
---

# Data Label

Data label can be added to a point by enabling the [`Visible`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationDataLabelSettings.html#Syncfusion_Blazor_Charts_AccumulationDataLabelSettings_Visible)
option in the DataLabel property.

{% aspTab template="chart/accumulation-charts/datalabel/default", sourceFiles="default.razor" %}

{% endaspTab %}

![Data Label](images/data-label/default-razor.png)

## Position

Accumulation chart provides support for placing the data label either `Inside` or `Outside` of the chart by using [`Position`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationDataLabelSettings.html#Syncfusion_Blazor_Charts_AccumulationDataLabelSettings_Position) property.

{% aspTab template="chart/accumulation-charts/datalabel/position", sourceFiles="position.razor" %}

{% endaspTab %}

![Positioning](images/data-label/position-razor.png)

## Smart Labels

Datalabels will be arranged smartly without overlapping with each other. You can enable or disable this feature using
the [`EnableSmartLabels`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfAccumulationChart.html#Syncfusion_Blazor_Charts_SfAccumulationChart_EnableSmartLabels)
property.

{% aspTab template="chart/accumulation-charts/datalabel/smartlabels", sourceFiles="smartlabels.razor" %}

{% endaspTab %}

![Smart Labels](images/data-label/smartlabels-razor.png)

## Connector Line

Connector line will be visible when the data label is placed `Outside` the chart.
The connector line can be customized using the [`Type`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartConnector.html#Syncfusion_Blazor_Charts_AccumulationChartConnector_Type), [`Color`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartConnector.html#Syncfusion_Blazor_Charts_AccumulationChartConnector_Color), [`Width`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartConnector.html#Syncfusion_Blazor_Charts_AccumulationChartConnector_Width), [`Length`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartConnector.html#Syncfusion_Blazor_Charts_AccumulationChartConnector_Length) and [`DashArray`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartConnector.html#Syncfusion_Blazor_Charts_AccumulationChartConnector_DashArray) properties

{% aspTab template="chart/accumulation-charts/datalabel/connector", sourceFiles="connector.razor" %}

{% endaspTab %}

![Connector Line](images/data-label/connector-razor.png)

## Text Mapping

Text from the data source can be mapped to data label using [`Name`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationDataLabelSettings.html#Syncfusion_Blazor_Charts_AccumulationDataLabelSettings_Name) property.

{% aspTab template="chart/accumulation-charts/datalabel/map", sourceFiles="map.razor" %}

{% endaspTab %}

![Text Mapping](images/data-label/map-razor.png)

## See Also

* [Tooltip](./tool-tip/)
* [Legend](./legend/)