---
layout: post
title: Events in Blazor Diagram Component | Syncfusion
description: Checkout and learn here all about Events in Syncfusion Blazor Diagram component and much more details.
platform: Blazor
control: Diagram Component
documentation: ug
---

# Events in Blazor Diagram Component

## Selection change

The `SelectionChanged` event is triggered when select or unselect the node or connector. The `SelectionChangedEventArgs`interface is used to get selection changed event arguments.

The following code example explains how to get the selection changed event in the diagram.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent @ref="Diagram" Width="1000px" SelectionChanged="@SelectionChange"Height="500px" Connectors="@connectors">
</SfDiagramComponent>

@code
{
    SfDiagramComponent Diagram;
    DiagramObjectCollection<Connector> connectors = new DiagramObjectCollection<Connector>();

    protected override void OnInitialized()
    {
        Connector Connector = new Connector()
        {
            ID = "connector1",
            SourcePoint = new DiagramPoint()
            {
                X = 100,
                Y = 100
            },
            TargetPoint = new DiagramPoint()
            {
                X = 200,
                Y = 200
            },
            Type = ConnectorSegmentType.Orthogonal,
            TargetDecorator = new DecoratorSettings()
            {
                Shape = DecoratorShape.Arrow,
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

    // SelectionChanged event for diagram
    private void SelectionChange(SelectionChangedEventArgs arg)
    {
        Console.WriteLine((arg.NewValue[0] as Connector).ID);
    }
}
```

## Position change

The `PositionChanged` events is triggered when drag the node or connector in interaction. The `PositionChangedEventArgs` interface is used to get position changed event arguments.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent @ref="Diagram" Width="1000px" PositionChanged="@OnPositionChange" Height="500px" Connectors="@connectors">
</SfDiagramComponent>

@code
{
    SfDiagramComponent Diagram;
    DiagramObjectCollection<Connector> connectors = new DiagramObjectCollection<Connector>();

    protected override void OnInitialized()
    {
        Connector Connector = new Connector()
        {
            ID = "connector1",
            SourcePoint = new DiagramPoint()
            {
                X = 100,
                Y = 100
            },
            TargetPoint = new DiagramPoint()
            {
                X = 200,
                Y = 200
            },
            Type = ConnectorSegmentType.Orthogonal,
            TargetDecorator = new DecoratorSettings()
            {
                Shape = DecoratorShape.Arrow,
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
    private void OnPositionChange(PositionChangedEventArgs args)
    {
        Console.WriteLine((args.NewValue.Connectors[0].ID));
    }
}
```

## Connection change

The `ConnectionChanged` event will notify when the connection is changed. The `ConnectionChangedEventArgs` interface is used to get event arguments.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent @ref="Diagram" Width="1000px" ConnectionChanged="@OnConnectionChange" Height="500px" Connectors="@connectors" Nodes="@nodes">
</SfDiagramComponent>

@code
{
    SfDiagramComponent Diagram;
    DiagramObjectCollection<Connector> connectors = new DiagramObjectCollection<Connector>();
    DiagramObjectCollection<Node> nodes = new DiagramObjectCollection<Node>();

    protected override void OnInitialized()
    {
        nodes = new DiagramObjectCollection<Node>()
       {
          new Node() 
          {
            OffsetX = 100,
            OffsetY = 100,
            Height = 50,
            Width = 100,
            ID = "node1",
          },
        };
        Connector Connector = new Connector()
        {
            ID = "connector1",
            SourcePoint = new DiagramPoint()
            {
                X = 200,
                Y = 200
            },
            TargetID = "node1",
            Type = ConnectorSegmentType.Orthogonal,
            TargetDecorator = new DecoratorSettings()
            {
                Shape = DecoratorShape.Arrow,
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
    private void OnConnectionChange(ConnectionChangedEventArgs args)
    {
        Console.WriteLine("Oldvalue", args.OldValue);
        Console.WriteLine("NewValue", args.NewValue);
    }
}
```

## See also

* [How to customize the connector properties](./customization)

* [How to interact the connector](./interactions)

* [How to change the segments](./segments)
