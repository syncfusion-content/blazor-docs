---
title: "Data Label in Blazor Accumulation Charts component | Syncfusion"

component: "Accumulation Charts"

description: "Learn here all about Data Label of Syncfusion Accumulation Charts (SfAccumulationChart) component and more."
---

# Data Label

The [`Visible`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationDataLabelSettings.html#Syncfusion_Blazor_Charts_AccumulationDataLabelSettings_Visible) option in the [`DataLabel`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartSeries.html#Syncfusion_Blazor_Charts_AccumulationChartSeries_DataLabel) settings can be used to add a data label to a series point.

{% aspTab template="chart/accumulation-charts/datalabel/default", sourceFiles="default.razor" %}

{% endaspTab %}

![Data Label](images/data-label/default-razor.png)

## Position

The [`Position`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationDataLabelSettings.html#Syncfusion_Blazor_Charts_AccumulationDataLabelSettings_Position) property of an accumulation chart allows the data label to be placed either [`Inside`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationLabelPosition.html#Syncfusion_Blazor_Charts_AccumulationLabelPosition_Inside) or [`Outside`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationLabelPosition.html#Syncfusion_Blazor_Charts_AccumulationLabelPosition_Outside) of the chart.

{% aspTab template="chart/accumulation-charts/datalabel/position", sourceFiles="position.razor" %}

{% endaspTab %}

![Positioning](images/data-label/position-razor.png)

## Smart Labels

Data labels will be arranged smartly without overlapping with each other. The [`EnableSmartLabels`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfAccumulationChart.html#Syncfusion_Blazor_Charts_SfAccumulationChart_EnableSmartLabels) property can be used to enable or disable this feature.

{% aspTab template="chart/accumulation-charts/datalabel/smartlabels", sourceFiles="smartlabels.razor" %}

{% endaspTab %}

![Smart Labels](images/data-label/smartlabels-razor.png)

## Connector Line

When the data label is placed [`Outside`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationLabelPosition.html#Syncfusion_Blazor_Charts_AccumulationLabelPosition_Outside) the chart, the connector line will be visible. The [`Type`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartConnector.html#Syncfusion_Blazor_Charts_AccumulationChartConnector_Type), [`Color`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartConnector.html#Syncfusion_Blazor_Charts_AccumulationChartConnector_Color), [`Width`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartConnector.html#Syncfusion_Blazor_Charts_AccumulationChartConnector_Width), [`Length`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartConnector.html#Syncfusion_Blazor_Charts_AccumulationChartConnector_Length) and [`DashArray`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartConnector.html#Syncfusion_Blazor_Charts_AccumulationChartConnector_DashArray) properties can be used to customise the connector line.

{% aspTab template="chart/accumulation-charts/datalabel/connector", sourceFiles="connector.razor" %}

{% endaspTab %}

![Connector Line](images/data-label/connector-razor.png)

## Text Mapping

The [`Name`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationDataLabelSettings.html#Syncfusion_Blazor_Charts_AccumulationDataLabelSettings_Name) property can be used to map text from a data source to a data label.

{% aspTab template="chart/accumulation-charts/datalabel/map", sourceFiles="map.razor" %}

{% endaspTab %}

![Text Mapping](images/data-label/map-razor.png)

> Refer to our [`Blazor Charts`](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations and also explore our [`Blazor Accumulation Chart Example`](https://blazor.syncfusion.com/demos/chart/pie?theme=bootstrap4) to know various features of accumulation charts and how it is used to represent numeric proportional data.

## See Also

* [Tooltip](./tool-tip/)
* [Legend](./legend/)