---
title: "Annotation in Blazor Accumulation Charts component | Syncfusion"

component: "Accumulation Charts"

description: "Learn here all about Annotation of Syncfusion Accumulation Charts (SfAccumulationChart) component and more."
---

# Annotation

Annotations are texts, shapes, or images that are used to highlight a specific region of interest in a chart. The [`AccumulationChartAnnotation`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartAnnotation.html) property allows to add annotations to the chart. Specify the element that needs to be displayed in the accumulation chart area by using the [`Content`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartAnnotation.html#Syncfusion_Blazor_Charts_AccumulationChartAnnotation_Content) property of the annotation.

{% aspTab template="chart/accumulation-charts/annotation/annotation", sourceFiles="annotation.razor" %}

{% endaspTab %}

![Annotation](images/annotation/annotation-razor.png)

## Region

The [`Region`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartAnnotation.html#Syncfusion_Blazor_Charts_AccumulationChartAnnotation_Region) property can be used to insert annotations in relation to a series or a chart. By default, it is positioned with respect to a [`Accumulation Chart`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.Regions.html#Syncfusion_Blazor_Charts_Regions_Chart).

{% aspTab template="chart/accumulation-charts/annotation/region", sourceFiles="region.razor" %}

{% endaspTab %}

![Region](images/annotation/region-razor.png)

## Co-ordinate Units

The [`CoordinateUnits`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartAnnotation.html#Syncfusion_Blazor_Charts_AccumulationChartAnnotation_CoordinateUnits) property allows to specify the annotation's coordinate units either in [`Pixel`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.Units.html#Syncfusion_Blazor_Charts_Units_Pixel) or [`Point`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.Units.html#Syncfusion_Blazor_Charts_Units_Point).

{% aspTab template="chart/accumulation-charts/annotation/co-ordinate", sourceFiles="co-ordinate.razor" %}

{% endaspTab %}

![Co-ordinate Units](images/annotation/co-ordinate-razor.png)

> Refer to our [`Blazor Charts`](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations and also explore our [`Blazor Accumulation Chart Example`](https://blazor.syncfusion.com/demos/chart/pie?theme=bootstrap4) to know various features of accumulation charts and how it is used to represent numeric proportional data.

## See Also

* [Data Label](./data-labels)
* [Tooltip](./tool-tip)
* [Legend](./legend)