---
layout: post
title: BPMN Event in Blazor Diagram Component | Syncfusion
description: Learn here all about how to create the BPMN event and event trigger in Syncfusion Blazor Diagram component and more.
platform: Blazor
control: Diagram Component
documentation: ug
---

# BPMN Event in Blazor Diagram Component

An [Event](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.BpmnEvent.html) is a common BPMN process model element that represents something that happens during a business process and is notated with a circle. The type of events are as follows:

* Start - Indicates the beginning of the process and every business process start with an event.
* Intermediate - Indicates the middle of the process.
* End - Indicates the end of the process, and every business process ends with an event.

The [EventType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.BpmnEvent.html#Syncfusion_Blazor_Diagram_BpmnEvent_EventType) property of the node allows you to define the type of the event. The default value of the event is [Start](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.BpmnEventType.html#Syncfusion_Blazor_Diagram_BpmnEventType_Start). The following code example explains how to create a BPMN event.

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
            //Sets shape as BpmnEvent.
            Shape = new BpmnEvent()
            {
                // Set the event type as End.
                EventType = BpmnEventType.End,
            }
        };
        nodes.Add(node);
    }
}
```
A complete working sample can be downloaded from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/BpmnEditor/BpmnEvent/BpmnEventType)

![None Trigger End event event BPMNShape](../images/Bpmn-Event-End.png)

## How to Create a BPMN Event Trigger

Event triggers are notated as icons inside the circle and they represent the specific details of the process. The [Trigger](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.BpmnEvent.html#Syncfusion_Blazor_Diagram_BpmnEvent_Trigger) property of the node allows you to set the type of trigger and by default, it is set to [None](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.BpmnEventTrigger.html#Syncfusion_Blazor_Diagram_BpmnEventTrigger_None). The following code example explains how to create a BPMN trigger.

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
            //Sets type as Bpmn and shape as Event
            Shape = new BpmnEvent()
            {
                // Set the event type to NonInterruptingIntermediate and set the trigger as message.
                EventType = BpmnEventType.Start,
                Trigger = BpmnEventTrigger.Message
            }
        };
        nodes.Add(node);
    }
}
```
A complete working sample can be downloaded from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/BpmnEditor/BpmnEvent/BpmnEventType)

![Message Trigger Start Event BPMN Shape](../images/Bpmn-Event-Message-Start.png)

The following table illustrates the type of event triggers.

| Triggers | Start | Non-Interrupting Start | Intermediate | Non-Interrupting Intermediate | Throwing Intermediate | End |
| -------- | -------- | -------- | -------- | -------- | -------- | -------- |
| None | ![None Trigger Start event BPMN Shape](../images/Bpmn-Event-Start.png)  | ![None Trigger Interupting event BPMN Shape](../images/Bpmn-Event-NonInteruptingStart.png) | ![None Trigger Intermediate event BPMN Shape](../images/Bpmn-Event-Intermidiate.png) | ![None Trigger NonInteruptingIntermediate BPMNShape](../images/Bpmn-Event-NoninteruptingIntermidiate.png) | ![Message Trigger ThrowingIntermediate Event BPMNShape](../images/Bpmn-Event-ThrowingIntermidiate.png) | ![None Trigger End event event BPMNShape](../images/Bpmn-Event-End.png) |

| Message | ![Message Trigger Start Event BPMN Shape](../images/Bpmn-Event-Message-Start.png) | ![Message Trigger NonInterupting Event BPMN Shape](../images/Bpmn-Event-Message-NonInterruptingStart.png) | ![Message Trigger Intermediate Event BPMN Shape](../images/Bpmn-Event-Message-Intermediate.png) | ![Message Trigger NonInteruptingIntermediate Event BPMN Shape](../images/Bpmn-Event-Message-NonInterruptingIntermediate.png) |![Message Trigger ThrowingIntermediate Event BPMNShape](../images/Bpmn-Event-Message-ThrowingIntermediate.png) | ![Message Trigger End Event BPMN EndShape](../images/Bpmn-Event-Message-End.png) |

