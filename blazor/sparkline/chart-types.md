---
layout: post
title: Chart Types in Blazor Sparkline Component | Syncfusion
description: Checkout and learn here all about chart types in Syncfusion Blazor Sparkline component and much more.
platform: Blazor
control: Sparkline Charts
documentation: ug
---

# Chart Types in Blazor Sparkline Component

The different type of shapes can be used to represent the Sparkline Chart, and the type of Sparkline Chart can be changed by specifying the [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfSparkline-1.html#Syncfusion_Blazor_Charts_SfSparkline_1_Type) property.

## Line

The [Line](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SparklineType.html#Syncfusion_Blazor_Charts_SparklineType_Line) chart type is used to render the Sparkline series as line.

```cshtml
@using Syncfusion.Blazor.Charts

<SfSparkline DataSource="PopulationData" TValue="PopulationReport" XName="Year" YName="Population" Width="200px" Height="150px" Type="SparklineType.Line">
</SfSparkline>

@code {
    public class PopulationReport
    {
        public int Year { get; set; }
        public int Population { get; set; }
    };
    private List<PopulationReport> PopulationData = new List<PopulationReport> {
        new  PopulationReport { Year= 2005, Population= 20090440 },
        new  PopulationReport { Year= 2006, Population= 20264080 },
        new  PopulationReport { Year= 2007, Population= 20434180 },
        new  PopulationReport { Year= 2008, Population= 21007310 },
        new  PopulationReport { Year= 2009, Population= 21262640 },
        new  PopulationReport { Year= 2010, Population= 21515750 },
        new  PopulationReport { Year= 2011, Population= 21766710 },
        new  PopulationReport { Year= 2012, Population= 22015580 },
        new  PopulationReport { Year= 2013, Population= 22262500 },
        new  PopulationReport { Year= 2014, Population= 22507620 }
    };
}
```

![Blazor Sparkline Line Chart](images/SparklineTypes/blazor-line-sparkline.png)

## Column

The [Column](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SparklineType.html#Syncfusion_Blazor_Charts_SparklineType_Column) chart type is used to render the Sparkline series as column.

```cshtml
@using Syncfusion.Blazor.Charts

<SfSparkline DataSource="PopulationData" TValue="PopulationReport" XName="Year" YName="Population" Width="500px" Height="150px" Type="SparklineType.Column">
</SfSparkline>
```

N> Refer to the [code block](#line) to know about the property value of the **PopulationData**.

![Blazor Sparkline Column Chart](images/SparklineTypes/blazor-column-sparkline.png)

## Pie

The [Pie](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SparklineType.html#Syncfusion_Blazor_Charts_SparklineType_Pie) chart type is used to render the Sparkline series as pie.

```cshtml
@using Syncfusion.Blazor.Charts

<SfSparkline DataSource="PopulationData" TValue="PopulationReport" XName="Year" YName="Population" Width="500px" Height="250px" Type="SparklineType.Pie">
</SfSparkline>
```

N> Refer to the [code block](#line) to know about the property value of the **PopulationData**.

![Blazor Sparkline Pie Chart](images/SparklineTypes/blazor-pie-sparkline.png)

## WinLoss

The [WinLoss](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SparklineType.html#Syncfusion_Blazor_Charts_SparklineType_WinLoss) chart type is used to render the Sparkline series as WinLoss.

```cshtml
@using Syncfusion.Blazor.Charts

<SfSparkline DataSource="new int[]{12, 15, -10, 13, 15, 6, -12, 17, 13, 0, 8, -10}" Width="500px" Height="200px" Type="SparklineType.WinLoss">
</SfSparkline>
```

![Blazor Sparkline WinLoss Chart](images/SparklineTypes/blazor-winloss-sparkline.png)

## Area

The [Area](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SparklineType.html#Syncfusion_Blazor_Charts_SparklineType_Area) chart type is used to render the Sparkline series as area.

```cshtml
@using Syncfusion.Blazor.Charts

<SfSparkline DataSource="PopulationData" TValue="PopulationReport" XName="Year" YName="Population" Width="500px" Height="100px" Type="SparklineType.Area">
</SfSparkline>
```

N> Refer to the [code block](#line) to know about the property value of the **PopulationData**.

![Blazor Sparkline Area Chart](images/SparklineTypes/blazor-area-sparkline.png)