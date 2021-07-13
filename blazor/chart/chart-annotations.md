---
layout: post
title: Chart Annotations in Blazor Chart Component | Syncfusion 
description: Learn about Chart Annotations in Blazor Chart component of Syncfusion, and more details.
platform: Blazor
control: Chart
documentation: ug
---

---
title: "Annotation in Blazor Charts component | Syncfusion"

component: "Charts"

description: "Learn here all about Annotation of Syncfusion Charts (SfCharts) component and more."
---

# Annotation in Blazor Charts (SfCharts)

Annotations are texts, shapes, or images that are used to highlight a specific region of interest in a chart.

The [`ChartAnnotations`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartAnnotations.html) property allows to add annotations to the chart. Specify the id of the element that needs to be displayed in the chart area by using the [`Content`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartAnnotation.html#Syncfusion_Blazor_Charts_ChartAnnotation_Content) property of annotation.

{% aspTab template="chart/series/column/annotation", sourceFiles="annotation.razor" %}

{% endaspTab %}

![Annotation](images/annotation/annotation-razor.png)

## Region

The [`Region`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartAnnotation.html#Syncfusion_Blazor_Charts_ChartAnnotation_Region) property can be used to insert annotations in relation to a series or a chart. It is positioned with respect to [`Chart`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.Regions.html#Syncfusion_Blazor_Charts_Regions_Chart) by default.

{% aspTab template="chart/series/column/region", sourceFiles="region.razor" %}

{% endaspTab %}

![Region](images/annotation/region-razor.png)

## Co-ordinate Units

[`CoordinateUnits`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartAnnotation.html#Syncfusion_Blazor_Charts_ChartAnnotation_CoordinateUnits) allows you to specify the annotation's coordinate units in either [`Pixel`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.Units.html#Syncfusion_Blazor_Charts_Units_Pixel) or [`Point`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.Units.html#Syncfusion_Blazor_Charts_Units_Point).

{% aspTab template="chart/series/column/co-ordinate", sourceFiles="co-ordinate.razor" %}

{% endaspTab %}

![Co-ordinate Unit](images/annotation/co-ordinate-razor.png)

> Refer to our [`Blazor Charts`](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations and also explore our [`Blazor Chart example`](https://blazor.syncfusion.com/demos/chart/line?theme=bootstrap4) to know various chart types and how to represent time-dependent data, showing trends at equal intervals.

## See Also

* [Tooltip](./tool-tip)
* [Legend](./legend)