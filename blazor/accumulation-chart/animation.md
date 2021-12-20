---
layout: post
title: Animation in Blazor Accumulation Chart Component | Syncfusion
description: Checkout and learn here all about Animation in Syncfusion Blazor Accumulation Chart component and more.
platform: Blazor
control: Accumulation Chart
documentation: ug
---

# Animation in Blazor Accumulation Chart Component

You can customize animation for a series using [`Animation`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartAnimation.html) property. You can enable or disable animation of the series using [`Enable`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartAnimation.html#Syncfusion_Blazor_Charts_AccumulationChartAnimation_Enable) property. [`Duration`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartAnimation.html#Syncfusion_Blazor_Charts_AccumulationChartAnimation_Duration) specifies the duration of an animation and [`Delay`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartAnimation.html#Syncfusion_Blazor_Charts_AccumulationChartAnimation_Delay) allows us to start the animation at desire time.

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

@code{
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
        new Statistics { Browser = "Android", Users = 12 },
    };
}
```