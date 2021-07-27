---
layout: post
title: Appearance in Blazor Stock Chart Component | Syncfusion
description: Learn here all about Appearance in Syncfusion Blazor Stock Chart component and more.
platform: Blazor
control: Stock Chart 
documentation: ug
---

# Appearance in Blazor Stock Chart Component

## Stock Chart Title

Stock Chart can be given a title using [`Title`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartModel.html#Syncfusion_Blazor_Charts_StockChartModel_Title) property, to show the information
about the data plotted.

```csharp

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
        public DateTime XValue;
        public double YValue;
    }

    public List<ChartData> DataSource = new List<ChartData>
{
        new ChartData { XValue = new DateTime(2005, 01, 01), YValue = 21 },
        new ChartData { XValue = new DateTime(2006, 01, 01), YValue = 24 },
        new ChartData { XValue = new DateTime(2007, 01, 01), YValue = 36 },
        new ChartData { XValue = new DateTime(2008, 01, 01), YValue = 38 },
        new ChartData { XValue = new DateTime(2009, 01, 01), YValue = 54 },
        new ChartData { XValue = new DateTime(2010, 01, 01), YValue = 57 },
        new ChartData { XValue = new DateTime(2011, 01, 01), YValue = 70 },
    };
}


```

![Title](images/appearance/title-razor.png)

<!-- markdownlint-disable MD036 -->

## Title Customizations

The `TextStyle` property of chart title provides options to customize the `Size`, `Color`, `FontFamily`, `FontWeight`, `FontStyle`, `Opacity`, `TextAlignment` and `TextOverflow`.

```csharp

@using Syncfusion.Blazor.Charts

<SfStockChart Title="AAPL Stock Price">
    <StockChartTitleStyle FontFamily="Arial" FontStyle="Italic" FontWeight="Regular" Color="#E27F2D" Size="20px" TextOverfLow="TextOverflow.Wrap"></StockChartTitleStyle>
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
        public DateTime XValue;
        public double YValue;
    }

    public List<ChartData> DataSource = new List<ChartData>
{
        new ChartData { XValue = new DateTime(2005, 01, 01), YValue = 21 },
        new ChartData { XValue = new DateTime(2006, 01, 01), YValue = 24 },
        new ChartData { XValue = new DateTime(2007, 01, 01), YValue = 36 },
        new ChartData { XValue = new DateTime(2008, 01, 01), YValue = 38 },
        new ChartData { XValue = new DateTime(2009, 01, 01), YValue = 54 },
        new ChartData { XValue = new DateTime(2010, 01, 01), YValue = 57 },
        new ChartData { XValue = new DateTime(2011, 01, 01), YValue = 70 },
    };
}

```

![Title Wrap](images/appearance/titlewrap-razor.png)

## Stock Chart Theme

Changing theme will affect background color, gridlines, tooltip colors and appearance.

Stock chart is shipped with several built-in themes such as `Material`, `Fabric`, `Bootstrap` , `HighContrastLight`, `MaterialDark`, `FabricDark`, `FabricDark`, `HighContrast` and `BootstrapDark`.

```csharp

@using Syncfusion.Blazor.Charts

<SfStockChart Title="AAPL Stock Price" Theme="ChartTheme.HighContrast">
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
        public DateTime XValue;
        public double YValue;
    }

    public List<ChartData> DataSource = new List<ChartData>
{
        new ChartData { XValue = new DateTime(2005, 01, 01), YValue = 21 },
        new ChartData { XValue = new DateTime(2006, 01, 01), YValue = 24 },
        new ChartData { XValue = new DateTime(2007, 01, 01), YValue = 36 },
        new ChartData { XValue = new DateTime(2008, 01, 01), YValue = 38 },
        new ChartData { XValue = new DateTime(2009, 01, 01), YValue = 54 },
        new ChartData { XValue = new DateTime(2010, 01, 01), YValue = 57 },
        new ChartData { XValue = new DateTime(2011, 01, 01), YValue = 70 },
    };
}

```

![Theme](images/appearance/theme-razor.png)

## See Also

* [Axis Customization](./axis-customization/)