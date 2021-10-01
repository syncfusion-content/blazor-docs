---
layout: post
title: Ticks in Blazor Range Slider Component | Syncfusion
description: Checkout and learn here all about Ticks in Syncfusion Blazor Range Slider component and much more details.
platform: Blazor
control: Range Slider
documentation: ug
---

# Ticks in Blazor Range Slider Component

The Ticks in Slider supports you to easily identify the current value/values of the Slider. It contains `SmallStep` and `LargeStep`. The value of the major ticks alone will be displayed in the slider. In order to enable/disable the small ticks, use the `ShowSmallTicks` property.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfSlider @bind-Value="@value">
    <SliderTicks Placement="Placement.After" ShowSmallTicks="true" LargeStep="20" SmallStep="10"></SliderTicks>
    <SliderTooltip IsVisible="true" ShowOn="TooltipShowOn.Always" Placement="TooltipPlacement.Before"></SliderTooltip>
</SfSlider>

@code {
    int value = 30;
}
```

![Blazor RangeSlider with Ticks](images/blazor-rangeslider-ticks.gif)

## Step

When the Slider is moved, it increases/decreases the value based on the step value. By default, the value is increased/decreased by 1. Use the `Step` property to change the increment step value.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfSlider Step="10" @bind-Value="@value">
   <SliderTooltip IsVisible="true" ShowOn="TooltipShowOn.Always" Placement="TooltipPlacement.Before"></SliderTooltip>
</SfSlider>

@code {
    int value = 30;
}
```

![Blazor RangeSlider with Step](./images/blazor-rangeslider-step.gif)

## Min and Max

Enables the minimum/starting and maximum/ending value of the Slider, by using the `Min` and `Max` property. By default, the minimum value is 1 and maximum value is 100. In the following sample the slider is rendered with the min value as 100 and max value as 1100.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfSlider @bind-Value ="@value" Min="100" Max="1100">
     <SliderTicks Placement="Placement.After" ShowSmallTicks="true" LargeStep="100" SmallStep="50"></SliderTicks>
    <SliderTooltip IsVisible="true" ShowOn="TooltipShowOn.Always" Placement="TooltipPlacement.Before"></SliderTooltip>
</SfSlider>

@code {
    int value = 300;
}
```

![Blazor RangeSlider with Minimum and Maximum Value](./images/blazor-rangeslider-min-max-value.gif)