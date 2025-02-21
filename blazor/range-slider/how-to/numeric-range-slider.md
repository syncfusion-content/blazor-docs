---
layout: post
title: Numeric Range Slider in Blazor Range Slider Component | Syncfusion
description: Checkout and learn here all about Numeric Range Slider in Syncfusion Blazor Range Slider component and more.
platform: Blazor
control: Range Slider
documentation: ug
---

# Numeric Range Slider in Blazor Range Slider Component

The numeric values can be formatted into different decimal digits or fixed number of whole numbers or to represent the units. The Numeric processing is demonstrated below.

There are Numeric Range Sliders, which can be formatted in any way of your choice. In the examples found below, the first one demonstrates the visualization of ticks in km.

```cshtml
<SliderTicks ShowSmallTicks="true" Placement="Placement.After" LargeStep="20" SmallStep="10" Format="##.##km"> </SliderTicks>
            <SliderTooltip IsVisible="true" Placement="TooltipPlacement.Before" Format="##.##km"></SliderTooltip>
```

The second example showcases the use of decimal point in the Slider's ticks and tooltip placement.

```cshtml
<SliderTicks ShowSmallTicks="true" Placement="Placement.After" LargeStep="20" SmallStep="10" Format="##.#00"> </SliderTicks>
                <SliderTooltip IsVisible="true" Placement="TooltipPlacement.Before" Format="##.#00"></SliderTooltip>
```

And in the third example, the formatting involves the placement of zeros before the required values.

```cshtml
<SliderTicks ShowSmallTicks="true" Placement="Placement.After" LargeStep="20" SmallStep="10" Format="0000#"> </SliderTicks>
            <SliderTooltip IsVisible="true" Placement="TooltipPlacement.Before" Format="0000#"></SliderTooltip>
```

The complete code for the above Numeric Range Slider can be found below.

```cshtml
@using Syncfusion.Blazor.Inputs;

<div class="control-section">
    <div class="content-wrapper">
        <div class="sliderwrap">
            <label class="labeltext userselect">Default Slider</label>
            <SfSlider @bind-Value="@Value1">
                <SliderTicks ShowSmallTicks="true" Placement="Placement.After" LargeStep="20" SmallStep="10" Format="##.##km"> </SliderTicks>
                <SliderTooltip IsVisible="true" Placement="TooltipPlacement.Before" Format="##.##km"></SliderTooltip>
            </SfSlider>
        </div>
        <div class="sliderwrap">
            <label class="labeltext userselect">MinRange Slider</label>
            <SfSlider @bind-Value="@Value2" Type=SliderType.MinRange>
                <SliderTicks ShowSmallTicks="true" Placement="Placement.After" LargeStep="20" SmallStep="10" Format="##.#00"> </SliderTicks>
                    <SliderTooltip IsVisible="true" Placement="TooltipPlacement.Before" Format="##.#00"></SliderTooltip>
            </SfSlider>
        </div>
        <div class="sliderwrap">
            <label class="labeltext userselect">Range Slider</label>
            <SfSlider @bind-Value="@Value" Type=SliderType.Range>
                <SliderTicks ShowSmallTicks="true" Placement="Placement.After" LargeStep="20" SmallStep="10" Format="0000#"> </SliderTicks>
                <SliderTooltip IsVisible="true" Placement="TooltipPlacement.Before" Format="0000#"></SliderTooltip>
            </SfSlider>
        </div>
    </div>
</div>
@code{
    int Value1 = 30;
    int Value2 = 30;
    public int[] Value = { 20, 50 };
}
<style>
    .content-wrapper {
        width: 40%;
        margin: 0 auto;
        min-width: 185px;
    }

    .sliderwrap {
        margin-top: 40px;
    }

    .sliderwrap label {
        padding-bottom: 26px;
        font-size: 13px;
        font-weight: 500;
        margin-top: 15px;
    }

    .userselect {
        -webkit-user-select: none; /* Safari 3.1+ */
        -moz-user-select: none; /* Firefox 2+ */
        -ms-user-select: none; /* IE 10+ */
        user-select: none; /* Standard syntax */
    }
</style>
```

![Blazor Range Slider with NumericSlider](./../images/blazor-rangeslider-with-numeric.gif)