---
layout: post
title: Appearance in Blazor Charts Component | Syncfusion
description: Check out and learn how to customize Chart Appearance in Syncfusion Blazor Charts component.
platform: Blazor
control: Chart
documentation: ug
---

# Appearance in Blazor Charts Component

## Custom color palette

Change the default color of series or points by providing a custom color palette to the [Palettes](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfChart.html#Syncfusion_Blazor_Charts_SfChart_Palettes) property.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart Title="Olympic Medals" Palettes="@palettes">
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />

    <ChartSeriesCollection>
        <ChartSeries DataSource="@MedalDetails" XName="Country" YName="Gold" Type="ChartSeriesType.Column">
        </ChartSeries>
        <ChartSeries DataSource="@MedalDetails" XName="Country" YName="Silver" Type="ChartSeriesType.Column">
        </ChartSeries>
        <ChartSeries DataSource="@MedalDetails" XName="Country" YName="Bronze" Type="ChartSeriesType.Column">
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class ChartData
    {
        public string Country { get; set; }
        public double Gold { get; set; }
        public double Silver { get; set; }
        public double Bronze { get; set; }
    }

    public List<ChartData> MedalDetails = new List<ChartData>
    {
        new ChartData { Country = "USA", Gold = 50, Silver = 70, Bronze = 45 },
        new ChartData { Country = "China", Gold = 40, Silver = 60, Bronze = 55 },
        new ChartData { Country = "Japan", Gold = 70, Silver = 60, Bronze = 50 },
        new ChartData { Country = "Australia", Gold = 60, Silver = 56, Bronze = 40 },
        new ChartData { Country = "France", Gold = 50, Silver = 45, Bronze = 35 },
        new ChartData { Country = "Germany", Gold = 40, Silver = 30, Bronze = 22 },
        new ChartData { Country = "Italy", Gold = 40, Silver = 35, Bronze = 37 },
        new ChartData { Country = "Sweden", Gold = 30, Silver = 25, Bronze = 27 }
    };

    public String[] palettes = new String[] { "#E94649", "#F6B53F", "#6FAAB0" };
}

```

![Blazor Column Chart with Custom Color Palette](images/appearance/blazor-column-chart-custom-color-palette.png)

<!-- markdownlint-disable MD036 -->

## Chart customization

<!-- markdownlint-disable MD036 -->

### Chart background and border

<!-- markdownlint-disable MD013 -->

Customize the chart's background color using the [Background](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfChart.html#Syncfusion_Blazor_Charts_SfChart_Background) property. Adjust border color and width with [ChartBorder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartBorder.html).

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart Title="Olympic Medals" Background="skyblue">
    <ChartBorder Color="#FF0000" Width="2"></ChartBorder>

    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />

    <ChartSeriesCollection>
        <ChartSeries DataSource="@MedalDetails" XName="Country" YName="Gold" Type="ChartSeriesType.Column">
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class ChartData
    {
        public string Country { get; set; }
        public double Gold { get; set; }
    }

    public List<ChartData> MedalDetails = new List<ChartData>
    {
        new ChartData { Country = "USA", Gold = 50  },
        new ChartData { Country = "China", Gold = 40 },
        new ChartData { Country = "Japan", Gold = 70 },
        new ChartData { Country = "Australia", Gold = 60 },
        new ChartData { Country = "France", Gold = 50 },
        new ChartData { Country = "Germany", Gold = 40 },
        new ChartData { Country = "Italy", Gold = 40 },
        new ChartData { Country = "Sweden", Gold = 30 }
    };
}

```

![Blazor Column Chart with Custom Background and Border](images/appearance/blazor-column-chart-custom-background-and-border.png)

### Chart margin

