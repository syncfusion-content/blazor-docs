---
layout: post
title: Events in Blazor Diagram Component | Syncfusion
description: Checkout and learn here all about Events in Syncfusion Blazor Diagram component and much more details.
platform: Blazor
control: Diagram Component
documentation: ug
---

# Events and Constraints in Blazor Diagram Component

## Events

Diagram provides some events support for node that triggers when interacting the node.

## Selection change

The `SelectionChange` event is triggered when select/unselect the node or connector. The `SelectionChangeEventArgs` interface is used to get selection change event arguments.

The following code example explains how to get the selection change event in the diagram.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px" Nodes="@nodes" SelectionChange="@OnSelectionChange" />

@code
{
    // To define node collection
    DiagramObjectCollection<Node> nodes;

    protected override void OnInitialized()
    {
        nodes = new DiagramObjectCollection<Node>();
        // A node is created and stored in nodes collection.
        Node node = new Node()
        {
            // Position of the node
            OffsetX = 250,
            OffsetY = 250,
            // Size of the node
            Width = 100,
            Height = 100,
            // Apperence of the node
            Style = new ShapeStyle() { Fill = "#6BA5D7", StrokeColor = "white" }
        };
        // Add node
        nodes.Add(node);
    }

    // SelectionChange event for diagram
    public void OnSelectionChange(SelectionChangeEventArgs args)
    {
        Console.WriteLine(args.NewValue.Count);
    }
}
```

## Position change

The `PositionChange` event is triggered when drag the node or connector through interaction. The `DraggingEventArgs` is used to get position change event arguments.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px" Nodes="@nodes" PositionChange="@OnPositionChange"/>

@code
{
    // To define node collection
    DiagramObjectCollection<Node> nodes;

    protected override void OnInitialized()
    {
        nodes = new DiagramObjectCollection<Node>();
        // A node is created and stored in nodes collection.
        Node node = new Node()
        {
            // Position of the node
            OffsetX = 250,
            OffsetY = 250,
            // Size of the node
            Width = 100,
            Height = 100,
            Style = new ShapeStyle() { Fill = "#6495ED", StrokeColor = "white" },
            Shape= new Shape() { Type=Shapes.Text}
        };
        // Add node
        nodes.Add(node);
    }

    // Position change event for diagram
    public void OnPositionChange(DraggingEventArgs args)
    {
        Console.WriteLine(args.NewValue.Nodes[0].ID);
    }
}
```

## Size change

The `SizeChange` event is triggered when resizing the node during the interaction. The `SizeChangeEventArgs` is used to get size change event arguments.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px" Nodes="@nodes" SizeChange="@OnSizeChange"/>

@code
{
    // To define node collection
    DiagramObjectCollection<Node> nodes;

    protected override void OnInitialized()
    {
        nodes = new DiagramObjectCollection<Node>();
        // A node is created and stored in nodes collection.
        Node node = new Node()
        {
            // Position of the node
            OffsetX = 250,
            OffsetY = 250,
            // Size of the node
            Width = 100,
            Height = 100,
            Style = new ShapeStyle() { Fill = "#6BA5D7", StrokeColor = "white" }
        };
        // Add node
        nodes.Add(node);
    }

    // Size change event for diagram
    public void OnSizeChange(SizeChangeEventArgs args)
    {
        Console.WriteLine(args.NewValue.Nodes[0].ID);
    }
}
```

## Rotate change

The `RotateChange` event is triggered when rotate the node during the interaction. The `RotationEventArgs` is used to get angle value change event arguments.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px" Nodes="@nodes" RotateChange="@OnRotateChange" />

@code
{
    // To define node collection
    DiagramObjectCollection<Node> nodes;

    protected override void OnInitialized()
    {
        nodes = new DiagramObjectCollection<Node>();
        // A node is created and stored in nodes collection.
        Node node = new Node()
        {
            // Position of the node
            OffsetX = 250,
            OffsetY = 250,
            // Size of the node
            Width = 100,
            Height = 100,
            Style = new ShapeStyle() { Fill = "#6BA5D7", StrokeColor = "white" }
        };
        // Add node
        nodes.Add(node);
    }

    // Rotate change event for diagram
    public void OnRotateChange(RotationEventArgs args)
    {
        Console.WriteLine(args.NewValue.Nodes.Count);
    }
}
```

## Constraints

The Constraints property of node allows you to enable or disable certain features. For more information about node constraints, refer to the [Node Constraints](../constraints).

## See also

* [`How to interact the node in diagram`](./interaction)

* [`How to get events when they interact the connector`](../connectors/events)

* [`How to get events when they interact the annotation`](../annotations/events)