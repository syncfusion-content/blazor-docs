---
layout: post
title: Events in Blazor Linear Gauge Component | Syncfusion
description: Check out and learn about all available events and event handling in the Syncfusion Blazor Linear Gauge component.
platform: Blazor
control: Linear Gauge
documentation: ug
---

# Events in Blazor Linear Gauge Component

This section lists the events raised by the Linear Gauge during corresponding operations. Wire events to the Linear Gauge by using the [LinearGaugeEvents](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugeEvents.html).

## AnnotationRendering

Before an annotation is rendered in the Linear Gauge, the [AnnotationRendering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugeEvents.html#Syncfusion_Blazor_LinearGauge_LinearGaugeEvents_AnnotationRendering) event is triggered. For details about the event arguments, see [AnnotationRenderEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.AnnotationRenderEventArgs.html#properties).

```cshtml

@using Syncfusion.Blazor.LinearGauge

<SfLinearGauge>
    <LinearGaugeEvents AnnotationRendering="AnnotationRender"></LinearGaugeEvents>
    <LinearGaugeAnnotations>
        <LinearGaugeAnnotation AxisValue="0" ZIndex="1" Content="40">
        </LinearGaugeAnnotation>
    </LinearGaugeAnnotations>
    <LinearGaugeAxes>
        <LinearGaugeAxis>
            <LinearGaugePointers>
                <LinearGaugePointer PointerValue="40"></LinearGaugePointer>
            </LinearGaugePointers>
        </LinearGaugeAxis>
    </LinearGaugeAxes>
</SfLinearGauge>

@code {
    public void AnnotationRender(AnnotationRenderEventArgs args)
    {
        // Code here
    }
}

```

## AxisLabelRendering

Before each axis label is rendered in the Linear Gauge, the [AxisLabelRendering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugeEvents.html#Syncfusion_Blazor_LinearGauge_LinearGaugeEvents_AxisLabelRendering) event is triggered. For details about the event arguments, see [AxisLabelRenderEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.AxisLabelRenderEventArgs.html#properties).

```cshtml

@using Syncfusion.Blazor.LinearGauge

<SfLinearGauge>
    <LinearGaugeEvents AxisLabelRendering="LabelRender"></LinearGaugeEvents>
    <LinearGaugeAxes>
        <LinearGaugeAxis>
        </LinearGaugeAxis>
    </LinearGaugeAxes>
</SfLinearGauge>

@code {
    public void LabelRender(AxisLabelRenderEventArgs args)
    {
        // Code here
    }
}

```

## Loaded

After the Linear Gauge is loaded, the [Loaded](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugeEvents.html#Syncfusion_Blazor_LinearGauge_LinearGaugeEvents_Loaded) event is triggered. For details about the event arguments, see [LoadedEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LoadedEventArgs.html).

```cshtml

@using Syncfusion.Blazor.LinearGauge

<SfLinearGauge>
    <LinearGaugeEvents Loaded="Loaded"></LinearGaugeEvents>
    <LinearGaugeAxes>
        <LinearGaugeAxis>
        </LinearGaugeAxis>
    </LinearGaugeAxes>
</SfLinearGauge>

@code {
    public void Loaded(LoadedEventArgs args)
    {
        // Code here
    }
}

```

## OnDragEnd

The [OnDragEnd](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugeEvents.html#Syncfusion_Blazor_LinearGauge_LinearGaugeEvents_OnDragEnd) event is triggered after pointer dragging completes. For details about the event arguments, see [PointerDragEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.PointerDragEventArgs.html#properties).

```cshtml

@using Syncfusion.Blazor.LinearGauge

<SfLinearGauge>
    <LinearGaugeEvents OnDragEnd="DragEnd"></LinearGaugeEvents>
    <LinearGaugeAxes>
        <LinearGaugeAxis>
            <LinearGaugePointers>
                <LinearGaugePointer PointerValue="40" EnableDrag="true"></LinearGaugePointer>
            </LinearGaugePointers>
        </LinearGaugeAxis>
    </LinearGaugeAxes>
</SfLinearGauge>

@code {
    public void DragEnd(PointerDragEventArgs args)
    {
        // Code here
    }
}

```

## OnDragStart

When pointer dragging begins, the [OnDragStart](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugeEvents.html#Syncfusion_Blazor_LinearGauge_LinearGaugeEvents_OnDragStart) event is triggered. For details about the event arguments, see [PointerDragEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.PointerDragEventArgs.html#properties).

```cshtml

@using Syncfusion.Blazor.LinearGauge

<SfLinearGauge>
    <LinearGaugeEvents OnDragStart="DragStart"></LinearGaugeEvents>
    <LinearGaugeAxes>
        <LinearGaugeAxis>
            <LinearGaugePointers>
                <LinearGaugePointer PointerValue="40" EnableDrag="true"></LinearGaugePointer>
            </LinearGaugePointers>
        </LinearGaugeAxis>
    </LinearGaugeAxes>
</SfLinearGauge>

@code {
    public void DragStart(PointerDragEventArgs args)
    {
        // Code here
    }
}

```

## OnGaugeMouseDown

When a mouse button is pressed over the gauge, the [OnGaugeMouseDown](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugeEvents.html#Syncfusion_Blazor_LinearGauge_LinearGaugeEvents_OnGaugeMouseDown) event is triggered. For details about the event arguments, see [MouseEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.MouseEventArgs.html#properties).

```cshtml

@using Syncfusion.Blazor.LinearGauge

<SfLinearGauge>
    <LinearGaugeEvents OnGaugeMouseDown="MouseDown"></LinearGaugeEvents>
    <LinearGaugeAxes>
        <LinearGaugeAxis>
        </LinearGaugeAxis>
    </LinearGaugeAxes>
</SfLinearGauge>

@code {
    public void MouseDown(Syncfusion.Blazor.LinearGauge.MouseEventArgs args)
    {
        //Code here
    }
}

```

## OnGaugeMouseLeave

When the mouse pointer leaves the gauge, the [OnGaugeMouseLeave](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugeEvents.html#Syncfusion_Blazor_LinearGauge_LinearGaugeEvents_OnGaugeMouseLeave) event is triggered. For details about the event arguments, see [MouseEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.MouseEventArgs.html#properties).

```cshtml

@using Syncfusion.Blazor.LinearGauge

<SfLinearGauge>
    <LinearGaugeEvents OnGaugeMouseLeave="MouseLeave"></LinearGaugeEvents>
    <LinearGaugeAxes>
        <LinearGaugeAxis>
        </LinearGaugeAxis>
    </LinearGaugeAxes>
</SfLinearGauge>

@code {
    public void MouseLeave(Syncfusion.Blazor.LinearGauge.MouseEventArgs args)
    {
        //Code here
    }
}

```

## OnGaugeMouseUp

When the mouse button is released over the Linear Gauge, the [OnGaugeMouseUp](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugeEvents.html#Syncfusion_Blazor_LinearGauge_LinearGaugeEvents_OnGaugeMouseUp) event is triggered. For details about the event arguments, see [MouseEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.MouseEventArgs.html#properties).

```cshtml

@using Syncfusion.Blazor.LinearGauge

<SfLinearGauge>
    <LinearGaugeEvents OnGaugeMouseUp="MouseUp"></LinearGaugeEvents>
    <LinearGaugeAxes>
        <LinearGaugeAxis>
        </LinearGaugeAxis>
    </LinearGaugeAxes>
</SfLinearGauge>

@code {
    public void MouseUp(Syncfusion.Blazor.LinearGauge.MouseEventArgs args)
    {
        //Code here
    }
}

```

## OnLoad

Before the Linear Gauge is loaded, the [OnLoad](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugeEvents.html#Syncfusion_Blazor_LinearGauge_LinearGaugeEvents_OnLoad) event is triggered. For details about the event arguments, see [LoadEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LoadEventArgs.html).

```cshtml

@using Syncfusion.Blazor.LinearGauge

<SfLinearGauge>
    <LinearGaugeEvents OnLoad="Load"></LinearGaugeEvents>
    <LinearGaugeAxes>
        <LinearGaugeAxis>
        </LinearGaugeAxis>
    </LinearGaugeAxes>
</SfLinearGauge>

@code {
    public void Load(LoadEventArgs args)
    {
        // Code here
    }
}

```

## OnPrint

The [OnPrint](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugeEvents.html#Syncfusion_Blazor_LinearGauge_LinearGaugeEvents_OnPrint) event is triggered before printing begins. For details about the event arguments, see [PrintEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.PrintEventArgs.html).

```cshtml

@using Syncfusion.Blazor.LinearGauge

<button @onclick="PrintGauge">Print</button>

<SfLinearGauge @ref="gauge" AllowPrint="true">
    <LinearGaugeEvents OnPrint="Print"></LinearGaugeEvents>
    <LinearGaugeAxes>
        <LinearGaugeAxis Minimum="0" Maximum="100">
            <LinearGaugeMajorTicks Interval="20"></LinearGaugeMajorTicks>
            <LinearGaugeMinorTicks Interval="10"></LinearGaugeMinorTicks>
        </LinearGaugeAxis>
    </LinearGaugeAxes>
</SfLinearGauge>

@code {
    SfLinearGauge gauge;
    public void PrintGauge()
    {
        this.gauge.Print();
    }

    public void Print(PrintEventArgs args)
    {
        // Code here
    }
}

```

## Resizing

During window resize, the [Resizing](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugeEvents.html#Syncfusion_Blazor_LinearGauge_LinearGaugeEvents_Resizing) event is triggered. For details about the event arguments, see [ResizeEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.ResizeEventArgs.html#properties).

```cshtml

@using Syncfusion.Blazor.LinearGauge

<SfLinearGauge Width="100%">
    <LinearGaugeEvents Resizing="Resize"></LinearGaugeEvents>
    <LinearGaugeAxes>
        <LinearGaugeAxis>
        </LinearGaugeAxis>
    </LinearGaugeAxes>
</SfLinearGauge>

@code {
    public void Resize(ResizeEventArgs args)
    {
        // Code here
    }
}

```

## TooltipRendering

The [TooltipRendering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugeEvents.html#Syncfusion_Blazor_LinearGauge_LinearGaugeEvents_TooltipRendering) event is triggered before a tooltip is rendered. For details about the event arguments, see [TooltipRenderEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.TooltipRenderEventArgs.html#properties).

```cshtml

@using Syncfusion.Blazor.LinearGauge

<SfLinearGauge Width="100%">
    <LinearGaugeEvents TooltipRendering="TooltipRender"></LinearGaugeEvents>
    <LinearGaugeTooltipSettings Enable="true"></LinearGaugeTooltipSettings>
    <LinearGaugeAxes>
        <LinearGaugeAxis>
            <LinearGaugePointers>
                <LinearGaugePointer PointerValue="50"></LinearGaugePointer>
            </LinearGaugePointers>
        </LinearGaugeAxis>
    </LinearGaugeAxes>
</SfLinearGauge>

@code {
    public void TooltipRender(TooltipRenderEventArgs args)
    {
        // Code here
    }
}

```

## ValueChange

The [ValueChange](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugeEvents.html#Syncfusion_Blazor_LinearGauge_LinearGaugeEvents_ValueChange) event is triggered when the pointer is dragged from one value to another. For details about the event arguments, see [ValueChangeEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.ValueChangeEventArgs.html#properties).

```cshtml

@using Syncfusion.Blazor.LinearGauge

<div style="width:250px">
    <SfLinearGauge Height="250px">
        <LinearGaugeEvents ValueChange="@UpdatePointerValue"></LinearGaugeEvents>
        <LinearGaugeAxes>
            <LinearGaugeAxis>
                <LinearGaugePointers>
                    <LinearGaugePointer EnableDrag="true" PointerValue="10">
                    </LinearGaugePointer>
                </LinearGaugePointers>
            </LinearGaugeAxis>
        </LinearGaugeAxes>
    </SfLinearGauge>
</div>

@code {
    private double pointerValue = 10;

    public void UpdatePointerValue(ValueChangeEventArgs args)
    {
        pointerValue = args.Value;
    }
}

```

![Blazor Linear Gauge with Binding Events](./images/blazor-linear-gauge-events.png)
