---
layout: post
title: Positioning in Blazor Diagram Component | Syncfusion
description: Checkout and learn here all about Positioning in Syncfusion Blazor Diagram component and much more details.
platform: Blazor
control: Diagram Component
documentation: ug
---

# ZIndex property of a node in Blazor Diagram Component

## ZIndex

* The nodes z-order property specifies the stack order of the node. A node with greater stack order is always in front of a node with a lower stack order. By default value is -1.


The following code illustrates how to render node based on the stack order.

```cshtml
@using Syncfusion.Blazor.Diagram
@using System.Collections.ObjectModel

<SfDiagramComponent Height="600px" @ref="@diagram" Nodes="@nodes" />

@code
{
    SfDiagramComponent diagram;
    DiagramObjectCollection<Node> nodes;

    protected override void OnInitialized()
    {
        nodes = new DiagramObjectCollection<Node>();
        // A node is created and stored in nodes array.
        Node node = new Node()
        {
            ID = "node",
            // Position of the node.
            OffsetX = 250,
            OffsetY = 250,
            // Size of the node.
            Width = 100,
            Height = 100,
            ZIndex = 2,
            Style = new ShapeStyle() 
            { 
                Fill = "#6495ED", 
                StrokeColor = "white" 
            },
            // Pivot of the node.
            Pivot = new DiagramPoint() { X = 0, Y = 0 }
        };
        nodes.Add(node);
    }
}
```

