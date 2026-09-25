---
layout: post
title: Tooltip in Blazor Range Slider | Syncfusion
description: Show and position tooltips in Blazor Range Slider using Placement, ShowOn, and IsVisible for clear, customizable value feedback.
platform: Blazor
control: Range Slider
documentation: ug
---

# Tooltip in Blazor Range Slider


The slider can display a tooltip that shows the current value when interacting with the control. The tooltip position is configured using the [`Placement`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SliderTooltip.html#Syncfusion_Blazor_Inputs_SliderTooltip_Placement) property.


The [`ShowOn`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SliderTooltip.html#Syncfusion_Blazor_Inputs_SliderTooltip_ShowOn) property controls how the tooltip responds to user interactions based on the device type:


- `Auto`: Displays the tooltip automatically on both focus and click interactions.
- `Focus`: Displays the tooltip only when the slider handle receives focus.
- `Hover`: Displays the tooltip when hovering over the slider handle.
- `Always`: Keeps the tooltip continuously visible at all times.

The Auto mode is recommended for most scenarios, as it adapts to both desktop and touch devices for optimal usability.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfSlider Min="0" Max="100" @bind-Value="@value">
   <SliderTooltip IsVisible="true" ShowOn="TooltipShowOn.Always" Placement="TooltipPlacement.After"></SliderTooltip>
</SfSlider>

@code {
    int value = 30;
}
```

![Blazor Range Slider displaying a tooltip](images/blazor-rangeslider-tooltip.webp)

## Buttons

Use the [ShowButtons](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfSlider-1.html#Syncfusion_Blazor_Inputs_SfSlider_1_ShowButtons) property to render increment and decrement buttons next to the slider. In a range slider, button clicks change the first handle by default. To change the other handle, move focus to it and then use the buttons.

N> After enabling slider buttons, pressing the Tab key moves focus to the handle, not the buttons.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfSlider TValue="int[]" Min="0" Max="100" Value="@Value" Type="SliderType.Range" ShowButtons="true">
     <SliderTooltip IsVisible="true" ShowOn="TooltipShowOn.Always" Placement="TooltipPlacement.After"></SliderTooltip>
</SfSlider>

@code{
   public int[] Value = { 30, 70 };
}
```

![Blazor Range Slider with buttons](images/blazor-rangeslider-buttons.webp)