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

* ``Enabled``: Enables the limits in the Slider.
* ``MinStart``: Sets the minimum limit for the first handle.
* ``MinEnd``: Sets the maximum limit for the first handle.
* ``MaxStart``: Sets the minimum limit for the second handle.
* ``MaxEnd``: Sets the maximum limit for the second handle.
* ``StartHandleFixed``: Locks the first handle.
* ``EndHandleFixed``: Locks the second handle.

## Default and MinRange slider limits

There is only one handle in the Default and MinRange Slider, so ``MinStart``, ``MinEnd``, and ``StartHandleFixed`` options can be used. When the limits are enabled in the Slider, the limited area becomes darken. So you can differentiate the allowed and restricted area. 

Refer to the following snippet to enable the limits in the Slider.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfSlider Value="30" Type="SliderType.MinRange">
    <SliderLimits MinStart="20" MinEnd="50" Enabled="true"></SliderLimits>
</SfSlider>
```

![Blazor RangeSlider with Minimum Range Limits](images/blazor-rangeslider-min-range-limit.gif)

## Range slider limits

In the range slider, both handles can be restricted and locked from the limit's object. In this sample, the first handle is limited between 10 and 40, and the second handle is limited between 60 and 90.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfSlider Value="@Value" Type="SliderType.Range">
    <SliderLimits Enabled="true" MinStart="10" MinEnd="40" MaxStart="60" MaxEnd="90"></SliderLimits>
</SfSlider>

@code{
   public int[] Value = { 30, 70 };
}
```

![Blazor RangeSlider within Range](images/blazor-rangeslider-within-range.gif)

## Handle lock

The movement of slider handles can be locked by enabling the ``StartHandleFixed`` and ``EndHandleFixed`` properties in the limit's object.

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

![Blazor RangeSlider with Handle Lock](images/blazor-rangeslider-handle-lock.gif)