---
layout: post
title: Bpmn Data Object in Blazor Diagram Component | Syncfusion 
description: Learn about Bpmn Data Object in Blazor Diagram component of Syncfusion, and more details.
platform: Blazor
control: Diagram
documentation: ug
---

# BPMN data object

A data object represents information flowing through the process, such as data placed into the process, data resulting from the process, data that needs to be collected, or data that must be stored. To define a [`DataObject`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.DiagramShape.html#Syncfusion_Blazor_Diagrams_DiagramShape_DataObject), set the shape to **DataObject** and the type property defines whether data is an input or output. You can create multiple instances of data object with the collection property of data.

```csharp
@using Syncfusion.Blazor.Diagrams
@using System.Collections.ObjectModel

@* Initialize the Diagram*@
<SfDiagram ID="Diagram" Height="600px" Nodes="@NodeCollection">
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
            //Sets type to Bpmn and shape to DataObject
            Shape = new DiagramShape()
            {
                Type = Shapes.Bpmn,
                BpmnShape=BpmnShapes.DataObject,
                //Sets collection to true when Dataobject is not a Single instance
                DataObject=new DiagramBpmnDataObject()
                {
                    Collection=true,
                    Type=BpmnDataObjects.Input
                }
            }
        },
    };
}
```

The following table contains various representation of the BPMN data object.

| Boundary | Image |
| -------- | -------- |
| Collection Data Object | ![Collection Data BPMN Shape](../images/Dataobject.png) |
| Data Input | ![Data Input BPMN Shape](../images/DataInput.png) |
| Data Output | ![Data Output BPMN Shape](../images/DataOutput.png) |
