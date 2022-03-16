---
layout: post
title: Diagram Methods in Blazor Diagram Component | Syncfusion
description: Checkout and learn here all about Diagram Methods in Syncfusion Blazor Diagram component and much more.
platform: Blazor
control: DiagramComponent
documentation: ug
---

# Diagram Methods in Blazor Diagram Component

The diagram functionalities are performed using the following methods.

## Add nodes through Add method

To create a node, define the Node object and add it to the nodes collection of the diagram using the `Add()` method. The Add() method in the OnInitialized method will measure and render each diagram element individually before rendering the diagram. As a result, calling the Add() method outside of the OnInitialized() method is not feasible. The following code example shows how to add a node to the diagram.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px" Nodes="@nodes" />

@code
{
    DiagramObjectCollection<Node> nodes;

    protected override void OnInitialized()
    {
        nodes = new DiagramObjectCollection<Node>();
        // A node is created and stored in the nodes collection.
        Node node = new Node()
        {
            ID = "node1",
            // Position of the node.
            OffsetX = 250,
            OffsetY = 250,
            // Size of the node.
            Width = 100,
            Height = 100,
            Style = new ShapeStyle() 
            { 
                Fill = "#6495ED", 
                StrokeColor = "white" 
            }
        };
        // Add node.
        nodes.Add(node);
    }
}
```

## Add nodes through AddDiagramElements

 Unlike the Add() method, the [AddDiagramElements](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_AddDiagramElements_Syncfusion_Blazor_Diagram_DiagramObjectCollection_Syncfusion_Blazor_Diagram_NodeBase__) method will measure the passed elements before re-rendering the complete diagram component at once. When using the Add() method to add multiple nodes and connectors simultaneously, the connectors will be rendered before the nodes. As a result, connectors may be misplaced due to the synchronous behavior of the Add method. To overcome this, use the asynchronous AddDiagramElements() method.

* AddDiagramElements() method is a preferred way to add a collection of items to the diagram to get better performance compared to Add() method.

```cshtml
@using Syncfusion.Blazor.Diagram

<button @onclick="Test">Test</button>

<SfDiagramComponent @ref="Diagram" Width="1000px" Height="500px">
</SfDiagramComponent>

@code
{
    SfDiagramComponent Diagram;

    public async void Test()
    {
        Node node1 = new Node()
        {
            OffsetX = 100,
            OffsetY = 100,
            Height = 50,
            Ports = new DiagramObjectCollection<PointPort>()
                {
                    new PointPort()
                    {
                        ID="port1",
                        Visibility = PortVisibility.Visible,
                        Offset = new DiagramPoint() { X = 1, Y = 0.5},
                        Height = 10, Width = 10,
                        Style = new ShapeStyle(){Fill = "yellow", StrokeColor = "yellow"}
                    }
                },
            Width = 100,
            ID = "node1",
            Style = new ShapeStyle() { Fill = "#6495ED", StrokeColor = "#6495ED" },
            Shape = new BasicShape() { Type = Shapes.Basic, Shape = BasicShapeType.Rectangle }
        };
 
        Node node2 = new Node()
        {
            OffsetX = 300,
            OffsetY = 300,
            Height = 50,
            Width = 100,
            ID = "node2",
            Ports = new DiagramObjectCollection<PointPort>()
            {
                new PointPort()
                {
                    ID="port2",
                    Visibility = PortVisibility.Visible,
                    Offset = new DiagramPoint() { X = 0, Y = 0.5},
                    Height = 10, Width = 10,
                    Style = new ShapeStyle(){Fill = "yellow", StrokeColor = "yellow"}
               }
            },
            Style = new ShapeStyle() { Fill = "#6495ED", StrokeColor = "#6495ED" },
            Shape = new BasicShape() { Type = Shapes.Basic, Shape = BasicShapeType.Rectangle }
        };

        Connector Connector = new Connector()
        {
            ID = "connector1",
            //Source node id of the connector.
            SourceID = "node1",
            //source node port id.
            SourcePortID = "port1",
            //Target node id of the connector.
            TargetID = "node2",
            //Target node port id.
            TargetPortID = "port2",
            TargetDecorator = new DecoratorSettings()
            {
                Style = new ShapeStyle()
                {
                    Fill = "#6495ED",
                    StrokeColor = "#6495ED",
                }
            },
            Style = new ShapeStyle()
            {
                Fill = "#6495ED",
                StrokeColor = "#6495ED",
            },
            // Type of the connector
            Type = ConnectorSegmentType.Straight,
        };
        DiagramObjectCollection<NodeBase> NodeCollection = new DiagramObjectCollection<NodeBase>();
        NodeCollection.Add(node1);
        NodeCollection.Add(node2);
        NodeCollection.Add(Connector);
        await Diagram.AddDiagramElements(NodeCollection);
    }
}
```
