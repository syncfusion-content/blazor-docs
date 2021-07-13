# Ticks

The Ticks in Slider supports you to easily identify the current value/values of the Slider. It contains `SmallStep` and `LargeStep`. The value of the major ticks alone will be displayed in the slider. In order to enable/disable the small ticks, use the `ShowSmallTicks` property.

```csharp
@using Syncfusion.Blazor.Inputs

<SfSlider @bind-Value="@value">
    <SliderTicks Placement="Placement.After" ShowSmallTicks="true" LargeStep="20" SmallStep="10"></SliderTicks>
    <SliderTooltip IsVisible="true" ShowOn="TooltipShowOn.Always" Placement="TooltipPlacement.Before"></SliderTooltip>
</SfSlider>

@code {
    int value = 30;
}
```

![Blazor- Slider - Ticks](images/ticks.gif)

## Step

When the Slider is moved, it increases/decreases the value based on the step value. By default, the value is increased/decreased by 1. Use the `Step` property to change the increment step value.

```csharp
@using Syncfusion.Blazor.Inputs

<SfSlider Step="10" @bind-Value="@value">
   <SliderTooltip IsVisible="true" ShowOn="TooltipShowOn.Always" Placement="TooltipPlacement.Before"></SliderTooltip>
</SfSlider>

@code {
    int value = 30;
}
```

![Blazor- Slider - Step](./images/step.gif)

## Min and Max

Enables the minimum/starting and maximum/ending value of the Slider, by using the `Min` and `Max` property. By default, the minimum value is 1 and maximum value is 100. In the following sample the slider is rendered with the min value as 100 and max value as 1100.

```csharp
@using Syncfusion.Blazor.Inputs

<SfSlider @bind-Value ="@value" Min="100" Max="1100">
     <SliderTicks Placement="Placement.After" ShowSmallTicks="true" LargeStep="100" SmallStep="50"></SliderTicks>
    <SliderTooltip IsVisible="true" ShowOn="TooltipShowOn.Always" Placement="TooltipPlacement.Before"></SliderTooltip>
</SfSlider>

@code {
    int value = 300;
}
```

![Blazor- Slider - Min and Max](./images/MinMax.gif)
