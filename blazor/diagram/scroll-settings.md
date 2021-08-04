---
layout: post
title: Scroll Settings in Blazor Diagram Component | Syncfusion
description: Checkout and learn here all about Scroll Settings in Syncfusion Blazor Diagram component and much more.
platform: Blazor
control: Diagram
documentation: ug
---

# Scroll Settings in Blazor Diagram Component

The diagram can be scrolled by using the vertical and horizontal ScrollBars. In addition to the ScrollBars, mousewheel can be used to scroll the diagram. Diagram’s [ScrollSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.SfDiagram.html#Syncfusion_Blazor_Diagrams_SfDiagram_ScrollSettings) enable you to read the current scroll status, view port size, current zoom and zoom factor. It also allows you to scroll the diagram programmatically.

## Get current scroll status

Scroll settings allow you to read the scroll status, [ViewPortWidth](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.DiagramScrollSettings.html#Syncfusion_Blazor_Diagrams_DiagramScrollSettings_ViewPortWidth), [ViewPortHeight](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.DiagramScrollSettings.html#Syncfusion_Blazor_Diagrams_DiagramScrollSettings_ViewPortHeight), and [CurrentZoom](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.DiagramScrollSettings.html#Syncfusion_Blazor_Diagrams_DiagramScrollSettings_CurrentZoom) with a set of properties. To explore those properties, see [Scroll Settings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.SfDiagram.html#Syncfusion_Blazor_Diagrams_SfDiagram_ScrollSettings).

## Define scroll status

Diagram allows you to pan the diagram before loading, so that any desired region of a large diagram is made to view. You can programmatically pan the diagram with the [HorizontalOffset](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.DiagramScrollSettings.html#Syncfusion_Blazor_Diagrams_DiagramScrollSettings_HorizontalOffset) and [VerticalOffset](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.DiagramScrollSettings.html#Syncfusion_Blazor_Diagrams_DiagramScrollSettings_VerticalOffset) properties of scroll settings. The following code illustrates how to set pan the diagram programmatically.

In the following example, the vertical scroll bar is scrolled down by 50px and horizontal scroll bar is scrolled to right by 100px.

```cshtml
@using Syncfusion.Blazor.Diagrams

<SfDiagram Height="600px">
    @* Sets the ScrollSettings for the diagram *@
    <DiagramScrollSettings HorizontalOffset="100" VerticalOffset="50">
    </DiagramScrollSettings>
</SfDiagram>
```

## Update scroll status

You can programmatically change the scroll offsets at runtime by using the server-side method update. The following code illustrates how to change the scroll offsets and zoom factor at runtime.

```cshtml
@using Syncfusion.Blazor.Diagrams

<SfDiagram Height="600px">
    @* Sets the ScrollSettings for the diagram *@
    <DiagramScrollSettings HorizontalOffset="@horizontalOffset" VerticalOffset="@verticalOffset">
    </DiagramScrollSettings>
</SfDiagram>

@code{
    public double horizontalOffset { get; set; } = 100;
    public double verticalOffset { get; set; } = 100;

    public void updateScrollValues()
    {
        //Update scroll settings
        verticalOffset = 400;
        horizontalOffset = 200;
    }
}

```

## Autoscroll

Autoscroll feature automatically scrolls the diagram, whenever the node or connector is moved beyond the boundary of the diagram. So that, it is always visible during dragging, resizing, and multiple selection operations. Autoscroll is automatically triggered when any one of the following is done towards the edges of the diagram.

* Node dragging, resizing
* Connection editing
* Rubber band selection
* Label dragging

The Autoscroll behavior in your diagram can be enabled/disabled by using the [CanAutoscroll](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.DiagramScrollSettings.html#Syncfusion_Blazor_Diagrams_DiagramScrollSettings_CanAutoScroll) property of the diagram.

## Autoscroll border

The Autoscroll border is used to specify the maximum distance between the object and diagram edge to trigger Autoscroll. The default value is set as 15 for all sides (left, right, top, and bottom) and it can be changed by using the [AutoScrollMargin](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.DiagramScrollSettings.html#Syncfusion_Blazor_Diagrams_DiagramScrollSettings_AutoScrollBorder) property of scroll settings. The following code example illustrates how to set Autoscroll margin.

```cshtml
@using Syncfusion.Blazor.Diagrams

<SfDiagram Height="600px">
    @* Sets the ScrollSettings for the diagram *@
    <DiagramScrollSettings HorizontalOffset="100" VerticalOffset="50">
        @* Sets the Auto Scroll border for the diagram *@
        <AutoScrollMargin Left="15" Bottom="15" Right="15" Top="15"></AutoScrollMargin>
    </DiagramScrollSettings>
</SfDiagram>
```

## Scroll limit

The scroll limit allows you to define the scrollable region of the diagram. It includes the following options:

* Allows to scroll in all directions without any restriction.
* Allows to scroll within the diagram content.
* Allows to scroll within the specified scrollable area.
* The [ScrollLimit](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.DiagramScrollSettings.html#Syncfusion_Blazor_Diagrams_DiagramScrollSettings_ScrollLimit) property of scroll settings helps to limit the scrolling.

The ScrollSettings [ScrollableArea](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.DiagramScrollSettings.html#Syncfusion_Blazor_Diagrams_DiagramScrollSettings_ScrollableArea) allow to extend the scrollable region that is based on the scroll limit.
The following code example illustrates how to specify the scroll limit.

```cshtml
@using Syncfusion.Blazor.Diagrams

<SfDiagram Height="600px">
    @* Sets the ScrollLimit of scroll settings *@
    <DiagramScrollSettings HorizontalOffset="100" VerticalOffset="50" ScrollLimit="ScrollLimit.Infinity">
    </DiagramScrollSettings>
</SfDiagram>
```

## Scroll Padding

The scroll padding allows you to extend the scrollable region that is based on the scroll limit. The following code example illustrates how to set scroll padding to diagram region.

```cshtml
@using Syncfusion.Blazor.Diagrams

<SfDiagram Height="600px">
    @* Sets the ScrollSettings for the diagram *@
    <DiagramScrollSettings HorizontalOffset="100" VerticalOffset="50">
        @* Sets the Padding for the diagram Scroll*@
        <AutoScrollPadding Right="50" Bottom="50"></AutoScrollPadding>
    </DiagramScrollSettings>
</SfDiagram>
```

## Scrollable Area

Scrolling beyond any particular rectangular area can be restricted by using the [ScrollableArea](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.DiagramScrollSettings.html#Syncfusion_Blazor_Diagrams_DiagramScrollSettings_ScrollableArea) property of scroll settings. To restrict scrolling beyond any custom region, set the [ScrollLimit](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.DiagramScrollSettings.html#Syncfusion_Blazor_Diagrams_DiagramScrollSettings_ScrollLimit) as “limited”. The following code example illustrates how to customize scrollable area.

```cshtml
@using Syncfusion.Blazor.Diagrams

<SfDiagram Height="600px">
    @* Sets the scrollable Area *@
    <DiagramScrollSettings HorizontalOffset="100" VerticalOffset="50" ScrollLimit="ScrollLimit.Infinity" ScrollableArea="@scrollArea">
    </DiagramScrollSettings>
</SfDiagram>

@code{
    public class Area {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }
    // Sets the values of scroll area
    object scrollArea = new Area() { X = 0, Y = 0, Width = 500, Height = 500 };
}
```

## UpdateViewport

The [UpdateViewPort](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.SfDiagram.html#Syncfusion_Blazor_Diagrams_SfDiagram_UpdateViewPort) method is used to update the diagram page and view size at runtime.
