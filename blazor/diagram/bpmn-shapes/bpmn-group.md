---
layout: post
title: BPMN group in Blazor Diagram Component | Syncfusion
description: Learn here all about how to create and update the BPMN group in Syncfusion Blazor Diagram component and more.
platform: Blazor
control: Diagram Component
documentation: ug
---

# BPMN Group in Blazor Diagram Component

A group is used to frame a part of the diagram, shows that elements included in it logically belong together and do not have any other semantics other than organizing elements. To create a group, the shape property of the node should be set to **Group**. The following code example explains how to create a BPMN group.

```cshtml
@using Syncfusion.Blazor.Diagram

@* Initialize Diagram *@
<SfDiagramComponent Height="600px" Nodes="@nodes" />

@code
{
    // Initialize node collection with Node.
    DiagramObjectCollection<Node> nodes;

    protected override void OnInitialized()
    {
        nodes = new DiagramObjectCollection<Node>();
        Node node = new Node()
        {
            // Position of the node.
            OffsetX = 100,
            OffsetY = 100,
            // Size of the node.
            Width = 100,
            Height = 100,
            // Unique Id of the node.
            ID = "node1",
            // Sets type to Bpmn and shape to Group.
            Shape = new BpmnShape()
            {
                Type = Shapes.Bpmn,
                Shape = BpmnShapes.Group,
            }
        };
        nodes.Add(node);
    }
}
```

![BPMN Group](../images/bpmn-group.png)
