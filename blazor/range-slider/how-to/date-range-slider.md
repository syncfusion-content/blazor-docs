---
layout: post
title: How to format date range slider in Blazor Range Slider | Syncfusion
description: Format Blazor Range Slider tick labels and tooltips to display date values in user-friendly format.
platform: Blazor
control: Range Slider
documentation: ug
---

# How to format date range slider in Blazor Range Slider

This example demonstrates how to display dates in the Blazor Range Slider by formatting tick labels and tooltips. The date formatting is implemented using the [`TicksRendering`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SliderEvents-1.html#Syncfusion_Blazor_Inputs_SliderEvents_1_TicksRendering) and [`OnTooltipChange`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SliderEvents-1.html#Syncfusion_Blazor_Inputs_SliderEvents_1_OnTooltipChange) events, as shown in the following sample.

```cshtml
@using System.Globalization;
@using Syncfusion.Blazor.Inputs

<SfSlider TValue="int" Min="@MinValue()" Max="@MaxValue()" @bind-Value="@value">
    <SliderEvents TicksRendering="@TicksRendering" TValue="int" OnTooltipChange="@TooltipChange"></SliderEvents>
    <SliderTicks LargeStep="1" ShowSmallTicks="true" Placement="Placement.Before"> </SliderTicks>
    <SliderTooltip Placement="TooltipPlacement.After" IsVisible="true"></SliderTooltip>
</SfSlider>

@code{
    int value = 15;
    string MonthName = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 13).ToString("MMM", CultureInfo.InvariantCulture);
    public double MinValue()
    {
        DateTime datetime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 13);
        return datetime.Day;
    }
    public double MaxValue()
    {
        DateTime datetime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 21);
        return datetime.Day;
    }
    public void TicksRendering(SliderTickEventArgs args)
    {
        args.Text = MonthName + " " + args.Value + ", " + DateTime.Now.Year;
    }
    public void TooltipChange(SliderTooltipEventArgs<int> args)
    {
        args.Text = MonthName + " " + args.Value + ", " + DateTime.Now.Year;
    }
}
```

![Blazor Range Slider with date-formatted ticks](../images/blazor-rangeslider-with-daterange.gif)