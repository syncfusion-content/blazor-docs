---
layout: post
title: Limits in Blazor Range Slider Component | Syncfusion
description: Checkout and learn here all about limits in Syncfusion Blazor Range Slider component and much more details.
platform: Blazor
control: Range Slider
documentation: ug
---

# Limits in Blazor Range Slider Component

The slider limits restrict the slider thumb between a particular range. This is used if higher or lower value affects the process or product where the slider is being used.

The following are the six options in the slider's limits object. Each API in the limits object is optional.

* [``Enabled``](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SliderLimits.html#Syncfusion_Blazor_Inputs_SliderLimits_Enabled): Enables the limits in the Slider.
* [``MinStart``](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SliderLimits.html#Syncfusion_Blazor_Inputs_SliderLimits_MinStart): Sets the minimum limit for the first handle.
* [``MinEnd``](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SliderLimits.html#Syncfusion_Blazor_Inputs_SliderLimits_MinEnd): Sets the maximum limit for the first handle.
* [``MaxStart``](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SliderLimits.html#Syncfusion_Blazor_Inputs_SliderLimits_MaxStart): Sets the minimum limit for the second handle.
* [``MaxEnd``](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SliderLimits.html#Syncfusion_Blazor_Inputs_SliderLimits_MaxEnd): Sets the maximum limit for the second handle.
* [``StartHandleFixed``](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SliderLimits.html#Syncfusion_Blazor_Inputs_SliderLimits_StartHandleFixed): Locks the first handle.
* [``EndHandleFixed``](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SliderLimits.html#Syncfusion_Blazor_Inputs_SliderLimits_EndHandleFixed): Locks the second handle.

## Default and MinRange Slider limits

There is only one handle in the Default and MinRange Slider, so [``MinStart``](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SliderLimits.html#Syncfusion_Blazor_Inputs_SliderLimits_MinStart), [``MinEnd``](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SliderLimits.html#Syncfusion_Blazor_Inputs_SliderLimits_MinEnd), and [``StartHandleFixed``](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SliderLimits.html#Syncfusion_Blazor_Inputs_SliderLimits_StartHandleFixed) options can be used. When the limits are enabled in the Slider, the limited area becomes darken. So you can differentiate the allowed and restricted area. 

Refer to the following snippet to enable the limits in the Slider.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfSlider Value="30" Type="SliderType.MinRange">
    <SliderLimits MinStart="20" MinEnd="50" Enabled="true"></SliderLimits>
</SfSlider>
```

![Blazor Range Slider with Minimum Range Limits](images/blazor-rangeslider-min-range-limit.gif)

## Range Slider limits

In the Range Slider, both handles can be restricted and locked from the limit's object. In this sample, the first handle is limited between 10 and 40, and the second handle is limited between 60 and 90.

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

The movement of slider handles can be locked by enabling the [``StartHandleFixed``](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SliderLimits.html#Syncfusion_Blazor_Inputs_SliderLimits_StartHandleFixed) and [``EndHandleFixed``](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SliderLimits.html#Syncfusion_Blazor_Inputs_SliderLimits_EndHandleFixed) properties in the limit's object.

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