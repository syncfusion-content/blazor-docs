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

Chart converts the datetime to milliseconds to calculate the bounds, so all events for datetime axis returns the value in milliseconds. For example, after zoom completion, the ranges for axis will be in the milliseconds. By using the [OnZoomEnd](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_OnZoomEnd) event, you can convert millisecond value to date time format.

To convert millisecond value to date time format, follow the given steps:

**Step 1**:

Using `OnZoomEnd` event, you can get the axis range in milliseconds. By using the following code, you can get the equivalent date value.

```cshtml
<ChartEvents OnZoomEnd="RangeSelectionCompleted"></ChartEvents>

public void RangeSelectionCompleted(ZoomingEventArgs args)
{
    var zoomData = args?.AxisCollection?.FirstOrDefault();
    Console.WriteLine(new DateTime(1970, 1, 1).AddMilliseconds(zoomData.AxisRange.Min));
    Console.WriteLine(new DateTime(1970, 1, 1).AddMilliseconds(zoomData.AxisRange.Max));
}

```