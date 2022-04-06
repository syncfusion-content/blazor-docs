---
layout: post
title: Interaction in Blazor Diagram Component | Syncfusion
description: Checkout and learn here all about Interaction in Syncfusion Blazor Diagram component and much more details.
platform: Blazor
control: Diagram Component
documentation: ug
---

# Interaction in Blazor Diagram Component

The port can be used to create connector by enabling the `Draw` in the [PortConstraints](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.PortConstraints.html).

## Draw connector from the port

Diagram provides the support to draw the connector in the port.

The following code explains how to draw the connector by using the port constraints.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px" Nodes="@nodes" />

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
                    Offset = new DiagramPoint() { X = 1, Y = 0.5 },
                    Visibility = PortVisibility.Visible,
                    //Set the style for the port.
                    Style = new ShapeStyle()
                    { 
                        Fill = "gray", 
                        StrokeColor = "black"
                     }, 
                    Width = 12, 
                    Height = 12, 
                    // Sets the shape of the port as Square.
                    Shape = PortShapes.Square,
                    // Enable draw operation for Port
                    Constraints = PortConstraints.Default | PortConstraints.Draw
                }
            },
        };
        nodes.Add(node);
    }
}
```

![Drawing Port Connection in Blazor Diagram](../images/blazor-diagram-draw-port-connection.gif)

## See also

* [How to create a node](../nodes/nodes)

* [How to customize the ports](./appearance)

* [How to set the position of the port](./positioning)
