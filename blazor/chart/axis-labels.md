---
layout: post
title: Axis Labels in Blazor Charts component | Syncfusion
description: Learn here all about Axis Labels of Syncfusion Charts (SfCharts) component and more.
platform: Blazor
control: Chart
documentation: ug
---

# Axis Labels in Blazor Charts (SfCharts)

## Smart Axis Labels

When the axis labels overlap, the [`LabelIntersectAction`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCommonAxis.html#Syncfusion_Blazor_Charts_ChartCommonAxis_LabelIntersectAction) property in the axis may be used to intelligently arrange them.

When [`LabelIntersectAction`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCommonAxis.html#Syncfusion_Blazor_Charts_ChartCommonAxis_LabelIntersectAction) is set to **Hide**,

{% aspTab template="chart/axis/multiple/hide", sourceFiles="hide.razor" %}

{% endaspTab %}

![Hide](images/axis-labels/hide.png)

When [`LabelIntersectAction`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCommonAxis.html#Syncfusion_Blazor_Charts_ChartCommonAxis_LabelIntersectAction) is set to **Rotate45**

{% aspTab template="chart/axis/multiple/rotate45", sourceFiles="rotate45.razor" %}

{% endaspTab %}

![Rotate45](images/axis-labels/rotate45.png)

When [`LabelIntersectAction`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCommonAxis.html#Syncfusion_Blazor_Charts_ChartCommonAxis_LabelIntersectAction) is set to **Rotate90**

{% aspTab template="chart/axis/multiple/rotate90", sourceFiles="rotate90.razor" %}

{% endaspTab %}

![Rotate90](images/axis-labels/rotate90.png)

## Axis Labels Positioning

The axis labels can be put **Outside** of the axis line by default, however the [`LabelPosition`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCommonAxis.html#Syncfusion_Blazor_Charts_ChartCommonAxis_LabelPosition) property may also be used to position them **Inside** the axis line.

{% aspTab template="chart/axis/multiple/position", sourceFiles="position.razor" %}

{% endaspTab %}

![Axis Labels Positioning](images/axis-labels/position.png)

## Multilevel Labels

The [`MultiLevelLabels`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCommonAxis.html#Syncfusion_Blazor_Charts_ChartCommonAxis_MultiLevelLabels) property allows you to add any number of layers of labels to the axis. The following properties can be used to configure this property.

### Categories

The [`Start`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCategory.html#Syncfusion_Blazor_Charts_ChartCategory_Start), [`End`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCategory.html#Syncfusion_Blazor_Charts_ChartCategory_End), [`Text`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCategory.html#Syncfusion_Blazor_Charts_ChartCategory_Text), and [`MaximumTextWidth`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCategory.html#Syncfusion_Blazor_Charts_ChartCategory_MaximumTextWidth) of multilevel labels can be customized using the [`Categories`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartMultiLevelLabel.html#Syncfusion_Blazor_Charts_ChartMultiLevelLabel_Categories).

{% aspTab template="chart/axis/multiple/multi-category", sourceFiles="categorys.razor" %}

{% endaspTab %}

![Axis Labels Positioning](images/axis-labels/categories.png)

### Overflow

[`Trim`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.TextOverflow.html#Syncfusion_Blazor_Charts_TextOverflow_Trim) or [`Wrap`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.TextOverflow.html#Syncfusion_Blazor_Charts_TextOverflow_Wrap) the multilevel labels using the [`Overflow`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartMultiLevelLabel.html#Syncfusion_Blazor_Charts_ChartMultiLevelLabel_Overflow) property.

{% aspTab template="chart/axis/multiple/multi-overflow", sourceFiles="overflows.razor" %}

{% endaspTab %}

![Axis Labels Positioning](images/axis-labels/overflow.png)

### Alignment

The [`Alignment`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartMultiLevelLabel.html#Syncfusion_Blazor_Charts_ChartMultiLevelLabel_Alignment) property provides option to position the multilevel labels at `Far`, `Center`, or `Near`.

The [`Alignment`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartMultiLevelLabel.html#Syncfusion_Blazor_Charts_ChartMultiLevelLabel_Alignment) property allows to place multilevel labels in a [`Far`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.Alignment.html#Syncfusion_Blazor_Charts_Alignment_Far), [`Center`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.Alignment.html#Syncfusion_Blazor_Charts_Alignment_Center), or [`Near`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.Alignment.html#Syncfusion_Blazor_Charts_Alignment_Near) location.

{% aspTab template="chart/axis/multiple/multi-alignment", sourceFiles="alignments.razor" %}

{% endaspTab %}

![Axis Labels Positioning](images/axis-labels/alignment.png)

### Text customization

The [`Size`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartAxisMultiLevelLabelTextStyle.html#Syncfusion_Blazor_Charts_ChartAxisMultiLevelLabelTextStyle_Size), [`Color`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartAxisMultiLevelLabelTextStyle.html#Syncfusion_Blazor_Charts_ChartAxisMultiLevelLabelTextStyle_Color), [`FontFamily`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCommonFont.html#Syncfusion_Blazor_Charts_ChartCommonFont_FontFamily), [`FontWeight`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCommonFont.html#Syncfusion_Blazor_Charts_ChartCommonFont_FontWeight), [`FontStyle`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCommonFont.html#Syncfusion_Blazor_Charts_ChartCommonFont_FontStyle), [`Opacity`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCommonFont.html#Syncfusion_Blazor_Charts_ChartCommonFont_Opacity), [`TextAlignment`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCommonFont.html#Syncfusion_Blazor_Charts_ChartCommonFont_TextAlignment) and [`TextOverflow`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCommonFont.html#Syncfusion_Blazor_Charts_ChartCommonFont_TextOverflow) may all be customized using the [`TextStyle`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartMultiLevelLabel.html#Syncfusion_Blazor_Charts_ChartMultiLevelLabel_TextStyle) property of multilevel labels.

{% aspTab template="chart/axis/multiple/multi-textcustom", sourceFiles="text-customs.razor" %}

{% endaspTab %}

![Axis Labels Positioning](images/axis-labels/textcustom.png)

### Border customization

The [`Width`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCommonLabelBorder.html#Syncfusion_Blazor_Charts_ChartCommonLabelBorder_Width), [`Color`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCommonLabelBorder.html#Syncfusion_Blazor_Charts_ChartCommonLabelBorder_Color), and [`Type`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCommonLabelBorder.html#Syncfusion_Blazor_Charts_ChartCommonLabelBorder_Type) of the border using the [`Border`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartMultiLevelLabel.html#Syncfusion_Blazor_Charts_ChartMultiLevelLabel_Border) can be changed. [`Rectangle`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BorderType.html#Syncfusion_Blazor_Charts_BorderType_Rectangle), [`Brace`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BorderType.html#Syncfusion_Blazor_Charts_BorderType_Brace), [`WithoutBorder`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BorderType.html#Syncfusion_Blazor_Charts_BorderType_WithoutBorder), [`WithoutTopBorder`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BorderType.html#Syncfusion_Blazor_Charts_BorderType_WithoutTopBorder), [`WithoutTopandBottomBorder`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BorderType.html#Syncfusion_Blazor_Charts_BorderType_WithoutTopandBottomBorder), [`Auto`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BorderType.html#Syncfusion_Blazor_Charts_BorderType_Auto), and [`CurlyBrace`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BorderType.html#Syncfusion_Blazor_Charts_BorderType_CurlyBrace) are the different types of borders.

{% aspTab template="chart/axis/multiple/multi-bordercustom", sourceFiles="border-customs.razor" %}

{% endaspTab %}

![Axis Labels Positioning](images/axis-labels/border-custom.png)

## Edge Label Placement

Long text labels at the axes' edges may display partially in the chart. To avoid this, utilise the axis' [`EdgeLabelPlacement`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCommonAxis.html#Syncfusion_Blazor_Charts_ChartCommonAxis_EdgeLabelPlacement) property, which moves or hides the label within the chart area for a better appearance using the [`Shift`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.EdgeLabelPlacement.html#Syncfusion_Blazor_Charts_EdgeLabelPlacement_Shift), [`Hide`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.EdgeLabelPlacement.html#Syncfusion_Blazor_Charts_EdgeLabelPlacement_Hide) Options. [`None`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.EdgeLabelPlacement.html#Syncfusion_Blazor_Charts_EdgeLabelPlacement_None) will leave the text as it is.

{% aspTab template="chart/axis/multiple/edge", sourceFiles="edge.razor" %}

{% endaspTab %}

## Labels Customization

An axis' [`LabelStyle`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartMultiLevelLabel.html#Syncfusion_Blazor_Charts_ChartMultiLevelLabel_TextStyle) property allows you to change the [`Colour`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartAxisMultiLevelLabelTextStyle.html#Syncfusion_Blazor_Charts_ChartAxisMultiLevelLabelTextStyle_Color) and [`Size`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartAxisMultiLevelLabelTextStyle.html#Syncfusion_Blazor_Charts_ChartAxisMultiLevelLabelTextStyle_Size) of the axis labels.

{% aspTab template="chart/axis/multiple/labels-custom", sourceFiles="labels-custom.razor" %}

{% endaspTab %}

## Label Trim

The label may be trimmed with [`EnableTrim`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCommonAxis.html#Syncfusion_Blazor_Charts_ChartCommonAxis_EnableTrim), and the width of the labels may be modified with the [`MaximumLabelWidth`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCommonAxis.html#Syncfusion_Blazor_Charts_ChartCommonAxis_MaximumLabelWidth) property in the axis; **34px** is the default value of [`MaximumLabelWidth`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCommonAxis.html#Syncfusion_Blazor_Charts_ChartCommonAxis_MaximumLabelWidth) property.

{% aspTab template="chart/axis/multiple/labels-trim", sourceFiles="labels-trim.razor" %}

{% endaspTab %}

![Trim using maximum label width](images/axis-labels/labels-trim.png)

## Line break

The <br> tag can used to separate the long axis label into multiple lines utilizing the line break functionality.

{% aspTab template="chart/axis/multiple/line-break", sourceFiles="line-break.razor" %}

{% endaspTab %}

![Line break support](images/axis-labels/line-break.png)

## Label Format

Learn more about axis label format in relation to axis types from the pages below.

* [Numeric Label Format](./numeric-axis#label-format)
* [DateTime Label Format](./date-time-axis#label-format)
* [Custom Label Format](./date-time-axis#custom-label-format)

> Refer to our [`Blazor Charts`](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations and also explore our [`Blazor Chart example`](https://blazor.syncfusion.com/demos/chart/line?theme=bootstrap4) to know various chart types and how to represent time-dependent data, showing trends at equal intervals.

## See Also

* [Data Label](./data-labels)
* [Tooltip](./tool-tip)
* [Marker](./data-markers)