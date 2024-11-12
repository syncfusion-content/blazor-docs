---
layout: post
title: BPMN Connectors in Blazor Diagram Component | Syncfusion
description: Learn here all about BPMN Connectors such as association, sequence, message in Syncfusion Blazor Diagram component and more.
platform: Blazor
control: Diagram Component
documentation: ug
---

# BPMN Connectors in Blazor Diagram Component

The `BPMN Connectors` are lines that connect BPMN flow objects.

They are classified as follows.
* Association
* Sequence
* Message

## Association

The `BPMN Association` flow is used to link flow objects with its corresponding text or artifact. An association is represented as a dotted graphical line with an opened arrow. 
To create an Association, the [Flow](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.BpmnFlow.html#Syncfusion_Blazor_Diagram_BpmnFlow_Flow) property of the [BpmnFlowShape](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.BpmnFlow.html) should be set to [AssociationFlow](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.BpmnFlowType.html#Syncfusion_Blazor_Diagram_BpmnFlowType_AssociationFlow). The types of association are as follows:

* DirectionalAssociationFlow: Represented as a dotted graphical line with one side arrow.
* BiDirectionalAssociationFlow: Represented as a dotted graphical line with double side arrow.
* AssociationFlow: An Association is represented as a dotted graphical line with an opened arrow.

The following code example explains how to create an association.

```cshtml
@using Syncfusion.Blazor.Diagram

@* Initialize Diagram *@
<SfDiagramComponent Height="600px" Connectors="@connectors"/>

@code
{
    // Create connector and store it in the connector collection.
    DiagramObjectCollection<Connector> connectors;

    protected override void OnInitialized()
    {
        connectors = new DiagramObjectCollection<Connector>();
        Connector connector = new Connector()
        {
            // Unique Id of the connector.
            ID = "connector1",
            // Start and end point of the connector
            SourcePoint = new DiagramPoint () { X = 100, Y = 200 },
            TargetPoint = new DiagramPoint () { X = 300, Y = 300 },
            // Sets the type to Bpmn, flow to AssociationFlow.
            Shape = new BpmnFlow()
            {
                Flow = BpmnFlowType.AssociationFlow,
            }
        };
        connectors.Add(connector);
    }
}
```
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/BpmnEditor/BpmnConnectors/Association)

![Default BPMN FlowShapes](../images/Bpmn-AssociationFlow.png)

The following table shows the visual representation of association flows.

| Association | Image |
| -------- | -------- |
| AssociationFlow | ![Default BPMN FlowShapes](../images/Bpmn-AssociationFlow.png) |
| DirectionalAssociationFlow | ![Directional BPMN FlowShapes](../images/Bpmn-DirectionalAssociatinFlow.png) |
| BiDirectionalAssociationFlow | ![BiDirectional BPMN FlowShapes](../images/Bpmn-BidirectionalAssociationFlow.png) |

## Sequence

A `Sequence` flow shows the order that the activities are performed in a BPMN process and is represented by a solid graphical line. To create a SequenceFlow, [Flow](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.BpmnFlow.html#Syncfusion_Blazor_Diagram_BpmnFlow_Flow) property of the [BpmnFlowShape](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.BpmnFlow.html) should be set to [SequenceFlow](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.BpmnFlowType.html#Syncfusion_Blazor_Diagram_BpmnFlowType_SequenceFlow). The types of sequence are as follows:

* SequenceFlow: Sequence flows represent the typical path between the two flow objects.
* ConditionalSequenceFlow: Conditional sequence flows are used to control the flow of a process based on the certain conditions.
* DefaultSequenceFlow: Default sequence flows are represented by an arrow with a tic mark on one end.

The following code example explains how to create a sequence flow.

```cshtml
@using Syncfusion.Blazor.Diagram

@* Initialize Diagram *@
<SfDiagramComponent Height="600px" Connectors="@connectors"/>

@code
{
    // Create connector and store it in the connector collection.
    DiagramObjectCollection<Connector> connectors;

    protected override void OnInitialized()
    {
        connectors = new DiagramObjectCollection<Connector>();
        Connector connector = new Connector()
        {
            // Unique Id of the connector.
            ID = "connector1",
            // Start and end point of the connector.
            SourcePoint = new DiagramPoint() { X = 100, Y = 200 },
            TargetPoint = new DiagramPoint() { X = 300, Y = 300 },
            // Sets the flow to SequenceFlow.
            Shape = new BpmnFlow()
            {
                Flow = BpmnFlowType.SequenceFlow,
            }
        };
        connectors.Add(connector);
    }
}
```
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/BpmnEditor/BpmnConnectors/Sequence)

