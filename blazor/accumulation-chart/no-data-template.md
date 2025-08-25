---
layout: post
title: No Data Template in Blazor Accumulation Chart Component | Syncfusion
description: Checkout and learn here all about No Data Template in Syncfusion Blazor Accumulation Chart component and more.
platform: Blazor
control: Accumulation Chart
documentation: ug
---

# No Data Template in Blazor Accumulation Chart Component

In the Blazor Accumulation Chart component, when there is no data to render, the `NoDataTemplate` property enables developers to display a custom layout within the chart area. This layout can include styled text, images, or interactive elements, helping maintain design consistency and improve user guidance.

This template is particularly useful for empty data scenarios. It can present a message indicating the absence of data, show a relevant image, and include a button to initiate data loading. Once data becomes available, the chart automatically updates to display the appropriate visualization.

```cshtml 

@using Syncfusion.Blazor.Charts
@using Syncfusion.Blazor.Buttons

<SfAccumulationChart @ref="accChart" Width="80%" Title="Mobile Browser Statistics" SubTitle="In the year 2014 - 2015">
    <NoDataTemplate>
        <div style="border: 2px solid orange; display: row-flex; align-items: center; justify-content: center; align-content: center; white-space: normal; text-align: center; width: inherit; height: inherit; font-weight: bolder; font-size: medium;">
            <span style="font-size: 100px;">📉</span>
            <div style="font-size:15px;"><strong>No data available to display.</strong></div>
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

![No Data Template in Blazor Accumulation Chart Before Loading the Data](images/empty/blazor-accumulation-chart-no-data-template-before-data.png)
![No Data Template in Blazor Accumulation Chart After Loading the Data](images/empty/blazor-accumulation-chart-no-data-template-after-data.png)

N> Refer to the [Blazor Charts](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations and also explore the [Blazor Accumulation Chart Example](https://blazor.syncfusion.com/demos/chart/pie?theme=bootstrap5) to know about the various features of accumulation charts and how it is used to represent numeric proportional data.

## See also

* [Data Label](./data-labels)
* [Tooltip](./tool-tip)
* [Legend](./legend)