---
layout: post
title: Events in Blazor Circular Gauge Component | Syncfusion
description: Check out and learn how to configure and handle Events in the Syncfusion Blazor Circular Gauge component.
platform: Blazor
control: Circular Gauge
documentation: ug
---

# Events in Blazor Circular Gauge Component

## Using events in Circular Gauge component

In the following example, the event [OnDragMove](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.CircularGaugeEvents.html#Syncfusion_Blazor_CircularGauge_CircularGaugeEvents_OnDragMove) is bound to the circular gauge component. The handler `UpdatePointerValue` executes while the pointer is dragged and updates the displayed pointer value in the div element.

```cshtml

@using Syncfusion.Blazor.CircularGauge

<div style="width:250px">
    <div style="text-align: center">@pointerValue</div>
    <SfCircularGauge EnablePointerDrag="true" Height="250px" Width="250px">
        <CircularGaugeEvents OnDragMove="@UpdatePointerValue"></CircularGaugeEvents>
        <CircularGaugeAxes>
            <CircularGaugeAxis>
                <CircularGaugePointers>
                    <CircularGaugePointer Value="@pointerValue"></CircularGaugePointer>
                </CircularGaugePointers>
            </CircularGaugeAxis>
        </CircularGaugeAxes>
    </SfCircularGauge>
</div>

@code {
    private double pointerValue = 10;

    void UpdatePointerValue(IPointerDragEventArgs args)
    {
        pointerValue = args.CurrentValue;
    }
}

```

![Event Binding in Blazor Circular Gauge](./images/blazor-circulargauge-binding-events.png)

## Available events

### AnimationCompleted

Description: Triggers after the animation completes.

### AnnotationRendering

Description: Triggers before each annotation is rendered. The following arguments customize annotations.

|   Argument name      |   Description                               |
|----------------------|---------------------------------------------|
|   Content            |   Specifies the annotation content          |
|   TextStyle          |   Specifies the text style                  |
|   Name               |   Specifies the name of the event           |
|   Cancel             |   Specifies the event cancel status         |

### Loaded

Description: Triggers after the gauge component loads.

### OnDragEnd

Description: Triggers after pointer dragging ends.

|   Argument name      |   Description                              |
|----------------------|--------------------------------------------|
|   AxisIndex          |   Specifies the current axis index         |
|   CurrentValue       |   Specifies the current pointer value      |
|   PointerIndex       |   Specifies the current pointer index      |
|   Name               |   Specifies the name of the event          |

### OnDragMove

Description: Triggers while the pointer is being dragged.

|   Argument name      |   Description                              |
|----------------------|--------------------------------------------|
|   AxisIndex          |   Specifies the axis index                 |
|   CurrentValue       |   Specifies the current pointer value      |
|   PointerIndex       |   Specifies the current pointer index      |
|   PreviousValue      |   Specifies the previous pointer value     |
|   Name               |   Specifies the name of the event          |

### OnDragStart

Description: Triggers when pointer dragging starts.

|   Argument name      |   Description                              |
|----------------------|--------------------------------------------|
|   AxisIndex          |   Specifies the axis index                 |
|   CurrentValue       |   Specifies the current pointer value      |
|   PointerIndex       |   Specifies the current pointer index      |
|   Name               |   Specifies the name of the event          |

### OnGaugeMouseDown

Description: Triggers when the mouse button is pressed on the gauge.

|   Argument name      |   Description                                     |
|----------------------|---------------------------------------------------|
|   Target             |   Specifies the current mouse event target id     |
|   X                  |   Specifies the current mouse x location          |
|   Y                  |   Specifies the current mouse y location          |
|   Name               |   Specifies the name of the event                 |

### OnGaugeMouseLeave

Description: Triggers when the mouse pointer leaves the gauge.

|   Argument name      |   Description                                     |
|----------------------|---------------------------------------------------|
|   Target             |   Specifies the current mouse event target id     |
|   X                  |   Specifies the current mouse x location          |
|   Y                  |   Specifies the current mouse y location          |
|   Name               |   Specifies the name of the event                 |

### OnGaugeMouseMove

Description: Triggers when the mouse moves over the gauge.

|   Argument name      |   Description                                     |
|----------------------|---------------------------------------------------|
|   Target             |   Specifies the current mouse event target id     |
|   X                  |   Specifies the current mouse x location          |
|   Y                  |   Specifies the current mouse y location          |
|   Name               |   Specifies the name of the event                 |
|   Cancel             |   Specifies the event cancel status               |

### OnGaugeMouseUp

Description: Triggers when the mouse button is released on the gauge.

|   Argument name      |   Description                                     |
|----------------------|---------------------------------------------------|
|   Target             |   Specifies the current mouse event target id     |
|   X                  |   Specifies the current mouse x location          |
|   Y                  |   Specifies the current mouse y location          |
|   Name               |   Specifies the name of the event                 |

### OnLoad

Description: Triggers before the gauge is rendered. This is the first event triggered by the gauge.

### OnRadiusCalculate

Description: Triggers before the radius is calculated for the gauge. The following arguments can customize the radius.

|   Argument name      |   Description                                      |
|----------------------|----------------------------------------------------|
|   CurrentRadius      |   Specifies the current radius value               |
|   MidPoint           |   Specifies the midpoint of the gauge location     |
|   Name               |   Specifies the name of the event                  |
|   Cancel             |   Specifies the event cancel status                |

### Resizing

Description: Triggers when the gauge is resized.

|   Argument name      |   Description                               |
|----------------------|---------------------------------------------|
|   CurrentSize        |   Specifies the current size of the gauge   |
|   PreviousSize       |   Specifies the previous size of the gauge  |
|   Name               |   Specifies the name of the event           |

### TooltipRendering

Description: Triggers before the gauge tooltip is rendered.

|   Argument name      |   Description                                             |
|----------------------| ----------------------------------------------------------|
|   Content            |   Specifies the tooltip text                              |
|   Event              |   Specifies the mouse event arguments                     |
|   Location           |   Specifies the tooltip location                          |
|   AppendInBodyTag    |   Specifies whether the tooltip is appended to the body   |
|   Tooltip            |   Tooltip instance used to customize tooltip settings     |
|   Name               |   Specifies the name of the event                         |
|   Cancel             |   Specifies the event cancel status                       |
|   Axis               |   Specifies the axis                                      |
|   Range              |   Specifies the range                                     |
