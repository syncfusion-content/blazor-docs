---
layout: post
title: Dimensions in Blazor Sparkline Component | Syncfusion
description: Checkout and learn here all about dimensions in Syncfusion Blazor Sparkline component and much more.
platform: Blazor
control: Sparkline Charts
documentation: ug
---

# Dimensions in Blazor Sparkline Component

## Size for the container

The size of the [Blazor Sparkline Chart](https://www.syncfusion.com/blazor-components/blazor-sparkline) is determined by the container size, and it can be changed inline or via CSS as following.

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

The [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfSparkline-1.html#Syncfusion_Blazor_Charts_SfSparkline_1_Width) and the [Height](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfSparkline-1.html#Syncfusion_Blazor_Charts_SfSparkline_1_Height) properties can be used to set the size of the Sparkline Chart.

### In Pixel

The Sparkline Chart can be sized in pixels.

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

N> Refer to the [code block](#size-for-the-container) to know about the property value of the `populationData`.

![Changing Blazor Sparkline Chart Size in Pixel](./images/SparklineDimension/blazor-sparkline-chart-size-in-pixel.png)

### In Percentage

By setting values in percentage, the Sparkline Chart gets their dimension with respect to their containers. For example, when the height is set to "50%", the Sparkline Chart is rendered to half of its container width.

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

N> Refer to the [code block](#size-for-the-container) to know about the property value of the `populationData`.

![Changing Blazor Sparkline Chart Size in Percentage](./images/SparklineDimension/blazor-sparkline-chart-size-in-percentage.png)