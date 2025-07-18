---
layout: post
title: Actions of Connectors in Blazor Diagram Component | Syncfusion
description: Checkout and learn here all about actions of connectors in Syncfusion Blazor Diagram component and more.
platform: Blazor
control: Diagram Component
documentation: ug
---

# Connector in Blazor Diagram Component

Connectors are objects used to create link between two points, nodes or ports to represent the relationships between them.

## How to Create and Customize Connector

[Connector](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.Connector.html) can be created by defining the source and target points of the connector. The path to be drawn can be defined with a collection of segments.

To create and customize the connectors easily in the Blazor Diagram component, refer to the below video link.

{% youtube "youtube:https://www.youtube.com/watch?v=EH4c8QVQoHo" %}

## How to Add Connectors Using the Connectors Collection

The [SourcePoint](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.Connector.html#Syncfusion_Blazor_Diagram_Connector_SourcePoint) and [TargetPoint](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.Connector.html#Syncfusion_Blazor_Diagram_Connector_TargetPoint) properties of connector allow you to define the endpoints of a connector.

The following code example illustrates how to add a connector through the connector collection,

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Width="1000px" Height="500px" Connectors="@connectors">
    <SnapSettings Constraints="@snapConstraints"></SnapSettings>
</SfDiagramComponent>

@code
{
    SnapConstraints snapConstraints = SnapConstraints.None;
    //Defines diagram's connector collection.
    DiagramObjectCollection<Connector> connectors = new DiagramObjectCollection<Connector>();

    protected override void OnInitialized()
    {
        Connector Connector = new Connector()
        {
            ID = "connector1",
            // Set the source and target point of the connector.
            SourcePoint = new DiagramPoint() { X = 100, Y = 100 },
            TargetPoint = new DiagramPoint() { X = 200, Y = 200 },
            // Type of the connector segments.
            Type = ConnectorSegmentType.Straight
        };
        connectors.Add(Connector);
    }
}
```
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/Connectors/ActionofConnectors/AddConnectorThroughConnectorCollection)

![Blazor Diagram Connector](../images/blazor-diagram-connector.png)

>**Note:** 
> * [ID](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.NodeBase.html#Syncfusion_Blazor_Diagram_NodeBase_ID) for each connector should be unique and so it is further used to find the connector at runtime and perform any customization. 
> * Connectors' Id should not start with numbers or special characters and should not contain special characters such as underscores(_) or spaces.

## How to Add Connectors at Runtime

You can add a connector at runtime by adding connector to the connectors collection in the Diagram component. The following code explains how to add connectors at runtime.

```cshtml
@using Syncfusion.Blazor.Diagram
@using Syncfusion.Blazor.Buttons


<SfButton Content="Add Connector" OnClick="@AddConnector" />
<SfDiagramComponent Width="1000px" Height="500px" Connectors="@connectors"></SfDiagramComponent>

@code
{

    //Defines diagram's connector collection.
    DiagramObjectCollection<Connector> connectors = new DiagramObjectCollection<Connector>();

    protected override void OnInitialized()
    {
        Connector Connector = new Connector()
        { 
            ID = "connector1",
            SourcePoint = new DiagramPoint() { X = 100, Y = 100 },
            TargetPoint = new DiagramPoint() { X = 200, Y = 200 },
            Type = ConnectorSegmentType.Straight
        };
        connectors.Add(Connector);
    }

    public void AddConnector()
    {
        Connector NewConnector = new Connector()
        { 
            ID = "connector2",
            SourcePoint = new DiagramPoint() { X = 300, Y = 300 },
            TargetPoint = new DiagramPoint() { X = 400, Y = 400 },
            Type = ConnectorSegmentType.Straight
        };
        //Add the connector at the run time.
        connectors.Add(NewConnector);
    }
}
```
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/Connectors/ActionofConnectors/AddConnectorAtRuntime)
### How to Clone a Connector at Runtime
[Clone](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.Connector.html#Syncfusion_Blazor_Diagram_Connector_Clone) is a virtual method of the connector that is used to create a copy of a diagram object. After cloning, we need to set the ID for the cloned connectors. The following code demonstrates how to clone the connector during runtime.

```cshtml
@using Syncfusion.Blazor.Diagram
@using System.Collections.ObjectModel
@using Syncfusion.Blazor.Buttons
@inject IJSRuntime js

<SfButton Content="Clone Connector" OnClick="@CloneConnector" />
<SfDiagramComponent @ref="diagram" Width="50%" Height="500px" @bind-Connectors="@Connectors"></SfDiagramComponent>

@functions
{

    SfDiagramComponent diagram;
    public DiagramObjectCollection<Connector> Connectors = new DiagramObjectCollection<Connector>();
    protected override void OnInitialized()
    {
        Connector connector1 = new Connector() { ID = "connector1", SourcePoint = new DiagramPoint() { X = 100, Y = 10 }, TargetPoint = new DiagramPoint() { X = 200, Y = 100 }, Type = ConnectorSegmentType.Straight };
        Connectors.Add(connector1);
    }
    public async Task CloneConnector()
    {
        Connector connector = Connectors[0].Clone() as Connector;
        connector.ID = RandomId();
        connector.SourcePoint = new DiagramPoint { X = 100, Y = 100 };
        connector.TargetPoint = new DiagramPoint { X = 200, Y = 100 };
        await diagram.AddDiagramElementsAsync(new DiagramObjectCollection<NodeBase>() { connector });

    }
    internal string RandomId()
    {
        Random random = new Random();
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXTZabcdefghiklmnopqrstuvwxyz";
#pragma warning disable CA5394 // Do not use insecure randomness
        return new string(Enumerable.Repeat(chars, 5)
          .Select(s => s[random.Next(s.Length)]).ToArray());
#pragma warning restore CA5394 // Do not use insecure randomness
    }

}
```
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/Connectors/CloneConnector)
![Clonning Node](../images/CloneConnector.gif)
## How to Add a Connector with Annotations at Runtime

You can add a connector with annotation at runtime in the diagram component by using the [AddDiagramElementsAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_AddDiagramElementsAsync_Syncfusion_Blazor_Diagram_DiagramObjectCollection_Syncfusion_Blazor_Diagram_NodeBase__) method.

The following code explains how to add a connector with annotation  at runtime by using the `AddDiagramElementsAsync` method.

```cshtml
@using Syncfusion.Blazor.Diagram
@using Syncfusion.Blazor.Buttons

<SfButton Content="Add Connector" OnClick="@AddConnector" />
<SfDiagramComponent Width="1000px" Height="500px" Connectors="@connectors"></SfDiagramComponent>

@code
{

    //Defines diagram's connector collection.
    DiagramObjectCollection<Connector> connectors = new DiagramObjectCollection<Connector>();

    DiagramObjectCollection<NodeBase> NodeCollection = new DiagramObjectCollection<NodeBase>();

    protected override void OnInitialized()
    {
        Connector Connector = new Connector()
        { 
            ID = "connector1",
            SourcePoint = new DiagramPoint() { X = 100, Y = 100 },
            TargetPoint = new DiagramPoint() { X = 200, Y = 200 },
            Type = ConnectorSegmentType.Straight
        };
        connectors.Add(Connector);
    }

    public async void AddConnector()
    {
        Connector NewConnector = new Connector()
        { 
            ID = "connector2",
            SourcePoint = new DiagramPoint() { X = 300, Y = 300 },
            TargetPoint = new DiagramPoint() { X = 400, Y = 400 },
            Type = ConnectorSegmentType.Straight,
             Annotations=new DiagramObjectCollection<PathAnnotation>()
            {
                new PathAnnotation()
                {
                    Content="NewAnnotation"
                }
            },
        };
        NodeCollection.Add(NewConnector);
       await Diagram.AddDiagramElementsAsync(NodeCollection);
    }
}
```

## How to Add a Connector to the Symbol Palette

Connectors can be predefined and added to the symbol palette. You can drop those connectors into the diagram when required.

```cshtml
@using Syncfusion.Blazor.Diagram
@using Syncfusion.Blazor.Diagram.SymbolPalette

<div style="width: 200px; float: left">
    <SfSymbolPaletteComponent Height="600px" @ref="@PaletteInstance" Palettes="@Palettes">
    </SfSymbolPaletteComponent>
</div>

<SfDiagramComponent @ref="@DiagramInstance" Width="1000px" Height="500px" Connectors="@connectors"></SfDiagramComponent>

@code
{
    SfSymbolPaletteComponent PaletteInstance;
    SfDiagramComponent DiagramInstance;
    //Defines Symbol palette's PaletteConnector collection.
    DiagramObjectCollection<NodeBase> PaletteConnector = new DiagramObjectCollection<NodeBase>();
    DiagramObjectCollection<Palette> Palettes = new DiagramObjectCollection<Palette>();

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        PaletteInstance.Targets = new DiagramObjectCollection<SfDiagramComponent>() { };
        PaletteInstance.Targets.Add(DiagramInstance);
    }

    DiagramObjectCollection<Connector> connectors = new DiagramObjectCollection<Connector>();

    protected override void OnInitialized()
    {
        Connector Connector = new Connector()
        {
            ID = "connector1",
            // Set the source and target point of the connector.
            SourcePoint = new DiagramPoint() { X = 100, Y = 100 },
            TargetPoint = new DiagramPoint() { X = 200, Y = 200 },
            // Type of the connector segments.
            Type = ConnectorSegmentType.Straight
        };
        connectors.Add(Connector);
        PaletteConnector = new DiagramObjectCollection<NodeBase>();
        Connector connector = new Connector
        {
            ID = "Link1",
            Type = ConnectorSegmentType.Straight,
            SourcePoint = new DiagramPoint() { X = 0, Y = 0 },
            TargetPoint = new DiagramPoint() { X = 60, Y = 60 }                                                                                 
        };
        PaletteConnector.Add(connector as NodeBase);
        Connector connector2 = new Connector
        {
            ID = "Link2",
            Type = ConnectorSegmentType.Orthogonal,
            SourcePoint = new DiagramPoint() { X = 0, Y = 0 },
            TargetPoint = new DiagramPoint() { X = 60, Y = 60 },
            TargetDecorator = new DecoratorSettings() { Shape = DecoratorShape.OpenArrow },
            Style = new ShapeStyle() { StrokeWidth =1}
        };
        PaletteConnector.Add(connector2 as NodeBase);
        Connector connector3 = new Connector
        {
            ID = "Link3",
            Type = ConnectorSegmentType.Bezier,
            SourcePoint = new DiagramPoint() { X = 0, Y = 0 },
            TargetPoint = new DiagramPoint() { X = 60, Y = 60 },
            TargetDecorator = new DecoratorSettings() { Shape = DecoratorShape.None },
        };
        PaletteConnector.Add(connector3 as NodeBase);
        Palettes = new DiagramObjectCollection<Palette>()
        {
            new Palette(){ Symbols = PaletteConnector, Title = "Connectors", IsExpanded = true },
        };
    }
}
```
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/Connectors/ActionofConnectors/ConnectorFromPalette)

![Connector from Palette in Blazor Diagram](../images/blazor-diagram-connector-from-palette.gif)

## How to Draw Connectors Using the Drawing Object

Connectors can be interactively drawn by clicking and dragging on the diagram surface by using the [DrawingObject](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_DrawingObject).

![Drawing Connector in Blazor Diagram](../images/blazor-diagram-draw-connector.gif)

## How to Remove Connectors at Runtime

A connector can be removed from the diagram at runtime by using the `Remove` method.

The following code shows how to remove a connector at runtime.

```cshtml
@using Syncfusion.Blazor.Diagram
@using Syncfusion.Blazor.Buttons


