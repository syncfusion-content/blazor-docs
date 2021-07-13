---
layout: post
title: Events in Blazor Diagram Component | Syncfusion 
description: Learn about Events in Blazor Diagram component of Syncfusion, and more details.
platform: Blazor
control: Diagram
documentation: ug
---

# Events

Diagram provides some events support for node that triggers when interacting the node.

## Selection change

The [`SelectionChanged`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.DiagramEvents.html#Syncfusion_Blazor_Diagrams_DiagramEvents_SelectionChanged) events is triggered when select/unselect the node or connector. The [`IBlazorSelectionChangeEventArgs`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.IBlazorSelectionChangeEventArgs.html) interface is used to get selection change event arguments.

The following code example explains how to get the selection change event in the diagram.

```csharp
@using Syncfusion.Blazor.Diagrams
@using System.Collections.ObjectModel

<SfDiagram Height="600px" Nodes="@NodeCollection">
    <DiagramEvents SelectionChanged="@SelectionChanged"></DiagramEvents>
</SfDiagram>

@code{
    // To define node collection
    public ObservableCollection<DiagramNode> NodeCollection = new ObservableCollection<DiagramNode>() { };
    protected override void OnInitialized()
    {
        // A node is created and stored in nodes collection.
        DiagramNode node1 = new DiagramNode()
        {
            // Position of the node
            OffsetX = 250, OffsetY = 250,
            // Size of the node
            Width = 100, Height = 100,
            // Apperence of the node
            Style = new NodeShapeStyle() { Fill = "#6BA5D7", StrokeColor = "white" }
        };
        // Add node
        NodeCollection.Add(node1);
    }

    // SelectionChange event for diagram
    public void SelectionChanged(IBlazorSelectionChangeEventArgs args)
    {
        Console.WriteLine(args.NewValue.Nodes[0].Id);
    }
}
```

## Position change

The [`OnPositionChange`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.DiagramEvents.html#Syncfusion_Blazor_Diagrams_DiagramEvents_OnPositionChange) events is triggered when drag the node or connector in interaction. The [`IBlazorDraggingEventArgs`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.IBlazorDraggingEventArgs.html) interface is used to get position change event arguments.

```csharp
@using Syncfusion.Blazor.Diagrams
@using System.Collections.ObjectModel

<SfDiagram Height="600px" Nodes="@NodeCollection">
    <DiagramEvents OnPositionChange="@OnPositionChange"></DiagramEvents>
</SfDiagram>

@code{
    // To define node collection
    public ObservableCollection<DiagramNode> NodeCollection = new ObservableCollection<DiagramNode>() { };
    protected override void OnInitialized()
    {
        // A node is created and stored in nodes collection.
        DiagramNode node1 = new DiagramNode()
        {
            // Position of the node
            OffsetX = 250, OffsetY = 250,
            // Size of the node
            Width = 100, Height = 100,
            Style = new NodeShapeStyle() { Fill = "#6BA5D7", StrokeColor = "white" }
        };
        // Add node
        NodeCollection.Add(node1);
    }

    // Position change event for diagram
    public void OnPositionChange(IBlazorDraggingEventArgs args)
    {
        Console.WriteLine(args.NewValue.Nodes[0].Id);
    }
}
```

## Size change

The [`OnSizeChange`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.DiagramEvents.html#Syncfusion_Blazor_Diagrams_DiagramEvents_OnSizeChange) events is triggered when resizing the node during the interaction. The [`ISizeChangeEventArgs`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.ISizeChangeEventArgs.html) interface is used to get size change event arguments.

```csharp
@using Syncfusion.Blazor.Diagrams
@using System.Collections.ObjectModel

<SfDiagram Height="600px" Nodes="@NodeCollection">
    <DiagramEvents OnSizeChange="@OnSizeChange"></DiagramEvents>
</SfDiagram>

@code{
    // To define node collection
    public ObservableCollection<DiagramNode> NodeCollection = new ObservableCollection<DiagramNode>() { };
    protected override void OnInitialized()
    {
        // A node is created and stored in nodes collection.
        DiagramNode node1 = new DiagramNode()
        {
            // Position of the node
            OffsetX = 250, OffsetY = 250,
            // Size of the node
            Width = 100, Height = 100,
            Style = new NodeShapeStyle() { Fill = "#6BA5D7", StrokeColor = "white" }
        };
        // Add node
        NodeCollection.Add(node1);
    }

    // Size change event for diagram
    public void OnSizeChange(ISizeChangeEventArgs args)
    {
        Console.WriteLine(args.NewValue.Nodes[0].Id);
    }
}
```

## Rotate change

The [`OnRotateChange`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.DiagramEvents.html#Syncfusion_Blazor_Diagrams_DiagramEvents_OnRotateChange) events is triggered when resizing the node during the interaction. The [`IRotationEventArgs`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.IRotationEventArgs.html) interface is used to get size change event arguments.

```csharp
@using Syncfusion.Blazor.Diagrams
@using System.Collections.ObjectModel

<SfDiagram Height="600px" Nodes="@NodeCollection">
    <DiagramEvents OnRotateChange="@OnRotateChange"></DiagramEvents>
</SfDiagram>

@code{
    // To define node collection
    public ObservableCollection<DiagramNode> NodeCollection = new ObservableCollection<DiagramNode>() { };
    protected override void OnInitialized()
    {
        // A node is created and stored in nodes collection.
        DiagramNode node1 = new DiagramNode()
        {
            // Position of the node
            OffsetX = 250, OffsetY = 250,
            // Size of the node
            Width = 100, Height = 100,
            Style = new NodeShapeStyle() { Fill = "#6BA5D7", StrokeColor = "white" }
        };
        // Add node
        NodeCollection.Add(node1);
    }

    // Rotate change event for diagram
    public void OnRotateChange(IRotationEventArgs args)
    {
        Console.WriteLine(args.NewValue.Nodes[0].Id);
    }
}
```

## See also

* [`How to interact the node in diagram`](./interaction)

* [`How to get events when they interact the connector`](../connectors/events)

* [`How to get events when they interact the annotation`](../annotations/events)