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

## How to select and unselect the connector

A connector can be selected at runtime by using the [Select](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_Select_System_Collections_ObjectModel_ObservableCollection_Syncfusion_Blazor_Diagram_IDiagramObject__System_Nullable_System_Boolean__) method and clear the selection in the diagram using the [ClearSelection](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_ClearSelection). The following code explains how to select and clear selection in the diagram.

```cshtml
@using Syncfusion.Blazor.Diagram
@using System.Collections.ObjectModel
@using Syncfusion.Blazor.Buttons

<SfButton Content="Select" OnClick="@OnSelect" />
<SfButton Content="UnSelect" OnClick="@UnSelect" />
<SfDiagramComponent @ref="Diagram" Width="1000px" Height="500px" Connectors="@connectors">
</SfDiagramComponent>

@code
{
    SfDiagramComponent Diagram;
    DiagramObjectCollection<Connector> connectors = new DiagramObjectCollection<Connector>();

    protected override void OnInitialized()
    {
        Dictionary<string, object> ConnectorInfo = new Dictionary<string, object>();
        ConnectorInfo.Add("connectorInfo", "Central Connector");
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
            AdditionalInfo = ConnectorInfo
        };
        connectors.Add(Connector);
    }

    public void OnSelect()
    {
        // Select the Connector.
        Diagram.Select(new ObservableCollection<IDiagramObject> { Diagram.GetObject(Diagram.Connectors[0].ID) as IDiagramObject });
    }

    public void UnSelect()
    {
        // Clear selection in the diagram.
        Diagram.ClearSelection();
    }
}
```
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/Connectors/Interaction/Select)

And also the selection can be enabled during the interaction.

* An element can be selected by clicking that element.
* When you select the elements in the diagram, the [SelectionChanging](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_SelectionChanging) and  [SelectionChanged](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_SelectionChanged) events get triggered and do customization in this event.

## How to drag a connector

A connector can be dragged at runtime by using the [Drag](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_Drag_Syncfusion_Blazor_Diagram_IDiagramObject_System_Double_System_Double_) method. The following code explains how to drag the connector by using the drag method.

```cshtml
@using Syncfusion.Blazor.Diagram
@using Syncfusion.Blazor.Buttons

<SfButton Content="Drag" OnClick="@OnDrag" />
<SfDiagramComponent @ref="Diagram" Width="1000px" Height="500px" Connectors="@connectors">
</SfDiagramComponent>

@code
{
    SfDiagramComponent Diagram;
    DiagramObjectCollection<Connector> connectors = new DiagramObjectCollection<Connector>();

    protected override void OnInitialized()
    {
        Dictionary<string, object> ConnectorInfo = new Dictionary<string, object>();
        ConnectorInfo.Add("connectorInfo", "Central Connector");
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
            AdditionalInfo = ConnectorInfo
        };
        connectors.Add(Connector);
    }

    public void OnDrag()
    {
        // Drag the connector.
        Diagram.Drag(Diagram.Connectors[0], 10, 10);
    }
}
```
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/Connectors/Interaction/Drag)

And also drag the connector during the interaction.

* An object can be dragged by clicking and dragging it. When multiple elements are selected, dragging any one of the selected elements move all the selected elements.
* When you drag the elements in the diagram, the [PositionChanging](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_PositionChanging) and [PositionChanged](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_PositionChanged) events get triggered and do customization in this event.

![Dragging Connector in Blazor Diagram](../images/blazor-diagram-drag-connector.gif)

## End point dragging

The connector can be selected by clicking it. When the connector is selected, circles will be added on the starting and ending of the connector that is represented by Thumbs. Clicking and dragging those handles helps you to adjust the source and target points.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent @ref="Diagram" Width="1000px" Height="500px" Connectors="@connectors">
</SfDiagramComponent>

