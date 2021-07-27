---
title: "Legend in Blazor Accumulation Charts component | Syncfusion"

component: "Accumulation Charts"

description: "Learn here all about Legend of Syncfusion Accumulation Charts (SfAccumulationChart) component and more."
---

# Legend

The legend is available for accumulation charts, just like it is for charts, and it provides information about the points. If the chart's width is large, the legend will be placed on the right, and if the chart's height is large, the legend will be placed on the bottom. The legend for a point can be collapsed by assigning an empty string to the point's x value.

{% aspTab template="chart/accumulation-charts/legend/default", sourceFiles="default.razor" %}

{% endaspTab %}

![Legend](images/legend/default-razor.png)

## Position and Alignment

The legend can be placed at [`Left`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.LegendPosition.html#Syncfusion_Blazor_Charts_LegendPosition_Left), [`Right`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.LegendPosition.html#Syncfusion_Blazor_Charts_LegendPosition_Right), [`Top`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.LegendPosition.html#Syncfusion_Blazor_Charts_LegendPosition_Top) or [`Bottom`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.LegendPosition.html#Syncfusion_Blazor_Charts_LegendPosition_Bottom)  [`Custom`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.LegendPosition.html#Syncfusion_Blazor_Charts_LegendPosition_Custom) position of the chart using the [`Position`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartLegendSettings.html#Syncfusion_Blazor_Charts_AccumulationChartLegendSettings_Position) property. The [`Alignment`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartLegendSettings.html#Syncfusion_Blazor_Charts_AccumulationChartLegendSettings_Alignment) property can also be used to align the legend to the chart's [`Center`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.Alignment.html#Syncfusion_Blazor_Charts_Alignment_Center), [`Far`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.Alignment.html#Syncfusion_Blazor_Charts_Alignment_Far) or [`Near`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.Alignment.html#Syncfusion_Blazor_Charts_Alignment_Near).

{% aspTab template="chart/accumulation-charts/legend/position", sourceFiles="position.razor" %}

{% endaspTab %}

![Position and Alignment](images/legend/position-razor.png)

## Legend Shape

The [`LegendShape`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartSeries.html#Syncfusion_Blazor_Charts_AccumulationChartSeries_LegendShape) property in the [`Series`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartSeries.html#properties) can be used to change the shape of the legend icon. The default icon shape for legends is [`SeriesType`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.LegendShape.html#Syncfusion_Blazor_Charts_LegendShape_SeriesType).

{% aspTab template="chart/accumulation-charts/legend/legend-shape", sourceFiles="legend-shape.razor" %}

{% endaspTab %}

![Legend Shape](images/legend/legend-shape-razor.png)

## Legend Size

The legend size can be customized by using the [`Width`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartLegendSettings.html#Syncfusion_Blazor_Charts_AccumulationChartLegendSettings_Width) and [`Height`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartLegendSettings.html#Syncfusion_Blazor_Charts_AccumulationChartLegendSettings_Height) properties of the [`AccumulationChartLegendSettings`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartLegendSettings.html).

{% aspTab template="chart/accumulation-charts/legend/size", sourceFiles="size.razor" %}

{% endaspTab %}

![Legend Size](images/legend/size-razor.png)

## Legend Shape Size

The [`ShapeHeight`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartLegendSettings.html#Syncfusion_Blazor_Charts_AccumulationChartLegendSettings_ShapeHeight)
and [`ShapeWidth`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartLegendSettings.html#Syncfusion_Blazor_Charts_AccumulationChartLegendSettings_ShapeWidth) properties can be used to adjust the dimensions of the legend shape.

{% aspTab template="chart/accumulation-charts/legend/item-size", sourceFiles="item-size.razor" %}

{% endaspTab %}

![Legend Item Size](images/legend/item-size-razor.png)

## Paging for Legend

When the legend items exceed legend bounds, paging will be enabled by default. End user can view each legend item using the navigation buttons to navigate between pages.

{% aspTab template="chart/accumulation-charts/legend/paging", sourceFiles="paging.razor" %}

{% endaspTab %}

![Paging for Legend](images/legend/paging-razor.png)

> Refer to our [`Blazor Charts`](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations and also explore our [`Blazor Accumulation Chart Example`](https://blazor.syncfusion.com/demos/chart/pie?theme=bootstrap4) to know various features of accumulation charts and how it is used to represent numeric proportional data.

* [Grouping](./grouping/)
* [Datalabel](./data-label/)