![Normal Sequence BPMN Shape](../images/Bpmn-SequenceFlow.png) 

The following table contains various representation of sequence flows.

| Sequence | Image |
| -------- | -------- |
| DefaultSequenceFlow | ![Default Sequence BPMN Shape](../images/Bpmn-DefaultSequentialFlow.png) |
| ConditionalSequenceFlow | ![Conditional Sequence BPMN Shape](../images/Bpmn-ConditionalSequenceFlow.png) |
| SequenceFlow | ![Normal Sequence BPMN Shape](../images/Bpmn-SequenceFlow.png) |

N> The default value for the property `Sequence` is **Normal.**

## Message

`Message` flows are the two separately controlled processes communicate and collaborate with one another. An activity or event in one pool can initiate a message to the another pool. Message Flows are depicted as lines with an empty circle indicating where the message originates and an empty arrowhead where the message terminates. To create a MessageFlow, the [Flow](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.BpmnFlow.html#Syncfusion_Blazor_Diagram_BpmnFlow_Flow) property of the [BpmnFlowShape](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.BpmnFlow.html) should be set to [MessageFlow](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.BpmnFlowType.html#Syncfusion_Blazor_Diagram_BpmnFlowType_MessageFlow). The types of message are as follows:

* InitiatingMessageFlow: An activity or event in one pool can initiate a message to another pool.
* NonInitiatingMessageFlow: An activity or event in one pool cannot initiate a message to another pool.
* MessageFlow: A MessageFlow flow shows the flow of messages between two participants and is represented by line.

The following code example explains how to define a message flow.

```cshtml
@using Syncfusion.Blazor.Diagram

@* Initialize Diagram *@
<SfDiagramComponent Height="600px" Connectors="@connectors"/>

@code
{
    // Create connector and store it in the connector collection.
    DiagramObjectCollection<Connector> connectors;

    protected override void OnInitialized()
    {
        connectors = new DiagramObjectCollection<Connector>();
        Connector connector = new Connector()
        {
            // Unique Id of the connector.
            ID = "connector1",
            // Start and end point of the connector.
            SourcePoint = new DiagramPoint() { X = 100, Y = 200 },
            TargetPoint = new DiagramPoint() { X = 300, Y = 300 },
            // Sets the flow to MessageFlow.
            Shape = new BpmnFlow()
            {
                Flow = BpmnFlowType.MessageFlow,
            }
        };
        connectors.Add(connector);
    }
}
```
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/BpmnEditor/BpmnConnectors/Message)

 ![Default Message BPMN Shape](../images/Bpmn-MessageFlow.png)

The following table contains various representation of message flows.

| Message | Image |
| -------- | -------- |
| MessageFlow | ![Default Message BPMN Shape](../images/Bpmn-MessageFlow.png) |
| InitiatingMessageFlow | ![InitiatingMessage Message BPMN Shape](../images/Bpmn-NonInitiatingMessageFlow.png) |
| NonInitiatingMessageFlow | ![NonInitiatingMessage Message BPMN Shape](../images/Bpmn-InitiatingMessageFlow.png) |

N> The default value for the property `Flow` is **SequenceFlow.**
