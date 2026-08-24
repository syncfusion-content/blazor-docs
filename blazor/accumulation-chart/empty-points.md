---
layout: post
title: Blazor Accumulation Chart Empty Points Examples | Syncfusion®
description: Learn how to handle empty data points in Syncfusion Blazor Accumulation Chart, including null and NaN values, and customize their rendering.
platform: Blazor
control: Accumulation Chart
documentation: ug
---

# Blazor Accumulation Chart Empty Points

Data points that contain **NaN** or **null** value are considered as empty points. The empty data points can be ignored or not plotted in the chart. Those points can be customized using the [AccumulationChartEmptyPointSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartEmptyPointSettings.html) in series. 

```cshtml 

@using Syncfusion.Blazor.Charts

<SfAccumulationChart Title="Mobile Browser Statistics">
    <AccumulationChartSeriesCollection>
        <AccumulationChartSeries DataSource="@StatisticsDetails" XName="Browser" YName="Users"
                                 Name="Profit">
            <AccumulationChartEmptyPointSettings Mode="@Mode"></AccumulationChartEmptyPointSettings>
            <AccumulationDataLabelSettings Visible="true" Name="Text" Position="AccumulationLabelPosition.Outside"></AccumulationDataLabelSettings>
        </AccumulationChartSeries>
    </AccumulationChartSeriesCollection>
</SfAccumulationChart>

@code{
    public EmptyPointMode Mode = EmptyPointMode.Gap;

    public class Statistics
    {
        public string Browser { get; set; }
        public double? Users { get; set; }
        public string Text { get; set; }
        public string Fill { get; set; }
    }
	
    public List<Statistics> StatisticsDetails = new List<Statistics>
	{
       new Statistics { Browser = "Chrome", Users = 37, Text= "37%", Fill="#498fff"},
       new Statistics { Browser = "UC Browser", Users = 17, Text= "17%", Fill="#ffa060"},
       new Statistics { Browser = "iPhone", Users = 19, Text= "19%", Fill="#ff68b6"},
       new Statistics { Browser = "Others", Users = 4 , Text= "4%", Fill="#81e2a1"},
    };
}

```

{% previewsample "https://blazorplayground.syncfusion.com/embed/BjrnjGLXqIQJyEIT?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Empty Points in Blazor Accumulation Chart](images/empty/blazor-accumulation-chart-with-empty-point.webp)" %}

## Empty Point Modes

In addition to the default `Gap` mode, the accumulation chart supports three additional modes that control how empty data points are represented:

* `Drop` — Drops the empty point entirely so that neighboring slices touch directly without leaving a wedge.
* `Zero` — Treats the empty point's value as 0, allowing it to render as a zero-sized slice.
* `Average` — Substitutes the empty point's value with the average of neighboring data points.

Choose the mode that best conveys the structure of your data when observations are missing.

```cshtml

@using Syncfusion.Blazor.Charts

<SfAccumulationChart Title="Mobile Browser Statistics">
    <AccumulationChartSeriesCollection>
        <AccumulationChartSeries DataSource="@StatisticsDetails" XName="Browser" YName="Users" Name="Profit">
            <AccumulationChartEmptyPointSettings Mode="@Mode"></AccumulationChartEmptyPointSettings>
            <AccumulationDataLabelSettings Visible="true" Name="Text" Position="AccumulationLabelPosition.Outside"></AccumulationDataLabelSettings>
        </AccumulationChartSeries>
    </AccumulationChartSeriesCollection>
</SfAccumulationChart>

@code{
    // Switch between Drop / Zero / Average to see each mode in action.
    public EmptyPointMode Mode = EmptyPointMode.Average;

    public class Statistics
    {
        public string Browser { get; set; }
        public double? Users { get; set; }
        public string Text { get; set; }
    }

    public List<Statistics> StatisticsDetails = new List<Statistics>
    {
        new Statistics { Browser = "Chrome", Users = 37, Text = "37%" },
        new Statistics { Browser = "UC Browser", Users = null, Text = "n/a" },
        new Statistics { Browser = "iPhone", Users = 19, Text = "19%" },
        new Statistics { Browser = "Others", Users = 4, Text = "4%" },
    };
}
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/BjBRXvBphIDpfwFC?appbar=true&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Customizing Empty Points in Blazor Accumulation Chart](images/empty/blazor-accumulation-chart-empty-point-average.webp)" %}

## Customization

The [Mode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartEmptyPointSettings.html#Syncfusion_Blazor_Charts_AccumulationChartEmptyPointSettings_Mode) property can be used to handle the visibility of the empty points. The default mode of the empty point is **Gap**. Other supported modes are **Average**, **Drop** and **Zero**. The [Fill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartEmptyPointSettings.html#Syncfusion_Blazor_Charts_AccumulationChartEmptyPointSettings_Fill) property can be used to set a specific color for an empty point, and the [Border](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartEmptyPointSettings.html#Syncfusion_Blazor_Charts_AccumulationChartEmptyPointSettings_Border) property can be used to set the border for an empty point.

```cshtml 

