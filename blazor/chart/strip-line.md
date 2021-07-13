---
layout: post
title: Strip Line in Blazor Chart Component | Syncfusion 
description: Learn about Strip Line in Blazor Chart component of Syncfusion, and more details.
platform: Blazor
control: Chart
documentation: ug
---

<!-- markdownlint-disable MD036 -->

# Striplines

<!-- markdownlint-disable MD036 -->

Blazor chart supports horizontal and vertical strip lines and customization of stripline in both orientation.

## Horizontal Striplines

You can create horizontal stripline by adding the [`ChartStripline`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AxisModel.html#Syncfusion_Blazor_Charts_AxisModel_StripLines) in the vertical axis.
Striplines are rendered in the specified start to end range and you can add more than one stripline for an axis.

{% aspTab template="chart/axis/strip-line/horizontal", sourceFiles="horizontal.razor" %}

{% endaspTab %}

![Horizontal Strip lines](images/strip-line/horizontal.png)

## Vertical Striplines

You can create vertical stripline by adding the [`ChartStripline`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AxisModel.html#Syncfusion_Blazor_Charts_AxisModel_StripLines) in the horizontal axis. Striplines are rendered in the specified start to end range and you can add more than one stripline for an axis.

{% aspTab template="chart/axis/strip-line/vertical", sourceFiles="vertical.razor" %}

{% endaspTab %}

![Vertical Striplines](images/strip-line/vertical.png)

## Customize the strip line

Starting value in specific strip line can be customized by [`Start`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCommonStripLines.html#Syncfusion_Blazor_Charts_ChartCommonStripLines_Start) property in strip line. Similarly, end value
is customized by [`End`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCommonStripLines.html#Syncfusion_Blazor_Charts_ChartCommonStripLines_End).
Size and border of the strip line can be customized by [`Size`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCommonStripLines.html#Syncfusion_Blazor_Charts_ChartCommonStripLines_Size) and  [`Border`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCommonStripLines.html#Syncfusion_Blazor_Charts_ChartCommonStripLines_Border) properties.
Order of the strip line such that whether it should be rendered  behind or over the series elements
can be customized by [`ZIndex`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCommonStripLines.html#Syncfusion_Blazor_Charts_ChartCommonStripLines_ZIndex) property.

{% aspTab template="chart/axis/strip-line/custom-stripline", sourceFiles="custom-stripline.razor" %}

{% endaspTab %}

![Customize the strip line](images/strip-line/custom-stripline.png)

## Customize the stripline text

You can customize and rotate the text rendered in stripline by [`TextStyle`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCommonStripLines.html#Syncfusion_Blazor_Charts_ChartCommonStripLines_TextStyle) and [`Rotation`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartStripLine.html) properties.
Horizontal and Vertical alignment of stripline text can be customized by [`HorizontalAlignment`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCommonStripLines.html#Syncfusion_Blazor_Charts_ChartCommonStripLines_HorizontalAlignment) and [`VerticalAlignment`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCommonStripLines.html#Syncfusion_Blazor_Charts_ChartCommonStripLines_VerticalAlignment) property.

{% aspTab template="chart/axis/strip-line/custom-striptext", sourceFiles="custom-striptext.razor" %}

{% endaspTab %}

![Customize the strip line](images/strip-line/custom-striptext.png)

> Note: You can refer to our [`Blazor Charts`](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations. You can also explore our [`Blazor Chart example`](https://blazor.syncfusion.com/demos/chart/line?theme=bootstrap4) to knows various chart types and how to represent time-dependent data, showing trends in data at equal intervals.

## See Also

* [Data label](./data-labels)
* [Tooltip](./tool-tip)
* [Marker](./data-markers)