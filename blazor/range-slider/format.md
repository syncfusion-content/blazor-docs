---
layout: post
title: Formatting in Blazor Range Slider Component | Syncfusion
description: Checkout and learn here all about Formatting in Syncfusion Blazor Range Slider component and much more.
platform: Blazor
control: Range Slider
documentation: ug
---

# Formatting in Blazor Range Slider Component

The `Format` feature used to customize the units of Slider values to desired format. The formatted values will also be applied to the ARIA attributes of the slider. There are two ways of achieving formatting in slider.

> Use the `Format` API of slider which utilizes our Internationalization to format values.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfSlider @bind-Value="@CurrencyValue">
    <SliderTooltip IsVisible="true" ShowOn="TooltipShowOn.Always" Format="C2" Placement="TooltipPlacement.Before"></SliderTooltip>
    <SliderTicks Placement="Placement.Before" Format="C2" ShowSmallTicks="true" LargeStep="20" SmallStep="10"></SliderTicks>
</SfSlider>

@code {
    int CurrencyValue = 30;
}
```

![Formating in Blazor RangeSlider](images/blazor-rangeslider-format.gif)

## Using format API

Slider provides different predefined formatting styles like Numeric (N), Percentage (P), Currency (C) and # specifiers. In this below example we have formatted the ticks and tooltip values into percentage.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfSlider Min="1" Max="10" @bind-Value="@PercentageValue">
    <SliderTicks Placement="Placement.After" Format="P0" ShowSmallTicks="true" LargeStep="2" SmallStep="1"></SliderTicks>
    <SliderTooltip IsVisible="true" ShowOn="TooltipShowOn.Always" Format="P0" Placement="TooltipPlacement.Before"></SliderTooltip>
</SfSlider>

@code {
    int PercentageValue = 3;
}

```

![Blazor RangeSlider Format API](images/blazor-rangeslider-format-api.gif)