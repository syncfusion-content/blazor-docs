---
layout: post
title: BPMN gateway in Blazor Diagram Component | Syncfusion
description: Learn here all about how to create the BPMN gateway in Syncfusion Blazor Diagram component and more.
platform: Blazor
control: Diagram Component
documentation: ug
---

# BPMN gateway in Blazor Diagram Component

Gateway is used to control the flow of a process and it is represented as a diamond shape. The `GatewayType` property of the `BpmnGateway` can be set with any of the appropriate gateways. The following code example explains how to create a BPMN Gateway.

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
                GatewayType = BpmnGatewayType.None }
            }
        };
        nodes.Add(node);
    }
}
```
![GateWay BPMN Shape](../images/bpmn-gataway-none.png)

N> By default, the `GatewayType` will be set to **None**.

There are several types of gateways as follows:

| Shape | Image |
| -------- | -------- |
| None | ![GateWay BPMN Shape](../images/bpmn-gataway-none.png) |
| Exclusive | ![Exclusive GateWay BPMN Shape](../images/Exclusive.png) |
| Parallel | ![Parallel GateWay BPMN Shape](../images/Bpmn-Gateway-Parallel.png) |
| Inclusive | ![Inclusive GateWay BPMN Shape](../images/Inclusive.png) |
| Complex | ![Complex GateWay BPMN Shape](../images/Complex.png) |
| EventBased | ![EventBased GateWay BPMNShape](../images/EventBased.png) |
| ExclusiveEventBased | ![Exclusive EventBased GateWay BPMN Shape](../images/EEBased.png) |
| ParallelEventBased | ![Parallel EventBased GateWay BPMN Shape](../images/Bpmn-Gateway-ParallelEventBased.png) |