| Timer | ![Timer Trigger Start Event BPMNShape](../images/Bpmn-Event-Timer-Start.png) | ![Timer Trigger NonInterupting Event BPMN Shape](../images/Bpmn-Event-Timer-NonInterruptingStart.png) | ![Timer Trigger Intermediate Event BPMN Shape](../images/Bpmn-Event-Timer-Intermediate.png)|![Timer Trigger NonInteruptingIntermediate  Event BPMN Shape](../images/Bpmn-Event-Timer-NonInterruptingIntermediate.png) |![Timer Trigger ThrowingIntermidiate Event BpmnShape](../images/Bpmn-Event-Timer-ThrowingIntermediate.png)|![Timer Trigger End Event BpmnShape](../images/Bpmn-Event-Timer-End.png)

| Conditional | ![Conditional Trigger Start BPMN Shape](../images/Bpmn-Event-Conditional-Start.png) | ![Conditional Trigger NonInterupting BPMN Shape](../images/Bpmn-Event-Conditional-NonInterruptingStart.png) | ![Conditional Trigger Intermediate BPMN Shape](../images/Bpmn-Event-Conditional-Intermediate.png) |![Conditional Trigger NonInteruptingIntermediateBPMNShape](../images/Bpmn-Event-Conditional-NonInterruptingIntermediate.png) |![Conditional Trigger ThrowingIntermidiate Event BpmnShape](../images/Bpmn-Event-Conditional-ThrowingIntermediate.png)|![Conditional Trigger End Event BpmnShape](../images/Bpmn-Event-Conditional-End.png)|

| Link |![Link Trigger Start BPMN Shape](../images/Bpmn-Event-Link-Start.png)  |![Link Trigger NonInterupting BPMN Shape](../images/Bpmn-Event-Link-NonInterruptingStart.png)  |![Link Trigger Intermediate Event BPMNShape](../images/Bpmn-Event-Link-Intermediate.png) | ![Link Trigger NonInteruptingIntermediateBPMNShape](../images/Bpmn-Event-Link-NonInterruptingIntermediate.png)| ![Link Trigger ThrowingIntermediate  Event BPMN Shape](../images/Bpmn-Event-Link-ThrowingIntermediate.png) | ![Link Trigger End Event BpmnShape](../images/Bpmn-Event-Link-End.png)|

| Signal | ![Signal Trigger Start Event BPMN Shape](../images/Bpmn-Event-Signal-Start.png) | ![Signal Trigger NonInterrupting Event BPMN Shape](../images/Bpmn-Event-Signal-NonInterruptingStart.png) | ![Signal Trigger Intermediate Event BPMN Shape](../images/Bpmn-Event-Signal-Intermediate.png) | ![Signal Trigger NonInterrupting Event BPMN Shape](../images/Bpmn-Event-Signal-NonInterruptingIntermediate.png) | ![Signal Throwing Trigger Intermediate  Event BPMN Shape](../images/Bpmn-Event-Signal-ThrowingIntermediate.png) | ![Signal Trigger End Event BPMN Shape](../images/Bpmn-Event-Signal-End.png ) |

| Error | ![Error Trigger Start Event BPMN Shape](../images/Bpmn-Event-Error-Start.png) | ![Error Trigger NonInterrupting Event BPMN Shape](../images/Bpmn-Event-Error-NonInterruptingStart.png)  | ![Error Trigger Intermediate Event BPMN Shape](../images/Bpmn-Event-Error-Intermediate.png) | ![Error Trigger NonInterrupting Event BPMN Shape](../images/Bpmn-Event-Error-NonInterruptingIntermediate.png)| ![Error Throwing Trigger Intermediate  Event BPMN Shape](../images/Bpmn-Event-Error-ThrowingIntermediate.png) | ![Error Trigger End Event BPMN Shape](../images/Bpmn-Event-Error-End.png)|

