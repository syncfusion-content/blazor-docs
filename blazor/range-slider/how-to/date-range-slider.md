---
layout: post
title: Date Range Slider in Blazor Range Slider Component | Syncfusion
description: Checkout and learn here all about Date Range Slider in Syncfusion Blazor Range Slider component and more.
platform: Blazor
control: Range Slider
documentation: ug
---

# Date Range Slider in Blazor Range Slider Component

The date formatting can be achieved using [`TicksRendering`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SliderEvents-1.html#Syncfusion_Blazor_Inputs_SliderEvents_1_TicksRendering) and [`OnTooltipChange`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SliderEvents-1.html#Syncfusion_Blazor_Inputs_SliderEvents_1_OnTooltipChange) events. The process of date formatting is explained in the below sample.

```cshtml
@using System.Globalization;
@using Syncfusion.Blazor.Inputs

<SfSlider TValue="int" Min="MinValue()" Max="@MaxValue()" @bind-Value="@value">
    <SliderEvents TicksRendering="@TickesRendering" TValue="int" OnTooltipChange="@TooltipChange"></SliderEvents>
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
    public void TickesRendering(SliderTickEventArgs args)
    {
        args.Text = MonthName + " " +args.Value + ", " + DateTime.Now.Year;
    }
    public void TooltipChange(SliderTooltipEventArgs<int> args)
    {
        args.Text = MonthName + " " + args.Value + ", " + DateTime.Now.Year;
    }
}
```

![Blazor Range Slider with DateRange](../images/blazor-rangeslider-with-daterange.gif)