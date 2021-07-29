---
layout: post
title: Port interaction in Blazor Diagram Component | Syncfusion
description: Learn here all about port interaction in Syncfusion Blazor Diagram component and more.
platform: Blazor
control: Diagram Component
documentation: ug
---

# Interaction

The port can be dragged in the diagram area and create the connector over the port by using the `port constraints`.

## Draw

Diagram provides the support to draw the connector in the port.

The following code explains how to draw the connector by using the port constraints.

```csharp
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px" Nodes="@nodes">
</SfDiagramComponent>
@code{

   DiagramObjectCollection<Node> nodes = new DiagramObjectCollection<Node>();
    protected override void OnInitialized()
    {
        // A node is created and stored in nodes array.
        Node node = new Node()
        {
            // Position of the node
            OffsetX = 250, OffsetY = 250,
            // Size of the node
            Width = 100, Height = 100,
            Style = new ShapeStyle() { Fill = "#6495ED", StrokeColor = "white" },
            // Initialize port collection
            Ports = new DiagramObjectCollection<PointPort>() {
            new PointPort() {
                ID = "port1",
                Offset = new Point() { X = 0.5, Y = 0.5 },
                Visibility = PortVisibility.Visible,
                //Set the style for the port
                Style= new ShapeStyle(){ Fill = "gray", StrokeColor = "black"},
                // Sets the shape of the port as Circle
                Width = 12, Height = 12, Shape = PortShapes.X,
                // Enable drag operation for Port
                Constraints = PortConstraints.Default|PortConstraints.Draw
            }},
        };
        nodes.Add(node);
    }
}
```

![Port Draw](../images/port_draw.gif)

## See also

* [`How to create a node`](../nodes/nodes)

* [`How to customize the ports`](./appearance)

* [`How to set the position of the port`](./positioning)