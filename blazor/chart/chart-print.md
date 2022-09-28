---
layout: post
title: Print and Export in Blazor Charts Component | Syncfusion
description: Checkout and learn here all about Print and Export in Syncfusion Blazor Charts component and much more.
platform: Blazor
control: Chart
documentation: ug
---

# Print and Export in Blazor Charts Component

## Print

The `PrintAsync` method can be used to print a rendered chart directly from the browser.

```cshtml

@using Syncfusion.Blazor.Charts
@using Syncfusion.Blazor.Buttons

<SfChart @ref="ChartObj" Title="Inflation - Consumer Price">
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category">
    </ChartPrimaryXAxis>

    <ChartSeriesCollection>
        <ChartSeries DataSource="@ConsumerDetails" XName="X" YName="YValue" Type="ChartSeriesType.Column">
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

<SfButton Id="button" Content="Print" @onclick="Print"  IsPrimary="true" CssClass="e-flat"></SfButton>

@code{

    SfChart ChartObj;

    private async Task Print(MouseEventArgs args)
    {
        await ChartObj.PrintAsync();
    }

    public class ChartData
    {
        public string X { get; set; }
        public double YValue { get; set; }
    }

    public List<ChartData> ConsumerDetails = new List<ChartData>
	{
        new ChartData { X= "USA", YValue= 46 },
        new ChartData { X= "GBR", YValue= 27 },
        new ChartData { X= "CHN", YValue= 26 },
        new ChartData { X= "UK", YValue= 36 },
        new ChartData { X= "AUS", YValue= 15 },
        new ChartData { X= "IND", YValue= 55 },
        new ChartData { X= "DEN", YValue= 40 },
        new ChartData { X= "MEX", YValue= 30 }
    };
}

```

![Printing in Blazor Chart](images/getting-started/blazor-chart-printing.png)

## Print all our chart component 

The `PrintAsync` method can be used to print all our Chart component rendered chart directly from the browser.

