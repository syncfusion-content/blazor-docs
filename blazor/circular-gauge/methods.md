---
layout: post
title: Methods in Blazor Circular Gauge Component | Syncfusion
description: Check out and learn about all the available Methods in the Syncfusion Blazor Circular Gauge component.
platform: Blazor
control: Circular Gauge
documentation: ug
---

# Methods in Blazor Circular Gauge Component

The Circular Gauge component exposes the following methods.

## SetAnnotationValueAsync

Use the [SetAnnotationValueAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.SfCircularGauge.html#methods) method to update annotation content dynamically. The following arguments are supported.

| Argument name   | Description |
|-----------------|-------------|
| axisIndex       | Index of the axis where the annotation is placed. |
| annotationIndex | Index of the annotation to update. |
| content         | Text content of the annotation to update. |

```cshtml

@using Syncfusion.Blazor.CircularGauge

<button style="margin-left:34px" @onclick="ChangeAnnotationValue">Change annotation value</button>
<SfCircularGauge @ref="gauge" Width="250px" Height="250px">
    <CircularGaugeAxes>
        <CircularGaugeAxis>
            <CircularGaugePointers>
                <CircularGaugePointer Value="50" />
            </CircularGaugePointers>
            <CircularGaugeAnnotations>
                <CircularGaugeAnnotation Angle="195" ZIndex="1" Content="Gauge">
                </CircularGaugeAnnotation>
            </CircularGaugeAnnotations>
        </CircularGaugeAxis>
    </CircularGaugeAxes>
</SfCircularGauge>

@code {
    SfCircularGauge gauge;

    public async Task ChangeAnnotationValue()
    {
        await gauge.SetAnnotationValueAsync(0, 0, "Circular Gauge");
    } 
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VZhgsBrwgTGlriiD?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## SetPointerValueAsync

Use the [SetPointerValueAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.SfCircularGauge.html#methods) method to update a pointer value dynamically. The following arguments are supported.

| Argument name | Description |
|---------------|-------------|
| axisIndex     | Index of the axis whose pointer value is updated. |
| pointerIndex  | Index of the pointer to update. |
| value         | Pointer value to set. |

```cshtml

@using Syncfusion.Blazor.CircularGauge

<button style="margin-left:34px" @onclick="ChangePoinerValue">Change pointer value</button>
<SfCircularGauge @ref="gauge" Width="250px" Height="250px">
    <CircularGaugeAxes>
        <CircularGaugeAxis>
            <CircularGaugePointers>
                <CircularGaugePointer Value="50" />
            </CircularGaugePointers>
        </CircularGaugeAxis>
    </CircularGaugeAxes>
</SfCircularGauge>

@code {
    SfCircularGauge gauge;

    public async Task ChangePoinerValue()
    {
        await gauge.SetPointerValueAsync(0, 0, 30);
    }
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LXrqsVBwKfbNwfqv?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor Circular Gauge](./images/blazor-circulargauge.png)

## SetRangeValue

Use the [SetRangeValue](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.SfCircularGauge.html#Syncfusion_Blazor_CircularGauge_SfCircularGauge_SetRangeValue_System_Int32_System_Int32_System_Double_System_Double_) method to update the start and end values of a range on an axis. The following arguments are supported.

| Argument name | Description |
|---------------|-------------|
| axisIndex     | Index of the axis whose range value is updated. |
| rangeIndex    | Index of the range to update. |
| start         | Start value of the range. |
| end           | End value of the range. |

```cshtml

@using Syncfusion.Blazor.CircularGauge

<button style="margin-left:34px" @onclick="ChangeRangeValue">Change range value</button>
<SfCircularGauge @ref="gauge" Width="250px" Height="250px">
    <CircularGaugeAxes>
        <CircularGaugeAxis>
            <CircularGaugeRanges>
                <CircularGaugeRange Start="40" End="80">
                </CircularGaugeRange>
            </CircularGaugeRanges>
            <CircularGaugePointers>
                <CircularGaugePointer Value="50" />
            </CircularGaugePointers>
        </CircularGaugeAxis>
    </CircularGaugeAxes>
</SfCircularGauge>

@code {
    SfCircularGauge gauge;

    public async Task ChangeRangeValue()
    {
        gauge.SetRangeValue(0, 0, 10, 50);
        await gauge.RefreshAsync();
    }
}

 ```
{% previewsample "https://blazorplayground.syncfusion.com/embed/rNreiNZuKSczWeEz?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## RefreshAsync

The [RefreshAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.SfCircularGauge.html#methods) method re-renders the component to reflect state changes.

```cshtml

@using Syncfusion.Blazor.CircularGauge

<button style="margin-left:34px" @onclick="RefreshAsync">Refresh</button>
<SfCircularGauge @ref="gauge" Width="250px" Height="250px">
    <CircularGaugeAxes>
        <CircularGaugeAxis>
            <CircularGaugeRanges>
                <CircularGaugeRange Start="40" End="80">
                </CircularGaugeRange>
            </CircularGaugeRanges>
            <CircularGaugePointers>
                <CircularGaugePointer Value="50" />
            </CircularGaugePointers>
        </CircularGaugeAxis>
    </CircularGaugeAxes>
</SfCircularGauge>

@code {
    SfCircularGauge gauge;

    public async Task RefreshAsync()
    {
        await gauge.RefreshAsync();
    }
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BXBysXjOUIuxUQbM?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}
