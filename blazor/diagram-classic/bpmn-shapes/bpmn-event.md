---
layout: post
title: BPMN Event in Blazor Diagram Component | Syncfusion
description: Checkout and learn here all about BPMN Event in Syncfusion Blazor Diagram component and much more details.
platform: Blazor
control: Diagram
documentation: ug
---

# BPMN Event in Blazor Diagram Component

An [Event](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.DiagramBpmnEvent.html#Syncfusion_Blazor_Diagrams_DiagramBpmnEvent_Event) is a common BPMN process model element that represents something that happens during a business process and is notated with a circle. The type of events are as follows:

* Start - indicates the beginning of the process and every business process start with an event.
* Intermediate - indicates the middle of the process.
* End - indicates the beginning of the process and every business process end with an event.

The event property of the node allows you to define the type of the event. The default value of the event is **start**. The following code example explains how to create a BPMN event.

```cshtml
@using Syncfusion.Blazor.Diagrams
@using System.Collections.ObjectModel

@* Initialize Diagram *@
<SfDiagram Height="600px" Nodes="@NodeCollection">
</SfDiagram>

@code{
    //Defines diagram's node collection
    public ObservableCollection<DiagramNode> NodeCollection { get; set; }

    protected override void OnInitialized()
    {
        NodeCollection = new ObservableCollection<DiagramNode>();
        DiagramNode node = new DiagramNode()
        {
            //Position of the node
            OffsetX = 100,
            OffsetY = 100,
            //Size of the node
            Width = 100,
            Height = 100,
            //Unique Id of the node
            Id = "node1",
            Shape = new DiagramShape()
            {
                //Sets type to Bpmn and shape to Event
                Type = Shapes.Bpmn,
                BpmnShape = BpmnShapes.Event,
                // Set the event type to End
                Event = new DiagramBpmnEvent() { Event = BpmnEvents.End }
            }
        };
        NodeCollection.Add(node);
    }
}
```

## BPMN event trigger

Event triggers are notated as icons inside the circle and they represent the specific details of the process. The Trigger property of the node allows you to set the type of trigger and by default, it is set to None. The following code example explains how to create a BPMN trigger.

```cshtml
@using Syncfusion.Blazor.Diagrams
@using System.Collections.ObjectModel

@* Initialize Diagram *@
<SfDiagram Height="600px" Nodes="@NodeCollection">
</SfDiagram>

@code{
    //Defines diagram's node collection
    public ObservableCollection<DiagramNode> NodeCollection { get; set; }

    protected override void OnInitialized()
    {
        NodeCollection = new ObservableCollection<DiagramNode>();
        DiagramNode node = new DiagramNode()
        {
            //Position of the node
            OffsetX = 100,
            OffsetY = 100,
            //Size of the node
            Width = 100,
            Height = 100,
            //Unique Id of the node
            Id = "node1",
            Shape = new DiagramShape()
            {
                //Sets type to Bpmn and shape to Event
                Type = Shapes.Bpmn,
                BpmnShape = BpmnShapes.Event,
                // Set the event type to NonInterruptingIntermediate and set the trigger as message
                Event = new DiagramBpmnEvent()
                {
                    Event = BpmnEvents.NonInterruptingIntermediate,
                    Trigger = BpmnTriggers.Message
                }
            }
        };
        NodeCollection.Add(node);
    }
}
```

The following table illustrates the type of event triggers.

| Triggers | Start | Non-Interrupting Start | Intermediate | Non-Interrupting Intermediate | Throwing Intermediate | End |
| -------- | -------- | -------- | -------- | -------- | -------- | -------- |
| None | ![None Trigger Start event BPMN Shape](../images/None1.png)  | ![None Trigger Interupting event BPMN Shape](../images/None2.png) | ![None Trigger Intermediate event  BPMN Shape](../images/None3.png) | ![None Trigger NonInteruptingIntermediate BPMNShape](../images/None4.png) | | ![None Trigger End event  event  BPMNShape](../images/None5.png) |
| Message | ![Message Trigger Start Event BPMN Shape](../images/Message1.png) | ![Message Trigger NonInterupting Event BPMN Shape](../images/Message2.png) | ![Message Trigger Intermediate Event BPMN Shape](../images/Message3.png) | ![Message Trigger NonInteruptingIntermediate Event BPMN Shape](../images/Message4.png) |![Message Trigger ThrowingIntermediate Event BPMNShape](../images/Message5.png) | ![Message Trigger End Event BPMN EndShape](../images/Message6.png) |
| Timer | ![Timer Trigger Start Event BPMNShape](../images/Timer1.png) | ![Timer Trigger NonInterupting Event BPMN Shape](../images/Timer2.png) | ![Timer Trigger Intermediate Event BPMN Shape](../images/Timer3.png)|![Timer Trigger NonInteruptingIntermediate  Event BPMN Shape](../images/Timer4.png) | | |
| Conditional | ![Conditional Trigger Start BPMN Shape](../images/Conditional1.png) | ![Conditional Trigger NonInterupting BPMN Shape](../images/Conditional2.png) | ![Conditional Trigger Intermediate BPMN Shape](../images/Conditional3.png) |![Conditional Trigger NonInteruptingIntermediateBPMNShape](../images/Conditional4.png) | | |
| Link | | |![Link Trigger Intermediate Event BPMNShape](../images/Link1.png) | | ![Link Trigger ThrowingIntermediate  Event BPMN Shape](../images/Link2.png) | |
| Signal | ![Signal Trigger Start Event BPMN Shape](../images/Signal1.png) | ![Signal Trigger NonInterrupting Event BPMN Shape](../images/Signal2.png) | ![Signal Trigger Intermediate Event BPMN Shape](../images/Signal3.png) | ![Signal Trigger NonInterrupting Event BPMN Shape](../images/Signal4.png) | ![SignalThrowing Trigger Intermediate  Event BPMN Shape](../images/Signal5.png) | ![Signal Trigger End Event BPMN Shape](../images/Signal6.png) |
| Error | ![Error Trigger Start Event BPMN Shape](../images/Error1.png) | | ![Error Trigger Intermediate Event BPMN Shape](../images/Error2.png) | | | ![Error Trigger End Event BPMN Shape](../images/Error3.png)|
| Escalation | ![Escalation Trigger Start Event BPMN Shape](../images/Esclation1.png) | ![Escalation  Trigger  Non-Interrupting  Event BPMN Shape](../images/Esclation2.png) | ![Escalation  Trigger  Intermediate  Event BPMN Shape](../images/Esclation3.png) | ![Escalation  Trigger Non-Interrupting  Event BPMN Shape](../images/Esclation4.png)| ![Escalation  Trigger  Throwing Intermediate Event  BPMN Shape](../images/Esclation5.png) |  ![Escalation  Trigger  End Event BPMN Shape](../images/Esclation6.png)|
| Termination | | | | | | ![Termination Trigger End  Event BPMN Shape](../images/Termination1.png)|
| Compensation |![Compensation  Trigger Start Event  BPMN Shape](../images/Compensation1.png)  | | ![Compensation Trigger Intermediate  Event BPMN Shape](../images/Compensation2.png) | | ![Compensation  Trigger  Throwing Intermediate Event  BPMN Shape](../images/Compensation3.png) |![Compensation  Trigger End BPMN  Event Shape](../images/Compensation4.png) |
| Cancel | | | ![Cancel Trigger Intermediate  Event BPMN Shape](../images/Cancel1.png) | | | ![Cancel Trigger End  Event BPMN Shape](../images/Cancel2.png) |
| Multiple | ![Multiple Trigger Start  Event BPMN Shape](../images/Multiple1.png) | ![Multiple Trigger Non-Interrupting  Event BPMN Shape](../images/Multiple2.png)  | ![Multiple Trigger Intermediate BPMN Shape](../images/Multiple3.png) | ![Multiple Trigger Non-Interrupting Event BPMN Shape](../images/Multiple4.png) | ![Multiple Trigger  Throwing Intermediate  Event BPMN Shape](../images/Multiple5.png)  | ![Multiple Trigger End Event  BPMN Shape](../images/Multiple6.png) |
| Parallel | ![Parallel Trigger Start  Event BPMN Shape](../images/Parallel1.png) | ![Parallel Trigger Non-Interrupting Event  BPMN Shape](../images/Parallel2.png) | ![Parallel Trigger Intermediate  Event BPMN Shape](../images/Parallel3.png) | ![Parallel Trigger End Event  BPMN Shape](../images/Parallel4.png) | | |