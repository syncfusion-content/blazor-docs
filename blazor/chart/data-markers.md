---
layout: post
title: Data Markers in Blazor Chart Component | Syncfusion 
description: Learn about Data Markers in Blazor Chart component of Syncfusion, and more details.
platform: Blazor
control: Chart
documentation: ug
---

# Data Markers

Data markers are used to provide information about the data points in the series. You can add a shape to adorn each data point.

<!-- markdownlint-disable MD036 -->

## Marker

<!-- markdownlint-disable MD036 -->

Markers can be added to the points by enabling the [`Visible`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor~Syncfusion.Blazor.Charts.ChartMarker~Visible.html)
option of the marker property.

{% aspTab template="chart/data-marker/marker", sourceFiles="marker.razor" %}

{% endaspTab %}

![Marker](images/marker/marker-razor.png)

## Shape

Markers can be assigned with different shapes such as Rectangle, Circle, Diamond etc using the [`Shape`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCommonMarker.html#Syncfusion_Blazor_Charts_ChartCommonMarker_Shape) property.

{% aspTab template="chart/data-marker/shape", sourceFiles="shape.razor" %}

{% endaspTab %}

![Shape](images/marker/shape-razor.png)

## Images

Apart from the shapes, you can also add custom images to mark the data point using the
[`ImageUrl`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCommonMarker.html#Syncfusion_Blazor_Charts_ChartCommonMarker_ImageUrl) property.

{% aspTab template="chart/data-marker/images", sourceFiles="images.razor" %}

{% endaspTab %}

## Customization

Marker color and border can be customized using [`Fill`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCommonMarker.html#Syncfusion_Blazor_Charts_ChartCommonMarker_Fill) and [`Border`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCommonMarker.html#Syncfusion_Blazor_Charts_ChartCommonMarker_Border) properties.

{% aspTab template="chart/data-marker/custom", sourceFiles="custom.razor" %}

{% endaspTab %}

![Customization](images/marker/custom-razor.png)

> Note: You can refer to our [`Blazor Charts`](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations. You can also explore our [`Blazor Chart example`](https://blazor.syncfusion.com/demos/chart/line?theme=bootstrap4) to knows various chart types and how to represent time-dependent data, showing trends in data at equal intervals.

## See Also

* [Tooltip](./tool-tip)
* [Legend](./legend)