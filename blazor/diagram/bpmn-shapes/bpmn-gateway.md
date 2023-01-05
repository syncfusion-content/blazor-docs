---
layout: post
title: BPMN Gateway in Blazor Diagram Component | Syncfusion
description: Learn here all about how to create the BPMN gateway in Syncfusion Blazor Diagram component and more.
platform: Blazor
control: Diagram Component
documentation: ug
---

# BPMN gateway in Blazor Diagram Component

A Gateway is used to control the flow of a process and it is represented in diamond shape. The [GatewayType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.BpmnGateway.html#Syncfusion_Blazor_Diagram_BpmnGateway_GatewayType) property of the [BpmnGateway](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.BpmnGateway.html) can be set with any of the appropriate gateways. By default, the value of [GatewayType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.BpmnGateway.html#Syncfusion_Blazor_Diagram_BpmnGateway_GatewayType) is **None.** The following code example explains how to create a BPMN Gateway.

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
            //Position of the node.
            OffsetX = 100,
            OffsetY = 100,
            //Size of the node.
            Width = 100,
            Height = 100,
            //Unique Id of the node.
            ID = "node1",
            Shape = new BpmnGateway()
            {
                //Sets gateway type to None.
                GatewayType = BpmnGatewayType.None 
            }
        };
        nodes.Add(node);
    }
}
```
![GateWay BPMN Shape](../images/bpmn-gataway-none.png)

N> By default, the `GatewayType` will be set to **None.**

There are several types of gateways as follows:

| Shape | Image | Description|
| -------- | -------- | -------- |
| None | ![GateWay BPMN Shape](../images/bpmn-gataway-none.png) |It is represented in diamond shape. None of the symbol shows inside this shape.|
| Exclusive | ![Exclusive GateWay BPMN Shape](../images/Exclusive.png) |It is a state of the business process and based on the condition, breaks the flow into one or more mutually exclusive paths.|
| Parallel | ![Parallel GateWay BPMN Shape](../images/Bpmn-Gateway-Parallel.png) |The parallel gateways are used to represent two concurrent tasks in a business flow.|
| Inclusive | ![Inclusive GateWay BPMN Shape](../images/Inclusive.png) |Breaks the process flow into one or more flows.|
| Complex | ![Complex GateWay BPMN Shape](../images/Complex.png) |These gateways are only used for the most complex flows in a business process.|
| EventBased | ![EventBased GateWay BPMNShape](../images/EventBased.png) |The event-based gateway allows you to make a decision based on events.|
| ExclusiveEventBased | ![Exclusive EventBased GateWay BPMN Shape](../images/EEBased.png) |Starts a new process instance with each occurrence of a subsequent event.|
| ParallelEventBased | ![Parallel EventBased GateWay BPMN Shape](../images/Bpmn-Gateway-ParallelEventBased.png) |This gateway is similar to a parallel gateway. It allows for multiple processes to happen at the same time but unlike the parallel gateway, the processes are event-dependent.|