<SfButton Content="Remove Connector" OnClick="@RemoveConnector" />
<SfDiagramComponent Width="1000px" Height="500px" Connectors="@connectors">
    <SnapSettings Constraints="@snapConstraints"></SnapSettings>
</SfDiagramComponent>
@code {
    //Defines snap consttraints
    SnapConstraints snapConstraints = SnapConstraints.None;
    //Defines diagram's connector collection
    DiagramObjectCollection<Connector> connectors = new DiagramObjectCollection<Connector>();
    protected override void OnInitialized()
    {
        Connector Connector = new Connector()
            {
                ID = "connector1",
                // Set the source and target point of the connector
                SourcePoint = new DiagramPoint() { X = 100, Y = 100 },
                TargetPoint = new DiagramPoint() { X = 200, Y = 200 },
                TargetDecorator = new DecoratorSettings()
                {
                    Shape = DecoratorShape.Arrow,
                    // Style of the connector segment
                    Style = new ShapeStyle() { Fill = "#6f409f", StrokeColor = "#6f409f", StrokeWidth = 1 }
                },
                Style = new ShapeStyle() { StrokeColor = "#6f409f", StrokeWidth = 1 },
                // Type of the connector
                Type = ConnectorSegmentType.Straight,
            };
        connectors.Add(Connector);
    }
    public void RemoveConnector()
    {
        // Remove connector at runtime
        connectors.Remove(connectors[0]);
    }
}
```
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/Connectors/ActionofConnectors/RemoveConnectorsAtRunTime)

A connector can be removed from the diagram by using the native `RemoveAt` method. Refer to the following example that shows how to remove the connector at runtime.

```cshtml
public void RemoveConnector()
{
    connectors.RemoveAt(0);
}
```

## How to Update Connector Properties at Runtime

You can change any connector's properties at runtime.

The following code example explains how to change the connector properties.

```cshtml
@using Syncfusion.Blazor.Diagram
@using Syncfusion.Blazor.Buttons


