---
layout: post
title: BPMN Event in Syncfusion Blazor Diagram Component | Syncfusion
description: Learn here all about how to create the BPMN event and event trigger in Syncfusion Blazor Diagram component and more.
platform: Blazor
control: Diagram Component
documentation: ug
---

# BPMN Event in Diagram Component

An [Event](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.BpmnEvent.html) is a common BPMN process model element that represents something that happens during a business process and is notated with a circle. The type of events are as follows:

* **Start** - Indicates the beginning of the process and every business process start with an event.
* **Intermediate** - Indicates the middle of the process.
* **End** - Indicates the end of the process, and every business process ends with an event.

The [EventType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.BpmnEvent.html#Syncfusion_Blazor_Diagram_BpmnEvent_EventType) property of the node allows you to define the type of the event. The default value of the event is [Start](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.BpmnEventType.html#Syncfusion_Blazor_Diagram_BpmnEventType_Start). The following code example explains how to create a BPMN event.

```cshtml
@using Syncfusion.Blazor.Diagram

@* Initialize Diagram *@
<SfDiagramComponent Height="600px" Nodes="@_nodes" />

@code
{
    // Initialize node collection with Node.
    DiagramObjectCollection<Node> _nodes;

    protected override void OnInitialized()
    {
        _nodes = new DiagramObjectCollection<Node>();
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
        _nodes.Add(node);
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LjLoWZZdracaAiTe?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

A complete working sample can be downloaded from [GitHub](https://github.com/SyncfusionExamples/Blazor-UG-Examples/blob/master/Diagram/Server/Pages/BpmnEditor/BpmnEvent/BpmnEventTypeSample.razor)

![None Trigger End event event BPMNShape](../images/Bpmn-Event-End.webp)

## How to Create a BPMN Event Trigger

Event triggers are notated as icons inside the circle and they represent the specific details of the process. The [Trigger](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.BpmnEvent.html#Syncfusion_Blazor_Diagram_BpmnEvent_Trigger) property of the node allows you to set the type of trigger and by default, it is set to [None](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.BpmnEventTrigger.html#Syncfusion_Blazor_Diagram_BpmnEventTrigger_None). The following code example explains how to create a BPMN trigger.

```cshtml

@using Syncfusion.Blazor.Diagram

@* Initialize Diagram *@
<SfDiagramComponent Height="600px" Nodes="@_nodes" />

@code
{
    // Initialize node collection with Node.
    DiagramObjectCollection<Node> _nodes;

    protected override void OnInitialized()
    {
        _nodes = new DiagramObjectCollection<Node>();
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
        _nodes.Add(node);
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VtresttdBOFpnepH?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

A complete working sample can be downloaded from [GitHub](https://github.com/SyncfusionExamples/Blazor-UG-Examples/blob/master/Diagram/Server/Pages/BpmnEditor/BpmnEvent/BpmnEventTriggerSample.razor)

![Message Trigger Start Event BPMN Shape](../images/Bpmn-Event-Message-Start.webp)

The following table illustrates the type of event triggers.

| Triggers | Start | Non-Interrupting Start | Intermediate | Non-Interrupting Intermediate | Throwing Intermediate | End |
| -------- | -------- | -------- | -------- | -------- | -------- | -------- |
| None | ![None Trigger Start event BPMN Shape](../images/Bpmn-Event-Start.webp)  | ![None Trigger Interupting event BPMN Shape](../images/Bpmn-Event-NonInteruptingStart.webp) | ![None Trigger Intermediate event BPMN Shape](../images/Bpmn-Event-Intermidiate.webp) | ![None Trigger NonInteruptingIntermediate BPMNShape](../images/Bpmn-Event-NoninteruptingIntermidiate.webp) | ![Message Trigger ThrowingIntermediate Event BPMNShape](../images/Bpmn-Event-ThrowingIntermidiate.webp) | ![None Trigger End event event BPMNShape](../images/Bpmn-Event-End.webp) |

| Message | ![Message Trigger Start Event BPMN Shape](../images/Bpmn-Event-Message-Start.webp) | ![Message Trigger NonInterupting Event BPMN Shape](../images/Bpmn-Event-Message-NonInterruptingStart.webp) | ![Message Trigger Intermediate Event BPMN Shape](../images/Bpmn-Event-Message-Intermediate.webp) | ![Message Trigger NonInteruptingIntermediate Event BPMN Shape](../images/Bpmn-Event-Message-NonInterruptingIntermediate.webp) |![Message Trigger ThrowingIntermediate Event BPMNShape](../images/Bpmn-Event-Message-ThrowingIntermediate.webp) | ![Message Trigger End Event BPMN EndShape](../images/Bpmn-Event-Message-End.webp) |

| Timer | ![Timer Trigger Start Event BPMNShape](../images/Bpmn-Event-Timer-Start.webp) | ![Timer Trigger NonInterupting Event BPMN Shape](../images/Bpmn-Event-Timer-NonInterruptingStart.webp) | ![Timer Trigger Intermediate Event BPMN Shape](../images/Bpmn-Event-Timer-Intermediate.webp)|![Timer Trigger NonInteruptingIntermediate  Event BPMN Shape](../images/Bpmn-Event-Timer-NonInterruptingIntermediate.webp) |![Timer Trigger ThrowingIntermidiate Event BpmnShape](../images/Bpmn-Event-Timer-ThrowingIntermediate.webp)|![Timer Trigger End Event BpmnShape](../images/Bpmn-Event-Timer-End.webp)

| Conditional | ![Conditional Trigger Start BPMN Shape](../images/Bpmn-Event-Conditional-Start.webp) | ![Conditional Trigger NonInterupting BPMN Shape](../images/Bpmn-Event-Conditional-NonInterruptingStart.webp) | ![Conditional Trigger Intermediate BPMN Shape](../images/Bpmn-Event-Conditional-Intermediate.webp) |![Conditional Trigger NonInteruptingIntermediateBPMNShape](../images/Bpmn-Event-Conditional-NonInterruptingIntermediate.webp) |![Conditional Trigger ThrowingIntermidiate Event BpmnShape](../images/Bpmn-Event-Conditional-ThrowingIntermediate.webp)|![Conditional Trigger End Event BpmnShape](../images/Bpmn-Event-Conditional-End.webp)|

| Link |![Link Trigger Start BPMN Shape](../images/Bpmn-Event-Link-Start.webp)  |![Link Trigger NonInterupting BPMN Shape](../images/Bpmn-Event-Link-NonInterruptingStart.webp)  |![Link Trigger Intermediate Event BPMNShape](../images/Bpmn-Event-Link-Intermediate.webp) | ![Link Trigger NonInteruptingIntermediateBPMNShape](../images/Bpmn-Event-Link-NonInterruptingIntermediate.webp)| ![Link Trigger ThrowingIntermediate  Event BPMN Shape](../images/Bpmn-Event-Link-ThrowingIntermediate.webp) | ![Link Trigger End Event BpmnShape](../images/Bpmn-Event-Link-End.webp)|

| Signal | ![Signal Trigger Start Event BPMN Shape](../images/Bpmn-Event-Signal-Start.webp) | ![Signal Trigger NonInterrupting Event BPMN Shape](../images/Bpmn-Event-Signal-NonInterruptingStart.webp) | ![Signal Trigger Intermediate Event BPMN Shape](../images/Bpmn-Event-Signal-Intermediate.webp) | ![Signal Trigger NonInterrupting Event BPMN Shape](../images/Bpmn-Event-Signal-NonInterruptingIntermediate.webp) | ![Signal Throwing Trigger Intermediate  Event BPMN Shape](../images/Bpmn-Event-Signal-ThrowingIntermediate.webp) | ![Signal Trigger End Event BPMN Shape](../images/Bpmn-Event-Signal-End.webp ) |

| Error | ![Error Trigger Start Event BPMN Shape](../images/Bpmn-Event-Error-Start.webp) | ![Error Trigger NonInterrupting Event BPMN Shape](../images/Bpmn-Event-Error-NonInterruptingStart.webp)  | ![Error Trigger Intermediate Event BPMN Shape](../images/Bpmn-Event-Error-Intermediate.webp) | ![Error Trigger NonInterrupting Event BPMN Shape](../images/Bpmn-Event-Error-NonInterruptingIntermediate.webp)| ![Error Throwing Trigger Intermediate  Event BPMN Shape](../images/Bpmn-Event-Error-ThrowingIntermediate.webp) | ![Error Trigger End Event BPMN Shape](../images/Bpmn-Event-Error-End.webp)|

| Escalation | ![Escalation Trigger Start Event BPMN Shape](../images/Bpmn-Event-Escalation-Start.webp) | ![Escalation Trigger  Non-Interrupting Event BPMN Shape](../images//Bpmn-Event-Escalation-NonInterruptingStart.webp) | ![Escalation Trigger Intermediate Event BPMN Shape](../images/Bpmn-Event-Escalation-Intermediate.webp) | ![Escalation Trigger Non-Interrupting Event BPMN Shape](../images/Bpmn-Event-Escalation-NonInterruptingIntermediate.webp)| ![Escalation Trigger Throwing Intermediate Event BPMN Shape](../images/Bpmn-Event-Escalation-ThrowingIntermediate.webp) | ![Escalation Trigger End Event BPMN Shape](../images/Bpmn-Event-Escalation-End.webp)|

| Terminate  |![Termination Trigger Start Event BPMN Shape](../images/Bpmn-Event-Terminate-Start.webp) | ![Termination Trigger  Non-Interrupting  Event BPMN Shape](../images//Bpmn-Event-Terminate-NonInterruptingStart.webp)|![Termination Trigger Intermediate Event BPMN Shape](../images/Bpmn-Event-Terminate-Intermediate.webp) | ![Termination Trigger Non-Interrupting Event BPMN Shape](../images/Bpmn-Event-Terminate-NonInterruptingIntermediate.webp) |![Termination Trigger Throwing Intermediate Event BPMN Shape](../images/Bpmn-Event-Terminate-ThrowingIntermediate.webp) | ![Termination Trigger End Event BPMN Shape](../images/Bpmn-Event-Terminate-End.webp)|

| Compensation |![Compensation Trigger Start Event BPMN Shape](../images/Bpmn-Event-Compensation-Start.webp)|![Compensation Trigger  Non-Interrupting Event BPMN Shape](../images//Bpmn-Event-Compensation-NonInterruptingStart.webp) | ![Compensation Trigger Intermediate  Event BPMN Shape](../images/Bpmn-Event-Compensation-Intermediate.webp) |![Compensation Trigger Non-Interrupting Event BPMN Shape](../images/Bpmn-Event-Compensation-NonInterruptingIntermediate.webp) | ![Compensation Trigger Throwing Intermediate Event BPMN Shape](../images/Bpmn-Event-Compensation-ThrowingIntermediate.webp) |![Compensation Trigger End BPMN Event Shape](../images/Bpmn-Event-Compensation-End.webp) |

| Cancel |![Cancel Trigger Start Event  BPMN Shape](../images/Bpmn-Event-Cancel-Start.webp) |![Cancel Trigger Non-Interrupting Event BPMN Shape](../images//Bpmn-Event-Cancel-NonInterruptingStart.webp) | ![Cancel Trigger Intermediate Event BPMN Shape](../images/Bpmn-Event-Cancel-Intermediate.webp) | ![Cancel Trigger Non-Interrupting Event BPMN Shape](../images/Bpmn-Event-Cancel-NonInterruptingIntermediate.webp)| ![Cancel Trigger Throwing Intermediate Event BPMN Shape](../images/Bpmn-Event-Cancel-ThrowingIntermediate.webp)| ![Cancel Trigger End Event BPMN Shape](../images/Bpmn-Error-Cancel-End.webp) |

| Multiple | ![Multiple Trigger Start Event BPMN Shape](../images/Bpmn-Event-Multiple-Start.webp) | ![Multiple Trigger Non-Interrupting  Event BPMN Shape](../images/Bpmn-Event-Multiple-NonInterruptingStart.webp)  | ![Multiple Trigger Intermediate BPMN Shape](../images/Bpmn-Event-Multiple-Intermediate.webp) | ![Multiple Trigger Non-Interrupting Event BPMN Shape](../images/Bpmn-Event-Multiple-NonInterruptingIntermediate.webp) | ![Multiple Trigger Throwing Intermediate Event BPMN Shape](../images/Bpmn-Event-Multiple-ThrowingIntermediate.webp)  | ![Multiple Trigger End Event BPMN Shape](../images/Bpmn-Event-Multiple-End.webp) |

| Parallel | ![Parallel Trigger Start Event BPMN Shape](../images/Bpmn-Event-Parallel-Start.webp) | ![Parallel Trigger Non-Interrupting Event BPMN Shape](../images/Bpmn-Event-Parallel-NonInterruptingStart.webp) | ![Parallel Trigger Intermediate Event BPMN Shape](../images/Bpmn-Event-Parallel-Intermediate.webp) | ![Parallel Trigger Non-Interrupting Event BPMN Shape](../images/Bpmn-Event-Parallel-NonInterruptingIntermediate.webp) |  ![Parallel Trigger Throwing Intermediate Event BPMN Shape](../images/Bpmn-Event-Parallel-ThrowingIntermediate.webp)  | ![Parallel Trigger End Event BPMN Shape](../images/Bpmn-Event-Parallel-End.webp) |
                   