---
layout: post
title: Convert millisecond to date time in Blazor Chart | Syncfusion®
description: Learn here all the features about Convert millisecond to date time in Blazor Charts component and more.
platform: Blazor
control: Chart
documentation: ug
---

<!-- markdownlint-disable MD036 -->

# Convert Millisecond to Date Time in Blazor Charts Component

In the Syncfusion Blazor Charts component, when working with a DateTime axis, the chart internally converts all date values into Unix time (milliseconds). This conversion simplifies calculations such as zooming, panning, and range selection. As a result, when you interact with chart events—especially zoom-related events—the axis values you receive will be in milliseconds rather than human-readable date formats.

A common scenario where this behavior becomes evident is during zoom operations. When a user zooms into a chart, the visible axis range dynamically changes based on the selected region. Once the zoom action is completed, the [OnZoomEnd](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_OnZoomEnd) event is triggered. This event provides access to the updated axis range, but the minimum and maximum values are returned in milliseconds calculated from January 1, 1970 (Unix epoch time) rather than in a readable DateTime format.

## Why Conversion is Required

- The chart internally stores date values as milliseconds for accuracy and performance.
- Event arguments such as ZoomingEventArgs return numeric values representing milliseconds.
- These raw values are not user-friendly or directly meaningful.
- Converting them to DateTime allows you to:

    - Display readable and understandable date ranges to users.
    - Perform filtering operations based on specific date ranges.
    - Integrate or synchronize with other UI components that rely on standard date formats.
    - Log or analyze user interactions with meaningful timestamps.

## Steps to Convert Milliseconds to DateTime

### Step 1: Handle the OnZoomEnd Event

You can access the zoomed axis range by subscribing to the OnZoomEnd event in the chart’s events section.

```cshtml
<ChartEvents OnZoomEnd="RangeSelectionCompleted"></ChartEvents>

```

### Step 2: Extract Axis Range Values

Inside the event handler, the ZoomingEventArgs object provides details about the zoom operation. The AxisCollection property contains information about all axes, including their updated ranges.

### Step 3: Convert Milliseconds to DateTime

To convert the millisecond value into a DateTime, use the Unix epoch reference (January 1, 1970) and add the milliseconds using the AddMilliseconds method.

```cshtml
<ChartEvents OnZoomEnd="RangeSelectionCompleted"></ChartEvents>

public void RangeSelectionCompleted(ZoomingEventArgs args)
{
    var zoomData = args?.AxisCollection?.FirstOrDefault();
    Console.WriteLine(new DateTime(1970, 1, 1).AddMilliseconds(zoomData.AxisRange.Min));
    Console.WriteLine(new DateTime(1970, 1, 1).AddMilliseconds(zoomData.AxisRange.Max));
}

```


## Explanation of the Code

- args.AxisCollection: Contains details about all chart axes.
- AxisRange.Min and AxisRange.Max: Represent the zoomed range in milliseconds.
- new DateTime(1970, 1, 1): Defines the Unix epoch start date.
- AddMilliseconds(...): Converts milliseconds into a valid DateTime.


Best Practices

- Always check for null values to avoid runtime exceptions.
- If your chart contains multiple axes, ensure you select the correct one.
- Consider formatting the output date using .ToString("yyyy-MM-dd HH:mm:ss") for better readability.
- If working with different time zones, apply appropriate conversions using DateTimeOffset.

When using the Syncfusion Blazor Chart with a DateTime axis, all internal computations use milliseconds. By leveraging the OnZoomEnd event, you can retrieve the zoomed range in milliseconds and convert it into meaningful DateTime values using the Unix epoch reference. This approach ensures that your application remains user-friendly while still benefiting from the performance optimizations of the chart component.
This method is particularly useful for scenarios such as reporting, filtering datasets, or synchronizing chart data with other components in your application.

