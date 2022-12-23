---
layout: post
title: BPMN Datasource in Blazor Diagram Component | Syncfusion
description: Learn here all about how to create the BPMN DataStore in Syncfusion Blazor Diagram component and more.
platform: Blazor
control: Diagram Component
documentation: ug
---

# BPMN DataStore in Blazor Diagram Component

DataStore is used to store or access data associated with a business process. To create a dataStore, set the Shape as **BpmnDataStore**. The following code example explains how to create a datasource.

```cshtml
@using Syncfusion.Blazor.Diagram

@* Initialize Diagram *@
<SfDiagramComponent Height="600px" Nodes="@nodes"/>

@code
{
    // Initialize the node collection with node.
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
            // Sets shape to DataStore.
            Shape = new BpmnDataStore()
        };
        nodes.Add(node);
    }
}
```

![BPMN Datasource](../images/Bpmn-DataStore.png)