@code
{
    SfDiagramComponent Diagram;
    DiagramObjectCollection<Connector> connectors = new DiagramObjectCollection<Connector>();

    protected override void OnInitialized()
    {
        Dictionary<string, object> ConnectorInfo = new Dictionary<string, object>();
        ConnectorInfo.Add("connectorInfo", "Central Connector");
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
            AdditionalInfo = ConnectorInfo
        };
        connectors.Add(Connector);
    }
}
```
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/Connectors/Interaction/EndPointDragging)

![Dragging Connector End Point in Blazor Diagram](../images/blazor-diagram-drag-connector-end-point.gif)

## How to route the connectors

The connectors may overlap with adjacent nodes when a node is positioned so that it encounters the connector. This overlap can reduce the clarity of the connector's path. To prevent this, the Routing process can be utilized.

Routing is the process of adjusting the geometry of connectors to prevent them from overlapping with any nearby nodes in their path. This feature can be activated by adding [Routing](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.DiagramConstraints.html#Syncfusion_Blazor_Diagram_DiagramConstraints_Routing) enum value to the [Constraints](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_Constraints) property of diagram.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Width="1000px" Height="500px" Connectors="@connectors" Nodes="@nodes" Constraints="@diagramConstraints">
</SfDiagramComponent>
@code 
{    
    // Enable routing constraints for diagram.
    DiagramConstraints diagramConstraints = DiagramConstraints.Default | DiagramConstraints.Routing;
    // Intialize the node collection.
    DiagramObjectCollection<Node> nodes = new DiagramObjectCollection<Node>();
    // Intialize the connector collection.
    DiagramObjectCollection<Connector> connectors = new DiagramObjectCollection<Connector>();
    
    protected override void OnInitialized()
    {
        nodes = new DiagramObjectCollection<Node>()
        {
            new Node() { ID = "node1", OffsetX = 100, OffsetY = 300, Width = 100, Height =100 },
            new Node() { ID = "node2", OffsetX = 600, OffsetY = 100, Width = 100, Height = 100 },
            new Node() { ID = "node3", OffsetX = 400, OffsetY = 250, Width = 100, Height = 100 }
        };
        connectors = new DiagramObjectCollection<Connector>(){
            new Connector()
            {
                ID = "connector1",
                SourceID = "node1", TargetID = "node2",
                Type = ConnectorSegmentType.Orthogonal
            }
        };
    }
}
```
![Blazor Diagram Connector Routing](../images/blazor-diagram-connector-routing.gif)

You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/Connectors/Interaction/DefaultRouting).

**Note:** Routing is applicable only for orthogonal connectors.

### Routing Types

