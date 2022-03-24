---
layout: post
title: BPMN Shapes in Blazor Diagram Component | Syncfusion
description: Learn here all about how to create various BPMN Shapes in Syncfusion Blazor Diagram component and more.
platform: Blazor
control: Diagram Component
documentation: ug
---

# Shapes in Blazor Diagram Component

BPMN(Business Process Model and Notation) shapes are used to represent the internal business procedure in a graphical notation and enable you to communicate the procedures in a standard manner. To create a BPMN shape, in the node property shape, type should be set to “Bpmn” and its shape should be set as any one of the built-in shapes.

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
            // Sets type as Bpmn and shape as Event.
            Shape = new BpmnShape()
            {
                Type = Shapes.Bpmn,
            }
        };
        nodes.Add(node);
    }
}
```

> The default value for the property `Shape` is “Event”.

The list of BPMN shapes are as follows:

| Shape | Image |
| -------- | -------- |
| Event | ![Event Shape](../images/Event.png) |
| Gateway | ![Gateway Shape](../images/Gateway.png) |
| Task | ![Task Shape](../images/Task.png) |
| Message | ![Message Shape](../images/Message.png) |
| DataSource | ![Datasource Shape](../images/Datasource.png) |
| DataObject | ![Dataobject Shape](../images/Dataobject.png) |
| Group | ![Group Shape](../images/Group.png) |