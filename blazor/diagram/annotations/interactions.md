---
layout: post
title: Annotation Interaction in Blazor Diagram Component | Syncfusion
description: Checkout and learn here all about Interaction in Syncfusion Blazor Diagram component and much more details.
platform: Blazor
control: Diagram Component
documentation: ug
---

# Controlling Annotation Interaction in Blazor Diagram Component

Diagram provides the support to the annotations rotation interactively.

## Annotation Rotation
The [RotationReference](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.ShapeAnnotation.html#Syncfusion_Blazor_Diagram_ShapeAnnotation_RotationReference) property of an annotation allows you to control whether the text should rotate relative to its parent node or the Page. The following code examples illustrate how to configure RotationReference for an annotation.


```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px" Nodes="@nodes" />

@code
{
    // Defines diagram's node collection.
    DiagramObjectCollection<Node> nodes;

    protected override void OnInitialized()
    {
        nodes = new DiagramObjectCollection<Node>();
        Node node1 = new Node()
        {
            ID = "node1",
            Width = 100,
            Height = 100,
            OffsetX = 100,
            OffsetY = 100,
            Annotations = new DiagramObjectCollection<ShapeAnnotation>()
            {
                new ShapeAnnotation 
                { 
                    Content = "Node1",
                    RotationReference = AnnotationRotationReference.Parent,
                }
            },
           
        };
         Node node2 = new Node()
        {
            ID = "node2",
            Width = 100,
            Height = 100,
            OffsetX = 100,
            OffsetY = 100,
            Annotations = new DiagramObjectCollection<ShapeAnnotation>()
            {
                new ShapeAnnotation 
                { 
                    Content = "Node2",
                    RotationReference = AnnotationRotationReference.Page,
                }
            },
           
        };
        nodes.Add(node1);
        nodes.Add(node2);
    }
}
```


 Value | Description | Image |
| -------- | -------- | -------- |
| Page | When this option is set, the annotation remains fixed in its original orientation even if its parent node is rotated. | ![Blazor Diagram RotationReference page](../images/rotationReferencePage.gif) |
| Parent | In this case, the annotation rotates along with its parent node. | ![Blazor Diagram RotationReference Parent](../images/rotationReferenceParent.gif) |


You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/Annotations/Interactions/RotationReference)

## See also

* [How to add or remove annotation constraints](../constraints#annotation-constraints)

* [How to add annotation for Node](./node-annotation)

* [How to add annotation for Connector](./connector-annotation)
