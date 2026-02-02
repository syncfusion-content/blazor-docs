---
layout: post
title: Actions of Connectors in Syncfusion Diagram Component | Syncfusion
description: Checkout and learn here all about actions of connectors in Syncfusion Blazor Diagram component and much more details.
platform: Blazor
control: Diagram Component
documentation: ug
---

# Connector in Diagram Component

Connectors create links between points, nodes or ports to represent the relationships between them.

## How to Create and Customize Connectors

A [Connector](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.Connector.html) is created by defining source and target points of the connector. The path to be drawn can be defined with a collection of segments.

To learn how to create and customize connectors easily in the Blazor Diagram component, watch the following video:

{% youtube "youtube:https://www.youtube.com/watch?v=EH4c8QVQoHo" %}

## How to Add Connectors Using the Connectors Collection

Use the [SourcePoint](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.Connector.html#Syncfusion_Blazor_Diagram_Connector_SourcePoint) and [TargetPoint](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.Connector.html#Syncfusion_Blazor_Diagram_Connector_TargetPoint) properties of connector to define the endpoints of a connector.

The following code example illustrates how to add a connector through the connectors collection.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Width="1000px" Height="500px" Connectors="@_connectors ">
    <SnapSettings Constraints="@_snapConstraints "></SnapSettings>
</SfDiagramComponent>

@code
{
    private SnapConstraints _snapConstraints  = SnapConstraints.None;
    //Defines diagram's connector collection.
    private DiagramObjectCollection<Connector> _connectors  = new DiagramObjectCollection<Connector>();

    protected override void OnInitialized()
    {
        Connector connector = new Connector()
        {
            ID = "connector1",
            // Set the source and target point of the connector.
            SourcePoint = new DiagramPoint() { X = 100, Y = 100 },
            TargetPoint = new DiagramPoint() { X = 200, Y = 200 },
            // Type of the connector segments.
            Type = ConnectorSegmentType.Straight
        };
        _connectors .Add(connector);
    }
}
```
A complete working sample can be downloaded from [GitHub](https://github.com/SyncfusionExamples/Blazor-UG-Examples/blob/master/Diagram/Server/Pages/Connectors/Connector/AddConnectorThroughConnectorCollection.razor).

{% previewsample "https://blazorplayground.syncfusion.com/embed/hNBoMNtRKRqMWtbh?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor Diagram Connector](../images/blazor-diagram-connector.png)" %}

>**Note:** 
> * The [ID](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.NodeBase.html#Syncfusion_Blazor_Diagram_NodeBase_ID) of each connector should be unique so it is further used to find the connector at runtime and perform any customization. 
> * Connector ID should not start with numbers or special characters and should not contain special characters such as underscores(_) or spaces.

## How to Add Connectors at Runtime

Add a connector at runtime by adding it to the connectors collection in the Diagram component. The following code explains how to add connectors at runtime.

```cshtml
@using Syncfusion.Blazor.Diagram
@using Syncfusion.Blazor.Buttons

<SfButton Content="Add Connector" OnClick="@AddConnector" />
<SfDiagramComponent Width="1000px" Height="500px" Connectors="@_connectors" />

@code
{
    //Defines diagram's connector collection.
    private DiagramObjectCollection<Connector> _connectors = new DiagramObjectCollection<Connector>();

    protected override void OnInitialized()
    {
        Connector connector = new Connector()
        {
            ID = "connector1",
            SourcePoint = new DiagramPoint() { X = 100, Y = 100 },
            TargetPoint = new DiagramPoint() { X = 200, Y = 200 },
            Type = ConnectorSegmentType.Straight
        };
        _connectors.Add(connector);
    }

    private void AddConnector()
    {
        Connector newConnector = new Connector()
        {
            ID = "connector2",
            SourcePoint = new DiagramPoint() { X = 300, Y = 300 },
            TargetPoint = new DiagramPoint() { X = 400, Y = 400 },
            Type = ConnectorSegmentType.Straight
        };
        //Add the connector at the runtime.
        _connectors.Add(newConnector);
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LNrSWjDxqRgcAwdw?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

A complete working sample can be downloaded from [GitHub](https://github.com/SyncfusionExamples/Blazor-UG-Examples/blob/master/Diagram/Server/Pages/Connectors/Connector/AddConnectorAtRuntime.razor).
### How to Clone a Connector at Runtime
[Clone](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.Connector.html#Syncfusion_Blazor_Diagram_Connector_Clone) is a virtual method on connector that creates a copy of a diagram object. After cloning, set a unique ID for the cloned connector. The following code demonstrates how to clone the connector during runtime.

```cshtml
@using Syncfusion.Blazor.Diagram
@using System.Collections.ObjectModel
@using Syncfusion.Blazor.Buttons
@inject IJSRuntime js

<SfButton Content="Clone Connector" OnClick="@CloneConnectors" />
<SfDiagramComponent @ref="_diagram" Width="50%" Height="500px" @bind-Connectors="@_connectors"></SfDiagramComponent>

@functions
{
    private SfDiagramComponent _diagram;
    private DiagramObjectCollection<Connector> _connectors = new DiagramObjectCollection<Connector>();

    protected override void OnInitialized()
    {
        Connector connector1 = new Connector() { ID = "connector1", SourcePoint = new DiagramPoint() { X = 100, Y = 10 }, TargetPoint = new DiagramPoint() { X = 200, Y = 100 }, Type = ConnectorSegmentType.Straight };
        _connectors.Add(connector1);
    }

    private async Task CloneConnectors()
    {
        Connector connector = _connectors[0].Clone() as Connector;
        connector.ID = RandomId();
        connector.SourcePoint = new DiagramPoint { X = 100, Y = 100 };
        connector.TargetPoint = new DiagramPoint { X = 200, Y = 100 };
        await _diagram.AddDiagramElementsAsync(new DiagramObjectCollection<NodeBase>() { connector });
    }

    private string RandomId()
    {
        Random random = new Random();
        const string Chars = "ABCDEFGHIJKLMNOPQRSTUVWXTZabcdefghiklmnopqrstuvwxyz";
#pragma warning disable CA5394 // Do not use insecure randomness
        return new string(Enumerable.Repeat(Chars, 5)
          .Select(s => s[random.Next(s.Length)]).ToArray());
#pragma warning restore CA5394 // Do not use insecure randomness
    }
}
```
A complete working sample can be downloaded from [GitHub](https://github.com/SyncfusionExamples/Blazor-UG-Examples/blob/master/Diagram/Server/Pages/Connectors/Connector/CloneConnector.razor)

{% previewsample "https://blazorplayground.syncfusion.com/embed/LjVSCZtHgnwMnRkK?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Cloning a connector in Blazor Diagram](../images/CloneConnector.gif)" %}

## How to Add a Connector with Annotations at Runtime

Add a connector with annotations at runtime in the diagram component by using the [AddDiagramElementsAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_AddDiagramElementsAsync_Syncfusion_Blazor_Diagram_DiagramObjectCollection_Syncfusion_Blazor_Diagram_NodeBase__) method.

The following code explains how to add a connector with annotation  at runtime by using the `AddDiagramElementsAsync` method.

```cshtml
@using Syncfusion.Blazor.Diagram
@using Syncfusion.Blazor.Buttons

<SfButton Content="Add Connector" OnClick="@AddConnector" />
<SfDiagramComponent @ref="_diagram" Width="1000px" Height="500px" Connectors="@_connectors"></SfDiagramComponent>

@code
{
    private SfDiagramComponent _diagram;

    //Defines diagram's connector collection.
    private DiagramObjectCollection<Connector> _connectors = new DiagramObjectCollection<Connector>();

    private DiagramObjectCollection<NodeBase> _connectorCollection = new DiagramObjectCollection<NodeBase>();

    protected override void OnInitialized()
    {
        Connector connector = new Connector()
        { 
            ID = "connector1",
            SourcePoint = new DiagramPoint() { X = 100, Y = 100 },
            TargetPoint = new DiagramPoint() { X = 200, Y = 200 },
            Type = ConnectorSegmentType.Straight
        };
        _connectors.Add(connector);
    }

    private async void AddConnector()
    {
        Connector newConnector = new Connector()
        { 
            ID = "connector2",
            SourcePoint = new DiagramPoint() { X = 300, Y = 300 },
            TargetPoint = new DiagramPoint() { X = 400, Y = 400 },
            Type = ConnectorSegmentType.Straight,
            Annotations = new DiagramObjectCollection<PathAnnotation>()
            {
                new PathAnnotation()
                {
                    Content="NewAnnotation"
                }
            },
        };
        _connectorCollection.Add(newConnector);
        await _diagram.AddDiagramElementsAsync(_connectorCollection);
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LjheijZRqdvOdfPm?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## How to Add a Connector to the Symbol Palette

Connectors can be predefined and added to the symbol palette. Then, drag and drop the connectors into the diagram when required.

```cshtml
@using Syncfusion.Blazor.Diagram
@using Syncfusion.Blazor.Diagram.SymbolPalette

<div style="width: 200px; float: left">
    <SfSymbolPaletteComponent Height="600px" @ref="@_paletteInstance" Palettes="@_palettes">
    </SfSymbolPaletteComponent>
</div>

<SfDiagramComponent @ref="@_diagramInstance" Width="1000px" Height="500px" Connectors="@_connectors" />

@code
{
    private SfSymbolPaletteComponent _paletteInstance;
    private SfDiagramComponent _diagramInstance;
    //Defines Symbol palette's PaletteConnector collection.
    private DiagramObjectCollection<NodeBase> _paletteConnector = new DiagramObjectCollection<NodeBase>();
    private DiagramObjectCollection<Palette> _palettes = new DiagramObjectCollection<Palette>();
    private DiagramObjectCollection<Connector> _connectors = new DiagramObjectCollection<Connector>();

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        _paletteInstance.Targets = new DiagramObjectCollection<SfDiagramComponent>() { };
        _paletteInstance.Targets.Add(_diagramInstance);
    }

    protected override void OnInitialized()
    {
        Connector connector = new Connector()
        {
            ID = "connector1",
            // Set the source and target point of the connector.
            SourcePoint = new DiagramPoint() { X = 100, Y = 100 },
            TargetPoint = new DiagramPoint() { X = 200, Y = 200 },
            // Type of the connector segments.
            Type = ConnectorSegmentType.Straight
        };
        _connectors.Add(connector);

        _paletteConnector = new DiagramObjectCollection<NodeBase>();
        Connector connector1 = new Connector
        {
            ID = "Link1",
            Type = ConnectorSegmentType.Straight,
            SourcePoint = new DiagramPoint() { X = 0, Y = 0 },
            TargetPoint = new DiagramPoint() { X = 60, Y = 60 }
        };
        _paletteConnector.Add(connector1 as NodeBase);

        Connector connector2 = new Connector
        {
            ID = "Link2",
            Type = ConnectorSegmentType.Orthogonal,
            SourcePoint = new DiagramPoint() { X = 0, Y = 0 },
            TargetPoint = new DiagramPoint() { X = 60, Y = 60 },
            TargetDecorator = new DecoratorSettings() { Shape = DecoratorShape.OpenArrow },
            Style = new ShapeStyle() { StrokeWidth = 1 }
        };
        _paletteConnector.Add(connector2 as NodeBase);

        Connector connector3 = new Connector
        {
            ID = "Link3",
            Type = ConnectorSegmentType.Bezier,
            SourcePoint = new DiagramPoint() { X = 0, Y = 0 },
            TargetPoint = new DiagramPoint() { X = 60, Y = 60 },
            TargetDecorator = new DecoratorSettings() { Shape = DecoratorShape.None },
        };
        _paletteConnector.Add(connector3 as NodeBase);

        _palettes = new DiagramObjectCollection<Palette>()
        {
            new Palette(){ Symbols = _paletteConnector , Title = "Connectors", IsExpanded = true },
        };
    }
}
```
A complete working sample can be downloaded from [GitHub](https://github.com/SyncfusionExamples/Blazor-UG-Examples/blob/master/Diagram/Server/Pages/Connectors/Connector/ConnectorFromPalette.razor)

{% previewsample "https://blazorplayground.syncfusion.com/embed/VDLSijDHAnuQEcxN?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Dragging connectors from the symbol palette into the diagram in Blazor](../images/blazor-diagram-connector-from-palette.gif)" %}

## How to Draw Connectors Using the Drawing Object

Connectors can be interactively drawn by clicking and dragging on the diagram surface by using the [DrawingObject](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_DrawingObject).

![Drawing a Connector interactively in Blazor Diagram](../images/blazor-diagram-draw-connector.gif)

## How to Remove Connectors at Runtime

Remove a connector from the diagram at runtime by using the `Remove` method.

The following code shows how to remove a connector at runtime.

```cshtml
@using Syncfusion.Blazor.Diagram
@using Syncfusion.Blazor.Buttons

<SfButton Content="Remove Connector" OnClick="@RemoveConnector" />
<SfDiagramComponent Width="1000px" Height="500px" Connectors="@_connectors">
    <SnapSettings Constraints="@_snapConstraints"></SnapSettings>
</SfDiagramComponent>

@code
{
    //Defines snap consttraints
    private SnapConstraints _snapConstraints = SnapConstraints.None;
    //Defines diagram's connector collection
    private DiagramObjectCollection<Connector> _connectors = new DiagramObjectCollection<Connector>();
    
    protected override void OnInitialized()
    {
        Connector connector = new Connector()
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
        _connectors.Add(connector);
    }

    private void RemoveConnector()
    {
        // Remove connector at runtime
        _connectors.Remove(_connectors[0]);
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/rNBoWNZHqcZySvbN?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

A complete working sample can be downloaded from [GitHub](https://github.com/SyncfusionExamples/Blazor-UG-Examples/blob/master/Diagram/Server/Pages/Connectors/Connector/RemoveConnectorsAtRunTime.razor)

A connector can also be removed from the diagram by using the native `RemoveAt` method. Refer to the following example that shows how to remove the connector at runtime.

```cshtml
public void RemoveConnector()
{
    connectors.RemoveAt(0);
}
```

## How to Update Connector Properties at Runtime

Connector properties can be changed at runtime.

The following code example explains how to change the connector properties.

```cshtml
@using Syncfusion.Blazor.Diagram
@using Syncfusion.Blazor.Buttons

<SfButton Content="Update Connector" OnClick="@UpdateConnector" />
<SfDiagramComponent @ref="_diagram" Width="1000px" Height="500px" Connectors="@_connectors">
    <SnapSettings Constraints="@_snapConstraints"></SnapSettings>
</SfDiagramComponent>

@code {
    //Reference the diagram
    private SfDiagramComponent _diagram;
    //Defines the snap constraints
    private SnapConstraints _snapConstraints = SnapConstraints.None;
    //Defines diagram's connector collection
    private DiagramObjectCollection<Connector> _connectors = new DiagramObjectCollection<Connector>();

    protected override void OnInitialized()
    {
        Connector connector = new Connector()
        {
            ID = "connector1",
            SourcePoint = new DiagramPoint() { X = 100, Y = 100 },
            TargetPoint = new DiagramPoint() { X = 200, Y = 200 },
            TargetDecorator = new DecoratorSettings() 
            { 
                Shape = DecoratorShape.Arrow, 
                Style = new ShapeStyle() 
                { 
                    Fill = "#6f409f", 
                    StrokeColor = "#6f409f", 
                    StrokeWidth = 1 
                } 
            },
            Style = new ShapeStyle() { StrokeColor = "#6f409f", StrokeWidth = 1 },
            // Type of the connector
            Type = ConnectorSegmentType.Straight,
        };
        _connectors.Add(connector);
    }

    //Method to update connector at runtime.
    private async Task UpdateConnector()
    {
        _diagram.BeginUpdate();
        _diagram.Connectors[0].SourcePoint.X = 50;
        _diagram.Connectors[0].SourcePoint.Y = 50;
        await _diagram.EndUpdateAsync();
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BXhoCXXRAwsrsupa?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

A complete working sample can be downloaded from [GitHub](https://github.com/SyncfusionExamples/Blazor-UG-Examples/blob/master/Diagram/Server/Pages/Connectors/Connector/UpdateConnectorAtRunTime.razor).

N> [BeginUpdate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_BeginUpdate) and [EndUpdateAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_EndUpdateAsync) methods allow you to temporarily stop the continuous update of the control and resume it once the updates are complete.

## Connections

Connectors are used to create links between two points, nodes or ports to represent relationships between them.

### How to Connect Nodes Using Source and Target ID

Use the [SourceID](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.Connector.html#Syncfusion_Blazor_Diagram_Connector_SourceID) and [TargetID](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.Connector.html#Syncfusion_Blazor_Diagram_Connector_TargetID) properties to define the nodes to be connected.

The following code example illustrates how to connect two nodes.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent @ref="_diagram" Width="1000px" Height="500px" Nodes="@_nodes" Connectors="@_connectors" />

@code
{
    private SfDiagramComponent _diagram;
    private DiagramObjectCollection<Connector> _connectors = new DiagramObjectCollection<Connector>();
    private DiagramObjectCollection<Node> _nodes = new DiagramObjectCollection<Node>();

    protected override void OnInitialized()
    {
        _nodes = new DiagramObjectCollection<Node>()
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
        Connector connector = new Connector()
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
        _connectors.Add(connector);
    }
}
```
A complete working sample can be downloaded from [GitHub](https://github.com/SyncfusionExamples/Blazor-UG-Examples/blob/master/Diagram/Server/Pages/Connectors/Connector/ConnectWithNode.razor).

{% previewsample "https://blazorplayground.syncfusion.com/embed/rtLIsZZHKcMbFFXS?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Displaying Connection between Nodes in Blazor Diagram](../images/blazor-diagram-node-to-node-connection.png)" %}

* Removing [NodeConstraints.InConnect](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.NodeConstraints.html#Syncfusion_Blazor_Diagram_NodeConstraints_InConnect) from Default, the node accepts only an outgoing connection to dock in it. Similarly, when you remove [NodeConstraints.OutConnect](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.NodeConstraints.html#Syncfusion_Blazor_Diagram_NodeConstraints_OutConnect) from Default, the node accepts only an incoming connection to dock in it.

* Removing both `InConnect` and `OutConnect` constraints from `Default`, the node restricts connectors from establishing a connection to it.

### How to Connect Nodes Using Specific Ports

Use the [SourcePortID](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.Connector.html#Syncfusion_Blazor_Diagram_Connector_SourcePortID) and [TargetPortID](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.Connector.html#Syncfusion_Blazor_Diagram_Connector_TargetPortID) properties to create connections between specific points on the source or target nodes.

The following code example illustrates how to create port to port connections.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent @ref="_diagram" Width="1000px" Height="500px" Nodes="@_nodes" Connectors="@_connectors" />

@code
{
    private SfDiagramComponent _diagram;
    private DiagramObjectCollection<Connector> _connectors = new DiagramObjectCollection<Connector>();
    private DiagramObjectCollection<Node> _nodes = new DiagramObjectCollection<Node>();

    protected override void OnInitialized()
    {
        _nodes = new DiagramObjectCollection<Node>()
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
        Connector connector = new Connector()
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
        _connectors.Add(connector);
    }
}
```
A complete working sample can be downloaded from [GitHub](https://github.com/SyncfusionExamples/Blazor-UG-Examples/blob/master/Diagram/Server/Pages/Connectors/Connector/ConnectWithPort.razor).

{% previewsample "https://blazorplayground.syncfusion.com/embed/htByCjDRKwBxkAkt?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Connecting two nodes using specific ports in Blazor Diagram](../images/blazor-diagram-port-to-port-connection.png)" %}

* Set [PortConstraints](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.PortConstraints.html) to **InConnect**, to accept only incoming connection to dock in it. Similarly, Set PortConstraints to **OutConnect**, to accept only an outgoing connection to dock in it.
* Setting **None**, the port restricts connectors from establishing a connection to the port.

## See also

* [How to customize the connector properties](./customization)

* [How to interact with the connector](./interactions)

* [How to change the segments](./segments/straight)

* [How to get the connector events](./events)

* [How to add annotations to the connectors](../annotations/labels)

* [How to Customize Connector Styles in a Hierarchical Layout in Blazor Diagram](https://support.syncfusion.com/kb/article/16310/how-to-customize-connector-styles-in-a-hierarchical-layout-in-blazor-diagram)

* [Why save and load functionality for nodes and connectors in Blazor Diagram?](https://support.syncfusion.com/kb/article/16008/why-save-and-load-functionality-for-nodes-and-connectors-in-blazor-diagram) 

* [How to Add Nodes or Connectors by Clicking on the Diagram in Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Diagram Component?](https://support.syncfusion.com/kb/article/17233/how-to-add-nodes-or-connectors-by-clicking-on-the-diagram-in-syncfusion-blazor-diagram-component)

* [How to add nodes and connectors at runtime asynchronously in Blazor Diagram Component?](https://support.syncfusion.com/kb/article/17285/how-to-add-nodes-and-connectors-at-runtime-asynchronously-in-blazor-diagram-component)

* [How to render the Freehand connector in symbol palette?](https://support.syncfusion.com/kb/article/17236/how-to-render-the-freehand-connector-in-symbol-palette)

* [How to Select and Highlight Ports and Connect Selected Elements in Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Diagram](https://support.syncfusion.com/kb/article/18997/how-to-select-and-highlight-ports-and-connect-selected-elements-in-syncfusion-blazor-diagram)  

* [How to Dynamically Create and Connect Diagram Nodes with Annotations via Ports in Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Diagram](https://support.syncfusion.com/kb/article/19001/how-to-dynamically-create-and-connect-diagram-nodes-with-annotations-via-ports-in-syncfusion-blazor-diagram)

* [How to Provide IDs for Diagram Elements in Blazor Diagrams](https://support.syncfusion.com/kb/article/17898/how-to-provide-ids-for-diagram-elements-in-blazor-diagrams)