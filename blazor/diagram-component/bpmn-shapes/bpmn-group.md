---
layout: post
title: BPMN group in Blazor Diagram Component | Syncfusion
description: Learn here all about how to create and update the BPMN group in Syncfusion Blazor Diagram component and more.
platform: Blazor
control: Diagram Component
documentation: ug
---

# BPMN group in Blazor Diagram Component

A group is used to frame a part of the diagram, shows that elements included in it are logically belong together and does not have any other semantics other than organizing elements. To create a group, the shape property of the node should be set to **Group**. The following code example explains how to create a BPMN group.

```cshtml
@using Syncfusion.Blazor.Diagram

@* Initialize Diagram *@
<SfDiagramComponent Height="600px" Nodes="@nodes">
</SfDiagramComponent>

@code{
    //Initialize the node collection with node
    DiagramObjectCollection<Node> nodes = new DiagramObjectCollection<Node>()
    {
        new Node()
        {
            //Position of the node
            OffsetX = 100,
            OffsetY = 100,
            //Size of the node
            Width = 100,
            Height = 100,
            //Unique Id of the node
            ID = "node1",
            //Sets type to Bpmn and shape to Group
            Shape = new BpmnShape()
            {
                Type = Shapes.Bpmn,
                Shape=BpmnShapes.Group,
            }
        }
    };
}
```

![BPMN Group](../images/bpmn-group.png)
