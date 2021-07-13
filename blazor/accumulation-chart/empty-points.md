# Empty Points

Data points that contains `NaN` value are considered as empty points. The empty data points
can be ignored or not plotted in the chart. You can customize those points, using the [`EmptyPointSettings`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartSeries.html#Syncfusion_Blazor_Charts_AccumulationChartSeries_EmptyPointSettings) property in
series. The default mode of the empty point is `Gap`. Other supported modes are `Average` and `Zero`.

{% aspTab template="chart/accumulation-charts/empty-points/empty", sourceFiles="empty.razor" %}

{% endaspTab %}

![Empty Points](images/pie-dough-nut/empty.png)

## Customization

Specific color for an empty point can be set by using the [`Fill`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartEmptyPointSettings.html#Syncfusion_Blazor_Charts_AccumulationChartEmptyPointSettings_Fill) property in [`EmptyPointSettings`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartSeries.html#Syncfusion_Blazor_Charts_AccumulationChartSeries_EmptyPointSettings) and the
border for an empty point can be set by using the [`Border`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartEmptyPointSettings.html#Syncfusion_Blazor_Charts_AccumulationChartEmptyPointSettings_Border) property.

{% aspTab template="chart/accumulation-charts/empty-points/custom", sourceFiles="custom.razor" %}

{% endaspTab %}