---
layout: post
title: Orientation in Blazor Range Slider Component | Syncfusion
description: Checkout and learn here all about Orientation in Syncfusion Blazor Range Slider component and much more.
platform: Blazor
control: Range Slider
documentation: ug
---

# Orientation in Blazor Range Slider Component

The Slider can be displayed in either **horizontal** or **vertical** orientation. This orientation is controlled by the [`Orientation`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfSlider-1.html#Syncfusion_Blazor_Inputs_SfSlider_1_Orientation) property of the Slider component. By default, when no orientation is specified, the Slider renders in **horizontal** orientation.

To change the orientation to vertical, set the Orientation property to **SliderOrientation.Vertical**, as demonstrated in the following example:

```cshtml
@using Syncfusion.Blazor.Inputs

<SfSlider ID="default" Value="40" Orientation="SliderOrientation.Vertical"></SfSlider>
<style>
    #default {
        height: 300px;
    }
</style>
```

![Blazor RangeSlider with Vertical Orientation](images/blazor-rangeslider-vertical-orientation.png)