```cshtml

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Charts
@using Syncfusion.Blazor.Buttons
@using System.Net.Http.Json
@inject HttpClient Http
@using Syncfusion.Blazor.Layouts
@using System.Timers
@inject NavigationManager NavigationManager

<style>
    .e-dashboardlayout {
        padding: 20px;
        z-index: 0;
    }
    .e-panel {
        cursor: auto !important;
    }
   
    .title {
		font-size: 13px;
        font-weight: 500;
    }
</style>

<div class="row">
  <div class="col-lg-9 property-section">
    <div class="property-panel-section">
        <div class="property-panel-content">
            <table style="width: 100%">
                <tbody>
                    <tr style="height: 50px; text-align: left">
                        <td>
                           <b>Print the chart - <SfButton ID="button" IsPrimary="true" IsToggle="true" OnClick="PrintChart">Print</SfButton></b>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
  </div>
</div>
<div class="control-section" @ref="Element"> 
    <SfDashboardLayout CellSpacing="@(new double[]{15 ,15 })" CellAspectRatio="0.8" Columns="8">
        <DashboardLayoutPanels>
            <DashboardLayoutEvents Created="LayoutCreated"></DashboardLayoutEvents>
            <DashboardLayoutPanel Column="0" Row="0" SizeX="4" SizeY="2">
                <HeaderTemplate>
					<span class="title">Sales Comparision</span>
				</HeaderTemplate>
                <ContentTemplate>
                    @if (isLayoutRender)
                    {
                      <SfChart Height="200" @ref="chart1">
                        <ChartArea><ChartAreaBorder Width="0"></ChartAreaBorder></ChartArea>
                        <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" Interval="1">
                            <ChartAxisMajorGridLines Width="0"></ChartAxisMajorGridLines>
                        </ChartPrimaryXAxis>
                        <ChartPrimaryYAxis Minimum="0" Maximum="20" Interval="4" LabelFormat="${value}k">
                            <ChartAxisMajorGridLines Width="2"></ChartAxisMajorGridLines>
                            <ChartAxisMajorTickLines Width="0"></ChartAxisMajorTickLines>
                            <ChartAxisLineStyle Width="0"></ChartAxisLineStyle>
                        </ChartPrimaryYAxis>
                        <ChartSeriesCollection>
                            <ChartSeries DataSource="@ChartPoints" XName="Manager" YName="SalesInfo" Type="ChartSeriesType.Column">
                                <ChartMarker>
                                    <ChartDataLabel Visible="true" Name="DataLabelMappingName" Position="Syncfusion.Blazor.Charts.LabelPosition.Top">
                                        <ChartDataLabelFont FontWeight="600" Color="#ffffff"></ChartDataLabelFont>
                                    </ChartDataLabel>
                                </ChartMarker>
                            </ChartSeries>
                        </ChartSeriesCollection>
                     </SfChart>
                    }
                </ContentTemplate>
            </DashboardLayoutPanel>
            <DashboardLayoutPanel Column="4" Row="0" SizeX="4" SizeY="2">
                <HeaderTemplate>
					<span class="title">Product Wise Sales - 2021</span>
				</HeaderTemplate>
                <ContentTemplate>
                        @if (isLayoutRender)
                        {
                             <SfAccumulationChart EnableAnimation="true">
                                <AccumulationChartBorder Color="transparent"></AccumulationChartBorder>
                                <AccumulationChartTooltipSettings Enable="true" Format="${point.x}"></AccumulationChartTooltipSettings>
                                <AccumulationChartSeriesCollection>
                                    <AccumulationChartSeries DataSource="@PieChartDataCollection" XName="Product" YName="Percentage" Radius="80%" InnerRadius="40%" Palettes="@palettes">
                                        <AccumulationDataLabelSettings Visible="true" Name="TextMapping" Position="AccumulationLabelPosition.Outside">
                                            <AccumulationChartConnector Length="8px"></AccumulationChartConnector>
                                        </AccumulationDataLabelSettings>
                                    </AccumulationChartSeries>
                                </AccumulationChartSeriesCollection>
                                <AccumulationChartLegendSettings Width="130px" ShapePadding="10" Padding="10">
                                    <AccumulationChartLegendFont Size="10px"></AccumulationChartLegendFont>
                                </AccumulationChartLegendSettings>
                            </SfAccumulationChart>
                        }
                </ContentTemplate>
            </DashboardLayoutPanel>
            <DashboardLayoutPanel Column="0" Row="4" SizeX="4" SizeY="2">
                <HeaderTemplate>
					<span class="title" style="margin-left:25%">Crude Steel Production Annual Growth</span>
				</HeaderTemplate>
                <ContentTemplate>
                    @if (isLayoutRender)
                    {
                        <SfChart @ref="chart2" >
                        <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" EdgeLabelPlacement="EdgeLabelPlacement.Shift">
                        </ChartPrimaryXAxis>
                        <ChartPrimaryYAxis Title="Million Metric Tons" Minimum="0" Maximum="20" Interval="4">
                        </ChartPrimaryYAxis>
                        <ChartTooltipSettings Enable="true"></ChartTooltipSettings>
                        <ChartSeriesCollection>
                            <ChartSeries DataSource="@ChartDatas" Name="Vietnam" XName="Period" Width="2"
                                            Opacity="1" YName="Viet_Growth" Type="ChartSeriesType.Line">
                                <ChartMarker Visible="true" Width="7" Height="7" IsFilled="true" Shape="ChartShape.Circle">
                                </ChartMarker>
                            </ChartSeries>
                            <ChartSeries DataSource="@ChartDatas" Name="Canada" XName="Period" Width="2"
                                            Opacity="1" YName="Can_Growth" Type="ChartSeriesType.Line">
                                <ChartMarker Visible="true" Width="6" IsFilled="true" Height="6" Shape="ChartShape.Triangle">
                                </ChartMarker>
                            </ChartSeries>
                            <ChartSeries DataSource="@ChartDatas" Name="Malaysia" XName="Period" Width="2"
                                            Opacity="1" YName="Mal_Growth" Type="ChartSeriesType.Line">
                                <ChartMarker Visible="true" Width="7" IsFilled="true" Height="7" Shape="ChartShape.Diamond">
                                </ChartMarker>
                            </ChartSeries>
                        </ChartSeriesCollection>
                        <ChartLegendSettings Visible="false"></ChartLegendSettings>
                </SfChart>
                     }
                </ContentTemplate>
            </DashboardLayoutPanel>
            <DashboardLayoutPanel Column="4" Row="4" SizeX="4" SizeY="2">
                <HeaderTemplate>
					<span class="title" style="margin-left:30%">NC Weather Report - 2016</span>
				</HeaderTemplate>
                <ContentTemplate>
                    @if (isLayoutRender)
                    {
                        <SfChart @ref="chartInstance">
                            <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" Interval="1" LabelIntersectAction="LabelIntersectAction.Rotate90">
                            </ChartPrimaryXAxis>
                            <ChartPrimaryYAxis LabelFormat="{value}°C">
                            </ChartPrimaryYAxis>
                            <ChartTooltipSettings Enable="true"></ChartTooltipSettings>
                            <ChartLegendSettings Visible="false"></ChartLegendSettings>
                            <ChartSeriesCollection>
                                <ChartSeries DataSource="@SplineData" Name="Max Temp" XName="Days" Width="2"
                                             Opacity="1" YName="MaxTemp" Type="ChartSeriesType.Spline">
                                    <ChartMarker Visible="true" Width="7" Height="7">
                                    </ChartMarker>
                                </ChartSeries>
                                <ChartSeries DataSource="@SplineData" Name="Avg Temp" XName="Days" Width="2"
                                             Opacity="1" YName="AvgTemp" Type="ChartSeriesType.Spline">
                                    <ChartMarker Visible="true" Width="7" Height="7">
                                    </ChartMarker>
                                </ChartSeries>
                                <ChartSeries DataSource="@SplineData" Name="Min Temp" XName="Days" Width="2"
                                             Opacity="1" YName="MinTemp" Type="ChartSeriesType.Spline">
                                    <ChartMarker Visible="true" Width="7" Height="7">
                                    </ChartMarker>
                                </ChartSeries>
                            </ChartSeriesCollection>
                     </SfChart>
                     }
                </ContentTemplate>
            </DashboardLayoutPanel>
            <DashboardLayoutPanel Column="0" Row="8" SizeX="4" SizeY="2">
                <HeaderTemplate>
					<span class="title" style="margin-left:30%">Inflation Rate in Percentage</span>
				</HeaderTemplate>
                <ContentTemplate>
                    @if (isLayoutRender)
                    {
                       <SfChart>
                            <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.DateTimeCategory" LabelFormat="yyyy" IntervalType="IntervalType.Years" EdgeLabelPlacement="EdgeLabelPlacement.Shift">
                            </ChartPrimaryXAxis>
                            <ChartPrimaryYAxis LabelFormat="{value}%" Minimum="0" Maximum="4" Interval="1">
                            </ChartPrimaryYAxis>
                            <ChartTooltipSettings Enable="true"></ChartTooltipSettings>
                            <ChartLegendSettings Visible="false"></ChartLegendSettings>
                            <ChartSeriesCollection>
                                <ChartSeries DataSource="@AreaChartPoints" Name="US" XName="Period" Width="2"
                                             Opacity="0.5" YName="US_InflationRate" Type="ChartSeriesType.SplineArea">
                                    <ChartSeriesBorder Width="2"></ChartSeriesBorder>
                                    <ChartMarker IsFilled="true" Visible="true" Width="6" Height="6" Shape="ChartShape.Circle"></ChartMarker>
                                </ChartSeries>
                                <ChartSeries DataSource="@AreaChartPoints" Name="France" XName="Period" Width="2"
                                             Opacity="0.5" YName="FR_InflationRate" Type="ChartSeriesType.SplineArea">
                                    <ChartSeriesBorder Width="2"></ChartSeriesBorder>
                                    <ChartMarker IsFilled="true" Visible="true" Height="7" Width="7" Shape="ChartShape.Diamond"></ChartMarker>
                                </ChartSeries>
                            </ChartSeriesCollection>
                        </SfChart>
                    }
                </ContentTemplate>
            </DashboardLayoutPanel>
            <DashboardLayoutPanel Column="4" Row="4" SizeX="4" SizeY="2">
                <HeaderTemplate>
					<span class="title" style="margin-left:40%">Wind Rose Chart</span>
				</HeaderTemplate>
                <ContentTemplate>
                    @if (isLayoutRender)
                    {
                        <SfChart>
                            <ChartPrimaryXAxis Interval="1" ValueType="Syncfusion.Blazor.Charts.ValueType.Category" Coefficient="100" LabelPlacement="LabelPlacement.OnTicks">
                            </ChartPrimaryXAxis>
                            <ChartLegendSettings Visible="false"></ChartLegendSettings>
                            <ChartTooltipSettings Enable="true"></ChartTooltipSettings>
                            <ChartSeriesCollection>
                                <ChartSeries DataSource="@WindChartPoints" Name="6-9" XName="XValue" Width="2" YName="YValue" Type="@SeriesType" DrawType="ChartDrawType.StackingColumn">
                                </ChartSeries>
                                <ChartSeries DataSource="@WindChartPoints" Name="9-11" XName="XValue" Width="2" YName="YValue1" Type="@SeriesType" DrawType="ChartDrawType.StackingColumn">
                                </ChartSeries>
                                <ChartSeries DataSource="@WindChartPoints" Name="11-14" XName="XValue" Width="2" YName="YValue2" Type="@SeriesType" DrawType="ChartDrawType.StackingColumn">
                                </ChartSeries>
                                <ChartSeries DataSource="@WindChartPoints" Name="14-17" XName="XValue" Width="2" YName="YValue3" Type="@SeriesType" DrawType="ChartDrawType.StackingColumn">
                                </ChartSeries>
                                <ChartSeries DataSource="@WindChartPoints" Name="17-20" XName="XValue" Width="2" YName="YValue4" Type="@SeriesType" DrawType="ChartDrawType.StackingColumn">
                                </ChartSeries>
                                <ChartSeries DataSource="@WindChartPoints" Name="23 Above" XName="XValue" Width="2" YName="YValue5" Type="@SeriesType" DrawType="ChartDrawType.StackingColumn">
                                </ChartSeries>
                            </ChartSeriesCollection>
                        </SfChart>
                    }
                </ContentTemplate>
            </DashboardLayoutPanel>
        </DashboardLayoutPanels>
    </SfDashboardLayout>
</div>

@code {
    private SfChart chartInstance; 
    private ElementReference Element;
    private bool isLayoutRender;
    private static Timer timer;
    SfChart chart1;
    SfChart chart2;

    private string[] palettes = new string[] { "#61EFCD", "#CDDE1F", "#FEC200", "#CA765A", "#2485FA", "#F57D7D", "#C152D2",
    "#8854D9", "#3D4EB8", "#00BCD7","#4472c4", "#ed7d31", "#ffc000", "#70ad47", "#5b9bd5", "#c1c1c1", "#6f6fe2", "#e269ae", "#9e480e", "#997300" };

   public List<ExportData> ChartPoints { get; set; } = new List<ExportData>
   {
        new ExportData { Manager = "John", SalesInfo = 10, DataLabelMappingName="$10k"},
        new ExportData { Manager = "Jake", SalesInfo = 12, DataLabelMappingName="$12k"},
        new ExportData { Manager = "Peter", SalesInfo = 18, DataLabelMappingName="$18k"},
        new ExportData { Manager = "James", SalesInfo = 11, DataLabelMappingName="$11k"},
        new ExportData { Manager = "Mary", SalesInfo = 9.7, DataLabelMappingName="$9.7k"}
   };

    public List<ChartData> PieChartDataCollection { get; set; } = new List<ChartData>
    {
        new ChartData { Product = "EarPods : 6%", Percentage = 6, TextMapping = "EarPods"},
        new ChartData { Product = "TV : 12%", Percentage = 12, TextMapping = "TV"},
        new ChartData { Product = "iPad : 10%", Percentage = 10, TextMapping = "iPad"},
        new ChartData { Product = "PC : 8%", Percentage = 8, TextMapping = "PC"},
        new ChartData { Product = "Laptop : 16%",  Percentage = 16, TextMapping = "Laptop"},
        new ChartData { Product = "Mobile : 36%", Percentage = 36, TextMapping = "Mobile"},
        new ChartData { Product = "Camera : 11%", Percentage = 11, TextMapping = "Camera"}
    };

    List<ChartData1> Data = new List<ChartData1>
    {
        new ChartData1 { x = new DateTime(1950, 1, 12), high = 125, low = 70,  open = 115, close = 90 , volume=10000 },
        new ChartData1 { x = new DateTime(1953, 1, 12), high = 150, low = 60,  open = 120, close = 70 , volume=35000 },
        new ChartData1 { x = new DateTime(1956, 1, 12), high = 200, low = 140, open = 160, close = 190, volume=20400 },
        new ChartData1 { x = new DateTime(1959, 1, 12), high = 160, low = 90,  open = 140, close = 110, volume=56000 },
        new ChartData1 { x = new DateTime(1962, 1, 12), high = 200, low = 100, open = 180, close = 120, volume=10000 },
        new ChartData1 { x = new DateTime(1965, 1, 12), high = 100, low = 45,  open = 70,  close = 50 , volume=87000 },
        new ChartData1 { x = new DateTime(1968, 1, 12), high = 150, low = 70,  open = 140, close = 130, volume=90000 },
        new ChartData1 { x = new DateTime(1971, 1, 12), high = 90,  low = 60,  open = 65,  close = 80 , volume=22000 },
        new ChartData1 { x = new DateTime(1974, 1, 12), high = 225, low = 170, open = 175, close = 220, volume=52000 },
        new ChartData1 { x = new DateTime(1977, 1, 12), high = 250, low = 180, open = 223, close = 190, volume=12000 },
        new ChartData1 { x = new DateTime(1980, 1, 12), high = 200, low = 140, open = 160, close = 190, volume=340000},
        new ChartData1 { x = new DateTime(1983, 1, 12), high = 160, low = 90,  open = 140, close = 110, volume=66000 },
        new ChartData1 { x = new DateTime(1986, 1, 12), high = 200, low = 100, open = 180, close = 120, volume=72000 },
        new ChartData1 { x = new DateTime(1989, 1, 12), high = 130, low = 95,  open = 120, close = 100, volume=45000 },
        new ChartData1 { x = new DateTime(1991, 1, 12), high = 100, low = 70,  open = 92,  close = 75 , volume=78000 },
        new ChartData1 { x = new DateTime(1994, 1, 12), high = 50,  low = 85,  open = 65,  close = 80 , volume=23000 },
        new ChartData1 { x = new DateTime(1997, 1, 12), high = 185, low = 110, open = 130, close = 170, volume=73000 },
        new ChartData1 { x = new DateTime(2000, 1, 12), high = 90,  low = 30,  open = 80,  close = 50 , volume=81000 },
        new ChartData1 { x = new DateTime(2003, 1, 12), high = 200, low = 140, open = 160, close = 190, volume=39000 },
        new ChartData1 { x = new DateTime(2006, 1, 12), high = 170, low = 90,  open = 140, close = 110, volume=41000 },
        new ChartData1 { x = new DateTime(2008, 1, 12), high = 200, low = 100, open = 180, close = 120, volume=57000 }
    };

    public List<SplineChartData> SplineData = new List<SplineChartData>
    {
        new SplineChartData { Days = "Sun", MaxTemp = 15, AvgTemp = 10, MinTemp = 2 },
        new SplineChartData { Days = "Mon", MaxTemp = 22, AvgTemp = 18, MinTemp = 12 },
        new SplineChartData { Days = "Tue", MaxTemp = 32, AvgTemp = 28, MinTemp = 22 },
        new SplineChartData { Days = "Wed", MaxTemp = 31, AvgTemp = 28, MinTemp = 23 },
        new SplineChartData { Days = "Thu", MaxTemp = 29, AvgTemp = 26, MinTemp = 19 },
        new SplineChartData { Days = "Fri", MaxTemp = 24, AvgTemp = 20, MinTemp = 13 },
        new SplineChartData { Days = "Sat", MaxTemp = 18, AvgTemp = 15, MinTemp = 8 }
    };
  

    private ChartSeriesType SeriesType { get; set; } = ChartSeriesType.Polar;
    public List<PolarWindRoseData> WindChartPoints { get; set; } = new List<PolarWindRoseData>
    {
        new PolarWindRoseData { XValue = "N", YValue= 1, YValue1= 0.8, YValue2= 0.8, YValue3= 0.3, YValue4= 0.2, YValue5= 0.2 },
        new PolarWindRoseData { XValue = "NNE", YValue= 0.9, YValue1= 0.7, YValue2= 0.7, YValue3= 0.3, YValue4= 0.2, YValue5= 0.2 },
        new PolarWindRoseData { XValue = "NE", YValue= 0.7, YValue1= 0.8, YValue2= 0.5, YValue3= 1.1, YValue4= 1.2, YValue5= 0.5 },
        new PolarWindRoseData { XValue = "ENE", YValue= 0.9, YValue1= 1, YValue2= 0.4, YValue3= 0.9, YValue4= 1, YValue5= 0.4 },
        new PolarWindRoseData { XValue = "E", YValue= 0.9, YValue1= 0.6, YValue2= 0.9, YValue3= 0.5, YValue4= 0.7, YValue5= 0.4 },
        new PolarWindRoseData { XValue = "ESE", YValue= 0.8, YValue1= 0.5, YValue2= 0.7, YValue3= 0.3, YValue4= 0.8, YValue5= 0.3 },
        new PolarWindRoseData { XValue = "SE", YValue= 0.7, YValue1= 0.4, YValue2= 0.6, YValue3= 0.5, YValue4= 0.5, YValue5= 0.3 },
        new PolarWindRoseData { XValue = "SSE", YValue= 1.4, YValue1= 0.4, YValue2= 0.5, YValue3= 0.4, YValue4= 0.6, YValue5= 0.2 },
        new PolarWindRoseData { XValue = "S", YValue= 2, YValue1= 1.2, YValue2= 0.6, YValue3= 0.6, YValue4= 0.4, YValue5= 0.4 },
        new PolarWindRoseData { XValue = "SSW", YValue= 2, YValue1= 2.5, YValue2= 2, YValue3= 1, YValue4= 0.5, YValue5= 0.3 },
        new PolarWindRoseData { XValue = "SW", YValue= 2.2, YValue1= 2, YValue2= 1.8, YValue3= 1, YValue4= 0.4, YValue5= 0.2 },
        new PolarWindRoseData { XValue = "WSW", YValue= 1.8, YValue1= 1.1, YValue2= 0.8, YValue3= 0.1, YValue4= 0.4, YValue5= 0.2 },
        new PolarWindRoseData { XValue = "W", YValue= 1.6, YValue1= 1.8, YValue2= 2.1, YValue3= 1, YValue4= 0.4, YValue5= 0.4 },
        new PolarWindRoseData { XValue = "WNW", YValue= 1.2, YValue1= 1.2, YValue2= 1.5, YValue3= 1.3, YValue4= 1.1, YValue5= 1.2 },
        new PolarWindRoseData { XValue = "NW", YValue= 2, YValue1= 2.5, YValue2= 2, YValue3= 1, YValue4= 0.2, YValue5= 0.7 },
        new PolarWindRoseData { XValue = "NNW", YValue= 1.8, YValue1= 1.1, YValue2= 0.8, YValue3= 0.1, YValue4= 0.4, YValue5= 0.2 }
    };

    public List<SplineAreaChartData> AreaChartPoints { get; set; } = new List<SplineAreaChartData>
     {
        new SplineAreaChartData { Period = new DateTime(2002, 01, 01), US_InflationRate = 2.2, FR_InflationRate = 2, GER_InflationRate = 0.8  },
        new SplineAreaChartData { Period = new DateTime(2003, 01, 01), US_InflationRate = 3.4, FR_InflationRate = 1.7, GER_InflationRate = 1.3 },
        new SplineAreaChartData { Period = new DateTime(2004, 01, 01), US_InflationRate = 2.8, FR_InflationRate = 1.8, GER_InflationRate = 1.1 },
        new SplineAreaChartData { Period = new DateTime(2005, 01, 01), US_InflationRate = 1.6, FR_InflationRate = 2.1, GER_InflationRate = 1.6 },
        new SplineAreaChartData { Period = new DateTime(2006, 01, 01), US_InflationRate = 2.3, FR_InflationRate = 2.3, GER_InflationRate = 2 },
        new SplineAreaChartData { Period = new DateTime(2007, 01, 01), US_InflationRate = 2.5, FR_InflationRate = 1.7, GER_InflationRate = 1.7 },
        new SplineAreaChartData { Period = new DateTime(2008, 01, 01), US_InflationRate = 2.9, FR_InflationRate = 1.5, GER_InflationRate = 2.3 },
        new SplineAreaChartData { Period = new DateTime(2009, 01, 01), US_InflationRate = 1.1, FR_InflationRate = 0.5, GER_InflationRate = 2.7 },
        new SplineAreaChartData { Period = new DateTime(2010, 01, 01), US_InflationRate = 1.4, FR_InflationRate = 1.5, GER_InflationRate = 1.1 },
        new SplineAreaChartData { Period = new DateTime(2011, 01, 01), US_InflationRate = 1.1, FR_InflationRate = 1.3, GER_InflationRate = 1.5 }
    };

      public List<LineChartData> ChartDatas = new List<LineChartData>
    {
        new LineChartData { Period = 2020, Can_Growth = 11.0, Viet_Growth = 19.5, Mal_Growth = 7.1, Egy_Growth = 8.2, Ind_Growth = 9.3 },
        new LineChartData { Period = 2019, Can_Growth = 12.9, Viet_Growth = 17.5, Mal_Growth = 6.8, Egy_Growth = 7.3, Ind_Growth = 7.8 },
        new LineChartData { Period = 2018, Can_Growth = 13.4, Viet_Growth = 15.5, Mal_Growth = 4.1, Egy_Growth = 7.8, Ind_Growth = 6.2  },
        new LineChartData { Period = 2017, Can_Growth = 13.7, Viet_Growth = 10.3, Mal_Growth = 2.8, Egy_Growth = 6.8, Ind_Growth = 5.3 },
        new LineChartData { Period = 2016, Can_Growth = 12.7, Viet_Growth = 7.8, Mal_Growth = 2.8, Egy_Growth = 5.0, Ind_Growth = 4.8 },
        new LineChartData { Period = 2015, Can_Growth = 12.5, Viet_Growth = 5.7, Mal_Growth = 3.8, Egy_Growth = 5.5, Ind_Growth = 4.9 },
        new LineChartData { Period = 2014, Can_Growth = 12.7, Viet_Growth = 5.9, Mal_Growth = 4.3, Egy_Growth = 6.5, Ind_Growth = 4.4 },
        new LineChartData { Period = 2013, Can_Growth = 12.4, Viet_Growth = 5.6, Mal_Growth = 4.7, Egy_Growth = 6.8, Ind_Growth = 2.6 },
        new LineChartData { Period = 2012, Can_Growth = 13.5, Viet_Growth = 5.3, Mal_Growth = 5.6, Egy_Growth = 6.6, Ind_Growth = 2.3 }
    };

     public class SplineChartData
    {
        public string Days { get; set; }
        public double MaxTemp { get; set; }
        public double AvgTemp { get; set; }
        public double MinTemp { get; set; }
    }
    public class SplineAreaChartData
    {
        public DateTime Period { get; set; }
        public double US_InflationRate { get; set; }
        public double FR_InflationRate { get; set; }
        public double GER_InflationRate { get; set; }
    }

     public class ChartData
    {
        public string Period { get; set; }
        public string Product { get; set; }
        public double Percentage { get; set; }
        public string TextMapping { get; set; }
        public string AnnotationX { get; set; }
        public string AnnotationY { get; set; }
    }

    public class ChartData1
    {
        public DateTime x { get; set; }
        public decimal high { get; set; }
        public decimal low { get; set; }
        public decimal open { get; set; }
        public decimal close { get; set; }
        public decimal volume { get; set; }
    }

    public class ExportData
    {
        public string Manager { get; set; }
        public double SalesInfo { get; set; }
        public string DataLabelMappingName{ get; set; }
    }

     
    public class PolarWindRoseData
    {
        public string XValue { get; set; }
        public double YValue { get; set; }
        public double YValue1 { get; set; }
        public double YValue2 { get; set; }
        public double YValue3 { get; set; }
        public double YValue4 { get; set; }
        public double YValue5 { get; set; }
    }
    
    public class LineChartData
    {
        public double Period { get; set; }
        public double Can_Growth { get; set; }
        public double Viet_Growth { get; set; }
        public double Mal_Growth { get; set; }
        public double Egy_Growth { get; set; }
        public double Ind_Growth { get; set; }
    }

    public void LayoutCreated()
    {
        isLayoutRender = true;
        timer = new Timer(1000);
        timer.Elapsed += RefreshCharts;
        timer.AutoReset = true;
        timer.Enabled = true;
    }

     

    private void RefreshCharts(Object source, ElapsedEventArgs e)
    {
        if (chart1 == null && chart2 == null)
            return;
        chart1.RefreshAsync(false);
        chart2.Refresh();
        timer.Enabled = false;
        timer.AutoReset = false;
    }
  
   
    public async Task PrintChart(MouseEventArgs args)
    {
        await chartInstance.PrintAsync(Element);
    }
}
```

