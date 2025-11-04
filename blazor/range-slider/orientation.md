---
layout: post
title: Orientation in Blazor Range Slider Component | Syncfusion
description: Checkout and learn here all about Orientation in Syncfusion Blazor Range Slider component and much more.
platform: Blazor
control: Range Slider
documentation: ug
---

# Orientation in Blazor Range Slider Component

The Slider can be displayed, either in horizontal or vertical orientation by using [**Orientation**](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfSlider-1.html#Syncfusion_Blazor_Inputs_SfSlider_1_ShowButtons) property. By default, the Slider renders in horizontal orientation.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfSlider ID="default" Value="40" Orientation="SliderOrientation.Vertical"></SfSlider>
<style>
    #default {
        height: 300px;
    }
</style>
```

![Blazor Range Slider with Vertical Orientation](images/blazor-rangeslider-vertical-orientation.png)