Set the chart margin from its container using the [ChartMargin](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartMargin.html) property.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart Title="Olympic Medals" Background="skyblue">
    <ChartBorder Color="#FF0000" Width="2"></ChartBorder>

    <ChartMargin Left="60" Right="60" Top="60" Bottom="60"></ChartMargin>

    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />

    <ChartSeriesCollection>
        <ChartSeries DataSource="@MedalDetails" XName="Country" YName="Gold" Type="ChartSeriesType.Column">
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class ChartData
    {
        public string Country { get; set; }
        public double Gold { get; set; }
    }

    public List<ChartData> MedalDetails = new List<ChartData>
    {
        new ChartData { Country = "USA", Gold = 50  },
        new ChartData { Country = "China", Gold = 40 },
        new ChartData { Country = "Japan", Gold = 70 },
        new ChartData { Country = "Australia", Gold = 60 },
        new ChartData { Country = "France", Gold = 50 },
        new ChartData { Country = "Germany", Gold = 40 },
        new ChartData { Country = "Italy", Gold = 40 },
        new ChartData { Country = "Sweden", Gold = 30 }
    };
}

```

![Blazor Column Chart with Custom Margin](images/appearance/blazor-column-chart-custom-margin.png)

### Chart area customization

Change the background color and border of the chart area using [Background](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartArea.html#Syncfusion_Blazor_Charts_ChartArea_Background) and [ChartAreaBorder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartAreaBorder.html). Customize the chart area width with the [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartArea.html#Syncfusion_Blazor_Charts_ChartArea_Width) property.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart Title="Olympic Medals" >
    <ChartArea Background="skyblue" Width="80%">
        <ChartAreaBorder Color="#FF0000"  Width="2" />
    </ChartArea>

    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />

    <ChartSeriesCollection>
        <ChartSeries DataSource="@MedalDetails" XName="Country" YName="Gold" Type="ChartSeriesType.Column" />
    </ChartSeriesCollection>
</SfChart>

@code {
    public class ChartData
    {
        public string Country { get; set; }
        public double Gold { get; set; }
    }

    public List<ChartData> MedalDetails = new List<ChartData>
    {
        new ChartData { Country = "USA", Gold = 50  },
        new ChartData { Country = "China", Gold = 40 },
        new ChartData { Country = "Japan", Gold = 70 },
        new ChartData { Country = "Australia", Gold = 60 },
        new ChartData { Country = "France", Gold = 50 },
        new ChartData { Country = "Germany", Gold = 40 },
        new ChartData { Country = "Italy", Gold = 40 },
        new ChartData { Country = "Sweden", Gold = 30 }
    };
}

```

![Blazor Area Chart with Custom Background and Border](images/appearance/blazor-area-chart-custom-background-and-border.png)

## Animation