@using Syncfusion.Blazor.Charts

<SfAccumulationChart Title="Mobile Browser Statistics">
    <AccumulationChartSeriesCollection>
        <AccumulationChartSeries DataSource="@StatisticsDetails" XName="Browser" YName="Users"
                                 Name="Profit">
            <AccumulationChartEmptyPointSettings Mode="@Mode" Fill="#c0faf4">
                <AccumulationChartEmptyPointBorder Color="red" Width="2"></AccumulationChartEmptyPointBorder>
            </AccumulationChartEmptyPointSettings>
            <AccumulationDataLabelSettings Visible="true" Name="Text" Position="AccumulationLabelPosition.Outside"></AccumulationDataLabelSettings>
        </AccumulationChartSeries>
    </AccumulationChartSeriesCollection>
</SfAccumulationChart>


@code{
    public EmptyPointMode Mode = EmptyPointMode.Average;

    public class Statistics
    {
        public string Browser { get; set; }
        public double? Users { get; set; }
        public string Text { get; set; }
        public string Fill { get; set; }
    }
	
    public List<Statistics> StatisticsDetails = new List<Statistics>
	{
       new Statistics { Browser = "Chrome", Users = 37, Text= "37%", Fill="#498fff"},
       new Statistics { Browser = "UC Browser", Users = null, Text= "17%", Fill="#ffa060"},
       new Statistics { Browser = "iPhone", Users = 19, Text= "19%", Fill="#ff68b6"},
       new Statistics { Browser = "Others", Users = 4 , Text= "4%", Fill="#81e2a1"},
    };
}

```

{% previewsample "https://blazorplayground.syncfusion.com/embed/hDLRZGhZqSYOeXNa?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Customizing Empty Points in Blazor Accumulation Chart](images/empty/blazor-accumulation-chart-empty-point-customization.webp)" %}

### Customizing Empty Point Border

The border of an empty point can be styled independently from data points using the [AccumulationChartEmptyPointBorder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartEmptyPointBorder.html) component. You can set color and width directly on the child component, and combine it with a `DashArray` pattern when you want the empty-point outline to stand out visually.

```cshtml

@using Syncfusion.Blazor.Charts

<SfAccumulationChart Title="Mobile Browser Statistics">
    <AccumulationChartSeriesCollection>
        <AccumulationChartSeries DataSource="@StatisticsDetails" XName="Browser" YName="Users" Name="Profit">
            <AccumulationChartEmptyPointSettings Mode="@Mode" Fill="#f7ce69">
                <AccumulationChartEmptyPointBorder Color="#ff7043" Width="2"></AccumulationChartEmptyPointBorder>
            </AccumulationChartEmptyPointSettings>
            <AccumulationDataLabelSettings Visible="true" Name="Text" Position="AccumulationLabelPosition.Outside"></AccumulationDataLabelSettings>
        </AccumulationChartSeries>
    </AccumulationChartSeriesCollection>
</SfAccumulationChart>

@code{
    public EmptyPointMode Mode = EmptyPointMode.Average;

    public class Statistics
    {
        public string Browser { get; set; }
        public double? Users { get; set; }
        public string Text { get; set; }
    }

    public List<Statistics> StatisticsDetails = new List<Statistics>
    {
        new Statistics { Browser = "Chrome", Users = 37, Text = "37%" },
        new Statistics { Browser = "UC Browser", Users = null, Text = "n/a" },
        new Statistics { Browser = "iPhone", Users = 19, Text = "19%" },
        new Statistics { Browser = "Others", Users = 4, Text = "4%" },
    };
}
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/BDhntlrzrSODNTRs?appbar=true&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Customizing Empty Points in Blazor Accumulation Chart](images/empty/blazor-accumulation-chart-empty-point-border.webp)" %}

