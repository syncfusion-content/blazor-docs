# Events

In this section, we have provided a list of chart component events that will be triggered for appropriate chart actions.

The events should be provided to the chart using [`ChartEvents`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html) component.

> From `v18.4.*`, we have added few additional events for the chart component

Event Name|
-----|
[OnZoomStart](events/#onzoomstart)|
[OnZoomEnd](events/#onzoomend)|
[OnLegendItemRender](events/#onlegenditemrender)|
[OnDataLabelRender](events/#ondatalabelrender)|
[OnPointRender](events/#onpointrender)|
[OnAxisLabelRender](events/#onaxislabelrender)|
[OnAxisLabelClick](events/#onaxislabelclick)|
[OnAxisActualRangeCalculated](events/#onaxisactualrangecalculated)|
[OnAxisMultiLevelLabelRender](events/#onaxismultilevellabelrender)|

> From `v18.4.*`, some event names are different from the previous releases. The following are the event name changes from `v18.3.*` to `v18.4.*`

Event Name(`v18.3.*`) |Event Name(`v18.4.*`)
-----|-----
Resized |[SizeChanged](events/#sizechanged)
ScrollChanged |[OnScrollChanged](events/#onscrollchanged)
OnScrollEnd |[OnScrollChanged](events/#onscrollchanged)
OnScrollStart |[OnScrollChanged](events/#onscrollchanged)
AfterExport |[OnExportComplete](events/#onexportcomplete)
OnPrint | [OnPrintComplete](events/#onprintcomplete)
DragStart |[OnDataEdit](events/#ondataedit)
DragEnd |[OnDataEditCompleted](events/#ondataeditcompleted)
LegendClick |[OnLegendClick](events/#onlegendclick)
MultiLevelLabelClick |[OnMultiLevelLabelClick](events/#onmultilevellabelclick)
OnSelectionComplete |[OnSelectionChanged](events/#onselectionchanged)
OnDragComplete |[OnSelectionChanged](events/#onselectionchanged)

> From `v18.4.*`, We have removed the following previous release events from chart component

Event Name|
-----|
OnAnimationComplete|
OnChartMouseClick|
OnChartMouseDown|
OnChartMouseLeave|
OnChartMouseMove|
OnChartMouseUp|
PointMoved|
BeforeExport|
Load|
OnPointDoubleClick|
PointMoved|

## OnZoomStart

After the zoom selection is made, the [`OnZoomStart`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_OnZoomStart) event is triggered.

{% aspTab template="chart/events", sourceFiles="zoomstart.razor" %}

{% endaspTab %}

## OnZoomEnd

[`OnZoomEnd`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_OnZoomEnd) event triggers, after the zoom selection is completed.

{% aspTab template="chart/events", sourceFiles="zoomend.razor" %}

{% endaspTab %}

## OnLegendItemRender

[`OnLegendItemRender`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_OnLegendItemRender) event triggers,before the legend is rendered.

{% aspTab template="chart/events", sourceFiles="legendrender.razor" %}

{% endaspTab %}

## OnDataLabelRender

[`OnDataLabelRender`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_OnDataLabelRender) event triggers, before the data label for series is rendered.

{% aspTab template="chart/events", sourceFiles="datalabelrender.razor" %}

{% endaspTab %}

## OnPointRender

[`OnPointRender`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_OnPointRender) event triggers, before each points for the series is rendered.

{% aspTab template="chart/events", sourceFiles="pointrender.razor" %}

{% endaspTab %}

## OnAxisLabelRender

[`OnAxisLabelRender`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_OnAxisLabelRender) event triggers, before each axis label is rendered.

{% aspTab template="chart/events", sourceFiles="axislabelrender.razor" %}

{% endaspTab %}

## OnAxisLabelClick

[`OnAxisLabelClick`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_OnAxisLabelClick) event triggers, when x axis label is clicked.

{% aspTab template="chart/events", sourceFiles="axislabelclick.razor" %}

{% endaspTab %}

## OnAxisActualRangeCalculated

[`OnAxisActualRangeCalculated`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_OnAxisActualRangeCalculated) event triggers, before each axis range is calculated.

{% aspTab template="chart/events", sourceFiles="axisactualrange.razor" %}

{% endaspTab %}

## OnAxisMultiLevelLabelRender

[`OnAxisMultiLevelLabelRender`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_OnAxisMultiLevelLabelRender) event triggers, while rendering multilevellabels.

{% aspTab template="chart/events", sourceFiles="axismultilabel.razor" %}

{% endaspTab %}

## SizeChanged

[`SizeChanged`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_SizeChanged) event triggers after resizing of chart.

{% aspTab template="chart/events", sourceFiles="sizechanged.razor" %}

{% endaspTab %}

## OnScrollChanged

[`OnScrollChanged`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_OnScrollChanged) event triggers while scrolling the chart.

{% aspTab template="chart/events", sourceFiles="scrollchanged.razor" %}

{% endaspTab %}

## OnExportComplete

[`OnExportComplete`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_OnExportComplete) event triggers after exporting the chart.

{% aspTab template="chart/events", sourceFiles="exportcomplete.razor" %}

{% endaspTab %}

## OnPrintComplete

`OnPrintComplete` event triggers after printing the chart.

{% aspTab template="chart/events", sourceFiles="printcomplete.razor" %}

{% endaspTab %}

## OnDataEdit

[`OnDataEdit`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_OnDataEdit) event triggers, while dragging the data point.

{% aspTab template="chart/events", sourceFiles="dataedit.razor" %}

{% endaspTab %}

## OnDataEditCompleted

[`OnDataEditCompleted`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_OnDataEditCompleted) event triggers  when the point drag completed.

{% aspTab template="chart/events", sourceFiles="dataeditcomplete.razor" %}

{% endaspTab %}

## OnLegendClick

[`OnLegendClick`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_OnLegendClick) event triggers after legend click.

{% aspTab template="chart/events", sourceFiles="legendclick.razor" %}

{% endaspTab %}

## OnMultiLevelLabelClick

[`OnMultiLevelLabelClick`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_OnMultiLevelLabelClick) event triggers after click on multilevellabelclick.

{% aspTab template="chart/events", sourceFiles="multilabelclick.razor" %}

{% endaspTab %}

## OnSelectionChanged

[`OnSelectionChanged`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_OnSelectionChanged) event triggers after the selection is completed.

{% aspTab template="chart/events", sourceFiles="selectionchanged.razor" %}

{% endaspTab %}

## Loaded

`Loaded` event triggers after chart load.

{% aspTab template="chart/events", sourceFiles="loaded.razor" %}

{% endaspTab %}

## OnPointClick

[`OnPointClick`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_OnPointClick) event triggers on point click.

{% aspTab template="chart/events", sourceFiles="pointclick.razor" %}

{% endaspTab %}

## TooltipRender

[`TooltipRender`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_TooltipRender) event triggers, before the tooltip for series is rendered.

{% aspTab template="chart/events", sourceFiles="tooltiprender.razor" %}

{% endaspTab %}

## SharedTooltipRender

[`SharedTooltipRender`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_SharedTooltipRender) event triggers, before the sharedtooltip for series is rendered.

{% aspTab template="chart/events", sourceFiles="sharedtooltiprender.razor" %}

{% endaspTab %}

## OnZooming

[`OnZooming`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_OnZooming) event triggers, after the zoom selection is completed.

{% aspTab template="chart/events", sourceFiles="zooming.razor" %}

{% endaspTab %}

> Note: You can refer to our [`Blazor Charts`](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations. You can also explore our [`Blazor Chart example`](https://blazor.syncfusion.com/demos/chart/line?theme=bootstrap4) to knows various chart types and how to represent time-dependent data, showing trends in data at equal intervals.