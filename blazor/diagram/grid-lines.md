---
layout: post
title: Gridlines in Blazor Diagram Component | Syncfusion
description: Checkout and learn here all about Gridlines in Syncfusion Blazor Diagram component and much more details.
platform: Blazor
control: Diagram
documentation: ug
---

# Gridlines in Blazor Diagram Component

Gridlines are the pattern of lines drawn behind the diagram elements. It provides a visual guidance while dragging or arranging the objects on the diagram surface.

The model’s [`SnapSettings`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.SfDiagram.html#Syncfusion_Blazor_Diagrams_SfDiagram_SnapSettings) property is used to customize the gridlines and control the snapping behavior in the diagram.

## Customize the gridlines visibility

The [`SnapConstraints`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.SnapConstraints.html) enables you to show/hide the gridlines. The following code example illustrates how to show or hide gridlines.

```cshtml
@using Syncfusion.Blazor.Diagrams

<SfDiagram Height="600px">
    @* Shows both horizontal and vertical gridlines *@
    <DiagramSnapSettings Constraints="@snapConstraints">
        <HorizontalGridlines LineColor="blue" LineDashArray="2,2">
        </HorizontalGridlines>
        <VerticalGridlines LineColor="blue" LineDashArray="2,2">
        </VerticalGridlines>
    </DiagramSnapSettings>
</SfDiagram>

@code{
    SnapConstraints snapConstraints = SnapConstraints.ShowLines;
}
```

To show only horizontal/vertical gridlines or to hide gridlines, refer to [`Constraints`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.SnapConstraints.html).

## Appearance

The appearance of the gridlines can be customized by using a set of predefined properties.

* The [`HorizontalGridLines`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.DiagramSnapSettings.html#Syncfusion_Blazor_Diagrams_DiagramSnapSettings_HorizontalGridlines) and the [`VerticalGridLines`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.DiagramSnapSettings.html#Syncfusion_Blazor_Diagrams_DiagramSnapSettings_VerticalGridlines) properties allow to customize the appearance of the horizontal and vertical gridlines respectively.

* The horizontal gridlines [`LineColor`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.DiagramsGridLines.html#Syncfusion_Blazor_Diagrams_DiagramsGridLines_LineColor) and [`LineDashArray`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.DiagramsGridLines.html#Syncfusion_Blazor_Diagrams_DiagramsGridLines_LineDashArray) properties are used to customizes the line color and line style of the horizontal gridlines.

* The vertical gridlines [`LineColor`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.DiagramsGridLines.html#Syncfusion_Blazor_Diagrams_DiagramsGridLines_LineColor) and [`LineDashArray`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.DiagramsGridLines.html#Syncfusion_Blazor_Diagrams_DiagramsGridLines_LineDashArray) properties are used to customizes the line color and line style of the vertical gridlines.

The following code example illustrates how to customize the appearance of gridlines.

```cshtml
@using Syncfusion.Blazor.Diagrams

<SfDiagram Height="600px">
    @* Shows both horizontal and vertical gridlines *@
    <DiagramSnapSettings Constraints="SnapConstraints.ShowLines">
        @* Customizes the line color and line style to the gridlines *@
        <HorizontalGridlines LineColor="blue" LineDashArray="2,2">
        </HorizontalGridlines>
        <VerticalGridlines LineColor="blue" LineDashArray="2,2">
        </VerticalGridlines>
    </DiagramSnapSettings>
</SfDiagram>
```

## Line intervals

Thickness and the space between gridlines can be customized by using horizontal gridline’s [`LinesInterval`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.DiagramsGridLines.html#Syncfusion_Blazor_Diagrams_DiagramsGridLines_LineIntervals) and vertical gridline’s [`LinesInterval`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.DiagramsGridLines.html#Syncfusion_Blazor_Diagrams_DiagramsGridLines_LineIntervals) properties. In the line intervals collections, values at the odd places are referred as the thickness of lines and values at the even places are referred as the space between gridlines.

The following code example illustrates how to customize the thickness of lines and the line intervals.

```cshtml
@using Syncfusion.Blazor.Diagrams

<SfDiagram Height="600px">
    @* Customize the appearance of the grid lines *@
    <DiagramSnapSettings Constraints="SnapConstraints.ShowLines">
        <HorizontalGridlines LineColor="blue" LineDashArray="2,2" LineIntervals="@LineIntervals">
        </HorizontalGridlines>
        <VerticalGridlines LineColor="blue" LineDashArray="2,2" LineIntervals="@LineIntervals">
        </VerticalGridlines>
    </DiagramSnapSettings>
</SfDiagram>

@code{
    //Sets the line intervals for the gridlines
    public double[] LineIntervals { get; set; } = new double[] {
                1.25, 14, 0.25, 15, 0.25, 15, 0.25, 15, 0.25, 15
                };
}
```

![Diagram Gridlines appearances](images/Gridlines.png)

## Snapping

### Snap to lines

This feature allows the diagram objects to snap to the nearest intersection of gridlines while being dragged or resized. This feature enables easier alignment during layout or design.

Snapping to gridlines can be enabled/disabled with the [`SnapConstraints`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.DiagramSnapSettings.html#Syncfusion_Blazor_Diagrams_DiagramSnapSettings_Constraints). The following code example illustrates how to enable/disable the snapping to gridlines.

```cshtml
@using Syncfusion.Blazor.Diagrams
@using System.Collections.ObjectModel

<SfDiagram Height="600px" Nodes="@NodeCollection">
    <DiagramSnapSettings Constraints="@snapConstraints"></DiagramSnapSettings>
</SfDiagram>

@code{
    //Sets the snap constraints
    public SnapConstraints snapConstraints = SnapConstraints.ShowLines | SnapConstraints.SnapToLines;
    public ObservableCollection<DiagramNode> NodeCollection
    {
        get; set;
    }
    protected override void OnInitialized()
    {
        NodeCollection = new ObservableCollection<DiagramNode>();
        DiagramNode diagramNode = new DiagramNode();
        diagramNode.OffsetX = 100;
        diagramNode.OffsetY = 100;
        diagramNode.Width = 100;
        diagramNode.Height = 100;
        diagramNode.Style = new NodeShapeStyle() { Fill = "#6BA5D7", StrokeColor = "#6BA5D7" };
        diagramNode.Id = "node1";
        NodeCollection.Add(diagramNode);
    }
}
```

### Customization of snap intervals

By default, the objects are snapped towards the nearest gridline. The gridline or position towards where the diagram object snaps can be customized with the horizontal gridline’s [`SnapInterval`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.DiagramsGridLines.html) and the vertical gridline’s [`SnapInterval`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.DiagramsGridLines.html) properties.

```cshtml
@using Syncfusion.Blazor.Diagrams
@using System.Collections.ObjectModel

<SfDiagram Height="600px" Nodes="@NodeCollection">
    @* Initialize the diagram snapping the custom interval *@
    <DiagramSnapSettings Constraints="SnapConstraints.All">
        <HorizontalGridlines SnapIntervals="@SnapInterval">
        </HorizontalGridlines>
        <VerticalGridlines SnapIntervals="@SnapInterval">
        </VerticalGridlines>
    </DiagramSnapSettings>
</SfDiagram>

@code{
    //Sets the snapinterval...
    public double[] SnapInterval { get; set; } = new double[]
    {
        10
        };
    public ObservableCollection<DiagramNode> NodeCollection
    {
        get; set;
    }
    protected override void OnInitialized()
    {
        NodeCollection = new ObservableCollection<DiagramNode>();
        DiagramNode diagramNode = new DiagramNode();
        diagramNode.OffsetX = 100;
        diagramNode.OffsetY = 100;
        diagramNode.Width = 100;
        diagramNode.Height = 100;
        diagramNode.Style = new NodeShapeStyle() { Fill = "#6BA5D7", StrokeColor = "#6BA5D7" };
        diagramNode.Id = "node1";
        NodeCollection.Add(diagramNode);
    }
}
```

### Snap to objects

The snap to object provides visual cues to assist with aligning and spacing diagram elements. A node can be snapped with its neighboring objects based on certain alignments. Such alignments are visually represented as smart guides.

The [`SnapObjectDistance`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.DiagramSnapSettings.html#Syncfusion_Blazor_Diagrams_DiagramSnapSettings_SnapObjectDistance) property allows you to define minimum distance between the selected object and the nearest object.

The [`SnapAngle`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.DiagramSnapSettings.html#Syncfusion_Blazor_Diagrams_DiagramSnapSettings_SnapAngle) property allows you to define the snap angle by which the object needs to be rotated.

The [`SnapConstraints`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.DiagramSnapSettings.html#Syncfusion_Blazor_Diagrams_DiagramSnapSettings_Constraints) property allows you to enable or disable the certain features of the snapping, refer to [`SnapConstraints`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.SnapConstraints.html).

```cshtml
@using Syncfusion.Blazor.Diagrams
@using System.Collections.ObjectModel

<SfDiagram Height="600px" Nodes="@NodeCollection">
    <DiagramSnapSettings Constraints="@snapConstraints" SnapAngle="10" SnapObjectDistance="10">
    </DiagramSnapSettings>
</SfDiagram>

@code{
    //Sets the Snap to objects constraints...
    public SnapConstraints snapConstraints = SnapConstraints.ShowLines | SnapConstraints.SnapToObject;
    public ObservableCollection<DiagramNode> NodeCollection
    {
        get; set;
    }
    protected override void OnInitialized()
    {
        NodeCollection = new ObservableCollection<DiagramNode>();
        DiagramNode diagramNode = new DiagramNode();
        diagramNode.OffsetX = 100;
        diagramNode.OffsetY = 100;
        diagramNode.Width = 100;
        diagramNode.Height = 100;
        diagramNode.Style = new NodeShapeStyle() { Fill = "#6BA5D7", StrokeColor = "#6BA5D7" };
        diagramNode.Id = "node1";
        NodeCollection.Add(diagramNode);

        diagramNode = new DiagramNode();
        diagramNode.OffsetX = 300;
        diagramNode.OffsetY = 100;
        diagramNode.Width = 100;
        diagramNode.Height = 100;
        diagramNode.Style = new NodeShapeStyle() { Fill = "#6BA5D7", StrokeColor = "#6BA5D7" };
        diagramNode.Id = "node2";
        NodeCollection.Add(diagramNode);
    }
}

```