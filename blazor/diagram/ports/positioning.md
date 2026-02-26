---
layout: post
title: Positioning a Port in Syncfusion Blazor Diagram Component | Syncfusion
description: Checkout and learn here all about Port positioning in Syncfusion Blazor Diagram component and much more details.
platform: Blazor
control: Diagram Component
documentation: ug
---

# Positioning a Port in Diagram Component

Customize the position and appearance of the port efficiently. Ports can be aligned relative to node boundaries. It has Margin, Offset, Horizontal, and Vertical alignment settings. It is quite tricky when all four alignments are used together but gives more control over alignments properties of the [PointPort](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.PointPort.html) class. Ports of a node can be positioned using the following properties of `PointPort`.

* Offset
* HorizontalAlignment
* VerticalAlignment
* Margin

## How to Change Offset at Runtime

Use [Offset](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.PointPort.html#Syncfusion_Blazor_Diagram_PointPort_Offset) to place a port using fractional values relative to the node: **0** represents the top/left, **1** represents the bottom/right, and **0.5** represents the center along each axis.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px" Nodes="@_nodes"/>

@code
{
    private DiagramObjectCollection<Node> _nodes;
    protected override void OnInitialized()
    {
        _nodes = new DiagramObjectCollection<Node>();
        // A node is created and stored in _nodes collection.
        Node node = new Node()
        {
            // Position of the node.
            OffsetX = 250,
            OffsetY = 250,
            // Size of the node.
            Width = 100,
            Height = 100,
            Style = new ShapeStyle() { Fill = "#6495ED", StrokeColor = "white" },
            // Initialize port collection.
            Ports = new DiagramObjectCollection<PointPort>()
            {
                new PointPort() 
                {
                    ID = "port1",
                    // Sets the offset for the port.
                    Offset = new DiagramPoint() { X = 0, Y = 0.5 },
                    Visibility = PortVisibility.Visible,
                    //Set the style for the port.
                    Style= new ShapeStyle() { Fill = "gray", StrokeColor = "black" },
                    Width = 12,
                    Height = 12,
                    // Sets the shape of the port as Square .
                    Shape = PortShapes.Square
                }
            }
        };
        _nodes.Add(node);
    }
}
```
A complete working sample can be downloaded from [GitHub](https://github.com/SyncfusionExamples/Blazor-UG-Examples/blob/master/Diagram/Server/Pages/Ports/Positioning/PortOffset.razor)

{% previewsample "https://blazorplayground.syncfusion.com/embed/rtVoiDXGrosCrFqt?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Port positioned using Offset values in Blazor Diagram](../images/blazor-diagram-port-offset.png)" %}

The following table shows the relationship between the shape port position and path port offset (fraction values).

| Offset values | Output |
|---|---|
| (0,0) | ![Blazor Diagram Port in Left Top Offset Values](../images/blazor-diagram-port-in-lefttop-offset-values.png) |
| (0,0.5) | ![Blazor Diagram Port in Left Center Offset Values](../images/blazor-diagram-port-in-leftcenter-offset-values.png) |
| (0,1) | ![Blazor Diagram Port in Left Bottom Offset Values](../images/blazor-diagram-port-in-leftbottom-offset-values.png) |
| (0.5,0) | ![Blazor Diagram Port in Center Top Offset Values](../images/blazor-diagram-port-in-centertop-offset-values.png) |
| (0.5,0.5) | ![Blazor Diagram Port in Center Offset Values](../images/blazor-diagram-port-in-center-offset-values.png) |
| (0.5,1) | ![Blazor Diagram Port in Center Bottom Offset Values](../images/blazor-diagram-port-in-centerbottom-offset-values.png) |
| (1,0) | ![Blazor Diagram Port in Right Top Offset Values](../images/blazor-diagram-port-in-righttop-offset-values.png) |
| (1,0.5) | ![Blazor Diagram Port in Right Center Offset Values](../images/blazor-diagram-port-in-rightcenter-offset-values.png) |
| (1,1) | ![Blazor Diagram Port in Right Bottom Offset Values](../images/blazor-diagram-port-in-rightbottom-offset-values.png) |

## How to Set Path Position for Connector Port

Use the `PathPosition` property to place a connector port along the connector path. It accepts values between 0 to 1, where:

* **0** represents the start point of the connector
* **1** represents the end point of the connector

>**Note:** The default value is **0.5**, which places the port at the midpoint of the connector.

| PathPosition value | Output |
|---|---|
| 0 | ![Connector port at start position](../images/ConnectorPort/ConnectorPortPathPosition0.png) |
| 0.5 | ![Connector port at midpoint](../images/ConnectorPort/ConnectorPortDefault.png) |
| 1 | ![Connector port at end position](../images/ConnectorPort/ConnectorPortPathPosition1.png) |

The following code example demonstrates how to set path position for a connector port.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px" Connectors="@_connectors">
</SfDiagramComponent>

@code
{
    //Define diagram's connector collection
    private DiagramObjectCollection<Connector> _connectors;

    protected override void OnInitialized()
    {
        // A connector is created and stored in connectors collection.
        _connectors = new DiagramObjectCollection<Connector>();

        // Create connector
        Connector connector = new Connector()
        {
            ID = "connector",
            SourcePoint = new DiagramPoint() { X = 400, Y = 200 },
            TargetPoint = new DiagramPoint() { X = 550, Y = 350 },
            Type = ConnectorSegmentType.Orthogonal,
            Ports = new DiagramObjectCollection<ConnectorPort>()
            {
                new ConnectorPort()
                {
                    ID = "port",
                    Visibility = PortVisibility.Visible,
                    Shape = PortShapes.Square,
                    PathPosition = 0,
                }
            }
        };
        _connectors.Add(connector);
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/rDBeCjtGVyLtTfkm?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

A complete working sample can be downloaded from [GitHub](https://github.com/SyncfusionExamples/Blazor-UG-Examples/blob/master/Diagram/Server/Pages/Ports/ConnectorPort/ConnectorPortPathPosition.razor)

## How to Change Horizontal and Vertical Alignment

[HorizontalAlignment](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.Port.html#Syncfusion_Blazor_Diagram_Port_HorizontalAlignment) property of the port is used to set how the port is horizontally aligned at the port position determined from the fraction values, and [VerticalAlignment](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.Port.html#Syncfusion_Blazor_Diagram_Port_VerticalAlignment) property is used to set how the port is vertically aligned at the port position.

The following table shows all the possible alignments visually with `offset (0, 0)`.

| Horizontal Alignment | Vertical Alignment | Output with Offset(0,0) |
| -------- | -------- | -------- |
| Left | Top | ![Blazor Diagram Port in Left Top Position](../images/blazor-diagram-port-in-lefttop-position.png) |
| Center | Top | ![Blazor Diagram Port in Center Top Position](../images/blazor-diagram-port-in-centertop-position.png) |
| Right | Top |  ![Blazor Diagram Port in Right Top Position](../images/blazor-diagram-port-in-righttop-position.png) |
| Left | Center | ![Blazor Diagram Port in Left Center Position](../images/blazor-diagram-port-in-leftcenter-position.png) |
| Center | Center| ![Blazor Diagram Port in Center Center Position](../images/blazor-diagram-port-in-centercenter-position.png) |
| Right | Center | ![Blazor Diagram Port in Right Center Position](../images/blazor-diagram-port-in-rightcenter-position.png) |
| Left | Bottom | ![Blazor Diagram Port in Left Bottom Position](../images/blazor-diagram-port-in-leftbottom-position.png) |
| Center | Bottom | ![Blazor Diagram Port in Center Bottom Position](../images/blazor-diagram-port-in-centerbottom-position.png) |
| Right |Bottom |![Blazor Diagram Port in Right Bottom Position](../images/blazor-diagram-port-in-rightbottom-position.png) |

The following code shows how to align ports.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px" Nodes="@_nodes"/>

@code
{
    private DiagramObjectCollection<Node> _nodes;
    protected override void OnInitialized()
    {
        _nodes = new DiagramObjectCollection<Node>();
        // A node is created and stored in _nodes array.
        Node node = new Node()
        {
            // Position of the node.
            OffsetX = 250,
            OffsetY = 250,
            // Size of the node.
            Width = 100,
            Height = 100,
            Style = new ShapeStyle() { Fill = "#6495ED", StrokeColor = "white" },
            // Initialize port collection.
            Ports = new DiagramObjectCollection<PointPort>() 
            {
                new PointPort() 
                {
                    ID = "port1",
                    Offset = new DiagramPoint() { X = 0, Y = 0 },
                    Visibility = PortVisibility.Visible,
                    //Set the style for the port.
                    Style = new ShapeStyle(){ Fill="gray", StrokeColor="black"},
                    Width = 12, 
                    Height = 12, 
                    // Sets the shape of the port as Square.                    
                    Shape = PortShapes.Square,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                }
            }
        };
        _nodes.Add(node);
    }
}
```
A complete working sample can be downloaded from [GitHub](https://github.com/SyncfusionExamples/Blazor-UG-Examples/blob/master/Diagram/Server/Pages/Ports/Positioning/PortHorizontalVerticalAlignment.razor)

{% previewsample "https://blazorplayground.syncfusion.com/embed/hXryMDDQBerYgNVs?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Changing port alignment relative to offset in Blazor Diagram](../images/blazor-diagram-port-position.png)" %}


N> The default values for `HorizontalAlignment` and `VerticalAlignment` are `Center`. Alignment is positioned based on the offset value.

## How to Update Margin for Port

[Margin](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.Port.html#Syncfusion_Blazor_Diagram_Port_Margin) is an absolute value that adds some blank space to any one of its four sides. The ports can be displaced with the `Margin` property. The following code example explains how to align a port based on its `Offset`, `HorizontalAlignment`, `VerticalAlignment`, and `Margin` values.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px" Nodes="@_nodes"/>

@code
{
    private DiagramObjectCollection<Node> _nodes;
    protected override void OnInitialized()
    {
        _nodes = new DiagramObjectCollection<Node>();
        // A node is created and stored in _nodes array.
        Node node = new Node()
        {
            // Position of the node.
            OffsetX = 250,
            OffsetY = 250,
            // Size of the node.
            Width = 100,
            Height = 100,
            Style = new ShapeStyle() { Fill = "#6495ED", StrokeColor = "white" },
            // Initialize port collection.
            Ports = new DiagramObjectCollection<PointPort>() 
            {
                new PointPort() 
                {
                    ID = "port1",
                    Offset = new DiagramPoint() { X = 0.5, Y = 1 },
                    Visibility = PortVisibility.Visible,
                    //Set the style for the port.
                    Style= new ShapeStyle() { Fill = "gray", StrokeColor = "black" },
                    Width = 12,
                    Height = 12, 
                    // Sets the shape of the port as Square.
                    Shape = PortShapes.Square,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Margin = new DiagramThickness() { Top = 20 }
                }
            }
        };
        _nodes.Add(node);
    }
}
```
A complete working sample can be downloaded from [GitHub](https://github.com/SyncfusionExamples/Blazor-UG-Examples/blob/master/Diagram/Server/Pages/Ports/Positioning/PortMargin.razor)

{% previewsample "https://blazorplayground.syncfusion.com/embed/LDhIWtXQhIAzipUo?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor Diagram Port with Margin](../images/blazor-diagram-port-margin.png)" %}

## See also

* [How to create a node](../nodes/nodes)

* [How to customize the ports](./appearance)

* [How to interact with the ports](./interaction)
