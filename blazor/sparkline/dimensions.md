---
layout: post
title: Dimensions in Blazor Sparkline Component | Syncfusion
description: Check out and learn how to set and customize dimensions in the Syncfusion Blazor Sparkline component.
platform: Blazor
control: Sparkline Charts
documentation: ug
---

# Dimensions in Blazor Sparkline Component

## Size for the Container

The size of the [Blazor Sparkline Chart](https://www.syncfusion.com/blazor-components/blazor-sparkline) is determined by its container. You can set the size inline or via CSS.

```cshtml

@using Syncfusion.Blazor.Charts

<div style="width:650px; height:350px;">
    <SfSparkline XName="Year" YName="Population" TValue="PopulationReport" DataSource="PopulationData"></SfSparkline>
</div>

@code {
    public class PopulationReport
    {
        public int Year;
        public int Population;
    };
    
    private List<PopulationReport> populationData = new List<PopulationReport> {
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

![Blazor Sparkline Chart with Container Size](./images/SparklineDimension/blazor-sparkline-chart-container-size.png)

## Size for Sparkline

Set the [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfSparkline-1.html#Syncfusion_Blazor_Charts_SfSparkline_1_Width) and [Height](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfSparkline-1.html#Syncfusion_Blazor_Charts_SfSparkline_1_Height) properties to define the Sparkline Chart's size.

### In Pixels

Specify the Sparkline Chart size in pixels.

```cshtml

@using Syncfusion.Blazor.Charts

<SfSparkline XName="Year"
              YName="Population"
              TValue="PopulationReport"
              DataSource="PopulationData"
              Width="350px"
              Height="150px">
</SfSparkline>

```

N> Refer to the [code block](#size-for-the-container) for the `populationData` property value.

![Changing Blazor Sparkline Chart Size in Pixel](./images/SparklineDimension/blazor-sparkline-chart-size-in-pixel.png)

### In Percentage

Set values in percentage to size the Sparkline Chart relative to its container. For example, setting height to "50%" renders the chart at half the container's height.

```cshtml

@using Syncfusion.Blazor.Charts

<div style="width:650px; height:350px;">
    <SfSparkline XName="Year"
                  YName="Population"
                  TValue="PopulationReport"
                  DataSource="PopulationData"
                  Width="50%"
                  Height="80%">
    </SfSparkline>
</div>

```

N> Refer to the [code block](#size-for-the-container) for the `populationData` property value.

![Changing Blazor Sparkline Chart Size in Percentage](./images/SparklineDimension/blazor-sparkline-chart-size-in-percentage.png)
