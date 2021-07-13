---
layout: post
title: Bpmn Data Source in Blazor Diagram Component | Syncfusion 
description: Learn about Bpmn Data Source in Blazor Diagram component of Syncfusion, and more details.
platform: Blazor
control: Diagram
documentation: ug
---

# BPMN Datasource

Datasource is used to store or access data associated with a business process. To create a datasource, set the shape to **DataSource**. The following code example explains how to create a datasource.

```csharp
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
             //Sets type to Bpmn and shape to DataSource
            Shape = new DiagramShape()
            {
                Type = Shapes.Bpmn,
                BpmnShape=BpmnShapes.DataSource,
            }
        },
    };
}
```

![BPMN Datasource](../images/bpmn-datasource.png)
