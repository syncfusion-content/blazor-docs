---
layout: post
title: Grid Lines in Blazor Diagram Component | Syncfusion
description: Checkout and learn here all about Grid Lines in Syncfusion Blazor Diagram component and much more details.
platform: Blazor
control: Diagram Component
documentation: ug
---

# Grid Lines in Blazor Diagram Component

Gridlines are the pattern of lines drawn behind diagram elements. They provide visual guidance while dragging or arranging objects on the diagram surface. The [SnapSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SnapSettings.html) property customizes gridlines and controls snapping behavior in the diagram.

## How to Customize Grid Lines Visibility

The [Constraints](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SnapSettings.html#Syncfusion_Blazor_Diagram_SnapSettings_Constraints) property of `SnapSettings` to control the visibility of gridlines.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px" Nodes="@_nodes">
    @* Initialize the diagram snapping the custom interval *@
    <SnapSettings Constraints="SnapConstraints.All">
        <HorizontalGridLines SnapIntervals="@_snapInterval">
        </HorizontalGridLines>
        <VerticalGridLines SnapIntervals="@_snapInterval">
        </VerticalGridLines>
    </SnapSettings>
</SfDiagramComponent>

@code
{
    //Sets the snap interval.
    private double[] _snapInterval { get; set; } = new double[]
    {
        10
    };
    private DiagramObjectCollection<Node> _nodes = new DiagramObjectCollection<Node>();

    protected override void OnInitialized()
    {
        _nodes = new DiagramObjectCollection<Node>();
        Node diagramNode = new Node();
        diagramNode.OffsetX = 100;
        diagramNode.OffsetY = 100;
        diagramNode.Width = 100;
        diagramNode.Height = 100;
        diagramNode.Style = new ShapeStyle() { Fill = "#6495ED", StrokeColor = "#6495ED" };
        diagramNode.ID = "node1";
        _nodes.Add(diagramNode);
    }
}
```
A complete working sample can be downloaded from [GitHub](https://github.com/SyncfusionExamples/Blazor-UG-Examples/blob/master/Diagram/Server/Pages/Gridlines/CustomGridline.razor)

{% previewsample "https://blazorplayground.syncfusion.com/embed/VthoitNvgOEsjvmF?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[GridLines in Blazor Diagram](images/blazor-diagram-gridlines.png)" %}

To show only horizontal or vertical gridlines, or to hide gridlines, refer to [SnapConstraints](constraints#snap-constraints).

## How to Customize Grid Lines Appearance

The appearance of gridlines can be customized using predefined properties.

* The [HorizontalGridLines](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SnapSettings.html#Syncfusion_Blazor_Diagram_SnapSettings_HorizontalGridLines) and [VerticalGridLines](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SnapSettings.html#Syncfusion_Blazor_Diagram_SnapSettings_VerticalGridLines) properties customize the appearance of the horizontal and vertical gridlines respectively.

* For horizontal gridlines, use [LineColor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.DiagramGridLines.html#Syncfusion_Blazor_Diagram_DiagramGridLines_LineColor) and [LineDashArray](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.DiagramGridLines.html#Syncfusion_Blazor_Diagram_DiagramGridLines_LineDashArray) properties are used to customize the line color and line style of the horizontal gridlines.

* For vertical gridlines, use `LineColor` and `LineDashArray` properties are used to customize the line color and line style of the vertical gridlines.

The following code example illustrates how to customize the appearance of gridlines.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px">
    @* Shows both horizontal and vertical gridlines *@
    <SnapSettings Constraints="SnapConstraints.ShowLines">
        @* Customizes the line color and line style to the gridlines *@
        <HorizontalGridLines LineColor="blue" LineDashArray="2,2" />
        <VerticalGridLines LineColor="blue" LineDashArray="2,2" />
    </SnapSettings>
</SfDiagramComponent>
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LthSstjFquOSqpGo?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

A complete working sample can be downloaded from [GitHub](https://github.com/SyncfusionExamples/Blazor-UG-Examples/blob/master/Diagram/Server/Pages/Gridlines/Appearance.razor)


## How to Create Dot Grid Patterns

The appearance of the grid lines can be changed into dots by using the [GridType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SnapSettings.html#Syncfusion_Blazor_Diagram_SnapSettings_GridType) as **Dots**. The following code illustrates how to render grid patterns as Dots.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Width="1000px" Height="500px">
    @* Customizes the appearance of the gridlines *@
    <SnapSettings GridType="GridType.Dots">
        <HorizontalGridLines LineColor="Blue" @bind-LineIntervals="@_hInterval" @bind-DotIntervals="@_hDotInterval"></HorizontalGridLines>
        <VerticalGridLines LineColor="Blue" @bind-LineIntervals="@_vInterval" @bind-DotIntervals="@_vDotInterval"></VerticalGridLines>
    </SnapSettings>
</SfDiagramComponent>

@code
{
    private double[] _hDotInterval { get; set; } = new double[] { 3, 20, 1, 20, 1, 20 };
    private double[] _vDotInterval { get; set; } = new double[] { 3, 20, 1, 20, 1, 20, 1, 20, 1, 20 };
    private double[] _hInterval { get; set; } = new double[] { 1.25, 18.75, 0.25, 19.75, 0.25, 19.75, 0.25, 19.75, 0.25, 19.75 };
    private double[] _vInterval { get; set; } = new double[] { 1.25, 18.75, 0.25, 19.75, 0.25, 19.75, 0.25, 19.75, 0.25, 19.75 };
}
```
A complete working sample can be downloaded from [GitHub](https://github.com/SyncfusionExamples/Blazor-UG-Examples/blob/master/Diagram/Server/Pages/Gridlines/CustomizeGridline.razor)

{% previewsample "https://blazorplayground.syncfusion.com/embed/VZLeCjDFUEuuwDSA?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Dot Grid in Blazor Diagram](images/blazor-diagram-dot-grid.png)" %}


## How to Customize Line Intervals

Customize line thickness and spacing using the by using [LinesIntervals](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.DiagramGridLines.html#Syncfusion_Blazor_Diagram_DiagramGridLines_LineIntervals) property of the `HorizontalGridLines` and `VerticalGridLines`. In the line intervals collections, values at the odd places are referred as the thickness of lines and values at the even places are referred as the space between gridlines.

The following code example illustrates how to customize the thickness of lines and the line intervals.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px">
    @* Customize the appearance of the grid lines *@
    <SnapSettings Constraints="SnapConstraints.ShowLines">
        <HorizontalGridLines LineColor="blue" LineDashArray="2,2" LineIntervals="@_lineInterval">
        </HorizontalGridLines>
        <VerticalGridLines LineColor="blue" LineDashArray="2,2" LineIntervals="@_lineInterval">
        </VerticalGridLines>
    </SnapSettings>
</SfDiagramComponent>

@code
{
    //Sets the line intervals for the gridlines.
    private double[] _lineInterval { get; set; } = new double[] 
    {
        1.25, 14, 0.25, 15, 0.25, 15, 0.25, 15, 0.25, 15
    };
}
```
A complete working sample can be downloaded from [GitHub](https://github.com/SyncfusionExamples/Blazor-UG-Examples/blob/master/Diagram/Server/Pages/Gridlines/LineInterval.razor)


{% previewsample "https://blazorplayground.syncfusion.com/embed/hDByMjjlTDjqLjhz?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor Diagram with Custom Thickness of GridLines](images/blazor-diagram-custom-gridlines-thickness.png)" %}

## Snapping

### How to Enable Snap to Lines

This feature snaps diagram objects to the nearest intersection of gridlines while being dragged or resized. This feature enables easier alignment during layout or design.

Snapping to gridlines can be enabled or disabled with the [SnapConstraints](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SnapConstraints.html). The following code example illustrates how to enable/disable the snapping to gridlines.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px" Nodes="@_nodes">
    <SnapSettings Constraints="@_snapConstraints"></SnapSettings>
</SfDiagramComponent>

@code
{
    //Sets the snap constraints.
    private SnapConstraints _snapConstraints = SnapConstraints.ShowLines | SnapConstraints.SnapToLines;
    private DiagramObjectCollection<Node> _nodes = new DiagramObjectCollection<Node>();

    protected override void OnInitialized()
    {
        _nodes = new DiagramObjectCollection<Node>();
        Node diagramNode = new Node();
        diagramNode.OffsetX = 100;
        diagramNode.OffsetY = 100;
        diagramNode.Width = 100;
        diagramNode.Height = 100;
        diagramNode.Style = new ShapeStyle() { Fill = "#6495ED", StrokeColor = "#6495ED" };
        diagramNode.ID = "node1";
        _nodes.Add(diagramNode);
    }
}
```
A complete working sample can be downloaded from [GitHub](https://github.com/SyncfusionExamples/Blazor-UG-Examples/blob/master/Diagram/Server/Pages/Gridlines/SnapToLines.razor)


{% previewsample "https://blazorplayground.syncfusion.com/embed/LDLIsZtFpZDwzFgS?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Snapping to GridLines in Blazor Diagram](images/blazor-diagram-snap-to-gridlines.gif)" %}

### How to Customize Snap Intervals

By default, objects snapped towards the nearest gridline. The gridline or position towards where the diagram object snaps can be customized by using the [SnapIntervals](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.DiagramGridLines.html#Syncfusion_Blazor_Diagram_DiagramGridLines_SnapIntervals) property of HorizontalGridLines and VerticalGridLines.

```cshtml
@page "/CustomSnapLineInterval Sample"

@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px" Nodes="@_nodes">
    @* Initialize the diagram snapping the custom interval *@
    <SnapSettings Constraints="SnapConstraints.All">
        <HorizontalGridLines SnapIntervals="@_snapInterval">
        </HorizontalGridLines>
        <VerticalGridLines SnapIntervals="@_snapInterval">
        </VerticalGridLines>
    </SnapSettings>
</SfDiagramComponent>

@code
{
    //Sets the snap interval.
    private double[] _snapInterval { get; set; } = new double[]
    {
        10
    };
    private DiagramObjectCollection<Node> _nodes = new DiagramObjectCollection<Node>();

    protected override void OnInitialized()
    {
        _nodes = new DiagramObjectCollection<Node>();
        Node diagramNode = new Node();
        diagramNode.OffsetX = 100;
        diagramNode.OffsetY = 100;
        diagramNode.Width = 100;
        diagramNode.Height = 100;
        diagramNode.Style = new ShapeStyle() { Fill = "#6495ED", StrokeColor = "#6495ED" };
        diagramNode.ID = "node1";
        _nodes.Add(diagramNode);
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VXroCZtbTNsMUXqH?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

A complete working sample can be downloaded from [GitHub](https://github.com/SyncfusionExamples/Blazor-UG-Examples/blob/master/Diagram/Server/Pages/Gridlines/CustomizeSnapInterval.razor)


### How to Enable Snap to Object

The snap to object provides visual cues to assist with aligning and spacing diagram elements. A node can be snapped with its neighboring objects based on certain alignments. Such alignments are visually represented as smart guides.

* The [SnapDistance](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SnapSettings.html#Syncfusion_Blazor_Diagram_SnapSettings_SnapDistance) property allows you to define minimum distance between the selected object and the nearest object.

* The [SnapAngle](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SnapSettings.html#Syncfusion_Blazor_Diagram_SnapSettings_SnapAngle) property allows you to define the snap angle by which the object needs to be rotated.

* The Constraints property of the SnapSettings class allows you to enable or disable certain features of the snapping, refer to [Constraints](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SnapSettings.html#Syncfusion_Blazor_Diagram_SnapSettings_Constraints).

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px" Nodes="@_nodes">
    <SnapSettings Constraints="@_snapConstraints" SnapAngle="10" SnapDistance="10">
    </SnapSettings>
</SfDiagramComponent>

@code
{
    //Sets the Snap to objects constraints.
    private SnapConstraints _snapConstraints = SnapConstraints.ShowLines | SnapConstraints.SnapToObject;
    private DiagramObjectCollection<Node> _nodes = new DiagramObjectCollection<Node>();

    protected override void OnInitialized()
    {
        _nodes = new DiagramObjectCollection<Node>();
        Node diagramNode = new Node();
        diagramNode.OffsetX = 100;
        diagramNode.OffsetY = 100;
        diagramNode.Width = 100;
        diagramNode.Height = 100;
        diagramNode.Style = new ShapeStyle() { Fill = "#6495ED", StrokeColor = "#6495ED" };
        diagramNode.ID = "node1";
        _nodes.Add(diagramNode);

        diagramNode = new Node();
        diagramNode.OffsetX = 300;
        diagramNode.OffsetY = 100;
        diagramNode.Width = 100;
        diagramNode.Height = 100;
        diagramNode.Style = new ShapeStyle() { Fill = "#6495ED", StrokeColor = "#6495ED" };
        diagramNode.ID = "node2";
        _nodes.Add(diagramNode);
    }
}
```
A complete working sample can be downloaded from [GitHub](https://github.com/SyncfusionExamples/Blazor-UG-Examples/blob/master/Diagram/Server/Pages/Gridlines/SnapToObject.razor)


{% previewsample "https://blazorplayground.syncfusion.com/embed/rDVeWZtPJtixDcGj?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[GuideLines in Blazor Diagram](images/blazor-diagram-guidelines.gif)" %}

### How to Customize Snap Line Style

The [SnapLineStyle](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SnapSettings.html#Syncfusion_Blazor_Diagram_SnapSettings_SnapLineStyle) property of the [SnapSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SnapSettings.html) class allows to adjust the appearance of snapping lines to enhance visibility or match specific aesthetic preferences. By customizing this property, modify the color, stroke width, stroke dash array, and opacity of the snap lines. These adjustments improve visual contrast, making it easier to align objects with precision. By default, the snap line color is **#07EDE1**.

The following code example illustrates how to customize the snap line style.


```cshtml
@page "/"
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px" Nodes="@_nodes">
    <SnapSettings Constraints="@_snapConstraints" SnapAngle="10" SnapDistance="10" SnapLineStyle="@_snapLineStyle">
    </SnapSettings>
</SfDiagramComponent>

@code
{
    //Sets the Snap to objects constraints.
    private SnapConstraints _snapConstraints = SnapConstraints.ShowLines | SnapConstraints.SnapToObject | SnapConstraints.SnapToLines;
    private DiagramObjectCollection<Node> _nodes = new DiagramObjectCollection<Node>();
    private ShapeStyle _snapLineStyle = new ShapeStyle() { StrokeColor = "green", StrokeWidth = 3 };

    protected override void OnInitialized()
    {
        _nodes = new DiagramObjectCollection<Node>();
        Node diagramNode = new Node();
        diagramNode.OffsetX = 100;
        diagramNode.OffsetY = 100;
        diagramNode.Width = 100;
        diagramNode.Height = 100;
        diagramNode.Style = new ShapeStyle() { Fill = "#6495ED", StrokeColor = "#6495ED" };
        diagramNode.ID = "node1";
        _nodes.Add(diagramNode);

        diagramNode = new Node();
        diagramNode.OffsetX = 300;
        diagramNode.OffsetY = 100;
        diagramNode.Width = 100;
        diagramNode.Height = 100;
        diagramNode.Style = new ShapeStyle() { Fill = "#6495ED", StrokeColor = "#6495ED" };
        diagramNode.ID = "node2";
        _nodes.Add(diagramNode);
    }
}
```
A complete working sample can be downloaded from [GitHub](https://github.com/SyncfusionExamples/Blazor-UG-Examples/blob/master/Diagram/Server/Pages/Gridlines/SnapLineStyle.razor)

{% previewsample "https://blazorplayground.syncfusion.com/embed/LXVSiXZbfDrShrCg?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[GuideLines in Blazor Diagram](images/SnapLineStyle.png)" %}