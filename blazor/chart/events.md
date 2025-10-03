---
layout: post
title: Events in Blazor Charts Component | Syncfusion
description: Learn to configure and utilize Events in Syncfusion Blazor Charts component to handle user interactions and chart lifecycle changes.
platform: Blazor
control: Chart
documentation: ug
---

# Events in Blazor Charts Component

Chart component events are triggered by corresponding chart actions.

The events should be provided to the chart using [ChartEvents](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html) component.

## ChartMouseMove

[ChartMouseMove](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_ChartMouseMove) event triggers when mouse moved over the chart.

### Arguments

The following properties are available in the [ChartMouseEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartMouseEventArgs.html).
* MouseX - Specifies the current mouse x coordinate.
* MouseY - Specifies the current mouse y coordinate.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartEvents ChartMouseMove="OnMouseEvent" />
	
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />
	
    <ChartSeriesCollection>
        <ChartSeries DataSource="@Sales" XName="Month" YName="SalesValue" Type="ChartSeriesType.Column">
        </ChartSeries>
    </ChartSeriesCollection>
	
    <ChartZoomSettings EnableSelectionZooming="true"></ChartZoomSettings>
</SfChart>

@code {
    public class SalesInfo
    {
        public string Month { get; set; }
        public double SalesValue { get; set; }
    }
	
    public List<SalesInfo> Sales = new List<SalesInfo>
    {
        new SalesInfo { Month = "Jan", SalesValue = 35 },
        new SalesInfo { Month = "Feb", SalesValue = 28 },
        new SalesInfo { Month = "Mar", SalesValue = 34 },
        new SalesInfo { Month = "Apr", SalesValue = 32 },
        new SalesInfo { Month = "May", SalesValue = 40 },
        new SalesInfo { Month = "Jun", SalesValue = 32 },
        new SalesInfo { Month = "Jul", SalesValue = 35 }
    };

    public void OnMouseEvent(ChartMouseEventArgs args)
    {
        // Here, you can customize your code.
    }
}

```
## ChartMouseClick

[ChartMouseClick](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_ChartMouseClick) event triggers when the chart got clicked. 

### Arguments

The following properties are available in the [ChartMouseEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartMouseEventArgs.html).
* MouseX - Specifies the current mouse x coordinate.
* MouseY - Specifies the current mouse y coordinate.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartEvents ChartMouseClick="OnMouseEvent" />
	
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />
	
    <ChartSeriesCollection>
        <ChartSeries DataSource="@Sales" XName="Month" YName="SalesValue" Type="ChartSeriesType.Column">
        </ChartSeries>
    </ChartSeriesCollection>
	
    <ChartZoomSettings EnableSelectionZooming="true"></ChartZoomSettings>
</SfChart>

@code {
    public class SalesInfo
    {
        public string Month { get; set; }
        public double SalesValue { get; set; }
    }
	
    public List<SalesInfo> Sales = new List<SalesInfo>
    {
        new SalesInfo { Month = "Jan", SalesValue = 35 },
        new SalesInfo { Month = "Feb", SalesValue = 28 },
        new SalesInfo { Month = "Mar", SalesValue = 34 },
        new SalesInfo { Month = "Apr", SalesValue = 32 },
        new SalesInfo { Month = "May", SalesValue = 40 },
        new SalesInfo { Month = "Jun", SalesValue = 32 },
        new SalesInfo { Month = "Jul", SalesValue = 35 }
    };

    public void OnMouseEvent(ChartMouseEventArgs args)
    {
        // Here, you can customize your code.
    }
    
}

```

## ChartMouseUp

[ChartMouseUp](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_ChartMouseUp) event triggers when the mouse left button is released over the chart element.  

### Arguments

The following properties are available in the [ChartMouseEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartMouseEventArgs.html).
* MouseX - Specifies the current mouse x coordinate.
* MouseY - Specifies the current mouse y coordinate.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartEvents ChartMouseUp="OnMouseEvent" />
	
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />
	
    <ChartSeriesCollection>
        <ChartSeries DataSource="@Sales" XName="Month" YName="SalesValue" Type="ChartSeriesType.Column">
        </ChartSeries>
    </ChartSeriesCollection>
	
    <ChartZoomSettings EnableSelectionZooming="true"></ChartZoomSettings>
</SfChart>

@code {
    public class SalesInfo
    {
        public string Month { get; set; }
        public double SalesValue { get; set; }
    }
	
    public List<SalesInfo> Sales = new List<SalesInfo>
    {
        new SalesInfo { Month = "Jan", SalesValue = 35 },
        new SalesInfo { Month = "Feb", SalesValue = 28 },
        new SalesInfo { Month = "Mar", SalesValue = 34 },
        new SalesInfo { Month = "Apr", SalesValue = 32 },
        new SalesInfo { Month = "May", SalesValue = 40 },
        new SalesInfo { Month = "Jun", SalesValue = 32 },
        new SalesInfo { Month = "Jul", SalesValue = 35 }
    };

    public void OnMouseEvent(ChartMouseEventArgs args)
    {
        // Here, you can customize your code.
    }
}

```
## ChartMouseDown

[ChartMouseDown](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_ChartMouseDown) event triggers when the mouse left button is pressed over the chart element.  

### Arguments

The following properties are available in the [ChartMouseEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartMouseEventArgs.html).
* MouseX - Specifies the current mouse x coordinate.
* MouseY - Specifies the current mouse y coordinate.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartEvents ChartMouseDown="OnMouseEvent" />
	
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />
	
    <ChartSeriesCollection>
        <ChartSeries DataSource="@Sales" XName="Month" YName="SalesValue" Type="ChartSeriesType.Column">
        </ChartSeries>
    </ChartSeriesCollection>
	
    <ChartZoomSettings EnableSelectionZooming="true"></ChartZoomSettings>
</SfChart>

@code {
    public class SalesInfo
    {
        public string Month { get; set; }
        public double SalesValue { get; set; }
    }
	
    public List<SalesInfo> Sales = new List<SalesInfo>
    {
        new SalesInfo { Month = "Jan", SalesValue = 35 },
        new SalesInfo { Month = "Feb", SalesValue = 28 },
        new SalesInfo { Month = "Mar", SalesValue = 34 },
        new SalesInfo { Month = "Apr", SalesValue = 32 },
        new SalesInfo { Month = "May", SalesValue = 40 },
        new SalesInfo { Month = "Jun", SalesValue = 32 },
        new SalesInfo { Month = "Jul", SalesValue = 35 }
    };

    public void OnMouseEvent(ChartMouseEventArgs args)
    {
        // Here, you can customize your code.
    }
}

```

