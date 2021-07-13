# Axis Customization

<!-- markdownlint-disable MD034 -->

## Title

You can add a title to the axis using [Title](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartModel.html#Syncfusion_Blazor_Charts_StockChartModel_Title) property to provide quick
information to the user about the data plotted in the axis. Title style can be customized using [`TitleStyle`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartModel.html#Syncfusion_Blazor_Charts_StockChartModel_TitleStyle) property of the axis.

{% aspTab template="stock-chart/axis/category/title", sourceFiles="title.razor" %}

{% endaspTab %}

![Title](images/common/title.png)

## Tick Lines Customization

You can customize the  `Width`, `Color` and `Size` of the minor and major tick lines, using
[`MajorTickLines`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartAxis.html#Syncfusion_Blazor_Charts_StockChartAxis_MajorTickLines) and
[`MinorTickLines`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartAxis.html#Syncfusion_Blazor_Charts_StockChartAxis_MinorTickLines) properties in the axis.

{% aspTab template="stock-chart/axis/category/tick", sourceFiles="tick.razor" %}

{% endaspTab %}

![Tick Lines](images/common/ticklines.png)

## Grid Lines Customization

You can customize the  `Width`, `Color` and `DashArray` of the minor and major grid lines, using
[`MajorGridLines`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor~Syncfusion.Blazor.Charts.AxisModel~MajorGridLines.html) and
[`MinorGridLines`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor~Syncfusion.Blazor.Charts.AxisModel~MinorGridLines.html) properties in the axis.

{% aspTab template="stock-chart/axis/category/grid", sourceFiles="grid.razor" %}

{% endaspTab %}

![Grid Lines](images/common/gridlines.png)

## Multiple Axis

In addition to primary X and Y axis, we can add n number of axis to the chart. Series can be associated with
this [Axis](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartAxis.html), by mapping with axis's unique name.

{% aspTab template="stock-chart/axis/category/multiple", sourceFiles="multiple.razor" %}

{% endaspTab %}

![Multiple Axis](images/common/multiple-axis.png)

## Inversed Axis

<!-- markdownlint-disable MD033 -->

When an axis is inversed, highest value of the axis comes closer to origin and vice versa. To place an axis in inversed manner set this property
 [`IsInversed`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartAxis.html#Syncfusion_Blazor_Charts_StockChartAxis_IsInversed) to true.

 {% aspTab template="stock-chart/axis/category/inversed", sourceFiles="inversed.razor" %}

{% endaspTab %}

![Inversed Axis](images/common/inversed-axis.png)

## Opposed Position

To place an axis opposite from its original position, set
 [`OpposedPosition`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartAxis.html#Syncfusion_Blazor_Charts_StockChartAxis_OpposedPosition) to true.

 {% aspTab template="stock-chart/axis/category/opposed", sourceFiles="opposed.razor" %}

{% endaspTab %}

![Opposed Position](images/common/opposed.png)