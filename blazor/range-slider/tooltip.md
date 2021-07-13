---
layout: post
title: Tooltip in Blazor Range Slider Component | Syncfusion 
description: Learn about Tooltip in Blazor Range Slider component of Syncfusion, and more details.
platform: Blazor
control: Range Slider
documentation: ug
---

# Tooltip

The Slider displays the tooltip to indicate the current value by clicking the Slider bar or drag
the Slider handle. The Tooltip position can be customized by using the `Placement` property. Also decides the tooltip display mode on a page, i.e., on hovering, focusing, or clicking on the Slider handle and it always remains/displays on the page.

```csharp
@using Syncfusion.Blazor.Inputs

<SfSlider Min="0" Max="100" @bind-Value="@value">
   <SliderTooltip IsVisible="true" ShowOn="TooltipShowOn.Always" Placement="TooltipPlacement.After"></SliderTooltip>
</SfSlider>

@code {
    int value = 30;
}
```

![Blazor - Slider - Tooltip](images/slider-tooltip.png)

## Buttons

The Slider value can be changed by using the Increase and Decrease buttons. In Range Slider, by
default the first handle value will be changed while clicking the button. Change the handle focus and
press the button to change the last focused handle value.

> After enabling the slider buttons if the 'Tab' key is pressed, the focus goes to the handle
and not to the button.

```csharp
@using Syncfusion.Blazor.Inputs

<SfSlider @bind-Value="@value" ShowButtons="true" >
    <SliderTooltip IsVisible="true" ShowOn="TooltipShowOn.Always" Placement="TooltipPlacement.After"></SliderTooltip>
</SfSlider>

@code {
    int value = 30;
}
```

![Blazor - Slider - Buttons](images/slider-buttons.png)
