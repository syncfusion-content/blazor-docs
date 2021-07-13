---
layout: post
title: Cross Hair in Blazor Stock Chart  Component | Syncfusion 
description: Learn about Cross Hair in Blazor Stock Chart  component of Syncfusion, and more details.
platform: Blazor
control: Stock Chart 
documentation: ug
---

# Add Crosshair

Crosshair has a vertical and horizontal line to view the value of the axis at mouse or touch position.

Crosshair lines can be enabled by using [`Enable`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartCrosshairSettings.html#Syncfusion_Blazor_Charts_StockChartCrosshairSettings_Enable)
property in the `Crosshair`.

{% aspTab template="stock-chart/user-interaction/crosshair-trackball/crosshair", sourceFiles="crosshair.razor" %}

{% endaspTab %}

![Crosshair](images/common/crosshair.png)

## Tooltip for axis

Tooltip label for an axis can be enabled by using [`Enable`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartCrosshairSettings.html#Syncfusion_Blazor_Charts_StockChartCrosshairSettings_Enable)
property of `CrosshairTooltip` in the corresponding axis.

{% aspTab template="stock-chart/user-interaction/crosshair-trackball/axis-tooltip", sourceFiles="axis-tooltip.razor" %}

{% endaspTab %}

![Crosshair Tooltip](images/common/crosshair-tooltip.png)

## Customization

The `Fill` and `TextStyle` property of the `CrosshairTooltip` is used to customize the background color and font style of the crosshair label respectively. Color and Width of the crosshair line can be customized by using the
[`Line`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartCrosshairSettings.html#Syncfusion_Blazor_Charts_StockChartCrosshairSettings_Line) property in the crosshair.

{% aspTab template="stock-chart/user-interaction/crosshair-trackball/custom", sourceFiles="custom.razor" %}

{% endaspTab %}

![Customization](images/common/crosshair-custom.png)

## Add Trackball

Trackball is used to track a data point closest to the mouse or touch position. Trackball marker indicates the closest point and trackball tooltip displays the information about the point.

Trackball can be enabled by setting the [`Enable`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartCrosshairSettings.html#Syncfusion_Blazor_Charts_StockChartCrosshairSettings_Enable) property of the crosshair to true and
`Shared` property in `Tooltip` to true in chart.

{% aspTab template="stock-chart/user-interaction/crosshair-trackball/trackball", sourceFiles="trackball.razor" %}

{% endaspTab %}

![Trackball](images/common/trackball.png)