---
layout: post
title: BPMN Text Annotation in Blazor Diagram Component | Syncfusion
description: Learn here all about how to create BPMN text annotation in Syncfusion Blazor Diagram component and more.
platform: Blazor
control: Diagram Component
documentation: ug
---

# BPMN Text Annotation in Blazor Diagram Component

* A BPMN object can be associated with a text annotation that does not affect the flow but gives details about objects within a flow. 

* The annotation element can be switched from a BPMN node to another BPMN node simply by dragging the source end of the annotation connector into the other BPMN node.

* A TextAnnotation points at or references the another BPMN shape, which we call the `TextAnnotationTarget` of the TextAnnotation. When a target shape is moved, copied, or deleted, any TextAnnotations attached to the shape will be moved, copied, or deleted too. Thus, the TextAnnotations stay with their target shapes though you can reposition the TextAnnotation to any offset from its target. The `TextAnnotationTarget` property of the `BpmnTextAnnotation` is used to connect an annotation element to the Bpmn Node.

* The `TextAnnotationDirection` property is used to set the shape direction of the text annotation.

* By default, the `TextAnnotationDirection` is set to a **Auto**.

* The TextAnnotation element can be moved (if their have connected with any BPMN Node) while dragging the BPMN node.

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
            // Sets type as Bpmn and shape as DataObject
            Shape = new BpmnTextAnnotation() 
            { 
                TextAnnotationTarget = TextAnnotationTarget.Auto,
            }
        };
        nodes.Add(node);
    }
}
```
![Auto BPMN Shape](../images/Bpmn-TextAnnotation-Auto.png)

The following code example represents how to create a TextAnnotation and make a connection between the Activity and TextAnnotation shape.

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
        Node node1 = new Node()
        {
            // Position of the node.
            OffsetX = 500,
            OffsetY = 500,
            // Size of the node.
            Width = 200,
            Height = 200,
            // Unique Id of the node.
            ID = "node1",
            // Sets the type of shape to Bpmn and shape to activity.
            Shape = new BpmnActivity() 
            { 
                ActivityType = BpmnActivityType.Task 
            },
        };
        nodes.Add(node1);
        Node node2 = new Node()
        {
            // Position of the node.
            OffsetX = 600,
            OffsetY = 100,
            // Size of the node.
            Width = 100,
            Height = 100,
            // Unique Id of the node.
            ID = "node2",
            // Sets type as Bpmn and shape as DataObject
            Shape = new BpmnTextAnnotation() 
            { 
                TextAnnotationDirection = TextAnnotationDirection.Auto,
                  TextAnnotationTarget = "node1"
            }
        };
        nodes.Add(node2);
    }
}

```
![Auto BPMN Shape](../images/bpmn-text-annotation_WithTarget.png) 

## How to create a connection between the TextAnnotation to BPMNNode
Drag and drop any bpmn shapes from the palette to diagram and make a connection between the BPMN Node and TextAnnotation.

The following image shows how to drag a symbol from the palette and create a connection between the TextAnnotation to BPMNNode with interaction.

![Auto BPMN Shape](../images/Bpmn-TextAnnotationTarget-Connect.gif)

There are several types of Text annotation Directions as follows:
| Direction | Image |
| -------- | -------- |
| Auto | ![Auto BPMN Shape](../images/Bpmn-TextAnnotation-Auto.png) |
| Left | ![Left TextAnnotation BPMN Shape](../images/Bpmn-TextAnnotation-Auto.png) |
| Right | ![Right TextAnnotation BPMN Shape](../images/Bpmn-TextAnnotation-Right.png) |
| Top | ![Top TextAnnotation BPMN Shape](../images/Bpmn-TextAnnotation-Top.png) |
| Bottom | ![Bottom TextAnnotation BPMN Shape](../images/Bpmn-TextAnnotation-Bottom.png) |