Determines the routing strategy used for connectors in the diagram. It can be set to either [Classic](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.RoutingTypes.html#Syncfusion_Blazor_Diagram_RoutingTypes_Classic) for faster routing or [Advanced](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.RoutingTypes.html#Syncfusion_Blazor_Diagram_RoutingTypes_Advanced) for more accurate routing with better obstacle avoidance. The routing algorithm can be specified by using [RoutingType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.LineRoutingSettings.html#Syncfusion_Blazor_Diagram_LineRoutingSettings_RoutingType) property of [LineRoutingSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.LineRoutingSettings.html) class.

#### Classic Routing

The [Classic](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.RoutingTypes.html#Syncfusion_Blazor_Diagram_RoutingTypes_Classic) routing algorithm adds additional segments based on the position and dimensions of the obstacles in the path. This routing method prioritizes reducing the impact of obstacles over minimizing the geometry length and the number of bends. Use Classic routing when it's crucial to navigate around obstacles efficiently, even if it means having a longer path or more bends.


```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Width="1000px" Height="500px" Connectors="@connectors" Nodes="@nodes" Constraints="@diagramConstraints">
    <LineRoutingSettings RoutingType ="@routingTypes"></LineRoutingSettings>
</SfDiagramComponent>
@code 
{
    // Set the type of the routing
    RoutingTypes routingTypes = RoutingTypes.Classic;
    // Enable routing constraints for diagram.
    DiagramConstraints diagramConstraints = DiagramConstraints.Default | DiagramConstraints.Routing;
    // Intialize the node collection.
    DiagramObjectCollection<Node> nodes = new DiagramObjectCollection<Node>();
    // Intialize the connector collection.
    DiagramObjectCollection<Connector> connectors = new DiagramObjectCollection<Connector>();
    
    protected override void OnInitialized()
    {
        nodes = new DiagramObjectCollection<Node>()
        {
            new Node() { ID = "node1", OffsetX = 100, OffsetY = 300, Width = 100, Height =100 },
            new Node() { ID = "node2", OffsetX = 600, OffsetY = 100, Width = 100, Height = 100 },
            new Node() { ID = "node3", OffsetX = 400, OffsetY = 250, Width = 100, Height = 100 }
        };
        connectors = new DiagramObjectCollection<Connector>(){
            new Connector()
            {
                ID = "connector1",
                SourceID = "node1", TargetID = "node2",
                Type = ConnectorSegmentType.Orthogonal
            }
        };
    }
}
```
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/)

#### Advanced Routing

The [Advanced](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.RoutingTypes.html#Syncfusion_Blazor_Diagram_RoutingTypes_Advanced) routing algorithm evaluates all possible geometrical paths for a connector, aiming to find the one with the minimal bends and the shortest length. Use Advanced routing when you need a more optimized path with the fewest bends and the shortest possible length, even if it means the path might get closer to obstacles.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Width="1000px" Height="500px" Connectors="@connectors" Nodes="@nodes" Constraints="@diagramConstraints">
    <LineRoutingSettings RoutingType ="@routingTypes" ObstaclePadding="@padding"></LineRoutingSettings>
</SfDiagramComponent>
@code 
{
    // Set the type of the routing
    RoutingTypes routingTypes = RoutingTypes.Advanced;
    // Set the padding for the obstable
    double padding = 20;
    // Enable routing constraints for diagram.
    DiagramConstraints diagramConstraints = DiagramConstraints.Default | DiagramConstraints.Routing;
    // Intialize the node collection.
    DiagramObjectCollection<Node> nodes = new DiagramObjectCollection<Node>();
    // Intialize the connector collection.
    DiagramObjectCollection<Connector> connectors = new DiagramObjectCollection<Connector>();
    
    protected override void OnInitialized()
    {
        nodes = new DiagramObjectCollection<Node>()
        {
            new Node() { ID = "node1", OffsetX = 100, OffsetY = 300, Width = 100, Height =100 },
            new Node() { ID = "node2", OffsetX = 600, OffsetY = 100, Width = 100, Height = 100 },
            new Node() { ID = "node3", OffsetX = 400, OffsetY = 250, Width = 100, Height = 100 }
        };
        connectors = new DiagramObjectCollection<Connector>(){
            new Connector()
            {
                ID = "connector1",
                SourceID = "node1", TargetID = "node2",
                Type = ConnectorSegmentType.Orthogonal
            }
        };
    }
}
```

You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/)

**Note:** Default value of [RoutingType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.LineRoutingSettings.html#Syncfusion_Blazor_Diagram_LineRoutingSettings_RoutingType) is [Classic](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.RoutingTypes.html#Syncfusion_Blazor_Diagram_RoutingTypes_Classic).

### How to enable or disable routing for nodes

By default, connectors treat all nodes as obstacles, causing connections to navigate around the node boundaries. However, you can disable this behavior and allow connectors to ignore the node as an obstacle by removing the [RoutingObstacle](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.NodeConstraints.html#Syncfusion_Blazor_Diagram_NodeConstraints_RoutingObstacle) from the node's [Constraints](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.Node.html#Syncfusion_Blazor_Diagram_Node_Constraints) property.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Width="1000px" Height="500px" NodeCreating="@OnNodeCreating" ConnectorCreating="@OnConnectorCreating" Connectors="@connectors" Nodes="@nodes" Constraints="@diagramConstraints">
    <SnapSettings Constraints="SnapConstraints.None"></SnapSettings>
</SfDiagramComponent>
@code
{
    // Enable routing constraints for the diagram.
    DiagramConstraints diagramConstraints = DiagramConstraints.Default | DiagramConstraints.Routing;
    // Intialize the node collection.
    DiagramObjectCollection<Node> nodes = new DiagramObjectCollection<Node>();
    // Intialize the connector collection.
    DiagramObjectCollection<Connector> connectors = new DiagramObjectCollection<Connector>();
    protected override void OnInitialized()
    {
        nodes = new DiagramObjectCollection<Node>()
        {
            new Node() { ID = "Source", OffsetX = 100, OffsetY = 300, Width = 100, Height =100, Annotations= new DiagramObjectCollection<ShapeAnnotation>(){ new ShapeAnnotation() { Content="Source" } }, Ports=new DiagramObjectCollection<PointPort>(){ new PointPort(){ ID="port1", Offset=new DiagramPoint() { X = 1, Y = 0.5 } } } },
            new Node() { ID = "Target", OffsetX = 800, OffsetY = 300, Width = 100, Height = 100, Annotations= new DiagramObjectCollection<ShapeAnnotation>(){ new ShapeAnnotation() { Content="Target" } }, Ports=new DiagramObjectCollection<PointPort>(){ new PointPort(){ ID="port1", Offset=new DiagramPoint() { X = 0, Y = 0.5 } } } },
            new Node() { ID = "RoutingObstacle", OffsetX = 300, OffsetY = 300, Width = 100, Height = 100,  Annotations= new DiagramObjectCollection<ShapeAnnotation>(){ new ShapeAnnotation() { Content="Routing Obstacle" } }, },
            new Node() { ID = "NonRoutingObstacle", OffsetX = 500, OffsetY = 250, Width = 100, Height = 100,  Annotations= new DiagramObjectCollection<ShapeAnnotation>(){ new ShapeAnnotation() { Content="Non-Routing Obstacle" } }, Constraints = NodeConstraints.Default & ~NodeConstraints.RoutingObstacle }
        };
        connectors = new DiagramObjectCollection<Connector>(){
            new Connector()
            {
                ID = "connector1",
                SourceID = "Source", TargetID = "Target", SourcePortID="port1", TargetPortID="port1",
                Type = ConnectorSegmentType.Orthogonal
            }
        };
    }
    private void OnNodeCreating(IDiagramObject obj)
    {
        if (obj is Node node)
        {
            node.Style = new ShapeStyle() { Fill = "#6BA5D7", StrokeColor = "#6BA5D7" };
        }
    }
    private void OnConnectorCreating(IDiagramObject obj)
    {
        if (obj is Connector connector)
        {
            connector.Style = new ShapeStyle() { StrokeColor = "#6BA5D7", StrokeWidth = 1 };
            connector.TargetDecorator = new DecoratorSettings()
                {
                    Shape = DecoratorShape.Arrow,
                    Style = new ShapeStyle() { Fill = "#6BA5D7", StrokeColor = "#6BA5D7", StrokeWidth = 1 }
                };
        }
    }
}
```
![Blazor Diagram RoutingObstacle for Node](../images/NodeRoutingObstable.png)

You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/Connectors/Interaction/NodeRoutingObstable).

### How to enable or disable routing for connectors

By default, each connector's routing process is inherited based on the value of the diagram's [Constraints](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_Constraints) property. If you wish to independently control the routing of a specific connector regardless of the diagram settings, you can achieve this by removing the [InheritRouting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.ConnectorConstraints.html#Syncfusion_Blazor_Diagram_ConnectorConstraints_InheritRouting) enum value from the connector's [Constraints](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.Connector.html#Syncfusion_Blazor_Diagram_Connector_Constraints) property. Then, add the [Routing](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.ConnectorConstraints.html#Syncfusion_Blazor_Diagram_ConnectorConstraints_Routing) enum value to enable routing or remove it to disable routing altogether.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Width="1000px" Height="500px" NodeCreating="@OnNodeCreating" ConnectorCreating="@OnConnectorCreating" Connectors="@connectors" Nodes="@nodes" Constraints="@diagramConstraints">
    <SnapSettings Constraints="SnapConstraints.None"></SnapSettings>
</SfDiagramComponent>
@code
{
    // Enable routing constraints for the diagram.
    DiagramConstraints diagramConstraints = DiagramConstraints.Default | DiagramConstraints.Routing;
    //Intialize the node collection
    DiagramObjectCollection<Node> nodes = new DiagramObjectCollection<Node>();
    //Intialize the connector collection
    DiagramObjectCollection<Connector> connectors = new DiagramObjectCollection<Connector>();
    protected override void OnInitialized()
    {
        nodes = new DiagramObjectCollection<Node>()
        {
            new Node() { ID = "Source", OffsetX = 90, OffsetY = 290, Width = 100, Height =100, Annotations= new DiagramObjectCollection<ShapeAnnotation>(){ new ShapeAnnotation() { Content="Source1" } }, Ports=new DiagramObjectCollection<PointPort>(){ new PointPort(){ ID="port1", Offset=new DiagramPoint() { X = 1, Y = 0.5 } } } },
            new Node() { ID = "Target", OffsetX = 700, OffsetY = 304, Width = 100, Height = 100, Annotations= new DiagramObjectCollection<ShapeAnnotation>(){ new ShapeAnnotation() { Content="Target1" } }, Ports=new DiagramObjectCollection<PointPort>(){ new PointPort(){ ID="port1", Offset=new DiagramPoint() { X = 0, Y = 0.5 } } } },
            new Node() { ID = "Source2", OffsetX = 120, OffsetY = 150, Width = 100, Height = 100,  Annotations= new DiagramObjectCollection<ShapeAnnotation>(){ new ShapeAnnotation() { Content="Source2" } }, },
            new Node() { ID = "Target2", OffsetX = 490, OffsetY = 250, Width = 100, Height = 100,  Annotations= new DiagramObjectCollection<ShapeAnnotation>(){ new ShapeAnnotation() { Content="Target2" } } },
            new Node() { ID = "Obstacle", OffsetX = 291, OffsetY = 300, Width = 100, Height = 100,  Annotations= new DiagramObjectCollection<ShapeAnnotation>(){ new ShapeAnnotation() { Content="Obstacle" } }, },
        };
        connectors = new DiagramObjectCollection<Connector>(){
            new Connector()
            {
                ID = "connector1",
                SourceID = "Source", TargetID = "Target",
                Type = ConnectorSegmentType.Orthogonal,
                // Disable the inherit routing for the connector
                Constraints = ConnectorConstraints.Default & ~ConnectorConstraints.InheritRouting,
                Annotations = new DiagramObjectCollection<PathAnnotation>(){ new PathAnnotation(){ Content = "Without Routing" } }
            },
            new Connector()
            {
                ID = "connector2",
                SourceID = "Source2", TargetID = "Target2",
                Type = ConnectorSegmentType.Orthogonal,
                // Enable the routing for the connector
                Constraints = (ConnectorConstraints.Default & ~ConnectorConstraints.InheritRouting) | ConnectorConstraints.Routing,
                Annotations = new DiagramObjectCollection<PathAnnotation>(){ new PathAnnotation(){ Content = "With Routing" } }
            }
        };
    }
    private void OnNodeCreating(IDiagramObject obj)
    {
        if (obj is Node node)
        {
            node.Style = new ShapeStyle() { Fill = "#6BA5D7", StrokeColor = "#6BA5D7" };
        }
    }
    private void OnConnectorCreating(IDiagramObject obj)
    {
        if (obj is Connector connector)
        {
            connector.Style = new ShapeStyle() { StrokeColor = "#6BA5D7", StrokeWidth = 1 };
            connector.TargetDecorator = new DecoratorSettings()
                {
                    Shape = DecoratorShape.Arrow,
                    Style = new ShapeStyle() { Fill = "#6BA5D7", StrokeColor = "#6BA5D7", StrokeWidth = 1 }
                };
        }
    }
}
```
![Blazor Diagram Routing for Connector](../images/ConnectorRoutingConstraints.png)

You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/Connectors/Interaction/RoutingConstraints).

### How to define distance between node and connector

The [ObstaclePadding](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.LineRoutingSettings.html#Syncfusion_Blazor_Diagram_LineRoutingSettings_ObstaclePadding) defines the minimum distance between the connectors and obstacles when the advanced routing is enabled. This ensures connectors are routed with clear spacing around obstacles, improving diagram readability.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Width="1000px" Height="500px" Connectors="@connectors" Nodes="@nodes" Constraints="@diagramConstraints">
    <LineRoutingSettings RoutingType ="@routingTypes" ObstaclePadding="@padding"></LineRoutingSettings>
</SfDiagramComponent>
@code 
{
    // Set the type of the routing
    RoutingTypes routingTypes = RoutingTypes.Advanced;
    // Set the padding for the obstable
    double padding = 20;
    // Enable routing constraints for diagram.
    DiagramConstraints diagramConstraints = DiagramConstraints.Default | DiagramConstraints.Routing;
    // Intialize the node collection.
    DiagramObjectCollection<Node> nodes = new DiagramObjectCollection<Node>();
    // Intialize the connector collection.
    DiagramObjectCollection<Connector> connectors = new DiagramObjectCollection<Connector>();
    
    protected override void OnInitialized()
    {
        nodes = new DiagramObjectCollection<Node>()
        {
            new Node() { ID = "node1", OffsetX = 100, OffsetY = 300, Width = 100, Height =100 },
            new Node() { ID = "node2", OffsetX = 600, OffsetY = 100, Width = 100, Height = 100 },
            new Node() { ID = "node3", OffsetX = 400, OffsetY = 250, Width = 100, Height = 100 }
        };
        connectors = new DiagramObjectCollection<Connector>(){
            new Connector()
            {
                ID = "connector1",
                SourceID = "node1", TargetID = "node2",
                Type = ConnectorSegmentType.Orthogonal
            }
        };
    }
}
```

You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/)

The following table shows the various obstacle padding.

| ObstaclePadding values | Output |
|---|---|
| 12 | ![Blazor Diagram ObstaclePadding12 ](../images/blazor-diagram-obstacle-padding12.png) |
| 20 | ![Blazor Diagram ObstaclePadding20 ](../images/blazor-diagram-obstacle-padding20.png) |

**Note:** [ObstaclePadding](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.LineRoutingSettings.html#Syncfusion_Blazor_Diagram_LineRoutingSettings_ObstaclePadding) property is only applicable when the [RoutingType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.LineRoutingSettings.html#Syncfusion_Blazor_Diagram_LineRoutingSettings_RoutingType) property is set to [RoutingTypes.Advanced]. Default value of [ObstaclePadding](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.LineRoutingSettings.html#Syncfusion_Blazor_Diagram_LineRoutingSettings_ObstaclePadding) is 12.

## How to flip the connector

The [Flip](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.NodeBase.html#Syncfusion_Blazor_Diagram_NodeBase_Flip) is performed to give the mirrored image of the original element.

For more information about the connector flip, refer to [Connector Flip](../flip#how-to-flip-the-connector).

## See also

* [How to customize the connector properties](./customization)

* [How to change the segments](./segments)

* [How to get the connector events](./events)