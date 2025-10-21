---
layout: post
title: Ticks in Blazor Range Slider Component | Syncfusion
description: Checkout and learn here all about Ticks in Syncfusion Blazor Range Slider component and much more details.
platform: Blazor
control: Range Slider
documentation: ug
---

# Ticks in Blazor Range Slider Component

Ticks in the slider help users quickly identify the current value or range. Configure tick intervals using [`SmallStep`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SliderTicks.html#Syncfusion_Blazor_Inputs_SliderTicks_SmallStep) and [`LargeStep`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SliderTicks.html#Syncfusion_Blazor_Inputs_SliderTicks_LargeStep). By default, only major (large) tick labels are displayed. Use the [`ShowSmallTicks`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SliderTicks.html#Syncfusion_Blazor_Inputs_SliderTicks_ShowSmallTicks) property to show or hide minor ticks.

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

![Blazor Range Slider with Ticks](images/blazor-rangeslider-ticks.gif)

## Step

When the slider moves, its value increases or decreases by the step amount. By default, the step is 1. Use the [`Step`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfSlider-1.html#Syncfusion_Blazor_Inputs_SfSlider_1_Step) property to change the increment.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfSlider Step="10" @bind-Value="@value">
   <SliderTooltip IsVisible="true" ShowOn="TooltipShowOn.Always" Placement="TooltipPlacement.Before"></SliderTooltip>
</SfSlider>

@code {
    int value = 30;
}
```

![Blazor Range Slider with Step](./images/blazor-rangeslider-step.gif)

## Min and Max

Set the minimum (start) and maximum (end) values using the [`Min`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfSlider-1.html#Syncfusion_Blazor_Inputs_SfSlider_1_Min) and [`Max`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfSlider-1.html#Syncfusion_Blazor_Inputs_SfSlider_1_Max) properties. By default, the slider range is 1 to 100. The following example configures a range from 100 to 1100.

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

![Blazor Range Slider with Minimum and Maximum Value](./images/blazor-rangeslider-min-max-value.gif)

## ValueChanged

The [ValueChanged](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfSlider-1.html#Syncfusion_Blazor_Inputs_SfSlider_1_ValueChanged) property of the Blazor Range Slider component allows you to define a callback method that will be invoked whenever the value of the Slider changes. This property enables you to capture the updated value of the Slider and perform custom actions based on the new value. The callback method can be used to handle any logic associated with the Slider value change, such as updating other parts of the application, triggering events, or displaying notifications.

```cshtml

@using Syncfusion.Blazor.Inputs
@inject IJSRuntime JSRuntime

<SfSlider TValue="int" Step="1" Min="1" Max="20" Value="value" ValueChanged="OnValueChanged">
    <SliderTooltip IsVisible="true" ShowOn="TooltipShowOn.Always" Placement="TooltipPlacement.After"></SliderTooltip>
</SfSlider>

@code {
    int value = 5;
    public void OnValueChanged(int newValue)
    {
        // Update the value variable with the new value
        value = newValue; 
        // For example, you can display the new value using an alert:
        JSRuntime.InvokeVoidAsync("alert", $"Slider value changed to: {value}");
    }
}

```