## OnZoomStart

After the zoom selection is made, the [OnZoomStart](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_OnZoomStart) event is triggered.

### Arguments

The following property is available in the [ZoomingEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ZoomingEventArgs.html).

* [AxisCollection](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ZoomingEventArgs.html#Syncfusion_Blazor_Charts_ZoomingEventArgs_AxisCollection) – Specifies the collection of the axis.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartEvents OnZoomStart="OnZoomingEvent" />
	
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />
	
    <ChartSeriesCollection>
        <ChartSeries DataSource="@Sales" XName="Month" YName="SalesValue" Type="ChartSeriesType.Column">
        </ChartSeries>
    </ChartSeriesCollection>
	
    <ChartZoomSettings EnableSelectionZooming="true"></ChartZoomSettings>
</SfChart>

@code {
    public class SalesInfo
    {
        public string Month { get; set; }
        public double SalesValue { get; set; }
    }
	
    public List<SalesInfo> Sales = new List<SalesInfo>
    {
        new SalesInfo { Month = "Jan", SalesValue = 35 },
        new SalesInfo { Month = "Feb", SalesValue = 28 },
        new SalesInfo { Month = "Mar", SalesValue = 34 },
        new SalesInfo { Month = "Apr", SalesValue = 32 },
        new SalesInfo { Month = "May", SalesValue = 40 },
        new SalesInfo { Month = "Jun", SalesValue = 32 },
        new SalesInfo { Month = "Jul", SalesValue = 35 }
    };

    public void OnZoomingEvent(ZoomingEventArgs args)
    {
        // Here, you can customize your code.
    }
}

```

## OnZoomEnd

[OnZoomEnd](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_OnZoomEnd) event triggers after the zoom selection is completed.

### Arguments

The following property is available in the [ZoomingEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ZoomingEventArgs.html).

* [AxisCollection](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ZoomingEventArgs.html#Syncfusion_Blazor_Charts_ZoomingEventArgs_AxisCollection) – Specifies the collection of the axis.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartEvents OnZoomEnd="OnZoomingEvent" />
	
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />
	
    <ChartSeriesCollection>
        <ChartSeries DataSource="@Sales" XName="Month" YName="SalesValue" Type="ChartSeriesType.Column">
        </ChartSeries>
    </ChartSeriesCollection>
	
    <ChartZoomSettings EnableSelectionZooming="true"></ChartZoomSettings>
</SfChart>

@code {
    public class SalesInfo
    {
        public string Month { get; set; }
        public double SalesValue { get; set; }
    }
	
    public List<SalesInfo> Sales = new List<SalesInfo>
    {
        new SalesInfo { Month = "Jan", SalesValue = 35 },
        new SalesInfo { Month = "Feb", SalesValue = 28 },
        new SalesInfo { Month = "Mar", SalesValue = 34 },
        new SalesInfo { Month = "Apr", SalesValue = 32 },
        new SalesInfo { Month = "May", SalesValue = 40 },
        new SalesInfo { Month = "Jun", SalesValue = 32 },
        new SalesInfo { Month = "Jul", SalesValue = 35 }
    };

    public void OnZoomingEvent(ZoomingEventArgs args)
    {
        // Here, you can customize your code.
    }
}

```

## OnZooming

[OnZooming](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_OnZooming) event triggers after the zoom selection is completed.

### Arguments

The following property is available in the [ZoomingEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ZoomingEventArgs.html).

* [AxisCollection](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ZoomingEventArgs.html#Syncfusion_Blazor_Charts_ZoomingEventArgs_AxisCollection) – Specifies the collection of the axis.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartEvents OnZooming="OnZoomingEvent" />
	
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />
	
    <ChartSeriesCollection>
        <ChartSeries DataSource="@Sales" XName="Month" YName="SalesValue" Type="ChartSeriesType.Column">
        </ChartSeries>
    </ChartSeriesCollection>
	
    <ChartZoomSettings EnableSelectionZooming="true"></ChartZoomSettings>
</SfChart>

@code {
    public class SalesInfo
    {
        public string Month { get; set; }
        public double SalesValue { get; set; }
    }
	
    public List<SalesInfo> Sales = new List<SalesInfo>
    {
        new SalesInfo { Month = "Jan", SalesValue = 35 },
        new SalesInfo { Month = "Feb", SalesValue = 28 },
        new SalesInfo { Month = "Mar", SalesValue = 34 },
        new SalesInfo { Month = "Apr", SalesValue = 32 },
        new SalesInfo { Month = "May", SalesValue = 40 },
        new SalesInfo { Month = "Jun", SalesValue = 32 },
        new SalesInfo { Month = "Jul", SalesValue = 35 }
    };

    public void OnZoomingEvent(ZoomingEventArgs args)
    {
        // Here, you can customize your code.
    }
}

```

## OnLegendItemRender

[OnLegendItemRender](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_OnLegendItemRender) event triggers before the legend is rendered.

### Arguments

The following properties are available in the [LegendRenderEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.LegendRenderEventArgs.html).

* [Fill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.LegendRenderEventArgs.html#Syncfusion_Blazor_Charts_LegendRenderEventArgs_Fill) – Specifies the fill color of the legend item's icon.
* [MarkerShape](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.LegendRenderEventArgs.html#Syncfusion_Blazor_Charts_LegendRenderEventArgs_MarkerShape) – Specifies the shape of the marker.
* [Shape](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.LegendRenderEventArgs.html#Syncfusion_Blazor_Charts_LegendRenderEventArgs_Shape) – Specifies the shape of the legend item's icon.
* [Text](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.LegendRenderEventArgs.html#Syncfusion_Blazor_Charts_LegendRenderEventArgs_Text) – Specifies the text to be displayed in the legend item.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartEvents OnLegendItemRender="LegendEvent" />
	
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />
	
    <ChartSeriesCollection>
        <ChartSeries DataSource="@Sales" Name="Column" XName="Month" YName="SalesValue" Type="ChartSeriesType.Column">
        </ChartSeries>
        <ChartSeries DataSource="@Sales" Name="Line" XName="Month" YName="SalesValue" Type="ChartSeriesType.Line">
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class SalesInfo
    {
        public string Month { get; set; }
        public double SalesValue { get; set; }
    }
	
    public List<SalesInfo> Sales = new List<SalesInfo>
    {
        new SalesInfo { Month = "Jan", SalesValue = 35 },
        new SalesInfo { Month = "Feb", SalesValue = 28 },
        new SalesInfo { Month = "Mar", SalesValue = 34 },
        new SalesInfo { Month = "Apr", SalesValue = 32 },
        new SalesInfo { Month = "May", SalesValue = 40 },
        new SalesInfo { Month = "Jun", SalesValue = 32 },
        new SalesInfo { Month = "Jul", SalesValue = 35 }
    };

    public void LegendEvent(LegendRenderEventArgs args)
    {
        // Here, you can customize your code.
    }
}

```

## OnDataLabelRender

[OnDataLabelRender](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_OnDataLabelRender) event triggers before the data label for series is rendered.

### Arguments

The following properties are available in the [TextRenderEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_OnDataLabelRender).

* [Border](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.TextRenderEventArgs.html#Syncfusion_Blazor_Charts_TextRenderEventArgs_Border) – Specifies the color and the width of the data label border.
* [Color](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.TextRenderEventArgs.html#Syncfusion_Blazor_Charts_TextRenderEventArgs_Color) – Specifies the text color of the data label.
* [Font](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.TextRenderEventArgs.html#Syncfusion_Blazor_Charts_TextRenderEventArgs_Font) – Specifies the font information of the data label.
* [Template](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.TextRenderEventArgs.html#Syncfusion_Blazor_Charts_TextRenderEventArgs_Template) – Provides information about the data point to be used in the data label template.
* [Text](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.TextRenderEventArgs.html#Syncfusion_Blazor_Charts_TextRenderEventArgs_Text) – Specifies the text to be displayed in the data label.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartEvents OnDataLabelRender="DataLabelEvent" />
	
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />
	
    <ChartSeriesCollection>
        <ChartSeries DataSource="@Sales" XName="Month" YName="SalesValue" Type="ChartSeriesType.Column">
            <ChartMarker>
                <ChartDataLabel Visible="true"></ChartDataLabel>
            </ChartMarker>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class SalesInfo
    {
        public string Month { get; set; }
        public double SalesValue { get; set; }
    }
	
    public List<SalesInfo> Sales = new List<SalesInfo>
    {
        new SalesInfo { Month = "Jan", SalesValue = 35 },
        new SalesInfo { Month = "Feb", SalesValue = 28 },
        new SalesInfo { Month = "Mar", SalesValue = 34 },
        new SalesInfo { Month = "Apr", SalesValue = 32 },
        new SalesInfo { Month = "May", SalesValue = 40 },
        new SalesInfo { Month = "Jun", SalesValue = 32 },
        new SalesInfo { Month = "Jul", SalesValue = 35 }
    };

    public void DataLabelEvent(TextRenderEventArgs args)
    {
        // Here, you can customize your code.
    }
}

```

## OnPointRender

[OnPointRender](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_OnPointRender) event triggers before each point for the series is rendered.

### Arguments

The following properties are available in the [PointRenderEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.PointRenderEventArgs.html).

* [Border](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.PointRenderEventArgs.html#Syncfusion_Blazor_Charts_PointRenderEventArgs_Border) – Specifies the color and the width of the point border.
* [CornerRadius](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.PointRenderEventArgs.html#Syncfusion_Blazor_Charts_PointRenderEventArgs_CornerRadius) – Specifies the corner radius of data points for rectangular series types.
* [Fill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.PointRenderEventArgs.html#Syncfusion_Blazor_Charts_PointRenderEventArgs_Fill) – Specifies the fill color of the point.
* [Height](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.PointRenderEventArgs.html#Syncfusion_Blazor_Charts_PointRenderEventArgs_Height) – Specifies the current point's height.
* [Shape](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.PointRenderEventArgs.html#Syncfusion_Blazor_Charts_PointRenderEventArgs_Shape) – Specifies the marker shape of the point.
* [Point](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.PointRenderEventArgs.html#Syncfusion_Blazor_Charts_PointRenderEventArgs_Point) – Specifies the current data point.
* [Series](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.PointRenderEventArgs.html#Syncfusion_Blazor_Charts_PointRenderEventArgs_Series) – Specifies the current series of the point.
* [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.PointRenderEventArgs.html#Syncfusion_Blazor_Charts_PointRenderEventArgs_Width) – Specifies the current point's width.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartEvents OnPointRender="PointRenderEvent" />
	
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />
	
    <ChartSeriesCollection>
        <ChartSeries DataSource="@Sales" XName="Month" YName="SalesValue" Type="ChartSeriesType.Column">
            <ChartMarker Visible="true">
            </ChartMarker>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class SalesInfo
    {
        public string Month { get; set; }
        public double SalesValue { get; set; }
    }
	
    public List<SalesInfo> Sales = new List<SalesInfo>
    {
        new SalesInfo { Month = "Jan", SalesValue = 35 },
        new SalesInfo { Month = "Feb", SalesValue = 28 },
        new SalesInfo { Month = "Mar", SalesValue = 34 },
        new SalesInfo { Month = "Apr", SalesValue = 32 },
        new SalesInfo { Month = "May", SalesValue = 40 },
        new SalesInfo { Month = "Jun", SalesValue = 32 },
        new SalesInfo { Month = "Jul", SalesValue = 35 }
    };

    public void PointRenderEvent(PointRenderEventArgs args)
    {
        // Here, you can customize your code.
    }
}

```

## OnAxisLabelRender

[OnAxisLabelRender](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_OnAxisLabelRender) event triggers before each axis label is rendered.

### Arguments

The following properties are available in the [AxisLabelRenderEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AxisLabelRenderEventArgs.html).

* [LabelStyle](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AxisLabelRenderEventArgs.html#Syncfusion_Blazor_Charts_AxisLabelRenderEventArgs_LabelStyle) – Specifies the font information of the axis label.
* [Text](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AxisLabelRenderEventArgs.html#Syncfusion_Blazor_Charts_AxisLabelRenderEventArgs_Text) – Specifies the text to be displayed in the axis label.
* [Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AxisLabelRenderEventArgs.html#Syncfusion_Blazor_Charts_AxisLabelRenderEventArgs_Value) – Specifies the value of the axis label.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartEvents OnAxisLabelRender="AxisLabelEvent" />
	
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />
	
    <ChartSeriesCollection>
        <ChartSeries DataSource="@Sales" XName="Month" YName="SalesValue" Type="ChartSeriesType.Column">
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class SalesInfo
    {
        public string Month { get; set; }
        public double SalesValue { get; set; }
    }
	
    public List<SalesInfo> Sales = new List<SalesInfo>
    {
        new SalesInfo { Month = "Jan", SalesValue = 35 },
        new SalesInfo { Month = "Feb", SalesValue = 28 },
        new SalesInfo { Month = "Mar", SalesValue = 34 },
        new SalesInfo { Month = "Apr", SalesValue = 32 },
        new SalesInfo { Month = "May", SalesValue = 40 },
        new SalesInfo { Month = "Jun", SalesValue = 32 },
        new SalesInfo { Month = "Jul", SalesValue = 35 }
    };

    public void AxisLabelEvent(AxisLabelRenderEventArgs args)
    {
        // Here, you can customize your code.
    }
}

```

## OnAxisLabelClick

[OnAxisLabelClick](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_OnAxisLabelClick) event triggers when x axis label is clicked.

### Arguments

The following fields are available in the [AxisLabelClickEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AxisLabelClickEventArgs.html).

* [Axis](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AxisLabelClickEventArgs.html#Syncfusion_Blazor_Charts_AxisLabelClickEventArgs_Axis) – Specifies the current axis.
* [Chart](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AxisLabelClickEventArgs.html#Syncfusion_Blazor_Charts_AxisLabelClickEventArgs_Chart) – Specifies the chart instance.
* [Index](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AxisLabelClickEventArgs.html#Syncfusion_Blazor_Charts_AxisLabelClickEventArgs_Index) – Specifies the index of the axis label.
* [LabelID](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AxisLabelClickEventArgs.html#Syncfusion_Blazor_Charts_AxisLabelClickEventArgs_LabelID) – Specifies the current axis label's element id.
* [Location](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AxisLabelClickEventArgs.html#Syncfusion_Blazor_Charts_AxisLabelClickEventArgs_Location) – Specifies the location of the axis label.
* [Text](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AxisLabelClickEventArgs.html#Syncfusion_Blazor_Charts_AxisLabelClickEventArgs_Text) – Specifies the text of the axis label.
* [Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AxisLabelClickEventArgs.html#Syncfusion_Blazor_Charts_AxisLabelClickEventArgs_Value) – Specifies the value of the axis label.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartEvents OnAxisLabelClick="AxisLabelClickEvent" />
	
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />
	
    <ChartSeriesCollection>
        <ChartSeries DataSource="@Sales" XName="Month" YName="SalesValue" Type="ChartSeriesType.Column">
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class SalesInfo
    {
        public string Month { get; set; }
        public double SalesValue { get; set; }
    }
	
    public List<SalesInfo> Sales = new List<SalesInfo>
    {
        new SalesInfo { Month = "Jan", SalesValue = 35 },
        new SalesInfo { Month = "Feb", SalesValue = 28 },
        new SalesInfo { Month = "Mar", SalesValue = 34 },
        new SalesInfo { Month = "Apr", SalesValue = 32 },
        new SalesInfo { Month = "May", SalesValue = 40 },
        new SalesInfo { Month = "Jun", SalesValue = 32 },
        new SalesInfo { Month = "Jul", SalesValue = 35 }
    };

    public void AxisLabelClickEvent(AxisLabelClickEventArgs args)
    {
        // Here, you can customize your code.
    }
}

```

## OnAxisActualRangeCalculated

[OnAxisActualRangeCalculated](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_OnAxisActualRangeCalculated) event triggers before each axis range is calculated.

### Arguments

The following properties are available in the [AxisRangeCalculatedEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AxisRangeCalculatedEventArgs.html).

* [Interval](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AxisRangeCalculatedEventArgs.html#Syncfusion_Blazor_Charts_AxisRangeCalculatedEventArgs_Interval) – Specifies the current interval of the axis.
* [Maximum](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AxisRangeCalculatedEventArgs.html#Syncfusion_Blazor_Charts_AxisRangeCalculatedEventArgs_Maximum) – Specifies the current maximum value of the axis.
* [Minimum](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AxisRangeCalculatedEventArgs.html#Syncfusion_Blazor_Charts_AxisRangeCalculatedEventArgs_Minimum) – Specifies current minimum value of the axis.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartEvents OnAxisActualRangeCalculated="AxisActualRangeEvent" />
	
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />
	
    <ChartSeriesCollection>
        <ChartSeries DataSource="@Sales" XName="Month" YName="SalesValue" Type="ChartSeriesType.Column">
            <ChartMarker Visible="true">
            </ChartMarker>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class SalesInfo
    {
        public string Month { get; set; }
        public double SalesValue { get; set; }
    }
	
    public List<SalesInfo> Sales = new List<SalesInfo>
    {
        new SalesInfo { Month = "Jan", SalesValue = 35 },
        new SalesInfo { Month = "Feb", SalesValue = 28 },
        new SalesInfo { Month = "Mar", SalesValue = 34 },
        new SalesInfo { Month = "Apr", SalesValue = 32 },
        new SalesInfo { Month = "May", SalesValue = 40 },
        new SalesInfo { Month = "Jun", SalesValue = 32 },
        new SalesInfo { Month = "Jul", SalesValue = 35 }
    };

    public void AxisActualRangeEvent(AxisRangeCalculatedEventArgs args)
    {
        // Here, you can customize your code.
    }
}

```

## OnAxisMultiLevelLabelRender

[OnAxisMultiLevelLabelRender](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_OnAxisMultiLevelLabelRender) event triggers while rendering multilevel labels.

### Arguments

The following properties are available in the [AxisMultiLabelRenderEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AxisMultiLabelRenderEventArgs.html).

* [Alignment](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AxisMultiLabelRenderEventArgs.html#Syncfusion_Blazor_Charts_AxisMultiLabelRenderEventArgs_Alignment) – Specifies the alignment of the axis label.
* [Text](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AxisMultiLabelRenderEventArgs.html#Syncfusion_Blazor_Charts_AxisMultiLabelRenderEventArgs_Text) – Specifies the text to be displayed in the axis label.
* [TextStyle](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AxisMultiLabelRenderEventArgs.html#Syncfusion_Blazor_Charts_AxisMultiLabelRenderEventArgs_TextStyle) – Specifies the text style of the axis label.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartEvents OnAxisMultiLevelLabelRender="AxisMultiLevelLabelEvent" />
	
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category">
        <ChartMultiLevelLabels>
            <ChartMultiLevelLabel>
               <ChartCategories>
                  <ChartCategory Start="0" End="3" Text="First_Half"></ChartCategory>
                  <ChartCategory Start="3" End="6" Text="Second_Half"></ChartCategory>
               </ChartCategories>
            </ChartMultiLevelLabel>
        </ChartMultiLevelLabels>
    </ChartPrimaryXAxis>
	
    <ChartSeriesCollection>
        <ChartSeries DataSource="@Sales" XName="Month" YName="SalesValue" Type="ChartSeriesType.Column">
            <ChartMarker Visible="true">
            </ChartMarker>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    
    public class SalesInfo
    {
        public string Month { get; set; }
        public double SalesValue { get; set; }
    }
	
    public List<SalesInfo> Sales = new List<SalesInfo>
    {
        new SalesInfo { Month = "Jan", SalesValue = 35 },
        new SalesInfo { Month = "Feb", SalesValue = 28 },
        new SalesInfo { Month = "Mar", SalesValue = 34 },
        new SalesInfo { Month = "Apr", SalesValue = 32 },
        new SalesInfo { Month = "May", SalesValue = 40 },
        new SalesInfo { Month = "Jun", SalesValue = 32 },
        new SalesInfo { Month = "Jul", SalesValue = 35 }
    };

    public void AxisMultiLevelLabelEvent(AxisMultiLabelRenderEventArgs args)
    {
        // Here, you can customize your code.
    }
}

```

## SizeChanged

[SizeChanged](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_SizeChanged) event triggers after resizing the chart.

### Arguments

The following fields are available in the [ResizeEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ResizeEventArgs.html).

* [CurrentSize](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ResizeEventArgs.html#Syncfusion_Blazor_Charts_ResizeEventArgs_CurrentSize) – Specifies the current size of the chart.
* [PreviousSize](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ResizeEventArgs.html#Syncfusion_Blazor_Charts_ResizeEventArgs_PreviousSize) – Specifies the previous size of the chart.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartEvents SizeChanged="@SizeChangedEvent" />
	
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />
	
    <ChartSeriesCollection>
        <ChartSeries DataSource="@Sales" XName="Month" YName="SalesValue" Type="ChartSeriesType.Column">
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class SalesInfo
    {
        public string Month { get; set; }
        public double SalesValue { get; set; }
    }
	
    public List<SalesInfo> Sales = new List<SalesInfo>
	{
        new SalesInfo { Month = "Jan", SalesValue = 35 },
        new SalesInfo { Month = "Feb", SalesValue = 28 },
        new SalesInfo { Month = "Mar", SalesValue = 34 },
        new SalesInfo { Month = "Apr", SalesValue = 32 },
        new SalesInfo { Month = "May", SalesValue = 40 },
        new SalesInfo { Month = "Jun", SalesValue = 32 },
        new SalesInfo { Month = "Jul", SalesValue = 35 }
    };

    public void SizeChangedEvent(ResizeEventArgs args)
    {
        // Here, you can customize your code.
    }
}

```

## OnScrollChanged

[OnScrollChanged](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_OnScrollChanged) event triggers while scrolling the chart.

### Arguments

The following properties are available in the [ScrollEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ScrollEventArgs.html).

* [Axis](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ScrollEventArgs.html#Syncfusion_Blazor_Charts_ScrollEventArgs_Axis) – Specifies the current axis that is scrolled.
* [CurrentRange](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ScrollEventArgs.html#Syncfusion_Blazor_Charts_ScrollEventArgs_CurrentRange) – Specifies the current range of the axis.
* [PreviousAxisRange](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ScrollEventArgs.html#Syncfusion_Blazor_Charts_ScrollEventArgs_PreviousAxisRange) – Specifies the current axis.
* [PreviousRange](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ScrollEventArgs.html#Syncfusion_Blazor_Charts_ScrollEventArgs_PreviousRange) – Specifies the previous range of the axis.
* [PreviousZoomFactor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ScrollEventArgs.html#Syncfusion_Blazor_Charts_ScrollEventArgs_PreviousZoomFactor) – Specifies the previous zoom factor value.
* [PreviousZoomPosition](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ScrollEventArgs.html#Syncfusion_Blazor_Charts_ScrollEventArgs_PreviousZoomPosition) – Specifies the previous zoom position value.
* [Range](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ScrollEventArgs.html#Syncfusion_Blazor_Charts_ScrollEventArgs_Range) – Specifies the range of the axis.
* [ZoomFactor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ScrollEventArgs.html#Syncfusion_Blazor_Charts_ScrollEventArgs_ZoomFactor) – Specifies the current zoom factor value.
* [ZoomPosition](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ScrollEventArgs.html#Syncfusion_Blazor_Charts_ScrollEventArgs_ZoomPosition) – Specifies the current zoom position value.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartEvents OnScrollChanged="ScrollChangeEvent" />
	
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" ZoomFactor="0.5" ZoomPosition="0.2">
        <ChartAxisScrollbarSettings Enable="true"></ChartAxisScrollbarSettings>
    </ChartPrimaryXAxis>
	
    <ChartSeriesCollection>
        <ChartSeries DataSource="@Sales" XName="Month" YName="SalesValue" Type="ChartSeriesType.Column">
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class SalesInfo
    {
        public string Month { get; set; }
        public double SalesValue { get; set; }
    }
	
    public List<SalesInfo> Sales = new List<SalesInfo>
	{
        new SalesInfo { Month = "Jan", SalesValue = 35 },
        new SalesInfo { Month = "Feb", SalesValue = 28 },
        new SalesInfo { Month = "Mar", SalesValue = 34 },
        new SalesInfo { Month = "Apr", SalesValue = 32 },
        new SalesInfo { Month = "May", SalesValue = 40 },
        new SalesInfo { Month = "Jun", SalesValue = 32 },
        new SalesInfo { Month = "Jul", SalesValue = 35 }
    };

    public void ScrollChangeEvent(ScrollEventArgs args)
    {
        // Here, you can customize your code.
    }
}

```

## OnExportComplete

[OnExportComplete](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_OnExportComplete) event triggers after exporting the chart.

### Arguments

The following field is available in the [ExportEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ExportEventArgs.html).

* [DataUrl](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ExportEventArgs.html#Syncfusion_Blazor_Charts_ExportEventArgs_DataUrl) – Specifies the DataUrl of the exported file.

```cshtml

@using Syncfusion.Blazor.Charts

<button class="btn-success" @onclick="Export">Export</button>
<SfChart @ref="chart">
    <ChartEvents OnExportComplete="ExportCompleteEvent" />
	
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />
	
    <ChartSeriesCollection>
        <ChartSeries DataSource="@Sales" XName="Month" YName="SalesValue" Type="ChartSeriesType.Column">
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    SfChart chart;
    public class SalesInfo
    {
        public string Month { get; set; }
        public double SalesValue { get; set; }
    }
	
    public List<SalesInfo> Sales = new List<SalesInfo>
	{
        new SalesInfo { Month = "Jan", SalesValue = 35 },
        new SalesInfo { Month = "Feb", SalesValue = 28 },
        new SalesInfo { Month = "Mar", SalesValue = 34 },
        new SalesInfo { Month = "Apr", SalesValue = 32 },
        new SalesInfo { Month = "May", SalesValue = 40 },
        new SalesInfo { Month = "Jun", SalesValue = 32 },
        new SalesInfo { Month = "Jul", SalesValue = 35 }
    };

    public void Export()
    {
        chart.Export(ExportType.JPEG, "Charts");
    }

    public void ExportCompleteEvent(ExportEventArgs args)
    {
        // Here, you can customize your code.
    }
}

```

## OnDataEdit

[OnDataEdit](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_OnDataEdit) event triggers while dragging the data point.

### Arguments

The following fields are available in the [DataEditingEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.DataEditingEventArgs.html).

* [NewValue](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.DataEditingEventArgs.html#Syncfusion_Blazor_Charts_DataEditingEventArgs_NewValue) – Specifies the new value of the current point.
* [OldValue](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.DataEditingEventArgs.html#Syncfusion_Blazor_Charts_DataEditingEventArgs_OldValue) – Specifies the previous value of the current point.
* [Point](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.DataEditingEventArgs.html#Syncfusion_Blazor_Charts_DataEditingEventArgs_Point) – Specifies the current point which is being edited.
* [PointIndex](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.DataEditingEventArgs.html#Syncfusion_Blazor_Charts_DataEditingEventArgs_PointIndex) – Specifies the index of the current point.
* [Series](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.DataEditingEventArgs.html#Syncfusion_Blazor_Charts_DataEditingEventArgs_Series) – Specifies the current chart series whose point is being edited.
* [SeriesIndex](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.DataEditingEventArgs.html#Syncfusion_Blazor_Charts_DataEditingEventArgs_SeriesIndex) – Specifies the index of the current series.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartEvents OnDataEdit="DataEditEvent" />
	
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />
	
    <ChartSeriesCollection>
        <ChartSeries DataSource="@Sales" XName="Month" YName="SalesValue" Type="ChartSeriesType.Column">
            <ChartDataEditSettings Enable="true"></ChartDataEditSettings>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class SalesInfo
    {
        public string Month { get; set; }
        public double SalesValue { get; set; }
    }
	
    public List<SalesInfo> Sales = new List<SalesInfo>
	{
        new SalesInfo { Month = "Jan", SalesValue = 35 },
        new SalesInfo { Month = "Feb", SalesValue = 28 },
        new SalesInfo { Month = "Mar", SalesValue = 34 },
        new SalesInfo { Month = "Apr", SalesValue = 32 },
        new SalesInfo { Month = "May", SalesValue = 40 },
        new SalesInfo { Month = "Jun", SalesValue = 32 },
        new SalesInfo { Month = "Jul", SalesValue = 35 }
    };

    public void DataEditEvent(DataEditingEventArgs arg)
    {
        // Here, you can customize your code.
    }
}

```

## OnDataEditCompleted

[OnDataEditCompleted](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_OnDataEditCompleted) event triggers when the point drag is completed.

### Arguments

The following fields are available in the [DataEditingEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.DataEditingEventArgs.html).

* [NewValue](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.DataEditingEventArgs.html#Syncfusion_Blazor_Charts_DataEditingEventArgs_NewValue) – Specifies the new value of the current point.
* [OldValue](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.DataEditingEventArgs.html#Syncfusion_Blazor_Charts_DataEditingEventArgs_OldValue) – Specifies the previous value of the current point.
* [Point](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.DataEditingEventArgs.html#Syncfusion_Blazor_Charts_DataEditingEventArgs_Point) – Specifies the current point which is being edited.
* [PointIndex](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.DataEditingEventArgs.html#Syncfusion_Blazor_Charts_DataEditingEventArgs_PointIndex) – Specifies the index of the current point.
* [Series](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.DataEditingEventArgs.html#Syncfusion_Blazor_Charts_DataEditingEventArgs_Series) – Specifies the current chart series whose point is being edited.
* [SeriesIndex](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.DataEditingEventArgs.html#Syncfusion_Blazor_Charts_DataEditingEventArgs_SeriesIndex) – Specifies the index of the current series.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartEvents OnDataEditCompleted="DataEditEvent" />
	
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />
	
    <ChartSeriesCollection>
        <ChartSeries DataSource="@Sales" XName="Month" YName="SalesValue" Type="ChartSeriesType.Column">
            <ChartDataEditSettings Enable="true"></ChartDataEditSettings>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class SalesInfo
    {
        public string Month { get; set; }
        public double SalesValue { get; set; }
    }
	
    public List<SalesInfo> Sales = new List<SalesInfo>
	{
        new SalesInfo { Month = "Jan", SalesValue = 35 },
        new SalesInfo { Month = "Feb", SalesValue = 28 },
        new SalesInfo { Month = "Mar", SalesValue = 34 },
        new SalesInfo { Month = "Apr", SalesValue = 32 },
        new SalesInfo { Month = "May", SalesValue = 40 },
        new SalesInfo { Month = "Jun", SalesValue = 32 },
        new SalesInfo { Month = "Jul", SalesValue = 35 }
    };

    public void DataEditEvent(DataEditingEventArgs arg)
    {
        // Here you can customize your code
    }
}

```

## OnLegendClick

[OnLegendClick](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_OnLegendClick) event triggers after legend click.

### Arguments

The following properties are available in the [LegendClickEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.LegendClickEventArgs.html).

* [LegendShape](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.LegendClickEventArgs.html#Syncfusion_Blazor_Charts_LegendClickEventArgs_LegendShape) – Specifies the shape of the legend item.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartEvents OnLegendClick="LegendClickEvent" />
	
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />
	
    <ChartSeriesCollection>
        <ChartSeries DataSource="@Sales" Name="Column" XName="Month" YName="SalesValue" Type="ChartSeriesType.Column">
        </ChartSeries>
        <ChartSeries DataSource="@Sales" Name="Line" XName="Month" YName="SalesValue" Type="ChartSeriesType.Line">
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class SalesInfo
    {
        public string Month { get; set; }
        public double SalesValue { get; set; }
    }
	
    public List<SalesInfo> Sales = new List<SalesInfo>
	{
        new SalesInfo { Month = "Jan", SalesValue = 35 },
        new SalesInfo { Month = "Feb", SalesValue = 28 },
        new SalesInfo { Month = "Mar", SalesValue = 34 },
        new SalesInfo { Month = "Apr", SalesValue = 32 },
        new SalesInfo { Month = "May", SalesValue = 40 },
        new SalesInfo { Month = "Jun", SalesValue = 32 },
        new SalesInfo { Month = "Jul", SalesValue = 35 }
    };

    public void LegendClickEvent(LegendClickEventArgs args)
    {
        // Here, you can customize your code.
    }
}

```

## OnMultiLevelLabelClick

[OnMultiLevelLabelClick](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_OnMultiLevelLabelClick) event triggers after clicking on multilevel label.

### Arguments

The following fields are available in the [MultiLevelLabelClickEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.MultiLevelLabelClickEventArgs.html).

* [Axis](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.MultiLevelLabelClickEventArgs.html#Syncfusion_Blazor_Charts_MultiLevelLabelClickEventArgs_Axis) – Specifies the axis of the clicked label.
* [CustomAttributes](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.MultiLevelLabelClickEventArgs.html#Syncfusion_Blazor_Charts_MultiLevelLabelClickEventArgs_CustomAttributes) – Specifies the custom objects for multi level labels.
* [End](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.MultiLevelLabelClickEventArgs.html#Syncfusion_Blazor_Charts_MultiLevelLabelClickEventArgs_End) – Specifies the end value of the multi level labels.
* [Level](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.MultiLevelLabelClickEventArgs.html#Syncfusion_Blazor_Charts_MultiLevelLabelClickEventArgs_Level) – Specifies the current level of the label.
* [Start](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.MultiLevelLabelClickEventArgs.html#Syncfusion_Blazor_Charts_MultiLevelLabelClickEventArgs_Start) – Specifies the start value of the multi level labels
* [Text](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.MultiLevelLabelClickEventArgs.html#Syncfusion_Blazor_Charts_MultiLevelLabelClickEventArgs_Text) – Specifies the text of the current label.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartEvents OnMultiLevelLabelClick="MultiLabelClickEvent" />
	
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category">
        <ChartMultiLevelLabels>
            <ChartMultiLevelLabel>
                <ChartCategories>
                    <ChartCategory Start="0" End="3" Text="First_Half"></ChartCategory>
                    <ChartCategory Start="3" End="6" Text="Second_Half"></ChartCategory>
                </ChartCategories>
            </ChartMultiLevelLabel>
        </ChartMultiLevelLabels>
    </ChartPrimaryXAxis>
	
    <ChartSeriesCollection>
        <ChartSeries DataSource="@Sales" XName="Month" YName="SalesValue" Type="ChartSeriesType.Column">
            <ChartMarker Visible="true">
            </ChartMarker>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class SalesInfo
    {
        public string Month { get; set; }
        public double SalesValue { get; set; }
    }
	
    public List<SalesInfo> Sales = new List<SalesInfo>
	{
        new SalesInfo { Month = "Jan", SalesValue = 35 },
        new SalesInfo { Month = "Feb", SalesValue = 28 },
        new SalesInfo { Month = "Mar", SalesValue = 34 },
        new SalesInfo { Month = "Apr", SalesValue = 32 },
        new SalesInfo { Month = "May", SalesValue = 40 },
        new SalesInfo { Month = "Jun", SalesValue = 32 },
        new SalesInfo { Month = "Jul", SalesValue = 35 }
    };

    public void MultiLabelClickEvent(MultiLevelLabelClickEventArgs args)
    {
        // Here, you can customize your code.
    }
}

```

## OnSelectionChanged

[OnSelectionChanged](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_OnSelectionChanged) event triggers after the selection is completed.

### Arguments

The following property is available in the  [SelectionCompleteEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SelectionCompleteEventArgs.html).

* [SelectedDataValues](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SelectionCompleteEventArgs.html#Syncfusion_Blazor_Charts_SelectionCompleteEventArgs_SelectedDataValues) – Specifies the selected Data X, Y values.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart SelectionMode="SelectionMode.Point">
    <ChartEvents OnSelectionChanged="SelectionChangedEvent" />
	
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />
	
    <ChartSeriesCollection>
        <ChartSeries DataSource="@Sales" XName="Month" YName="SalesValue" Type="ChartSeriesType.Column">
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class SalesInfo
    {
        public string Month { get; set; }
        public double SalesValue { get; set; }
    }
	
    public List<SalesInfo> Sales = new List<SalesInfo>
	{
        new SalesInfo { Month = "Jan", SalesValue = 35 },
        new SalesInfo { Month = "Feb", SalesValue = 28 },
        new SalesInfo { Month = "Mar", SalesValue = 34 },
        new SalesInfo { Month = "Apr", SalesValue = 32 },
        new SalesInfo { Month = "May", SalesValue = 40 },
        new SalesInfo { Month = "Jun", SalesValue = 32 },
        new SalesInfo { Month = "Jul", SalesValue = 35 }
    };

    public void SelectionChangedEvent(SelectionCompleteEventArgs args)
    {
        // Here, you can customize your code.
    }
}

```

## Loaded

`Loaded` event triggers after chart load.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartEvents Loaded="LoadedEvent" />
	
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />
	
    <ChartSeriesCollection>
        <ChartSeries DataSource="@Sales" XName="Month" YName="SalesValue" Type="ChartSeriesType.Column">
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class SalesInfo
    {
        public string Month { get; set; }
        public double SalesValue { get; set; }
    }
	
    public List<SalesInfo> Sales = new List<SalesInfo>
    {
        new SalesInfo { Month = "Jan", SalesValue = 35 },
        new SalesInfo { Month = "Feb", SalesValue = 28 },
        new SalesInfo { Month = "Mar", SalesValue = 34 },
        new SalesInfo { Month = "Apr", SalesValue = 32 },
        new SalesInfo { Month = "May", SalesValue = 40 },
        new SalesInfo { Month = "Jun", SalesValue = 32 },
        new SalesInfo { Month = "Jul", SalesValue = 35 }
    };

    public void LoadedEvent(LoadedEventArgs args)
    {
        // Here, you can customize your code.
    }
}

```

## OnPointClick

[OnPointClick](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_OnPointClick) event triggers on point click.

### Arguments

The following fields are available in the [PointEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.PointEventArgs.html).

* [Chart](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.PointEventArgs.html#Syncfusion_Blazor_Charts_PointEventArgs_Chart) – Specifies the current chart instance.
* [PageX](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.PointEventArgs.html#Syncfusion_Blazor_Charts_PointEventArgs_PageX) – Specifies the current window page x location.
* [PageY](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.PointEventArgs.html#Syncfusion_Blazor_Charts_PointEventArgs_PageY) – Specifies the current window page y location.
* [Point](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.PointEventArgs.html#Syncfusion_Blazor_Charts_PointEventArgs_Point) – Specifies the current point which is clicked.
* [PointIndex](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.PointEventArgs.html#Syncfusion_Blazor_Charts_PointEventArgs_PointIndex) – Specifies the index of the current point.
* [Series](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.PointEventArgs.html#Syncfusion_Blazor_Charts_PointEventArgs_Series) – Specifies the current series.
* [SeriesIndex](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.PointEventArgs.html#Syncfusion_Blazor_Charts_PointEventArgs_SeriesIndex) – Specifies the current series index.
* [X](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.PointEventArgs.html#Syncfusion_Blazor_Charts_PointEventArgs_X) – Specifies the x coordinate of the current mouse click.
* [Y](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.PointEventArgs.html#Syncfusion_Blazor_Charts_PointEventArgs_Y) – Specifies the y coordinate of the current mouse click.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartEvents OnPointClick="PointClickEvent" />
	
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />
	
    <ChartSeriesCollection>
        <ChartSeries DataSource="@Sales" XName="Month" YName="SalesValue" Type="ChartSeriesType.Column">
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class SalesInfo
    {
        public string Month { get; set; }
        public double SalesValue { get; set; }
    }
	
    public List<SalesInfo> Sales = new List<SalesInfo>
    {
        new SalesInfo { Month = "Jan", SalesValue = 35 },
        new SalesInfo { Month = "Feb", SalesValue = 28 },
        new SalesInfo { Month = "Mar", SalesValue = 34 },
        new SalesInfo { Month = "Apr", SalesValue = 32 },
        new SalesInfo { Month = "May", SalesValue = 40 },
        new SalesInfo { Month = "Jun", SalesValue = 32 },
        new SalesInfo { Month = "Jul", SalesValue = 35 }
    };

    public void PointClickEvent(PointEventArgs args)
    {
        // Here, you can customize your code.
    }
}

```

## TooltipRender

[TooltipRender](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_TooltipRender) event triggers before the tooltip for series is rendered.

### Arguments

The following properties are available in the [TooltipRenderEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.TooltipRenderEventArgs.html).

* [HeaderText](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.TooltipRenderEventArgs.html#Syncfusion_Blazor_Charts_TooltipRenderEventArgs_HeaderText) – Specifies the header text for the tooltip.
* [Text](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.TooltipRenderEventArgs.html#Syncfusion_Blazor_Charts_TooltipRenderEventArgs_Text) – Specifies the text for the tooltip.  

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartEvents TooltipRender="TooltipEvent" />
	
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />
	
    <ChartSeriesCollection>
        <ChartSeries DataSource="@Sales" XName="Month" YName="SalesValue" Type="ChartSeriesType.Column">
        </ChartSeries>
    </ChartSeriesCollection>
	
    <ChartTooltipSettings Enable="true" />
</SfChart>

@code {
    public class SalesInfo
    {
        public string Month { get; set; }
        public double SalesValue { get; set; }
    }
	
    public List<SalesInfo> Sales = new List<SalesInfo>
    {
        new SalesInfo { Month = "Jan", SalesValue = 35 },
        new SalesInfo { Month = "Feb", SalesValue = 28 },
        new SalesInfo { Month = "Mar", SalesValue = 34 },
        new SalesInfo { Month = "Apr", SalesValue = 32 },
        new SalesInfo { Month = "May", SalesValue = 40 },
        new SalesInfo { Month = "Jun", SalesValue = 32 },
        new SalesInfo { Month = "Jul", SalesValue = 35 }
    };

    public void TooltipEvent(TooltipRenderEventArgs args)
    {
        // Here, you can customize your code.
    }
}

```

## SharedTooltipRender

[SharedTooltipRender](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_SharedTooltipRender) event triggers before the shared tooltip for series is rendered.

### Arguments

The following properties are available in the [SharedTooltipRenderEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SharedTooltipRenderEventArgs.html).

* [HeaderText](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SharedTooltipRenderEventArgs.html#Syncfusion_Blazor_Charts_SharedTooltipRenderEventArgs_HeaderText) – Specifies the header text for the tooltip.
* [Text](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SharedTooltipRenderEventArgs.html#Syncfusion_Blazor_Charts_SharedTooltipRenderEventArgs_Text) – Specifies the text for the tooltip.  

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartEvents SharedTooltipRender="SharedTooltipEvent" />
	
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />
	
    <ChartSeriesCollection>
        <ChartSeries DataSource="@Sales" XName="Month" YName="SalesValue" Type="ChartSeriesType.Column">
        </ChartSeries>
        <ChartSeries DataSource="@Sales" XName="Month" YName="SalesValue" Type="ChartSeriesType.Column">
        </ChartSeries>
    </ChartSeriesCollection>
	
    <ChartTooltipSettings Enable="true" Shared="true" />
</SfChart>

@code {
    public class SalesInfo
    {
        public string Month { get; set; }
        public double SalesValue { get; set; }
    }
	
    public List<SalesInfo> Sales = new List<SalesInfo>
    {
        new SalesInfo { Month = "Jan", SalesValue = 35 },
        new SalesInfo { Month = "Feb", SalesValue = 28 },
        new SalesInfo { Month = "Mar", SalesValue = 34 },
        new SalesInfo { Month = "Apr", SalesValue = 32 },
        new SalesInfo { Month = "May", SalesValue = 40 },
        new SalesInfo { Month = "Jun", SalesValue = 32 },
        new SalesInfo { Month = "Jul", SalesValue = 35 }
    };

    public void SharedTooltipEvent(SharedTooltipRenderEventArgs args)
    {
        // Here, you can customize your code.
    }
}

```

N> Refer to our [Blazor Charts](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations and also explore our [Blazor Chart Example](https://blazor.syncfusion.com/demos/chart/line?theme=bootstrap5) to know various chart types and how to represent time-dependent data, showing trends at equal intervals.
