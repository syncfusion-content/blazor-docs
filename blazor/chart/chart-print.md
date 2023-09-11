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

### Print - Multiple Charts

Again, the [PrintAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfChart.html#Syncfusion_Blazor_Charts_SfChart_PrintAsync_Microsoft_AspNetCore_Components_ElementReference_) method can be used to print all of the charts on a page by passing the element reference of the parent for all of the charts.

```cshtml

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Charts
@using Syncfusion.Blazor.Buttons

<div class="row">
<div class="col-lg-9 property-section">
    <div class="property-panel-section">
        <div class="property-panel-content">
            <table style="width: 100%">
                <tbody>
                    <tr style="height: 50px; text-align: left">
                        <td>
                           <b>Print the chart - <SfButton ID="button" IsPrimary="true" IsToggle="true" OnClick="PrintChart">Print</SfButton> </b>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
</div>
</div>

<div class="justify-content-center">
  <div id = "print_support" class="container" style="justify-content:center" @ref="Element">
    <div class="row">
         <div align="center" class="col-sm-1"  style="height:500px; width:600px" > 
           <div class="p-5"> 
              <SfChart @ref="chartInstance">
                        <ChartArea><ChartAreaBorder Width="0"></ChartAreaBorder></ChartArea>
                        <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" Interval="1">
                            <ChartAxisMajorGridLines Width="0"></ChartAxisMajorGridLines>
                        </ChartPrimaryXAxis>
                        <ChartPrimaryYAxis Minimum="0" Maximum="20" Interval="4" LabelFormat="${value}k">
                            <ChartAxisMajorGridLines Width="2"></ChartAxisMajorGridLines>
                            <ChartAxisMajorTickLines Width="0"></ChartAxisMajorTickLines>
                            <ChartAxisLineStyle Width="0"></ChartAxisLineStyle>
                        </ChartPrimaryYAxis>
                        <ChartLegendSettings Visible="false"></ChartLegendSettings>
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
            </div>
         </div>
         <div align="center" class="col-sm-2"  style="height:500px; width:500px">
             <div class="p-5">
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
                 
             </div>
         </div>
    </div>
    <div align="center" class="col-sm-2"  style="height:450px; width:500px">
    <div class="p-5">
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
    </div>
    </div>
  </div>
</div>

@code{
    private SfChart chartInstance;
    private ElementReference Element;

     private string[] palettes = new string[] { "#61EFCD", "#CDDE1F", "#FEC200", "#CA765A", "#2485FA", "#F57D7D", "#C152D2",
    "#8854D9", "#3D4EB8", "#00BCD7","#4472c4", "#ed7d31", "#ffc000", "#70ad47", "#5b9bd5", "#c1c1c1", "#6f6fe2", "#e269ae", "#9e480e", "#997300" };

    public async Task PrintChart(MouseEventArgs args)
    {
        await chartInstance.PrintAsync(Element);
    }

    public class ExportData
    {
        public string Manager { get; set; }
        public double SalesInfo { get; set; }
        public string DataLabelMappingName{ get; set; }
    }

    public List<ExportData> ChartPoints { get; set; } = new List<ExportData>
    {
        new ExportData { Manager = "John", SalesInfo = 10, DataLabelMappingName="$10k"},
        new ExportData { Manager = "Jake", SalesInfo = 12, DataLabelMappingName="$12k"},
        new ExportData { Manager = "Peter", SalesInfo = 18, DataLabelMappingName="$18k"},
        new ExportData { Manager = "James", SalesInfo = 11, DataLabelMappingName="$11k"},
        new ExportData { Manager = "Mary", SalesInfo = 9.7, DataLabelMappingName="$9.7k"}
    };

     public class ChartData
     {
        public string Product { get; set; }
        public double Percentage { get; set; }
        public string TextMapping { get; set; }
    }

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

    public class SplineAreaChartData
    {
        public DateTime Period { get; set; }
        public double US_InflationRate { get; set; }
        public double FR_InflationRate { get; set; }
        public double GER_InflationRate { get; set; }
    }

    public List<SplineAreaChartData> AreaChartPoints { get; set; } = new List<SplineAreaChartData>
    {
        new SplineAreaChartData { Period = new DateTime(2002, 01, 01), US_InflationRate = 2.2, FR_InflationRate = 2, GER_InflationRate = 0.8  },
        new SplineAreaChartData { Period = new DateTime(2003, 01, 01), US_InflationRate = 3.4, FR_InflationRate = 1.7, GER_InflationRate = 1.3 },
        new SplineAreaChartData { Period = new DateTime(2004, 01, 01), US_InflationRate = 2.8, FR_InflationRate = 1.8, GER_InflationRate = 1.1 },
        new SplineAreaChartData { Period = new DateTime(2005, 01, 01), US_InflationRate = 1.6, FR_InflationRate = 2.1, GER_InflationRate = 1.6 },
        new SplineAreaChartData { Period = new DateTime(2006, 01, 01), US_InflationRate = 2.3, FR_InflationRate = 2.3, GER_InflationRate = 2 },
    };
   
}

```

![Blazor Chart - Print Multiple Charts](images/getting-started/blazor-chart-print-all-charts.png)
![Blazor Chart - Print Multiple Charts](images/getting-started/blazor-chart-print-all-charts2.png)

## Export

Using the `ExportAsync` method, the rendered chart can be exported to [JPEG](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ExportType.html#Syncfusion_Blazor_Charts_ExportType_JPEG), [PNG](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ExportType.html#Syncfusion_Blazor_Charts_ExportType_PNG), [SVG](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ExportType.html#Syncfusion_Blazor_Charts_ExportType_SVG), or [PDF](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ExportType.html#Syncfusion_Blazor_Charts_ExportType_PDF) format. The [Export Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ExportType.html) specifies the image format and `FileName` specifies the name of the exported file. Both of these parameters are required input parameters for this method.

The optional parameters for this method are,
* `Orientation` - Specifies the portrait or landscape orientation in the PDF document.
* `AllowDownload` - Specifies whether to download or not. If not, base64 string will be returned.
* `IsBase64` - Specifies whether to export chart as base64 string or not.

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

### Export Chart as base64 string

Sometimes, you may encounter situations where sending images in standard formats like [JPEG](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ExportType.html#Syncfusion_Blazor_Charts_ExportType_JPEG), [PNG](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ExportType.html#Syncfusion_Blazor_Charts_ExportType_PNG), [SVG](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ExportType.html#Syncfusion_Blazor_Charts_ExportType_SVG), or [PDF](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ExportType.html#Syncfusion_Blazor_Charts_ExportType_PDF) might not be feasible. In such cases, We provide support to export the rendered chart as `base64` string, which can then be easily embedded or transmitted in various contexts. 

This can be achieved using the `ExportAsync` method by made the `allowDownload` boolean as false and `isBase64` as true. The exported Base64 string can be get by using [OnExportComplete](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_OnExportComplete) event.

The following code shows how to pass parameters to the `ExportAsync` method to get `base64` string.

In this method, you'll need to specify the following parameters:

* [Export Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ExportType.html): The desired export format (e.g., Png, Jpeg, Svg, Pdf).
* `fileName`: A name for the exported file (this is not used when exporting as base64).
* `allowDownload`: Set this parameter to false to prevent the browser's download prompt.
* `isBase64`: Set this parameter to true to indicate that you want to receive the exported content as a base64 string.

```cshtml

sfChart.ExportAsync(ExportFileType, FileName, null, false, true);

```

The following code shows the complete demonstration of exporting chart image of standard formats like [JPEG](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ExportType.html#Syncfusion_Blazor_Charts_ExportType_JPEG), [PNG](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ExportType.html#Syncfusion_Blazor_Charts_ExportType_PNG), [SVG](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ExportType.html#Syncfusion_Blazor_Charts_ExportType_SVG), or [PDF](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ExportType.html#Syncfusion_Blazor_Charts_ExportType_PDF) as `base64` string.

```cshtml
 
@using Syncfusion.Blazor.Charts;
 
<div id="button">
    <button onclick="@ExportChart">
        Export
    </button>
</div>

<div id="chart">
    <SfChart @ref="@chartInstance">
        <ChartArea><ChartAreaBorder Width="0"></ChartAreaBorder></ChartArea>
        <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" Interval="1" LabelIntersectAction="@Label" LabelRotation="-45">
            <ChartAxisMajorGridLines Width="0"></ChartAxisMajorGridLines>
            <ChartAxisMajorTickLines Width="0"></ChartAxisMajorTickLines>
        </ChartPrimaryXAxis>
        <ChartPrimaryYAxis Minimum="0" Maximum="40" Interval="10" Title="Measurements (in Gigawatt)" LabelFormat="@Format">
            <ChartAxisMajorGridLines Width="0"></ChartAxisMajorGridLines>
            <ChartAxisLineStyle Width="0"></ChartAxisLineStyle>
            <ChartAxisMajorGridLines Width="2"></ChartAxisMajorGridLines>
            <ChartAxisMajorTickLines Width="0"></ChartAxisMajorTickLines>
        </ChartPrimaryYAxis>
        <ChartSeriesCollection>
            <ChartSeries DataSource="@ChartPoints" XName="Country" YName="GigaWatts" Type="ChartSeriesType.Column">
                <ChartMarker>
                    <ChartDataLabel Visible="true" EnableRotation="@Rotate" Angle="@AngleRotate" Name=" DataLabelMappingName" Position="Syncfusion.Blazor.Charts.LabelPosition.Top">
                        <ChartDataLabelFont FontWeight="600" Size="9px" Color="#ffffff"></ChartDataLabelFont>
                    </ChartDataLabel>
                </ChartMarker>
            </ChartSeries>
        </ChartSeriesCollection>
        <ChartEvents OnExportComplete="ExportComplete"></ChartEvents>
    </SfChart>
</div>


@code{
    private SfChart chartInstance;    
    public string FileName { get; set; } = "Charts";
    public string Format { get; set; } = "{value}GW";
    public bool Rotate { get; set; } = false;
    public double AngleRotate { get; set; } = 0;
    public LabelIntersectAction Label { get; set; } = LabelIntersectAction.Trim;

    public List<ExportData> ChartPoints { get; set; } = new List<ExportData>
    {
        new ExportData {Country="India", GigaWatts = 35.5, DataLabelMappingName="35.5"},
        new ExportData {Country="China", GigaWatts = 18.3, DataLabelMappingName="18.3"},
        new ExportData {Country="Italy", GigaWatts = 17.6, DataLabelMappingName="17.6"},
        new ExportData {Country="Japan", GigaWatts = 13.6, DataLabelMappingName="13.6"},
        new ExportData {Country="United state", GigaWatts = 12, DataLabelMappingName="12"},
        new ExportData {Country="Spain", GigaWatts = 5.6, DataLabelMappingName="5.6"},
        new ExportData {Country="France", GigaWatts = 4.6, DataLabelMappingName="4.6"},
        new ExportData {Country="Australia", GigaWatts = 3.3, DataLabelMappingName="3.3"},
        new ExportData {Country="Belgium", GigaWatts = 3, DataLabelMappingName="3"},
        new ExportData {Country="United Kingdom", GigaWatts = 2.9, DataLabelMappingName="2.9"},
    };

    public async Task ExportChart(Microsoft.AspNetCore.Components.Web.MouseEventArgs args)
    {
        ExportType ExportFileType = ExportType.PDF;
        
        await chartInstance.ExportAsync(ExportFileType, FileName, null,false, true);
    }

    public class ExportData
    {
        public string Country { get; set; }
        public double GigaWatts { get; set; }
        public string DataLabelMappingName { get; set; }
    }

    public void ExportComplete(ExportEventArgs exportEventArgs)
    {
        string base64 = exportEventArgs.Base64;
    }
}


```

N> Refer to our [Blazor Charts](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations and also explore our [Blazor Chart Example](https://blazor.syncfusion.com/demos/chart/line?theme=bootstrap4) to know various chart types and how to represent time-dependent data, showing trends at equal intervals.

## See Also

* [Data Label](./data-labels)
* [Tooltip](./tool-tip)
* [Legend](./legend)
