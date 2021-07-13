---
layout: post
title: Tool Tip in Blazor Stock Chart  Component | Syncfusion 
description: Learn about Tool Tip in Blazor Stock Chart  component of Syncfusion, and more details.
platform: Blazor
control: Stock Chart 
documentation: ug
---

# Tooltip

<!-- markdownlint-disable MD036 -->

Stock Chart will display details about the points through tooltip, when the mouse is moved over the point.

## Default Tooltip

By default, tooltip is not visible. Enable the tooltip by setting
[`Enable`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartTooltipSettings.html#Syncfusion_Blazor_Charts_StockChartTooltipSettings_Enable) property to true .

{% aspTab template="stock-chart/stockchart-feature/tooltip", sourceFiles="tooltip.razor" %}

{% endaspTab %}

![Tooltip](images/common/tooltip.png)

<!-- markdownlint-disable MD013 -->

## Format the Tooltip

<!-- markdownlint-disable MD013 -->

By default, tooltip shows information of x and y value in points. In addition to that, you can show more information in tooltip. For example the format `${point.x} : ${point.high}` shows point x and high value.

{% aspTab template="stock-chart/stockchart-feature/format", sourceFiles="format.razor" %}

{% endaspTab %}

## Customize the Appearance of Tooltip

The [`Fill`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartTooltipSettings.html#Syncfusion_Blazor_Charts_StockChartTooltipSettings_Fill) and [`Border`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartTooltipSettings.html#Syncfusion_Blazor_Charts_StockChartTooltipSettings_Border) properties are used to customize the background color and border of the tooltip respectively. The [`TextStyle`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartTooltipSettings.html#Syncfusion_Blazor_Charts_StockChartTooltipSettings_TextStyle) property in the tooltip is used to customize the font of the tooltip text.

{% aspTab template="stock-chart/stockchart-feature/customtooltip", sourceFiles="customtooltip.razor" %}

{% endaspTab %}

![Tooltip Customization](images/common/custom-tooltip.png)