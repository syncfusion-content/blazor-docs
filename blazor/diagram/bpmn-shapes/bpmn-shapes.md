---
layout: post
title: BPMN Shapes in Blazor Diagram Component | Syncfusion
description: Learn here all about how to create various BPMN Shapes in Syncfusion Blazor Diagram component and more.
platform: Blazor
control: Diagram Component
documentation: ug
---

# Shapes in Blazor Diagram Component

BPMN(Business Process Model and Notation) shapes are used to represent the internal business procedure in a graphical notation and enable you to communicate the procedures in a standard manner. To create a BPMN shape, the node property shape, should be set as any one of the built-in shapes.

The following code example explains how to create a simple business process.

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
            // Sets shape as BpmnEvent.
            Shape = new BpmnEvent()
            {
                EventType = BpmnEventType.Intermediate,
            }
        };
        nodes.Add(node);
    }
}
```

The list of supported BPMN shapes are as follows:

| Shape | Image |
| -------- | -------- |
| Event | ![Event Shape](../images/Bpmn-Event-Start.png) |
| Gateway | ![Gateway Shape](../images/Gateway.png) |
| Activity | ![Activity Shape](../images/Task.png) |
| Message | ![Message Shape](../images/Message.png) |
| DataStore | ![DataStore Shape](../images/Datasource.png) |
| DataObject | ![DataObject Shape](../images/Dataobject.png) |
| Expanded Sub-Process | ![Expanded Sub-Process Shape](../images/Group.png) |
| TextAnnotation | ![TextAnnotation Shape](../images/Bpmn-TextAnnotation-Auto.png) |
| Sequence Flow | ![TextAnnotation Shape](../images/Bpmn-SequenceFlow.png) |
| Association | ![TextAnnotation Shape](../images/Bpmn-AssociationFlow.png) |
| Message Flow | ![TextAnnotation Shape](../images/Bpmn-MessageFlow.png) |