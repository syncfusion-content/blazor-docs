---
layout: post
title: BPMN Group in Blazor Diagram Component | Syncfusion
description: Checkout and learn here all about BPMN Group in Syncfusion Blazor Diagram component and much more details.
platform: Blazor
control: Diagram
documentation: ug
---

# BPMN Group in Blazor Diagram Component

A group is used to frame a part of the diagram, shows that elements included in it are logically belong together and does not have any other semantics other than organizing elements. To create a group, the shape property of the node should be set to **group**. The following code example explains how to create a BPMN group.

```cshtml
@using Syncfusion.Blazor.Diagrams
@using System.Collections.ObjectModel

@* Initialize Diagram *@
<SfDiagram Height="600px" Nodes="@NodeCollection">
</SfDiagram>

@code{
    //Initialize the node collection with node
    ObservableCollection<DiagramNode> NodeCollection = new ObservableCollection<DiagramNode>()
    {
        new DiagramNode()
        {
            //Position of the node
            OffsetX = 100,
            OffsetY = 100,
            //Size of the node
            Width = 100,
            Height = 100,
            //Unique Id of the node
            Id = "node1",
            //Sets type to Bpmn and shape to Group
            Shape = new DiagramShape()
            {
                Type = Shapes.Bpmn,
                BpmnShape=BpmnShapes.Group,
            }
        }
    };
}
```

![BPMN Group](../images/bpmn-group.png)