![Blazor Print all our charts](images/getting-started/blazor-chart-print-all-charts.png)
## Export

Using the `ExportAsync` method, the rendered chart can be exported to [JPEG](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ExportType.html#Syncfusion_Blazor_Charts_ExportType_JPEG), [PNG](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ExportType.html#Syncfusion_Blazor_Charts_ExportType_PNG), [SVG](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ExportType.html#Syncfusion_Blazor_Charts_ExportType_SVG), or [PDF](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ExportType.html#Syncfusion_Blazor_Charts_ExportType_PDF) format. The [Export Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ExportType.html) specifies the image format and `FileName` specifies the name of the exported file. Both of these parameters are required input parameters for this method.

The optional parameters for this method are,
* `Orientation` - Specifies the portrait or landscape orientation in the PDF document.
* `AllowDownload` - Specifies whether to download or not. If not, base64 string will be returned.

```cshtml

@using Syncfusion.Blazor.Charts
@using Syncfusion.Blazor.Buttons

<SfChart @ref="ChartObj" Title="Inflation - Consumer Price">
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category">
    </ChartPrimaryXAxis>

    <ChartSeriesCollection>
        <ChartSeries DataSource="@ConsumerDetails" XName="X" YName="YValue" Type="ChartSeriesType.Column">
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

<SfButton Id="button" Content="Export" @onclick="Export"  IsPrimary="true" CssClass="e-flat"></SfButton>

@code{

    SfChart ChartObj;

    private async Task Export(MouseEventArgs args)
    {
        await ChartObj.ExportAsync(ExportType.PNG, "pngImage");
    }

    public class ChartData
    {
        public string X { get; set; }
        public double YValue { get; set; }
    }

    public List<ChartData> ConsumerDetails = new List<ChartData>
    {
        new ChartData { X= "USA", YValue= 46 },
        new ChartData { X= "GBR", YValue= 27 },
        new ChartData { X= "CHN", YValue= 26 },
        new ChartData { X= "UK", YValue= 36 },
        new ChartData { X= "AUS", YValue= 15 },
        new ChartData { X= "IND", YValue= 55 },
        new ChartData { X= "DEN", YValue= 40 },
        new ChartData { X= "MEX", YValue= 30 }
    };
}

```

> Refer to our [Blazor Charts](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations and also explore our [Blazor Chart Example](https://blazor.syncfusion.com/demos/chart/line?theme=bootstrap4) to know various chart types and how to represent time-dependent data, showing trends at equal intervals.

## See Also

* [Data Label](./data-labels)
* [Tooltip](./tool-tip)
* [Legend](./legend)