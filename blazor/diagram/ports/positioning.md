---
layout: post
title: Positioning a Port in Blazor Diagram Component | Syncfusion
description: Checkout and learn here all about positioning in Syncfusion Blazor Diagram component and much more details.
platform: Blazor
control: Diagram Component
documentation: ug
---

# Positioning a Port in Blazor Diagram Component

Diagram allows you to customize the position and appearance of the port efficiently. Ports can be aligned relative to the node boundaries. It has Margin, Offset, Horizontal, and Vertical alignment settings. It is quite tricky when all four alignments are used together but gives more control over alignments properties of the [PointPort](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.PointPort.html) class. Ports of a node can be positioned using the following properties of `PointPort`.

* Offset
* HorizontalAlignment
* VerticalAlignment
* Margin

## How to Change Offset at Runtime

The [Offset](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.PointPort.html#Syncfusion_Blazor_Diagram_PointPort_Offset) property is used to align the ports based on fractions. 0 represents top/left corner, 1 represents bottom/right corner, and 0.5 represents half of width/height.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px" Nodes="@nodes"/>

@code
{
    DiagramObjectCollection<Node> nodes;

    protected override void OnInitialized()
    {
        nodes = new DiagramObjectCollection<Node>();
        // A node is created and stored in nodes collection.
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
        nodes.Add(node);
    }
}
```
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/Ports/Positioning/PortOffset)

![Blazor Diagram with Port based on Offset](../images/blazor-diagram-port-offset.png)

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

The `PathPosition` property allows you to place a connector port along the path of a connector. It accepts a value between 0 to 1, where:

* 0 represents the starting point of the connector.
* 1 represents the endpoint of the connector.

You can set any value between 0 and 1 to position the port at a specific location along the connector's path.

>**Note:** The default value of PathPosition is 0.5, which places the port at the midpoint of the connector.

| PathPosition value | Output |
|---|---|
| 0 | ![Start](../images/ConnectorPort/ConnectorPortPathPosition0.png) |
| 0.5 | ![Center](../images/ConnectorPort/ConnectorPortDefault.png) |
| 1 | ![End](../images/ConnectorPort/ConnectorPortPathPosition1.png) |

The following code example demonstrates how to set the PathPosition for a connector port.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px" Connectors="@connectors">
</SfDiagramComponent>

@code
{
    //Define diagram's connector collection
    DiagramObjectCollection<Connector> connectors;

    protected override void OnInitialized()
    {
        // A connector is created and stored in connectors collection.
        connectors = new DiagramObjectCollection<Connector>();

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
        connectors.Add(connector);
    }
}
```
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/Ports/ConnectorPort/ConnectorPortPathPosition)

## How to Change Horizontal and Vertical Alignment

The [HorizontalAlignment](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.Port.html#Syncfusion_Blazor_Diagram_Port_HorizontalAlignment) property of the port is used to set how the port is horizontally aligned at the port position determined from the fraction values. The [VerticalAlignment](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.Port.html#Syncfusion_Blazor_Diagram_Port_VerticalAlignment) property is used to set how the port is vertically aligned at the port position.

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

The following code explains how to align ports.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px" Nodes="@nodes"/>

@code
{
    DiagramObjectCollection<Node> nodes;

    protected override void OnInitialized()
    {
        nodes = new DiagramObjectCollection<Node>();
        // A node is created and stored in nodes array.
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
        nodes.Add(node);
    }
}
```
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/Ports/Positioning/PortHorizontalVerticalAlignment)

![Changing Port Position in Blazor Diagram](../images/blazor-diagram-port-position.png)


N> By default, the value of the `HorizontalAlignment` and `VerticalAlignment` is `Center`. The alignment is positioned based on the offset value.

## How to Update Margin for Port

[Margin](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.Port.html#Syncfusion_Blazor_Diagram_Port_Margin) is an absolute value used to add some blank space to any one of its four sides. The ports can be displaced with the margin property. The following code example explains how to align a port based on its Offset, HorizontalAlignment, VerticalAlignment, and Margin values.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px" Nodes="@nodes"/>

@code
{
    DiagramObjectCollection<Node> nodes;

    protected override void OnInitialized()
    {
        nodes = new DiagramObjectCollection<Node>();
        // A node is created and stored in nodes array.
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
        nodes.Add(node);
    }
}
```
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/Ports/Positioning/PortMargin)

![Blazor Diagram Port with Margin](../images/blazor-diagram-port-margin.png)

## See also

* [How to create a node](../nodes/nodes)

* [How to customize the ports](./appearance)

* [How to interact with the ports](./interaction)
