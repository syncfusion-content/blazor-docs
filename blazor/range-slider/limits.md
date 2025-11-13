---
layout: post
title: Limits in Blazor Range Slider Component | Syncfusion
description: Checkout and learn here all about limits in Syncfusion Blazor Range Slider component and much more details.
platform: Blazor
control: Range Slider
documentation: ug
---

# Limits in Blazor Range Slider Component

Slider limits restrict the movement of the slider thumb(s) within a specified range. This is useful when higher or lower values would negatively affect a process or product where the slider is used.

The following options are available in the slider’s limits object. Each API in the limits object is optional.

* [``Enabled``](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SliderLimits.html#Syncfusion_Blazor_Inputs_SliderLimits_Enabled): Enables the limits in the slider.
* [``MinStart``](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SliderLimits.html#Syncfusion_Blazor_Inputs_SliderLimits_MinStart): Sets the minimum limit for the first handle.
* [``MinEnd``](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SliderLimits.html#Syncfusion_Blazor_Inputs_SliderLimits_MinEnd): Sets the maximum limit for the first handle.
* [``MaxStart``](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SliderLimits.html#Syncfusion_Blazor_Inputs_SliderLimits_MaxStart): Sets the minimum limit for the second handle.
* [``MaxEnd``](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SliderLimits.html#Syncfusion_Blazor_Inputs_SliderLimits_MaxEnd): Sets the maximum limit for the second handle.
* [``StartHandleFixed``](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SliderLimits.html#Syncfusion_Blazor_Inputs_SliderLimits_StartHandleFixed): Locks the first handle.
* [``EndHandleFixed``](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SliderLimits.html#Syncfusion_Blazor_Inputs_SliderLimits_EndHandleFixed): Locks the second handle.

## Default and MinRange slider limits

In Default and MinRange sliders, there is only one handle, so the [``MinStart``](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SliderLimits.html#Syncfusion_Blazor_Inputs_SliderLimits_MinStart), [``MinEnd``](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SliderLimits.html#Syncfusion_Blazor_Inputs_SliderLimits_MinEnd), and [``StartHandleFixed``](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SliderLimits.html#Syncfusion_Blazor_Inputs_SliderLimits_StartHandleFixed) options are applicable. When limits are enabled, the restricted area is darkened, making it easy to distinguish allowed and disallowed regions.

Refer to the following snippet to enable limits in the slider.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfSlider Value="30" Type="SliderType.MinRange">
    <SliderLimits MinStart="20" MinEnd="50" Enabled="true"></SliderLimits>
</SfSlider>
```

![Blazor Range Slider with Minimum Range Limits](images/blazor-rangeslider-min-range-limit.gif)

## Range slider limits

In the Range slider, both handles can be restricted and locked using the limits object. In this example, the first handle is limited between 10 and 40, and the second handle is limited between 60 and 90.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfSlider Value="@Value" Type="SliderType.Range">
    <SliderLimits Enabled="true" MinStart="10" MinEnd="40" MaxStart="60" MaxEnd="90"></SliderLimits>
</SfSlider>

@code{
   public int[] Value = { 30, 70 };
}
```

![Blazor Range Slider within Range](images/blazor-rangeslider-within-range.gif)

## Handle lock

The movement of slider handles can be locked by enabling the [``StartHandleFixed``](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SliderLimits.html#Syncfusion_Blazor_Inputs_SliderLimits_StartHandleFixed) and [``EndHandleFixed``](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SliderLimits.html#Syncfusion_Blazor_Inputs_SliderLimits_EndHandleFixed) properties in the limits object.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfSlider Value="@Value" Type="SliderType.Range">
     <SliderLimits Enabled="true" StartHandleFixed="true" EndHandleFixed="true">
    </SliderLimits>
</SfSlider>

@code{
   public int[] Value = { 30, 70 };
}
```

![Blazor Range Slider with Handle Lock](images/blazor-rangeslider-handle-lock.gif)