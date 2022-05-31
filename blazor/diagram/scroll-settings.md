---
layout: post
title: Scroll Settings in Blazor Diagram Component | Syncfusion
description: Checkout and learn here all about Scroll Settings in Syncfusion Blazor Diagram component and much more.
platform: Blazor
control: Diagram Component
documentation: ug
---

# Scroll Settings in Blazor Diagram Component

The diagram can be scrolled by using the vertical and horizontal scrollbars. In addition to the scrollbars, the mouse wheel can be used to scroll the diagram. The Diagram’s [ScrollSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.ScrollSettings.html) allows you to read the current scroll status, current zoom and zoom factor values. 

## Get current scroll status

Scroll settings allow you to read the scroll status, [CurrentZoom](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.ScrollSettings.html#Syncfusion_Blazor_Diagram_ScrollSettings_CurrentZoom) with a set of properties. To explore those properties, see [Scroll Settings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.ScrollSettings.html).

* CurrentZoom: Specifies the zooming level of the diagram page.
* MinZoom: Specifies the minimum zooming level of the diagram page.
* MaxZoom: Specifies the maximum zooming level of the diagram page.
* HorizontalOffset: Specifies the horizontal origin or left side origin of the view port of the diagram page.
* VerticalOffset: Specifies the vertical origin or top side of the view port of the diagram page.

## Define scroll status

Diagram allows you to pan the diagram before loading, so that any desired region of a large diagram can be viewed. You can programmatically pan the diagram with the [HorizontalOffset](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.ScrollSettings.html#Syncfusion_Blazor_Diagram_ScrollSettings_HorizontalOffset) and [VerticalOffset](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.ScrollSettings.html#Syncfusion_Blazor_Diagram_ScrollSettings_VerticalOffset) properties of scroll settings. The following code illustrates how to pan the diagram programmatically.

In the following example, the vertical scroll bar is scrolled down by 50px and the horizontal scroll bar is scrolled to right by 100px.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px">
    @* Sets the ScrollSettings for the diagram *@
    <ScrollSettings HorizontalOffset="100" VerticalOffset="50">
    </ScrollSettings>
</SfDiagramComponent>
```

## Update scroll status

You can programmatically change the scroll offsets at runtime by using the external button click. The following code illustrates how to change the scroll offsets at runtime.

```cshtml
@using Syncfusion.Blazor.Diagram

<input type="button" @onclick="updateScrollValues"/>
<SfDiagramComponent Height="600px">
    @* Sets the ScrollSettings for the diagram *@
    <ScrollSettings HorizontalOffset="@horizontalOffset" VerticalOffset="@verticalOffset">
    </ScrollSettings>
</SfDiagramComponent>

@code{
    public double horizontalOffset { get; set; } = 100;
    public double verticalOffset { get; set; } = 100;

    public void updateScrollValues()
    {
        //Update scroll settings.
        verticalOffset = 400;
        horizontalOffset = 200;
    }
}
```

## Scroll limit

The scroll limit allows you to define the scrollable region of the Diagram while scrolling the page with the mouse. The [ScrollLimit](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.ScrollSettings.html#Syncfusion_Blazor_Diagram_ScrollSettings_ScrollLimit) property of scroll settings helps to limit the scrolling area. It includes the following options:

* Infinity: Allows you to scroll in any directions without being restricted.
* Diagram: Allows you to scroll within the Diagram content.
* Limited: Allows you to scroll within the specified area.

The default operation is Diagram.

The following code example illustrates how to specify the scroll limit.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px">
    @* Sets the ScrollLimit of scroll settings *@
     <ScrollSettings @bind-ScrollLimit="@scrollLimit" ></ScrollSettings>
</SfDiagramComponent>

@code{
    ScrollLimitMode scrollLimit { get; set; } = ScrollLimitMode.Infinity;
}

```
To explore about the options , refer [ScrollLimitMode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.ScrollLimitMode.html).

| ScrollLimit | Output |
|-------------|--------|
|   Diagram   | ![ScrollLimitMode as Diagram](./images/ScrollLimitDiagram.gif)|   
|   Infinity  | ![ScrollLimitMode as Infinity](./images/ScrollLimitInfinity.gif)|

## CallBack Methods

* CurrentZoomChanged : Specifies the callback to be triggered when the current zoom value changes.
* HorizontalOffsetChanged : Specifies the callback to be triggered when the horizontal offset changes.
* VerticalOffsetChanged : Specifies the callback to be triggered when the vetical offset changes.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px">
    @* Sets the ScrollLimit of scroll settings *@
     <ScrollSettings CurrentZoomChanged="OnCurrentZoomChanged"></ScrollSettings>
</SfDiagramComponent>

@code
{
    private void OnCurrentZoomChanged()
    {
        // Enter your code
    }
}
