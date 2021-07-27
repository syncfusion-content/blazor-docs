---
layout: post
title: Convert millisecond to date time in Blazor Charts Component | Syncfusion
description: Learn here all about Convert millisecond to date time in Syncfusion Blazor Charts component and more.
platform: Blazor
control: Chart
documentation: ug
---

<!-- markdownlint-disable MD036 -->

# Convert millisecond to date time in Blazor Charts Component

Chart converts the datetime to milliseconds to calculate the bounds, so all events for datetime axis returns the value in milliseconds. For example, after zoom completion, the ranges for axis will be in the milliseconds, by using the [`OnZoomEnd`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_OnZoomEnd) event, you can convert millisecond value to date time format.

To convert millisecond value to date time format, follow the given steps:

**Step 1**:

Using `OnZoomEnd` event, you can get the axis range in milliseconds, by using below code, you can get the equivalent date value.

```
<ChartEvents OnZoomEnd="RangeSelectionCompleted"></ChartEvents>

public void RangeSelectionCompleted(ZoomingEventArgs args)
{
    var zoomData = args?.AxisCollection?.FirstOrDefault();
    Console.WriteLine(new DateTime(1970, 1, 1).AddMilliseconds(zoomData.AxisRange.Min));
    Console.WriteLine(new DateTime(1970, 1, 1).AddMilliseconds(zoomData.AxisRange.Max));
}

```ge.Max));
}

```