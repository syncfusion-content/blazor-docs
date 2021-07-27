---
title: "Tooltip in Blazor Accumulation Charts component | Syncfusion"

component: "Accumulation Charts"

description: "Learn here all about Tooltip of Syncfusion Accumulation Charts (SfAccumulationChart) component and more."
---

# Tooltip

The [`Enable`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartTooltipSettings.html#Syncfusion_Blazor_Charts_AccumulationChartTooltipSettings_Enable) property in [`AccumulationChartTooltipSettings`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartTooltipSettings.html) can be set to **true** to enable the tooltip.

{% aspTab template="chart/accumulation-charts/tooltip/default", sourceFiles="default.razor" %}

{% endaspTab %}

![Tooltip](images/tool-tip/default-razor.png)

## Header

The [`Header`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartTooltipSettings.html#Syncfusion_Blazor_Charts_AccumulationChartTooltipSettings_Header) property in [`AccumulationChartTooltipSettings`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartTooltipSettings.html) can be used to specify the tooltip's header.

{% aspTab template="chart/accumulation-charts/tooltip/header", sourceFiles="header.razor" %}

{% endaspTab %}

![Header](images/tool-tip/header-razor.png)

## Tooltip Format

By default, tooltip shows information about x and y value in points. In addition, further customization can be done in the tooltip. For example the format `${point.x} : <b>${point.y}%</b>` shows point x value and customized point y value.

{% aspTab template="chart/accumulation-charts/tooltip/format", sourceFiles="format.razor" %}

{% endaspTab %}

![Tooltip Format](images/tool-tip/format-razor.png)

## Tooltip Customization 

The [`Fill`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartTooltipSettings.html#Syncfusion_Blazor_Charts_AccumulationChartTooltipSettings_Fill) and [`Border`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartTooltipSettings.html#Syncfusion_Blazor_Charts_AccumulationChartTooltipSettings_Border) properties are used to customize the background color and the border of the tooltip respectively. The [`TextStyle`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartTooltipSettings.html#Syncfusion_Blazor_Charts_AccumulationChartTooltipSettings_TextStyle) property in the tooltip is used to customize the font size of the tooltip text.

{% aspTab template="chart/accumulation-charts/tooltip/custom", sourceFiles="custom.razor" %}

{% endaspTab %}

![Tooltip Customization](images/tool-tip/custom-razor.png)

## Tooltip Text Mapping

By default, tooltip shows information of x and y value in points. In addition, by using the [`TooltipMappingName`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartSeries.html#Syncfusion_Blazor_Charts_AccumulationChartSeries_TooltipMappingName), more information from the datasource can be displayed in the tooltip. To display the specified tooltip content, **$point.tooltip** can be used as a placeholder.

{% aspTab template="chart/accumulation-charts/tooltip/mapping", sourceFiles="mapping.razor" %}

{% endaspTab %}

![mapping](images/tool-tip/mapping-razor.png)

> Refer to our [`Blazor Charts`](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations and also explore our [`Blazor Accumulation Chart Example`](https://blazor.syncfusion.com/demos/chart/pie?theme=bootstrap4) to know various features of accumulation charts and how it is used to represent numeric proportional data.

## See Also

* [Grouping](./grouping/)
* [Datalabel](./data-label/)