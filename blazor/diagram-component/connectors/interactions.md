---
layout: post
title: Connector in Blazor Diagram Component | Syncfusion
description: Learn here all about Connector interaction in Syncfusion Blazor Diagram component and more.
platform: Blazor
control: Diagram Component
documentation: ug
---

# Interaction

Connectors can be selected, dragged, and routed over the diagram page.

## Select

A connector can be selected at runtime by using the `Select` method and clear the selection in the diagram using the `ClearSelection`. The following code explains how to select and clear selection in the diagram.

```csharp
@using Syncfusion.Blazor.Diagram
@using System.Collections.ObjectModel
<input type="button" value="Select" @onclick="OnSelect">
<input type="button" value="UnSelect" @onclick="@UnSelect" />
<SfDiagramComponent @ref="Diagram" Width="1000px" Height="500px" Connectors="@connectors">
</SfDiagramComponent>
@code{
    SfDiagramComponent Diagram;
    DiagramObjectCollection<Connector> connectors = new DiagramObjectCollection<Connector>();
    protected override void OnInitialized()
    {
        Dictionary<string, object> ConnectorInfo = new Dictionary<string, object>();
        ConnectorInfo.Add("connectorInfo", "Central Connector");
        Connector Connector = new Connector()
        {
            ID = "connector1",
            SourcePoint = new Point()
            {
                X = 100,
                Y = 100
            },
            TargetPoint = new Point()
            {
                X = 200,
                Y = 200
            },
            Type = Segments.Orthogonal,
            TargetDecorator = new Decorator()
            {
                Shape = DecoratorShapes.Arrow,
                Style = new ShapeStyle()
                {
                    Fill = "#6495ED",
                    StrokeColor = "#6495ED",
                    StrokeWidth = 1
                }
            },
            Style = new ShapeStyle()
            {
                StrokeColor = "#6495ED",
                StrokeWidth = 1
            },
            AddInfo = ConnectorInfo
        };
        connectors.Add(Connector);
    }
    public void OnSelect()
    {
        // Select the Connector
        Diagram.Select(new ObservableCollection<IDiagramObject> { Diagram.GetObject(Diagram.Connectors[0].ID) as IDiagramObject });
    }
    public void UnSelect()
    {
        // clear selection in the diagram
        Diagram.ClearSelection();
    }
}
```

And also the selection can be enabled during the interaction.

* An element can be selected by clicking that element.
* When you select the elements in the diagram, the `SelectionChange` event gets triggered and do customization in this event.

![Select](../images/connector-select.gif)

## Drag

A connector can be dragged at runtime by using the `Drag` method. The following code explains how to drag the connector by using the drag method.

```csharp
@using Syncfusion.Blazor.Diagram
<input type="button" value="Drag" @onclick="OnDrag">
<SfDiagramComponent @ref="Diagram" Width="1000px" Height="500px" Connectors="@connectors">
</SfDiagramComponent>
@code{
    SfDiagramComponent Diagram;
    DiagramObjectCollection<Connector> connectors = new DiagramObjectCollection<Connector>();
    protected override void OnInitialized()
    {
        Dictionary<string, object> ConnectorInfo = new Dictionary<string, object>();
        ConnectorInfo.Add("connectorInfo", "Central Connector");
        Connector Connector = new Connector()
        {
            ID = "connector1",
            SourcePoint = new Point()
            {
                X = 100,
                Y = 100
            },
            TargetPoint = new Point()
            {
                X = 200,
                Y = 200
            },
            Type = Segments.Orthogonal,
            TargetDecorator = new Decorator()
            {
                Shape = DecoratorShapes.Arrow,
                Style = new ShapeStyle()
                {
                    Fill = "black",
                    StrokeColor = "black",
                    StrokeWidth = 1
                }
            },
            Style = new ShapeStyle()
            {
                StrokeColor = "black",
                StrokeWidth = 1
            },
            AddInfo = ConnectorInfo
        };
        connectors.Add(Connector);
    }
    public void OnDrag()
    {
        // Drag the connector
        Diagram.Drag(Diagram.Connectors[0], 10, 10);
    }
}
```

And also drag the connector during the interaction.

* An object can be dragged by clicking and dragging it. When multiple elements are selected, dragging any one of the selected elements move all the selected elements.
* When you drag the elements in the diagram, the `PositionChange` event gets triggered and to do customization in this event.

