# BPMN gateway

Gateway is used to control the flow of a process and it is represented as a diamond shape. To create a gateway, the shape property of the node should be set to “Gateway” and the `Gateway` property can be set with any of the appropriate gateways. The following code example explains how to create a BPMN Gateway.

```csharp
@using Syncfusion.Blazor.Diagram

@* Initialize Diagram *@
<SfDiagramComponent Height="600px" Nodes="@nodes">
</SfDiagramComponent>

@code{

    //Initialize the node collection with node
    DiagramObjectCollection<Node> nodes = new DiagramObjectCollection<Node>()
    {
        new Node()
        {
            //Position of the node
            OffsetX = 100, OffsetY = 100,
            //Size of the node
            Width = 100, Height = 100,
            //Unique Id of the node
            ID = "node1",
            Shape = new BpmnShape()
            {
                //Sets type to Bpmn and shape to Gateway
                Type = Shapes.Bpmn, Shape = BpmnShapes.Gateway,
                //Sets type of the gateway to None
                Gateway = new BpmnGateway(){Type = BpmnGateways.None}
            }
        }
    };
}
```

>Note: By default, the `Gateway` will be set to **None**.

There are several types of gateways as follows:

| Shape | Image |
| -------- | -------- |
| None | ![GateWay BPMN Shape](../images/bpmn-gataway-none.png) |
| Exclusive | ![Exclusive GateWay BPMN Shape](../images/Exclusive.png) |
| Parallel | ![Parallel GateWay BPMN Shape](../images/Parallel.png) |
| Inclusive | ![Inclusive GateWay BPMN Shape](../images/Inclusive.png) |
| Complex | ![Complex GateWay BPMN Shape](../images/Complex.png) |
| EventBased | ![EventBased GateWay BPMNShape](../images/EventBased.png) |
| ExclusiveEventBased | ![Exclusive EventBased GateWay BPMN Shape](../images/EEBased.png) |
| ParallelEventBased | ![Parallel EventBased GateWay BPMN Shape](../images/PEBased.png) |
