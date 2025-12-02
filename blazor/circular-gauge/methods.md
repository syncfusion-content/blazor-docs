---
layout: post
title: Methods in Blazor Circular Gauge Component | Syncfusion
description: Checkout and learn here all about Methods in Syncfusion Blazor Circular Gauge component and much more.
platform: Blazor
control: Circular Gauge
documentation: ug
---

# Methods in Blazor Circular Gauge Component

The following methods are available in the Circular Gauge component.

## SetAnnotationValueAsync

To change the annotation content dynamically, use the [SetAnnotationValueAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.SfCircularGauge.html#methods) method in the Circular Gauge component. The following are the arguments for this method.

|   Argument name      |   Description                            |
|----------------------| -----------------------------------------|
|     axisIndex        |    Specifies the index of the axis where the annotation is to be placed.  |
|     annotationIndex  |    Specifies the index number of the annotation to be updated.        |
|     content          |    Specifies the text for the annotation to be updated.         |

```cshtml
@using Syncfusion.Blazor.CircularGauge

<button style="margin-left:34px" @onclick="ChangeAnnotationValue">Change annotation value</button>
<SfCircularGauge @ref="gauge" Width="250px" Height="250px">
    <CircularGaugeAxes>
        <CircularGaugeAxis>
            <CircularGaugePointers>
                <CircularGaugePointer Value="50"></CircularGaugePointer>
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

To change the pointer value dynamically, use the [SetPointerValueAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.SfCircularGauge.html#methods) method in the Circular Gauge component. The following are the arguments for this method.

|   Argument name      |   Description                            |
|----------------------| -----------------------------------------|
|     axis index       |    Specifies the index of the axis in which the pointer value is to be updated. |
|     pointerIndex     |    Specifies the index of the pointer to be updated.           |
|     value            |    Specifies the value of the pointer to be updated.           |

```cshtml
@using Syncfusion.Blazor.CircularGauge

<button style="margin-left:34px" @onclick="ChangePoinerValue">Change pointer value</button>
<SfCircularGauge @ref="gauge" Width="250px" Height="250px">
    <CircularGaugeAxes>
        <CircularGaugeAxis>
            <CircularGaugePointers>
                <CircularGaugePointer Value="50"></CircularGaugePointer>
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
{% previewsample "https://blazorplayground.syncfusion.com/embed/LXrqsVBwKfbNwfqv?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor Circular Gauge](./images/blazor-circulargauge.png)" %}

## SetRangeValue

To change the start and end of a range in axis, use the [SetRangeValue](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.SfCircularGauge.html#Syncfusion_Blazor_CircularGauge_SfCircularGauge_SetRangeValue_System_Int32_System_Int32_System_Double_System_Double_) method in the Circular Gauge component. The following are the arguments for this method.

|   Argument name      |   Description                            |
|----------------------| -----------------------------------------|
|     axis index       |    Specifies the index of the axis in which the range value is to be updated. |
|     rangeIndex       |    Specifies the index of the range to be updated. |
|     start            |    Specifies the start value of the range.         |
|     end              |    Specifies the end value of the range            |

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
{% previewsample "https://blazorplayground.syncfusion.com/embed/rjLUiBhcUpvhczFW?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## RefreshAsync

The [RefreshAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.SfCircularGauge.html#methods) method can be used to change the state of the component and render it again.

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
{% previewsample "https://blazorplayground.syncfusion.com/embed/hNrUMLrcAJPpcAFo?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}