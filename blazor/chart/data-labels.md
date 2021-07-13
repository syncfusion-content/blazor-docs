---
layout: post
title: Data Labels in Blazor Chart Component | Syncfusion 
description: Learn about Data Labels in Blazor Chart component of Syncfusion, and more details.
platform: Blazor
control: Chart
documentation: ug
---

# Data Labels

Data label can be added to a chart series by enabling the [`Visible`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartDataLabel.html#Syncfusion_Blazor_Charts_ChartDataLabel_Visible) option in the data label. By default, the labels will arrange smartly without overlapping.

{% aspTab template="chart/datalabels/datalabel", sourceFiles="datalabel.razor" %}

{% endaspTab %}

![Data Labels](images/data-label/datalabel-razor.png)

## Position

Using [`Position`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartDataLabel.html#Syncfusion_Blazor_Charts_ChartDataLabel_Position) property, you can place the label either on `Top`, `Middle`, `Bottom` or `Outer`.

{% aspTab template="chart/datalabels/position", sourceFiles="position.razor" %}

{% endaspTab %}

![Position](images/data-label/position-razor.png)

>Note: The position `Outer` is applicable for column and bar type series.

## Data label template

Label content can be formatted by using the [`Template`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartDataLabel.html#Syncfusion_Blazor_Charts_ChartDataLabel_Template) option. Inside the template, you can add the placeholder text `${point.x}` and `${point.y}` to display corresponding data point value.

## Text Mapping

Text from the data source can be mapped to data label using [`Name`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartDataLabel.html#Syncfusion_Blazor_Charts_ChartDataLabel_Name) property.

{% aspTab template="chart/datalabels/mapping", sourceFiles="mapping.razor" %}

{% endaspTab %}

![Text Mapping](images/data-label/mapping-razor.png)

## Margin

[`Margin`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartDataLabel.html#Syncfusion_Blazor_Charts_ChartDataLabel_Margin) can be applied to the data label to create space around the element.

{% aspTab template="chart/datalabels/margin", sourceFiles="margin.razor" %}

{% endaspTab %}

![Margin](images/data-label/margin-razor.png)

## Customization

Data label can be further customized using [`Fill`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartDataLabel.html#Syncfusion_Blazor_Charts_ChartDataLabel_Fill) and [`Border`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartDataLabel.html#Syncfusion_Blazor_Charts_ChartDataLabel_Border) properties. Rounded corners can be customized using [`Rx`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartDataLabel.html#Syncfusion_Blazor_Charts_ChartDataLabel_Rx) and [`Ry`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartDataLabel.html#Syncfusion_Blazor_Charts_ChartDataLabel_Ry) properties. Rx and Ry properties requires `Border` values not to be null.

{% aspTab template="chart/datalabels/custom", sourceFiles="custom.razor" %}

{% endaspTab %}

![Customization](images/data-label/custom-razor.png)

> Note: You can refer to our [`Blazor Charts`](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations. You can also explore our [`Blazor Chart example`](https://blazor.syncfusion.com/demos/chart/line?theme=bootstrap4) to knows various chart types and how to represent time-dependent data, showing trends in data at equal intervals.

## See Also

* [Tooltip](./tool-tip)
* [Legend](./legend)