---
layout: post
title: 100% Stacked Line in Blazor Charts Component | Syncfusion
description: Checkout and learn here all about 100% Stacked Line Chart in Syncfusion Blazor Charts component and more.
platform: Blazor
control: Chart
documentation: ug
---

# 100% Stacked Line in Blazor Charts Component

## 100% Stacked Line

[100% Stacked Line Chart](https://www.syncfusion.com/blazor-components/blazor-charts/chart-types/100-stacked-line-chart) displays multiple series of data as stacked lines, ensuring that the cumulative proportion of each stacked element always totals 100%. Hence, the y-axis will always be rendered with the range 0–100%. To render a [100% stacked line](https://www.syncfusion.com/blazor-components/blazor-charts/chart-types/100-stacked-line-chart) series in your chart, define the series [`Type`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Type) as [`StackingLine100`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesType.html#Syncfusion_Blazor_Charts_ChartSeriesType_StackingLine100) in your chart configuration. This indicates that the data should be represented as a 100% stacked line chart, with each data series shown as a percentage of the total. This chart type ensures that all lines are stacked to always reach 100% at each data point, allowing for easy comparison of the proportional relationships between the series without the influence of absolute values.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart Title="Family Expense for Month">
    <ChartPrimaryXAxis LabelRotation="90" ValueType="Syncfusion.Blazor.Charts.ValueType.Category">
    </ChartPrimaryXAxis>
	
    <ChartSeriesCollection>
        <ChartSeries XName="X" DataSource="@ExpenseReports"
                     YName="Y" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingLine100">
            <ChartMarker Visible="true">
            </ChartMarker>
        </ChartSeries>
        <ChartSeries XName="X" DataSource="@ExpenseReports"
                     YName="Y1" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingLine100">
            <ChartMarker Visible="true">
            </ChartMarker>
        </ChartSeries>
        <ChartSeries XName="X" DataSource="@ExpenseReports"
                     YName="Y2" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingLine100">
            <ChartMarker Visible="true">
            </ChartMarker>
        </ChartSeries>
        <ChartSeries XName="X" DataSource="@ExpenseReports"
                     YName="Y3" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingLine100">
            <ChartMarker Visible="true">
            </ChartMarker>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code{
    public class ChartData
    {
        public string X { get; set; }
        public double Y { get; set; }
        public double Y1 { get; set; }
        public double Y2 { get; set; }
        public double Y3 { get; set; }
    }
	
    public List<ChartData> ExpenseReports = new List<ChartData>
	{
        new ChartData { X = "Food" , Y = 90, Y1 = 40 , Y2= 70, Y3= 120},
        new ChartData { X = "Transport", Y = 80, Y1 = 90, Y2= 110, Y3= 70 },
        new ChartData { X = "Medical",Y = 50, Y1 = 80, Y2= 120, Y3= 50 },
        new ChartData { X = "Clothes",Y = 70, Y1 = 30, Y2= 60, Y3= 180 },
        new ChartData { X = "Personal Care", Y = 30, Y1 = 80, Y2= 80, Y3= 30 },
        new ChartData { X = "Books", Y = 10, Y1 = 40, Y2= 30, Y3= 270},
        new ChartData { X = "Fitness",Y = 100, Y1 = 30, Y2= 70, Y3= 40 },
        new ChartData { X = "Electricity", Y = 55, Y1 = 95, Y2= 55, Y3= 75},
        new ChartData { X = "Tax", Y = 20, Y1 = 50, Y2= 40, Y3= 65 },
        new ChartData { X = "Pet Care", Y = 40, Y1 = 20, Y2= 80, Y3= 95 },
        new ChartData { X = "Education", Y = 45, Y1 = 15, Y2= 45, Y3= 195 },
        new ChartData { X = "Entertainment", Y = 75, Y1 = 45, Y2= 65, Y3= 115 }
    };
}

``` 
{% previewsample "https://blazorplayground.syncfusion.com/embed/BthfjusLTJpWigyi?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor Stacked Line100 Chart](../images/chart-types-images/blazor-stacked-line-100-chart.png)" %}

N> Refer to our [Blazor 100% Stacked Line Chart](https://www.syncfusion.com/blazor-components/blazor-charts/chart-types/100-stacked-line-chart) feature tour page to know about its other groundbreaking feature representations. Explore our [Blazor 100% Stacked Line Chart Example](https://blazor.syncfusion.com/demos/chart/percent-stacked-line?theme=bootstrap5) to know how to render and configure the 100% Stacked Line type chart.

## Binding data with series

You can bind data to the chart using the [`DataSource`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_DataSource) property within the series configuration. The [`DataSource`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_DataSource) value can be set using either [`SfDataManager`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) property values or a list of business objects. More information on data binding can be found [here](../working-with-data). To display the data correctly, map the fields from the data to the chart series' [`XName`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_XName) and [`YName`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_YName) properties.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart Title="Family Expense for Month">
    <ChartPrimaryXAxis LabelRotation="90" ValueType="Syncfusion.Blazor.Charts.ValueType.Category">
    </ChartPrimaryXAxis>
	
    <ChartSeriesCollection>
        <ChartSeries XName="X" DataSource="@ExpenseReports"
                     YName="Y" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingLine100">
            <ChartMarker Visible="true">
            </ChartMarker>
        </ChartSeries>
        <ChartSeries XName="X" DataSource="@ExpenseReports"
                     YName="Y1" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingLine100">
            <ChartMarker Visible="true">
            </ChartMarker>
        </ChartSeries>
        <ChartSeries XName="X" DataSource="@ExpenseReports"
                     YName="Y2" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingLine100">
            <ChartMarker Visible="true">
            </ChartMarker>
        </ChartSeries>
        <ChartSeries XName="X" DataSource="@ExpenseReports"
                     YName="Y3" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingLine100">
            <ChartMarker Visible="true">
            </ChartMarker>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code{
    public class ChartData
    {
        public string X { get; set; }
        public double Y { get; set; }
        public double Y1 { get; set; }
        public double Y2 { get; set; }
        public double Y3 { get; set; }
    }
	
    public List<ChartData> ExpenseReports = new List<ChartData>
	{
        new ChartData { X = "Food" , Y = 90, Y1 = 40 , Y2= 70, Y3= 120},
        new ChartData { X = "Transport", Y = 80, Y1 = 90, Y2= 110, Y3= 70 },
        new ChartData { X = "Medical",Y = 50, Y1 = 80, Y2= 120, Y3= 50 },
        new ChartData { X = "Clothes",Y = 70, Y1 = 30, Y2= 60, Y3= 180 },
        new ChartData { X = "Personal Care", Y = 30, Y1 = 80, Y2= 80, Y3= 30 },
        new ChartData { X = "Books", Y = 10, Y1 = 40, Y2= 30, Y3= 270},
        new ChartData { X = "Fitness",Y = 100, Y1 = 30, Y2= 70, Y3= 40 },
        new ChartData { X = "Electricity", Y = 55, Y1 = 95, Y2= 55, Y3= 75},
        new ChartData { X = "Tax", Y = 20, Y1 = 50, Y2= 40, Y3= 65 },
        new ChartData { X = "Pet Care", Y = 40, Y1 = 20, Y2= 80, Y3= 95 },
        new ChartData { X = "Education", Y = 45, Y1 = 15, Y2= 45, Y3= 195 },
        new ChartData { X = "Entertainment", Y = 75, Y1 = 45, Y2= 65, Y3= 115 }
    };
}

``` 
{% previewsample "https://blazorplayground.syncfusion.com/embed/BthfjusLTJpWigyi?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Series customization

The following properties can be used to customize the [100% Stacked Line](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesType.html#Syncfusion_Blazor_Charts_ChartSeriesType_StackingLine100) series.

**Fill**

The [Fill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Fill) property determines the color applied to the series.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart Title="Family Expense for Month">
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category">
    </ChartPrimaryXAxis>

    <ChartSeriesCollection>
        <ChartSeries XName="X" DataSource="@ExpenseReports"
                     YName="Y" Fill="blue" Type="ChartSeriesType.StackingLine100">
            <ChartMarker Visible="true">
            </ChartMarker>
        </ChartSeries>
        <ChartSeries XName="X" DataSource="@ExpenseReports"
                     YName="Y1" Fill="green" Type="ChartSeriesType.StackingLine100">
            <ChartMarker Visible="true">
            </ChartMarker>
        </ChartSeries>
        <ChartSeries XName="X" DataSource="@ExpenseReports"
                     YName="Y2" Fill="red" Type="ChartSeriesType.StackingLine100">
            <ChartMarker Visible="true">
            </ChartMarker>
        </ChartSeries>
        <ChartSeries XName="X" DataSource="@ExpenseReports"
                     YName="Y3" Fill="black" Type="ChartSeriesType.StackingLine100">
            <ChartMarker Visible="true">
            </ChartMarker>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class ChartData
    {
        public string X { get; set; }
        public double Y { get; set; }
        public double Y1 { get; set; }
        public double Y2 { get; set; }
        public double Y3 { get; set; }
    }

    public List<ChartData> ExpenseReports = new List<ChartData>
    {
         new ChartData { X = "Food" , Y = 90, Y1 = 40 , Y2= 70, Y3= 120},
         new ChartData { X = "Transport", Y = 80, Y1 = 90, Y2= 110, Y3= 70 },
         new ChartData { X = "Medical",Y = 50, Y1 = 80, Y2= 120, Y3= 50 },
         new ChartData { X = "Clothes",Y = 70, Y1 = 30, Y2= 60, Y3= 180 },
         new ChartData { X = "Personal Care", Y = 30, Y1 = 80, Y2= 80, Y3= 30 },
         new ChartData { X = "Books", Y = 10, Y1 = 40, Y2= 30, Y3= 270},
         new ChartData { X = "Fitness",Y = 100, Y1 = 30, Y2= 70, Y3= 40 },
         new ChartData { X = "Electricity", Y = 55, Y1 = 95, Y2= 55, Y3= 75},
         new ChartData { X = "Tax", Y = 20, Y1 = 50, Y2= 40, Y3= 65 },
         new ChartData { X = "Pet Care", Y = 40, Y1 = 20, Y2= 80, Y3= 95 },
         new ChartData { X = "Education", Y = 45, Y1 = 15, Y2= 45, Y3= 195 },
         new ChartData { X = "Entertainment", Y = 75, Y1 = 45, Y2= 65, Y3= 115 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VZhpNvMxVrNGkxdr?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

The [Fill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Fill) property can be used to apply a gradient color to the 100% stacked line series. By configuring this property with gradient values, you can create a visually appealing effect in which the color transitions smoothly from one shade to another.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart Title="Family Expense for Month">
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category">
    </ChartPrimaryXAxis>

    <ChartSeriesCollection>
        <ChartSeries XName="X" DataSource="@ExpenseReports"
                     YName="Y" Fill="url(#grad1)" Type="ChartSeriesType.StackingLine100">
            <ChartMarker Visible="true"></ChartMarker>
        </ChartSeries>
        <ChartSeries XName="X" DataSource="@ExpenseReports"
                     YName="Y1" Fill="url(#grad2)" Type="ChartSeriesType.StackingLine100">
            <ChartMarker Visible="true"></ChartMarker>
        </ChartSeries>
        <ChartSeries XName="X" DataSource="@ExpenseReports"
                     YName="Y2" Fill="url(#grad3)" Type="ChartSeriesType.StackingLine100">
            <ChartMarker Visible="true"></ChartMarker>
        </ChartSeries>
        <ChartSeries XName="X" DataSource="@ExpenseReports"
                     YName="Y3" Fill="url(#grad4)" Type="ChartSeriesType.StackingLine100">
            <ChartMarker Visible="true"></ChartMarker>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

<svg style="height: 0">
    <defs>
        <linearGradient id="grad1" x1="0%" y1="0%" x2="0%" y2="100%">
            <stop offset="20%" style="stop-color:orange;stop-opacity:1" />
            <stop offset="100%" style="stop-color:black;stop-opacity:1" />
        </linearGradient>

        <linearGradient id="grad2" x1="0%" y1="0%" x2="0%" y2="100%">
            <stop offset="20%" style="stop-color:lightgreen;stop-opacity:1" />
            <stop offset="100%" style="stop-color:green;stop-opacity:1" />
        </linearGradient>

        <linearGradient id="grad3" x1="0%" y1="0%" x2="0%" y2="100%">
            <stop offset="20%" style="stop-color:pink;stop-opacity:1" />
            <stop offset="100%" style="stop-color:red;stop-opacity:1" />
        </linearGradient>

        <linearGradient id="grad4" x1="0%" y1="0%" x2="0%" y2="100%">
            <stop offset="20%" style="stop-color:gray;stop-opacity:1" />
            <stop offset="100%" style="stop-color:black;stop-opacity:1" />
        </linearGradient>
    </defs>
</svg>

@code {
    public class ChartData
    {
        public string X { get; set; }
        public double Y { get; set; }
        public double Y1 { get; set; }
        public double Y2 { get; set; }
        public double Y3 { get; set; }
    }

    public List<ChartData> ExpenseReports = new List<ChartData>
    {
         new ChartData { X = "Food" , Y = 90, Y1 = 40 , Y2= 70, Y3= 120},
         new ChartData { X = "Transport", Y = 80, Y1 = 90, Y2= 110, Y3= 70 },
         new ChartData { X = "Medical",Y = 50, Y1 = 80, Y2= 120, Y3= 50 },
         new ChartData { X = "Clothes",Y = 70, Y1 = 30, Y2= 60, Y3= 180 },
         new ChartData { X = "Personal Care", Y = 30, Y1 = 80, Y2= 80, Y3= 30 },
         new ChartData { X = "Books", Y = 10, Y1 = 40, Y2= 30, Y3= 270},
         new ChartData { X = "Fitness",Y = 100, Y1 = 30, Y2= 70, Y3= 40 },
         new ChartData { X = "Electricity", Y = 55, Y1 = 95, Y2= 55, Y3= 75},
         new ChartData { X = "Tax", Y = 20, Y1 = 50, Y2= 40, Y3= 65 },
         new ChartData { X = "Pet Care", Y = 40, Y1 = 20, Y2= 80, Y3= 95 },
         new ChartData { X = "Education", Y = 45, Y1 = 15, Y2= 45, Y3= 195 },
         new ChartData { X = "Entertainment", Y = 75, Y1 = 45, Y2= 65, Y3= 115 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BNBTXlMxLPhEYpdw?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

**Opacity**

The [Opacity](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Opacity) – property specifies the transparency level of the [Fill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Fill). Adjusting this property allows you to control how opaque or transparent the fill color of the series appears.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart Title="Family Expense for Month">
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category">
    </ChartPrimaryXAxis>

    <ChartSeriesCollection>
        <ChartSeries XName="X" DataSource="@ExpenseReports"
                     YName="Y" Fill="blue" Opacity="0.7" Type="ChartSeriesType.StackingLine100">
            <ChartMarker Visible="true">
            </ChartMarker>
        </ChartSeries>
        <ChartSeries XName="X" DataSource="@ExpenseReports"
                     YName="Y1" Fill="green" Opacity="0.7" Type="ChartSeriesType.StackingLine100">
            <ChartMarker Visible="true">
            </ChartMarker>
        </ChartSeries>
        <ChartSeries XName="X" DataSource="@ExpenseReports"
                     YName="Y2" Fill="red" Opacity="0.7" Type="ChartSeriesType.StackingLine100">
            <ChartMarker Visible="true">
            </ChartMarker>
        </ChartSeries>
        <ChartSeries XName="X" DataSource="@ExpenseReports"
                     YName="Y3" Fill="black" Opacity="0.7" Type="ChartSeriesType.StackingLine100">
            <ChartMarker Visible="true">
            </ChartMarker>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class ChartData
    {
        public string X { get; set; }
        public double Y { get; set; }
        public double Y1 { get; set; }
        public double Y2 { get; set; }
        public double Y3 { get; set; }
    }

    public List<ChartData> ExpenseReports = new List<ChartData>
    {
         new ChartData { X = "Food" , Y = 90, Y1 = 40 , Y2= 70, Y3= 120},
         new ChartData { X = "Transport", Y = 80, Y1 = 90, Y2= 110, Y3= 70 },
         new ChartData { X = "Medical",Y = 50, Y1 = 80, Y2= 120, Y3= 50 },
         new ChartData { X = "Clothes",Y = 70, Y1 = 30, Y2= 60, Y3= 180 },
         new ChartData { X = "Personal Care", Y = 30, Y1 = 80, Y2= 80, Y3= 30 },
         new ChartData { X = "Books", Y = 10, Y1 = 40, Y2= 30, Y3= 270},
         new ChartData { X = "Fitness",Y = 100, Y1 = 30, Y2= 70, Y3= 40 },
         new ChartData { X = "Electricity", Y = 55, Y1 = 95, Y2= 55, Y3= 75},
         new ChartData { X = "Tax", Y = 20, Y1 = 50, Y2= 40, Y3= 65 },
         new ChartData { X = "Pet Care", Y = 40, Y1 = 20, Y2= 80, Y3= 95 },
         new ChartData { X = "Education", Y = 45, Y1 = 15, Y2= 45, Y3= 195 },
         new ChartData { X = "Entertainment", Y = 75, Y1 = 45, Y2= 65, Y3= 115 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BjhJtPixLVgdYjtA?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

**Width**

The [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Width) property specifies the stroke width applied to the series.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart Title="Family Expense for Month">
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category">
    </ChartPrimaryXAxis>

    <ChartSeriesCollection>
        <ChartSeries XName="X" DataSource="@ExpenseReports"
                     YName="Y" Fill="blue" Opacity="0.7" Width="2" Type="ChartSeriesType.StackingLine100">
            <ChartMarker Visible="true">
            </ChartMarker>
        </ChartSeries>
        <ChartSeries XName="X" DataSource="@ExpenseReports"
                     YName="Y1" Fill="green" Opacity="0.7" Width="2" Type="ChartSeriesType.StackingLine100">
            <ChartMarker Visible="true">
            </ChartMarker>
        </ChartSeries>
        <ChartSeries XName="X" DataSource="@ExpenseReports"
                     YName="Y2" Fill="red" Opacity="0.7" Width="2" Type="ChartSeriesType.StackingLine100">
            <ChartMarker Visible="true">
            </ChartMarker>
        </ChartSeries>
        <ChartSeries XName="X" DataSource="@ExpenseReports"
                     YName="Y3" Fill="black" Opacity="0.7" Width="2" Type="ChartSeriesType.StackingLine100">
            <ChartMarker Visible="true">
            </ChartMarker>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class ChartData
    {
        public string X { get; set; }
        public double Y { get; set; }
        public double Y1 { get; set; }
        public double Y2 { get; set; }
        public double Y3 { get; set; }
    }

    public List<ChartData> ExpenseReports = new List<ChartData>
    {
         new ChartData { X = "Food" , Y = 90, Y1 = 40 , Y2= 70, Y3= 120},
         new ChartData { X = "Transport", Y = 80, Y1 = 90, Y2= 110, Y3= 70 },
         new ChartData { X = "Medical",Y = 50, Y1 = 80, Y2= 120, Y3= 50 },
         new ChartData { X = "Clothes",Y = 70, Y1 = 30, Y2= 60, Y3= 180 },
         new ChartData { X = "Personal Care", Y = 30, Y1 = 80, Y2= 80, Y3= 30 },
         new ChartData { X = "Books", Y = 10, Y1 = 40, Y2= 30, Y3= 270},
         new ChartData { X = "Fitness",Y = 100, Y1 = 30, Y2= 70, Y3= 40 },
         new ChartData { X = "Electricity", Y = 55, Y1 = 95, Y2= 55, Y3= 75},
         new ChartData { X = "Tax", Y = 20, Y1 = 50, Y2= 40, Y3= 65 },
         new ChartData { X = "Pet Care", Y = 40, Y1 = 20, Y2= 80, Y3= 95 },
         new ChartData { X = "Education", Y = 45, Y1 = 15, Y2= 45, Y3= 195 },
         new ChartData { X = "Entertainment", Y = 75, Y1 = 45, Y2= 65, Y3= 115 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BjrTDFWRrUwyyFzg?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

**DashArray**

The [DashArray](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_DashArray) property determines the pattern of dashes and gaps in the series.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart Title="Family Expense for Month">
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category">
    </ChartPrimaryXAxis>
	
    <ChartSeriesCollection>
        <ChartSeries XName="X" Width="2" DashArray="5,1" DataSource="@ExpenseReports"
                     YName="Y" Fill="blue" Opacity="0.7" Type="ChartSeriesType.StackingLine100">
            <ChartMarker Visible="true">
            </ChartMarker>
        </ChartSeries>
        <ChartSeries XName="X" Width="2" DashArray="5,1" DataSource="@ExpenseReports"
                     YName="Y1" Fill="green" Opacity="0.7" Type="ChartSeriesType.StackingLine100">
            <ChartMarker Visible="true">
            </ChartMarker>
        </ChartSeries>
        <ChartSeries XName="X" Width="2" DashArray="5,1" DataSource="@ExpenseReports"
                     YName="Y2" Fill="red" Opacity="0.7" Type="ChartSeriesType.StackingLine100">
            <ChartMarker Visible="true">
            </ChartMarker>
        </ChartSeries>
        <ChartSeries XName="X" Width="2" DashArray="5,1" DataSource="@ExpenseReports"
                     YName="Y3" Fill="black" Opacity="0.7" Type="ChartSeriesType.StackingLine100">
            <ChartMarker Visible="true">
            </ChartMarker>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code{
    public class ChartData
    {
        public string X { get; set; }
        public double Y { get; set; }
        public double Y1 { get; set; }
        public double Y2 { get; set; }
        public double Y3 { get; set; }
    }
	
    public List<ChartData> ExpenseReports = new List<ChartData>
	{
         new ChartData { X = "Food" , Y = 90, Y1 = 40 , Y2= 70, Y3= 120},
         new ChartData { X = "Transport", Y = 80, Y1 = 90, Y2= 110, Y3= 70 },
         new ChartData { X = "Medical",Y = 50, Y1 = 80, Y2= 120, Y3= 50 },
         new ChartData { X = "Clothes",Y = 70, Y1 = 30, Y2= 60, Y3= 180 },
         new ChartData { X = "Personal Care", Y = 30, Y1 = 80, Y2= 80, Y3= 30 },
         new ChartData { X = "Books", Y = 10, Y1 = 40, Y2= 30, Y3= 270},
         new ChartData { X = "Fitness",Y = 100, Y1 = 30, Y2= 70, Y3= 40 },
         new ChartData { X = "Electricity", Y = 55, Y1 = 95, Y2= 55, Y3= 75},
         new ChartData { X = "Tax", Y = 20, Y1 = 50, Y2= 40, Y3= 65 },
         new ChartData { X = "Pet Care", Y = 40, Y1 = 20, Y2= 80, Y3= 95 },
         new ChartData { X = "Education", Y = 45, Y1 = 15, Y2= 45, Y3= 195 },
         new ChartData { X = "Entertainment", Y = 75, Y1 = 45, Y2= 65, Y3= 115 }
    };
}

``` 
{% previewsample "https://blazorplayground.syncfusion.com/embed/BDhUsBrnVIxJdFqq?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Empty points

Data points with `null` or `undefined` values are considered empty. Empty data points are ignored and not plotted on the chart.

**Mode**

Use the [`Mode`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEmptyPointSettings.html#Syncfusion_Blazor_Charts_ChartEmptyPointSettings_Mode) property to define how empty or missing data points are handled in the series. The default mode for empty points is [`Gap`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.EmptyPointMode.html#Syncfusion_Blazor_Charts_EmptyPointMode_Gap).

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart Title="Family Expense for Month">
    <ChartPrimaryXAxis LabelRotation="90" ValueType="Syncfusion.Blazor.Charts.ValueType.Category">
    </ChartPrimaryXAxis>

    <ChartSeriesCollection>
        <ChartSeries XName="X" DataSource="@ExpenseReports" YName="Y" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingLine100">
            <ChartEmptyPointSettings Mode="EmptyPointMode.Average"></ChartEmptyPointSettings>
            <ChartMarker Visible="true"></ChartMarker>
        </ChartSeries>
        <ChartSeries XName="X" DataSource="@ExpenseReports" YName="Y1" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingLine100">
            <ChartMarker Visible="true"></ChartMarker>
        </ChartSeries>
        <ChartSeries XName="X" DataSource="@ExpenseReports" YName="Y2" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingLine100">
            <ChartEmptyPointSettings Mode="EmptyPointMode.Gap"></ChartEmptyPointSettings>
            <ChartMarker Visible="true"></ChartMarker>
        </ChartSeries>
        <ChartSeries XName="X" DataSource="@ExpenseReports" YName="Y3" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingLine100">
            <ChartMarker Visible="true"></ChartMarker>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class ChartData
    {
        public string X { get; set; }
        public double Y { get; set; }
        public double Y1 { get; set; }
        public double Y2 { get; set; }
        public double Y3 { get; set; }
    }

    public List<ChartData> ExpenseReports = new List<ChartData>
    {
         new ChartData { X = "Food" , Y = 90, Y1 = 40 , Y2= 70, Y3= 120},
         new ChartData { X = "Transport", Y = 80, Y1 = 90, Y2= 110, Y3= 70 },
         new ChartData { X = "Medical",Y = 50, Y1 = 80, Y2= 120, Y3= 50 },
         new ChartData { X = "Clothes",Y = 70, Y1 = 30, Y2= 60, Y3= 180 },
         new ChartData { X = "Personal Care", Y = 30, Y1 = 80, Y2= 80, Y3= 30 },
         new ChartData { X = "Books", Y = double.NaN, Y1 = 40, Y2= double.NaN, Y3= 270},
         new ChartData { X = "Fitness",Y = 100, Y1 = 30, Y2= 70, Y3= 40 },
         new ChartData { X = "Electricity", Y = 55, Y1 = 95, Y2= 55, Y3= 75},
         new ChartData { X = "Tax", Y = 20, Y1 = 50, Y2= 40, Y3= 65 },
         new ChartData { X = "Pet Care", Y = 40, Y1 = 20, Y2= 80, Y3= 95 },
         new ChartData { X = "Education", Y = 45, Y1 = 15, Y2= 45, Y3= 195 },
         new ChartData { X = "Entertainment", Y = 75, Y1 = 45, Y2= 65, Y3= 115 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BtBzjkCLTJvEceAo?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

**Fill**

Use the [`Fill`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEmptyPointSettings.html#Syncfusion_Blazor_Charts_ChartEmptyPointSettings_Fill) property to customize the fill color of empty points in the series.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart Title="Family Expense for Month">
    <ChartPrimaryXAxis LabelRotation="90" ValueType="Syncfusion.Blazor.Charts.ValueType.Category">
    </ChartPrimaryXAxis>

    <ChartSeriesCollection>
        <ChartSeries XName="X" DataSource="@ExpenseReports" YName="Y" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingLine100">
            <ChartEmptyPointSettings Mode="EmptyPointMode.Average" Fill="red"></ChartEmptyPointSettings>
            <ChartMarker Visible="true"></ChartMarker>
        </ChartSeries>
        <ChartSeries XName="X" DataSource="@ExpenseReports" YName="Y1" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingLine100">
            <ChartMarker Visible="true"></ChartMarker>
        </ChartSeries>
        <ChartSeries XName="X" DataSource="@ExpenseReports" YName="Y2" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingLine100">
            <ChartEmptyPointSettings Mode="EmptyPointMode.Gap"></ChartEmptyPointSettings>
            <ChartMarker Visible="true"></ChartMarker>
        </ChartSeries>
        <ChartSeries XName="X" DataSource="@ExpenseReports" YName="Y3" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingLine100">
            <ChartMarker Visible="true"></ChartMarker>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class ChartData
    {
        public string X { get; set; }
        public double Y { get; set; }
        public double Y1 { get; set; }
        public double Y2 { get; set; }
        public double Y3 { get; set; }
    }

    public List<ChartData> ExpenseReports = new List<ChartData>
    {
         new ChartData { X = "Food" , Y = 90, Y1 = 40 , Y2= 70, Y3= 120},
         new ChartData { X = "Transport", Y = 80, Y1 = 90, Y2= 110, Y3= 70 },
         new ChartData { X = "Medical",Y = 50, Y1 = 80, Y2= 120, Y3= 50 },
         new ChartData { X = "Clothes",Y = 70, Y1 = 30, Y2= 60, Y3= 180 },
         new ChartData { X = "Personal Care", Y = 30, Y1 = 80, Y2= 80, Y3= 30 },
         new ChartData { X = "Books", Y = double.NaN, Y1 = 40, Y2= double.NaN, Y3= 270},
         new ChartData { X = "Fitness",Y = 100, Y1 = 30, Y2= 70, Y3= 40 },
         new ChartData { X = "Electricity", Y = 55, Y1 = 95, Y2= 55, Y3= 75},
         new ChartData { X = "Tax", Y = 20, Y1 = 50, Y2= 40, Y3= 65 },
         new ChartData { X = "Pet Care", Y = 40, Y1 = 20, Y2= 80, Y3= 95 },
         new ChartData { X = "Education", Y = 45, Y1 = 15, Y2= 45, Y3= 195 },
         new ChartData { X = "Entertainment", Y = 75, Y1 = 45, Y2= 65, Y3= 115 }
    };
}

``` 
{% previewsample "https://blazorplayground.syncfusion.com/embed/VDhzZECrpyXsTCTm?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

**Border**

Use the [`Border`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEmptyPointSettings.html#Syncfusion_Blazor_Charts_ChartEmptyPointSettings_Border) property to customize the [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEmptyPointBorder.html#Syncfusion_Blazor_Charts_ChartEmptyPointBorder_Width) and [Color](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEmptyPointBorder.html#Syncfusion_Blazor_Charts_ChartEmptyPointBorder_Color) of the border for empty points.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart Title="Family Expense for Month">
    <ChartPrimaryXAxis LabelRotation="90" ValueType="Syncfusion.Blazor.Charts.ValueType.Category">
    </ChartPrimaryXAxis>

    <ChartSeriesCollection>
        <ChartSeries XName="X" DataSource="@ExpenseReports" YName="Y" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingLine100">
            <ChartEmptyPointSettings Mode="EmptyPointMode.Average" Fill="red">
                <ChartEmptyPointBorder Color="green" Width="2"></ChartEmptyPointBorder>
            </ChartEmptyPointSettings>
            <ChartMarker Visible="true"></ChartMarker>
        </ChartSeries>
        <ChartSeries XName="X" DataSource="@ExpenseReports" YName="Y1" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingLine100">
            <ChartMarker Visible="true"></ChartMarker>
        </ChartSeries>
        <ChartSeries XName="X" DataSource="@ExpenseReports" YName="Y2" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingLine100">
            <ChartEmptyPointSettings Mode="EmptyPointMode.Gap"></ChartEmptyPointSettings>
            <ChartMarker Visible="true"></ChartMarker>
        </ChartSeries>
        <ChartSeries XName="X" DataSource="@ExpenseReports" YName="Y3" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingLine100">
            <ChartMarker Visible="true"></ChartMarker>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class ChartData
    {
        public string X { get; set; }
        public double Y { get; set; }
        public double Y1 { get; set; }
        public double Y2 { get; set; }
        public double Y3 { get; set; }
    }

    public List<ChartData> ExpenseReports = new List<ChartData>
    {
         new ChartData { X = "Food" , Y = 90, Y1 = 40 , Y2= 70, Y3= 120},
         new ChartData { X = "Transport", Y = 80, Y1 = 90, Y2= 110, Y3= 70 },
         new ChartData { X = "Medical",Y = 50, Y1 = 80, Y2= 120, Y3= 50 },
         new ChartData { X = "Clothes",Y = 70, Y1 = 30, Y2= 60, Y3= 180 },
         new ChartData { X = "Personal Care", Y = 30, Y1 = 80, Y2= 80, Y3= 30 },
         new ChartData { X = "Books", Y = double.NaN, Y1 = 40, Y2= double.NaN, Y3= 270},
         new ChartData { X = "Fitness",Y = 100, Y1 = 30, Y2= 70, Y3= 40 },
         new ChartData { X = "Electricity", Y = 55, Y1 = 95, Y2= 55, Y3= 75},
         new ChartData { X = "Tax", Y = 20, Y1 = 50, Y2= 40, Y3= 65 },
         new ChartData { X = "Pet Care", Y = 40, Y1 = 20, Y2= 80, Y3= 95 },
         new ChartData { X = "Education", Y = 45, Y1 = 15, Y2= 45, Y3= 195 },
         new ChartData { X = "Entertainment", Y = 75, Y1 = 45, Y2= 65, Y3= 115 }
    };
}

``` 
{% previewsample "https://blazorplayground.syncfusion.com/embed/BNhpjaihpyjGvmon?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Stack labels

The stack labels display cumulative total values for stack segments directly using data labels. If all the values in a stack segment are negative, the stack label is displayed below the point.

The [Visible](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartStackLabelSettings.html#Syncfusion_Blazor_Charts_ChartStackLabelSettings_Visible) property of the [ChartStackLabelSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartStackLabelSettings.html) is used to enable stack labels. Setting it to **true** will display the stack labels.

```cshtml
@using Syncfusion.Blazor.Charts

<SfChart Title="Family Expense for Month">

    <ChartPrimaryXAxis LabelRotation="90" ValueType="Syncfusion.Blazor.Charts.ValueType.Category" Interval="1">
    </ChartPrimaryXAxis>

    <ChartPrimaryYAxis Title="Expense" Interval="100" LabelFormat="${value}">
    </ChartPrimaryYAxis>

    <ChartArea>
        <ChartAreaBorder Width="0"></ChartAreaBorder>
    </ChartArea>

    <ChartSeriesCollection>
        <ChartSeries XName="X" DataSource="@ExpenseReports"
                     YName="Y" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingLine100">
            <ChartSeriesAnimation Enable="false" />
            <ChartMarker Visible="true">
                <ChartDataLabel Visible="true"/>
            </ChartMarker>
        </ChartSeries>
        <ChartSeries XName="X" DataSource="@ExpenseReports"
                     YName="Y2" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingLine100">
            <ChartSeriesAnimation Enable="false" />
            <ChartMarker Visible="true">
                <ChartDataLabel Visible="true"/>
            </ChartMarker>
        </ChartSeries>
        <ChartSeries XName="X" DataSource="@ExpenseReports"
                     YName="Y3" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingLine100">
            <ChartSeriesAnimation Enable="false" />
            <ChartMarker Visible="true">
                <ChartDataLabel Visible="true"/>
            </ChartMarker>
        </ChartSeries>
    </ChartSeriesCollection>

    <ChartStackLabelSettings  Visible="true">
    </ChartStackLabelSettings>
</SfChart>

@code {
    public class ChartData
    {
        public string X { get; set; }
        public double Y { get; set; }
        public double Y2 { get; set; }
        public double Y3 { get; set; }
    }

    public List<ChartData> ExpenseReports = new List<ChartData>
    {
        new ChartData { X = "Food" , Y = 90, Y2= 70, Y3= 120},
        new ChartData { X = "Transport", Y = 80, Y2= 110, Y3= 70 },
        new ChartData { X = "Medical",Y = 50, Y2= 120, Y3= 50 },
        new ChartData { X = "Clothes",Y = 70, Y2= 60, Y3= 180 },
        new ChartData { X = "Personal Care", Y = 30, Y2= 80, Y3= 30 },
        new ChartData { X = "Books", Y = 10, Y2= 30, Y3= 270},
        new ChartData { X = "Fitness",Y = 100, Y2= 70, Y3= 40 },
        new ChartData { X = "Electricity", Y = 55, Y2= 55, Y3= 75}
    };
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/hXLeNxrxptwavgKW?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Customization

The stack labels can be customized using the `ChartStackLabelSettings` properties as given below.

* [Fill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartStackLabelSettings.html#Syncfusion_Blazor_Charts_ChartStackLabelSettings_Fill) - Specifies the background color of the stack labels when border is set. The default value is **transparent**.
* [Format](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartStackLabelSettings.html#Syncfusion_Blazor_Charts_ChartStackLabelSettings_Format) - Specifies the format of the stack labels. It supports a placeholder `{value}` which will be replaced by the stack label value.
* [Rx](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartStackLabelSettings.html#Syncfusion_Blazor_Charts_ChartStackLabelSettings_Rx) - Specifies the rounded corner radius along the X-axis (horizontal direction) for the stack label background. The default value is **5**.
* [Ry](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartStackLabelSettings.html#Syncfusion_Blazor_Charts_ChartStackLabelSettings_Ry) - Specifies the rounded corner radius along the Y-axis (vertical direction) for the stack label background. The default value is **5**.
* [Angle](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartStackLabelSettings.html#Syncfusion_Blazor_Charts_ChartStackLabelSettings_Angle) - Specifies the rotation angle for stack labels in degrees. The default value is **0**.

We can customize the font of the stack labels using the [ChartStackLabelFont](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartStackLabelFont.html) properties as given below:

* [TextAlignment](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartStackLabelFont.html#Syncfusion_Blazor_Charts_ChartStackLabelFont_TextAlignment) - Customizes the alignment of the text within the stack label.
* [FontFamily](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartStackLabelFont.html#Syncfusion_Blazor_Charts_ChartStackLabelFont_FontFamily) - Customizes the font family for the stack label text.
* [Size](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartStackLabelFont.html#Syncfusion_Blazor_Charts_ChartStackLabelFont_Size) - Customizes the font size of the stack label text.
* [FontStyle](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartDefaultFont.html#Syncfusion_Blazor_Charts_ChartDefaultFont_FontStyle) - Customizes the font style of the stack label text.
* [FontWeight](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartStackLabelFont.html#Syncfusion_Blazor_Charts_ChartStackLabelFont_FontWeight) - Customizes the font weight of the stack label text.
* [Color](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartStackLabelFont.html#Syncfusion_Blazor_Charts_ChartStackLabelFont_Color) - Customizes the color of the stack label text.

We can customize the border of the stack labels using the [ChartStackLabelBorder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartStackLabelBorder.html) properties as given below:

* [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartStackLabelBorder.html#Syncfusion_Blazor_Charts_ChartStackLabelBorder_Width) - Specifies the width of the border around the stack label.
* [Color](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartDefaultBorder.html#Syncfusion_Blazor_Charts_ChartDefaultBorder_Color) - Specifies the color of the border around the stack label.

 To customize the margin, we can use the [ChartStackLabelMargin](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartStackLabelMargin.html) properties as given below:

* [Bottom](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartStackLabelMargin.html#Syncfusion_Blazor_Charts_ChartStackLabelMargin_Bottom) - Specifies the bottom margin of the stack label.
* [Top](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartStackLabelMargin.html#Syncfusion_Blazor_Charts_ChartStackLabelMargin_Top) - Specifies the top margin of the stack label.
* [Right](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartStackLabelMargin.html#Syncfusion_Blazor_Charts_ChartStackLabelMargin_Right) - Specifies the right margin of the stack label.
* [Left](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartStackLabelMargin.html#Syncfusion_Blazor_Charts_ChartStackLabelMargin_Left) - Specifies the left margin of the stack label.

```cshtml
@using Syncfusion.Blazor.Charts

<SfChart Title="Family Expense for Month">

    <ChartPrimaryXAxis LabelRotation="90" ValueType="Syncfusion.Blazor.Charts.ValueType.Category" Interval="1">
    </ChartPrimaryXAxis>

    <ChartPrimaryYAxis Title="Expense" Interval="100" LabelFormat="${value}">
    </ChartPrimaryYAxis>

    <ChartArea>
        <ChartAreaBorder Width="0"></ChartAreaBorder>
    </ChartArea>

    <ChartSeriesCollection>
        <ChartSeries XName="X" DataSource="@ExpenseReports"
                     YName="Y" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingLine100">
            <ChartSeriesAnimation Enable="false" />
            <ChartMarker Visible="true">
                <ChartDataLabel Visible="true" />
            </ChartMarker>
        </ChartSeries>
        <ChartSeries XName="X" DataSource="@ExpenseReports"
                     YName="Y2" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingLine100">
            <ChartSeriesAnimation Enable="false" />
            <ChartMarker Visible="true">
                <ChartDataLabel Visible="true" />
            </ChartMarker>
        </ChartSeries>
        <ChartSeries XName="X" DataSource="@ExpenseReports"
                     YName="Y3" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingLine100">
            <ChartSeriesAnimation Enable="false" />
            <ChartMarker Visible="true">
                <ChartDataLabel Visible="true" />
            </ChartMarker>
        </ChartSeries>
    </ChartSeriesCollection>

    <ChartStackLabelSettings Visible="true" Format="{value}" Fill="#ADD8E6" Rx="10" Ry="10" Angle="35">
        <ChartStackLabelFont TextAlignment="Alignment.Center" FontFamily="Roboto" Size="12px" FontStyle="bold" FontWeight="600" Color="blue" />
        <ChartStackLabelBorder Width="2" Color="#000000" />
        <ChartStackLabelMargin Bottom="8" Top="8" Right="8" Left="8" />
    </ChartStackLabelSettings>
</SfChart>

@code {
    public class ChartData
    {
        public string X { get; set; }
        public double Y { get; set; }
        public double Y2 { get; set; }
        public double Y3 { get; set; }
    }

    public List<ChartData> ExpenseReports = new List<ChartData>
    {
        new ChartData { X = "Food" , Y = 90, Y2= 70, Y3= 120},
        new ChartData { X = "Transport", Y = 80, Y2= 110, Y3= 70 },
        new ChartData { X = "Medical",Y = 50, Y2= 120, Y3= 50 },
        new ChartData { X = "Clothes",Y = 70, Y2= 60, Y3= 180 },
        new ChartData { X = "Personal Care", Y = 30, Y2= 80, Y3= 30 },
        new ChartData { X = "Books", Y = 10, Y2= 30, Y3= 270},
        new ChartData { X = "Fitness",Y = 100, Y2= 70, Y3= 40 },
        new ChartData { X = "Electricity", Y = 55, Y2= 55, Y3= 75},
    };
}
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/BDByZdBHfjFPhexI?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Events

### Series render

The [`OnSeriesRender`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_OnSeriesRender) event allows you to customize series properties, such as [Data](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SeriesRenderEventArgs.html#Syncfusion_Blazor_Charts_SeriesRenderEventArgs_Data), [Fill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SeriesRenderEventArgs.html#Syncfusion_Blazor_Charts_SeriesRenderEventArgs_Fill), and [Series](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SeriesRenderEventArgs.html#Syncfusion_Blazor_Charts_SeriesRenderEventArgs_Series), before they are rendered on the chart.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart Title="Family Expense for Month">
    <ChartEvents OnSeriesRender="SeriesRender"></ChartEvents>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category"></ChartPrimaryXAxis>
     <ChartSeriesCollection>
        <ChartSeries XName="X" Width="2" DashArray="5,1" DataSource="@ExpenseReports"
                     YName="Y" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingLine100">
            <ChartMarker Visible="true">
            </ChartMarker>
        </ChartSeries>
        <ChartSeries XName="X" Width="2" DashArray="5,1" DataSource="@ExpenseReports"
                     YName="Y1" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingLine100">
            <ChartMarker Visible="true">
            </ChartMarker>
        </ChartSeries>
        <ChartSeries XName="X" Width="2" DashArray="5,1" DataSource="@ExpenseReports"
                     YName="Y2" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingLine100">
            <ChartMarker Visible="true">
            </ChartMarker>
        </ChartSeries>
        <ChartSeries XName="X" Width="2" DashArray="5,1" DataSource="@ExpenseReports"
                     YName="Y3" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingLine100">
            <ChartMarker Visible="true">
            </ChartMarker>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class ChartData
    {
        public string X { get; set; }
        public double Y { get; set; }
        public double Y1 { get; set; }
        public double Y2 { get; set; }
        public double Y3 { get; set; }
    }

    public List<ChartData> ExpenseReports = new List<ChartData>
	{
        new ChartData { X = "Food" , Y = 90, Y1 = 40 , Y2= 70, Y3= 120},
        new ChartData { X = "Transport", Y = 80, Y1 = 90, Y2= 110, Y3= 70 },
        new ChartData { X = "Medical",Y = 50, Y1 = 80, Y2= 120, Y3= 50 },
        new ChartData { X = "Clothes",Y = 70, Y1 = 30, Y2= 60, Y3= 180 },
        new ChartData { X = "Personal Care", Y = 30, Y1 = 80, Y2= 80, Y3= 30 },
        new ChartData { X = "Books", Y = 10, Y1 = 40, Y2= 30, Y3= 270},
        new ChartData { X = "Fitness",Y = 100, Y1 = 30, Y2= 70, Y3= 40 },
        new ChartData { X = "Electricity", Y = 55, Y1 = 95, Y2= 55, Y3= 75},
        new ChartData { X = "Tax", Y = 20, Y1 = 50, Y2= 40, Y3= 65 },
        new ChartData { X = "Pet Care", Y = 40, Y1 = 20, Y2= 80, Y3= 95 },
        new ChartData { X = "Education", Y = 45, Y1 = 15, Y2= 45, Y3= 195 },
        new ChartData { X = "Entertainment", Y = 75, Y1 = 45, Y2= 65, Y3= 115 }
    };

    public void SeriesRender(SeriesRenderEventArgs args)
    {
        args.Fill = "#FF4081";
    }
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/rNLpZvBiCLhmMMJU?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Point render

The [`OnPointRender`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_OnPointRender) event allows you to customize each data point before it is rendered on the chart.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart Title="Family Expense for Month">
    <ChartEvents OnPointRender="PointRender"></ChartEvents>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category"></ChartPrimaryXAxis>
     <ChartSeriesCollection>
        <ChartSeries XName="X" Width="2" DashArray="5,1" DataSource="@ExpenseReports"
                     YName="Y" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingLine100">
            <ChartMarker Visible="true" Height="10" Width ="10">
            </ChartMarker>
        </ChartSeries>
        <ChartSeries XName="X" Width="2" DashArray="5,1" DataSource="@ExpenseReports"
                     YName="Y1" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingLine100">
            <ChartMarker Visible="true" Height="10" Width ="10">
            </ChartMarker>
        </ChartSeries>
        <ChartSeries XName="X" Width="2" DashArray="5,1" DataSource="@ExpenseReports"
                     YName="Y2" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingLine100">
            <ChartMarker Visible="true" Height="10" Width ="10">
            </ChartMarker>
        </ChartSeries>
        <ChartSeries XName="X" Width="2" DashArray="5,1" DataSource="@ExpenseReports"
                     YName="Y3" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingLine100">
            <ChartMarker Visible="true" Height="10" Width ="10">
            </ChartMarker>
        </ChartSeries>
    </ChartSeriesCollection>

</SfChart>

@code {
    public class ChartData
    {
        public string X { get; set; }
        public double Y { get; set; }
        public double Y1 { get; set; }
        public double Y2 { get; set; }
        public double Y3 { get; set; }
    }

    public List<ChartData> ExpenseReports = new List<ChartData>
	{
        new ChartData { X = "Food" , Y = 90, Y1 = 40 , Y2= 70, Y3= 120},
        new ChartData { X = "Transport", Y = 80, Y1 = 90, Y2= 110, Y3= 70 },
        new ChartData { X = "Medical",Y = 50, Y1 = 80, Y2= 120, Y3= 50 },
        new ChartData { X = "Clothes",Y = 70, Y1 = 30, Y2= 60, Y3= 180 },
        new ChartData { X = "Personal Care", Y = 30, Y1 = 80, Y2= 80, Y3= 30 },
        new ChartData { X = "Books", Y = 10, Y1 = 40, Y2= 30, Y3= 270},
        new ChartData { X = "Fitness",Y = 100, Y1 = 30, Y2= 70, Y3= 40 },
        new ChartData { X = "Electricity", Y = 55, Y1 = 95, Y2= 55, Y3= 75},
        new ChartData { X = "Tax", Y = 20, Y1 = 50, Y2= 40, Y3= 65 },
        new ChartData { X = "Pet Care", Y = 40, Y1 = 20, Y2= 80, Y3= 95 },
        new ChartData { X = "Education", Y = 45, Y1 = 15, Y2= 45, Y3= 195 },
        new ChartData { X = "Entertainment", Y = 75, Y1 = 45, Y2= 65, Y3= 115 }
    };

    public void PointRender(PointRenderEventArgs args)
    {
        args.Fill = args.Point.X.ToString() == "Clothes" ? "#E91E63" : "#3F51B5";
    }
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LXLpZlhMCrpBJvmA?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

N> Refer to our [Blazor Charts](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations and also explore our [Blazor Chart Example](https://blazor.syncfusion.com/demos/chart/line?theme=bootstrap5) to know various chart types and how to represent time-dependent data, showing trends at equal intervals.

## See also

* [Data Label](../data-labels)
* [Tooltip](../tool-tip)