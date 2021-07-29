---
layout: post
title: Events in Blazor Diagram Component | Syncfusion
description: Checkout and learn here all about Events in Syncfusion Blazor Diagram component and much more details.
platform: Blazor
control: Diagram
documentation: ug
---

# Events in Blazor Diagram Component

## Selection change

The `SelectionChange` event is triggered when select or unselect the node or connector. The `SelectionChangeEventArgs`interface is used to get selection change event arguments.

The following code example explains how to get the selection change event in the diagram.

```cshtml
@using Syncfusion.Blazor.Diagram
<SfDiagramComponent @ref="Diagram" Width="1000px" SelectionChange="@SelectionChange"Height="500px" Connectors="@connectors">
</SfDiagramComponent>
@code{
    SfDiagramComponent Diagram;
    DiagramObjectCollection<Connector> connectors = new DiagramObjectCollection<Connector>();
    protected override void OnInitialized()
    {
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
        };
        connectors.Add(Connector);
    }
    // SelectionChange event for diagram
    private void SelectionChange(SelectionChangeEventArgs arg)
    {
        Console.WriteLine((arg.NewValue[0] as Connector).ID);
    }
}
```

## Position change

The `PositionChange` events is triggered when drag the node or connector in interaction. The `DraggingEventArgs` interface is used to get position change event arguments.

```cshtml
@using Syncfusion.Blazor.Diagram
<SfDiagramComponent @ref="Diagram" Width="1000px" PositionChange="@OnPositionChange" Height="500px" Connectors="@connectors">
</SfDiagramComponent>
@code{
    SfDiagramComponent Diagram;
    DiagramObjectCollection<Connector> connectors = new DiagramObjectCollection<Connector>();
    protected override void OnInitialized()
    {
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
        };
        connectors.Add(Connector);
    }
    // Position change event for diagram
    private void OnPositionChange(DraggingEventArgs args)
    {
        Console.WriteLine((args.NewValue.Connectors[0].ID));
    }
}
```

## Connection change

The `ConnectionChange` event will notify when the connection is changed. The `ConnectionChangeEventArgs` interface is used to get event arguments.

```cshtml
@using Syncfusion.Blazor.Diagram
<SfDiagramComponent @ref="Diagram" Width="1000px" ConnectionChange="@OnConnectionChange" Height="500px" Connectors="@connectors">
</SfDiagramComponent>
@code{
    SfDiagramComponent Diagram;
    DiagramObjectCollection<Connector> connectors = new DiagramObjectCollection<Connector>();
    protected override void OnInitialized()
    {
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
        };
        connectors.Add(Connector);
    }
    // Connection change event for diagram
    private void OnConnectionChange(ConnectionChangeEventArgs args)
    {
        Console.WriteLine("Oldvalue", args.OldValue);
        Console.WriteLine("NewValue", args.NewValue);
    }
}
```

## See also

* [`How to customize the connector properties`](./customization)

* [`How to interact the connector`](./interactions)

* [`How to change the segments`](./segments)