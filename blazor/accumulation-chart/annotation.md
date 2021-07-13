---
layout: post
title: Annotation in Blazor Accumulation Chart Component | Syncfusion 
description: Learn about Annotation in Blazor Accumulation Chart component of Syncfusion, and more details.
platform: Blazor
control: Accumulation Chart
documentation: ug
---

# Annotation

Annotations are used to mark the specific area of interest in the chart with texts, shapes or images. By using the [`Content`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartAnnotation.html#Syncfusion_Blazor_Charts_AccumulationChartAnnotation_Content) option of annotation property, you can specify the Id of the HTML element that needs to be displayed in the chart.

{% aspTab template="chart/accumulation-charts/annotation/annotation", sourceFiles="annotation.razor" %}

{% endaspTab %}

![Annotation](images/annotation/annotation-razor.png)

## Region

The annotation can be placed with respect to `Series` or `Chart`.

{% aspTab template="chart/accumulation-charts/annotation/region", sourceFiles="region.razor" %}

{% endaspTab %}

![Region](images/annotation/region-razor.png)

## Co-ordinate Units

Specifies the [`CoordinateUnits`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartAnnotation.html#Syncfusion_Blazor_Charts_AccumulationChartAnnotation_CoordinateUnits) of an annotation either in `Pixel` or `Point`.

{% aspTab template="chart/accumulation-charts/annotation/co-ordinate", sourceFiles="co-ordinate.razor" %}

{% endaspTab %}

![Co-ordinate Units](images/annotation/co-ordinate-razor.png)