---
layout: post
title: Events in Blazor Sparkline Component | Syncfusion
description: Checkout and learn here all about events in Syncfusion Blazor Sparkline component and much more details.
platform: Blazor
control: Sparkline Charts
documentation: ug
---

# Events in Blazor Sparkline Component

This section describes the Sparkline component's events that will be triggered when appropriate actions are performed. The events should be provided to the Sparkline through the [SparklineEvents](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SparklineEvents.html).

## Loaded

The `Loaded` event triggers after the Sparkline component has been loaded.

```cshtml
@using Syncfusion.Blazor.Charts

<SfSparkline DataSource="new int[]{ 0, 6, 4, 1, 3, 2, 5 }" Type="SparklineType.Line" Height="200px" Width="450px">
    <SparklineEvents OnLoaded="@LoadedHandler"></SparklineEvents>
</SfSparkline>

@code{
    public void LoadedHandler(System.EventArgs args)
    {
        // Here you can customize the code.
    }
}
```

## OnPointRendering

The [OnPointRendering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SparklineEvents.html#Syncfusion_Blazor_Charts_SparklineEvents_OnPointRendering) event triggers before the point rendering.

|   Argument name    |   Description                                          |
|--------------------| -------------------------------------------------------|
|   PointIndex            |    Specifies the current point index.           |
|   Fill     |    Specifies the point index color.       |
|   Border               |   Specifies the color and the width of the point border. |
|   Cancel               |   Specifies the event cancel status. |

```cshtml
@using Syncfusion.Blazor.Charts

<SfSparkline DataSource="new int[]{ 6, 4, 1, 3, 2, 5 }" Type="SparklineType.Column" Height="200px" Width="450px">
    <SparklineMarkerSettings Visible="new List<VisibleType>() { VisibleType.All }"></SparklineMarkerSettings>
    <SparklineEvents OnPointRendering="@PointRenderHandler"></SparklineEvents>
</SfSparkline>

@code{
    public void PointRenderHandler(SparklinePointEventArgs args)
    {
        // Here you can customize the code.
    }
}
```

## OnPointRegionMouseClick

The [OnPointRegionMouseClick](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SparklineEvents.html#Syncfusion_Blazor_Charts_SparklineEvents_OnPointRegionMouseClick) event triggers when the mouse click on the point region.

|   Argument name    |   Description                                          |
|--------------------| -------------------------------------------------------|
|   PointerIndex     |    Specifies the Sparkline point index region.      |
|   Cancel             |   Specifies the event cancel status. |

```cshtml
@using Syncfusion.Blazor.Charts

<SfSparkline DataSource="new int[]{ 6, 4, 1, 3, 2, 5 }" Type="SparklineType.Column" Height="200px" Width="450px">
    <SparklineMarkerSettings Visible="new List<VisibleType>() { VisibleType.All }"></SparklineMarkerSettings>
    <SparklineEvents OnPointRegionMouseClick="@PointRegionMouseClickHandler"></SparklineEvents>
</SfSparkline>

@code{
    public void PointRegionMouseClickHandler(PointRegionEventArgs args)
    {
        // Here you can customize the code.
    }
}
```

## OnResizing

The [OnResizing](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SparklineEvents.html#Syncfusion_Blazor_Charts_SparklineEvents_OnResizing) event triggers while resizing the window.

|   Argument name      |   Description                          |
|----------------------| ---------------------------------------|
|   CurrentSize        |   Specifies the size of Sparkline.         |
|   PreviousSize       |   Specifies the previous size of Sparkline. |
|   Cancel             |   Specifies the event cancel status. |

```cshtml
@using Syncfusion.Blazor.Charts

<SfSparkline DataSource="new int[]{ 0, 6, 4, 1, 3, 2, 5 }" Type="SparklineType.Line" Height="200px" Width="450px">
    <SparklineEvents OnResizing="@ResizeHandler"></SparklineEvents>
</SfSparkline>

@code{
    public void ResizeHandler(SparklineResizeEventArgs args)
    {
        // Here you can customize the code.
    }
}
```

## OnSeriesRendering

The [OnSeriesRendering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SparklineEvents.html#Syncfusion_Blazor_Charts_SparklineEvents_OnSeriesRendering) event triggers before rendering on each Sparkline series.

|   Argument name      |   Description                                                         |
|----------------------| ----------------------------------------------------------------------|
|   Border             |   Specifies the color and width of the series border.                         |
|   Fill               |   Specifies the series fill color.                             |
|   LineWidth          |   Specifies the series line width. |
|   Cancel             |   Specifies the event cancel status. |

```cshtml
@using Syncfusion.Blazor.Charts

<SfSparkline DataSource="new int[]{ 0, 6, 4, 1, 3, 2, 5 }" Type="SparklineType.Line" Height="200px" Width="450px">
    <SparklineEvents OnSeriesRendering="@SeriesRenderingHandler"></SparklineEvents>
</SfSparkline>

@code{
    public void SeriesRenderingHandler(SeriesRenderingEventArgs args)
    {
        // Here you can customize the code.
    }
}
```

## OnMarkerRendering

The [OnMarkerRendering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SparklineEvents.html#Syncfusion_Blazor_Charts_SparklineEvents_OnMarkerRendering) event triggers before rendering the Sparkline marker render.

|   Argument name      |   Description                                                         |
|----------------------| ----------------------------------------------------------------------|
|   Border             |   Specifies the color and the width of the marker border.                         |
|   Fill               |   Specifies the marker fill color.                             |
|   PointIndex          |   Specifies the marker point index. |
|   X          |   Specifies the x axis of the marker. |
|   Y          |   Specifies the y axis of the marker. |
|   Size          |   Specifies the size of the marker. |
|   Cancel             |   Specifies the event cancel status. |

```cshtml
@using Syncfusion.Blazor.Charts

<SfSparkline DataSource="new int[]{ 6, 4, 1, 3, 2, 5 }" Type="SparklineType.Line" Height="200px" Width="450px">
    <SparklineMarkerSettings Visible="new List<VisibleType>() { VisibleType.All }"></SparklineMarkerSettings>
    <SparklineEvents OnMarkerRendering="@MarkerRenderingHandler"></SparklineEvents>
</SfSparkline>

@code{
    public void MarkerRenderingHandler(MarkerRenderingEventArgs args)
    {
        // Here you can customize the code.
    }
}
```

## OnDataLabelRendering

The [OnDataLabelRendering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SparklineEvents.html#Syncfusion_Blazor_Charts_SparklineEvents_OnDataLabelRendering) event triggers before rendering the Sparkline data label render.

|   Argument name      |   Description                                                         |
|----------------------| ----------------------------------------------------------------------|
|   Border             |   Specifies the color and the width of the data label border.                        |
|   Fill               |   Specifies the series fill color of the data label.                             |
|   PointIndex          |   Specifies the data label point index. |
|   X          |   Specifies the x axis of the data label. |
|   Y          |   Specifies the y axis of the data label. |
|   Text          |   Specifies the content of the data label. |
|   Color          |   Specifies the content color. |
|   Cancel             |   Specifies the event cancel status. |

```cshtml
@using Syncfusion.Blazor.Charts

<SfSparkline DataSource="new int[]{ 6, 4, 1, 3, 2, 5 }" Type="SparklineType.Line" Height="200px" Width="450px">
    <SparklineDataLabelSettings Visible="new List<VisibleType>() { VisibleType.All }"></SparklineDataLabelSettings>
    <SparklineEvents OnDataLabelRendering="@DataLabelRenderingHandler"></SparklineEvents>
    <SparklineAxisSettings MinX="-1" MaxX="7" MaxY="7" MinY="-1"></SparklineAxisSettings>
</SfSparkline>

@code{
    public void DataLabelRenderingHandler(DataLabelRenderingEventArgs args)
    {
        // Here you can customize the code.
    }
}
```