<SfButton Content="Update Connector" OnClick="@UpdateConnector" />
<SfDiagramComponent @ref="Diagram" Width="1000px" Height="500px" Connectors="@connectors">
    <SnapSettings Constraints="@snapConstraints"></SnapSettings>
</SfDiagramComponent>
@code {
    //Reference the diagram
    SfDiagramComponent Diagram;
    //Defines the snap constraints
    SnapConstraints snapConstraints = SnapConstraints.None;
    //Defines diagram's connector collection
    DiagramObjectCollection<Connector> connectors = new DiagramObjectCollection<Connector>();
    protected override void OnInitialized()
    {
        Connector Connector = new Connector()
            {
                ID = "connector1",
                SourcePoint = new DiagramPoint() { X = 100, Y = 100 },
                TargetPoint = new DiagramPoint() { X = 200, Y = 200 },
                TargetDecorator = new DecoratorSettings() { Shape = DecoratorShape.Arrow, Style = new ShapeStyle() { Fill = "#6f409f", StrokeColor = "#6f409f", StrokeWidth = 1 } },
                Style = new ShapeStyle() { StrokeColor = "#6f409f", StrokeWidth = 1 },
                // Type of the connector
                Type = ConnectorSegmentType.Straight,
            };
        connectors.Add(Connector);
    }
    //Method to update connector at runtime.
    public void UpdateConnector()
    {
        Diagram.BeginUpdate();
        Diagram.Connectors[0].SourcePoint.X = 50;
        Diagram.Connectors[0].SourcePoint.Y = 50;
        Diagram.EndUpdateAsync();
    }
}
```
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/Connectors/ActionofConnectors/UpdateConnectorAtRunTime)

N> [BeginUpdate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_BeginUpdate) and [EndUpdateAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_EndUpdateAsync) methods allow you to temporarily stop the continuous update of the control and resume it once the updates are complete.

## Connections

Connectors are used to create a link between two points, nodes or ports to represent the relationships between them.

### How to Connect Nodes Using Source and Target ID

The [SourceID](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.Connector.html#Syncfusion_Blazor_Diagram_Connector_SourceID) and [TargetID](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.Connector.html#Syncfusion_Blazor_Diagram_Connector_TargetID) properties allow to define the nodes to be connected.

The following code example illustrates how to connect two nodes.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent @ref="Diagram" Width="1000px" Height="500px" Nodes="@nodes" Connectors="@connectors">
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
                Style = new ShapeStyle(){ Fill = "#6495ED", StrokeColor = "#6495ED" },
                Shape = new BasicShape() { Type = NodeShapes.Basic, Shape = NodeBasicShapes.Rectangle }
            },
            new Node()
            {
                OffsetX = 300,
                OffsetY = 300,
                Height = 50,
                Width = 100,
                ID = "node2",
                Style = new ShapeStyle(){ Fill = "#6495ED", StrokeColor = "#6495ED" },
                Shape = new BasicShape() { Type = NodeShapes.Basic, Shape = NodeBasicShapes.Rectangle }
            }
        };
        Connector Connector = new Connector()
        {
            ID = "connector1",
            //Source node id of the connector.
            SourceID = "node1",
            TargetDecorator = new DecoratorSettings()
            {
                Style = new ShapeStyle()
                {
                    Fill = "#6495ED",
                    StrokeColor = "#6495ED",
                }
            },
            //Target node id of the connector.
            TargetID = "node2",
            Style = new ShapeStyle()
            {
                Fill = "#6495ED",
                StrokeColor = "#6495ED",
            },
            // Type of the connector.
            Type = ConnectorSegmentType.Straight,
        };
        connectors.Add(Connector);
    }
}
```
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/Connectors/ActionofConnectors/ConnectWithNode)

