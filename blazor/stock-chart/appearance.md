---
layout: post
title: Blazor Stock Chart Appearance | Syncfusion®
description: Learn how to customize the Blazor Stock Chart's title font, color, theme, background, gridlines, tooltip, and overall styling.
platform: Blazor
control: Stock Chart
documentation: ug
---

# Blazor Stock Chart Appearance

## Stock Chart Title

Set a chart title using the [Title](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfStockChart.html#Syncfusion_Blazor_Charts_SfStockChart_Title) property to provide context for the plotted data.

```cshtml

@using Syncfusion.Blazor.Charts

<SfStockChart Title="AAPL Stock Price">
    <StockChartSeriesCollection>
        <StockChartSeries DataSource="@DataSource" Type="ChartSeriesType.Line" XName="XValue" YName="YValue"></StockChartSeries>
    </StockChartSeriesCollection>
    <StockChartPeriods>
        <StockChartPeriod Text="1Y"></StockChartPeriod>
        <StockChartPeriod Text="All" Selected="true"></StockChartPeriod>
    </StockChartPeriods>
</SfStockChart>

@code {
    public class ChartData
    {
        public DateTime XValue { get; set; }
        public double YValue { get; set; }
    }

    public List<ChartData> DataSource = new List<ChartData>
    {
        new ChartData { XValue = new DateTime(2005, 01, 01), YValue = 21 },
        new ChartData { XValue = new DateTime(2006, 01, 01), YValue = 24 },
        new ChartData { XValue = new DateTime(2007, 01, 01), YValue = 36 },
        new ChartData { XValue = new DateTime(2008, 01, 01), YValue = 38 },
        new ChartData { XValue = new DateTime(2009, 01, 01), YValue = 54 },
        new ChartData { XValue = new DateTime(2010, 01, 01), YValue = 57 },
        new ChartData { XValue = new DateTime(2011, 01, 01), YValue = 70 }
    };
}

```

![Blazor Stock Chart with Title](images/appearance/blazor-stock-chart-title.webp)

<!-- markdownlint-disable MD036 -->

## Title Customizations

The [`StockChartTitleStyle`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartTitleStyle.html) provides options to customize the chart title's [`Size`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartTitleStyle.html#Syncfusion_Blazor_Charts_StockChartTitleStyle_Size), [`Color`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartTitleStyle.html#Syncfusion_Blazor_Charts_StockChartTitleStyle_Color), [`FontFamily`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartTitleStyle.html#Syncfusion_Blazor_Charts_StockChartTitleStyle_FontFamily), [`FontWeight`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartTitleStyle.html#Syncfusion_Blazor_Charts_StockChartTitleStyle_FontWeight), [`FontStyle`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartTitleStyle.html#Syncfusion_Blazor_Charts_StockChartTitleStyle_FontStyle), [`Opacity`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartTitleStyle.html#Syncfusion_Blazor_Charts_StockChartTitleStyle_Opacity), [`TextAlignment`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartTitleStyle.html#Syncfusion_Blazor_Charts_StockChartTitleStyle_TextAlignment), and [`TextOverflow`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartTitleStyle.html#Syncfusion_Blazor_Charts_StockChartTitleStyle_TextOverflow).

```cshtml

@using Syncfusion.Blazor.Charts

<SfStockChart Title="AAPL Stock Price">
    <StockChartTitleStyle FontFamily="Arial" FontStyle="Italic" FontWeight="Regular" Color="#E27F2D" Size="20px" TextOverflow="TextOverflow.Wrap"></StockChartTitleStyle>
    <StockChartSeriesCollection>
        <StockChartSeries DataSource="@DataSource" Type="ChartSeriesType.Line" XName="XValue" YName="YValue"></StockChartSeries>
    </StockChartSeriesCollection>
    <StockChartPeriods>
        <StockChartPeriod Text="1Y"></StockChartPeriod>
        <StockChartPeriod Text="All" Selected="true"></StockChartPeriod>
    </StockChartPeriods>
</SfStockChart>

@code {
    public class ChartData
    {
        public DateTime XValue { get; set; }
        public double YValue { get; set; }
    }

    public List<ChartData> DataSource = new List<ChartData>
    {
        new ChartData { XValue = new DateTime(2005, 01, 01), YValue = 21 },
        new ChartData { XValue = new DateTime(2006, 01, 01), YValue = 24 },
        new ChartData { XValue = new DateTime(2007, 01, 01), YValue = 36 },
        new ChartData { XValue = new DateTime(2008, 01, 01), YValue = 38 },
        new ChartData { XValue = new DateTime(2009, 01, 01), YValue = 54 },
        new ChartData { XValue = new DateTime(2010, 01, 01), YValue = 57 },
        new ChartData { XValue = new DateTime(2011, 01, 01), YValue = 70 }
    };
}

```

![Blazor Stock Chart with Custom Title](images/appearance/blazor-stock-chart-custom-title.webp)

## Stock Chart Theme

Changing the theme affects background color, gridlines, tooltip appearance, and overall styling.

Stock Chart supports several built-in themes such as `Material3`, `Fluent2`, `Bootstrap5`, `Tailwind3`, `HighContrast`, and their corresponding dark variants.

```cshtml

@using Syncfusion.Blazor.Charts

<SfStockChart Title="AAPL Stock Price" Theme="Syncfusion.Blazor.Theme.Bootstrap4">
    <StockChartSeriesCollection>
        <StockChartSeries DataSource="@DataSource" Type="ChartSeriesType.Line" XName="XValue" YName="YValue"></StockChartSeries>
    </StockChartSeriesCollection>
    <StockChartPeriods>
        <StockChartPeriod Text="1Y"></StockChartPeriod>
        <StockChartPeriod Text="All" Selected="true"></StockChartPeriod>
    </StockChartPeriods>
</SfStockChart>

@code {
    public class ChartData
    {
        public DateTime XValue { get; set; }
        public double YValue { get; set; }
    }

    public List<ChartData> DataSource = new List<ChartData>
    {
        new ChartData { XValue = new DateTime(2005, 01, 01), YValue = 21 },
        new ChartData { XValue = new DateTime(2006, 01, 01), YValue = 24 },
        new ChartData { XValue = new DateTime(2007, 01, 01), YValue = 36 },
        new ChartData { XValue = new DateTime(2008, 01, 01), YValue = 38 },
        new ChartData { XValue = new DateTime(2009, 01, 01), YValue = 54 },
        new ChartData { XValue = new DateTime(2010, 01, 01), YValue = 57 },
        new ChartData { XValue = new DateTime(2011, 01, 01), YValue = 70 }
    };
}

```

![Applying Theme in Blazor Stock Chart](images/appearance/blazor-stock-chart-with-theme.webp)

## See also

* [Axis Customization](./axis-customization)