Customize series animation using the [Animation](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Animation) property. Enable or disable animation with [Enable](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartCommonAnimation.html#Syncfusion_Blazor_Charts_StockChartCommonAnimation_Enable), set duration with [Duration](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartCommonAnimation.html#Syncfusion_Blazor_Charts_StockChartCommonAnimation_Duration), and specify a start delay with [Delay](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartCommonAnimation.html#Syncfusion_Blazor_Charts_StockChartCommonAnimation_Delay).

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart Title="Olympic Medals">
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />

    <ChartSeriesCollection>
        <ChartSeries DataSource="@MedalDetails" Name="Gold" XName="Country" Width="2" Opacity="1" YName="Gold" Type="ChartSeriesType.Column">
            <ChartSeriesAnimation Enable="true" Duration="2000" Delay="200"></ChartSeriesAnimation>
            <ChartSeriesBorder Width="3" Color="red"></ChartSeriesBorder>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code{
    public class ChartData
    {
        public string Country { get; set; }
        public double Gold { get; set; }
        public double Silver { get; set; }
        public double Bronze { get; set; }
    }

    public List<ChartData> MedalDetails = new List<ChartData>
    {
        new ChartData{ Country= "USA", Gold=50, Silver=70, Bronze=45 },
        new ChartData{ Country="China", Gold=40, Silver= 60, Bronze=55 },
        new ChartData{ Country= "Japan", Gold=70, Silver= 60, Bronze=50 },
        new ChartData{ Country= "Australia", Gold=60, Silver= 56, Bronze=40 },
        new ChartData{ Country= "France", Gold=50, Silver= 45, Bronze=35 },
        new ChartData{ Country= "Germany", Gold=40, Silver=30, Bronze=22 },
        new ChartData{ Country= "Italy", Gold=40, Silver=35, Bronze=37 },
        new ChartData{ Country= "Sweden", Gold=30, Silver=25, Bronze=27 }
    };
}

```

## Chart title

Add a chart title using the [Title](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfChart.html#Syncfusion_Blazor_Charts_SfChart_Title) property to provide information about the displayed data.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart Title="Olympic Medals">
    <ChartTitleStyle Size="23px" Color="red" FontFamily="Arial" FontWeight="regular" FontStyle="italic"></ChartTitleStyle>

    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />

    <ChartSeriesCollection>
        <ChartSeries DataSource="@MedalDetails" XName="Country" YName="Gold" Type="ChartSeriesType.Column">
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class ChartData
    {
        public string Country { get; set; }
        public double Gold {get; set; }
    }

    public List<ChartData> MedalDetails = new List<ChartData>
    {
        new ChartData { Country = "USA", Gold = 50  },
        new ChartData { Country = "China", Gold = 40 },
        new ChartData { Country = "Japan", Gold = 70 },
        new ChartData { Country = "Australia", Gold = 60 },
        new ChartData { Country = "France", Gold = 50 },
        new ChartData { Country = "Germany", Gold = 40 },
        new ChartData { Country = "Italy", Gold = 40 },
        new ChartData { Country = "Sweden", Gold = 30 }
    };
}

```

![Blazor Column Chart with Title](images/appearance/blazor-column-chart-title.png)

### Title position

Customize the chart title placement using the [Position](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartTitleStyle.html#Syncfusion_Blazor_Charts_ChartTitleStyle_Position) property. Options include [Right](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartTitlePosition.html#Syncfusion_Blazor_Charts_ChartTitlePosition_Right), [Left](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartTitlePosition.html#Syncfusion_Blazor_Charts_ChartTitlePosition_Left), [Bottom](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartTitlePosition.html#Syncfusion_Blazor_Charts_ChartTitlePosition_Bottom), [Top](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartTitlePosition.html#Syncfusion_Blazor_Charts_ChartTitlePosition_Top), and [Custom](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartTitlePosition.html#Syncfusion_Blazor_Charts_ChartTitlePosition_Custom). By default, the title appears at the **top**.

N> The subtitle, which appears below the title, will also be positioned along with the title when the `Position` property is set.

```cshtml 

@using Syncfusion.Blazor.Charts

<SfChart Title="Olympic Medals" SubTitle="Medals">
    <ChartTitleStyle Position="ChartTitlePosition.Bottom"></ChartTitleStyle>

    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />

    <ChartSeriesCollection>
        <ChartSeries DataSource="@MedalDetails" XName="Country" YName="Gold" Type="Syncfusion.Blazor.Charts.ChartSeriesType.Column">
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class ChartData
    {
        public string Country { get; set; }
        public double Gold { get; set; }
    }

    public List<ChartData> MedalDetails = new List<ChartData>
    {
        new ChartData { Country = "USA", Gold = 50  },
        new ChartData { Country = "China", Gold = 40 },
        new ChartData { Country = "Japan", Gold = 70 },
        new ChartData { Country = "Australia", Gold = 60 },
        new ChartData { Country = "France", Gold = 50 },
        new ChartData { Country = "Germany", Gold = 40 },
        new ChartData { Country = "Italy", Gold = 40 },
        new ChartData { Country = "Sweden", Gold = 30 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BZLIZEryzUPiuQCS?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Position customization of title in Blazor Chart](images/appearance/blazor-chart-title-position.png)

When the `Position` is set to `Custom`, the title can be positioned anywhere on the chart using the [X](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartTitleStyle.html#Syncfusion_Blazor_Charts_ChartTitleStyle_X) and [Y](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartTitleStyle.html#Syncfusion_Blazor_Charts_ChartTitleStyle_Y) properties in [ChartTitleStyle](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartTitleStyle.html). This provides precise control over the title’s location, enabling customization to fit specific design or layout needs. The `X` and `Y` values specify the horizontal and vertical coordinates, respectively.

```cshtml 

@using Syncfusion.Blazor.Charts

<SfChart Title="Olympic Medals" SubTitle="Medals">
    <ChartTitleStyle Position="ChartTitlePosition.Custom" X="335" Y="60"></ChartTitleStyle>

    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category">
        <ChartAxisMajorGridLines Width="0"></ChartAxisMajorGridLines>
    </ChartPrimaryXAxis>

    <ChartSeriesCollection>
        <ChartSeries DataSource="@MedalDetails" XName="Country" YName="Gold" Type="Syncfusion.Blazor.Charts.ChartSeriesType.Column">
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
        new ChartData { Country = "USA", Gold = 50  },
        new ChartData { Country = "China", Gold = 40 },
        new ChartData { Country = "Japan", Gold = 70 },
        new ChartData { Country = "Australia", Gold = 60 },
        new ChartData { Country = "France", Gold = 50 },
        new ChartData { Country = "Germany", Gold = 40 },
        new ChartData { Country = "Italy", Gold = 40 },
        new ChartData { Country = "Sweden", Gold = 30 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BXrotuVozgajpbhW?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Custom position of title in Blazor Chart](images/appearance/blazor-chart-title-position-custom.png)

## Chart subtitle

Add a subtitle using the [SubTitle](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfChart.html#Syncfusion_Blazor_Charts_SfChart_SubTitle) property for additional information about the chart data.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart Title="Olympic Medals" SubTitle="Medals">
    <ChartSubTitleStyle FontFamily="Arial" FontStyle="italic" FontWeight="regular" Size="18px" Color="red"></ChartSubTitleStyle>

    <ChartTitleStyle FontFamily="Arial" FontStyle="italic" FontWeight="regular" Size="23px" Color="red"></ChartTitleStyle>

    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />

    <ChartSeriesCollection>
        <ChartSeries DataSource="@MedalDetails" XName="Country" YName="Gold" Type="ChartSeriesType.Column">
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class ChartData
    {
        public string Country { get; set; }
        public double Gold { get; set; }
    }

    public List<ChartData> MedalDetails = new List<ChartData>
    {
        new ChartData { Country = "USA", Gold = 50  },
        new ChartData { Country = "China", Gold = 40 },
        new ChartData { Country = "Japan", Gold = 70 },
        new ChartData { Country = "Australia", Gold = 60 },
        new ChartData { Country = "France", Gold = 50 },
        new ChartData { Country = "Germany", Gold = 40 },
        new ChartData { Country = "Italy", Gold = 40 },
        new ChartData { Country = "Sweden", Gold = 30 }
    };
}

```

![Blazor Column Chart with Subtitle](images/appearance/blazor-column-chart-with-subtitle.png)

N> The chart components do not use any CSS style for customization; chart elements like axis labels, datalabel, background, series palette, legend text, and tooltip text can be customized by using the [ChartAxisLabelStyle](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartAxisLabelStyle.html), [ChartDataLabelFont](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartDataLabelFont.html), [BackGround](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfChart.html#Syncfusion_Blazor_Charts_SfChart_Background), [Palettes](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfChart.html#Syncfusion_Blazor_Charts_SfChart_Palettes), [ChartLegendTextStyle](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartLegendTextStyle.html), and [ChartTooltipTextStyle](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartTooltipTextStyle.html), respectively. 

## See also

* [Data label](./data-labels)
* [Tooltip](./tool-tip)