![Drag](../images/connector-drag.gif)

## End Point Dragging

The connector can be selected by clicking it. When the connector is selected, circles will be added on the starting and ending of the connector that is represented by Thumbs. Clicking and dragging those handles helps you to adjust the source and target points.

```csharp
@using Syncfusion.Blazor.Diagram
<SfDiagramComponent @ref="Diagram" Width="1000px" Height="500px" Connectors="@connectors">
</SfDiagramComponent>
@code{
    SfDiagramComponent Diagram;
    DiagramObjectCollection<Connector> connectors = new DiagramObjectCollection<Connector>();
    protected override void OnInitialized()
    {
        Dictionary<string, object> ConnectorInfo = new Dictionary<string, object>();
        ConnectorInfo.Add("connectorInfo", "Central Connector");
        Connector Connector = new Connector()
        {
            ID = "connector1",
            SourcePoint = new Point()
            {
                X = 100,
                Y = 100
            },
            TargetPoint = new Point()
            {
                X = 200,
                Y = 200
            },
            Type = Segments.Orthogonal,
            TargetDecorator = new Decorator()
            {
                Shape = DecoratorShapes.Arrow,
                Style = new ShapeStyle()
                {
                    Fill = "black",
                    StrokeColor = "black",
                    StrokeWidth = 1
                }
            },
            Style = new ShapeStyle()
            {
                StrokeColor = "black",
                StrokeWidth = 1
            },
            AddInfo = ConnectorInfo
        };
        connectors.Add(Connector);
    }
}
```

![End point dragging](../images/connector-end-point.gif)

## Segment Editing

### Straight segment editing

* End point of each straight segment is represented by a thumb that enables to edit the segment.
* Any number of new segments can be inserted into a straight line by clicking, when Shift and Ctrl keys are pressed (Ctrl+Shift+Click).

* Straight segments can be removed by clicking the segment end point, when Ctrl and Shift keys are pressed (Ctrl+Shift+Click).

```csharp
@using Syncfusion.Blazor.Diagram
<SfDiagramComponent @ref="Diagram" Width="1000px"  Height="500px" Connectors="@connectors">
</SfDiagramComponent>
@code{
    SfDiagramComponent Diagram;
    DiagramObjectCollection<Connector> connectors = new DiagramObjectCollection<Connector>();
    protected override void OnInitialized()
    {
        Connector Connector = new Connector()
        // Enable the segment editing
        { ID = "Connector1", Constraints = ConnectorConstraints.Default | ConnectorConstraints.DragSegmentThumb, SourcePoint = new Point { X = 200, Y = 100 }, TargetPoint = new Point { X = 340, Y = 150 }, Segments = new DiagramObjectCollection<ConnectorSegment> { new StraightSegment() { Type = Segments.Straight, Point = new Point { X = 300, Y = 200 } } } };
        connectors.Add(Connector);
    }

}
```

![Straight Segment Editing Addition](../images/straight-segment-add.gif)

### Orthogonal Segment Editing

* Orthogonal thumbs allow you to adjust the length of adjacent segments by clicking and dragging it.
* When necessary, some segments are added or removed automatically, when dragging the segment. This is to maintain proper routing of orthogonality between segments.

```csharp
@using Syncfusion.Blazor.Diagram
<SfDiagramComponent @ref="Diagram" Width="1000px"  Height="500px" Connectors="@connectors">
</SfDiagramComponent>
@code{
    SfDiagramComponent Diagram;
    DiagramObjectCollection<Connector> connectors = new DiagramObjectCollection<Connector>();
    protected override void OnInitialized()
    {
        Connector Connector = new Connector()
        // Enable the segment editing
        { ID = "Connector2", Constraints = ConnectorConstraints.Default | ConnectorConstraints.DragSegmentThumb, Type = Segments.Orthogonal, SourcePoint = new Point { X = 400, Y = 100 }, TargetPoint = new Point { X = 500, Y = 200 } };
        connectors.Add(Connector);
    }
}
```

![Orthogonal Segment Edit](../images/orthogonal-segment-edit.gif)

### Bezier Segment Editing

* A segment control point of the Bezier connector is used to change the bezier vectors, points of the connector.

![Bezier](images/bezieredit.gif)

## See also

* [`How to customize the connector properties`](./customization)

* [`How to change the segments`](./segments)

* [`How to get the connector events`](./events)