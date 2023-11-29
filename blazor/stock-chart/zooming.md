---
layout: post
title: Zooming in Blazor Stock Chart Component | Syncfusion
description: Checkout and learn here all about Zooming functionality in Syncfusion Blazor Stock Chart component and more.
platform: Blazor
control: Stock Chart
documentation: ug
---

# Zooming in Blazor Stock Chart Component

## Enable zooming

The stock chart can be zoomed in three different ways.

* Selection - By setting [EnableSelectionZooming](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartZoomSettings.html#Syncfusion_Blazor_Charts_StockChartZoomSettings_EnableSelectionZooming) property to **true** in [StockChartZoomSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartZoomSettings.html), the stock chart can be zoomed using the rubber band selection.
* Mouse Wheel - By setting [EnableMouseWheelZooming](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartZoomSettings.html#Syncfusion_Blazor_Charts_StockChartZoomSettings_EnableMouseWheelZooming) property to **true** in [StockChartZoomSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartZoomSettings.html), the stock chart can be zoomed-in and zoomed-out by scrolling the mouse wheel.
* Pinch - By setting [EnablePinchZooming](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartZoomSettings.html#Syncfusion_Blazor_Charts_StockChartZoomSettings_EnablePinchZooming) property to **true** in [StockChartZoomSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartZoomSettings.html), the stock chart can be zoomed through pinch gesture in touch enabled devices.

 N> Pinch zooming is only usable in browsers that support multi-touch gestures.

```cshtml

@using Syncfusion.Blazor.Charts
@using System.IO
@using System.Runtime.Serialization
@inject NavigationManager NavigationManager
@inject HttpClient Http
@if (DataSource != null)
{
    <SfStockChart Title="AAPL Stock Price">
       <StockChartZoomSettings EnableMouseWheelZooming="true" EnablePinchZooming="true" EnableSelectionZooming="true"></StockChartZoomSettings>
            <StockChartPrimaryXAxis>
                <StockChartAxisMajorGridLines Width="0"></StockChartAxisMajorGridLines>
            </StockChartPrimaryXAxis>
            <StockChartPrimaryYAxis>
                <StockChartAxisLineStyle Width="0"></StockChartAxisLineStyle>
                <StockChartAxisMajorTickLines Width="0"></StockChartAxisMajorTickLines>
            </StockChartPrimaryYAxis>
            <StockChartSeriesCollection>
                <StockChartSeries DataSource="@DataSource" Type="ChartSeriesType.Candle"></StockChartSeries>
            </StockChartSeriesCollection>
            <StockChartChartArea>
                <StockChartChartAreaBorder Width="0"></StockChartChartAreaBorder>
            </StockChartChartArea>
    </SfStockChart>
}   

@code {
    public ChartData[] DataSource{ get; set; }

     public class ChartData
    {
        public DateTime date { get; set; }
        public double open { get; set; }
        public double low { get; set; }
        public double close { get; set; }
        public double high { get; set; }
        public double volume { get; set; }
    }   
    protected override async Task OnInitializedAsync()
      {
          DataSource = await Http.GetFromJsonAsync<ChartData[]>(NavigationManager.BaseUri +"./chart-data.json");
      }
}

```

![Zooming in Blazor Stock Chart](images/zooming/stock-chart-zoom.PNG)

A zooming toolbar will show after zooming the stock chart, featuring options for **Zoom**, **Zoom In**, **Zoom Out**, **Pan**, and **Reset**. The **Pan** option allows you to pan the stock chart, while the **Reset** option allows you to reset the zoomed stock chart.

## Modes

The [Mode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartZoomSettings.html#Syncfusion_Blazor_Charts_StockChartZoomSettings_Mode) property in [StockChartZoomSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartZoomSettings.html) determines whether the stock chart can scale along the horizontal or vertical axes. The default value of the mode is XY (both axis).

There are three types of modes.

* X - Allows us to zoom the chart horizontally.
* Y - Allows us to zoom the chart vertically.
* XY - Allows us to zoom the chart both vertically and horizontally.

```cshtml

@using Syncfusion.Blazor.Charts
@using System.IO
@using System.Runtime.Serialization
@inject NavigationManager NavigationManager
@inject HttpClient Http
@if (DataSource != null)
{
    <SfStockChart Title="AAPL Stock Price">
       <StockChartZoomSettings EnableSelectionZooming="true" Mode="ZoomMode.X"></StockChartZoomSettings>
            <StockChartPrimaryXAxis>
                <StockChartAxisMajorGridLines Width="0"></StockChartAxisMajorGridLines>
                <StockChartAxisCrosshairTooltip Enable="true"></StockChartAxisCrosshairTooltip>
            </StockChartPrimaryXAxis>
            <StockChartPrimaryYAxis>
                <StockChartAxisLineStyle Width="0"></StockChartAxisLineStyle>
                <StockChartAxisMajorTickLines Width="0"></StockChartAxisMajorTickLines>
            </StockChartPrimaryYAxis>
            <StockChartSeriesCollection>
                <StockChartSeries DataSource="@DataSource" Type="ChartSeriesType.Candle"></StockChartSeries>
            </StockChartSeriesCollection>
            <StockChartChartArea>
                <StockChartChartAreaBorder Width="0"></StockChartChartAreaBorder>
            </StockChartChartArea>
    </SfStockChart>
}    

@code {
    public ChartData[] DataSource{ get; set; }

     public class ChartData
    {
        public DateTime date { get; set; }
        public double open { get; set; }
        public double low { get; set; }
        public double close { get; set; }
        public double high { get; set; }
        public double volume { get; set; }
    }  

    protected override async Task OnInitializedAsync()
      {
          DataSource = await Http.GetFromJsonAsync<ChartData[]>(NavigationManager.BaseUri +"./chart-data.json");
      }
}

```

![Horizontal Zooming in Blazor Stock Chart](images/zooming/stock-chart-zoom.PNG)

## Toolbar

By default, zoom in, zoom out, pan, and reset buttons are available in the toolbar for zoomed stock chart. The [ToolbarItems](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartZoomSettings.html#Syncfusion_Blazor_Charts_StockChartZoomSettings_ToolbarItems) property specifies which tools should be displayed in the toolbar.

```cshtml

@using Syncfusion.Blazor.Charts
@using System.IO
@using System.Runtime.Serialization
@inject NavigationManager NavigationManager
@inject HttpClient Http
@if (DataSource != null)
{
    <SfStockChart Title="AAPL Stock Price">
       <StockChartZoomSettings EnableSelectionZooming="true" EnableMouseWheelZooming="true"
                       EnablePinchZooming="true" ToolbarItems="@ToolbarItem"></StockChartZoomSettings>
            <StockChartPrimaryXAxis>
                <StockChartAxisMajorGridLines Width="0"></StockChartAxisMajorGridLines>
                <StockChartAxisCrosshairTooltip Enable="true"></StockChartAxisCrosshairTooltip>
            </StockChartPrimaryXAxis>
            <StockChartPrimaryYAxis>
                <StockChartAxisLineStyle Width="0"></StockChartAxisLineStyle>
                <StockChartAxisMajorTickLines Width="0"></StockChartAxisMajorTickLines>
            </StockChartPrimaryYAxis>
            <StockChartSeriesCollection>
                <StockChartSeries DataSource="@DataSource" Type="ChartSeriesType.Candle"></StockChartSeries>
            </StockChartSeriesCollection>
            <StockChartChartArea>
                <StockChartChartAreaBorder Width="0"></StockChartChartAreaBorder>
            </StockChartChartArea>
    </SfStockChart>
}

@code {
    public List<ToolbarItems> ToolbarItem = new List<ToolbarItems>() { ToolbarItems.Zoom, ToolbarItems.Reset, ToolbarItems.Pan };
    public ChartData[] DataSource{ get; set; }

     public class ChartData
    {
        public DateTime date { get; set; }
        public double open { get; set; }
        public double low { get; set; }
        public double close { get; set; }
        public double high { get; set; }
        public double volume { get; set; }
    }   

    protected override async Task OnInitializedAsync()
      {
          DataSource = await Http.GetFromJsonAsync<ChartData[]>(NavigationManager.BaseUri +"./chart-data.json");
      }
}

```

![Zooming Option in Blazor Stock Chart Toolbar](images/zooming/stock-chart-zoom.PNG)

## Enable pan

By using the [EnablePan](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartZoomSettings.html#Syncfusion_Blazor_Charts_StockChartZoomSettings_EnablePan) property, one can pan the zoomed stock chart without the help of toolbar items.

```cshtml

@using Syncfusion.Blazor.Charts
@using System.IO
@using System.Runtime.Serialization
@inject NavigationManager NavigationManager
@inject HttpClient Http
@if (DataSource != null)
{
    <SfStockChart Title="AAPL Stock Price">
       <StockChartZoomSettings EnableSelectionZooming="true" EnablePan="true"></StockChartZoomSettings>
            <StockChartPrimaryXAxis ZoomFactor="0.2" ZoomPosition="0.6">
                <StockChartAxisMajorGridLines Width="0"></StockChartAxisMajorGridLines>
                <StockChartAxisCrosshairTooltip Enable="true"></StockChartAxisCrosshairTooltip>
            </StockChartPrimaryXAxis>
            <StockChartPrimaryYAxis>
                <StockChartAxisLineStyle Width="0"></StockChartAxisLineStyle>
                <StockChartAxisMajorTickLines Width="0"></StockChartAxisMajorTickLines>
            </StockChartPrimaryYAxis>
            <StockChartSeriesCollection>
                <StockChartSeries DataSource="@DataSource" Type="ChartSeriesType.Candle"></StockChartSeries>
            </StockChartSeriesCollection>
            <StockChartChartArea>
                <StockChartChartAreaBorder Width="0"></StockChartChartAreaBorder>
        </StockChartChartArea>
    </SfStockChart>
}    

@code {
    
    public ChartData[] DataSource{ get; set; }

     public class ChartData
    {
        public DateTime date { get; set; }
        public double open { get; set; }
        public double low { get; set; }
        public double close { get; set; }
        public double high { get; set; }
        public double volume { get; set; }
    }   

    protected override async Task OnInitializedAsync()
      {
          DataSource = await Http.GetFromJsonAsync<ChartData[]>(NavigationManager.BaseUri +"./chart-data.json");
      }
}

```

![Zooming with Pan in Blazor Stock Chart Toolbar](images/zooming/stock-chart-pan.PNG)

## Enable scrollbar

The [EnableScrollbar](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartZoomSettings.html#Syncfusion_Blazor_Charts_StockChartZoomSettings_EnableScrollbar) property can be used to add a scrollbar to a zoomed stock chart. The stock chart can be panned or zoomed using this scrollbar.

```cshtml

@using Syncfusion.Blazor.Charts
@using System.IO
@using System.Runtime.Serialization
@inject NavigationManager NavigationManager
@inject HttpClient Http
@if (DataSource != null)
{
    <SfStockChart Title="AAPL Stock Price">
       <StockChartZoomSettings EnableMouseWheelZooming="true" EnableScrollbar="true" EnablePinchZooming="true"
                       EnableSelectionZooming="true"></StockChartZoomSettings>
            <StockChartPrimaryXAxis>
                <StockChartAxisMajorGridLines Width="0"></StockChartAxisMajorGridLines>
                <StockChartAxisCrosshairTooltip Enable="true"></StockChartAxisCrosshairTooltip>
            </StockChartPrimaryXAxis>
            <StockChartPrimaryYAxis>
                <StockChartAxisLineStyle Width="0"></StockChartAxisLineStyle>
                <StockChartAxisMajorTickLines Width="0"></StockChartAxisMajorTickLines>
            </StockChartPrimaryYAxis>
            <StockChartSeriesCollection>
                <StockChartSeries DataSource="@DataSource" Type="ChartSeriesType.Candle"></StockChartSeries>
            </StockChartSeriesCollection>
            <StockChartChartArea>
                <StockChartChartAreaBorder Width="0"></StockChartChartAreaBorder>
        </StockChartChartArea>
    </SfStockChart>
}

@code {
    
    public ChartData[] DataSource{ get; set; }

     public class ChartData
    {
        public DateTime date { get; set; }
        public double open { get; set; }
        public double low { get; set; }
        public double close { get; set; }
        public double high { get; set; }
        public double volume { get; set; }
    }   

    protected override async Task OnInitializedAsync()
      {
          DataSource = await Http.GetFromJsonAsync<ChartData[]>(NavigationManager.BaseUri +"./chart-data.json");
      }
}

```

![Zooming with Scrollbar in Blazor Stock Chart](images/zooming/stock-chart-scrollbar.PNG)

## Auto interval on zooming

The axis interval will be calculated automatically with respect to the zoomed range, if the [EnableAutoIntervalOnZooming](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartCommonAxis.html#Syncfusion_Blazor_Charts_StockChartCommonAxis_EnableAutoIntervalOnZooming) property is set to **true**.

```cshtml

@using Syncfusion.Blazor.Charts
@using System.IO
@using System.Runtime.Serialization
@inject NavigationManager NavigationManager
@inject HttpClient Http
@if (DataSource != null)
{
    <SfStockChart Title="AAPL Stock Price">
       <StockChartZoomSettings EnableMouseWheelZooming="true" EnablePinchZooming="true"
                       EnableSelectionZooming="true"></StockChartZoomSettings>
            <StockChartPrimaryXAxis EnableAutoIntervalOnZooming="true">
                <StockChartAxisMajorGridLines Width="0"></StockChartAxisMajorGridLines>
                <StockChartAxisCrosshairTooltip Enable="true"></StockChartAxisCrosshairTooltip>
            </StockChartPrimaryXAxis>
            <StockChartPrimaryYAxis>
                <StockChartAxisLineStyle Width="0"></StockChartAxisLineStyle>
                <StockChartAxisMajorTickLines Width="0"></StockChartAxisMajorTickLines>
            </StockChartPrimaryYAxis>
            <StockChartSeriesCollection>
                <StockChartSeries DataSource="@DataSource" Type="ChartSeriesType.Candle"></StockChartSeries>
            </StockChartSeriesCollection>
            <StockChartChartArea>
                <StockChartChartAreaBorder Width="0"></StockChartChartAreaBorder>
            </StockChartChartArea>
    </SfStockChart>
}

@code {
    
    public ChartData[] DataSource{ get; set; }

     public class ChartData
    {
        public DateTime date { get; set; }
        public double open { get; set; }
        public double low { get; set; }
        public double close { get; set; }
        public double high { get; set; }
        public double volume { get; set; }
    }   

    protected override async Task OnInitializedAsync()
      {
          DataSource = await Http.GetFromJsonAsync<ChartData[]>(NavigationManager.BaseUri +"./chart-data.json");
      }
}

```

![Auto Interval on Zooming in Blazor Area Chart](images/zooming/stock-chart-autointerval.PNG)

N> Refer to our [Blazor Stock Charts](https://www.syncfusion.com/blazor-components/blazor-stock-chart) feature tour page for its groundbreaking feature representations and also explore our [Blazor Stock Chart Example](https://blazor.syncfusion.com/demos/stock-chart/stock-chart?theme=bootstrap5) to know various stock chart types and how to represent time-dependent data, showing trends at equal intervals.