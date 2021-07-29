---
layout: post
title: BPMN Text Annotation in Blazor Diagram Component | Syncfusion
description: Checkout and learn here all about BPMN Text Annotation in Syncfusion Blazor Diagram component and more.
platform: Blazor
control: Diagram
documentation: ug
---

# BPMN Text Annotation in Blazor Diagram Component

* A BPMN object can be associated with a text annotation that does not affect the flow but gives details about objects within a flow. The annotation property of the node is used to connect an annotation element to the BPMN node.

* The annotation element can be switched from a BPMN node to another BPMN node simply by dragging the source end of the annotation connector into the other BPMN node.

* The annotation angle property is used to set the angle between the BPMN shape and the annotation.

* The annotation direction property is used to set the direction of the text annotation.

* To set the size for text annotation, use width and height properties.

* The annotation length property is used to set the distance between the BPMN shape and the annotation.

* The annotation text property defines the additional information about the flow object in a BPMN process.

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
            //Sets type as Bpmn and shape as DataObject
            Shape = new DiagramShape()
            {
                Type = Shapes.Bpmn,
                BpmnShape=BpmnShapes.DataObject,
                //Sets collection as true when Dataobject is not a Single instance
                DataObject=new DiagramBpmnDataObject()
                {
                    Collection=true,
                    Type=BpmnDataObjects.Input
                }
            },
            //Sets the id, angle, and text for the annotation
            Annotations=new ObservableCollection<DiagramNodeAnnotation>()
            {
                new DiagramNodeAnnotation()
                {
                    Id="Left",
                    RotateAngle=45,
                    Content="Left"
                }
            }
        },
    };
}
```

![BPMN Text Annotation](../images/bpmn-text-annotation.png)