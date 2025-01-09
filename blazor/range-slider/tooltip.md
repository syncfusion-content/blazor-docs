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

![Blazor RangeSlider displays Tooltip](images/blazor-rangeslider-tooltip.png)

## Buttons

The Slider can be equipped with increase and decrease buttons to change its value. This functionality is enabled by setting the [`ShowButtons`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfSlider-1.html#Syncfusion_Blazor_Inputs_SfSlider_1_ShowButtons) property to true. In a Range Slider, clicking these buttons will, by default, adjust the value of the first handle. To change the value of a different handle, first focus on that handle and then use the buttons.

N> After enabling the slider buttons if the 'Tab' key is pressed, the focus goes to the handle and not to the button.

Here's an example of how to implement buttons in a Slider:

```cshtml
@using Syncfusion.Blazor.Inputs

<SfSlider @bind-Value="@value" ShowButtons="true" >
    <SliderTooltip IsVisible="true" ShowOn="TooltipShowOn.Always" Placement="TooltipPlacement.After"></SliderTooltip>
</SfSlider>

@code {
    int value = 30;
}
```

![Blazor RangeSlider with Buttons](images/blazor-rangeslider-buttons.png)