---
layout: post
title: Interaction in Blazor Diagram Component | Syncfusion
description: Checkout and learn here all about Interaction in Syncfusion Blazor Diagram component and much more details.
platform: Blazor
control: Diagram Component
documentation: ug
---

# Interaction in Blazor Diagram Component

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

## See also

* [`How to customize the connector properties`](./customization)

* [`How to change the segments`](./segments)

* [`How to get the connector events`](./events)