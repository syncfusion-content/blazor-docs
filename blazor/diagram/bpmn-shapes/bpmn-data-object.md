---
layout: post
title: BPMN Data Object in Syncfusion Blazor Diagram Component | Syncfusion
description: Learn here all about how to create BPMN data object in Syncfusion Blazor Diagram component and more.
platform: Blazor
control: Diagram Component
documentation: ug
---

# BPMN Data Object in Blazor Diagram Component

A [BpmnDataObject](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.BpmnDataObject.html) represents information flowing through the process, such as data placed into the process, data resulting from the process, data that needs to be collected, or data that must be stored. To define a `BpmnDataObject`, the node property [Shape](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.Shape.html) should be set as `BpmnDataObject`, and the [DataObjectType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.BpmnDataObject.html#Syncfusion_Blazor_Diagram_BpmnDataObject_DataObjectType) property defines whether data is an input or output. You can indicate the collection of data object by setting the [IsCollectiveData](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.BpmnDataObject.html#Syncfusion_Blazor_Diagram_BpmnDataObject_IsCollectiveData) property of `BpmnDataObject` as **True.**

```cshtml
@using Syncfusion.Blazor.Diagram

@* Initialize the Diagram*@
<SfDiagramComponent Height="600px" Nodes="@_nodes" />

@code
{
    // Initialize the node collection with node.
    private DiagramObjectCollection<Node> _nodes;

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
            // Sets shape to DataObject.
            Shape = new BpmnDataObject()
            {
                IsCollectiveData = true,
                DataObjectType = BpmnDataObjectType.None
            }
        };
        _nodes.Add(node);
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BNBeiXjxVORwXwCi?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

A complete working sample can be downloaded from [GitHub](https://github.com/SyncfusionExamples/Blazor-UG-Examples/blob/master/Diagram/Server/Pages/BpmnEditor/BpmnDataObject/BpmnDataObjectSample.razor)

![ Data BPMN Shape](../images/Bpmn-DataObject-Collective-None.png)

The following table describes the different types of BPMN Data Objects.

| DataObjectType | Symbol |IsCollectiveData| Description|
| -------- | -------- |-------- | -------- |
| [None](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.BpmnDataObjectType.html#Syncfusion_Blazor_Diagram_BpmnDataObjectType_None) | ![Collection Data BPMN Shape](../images/Bpmn-DataObject-None.png) |![ Data BPMN Shape](../images/Bpmn-DataObject-Collective-None.png) |None of the business processes with the signified information collected within a DataObject|
| [Input](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.BpmnDataObjectType.html#Syncfusion_Blazor_Diagram_BpmnDataObjectType_Input) | ![Data Input BPMN Shape](../images/Bpmn-DataObject-Input.png) |![Data Input BPMN Shape](../images/Bpmn-DataObject-Collective-Input.png) |Represents the data requirements on which the tasks in the business process depend on with the signified information collected within a DataObject|
| [Output](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.BpmnDataObjectType.html#Syncfusion_Blazor_Diagram_BpmnDataObjectType_Output) | ![Data Output BPMN Shape](../images/Bpmn-DataObject-Output.png) |![Data Output BPMN Shape](../images/Bpmn-DataObject-Collective-OutPut.png) |Demonstrates information produced as the result of a business process with the signified information collected within a DataObject|