| Escalation | ![Escalation Trigger Start Event BPMN Shape](../images/Bpmn-Event-Escalation-Start.png) | ![Escalation Trigger  Non-Interrupting Event BPMN Shape](../images//Bpmn-Event-Escalation-NonInterruptingStart.png) | ![Escalation Trigger Intermediate Event BPMN Shape](../images/Bpmn-Event-Escalation-Intermediate.png) | ![Escalation Trigger Non-Interrupting Event BPMN Shape](../images/Bpmn-Event-Escalation-NonInterruptingIntermediate.png)| ![Escalation Trigger Throwing Intermediate Event BPMN Shape](../images/Bpmn-Event-Escalation-ThrowingIntermediate.png) | ![Escalation Trigger End Event BPMN Shape](../images/Bpmn-Event-Escalation-End.png)|

| Terminate  |![Termination Trigger Start Event BPMN Shape](../images/Bpmn-Event-Terminate-Start.png) | ![Termination Trigger  Non-Interrupting  Event BPMN Shape](../images//Bpmn-Event-Terminate-NonInterruptingStart.png)|![Termination Trigger Intermediate Event BPMN Shape](../images/Bpmn-Event-Terminate-Intermediate.png) | ![Termination Trigger Non-Interrupting Event BPMN Shape](../images/Bpmn-Event-Terminate-NonInterruptingIntermediate.png) |![Termination Trigger Throwing Intermediate Event BPMN Shape](../images/Bpmn-Event-Terminate-ThrowingIntermediate.png) | ![Termination Trigger End Event BPMN Shape](../images/Bpmn-Event-Terminate-End.png)|

| Compensation |![Compensation Trigger Start Event BPMN Shape](../images/Bpmn-Event-Compensation-Start.png)|![Compensation Trigger  Non-Interrupting Event BPMN Shape](../images//Bpmn-Event-Compensation-NonInterruptingStart.png) | ![Compensation Trigger Intermediate  Event BPMN Shape](../images/Bpmn-Event-Compensation-Intermediate.png) |![Compensation Trigger Non-Interrupting Event BPMN Shape](../images/Bpmn-Event-Compensation-NonInterruptingIntermediate.png) | ![Compensation Trigger Throwing Intermediate Event BPMN Shape](../images/Bpmn-Event-Compensation-ThrowingIntermediate.png) |![Compensation Trigger End BPMN Event Shape](../images/Bpmn-Event-Compensation-End.png) |

| Cancel |![Cancel Trigger Start Event  BPMN Shape](../images/Bpmn-Event-Cancel-Start.png) |![Cancel Trigger Non-Interrupting Event BPMN Shape](../images//Bpmn-Event-Cancel-NonInterruptingStart.png) | ![Cancel Trigger Intermediate Event BPMN Shape](../images/Bpmn-Event-Cancel-Intermediate.png) | ![Cancel Trigger Non-Interrupting Event BPMN Shape](../images/Bpmn-Event-Cancel-NonInterruptingIntermediate.png)| ![Cancel Trigger Throwing Intermediate Event BPMN Shape](../images/Bpmn-Event-Cancel-ThrowingIntermediate.png)| ![Cancel Trigger End Event BPMN Shape](../images/Bpmn-Error-Cancel-End.png) |

| Multiple | ![Multiple Trigger Start Event BPMN Shape](../images/Bpmn-Event-Multiple-Start.png) | ![Multiple Trigger Non-Interrupting  Event BPMN Shape](../images/Bpmn-Event-Multiple-NonInterruptingStart.png)  | ![Multiple Trigger Intermediate BPMN Shape](../images/Bpmn-Event-Multiple-Intermediate.png) | ![Multiple Trigger Non-Interrupting Event BPMN Shape](../images/Bpmn-Event-Multiple-NonInterruptingIntermediate.png) | ![Multiple Trigger Throwing Intermediate Event BPMN Shape](../images/Bpmn-Event-Multiple-ThrowingIntermediate.png)  | ![Multiple Trigger End Event BPMN Shape](../images/Bpmn-Event-Multiple-End.png) |

| Parallel | ![Parallel Trigger Start Event BPMN Shape](../images/Bpmn-Event-Parallel-Start.png) | ![Parallel Trigger Non-Interrupting Event BPMN Shape](../images/Bpmn-Event-Parallel-NonInterruptingStart.png) | ![Parallel Trigger Intermediate Event BPMN Shape](../images/Bpmn-Event-Parallel-Intermediate.png) | ![Parallel Trigger Non-Interrupting Event BPMN Shape](../images/Bpmn-Event-Parallel-NonInterruptingIntermediate.png) |  ![Parallel Trigger Throwing Intermediate Event BPMN Shape](../images/Bpmn-Event-Parallel-ThrowingIntermediate.png)  | ![Parallel Trigger End Event BPMN Shape](../images/Bpmn-Event-Parallel-End.png) |
                   