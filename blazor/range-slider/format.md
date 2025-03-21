---
layout: post
title: Formatting in Blazor Range Slider Component | Syncfusion
description: Checkout and learn here all about formatting in Syncfusion Blazor Range Slider component and much more.
platform: Blazor
control: Range Slider
documentation: ug
---

# Formatting in Blazor Range Slider Component

The [`Format`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SliderTicks.html#Syncfusion_Blazor_Inputs_SliderTicks_Format) feature used to customize the units of Slider values to desired format. The formatted values will also be applied to the ARIA attributes of the slider. There are two ways of achieving formatting in slider.

* Use the `Format` API of slider which utilizes our **Internationalization** to format values.

* Customize using the events namely [`TicksRendering`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SliderEvents-1.html#Syncfusion_Blazor_Inputs_SliderEvents_1_TicksRendering) and [`OnTooltipChange`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SliderEvents-1.html#Syncfusion_Blazor_Inputs_SliderEvents_1_OnTooltipChange).

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

Slider provides different predefined formatting styles like Numeric (N), Percentage (P), Currency (C) and # specifiers.

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

![Blazor Range Slider Format API](images/blazor-rangeslider-format-api.gif)

## Using Events

For custom formatting use event handlers like [`TicksRendering`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SliderEvents-1.html#Syncfusion_Blazor_Inputs_SliderEvents_1_TicksRendering) and [`OnTooltipChange`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SliderEvents-1.html#Syncfusion_Blazor_Inputs_SliderEvents_1_OnTooltipChange). Below is an example where slider values are formatted into weekdays and corresponding tooltip values are formatted as days of the week.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfSlider id='default' Min="0" Max="6" @bind-Value="@Value">
    <SliderEvents TValue="int" OnTooltipChange="@TooltipChange" TicksRendering="@TickesRendering"></SliderEvents>
    <SliderTicks Placement="Placement.After" LargeStep="1"></SliderTicks>
    <SliderTooltip Placement="TooltipPlacement.Before" IsVisible="true"></SliderTooltip>
</SfSlider>

@code{

    private int Value = 2;

    public void TickesRendering(SliderTickEventArgs args)
    {
        string[] daysArr = { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };

        args.Text = daysArr[int.Parse(args.Value.ToString())];
    }

    public void TooltipChange(SliderTooltipEventArgs<int> args)
    {
        args.Text = "Day " + (args.Value + 1).ToString();
    }
}

```

![Blazor Range Slider Events](images/blazor-rangeslider-format-using-events.png)