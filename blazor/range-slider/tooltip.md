---
layout: post
title: Tooltip in Blazor Range Slider Component | Syncfusion
description: Checkout and learn here all about Tooltip in Syncfusion Blazor Range Slider component and much more.
platform: Blazor
control: Range Slider
documentation: ug
---

# Tooltip in Blazor Range Slider Component

The slider can display a tooltip that shows the current value when interacting with the control. Configure the tooltip position using the [`Placement`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SliderTooltip.html#Syncfusion_Blazor_Inputs_SliderTooltip_Placement) property. Also decides the tooltip display mode on a page, i.e., on hovering, focusing, or clicking on the Slider handle and it always remains/displays on the page.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfSlider Min="0" Max="100" @bind-Value="@value">
   <SliderTooltip IsVisible="true" ShowOn="TooltipShowOn.Always" Placement="TooltipPlacement.After"></SliderTooltip>
</SfSlider>

@code {
    int value = 30;
}
```

![Blazor Range Slider displaying a tooltip](images/blazor-rangeslider-tooltip.png)

## Buttons

Change the slider value using the [ShowButtons](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfSlider-1.html#Syncfusion_Blazor_Inputs_SfSlider_1_ShowButtons) property, which renders increment and decrement buttons. In a range slider, button clicks change the first handle by default. To change the other handle, move focus to it and then use the buttons.

N> After enabling slider buttons, pressing the Tab key moves focus to the handle, not the buttons.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfSlider @bind-Value="@value" ShowButtons="true" >
    <SliderTooltip IsVisible="true" ShowOn="TooltipShowOn.Always" Placement="TooltipPlacement.After"></SliderTooltip>
</SfSlider>

@code {
    int value = 30;
}
```

![Blazor Range Slider with buttons](images/blazor-rangeslider-buttons.png)