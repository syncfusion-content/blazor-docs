---
layout: post
title: Events in Blazor Diagram Component | Syncfusion
description: Checkout and learn here all about Events in Syncfusion Blazor Diagram component and much more details.
platform: Blazor
control: Diagram Component
documentation: ug
---

# Events in Blazor Diagram Component

## Text Change

* While editing the node's or connector's annotation, this event can be used to do the customization.
* When the node's or connector's annotation is changed in the diagram, this event is getting triggered. 

The `TextChangeEventArgs` notifies when the annotation of an element undergoes editing.

The following code example shows how to register and get the notification from the TextChanged event.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px" TextChanged="OnTextChanged" Nodes="@nodes" />

@code
{
    // Defines diagram's nodes collection
    DiagramObjectCollection<Node> nodes;

    // Triggered this event when complete the editing for Annotation and update the old text and new text values.
    private void OnTextChanged(TextChangeEventArgs args)
    {
        Console.WriteLine("Oldvalue", args.OldValue);
        Console.WriteLine("NewValue", args.NewValue);
    }

    protected override void OnInitialized()
    {
        nodes = new DiagramObjectCollection<Node>();
        Node node = new Node()
        {
            Width = 100,
            Height = 100,
            OffsetX = 100,
            OffsetY = 100,
            Style = new ShapeStyle() { Fill = "#6495ED", StrokeColor = "white" },
        };
        node.Annotations = new DiagramObjectCollection<ShapeAnnotation>()
        {
            new ShapeAnnotation {Content = "Annotation" }
        };
        nodes.Add(node);
    }
}
```

## See also

* [How to add or remove annotation constraints](../constraints/#annotation-constraints)

* [How to customize the annotation](./appearance)

* [How to add annotation for Node](./node-annotation)

* [How to add annotation for Connector](./connector-annotation)
