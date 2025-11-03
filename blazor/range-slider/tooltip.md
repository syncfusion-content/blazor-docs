---
layout: post
title: Tooltip in Blazor Range Slider Component | Syncfusion
description: Checkout and learn here all about Tooltip in Syncfusion Blazor Range Slider component and much more.
platform: Blazor
control: Range Slider
documentation: ug
---

# Tooltip in Blazor Range Slider Component

The Slider displays the tooltip to indicate the current value by clicking the Slider bar or drag the Slider handle. The Tooltip position can be customized by using the [`Placement`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SliderTooltip.html#Syncfusion_Blazor_Inputs_SliderTooltip_Placement) property. Also decides the tooltip display mode on a page, i.e., on hovering, focusing, or clicking on the Slider handle and it always remains/displays on the page.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfSlider Min="0" Max="100" @bind-Value="@value">
   <SliderTooltip IsVisible="true" ShowOn="TooltipShowOn.Always" Placement="TooltipPlacement.After"></SliderTooltip>
</SfSlider>

@code {
    int value = 30;
}
```

![Blazor Range Slider displays Tooltip](images/blazor-rangeslider-tooltip.png)

## Buttons

The Slider value can be changed by using the [**ShowButtons**](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfSlider-1.html#Syncfusion_Blazor_Inputs_SfSlider_1_ShowButtons) property which can be used to Increase and Decrease the values. In Range Slider, by default the first handle value will be changed while clicking the button. Change the handle focus and press the button to change the last focused handle value.

N> After enabling the slider buttons if the 'Tab' key is pressed, the focus goes to the handle and not to the button.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfSlider @bind-Value="@value" ShowButtons="true" >
    <SliderTooltip IsVisible="true" ShowOn="TooltipShowOn.Always" Placement="TooltipPlacement.After"></SliderTooltip>
</SfSlider>

@code {
    int value = 30;
}
```

![Blazor Range Slider with Buttons](images/blazor-rangeslider-buttons.png)