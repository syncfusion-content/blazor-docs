---
layout: post
title: Legend in Blazor Stock Chart Component | Syncfusion
description: Checkout and learn here all about Legend in Syncfusion Blazor Stock Chart component and much more details.
platform: Blazor
control: Stock Chart 
documentation: ug
---

# Legend in Blazor Stock Chart Component

Legend provides information about the series rendered in the Stock Chart. Legend can be added to a Stock Chart by enabling the [Visible](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartLegendSettings.html#Syncfusion_Blazor_Charts_StockChartLegendSettings_Visible) option in the [StockChartLegendSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartLegendSettings.html).

## Enable Legend

To display the legend for the Stock Chart, set the [Visible](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartLegendSettings.html#Syncfusion_Blazor_Charts_StockChartLegendSettings_Visible) property in [StockChartLegendSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartLegendSettings.html) to **true**.

```cshtml
@using Syncfusion.Blazor.Charts

        <SfStockChart Title="AAPL Stock Price">
            <StockChartLegendSettings Visible="true"></StockChartLegendSettings>
            <StockChartSeriesCollection>
                <StockChartSeries DataSource="@StockDetails" XName="Date" High="High" Low="Low" Open="Open" Close="Close" Name="Apple  Inc" Type="ChartSeriesType.Candle"></StockChartSeries>
            </StockChartSeriesCollection>
        </SfStockChart>
  

@code {
    public class ChartData
    {
        public DateTime Date { get; set; }
        public Double Open { get; set; }
        public Double Low { get; set; }
        public Double Close { get; set; }
        public Double High { get; set; }
        public Double Volume { get; set; }
    }

    public List<ChartData> StockDetails = new List<ChartData>
    {
         new ChartData { Date = new DateTime(2012, 04, 02), Open= 85.9757, High = 90.6657,Low = 85.7685, Close = 90.5257,Volume = 660187068},
         new ChartData { Date = new DateTime(2012, 04, 09), Open= 89.4471, High = 92,Low = 86.2157, Close = 86.4614,Volume = 912634864},
         new ChartData { Date = new DateTime(2012, 04, 16), Open= 87.1514, High = 88.6071,Low = 81.4885, Close = 81.8543,Volume = 1221746066},
         new ChartData { Date = new DateTime(2012, 04, 23), Open= 81.5157, High = 88.2857,Low = 79.2857, Close = 86.1428,Volume = 965935749},
         new ChartData { Date = new DateTime(2012, 04, 30), Open= 85.4, High =  85.4857,Low = 80.7385, Close = 80.75,Volume = 615249365},
   };
}
```

![Blazor Stock Chart with legend](images/blazor-stock-chart-legend.png)


## Legend Position

By using the [Position](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartLegendSettings.html#Syncfusion_Blazor_Charts_StockChartLegendSettings_Position) property, legend can be placed at **Left**, **Right**, **Top**, **Bottom** or **Custom** of the Stock Chart. The legend is positioned at the bottom of the Stock Chart, by default.

```cshtml

@using Syncfusion.Blazor.Charts

        <SfStockChart Title="AAPL Stock Price">
            <StockChartLegendSettings Visible="true" Position="LegendPosition.Top"></StockChartLegendSettings>
            <StockChartSeriesCollection>
                <StockChartSeries DataSource="@StockDetails" XName="Date" High="High" Low="Low" Open="Open" Close="Close" Name="Apple Inc" Type="ChartSeriesType.Candle"></StockChartSeries>
            </StockChartSeriesCollection>
        </SfStockChart>
  

@code {
    public class ChartData
    {
        public DateTime Date { get; set; }
        public Double Open { get; set; }
        public Double Low { get; set; }
        public Double Close { get; set; }
        public Double High { get; set; }
        public Double Volume { get; set; }
    }

    public List<ChartData> StockDetails = new List<ChartData>
    {
         new ChartData { Date = new DateTime(2012, 04, 02), Open= 85.9757, High = 90.6657,Low = 85.7685, Close = 90.5257,Volume = 660187068},
         new ChartData { Date = new DateTime(2012, 04, 09), Open= 89.4471, High = 92,Low = 86.2157, Close = 86.4614,Volume = 912634864},
         new ChartData { Date = new DateTime(2012, 04, 16), Open= 87.1514, High = 88.6071,Low = 81.4885, Close = 81.8543,Volume = 1221746066},
         new ChartData { Date = new DateTime(2012, 04, 23), Open= 81.5157, High = 88.2857,Low = 79.2857, Close = 86.1428,Volume = 965935749},
         new ChartData { Date = new DateTime(2012, 04, 30), Open= 85.4, High =  85.4857,Low = 80.7385, Close = 80.75,Volume = 615249365},
   };
}
```

![Blazor Stock Chart with legend position](images/blazor-stock-chart-legend-position.png)

The **Custom** position helps to position the legend anywhere in the Stock Chart using x and y coordinates.

```cshtml
@using Syncfusion.Blazor.Charts

        <SfStockChart Title="AAPL Stock Price">
            <StockChartLegendSettings Visible="true" Position="LegendPosition.Custom">
                <StockChartLocation X="50" Y="50"></StockChartLocation>
                <StockChartLegendBorder Color="Black" Width="2"></StockChartLegendBorder>
            </StockChartLegendSettings>
            <StockChartSeriesCollection>
                <StockChartSeries DataSource="@StockDetails" XName="Date" High="High" Low="Low" Open="Open" Close="Close" Name="Apple Inc" Type="ChartSeriesType.Candle"></StockChartSeries>
            </StockChartSeriesCollection>
        </SfStockChart>
  

@code {
    public class ChartData
    {
        public DateTime Date { get; set; }
        public Double Open { get; set; }
        public Double Low { get; set; }
        public Double Close { get; set; }
        public Double High { get; set; }
        public Double Volume { get; set; }
    }

    public List<ChartData> StockDetails = new List<ChartData>
    {
         new ChartData { Date = new DateTime(2012, 04, 02), Open= 85.9757, High = 90.6657,Low = 85.7685, Close = 90.5257,Volume = 660187068},
         new ChartData { Date = new DateTime(2012, 04, 09), Open= 89.4471, High = 92,Low = 86.2157, Close = 86.4614,Volume = 912634864},
         new ChartData { Date = new DateTime(2012, 04, 16), Open= 87.1514, High = 88.6071,Low = 81.4885, Close = 81.8543,Volume = 1221746066},
         new ChartData { Date = new DateTime(2012, 04, 23), Open= 81.5157, High = 88.2857,Low = 79.2857, Close = 86.1428,Volume = 965935749},
         new ChartData { Date = new DateTime(2012, 04, 30), Open= 85.4, High =  85.4857,Low = 80.7385, Close = 80.75,Volume = 615249365},
   };
}
```

![Blazor Stock Chart with custom legend position](images/blazor-stock-chart-legend-location.png)

## Reverse Legend

You can reverse the order of the legend items by using the [Reversed](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartLegendSettings.html#Syncfusion_Blazor_Charts_StockChartLegendSettings_Reversed) property. By default, legend for the first series in the collection will be placed first.

```cshtml
@using Syncfusion.Blazor.Charts

        <SfStockChart Title="AAPL Stock Price">
           <StockChartLegendSettings Visible="true" Reversed="true">
            </StockChartLegendSettings>
           <StockChartSeriesCollection>

                <StockChartSeries DataSource="@StockDetails" Type="ChartSeriesType.Line" XName="Date" High="High" Low="Low" Open="Open" Close="Close" Name="Apple Stock Price"></StockChartSeries>

                <StockChartSeries DataSource="@StockDetails" Type="ChartSeriesType.Line" XName="Date" High="High" Low="Low" Open="Open" Close="Close" Name="Google Stock Price"></StockChartSeries>

                <StockChartSeries DataSource="@StockDetails" Type="ChartSeriesType.Spline"XName="Date" High="High" Low="Low" Open="Open" Close="Close" Name="Tesla Stock Price"></StockChartSeries>

            </StockChartSeriesCollection>
        </SfStockChart>
  

@code {
    public class ChartData
    {
        public DateTime Date { get; set; }
        public Double Open { get; set; }
        public Double Low { get; set; }
        public Double Close { get; set; }
        public Double High { get; set; }
        public Double Volume { get; set; }
    }

    public List<ChartData> StockDetails = new List<ChartData>
    {
         new ChartData { Date = new DateTime(2012, 04, 02), Open= 85.9757, High = 90.6657,Low = 85.7685, Close = 90.5257,Volume = 660187068},
         new ChartData { Date = new DateTime(2012, 04, 09), Open= 89.4471, High = 92,Low = 86.2157, Close = 86.4614,Volume = 912634864},
         new ChartData { Date = new DateTime(2012, 04, 16), Open= 87.1514, High = 88.6071,Low = 81.4885, Close = 81.8543,Volume = 1221746066},
         new ChartData { Date = new DateTime(2012, 04, 23), Open= 81.5157, High = 88.2857,Low = 79.2857, Close = 86.1428,Volume = 965935749},
         new ChartData { Date = new DateTime(2012, 04, 30), Open= 85.4, High =  85.4857,Low = 80.7385, Close = 80.75,Volume = 615249365},
   };
}
```

![Blazor Stock Chart with legend reversed](images/blazor-stock-chart-legend-reversed.png)

## Legend Alignment

Using the [Alignment](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartLegendSettings.html#Syncfusion_Blazor_Charts_StockChartLegendSettings_Alignment) property, place the legend in **Centre**, **Far**, or **Near** alignment.

```cshtml
@using Syncfusion.Blazor.Charts

        <SfStockChart Title="AAPL Stock Price">
            <StockChartLegendSettings Visible="true" Alignment="Alignment.Near">
            <StockChartLegendBorder Color="Black" Width="2"></StockChartLegendBorder>
            </StockChartLegendSettings>
            <StockChartSeriesCollection>
                <StockChartSeries DataSource="@StockDetails"  XName="Date" High="High" Low="Low" Open="Open" Close="Close" Name="Apple Inc" Type="ChartSeriesType.Candle"></StockChartSeries>
            </StockChartSeriesCollection>
        </SfStockChart>
  

@code {
    public class ChartData
    {
        public DateTime Date { get; set; }
        public Double Open { get; set; }
        public Double Low { get; set; }
        public Double Close { get; set; }
        public Double High { get; set; }
        public Double Volume { get; set; }
    }

    public List<ChartData> StockDetails = new List<ChartData>
    {
         new ChartData { Date = new DateTime(2012, 04, 02), Open= 85.9757, High = 90.6657,Low = 85.7685, Close = 90.5257,Volume = 660187068},
         new ChartData { Date = new DateTime(2012, 04, 09), Open= 89.4471, High = 92,Low = 86.2157, Close = 86.4614,Volume = 912634864},
         new ChartData { Date = new DateTime(2012, 04, 16), Open= 87.1514, High = 88.6071,Low = 81.4885, Close = 81.8543,Volume = 1221746066},
         new ChartData { Date = new DateTime(2012, 04, 23), Open= 81.5157, High = 88.2857,Low = 79.2857, Close = 86.1428,Volume = 965935749},
         new ChartData { Date = new DateTime(2012, 04, 30), Open= 85.4, High =  85.4857,Low = 80.7385, Close = 80.75,Volume = 615249365},
   };
}
```

![Blazor Stock Chart with legend alignment](images/blazor-stock-chart-legend-alignment.png)

## Legend Customization

### Legend Shape

The [LegendShape](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartSeries.html#Syncfusion_Blazor_Charts_StockChartSeries_LegendShape) property in the [Series](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartSeries.html#properties) can be used to change the shape of the legend icon. The default icon shape for legends is **SeriesType**.


```cshtml
@using Syncfusion.Blazor.Charts

        <SfStockChart Title="AAPL Stock Price">
            <StockChartLegendSettings Visible="true" ShapeHeight="13" ShapeWidth="13">
            </StockChartLegendSettings>
            <StockChartSeriesCollection>
                <StockChartSeries DataSource="@StockDetails" XName="Date" High="High" Low="Low" Open="Open" Close="Close" Name="Apple Inc" Type="ChartSeriesType.Candle"  LegendShape="LegendShape.Diamond"></StockChartSeries>
            </StockChartSeriesCollection>
        </SfStockChart>
  

@code {
    public class ChartData
    {
        public DateTime Date { get; set; }
        public Double Open { get; set; }
        public Double Low { get; set; }
        public Double Close { get; set; }
        public Double High { get; set; }
        public Double Volume { get; set; }
    }

    public List<ChartData> StockDetails = new List<ChartData>
    {
         new ChartData { Date = new DateTime(2012, 04, 02), Open= 85.9757, High = 90.6657,Low = 85.7685, Close = 90.5257,Volume = 660187068},
         new ChartData { Date = new DateTime(2012, 04, 09), Open= 89.4471, High = 92,Low = 86.2157, Close = 86.4614,Volume = 912634864},
         new ChartData { Date = new DateTime(2012, 04, 16), Open= 87.1514, High = 88.6071,Low = 81.4885, Close = 81.8543,Volume = 1221746066},
         new ChartData { Date = new DateTime(2012, 04, 23), Open= 81.5157, High = 88.2857,Low = 79.2857, Close = 86.1428,Volume = 965935749},
         new ChartData { Date = new DateTime(2012, 04, 30), Open= 85.4, High =  85.4857,Low = 80.7385, Close = 80.75,Volume = 615249365},
   };
}
```

![Blazor Stock Chart with legend shape](images/blazor-stock-chart-legend-shape.png)

### Legend Size

When the legend is placed on the top or bottom of the Stock Chart, it takes up 20% - 25% of the Stock Chart's height, and 20% - 25% of the Stock Chart's width when it is positioned on the left or right side of the Stock Chart. So, the [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartLegendSettings.html#Syncfusion_Blazor_Charts_StockChartLegendSettings_Width) and [Height](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartLegendSettings.html#Syncfusion_Blazor_Charts_StockChartLegendSettings_Height) properties can be used to adjust the default legend size.

```cshtml
@using Syncfusion.Blazor.Charts

        <SfStockChart Title="AAPL Stock Price">
           <StockChartLegendSettings Visible="true" Height="50" Width="300">
                <StockChartLegendBorder Color="blue" Width="1"></StockChartLegendBorder>
            </StockChartLegendSettings>
            <StockChartSeriesCollection>
               <StockChartSeries DataSource="@StockDetails" Type="ChartSeriesType.Line" XName="Date" High="High" Low="Low" Open="Open" Close="Close" Name="Apple Stock Price"></StockChartSeries>
                <StockChartSeries DataSource="@StockDetails" Type="ChartSeriesType.Line" XName="Date" High="High" Low="Low" Open="Open" Close="Close" Name="Google Stock Price"></StockChartSeries>
            </StockChartSeriesCollection>
        </SfStockChart>
  

@code {
    public class ChartData
    {
        public DateTime Date { get; set; }
        public Double Open { get; set; }
        public Double Low { get; set; }
        public Double Close { get; set; }
        public Double High { get; set; }
        public Double Volume { get; set; }
    }

    public List<ChartData> StockDetails = new List<ChartData>
    {
         new ChartData { Date = new DateTime(2012, 04, 02), Open= 85.9757, High = 90.6657,Low = 85.7685, Close = 90.5257,Volume = 660187068},
         new ChartData { Date = new DateTime(2012, 04, 09), Open= 89.4471, High = 92,Low = 86.2157, Close = 86.4614,Volume = 912634864},
         new ChartData { Date = new DateTime(2012, 04, 16), Open= 87.1514, High = 88.6071,Low = 81.4885, Close = 81.8543,Volume = 1221746066},
         new ChartData { Date = new DateTime(2012, 04, 23), Open= 81.5157, High = 88.2857,Low = 79.2857, Close = 86.1428,Volume = 965935749},
         new ChartData { Date = new DateTime(2012, 04, 30), Open= 85.4, High =  85.4857,Low = 80.7385, Close = 80.75,Volume = 615249365},
   };
}
```

![Blazor Stock Chart with legend size](images/blazor-stock-chart-legend-size.png)

### Legend Shape Size

The [ShapeHeight](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartLegendSettings.html#Syncfusion_Blazor_Charts_StockChartLegendSettings_ShapeHeight) and [ShapeWidth](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartLegendSettings.html#Syncfusion_Blazor_Charts_StockChartLegendSettings_ShapeWidth) properties can be used to adjust the dimensions of the legend shape.

```cshtml
@using Syncfusion.Blazor.Charts

        <SfStockChart Title="AAPL Stock Price">
           <StockChartLegendSettings Visible="true" Height="50" Width="300" ShapeHeight="15" ShapeWidth="15">
            </StockChartLegendSettings>
            <StockChartSeriesCollection>
                <StockChartSeries DataSource="@StockDetails" XName="Date" High="High" Low="Low" Open="Open" Close="Close" Name="Apple Inc" Type="ChartSeriesType.Candle"></StockChartSeries>
            </StockChartSeriesCollection>
        </SfStockChart>
  

@code {
    public class ChartData
    {
        public DateTime Date { get; set; }
        public Double Open { get; set; }
        public Double Low { get; set; }
        public Double Close { get; set; }
        public Double High { get; set; }
        public Double Volume { get; set; }
    }

    public List<ChartData> StockDetails = new List<ChartData>
    {
         new ChartData { Date = new DateTime(2012, 04, 02), Open= 85.9757, High = 90.6657,Low = 85.7685, Close = 90.5257,Volume = 660187068},
         new ChartData { Date = new DateTime(2012, 04, 09), Open= 89.4471, High = 92,Low = 86.2157, Close = 86.4614,Volume = 912634864},
         new ChartData { Date = new DateTime(2012, 04, 16), Open= 87.1514, High = 88.6071,Low = 81.4885, Close = 81.8543,Volume = 1221746066},
         new ChartData { Date = new DateTime(2012, 04, 23), Open= 81.5157, High = 88.2857,Low = 79.2857, Close = 86.1428,Volume = 965935749},
         new ChartData { Date = new DateTime(2012, 04, 30), Open= 85.4, High =  85.4857,Low = 80.7385, Close = 80.75,Volume = 615249365},
   };
}
```

![Blazor Stock Chart with legend shape size](images/blazor-stock-chart-legend-size-shape.png)


### Legend Item Padding

The [ItemPadding](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartLegendSettings.html#Syncfusion_Blazor_Charts_StockChartLegendSettings_ItemPadding) property can be used to adjust the space between the legend items.

```cshtml
@using Syncfusion.Blazor.Charts

        <SfStockChart Title="AAPL Stock Price">
           <StockChartLegendSettings Visible="true" ItemPadding="30">
            </StockChartLegendSettings>
           <StockChartSeriesCollection>
                <StockChartSeries DataSource="@StockDetails" Type="ChartSeriesType.Line" XName="Date" High="High" Low="Low" Open="Open" Close="Close" Name="Apple"></StockChartSeries>
                <StockChartSeries DataSource="@StockDetails" Type="ChartSeriesType.Line" XName="Date" High="High" Low="Low" Open="Open" Close="Close" Name="Google"></StockChartSeries>
            </StockChartSeriesCollection>
        </SfStockChart>
  

@code {
    public class ChartData
    {
        public DateTime Date { get; set; }
        public Double Open { get; set; }
        public Double Low { get; set; }
        public Double Close { get; set; }
        public Double High { get; set; }
        public Double Volume { get; set; }
    }

    public List<ChartData> StockDetails = new List<ChartData>
    {
         new ChartData { Date = new DateTime(2012, 04, 02), Open= 85.9757, High = 90.6657,Low = 85.7685, Close = 90.5257,Volume = 660187068},
         new ChartData { Date = new DateTime(2012, 04, 09), Open= 89.4471, High = 92,Low = 86.2157, Close = 86.4614,Volume = 912634864},
         new ChartData { Date = new DateTime(2012, 04, 16), Open= 87.1514, High = 88.6071,Low = 81.4885, Close = 81.8543,Volume = 1221746066},
         new ChartData { Date = new DateTime(2012, 04, 23), Open= 81.5157, High = 88.2857,Low = 79.2857, Close = 86.1428,Volume = 965935749},
         new ChartData { Date = new DateTime(2012, 04, 30), Open= 85.4, High =  85.4857,Low = 80.7385, Close = 80.75,Volume = 615249365},
   };
}
```

![Blazor Stock Chart with legend item padding](images/Blazor-stock-chart-legend-itemPadding.png)

### Legend Paging

When the legend items exceed legend bounds, paging will be enabled by default. End user can view each legend item using the navigation buttons to navigate between pages.

```cshtml
@using Syncfusion.Blazor.Charts

        <SfStockChart Title="AAPL Stock Price">
           <StockChartLegendSettings Visible="true" Width="100" Height="70" Padding="10" ShapePadding="10">
            </StockChartLegendSettings>
           <StockChartSeriesCollection>
                <StockChartSeries DataSource="@StockDetails" Type="ChartSeriesType.Line" XName="Date" High="High" Low="Low" Open="Open" Close="Close" Name="Apple"></StockChartSeries>
                <StockChartSeries DataSource="@StockDetails" Type="ChartSeriesType.Line" XName="Date" High="High" Low="Low" Open="Open" Close="Close" Name="Google"></StockChartSeries>
                <StockChartSeries DataSource="@StockDetails" Type="ChartSeriesType.Spline" XName="Date" High="High" Low="Low" Open="Open" Close="Close" Name="Tesla"></StockChartSeries>
            </StockChartSeriesCollection>
        </SfStockChart>
  

@code {
    public class ChartData
    {
        public DateTime Date { get; set; }
        public Double Open { get; set; }
        public Double Low { get; set; }
        public Double Close { get; set; }
        public Double High { get; set; }
        public Double Volume { get; set; }
    }

    public List<ChartData> StockDetails = new List<ChartData>
    {
         new ChartData { Date = new DateTime(2012, 04, 02), Open= 85.9757, High = 90.6657,Low = 85.7685, Close = 90.5257,Volume = 660187068},
         new ChartData { Date = new DateTime(2012, 04, 09), Open= 89.4471, High = 92,Low = 86.2157, Close = 86.4614,Volume = 912634864},
         new ChartData { Date = new DateTime(2012, 04, 16), Open= 87.1514, High = 88.6071,Low = 81.4885, Close = 81.8543,Volume = 1221746066},
         new ChartData { Date = new DateTime(2012, 04, 23), Open= 81.5157, High = 88.2857,Low = 79.2857, Close = 86.1428,Volume = 965935749},
         new ChartData { Date = new DateTime(2012, 04, 30), Open= 85.4, High =  85.4857,Low = 80.7385, Close = 80.75,Volume = 615249365},
   };
}
```

![Blazor Stock Chart with legend paging](images/blazor-stock-chart-legend-paging.png)


### Legend Text Wrap

When the legend text exceeds the container, the text can be wrapped by using [TextWrap](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartLegendSettings.html#Syncfusion_Blazor_Charts_StockChartLegendSettings_TextWrap) property. End user can also wrap the legend text based on the [MaxLabelWidth](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartLegendSettings.html#Syncfusion_Blazor_Charts_StockChartLegendSettings_MaxLabelWidth) property.

```cshtml
@using Syncfusion.Blazor.Charts

        <SfStockChart Title="AAPL Stock Price">
           <StockChartLegendSettings Visible="true" Position="@LegendPosition.Right" TextWrap="@TextWrap.Wrap" MaxLabelWidth="70">
            </StockChartLegendSettings>
           <StockChartSeriesCollection>
                <StockChartSeries DataSource="@StockDetails" Type="ChartSeriesType.Line" XName="Date" High="High" Low="Low" Open="Open" Close="Close" Name="Apple Stock Price"></StockChartSeries>
                <StockChartSeries DataSource="@StockDetails" Type="ChartSeriesType.Line" XName="Date" High="High" Low="Low" Open="Open" Close="Close" Name="Google Stock Price"></StockChartSeries>
                <StockChartSeries DataSource="@StockDetails" Type="ChartSeriesType.Spline" XName="Date" High="High" Low="Low" Open="Open" Close="Close" Name="Tesla Stock Price"></StockChartSeries>
            </StockChartSeriesCollection>
        </SfStockChart>
  

@code {
    public class ChartData
    {
        public DateTime Date { get; set; }
        public Double Open { get; set; }
        public Double Low { get; set; }
        public Double Close { get; set; }
        public Double High { get; set; }
        public Double Volume { get; set; }
    }

    public List<ChartData> StockDetails = new List<ChartData>
    {
         new ChartData { Date = new DateTime(2012, 04, 02), Open= 85.9757, High = 90.6657,Low = 85.7685, Close = 90.5257,Volume = 660187068},
         new ChartData { Date = new DateTime(2012, 04, 09), Open= 89.4471, High = 92,Low = 86.2157, Close = 86.4614,Volume = 912634864},
         new ChartData { Date = new DateTime(2012, 04, 16), Open= 87.1514, High = 88.6071,Low = 81.4885, Close = 81.8543,Volume = 1221746066},
         new ChartData { Date = new DateTime(2012, 04, 23), Open= 81.5157, High = 88.2857,Low = 79.2857, Close = 86.1428,Volume = 965935749},
         new ChartData { Date = new DateTime(2012, 04, 30), Open= 85.4, High =  85.4857,Low = 80.7385, Close = 80.75,Volume = 615249365},
   };
}
```

![Blazor Stock Chart with legend text wrap](images/blazor-stock-chart-legend-text-wrap.png)

## Series selection based on legend

By default, when you click on the legend item, the appropriate series visibility is collapsed. On the other hand, [ToggleVisibility](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartLegendSettings.html#Syncfusion_Blazor_Charts_StockChartLegendSettings_ToggleVisibility) property is used to disable such functionality.

```cshtml
@using Syncfusion.Blazor.Charts

        <SfStockChart Title="AAPL Stock Price" SelectionMode="SelectionMode.Series">
           <StockChartLegendSettings Visible="true"  ToggleVisibility="false">
            </StockChartLegendSettings>
           <StockChartSeriesCollection>
                <StockChartSeries DataSource="@StockDetails" Type="ChartSeriesType.Line" XName="Date" High="High" Low="Low" Open="Open" Close="Close" Name="Apple Stock Price"></StockChartSeries>
                <StockChartSeries DataSource="@StockDetails" Type="ChartSeriesType.Line" XName="Date" High="High" Low="Low" Open="Open" Close="Close" Name="Google Stock Price"></StockChartSeries>
                <StockChartSeries DataSource="@StockDetails" Type="ChartSeriesType.Spline" XName="Date" High="High" Low="Low" Open="Open" Close="Close" Name="Tesla Stock Price"></StockChartSeries>
            </StockChartSeriesCollection>
        </SfStockChart>
  

@code {
    public class ChartData
    {
        public DateTime Date { get; set; }
        public Double Open { get; set; }
        public Double Low { get; set; }
        public Double Close { get; set; }
        public Double High { get; set; }
        public Double Volume { get; set; }
    }

    public List<ChartData> StockDetails = new List<ChartData>
    {
         new ChartData { Date = new DateTime(2012, 04, 02), Open= 85.9757, High = 90.6657,Low = 85.7685, Close = 90.5257,Volume = 660187068},
         new ChartData { Date = new DateTime(2012, 04, 09), Open= 89.4471, High = 92,Low = 86.2157, Close = 86.4614,Volume = 912634864},
         new ChartData { Date = new DateTime(2012, 04, 16), Open= 87.1514, High = 88.6071,Low = 81.4885, Close = 81.8543,Volume = 1221746066},
         new ChartData { Date = new DateTime(2012, 04, 23), Open= 81.5157, High = 88.2857,Low = 79.2857, Close = 86.1428,Volume = 965935749},
         new ChartData { Date = new DateTime(2012, 04, 30), Open= 85.4, High =  85.4857,Low = 80.7385, Close = 80.75,Volume = 615249365},
   };
}
```

![Blazor Stock Chart with selection mode](images/blazor-stock-chart-selection-mode.png)

## Hiding legend item

The series [Name](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartSeries.html#Syncfusion_Blazor_Charts_StockChartSeries_Name) will be displayed as the legend text by default. You can skip the legend for particular series by providing an empty string to the series [Name](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartSeries.html#Syncfusion_Blazor_Charts_StockChartSeries_Name) property.

```cshtml
@using Syncfusion.Blazor.Charts

        <SfStockChart Title="AAPL Stock Price" SelectionMode="SelectionMode.Series">
           <StockChartLegendSettings Visible="true"  ToggleVisibility="true">
            </StockChartLegendSettings>
           <StockChartSeriesCollection>
                <StockChartSeries DataSource="@StockDetails" Type="ChartSeriesType.Line" XName="Date" High="High" Low="Low" Open="Open" Close="Close" Name="Apple Stock Price"></StockChartSeries>
                <StockChartSeries DataSource="@StockDetails" Type="ChartSeriesType.Line" XName="Date" High="High" Low="Low" Open="Open" Close="Close" Name="Google Stock Price"></StockChartSeries>
                <StockChartSeries DataSource="@StockDetails" Type="ChartSeriesType.Spline" XName="Date" High="High" Low="Low" Open="Open" Close="Close" Name="Tesla Stock Price"></StockChartSeries>
            </StockChartSeriesCollection>
        </SfStockChart>
  

@code {
    public class ChartData
    {
        public DateTime Date { get; set; }
        public Double Open { get; set; }
        public Double Low { get; set; }
        public Double Close { get; set; }
        public Double High { get; set; }
        public Double Volume { get; set; }
    }

    public List<ChartData> StockDetails = new List<ChartData>
    {
         new ChartData { Date = new DateTime(2012, 04, 02), Open= 85.9757, High = 90.6657,Low = 85.7685, Close = 90.5257,Volume = 660187068},
         new ChartData { Date = new DateTime(2012, 04, 09), Open= 89.4471, High = 92,Low = 86.2157, Close = 86.4614,Volume = 912634864},
         new ChartData { Date = new DateTime(2012, 04, 16), Open= 87.1514, High = 88.6071,Low = 81.4885, Close = 81.8543,Volume = 1221746066},
         new ChartData { Date = new DateTime(2012, 04, 23), Open= 81.5157, High = 88.2857,Low = 79.2857, Close = 86.1428,Volume = 965935749},
         new ChartData { Date = new DateTime(2012, 04, 30), Open= 85.4, High =  85.4857,Low = 80.7385, Close = 80.75,Volume = 615249365},
   };
}
```

![Blazor Stock Chart hiding legend item](images/blazor-stock-chart-hidding-legend.png)