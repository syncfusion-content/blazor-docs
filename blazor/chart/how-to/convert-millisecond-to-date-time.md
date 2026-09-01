---
layout: post
title: How to Convert Milliseconds to DateTime in Blazor Chart | Syncfusion®
description: Learn how to convert milliseconds to a DateTime value in Blazor Charts using Syncfusion. Use the OnZoomEnd event to convert axis range after zoom.
platform: Blazor
control: Charts
documentation: ug
---

<!-- markdownlint-disable MD036 -->

# How to Convert Milliseconds to DateTime in Blazor Charts

The chart converts `DateTime` values to milliseconds internally when calculating axis ranges. As a result, axis range values returned through events such as `OnZoomEnd` are provided in milliseconds. You can use the [OnZoomEnd](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_OnZoomEnd) event to retrieve the zoomed axis range and convert the millisecond values back to `DateTime`.

To convert axis range values from milliseconds to `DateTime`, follow these steps:

**Step 1**:

Using [OnZoomEnd](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_OnZoomEnd) event, you can get the axis range in milliseconds. By using the following code, you can get the equivalent date value.

```cshtml
<ChartEvents OnZoomEnd="RangeSelectionCompleted"></ChartEvents>

public void RangeSelectionCompleted(ZoomingEventArgs args)
{
    var zoomData = args?.AxisCollection?.FirstOrDefault();
    Console.WriteLine(new DateTime(1970, 1, 1).AddMilliseconds(zoomData.AxisRange.Min));
    Console.WriteLine(new DateTime(1970, 1, 1).AddMilliseconds(zoomData.AxisRange.Max));
}

```