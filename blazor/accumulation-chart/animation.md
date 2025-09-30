---
layout: post
title: Animation in Blazor Accumulation Chart Component | Syncfusion
description: Check out and learn how to configure and control Animation in Syncfusion Blazor Accumulation Chart component.
platform: Blazor
control: Accumulation Chart
documentation: ug
---

# Animation in Blazor Accumulation Chart Component

Customize series animation using the [`Animation`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartAnimation.html) property. Enable or disable series animation with the [`Enable`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartAnimation.html#Syncfusion_Blazor_Charts_AccumulationChartAnimation_Enable) property. The [`Duration`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartAnimation.html#Syncfusion_Blazor_Charts_AccumulationChartAnimation_Duration) property sets the animation duration, and [`Delay`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartAnimation.html#Syncfusion_Blazor_Charts_AccumulationChartAnimation_Delay) specifies when the animation should start.

```cshtml

@using Syncfusion.Blazor.Charts

<SfAccumulationChart Title="Mobile Browser Statistics">
    <AccumulationChartLegendSettings Visible="false"></AccumulationChartLegendSettings>

    <AccumulationChartSeriesCollection>
        <AccumulationChartSeries DataSource="@StatisticsDetails" XName="Browser" YName="Users" Name="Browser">
            <AccumulationDataLabelSettings Visible="true"></AccumulationDataLabelSettings>
            <AccumulationChartAnimation Enable="false"></AccumulationChartAnimation>
        </AccumulationChartSeries>
    </AccumulationChartSeriesCollection>

</SfAccumulationChart>

@code {
    public class Statistics
    {
        public string Browser;
        public double Users;
    }

    public List<Statistics> StatisticsDetails = new List<Statistics>
    {
        new Statistics { Browser = "Chrome", Users = 37 },
        new Statistics { Browser = "UC Browser", Users = 17 },
        new Statistics { Browser = "iPhone", Users = 19 },
        new Statistics { Browser = "Others", Users = 4  },
        new Statistics { Browser = "Opera", Users = 11 },
        new Statistics { Browser = "Android", Users = 12 }
    };
}

```

## Disable Animation on Programmatic Refresh

Refresh the chart programmatically using the [Refresh](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfAccumulationChart.html#Syncfusion_Blazor_Charts_SfAccumulationChart_Refresh_System_Boolean_) method. Control animation by passing a boolean parameter to the `Refresh` method.

```cshtml

@using Syncfusion.Blazor.Charts

<SfAccumulationChart @ref=accumulationChart Title="Mobile Browser Statistics">
    <AccumulationChartSeriesCollection>
       <AccumulationChartSeries DataSource="@StatisticsDetails" XName="Browser" YName="Users" Name="Browser">
      </AccumulationChartSeries>
    </AccumulationChartSeriesCollection>
   <AccumulationChartLegendSettings Visible="true"></AccumulationChartLegendSettings>
</SfAccumulationChart>
<button  @onclick="ButtonClick">Click me</button>

@code {
    SfAccumulationChart accumulationChart;
    public class Statistics
    {
        public string Browser { get; set; }
        public double Users { get; set; }
    }

    public List<Statistics> StatisticsDetails = new List<Statistics>
    {
        new Statistics { Browser = "Chrome", Users = 37 },
        new Statistics { Browser = "UC Browser", Users = 17 },
        new Statistics { Browser = "iPhone", Users = 19 },
        new Statistics { Browser = "Others", Users = 4  },
        new Statistics { Browser = "Opera", Users = 11 },
        new Statistics { Browser = "Android", Users = 12 },
    };
    
    public void ButtonClick()
    {
      accumulationChart.Refresh(false);
    }         
}

```

{% previewsample "https://blazorplayground.syncfusion.com/embed/rZBAWrMgzIuHCzXH?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

N> Refer to the [Blazor Charts](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations and also explore the [Blazor Accumulation Chart Example](https://blazor.syncfusion.com/demos/chart/pie?theme=bootstrap5) to know various features of accumulation charts and how it is used to represent numeric proportional data.