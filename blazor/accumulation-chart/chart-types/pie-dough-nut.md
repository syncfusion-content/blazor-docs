# Pie & Doughnut

## Pie Chart

To render a pie series, use the series [`Type`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartSeries.html#Syncfusion_Blazor_Charts_AccumulationChartSeries_Type)
as `Pie`.

{% aspTab template="chart/accumulation-charts/pie_doughnut/pie", sourceFiles="pie.razor" %}

{% endaspTab %}

![Pie Chart](../images/pie-dough-nut/pie-razor.png)

> Note: You can refer to our [`Blazor Pie Chart`](https://www.syncfusion.com/blazor-components/blazor-charts/chart-types/pie-chart) feature tour page to know about its other groundbreaking feature representations. You can also explore our [`Blazor Pie Chart example`](https://blazor.syncfusion.com/demos/chart/pie) to knows how to render and configure the pie chart.

## Radius Customization

By default, radius of the pie series will be 80% of the size (minimum of chart width and height).
You can customize this using [`Radius`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartSeries.html#Syncfusion_Blazor_Charts_AccumulationChartSeries_Radius)
property of the series.

{% aspTab template="chart/accumulation-charts/pie_doughnut/radius", sourceFiles="radius.razor" %}

{% endaspTab %}

![Radius Customization](../images/pie-dough-nut/radius-razor.png)

## Pie Center

The center position of the pie can be changed by center x and center y. By default, center x and center y of the pie series are 50%. You can customize this using [`Center`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartModel.html#Syncfusion_Blazor_Charts_AccumulationChartModel_Center) property of the series.

{% aspTab template="chart/accumulation-charts/pie_doughnut/piecenter", sourceFiles="piecenter.razor" %}

{% endaspTab %}

![Pie Center](../images/pie-dough-nut/piecenter-razor.png)

## Various Radius Pie Chart

You can use radius mapping to render the slice with different [`Radius`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartSeries.html#Syncfusion_Blazor_Charts_AccumulationChartSeries_Radius) and also use border, fill properties to customize the point.

{% aspTab template="chart/accumulation-charts/pie_doughnut/various-radius", sourceFiles="various-radius.razor" %}

{% endaspTab %}

![Various Radius Pie Chart](../images/pie-dough-nut/various-radius-razor.png)

## Doughnut Chart

To achieve a Doughnut Chart in pie series, customize the [`InnerRadius`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartSeries.html#Syncfusion_Blazor_Charts_AccumulationChartSeries_InnerRadius) property of the series. By setting value greater than 0%, a doughnut will appear.
The InnerRadius property takes value from 0 to 100% of the pie radius.

{% aspTab template="chart/accumulation-charts/pie_doughnut/doughnut", sourceFiles="doughnut.razor" %}

{% endaspTab %}

![Doughnut Chart](../images/pie-dough-nut/doughnut-razor.png)

> Note: You can also explore our [`Blazor Doughnut Chart`](https://blazor.syncfusion.com/demos/chart/donut) example to knows how to render and configure the doughnut charts.

## Start and End angles

You can customize the start and end angle of the pie series using the
[`StartAngle`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartSeries.html#Syncfusion_Blazor_Charts_AccumulationChartSeries_StartAngle) and
[`EndAngle`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartSeries.html#Syncfusion_Blazor_Charts_AccumulationChartSeries_EndAngle)
properties. The default value of  StartAngle is 0 degree, and EndAngle is 360 degrees. By customizing this,
you can achieve a semi pie series.

{% aspTab template="chart/accumulation-charts/pie_doughnut/start-angle", sourceFiles="start-angle.razor" %}

{% endaspTab %}

![Start and End angles](../images/pie-dough-nut/start-angle-razor.png)

## Color and Text Mapping

The fill color and the text in the data source can be mapped to the chart using [`PointColorMapping`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartSeries.html#Syncfusion_Blazor_Charts_AccumulationChartSeries_PointColorMapping) in series and [`Name`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationDataLabelSettings.html#Syncfusion_Blazor_Charts_AccumulationDataLabelSettings_Name) in datalabel respectively.

{% aspTab template="chart/accumulation-charts/pie_doughnut/map", sourceFiles="map.razor" %}

{% endaspTab %}

![Color Mapping](../images/pie-dough-nut/map-razor.png)

## Hide pie or doughnut border

By default, the border will appear in the pie/doughnut chart while mouse hover on the chart. You can disable the the border by setting [`EnableBorderOnMouseMove`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfAccumulationChart.html#Syncfusion_Blazor_Charts_SfAccumulationChart_EnableBorderOnMouseMove)
property is **false**.

{% aspTab template="chart/accumulation-charts/pie_doughnut/boder", sourceFiles="boder.razor" %}

{% endaspTab %}

![Pie Chart](../images/pie-dough-nut/pie-razor.png)

## See Also

* [Data label](../data-label/)
* [Grouping](../grouping/)