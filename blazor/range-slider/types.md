---
layout: post
title: Types in Blazor Range Slider Component | Syncfusion
description: Checkout and learn here all about types in Syncfusion Blazor Range Slider component and much more details.
platform: Blazor
control: Range Slider
documentation: ug
---

# Types in Blazor Range Slider Component

The [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfSlider-1.html#Syncfusion_Blazor_Inputs_SfSlider_1_Type) options for the slider are:

| **Types** | **Usage** |
| --- | --- |
| Default | Selects a single value. |
| MinRange | Selects a single value and displays a filled selection from the start to the current value. |
| Range | Selects a range of values using two handles and displays a filled selection between them. |

N> Default and MinRange both select a single value. MinRange visually fills the track from the start value to the current handle position. Range uses two handles to select a span of values and fills the area between them.

```cshtml
@using Syncfusion.Blazor.Inputs

<label class="labeltext">Default</label>
<SfSlider Value="30"></SfSlider>

<label class="labeltext">MinRange</label>
<SfSlider Value="40" Type="SliderType.MinRange"></SfSlider>

<label class="labeltext">Range</label>
<SfSlider Value=@RangeValue Type="SliderType.Range"></SfSlider>


@code{
    public int[] RangeValue = { 30, 70 };
}
```

![Displaying different Blazor Range Sliders](images/blazor-rangeslider-types.png)