![Displaying Connection between Nodes in Blazor Diagram](../images/blazor-diagram-node-to-node-connection.png)

* When you remove [NodeConstraints.InConnect](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.NodeConstraints.html#Syncfusion_Blazor_Diagram_NodeConstraints_InConnect) from Default, the node accepts only an outgoing connection to dock in it. Similarly, when you remove [NodeConstraints.OutConnect](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.NodeConstraints.html#Syncfusion_Blazor_Diagram_NodeConstraints_OutConnect) from Default, the node accepts only an incoming connection to dock in it.

* When you remove both InConnect and OutConnect [NodeConstraints](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.NodeConstraints.html) from [Default](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.NodeConstraints.html#Syncfusion_Blazor_Diagram_NodeConstraints_Default), the node restricts connectors from establishing a connection to it.

### How to Connect Nodes Using Specific Ports

The [SourcePortID](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.Connector.html#Syncfusion_Blazor_Diagram_Connector_SourcePortID) and [TargetPortID](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.Connector.html#Syncfusion_Blazor_Diagram_Connector_TargetPortID) properties allow to create connections between some specific points of source/target nodes.

The following code example illustrates how to create port to port connections.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent @ref="Diagram" Width="1000px" Height="500px" Nodes="@nodes" Connectors="@connectors">
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
                Ports = new DiagramObjectCollection<PointPort>()
                {
                    new PointPort()
                    {
                        ID="port1",
                        Visibility = PortVisibility.Visible,
                        Offset = new DiagramPoint() { X = 1, Y = 0.5},
                        Height = 10, Width = 10,
                        Style =  new ShapeStyle(){Fill = "yellow", StrokeColor = "yellow"}
                    }
                },
                Width = 100,
                ID = "node1",
                Style = new ShapeStyle(){ Fill = "#6495ED", StrokeColor = "#6495ED"},
                Shape = new BasicShape() { Type = NodeShapes.Basic, Shape = NodeBasicShapes.Rectangle }
            },
            new Node()
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
                        Style =  new ShapeStyle(){Fill = "yellow", StrokeColor = "yellow"}
                    }
                },
                Style = new ShapeStyle(){ Fill = "#6495ED", StrokeColor = "#6495ED" },
                Shape = new BasicShape() { Type = NodeShapes.Basic, Shape = NodeBasicShapes.Rectangle }
              }
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
            // Type of the connector.
            Type = ConnectorSegmentType.Straight,
        };
        connectors.Add(Connector);
    }
}
```
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/Connectors/ActionofConnectors/ConnectWithPort)

![Connection between Ports in Blazor Diagram](../images/blazor-diagram-port-to-port-connection.png)

* When you set [PortConstraints](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.PortConstraints.html) to [InConnect](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.PortConstraints.html#Syncfusion_Blazor_Diagram_PortConstraints_InConnect), the port accepts only an incoming connection to dock in it. Similarly, when you set PortConstraints to [OutConnect](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.PortConstraints.html#Syncfusion_Blazor_Diagram_PortConstraints_OutConnect), the port accepts only an outgoing connection to dock in it.
* When you set PortConstraints to [None](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.PortConstraints.html#Syncfusion_Blazor_Diagram_PortConstraints_None), the port restricts connectors from establishing a connection to it.

## See also

* [How to customize the connector properties](./customization)

* [How to interact with the connector](./interactions)

* [How to change the segments](./segments)

* [How to get the connector events](./events)

* [How to add annotations to the connectors](../annotations/labels)

* [How to Customize Connector Styles in a Hierarchical Layout in Blazor Diagram](https://support.syncfusion.com/kb/article/16310/how-to-customize-connector-styles-in-a-hierarchical-layout-in-blazor-diagram)

* [Why save and load functionality for nodes and connectors in Blazor Diagram?](https://support.syncfusion.com/kb/article/16008/why-save-and-load-functionality-for-nodes-and-connectors-in-blazor-diagram) 

* [How to Add Nodes or Connectors by Clicking on the Diagram in Syncfusion Blazor Diagram Component?](https://support.syncfusion.com/kb/article/17233/how-to-add-nodes-or-connectors-by-clicking-on-the-diagram-in-syncfusion-blazor-diagram-component)

* [How to add nodes and connectors at runtime asynchronously in Blazor Diagram Component?](https://support.syncfusion.com/kb/article/17285/how-to-add-nodes-and-connectors-at-runtime-asynchronously-in-blazor-diagram-component)

* [How to render the Freehand connector in symbol palette?](https://support.syncfusion.com/kb/article/17236/how-to-render-the-freehand-connector-in-symbol-palette)

* [How to Select and Highlight Ports and Connect Selected Elements in Syncfusion Blazor Diagram](https://support.syncfusion.com/kb/article/18997/how-to-select-and-highlight-ports-and-connect-selected-elements-in-syncfusion-blazor-diagram)  

* [How to Dynamically Create and Connect Diagram Nodes with Annotations via Ports in Syncfusion Blazor Diagram](https://support.syncfusion.com/kb/article/19001/how-to-dynamically-create-and-connect-diagram-nodes-with-annotations-via-ports-in-syncfusion-blazor-diagram)

* [How to Provide IDs for Diagram Elements in Blazor Diagrams](https://support.syncfusion.com/kb/article/17898/how-to-provide-ids-for-diagram-elements-in-blazor-diagrams)