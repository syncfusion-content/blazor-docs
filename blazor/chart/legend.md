---
layout: post
title: Legend in Blazor Charts Component | Syncfusion
description: Check out and learn how to configure and customize Legends in Syncfusion Blazor Charts component to improve series identification and chart clarity.
platform: Blazor
control: Chart
documentation: ug
---

# Legend in Blazor Charts Component

The [legend](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartLegendSettings.html) provides information about the series shown in the chart.

Learn how to add legends to Blazor Charts by watching the video below.

{% youtube "youtube:https://www.youtube.com/watch?v=mra9AP4HBPc" %}

## Enable legend

Display the legend by setting the [Visible](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartLegendSettings.html#Syncfusion_Blazor_Charts_ChartLegendSettings_Visible) property in [ChartLegendSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartLegendSettings.html) to **true**.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart Title="Olympic Medals">
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />

    <ChartSeriesCollection>
        <ChartSeries DataSource="@MedalDetails" Name="Gold" XName="Country" Width="2" Opacity="1" YName="Gold" Type="ChartSeriesType.Column"/>      
        <ChartSeries DataSource="@MedalDetails" Name="Silver" XName="Country" Width="2" Opacity="1" YName="Silver" Type="ChartSeriesType.Column"/>     
        <ChartSeries DataSource="@MedalDetails" Name="Bronze" XName="Country" Width="2" Opacity="1" YName="Bronze" Type="ChartSeriesType.Column"/>      
    </ChartSeriesCollection>

    <ChartLegendSettings Visible="true" />
</SfChart>

@code {
    public class ChartData
    {
        public string Country { get; set; }
        public double Gold { get; set; }
        public double Silver { get; set; }
        public double Bronze { get; set; }
    }

    public List<ChartData> MedalDetails = new List<ChartData>
    {
        new ChartData { Country = "USA", Gold = 50, Silver = 70, Bronze = 45 },
        new ChartData { Country = "China", Gold = 40, Silver = 60, Bronze = 55 },
        new ChartData { Country = "Japan", Gold = 70, Silver = 60, Bronze = 50 },
        new ChartData { Country = "Australia", Gold = 60, Silver = 56, Bronze = 40 },
        new ChartData { Country = "France", Gold = 50, Silver = 45, Bronze = 35 },
        new ChartData { Country = "Germany", Gold = 40, Silver = 30, Bronze = 22 },
        new ChartData { Country = "Italy", Gold = 40, Silver = 35, Bronze = 37 },
        new ChartData { Country = "Sweden", Gold = 30, Silver = 25, Bronze = 27 }
	};
}

```

![Blazor Column Chart with Legend](images/legend/blazor-column-chart-legend.png)

## Position and alignment

<!-- markdownlint-disable MD036 -->

**Legend Position**

<!-- markdownlint-disable MD036 -->
Set the legend position to [Left](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.LegendPosition.html#Syncfusion_Blazor_Charts_LegendPosition_Left), [Right](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.LegendPosition.html#Syncfusion_Blazor_Charts_LegendPosition_Right), [Top](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.LegendPosition.html#Syncfusion_Blazor_Charts_LegendPosition_Top), [Bottom](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.LegendPosition.html#Syncfusion_Blazor_Charts_LegendPosition_Bottom), or [Custom](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.LegendPosition.html#Syncfusion_Blazor_Charts_LegendPosition_Custom) using the [Position](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartLegendSettings.html#Syncfusion_Blazor_Charts_ChartLegendSettings_Position) property. By default, the legend appears at the **Bottom**.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart Title="Olympic Medals">
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />  

    <ChartSeriesCollection>
        <ChartSeries DataSource="@MedalDetails" Name="Gold" XName="Country" Width="2" Opacity="1" YName="Gold" Type="ChartSeriesType.Column"/>      
        <ChartSeries DataSource="@MedalDetails" Name="Silver" XName="Country" Width="2" Opacity="1" YName="Silver" Type="ChartSeriesType.Column"/>     
        <ChartSeries DataSource="@MedalDetails" Name="Bronze" XName="Country" Width="2" Opacity="1" YName="Bronze" Type="ChartSeriesType.Column"/>      
    </ChartSeriesCollection>

    <ChartLegendSettings Visible="true" Position="LegendPosition.Top" />
</SfChart>

@code {
    public class ChartData
    {
        public string Country { get; set; }
        public double Gold { get; set; }
        public double Silver { get; set; }
        public double Bronze { get; set; }
    }

    public List<ChartData> MedalDetails = new List<ChartData>
    {
        new ChartData { Country = "USA", Gold = 50, Silver = 70, Bronze = 45 },
        new ChartData { Country = "China", Gold = 40, Silver = 60, Bronze = 55 },
        new ChartData { Country = "Japan", Gold = 70, Silver = 60, Bronze = 50 },
        new ChartData { Country = "Australia", Gold = 60, Silver = 56, Bronze = 40 },
        new ChartData { Country = "France", Gold = 50, Silver = 45, Bronze = 35 },
        new ChartData { Country = "Germany", Gold = 40, Silver = 30, Bronze = 22 },
        new ChartData { Country = "Italy", Gold = 40, Silver = 35, Bronze = 37 },
        new ChartData { Country = "Sweden", Gold = 30, Silver = 25, Bronze = 27 }
	};
}

```

![Changing Legend Position in Blazor Column Chart](images/legend/blazor-column-chart-legend-position.png)

The [Custom](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.LegendPosition.html#Syncfusion_Blazor_Charts_LegendPosition_Custom) position helps to position the legend anywhere in the chart using x and y coordinates.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart Title="Olympic Medals">
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />

    <ChartSeriesCollection>
        <ChartSeries DataSource="@MedalDetails" Name="Gold" XName="Country" Width="2" Opacity="1" YName="Gold" Type="ChartSeriesType.Column">
        </ChartSeries>
        <ChartSeries DataSource="@MedalDetails" Name="Silver" XName="Country" Width="2" Opacity="1" YName="Silver" Type="ChartSeriesType.Column">
        </ChartSeries>
        <ChartSeries DataSource="@MedalDetails" Name="Bronze" XName="Country" Width="2" Opacity="1" YName="Bronze" Type="ChartSeriesType.Column">
        </ChartSeries>
    </ChartSeriesCollection>

    <ChartLegendSettings Visible="true" Position="LegendPosition.Custom">
        <ChartLocation X="200" Y="100" />
    </ChartLegendSettings>
</SfChart>

@code {
    public class ChartData
    {
        public string Country { get; set; }
        public double Gold { get; set; }
        public double Silver { get; set; }
        public double Bronze { get; set; }
    }

    public List<ChartData> MedalDetails = new List<ChartData>
    {
        new ChartData { Country = "USA", Gold = 50, Silver = 70, Bronze = 45 },
        new ChartData { Country = "China", Gold = 40, Silver = 60, Bronze = 55 },
        new ChartData { Country = "Japan", Gold = 70, Silver = 60, Bronze = 50 },
        new ChartData { Country = "Australia", Gold = 60, Silver = 56, Bronze = 40 },
        new ChartData { Country = "France", Gold = 50, Silver = 45, Bronze = 35 },
        new ChartData { Country = "Germany", Gold = 40, Silver = 30, Bronze = 22 },
        new ChartData { Country = "Italy", Gold = 40, Silver = 35, Bronze = 37 },
        new ChartData { Country = "Sweden", Gold = 30, Silver = 25, Bronze = 27 }
    };
}

```

![Blazor Column Chart Legend in Custom Position](images/legend/blazor-column-chart-legend-in-custom-position.png)

<!-- markdownlint-disable MD036 -->
## Legend Reverse

Reverse the order of legend items using the [Reverse](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartLegendSettings.html#Syncfusion_Blazor_Charts_ChartLegendSettings_Reverse) property. By default, the first series appears first in the legend.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart Title="Olympic Medals">
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category">
    </ChartPrimaryXAxis>

    <ChartSeriesCollection>
        <ChartSeries DataSource="@MedalDetails" Name="Gold" XName="Country" Width="2" Opacity="1" YName="Gold" Type="ChartSeriesType.Column">
        </ChartSeries>
        <ChartSeries DataSource="@MedalDetails" Name="Silver" XName="Country" Width="2" Opacity="1" YName="Silver" Type="ChartSeriesType.Column">
        </ChartSeries>
        <ChartSeries DataSource="@MedalDetails" Name="Bronze" XName="Country" Width="2" Opacity="1" YName="Bronze" Type="ChartSeriesType.Column">
        </ChartSeries>
    </ChartSeriesCollection>

    <ChartLegendSettings Visible="true" Reverse="true"></ChartLegendSettings>
</SfChart>

@code{

    public class ChartData
    {
        public string Country { get; set; }
        public double Gold { get; set; }
        public double Silver { get; set; }
        public double Bronze { get; set; }
    }

    public List<ChartData> MedalDetails = new List<ChartData>
    {
        new ChartData { Country = "USA", Gold = 50, Silver = 70, Bronze = 45 },
        new ChartData { Country = "China", Gold = 40, Silver = 60, Bronze = 55 },
        new ChartData { Country = "Japan", Gold = 70, Silver = 60, Bronze = 50 },
        new ChartData { Country = "Australia", Gold = 60, Silver = 56, Bronze = 40 },
        new ChartData { Country = "France", Gold = 50, Silver = 45, Bronze = 35 },
        new ChartData { Country = "Germany", Gold = 40, Silver = 30, Bronze = 22 },
        new ChartData { Country = "Italy", Gold = 40, Silver = 35, Bronze = 37 },
        new ChartData { Country = "Sweden", Gold = 30, Silver = 25, Bronze = 27 }
	};
}


```

![Changing Blazor Column Chart Legend Reverse](images/legend/blazor-column-chart-legend-reverse.png)

**Legend Alignment**

<!-- markdownlint-disable MD036 -->
Set legend alignment to [Centre](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.Alignment.html#Syncfusion_Blazor_Charts_Alignment_Center), [Far](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.Alignment.html#Syncfusion_Blazor_Charts_Alignment_Far), or [Near](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.Alignment.html#Syncfusion_Blazor_Charts_Alignment_Near) using the [Alignment](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartLegendSettings.html#Syncfusion_Blazor_Charts_ChartLegendSettings_Alignment) property.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart Title="Olympic Medals">
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />

    <ChartSeriesCollection>
        <ChartSeries DataSource="@MedalDetails" Name="Gold" XName="Country" Width="2" Opacity="1" YName="Gold" Type="ChartSeriesType.Column">
        </ChartSeries>
        <ChartSeries DataSource="@MedalDetails" Name="Silver" XName="Country" Width="2" Opacity="1" YName="Silver" Type="ChartSeriesType.Column">
        </ChartSeries>
        <ChartSeries DataSource="@MedalDetails" Name="Bronze" XName="Country" Width="2" Opacity="1" YName="Bronze" Type="ChartSeriesType.Column">
        </ChartSeries>
    </ChartSeriesCollection>

    <ChartLegendSettings Visible="true" Alignment="Alignment.Far" />
</SfChart>

@code {
    public class ChartData
    {
        public string Country { get; set; }
        public double Gold { get; set; }
        public double Silver { get; set; }
        public double Bronze { get; set; }
    }

    public List<ChartData> MedalDetails = new List<ChartData>
    {
        new ChartData { Country = "USA", Gold = 50, Silver = 70, Bronze = 45 },
        new ChartData { Country = "China", Gold = 40, Silver = 60, Bronze = 55 },
        new ChartData { Country = "Japan", Gold = 70, Silver = 60, Bronze = 50 },
        new ChartData { Country = "Australia", Gold = 60, Silver = 56, Bronze = 40 },
        new ChartData { Country = "France", Gold = 50, Silver = 45, Bronze = 35 },
        new ChartData { Country = "Germany", Gold = 40, Silver = 30, Bronze = 22 },
        new ChartData { Country = "Italy", Gold = 40, Silver = 35, Bronze = 37 },
        new ChartData { Country = "Sweden", Gold = 30, Silver = 25, Bronze = 27 }
	};
}


```

![Changing Blazor Column Chart Legend Alignment Position](images/legend/blazor-column-chart-legend-alignment-position.png)

## Legend Customization

### Legend Shape

Change the legend icon shape using the [LegendShape](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_LegendShape) property in the series. The default shape is [SeriesType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.LegendShape.html#Syncfusion_Blazor_Charts_LegendShape_SeriesType).

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart Title="Olympic Medals">
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />

    <ChartSeriesCollection>
        <ChartSeries DataSource="@MedalDetails" Name="Gold" XName="Country" Width="2" Opacity="1" YName="Gold" Type="ChartSeriesType.Column" LegendShape="LegendShape.Circle"/>
        <ChartSeries DataSource="@MedalDetails" Name="Silver" XName="Country" Width="2" Opacity="1" YName="Silver" Type="ChartSeriesType.Column" LegendShape="LegendShape.SeriesType"/>
        <ChartSeries DataSource="@MedalDetails" Name="Bronze" XName="Country" Width="2" Opacity="1" YName="Bronze" Type="ChartSeriesType.Column" LegendShape="LegendShape.Diamond"/>
    </ChartSeriesCollection>

    <ChartLegendSettings Visible="true" />
</SfChart>

@code {
    public class ChartData
    {
        public string Country { get; set; }
        public double Gold { get; set; }
        public double Silver { get; set; }
        public double Bronze { get; set; }
    }

    public List<ChartData> MedalDetails = new List<ChartData>
    {
        new ChartData { Country = "USA", Gold = 50, Silver = 70, Bronze = 45 },
        new ChartData { Country = "China", Gold = 40, Silver = 60, Bronze = 55 },
        new ChartData { Country = "Japan", Gold = 70, Silver = 60, Bronze = 50 },
        new ChartData { Country = "Australia", Gold = 60, Silver = 56, Bronze = 40 },
        new ChartData { Country = "France", Gold = 50, Silver = 45, Bronze = 35 },
        new ChartData { Country = "Germany", Gold = 40, Silver = 30, Bronze = 22 },
        new ChartData { Country = "Italy", Gold = 40, Silver = 35, Bronze = 37 },
        new ChartData { Country = "Sweden", Gold = 30, Silver = 25, Bronze = 27 }
    };
}

```

![Changing Legend Shape in Blazor Column Chart](images/legend/blazor-column-chart-legend-shape.png)

### Legend Size

Adjust legend size using the [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartLegendSettings.html#Syncfusion_Blazor_Charts_ChartLegendSettings_Width) and [Height](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartLegendSettings.html#Syncfusion_Blazor_Charts_ChartLegendSettings_Height) properties.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart Title="Olympic Medals">
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />    

    <ChartSeriesCollection>
        <ChartSeries DataSource="@MedalDetails" Name="Gold" XName="Country" Width="2" LegendShape="LegendShape.Circle" Opacity="1" YName="Gold" Type="ChartSeriesType.Column">
        </ChartSeries>
        <ChartSeries DataSource="@MedalDetails" Name="Silver" XName="Country" Width="2" LegendShape="LegendShape.SeriesType" Opacity="1" YName="Silver" Type="ChartSeriesType.Column">
        </ChartSeries>
        <ChartSeries DataSource="@MedalDetails" Name="Bronze" XName="Country" Width="2" LegendShape="LegendShape.Diamond" Opacity="1" YName="Bronze" Type="ChartSeriesType.Column">
        </ChartSeries>
    </ChartSeriesCollection>

    <ChartLegendSettings Visible="true" Height="50" Width="300" >
        <ChartLegendBorder Color="red" Width="1"/>
    </ChartLegendSettings>
</SfChart>

@code {
    public class ChartData
    {
        public string Country { get; set; }
        public double Gold { get; set; }
        public double Silver { get; set; }
        public double Bronze { get; set; }
    }

    public List<ChartData> MedalDetails = new List<ChartData>
    {
        new ChartData { Country = "USA", Gold = 50, Silver = 70, Bronze = 45 },
        new ChartData { Country = "China", Gold = 40, Silver = 60, Bronze = 55 },
        new ChartData { Country = "Japan", Gold = 70, Silver = 60, Bronze = 50 },
        new ChartData { Country = "Australia", Gold = 60, Silver = 56, Bronze = 40 },
        new ChartData { Country = "France", Gold = 50, Silver = 45, Bronze = 35 },
        new ChartData { Country = "Germany", Gold = 40, Silver = 30, Bronze = 22 },
        new ChartData { Country = "Italy", Gold = 40, Silver = 35, Bronze = 37 },
        new ChartData { Country = "Sweden", Gold = 30, Silver = 25, Bronze = 27 }
    };
}

```

![Blazor Column Chart Legend with Custom Size](images/legend/blazor-column-chart-legend-custom-size.png)

### Legend Shape Size

Set legend shape dimensions using [ShapeHeight](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartLegendSettings.html#Syncfusion_Blazor_Charts_ChartLegendSettings_ShapeHeight) and [ShapeWidth](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartLegendSettings.html#Syncfusion_Blazor_Charts_ChartLegendSettings_ShapeWidth).

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart Title="Olympic Medals">
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category"/>    

    <ChartSeriesCollection>
        <ChartSeries DataSource="@MedalDetails" Name="Gold" XName="Country" Width="2" LegendShape="LegendShape.Circle" Opacity="1" YName="Gold" Type="ChartSeriesType.Column">
        </ChartSeries>
        <ChartSeries DataSource="@MedalDetails" Name="Silver" XName="Country" Width="2" LegendShape="LegendShape.SeriesType" Opacity="1" YName="Silver" Type="ChartSeriesType.Column">
        </ChartSeries>
        <ChartSeries DataSource="@MedalDetails" Name="Bronze" XName="Country" Width="2" LegendShape="LegendShape.Diamond" Opacity="1" YName="Bronze" Type="ChartSeriesType.Column">
        </ChartSeries>
    </ChartSeriesCollection>

    <ChartLegendSettings Visible="true" Height="50" Width="300" ShapeHeight="20" ShapeWidth="20">
    </ChartLegendSettings>
</SfChart>

@code {
    public class ChartData
    {
        public string Country { get; set; }
        public double Gold { get; set; }
        public double Silver { get; set; }
        public double Bronze { get; set; }
    }

    public List<ChartData> MedalDetails = new List<ChartData>
    {
        new ChartData { Country = "USA", Gold = 50, Silver = 70, Bronze = 45 },
        new ChartData { Country = "China", Gold = 40, Silver = 60, Bronze = 55 },
        new ChartData { Country = "Japan", Gold = 70, Silver = 60, Bronze = 50 },
        new ChartData { Country = "Australia", Gold = 60, Silver = 56, Bronze = 40 },
        new ChartData { Country = "France", Gold = 50, Silver = 45, Bronze = 35 },
        new ChartData { Country = "Germany", Gold = 40, Silver = 30, Bronze = 22 },
        new ChartData { Country = "Italy", Gold = 40, Silver = 35, Bronze = 37 },
        new ChartData { Country = "Sweden", Gold = 30, Silver = 25, Bronze = 27 }
    };
}

```

![Blazor Column Chart Legend Shape with Custom Size](images/legend/blazor-column-chart-custom-legend-shape-size.png)

### Legend Item Padding

Adjust space between legend items using the [ItemPadding](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartLegendSettings.html#Syncfusion_Blazor_Charts_ChartLegendSettings_ItemPadding) property.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart Title="Olympic Medals">
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category"/>
    <ChartSeriesCollection>
        <ChartSeries DataSource="@MedalDetails" Name="Gold" XName="Country" Width="2" LegendShape="LegendShape.Circle" Opacity="1" YName="Gold" Type="ChartSeriesType.Column">
        </ChartSeries>
        <ChartSeries DataSource="@MedalDetails" Name="Silver" XName="Country" Width="2" LegendShape="LegendShape.SeriesType" Opacity="1" YName="Silver" Type="ChartSeriesType.Column">
        </ChartSeries>
        <ChartSeries DataSource="@MedalDetails" Name="Bronze" XName="Country" Width="2" LegendShape="LegendShape.Diamond" Opacity="1" YName="Bronze" Type="ChartSeriesType.Column">
        </ChartSeries>
    </ChartSeriesCollection>
    <ChartLegendSettings Visible="true" ItemPadding="30" >
    </ChartLegendSettings>
</SfChart>

@code{

    public class ChartData
    {
        public string Country { get; set; }
        public double Gold { get; set; }
        public double Silver { get; set; }
        public double Bronze { get; set; }
    }

    public List<ChartData> MedalDetails = new List<ChartData>
    {
        new ChartData { Country = "USA", Gold = 50, Silver = 70, Bronze = 45 },
        new ChartData { Country = "China", Gold = 40, Silver = 60, Bronze = 55 },
        new ChartData { Country = "Japan", Gold = 70, Silver = 60, Bronze = 50 },
        new ChartData { Country = "Australia", Gold = 60, Silver = 56, Bronze = 40 },
        new ChartData { Country = "France", Gold = 50, Silver = 45, Bronze = 35 },
        new ChartData { Country = "Germany", Gold = 40, Silver = 30, Bronze = 22 },
        new ChartData { Country = "Italy", Gold = 40, Silver = 35, Bronze = 37 },
        new ChartData { Country = "Sweden", Gold = 30, Silver = 25, Bronze = 27 }
    };
}

```

![Blazor Column Chart Legend Shape with Item Padding](images/legend/blazor-column-chart-legend-item-padding.png)

### Legend Paging

Paging is enabled by default when legend items exceed legend bounds. Use navigation buttons to view all legend items.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart Title="Olympic Medals">
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />

    <ChartSeriesCollection>
        <ChartSeries DataSource="@MedalDetails" Name="Gold" XName="Country" Width="2" LegendShape="LegendShape.Circle" Opacity="1" YName="Gold" Type="ChartSeriesType.Column">
        </ChartSeries>
        <ChartSeries DataSource="@MedalDetails" Name="Silver" XName="Country" Width="2" LegendShape="LegendShape.SeriesType" Opacity="1" YName="Silver" Type="ChartSeriesType.Column">
        </ChartSeries>
        <ChartSeries DataSource="@MedalDetails" Name="Bronze" XName="Country" Width="2" LegendShape="LegendShape.Diamond" Opacity="1" YName="Bronze" Type="ChartSeriesType.Column">
        </ChartSeries>
    </ChartSeriesCollection>

    <ChartLegendSettings Visible="true" Width="100" Height="70" Padding="10" ShapePadding="10" >
        <ChartLegendBorder Color="red" Width="1"/>
    </ChartLegendSettings>
</SfChart>

@code {
    public class ChartData
    {
        public string Country { get; set; }
        public double Gold { get; set; }
        public double Silver { get; set; }
        public double Bronze { get; set; }
    }

    public List<ChartData> MedalDetails = new List<ChartData>
    {
        new ChartData { Country = "USA", Gold = 50, Silver = 70, Bronze = 45 },
        new ChartData { Country = "China", Gold = 40, Silver = 60, Bronze = 55 },
        new ChartData { Country = "Japan", Gold = 70, Silver = 60, Bronze = 50 },
        new ChartData { Country = "Australia", Gold = 60, Silver = 56, Bronze = 40 },
        new ChartData { Country = "France", Gold = 50, Silver = 45, Bronze = 35 },
        new ChartData { Country = "Germany", Gold = 40, Silver = 30, Bronze = 22 },
        new ChartData { Country = "Italy", Gold = 40, Silver = 35, Bronze = 37 },
        new ChartData { Country = "Sweden", Gold = 30, Silver = 25, Bronze = 27 }
   };
}

```

![Blazor Column Chart Legend with Paging](images/legend/blazor-column-chart-legend-paging.png)

### Legend Text Wrap

Wrap legend text using [TextWrap](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartLegendSettings.html#Syncfusion_Blazor_Charts_ChartLegendSettings_TextWrap) and [MaximumLabelWidth](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartLegendSettings.html#Syncfusion_Blazor_Charts_ChartLegendSettings_MaximumLabelWidth) properties.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart Title="Olympic Medals">
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />

    <ChartSeriesCollection>
        <ChartSeries DataSource="@MedalDetails" Name="Gold Medals" XName="Country" Width="2" LegendShape="LegendShape.Circle" Opacity="1" YName="Gold" Type="ChartSeriesType.Column">
        </ChartSeries>
        <ChartSeries DataSource="@MedalDetails" Name="Silver Medals" XName="Country" Width="2" LegendShape="LegendShape.SeriesType" Opacity="1" YName="Silver" Type="ChartSeriesType.Column">
        </ChartSeries>
        <ChartSeries DataSource="@MedalDetails" Name="Bronze Medals" XName="Country" Width="2" LegendShape="LegendShape.Diamond" Opacity="1" YName="Bronze" Type="ChartSeriesType.Column">
        </ChartSeries>
    </ChartSeriesCollection>
    <ChartLegendSettings Visible="true" Position="@LegendPosition.Right" TextWrap="@TextWrap.Wrap" MaximumLabelWidth="50">
        <ChartLegendBorder Color="red" Width="1"/>
    </ChartLegendSettings>
</SfChart>

@code {
    public class ChartData
    {
        public string Country { get; set; }
        public double Gold { get; set; }
        public double Silver { get; set; }
        public double Bronze { get; set; }
    }

    public List<ChartData> MedalDetails = new List<ChartData>
    {
        new ChartData { Country = "USA", Gold = 50, Silver = 70, Bronze = 45 },
        new ChartData { Country = "China", Gold = 40, Silver = 60, Bronze = 55 },
        new ChartData { Country = "Japan", Gold = 70, Silver = 60, Bronze = 50 },
        new ChartData { Country = "Australia", Gold = 60, Silver = 56, Bronze = 40 },
        new ChartData { Country = "France", Gold = 50, Silver = 45, Bronze = 35 },
        new ChartData { Country = "Germany", Gold = 40, Silver = 30, Bronze = 22 },
        new ChartData { Country = "Italy", Gold = 40, Silver = 35, Bronze = 37 },
        new ChartData { Country = "Sweden", Gold = 30, Silver = 25, Bronze = 27 }
   };
}

```

![Blazor Chart Legend with Wrap](images/legend/blazor-chart-legend-wrap.png)

## Series selection based on legend

By default, clicking a legend item collapses the corresponding series. Disable this with the [ToggleVisibility](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartLegendSettings.html#Syncfusion_Blazor_Charts_ChartLegendSettings_ToggleVisibility) property.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart Title="Olympic Medals" SelectionMode="SelectionMode.Series">
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />

    <ChartSeriesCollection>
        <ChartSeries DataSource="@MedalDetails" Name="Gold" XName="Country" Width="2" LegendShape="LegendShape.Circle" Opacity="1" YName="Gold" Type="ChartSeriesType.Column">
        </ChartSeries>
        <ChartSeries DataSource="@MedalDetails" Name="Silver" XName="Country" Width="2" LegendShape="LegendShape.SeriesType" Opacity="1" YName="Silver" Type="ChartSeriesType.Column">
        </ChartSeries>
        <ChartSeries DataSource="@MedalDetails" Name="Bronze" XName="Country" Width="2" LegendShape="LegendShape.Diamond" Opacity="1" YName="Bronze" Type="ChartSeriesType.Column">
        </ChartSeries>
    </ChartSeriesCollection>

    <ChartLegendSettings Visible="true" ToggleVisibility="false" />
</SfChart>

@code {
    public class ChartData
    {
        public string Country { get; set; }
        public double Gold { get; set; }
        public double Silver { get; set; }
        public double Bronze { get; set; }
    }

    public List<ChartData> MedalDetails = new List<ChartData>
    {
        new ChartData { Country = "USA", Gold = 50, Silver = 70, Bronze = 45 },
        new ChartData { Country = "China", Gold = 40, Silver = 60, Bronze = 55 },
        new ChartData { Country = "Japan", Gold = 70, Silver = 60, Bronze = 50 },
        new ChartData { Country = "Australia", Gold = 60, Silver = 56, Bronze = 40 },
        new ChartData { Country = "France", Gold = 50, Silver = 45, Bronze = 35 },
        new ChartData { Country = "Germany", Gold = 40, Silver = 30, Bronze = 22 },
        new ChartData { Country = "Italy", Gold = 40, Silver = 35, Bronze = 37 },
        new ChartData { Country = "Sweden", Gold = 30, Silver = 25, Bronze = 27 }
	};
}

```

![Blazor Column Chart Legend with Series Selection](images/legend/blazor-column-chart-legend-series-selection.png)

## Hiding legend item

The series [Name](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Name) is displayed as the legend text by default. Skip the legend for a series by providing an empty string to the series [Name](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Name) property.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart Title="Olympic Medals">
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />

    <ChartSeriesCollection>
        <ChartSeries DataSource="@MedalDetails" Name="Gold" XName="Country" Width="2" LegendShape="LegendShape.Circle" Opacity="1" YName="Gold" Type="ChartSeriesType.Column">
        </ChartSeries>
        <ChartSeries DataSource="@MedalDetails" Name="" XName="Country" Width="2" LegendShape="LegendShape.SeriesType" Opacity="1" YName="Silver" Type="ChartSeriesType.Column">
        </ChartSeries>
        <ChartSeries DataSource="@MedalDetails" Name="Bronze" XName="Country" Width="2" LegendShape="LegendShape.Diamond" Opacity="1" YName="Bronze" Type="ChartSeriesType.Column">
        </ChartSeries>
    </ChartSeriesCollection>

    <ChartLegendSettings Visible="true" ToggleVisibility="true" />
</SfChart>

@code {
    public class ChartData
    {
        public string Country { get; set; }
        public double Gold { get; set; }
        public double Silver { get; set; }
        public double Bronze { get; set; }
    }

    public List<ChartData> MedalDetails = new List<ChartData>
    {
        new ChartData { Country = "USA", Gold = 50, Silver = 70, Bronze = 45 },
        new ChartData { Country = "China", Gold = 40, Silver = 60, Bronze = 55 },
        new ChartData { Country = "Japan", Gold = 70, Silver = 60, Bronze = 50 },
        new ChartData { Country = "Australia", Gold = 60, Silver = 56, Bronze = 40 },
        new ChartData { Country = "France", Gold = 50, Silver = 45, Bronze = 35 },
        new ChartData { Country = "Germany", Gold = 40, Silver = 30, Bronze = 22 },
        new ChartData { Country = "Italy", Gold = 40, Silver = 35, Bronze = 37 },
        new ChartData { Country = "Sweden", Gold = 30, Silver = 25, Bronze = 27 }
	};
}

```

![Hiding Legend Item in Blazor Column Chart](images/legend/blazor-column-chart-hide-legend-item.png)

N> Refer to our [Blazor Charts](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations and also explore our [Blazor Chart Example](https://blazor.syncfusion.com/demos/chart/line?theme=bootstrap5) to know various chart types and how to represent time-dependent data, showing trends at equal intervals.

## See also

* [Data label](./data-labels)
* [Marker](./data-markers)
* [Toggle Series Visibility Using Legend](https://support.syncfusion.com/kb/article/20966/how-to-toggle-series-visibility-using-legend-in-live-blazor-chart)