## Handling No Data

When no data is available to render in the accumulation chart, the [NoDataTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfAccumulationChart.html#Syncfusion_Blazor_Charts_SfAccumulationChart_NoDataTemplate) property can be used to display a custom layout within the chart area. This layout may include a message indicating the absence of data, a relevant image, or a button to initiate data loading. Styled text, images, or interactive elements can be incorporated to maintain design consistency and improve user guidance. Once data becomes available, the chart automatically updates to display the appropriate visualization.

```cshtml 

@using Syncfusion.Blazor.Charts
@using Syncfusion.Blazor.Buttons

<SfAccumulationChart @ref="accChart" Width="80%" Title="Mobile Browser Statistics" SubTitle="In the year 2014 - 2015">
    <NoDataTemplate>
    <div style="border: 2px solid orange; display: row-flex; align-items: center; justify-content: center; align-content: center; white-space: normal; text-align: center; width: inherit; height: inherit; font-weight: bolder; font-size: medium;">
        <div style="font-size:15px; margin-bottom:10px"><strong>No data available to display.</strong></div>
        <SfButton IconCss="e-icons e-refresh" OnClick="LoadData">Load Data</SfButton>
    </div>
</NoDataTemplate>
    <ChildContent>
        <AccumulationChartSeriesCollection>
            <AccumulationChartSeries DataSource="@StatisticsDetails" XName="Browser" YName="Users" Name="Browser">
            </AccumulationChartSeries>
        </AccumulationChartSeriesCollection>
        <AccumulationChartLegendSettings Visible="true"></AccumulationChartLegendSettings>
    </ChildContent>
</SfAccumulationChart>

@code {
    private SfAccumulationChart accChart;
    public class Statistics
    {
        public string Browser { get; set; }
        public double Users { get; set; }
    }
    public List<Statistics> StatisticsDetails = new List<Statistics>();
    private void LoadData()
    {
        StatisticsDetails = new List<Statistics>
        {
            new Statistics { Browser = "Chrome", Users = 37 },
            new Statistics { Browser = "UC Browser", Users = 17 },
            new Statistics { Browser = "iPhone", Users = 19 },
            new Statistics { Browser = "Others", Users = 4  },
            new Statistics { Browser = "Opera", Users = 11 },
            new Statistics { Browser = "Android", Users = 12 },
        };
        if (accChart != null)
        accChart.Refresh();
    }
}

```

{% previewsample "https://blazorplayground.syncfusion.com/embed/rDBdtwrtAxNOqjQw?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[No Data Template in Blazor Accumulation Chart](images/empty/blazor-accumulation-chart-no-data-template.webp)" %}

## Troubleshooting

This section answers common questions when working with empty points in the Blazor Accumulation Chart.

**Q: Why are empty points not being detected?**

A: Empty points are detected only when a data point's Y value is either `null` or `NaN`. Make sure the corresponding property type is nullable (for example, `double?`) and that the value is assigned explicitly to `null` rather than leaving it uninitialized. With `double` (non-nullable), an unassigned value defaults to `0`, which is treated as a valid data point.

**Q: Which mode should I use?**

A: Use:

* `Gap` — When you want to highlight that data is missing without distorting neighboring values.
* `Average` — When the missing observation should not skew the overall proportions of the chart.
* `Drop` — When the missing data point should be removed entirely from the visualization.
* `Zero` — When the missing observation should still count as zero in legends and totals.

**Q: Why is the data label not showing for empty points?**

A: Data labels are drawn only when the point has a renderable value. In `Gap` and `Drop` modes the empty slice is not drawn, so its label is also suppressed. Switch to `Average` or `Zero` if you need a label for the empty point.

**Q: Can I customize empty-point borders independently?**

A: Yes. Use the `AccumulationChartEmptyPointBorder` child component inside `AccumulationChartEmptyPointSettings`. The component supports `Color`, `Width`, and `DashArray` properties. The styles apply only to empty points; other slices keep their normal border.

N> Refer to the [Blazor Charts](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations and also explore the [Blazor Accumulation Chart Example](https://blazor.syncfusion.com/demos/chart/pie?theme=fluent2) to know about the various features of accumulation charts and how they are used to represent numeric proportional data.

## See also

* [Data Label](./data-label)
* [Tooltip](./tool-tip)
* [Legend](./legend)