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

* While selecting the diagram elements, the following events can be used to do the customization.
* When selecting/unselecting the diagram elements, the following events are getting triggered and to do customization on those events

|Event Name|Arguments|Description|
|------------|-----------|------------------------|
|`SelectionChanging`|`SelectionChangingEventArgs`|Triggers before the select or deselect any objects from the diagram.|
|`SelectionChanged`|`SelectionChangedEventArgs`|Triggers when select or deselect any objects from the diagram.|

The following code example explains how to get the selection change event in the diagram.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent @ref="Diagram" Width="1000px" SelectionChanging="@OnSelectionChanging" SelectionChanged="@OnSelectionChanged"  Height="500px" Connectors="@connectors">
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

    // Event to notify the selection changing event before select/unselect the diagram elements
    public void OnSelectionChanging(SelectionChangingEventArgs args)
    {
    //sets true to cancel the selection.
    args.Cancel = true;
    }

    // Event to notify the selection changed event after select/unselect the diagram elements.
    private void OnSelectionChanged(SelectionChangedEventArgs arg)
    {
        //Action to be performed
    }
}
```

## Position change

* While dragging the diagram elements, the following events can be used to do the customization.

|Event Name|Arguments|Description|
|------------|-----------|------------------------|
|`PositionChanging`|`PositionChangingEventArgs`|Triggers while before the node or connector is dragging or its position is changing.|
|`PositionChanged`|`PositionChangedEventArgs`|Triggers when the node or connector is dragged or its position is changed.|

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent @ref="Diagram" Width="1000px" PositionChanging="@OnPositionChanging" PositionChanged="@OnPositionChanged" Height="500px" Connectors="@connectors">
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

    // Event to notify the position changing event before dragging the diagram elements
    public void OnPositionChanging(PositionChangingEventArgs args)
    {
    //sets true to cancel the dragging.
    args.Cancel = true;
    }

    // Event to notify the position changed event after dragged the diagram elements.
    private void OnPositionChanged(PositionChangedEventArgs arg)
    {
        //Action to be performed
    }
}
```

## Connection change

* While changing the connection of the connector, the following events can be used to do the customization.

|Event Name|Arguments|Description|
|------------|-----------|------------------------|
|`ConnectionChanging`|`ConnectionChangingEventArgs`|Triggers while before the connector’s source id or target id has changing.|
|`ConnectionChanged`|`ConnectionChangedEventArgs`|Triggers when the connector’s source id or target id has changed.|

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent @ref="Diagram" Width="1000px" ConnectionChanging="@OnConnectionChanging" ConnectionChanged="@OnConnectionChange" Height="500px" Connectors="@connectors" Nodes="@nodes">
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

    // To notify the  connection changing event before the connection change
    private void OnConnectionChanging(ConnectionChangingEventArgs args)
    {
        //sets true to cancel the connection change.
        args.Cancel = true;
    }

    // To notify the  connection changed event after connection has been changed
    private void OnConnectionChange(ConnectionChangedEventArgs args)
    {
        //Action to be performed
    }
}
```

## See also

* [How to customize the connector properties](./customization)

* [How to interact the connector](./interactions)

* [How to change the segments](./segments)
