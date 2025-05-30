---
layout: post
title: Time Range Slider in Blazor Range Slider Component | Syncfusion
description: Checkout and learn here all about Time Range Slider in Syncfusion Blazor Range Slider component and more.
platform: Blazor
control: Range Slider
documentation: ug
---

# Time Range Slider in Blazor Range Slider Component

The time formatting can be achieved same as the date formatting using [`TicksRendering`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SliderEvents-1.html#Syncfusion_Blazor_Inputs_SliderEvents_1_TicksRendering) and [`OnTooltipChange`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SliderEvents-1.html#Syncfusion_Blazor_Inputs_SliderEvents_1_OnTooltipChange) events.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfSlider TValue="int[]" Min="MinValue()" Max="@MaxValue()" Type="SliderType.Range" @bind-Value="@SliderValues">
    <SliderEvents TValue="int[]" OnTooltipChange="@TooltipChange" TicksRendering="@TickesRendering"></SliderEvents>
    <SliderTicks Placement="Placement.Before" LargeStep="7200000" SmallStep="3600000" ShowSmallTicks="true"></SliderTicks>
    <SliderTooltip Placement="TooltipPlacement.After" IsVisible="true"></SliderTooltip>
</SfSlider>

@code{
    int[] SliderValues = new int[] { 43200000, 54000000 };
    public double MinValue()
    {
        DateTime datetime = new DateTime(2013, 6, 13, 11, 0, 0);
        return datetime.TimeOfDay.TotalMilliseconds;
    }
    public double MaxValue()
    {
        DateTime datetime = new DateTime(2013, 6, 13, 23, 0, 0);
        return datetime.TimeOfDay.TotalMilliseconds;
    }
    public void TickesRendering(SliderTickEventArgs args)
    {
        double time = args.Value / 3600000;
        args.Text = time > 11 ? time + ".00 PM" : time + ".00 AM";
    }
    public void TooltipChange(SliderTooltipEventArgs<int[]> args)
    {
        double FirstValue = args.Value[0] / 3600000;
        double SecondValue = args.Value[1] / 3600000;

        if (FirstValue <= 11 && SecondValue < 11)
        {
            args.Text = FirstValue + ".00 AM -" + SecondValue + ".00 AM";
        }
        else if (FirstValue <= 11 && SecondValue > 11)
        {
            args.Text = FirstValue + ".00 AM -" + SecondValue + ".00 PM";
        }
        else if (FirstValue > 11 && SecondValue > 11)
        {
            args.Text = FirstValue + ".00 PM -" + SecondValue + ".00 PM";
        }
    }
}
```

![Blazor Range Slider with TimeRange](../images/blazor-rangeslider-with-timerange.gif)