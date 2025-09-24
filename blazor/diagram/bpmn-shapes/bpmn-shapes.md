---
layout: post
title: BPMN Shapes in Syncfusion Blazor Diagram Component | Syncfusion
description: Learn here all about how to create various BPMN Shapes in Syncfusion Blazor Diagram component and more.
platform: Blazor
control: Diagram Component
documentation: ug
---

# BPMN Shapes in Diagram Component

BPMN (Business Process Model and Notation) shapes are used to represent the internal business procedure in a graphical notation and enable you to communicate the procedures in a standard manner. To create a BPMN shape, the node property [Shape](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.Shape.html) should be set as any one of the built-in shapes.

The following code example demonstrates how to create a simple BPMN Task shape.

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
            // Sets the shape to activity.
            Shape = new BpmnActivity() 
            { 
                ActivityType = BpmnActivityType.Task 
            },
        };
        nodes.Add(node);
    }
}
```
A complete working sample can be downloaded from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/BpmnEditor/BpmnShape/BpmnShape)


>**Note:** Node's Id should not start with numbers or special characters and should not contain special characters such as underscore(_) or space.

![Activity Shape](../images/Task.png) 

The following table describes the available BPMN shapes.

| Shape | Image | Description|
| -------- | -------- | -------- |
| [Event](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.BpmnDataObject.html) | ![Event Shape](../images/Bpmn-Event-Start.png) |Event shape represents something happens during a business process.|
| [Gateway](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.BpmnGateway.html) | ![Gateway Shape](../images/Gateway.png) |Gateway is used to control the flow of a process.|
| [Activity](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.BpmnActivity.html) | ![Activity Shape](../images/Task.png) |Activities describe the kind of work being done in a particular process instance.|
| [Message](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.BpmnMessage.html) | ![Message Shape](../images/Message.png) |The message is just the content of the communication.|
| [DataStore](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.BpmnDataObject.html) | ![DataStore Shape](../images/Datasource.png) |DataStore is used to store or access data associated with a business process.|
| [DataObject](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.BpmnDataObject.html) | ![DataObject Shape](../images/Dataobject.png) |A DataObject represents information flowing using the process, such as data placed into the process, data resulting from the process, data that needs to be collected, or data that must be stored.|
| [TextAnnotation](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.BpmnTextAnnotation.html) | ![TextAnnotation Shape](../images/Bpmn-TextAnnotation-Auto.png) |A TextAnnotation points at or references another BPMN shape, which we call as the TextAnnotationTarget of the TextAnnotation.|
| [Expanded Sub-Process](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.BpmnExpandedSubProcess.html) | ![Expanded Sub-Process Shape](../images/Group.png) |Organize tasks or processes that have significance in the overall process.|
| [Sequence Flow](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.BpmnFlowType.html#Syncfusion_Blazor_Diagram_BpmnFlowType_SequenceFlow) | ![Sequence Flow  Shape](../images/Bpmn-SequenceFlow.png) |Sequence flows represent the typical path between two flow objects.|
| [DefaultSequenceFlow](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.BpmnFlowType.html#Syncfusion_Blazor_Diagram_BpmnFlowType_DefaultSequenceFlow) | ![Default Sequence BPMN Shape](../images/Bpmn-DefaultSequentialFlow.png) |Default sequence flows are represented by an arrow with a tic mark on the one end.|
| [ConditionalSequenceFlow](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.BpmnFlowType.html#Syncfusion_Blazor_Diagram_BpmnFlowType_ConditionalSequenceFlow) | ![Conditional Sequence BPMN Shape](../images/Bpmn-ConditionalSequenceFlow.png) |Conditional sequence flows are used to control the flow of a process based on the certain conditions.|
| [Association](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.BpmnFlowType.html#Syncfusion_Blazor_Diagram_BpmnFlowType_AssociationFlow) | ![Association Shape](../images/Bpmn-AssociationFlow.png) |An association is represented as a dotted graphical line with an opened arrow.|
| [DirectionalAssociationFlow](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.BpmnFlowType.html#Syncfusion_Blazor_Diagram_BpmnFlowType_DirectionalAssociationFlow) | ![Directional BPMN FlowShapes](../images/Bpmn-DirectionalAssociatinFlow.png) |DirectionalAssociation is represented as a dotted graphical line with one side arrow.|
| [BiDirectionalAssociationFlow](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.BpmnFlowType.html#Syncfusion_Blazor_Diagram_BpmnFlowType_BiDirectionalAssociationFlow) | ![BiDirectional BPMN FlowShapes](../images/Bpmn-BidirectionalAssociationFlow.png) |BiDirectionalAssociation is represented as a dotted graphical line with the double side arrow.|
| [Message Flow](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.BpmnFlowType.html#Syncfusion_Blazor_Diagram_BpmnFlowType_MessageFlow) | ![Message Flow Shape](../images/Bpmn-MessageFlow.png) |A MessageFlow flow shows the flow of messages between two participants and is represented by line.|
| [InitiatingMessageFlow](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.BpmnFlowType.html#Syncfusion_Blazor_Diagram_BpmnFlowType_InitiatingMessageFlow) | ![InitiatingMessage Message BPMN Shape](../images/Bpmn-NonInitiatingMessageFlow.png) |An activity or event in one pool can initiate a message to another pool.|
| [NonInitiatingMessageFlow](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.BpmnFlowType.html#Syncfusion_Blazor_Diagram_BpmnFlowType_NonInitiatingMessageFlow) | ![NonInitiatingMessage Message BPMN Shape](../images/Bpmn-InitiatingMessageFlow.png) |An activity or event in one pool cannot initiate a message to another pool.|
