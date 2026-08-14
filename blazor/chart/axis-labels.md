---
layout: post
title: Blazor Charts Axis Labels Configuration | Syncfusion®
description: Learn how to configure axis labels in Syncfusion Blazor Charts. Use LabelIntersectAction to hide, rotate, or trim overlapping text.
platform: Blazor
control: Charts
documentation: ug
---

# Blazor Charts Axis Labels

This section explains how to customize the Blazor Charts axis labels, including smart label arrangement, positioning, multilevel labels, edge placement, trimming, and templating.

A detailed walkthrough for customizing the chart axis labels is provided in the video below.

{% youtube "youtube:https://www.youtube.com/watch?v=FzH0Pl_LnvQ" %}

## Smart Axis Labels

When the axis labels overlap, the [LabelIntersectAction](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartAxis.html#Syncfusion_Blazor_Charts_ChartAxis_LabelIntersectAction) property in the axis can be used to intelligently arrange them. The default value is `LabelIntersectAction.Trim`. For the vertical axis, only `Hide` is applicable.

|Value|Description|
|-----|-----|
|`None`|Shows all labels, regardless of intersections (default rendering).|
|`Hide`|Hides labels that intersect with each other.|
|`Trim`|Trims labels to fit within the available space when they intersect.|
|`Wrap`|Wraps labels to multiple lines when they intersect.|
|`MultipleRows`|Displays labels in multiple rows when they intersect.|
|`Rotate45`|Rotates labels by 45 degrees when they intersect.|
|`Rotate90`|Rotates labels by 90 degrees when they intersect.|

**Option 1:** Use **Hide** to remove overlapping axis labels.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart Title="Olympic Medals" >
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category"
        LabelIntersectAction="LabelIntersectAction.Hide" />

    <ChartSeriesCollection>
        <ChartSeries DataSource="@MedalDetails" XName="X" YName="Y" Type="ChartSeriesType.Column" />
    </ChartSeriesCollection>
</SfChart>

@code{
    public class ChartData
    {
        public string X { get; set; }
        public double Y { get; set; }
    }
	
    public List<ChartData> MedalDetails = new List<ChartData>
    {
		new ChartData { X= "South Korea", Y= 39 },
		new ChartData { X= "India", Y= 61 },
		new ChartData { X= "Pakistan", Y= 20 },
		new ChartData { X= "Germany", Y= 65 },
		new ChartData { X= "Australia", Y= 15 },
		new ChartData { X= "Italy", Y= 29 },
		new ChartData { X= "United Kingdom", Y= 44 },
		new ChartData { X= "Saudi Arabia", Y= 9 },
		new ChartData { X= "Russia", Y= 40 },
		new ChartData { X= "Mexico", Y= 31 },
		new ChartData { X= "Brazil", Y= 75 },
		new ChartData { X= "China", Y= 51 }
    };
}


```
{% previewsample "https://blazorplayground.syncfusion.com/embed/htBHZHMrzgSBqKay?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Hiding Smart Axis Label in Blazor Column Chart](images/axis-labels/blazor-column-chart-hide-smart-axis-label.webp)" %}

**Option 2:** Use **Rotate45** to rotate the overlapping axis labels by 45 degrees.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart Title="Olympic Medals">
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category"
                       LabelIntersectAction="LabelIntersectAction.Rotate45" />

    <ChartSeriesCollection>
        <ChartSeries DataSource="@MedalDetails" XName="X" YName="Y" Type="ChartSeriesType.Column" />
    </ChartSeriesCollection>
</SfChart>

@code{
    public class ChartData
    {
        public string X { get; set; }
        public double Y { get; set; }
    }
	
    public List<ChartData> MedalDetails = new List<ChartData>
	{
		new ChartData { X= "South Korea", Y= 39 },
		new ChartData { X= "India", Y= 61 },
		new ChartData { X= "Pakistan", Y= 20 },
		new ChartData { X= "Germany", Y= 65 },
		new ChartData { X= "Australia", Y= 15 },
		new ChartData { X= "Italy", Y= 29 },
		new ChartData { X= "United Kingdom", Y= 44 },
		new ChartData { X= "Saudi Arabia", Y= 9 },
		new ChartData { X= "Russia", Y= 40 },
		new ChartData { X= "Mexico", Y= 31 },
		new ChartData { X= "Brazil", Y= 75 },
		new ChartData { X= "China", Y= 51 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/hNVxNnCLpqoSQjrY?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Blazor Column Chart with Smart Axis Label in Rotate45](images/axis-labels/blazor-column-chart-axis-label-in-rotate45.webp)" %}

**Option 3:** Use **Rotate90** to rotate the overlapping axis labels by 90 degrees.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart Title="Olympic Medals">
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category"
                       LabelIntersectAction="LabelIntersectAction.Rotate90" />

    <ChartSeriesCollection>
        <ChartSeries DataSource="@MedalDetails" XName="X" YName="Y" Type="ChartSeriesType.Column" />
    </ChartSeriesCollection>
</SfChart>

@code{
    public class ChartData
    {
        public string X { get; set; }
        public double Y { get; set; }
    }
	
    public List<ChartData> MedalDetails = new List<ChartData>
	{
		new ChartData { X= "South Korea", Y= 39 },
		new ChartData { X= "India", Y= 61 },
		new ChartData { X= "Pakistan", Y= 20 },
		new ChartData { X= "Germany", Y= 65 },
		new ChartData { X= "Australia", Y= 15 },
		new ChartData { X= "Italy", Y= 29 },
		new ChartData { X= "United Kingdom", Y= 44 },
		new ChartData { X= "Saudi Arabia", Y= 9 },
		new ChartData { X= "Russia", Y= 40 },
		new ChartData { X= "Mexico", Y= 31 },
		new ChartData { X= "Brazil", Y= 75 },
		new ChartData { X= "China", Y= 51 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/htBnNdiBJAoPOXAx?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Blazor Column Chart with Smart Axis Label in Rotate90](images/axis-labels/blazor-column-chart-axis-label-in-rotate90.webp)" %}

## Axis label positioning

The axis labels are placed **Outside** of the axis line by default. The [LabelPosition](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartAxis.html#Syncfusion_Blazor_Charts_ChartAxis_LabelPosition) property can also be used to position them **Inside** the axis line.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart Title="Olympic Medals" >
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" 
                       LabelPosition="AxisPosition.Inside"/>   

    <ChartSeriesCollection>
        <ChartSeries DataSource="@MedalDetails" XName="X" YName="Y" Type="ChartSeriesType.Column"/>        
    </ChartSeriesCollection>
</SfChart>

@code{
    public class ChartData
    {
        public string X { get; set; }
        public double Y { get; set; }
    }
	
    public List<ChartData> MedalDetails = new List<ChartData>
	{
		new ChartData { X= "South Korea", Y= 39 },
		new ChartData { X= "India", Y= 61 },
		new ChartData { X= "Pakistan", Y= 20 },
		new ChartData { X= "Germany", Y= 65 },
		new ChartData { X= "Australia", Y= 15 },
		new ChartData { X= "Italy", Y= 29 },
		new ChartData { X= "United Kingdom", Y= 44 },
		new ChartData { X= "Saudi Arabia", Y= 9 },
		new ChartData { X= "Russia", Y= 40 },
		new ChartData { X= "Mexico", Y= 31 },
		new ChartData { X= "Brazil", Y= 75 },
		new ChartData { X= "China", Y= 51 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VtrnXdiVpgnClUcS?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Changing Axis Label Position in Blazor Column Chart](images/axis-labels/blazor-column-chart-axis-label-position.webp)" %}

## Multilevel labels

The [MultiLevelLabels](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartAxis.html#Syncfusion_Blazor_Charts_ChartAxis_MultiLevelLabels) property allows you to add any number of layers of labels to the axis. The following properties can be used to configure this property.

### Categories

Use the [ChartCategories](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCategories.html) collection, which accepts a set of [ChartCategory](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCategory.html) objects, to customize the [Start](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCategory.html#Syncfusion_Blazor_Charts_ChartCategory_Start), [End](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCategory.html#Syncfusion_Blazor_Charts_ChartCategory_End), [Text](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCategory.html#Syncfusion_Blazor_Charts_ChartCategory_Text), and [MaximumTextWidth](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCategory.html#Syncfusion_Blazor_Charts_ChartCategory_MaximumTextWidth) of multilevel labels.

N> For a category axis, the `Start` and `End` values use a half-step convention: each category occupies one unit, so the first category spans `Start = -0.5` to `End = 0.5`, the second from `0.5` to `1.5`, and so on. To group `n` consecutive categories, set `End = Start + n`.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart Title="Olympic Medals">
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category">
        <ChartMultiLevelLabels>
            <ChartMultiLevelLabel>
                <ChartCategories>                   
                        <ChartCategory Start="-0.5" End="3.5" Text="Half yearly 1" MaximumTextWidth="50"></ChartCategory>
                        <ChartCategory Start="3.5" End="7.5" Text="Half yearly 2" MaximumTextWidth="50"></ChartCategory>                
                </ChartCategories>
            </ChartMultiLevelLabel>
        </ChartMultiLevelLabels>
    </ChartPrimaryXAxis>

    <ChartSeriesCollection>
        <ChartSeries DataSource="@MedalDetails" XName="X" YName="Y" Type="ChartSeriesType.Column">
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code{
    public class ChartData
    {
        public string X { get; set; }
        public double Y { get; set; }
    }
	
    public List<ChartData> MedalDetails = new List<ChartData>
	{
		new ChartData { X= "Russia", Y= 50 },
		new ChartData { X= "China", Y= 40 },
		new ChartData { X= "Japan", Y= 70 },
		new ChartData { X= "Australia", Y= 60 },
		new ChartData { X= "France", Y= 70 },
		new ChartData { X= "Germany", Y= 40 },
		new ChartData { X= "Italy", Y= 40 },
		new ChartData { X= "United states", Y= 30 },
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/rtLRtxWrJqneRbjw?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Blazor Column Chart with Multilevel Labels](images/axis-labels/blazor-column-chart-multi-labels.webp)" %}

### Overflow

Using the [Overflow](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartMultiLevelLabel.html#Syncfusion_Blazor_Charts_ChartMultiLevelLabel_Overflow) property, one can [Trim](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.TextOverflow.html#Syncfusion_Blazor_Charts_TextOverflow_Trim) or [Wrap](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.TextOverflow.html#Syncfusion_Blazor_Charts_TextOverflow_Wrap) the multilevel labels.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart Title="Olympic Medals">
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category">
        <ChartMultiLevelLabels>
            <ChartMultiLevelLabel Overflow="TextOverflow.Trim">
                <ChartCategories>                  
                        <ChartCategory Start="-0.5" End="3.5" Text="Half yearly 1" MaximumTextWidth="50"></ChartCategory>
                        <ChartCategory Start="3.5" End="7.5" Text="Half yearly 2" MaximumTextWidth="50"></ChartCategory>                   
                </ChartCategories>
            </ChartMultiLevelLabel>
        </ChartMultiLevelLabels>
    </ChartPrimaryXAxis>

    <ChartSeriesCollection>
        <ChartSeries DataSource="@MedalDetails" XName="X" YName="Y" Type="ChartSeriesType.Column">
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code{
    public class ChartData
    {
        public string X { get; set; }
        public double Y { get; set; }
    }
	
    public List<ChartData> MedalDetails = new List<ChartData>
	{
		new ChartData { X= "Russia", Y= 50 },
		new ChartData { X= "China", Y= 40 },
		new ChartData { X= "Japan", Y= 70 },
		new ChartData { X= "Australia", Y= 60 },
		new ChartData { X= "France", Y= 70 },
		new ChartData { X= "Germany", Y= 40 },
		new ChartData { X= "Italy", Y= 40 },
		new ChartData { X= "United states", Y= 30 },
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BtLRXxMVTAHarkMR?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Blazor Column Chart Multilevel Labels with Overflow](images/axis-labels/blazor-column-chart-axis-label-overflow.webp)" %}

### Alignment

The [Alignment](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartMultiLevelLabel.html#Syncfusion_Blazor_Charts_ChartMultiLevelLabel_Alignment) property allows you to place multilevel labels in a [Far](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.Alignment.html#Syncfusion_Blazor_Charts_Alignment_Far), [Center](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.Alignment.html#Syncfusion_Blazor_Charts_Alignment_Center), or [Near](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.Alignment.html#Syncfusion_Blazor_Charts_Alignment_Near) location. The default alignment is **Center**.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart Title="Olympic Medals">
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category">
        <ChartMultiLevelLabels>
            <ChartMultiLevelLabel Alignment="Alignment.Far">
                <ChartCategories>
                        <ChartCategory Start="-0.5" End="3.5" Text="Half yearly 1" MaximumTextWidth="100"></ChartCategory>
                        <ChartCategory Start="3.5" End="7.5" Text="Half yearly 2" MaximumTextWidth="100"></ChartCategory>                      
                </ChartCategories>
            </ChartMultiLevelLabel>
        </ChartMultiLevelLabels>
    </ChartPrimaryXAxis>

    <ChartSeriesCollection>
        <ChartSeries DataSource="@MedalDetails" XName="X" YName="Y" Type="ChartSeriesType.Column">
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code{
    public class ChartData
    {
        public string X { get; set; }
        public double Y { get; set; }
    }
	
    public List<ChartData> MedalDetails = new List<ChartData>
	{
		new ChartData { X= "Russia", Y= 50 },
		new ChartData { X= "China", Y= 40 },
		new ChartData { X= "Japan", Y= 70 },
		new ChartData { X= "Australia", Y= 60 },
		new ChartData { X= "France", Y= 70 },
		new ChartData { X= "Germany", Y= 40 },
		new ChartData { X= "Italy", Y= 40 },
		new ChartData { X= "United states", Y= 30 },
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BXrHZHsLpUQqQGmT?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Changing Multilevel Labels Alignment in Blazor Column Chart](images/axis-labels/blazor-column-chart-axis-label-alignment.webp)" %}

### Text customization

The [Size](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartAxisMultiLevelLabelTextStyle.html#Syncfusion_Blazor_Charts_ChartAxisMultiLevelLabelTextStyle_Size), [Color](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartAxisMultiLevelLabelTextStyle.html#Syncfusion_Blazor_Charts_ChartAxisMultiLevelLabelTextStyle_Color), [FontFamily](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCommonFont.html#Syncfusion_Blazor_Charts_ChartCommonFont_FontFamily), [FontWeight](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCommonFont.html#Syncfusion_Blazor_Charts_ChartCommonFont_FontWeight), [FontStyle](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCommonFont.html#Syncfusion_Blazor_Charts_ChartCommonFont_FontStyle), [Opacity](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCommonFont.html#Syncfusion_Blazor_Charts_ChartCommonFont_Opacity), [TextAlignment](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCommonFont.html#Syncfusion_Blazor_Charts_ChartCommonFont_TextAlignment), and [TextOverflow](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCommonFont.html#Syncfusion_Blazor_Charts_ChartCommonFont_TextOverflow) properties can be customized via the [TextStyle](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartMultiLevelLabel.html#Syncfusion_Blazor_Charts_ChartMultiLevelLabel_TextStyle) property of multilevel labels.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart Title="Olympic Medals">
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category">
        <ChartMultiLevelLabels>
            <ChartMultiLevelLabel>
                <ChartCategories>
                        <ChartCategory Start="-0.5" End="3.5" Text="Half yearly 1" MaximumTextWidth="100"></ChartCategory>
                        <ChartCategory Start="3.5" End="7.5" Text="Half yearly 2" MaximumTextWidth="100"></ChartCategory>                  
                </ChartCategories>
                <ChartAxisMultiLevelLabelTextStyle Size="14px" Color="red"/>
            </ChartMultiLevelLabel>
        </ChartMultiLevelLabels>
    </ChartPrimaryXAxis>

    <ChartSeriesCollection>
        <ChartSeries DataSource="@MedalDetails" XName="X" YName="Y" Type="ChartSeriesType.Column">
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code{
    public class ChartData
    {
        public string X { get; set; }
        public double Y { get; set; }
    }
	
    public List<ChartData> MedalDetails = new List<ChartData>
	{
		new ChartData { X= "Russia", Y= 50 },
		new ChartData { X= "China", Y= 40 },
		new ChartData { X= "Japan", Y= 70 },
		new ChartData { X= "Australia", Y= 60 },
		new ChartData { X= "France", Y= 70 },
		new ChartData { X= "Germany", Y= 40 },
		new ChartData { X= "Italy", Y= 40 },
		new ChartData { X= "United states", Y= 30 },
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BZBxXnMBpgcmomUl?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Customizing Multilevel Labels Text in Blazor Column Chart](images/axis-labels/blazor-column-chart-custom-axis-label.webp)" %}

### Border customization

The [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartAxisMultiLevelLabelBorder.html#Syncfusion_Blazor_Charts_ChartAxisMultiLevelLabelBorder_Width) (default **1**), [Color](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartAxisMultiLevelLabelBorder.html#Syncfusion_Blazor_Charts_ChartAxisMultiLevelLabelBorder_Color) (default **transparent**), and [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartAxisMultiLevelLabelBorder.html#Syncfusion_Blazor_Charts_ChartAxisMultiLevelLabelBorder_Type) (default **Auto**) of the border can be customized via the [ChartAxisMultiLevelLabelBorder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartAxisMultiLevelLabelBorder.html) component. The available border types are [Rectangle](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BorderType.html#Syncfusion_Blazor_Charts_BorderType_Rectangle), [Brace](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BorderType.html#Syncfusion_Blazor_Charts_BorderType_Brace), [WithoutBorder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BorderType.html#Syncfusion_Blazor_Charts_BorderType_WithoutBorder), [WithoutTopBorder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BorderType.html#Syncfusion_Blazor_Charts_BorderType_WithoutTopBorder), [WithoutTopandBottomBorder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BorderType.html#Syncfusion_Blazor_Charts_BorderType_WithoutTopandBottomBorder), [Auto](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BorderType.html#Syncfusion_Blazor_Charts_BorderType_Auto), and [CurlyBrace](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BorderType.html#Syncfusion_Blazor_Charts_BorderType_CurlyBrace).

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart Title="Olympic Medals">
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category">
        <ChartMultiLevelLabels>
            <ChartMultiLevelLabel>
                <ChartCategories>
                        <ChartCategory Start="-0.5" End="3.5" Text="Half yearly 1" MaximumTextWidth="50"></ChartCategory>
                        <ChartCategory Start="3.5" End="7.5" Text="Half yearly 2" MaximumTextWidth="50"></ChartCategory>
                </ChartCategories>
                <ChartAxisMultiLevelLabelBorder Type="BorderType.Brace" Color="blue" Width="2"></ChartAxisMultiLevelLabelBorder>
            </ChartMultiLevelLabel>
        </ChartMultiLevelLabels>
    </ChartPrimaryXAxis>

    <ChartSeriesCollection>
        <ChartSeries DataSource="@MedalDetails" XName="X" YName="Y" Type="ChartSeriesType.Column">
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code{
    public class ChartData
    {
        public string X { get; set; }
        public double Y { get; set; }
    }

    public List<ChartData> MedalDetails = new List<ChartData>
    {
        new ChartData { X= "Russia", Y= 50 },
        new ChartData { X= "China", Y= 40 },
        new ChartData { X= "Japan", Y= 70 },
        new ChartData { X= "Australia", Y= 60 },
        new ChartData { X= "France", Y= 70 },
        new ChartData { X= "Germany", Y= 40 },
        new ChartData { X= "Italy", Y= 40 },
        new ChartData { X= "United states", Y= 30 },
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LjLdNnihJKFCjqNj?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Customizing Multilevel Labels Border in Blazor Column Chart](images/axis-labels/blazor-column-chart-label-with-custom-border.webp)" %}

## Edge label placement

The longer text labels at the edges of the axis may only be partially visible in the chart. To avoid this, use the [EdgeLabelPlacement](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartAxis.html#Syncfusion_Blazor_Charts_ChartAxis_EdgeLabelPlacement) property, which moves or hides the label within the chart area for a better user experience. The available options are [Shift](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.EdgeLabelPlacement.html#Syncfusion_Blazor_Charts_EdgeLabelPlacement_Shift) and [Hide](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.EdgeLabelPlacement.html#Syncfusion_Blazor_Charts_EdgeLabelPlacement_Hide). [None](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.EdgeLabelPlacement.html#Syncfusion_Blazor_Charts_EdgeLabelPlacement_None) leaves the text as it is, and is the default.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart Title="Yearly Sales">
    <ChartPrimaryXAxis LabelPlacement="LabelPlacement.OnTicks" EdgeLabelPlacement="EdgeLabelPlacement.Shift" ValueType="Syncfusion.Blazor.Charts.ValueType.Category">
        <ChartAxisLabelStyle Size="18px" Color="red" />
    </ChartPrimaryXAxis>

    <ChartPrimaryYAxis Title="Sales in Millions" />

    <ChartSeriesCollection>
        <ChartSeries DataSource="@MedalDetails" XName="X" YName="Y" Type="ChartSeriesType.Line">
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code{
    public class ChartData
    {
        public string X { get; set; }
        public double Y { get; set; }
    }
	
    public List<ChartData> MedalDetails = new List<ChartData>
	{
        new ChartData { X= "2005", Y= 1.2},
        new ChartData { X= "2006", Y= 1 },
        new ChartData { X= "2007", Y= 1 },
        new ChartData { X= "2008", Y= 0.2},
        new ChartData { X= "2009", Y= 0.1},
        new ChartData { X= "2010", Y= 1 },
        new ChartData { X= "2011", Y= 0.1},
        new ChartData { X= "2012", Y= 0.5},
        new ChartData { X= "2013", Y= 0.2},
        new ChartData { X= "2014", Y= 0.6},
        new ChartData { X= "2015", Y= 0.9},
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/rNrntnsrpqbeqVsF?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Displaying Blazor Chart Axis Label in Edge Position](images/axis-labels/blazor-chart-axis-label-in-edge.webp)" %}

## Label customization

The label [Color](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartAxisLabelStyle.html#Syncfusion_Blazor_Charts_ChartAxisLabelStyle_Color), [Size](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartAxisLabelStyle.html#Syncfusion_Blazor_Charts_ChartAxisLabelStyle_Size), `FontFamily`, `FontWeight`, `FontStyle`, and `Opacity` can be customized via the [ChartAxisLabelStyle](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartAxisLabelStyle.html) component. The example below customizes the most commonly used `Color` and `Size` properties.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart Title="Olympic Medals">
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category">
        <ChartAxisLabelStyle Size="18px" Color="red" />
    </ChartPrimaryXAxis>

    <ChartSeriesCollection>
        <ChartSeries DataSource="@MedalDetails" XName="Country" YName="Gold" Type="ChartSeriesType.Column">
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code{
    public class ChartData
    {
        public string Country { get; set; }
        public double Gold { get; set; }
    }
	
    public List<ChartData> MedalDetails = new List<ChartData>
	{
		new ChartData{ Country= "United States", Gold=50  },
		new ChartData{ Country= "China", Gold=40 },
		new ChartData{ Country= "Japan", Gold=70 },
		new ChartData{ Country= "Australia", Gold=60},
		new ChartData{ Country= "France", Gold=50 },
		new ChartData{ Country= "Germany", Gold=40 },
		new ChartData{ Country= "Italy", Gold=40 },
		new ChartData{ Country= "Sweden", Gold=30 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/hZBnZnCBTgPPuXVx?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Blazor Column Chart Axis with Custom Label](images/axis-labels/blazor-column-chart-axis-custom-label.webp)" %}

## Trim label

The label can be trimmed using the [EnableTrim](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartAxis.html#Syncfusion_Blazor_Charts_ChartAxis_EnableTrim) property (default **false**), and the width of the label can be modified using the [MaximumLabelWidth](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartAxis.html#Syncfusion_Blazor_Charts_ChartAxis_MaximumLabelWidth) property in the axis. The default value of [MaximumLabelWidth](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartAxis.html#Syncfusion_Blazor_Charts_ChartAxis_MaximumLabelWidth) is **34px**.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart Title="Olympic Medals">
    <ChartPrimaryXAxis EnableTrim="true" MaximumLabelWidth="40" ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />

    <ChartSeriesCollection>
        <ChartSeries DataSource="@MedalDetails" XName="Country" YName="Gold" Type="ChartSeriesType.Column">
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code{
    public class ChartData
    {
        public string Country { get; set; }
        public double Gold { get; set; }
    }
	
    public List<ChartData> MedalDetails = new List<ChartData>
	{
		new ChartData{ Country= "United States", Gold=50  },
		new ChartData{ Country= "China", Gold=40 },
		new ChartData{ Country= "Japan", Gold=70 },
		new ChartData{ Country= "Australia", Gold=60},
		new ChartData{ Country= "France", Gold=50 },
		new ChartData{ Country= "Germany", Gold=40 },
		new ChartData{ Country= "Italy", Gold=40 },
		new ChartData{ Country= "Sweden", Gold=30 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VDrxtnChTKuBXOyK?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Label Trimming in Blazor Column Chart Axis](images/axis-labels/blazor-column-chart-axis-label-trim.webp)" %}

## Line break

The `<br>` tag can be used to separate a long axis label into multiple lines.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart Title="Olympic Medals">
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />

    <ChartSeriesCollection>
        <ChartSeries DataSource="@MedalDetails" XName="Country" YName="Gold" Type="ChartSeriesType.Column">
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code{
    public class ChartData
    {
        public string Country { get; set; }
        public double Gold { get; set; }
    }
	
    public List<ChartData> MedalDetails = new List<ChartData>
	{
        new ChartData{ Country= "Australia", Gold=60},
        new ChartData{ Country= "China", Gold=40 },
        new ChartData{ Country= "Japan", Gold=70 },
        new ChartData{ Country= "United States<br>Of America", Gold=50  },
        new ChartData{ Country= "France", Gold=50 },
        new ChartData{ Country= "Germany", Gold=40 },
        new ChartData{ Country= "Italy", Gold=40 },
        new ChartData{ Country= "Sweden", Gold=30 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BXLdtxCBJqESmnux?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Blazor Column Chart Axis with Line break Label](images/axis-labels/blazor-column-chart-axis-line-break-label.webp)" %}

## Label format

The [LabelFormat](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartAxis.html#Syncfusion_Blazor_Charts_ChartAxis_LabelFormat) property controls how numeric, logarithmic, and date-time axis labels are rendered. It supports standard format strings (for example, `C`, `N`, `P`, `d`, `D`, `t`) and custom placeholders such as `{value}K`. It is primarily used for value-based axes and is not typically used to format Category axis text labels.

For details on label formatting for specific axis types, see:

* [Numeric Label Format](./numeric-axis#label-format)
* [DateTime Label Format](./date-time-axis#label-format)
* [Custom Label Format](./date-time-axis#custom-label-format)

## Label customization using an event

You can customize the axis labels by using the [OnAxisLabelRender](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_OnAxisLabelRender) event. The following properties in the event args can be used to customize the label rendering.

* [LabelStyle](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AxisLabelRenderEventArgs.html#Syncfusion_Blazor_Charts_AxisLabelRenderEventArgs_LabelStyle) – Specifies the font information of the axis label with following properties,

	|Properties|Description|
	|-----|-----|
	|Color |To customize the color of the text. |
	|FontFamily |To customize the font family of label. |
	|FontStyle |To customize the font style. |
	|FontWeight |To customize the font weight.|
	|Size |To customize the font size of the label text.|
	|TextAlignment |To customize the horizontal alignment of the label text.|
	|Opacity |To customize the transparency of text.|

* [Text](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AxisLabelRenderEventArgs.html#Syncfusion_Blazor_Charts_AxisLabelRenderEventArgs_Text) – Gets or sets the text to be displayed in the axis label. You can change the text based on the `Value` and `Axis` properties.
* [Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AxisLabelRenderEventArgs.html#Syncfusion_Blazor_Charts_AxisLabelRenderEventArgs_Value) – Specifies the value of the axis label. For `CategoryAxis`, it denotes the index of the datapoints and for numeric and date-time axes `Value` denotes the actual value of the datapoints.
* [Axis](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AxisLabelRenderEventArgs.html#Syncfusion_Blazor_Charts_AxisLabelRenderEventArgs_Axis) – Specifies the axis for which labels are rendering. The default axis names for the primary axes are `PrimaryXAxis` and `PrimaryYAxis`.
* `Cancel`- Gets or sets whether to cancel the rendering of particular label. Set to `true` to suppress a specific label.


```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartEvents OnAxisLabelRender="AxisLabelEvent"></ChartEvents>
	
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category"></ChartPrimaryXAxis>
	
    <ChartSeriesCollection>
        <ChartSeries DataSource="@Sales" XName="Month" YName="SalesValue" Type="ChartSeriesType.Column">
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code{
    public class SalesInfo
    {
        public string Month { get; set; }
        public double SalesValue { get; set; }
    }
	
    public List<SalesInfo> Sales = new List<SalesInfo>
    {
        new SalesInfo { Month = "Jan", SalesValue = 35 },
        new SalesInfo { Month = "Feb", SalesValue = 28 },
        new SalesInfo { Month = "Mar", SalesValue = 34 },
        new SalesInfo { Month = "Apr", SalesValue = 32 },
        new SalesInfo { Month = "May", SalesValue = 40 },
        new SalesInfo { Month = "Jun", SalesValue = 32 },
        new SalesInfo { Month = "Jul", SalesValue = 35 }
    };

    public void AxisLabelEvent(AxisLabelRenderEventArgs args)
    {
        if (args.Axis.Name == "PrimaryXAxis")
        {
            args.LabelStyle.Color = "Red";
            if (args.Value == 4)
            {
                args.Text = "chart";
            }
        }
        else if (args.Axis.Name == "PrimaryYAxis")
        {
            args.LabelStyle.Color = "Blue";
        }
    }
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LtBHjdCVTUkYTNzR?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Blazor Column Chart Axis with Label customization](images/axis-labels/blazor-column-chart-label-customization.webp)" %}

## Axis label template

The axis label template allows you to customize axis labels by formatting them with HTML content, applying conditional styling, and including dynamic elements such as icons, images or additional data. This customization is enabled by setting the template content in the [LabelTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartAxis.html#Syncfusion_Blazor_Charts_ChartAxis_LabelTemplate) property of the [ChartAxis](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartAxis.html) component.

Within the `LabelTemplate`, the implicit parameter `context` provides access to label-specific information. To use this data, cast `context` to the [ChartAxisLabelInfo](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartAxisLabelInfo.html) class. The `LabelTemplate` is currently supported on the X axis only and may increase the time required to render labels.

The `ChartAxisLabelInfo` class exposes the following members:

|Member|Description|
|-----|-----|
|`Text`|The label text. Use for category, numeric, and logarithmic axes.|
|`Value`|The numeric value of the label. Use for numeric and date-time axes.|
|`DateTimeLabel`|The `DateTime` value of the label. Use for date-time and date-time-category axes.|

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart Title="Olympic Medals">
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category">
        <LabelTemplate>
            @{
                var data = context as ChartAxisLabelInfo;
            }
            @if (data != null)
            {
            <table>
                <tr>
                    <td align="center" style="background-color: #2E8B57; font-size: 14px; color: #FFD700; font-weight: bold; padding: 5px">Country :</td>
                    <td align="center" style="background-color: #4682B4; font-size: 14px; color: #FFFFFF; font-weight: bold; padding: 5px">@data.Text</td>
                </tr>
            </table>
            }
        </LabelTemplate>
    </ChartPrimaryXAxis>
    <ChartPrimaryYAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Double"></ChartPrimaryYAxis>
    <ChartSeriesCollection>
        <ChartSeries DataSource="@MedalDetails" XName="Country" YName="Medals" Type="ChartSeriesType.Column">
            <ChartMarker>
                <ChartDataLabel Visible="true"></ChartDataLabel>
            </ChartMarker>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class MedalData
    {
        public string Country { get; set; }
        public double Medals { get; set; }
    }

    public List<MedalData> MedalDetails = new List<MedalData>
    {
        new MedalData { Country = "USA", Medals = 46 },
        new MedalData { Country = "UK", Medals = 27 },
        new MedalData { Country = "China", Medals = 26 },
        new MedalData { Country = "Russia", Medals = 19 },
        new MedalData { Country = "Germany", Medals = 17 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BDVHNHChJzjTfWZv?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Blazor Column Chart Axis with Template using Text](images/axis-labels/blazor-column-chart-axis-text-template.webp)" %}

N> [View Sample in GitHub](https://github.com/SyncfusionExamples/Blazor-Chart-Axis-Label-Customization).

## See also

* [Data Label](./data-labels)
* [Tooltip](./tool-tip)
* [Marker](./data-markers)

N> Refer to the [Blazor Charts](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations and also explore the [Blazor Chart Example](https://blazor.syncfusion.com/demos/chart/line?theme=fluent2) to know various chart types and how to represent time-dependent data, showing trends at equal intervals.
